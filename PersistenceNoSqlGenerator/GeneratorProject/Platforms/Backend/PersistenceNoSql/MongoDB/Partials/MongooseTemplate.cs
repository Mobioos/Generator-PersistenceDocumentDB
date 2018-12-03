using Mobioos.Foundation.Jade.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Linq;

namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    public partial class MongooseTemplate : TemplateBase
    {
        private string _modelSuffix { get; set; }

        public MongooseTemplate(EntityInfo entityInfo, string modelSuffix) : base(entityInfo)
        {
            _modelSuffix = modelSuffix;
        }

        private string GetPropertyType(string type)
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

        public override string OutputPath => "src\\mongoose\\";
    }
}
