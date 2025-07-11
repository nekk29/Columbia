﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Columbia.DslPackage
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class UpdateCommandValidatorCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;
	var keyProperty = Entity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey);

            
            #line default
            #line hidden
            this.Write("using FluentValidation;\r\nusing Microsoft.EntityFrameworkCore;\r\nusing ");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.Base;\r\nusing ");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.RepositoryAbstractions));
            
            #line default
            #line hidden
            this.Write(".Base;\r\n\r\nnamespace ");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class Update");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("CommandValidator : CommandValidatorBase<Update");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command>\r\n    {\r\n        private readonly IRepository<Entity.");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("> _");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n\r\n        public Update");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("CommandValidator(IRepository<Entity.");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository)\r\n        {\r\n            _");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository = ");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n\r\n            RequiredInformation(x => x.UpdateDto)\r\n               " +
                    " .DependentRules(() => {\r\n");
            
            #line 27 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    if(!Entity.EntityProperties.Any() && !Entity.PrimitiveProperties.Where(x => !x.IsPrimaryKey).Any())
    {

            
            #line default
            #line hidden
            this.Write("                    /* Place your validations here... */\r\n");
            
            #line 32 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    }

            
            #line default
            #line hidden
            
            #line 35 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    if (keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("                    //RequiredField(x => x.UpdateDto.");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(", Resources.Common.IdentifierRequired);\r\n");
            
            #line 40 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    }

            
            #line default
            #line hidden
            
            #line 43 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

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
            this.Write("                    //RequiredString(x => x.UpdateDto.");
            
            #line 57 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 57 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 57 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(", {Min}, {Max});\r\n");
            
            #line 58 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

            } else {

            
            #line default
            #line hidden
            this.Write("                    //RequiredField(x => x.UpdateDto.");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 62 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

            }
        }
	}

            
            #line default
            #line hidden
            
            #line 67 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => !x.IsPrimaryKey))
	{
        if (!primitiveProperty.Required) continue;
        if (primitiveProperty.Type == "string") {

            
            #line default
            #line hidden
            this.Write("                    //RequiredString(x => x.UpdateDto.");
            
            #line 73 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 73 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 73 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(", {Min}, {Max});\r\n");
            
            #line 74 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

        } else {

            
            #line default
            #line hidden
            this.Write("                    //RequiredField(x => x.UpdateDto.");
            
            #line 77 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(", Resources.");
            
            #line 77 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 77 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 78 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

        }
	}

            
            #line default
            #line hidden
            
            #line 82 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    if (keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("                }).DependentRules(() =>\r\n                {\r\n                    R" +
                    "uleFor(x => x.UpdateDto.");
            
            #line 88 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n                        .MustAsync(ValidateExistenceAsync)\r\n                  " +
                    "      .WithCustomValidationMessage();\r\n                });\r\n        }\r\n\r\n");
            
            #line 94 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    }
    else
    {

            
            #line default
            #line hidden
            this.Write("\r\n                });\r\n        }\r\n");
            
            #line 102 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    }

            
            #line default
            #line hidden
            
            #line 105 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    if (keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("\r\n        protected async Task<bool> ValidateExistenceAsync(Update");
            
            #line 110 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command command, ");
            
            #line 110 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 110 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(", ValidationContext<Update");
            
            #line 110 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command> context, CancellationToken cancellationToken)\r\n        {\r\n            va" +
                    "r exists = await _");
            
            #line 112 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository.FindAll().Where(x => x.");
            
            #line 112 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(" == ");
            
            #line 112 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(").AnyAsync(cancellationToken);\r\n            if (!exists) return CustomValidationM" +
                    "essage(context, Resources.Common.UpdateRecordNotFound);\r\n            return true" +
                    ";\r\n        }\r\n");
            
            #line 116 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\UpdateCommandValidatorCodeGenerator.tt"

    }

            
            #line default
            #line hidden
            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
