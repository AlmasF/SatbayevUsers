using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatbayevUsers.Data;
using SatbayevUsers.Models;

namespace SatbayevUsers.Controllers
{
    public class UsersController : Controller
    {
        private readonly SatbayevUsersContext _context;

        public UsersController(SatbayevUsersContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _context.Users.ToListAsync();
            return View(user);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,DateOfBirth,IIN")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            } else
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.DateOfBirth);
                Console.WriteLine(user.IIN);
                Console.WriteLine("Invalid model state");
            }
            return View(user);
        }
    }
}
