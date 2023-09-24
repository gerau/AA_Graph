namespace AL_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new WeightedGraph(5, 0.5, 1, 100,false);
         
            graph.printMatrix();
           
        }
    }
}