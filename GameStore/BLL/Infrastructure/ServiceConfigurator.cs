using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Infrastructure
{
    public class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DAL.Infrastructure.ServiceConfigurator.ConfigureServices(services, configuration);

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameGenreService, GameGenreService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICartLineService, CartLineService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRegisteredUserService, RegisteredUserService>();
        }
    }
}
