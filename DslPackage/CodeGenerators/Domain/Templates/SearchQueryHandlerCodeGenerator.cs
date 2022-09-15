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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class SearchQueryHandlerCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"

    var module = !string.IsNullOrEmpty(Entity.Module) ? Entity.Module : Entity.Name;

            
            #line default
            #line hidden
            this.Write("using AutoMapper;\r\nusing ");
            
            #line 10 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Queries.Base;\r\nusing ");
            
            #line 11 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing ");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Dto));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 12 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 13 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.RepositoryAbstractions));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing ");
            
            #line 14 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Repository));
            
            #line default
            #line hidden
            this.Write(".Extensions;\r\nusing System.Linq.Expressions;\r\n\r\nnamespace ");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Queries.");
            
            #line 17 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class Search");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("QueryHandler : SearchQueryHandlerBase<Search");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Query, Search");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("FilterDto, Search");
            
            #line 19 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>\r\n    {\r\n        private readonly IRepository<Entity.");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("> _");
            
            #line 21 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n\r\n        public Search");
            
            #line 23 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("QueryHandler(\r\n            IMapper mapper,\r\n            IRepository<Entity.");
            
            #line 25 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 25 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository\r\n        ) : base(mapper)\r\n        {\r\n            _");
            
            #line 28 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository = ");
            
            #line 28 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n        }\r\n\r\n        protected override async Task<ResponseDto<Searc" +
                    "hResultDto<Search");
            
            #line 31 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>>> HandleQuery(Search");
            
            #line 31 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Query request, CancellationToken cancellationToken)\r\n        {\r\n            var r" +
                    "esponse = new ResponseDto<SearchResultDto<Search");
            
            #line 33 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>>();\r\n\r\n            Expression<Func<Entity.");
            
            #line 35 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(", bool>> filter = x => true;\r\n\r\n            var filters = request.SearchParams?.F" +
                    "ilter;\r\n\r\n            /*\r\n                Place your filters here...\r\n          " +
                    "  */\r\n\r\n            var ");
            
            #line 43 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("s = await _");
            
            #line 43 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write(@"Repository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter //Include navigation properties...
            );

            var ");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Dtos = _mapper?.Map<IEnumerable<Search");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>>(");
            
            #line 50 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("s.Items);\r\n\r\n            var searchResult = new SearchResultDto<Search");
            
            #line 52 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>(\r\n                ");
            
            #line 53 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("Dtos ?? new List<Search");
            
            #line 53 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write("Dto>(),\r\n                ");
            
            #line 54 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\SearchQueryHandlerCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(Entity.Name)));
            
            #line default
            #line hidden
            this.Write("s.Total,\r\n                request.SearchParams\r\n            );\r\n\r\n            res" +
                    "ponse.UpdateData(searchResult);\r\n\r\n            return await Task.FromResult(resp" +
                    "onse);\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
