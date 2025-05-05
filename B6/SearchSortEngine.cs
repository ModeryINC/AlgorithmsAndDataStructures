using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.IO;
using System;
using System.ComponentModel;

namespace B6 {
    class SearchSortEngine {
        private List<int> numbers;
        private readonly int size;
        public SearchSortEngine(int n){
            //constructor
            if (n > 0) size = n;
            else {
                Console.WriteLine("List size cannot be negative - defaulting to 10 instead");
                size = 10;
            }
            numbers = new List<int>(size);
            Random rnd = new();
            for (int i = 0; i < size; i++) {
                numbers.Add(rnd.Next(10000));
            }
        }
        // utility methods
        public void Reshuffle() {
            // shuffle list contents 
            // Fisher-Yates shuffle algorithm
            Random rnd = new();
            int j = size;
            while (j > 1) {
                int i = rnd.Next(j);
                j--;
                (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
            }
        }
        public void SaveList(string filename) {
            // save list to "filename.txt"
            // uwaga dla Panstwa - pliki domyslnie zapisuja sie w folderze aplikacji
            // typowo jest to katalog roboczy -> bin -> Debug (-> netcoreappX.Y jesli taki katalog wystepuje)
            try {
                List<String> listStr = numbers.ConvertAll<string>(i => i.ToString()); // convert list<int> to list<string>
                File.WriteAllLines("./B6/" + filename + ".txt", [.. listStr]); // write the list 
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be opened or a writing error has occurred:");
                Console.WriteLine(e.Message);
            }
        }
        public void SelectionSort() {
            for (int i = 0; i < size; i++) {
                int minIndex = i;
                for (int j = i + 1; j < size; j++) {
                    if (numbers[minIndex] > numbers[j]) minIndex = j;
                }
                if (minIndex != i) (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
            }
        }
        public void InsertionSort() {
            for (int i = 1; i < size; i++) {
                int keyValue = numbers[i];
                int insertIndex = i;
                for (int j = i - 1; j >= 0; j--) {
                    if (numbers[j] > keyValue) {
                        insertIndex = j;
                    } else break;
                }
                if (insertIndex != i) {
                    numbers.RemoveAt(i);
                    numbers.Insert(insertIndex, keyValue);
                }
            }
        }
        public void BubbleSort() {
            for (int i = size; i > 0; i--) {
                for (int j = 1; j < i; j++) {
                    if (numbers[j] < numbers[j-1]) (numbers[j], numbers[j-1]) = (numbers[j-1], numbers[j]);
                }
            }
        }
        public bool LinearSearch(int number) {
            for(int i = 0; i < size; i++) {
                if (numbers[i] == number) return true;
            }
            return false;
        }
        public bool JumpSearch(int number) {
            int jumpLength = (int)Math.Sqrt(size),
                prev = jumpLength;
            for (int i = jumpLength; i < size; i += jumpLength) {
                if (numbers[i - jumpLength] < number && number < numbers[i]) {
                    for (int j = i - jumpLength; j < i; j++) {
                        if (numbers[j] == number) return true;
                    }
                    return false;
                }
            }
            // while (prev < size - jumpLength && numbers[prev] < number && number < numbers[prev + jumpLength]) {
            //     prev += jumpLength;
            // }
            // for (int i = prev; i <= prev + jumpLength && i < size; i++) {
            //     if (numbers[i] == number) return true;
            // }
            return false;
        }
    }
}
