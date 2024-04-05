using System;

namespace dz04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ArrayExtensions.ArrayFiltered += OnArrayFiltered;

            int[] filteredEven = numbers.Filter(x => x % 2 == 0);

            Console.WriteLine("Filtered even numbers:");
            foreach (int num in filteredEven)
            {
                Console.WriteLine(num);
            }

            int[] filteredOdd = numbers.Filter(x => x % 2 != 0);

            Console.WriteLine("\nFiltered odd numbers:");
            foreach (int num in filteredOdd)
            {
                Console.WriteLine(num);
            }
        }

        static void OnArrayFiltered(object sender, ArrayFilteredEventArgs e)
        {
            Console.WriteLine($"\nFiltered array: [{string.Join(", ", e.FilteredArray)}]");
        }
    }
}
