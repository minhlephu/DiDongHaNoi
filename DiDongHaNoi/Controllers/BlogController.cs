using Microsoft.AspNetCore.Mvc;

namespace DiDongHaNoi.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
