using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EngHowToSay;
using OpenNLP.Tools.SentenceDetect;
using Xunit;

namespace Tests
{
    public class SentenceParserTests
    {
        readonly SentenceParser _sentenceParser = new SentenceParser();

        [Fact]
        public void Parse_Sentences()
        {
            string[] parts = Regex.Split(TestData.Topic0, @"(?<=[\.\?\!])");


            var sentences = _sentenceParser.GetSentences(TestData.Topic1);

            Assert.Equal(2, sentences.Length);
            foreach (var item in sentences)
            {
                Assert.False(string.IsNullOrWhiteSpace(item));
            }
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


        public string[] GetSentences(string sentences)
        {
            //return sentences.Split(SentenceSeparators, StringSplitOptions.RemoveEmptyEntries);

            // sentence min length?

            //for (var index = 0; index < sentences.Length; index++)
            //{
            //    var character = sentences[index];

            //    if (SentenceSeparators.Contains(character))
            //    {

            //    }

            //}

            return null;
        }


        public List<SentenceModel> GetSentences(string sentences, string translations)
        {
            return new List<SentenceModel>()
            {
                new SentenceModel(){Sentence = "2", Translation = "2"},
                new SentenceModel(){Sentence = "2", Translation = "2"},
            };
        }
    }
}
