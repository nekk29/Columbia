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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class MappingProfileCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using AutoMapper;\r\nusing ");
            
            #line 7 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 7 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\nnamespace ");
            
            #line 9 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Mapping.");
            
            #line 9 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Profile : Profile\r\n    {\r\n        public ");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Profile()\r\n        {\r\n            CreateMap<Entity.");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Create");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Update");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Get");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 27 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", List");
            
            #line 27 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Search");
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
