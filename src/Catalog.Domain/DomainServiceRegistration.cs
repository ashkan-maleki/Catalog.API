using System.Reflection;
using Catalog.Domain.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomainServices
            (this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IItemService, ItemService>();
            return services;
        }
    }
}
