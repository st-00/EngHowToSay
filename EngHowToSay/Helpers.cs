using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EngHowToSay
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
