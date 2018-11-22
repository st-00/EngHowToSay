using System.Collections.Generic;

namespace HowToSay.Bll.ChapterDisplay
{
    public class ChapterDisplayGroupModel
    {
        public string Title { get; set; }
        public List<ChapterDisplayTextModel> Texts { get; set; }

        public ChapterDisplayGroupModel(string title, List<ChapterDisplayTextModel> texts)
        {
            Title = title;
            Texts = texts;
        }
    }
}