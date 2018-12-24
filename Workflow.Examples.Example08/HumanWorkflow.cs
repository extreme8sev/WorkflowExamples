#region Usings

using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example08
{
    public class HumanWorkflow : IWorkflow
    {
        #region  .ctor

        public HumanWorkflow()
        {
            Id = nameof(HumanWorkflow);
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
            builder
               .StartWith(context => ExecutionResult.Next())
               .UserTask("Do you approve",
                         data => @"domain\bob")
               .WithOption("yes",
                           "I approve")
               .Do(then => then
                      .StartWith(context => Console.WriteLine("You approved"))
                  )
               .WithOption("no",
                           "I do not approve")
               .Do(then => then
                      .StartWith(context => Console.WriteLine("You did not approve"))
                  )
               .WithEscalation(x => TimeSpan.FromSeconds(20),
                               x => @"domain\frank",
                               action => action
                                        .StartWith(context => Console.WriteLine("Escalated task"))
                                        .Then(context => Console.WriteLine("Sending notification..."))
                              )
               .Then(context => Console.WriteLine("end"));
        }

        #endregion
    }
}