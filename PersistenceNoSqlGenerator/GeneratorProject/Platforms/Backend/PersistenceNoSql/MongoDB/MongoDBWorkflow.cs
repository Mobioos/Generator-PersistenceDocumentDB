using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    [Workflow(Id = "MongoDBWorkflowId", Order = 1)]
    public class MongoDBWorkflow : IWorkflow
    {
        public string Id => "MongoDBWorkflowId";
        public int Version => 1;
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith<MongoDBPromptingSteps>()
                .WaitFor(
                   nameof(MongoDBPromptingSteps),
                   data => nameof(MongoDBPromptingSteps))
                .Then<MongoDBWritingSteps>()
                .Then<MongooseWritingSteps>()
                .Then<WorkflowEndStepBase>();
        }
    }
}