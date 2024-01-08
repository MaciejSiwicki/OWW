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
            
            if (numberOfCities < 14)
            {
                var seqMethod = new TSPseq();
                watch.Start();
                shortestPathCost = seqMethod.Tsp(graph, visitedCities, 0, numberOfCities, 1, 0, shortestPathCost, currentPath);
                watch.Stop();

                Console.WriteLine(shortestPathCost);
                Console.WriteLine(string.Join(" -> ", seqMethod.shortestPath));
                Console.WriteLine(watch.Elapsed.TotalSeconds);
                FileController.WriteToFileTime(watch.Elapsed.TotalSeconds, "../../../output_time.txt");
            }
            else
            {
                FileController.WriteToFileTime(0, "../../../output_time.txt");
            }

            var parMethod = new TSPpar();
            watch.Restart();
            shortestPathCost = parMethod.TspPar(graph, numberOfCities);
            watch.Stop();

            Console.WriteLine(shortestPathCost);
            Console.WriteLine(string.Join(" -> ", parMethod.shortestPathFinal));
            Console.WriteLine(watch.Elapsed.TotalSeconds);
            FileController.WriteToFileTime(watch.Elapsed.TotalSeconds, "../../../output_time.txt");
            FileController.WriteToFilePath(parMethod.shortestPathFinal, "../../../output.txt");
        }
    }
}
