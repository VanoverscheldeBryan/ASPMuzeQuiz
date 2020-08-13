using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MuzeQuiz.Web.Models;
using Microsoft.AspNetCore.Authorization;
using MuzeQuiz.Models.Data;

namespace MuzeQuiz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataInitializer _dataInitializer;

        public HomeController(ILogger<HomeController> logger, IDataInitializer dataini)
        {
            _logger = logger;
            _dataInitializer = dataini;
        }

        public async Task<IActionResult> Index()
        {
            await _dataInitializer.InitQuizzes();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
