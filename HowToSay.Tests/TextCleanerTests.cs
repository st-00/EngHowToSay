using System;
using HowToSay.Infrastructure;
using Xunit;

namespace Tests
{
    public class TextCleanerTests
    {
        [Fact]
        public void Clean_Text_Fragment()
        {
            var cleanedText = TextCleaner.Clean(TestData.TextWithOddCharacters);

            Assert.DoesNotContain(Environment.NewLine, cleanedText);
            Assert.DoesNotContain("  ", cleanedText);
            Assert.DoesNotContain("\t", cleanedText);
            Assert.False(cleanedText.StartsWith(" "));
        }
    }
}
