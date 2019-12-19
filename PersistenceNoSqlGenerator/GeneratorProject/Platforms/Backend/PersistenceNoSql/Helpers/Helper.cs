namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    public static class Helper
    {
        public static string GetType(string type)
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

        public static bool IsModelBool(string type)
        {
            bool result = false;
            switch (type.ToLower())
            {
                case "date": break;
                case "integer": break;
                case "string": break;
                case "number": break;
                case "boolean": break;
                default: result = true; break;
            }
            return result;
        }
    }
}
