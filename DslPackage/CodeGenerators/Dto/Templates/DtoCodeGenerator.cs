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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class DtoCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\n\r\nnamespace ");
            
            #line 8 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 8 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"

if(Entity != null)
{
	PushIndent(DefautIndent);

            
            #line default
            #line hidden
            this.Write("public class ");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto\r\n{\r\n");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"

	PushIndent(DefautIndent);

	foreach (var entityProperty in Entity.EntityProperties)
	{
		var relatedEntity = DomainModel.Entities.FirstOrDefault(x => x.Name == entityProperty.Type);
		var relatedEntityKey = relatedEntity != null ? relatedEntity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey) : null;

		if(relatedEntityKey != null)
		{

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 28 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntityKey.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 28 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityProperty.Name));
            
            #line default
            #line hidden
            
            #line 28 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntityKey.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 29 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"

		}
	}

	PopIndent();
	PushIndent(DefautIndent);

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => !x.IsPrimaryKey))
	{

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type));
            
            #line default
            #line hidden
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Nullable ? "?" : string.Empty));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; } ");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Nullable ? string.Empty : "= null!;"));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 40 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"

	}

	PopIndent();

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 46 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\DtoCodeGenerator.tt"

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
