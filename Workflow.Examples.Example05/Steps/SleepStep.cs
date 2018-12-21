#region Usings

using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example05.Steps
{
    public class SleepStep : StepBody
    {
        #region  Properties

        public TimeSpan Period { get; set; }

        #endregion

        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context) => context.PersistenceData == null
                                                                                  ? ExecutionResult.Sleep(Period,
                                                                                                          new object())
                                                                                  : ExecutionResult.Next();

        #endregion
    }
}