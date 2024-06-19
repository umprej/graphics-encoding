namespace Models
{
    public class StringRaster : Raster
    {
        public StringRaster(string gridString, int startColor, bool displayValues = true, bool displayColor = true, bool clickable = false)
        {
            string[] lines = gridString.Trim().Split(Environment.NewLine);
            int sum;
            var sums = new HashSet<int>();

            foreach (string line in lines)
            {
                string[] numberStrings = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                sum = 0;

                foreach (string numStr in numberStrings)
                {
                    if (int.TryParse(numStr, out int num))
                    {
                        sum += num;
                    }
                    else
                    {
                        throw new Exception($"Failed to parse '{numStr}' as an integer.");
                    }
                }
                sums.Add(sum);
            }

            if (sums.Count != 1)
            {
                throw new Exception("Failed to parse input string, not all lines have the same sum");
            }

            int col = sums.First();
            int row = lines.Length;

            int[,] grid = new int[row, col];

            int i = 0, j = 0;
            foreach (string line in lines)
            {
                string[] numberStrings = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string num in numberStrings)
                {
                    grid[i, j++] = int.Parse(num);
                }
                i++;
                j = 0;
            }

            Grid = new Grid(grid);
            DisplayValues = displayValues;
            DisplayColor = displayColor;
            Clickable = clickable;
        }
    }
}
