using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Models
{
    public class RolesApp : IdentityRole<Guid>
    {
        public RolesApp()
        {

        }

        public RolesApp(string roleName) : base(roleName)
        {

        }
    }
}
