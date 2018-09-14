using EngTranslations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngTranslations.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EngTranslator()
        {
            //var modelList = TranslationModel.GetTestData();
            var model = new TranslationModel(
                @"E:\(user_profile)\YandexDisk\english\_data\14-29 RUS.txt",
                @"E:\(user_profile)\YandexDisk\english\_data\14-29 ENG.txt"
            );

            List<ChaperItemJoined> chaptersJoined = model.GetChaptersJoined();

            chaptersJoined.ForEach(i => i.InitTranslationPairs());

            chaptersJoined.ForEach(i => i.InitTranslationPairsForDisplay());



            return View(chaptersJoined);
        }
    }

    
}