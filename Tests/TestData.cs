using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public static class TestData
    {

        public const string TextWithOddCharacters = @"  Я 
умел
чинить велосипеды.      Ты умел воспитывать хулиганов.
Я умел чинить  велосипеды?   Я умел 
чинить велосипеды!       " + "before tab\tafter tab  ";


        public const string Topic0 = @"Я умел чинить велосипеды. Ты умел воспитывать хулиганов.Я умел чинить велосипеды? Я умел чинить велосипеды!";

        public const string Topic1 = @"Я умел чинить велосипеды. Ты умел воспитывать хулиганов.";
        public const string Topic1Eng = "I could repair bicycles.   You couldn't bring up hooligans. ";


        public const string Topic99 = @"#14.1
        Я умел чинить велосипеды.Ты умел воспитывать хулиганов.";

        public const string Topic99Eng = @"#14.1
I could repair bicycles. / Could I repair bicycles? / I couldn't repair bicycles. 
You could bring up hooligans. / Could you bring up hooligans? /You couldn't bring up hooligans. ";
    }
}
