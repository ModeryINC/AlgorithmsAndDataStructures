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
        public static async Task<List<int>> Find(int start = 1, int count = 833334) {
            await Task.Run(() => {});
            if (start < 1 || count < 0) return [];
            ConcurrentBag<int> PrimaryNumbersList = [];
            Parallel.For(0, count, i => {
                int numberBase = (i + start) * 6;
                int numberFirst = numberBase + 1,
                    numberSecond = numberBase + 5;
                if(IsPrimary(numberFirst)) PrimaryNumbersList.Add(numberFirst);
                if(IsPrimary(numberSecond)) PrimaryNumbersList.Add(numberSecond);
            });
            return [.. PrimaryNumbersList.Order()];
        }
	}
}
