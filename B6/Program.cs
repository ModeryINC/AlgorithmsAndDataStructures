using System.Diagnostics;
using System;

namespace B6 {
    class Program {
        static void Main(string[] args) {
            SearchSortEngine testList = new(1000);
            testList.SaveList("unsorted");
            // selection sort
            testList.SelectionSort();
            testList.SaveList("selection");
            // insertion sort
            testList.Reshuffle();
            testList.InsertionSort();
            testList.SaveList("insertion");
            // bubble sort
            testList.Reshuffle();
            testList.BubbleSort();
            testList.SaveList("bubble");
            // linear search
            testList.Reshuffle();
            Console.WriteLine("Searching for numbers... [linear search]");
            for (int i = 10; i < 20; i++) {
                Console.WriteLine(i + " - " + testList.LinearSearch(i));
            }
            // jump search
            testList.SelectionSort(); // we need to sort the list first
            Console.WriteLine("Searching for numbers... [jump search]");
            for (int i = 10; i < 20; i++) {
                Console.WriteLine(i + " - " + testList.JumpSearch(i));
            }

            // ************************* performance **************************
            Console.WriteLine("\nPerformance tests");
            SearchSortEngine timeTest = new(10000); // we want slightly longer list to get more reliable results 
            Stopwatch stopwatch; // this is the time measurement device we will use
            double measurement; // here results will be saved
            // selection sort
            stopwatch = Stopwatch.StartNew(); // start the measurement
            timeTest.SelectionSort(); // do your job
            stopwatch.Stop(); // stop the measurement
            measurement = Convert.ToDouble(stopwatch.ElapsedTicks) / Stopwatch.Frequency; // read the measurements value (in seconds)
            Console.WriteLine("Execution time for selection sort: {0:0.00} miliseconds", 1000 * measurement); // for convenience, we scale by 1000 and give value in ms
            // insertion sort
            timeTest.Reshuffle(); // shuffling is not included in the measurement, since we want to compare sorting algorithms only
            stopwatch = Stopwatch.StartNew();
            timeTest.InsertionSort();
            stopwatch.Stop();
            measurement = Convert.ToDouble(stopwatch.ElapsedTicks) / Stopwatch.Frequency;
            Console.WriteLine("Execution time for insertion sort: {0:0.00} miliseconds", 1000 * measurement);
            // bubble sort
            timeTest.Reshuffle();
            stopwatch = Stopwatch.StartNew();
            timeTest.BubbleSort();
            stopwatch.Stop();
            measurement = Convert.ToDouble(stopwatch.ElapsedTicks) / Stopwatch.Frequency;
            Console.WriteLine("Execution time for bubble sort: {0:0.00} miliseconds", 1000 * measurement);
        }
    }
}
