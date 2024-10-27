﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace Company.Product.Module.Domain.Resources
{
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Role
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Role()
        {
        }

        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Company.Product.Module.Domain.Resources.Role", typeof(Role).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a An user with the same role name already exists.
        /// </summary>
        internal static string DuplicateRecordByRoleName
        {
            get
            {
                return ResourceManager.GetString("DuplicateRecordByRoleName", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a Identifier.
        /// </summary>
        internal static string Id
        {
            get
            {
                return ResourceManager.GetString("Id", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a Name.
        /// </summary>
        internal static string Name
        {
            get
            {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a Normalized Name.
        /// </summary>
        internal static string NormalizedName
        {
            get
            {
                return ResourceManager.GetString("NormalizedName", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a Role does not exist.
        /// </summary>
        internal static string RoleDoesNotExist
        {
            get
            {
                return ResourceManager.GetString("RoleDoesNotExist", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a Role Identifier.
        /// </summary>
        internal static string RoleId
        {
            get
            {
                return ResourceManager.GetString("RoleId", resourceCulture);
            }
        }
    }
}
