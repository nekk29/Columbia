﻿using Company.Product.Module.Apis.Base;

namespace Company.Product.Module.Apis.Endpoints
{
    public static class RootApiEndpointApplicationBuilderExtensions
    {
        public static void UseRootApiEndpoint(this IApplicationBuilder app, IConfiguration configuration)
        {
            var options = configuration.GetSection("ApiOptions").Get<ApiOptions>() ?? new();

            app.UseEndpoints(configure =>
            {
                configure.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"{options.Name} Api - v{options.Version} ({options.Environment})");
                });
            });
        }
    }
}
