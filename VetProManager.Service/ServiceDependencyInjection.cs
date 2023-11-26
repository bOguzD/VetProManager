using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using VetProManager.DAL;
using VetProManager.Service.Modules.CRM;
using VetProManager.Service.Modules.Shared;
using VetProManager.Service.Validations;

namespace VetProManager.Service {
    public static class ServiceDependencyInjection {
        public static void RegisterServiceDependencies(this IServiceCollection services,
            IConfiguration configuration) {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq("http://localhost:5341", LogEventLevel.Verbose)
                .CreateLogger();

            //FluentValidation
            services.AddScoped<SpeciesValidator>();
            services.AddAutoMapper(typeof(Mapper.AutoMapper));

            services.AddScoped<CustomerService>();
            services.AddScoped<SpeciesService>();

            services.AddSingleton(provider => Log.Logger);


            //DAL katmanının dependencyleri
            services.RegisterDalDependencies(configuration);

        }
    }
}
