using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Models.ContaViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Usuário")]
        public string Usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [Display(Name = "Lembrar de mim")]
        public bool lembrar { get; set; }

    }
}
