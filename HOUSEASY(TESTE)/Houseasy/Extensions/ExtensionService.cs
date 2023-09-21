using HouseasyCommon.Model;
using HouseasyCommon.Service;
using HouseasyModel.DTO;

namespace HouseasyFront.Extensions
{
    public static class ExtensionService
    {

        public static void ConfigurarServicos(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IApiToken, ApiToken>();
            services.AddScoped<LoginResponse>();
        }

        public static void ConfigurarAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Database>(configuration.GetSection("Database"));
        }

    }
}
