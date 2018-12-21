#region Usings

using WorkflowCore.Interface;
using WorkflowCore.Models;

#endregion

namespace Workflow.Examples.Example03.Steps
{
    public class AddNumbers : StepBody
    {
        #region  Properties

        public int Input1 { get; set; }
        public int Input2 { get; set; }
        public int Output { get; set; }

        #endregion

        #region  Public Methods

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Output = Input1 + Input2;
            return ExecutionResult.Next();
        }

        #endregion
    }
}