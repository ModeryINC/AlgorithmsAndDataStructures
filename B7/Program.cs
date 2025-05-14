using System.Collections.Generic;
using System;

namespace B7 {
    class Program {
        static void Main(string[] args) {
            Tree tree = Tree.ZadanieDomowe();
            Dictionary<string, int?> functions = new(){
                {"Minimala wartość: ", tree.MinValue()},
                {"Maksymalna wartość: ", tree.MaxValue()},
                {"Suma wartości: ", tree.SumValues()},
                {"Ilość node'ów: ", tree.CountNodes()},
                {"Ilość połączeń: ", tree.CountLinks()},
                {"Głębokość node'a 49: ", tree.Depth(49)},
            }; 
            foreach (var pair in functions) {
                Console.Write(pair.Key);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(pair.Value + "\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}