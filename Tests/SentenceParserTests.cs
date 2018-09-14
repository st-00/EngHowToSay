using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EngHowToSay;
using Xunit;

namespace Tests
{
    public class SentenceParserTests
    {
        readonly SentenceParser _sentenceParser = new SentenceParser();

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
                Assert.False(string.IsNullOrWhiteSpace(item.Translation));
            }
        }
    }

    public class SentenceParser
    {
        public readonly string[] SentenceSeparators = {".", "?", "!"};
        public readonly string SpecialSeparator3Forms = "/";


        public string[] GetSentences(string textWithSentences)
        {
            string[] sentences = Regex.Split(textWithSentences, @"(?<=[\.\?\!])")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();

            var sentensesCombined = CombineSentences(sentences);

            return sentensesCombined;
        }

        private string[] CombineSentences(string[] sentences)
        {
            var sentensesCombined = new List<string>(sentences.Length);
            string senteceBuffer = null;

            for (int i = 0, iNext = 1; i < sentences.Length; i++, iNext++)
            {
                var sentence = sentences[i];
                var sentenceNext = iNext < sentences.Length ? sentences[iNext] : string.Empty;

                if (senteceBuffer == null)
                {
                    senteceBuffer = sentence;
                }

                if (sentenceNext.Contains(SpecialSeparator3Forms))
                {
                    senteceBuffer += sentenceNext;
                }
                else
                {
                    sentensesCombined.Add(senteceBuffer);
                    senteceBuffer = null;
                }
            }

            return sentensesCombined.ToArray();
        }

        public List<SentenceModel> GetSentences(string sentences, string translations)
        {
            var a1 = GetSentences(sentences);
            var a2 = GetSentences(translations);

            if (a1.Length != a2.Length)
            {
                throw new Exception("Sentences count doesn't match to Translations count!");
            }

            var result = new List<SentenceModel>();
            for (int i = 0; i < a1.Length; i++)
            {
                result.Add(new SentenceModel() {Sentence = a1[i], Translation = a2[i]});
            }

            return result;
        }
    }
}