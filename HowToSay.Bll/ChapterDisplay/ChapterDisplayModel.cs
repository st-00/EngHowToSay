using EngHowToSay;

namespace Tests
{
    public class ChapterDisplayModel
    {
        public string Text { get; set; }
        public string TextTranslation { get; set; }

        public ChapterDisplayModel(SentenceModel sentence)
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