using Microsoft.Extensions.DependencyInjection;

namespace MyDeal.TechTest.Services
{
    public static class ConfigRegister
    {
        public static IServiceCollection RegisterHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>(c =>
            {
                c.BaseAddress = new Uri("https://reqres.in");
            });

            return services;
        }
    }
}
