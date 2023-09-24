using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Graph
{
    internal class WeightedGraph : Graph
    {
        public WeightedGraph(int numberOfVertices, bool isOrientated = false) : base(numberOfVertices, isOrientated)
        {}
        public WeightedGraph(int numberOfVertices, double probability, int min, int max, bool isOrientated = false) : base(numberOfVertices, isOrientated)
        {
            var rand = new Random();
            if (!_isOrientated)
            {
                for (int i = 0; i < _numberOfVertices; i++)
                {
                    for (int j = i + 1; j < _numberOfVertices; j++)
                    {
                        double pr = rand.NextDouble();
                        if (pr < probability)
                        {
                            int weight = rand.Next(min, max);
                            addEdge(i, j, weight);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < _numberOfVertices; i++)
                {
                    for (int j = 0; j < _numberOfVertices; j++)
                    {
                        if (i == j) continue;
                        double pr = rand.NextDouble();
                        if (pr < probability)
                        {
                            int weight = rand.Next(min, max);
                            addEdge(i, j, weight);
                        }
                    }
                }
            }
        }
        public void addEdge(int i, int j, int weight)
        {
            if (_isOrientated)
            {
                _adjacencyMatrix[i, j] = weight;
            }
            else
            {
                _adjacencyMatrix[i, j] = weight;
                _adjacencyMatrix[j, i] = _adjacencyMatrix[i, j];
            }
        }
        private List<List<(int,int)>> convertMatrixIntoList()
        {
            var _adjacencyList = new List<List<(int,int)>>();
            for (int i = 0; i < _numberOfVertices; i++)
            {
                var list = new List<(int,int)>();
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    if (_adjacencyMatrix[i, j] != 0)
                    {
                        list.Add((j, _adjacencyMatrix[i,j]));
                    }
                }
                _adjacencyList.Add(list);
            }
            return _adjacencyList;
        }
    }
}
