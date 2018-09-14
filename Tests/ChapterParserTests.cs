using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngHowToSay;
using Xunit;

namespace Tests
{
    public static class ChapterTestData
    {
        public const string ChaptersWithText = @"#14.1
I could repair bicycles. / Could I repair bicycles? / I couldn't repair bicycles. 
#14.2
I show off every day. 

You usually lose your handkerchiefs. 

#15.1
I was sleeping from 10 till 12 yesterday. / Was I sleeping from 10till 12 yesterday? / I wasn't sleeping from 10 till 12 yesterday.

#15.2
I always sail against the wind
#16.1
I have already lost my heart. 

#16.2
[X]

#17.1
I have just come. / Have I just come? / I haven't just come.
#17.2
I ate an apple yesterday. 

#19.2a
Hardly had I seen her when I fell in love

#19.2b
Hardly had I seen her when I lost the gift of speech. 

#20.2a
[20.2a]

#20.2b
[20.2b]
#21.1
[21.1]
#21.2
[21.2]
";
    }

    public class ChapterParserTests
    {
        readonly ChapterParser _chapterParser = new ChapterParser();

        [Fact]
        public void Parse_Chapters()
        {
            var chapters = _chapterParser.GetChapters(ChapterTestData.ChaptersWithText);

            Assert.Equal(14, chapters.Count);
            Assert.Equal(0, chapters.Count(i => i.StartsWith(ChapterParser.ChapterNumberPrefix)));
        }

        [Fact]
        public void Parse_Title_And_Text()
        {
            var chapters = _chapterParser.GetChapters2(ChapterTestData.ChaptersWithText);

            Assert.Equal(14, chapters.Count);
        }
    }

    public class ChapterParser
    {
        public const string ChapterNumberPrefix = "#";

        public List<ChapterModel> GetChapters2(string chaptersWithText)
        {
            List<string> chaptersRaw = GetChapters(chaptersWithText);

            var result = new List<ChapterModel>(chaptersRaw.Count);

            foreach (var item in chaptersRaw)
            {
                var indexEndChapterNo = item.IndexOf(Environment.NewLine, StringComparison.Ordinal) > 0
                    ? item.IndexOf(Environment.NewLine, StringComparison.Ordinal)
                    : item.IndexOf(" ", StringComparison.Ordinal);

                var chapterNo = item.Substring(0, indexEndChapterNo);
                var text = item.Substring(indexEndChapterNo + 1);

                result.Add(new ChapterModel(chapterNo, text));
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
