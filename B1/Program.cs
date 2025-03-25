using System;
using Microsoft.VisualBasic;

namespace B1 {
    internal class Program {
        static void Main(string[] args) {
            Fibonacci fib = new() {N = 10};
            Calculator calculator = new();
            Print.F(fib.CalcFibonacciRecursive());
            List<int> list = fib.CalcFibonacciLoop();
            Print.F(string.Join(" | ", list.GetRange(1, list.Count - 1)));
            Print.F(UseApi.XyzApi());
            Print.F(UseApi.GetCount());
            UseApi.ClearApiCache();
            Print.F(UseApi.GetCount());
            Print.F(calculator.Variables?.A ?? 0);
            Print.F(RandomFunctions.TwoToOne("Testowe", "String'i"));
            Print.F(RandomFunctions.Multiply("fef", 5));
        }
    }
}