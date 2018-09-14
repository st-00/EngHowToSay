using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngHowToSay;
using Xunit;

namespace Tests
{
    public class TranslationServiceTests
    {
        private readonly TranslationService _translationService = new TranslationService(new ChapterParser(), new SentenceParser());

        [Fact]
        public void Get_Chapters()
        {
            var chapters = _translationService.GetChapters(TestData.Topic99, TestData.Topic99Eng);
        }
    }

    public class TranslationService
    {
        private readonly ChapterParser _chapterParser;
        private readonly SentenceParser _sentenceParser;

        public TranslationService(ChapterParser chapterParser, SentenceParser sentenceParser)
        {
            _chapterParser = chapterParser;
            _sentenceParser = sentenceParser;
        }

        public List<TranslationModel> GetChapters(string text, string translation)
        {
            var chapters = _chapterParser.GetChapters2(text);
            var chaptersTranslations = _chapterParser.GetChapters2(translation);

            var result = new List<TranslationModel>();

            foreach (var model in chapters)
            {
                var modelTranslation = chaptersTranslations.Single(i => string.Equals(i.Title, model.Title, StringComparison.CurrentCultureIgnoreCase));

                var chapterModel = new TranslationModel {ChapterNo = model.Title};
                chapterModel.Sentences = _sentenceParser.GetSentences(model.Text, modelTranslation.Text);

                result.Add(chapterModel);
            }

            return result;
        }
    }
}