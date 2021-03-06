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
        
        public static void SetupCorsPolicy(this IServiceCollection services) {
            services.AddCors(options => {
                options.AddPolicy(name: "CorsPolicy", builder => {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public static void AddServices(this IServiceCollection services) {
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IDatabaseClient, Models.DatabaseClient>();
        }

        public static void ConfigureMvc(this IServiceCollection services) {
            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson();
        }
    }
}