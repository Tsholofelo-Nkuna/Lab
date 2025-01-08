using Lab.DataAccessLayer.Entities;
using Lab.DataAccessLayer.Interfaces.Json;
using Lab.DataAccessLayer.Repositories.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLabRepositories(this IServiceCollection services, string fileStorageDirectoryPath)
        {
            services.Configure<JsonRepositoryOptions<TestEntity>>(options =>
            {
                options.FilePath = Path.Combine(fileStorageDirectoryPath, "Tests.json");
                options.SeedData = new List<TestEntity> { 
                    new TestEntity
                    {
                        Mnemonic = "Na",
                        Description ="Sodium",
                        IsActive = true,
                    },
                    new TestEntity
                    {
                        Mnemonic = "K",
                        Description ="Potassium",
                        IsActive = true,
                    },
                    new TestEntity
                    {
                        Mnemonic = "Cr",
                        Description ="Createnine",
                        IsActive = true,
                    },
                    new TestEntity
                    {
                        Mnemonic = "Ucr",
                        Description ="Urine-Createnine",
                        IsActive = false,
                    },
                    new TestEntity
                    {
                        Mnemonic = "Ur",
                        Description ="Urea",
                        IsActive = true,
                    },
                    new TestEntity
                    {
                        Mnemonic = "Uce",
                        Description ="Urea+Createnine+Electrolytes",
                        IsActive = true,
                    }
                };
            })
            .AddScoped<ITestRepository, TestRepository>();

            services.Configure<JsonRepositoryOptions<RequisitionEntity>>(options =>
            {
                options.FilePath = Path.Combine(fileStorageDirectoryPath, "Requisitions.json");
                options.SeedData = new List<RequisitionEntity>();

            }).AddScoped<IRequisitionRepository, RequisitionRepository>();
            
            services.Configure<JsonRepositoryOptions<TestResultEntity>>(options =>
            {
                options.FilePath = Path.Combine(fileStorageDirectoryPath, "TestResults.json");
                options.SeedData = new List<TestResultEntity>();
            }).AddScoped<ITestResultRepository, TestResultRepository>();

            services
                .AddScoped<IJsonRepository<TestEntity, int>, TestRepository>()
                .AddScoped<IJsonRepository<RequisitionEntity, int>, RequisitionRepository>()
                .AddScoped<IJsonRepository<TestResultEntity, int>, TestResultRepository>();
            return services;
        }
    }
}
