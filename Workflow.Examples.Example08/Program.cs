#region Usings

using System;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example08
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //start the workflow host
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HumanWorkflow>();
            host.Start();


            Console.WriteLine("Starting workflow...");
            string workflowId = host.StartWorkflow("HumanWorkflow").Result;

            var timer = new Timer(state => PrintOptions(host,
                                                        workflowId),
                                  null,
                                  TimeSpan.FromSeconds(10),
                                  TimeSpan.FromSeconds(10));

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Open user actions are");
            var openItems = host.GetOpenUserActions(workflowId);
            foreach (var item in openItems)
            {
                Console.WriteLine(item.Prompt + ", Assigned to " + item.AssignedPrincipal);
                Console.WriteLine("Options are ");
                foreach (var option in item.Options)
                {
                    Console.WriteLine(" - " + option.Key + " : " + option.Value + ", ");
                }

                //Thread.Sleep(500);

                Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Choosing " + item.Options.First().Key);

                host.PublishUserAction(openItems.First().Key,
                                       @"domain\john",
                                       item.Options.First().Value)
                    .Wait();
            }

            Console.ReadLine();
            host.Stop();
        }

        private static void PrintOptions(IWorkflowHost host,
                                         string workflowId)
        {
            var openItems = host.GetOpenUserActions(workflowId);
            foreach (var item in openItems)
            {
                Console.WriteLine(item.Prompt + ", Assigned to " + item.AssignedPrincipal);
                Console.WriteLine("Options are ");
                foreach (var option in item.Options)
                {
                    Console.WriteLine(" - " + option.Key + " : " + option.Value + ", ");
                }
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        #endregion
    }
}