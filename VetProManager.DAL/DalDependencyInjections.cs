using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Contracts.Modules.CRM;
using VetProManager.DAL.Contracts.Modules.Security;
using VetProManager.DAL.Modules.Security;
using VetProManager.DAL.Modules.Shared;
using VetProManager.DAL.Repositories.Modules.CRM;
using VetProManager.DAL.Repositories.Modules.Security;
using VetProManager.DAL.Repositories.Modules.Shared;
using VetProManager.DAL.UnitOfWorks;

namespace VetProManager.DAL {
    public static class DalDependencyInjections {
        public static void RegisterDalDependencies(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<VetProManagerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //Identity
//            services.AddIdentity

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Species>, SpeciesRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<User>,  UserRepository>();
            services.AddScoped<IRepository<AuthToken>,  AuthTokenRepository>();
            services.AddScoped<IRepository<UserRole>, UserRoleRepository>();
        }
    }
}
