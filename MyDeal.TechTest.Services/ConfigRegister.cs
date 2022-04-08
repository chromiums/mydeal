using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyDeal.TechTest.Services
{
    public static class ConfigRegister
    {
        public static IServiceCollection RegisterHttpClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IUserService, UserService>(c =>
            {
                c.BaseAddress = new Uri(config.GetValue<string>("UserService:Url"));
            });

            return services;
        }
    }
}
