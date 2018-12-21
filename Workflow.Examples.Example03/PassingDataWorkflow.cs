#region Usings

using System;
using Workflow.Examples.Example03.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example03
{
    public class PassingDataWorkflow : IWorkflow<MyDataClass>
    {
        #region  .ctor

        public PassingDataWorkflow()
        {
            Id = nameof(PassingDataWorkflow);
            Version = 1;
        }

        #endregion

        #region  Properties

        public string Id { get; }
        public int Version { get; }

        #endregion

        #region Implementation of IWorkflow<MyDataClass>

        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder.StartWith(context =>
                    {
                        Console.WriteLine("Starting workflow...");
                        return ExecutionResult.Next();
                    })
                   .Then<AddNumbers>()
                   .Input(step => step.Input1,
                          data => data.Value1)
                   .Input(step => step.Input2,
                          data => data.Value2)
                   .Output(data => data.Value3,
                           step => step.Output)
                   .Then<CustomMessage>()
                   .Name("Print cusom message")
                   .Input(step => step.Message,
                          data => "The answer is " + data.Value3)
                   .Then(context =>
                    {
                        Console.WriteLine("Workflow complete");
                        return ExecutionResult.Next();
                    });
        }

        #endregion
    }
}