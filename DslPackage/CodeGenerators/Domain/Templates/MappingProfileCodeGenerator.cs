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
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"

    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;

            
            #line default
            #line hidden
            this.Write("using AutoMapper;\r\nusing ");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\nnamespace ");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Mapping\r\n{\r\n    public class ");
            
            #line 14 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Profile : Profile\r\n    {\r\n        public ");
            
            #line 16 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Profile()\r\n        {\r\n            CreateMap<Entity.");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 18 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Create");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Update");
            
            #line 24 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 27 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Get");
            
            #line 27 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", List");
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>()\r\n                .ReverseMap();\r\n\r\n            CreateMap<Entity.");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", Search");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\MappingProfileCodeGenerator.tt"
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
