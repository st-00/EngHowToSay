using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowToSay.Bll.SourceText
{
    public class SourceTextParser
    {
        public const string ChapterNumberPrefix = "#";

        public List<SourceTextModel> GetChapters2(string chaptersWithText)
        {
            List<string> chaptersRaw = GetChapters(chaptersWithText);

            var result = new List<SourceTextModel>(chaptersRaw.Count);

            foreach (var item in chaptersRaw)
            {
                var indexEndChapterNo = item.IndexOf(Environment.NewLine, StringComparison.Ordinal) > 0
                    ? item.IndexOf(Environment.NewLine, StringComparison.Ordinal)
                    : item.IndexOf(" ", StringComparison.Ordinal);

                var chapterNo = item.Substring(0, indexEndChapterNo);
                var text = item.Substring(indexEndChapterNo + 1);

                result.Add(new SourceTextModel(chapterNo, text));
            }

            return result;
        }

        public List<string> GetChapters(string chaptersWithText)
        {
            List<string> chapters = chaptersWithText.Split(new[] { ChapterNumberPrefix }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Trim())
                .Where(i => string.IsNullOrWhiteSpace(i) == false)
                .ToList();

            return chapters;
        }
    }
}
