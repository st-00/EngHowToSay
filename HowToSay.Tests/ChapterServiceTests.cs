using System.Globalization;
using HowToSay.Bll;
using HowToSay.Bll.Chapter;
using HowToSay.Bll.Sentence;
using HowToSay.Bll.SourceText;
using Xunit;

namespace Tests
{
    public class ChapterServiceTests
    {
        private readonly ChapterService _chapterService = ServiceLocator.GetChapterService();

        [Fact]
        public void Get_Chapters()
        {
            var chapters = _chapterService.GetChapters(TestData.Topic99, TestData.Topic99Eng);
        }

        [Fact]
        public void Get_Chapters_From_Resource()
        {
            var textChapters = SourceTextResource.ResourceManager.GetString("Chapters", CultureInfo.InvariantCulture);
            var textChaptersTranslation = SourceTextResource.ResourceManager.GetString("Chapters", new CultureInfo("en-US"));

            var chapters = _chapterService.GetChapters(textChapters, textChaptersTranslation);
        }
    }
}