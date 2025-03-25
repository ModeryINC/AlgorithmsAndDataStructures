using System;
using System.Collections.Generic;
using System.Text;

namespace B2 {
    class Ship {
        private Engine engine;
        private readonly int unloadedMass;
        public Ship() {
            this.engine = new(Fuel.Hydrogen);
            this.unloadedMass = 50;
        }
        public Ship(Engine engine, int unloadedMass) {
            this.engine = engine;
            this.unloadedMass = (unloadedMass > 0) ? unloadedMass : 50;
        }
        public Engine GetEngine() {
            return engine;
        }
        public void SetEngine(Engine engine) {
            this.engine = engine;
        }
        // public Engine Engine { get; set; }
        public bool TravelOffer(Destination destination, Product firstProduct, Product secondProduct) {
            int distance = destination.GetDistance(),
                firstProductMass = firstProduct.GetMass(),
                secondProductMass = secondProduct.GetMass(),
                wholeMass = unloadedMass + firstProductMass + secondProductMass,
                expenses = engine.TravelCost(distance, wholeMass),
                income = firstProduct.GetCurrentValue() + secondProduct.GetCurrentValue(),
                profit = income - expenses,
                travelTime = engine.TravelTime(distance, wholeMass);
            if (
                distance <= 0 ||
                firstProductMass <= 0 ||
                secondProductMass <= 0 ||
                profit < 1000
            ) return false;
            Console.Write(
                "Offer Accepted!\n  1) Transported Suplies:\n    > " +
                firstProduct.GetName() + " - " + firstProductMass +
                ((firstProductMass == 1) ? " Ton." : " Tons.") +
                "\n    > "  +  secondProduct.GetName() + 
                " - " + secondProductMass +
                ((secondProductMass == 1) ? " Ton." : " Tons.") +
                "\n  2) Travel Length: "  + travelTime + 
                ((travelTime == 1) ? " hour." : " hours.") + 
                "\n  3) Income: " + income + " zł.\n  4) Expenses: " +
                expenses + " zł.\n\n"
            );
            return true;
        }
    }
}
