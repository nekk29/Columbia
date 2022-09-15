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

    var entity = Entity.Name;
    var entityLower = LowerFirst(entity);
    var entityModule = Entity.Module;
    
    var module = !string.IsNullOrEmpty(entityModule) && entityModule.ToLower() != entity.ToLower()  ? entityModule : entity;
    var moduleLower = LowerFirst(module);

    var entitySuffix = !string.IsNullOrEmpty(entityModule) && entityModule.ToLower() != entity.ToLower() ? entity : string.Empty;
    var entitySuffixLower = LowerFirst(entitySuffix);

	var keyProperty = Entity.PrimitiveProperties.FirstOrDefault(x => x.IsPrimaryKey);
	var keyPropertyParam = keyProperty != null ? LowerFirst(keyProperty.Name) : string.Empty;
	var keyPropertyParamIn = keyProperty != null ? $"{keyProperty.Type} {LowerFirst(keyProperty.Name)}" : string.Empty;
	var keyPropertyParamRoute = keyProperty != null ? "{" + LowerFirst(keyProperty.Name) + "}" : string.Empty;

    var createRoute = string.IsNullOrEmpty(entitySuffixLower) ? string.Empty : $"(\"{entitySuffixLower}\")";
    var updateRoute = createRoute;
    var deleteRoute = string.IsNullOrEmpty(entitySuffixLower) ?
        (!string.IsNullOrEmpty(keyPropertyParamRoute) ? $"(\"{keyPropertyParamRoute}\")" : string.Empty) :
        (!string.IsNullOrEmpty(keyPropertyParamRoute) ? $"(\"{entitySuffixLower}/{keyPropertyParamRoute}\")" : $"(\"{entitySuffixLower}\")");
    var getRoute = deleteRoute;
    var listRoute = string.IsNullOrEmpty(entitySuffixLower) ? $"(\"list\")" : $"(\"{entitySuffixLower}/list\")";
    var searchRoute = string.IsNullOrEmpty(entitySuffixLower) ? $"(\"search\")" : $"(\"{entitySuffixLower}/search\")";

            
            #line default
            #line hidden
            this.Write("using Microsoft.AspNetCore.Mvc;\r\nusing ");
            
            #line 32 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.ApplicationAbstractions));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing ");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 34 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\nnamespace ");
            
            #line 36 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Apis));
            
            #line default
            #line hidden
            this.Write(".Controllers\r\n{\r\n    [ApiController]\r\n    [Route(\"api/");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("\")]\r\n    public class ");
            
            #line 40 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Controller\r\n    {\r\n        private readonly I");
            
            #line 42 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Application _");
            
            #line 42 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application;\r\n\r\n        public ");
            
            #line 44 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Controller(I");
            
            #line 44 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("Application ");
            
            #line 44 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application)\r\n            => _");
            
            #line 45 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application = ");
            
            #line 45 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application;\r\n\r\n        [HttpPost");
            
            #line 47 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(createRoute));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<Get");
            
            #line 48 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>> Create");
            
            #line 48 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(Create");
            
            #line 48 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto createDto)\r\n            => await _");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application.Create");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(createDto);\r\n\r\n        [HttpPut");
            
            #line 51 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(updateRoute));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<Get");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>> Update");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(Update");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto updateDto)\r\n            => await _");
            
            #line 53 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application.Update");
            
            #line 53 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(updateDto);\r\n\r\n        [HttpDelete");
            
            #line 55 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(deleteRoute));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto> Delete");
            
            #line 56 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 56 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyPropertyParamIn));
            
            #line default
            #line hidden
            this.Write(")\r\n            => await _");
            
            #line 57 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application.Delete");
            
            #line 57 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 57 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyPropertyParam));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n        [HttpGet");
            
            #line 59 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getRoute));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<Get");
            
            #line 60 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>> Get");
            
            #line 60 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 60 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyPropertyParamIn));
            
            #line default
            #line hidden
            this.Write(")\r\n            => await _");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application.Get");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyPropertyParam));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n        [HttpGet");
            
            #line 63 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(listRoute));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<IEnumerable<List");
            
            #line 64 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>>> List");
            
            #line 64 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("()\r\n            => await _");
            
            #line 65 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application.List");
            
            #line 65 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("();\r\n\r\n        [HttpPost");
            
            #line 67 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(searchRoute));
            
            #line default
            #line hidden
            this.Write("]\r\n        public async Task<ResponseDto<SearchResultDto<Search");
            
            #line 68 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>>> Search");
            
            #line 68 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(SearchParamsDto<Search");
            
            #line 68 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("FilterDto> searchParams)\r\n            => await _");
            
            #line 69 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("Application.Search");
            
            #line 69 "D:\Projects\Columbia\DslPackage\CodeGenerators\Apis\Templates\ControllerCodeGenerator.tt"
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
