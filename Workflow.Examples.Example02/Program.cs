#region Usings

using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example02
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<SimpleDecisionWorkflow>();
            host.Start();
            host.StartWorkflow(nameof(SimpleDecisionWorkflow));
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