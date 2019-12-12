using AcmeContracts;
using AcmeEntities;
using AcmeRepository;
using EmpLoggingService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeAPI.ServiceExtensions
{
    public class ServiceExtension : IServiceExtension
    {
        public void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public void ConfigureIISIntegration(IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public void ConfigureRepositoryWrapper(IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public void ConfigureSqlContext(IServiceCollection services, IConfiguration config)
        {
            var sqlConnectionString = config["connectionStrings:sqlConnectionString"];
            services.AddDbContext<AcmeContext>(o => o.UseSqlServer(sqlConnectionString));
        }
        public void ConfigureLoggerService(IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, Logger>();
        }
    }
}
