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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class EntityCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.ComponentModel.Dat" +
                    "aAnnotations;\r\nusing System.ComponentModel.DataAnnotations.Schema;\r\n");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

if (Entity.IsAuditable)
{

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 14 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Entity));
            
            #line default
            #line hidden
            this.Write(".Base;\r\n");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

}

            
            #line default
            #line hidden
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

var relatedEntities = DomainModel.Entities.Where(x => x.EntityProperties.Any(p => p.Type == Entity.Name));

            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 22 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Entity));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

if (Entity != null)
{

            
            #line default
            #line hidden
            
            #line 28 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

	PushIndent(DefautIndent);

            
            #line default
            #line hidden
            this.Write("[Table(\"");
            
            #line 31 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.IsNullOrEmpty(Entity.TableName) ? Entity.Name : Entity.TableName));
            
            #line default
            #line hidden
            this.Write("\")]\r\npublic class ");
            
            #line 32 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            
            #line 32 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.IsAuditable ? " : SystemEntity" : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

	if (relatedEntities.Any())
	{
		PushIndent(DefautIndent);

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("()\r\n{\r\n");
            
            #line 41 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

		PushIndent(DefautIndent);

		foreach(var relatedEntity in relatedEntities)
		{

            
            #line default
            #line hidden
            
            #line 47 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntity.Name));
            
            #line default
            #line hidden
            this.Write("s = new HashSet<");
            
            #line 47 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntity.Name));
            
            #line default
            #line hidden
            this.Write(">();\r\n");
            
            #line 48 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

		}

		PopIndent();

            
            #line default
            #line hidden
            this.Write("}\r\n\r\n");
            
            #line 55 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
	
		PopIndent();
	}
	
	PushIndent(DefautIndent);

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => x.IsPrimaryKey))
	{
		if(!string.IsNullOrEmpty(primitiveProperty.Column))
		{

            
            #line default
            #line hidden
            this.Write("[Column(\"");
            
            #line 66 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Column));
            
            #line default
            #line hidden
            this.Write("\")]\r\n");
            
            #line 67 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
	
		}

            
            #line default
            #line hidden
            this.Write("[Key]\r\npublic ");
            
            #line 71 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 71 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }");
            
            #line 71 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type == "string" ? " = null!;" : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 72 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

	}

	PopIndent();

            
            #line default
            #line hidden
            
            #line 77 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

	PushIndent(DefautIndent);

	foreach (var entityProperty in Entity.EntityProperties)
	{
		var relatedEntity = DomainModel.Entities.FirstOrDefault(x => x.Name == entityProperty.Type);
		var relatedEntityKey = relatedEntity != null ? relatedEntity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey) : null;

            
            #line default
            #line hidden
            
            #line 85 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

		if (relatedEntityKey != null)
		{
			var foreignKey = string.IsNullOrEmpty(entityProperty.ForeignKey) ? entityProperty.Name + relatedEntityKey.Name : entityProperty.ForeignKey;

            
            #line default
            #line hidden
            this.Write("[ForeignKey(\"");
            
            #line 90 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write("\")]\r\npublic virtual ");
            
            #line 91 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityProperty.Type));
            
            #line default
            #line hidden
            
            #line 91 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityProperty.Required ? string.Empty : "?"));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 91 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; } = null!;\r\npublic ");
            
            #line 92 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntityKey.Type));
            
            #line default
            #line hidden
            
            #line 92 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityProperty.Required ? string.Empty : "?"));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 92 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey));
            
            #line default
            #line hidden
            this.Write(" { get; set; }");
            
            #line 92 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityProperty.Required ? (relatedEntityKey.Type == "string" ? " = null!;" : string.Empty) : " = null!;"));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 93 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

		}

            
            #line default
            #line hidden
            
            #line 96 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

	}

	PopIndent();

            
            #line default
            #line hidden
            
            #line 101 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

	PushIndent(DefautIndent);

	foreach (var primitiveProperty in Entity.PrimitiveProperties.Where(x => !x.IsPrimaryKey))
	{
		if(!string.IsNullOrEmpty(primitiveProperty.Column))
		{

            
            #line default
            #line hidden
            this.Write("[Column(\"");
            
            #line 109 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Column));
            
            #line default
            #line hidden
            this.Write("\")]\r\n");
            
            #line 110 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
	
		}

            
            #line default
            #line hidden
            this.Write("public ");
            
            #line 113 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Type));
            
            #line default
            #line hidden
            
            #line 113 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Required ? string.Empty : "?"));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 113 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }");
            
            #line 113 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(primitiveProperty.Required ? (primitiveProperty.Type == "string" ? " = null!;" : string.Empty) : " = null!;"));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 114 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

	}

	PopIndent();

	if (relatedEntities.Any())
	{

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 123 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

		PushIndent(DefautIndent);

		foreach(var relatedEntity in relatedEntities)
		{

            
            #line default
            #line hidden
            this.Write("public virtual ICollection<");
            
            #line 129 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntity.Name));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 129 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relatedEntity.Name));
            
            #line default
            #line hidden
            this.Write("s { get; set; }\r\n");
            
            #line 130 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

		}

		PopIndent();
	}

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 137 "D:\Projects\Columbia\DslPackage\CodeGenerators\Entity\Templates\EntityCodeGenerator.tt"

ClearIndent();
}

            
            #line default
            #line hidden
            this.Write("}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
