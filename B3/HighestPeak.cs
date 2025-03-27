using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3 {
    class HighestPeak {
        public string Country { get; private set; }
        public string Name { get; private set; }
        public int Elevation { get; private set; }
		
        public HighestPeak(string country, string name, int elevation) {
            Name = name;
            Country = country;
            Elevation = elevation;
        }
		
        public void ShowInfo() {
            Console.WriteLine(" > Country: " + Country + ", Name: " + Name + ", Elevation: " + Elevation);
        }
    }
}
