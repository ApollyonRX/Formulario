using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Models.ContaViewModels
{
    public class RegistrarViewModel
    {
        [Required]
        [Display(Name = "Primeiro Nome")]
        public string PrimeiroNome { get; set; }
        [Required]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
        [Required]
        [Display(Name = "Gênero")]
        public string Genero { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [Display(Name = "Usuário")]
        public string Login { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage =
            "O campo {0} deve ter no mínimo {2} e no máximo {1} caracteres", MinimumLength = 8)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage =
            "O campo {0} deve ter no mínimo {2} e no máximo {1} caracteres", MinimumLength = 8)]
        [Display(Name = "Confirmação de Senha")]
        [Compare("Senha", ErrorMessage = "A confirmação de senha e a senha não coincidem.")]
        public string ConfirmacaoDeSenha { get; set; }
    }
}
