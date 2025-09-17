using Microsoft.AspNetCore.Mvc;

namespace ContactList.Web.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}