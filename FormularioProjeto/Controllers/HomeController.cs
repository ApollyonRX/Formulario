using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FormularioProjeto.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FormularioProjeto.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserApp> _userManager;

        public HomeController(ILogger<HomeController> logger,
           UserManager<UserApp> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "CLIENTE")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
