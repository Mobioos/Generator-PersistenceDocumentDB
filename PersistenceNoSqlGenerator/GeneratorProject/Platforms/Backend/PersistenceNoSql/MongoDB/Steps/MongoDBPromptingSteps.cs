using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using WorkflowCore.Interface;
using WorkflowCore.Models;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    public class MongoDBPromptingSteps: StepBodyAsync
    {
        private readonly IPrompting _promptingService;

        public MongoDBPromptingSteps(IPrompting promptingService)
        {
            _promptingService = promptingService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var prompts = new Stack<Question>();

            prompts.Push(new Question
            {
                Name = "ModelSuffix",
                Message = "Enter suffix for model",
                Type = QuestionType.Text
            });

            await _promptingService.Prompts(nameof(MongoDBPromptingSteps), prompts, "PersistenceNoSql framework: questions for model");

            return ExecutionResult.Next();
        }
    }
}
