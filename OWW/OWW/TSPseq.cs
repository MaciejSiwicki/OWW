namespace OWW
{
    internal class TSPseq
    {
        public List<int> shortestPath = new List<int>();
        public int Tsp(int[,] graph, bool[] visited, int currentPos, int numberOfCities, int count, int cost, int shortestPathCost, List<int> currentPath)
        {
            if (count == numberOfCities && graph[currentPos, 0] > 0)
            {
                if(shortestPathCost > cost + graph[currentPos, 0]) 
                {
                    shortestPathCost = cost + graph[currentPos, 0];
                    shortestPath =  new List<int>(currentPath);
                    shortestPath.Add(0);
                }
                return shortestPathCost;
            }
            for(int i = 0; i < numberOfCities;i++)
            {
                if (visited[i] == false && graph[currentPos,i] > 0) 
                {
                    visited[i] = true;
                    currentPath.Add(i);
                    shortestPathCost = Tsp(graph, visited, i, numberOfCities, count + 1, cost + graph[currentPos, i], shortestPathCost, currentPath);
                    visited[i] = false;
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
            return shortestPathCost; 
        }
    }
}