namespace Models
{
    public class Raster
    {
        public Pixel[,] Grid { get; set; }

        public int Col = 0;
        public int Row = 0;
        public int MaxColor = 0;

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

        public Raster(int[,] grid) { 
            Col = grid.GetLength(0);
            Row = grid.GetLength(1);

            BuildRaster(grid);
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


        private void BuildRaster(int[,] grid)
        {
            Grid = new Pixel[Col, Row];

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    MaxColor = Math.Max(MaxColor, grid[i, j]);
                    Grid[i, j] = new Pixel(grid[i,j]);
                }
            }
        }
    }
}
