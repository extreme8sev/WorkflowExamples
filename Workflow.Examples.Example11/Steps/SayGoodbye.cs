﻿#region Usings

using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example11.Steps
{
    public class SayGoodbye : StepBody
    {
        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Goodbye!");
            return ExecutionResult.Next();
        }

        #endregion
    }
}