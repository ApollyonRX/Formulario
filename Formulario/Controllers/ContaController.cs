using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formulario.Models;
using Formulario.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Formulario.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new IdentityDbContext<UsuarioApp>("DefaultConnection");
                var userStore = new UserStore<UsuarioApp>(dbContext);
                var userManager = new UserManager<UsuarioApp>(userStore);

                var novoUsuario = new UsuarioApp();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.Login;
                novoUsuario.PrimeiroNome = modelo.PrimeiroNome;
                novoUsuario.Sobrenome = modelo.Sobrenome;
                novoUsuario.DataNascimento = modelo.DataNascimento;
                novoUsuario.Genero = modelo.Genero;

                userManager.Create(novoUsuario, modelo.Senha);

                return RedirectToAction("Index", "Home");
            }
            return View(modelo);
        }
    }
}
