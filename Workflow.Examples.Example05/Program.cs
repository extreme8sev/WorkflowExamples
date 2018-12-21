#region Usings

using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example05
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<DeferSampleWorkflow>();
            host.Start();
            host.StartWorkflow(nameof(DeferSampleWorkflow),1, null, null);
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