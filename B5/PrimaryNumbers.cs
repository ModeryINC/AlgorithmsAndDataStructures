using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace B5 {
    class PrimaryNumbers {
        public static bool IsPrimary(int number, int divider = 2) {
            if (number % divider == 0) return false;
            if (number / divider < divider) return true;
            return IsPrimary(number, divider+1);
        }
        public static async Task<List<int>> Find(int start = 1, int end = 833334) {
            await Task.Run(() => {});
            if (start < 1 || end < start) return [];
            ConcurrentBag<int> PrimaryNumbersList = [];
            Parallel.For(0, end, i => {
                int num = (i + start) * 6 + 1;
                if(PrimaryNumbers.IsPrimary(num)) PrimaryNumbersList.Add(num);
                num +=4;
                if(PrimaryNumbers.IsPrimary(num)) PrimaryNumbersList.Add(num);
            });
            return [.. PrimaryNumbersList.Order()];
        }
	}
}
