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

        public async Task<IActionResult> Index()
        {
            try
            {
                var Products = await _dbContext.ReadJson<Product>("Products");
                ViewBag.Products = Products;
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public async Task<IActionResult> DashBoard(User user)
        {
            var Users = await _dbContext.ReadJson<User>("Users.json");
            foreach (var person in Users)
            {
                if (person.Email == user.Email && person.Password == user.Password) return View(person);
            }
            return View("User not found");
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
