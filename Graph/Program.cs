namespace AL_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph(5, 0.5);
            graph.printMatrix();

            graph.addVertex();
            graph.printMatrix();
           
        }
    }
}