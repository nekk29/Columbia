﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Columbia.DslPackage.CodeGenerators
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CreateCommandValidatorCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"

    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 9 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.Base;\r\n\r\nnamespace ");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class Create");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("CommandValidator : CommandValidatorBase<Create");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command>\r\n    {\r\n        public Create");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("CommandValidator()\r\n        {\r\n            RequiredInformation(x => x.CreateDto)\r" +
                    "\n                .DependentRules(() =>\r\n                {\r\n");
            
            #line 20 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"

	foreach (var entityProperty in Entity.EntityProperties)
	{
        if (!entityProperty.Required) continue;

		var relatedEntity = DomainModel.Entities.FirstOrDefault(x => x.Name == entityProperty.Type);
		var relatedEntityKey = relatedEntity != null ? relatedEntity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey) : null;
        
		if (relatedEntityKey != null)
		{
			var foreignKey = string.IsNullOrEmpty(entityProperty.ForeignKey) ? entityProperty.Name + relatedEntityKey.Name : entityProperty.ForeignKey;

            if (relatedEntityKey.Type == "string") {

            
            #line default
            #line hidden
            this.Write("                    //RequiredString(x => x.CreateDto.");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(", {Min}, {Max});\r\n");
            
            #line 35 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"

            } else {

            
            #line default
            #line hidden
            this.Write("                    //RequiredField(x => x.CreateDto.");
            
            #line 38 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 38 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 38 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"

            }
        }
	}

            
            #line default
            #line hidden
            
            #line 44 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => !x.IsPrimaryKey))
	{
        if (!primitiveProperty.Required) continue;
        if (primitiveProperty.Type == "string") {

            
            #line default
            #line hidden
            this.Write("                    //RequiredString(x => x.CreateDto.");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(", {Min}, {Max});\r\n");
            
            #line 51 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"

        } else {

            
            #line default
            #line hidden
            this.Write("                    //RequiredField(x => x.CreateDto.");
            
            #line 54 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 54 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 54 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 55 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandValidatorCodeGenerator.tt"

        }
	}

            
            #line default
            #line hidden
            this.Write("                });\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
