using System.Diagnostics;
using Project;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        int totalWeight = graph.GraphGenerator(8, 22);
        
        graph.AdjacencyList();
        graph.AdjacencyMatrix();
        
        KruskalsAlgorithm kruskalsAlgorithm = new KruskalsAlgorithm();
        
        stopwatch.Stop();
        Console.WriteLine($"Time taken for graph generation and adjacency operations: {stopwatch.ElapsedMilliseconds} ms");
        
        stopwatch.Restart();
        
        List<Edge> minimumSpanningTree = kruskalsAlgorithm.KruskalsMST(graph);

        stopwatch.Stop();
        Console.WriteLine($"Time taken for Kruskal's algorithm: {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine("\nMinimum spanning tree (Kruskal's algorithm): ");
        foreach (Edge edge in minimumSpanningTree)
        {
            Console.WriteLine($"{edge.Begin.Data} - {edge.End.Data}: weight {edge.Weight}");
        }
        
        int totalWeightMST = 0;
        foreach (Edge edge in minimumSpanningTree)
        {
            totalWeightMST += edge.Weight;
        }

        Console.WriteLine($"Total weight of the original graph: {totalWeight}");
        Console.WriteLine($"Total weight of the Minimum Spanning Tree: {totalWeightMST}");
    }
}