using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AcmeAPI.ServiceExtensions
{
    public interface IServiceExtension
    {
        void ConfigureIISIntegration(IServiceCollection services);
        void ConfigureSqlContext(IServiceCollection services, IConfiguration config);
        void ConfigureCors(IServiceCollection services);
        void ConfigureRepositoryWrapper(IServiceCollection services);
        void ConfigureLoggerService(IServiceCollection services);
    }
}
