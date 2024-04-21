namespace Project;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        
        graph.GraphGenerator(10, 40);
        
        graph.AdjacencyList();
        graph.AdjacencyMatrix();
        
        KruskalsAlgorithm kruskalsAlgorithm = new KruskalsAlgorithm();
        List<Edge> minimumSpanningTree = kruskalsAlgorithm.KruskalsMST(graph);

        Console.WriteLine("\nMinimum spanning tree(Kruskal's algorithm): ");
        foreach (Edge edge in minimumSpanningTree)
        {
            Console.WriteLine($"{edge.Begin.Data} - {edge.End.Data}: weight {edge.Weight}");
        }
        
        int totalWeightOriginalGraph = 0;
        foreach (Vertex vertex in graph.Vertices)
        {
            foreach (Edge edge in vertex.Neighbors)
            {
                totalWeightOriginalGraph += edge.Weight;
            }
        }
        
        int totalWeightMST = 0;
        foreach (Edge edge in minimumSpanningTree)
        {
            totalWeightMST += edge.Weight;
        }

        Console.WriteLine($"\nTotal weight of the original graph: {totalWeightOriginalGraph}");
        Console.WriteLine($"Total weight of the Minimum Spanning Tree: {totalWeightMST}");
    }
}