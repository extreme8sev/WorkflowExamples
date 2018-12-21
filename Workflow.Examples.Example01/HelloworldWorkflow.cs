#region Usings

using Workflow.Examples.Example01.Steps;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example01
{
    public class HelloworldWorkflow : IWorkflow
    {
        #region  .ctor

        public HelloworldWorkflow()
        {
            Id = "HelloWorld";
            Version = 1;
        }

        #endregion

        #region  Properties

        public string Id { get; }
        public int Version { get; }

        #endregion

        #region Implementation of IWorkflow<object>

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith<HelloWorld>().Then<GoodbyeWorld>();
        }

        #endregion
    }
}