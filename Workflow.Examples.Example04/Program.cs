#region Usings

using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example04
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<EventSampleWorkflow, MyDataClass>();

            var initialData = new MyDataClass();

            var workflowId = host.StartWorkflow(nameof(EventSampleWorkflow),
                                                1,
                                                initialData)
                                 .Result;

            host.Start();

            Console.WriteLine("Enter value to publish");

            string value = Console.ReadLine();

            host.PublishEvent("MyEvent",
                              workflowId,
                              value);

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