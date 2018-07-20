using Microsoft.AspNetCore.Mvc;

namespace EisenhowerMatrix.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Privacy() => View();
    }
}
