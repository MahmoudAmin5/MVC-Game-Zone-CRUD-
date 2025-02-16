using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameServices _gameServices;

        public HomeController(ILogger<HomeController> logger,IGameServices gameServices )
        {
            _logger = logger;
            _gameServices = gameServices;
        }

        public IActionResult Index()
        {
            var Games = _gameServices.GetAll();
            return View(Games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
