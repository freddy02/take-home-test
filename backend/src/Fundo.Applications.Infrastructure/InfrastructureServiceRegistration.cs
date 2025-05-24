using Fundo.Applications.Application.IRepository;
using Fundo.Applications.Infrastructure.Data;
using Fundo.Applications.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
         public static IServiceCollection AddConfigInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var ll = configuration.GetConnectionString("LoanConn");
            services.AddDbContext<LoanDbContext>(options => options.UseSqlServer(
       configuration.GetConnectionString("LoanConn"),
       sqlOptions => sqlOptions.EnableRetryOnFailure(
           maxRetryCount: 5,
           maxRetryDelay: TimeSpan.FromSeconds(10),
           errorNumbersToAdd: null
       )));
                
            services.AddScoped<ILoanRepository, LoanRepository>();
            return services;
        }
    }
}
