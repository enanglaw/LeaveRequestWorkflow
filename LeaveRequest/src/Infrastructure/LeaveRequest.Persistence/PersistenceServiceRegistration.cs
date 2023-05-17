using LeaveRequest.Application.Contracts.Persistence;
using LeaveRequest.Domain.Entity;
using LeaveRequest.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveRequest.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveRequestDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("leaveRequestDataConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            return services;

        }
            
            
            
    }
}
