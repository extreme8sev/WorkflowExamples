using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Examples.Example06.Steps
{
    public class TaskC: StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine($"Doing {nameof(TaskC)}");
            return ExecutionResult.Next();
        }
    }
}