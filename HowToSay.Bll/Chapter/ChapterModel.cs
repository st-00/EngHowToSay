using System.Collections.Generic;
using HowToSay.Bll.Sentence;

namespace HowToSay.Bll.Chapter
{
    public class ChapterModel
    {
        public string ChapterNo { get; set; }
        public List<SentenceModel> Sentences { get; set; }
    }
}