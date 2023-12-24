using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using VetProManager.DAL;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.Modules.CRM;
using VetProManager.Service.Modules.Security;
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
            services.AddScoped<UserValidator>();
            services.AddScoped<AuthTokenValidator>();
            services.AddAutoMapper(typeof(Mapper.AutoMapper));

            services.AddScoped<CustomerService>();
            services.AddScoped<SpeciesService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();



            services.AddSingleton(provider => Log.Logger);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] ?? string.Empty))
                    };
                });

            //DAL katmanının dependencyleri
            services.RegisterDalDependencies(configuration);

        }
    }
}
