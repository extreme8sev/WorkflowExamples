#region Usings

using System;
using Workflow.Examples.Example05.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example05
{
    public class DeferSampleWorkflow : IWorkflow
    {
        #region  .ctor

        public DeferSampleWorkflow()
        {
            Id = nameof(DeferSampleWorkflow);
            Version = 1;
        }

        #endregion

        #region  Properties

        public string Id { get; }
        public int Version { get; }

        #endregion

        #region Implementation of IWorkflow<object>

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith(context =>
                    {
                        Console.WriteLine("Workflow started");
                        return ExecutionResult.Next();
                    })
                   .Then<SleepStep>()
                   .Input(step => step.Period,
                          data => TimeSpan.FromSeconds(2))
                   .Then(context =>
                    {
                        Console.WriteLine("Workflow completed");
                        return ExecutionResult.Next();
                    });
        }

        #endregion
    }
}