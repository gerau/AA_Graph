﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Graph
{
    internal class Graph
    {
        protected int _numberOfVertices { get; }
        protected bool _isOrientated{ get; }
        protected int[,] _adjacencyMatrix;

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

        private List<List<int>> convertMatrixIntoList()
        {
            var _adjacencyList = new List<List<int>>();
            for (int i = 0; i < _numberOfVertices; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    if (_adjacencyMatrix[i, j] == 1)
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
    }
}
