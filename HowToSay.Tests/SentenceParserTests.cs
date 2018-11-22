using System.Collections.Generic;
using EngHowToSay;
using HowToSay.Bll;
using HowToSay.Bll.Sentence;
using Xunit;

namespace Tests
{
    public class SentenceParserTests
    {
        readonly SentenceParser _sentenceParser = ServiceLocator.GetSentenceParser();

        [Fact]
        public void Parse_Sentences()
        {
            var sentences = _sentenceParser.GetSentences(TestData.TextSentences);

            Assert.Equal(4, sentences.Length);
            foreach (var item in sentences)
            {
                Assert.False(string.IsNullOrWhiteSpace(item));
            }
        }

        [Fact]
        public void Parse_Sentences_With_Slash()
        {
            var sentences = _sentenceParser.GetSentences(TestData.TextSentencesWithSlash);

            Assert.Equal(3, sentences.Length);
        }

        [Fact]
        public void Parse_Two_Sentences_With_Translations()
        {
            List<SentenceModel> sentences = _sentenceParser.GetSentences(TestData.Topic1, TestData.Topic1Eng);

            Assert.Equal(2, sentences.Count);

            foreach (var item in sentences)
            {
                Assert.False(string.IsNullOrWhiteSpace(item.Sentence));
                Assert.False(string.IsNullOrWhiteSpace(item.SentenceTranslation));
            }
        }
    }
}