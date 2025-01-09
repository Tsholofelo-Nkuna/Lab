using Lab.BusinessLogicLayer.Services;
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
            services.AddScoped(typeof(TestRequisitionService));
            services.AddScoped(typeof(TestResultService));
            services.AddScoped(typeof(TestService));
            return services;
        }
    }
}
