﻿using FormularioProjeto.Models.EnviarContaViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Controllers
{
    public class EnviarContaController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult EnviarConta()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult EnviarConta(EnviarContaViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(model);
        }
    }
}
