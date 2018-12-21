using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Examples.Example02.Steps
{
    public class HelloWorld : StepBody
    {
        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello World!");
            return ExecutionResult.Next();
        }

        #endregion
    }
}