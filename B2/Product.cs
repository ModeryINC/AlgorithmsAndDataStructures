using System;
using System.Collections.Generic;
using System.Text;

namespace B2 {
    class Product {
        private readonly int currentPrice = WorldMarket.GetInitialPricePerKg();
        private readonly string name = "";
        private int mass = 0;
        public Product(string name) {
            this.name = name;
            this.mass = 0;
        }
        public Product(string name, int mass) {
            this.name = name;
            if (mass > 0) this.mass = mass;
            else this.mass = 0;
        }
        public string GetName() { return name; }
        public int GetMass() { return mass; }
        public void SetMass(int newMass) { mass = (newMass > 0) ? newMass : mass; }
        public int GetCurrentValue() { return currentPrice*mass; }
        // public string Name { get { return name }; }
        // public int Mass { get { return mass; } set { if(value > 0) mass = value; } }
    }
}
