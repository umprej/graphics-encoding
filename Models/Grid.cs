namespace Models
{
    public class Grid
    {
        public Pixel[,] Pixels { get; set; }

        public int Col { get; private set; }
        public int Row { get; private set; }
        public int MaxColor { get; private set; }
        public SortedSet<int> ColorPallete { get; private set; } = new SortedSet<int>();

        public Grid(int row, int col)
        {
            Col = col;
            Row = row;
            InitializeGrid();
        }

        public Grid(int[,] grid)
        {
            Col = grid.GetLength(0);
            Row = grid.GetLength(1);
            InitializeGrid(grid);
        }

        private void InitializeGrid()
        {
            Pixels = new Pixel[Col, Row];

            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    Pixels[i, j] = new Pixel();
                }
            }
        }

        private void InitializeGrid(int[,] grid)
        {
            Pixels = new Pixel[Col, Row];

            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    MaxColor = Math.Max(MaxColor, grid[i, j]);
                    Pixels[i, j] = new Pixel(grid[i, j]);
                    ColorPallete.Add(Pixels[i, j].Color);
                }
            }
        }

        public bool ColorsMatchBool()
        {
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (!Pixels[i, j].ColorsMatch())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public (List<int> mismatchedRows, List<int> mismatchedColumns) ColorsMatch()
        {
            HashSet<int> mismatchedRows = new HashSet<int>();
            HashSet<int> mismatchedColumns = new HashSet<int>();

            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (!Pixels[i, j].ColorsMatch())
                    {
                        mismatchedRows.Add(i);
                        mismatchedColumns.Add(j);
                    }
                }
            }

            return (mismatchedRows.ToList(), mismatchedColumns.ToList());
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    str += Pixels[i, j].Color.ToString();
                    str += j != Row - 1 ? " " : Environment.NewLine;
                }
            }
            return str;
        }
    }
}