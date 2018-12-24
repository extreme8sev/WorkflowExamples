#region Usings

using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example10
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<WhileWorkflow, MyData>();
            Console.WriteLine("Starting workflow...");
            host.Start();
            host.StartWorkflow(nameof(WhileWorkflow),
                               new MyData {Counter = 0});

            Console.ReadLine();
            host.Stop();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            serviceCollection.AddWorkflow();
            return serviceCollection.BuildServiceProvider();
        }

        #endregion
    }
}