using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FormularioProjeto.Models;
using FormularioProjeto.Models.ContaViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormularioProjeto.Controllers
{
    public class ContaController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;

        public ContaController(UserManager<UserApp> userManager,
           SignInManager<UserApp> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegistrarCliente(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarCliente(RegistrarViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var novoUsuario = new UserApp()
                {
                    UserName = model.Login,
                    Email = model.Email,
                    PrimeiroNome = model.PrimeiroNome,
                    Sobrenome = model.Sobrenome,
                    Genero = model.Genero,
                    DataNascimento = model.DataNascimento,
                };
                var result = await _userManager.CreateAsync(novoUsuario, model.Senha);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(novoUsuario, "CLIENTE");
                    //await _userManager.AddClaimAsync(novoUsuario, new Claim("Politica", "01"));

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }

                foreach (var erro in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }

            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegistrarADM(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarADM(RegistrarViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var novoUsuario = new UserApp()
                {
                    UserName = model.Login,
                    Email = model.Email,
                    PrimeiroNome = model.PrimeiroNome,
                    Sobrenome = model.Sobrenome,
                    Genero = model.Genero,
                    DataNascimento = model.DataNascimento,
                };
                var result = await _userManager.CreateAsync(novoUsuario, model.Senha);
                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(novoUsuario, new List<string> { "ADMINISTRADOR", "CLIENTE" });
                    //await _userManager.AddClaimAsync(novoUsuario, new Claim("Politica", "01"));

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }

                foreach (var erro in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }

            }

            return View(model);
        }




        protected IActionResult RedirectToLocal(string returnUrl = "") => Url.IsLocalUrl(returnUrl)
           ? Redirect(returnUrl)
           : (IActionResult)RedirectToAction(nameof(HomeController.Index), "Home");

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Usuario, model.Senha, model.lembrar, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tentativa de Login Inválida");
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AcessoNegado()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
