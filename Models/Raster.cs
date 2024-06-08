namespace Models
{
    public class Raster
    {
        public Pixel[,] Grid { get; set; }


        public int Col = 0;
        public int Row = 0;
        public int MaxColor = 0;
        public SortedSet<int> ColorPallete = new SortedSet<int>();

        public bool DisplayValues = true;
        public bool DisplayColor = true;
        public bool Clickable = false;

        public bool CheckState = false;

        private HashSet<int> ColsMiscolored = new HashSet<int>();
        private HashSet<int> RowsMiscolored = new HashSet<int>();

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

        public bool Check()
        {
            CheckState = true;
            bool ret = true;
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0;j < Row; j++)
                {
                    if (!Grid[i, j].ColorsMatch())
                    {
                        ColsMiscolored.Add(i);
                        RowsMiscolored.Add(j);
                        ret = false;
                    }
                }
            }
            return ret;
        }

    }
}
