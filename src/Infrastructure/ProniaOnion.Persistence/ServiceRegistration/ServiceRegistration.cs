using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories;
using ProniaOnion.Persistence.Implementations.Services;

namespace ProniaOnion.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 8;

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService,CategoryService>();

            services.AddScoped<IColorRepository,ColorRepository>();
            services.AddScoped<IColorService,ColorService>();

            services.AddScoped<ITagRepository,TagRepository> ();
            services.AddScoped<ITagService,TagService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService,ProductService>();


            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IAuthService,AuthService>();

            return services;
        }
    }
}
