using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PathonDB.Server.Models;
using PathonDB.Server.Services;

namespace PathonDB.Server.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureControllers(this IServiceCollection services) {
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services) {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        
        public static void AddServices(this IServiceCollection services) {
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IDatabaseClient, Models.DatabaseClient>();
        }
    }
}