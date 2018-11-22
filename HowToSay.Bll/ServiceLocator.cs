using HowToSay.Bll.Chapter;
using HowToSay.Bll.ChapterDisplay;
using HowToSay.Bll.Sentence;
using HowToSay.Bll.SourceText;

namespace HowToSay.Bll
{
    public static class ServiceLocator
    {
        public static ChapterService GetChapterService() => new ChapterService(new SourceTextParser(), new SentenceParser());
        public static ChapterDisplayService GetChapterDisplayService() => new ChapterDisplayService();

        public static SentenceParser GetSentenceParser() => new SentenceParser();
        public static SourceTextParser GetSourceTextParser() => new SourceTextParser();
    }
}
