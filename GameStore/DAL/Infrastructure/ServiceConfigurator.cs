﻿using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Infrastructure
{
    public class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GameStoreDB")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GSIdentityDB")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddScoped<ICartLineRepository, CartLineRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IGameGenreRepository, GameGenreRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<IRegisteredUserRepository, RegisteredUserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}