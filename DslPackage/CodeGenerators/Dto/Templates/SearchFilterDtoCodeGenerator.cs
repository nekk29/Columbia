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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class SearchFilterDtoCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\n\r\nnamespace ");
            
            #line 8 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 8 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"

if (Entity != null)
{
	PushIndent(DefautIndent);

            
            #line default
            #line hidden
            this.Write("public class Search");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("FilterDto\r\n{\r\n");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"

	PushIndent(DefautIndent);

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => x.IsPrimaryKey))
	{

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type));
            
            #line default
            #line hidden
            this.Write("? ");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; } = null!;\r\n");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"

	}

	PopIndent();

            
            #line default
            #line hidden
            
            #line 29 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"

	PushIndent(DefautIndent);

	foreach (var entityProperty in Entity.EntityProperties)
	{
		var relatedEntity = DomainModel.Entities.FirstOrDefault(x => x.Name == entityProperty.Type);
		var relatedEntityKey = relatedEntity != null ? relatedEntity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey) : null;

		if (relatedEntityKey != null)
		{
			var foreignKey = string.IsNullOrEmpty(entityProperty.ForeignKey) ? entityProperty.Name + relatedEntityKey.Name : entityProperty.ForeignKey;

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 41 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntityKey.Type));
            
            #line default
            #line hidden
            this.Write("? ");
            
            #line 41 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(" { get; set; } = null!;\r\n");
            
            #line 42 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"

		}
	}

	PopIndent();
	PushIndent(DefautIndent);

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => !x.IsPrimaryKey))
	{

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type));
            
            #line default
            #line hidden
            this.Write("? ");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; } = null!;\r\n");
            
            #line 53 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"

	}

	PopIndent();

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 59 "D:\Projects\Columbia\DslPackage\CodeGenerators\Dto\Templates\SearchFilterDtoCodeGenerator.tt"

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
