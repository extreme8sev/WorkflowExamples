using System;
using Workflow.Examples.Example06.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Examples.Example06
{
    public class MultipleOutcomeWorkflow : IWorkflow
    {
        #region  .ctor

        public MultipleOutcomeWorkflow()
        {
            Id = nameof(MultipleOutcomeWorkflow);
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
                        Console.WriteLine("Workflow started...");
                        return ExecutionResult.Next();
                    })
                   .Then<RandomOutput>(randomOutput =>
                    {
                        randomOutput
                           .When(_ => 0)
                           .Do(then => then
                                      .StartWith<TaskA>()
                                      .Then<TaskB>());
                        randomOutput
                           .When(_ => 1)
                           .Do(then => then.StartWith<TaskC>().Then<TaskD>());
                    });
        }

        #endregion
    }
}