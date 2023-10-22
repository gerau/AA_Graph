using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA_Graph
{
    internal class Graph
    {
        protected int _numberOfVertices { get; set; }
        protected bool _isOrientated{ get; }
        protected int[,] _adjacencyMatrix { get; set; }

        public Graph(int numberOfVertices, bool isOrientated = false)
        {
            _numberOfVertices = numberOfVertices;
            _adjacencyMatrix = new int[numberOfVertices, numberOfVertices];
            _isOrientated = isOrientated;
        }
        public Graph(int numberOfVertices, double probability, bool isOrientated = false)
        {
            _numberOfVertices = numberOfVertices;
            _adjacencyMatrix = new int[numberOfVertices, numberOfVertices];
            _isOrientated = isOrientated;
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
                            addEdge(i, j);
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
                            addEdge(i, j);
                        }
                    }
                }
            }
        }
        
        public void addEdge(int i, int j)
        {
            if (i < 0 || j < 0 || i > _numberOfVertices || j > _numberOfVertices) return;
            if (_isOrientated)
            {
                _adjacencyMatrix[i, j] = 1;
            }
            else
            {
                _adjacencyMatrix[i, j] = 1;
                _adjacencyMatrix[j, i] = _adjacencyMatrix[i, j];
            }
        }
        public void addVertex()
        {
            _numberOfVertices = _numberOfVertices + 1;
            int[,] newMatrix = new int[_numberOfVertices,_numberOfVertices];
            
            for(int i = 0; i < _numberOfVertices - 1; i++) 
            {
                for(int j = 0; j < _numberOfVertices - 1; j++)
                {
                    newMatrix[i,j] = _adjacencyMatrix[i, j];
                }
            }
            _adjacencyMatrix = newMatrix;
        }
        public void removeEdge(int i, int j)
        {
            if (!_isOrientated) 
            {
                _adjacencyMatrix[i, j] = 0;
                _adjacencyMatrix[j, i] = 0;
            }
            else
            {
                _adjacencyMatrix[i, j] = 0;
            }
        }
        public void removeVertex(int deleted)
        {
            if (deleted < 0 || deleted >= _numberOfVertices) return;
            
            int[,] newMatrix = new int[_numberOfVertices - 1,_numberOfVertices - 1];
            int newRow = 0;
            for(int i = 0; i < _numberOfVertices; i++)
            {
                if(i == deleted) continue;
                int newColumn = 0;
                for(int j = 0; j < _numberOfVertices; j++)
                {
                    if (j == deleted) continue;
                    newMatrix[newRow,newColumn] = _adjacencyMatrix[i,j];
                    newColumn++;
                }
                newRow++;
            }
            _adjacencyMatrix = newMatrix;
            _numberOfVertices--;
        }

        protected List<List<int>> convertMatrixIntoList()
        {
            var _adjacencyList = new List<List<int>>();
            for (int i = 0; i < _numberOfVertices; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    if (_adjacencyMatrix[i, j] != 0)
                    {
                        list.Add(j);
                    }
                }
                _adjacencyList.Add(list);
            }
            return _adjacencyList;
        }
        
        public void printMatrix()
        {
            for (int i = 0; i < _numberOfVertices; i++)
            {
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    Console.Write("[" + _adjacencyMatrix[i, j] + "]");
                }
                Console.Write('\n');
            }
        }
        public void printList()
        {
            var lists = convertMatrixIntoList();
            for (int i = 0; i < _numberOfVertices; i++)
            {
                Console.Write($"{i} :[ ");
                foreach(var vertix in lists[i])
                {
                    Console.Write(vertix + ", ");
                }
                Console.Write("] \n");
                
            }
        }
    }
}
