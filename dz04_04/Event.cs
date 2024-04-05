using System;

namespace dz04_04
{
    public static class StringExtensions
    {
        public static event EventHandler<WordCountEventArgs> WordCountCompleted;

        public static int CountWords(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            int count = 0;
            bool inWord = false;

            foreach (char c in str)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (inWord)
                    {
                        count++;
                        inWord = false;
                    }
                }
                else
                {
                    inWord = true;
                }
            }

            if (inWord)
                count++;

            OnWordCountCompleted(count);

            return count;
        }

        private static void OnWordCountCompleted(int count)
        {
            WordCountCompleted?.Invoke(null, new WordCountEventArgs(count));
        }
    }

    public class WordCountEventArgs : EventArgs
    {
        public int WordCount { get; }

        public WordCountEventArgs(int wordCount)
        {
            WordCount = wordCount;
        }
    }
}
