using HowToSay.Bll.Sentence;

namespace HowToSay.Bll.ChapterDisplay
{
    public class ChapterDisplayTextModel
    {
        public string Text { get; set; }
        public string TextTranslation { get; set; }

        public ChapterDisplayTextModel(SentenceModel sentence)
        {
            Text = sentence.Sentence;
            TextTranslation = sentence.SentenceTranslation;
        }

        public void AppendText(SentenceModel sentence)
        {
            Text += " " + sentence.Sentence;
            TextTranslation += " " + sentence.SentenceTranslation;
        }
    }
}