using System;
using System.Collections.Generic;
using System.Text;

namespace B2 {
    class Destination(int distance, string portName)
    {
        private readonly int distance = (distance > 0) ? distance : 0;
        private readonly string portName = portName;
        public int GetDistance() {
            return distance;
        }
        public string GetPortName() {
            return portName;
        }
    }
}
