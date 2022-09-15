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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class RestServiceCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"

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

    var createRoute = string.IsNullOrEmpty(entitySuffixLower) ? "string.Empty" : $"\"/{entitySuffixLower}\"";
    var updateRoute = createRoute;
    var deleteRoute = string.IsNullOrEmpty(entitySuffixLower) ?
        (!string.IsNullOrEmpty(keyPropertyParamRoute) ? $"$\"/{keyPropertyParamRoute}\"" : "") :
        (!string.IsNullOrEmpty(keyPropertyParamRoute) ? $"$\"/{entitySuffixLower}/{keyPropertyParamRoute}\"" : $"\"/{entitySuffixLower}\"");
    var getRoute = deleteRoute;
    var listRoute = string.IsNullOrEmpty(entitySuffixLower) ? $"\"/list\"" : $"\"/{entitySuffixLower}/list\"";
    var searchRoute = string.IsNullOrEmpty(entitySuffixLower) ? $"\"/search\"" : $"\"/{entitySuffixLower}/search\"";

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 31 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.RestClient));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing ");
            
            #line 32 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing ");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\nnamespace ");
            
            #line 35 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.RestClient));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 37 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("RestService : BaseService\r\n    {\r\n        protected override string ApiController" +
                    " => \"api/");
            
            #line 39 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleLower));
            
            #line default
            #line hidden
            this.Write("\";\r\n\r\n        public ");
            
            #line 41 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("RestService(ServiceOptions options) : base(options)\r\n        {\r\n\r\n        }\r\n\r\n  " +
                    "      public async Task<ResponseDto<Get");
            
            #line 46 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>> Create");
            
            #line 46 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(Create");
            
            #line 46 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto createDto)\r\n            => await Post<Create");
            
            #line 47 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto, Get");
            
            #line 47 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>(");
            
            #line 47 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(createRoute));
            
            #line default
            #line hidden
            this.Write(", createDto)!;\r\n\r\n        public async Task<ResponseDto<Get");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>> Update");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(Update");
            
            #line 49 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto updateDto)\r\n            => await Put<Update");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto, Get");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>(");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(updateRoute));
            
            #line default
            #line hidden
            this.Write(", updateDto)!;\r\n\r\n        public async Task<ResponseDto> Delete");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyPropertyParamIn));
            
            #line default
            #line hidden
            this.Write(")\r\n            => await Delete(");
            
            #line 53 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(deleteRoute));
            
            #line default
            #line hidden
            this.Write(")!;\r\n\r\n        public async Task<ResponseDto<Get");
            
            #line 55 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>> Get");
            
            #line 55 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 55 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyPropertyParamIn));
            
            #line default
            #line hidden
            this.Write(")\r\n            => await Get<Get");
            
            #line 56 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>(");
            
            #line 56 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getRoute));
            
            #line default
            #line hidden
            this.Write(")!;\r\n\r\n        public async Task<ResponseDto<IEnumerable<List");
            
            #line 58 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>>> List");
            
            #line 58 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("()\r\n            => await Get<IEnumerable<List");
            
            #line 59 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>>(");
            
            #line 59 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(listRoute));
            
            #line default
            #line hidden
            this.Write(")!;\r\n\r\n        public async Task<ResponseDto<SearchResultDto<Search");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>>> Search");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entitySuffix));
            
            #line default
            #line hidden
            this.Write("(SearchParamsDto<Search");
            
            #line 61 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("FilterDto> filter)\r\n            => await Post<SearchParamsDto<Search");
            
            #line 62 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("FilterDto>, SearchResultDto<Search");
            
            #line 62 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto>>(");
            
            #line 62 "D:\Projects\Columbia\DslPackage\CodeGenerators\RestClient\Templates\RestServiceCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(searchRoute));
            
            #line default
            #line hidden
            this.Write(", filter)!;\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
