#region Usings

using Workflow.Examples.Example10.Steps;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example10
{
    public class WhileWorkflow : IWorkflow<MyData>
    {
        #region  .ctor

        public WhileWorkflow()
        {
            Id = nameof(WhileWorkflow);
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
                   .While(data => data.Counter < 3)
                   .Do(x => x.StartWith<DoSomething>()
                             .Then<IncrementStep>()
                             .Input(step => step.Value1,
                                    data => data.Counter)
                             .Output(data => data.Counter,
                                     step => step.Value2))
                   .Then<SayGoodbye>();
        }

        #endregion
    }
}