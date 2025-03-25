using System;

namespace B1 {
    public class Calculator {
        public Variables? Variables {get; set; }
        private float a = 1;
        private float b = 2;

        public Calculator() {
            if (Variables != null) {
                a = Variables.A;
                b = Variables.B;
            }
        }

        public float A {
            get { return a; }
            set { if(float.IsRealNumber(value)) a = value; }
        }
        public float B {
            get { return b; }
            set { if(float.IsRealNumber(value)) b = value; }
        }
        public float Add() { return a + b; }
        public float Subtrack() { return a - b; }
        public float Multiply() { return a * b; }
        public float Devision() { return a / b; }
    }
}