#region Usings

using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example11
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<IfWorkflow, MyData>();
            host.Start();
            Console.WriteLine("Starting workflow...");
            host.StartWorkflow(nameof(IfWorkflow),
                               new MyData {Counter = 4});
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