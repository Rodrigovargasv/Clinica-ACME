
using ClinicaACME.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;

namespace ClinicaACME.Infra.Ioc.Context
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceDBContext(this IServiceCollection services, IConfiguration configuration)
        {

            // Configura o contexto para usar SQLite
            // Configurações do banco de dados SQLite
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            return services;
        }
    }
}
