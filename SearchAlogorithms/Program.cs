using System;
using System.Diagnostics;

namespace Main
{
    class Algo
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int seed = 9999;
            int[] SearchArray = CreateArray();
            stopwatch.Start();
            LinearSearch(SearchArray, seed, 0);
            stopwatch.Stop();
            Console.WriteLine($"Linear Search found {seed} in {stopwatch.Elapsed.TotalMilliseconds} mseconds");

            stopwatch.Reset();
            stopwatch.Start();
            BinarySearch(SearchArray, seed);
            stopwatch.Stop();
            System.Console.WriteLine($"");
            Console.WriteLine($"Binary Search found {seed} in {stopwatch.Elapsed.TotalMilliseconds} mseconds");

            stopwatch.Reset();
            stopwatch.Start();
            JumpSearch(SearchArray, seed);
            stopwatch.Stop();
            System.Console.WriteLine($"");
            Console.WriteLine($"Jump Search found {seed} in {stopwatch.Elapsed.TotalMilliseconds} mseconds");

            stopwatch.Reset();
            stopwatch.Start();
            ExponentialSearch(SearchArray, seed);
            stopwatch.Stop();
            System.Console.WriteLine($"");
            Console.WriteLine($"Exponential Search found {seed} in {stopwatch.Elapsed.TotalMilliseconds} mseconds");
            

        }

        public static int[] CreateArray()
        {
            int[] numbers = new int[10000];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }
            return numbers;
        }

        // Linear Search (Recursive), this function is a incremeting counter that will recursivly call itself until the value is found.
        public static void LinearSearch(int[] array, int value, int counter)
        {
            if (array[counter] == value)
            {
                return;
            }
            else
            {
                counter++;
                LinearSearch(array, value, counter);
            }
        }

        // Binary Search, this function will divide the array in half and check if the value is in the left or right half.
        // It will continue to divide the array in half until the value is found or the array is empty.
        public static void BinarySearch(int[] array, int value)
        {
            int min = 0;
            int max = array.Length - 1;

            // Continue searching while the minimum index is less than or equal to the maximum index.
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (array[mid] == value)
                {
                    return;
                }
                else if (array[mid] < value)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
        }

        // Jump Search, this function will jump ahead by a fixed number of steps and check if the value is in the array.
        // If the value is not found, it will perform a linear search in the block where the value is expected to be.
        public static void JumpSearch(int[] array, int value)
        {
            int length = array.Length;
            int step = (int)Math.Floor(Math.Sqrt(length)); // Jump step size
            int prev = 0; // Previous block index

            // Finding the block where the value is expected to be
            while (array[Math.Min(step, length) - 1] < value)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(length));
                if (prev >= length)
                {
                    return;
                }
            }
            // Performing a linear search in the found block
            while (array[prev] < value)
            {
                prev++;
                if (prev == Math.Min(step, length))
                {
                    return;
                }
            }
            // Check if the value is found
            if (array[prev] == value)
            {
                return;
            }
        }

        // Exponential Search, this function will find the range where the value is expected to be by doubling the index. with each iteration. Unitl the value is found or the index exceeds the length of the array.
        // Once the range is found, it will perform a binary search in that range.
        public static void ExponentialSearch(int[] array, int value)
        {
            if (array[0] == value)
            {
                return;
            }
            // Find range for binary search by repeated doubling the index until the value is found or the index exceeds the length of the array.
            int i = 1;
            while (i < array.Length && array[i] <= value)
            {
                i = i * 2;
            }
            //  Perform a binary search in the found range
            int left = i / 2;
            int right = Math.Min(i, array.Length - 1);
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == value)
                {
                    return;
                }
                else if (array[mid] < value)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
    }
}