using System.Runtime.InteropServices;

namespace AA_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new WeightedGraph(5);
            graph.printMatrix();
            graph.addEdge(0, 1,2);
            graph.addEdge(0, 4,2);
            graph.addEdge(1, 2,4);
            graph.addEdge(1, 3,3);
            graph.addEdge(2, 3,1);
            graph.addEdge(2, 4,3);
            graph.addEdge(3, 4,1);

            Console.WriteLine(graph.FloydWarshall(1, 2));
            Console.WriteLine(graph.Dijkstra(1, 2));

            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"for {i} and {j} - FloydWarshall: {graph.FloydWarshall(i, j)},  {graph.Dijkstra(i, j)} - Dijkstra");
                }
            }
            graph.printMatrix();

        }
    }
}