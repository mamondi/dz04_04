using System;

namespace dz04_04
{
    public class DayTemperature
    {
        private int[] temperatures;

        public event EventHandler<MaxTemperatureDifferenceEventArgs> MaxTemperatureDifferenceFound;

        public DayTemperature(int[] temperatures)
        {
            this.temperatures = temperatures;
        }

        public void FindDaysWithMaxTemperatureDifference()
        {
            int maxTemperatureDifference = 0;
            int[] daysWithMaxDifference = new int[0];

            for (int i = 0; i < temperatures.Length; i++)
            {
                for (int j = i + 1; j < temperatures.Length; j++)
                {
                    int difference = Math.Abs(temperatures[i] - temperatures[j]);
                    if (difference > maxTemperatureDifference)
                    {
                        maxTemperatureDifference = difference;
                        daysWithMaxDifference = new int[] { i, j };
                    }
                    else if (difference == maxTemperatureDifference)
                    {
                        Array.Resize(ref daysWithMaxDifference, daysWithMaxDifference.Length + 2);
                        daysWithMaxDifference[daysWithMaxDifference.Length - 2] = i;
                        daysWithMaxDifference[daysWithMaxDifference.Length - 1] = j;
                    }
                }
            }

            OnMaxTemperatureDifferenceFound(maxTemperatureDifference, daysWithMaxDifference);
        }

        private void OnMaxTemperatureDifferenceFound(int maxDifference, int[] days)
        {
            MaxTemperatureDifferenceFound?.Invoke(this, new MaxTemperatureDifferenceEventArgs(maxDifference, days));
        }
    }

    public class MaxTemperatureDifferenceEventArgs : EventArgs
    {
        public int MaxDifference { get; }
        public int[] Days { get; }

        public MaxTemperatureDifferenceEventArgs(int maxDifference, int[] days)
        {
            MaxDifference = maxDifference;
            Days = days;
        }
    }
}
