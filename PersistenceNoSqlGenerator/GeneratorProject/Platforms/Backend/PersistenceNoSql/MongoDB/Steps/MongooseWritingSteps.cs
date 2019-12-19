using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using Mobioos.Foundation.Prompt;
using WorkflowCore.Interface;
using WorkflowCore.Models;

using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    public class MongooseWritingSteps : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public MongooseWritingSteps(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
        {
            _context = context;
            _writingService = writingService;
            _workflowNotifier = workflowNotifier;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            SmartAppInfo smartApp = _context.Manifest;

            _workflowNotifier.Notify(nameof(MongooseWritingSteps), NotificationType.GeneralInfo, "Generating PersistenceNoSql Mongoose");

            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                TransformModels(smartApp);

            }
            return Task.FromResult(ExecutionResult.Next());
        }

        private void TransformModels(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.DataModel != null && smartApp.DataModel.Entities != null && smartApp.DataModel.Entities.Count > 0)
            {
                string modelSuffix = GetModelSuffix();

                foreach (var dataModel in smartApp.DataModel.Entities)
                {
                    if (!dataModel.IsAbstract)
                    {
                        MongooseTemplate template = new MongooseTemplate(dataModel, modelSuffix);
                        _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath, (dataModel.Id.ToPascalCase() + modelSuffix + ".js")), template.TransformText());
                    }
                    
                }
            }
        }

        private string GetModelSuffix()
        {
            var modelSuffix = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("ModelSuffix") ? _context.DynamicContext.ModelSuffix as List<Answer> : new List<Answer>();
            return (modelSuffix != null && modelSuffix.Count > 0) ? modelSuffix.FirstOrDefault().Value : "Model";
        }
    }
}
