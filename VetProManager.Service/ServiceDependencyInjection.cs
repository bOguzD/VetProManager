using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VetProManager.DAL;
using VetProManager.Service.Modules.CRM;
using VetProManager.Service.Modules.Shared;
using VetProManager.Service.Validations;

namespace VetProManager.Service {
    public static class ServiceDependencyInjection {
        public static void RegisterServiceDependencies(this IServiceCollection services,
            IConfiguration configuration) {


            //FluentValidation
            services.AddScoped<SpeciesValidator>();
            services.AddAutoMapper(typeof(Mapper.AutoMapper));

            services.AddScoped<CustomerService>();
            services.AddScoped<SpeciesService>();


            //DAL katmanının dependencyleri
            services.RegisterDalDependencies(configuration);

        }
    }
}
