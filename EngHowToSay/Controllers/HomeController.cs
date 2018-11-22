using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using EngHowToSay.Models;
using HowToSay.Bll;

namespace EngHowToSay.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var textChapters = SourceTextResource.ResourceManager.GetString("Chapters", CultureInfo.InvariantCulture);
            var textChaptersTranslation = SourceTextResource.ResourceManager.GetString("Chapters", new CultureInfo("en-US"));

            var chapterService = ServiceLocator.GetChapterService();
            var chapterDisplayService = ServiceLocator.GetChapterDisplayService();

            var chapters = chapterService.GetChapters(textChapters, textChaptersTranslation);
            var textGroups = chapterDisplayService.GetChaptersToDisplay(chapters);

            var model = new IndexViewModel {TextGroups = textGroups};

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}