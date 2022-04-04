using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
