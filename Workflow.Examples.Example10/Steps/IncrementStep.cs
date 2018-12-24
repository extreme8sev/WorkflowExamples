#region Usings

using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example10.Steps
{
    public class IncrementStep : StepBody
    {
        #region  Properties

        public int Value1 { get; set; }
        public int Value2 { get; set; }

        #endregion

        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Value2 = Value1 + 1;
            return ExecutionResult.Next();
        }

        #endregion
    }
}