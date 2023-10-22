using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA_Graph
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
        private List<List<(int,int)>> convertMatrixIntoListWithWeights()
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
        public int FloydWarshall(int v, int u)
        {
            var w = new int[_numberOfVertices,_numberOfVertices];

            for (int i = 0; i < _numberOfVertices; i++)
            {
                for (int j = 0; j < _numberOfVertices; j++) 
                {
                    if (i != j && _adjacencyMatrix[i, j] == 0)
                    {
                        w[i, j] = int.MaxValue/2; 
                    }
                    else
                    {
                        w[i, j] = _adjacencyMatrix[i, j];
                    }
                }
            }
            for (int k = 0; k < _numberOfVertices; k++)
            {
                for (int i = 0; i < _numberOfVertices; i++)
                {
                    for (int j = 0; j < _numberOfVertices; j++)
                    {
                        w[i, j] = Math.Min(w[i, j], (w[i, k] + w[k, j]));
                    }
                }
            }
            for(int i = 0; i < _numberOfVertices; i++)
            {
                if (w[i,i] < 0)
                {
                    return -1;
                }
            }
            return w[v, u];
        }
        public int Dijkstra(int s, int e)
        {
            List<int> X = new List<int>();
            List<int> V = new List<int>();
            List<int> minWeights = new List<int>();
            var adjecencyList = this.convertMatrixIntoList();
            for (int i = 0; i < _numberOfVertices;i++)
            {
                minWeights.Add(int.MaxValue / 2);
                V.Add(i);
            }
            minWeights[s] = 0;
            V.Remove(s);
            int v = s;
            while (V.Count > 0)
            {
                var inter = new List<int>();
                foreach(int i in V)
                {
                    foreach(int j in adjecencyList[v])
                    {
                        if(i == j) inter.Add(j);
                    }
                }
                foreach (var u in inter)
                {
                    if (minWeights[u] > minWeights[v] + _adjacencyMatrix[v, u])
                    {
                        minWeights[u] = minWeights[v] + _adjacencyMatrix[v, u];
                    }
                }
                int min = int.MaxValue;
                int index = 0;
                foreach(int i in V)
                {
                    if(min > minWeights[i])
                    {
                        min = minWeights[i];
                        index = i;
                    }
                }
                v = index;
                V.Remove(v);
            }
            return minWeights[e];
        }
    }
}
