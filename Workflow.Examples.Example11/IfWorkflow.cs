#region Usings

using Workflow.Examples.Example11.Steps;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example11
{
    public class IfWorkflow : IWorkflow<MyData>
    {
        #region  .ctor

        public IfWorkflow()
        {
            Id = nameof(IfWorkflow);
            Version = 1;
        }

        #endregion

        #region  Properties

        public string Id { get; }
        public int Version { get; }

        #endregion

        #region Implementation of IWorkflow<MyData>

        public void Build(IWorkflowBuilder<MyData> builder)
        {
            builder.StartWith<SayHello>()
                   .If(data => data.Counter < 3)
                   .Do(then => then.StartWith<PrintMessage>()
                                   .Input(step => step.Message,
                                          data => "Value is less than 3"))
                   .If(data => data.Counter < 5)
                   .Do(then => then.StartWith<PrintMessage>()
                                   .Input(step => step.Message,
                                          data => "Value is less than 5"))
                   .Then<SayGoodbye>();
        }

        #endregion
    }
}