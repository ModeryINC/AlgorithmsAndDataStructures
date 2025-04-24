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
            Task<List<int>> taskFirst = PrimaryNumbers.Find();
            Task<List<int>> taskSecond = PrimaryNumbers.Find(833334);
            List<int> PrimaryNumbersList = [2, 3, 5];
            PrimaryNumbersList.AddRange(await taskFirst);
            PrimaryNumbersList.AddRange(await taskSecond);
            stopwatch.Stop();
            Console.Write(
                "| " + string.Join(" | ", PrimaryNumbersList.Order().Take(20)) + " |\n"
                + "Czas wykonywania: " + Math.Round(stopwatch.ElapsedMilliseconds / 1000.0)
                + "s | " + stopwatch.ElapsedMilliseconds + "ms\nIlość liczb: " + PrimaryNumbersList.Count + "\n");
        }
    }
}
