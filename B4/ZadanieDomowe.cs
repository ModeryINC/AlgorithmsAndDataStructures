using System;
using System.Collections.Generic;
using System.IO;

namespace B4 {
    class ZadanieDomowe {
        public static List<string> Read() {
            //tutaj nalezy zmienic sciezke do pliku
            string filepath = "./B4/KsiegaPierwszaBezInterpunkcji.txt";
            // wczytywanie
            try {
                StreamReader sr = new(filepath);
                List<string> ans = [];
                string? line = sr.ReadLine();
                while (line != null) {
                    ans.AddRange(line.Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    line = sr.ReadLine();
                }
                sr.Close();
                return ans;
            }
            catch(Exception e) {
                Console.WriteLine("Nie udalo sie wczytac pliku ze sciezki " + filepath + ": " + e.Message);
                return [];
            } 
        }


    }
}
