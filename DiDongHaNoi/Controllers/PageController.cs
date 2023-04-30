using AspNetCoreHero.ToastNotification.Abstractions;
using DiDongHaNoi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiDongHaNoi.Controllers
{
    public class PageController : Controller
    {
        private readonly QlbanDienThoaiContext _context;

        public INotyfService _notyfService { get; }
        public PageController(QlbanDienThoaiContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }



        [Route("/page/{Alias}", Name = "PageDetails")]
        public IActionResult Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias)) return RedirectToAction("Index", "Home");

            var page = _context.Pages.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
            if (page == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(page);
        }
    }
}
