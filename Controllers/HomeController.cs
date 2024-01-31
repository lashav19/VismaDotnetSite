using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var database = new DataBase("server=127.0.0.1;uid=admin;database=butikk_william;pwd=Server2023");
        var model = database.Read();

        return View(model);
    }

    public IActionResult About()
    {
        return View();
    }
    public IActionResult Login(){
        if(HttpContext.Request.Method == "POST"){
            string username = HttpContext.Request.Form["username"];
            string password = HttpContext.Request.Form["password"];
            System.Console.WriteLine(username);
            System.Console.WriteLine(password);
        }
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
