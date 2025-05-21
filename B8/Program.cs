using System;
using System.Threading.Tasks;

namespace B8 {
    class Program {
        static async Task Main(string[] args) {
            Graph graph = Graph.ZadanieDomowe();
            graph.Save(@"./B8/graf.txt");
            Console.WriteLine(graph.CountAllLinks());
            Console.WriteLine(string.Join(" | ",
                graph.GetNodeValue(graph.BFS(graph.GetNodeValue(1))) ?? throw new Exception("Wrong Data!")));
            Console.WriteLine(
                await graph.CheckConnectivity(
                    graph.GetNodeValue(1),
                    graph.GetNodeValue(graph.GetNodeCount() - 1)
                )
            );
        }
    }
}
