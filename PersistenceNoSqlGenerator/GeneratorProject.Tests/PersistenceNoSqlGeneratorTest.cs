using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Mobioos.Scaffold.BaseGenerators.Testing;
using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;

using GeneratorProject.Platforms.Backend.PersistenceNoSql;

namespace GeneratorProject.Tests
{
    public class PersistenceNoSqlGeneratorTest
    {
        [Fact]
        public async Task Test()
        {
            var generatorTest = new GeneratorTestBuilder()
                .InitializeContext(
                  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                  Path.Combine(
                     AppDomain.CurrentDomain.BaseDirectory,
                      "Manifest"),
                  Path.Combine(
                     Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                      "GeneratedCode"),
                        "PersistenceNoSqlGenerator")
                .AddAnswer("ModelSuffix",
                  new List<Answer>
                  {
                      new Answer
                      {
                         Name = "ModelSuffix",
                         Type = AnswerType.Text,
                         Value = "Model"
                      }
                  })

                .RegisterStep<MongoDBPromptingSteps>()
                .RegisterStep<MongoDBWritingSteps>()
                .RegisterStep<MongooseWritingSteps>()
                .Build();

            generatorTest.RegisterWorkflow<MongoDBWorkflow>("MongoDBWorkflowId");
        
            await generatorTest.Start();
        }
    }
}
