using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace EngTranslations.Models
{

    public class ChaperItemJoined
    {
        public readonly int MaxCharactersPerTransaltion;

        public readonly string[] separators = { ".", "?", "!" };
        public readonly string SpecialSeparator3Forms = "/";

        public string Number { get; set; }

        public string TextRus { get; set; }
        public string TextEng { get; set; }

        public List<Tuple<string, string>> TranslationPairs { get; set; }

        public List<Tuple<string, string>> TranslationPairsForDisplay { get; set; }

        public ChaperItemJoined()
        {
            //MaxCharactersPerTransaltion = 100;
            MaxCharactersPerTransaltion = 1;


            TranslationPairs = new List<Tuple<string, string>>();
            TranslationPairsForDisplay = new List<Tuple<string, string>>();

        }

        public void InitTranslationPairs()
        {
            var rusTexts = TextRus.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Trim())
                .Where(i => string.IsNullOrWhiteSpace(i) == false)
                .ToList();

            var engTexts = TextEng.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Trim())
                .Where(i => string.IsNullOrWhiteSpace(i) == false)
                .ToList();

            var index = 0;
            foreach (var itemRus in rusTexts)
            {
                var itemEng = engTexts.Count > index ? engTexts[index] : "--error in matching translation--";

                // 3 forms of translation
                index++;
                while (engTexts.Count > index && engTexts[index].ToString().StartsWith(SpecialSeparator3Forms))
                {
                    itemEng += engTexts[index];
                    index++;
                }


                TranslationPairs.Add(new Tuple<string, string>(itemRus, itemEng));
            }


        }

        public void InitTranslationPairsForDisplay()
        {
            var currLength = 0;
            var counter = 0;

            //Tuple<string, string> pairForDisplay = null;
            string item1 = string.Empty;
            string item2 = string.Empty;

            var lastPair = TranslationPairs.LastOrDefault();
            foreach (var pair in TranslationPairs)
            {
                var prefix = " #" + /*++counter+*/  " ";

                item1 += prefix + pair.Item1;
                item2 += prefix + pair.Item2;

                currLength = Math.Max(item1.Length, item2.Length);
                if (currLength >= MaxCharactersPerTransaltion || pair.Equals(lastPair))
                {
                    TranslationPairsForDisplay.Add(new Tuple<string, string>(item1, item2));
                    item1 = string.Empty;
                    item2 = string.Empty;
                }
            }

        }
    }

    public class ChaperItem
    {
        public string Number { get; set; }

        public string Text { get; set; }
    }


    public class TranslationModel
    {
        private const string separator1 = "#";
        private string[] separators = { Environment.NewLine, separator1 };

        private string _filePathRus;
        private string _filePathEng;




        public TranslationModel(string filePathRus, string filePathEng)
        {
            _filePathRus = filePathRus;
            _filePathEng = filePathEng;
        }

        public string[] ReadFile()
        {
            //string file = File.ReadAllText(filePath);
            string[] lines = File.ReadAllLines(_filePathRus);

            return lines;
        }

        public List<ChaperItem> GetChapters(string filePath)
        {
            var textAll = File.ReadAllText(filePath);

            List<string> chapters = textAll.Split(new[] { separator1 }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Trim())
                .Where(i => string.IsNullOrWhiteSpace(i) == false)
                .ToList();

            var chapterItems = new List<ChaperItem>();

            foreach (var item in chapters)
            {
                var idxEndChapterNo = item.IndexOf(Environment.NewLine) > 0 ? item.IndexOf(Environment.NewLine) : item.IndexOf(" ");

                var chapterNo = item.Substring(0, idxEndChapterNo);

                var text = item.Substring(idxEndChapterNo + 1).Replace("\r", "").Replace("\n", "");


                chapterItems.Add(new ChaperItem { Text = text, Number = chapterNo.Trim() });

            }

            return chapterItems;


        }
        public List<ChaperItemJoined> GetChaptersJoined()
        {
            var list1 = GetChapters(_filePathRus);
            var list2 = GetChapters(_filePathEng);


            var list = new List<ChaperItemJoined>();
            var listFailed = new List<ChaperItem>();
            foreach (var item in list1)
            {
                var item2 = list2.SingleOrDefault(i => i.Number == item.Number);
                if(item2!= null)
                {
                    list.Add(new ChaperItemJoined
                    {
                        Number = item.Number,
                        TextRus = item.Text,
                        TextEng = item2.Text
                    });
                }
                else
                {
                    listFailed.Add(item);
                }

            }

            if (listFailed.Any())
            {
                Debug.Fail("Cannot join RUS and ENG chapters!");
            }

            return list;

        }







        public List<ChaperItem> GetChapters0()
        {
            var lines = ReadFile();

            var chaptersList = new List<string[]>();

            int indexStart = 0;
            int indexEnd = 0;
            for (int index = 0; index < lines.Length; index++)
            {
                var item = lines[index].Trim();

                var isStartOfChapter = item.Length > 1 && item.StartsWith(separator1) && Char.IsDigit(item.ElementAt(1));
                if (isStartOfChapter)
                {
                    var takeCnt = indexEnd - indexStart;
                    if (takeCnt > 0)
                    {
                        // each chapter:
                        chaptersList.Add(lines.Skip(indexStart).Take(indexEnd - indexStart).ToArray());
                    }

                    indexStart = index;
                }
                indexEnd = index;
            }

            // last chapter:
            chaptersList.Add(lines.Skip(indexStart).Take(indexEnd - indexStart).ToArray());

            var result = chaptersList.Where(i => i.Count() > 1 && !string.IsNullOrWhiteSpace(i.ElementAt(0))).Select(i => new ChaperItem
            {
                Number = i.ElementAt(0),
                Text = i.ElementAt(1)

            }).ToList();

            return result;

        }


        //public List<ChaperItemJoined> GetParsedTranslations()
        //{
        //    var chapters = GetChapters();


        //    //foreach (var chapter in chapters)
        //    //{
        //    //    var parsedTranslation = new ParsedTranslation();

        //    //    parsedTranslation.ChapterNo = chapter.ElementAt(0);

        //    //    foreach (var line in chapter.Skip(1))
        //    //    {
        //    //        if (line.Equals(separator1))
        //    //        {

        //    //        }

        //    //    }


        //    //}
        //    return null;

        //}

    }
}
//    public class ParsedTranslation0
//    {
//        public string ChapterNo { get; set; }
//        public string Text { get; set; }

//    }

//    public class ParsedTranslation
//    {
//        public string ChapterNo { get; set; }
//        public Tuple<string, string> TranslationPairs { get; set; }

//    }
//}