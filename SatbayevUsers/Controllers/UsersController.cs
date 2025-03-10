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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,DateOfBirth,IIN")] User user)
        {
            if (!ModelState.IsValid)
            {

                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.DateOfBirth);
                Console.WriteLine(user.IIN);
                Console.WriteLine("Invalid model state");

                return View(user);
            }

            var userExists = await _context.Users.AnyAsync(x => x.IIN == user.IIN || x.Email == user.Email);
            
            if (userExists)
            {
                ModelState.AddModelError("IIN", "User with this IIN or Email already exists");
                return View(user);
            }

            var userDays = (DateTime.Now - user.DateOfBirth).TotalDays;

            if (userDays < 6570)
            {
                ModelState.AddModelError("DateOfBirth", "User must be at least 18 years old");
                return View(user);
            }

            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Users.FindAsync(id);
            return View(item);
        }

        //[HttpPut("/users/edit/{id}")]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,DateOfBirth,IIN")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    } else
        //    {
        //        Console.WriteLine(user.Name);
        //        Console.WriteLine(user.Email);
        //        Console.WriteLine(user.DateOfBirth);
        //        Console.WriteLine(user.IIN);
        //        Console.WriteLine("Invalid model state");
        //    }
        //        return View(user);
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,DateOfBirth,IIN")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var userExists = await _context.Users.AnyAsync(x => (x.IIN == user.IIN || x.Email == user.Email) && x.Id != user.Id);

            if (userExists)
            {
                ModelState.AddModelError("IIN", "User with this IIN or Email already exists");
                return View(user);
            }

            var userDays = (DateTime.Now - user.DateOfBirth).TotalDays;

            if (userDays < 6570)
            {
                ModelState.AddModelError("DateOfBirth", "User must be at least 18 years old");
                return View(user);
            }

            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemToDelete = await _context.Users.FindAsync(id);
            if (itemToDelete != null)
            {
                _context.Users.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
