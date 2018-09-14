using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngTranslations.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {

        private string filePath = @"E:\(user_profile)\YandexDisk\english\_data\14-29 RUS.txt";
        private string filePathEng = @"E:\(user_profile)\YandexDisk\english\_data\14-29 ENG.txt";


        [TestMethod]
        public void TestMethod1()
        {
            var model = new TranslationModel(filePath, filePathEng);

            //var chapters = model.GetChapters();

            List<ChaperItemJoined> chaptersJoined = model.GetChaptersJoined();

            chaptersJoined.ForEach(i => i.InitTranslationPairs());

            chaptersJoined.ForEach(i => i.InitTranslationPairsForDisplay());


            //var arr = file.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        }
    }
}
