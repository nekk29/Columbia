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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class GetQueryCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using ");
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Queries.Base;\r\nusing ");
            
            #line 7 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 7 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 8 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"

	var keyProperty = Entity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey);

            
            #line default
            #line hidden
            this.Write("namespace ");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Queries.");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class Get");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Query : QueryBase<Get");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>\r\n    {\r\n");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"

	if (keyProperty != null)
    {

            
            #line default
            #line hidden
            this.Write("        public Get");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Query(");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(") => ");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(keyProperty.Name)));
            
            #line default
            #line hidden
            this.Write(";\r\n        public ");
            
            #line 20 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Type));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 20 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\GetQueryCodeGenerator.tt"

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
