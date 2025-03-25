using System;
using System.Collections.Generic;
using System.Text;

namespace B2 {
    class WorldMarket {
        private static readonly Random random = new();
        public static int GetInitialPricePerKg() {
            return random.Next(100, 1001);
        }
        public static int GetNewPricePerKg(int oldPrice) {
            return oldPrice + random.Next(-50, 201);
        }
    }
}