using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace PathonDB.Server.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureControllers(this IServiceCollection services) {
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }
    }
}