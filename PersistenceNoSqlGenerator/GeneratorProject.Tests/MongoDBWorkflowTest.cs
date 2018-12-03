using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Unity;
using Xunit;

using GeneratorProject.Platforms.Backend.PersistenceNoSql;

namespace GeneratorProject.Tests
{
    public class MongoDBWorkflowTest : BaseGeneratorTest, IDisposable
    {
        public MongoDBWorkflowTest() : base()
        {
            _workflowHost.RegisterWorkflow<MongoDBWorkflow>();
            _container.RegisterType<MongoDBWritingSteps>();
            _container.RegisterType<MongooseWritingSteps>();
            _workflowHost.Start();
        }

        [Fact]
        public async Task Execute()
        {
            var answers = new List<Answer>();
            answers.Add(new Answer()
            {
                Name = "ModelSuffix",
                Type = AnswerType.Text,
                Value = "Model"
            });

            ((IDictionary<string, object>)_context.DynamicContext).Add("ModelSuffix", answers);

            string workflowId = await _workflowHost.StartWorkflow("MongoDBWorkflowId", 1);
            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(30));
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
