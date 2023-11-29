using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWW
{
    internal class TSPpar
    {
        public int TspPar(int[,] graph, int numberOfCities)
        {
            int[] pathCosts = new int[numberOfCities];
            List<int>[] arrayOfPaths = new List<int>[numberOfCities];
            bool[] visitedCities = new bool[numberOfCities];
            visitedCities[0] = true;
            for (int i = 1; i < numberOfCities; i++)
            {
                int shortestPathCost = int.MaxValue;
                List<int> currentPath = new List<int>() { 0 };
                visitedCities[i] = true;
                var seqMethod = new TSPseq();
                pathCosts[i] = seqMethod.Tsp(graph, visitedCities, i, numberOfCities, 2, 0, shortestPathCost, currentPath);
                pathCosts[i] += graph[0, i];
                //Console.WriteLine(pathCosts[i]);
                seqMethod.shortestPath.Insert(1, i);
                arrayOfPaths[i] = seqMethod.shortestPath;
                visitedCities[i] = false;
            }
            for (int i = 1; i < numberOfCities; i++)
            {
                Console.WriteLine(string.Join(" -> ", arrayOfPaths[i]));
            }
            return 0;
        }
    }
}
