using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    public partial class MongoDBTemplate: TemplateBase
    {
       private string _modelSuffix { get; set; }

        public MongoDBTemplate(EntityInfo entityInfo, string modelSuffix) : base(entityInfo)
        {
         _modelSuffix = modelSuffix;
        }
        
        public override string OutputPath => "src\\mongoDB\\";
    }
}
