using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HowToSay.Bll.Sentence;
using HowToSay.Bll.SourceText;

namespace HowToSay.Bll.Chapter
{
    public class ChapterService
    {
        private readonly SourceTextParser _sourceTextParser;
        private readonly SentenceParser _sentenceParser;

        public ChapterService(SourceTextParser sourceTextParser, SentenceParser sentenceParser)
        {
            _sourceTextParser = sourceTextParser;
            _sentenceParser = sentenceParser;
        }

        public List<ChapterModel> GetChapters(string text, string translation)
        {
            var chapters = _sourceTextParser.GetChapters2(text);
            var chaptersTranslations = _sourceTextParser.GetChapters2(translation);

            var result = new List<ChapterModel>();

            foreach (var model in chapters)
            {
                var modelTranslation = chaptersTranslations.Single(i => string.Equals(i.Title, model.Title, StringComparison.CurrentCultureIgnoreCase));

                var chapterModel = new ChapterModel { ChapterNo = model.Title };
                chapterModel.Sentences = _sentenceParser.GetSentences(model.Text, modelTranslation.Text);

                result.Add(chapterModel);
            }

            return result;
        }
    }
}
