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
    
    #line 1 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\ResourcesCodeCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ResourcesCodeCodeGenerator : Columbia.DslPackage.CodeGenerators.Base.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ");
            
            #line 16 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\ResourcesCodeCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainModel.Domain));
            
            #line default
            #line hidden
            this.Write(".Resources.");
            
            #line 16 "D:\Projects\Columbia\DslPackage\CodeGenerators\Domain\Templates\ResourcesCodeCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Name));
            
            #line default
            #line hidden
            this.Write(" {\r\n    using System;\r\n    \r\n    \r\n    /// <summary>\r\n    ///   A strongly-typed " +
                    "resource class, for looking up localized strings, etc.\r\n    /// </summary>\r\n    " +
                    "// This class was auto-generated by the StronglyTypedResourceBuilder\r\n    // cla" +
                    "ss via a tool like ResGen or Visual Studio.\r\n    // To add or remove a member, e" +
                    "dit your .ResX file then rerun ResGen\r\n    // with the /str option, or rebuild y" +
                    "our VS project.\r\n    [global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"Sy" +
                    "stem.Resources.Tools.StronglyTypedResourceBuilder\", \"17.0.0.0\")]\r\n    [global::S" +
                    "ystem.Diagnostics.DebuggerNonUserCodeAttribute()]\r\n    [global::System.Runtime.C" +
                    "ompilerServices.CompilerGeneratedAttribute()]\r\n    internal class Resource1 {\r\n " +
                    "       \r\n        private static global::System.Resources.ResourceManager resourc" +
                    "eMan;\r\n        \r\n        private static global::System.Globalization.CultureInfo" +
                    " resourceCulture;\r\n        \r\n        [global::System.Diagnostics.CodeAnalysis.Su" +
                    "ppressMessageAttribute(\"Microsoft.Performance\", \"CA1811:AvoidUncalledPrivateCode" +
                    "\")]\r\n        internal Resource1() {\r\n        }\r\n        \r\n        /// <summary>\r" +
                    "\n        ///   Returns the cached ResourceManager instance used by this class.\r\n" +
                    "        /// </summary>\r\n        [global::System.ComponentModel.EditorBrowsableAt" +
                    "tribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]\r\n        i" +
                    "nternal static global::System.Resources.ResourceManager ResourceManager {\r\n     " +
                    "       get {\r\n                if (object.ReferenceEquals(resourceMan, null)) {\r\n" +
                    "                    global::System.Resources.ResourceManager temp = new global::" +
                    "System.Resources.ResourceManager(\"Columbia.DslPackage.CodeGenerators.Domain.Temp" +
                    "lates.Resource1\", typeof(Resource1).Assembly);\r\n                    resourceMan " +
                    "= temp;\r\n                }\r\n                return resourceMan;\r\n            }\r\n" +
                    "        }\r\n        \r\n        /// <summary>\r\n        ///   Overrides the current " +
                    "thread\'s CurrentUICulture property for all\r\n        ///   resource lookups using" +
                    " this strongly typed resource class.\r\n        /// </summary>\r\n        [global::S" +
                    "ystem.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.Edit" +
                    "orBrowsableState.Advanced)]\r\n        internal static global::System.Globalizatio" +
                    "n.CultureInfo Culture {\r\n            get {\r\n                return resourceCultu" +
                    "re;\r\n            }\r\n            set {\r\n                resourceCulture = value;\r" +
                    "\n            }\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
