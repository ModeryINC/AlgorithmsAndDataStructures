using System;

namespace B1 {
    public class Print {
        public static void F(params object[] parameters) {
            Console.WriteLine(" | " + string.Join(" | ", parameters) + " |");
            return;
        }
        public static void Multi(string str, int n) {
            
        }
    }
}