using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SatbayevUsers.Models;

namespace SatbayevUsers.Controllers;

public class ItemsController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ItemsController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
