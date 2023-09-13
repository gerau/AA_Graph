using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Graph
{
    internal class Graph
    {
        private int _numberOfVertices { get; }
        private bool _isDirected { get; }
        private int[,] _adjacencyMatrix;
        private List<List<int>> _adjacencyList;

        public Graph(int numberOfVertices, bool isDirected = false)
        {
            var rand = new Random();
            _numberOfVertices = numberOfVertices;
            _adjacencyMatrix = new int[numberOfVertices, numberOfVertices];
            _adjacencyList = new List<List<int>>();
            if (_isDirected)
            {
                for (int i = 0; i < _numberOfVertices; i++)
                {
                    for (int j = i + 1; j < _numberOfVertices; j++)
                    {
                        int randomBit = rand.Next() % 2;
                        _adjacencyMatrix[i, j] = randomBit;
                        _adjacencyMatrix[j, i] = _adjacencyMatrix[i, j];
                    }
                }
                convertMatrixIntoList();
            }
            else
            {
                for (int i = 0; i < _numberOfVertices; i++)
                {
                    for (int j = 0; j < _numberOfVertices; j++)
                    {
                        if (i == j) continue;
                        int randomBit = rand.Next() % 2;
                        _adjacencyMatrix[i, j] = randomBit;
                    }
                }
                convertMatrixIntoList();
            }
        }
        private void convertMatrixIntoList()
        {
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
            int i = 0;
            foreach (var list in _adjacencyList)
            {
                Console.Write(i + ": ");
                foreach (var item in list)
                {
                    Console.Write(item + ", ");
                }
                Console.Write('\n');
                i++;
            }
        }
    }
}
