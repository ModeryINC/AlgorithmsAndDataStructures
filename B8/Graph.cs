using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace B8 {
    class Graph {
        // class representing an undirected graph
        public SquareMatrix AdjacencyMatrix { get; private set; } // not meant to be used directly, but gettable just in case
        public List<int> NodeValues { get; private set; } // same as above
        private TaskCompletionSource<bool> taskCompletionSource = new(false);
        public Graph() {
            // initialize empty matrix and empty list
            AdjacencyMatrix = new SquareMatrix(0);
            NodeValues = [];
        }
        public void AddNode(int value) {
            NodeValues.Add(value); // add new node
            AdjacencyMatrix.Grow(); // increase adjacency matrix size by 1
        }
        public void AddConnection(int x1, int x2) {
            if (x1 < 0 || x2 < 0 || x1 >= NodeValues.Count || x2 >= NodeValues.Count) {
                Console.WriteLine("Blad: indeksy macierzy musza byc nieujemne i nie moga byc wieksze niz rozmiar macierzy");
                return;
            }
            if (x1 == x2) {
                Console.WriteLine("Blad: polaczenia do samego siebie sa niedozwolone");
                return;
            }
            AdjacencyMatrix[x1, x2] = 1; // 1 represents a conection, 0 represents no connection
            AdjacencyMatrix[x2, x1] = 1; // we model an undirected graph, so the matrix is always symmetrical
        }
        public void Print() {
            Console.WriteLine();
            Console.WriteLine("Printing graph:");
            Console.WriteLine("--------");
            PrintNodes();
            Console.WriteLine("--------");
            PrintMatrix();
            Console.WriteLine("--------");
            Console.WriteLine();
        }
        public void PrintNodes() {
            for (int i = 0; i < NodeValues.Count; i++) Console.WriteLine("node" + i + ": " + NodeValues[i]);
        }
        public void PrintMatrix() {
            AdjacencyMatrix.Print();
        }
        public void Save(string filepath) {
            // writing to a file
            try {
                StreamWriter sr = new(filepath, false);
                sr.WriteLine("Matrix:");
                for (int i = 0; i < NodeValues.Count; i++) {
                    for (int j = 0; j < NodeValues.Count - 1; j++) {
                        sr.Write(AdjacencyMatrix[i,j] + ", ");
                    }
                    sr.Write(AdjacencyMatrix[i, NodeValues.Count - 1]);
                    sr.WriteLine();
                }
                sr.WriteLine("\nNodes:");
                for (int i = 0; i < NodeValues.Count; i++) sr.WriteLine(NodeValues[i]);
                sr.Close();
            }
            catch (Exception e) {
                Console.WriteLine("Nie udalo sie zapisac pliku " + filepath + ": " + e.Message);
            }
        }
        public int GetNodeValue(int index) { return NodeValues[index]; }
        public int GetNodeCount() { return NodeValues.Count; }
        private void BFS(int startIndex, ref CancellationTokenSource cancellationTokenSource, int endValue) {
                Queue<int> queue = new();
                HashSet<int> visited = [];
                queue.Enqueue(startIndex);
                visited.Add(startIndex);
                while (queue.Count > 0 && !cancellationTokenSource.Token.IsCancellationRequested) {
                    int index = queue.Dequeue();
                    if (NodeValues[index] == endValue) {
                        cancellationTokenSource.Cancel();
                        taskCompletionSource.TrySetResult(true);
                        return;
                    }
                    List<int> row = AdjacencyMatrix.GetRow(index) ?? throw new Exception("Row cannot be null!");
                    for (int j = 0; j < row.Count; j++) {
                        if (row[j] == 1 && !visited.Contains(j)) {
                            visited.Add(j);
                            queue.Enqueue(j);
                        }
                    }
                }
            }
            public List<int>? GetNodeValue(List<int> indexes) {
                if (indexes.Count == 0) return null;
                List<int> values = [];
                foreach (int index in indexes) {
                    if (index < 0 || index > NodeValues.Count) return null;
                    values.Add(NodeValues[index]);
                }
                return values;
            }
            public List<int> BFS(int startValue) {
                int startIndex = NodeValues.IndexOf(startValue);
                Queue<int> queue = new();
                HashSet<int> visited = [];
                queue.Enqueue(startIndex);
                visited.Add(startIndex);
                while (queue.Count > 0) {
                    int index = queue.Dequeue();
                    List<int> row = AdjacencyMatrix.GetRow(index) ?? throw new Exception("Row cannot be null!");
                    for (int j = 0; j < row.Count; j++) {
                        if (row[j] == 1 && !visited.Contains(j)) {
                            visited.Add(j);
                            queue.Enqueue(j);
                        }
                    }
                }
                return [.. visited];
            }
        public async Task<bool?> CheckConnectivity(int value1, int value2)
        {
            List<int>[] indexes = [[], []];
            for (int i = 0; i < NodeValues.Count; i++)
            {
                if (NodeValues[i] == value1) indexes[0].Add(i);
                if (NodeValues[i] == value2) indexes[1].Add(i);
            }
            if (indexes[0].Count == 0 || indexes[1].Count == 0) return null;
            int startListIndex = 0,
                endValue = value2;
            if (indexes[0].Count > indexes[1].Count) (startListIndex, endValue) = (1, value1);
            TaskCompletionSource<bool> taskCompletionSource = new();
            CancellationTokenSource cancellationTokenSource = new();
            List<Task> tasks = [];
            foreach (int idx in indexes[startListIndex])
                tasks.Add(Task.Run(() => BFS(idx, ref cancellationTokenSource, endValue)));
            Task output = await Task.WhenAny(Task.WhenAll(tasks), taskCompletionSource.Task);
            return output == taskCompletionSource.Task && taskCompletionSource.Task.Result;
        }
        public int? CountAllLinks() {
            if (AdjacencyMatrix.Size <= 0) return null;
            int count = 0;
            for (int i = 0; i < AdjacencyMatrix.Size; i++) {
                List<int> row = AdjacencyMatrix.GetRow(i) ?? throw new Exception("Row cannot be null!");
                for (int j = i; j < AdjacencyMatrix.Size; j++) {
                    count += row[j];
                }
            }
            return count;
        }
        // na potrzeby zadania domowego
        public static Graph ZadanieDomowe() {
            int seed = 1234;
            Graph ans = new();
            Random rng = new(seed);
            int extraSize = rng.Next(5);
            for (int i = 0; i < 5; i++) ans.AddNode(rng.Next(100));
            ans.AddNode(49);
            for (int i = 0; i < 5 + extraSize; i++) ans.AddNode(rng.Next(100));
            int connections = ans.NodeValues.Count + 5 + rng.Next(5);
            for (int i = 0; i < connections; i++) {
                int x1 = rng.Next(ans.NodeValues.Count);
                int x2 = rng.Next(ans.NodeValues.Count);
                if (x1 == x2) continue;
                ans.AddConnection(x1, x2);
            }
            return ans;
        }
    }
}
