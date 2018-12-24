#region Usings

using System.Collections.Generic;
using Workflow.Examples.Example09.Steps;
using WorkflowCore.Interface;

#endregion

namespace Workflow.Examples.Example09
{
    public class ForEachWorkflow : IWorkflow
    {
        #region  .ctor

        public ForEachWorkflow()
        {
            Id = nameof(ForEachWorkflow);
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
            builder.StartWith<SayHello>()
                   .ForEach(data => new List<int> {1, 2, 3, 4})
                   .Do(x => x.StartWith<DisplayContext>()
                             .Input(step => step.Item,
                                    (data,
                                     context) => context.Item)
                             .Then<DoSomething>())
                   .Then<SayGoodbye>();
        }

        #endregion
    }
}