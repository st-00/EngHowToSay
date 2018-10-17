using System;
using System.Collections.Generic;
using System.Linq;
using EngHowToSay;
using Xunit;

namespace Tests
{
    public static partial class TestData
    {
        public const string Sentence60Chars = @"#17.2 I ate an apple yesterday. I have eaten an apple today.";
        public const string SentenceSpecialChars = @"You have already got this letter. / Have you got this letter yet? /You haven't got this letter yet.";
    }

    public class DisplayChapterServiceTests
    {
        private readonly DisplayChapterService _service = new DisplayChapterService();
        private readonly ChapterService _chapterService = new ChapterService(new SourceTextParser(), new SentenceParser());

        [Fact]
        public void Merge_Chapter_No_Merge()
        {
            var chapters = _chapterService.GetChapters(TestData.Topic99, TestData.Topic99Eng);
            var sentences = chapters[0].Sentences;

            var sentencesToDisplay = _service.GetSentencesToDisplay(sentences);

            Assert.Equal(sentencesToDisplay.Count, sentences.Count);
        }

        [Fact]
        public void Merge_Chapter()
        {
            var chapters = _chapterService.GetChapters(TestData.Topic1702, TestData.Topic1702Eng);
            var sentences = chapters[0].Sentences;

            var sentencesToDisplay = _service.GetSentencesToDisplay(sentences);

            Assert.NotEqual(sentencesToDisplay.Count, sentences.Count);
        }


        [Fact]
        public void Check_If_Two_Sentences_Merged()
        {
            Assert.True(_service.CheckMergeRequired(TestData.Sentence60Chars, TestData.Sentence60Chars));
            Assert.False(_service.CheckMergeRequired(TestData.Sentence60Chars + TestData.Sentence60Chars, TestData.Sentence60Chars));
        }

        [Fact]
        public void Check_Boundary_Conditions()
        {
            Assert.ThrowsAny<ArgumentException>(() => _service.CheckMergeRequired(null, null));
            Assert.False(_service.CheckMergeRequired(TestData.Sentence60Chars, null));
        }

        [Fact]
        public void Check_Special_Characters()
        {
            Assert.False(_service.CheckMergeRequired(TestData.SentenceSpecialChars, null));
            Assert.False(_service.CheckMergeRequired("", TestData.SentenceSpecialChars));
        }
    }

    public class DisplayChapterService
    {
        public const int DesiredMaxNumberOfChars = 150;
        public const string SpecialCharacters = " /";

        public bool CheckMergeRequired(string current, string next)
        {
            if (current == null) throw new ArgumentException("Parameter 'current' cannot be null.");
            if (next == null) return false;

            if (current.Contains(SpecialCharacters) || next.Contains(SpecialCharacters)) return false;

            if (current.Length + next.Length > DesiredMaxNumberOfChars) return false;

            return true;
        }

        public List<SentenceModel> GetSentencesToDisplay(List<SentenceModel> sentences)
        {
            return sentences.ToList();
        }
    }
}