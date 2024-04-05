using System;

namespace dz04_04
{
    public static class StringExtensions
    {
        public static event EventHandler<LastWordLengthEventArgs> LastWordLengthCalculated;

        public static int GetLastWordLength(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            int length = 0;
            int lastWordStartIndex = -1;
            bool inWord = false;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    if (inWord)
                    {
                        lastWordStartIndex = i + 1;
                        break;
                    }
                }
                else
                {
                    inWord = true;
                }
            }

            if (lastWordStartIndex != -1)
            {
                length = str.Length - lastWordStartIndex;
                OnLastWordLengthCalculated(length);
            }

            return length;
        }

        private static void OnLastWordLengthCalculated(int length)
        {
            LastWordLengthCalculated?.Invoke(null, new LastWordLengthEventArgs(length));
        }
    }

    public class LastWordLengthEventArgs : EventArgs
    {
        public int LastWordLength { get; }

        public LastWordLengthEventArgs(int lastWordLength)
        {
            LastWordLength = lastWordLength;
        }
    }
}
