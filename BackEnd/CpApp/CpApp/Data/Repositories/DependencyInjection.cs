using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CpApp.Interfaces;
using CpApp.Repositories;
using CpApp.Services;
using CpApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CpApp.Data.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientService, ClientService>();

            services.AddDbContext<CpAppContext>(opt => opt
                .UseMySql("Server=localhost; Database=CpAppNet;UserId=root; Password=admin123;"));
            return services;
        }
    }
}

