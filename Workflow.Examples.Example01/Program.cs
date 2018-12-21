#region Usings

using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example01
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            IServiceProvider provider = CreateServiceProvider();
            var host = provider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HelloworldWorkflow>();
            host.Start();
            host.StartWorkflow("HelloWorld");
            Console.ReadLine();
            host.Stop();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            serviceCollection.AddWorkflow();
            return serviceCollection.BuildServiceProvider();
        }

        #endregion
    }
}