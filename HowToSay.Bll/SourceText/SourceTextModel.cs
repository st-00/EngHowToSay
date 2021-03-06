﻿using HowToSay.Infrastructure;

namespace HowToSay.Bll.SourceText
{
    public class SourceTextModel
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public SourceTextModel(string title, string text)
        {
            Title = TextCleaner.Clean(title);
            Text = TextCleaner.Clean(text);
        }
    }
}