namespace Models
{
    public class Raster
    {
        public Pixel[,] Grid { get; set; }


        public int Col = 0;
        public int Row = 0;
        public int MaxColor = 0;
        public SortedSet<int> ColorPallete = new SortedSet<int>();

        private string delimiter = " ";

        public bool DisplayValues = true;
        public bool DisplayColor = true;
        public bool Clickable = false;

        public Raster()
        {
            BuildRaster();
        }

        public Raster(int row, int col)
        {
            Col = col;
            Row = row;
            BuildRaster();
        }

        public Raster(int[,] grid,
                                 bool displayValues = true,
                                 bool displayColor = true,
                                 bool clickable = false)
        { 
            Col = grid.GetLength(0);
            Row = grid.GetLength(1);

            BuildRaster(grid, displayValues, displayColor, clickable);
        }

        public Raster(string filename, int firstColor) {
            try
            {
                // Open the text file using a stream reader.
                using StreamReader reader = new("/Data/" + filename);

                // Read the stream as a string.
                string text = reader.ReadToEnd();

                // Write the text to the console.
                Console.WriteLine(text);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        public override string ToString() {
            string str = "";
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    str += Grid[i, j].Color.ToString();
                    str += j != Grid.GetLength(1) - 1 ? this.delimiter : Environment.NewLine;
                }
            }
            return str;
        }

        private void BuildRaster()
        {
            Grid = new Pixel[Col, Row];

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Pixel();
                }
            }
        }

        private void BuildRaster(int[,] grid,
                                 bool displayValues = true,
                                 bool displayColor = true,
                                 bool clickable = false)
        {
            Grid = new Pixel[Col, Row];
            DisplayValues = displayValues;
            DisplayColor = displayColor;
            Clickable = clickable;

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    MaxColor = Math.Max(MaxColor, grid[i, j]);
                    Grid[i, j] = new Pixel(grid[i, j]);
                    ColorPallete.Add(Grid[i, j].Color);
                }
            }
        }

        public void ChangeColor(Pixel pixel) {
            Console.WriteLine("Attempt to change color");
            Console.WriteLine(pixel);
        }

        public int GetColorAtIndex(int index)
        {
            SortedSet<int>.Enumerator em = ColorPallete.GetEnumerator();
            for (int i = 0; i < index + 1; i++)
            {
                em.MoveNext();
            }
            return em.Current;
        }


    }
}
