using HowToSay.Bll.Chapter;
using HowToSay.Bll.Sentence;
using HowToSay.Bll.SourceText;
using Xunit;

namespace Tests
{
    public class ChapterServiceTests
    {
        private readonly ChapterService _chapterService = new ChapterService(new SourceTextParser(), new SentenceParser());

        [Fact]
        public void Get_Chapters()
        {
            var chapters = _chapterService.GetChapters(TestData.Topic99, TestData.Topic99Eng);
        }
    }
}