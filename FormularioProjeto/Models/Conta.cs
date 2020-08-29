using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Models
{
    public class Conta
    {
        public Guid ContaId { get; set; }
        public string NomeCompleto { get; set; }
        public string EmailBet { get; set; }
        public string SenhaEmail { get; set; }
        public string LoginBet { get; set; }
        public string SenhaBet { get; set; }
        public string CodigoSeg { get; set; }
        public string CPF { get; set; }
        public Guid UserAppId { get; set; }
    }
}
