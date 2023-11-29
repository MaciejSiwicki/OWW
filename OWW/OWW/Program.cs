using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWW
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<(int, int)> coordinates = FileController.ReadInput("../../../input.txt");
            int[,] graph = FileController.CalculateDistanceMatrix(coordinates);
            int numberOfCities = graph.GetLength(0);
            bool[] visitedCities = new bool[numberOfCities];
            visitedCities[0] = true;
            int shortestPathCost = int.MaxValue;
            List<int> currentPath = new List<int>() { 0 };

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            var seqMethod = new TSPseq();
            shortestPathCost = seqMethod.Tsp(graph, visitedCities, 0, numberOfCities, 1, 0, shortestPathCost, currentPath);
            watch.Stop();

            Console.WriteLine(shortestPathCost);
            Console.WriteLine(string.Join(" -> ", seqMethod.shortestPath));
            Console.WriteLine(watch.Elapsed.TotalSeconds);
            FileController.WriteToFile(seqMethod.shortestPath, "../../../output.txt");
        }
    }
}
