using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace B7 {
    partial class Tree {
        private TreeNode root; // korzen drzewa
        public Tree() { // konstruktor
            root = null;
        }
        public void Add(int value) { // dodawanie nowych elementow
            if (root == null) root = new TreeNode(value); // jesli drzewo jest puste, to stworz korzen
            else root.Add(value); // jesli drzewo nie jest puste, wywolaj odpowiednia metode z klasy TreeNode
        }
        public bool Search(int value) {
            if (root == null) return false; // jesli drzewo jest puste, to nic nie znajdziemy
            else return root.Search(value); // jesli drzewo nie jest puste, wywolaj odpowiednia metode z klasy TreeNode
        }
        public int? MinValue() {
            if (root == null) return null;
            else return root.MinValue();
        }
        public int? MaxValue() {
            if (root == null) return null;
            else return root.MaxValue();
        }
        public int? SumValues() {
            //* Ja bym za pierwszym razem tylko to wyliczał a potem przy jakichkolwiek zmianach bym to
            //* powiększał / zmniejszał, ale nie można ingerować w powstałe metody i parametry :(
            if (root == null) return null;
            int sum = 0;
            root.SumValues(ref sum);
            return sum;
        }
        public int CountNodes() {
            //* Ja bym za pierwszym razem tylko to wyliczał a potem przy jakichkolwiek zmianach bym to
            //* powiększał / zmniejszał, ale nie można ingerować w powstałe metody i parametry :(
            if (root == null) return 0;
            int count = 0;
            root.CountNodes(ref count);
            return count;
        }
        public int CountLinks() {
            //* Ja bym za pierwszym razem tylko to wyliczał a potem przy jakichkolwiek zmianach bym to
            //* powiększał / zmniejszał, ale nie można ingerować w powstałe metody i parametry :(
            if (root == null) return 0;
            int count = 0;
            root.CountNodes(ref count);
            return count - 1;
        }
        public int? Depth(int value) {
            if (root == null) return null;
            int? level = 0;
            root.FindNodeLevel(value, ref level);
            return level;
        }
        // ponizej znajduje sie kod pomocniczy dla zadania 3 i zadania domowego
        public void Print() {
            TreePrint.Print(root);
        }
        public static Tree ZadanieDomowe() {
            Tree ans = new();
            Random rng = new();
            int extraSize = rng.Next(10);
            for (int i = 0; i < 10; i++) ans.Add(rng.Next(100));
            ans.Add(49);
            for (int i = 0; i < 10 + extraSize; i++) ans.Add(rng.Next(100));
            return ans;
        }
    }
}
