using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System;

namespace B5 {
    class Program {
        static async Task Main(string[] args) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<int> PrimaryNumbersList = await PrimaryNumbers.CreateTasks(0, 10000000, 1);
            stopwatch.Stop();
            if (PrimaryNumbersList.Count == 0) {
                Console.Write("Error occurred in generating tasks!\n");
                return;
            }
            Console.Write(
                "| " + string.Join(" | ", PrimaryNumbersList.Order().Take(20)) + " |\n"
                + "Czas wykonywania: " + Math.Round(stopwatch.ElapsedMilliseconds / 100.0) / 10.0
                + "s | " + stopwatch.ElapsedMilliseconds + "ms\nIlość liczb: " + PrimaryNumbersList.Count + "\n");
        }
    }
}
