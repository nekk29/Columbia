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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class UpdateDtoCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"

    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;

            
            #line default
            #line hidden
            this.Write("using System;\r\n\r\nnamespace ");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"

if (Entity != null)
{
	PushIndent(DefautIndent);

            
            #line default
            #line hidden
            this.Write("public class Update");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto : ");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto\r\n{\r\n");
            
            #line 20 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"

	PushIndent(DefautIndent);

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => x.IsPrimaryKey))
	{

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 26 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 26 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }");
            
            #line 26 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type == "string" ? " = null!;" : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 27 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"

	}

	PopIndent();

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\UpdateDtoCodeGenerator.tt"

}

ClearIndent();

            
            #line default
            #line hidden
            this.Write("}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
