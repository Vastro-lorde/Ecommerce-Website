using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpiritEcommerce.Data;
using SpiritEcommerce.Models;
using SpiritEcommerce.Utills;
using System.Threading.Tasks;

namespace SpiritEcommerce.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IReadWriteToJson _dbContext;
        private readonly string userFile = "Users.json";
        private readonly SpiritEcommerceContext _context;

        public SignUpController(SpiritEcommerceContext context)
        {
            _context = context;
        }

        // GET: SignUp
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: SignUp/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: SignUp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignUp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,FullName,Gender,DateOfBirth,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.WriteJson(user, "Users");
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: SignUp/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: SignUp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,Password,FullName,Gender,DateOfBirth,PhoneNumber")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


    }
}
