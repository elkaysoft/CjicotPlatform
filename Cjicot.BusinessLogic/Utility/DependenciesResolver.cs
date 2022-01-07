using Cjicot.Persistence.Domain;
using Cjicot.Persistence.Repository;
using Cjicot.Presentation.IManager;
using Cjicot.Presentation.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.Utility
{
    public class DependenciesResolver
    {
        public static void AddServiceDependencies(IServiceCollection services)
        {
            services.AddScoped<IRepository<UserLogin>, EntityRepository<UserLogin>>();
            services.AddScoped<IRepository<UserRole>, EntityRepository<UserRole>>();
            services.AddScoped<IRepository<Roles>, EntityRepository<Roles>>();

            services.AddTransient<IAccountManager, AccountManager>();
        }
    }
}
