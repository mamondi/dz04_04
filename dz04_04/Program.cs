using System;

namespace dz04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ляляляляляля останнє слово -> dorov";

            int lastWordLength = text.GetLastWordLength();
            Console.WriteLine($"The length of the last word in the string is: {lastWordLength}");
        }
    }
}
