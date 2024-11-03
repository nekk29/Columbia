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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class DeleteCommandCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"

    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;
	var keyProperty = Entity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey);

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.Base;\r\n\r\nnamespace ");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Commands.");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 14 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"

	if (keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("    public class Delete");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command(");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(") : CommandBase\r\n    {\r\n");
            
            #line 20 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"

	}
    else
    {

            
            #line default
            #line hidden
            this.Write("    public class Delete");
            
            #line 25 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Command : CommandBase\r\n    {\r\n");
            
            #line 27 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"

    }

            
            #line default
            #line hidden
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"

	if (keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; } = ");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 35 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\DeleteCommandCodeGenerator.tt"

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
