using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Models;
using Sample.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestServiceA _serviceA;
        private readonly TestServiceB _serviceB;
        private readonly ITestService _serviceC;

        public HomeController(ILogger<HomeController> logger
            , TestServiceA serviceA
            , TestServiceB serviceB
            , ITestService serviceC)
        {
            _logger = logger;

            _serviceA = serviceA;
            _serviceB = serviceB;
            _serviceC = serviceC;
        }

        public IActionResult Index()
        {
            _serviceA.Test();
            _serviceB.Test();
            _serviceC.Test();

            return View();
        }

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
