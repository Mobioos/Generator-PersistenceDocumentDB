﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace GeneratorProject.Platforms.Backend.PersistenceNoSql
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Mobioos.Scaffold.BaseGenerators.TextTemplating;
    using Mobioos.Scaffold.BaseGenerators.Helpers;
    using Mobioos.Foundation.Jade.Models;
    using Mobioos.Foundation.Jade.Extensions;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class MongoDBTemplate : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 2 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
var _entityInfo = (EntityInfo)Model;
            
            #line default
            #line hidden
            this.Write("db.createCollection(\"");
            
            #line 3 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(_entityInfo.Id)));
            
            #line default
            #line hidden
            this.Write("\", {\r\n    validator: {\r\n        $jsonSchema: {\r\n            bsonType: \"object\",\r\n" +
                    "");
            
            #line 7 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

    if(_entityInfo.Properties!=null && _entityInfo.Properties.Count>0)
    {

            
            #line default
            #line hidden
            this.Write("            required:[\r\n");
            
            #line 12 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

        int count = _entityInfo.Properties.Count() -1;
        int counter = 0;
        foreach(var property in _entityInfo.Properties)
        {
            if(property.IsRequired)
            {
                if(count == counter)
            {

            
            #line default
            #line hidden
            this.Write("                \"");
            
            #line 22 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id)));
            
            #line default
            #line hidden
            this.Write("\"\r\n");
            
            #line 23 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

                }else{

            
            #line default
            #line hidden
            this.Write("                \"");
            
            #line 26 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id)));
            
            #line default
            #line hidden
            this.Write("\",\r\n");
            
            #line 27 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

                }
            }
                     counter++;
        }

            
            #line default
            #line hidden
            this.Write("            ],\r\n");
            
            #line 34 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

    }

            
            #line default
            #line hidden
            
            #line 37 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

    if(_entityInfo.Properties!=null && _entityInfo.Properties.Count>0)
    {

            
            #line default
            #line hidden
            this.Write("            properties:{\r\n");
            
            #line 42 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

        int count = _entityInfo.Properties.Count() -1;
        int counter = 0;
        foreach(var property in _entityInfo.Properties)
        {

            
            #line default
            #line hidden
            
            #line 48 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
var propertyType = GetType(property.Type);
            
            #line default
            #line hidden
            this.Write("                ");
            
            #line 49 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id)));
            
            #line default
            #line hidden
            this.Write(": {\r\n                    bsonType: \"");
            
            #line 50 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyType));
            
            #line default
            #line hidden
            this.Write("\",\r\n");
            
            #line 51 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

                if(property.Minimum !=null && property.Maximum !=null)
                {
                    if(propertyType == "int")
                    {

            
            #line default
            #line hidden
            this.Write("                    minimum: ");
            
            #line 57 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Minimum));
            
            #line default
            #line hidden
            this.Write(",\r\n                    maximum: ");
            
            #line 58 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Maximum));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 59 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

                    }
                }
                if(count == counter)
                {

            
            #line default
            #line hidden
            this.Write("                }\r\n");
            
            #line 66 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

              }else{

            
            #line default
            #line hidden
            this.Write("                },\r\n");
            
            #line 70 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

                }
                     counter++;
        }

            
            #line default
            #line hidden
            this.Write("            }\r\n");
            
            #line 76 "D:\Working\Mobioos\Generators new changes\PersistenceNoSqlGenerator\PersistenceNoSqlGenerator\GeneratorProject\Platforms\Backend\PersistenceNoSql\MongoDB\Templates\MongoDBTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("        }\r\n    }\r\n})");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
