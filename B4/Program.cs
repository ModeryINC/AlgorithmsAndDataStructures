using System;
using System.Collections.Generic;
using System.Linq;

namespace B4 {
    class Program {
        static void Main(string[] args) {
            List<string> words = ZadanieDomowe.Read();
            
            // A
            Console.Write("\n\nA\n");
            List<string> answerA = words.FindAll(word => word.Length == 13);
            Console.Write(string.Join(" | ", answerA));
            
            // B
            Console.Write("\n\nB\n");
            List<char> answerB = [.. words.Select(word => word[0])];
            Console.Write(string.Join(" | ", answerB.Where((word, index) => index < 20)));
            
            // C
            Console.Write("\n\nC\n");
            string vowels = "AEIOUYĄĘÓaeiouyąęó";
            List<string> answerC = [.. words.Select(word => new string([.. word.Select(ch => vowels.Contains(ch) ? 'a' : ch)]))];
            Console.Write(string.Join(" | ", answerC.Where((word, index) => index < 20)));
            
            // D
            Console.Write("\n\nD\n");
            string answerD = words.Where(word => word.Length > 1 && word[1] == 'a').ToList().Order().First();
            Console.Write(answerD); 
            
            // E
            Console.Write("\n\nE\n");
            double answerE = words.Distinct().ToList().Average(word => word.Length);
            Console.Write("{0:0.0}", answerE); 
            
            // F
            Console.Write("\n\nF\n");
            bool answerF = words.Where(word => word.Contains('z') && word.Length == 10).ToList().Count != 0;
            Console.Write(answerF); 
            
            // G
            Console.Write("\n\nG\n");
            int answerG = words.Sum(word => word.Length);
            Console.Write(answerG); 
            
            // H
            Console.Write("\n\nH\n");
            string? answerH = string.Join("", words.Where(word => word.Length == 1));
            Console.Write(answerH);
            
            // I
            Console.Write("\n\nI\n");
            List<string> answerI = [.. words.Where((word, index) => index > 0 && words[index - 1] == "ale").ToList().Select(word => word = "ale " + word)];
            Console.Write(string.Join(" | ", answerI));
            
            // J
            Console.Write("\n\nJ\n");
            List<string> answerJ = [.. words.Where(word => word.Contains('ź') || word.Contains('Ź')).ToList().Select(word => word += " - " + word.Length.ToString())];
            Console.Write(string.Join(" | ", answerJ));
        }
        
        private static object Word(object source, int arg2) {
            throw new NotImplementedException();
        }
    }
}
