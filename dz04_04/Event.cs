using System;
using System.Collections.Generic;

namespace dz04_04
{
    public static class StringExtensions
    {
        public static event EventHandler<BracketsValidationEventArgs> BracketsValidationCompleted;

        public static bool IsValidBrackets(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            Stack<char> bracketsStack = new Stack<char>();
            bool isValid = true;

            foreach (char c in str)
            {
                if (IsOpeningBracket(c))
                {
                    bracketsStack.Push(c);
                }
                else if (IsClosingBracket(c))
                {
                    if (bracketsStack.Count == 0 || !IsMatchingPair(bracketsStack.Pop(), c))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            isValid &= bracketsStack.Count == 0;

            OnBracketsValidationCompleted(isValid);

            return isValid;
        }

        private static bool IsOpeningBracket(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        private static bool IsClosingBracket(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }

        private static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '[' && closing == ']') ||
                   (opening == '{' && closing == '}');
        }

        private static void OnBracketsValidationCompleted(bool isValid)
        {
            BracketsValidationCompleted?.Invoke(null, new BracketsValidationEventArgs(isValid));
        }
    }

    public class BracketsValidationEventArgs : EventArgs
    {
        public bool IsValid { get; }

        public BracketsValidationEventArgs(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
