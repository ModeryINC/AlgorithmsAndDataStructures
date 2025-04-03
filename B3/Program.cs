using System.Runtime.ExceptionServices;
using System.Collections.Generic;
using System;

namespace B3 {
    class Program {
        static void Main(string[] args) {
            List<HighestPeak> peaksListSecond = [];
            HighestPeak austriaHighestPeak = new("", "", 0);
            List<HighestPeak> peaksList = new();
            string[] sourceArray = ["Lithuania", "Latvia", "Estonia"];
            Dictionary<string, double> countryPopulations = Homework.CreateDictionary();
            
            peaksList.ForEach(peak => {
                if (peak.Country == "Austria" && peak.Elevation > austriaHighestPeak.Elevation) austriaHighestPeak = peak;
                if (4000 < peak.Elevation && peak.Elevation < 5000 ) peaksListSecond.Add(peak);
            });
            
            // Można też:
            // foreach(HighestPeak peak in peaksList) {
            //     if (peak.Country == "Austria" && peak.Elevation > austriaHighestPeak.Elevation) austriaHighestPeak = peak;
            //     if (4000 < peak.Elevation && peak.Elevation < 5000 ) peaksListSecond.Add(peak);
            // }
            
            Console.Write("\n\n#01\n");
            austriaHighestPeak.ShowInfo();
            
            // Console.Write("\n\n#02\n");
            // peaksList[^2].ShowInfo();
            
            Console.Write("\n\n#03\n > ");
            Console.Write("Średnia wysokość: " + ((peaksList.Count != 0) ? peaksList.Sum(peak => peak.Elevation) / peaksList.Count : "--")); // Lub try catch
            
            Console.Write("\n\n#04\n");
            peaksList.ForEach(peak => peak.ShowInfo());
            
            Console.Write("\n\n#05\n");
            peaksList = [.. peaksList.OrderBy(peak => peak.Elevation)];
            for (int i = 0; i < 10; i++) peaksList[i].ShowInfo();
            
            Console.Write("\n\n#06\n > ");
            Console.Write(countryPopulations.FirstOrDefault(country => country.Value == 5.5).Key);
            
            Console.Write("\n\n#07\n > ");
            countryPopulations.Add("newCountry", 50.7);
            Console.Write(countryPopulations.Count);
            
            Console.Write("\n\n#08\n > ");
            Console.Write(countryPopulations.Average(country => country.Value));
            
            Console.Write("\n\n#09\n > ");
            Console.Write(string.Join(" | ", countryPopulations.Where(country => 10 < country.Value && country.Value < 20).ToDictionary().Keys));
            
            Console.Write("\n\n#10\n > ");
            Console.Write(countryPopulations.Where(country => sourceArray.Contains(country.Key)).ToDictionary().Values.Sum());
        }
    }
}
