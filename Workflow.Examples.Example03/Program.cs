#region Usings

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example03
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<PassingDataWorkflow, MyDataClass>();
            host.Start();

            var initialData = new MyDataClass {Value1 = 2, Value2 = 3};
            host.StartWorkflow(nameof(PassingDataWorkflow),
                               1,
                               initialData);
            host.RegisterWorkflow<PassingDataWorkflow2, Dictionary<string, int>>();

            var initialData2 = new Dictionary<string, int>
            {
                ["Value1"] = 2,
                ["Value2"] = 3
            };

            host.StartWorkflow(nameof(PassingDataWorkflow2),
                               1,
                               initialData2);

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