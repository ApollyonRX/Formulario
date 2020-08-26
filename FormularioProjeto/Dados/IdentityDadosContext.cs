using FormularioProjeto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Dados
{
    public class IdentityDadosContext : IdentityDbContext<UserApp,RolesApp,Guid>
    {
        public IdentityDadosContext(DbContextOptions<IdentityDadosContext> options):base(options)
        {

        }
    }
}
