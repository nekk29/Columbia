﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Columbia.DslPackage.CodeGenerators.Dto
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class SearchDtoCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\n\r\nnamespace ");
            
            #line 9 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"

if(Entity != null)
{
	PushIndent(DefautIndent);

            
            #line default
            #line hidden
            this.Write("public class Update");
            
            #line 16 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto : ");
            
            #line 16 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto\r\n{\r\n");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"

	PushIndent(DefautIndent);

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => x.IsPrimaryKey))
	{

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 25 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"

	}

	PopIndent();

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 31 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\SearchDtoCodeGenerator.tt"

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
