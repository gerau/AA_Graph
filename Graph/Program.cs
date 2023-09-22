namespace AL_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph(5, probability: 0.9);
            graph.printMatrix();
            graph.printList();
        }
    }
}