using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Lancamentos.Repository.Data;
using Lancamentos.Business.Contracts.Services;
using Lancamentos.Business.Services;
using Lancamentos.Business.Contracts.Repositories;
using Lancamentos.Repository.Repositories;

namespace Lancamentos.IoC
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
    .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddScoped<ICaixaService, CaixaService>();
            services.AddScoped<ICaixaDiarioRepository, CaixaDiarioRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            return services;
        }
    }
}