using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopV2.Application.Admin.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg => {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
           
            return services;
        }
    }

}
