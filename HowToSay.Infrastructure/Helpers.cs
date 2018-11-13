using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HowToSay.Infrastructure
{
    public static class TextCleaner
    {
        public static string Clean(string textWithOddCharacters)
        {
            var noWhiteSpaces = Regex.Replace(textWithOddCharacters, @"\s+", " ");
            return noWhiteSpaces.Trim();
        }
    }
}
