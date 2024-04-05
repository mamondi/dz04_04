using System;

namespace dz04_04
{
    public static class ArrayExtensions
    {
        public static event EventHandler<ArrayFilteredEventArgs> ArrayFiltered;

        public static int[] Filter(this int[] array, Predicate<int> predicate)
        {
            if (array == null || predicate == null)
                throw new ArgumentNullException();

            int[] filteredArray = Array.FindAll(array, predicate);

            OnArrayFiltered(filteredArray);

            return filteredArray;
        }

        private static void OnArrayFiltered(int[] filteredArray)
        {
            ArrayFiltered?.Invoke(null, new ArrayFilteredEventArgs(filteredArray));
        }
    }

    public class ArrayFilteredEventArgs : EventArgs
    {
        public int[] FilteredArray { get; }

        public ArrayFilteredEventArgs(int[] filteredArray)
        {
            FilteredArray = filteredArray;
        }
    }
}
