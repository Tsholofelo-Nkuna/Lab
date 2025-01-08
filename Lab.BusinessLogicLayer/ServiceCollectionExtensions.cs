using Lab.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLabBusinessServices(this IServiceCollection services, string fileStorageDirectoryPath)
        {
            services.AddLabRepositories(fileStorageDirectoryPath);
            services.AddAutoMapper(typeof(MapperConfig));
            return services;
        }
    }
}
