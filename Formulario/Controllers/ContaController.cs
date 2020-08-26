using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Formulario.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Criar()
        {
            return View();
        }
    }
}
