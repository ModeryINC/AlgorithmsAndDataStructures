using System;
using System.Runtime.ExceptionServices;

namespace B2 {
    class Program {
        static void Main(string[] args) {
            // statki
            Ship myShip = new(new Engine(Fuel.Diesel), 25);
            Ship mySubmarine = new(new Engine(Fuel.Nuclear), 15);

            // produkty
            Product p1 = new("Corn", 4);
            Product p2 = new("Cocoa", 5);
            Product p3 = new("Coconut", 9);
            Product p4 = new("Coffee", 2);

            // chetni do kupienia
            Destination aberdeen = new(2100, "Aberdeen");
            Destination bilbao = new(800, "Bilbao");
            Destination ceuta = new(1200, "Ceuta");

            // jednorazowa oferta przewozu
            mySubmarine.TravelOffer(ceuta, p1, p2);
            // ta oferta bedzie skladana do skutku
            bool accepted = false;
            while (!accepted) {
                accepted = myShip.TravelOffer(aberdeen, p3, p4);
            }
            // wymiana silnika na nowy model i kolejna oferta
            myShip.SetEngine(new Engine(Fuel.Hydrogen));
            myShip.TravelOffer(bilbao, p2, p4);
        }
    }
}
