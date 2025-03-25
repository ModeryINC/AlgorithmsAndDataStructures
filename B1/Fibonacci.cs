using System;

namespace B1 {
    public class Fibonacci {
        public int N { get; init; } = 5;
        public int CalcFibonacciRecursive(int number = -1) {
            if ( number == -1) number = N;
            if ( number > 1) {
                return CalcFibonacciRecursive( number - 1) + CalcFibonacciRecursive( number - 2);
            } else return 1;
        }
        public List<int> CalcFibonacciLoop(int number = -1) {
            if ( number < 0) number = N;
            int fibElementOne = 1, fibElementTwo = 1;
            List<int>  fibElementsList = [];
            if ( number == 0 || number == 1 ) {
                fibElementsList.Insert(0, fibElementOne);
                return fibElementsList;
            }
            for (int i = 0; i <= number-2; i++) {
                int fibElementNext = fibElementOne + fibElementTwo;
                fibElementsList.Add(fibElementNext);
                fibElementOne = fibElementTwo;
                fibElementTwo = fibElementNext;
            }
            fibElementsList.Insert(0, (fibElementOne > fibElementTwo) ? fibElementOne : fibElementTwo);
            return fibElementsList;
        }
    }
}