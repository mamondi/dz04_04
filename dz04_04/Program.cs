using System;

namespace dz04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Це приклад рядка для підрахунку слів";

            int wordCount = text.CountWords();
            Console.WriteLine($"The number of words in the string is: {wordCount}");
        }
    }
}
