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
    }
}
