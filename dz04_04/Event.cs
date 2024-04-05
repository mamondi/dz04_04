using System;

namespace dz04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciChecker checker = new FibonacciChecker();
            checker.FibonacciChecked += OnFibonacciChecked;

            int number = 21;

            Console.WriteLine($"Checking if {number} is a Fibonacci number...");
            checker.CheckFibonacci(number);
        }

        static void OnFibonacciChecked(object sender, FibonacciCheckEventArgs e)
        {
            if (e.IsFibonacci)
            {
                Console.WriteLine($"{e.Number} is a Fibonacci number.");
            }
            else
            {
                Console.WriteLine($"{e.Number} is not a Fibonacci number.");
            }
        }
    }
}
