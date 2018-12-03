using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    [WorkFlow(Id = "MongoDBWorkflowId", Order = 1)]
    public class MongoDBWorkflow : IWorkflow
    {
        public string Id => "MongoDBWorkflowId";
        public int Version => 1;

        public void Build(IWorkflowBuilder builder)
        {
            builder.StartWith<MongoDBPromptingSteps>()
                 .WaitForAnswers(nameof(MongoDBPromptingSteps))
                 .Then<MongoDBWritingSteps>()
                 .Then<MongooseWritingSteps>()
                 .Then<WorkFlowEndStepBase>();
        }
    }
}