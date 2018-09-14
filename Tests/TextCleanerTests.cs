using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Tests
{
    public class TextCleanerTests
    {
        readonly TextCleaner _textCleaner = new TextCleaner();

        [Fact]
        public void Clean_Text_Fragment()
        {
            var cleanedText = _textCleaner.Clean(TestData.TextWithOddCharacters);

            Assert.DoesNotContain(Environment.NewLine, cleanedText);
            Assert.DoesNotContain("  ", cleanedText);
            Assert.DoesNotContain("\t", cleanedText);
            Assert.False(cleanedText.StartsWith(" "));
        }
    }

    internal class TextCleaner
    {
        // remove new lines
        //replace 2 spaces
        //remove tabulations
        //trim
        public string Clean(string textWithOddCharacters)
        {
            var noWhiteSpaces = Regex.Replace(textWithOddCharacters, @"\s+", " ");
            return noWhiteSpaces.Trim();
        }
    }
}
