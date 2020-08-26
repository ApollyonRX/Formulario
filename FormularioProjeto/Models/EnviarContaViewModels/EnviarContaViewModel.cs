using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Models.EnviarContaViewModels
{
    public class EnviarContaViewModel
    {
        [Required]
        [Display(Name ="Nome Completo")]
        public string NomeCompleto { get; set; }
        [Required]
        [Display(Name ="E-Mail Bet365")]
        public string EmailBet { get; set; }
        [Required]
        [Display(Name ="Senha do E-mail")]
        public string SenhaEmail { get; set; }
        [Required]
        [Display(Name ="Login da Bet365")]
        public string LoginBet { get; set; }
        [Required]
        [Display(Name ="Senha da Bet365")]
        public string SenhaBet { get; set; }
        [Required]
        [Display(Name ="Código de Segurança")]
        public string CodigoSeg { get; set; }
        [Required]
        [Display(Name ="CPF Cadastrado")]
        public string CPF { get; set; }

    }
}
