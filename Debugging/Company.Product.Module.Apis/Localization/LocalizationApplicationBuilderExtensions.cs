﻿using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Company.Product.Module.Apis.Localization
{
    public static class LocalizationApplicationBuilderExtensions
    {
        public static void UseLocalization(this IApplicationBuilder app, IConfiguration configuration, params string[] cultures)
        {
            var defaultCulture = configuration.GetValue<string>("AppSettings:DefaultCulture");

            defaultCulture = string.IsNullOrEmpty(defaultCulture) ? "en-US" : defaultCulture;

            var supportedCultures = cultures.Select(x => new CultureInfo(x)).ToArray();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = supportedCultures
            });
        }
    }
}
