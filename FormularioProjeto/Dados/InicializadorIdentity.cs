using FormularioProjeto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Dados
{
    public static class InicializadorIdentity 
    {
        public static async Task CriarRoleClaims(this IServiceProvider serviceProvider)
        {
            using (var roleManager = serviceProvider.GetRequiredService<RoleManager<RolesApp>>())
            {
                var roles = roleManager.Roles.ToList();

                if (!roles.Any())
                {
                    string[] rolesNames = { "ADMINISTRADOR", "CLIENTE" };
                    foreach (var namesRole in rolesNames)
                    {
                        var role = new RolesApp(namesRole);
                        await roleManager.CreateAsync(role);
                    }
                }
            }
        }
    }
}
