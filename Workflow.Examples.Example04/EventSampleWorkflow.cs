#region Usings

using System;
using Workflow.Examples.Example04.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example04
{
    public class EventSampleWorkflow : IWorkflow<MyDataClass>
    {
        #region  .ctor

        public EventSampleWorkflow()
        {
            Id = nameof(EventSampleWorkflow);
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
            builder
               .StartWith(context => ExecutionResult.Next())
               .WaitFor("MyEvent",
                        (data,
                         context) => context.Workflow.Id,
                        data => DateTime.Now)
               .Output(data => data.StrData,
                       step => step.EventData)
               .Then<CustomMessage>()
               .Input(step => step.Message,
                      data => $"The data from the event is {data.StrData}")
               .Then(context => Console.WriteLine("Workflow complete"));
        }

        #endregion
    }
}