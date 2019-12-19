using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    public partial class MongooseTemplate : TemplateBase
    {
        private string _modelSuffix { get; set; }

        public MongooseTemplate(EntityInfo entityInfo, string modelSuffix) : base(entityInfo)
        {
            _modelSuffix = modelSuffix;
        }

       public override string OutputPath => "src\\mongoose\\";
    }
}
