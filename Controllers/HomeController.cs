using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using Microsoft.Extensions.Configuration;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {   
        var con = _configuration.GetConnectionString("ConnectionStrings:ButikkWilliam");
        var database = new DataBase(con);
        var model = database.Read("SELECT * FROM bruker;");

        return View(model);
    }

    public IActionResult About()
    {

        return View();
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
