using System;
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
    }
}