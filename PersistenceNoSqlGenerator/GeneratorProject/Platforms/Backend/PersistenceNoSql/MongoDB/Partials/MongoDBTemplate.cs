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

        private string GetType(string type)
        {
            string returnType = "";
            switch (type.ToLower())
            {
                case "number":
                case "integer":
                    returnType = "int";
                    break;
                case "string":
                    returnType = "string";
                    break;
                case "date":
                    returnType = "date";
                    break;
                default:
                    returnType = type;
                    break;
            }
            return returnType;
        }

        public override string OutputPath => "src\\mongoDB\\";
    }
}
