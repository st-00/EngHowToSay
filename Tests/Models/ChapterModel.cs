namespace EngHowToSay
{
    public class ChapterModel
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public ChapterModel(string title, string text)
        {
            Title = TextCleaner.Clean(title);
            Text = TextCleaner.Clean(text);
        }
    }
}