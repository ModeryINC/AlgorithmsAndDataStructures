using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BG {
    class Program {
        static async Task Main(string[] args) {
            if (!int.TryParse(Console.ReadLine(), out int width) ||
                !int.TryParse(Console.ReadLine(), out int heigth)) {
                    Console.Write("Wrong input data!");
                    return;
            }
            GameOfLife game = new(width, heigth);
            await game.Start();
        }
    }
}