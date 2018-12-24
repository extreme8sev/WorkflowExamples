#region Usings

using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example11.Steps
{
    public class PrintMessage : StepBody
    {
        #region  Properties

        public string Message { get; set; }

        #endregion

        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(Message);
            return ExecutionResult.Next();
        }

        #endregion
    }
}