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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CreateCommandCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"

    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 9 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.Base;\r\nusing ");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\nnamespace ");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class Create");
            
            #line 14 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command : CommandBase<Get");
            
            #line 14 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>\r\n    {\r\n        public Create");
            
            #line 16 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command(Create");
            
            #line 16 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto createDto) => CreateDto = createDto;\r\n        public Create");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\CreateCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto CreateDto { get; set; }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
