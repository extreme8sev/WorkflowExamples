#region Usings

using Workflow.Examples.Example02.Steps;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example02
{
    public class SimpleDecisionWorkflow : IWorkflow
    {
        #region  .ctor

        public SimpleDecisionWorkflow()
        {
            Id = nameof(SimpleDecisionWorkflow);
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
            builder
               .StartWith<HelloWorld>()
               .Then<RandomOutput>(randomOutput =>
                {
                    randomOutput
                       .When(0)
                       .Then<CustomMessage>(cm =>
                        {
                            cm.Name("Print custom message");
                            cm.Input(step => step.Message,
                                     data => "Looping back....");
                        })
                       .Then(randomOutput); //loop back to randomOutput

                    randomOutput
                       .When(1)
                       .Then<GoodbyeWorld>();
                });
        }

        #endregion
    }
}