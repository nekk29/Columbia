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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ControllerCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"

    var entitySuffix = !string.IsNullOrEmpty(Entity.Module) && Entity.Module != Entity.Name ? Entity.Name : string.Empty;
    var entitySuffixAct = !string.IsNullOrEmpty(entitySuffix) ? LowerFirst(entitySuffix) + "/" : string.Empty;
    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;
	var keyProperty = Entity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey);

            
            #line default
            #line hidden
            this.Write("using Microsoft.AspNetCore.Mvc;\r\nusing ");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.ApplicationAbstractions));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 14 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing ");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 15 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\nnamespace ");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Apis));
            
            #line default
            #line hidden
            this.Write(".Controllers\r\n{\r\n    [ApiController]\r\n    [Route(\"api/");
            
            #line 20 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("\")]\r\n    public class ");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Controller\r\n    {\r\n        private readonly I");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Application _");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application;\r\n\r\n        public ");
            
            #line 25 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Controller(I");
            
            #line 25 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Application ");
            
            #line 25 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application)\r\n            => _");
            
            #line 26 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application = ");
            
            #line 26 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application;\r\n\r\n        [HttpPost");
            
            #line 28 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.IsNullOrEmpty(entitySuffix) ? string.Empty : "(\"" + LowerFirst(entitySuffix) + "\")"));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<Get");
            
            #line 29 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>> Create");
            
            #line 29 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(Create");
            
            #line 29 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto createDto)\r\n            => await _");
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application.Create");
            
            #line 30 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(createDto);\r\n\r\n        [HttpPut");
            
            #line 32 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.IsNullOrEmpty(entitySuffix) ? string.Empty : "(\"" + LowerFirst(entitySuffix) + "\")"));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<Get");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>> Update");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(Update");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto updateDto)\r\n            => await _");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application.Update");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(updateDto);\r\n\r\n        [HttpDelete");
            
            #line 36 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty != null ? "(\"" + entitySuffixAct + "{" + LowerFirst(keyProperty.Name) + "}\")" : (!string.IsNullOrEmpty(entitySuffix) ? "(\"" + entitySuffix +"\")" : string.Empty)));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto> Delete");
            
            #line 37 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 37 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty != null ? keyProperty.Type + " " + LowerFirst(keyProperty.Name) : string.Empty));
            
            #line default
            #line hidden
            this.Write(")\r\n            => await _");
            
            #line 38 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application.Delete");
            
            #line 38 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 38 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty != null ? LowerFirst(keyProperty.Name) : string.Empty));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n        [HttpGet");
            
            #line 40 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty != null ? "(\"" + entitySuffixAct + "{" + LowerFirst(keyProperty.Name) + "}\")" : (!string.IsNullOrEmpty(entitySuffix) ? "(\"" + entitySuffix +"\")" : string.Empty)));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<Get");
            
            #line 41 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>> Get");
            
            #line 41 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 41 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty != null ? keyProperty.Type + " " + LowerFirst(keyProperty.Name) : string.Empty));
            
            #line default
            #line hidden
            this.Write(")\r\n            => await _");
            
            #line 42 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application.Get");
            
            #line 42 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 42 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty != null ? LowerFirst(keyProperty.Name) : string.Empty));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n        [HttpGet(\"");
            
            #line 44 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffixAct));
            
            #line default
            #line hidden
            this.Write("list\")]\r\n        public async Task<ResponseDto<IEnumerable<List");
            
            #line 45 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>>> List");
            
            #line 45 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("()\r\n            => await _");
            
            #line 46 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application.List");
            
            #line 46 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("();\r\n\r\n        [HttpPost(\"");
            
            #line 48 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffixAct));
            
            #line default
            #line hidden
            this.Write("search\")]\r\n        public async Task<ResponseDto<SearchResultDto<Search");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>>> Search");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(SearchParamsDto<Search");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("FilterDto> searchParams)\r\n            => await _");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(module)));
            
            #line default
            #line hidden
            this.Write("Application.Search");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(searchParams);\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
