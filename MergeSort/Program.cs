using System;

namespace MergeSort
{
    class Program
    {
        private static void Main()
        {
            var array = new int[] { 1, 4, 3, 2, 9, 5, 4 };            

            Sorting.MergeSort(array);
            
            foreach(var value in array)
            {
                Console.WriteLine(value + " ");
            }
        }        
    }

    static class Sorting
    {
        public static void MergeSort<T>(T[] array, bool ascending = true) where T : IComparable
        {
            MergeSort(array, 0, array.Length - 1, ascending);
        }

        public static void MergeSort<T>(T[] array, int lowIndex, int highIndex, bool ascending = true) where T : IComparable
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex, ascending);
                MergeSort(array, middleIndex + 1, highIndex, ascending);
                Merge(array, lowIndex, middleIndex, highIndex, ascending);
            }
        }

        private static void Merge<T>(T[] array, int lowIndex, int middleIndex, int highIndex, bool ascending) where T : IComparable
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new T[highIndex - lowIndex + 1];
            var index = 0;
            var compare = ascending ? -1 : 1;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left].CompareTo(array[right]) == compare)
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
    }
}