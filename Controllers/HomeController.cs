using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(string textEntry)
        {
            if (!string.IsNullOrEmpty(textEntry))
            {

                for (int i = 0; i < 5000; i++)
                {
                    var data = new MyData
                    {
                        Data = textEntry
                    };
                    _context.MyDatas.Add(data);
                }
                _context.SaveChanges();
            }

            return View("Index");
        }
        public IActionResult ViewEntries()
        {
            var entries = _context.MyDatas.ToList();
            return View(entries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
