using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Examples.Example06.Steps
{
    public class RandomOutput: StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var random = new Random();
            var value = random.Next(2);
            Console.WriteLine($"Generated random value {value}");
            return ExecutionResult.Outcome(value);
        }
    }
}