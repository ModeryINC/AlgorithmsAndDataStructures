using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace B5 {
    class PrimaryNumbers {
        public static bool IsPrimary(int number, int divider = 2) {
            //* Iteracyjnie jest średnio 10x szybsze (R: 8000ms; I: 800ms)
            //! if (number % divider == 0) return false;
            //! if (number / divider < divider) return true;
            //! return IsPrimary(number, divider+1);
            if (number < 2) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;
            int limit = (int)Math.Sqrt(number);
            for (int i = 5; i <= limit; i += 6)
                if (number % i == 0 || number % (i + 2) == 0) return false;
            return true;
        }
        public static List<int> Find(int start = 0, int count = 833334) {
            if (start < 0 || count < 0) return [];
            ConcurrentBag<int> PrimaryNumbersList = [];
            Parallel.For(0, count, i => {
                if (i == 0 && start == 0) {
                    PrimaryNumbersList.Add(2);
                    PrimaryNumbersList.Add(3);
                    PrimaryNumbersList.Add(5);
                    return;
                }
                int numberBase = (i + start) * 6;
                int numberFirst = numberBase + 1,
                    numberSecond = numberBase + 5;
                if(IsPrimary(numberFirst)) PrimaryNumbersList.Add(numberFirst);
                if(IsPrimary(numberSecond)) PrimaryNumbersList.Add(numberSecond);
            });
            return [.. PrimaryNumbersList];
        }
        public static async Task<List<int>> CreateTasks(int start = 0, int end = 10000000, int parts = 2) {
            if (start < 0 || end < 2 || start > end || parts < 1 || parts > 100) return [];
            int chunkSize = ((end - start) / (6 * parts)) + 1;
            List<Task<List<int>>> tasks = [];
            for (int i = 0; i < parts; i++) {
                int chunkStart = start + i * chunkSize;
                int chunkCount = (i == parts - 1) ? (end / 6) - (chunkSize * i) : chunkSize;
                tasks.Add(Task.Run(() => Find(chunkStart, chunkCount)));
            }
            var results = await Task.WhenAll(tasks);
            return [.. results.SelectMany(x => x).Order()];
        }
	}
}
