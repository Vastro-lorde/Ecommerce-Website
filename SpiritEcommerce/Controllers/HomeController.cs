using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpiritEcommerce.Models;
using SpiritEcommerce.Utills;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SpiritEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadWriteToJson _dbContext;
        private readonly IUtilities _utility;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IReadWriteToJson dbContext, IUtilities utilities)
        {
            _logger = logger;
            _utility = utilities;
            _dbContext = dbContext;
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Index(User user)
        {
            user.Id = _utility.RandomDigits(8);
            try
            {
                var write = await _dbContext.WriteJson<User>(user, "Users.json");
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult DashBoard()
        {
            return View();
        }


        public IActionResult SignUp()
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
