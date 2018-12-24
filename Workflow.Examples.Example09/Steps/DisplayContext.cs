#region Usings

using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example09.Steps
{
    public class DisplayContext : StepBody
    {
        #region  Properties

        public object Item { get; set; }

        #endregion

        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine($"Working on item {Item}");
            return ExecutionResult.Next();
        }

        #endregion
    }
}