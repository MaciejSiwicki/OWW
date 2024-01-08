namespace OWW
{
    internal class FileController
    {
        public static List<(int, int)> ReadInput(string filePath)
        {
            List<(int, int)> coordinates = new List<(int, int)>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                {
                    coordinates.Add((x, y));
                }
                else
                {
                    Console.WriteLine($"Invalid line: {line}");
                }
            }
            return coordinates;
        }
        public static void WriteToFilePath(List<int> shortestPath, string filePath)
        {
            string pathString = string.Join(" ", shortestPath);

            File.WriteAllText(filePath, pathString);
        }
        public static void WriteToFileTime(double time, string filePath)
        {
            char lastChar = 'j';
            if (File.Exists(filePath))
            {
                using StreamReader reader = new(filePath);
                while (!reader.EndOfStream)
                {
                    lastChar = (char)reader.Read();
                }
            }
            using StreamWriter writer = new(filePath, true);
            if (lastChar == ' ')
            {
                writer.Write(time + Environment.NewLine);
            }
            else if (lastChar == '\n' || lastChar == '\r')
            {
                writer.Write(time + " ");
            }
            else
            {
                writer.Write(time + " ");
            }
        }
        public static int[,] CalculateDistanceMatrix(List<(int, int)> coordinates)
        {
            int numberOfCities = coordinates.Count;
            int[,] distanceMatrix = new int[numberOfCities, numberOfCities];

            for (int i = 0; i < numberOfCities; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    distanceMatrix[i, j] = CalculateDistance(coordinates[i], coordinates[j]);
                }
            }

            return distanceMatrix;
        }
        static int CalculateDistance((int, int) point1, (int, int) point2)
        {
            int deltaX = point2.Item1 - point1.Item1;
            int deltaY = point2.Item2 - point1.Item2;
            return (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
