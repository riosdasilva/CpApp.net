using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElsaConcept.Interfaces;
using ElsaConcept.Repositories;
using ElsaConcept.Services;
using ElsaConcept.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElsaConcept.Data.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();

            services.AddDbContext<ElsaConceptContext>(opt => opt
                .UseMySql("Server=localhost; Database=ElsaConcept;UserId=root; Password=admin123;"));
            return services;
        }
    }
}

