using AutoMapper.Configuration;
using FormularioProjeto.Banco;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace FormularioProjeto.Helpers
{
    public static class InjectorConfiguration
    {

        public static void InjectorServices(this IServiceProvidersFeature services, IConfiguration configuration )
        {
            services.AddDbContext<InvestContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                p => p.MigrationsHistoryTable("HistoricoDasMigrations", "DefaultConnection")));
        }
    }
}
