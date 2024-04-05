using System;

namespace dz04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] temperatures = { 20, 25, 30, 15, 10, 25, 35 };

            DayTemperature dayTemperature = new DayTemperature(temperatures);
            dayTemperature.MaxTemperatureDifferenceFound += OnMaxTemperatureDifferenceFound;
            dayTemperature.FindDaysWithMaxTemperatureDifference();
        }

        static void OnMaxTemperatureDifferenceFound(object sender, MaxTemperatureDifferenceEventArgs e)
        {
            Console.WriteLine($"Maximum temperature difference: {e.MaxDifference} °C");
            Console.WriteLine("Days with maximum temperature difference:");
            foreach (int day in e.Days)
            {
                Console.WriteLine($"Day {day + 1}: {temperatures[day]} °C");
            }
        }
    }
}
