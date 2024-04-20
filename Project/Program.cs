namespace Project;

class Program
{
    static void Main(string[] args)
    {
        Project.Graph graph = new Project.Graph();
        
        graph.GraphGenerator(10, 40);

        graph.AdjacencyList();
        graph.AdjacencyMatrix();
    }
}