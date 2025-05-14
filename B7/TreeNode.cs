using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace B7 {
    partial class TreeNode {
        public int Val { get; set; } // wartosc przechowywana w wezle
        public TreeNode Left { get; set; } // wezel na lewo od obecnego ("dziecko")
        public TreeNode Right { get; set; } // wezel na prawo od obecnego ("dziecko")
        public TreeNode Up { get; set; } // wezel w gore od obecnego ("rodzic")
        public TreeNode(int value) { // konstruktor do tworzenia nowych wezlow
            Val = value;
            Left = Right = Up = null;
        }
        private TreeNode(int value, TreeNode parent) { // konstruktor prywatny, uzywany dla wygody
            Val = value;
            Left = Right = null;
            Up = parent;
        }
        public void Add(int value) { // rekurencyjna metoda pozwalajaca dodawac nowe wezly
            if (value >= Val) { // idziemy w prawo
                if (Right == null) Right = new TreeNode(value, this); // jezeli miejsce po prawej jest wolne - stworz nowy wezel tam
                else Right.Add(value); // jezeli nie - kolejne wywolanie rekurencyjne
            } else { // idziemy w lewo
                if (Left == null) Left = new TreeNode(value, this); // jezeli miejsce po lewej jest wolne - stworz nowy wezel tam
                else Left.Add(value); // jezeli nie - kolejne wywolanie rekurencyjne
            }
        }
        public bool Search(int value) { // rekurencyjna metoda pozwalajaca sprawdzac czy wezel o danej wartosci istnieje
            if (value == Val) return true; 
            else if (value > Val && Right != null) return Right.Search(value); // szukana wartosc jest wieksza - szukaj dalej po prawej
            else if (value < Val && Left != null) return Left.Search(value); // szukana wartosc jest mniejsza - szukaj dalej po lewej
            return false; // nie ma juz gdzie dalej szukac, a wartosci nie znaleziono - zwracamy false
        }
        public int MinValue() {
            if (Left != null) return Left.MinValue();
            return Val;
        }
        public int MaxValue() {
            if (Right != null) return Right.MaxValue();
            return Val;
        }
        public void SumValues(ref int sum) {
            sum += Val;
            Right?.SumValues(ref sum);
            Left?.SumValues(ref sum);
        }
        public void CountNodes(ref int count) {
            count++;
            Right?.CountNodes(ref count);
            Left?.CountNodes(ref count);
        }
        public int? FindNodeLevel(int value, ref int? currentLevel) {
            currentLevel++;
            if (value == Val) return currentLevel; 
            else if (value > Val && Right != null) return Right.FindNodeLevel(value, ref currentLevel); // szukana wartosc jest wieksza - szukaj dalej po prawej
            else if (value < Val && Left != null) return Left.FindNodeLevel(value, ref currentLevel); // szukana wartosc jest mniejsza - szukaj dalej po lewej
            return null;
        }
    }
}
