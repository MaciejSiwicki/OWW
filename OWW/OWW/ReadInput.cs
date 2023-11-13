namespace OWW
{
    internal class ReadInput
    {
        public static int[,] ReadInputFromFile(string textFile)
        {
            string[] lines = File.ReadAllLines(textFile);
            int size = lines.GetLength(0);
            int[,] graph = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    graph[i, j] = Int32.Parse(lines[i].Split()[j]);
                }
            }
            return graph;
        }
    }
}
