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
            
            if (numberOfCities < 13)
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
            var elapsedTimes = new List<double>();
            for (int i = 2; i < 9; i++)
            {
                watch.Restart();
                shortestPathCost = parMethod.TspPar(graph, numberOfCities, i);
                watch.Stop();
                Console.WriteLine(watch.Elapsed.TotalSeconds);
                elapsedTimes.Add(watch.Elapsed.TotalSeconds);
            }
            var delimitedTimes = string.Join(" ", elapsedTimes.Select(time => time.ToString("F6")));
            FileController.WriteToFileThread(delimitedTimes + Environment.NewLine, "../../../output_time_thread.txt");
            Console.WriteLine(shortestPathCost);
            Console.WriteLine(string.Join(" -> ", parMethod.shortestPathFinal));
            Console.WriteLine(watch.Elapsed.TotalSeconds);
            FileController.WriteToFileTime(watch.Elapsed.TotalSeconds, "../../../output_time.txt");
            FileController.WriteToFilePath(parMethod.shortestPathFinal, "../../../output.txt");
        }
    }
}
