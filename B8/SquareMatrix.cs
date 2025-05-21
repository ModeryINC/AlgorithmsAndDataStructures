using System;
using System.Collections.Generic;
using System.Text;

namespace B8 {
    // wrapper class for a dynamically allocated square matrix that is always symmetrical
    // uwaga: niektore z zaprezentowanych tu rozwiazan wykraczaja poza zakres naszego kursu C#
    // zostaly jednak uzyte dla wygody
    class SquareMatrix {
        private List<List<int>> values;
        public int Size { get; private set; }
        public int this[int a, int b] {
            get {
                if (a < 0 || b < 0 || a > Size || b > Size) return -1;
                return values[a][b];
            }
            set {
                if (a < 0 || b < 0 || a > Size || b > Size) return;
                values[a][b] = value;
            }
        }
        public SquareMatrix(int size) {
            if (size >= 0) {
                values = [];
                Size = size;
                for (int i = 0; i < size; i++) {
                    values.Add([]);
                    for (int j = 0; j < size; j++) {
                        values[i].Add(0);
                    }
                }
            }
            else throw new ArgumentOutOfRangeException("size", "Matrix size must be positive");
        }
        public void Grow() { // increase size by 1 and fill new indices with zeros
            Size++;
            values.Add([]);
            for (int i = 0; i < Size; i++) values[Size - 1].Add(0);
            for (int i = 0; i < Size; i++) values[i].Add(0);
        }
        public void Print() {
            Console.WriteLine("Matrix:");
            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    Console.Write(values[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public List<int>? GetRow(int Index) {
            return Index < values.Count && Index >= 0 ? values[Index] : null;
        }
    }
}
