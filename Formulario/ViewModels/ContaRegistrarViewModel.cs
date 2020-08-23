using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Formulario.ViewModels
{
    public class ContaRegistrarViewModel
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
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
