namespace Project;

public class KruskalsAlgorithm
{
    public List<Edge> KruskalsMST(Graph graph)
    {
        List<Edge> result = new List<Edge>();
        List<Edge> sortedEdges = graph.GetAllEdges().OrderBy(edge => edge.Weight).ToList();

        DisjointSet disjointSet = new DisjointSet();

        foreach (Vertex vertex in graph.Vertices)
        {
            disjointSet.MakeSet(vertex);
        }

        foreach (Edge edge in sortedEdges)
        {
            Vertex beginRoot = disjointSet.FindSet(edge.Begin);
            Vertex endRoot = disjointSet.FindSet(edge.End);

            if (beginRoot != endRoot)
            {
                result.Add(edge);
                disjointSet.Union(beginRoot, endRoot);
            }
        }

        return result;
    }

    public class DisjointSet
    {
        private Dictionary<Vertex, Vertex> parent = new Dictionary<Vertex, Vertex>();

        public void MakeSet(Vertex vertex)
        {
            parent[vertex] = vertex;
        }

        public Vertex FindSet(Vertex vertex)
        {
            if (parent[vertex] != vertex)
            {
                parent[vertex] = FindSet(parent[vertex]);
            }

            return parent[vertex];
        }

        public void Union(Vertex x, Vertex y)
        {
            Vertex xRoot = FindSet(x);
            Vertex yRoot = FindSet(y);
            parent[yRoot] = xRoot;
        }
    }
}