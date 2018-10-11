using System;
using System.Collections.Generic;
using System.Text;
using EngHowToSay;

namespace Tests
{
    public static class TestData
    {

        public const string TextWithOddCharacters = @"  Я 
умел
чинить велосипеды.      Ты умел воспитывать хулиганов.
Я умел чинить  велосипеды?   Я умел 
чинить велосипеды!       " + "before tab\tafter tab  ";


        public const string TextSentences = @"Я умел чинить велосипеды. Ты умел воспитывать хулиганов.Я умел чинить велосипеды? Я умел чинить велосипеды!";
        public const string TextSentencesWithSlash = @"I could repair bicycles. I could repair bicycles. / Could I repair bicycles? / I couldn't repair bicycles. 
You could bring up hooligans. / Could you bring up hooligans? /You couldn't bring up hooligans.";

        public const string Topic1 = @"Я умел чинить велосипеды. Ты умел воспитывать хулиганов.";
        public const string Topic1Eng = "I could repair bicycles.   You couldn't bring up hooligans. ";


        public const string Topic1701 = @"#17.1
Я только что пришел. Вы уже получили это письмо.Он много писал в последние дни. Она читала эту книгу целую вечность.Я порезал палец.Ты бросил курить.Дождь прекратился.Я впервые в Лондоне.Я разговариваю с иностранцем в третий раз в своей жизни.Она видела этот фильм 7 раз.";
        public const string Topic1701Eng = @"#17.1
        I have just come. / Have I just come? / I haven't just come.
            You have already got this letter. / Have you got this letter yet? /You haven't got this letter yet.
            He has written a lot lately. / Has he written a lot lately? / He hasn’t written a lot lately.
            She has read this book for ages. / Has she read this book for a while? / She hasn’t read this book for ages.
            I have cut my finger. / Have I cut my finger? / I haven’t cut my finger.
            You have given up smoking. / Have you given up smoking? / You haven’t given up smoking.
            It has stopped raining. / Has it stopped raining? / It hasn’t stopped raining.
            It’s the first time I’ve been to London. / Is it the first time I’ve been to London? / It isn’t the first time I’ve been to London.
            It’s the third time I’ve spoken to a foreigner. / Is it the third time I’ve spoken to a foreigner? / It isn’t the third time I’ve spoken to a foreigner.
            She has watched this movie 7 times. / Has she watched this movie7 times? / She hasn’t watched this movie 7 times.";


        public const string Topic1702 = @"#17.2
Я вчера ел яблоко. Я сегодня ел яблоко. Вчера, когда я ел ябло-ко, я поперхнулся.Ты прочла его письмо на пошлой неделе. Ты только что прочи-тала его письмо. Ты уже прочла его письмо? Неужели ты про-читала его письмо?Он никогда не смотрел на меня. Он никогда не смотрел на меняв детстве. Он не смотрел на меня, когда я посылала ему воз-душный поцелуй.Она не была там вчера (ее не было там вчера). Она не была тамна этих днях. Она не была там с детства. Ее там не было, когдая вошел. Она не была там целую вечность.Вы когда-нибудь ссорились со своими родителями? Вы когда-нибудь ссорились со своими родителями в детстве?Я с удовольствием учу наизусть хорошие стихи. Я только чтовыучил потрясающее стихотворение. Перестань заучиватьнаизусть всякую ерунду! Когда я учил это стихотворение на-изусть, открь1лась дверь и в комнату вошла мама.Мы сидим на мели с Нового года. Мы, бывало, в юности частосидели на мели, но никогда не страдали от этого.Представьте себе! Мальчик совсем отбился от рук!Не прислушивайся к голосу рассудка! Это скучно!У нее совсем крыша поехала! Она перессорилась со всеми знакомыми!";
        public const string Topic1702Eng = @"#17.2
I ate an apple yesterday. I have eaten an apple today. When I was seating an apple yesterday, I choked. You read his letter last week. You have just read his letter. Have you read his letter yet? Have you already read his letter? He has never looked at me. He never looked at me in childhood. He wasn’t looking at me while I was blowing him kisses. She wasn’t there yesterday. She hasn’t been there these days. She hasn’t been there since childhood. She wasn’t there when I got in(came in). She hasn’t been there for ages. Have you ever quarreled with your parents? Did you ever quarrel with your parents in childhood? I learn good poems by heart with great pleasure. I’ve just learnt a marvelous poem by heart. Stop learning all sorts of rubbish by heart! When I was learning this poem by heart, the door opened and my mum entered the room. We’ve been at a low ebb since New Year’s Day. We would be at a low ebb in youth, but never suffered from it. Fancy that! The boy has been out of hand again! Don’t listen to reason. It’s boring! She has a screw loose! She has quarreled with all her acquaintances/friends!";


        public const string Topic99 = @"#14.1
        Я умел чинить велосипеды.Ты умел воспитывать хулиганов.";

        public const string Topic99Eng = @"#14.1
I could repair bicycles. / Could I repair bicycles? / I couldn't repair bicycles. 
You could bring up hooligans. / Could you bring up hooligans? /You couldn't bring up hooligans. ";


        public static  List<string> Sentences = new List<string>();//TODO
    }
}
