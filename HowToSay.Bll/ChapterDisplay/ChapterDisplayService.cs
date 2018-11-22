using System;
using System.Collections.Generic;
using System.Linq;
using HowToSay.Bll.Chapter;
using HowToSay.Bll.Sentence;

namespace HowToSay.Bll.ChapterDisplay
{
    public class ChapterDisplayService
    {
        public const int DesiredMaxNumberOfChars = 150;
        public const string SpecialCharacters = " /";
        public const string Space = " ";

        public List<ChapterDisplayGroupModel> GetChaptersToDisplay(List<ChapterModel> chapters)
        {
            var result = new List<ChapterDisplayGroupModel>();
            foreach (var chapter in chapters)
            {
                var texts = GetSentencesToDisplay(chapter.Sentences);

                result.Add(new ChapterDisplayGroupModel(chapter.ChapterNo, texts));
            }

            return result;
        }

        public List<ChapterDisplayTextModel> GetSentencesToDisplay(List<SentenceModel> sentences)
        {
            if (sentences == null) return null;
            if (sentences.Count < 2) return sentences.Select(GetTextModel).ToList();

            var mergedSentences = new List<ChapterDisplayTextModel>();

            foreach (var sentence in sentences)
            {
                var mergedSentence = GetMergedSentence(mergedSentences.LastOrDefault(), sentence);

                if (!mergedSentences.Contains(mergedSentence))
                {
                    mergedSentences.Add(mergedSentence);
                }
            }

            return mergedSentences;
        }

        public bool CheckMergeRequired(string current, string next)
        {
            if (current == null) throw new ArgumentException("Parameter 'current' cannot be null.");
            if (next == null) return false;

            if (current.Contains(SpecialCharacters) || next.Contains(SpecialCharacters)) return false;

            if (current.Length + Space.Length + next.Length > DesiredMaxNumberOfChars) return false;

            return true;
        }

        public bool CheckMergeRequired(ChapterDisplayTextModel current, SentenceModel next)
        {
            return CheckMergeRequired(current.Text, next.Sentence) && CheckMergeRequired(current.TextTranslation, next.SentenceTranslation);
        }


        private ChapterDisplayTextModel GetMergedSentence(ChapterDisplayTextModel mergedSentence, SentenceModel sentence)
        {
            if (mergedSentence == null)
            {
                return GetTextModel(sentence);
            }

            if (CheckMergeRequired(mergedSentence, sentence))
            {
                mergedSentence.AppendText(sentence);
                return mergedSentence;
            }

            return GetTextModel(sentence);
        }

        private static ChapterDisplayTextModel GetTextModel(SentenceModel sentence) => new ChapterDisplayTextModel(sentence);
    }
}