using System;
using System.Collections.Generic;
using System.Linq;
using EngHowToSay;

namespace Tests
{
    public class ChapterDisplayService
    {
        public const int DesiredMaxNumberOfChars = 150;
        public const string SpecialCharacters = " /";
        public const string Space = " ";

        public bool CheckMergeRequired(string current, string next)
        {
            if (current == null) throw new ArgumentException("Parameter 'current' cannot be null.");
            if (next == null) return false;

            if (current.Contains(SpecialCharacters) || next.Contains(SpecialCharacters)) return false;

            if (current.Length + Space.Length + next.Length > DesiredMaxNumberOfChars) return false;

            return true;
        }

        public bool CheckMergeRequired(ChapterDisplayModel current, SentenceModel next)
        {
            return CheckMergeRequired(current.Text, next.Sentence) && CheckMergeRequired(current.TextTranslation, next.SentenceTranslation);
        }

        public List<ChapterDisplayModel> GetSentencesToDisplay(List<SentenceModel> sentences)
        {
            if (sentences == null) return null;
            if (sentences.Count < 2) return sentences.Select(GetTextModel).ToList();

            var mergedSentences = new List<ChapterDisplayModel>();

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

        private ChapterDisplayModel GetMergedSentence(ChapterDisplayModel mergedSentence, SentenceModel sentence)
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

        private static ChapterDisplayModel GetTextModel(SentenceModel sentence) => new ChapterDisplayModel(sentence);
    }
}