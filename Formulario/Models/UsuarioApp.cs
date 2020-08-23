using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulario.Models
{
    public class UsuarioApp : IdentityUser
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
