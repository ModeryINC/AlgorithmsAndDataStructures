using System;

namespace B1 {
    public class RandomFunctions {
        public static string Multiply(string str = "htd", int n = 1) {
            return string.Join(" ", Enumerable.Repeat(str, n).ToList());
        }
        public static string TwoToOne(string str1 = "grdgrd", string str2 = "dadwa") {
            return string.Join("", [str1[^1], str2[0]]);
        }
        public static bool NAND(bool a, bool b) {
            return ((a != b) != (a == b == false));
        }
    }
}