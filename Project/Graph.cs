namespace Project
{
    public class Edge
    {
        public Vertex Begin { get; }
        public Vertex End { get; }
        public int Weight { get; }

        public Edge(Vertex begin, Vertex end, int weight)
        {
            Begin = begin;
            End = end;
            Weight = weight;
        }
    }

    public class Vertex
    {
        public int Data { get; }
        public List<Edge> Neighbors { get; }

        public Vertex(int data)
        {
            Data = data;
            Neighbors = new List<Edge>();
        }
    }

    public class Graph
    {
        public List<Vertex> Vertices { get; }

        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        public void AddVertex(int data)
        {
            Vertices.Add(new Vertex(data));
        }

        public void AddEdge(Vertex begin, Vertex end, int weight)
        {
            var edge = new Edge(begin, end, weight);
            begin.Neighbors.Add(edge);
        }

        public void AdjacencyList()
        {
            foreach (var value in Vertices)
            {
                Console.Write($"{value.Data}: ");
                if (value.Neighbors.Count == 0)
                {
                    Console.WriteLine();
                    continue;
                }
                List<string> neighborData = new List<string>();
                foreach (Edge edge in value.Neighbors)
                {
                    string data = $"{edge.End.Data}({edge.Weight})";
                    neighborData.Add(data);
                }
                Console.WriteLine(string.Join(", ", neighborData));
            }
        }

        public void AdjacencyMatrix()
        {
            var adjacencyMatrix = new bool[Vertices.Count, Vertices.Count];
            for (int i = 0; i < Vertices.Count; i++)
            {
                for (int j = 0; j < Vertices.Count; j++)
                {
                    bool hasEdge = false;
                    foreach (var edge in Vertices[i].Neighbors)
                    {
                        if (edge.End == Vertices[j])
                        {
                            hasEdge = true;
                            break;
                        }
                    }
                    adjacencyMatrix[i, j] = hasEdge;
                }
            }

            Console.WriteLine("\nAdjacency Matrix:");
            for (int i = 0; i < Vertices.Count; i++)
            {
                for (int j = 0; j < Vertices.Count; j++)
                {
                    if (adjacencyMatrix[i, j])
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static long Combinations(int n, int k)
        {
            var numerator = 1;
            var denominator = 1;

            for (int i = 0; i < k; i++)
            {
                numerator *= (n - i);
                denominator *= (i + 1);
            }
            return numerator / denominator;
        }
        

        public int GraphGenerator(int n, double density)
        {
            for (int i = 0; i < n; i++)
            {
                AddVertex(i + 1);
            }

            var maxEdge = Combinations(n, 2);
            var densityEdge = (maxEdge * density) / 100;

            List<(Vertex, Vertex)> avEdge = new List<(Vertex, Vertex)>();
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    avEdge.Add((Vertices[i], Vertices[j]));
                }
            }
            Random random = new Random();
            int totalWeight = 0;

            for (int i = 0; i < densityEdge; i++)
            {
                var index = random.Next(avEdge.Count);
                var (start, end) = avEdge[index];
                avEdge.RemoveAt(index);

                var weight = random.Next(1, 20);
                AddEdge(start, end, weight);
                AddEdge(end, start, weight);
                totalWeight += weight;
            }
            return totalWeight;
        }
        
        public List<Edge> GetAllEdges()
        {
            List<Edge> allEdges = new List<Edge>();
            foreach (Vertex vertex in Vertices)
            {
                allEdges.AddRange(vertex.Neighbors);
            }
            return allEdges;
        }
    }
}