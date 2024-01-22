using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWW
{
    internal class TSPpar
    {
        public List<int> shortestPathFinal = new List<int>();
        public int TspPar(int[,] graph, int numberOfCities, int numberOfProcessors)
        {
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = numberOfProcessors
            };
            int[] pathCosts = new int[numberOfCities];
            List<int>[] arrayOfPaths = new List<int>[numberOfCities];
            bool[] visitedCities = new bool[numberOfCities];
            visitedCities[0] = true;

            object lockObject = new object();

            Parallel.For(1, numberOfCities, options, i =>
            {
                int shortestPathCost = int.MaxValue;
                List<int> currentPath = new List<int>() { 0 };

                bool[] localVisitedCities = new bool[numberOfCities];
                Array.Copy(visitedCities, localVisitedCities, numberOfCities);

                localVisitedCities[i] = true;

                var seqMethod = new TSPseq();
                int localPathCost = seqMethod.Tsp(graph, localVisitedCities, i, numberOfCities, 2, 0, shortestPathCost, currentPath);
                localPathCost += graph[0, i];

                lock (lockObject)
                {
                    pathCosts[i] = localPathCost;
                    seqMethod.shortestPath.Insert(1, i);
                    arrayOfPaths[i] = new List<int>(seqMethod.shortestPath);
                    visitedCities[i] = false;
                }
            });

            int shortestPathCostFinal = pathCosts.Where(x => x > 0).DefaultIfEmpty().Min();
            shortestPathFinal = arrayOfPaths[Array.IndexOf(pathCosts, shortestPathCostFinal)];
            return shortestPathCostFinal;
        }
    }
}
