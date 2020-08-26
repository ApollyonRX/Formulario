using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Models
{
    public class UserApp : IdentityUser<Guid>
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
