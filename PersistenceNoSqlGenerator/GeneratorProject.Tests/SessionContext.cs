using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;

namespace GeneratorProject.Tests
{
    public class SessionContext : ISessionContext
    {
        public dynamic DynamicContext { get; set; }

        public string BasePath { get; set; }

        public string GeneratorPath { get; set; }

        public SmartAppInfo Manifest { get; set; }
    }
}
