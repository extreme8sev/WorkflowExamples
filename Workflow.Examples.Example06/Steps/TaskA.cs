using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Examples.Example06.Steps
{
    public class TaskA: StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine($"Doing {nameof(TaskA)}");
            return ExecutionResult.Next();
        }
    }
}