using System;

namespace dz04_04
{
    public static class IntExtensions
    {
        public static bool IsFibonacci(this int number)
        {
            double sqrt5 = Math.Sqrt(5);
            double phi = (1 + sqrt5) / 2;
            double psi = (1 - sqrt5) / 2;

            int fib1 = (int)Math.Round(Math.Pow(phi, number) / sqrt5);
            int fib2 = (int)Math.Round(Math.Pow(psi, number) / sqrt5);

            return fib1 * fib1 == number || fib2 * fib2 == number;
        }
    }

    public class FibonacciChecker
    {
        public event EventHandler<FibonacciCheckEventArgs> FibonacciChecked;

        public void CheckFibonacci(int number)
        {
            bool isFibonacci = number.IsFibonacci();
            OnFibonacciChecked(new FibonacciCheckEventArgs(number, isFibonacci));
        }

        protected virtual void OnFibonacciChecked(FibonacciCheckEventArgs e)
        {
            FibonacciChecked?.Invoke(this, e);
        }
    }

    public class FibonacciCheckEventArgs : EventArgs
    {
        public int Number { get; }
        public bool IsFibonacci { get; }

        public FibonacciCheckEventArgs(int number, bool isFibonacci)
        {
            Number = number;
            IsFibonacci = isFibonacci;
        }
    }
}
