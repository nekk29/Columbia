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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class DeleteCommandValidatorCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using FluentValidation;\r\nusing Microsoft.EntityFrameworkCore;\r\nusing ");
            
            #line 8 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.Base;\r\nusing ");
            
            #line 9 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.RepositoryAbstractions));
            
            #line default
            #line hidden
            this.Write(".Base;\r\n");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"

	var keyProperty = Entity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey);

            
            #line default
            #line hidden
            this.Write("namespace ");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class Delete");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("CommandValidator : CommandValidatorBase<Delete");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command>\r\n    {\r\n        private readonly IRepository<Entity.");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("> _");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n\r\n        public Delete");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("CommandValidator(IRepository<Entity.");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository)\r\n        {\r\n            _");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository = ");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n\r\n            RequiredField(x => x.");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(", Resources.Common.IdentifierRequired)\r\n                .DependentRules(() =>\r\n  " +
                    "              {\r\n");
            
            #line 26 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"

    if(keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("                    RuleFor(x => x.");
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n                        .MustAsync(ValidateExistenceAsync)\r\n                  " +
                    "      .WithCustomValidationMessage();\r\n");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"

    }
    else
    {

            
            #line default
            #line hidden
            this.Write("                    /* Place your validations here... */\r\n");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"

    }

            
            #line default
            #line hidden
            this.Write("                });\r\n        }\r\n");
            
            #line 44 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"

    if(keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("\r\n        protected async Task<bool> ValidateExistenceAsync(Delete");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command command, ");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(", ValidationContext<Delete");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command> context, CancellationToken cancellationToken)\r\n        {\r\n            va" +
                    "r exists = await _");
            
            #line 51 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository.FindAll().Where(x => x.");
            
            #line 51 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(" == ");
            
            #line 51 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(").AnyAsync(cancellationToken);\r\n            if (!exists) return CustomValidationM" +
                    "essage(context, Resources.Common.DeleteRecordNotFound);\r\n            return true" +
                    ";\r\n        }\r\n");
            
            #line 55 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandValidatorCodeGenerator.tt"

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
