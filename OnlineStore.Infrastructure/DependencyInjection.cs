using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.ProductCatalog.Commands.CreateProduct;
using OnlineStore.Application.Services.JWTService;
using OnlineStore.Application.Services.UserContext;
using OnlineStore.Domain.Repositories.OrdrerItemRepository;
using OnlineStore.Domain.Repositories.OrdrerRepository;
using OnlineStore.Domain.Repositories.ProductCatalogRepository;
using OnlineStore.Domain.Repositories.UserRepository;
using OnlineStore.Domain.SeedWork;
using OnlineStore.Infrastructure.Persistence.Context;
using OnlineStore.Infrastructure.Persistence.Repositories.OrderItemRepository;
using OnlineStore.Infrastructure.Persistence.Repositories.OrderRepository;
using OnlineStore.Infrastructure.Persistence.Repositories.ProductCatalogRepository;
using OnlineStore.Infrastructure.Persistence.Repositories.UserRepository;
using OnlineStore.Infrastructure.Persistence.UnitOfWork;
using System.Reflection;

namespace OnlineStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommandHandler).GetTypeInfo().Assembly));


            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();
            services.AddDbContextPool<ProductDbContext>((serviceProvider, options) =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("ProductDatabase"));
                options.UseInternalServiceProvider(serviceProvider);
            });


            services.AddScoped<ProductDbContext>();
            services.AddTransient<IProductCatalogRepository, ProductCatalogRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddScoped<UserContextService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
