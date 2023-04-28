using AspNetCoreHero.ToastNotification.Abstractions;
using DiDongHaNoi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace DiDongHaNoi.Controllers
{
    public class BlogController : Controller
    {
        private readonly QlbanDienThoaiContext _context;

        public INotyfService _notyfService { get; }
        public BlogController(QlbanDienThoaiContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Route("blogs.html", Name = ("Blog"))]
        public IActionResult Index(int? page)
        {
            var collection = _context.Posts.AsNoTracking().ToList();
            foreach (var item in collection)
            {
                if (item.CreateDate == null)
                {
                    item.CreateDate = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                }
            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTinDangs = _context.Posts
                .AsNoTracking()
                .OrderBy(x => x.PostId);
            PagedList<Post> models = new PagedList<Post>(lsTinDangs, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        [Route("/tin-tuc/{Alias}-{id}.html", Name = "TinChiTiet")]
        public IActionResult Details(int id)
        {
            var tindang = _context.Posts.AsNoTracking().SingleOrDefault(x => x.PostId == id);
            if (tindang == null)
            {
                return RedirectToAction("Index");
            }
            var lsBaivietlienquan = _context.Posts
                .AsNoTracking()
                .Where(x => x.Published == true && x.PostId != id)
                .Take(3)
                .OrderByDescending(x => x.CreateDate).ToList();
            ViewBag.Baivietlienquan = lsBaivietlienquan;
            return View(tindang);
        }

    }
}
