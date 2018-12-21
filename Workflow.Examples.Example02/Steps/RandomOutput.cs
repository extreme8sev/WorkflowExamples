#region Usings

using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example02.Steps
{
    public class RandomOutput : StepBody
    {
        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var random = new Random();
            int value = random.Next(2);
            Console.WriteLine($"Generated random value {value}");
            return ExecutionResult.Outcome(value);
        }

        #endregion
    }
}