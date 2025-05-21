// using System;
// using System.Data.Common;
// using System.Reflection.Metadata;
// using System.Threading.Tasks;

// namespace BG {
//     class GameOfLife(int width, int heigth) {
//         int width = width > 2 ? width : 20,
//             heigth = heigth > 2 ? heigth : 20,
//             solitude = 1,
//             overpopulation = 4,
//             birth = 3;
//         bool[,] board = new bool[width+2, heigth+2];
//         TaskCompletionSource<bool[,]> boardState = new( new bool[width + 2, heigth + 2]);
//         bool doAction = false;
//         private Task sequence = new(() => {}),
//                         print = new(() => {});
//         public async Task<bool> Wait() {
//             while(doAction) {}
//             await Task.Delay(1000);
//             return false;
//         }
//         public Task GetSequence() {
//             return sequence;
//         }
//         private void GenerateBoard() {
//             Random random = new();
//             for (int i = 1; i <= width; i++) {
//                 for (int j = 1; j <= heigth; j++) {
//                     board[i,j] = random.Next(2) == 1;
//                 }
//             }
//         }
//         private int CheckElementNeighbors(int[] coordinates) {
//             int count = 0;
//             if (board[coordinates[0] - 1, coordinates[1]]) count++;
//             for (int i = 0; i < 9; i++) {
//                 if (i % 3 != 1 && board[
//                     coordinates[0] + (i % 3 == 0 ? -1 : i % 3 == 2 ? 1 : 0),
//                     coordinates[1] + (i / 3 < 1 ? -1 : i / 3 >= 2 ? 1 : 0)]
//                 ) count++;
//             }
//             return count;
//         }
//         private void SetNewValue(ref bool boardSpace, int count) {
//             if (boardSpace && count <= solitude) boardSpace = false; // Osamotnienie
//             else if (boardSpace && count >= solitude && count < overpopulation) boardSpace = true; // Przeżycie
//             else if (boardSpace && count >= overpopulation) boardSpace = false; // Przeżycie
//             else if (!boardSpace && count == birth) boardSpace = true; // Przeżycie
//         }
//         private void Step() {
//             for (int i = 1; i <= width; i++) {
//                 for (int j = 1; j < heigth - 1; j++) {
//                     SetNewValue(ref board[i, j], CheckElementNeighbors([width, heigth]));
//                 }
//             }
//         }
//         private void Sequence() {
//             while(doAction) {
//                 Step();
//             }
//         }
//         private async void ShowData() {
//             while(doAction) {
//                 bool[,] display = await boardState.Task;
//                 char[] line = new char[20];
//                 Console.Clear();
//                 for (int i = 1; i <= width; i++) {
//                     for (int j = 1; j <= heigth; j++) {
//                         if(display[i,j]) Console.ForegroundColor = ConsoleColor.Green;
//                         else Console.ForegroundColor = ConsoleColor.Red;
//                         Console.Write("#");
//                     }
//                 }
//                 Console.Write("\n");
//             }
//         }
//         public async Task<bool> Start() {
//             GenerateBoard();
//             doAction = true;
//             sequence = new(() => Sequence());
//             print = new(() => ShowData());
//             await sequence;
//             await print;
//             return true;
//         }
//         public bool[,] Stop() {
//             doAction = false;
//             return board;
//         }
//         public void Resume() {
//             doAction = true;
//             sequence = new(() => Sequence());
//         }
//     }
// }
using System;
using System.Threading.Tasks;

namespace BG {
    class GameOfLife {
        private readonly int width, height;
        private bool[,] board;
        private bool doAction = false;
        private Task? sequence, print;
        private readonly int solitude = 1, overpopulation = 4, birth = 3;
        public GameOfLife(int width, int height) {
            this.width = width > 2 ? width : 20;
            this.height = height > 2 ? height : 20;
            board = new bool[this.width + 2, this.height + 2];
        }
        public GameOfLife(int width, int height, int solitude, int alive, int overpopulation, int birth) {
            this.width = width > 2 ? width : 20;
            this.height = height > 2 ? height : 20;
            board = new bool[this.width + 2, this.height + 2];
            this.solitude = solitude > 0 && solitude < 7
                ? solitude : throw new Exception("Wrong solitude value!");
            int alive_ = alive > solitude && overpopulation < 8
                ? solitude : throw new Exception("Wrong alive value!");
            this.overpopulation = overpopulation > alive_ && overpopulation < 9 ?
                solitude : throw new Exception("Wrong overpopulation value!");
            this.birth = birth > 0 && birth < 9
                ? birth : throw new Exception("Wrong birth value!");
        }
        public void ChangeElementValue(int idx, int idy) { board[idx, idy] = !board[idx, idy]; }
        private void GenerateBoard() {
            Random random = new();
            for (int i = 1; i <= width; i++) {
                for (int j = 1; j <= height; j++) {
                    board[i, j] = random.Next(2) == 1;
                }
            }
        }
        private int CheckElementNeighbors(int[] coordinates) {
            int count = 0;
            int x = coordinates[0], y = coordinates[1];
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (i == 0 && j == 0) continue;
                    if (board[x + i, y + j]) count++;
                }
            }
            return count;
        }
        private void SetNewValue(ref bool boardSpace, int count) {
            if (boardSpace && count <= solitude) boardSpace = false;
            else if (boardSpace && count < overpopulation) boardSpace = true;
            else if (boardSpace && count >= overpopulation) boardSpace = false;
            else if (!boardSpace && count == birth) boardSpace = true;
        }
        private void Step() {
            bool[,] next = (bool[,])board.Clone();
            for (int i = 1; i <= width; i++) {
                for (int j = 1; j <= height; j++) {
                    int neighbors = CheckElementNeighbors([i, j]);
                    bool state = board[i, j];
                    SetNewValue(ref state, neighbors);
                    next[i, j] = state;
                }
            }
            board = next;
        }
        private void Sequence() {
            while (doAction) {
                Step();
                Task.Delay(500).Wait();
            }
        }
        private void ShowData() {
            Console.CursorVisible = false;
            while (doAction) {
                Console.SetCursorPosition(0, 0);
                for (int i = 1; i <= width; i++) {
                    for (int j = 1; j <= height; j++) {
                        Console.ForegroundColor = board[i, j] ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.Write(board[i, j] ? "O" : "#");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Task.Delay(500).Wait();
            }
        }
        public async Task<bool> Start() {
            GenerateBoard();
            doAction = true;
            Console.Clear();
            sequence = Task.Run(() => Sequence());
            print = Task.Run(() => ShowData());
            await Task.WhenAll(sequence, print);
            return true;
        }
        public bool[,] Stop() {
            doAction = false;
            return board;
        }
        public void Resume() {
            doAction = true;
            sequence = Task.Run(() => Sequence());
            print = Task.Run(() => ShowData());
        }
    }
}
