namespace AL_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph(10, true);
            graph.printMatrix();
            graph.printList();
        }
    }
}