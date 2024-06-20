using System.Text;

namespace Models
{
    public abstract class GridBase
    {
        public Pixel[,] Pixels { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public int MaxColor { get; set; }
        public SortedSet<int> ColorPalette = new SortedSet<int>();

        protected string Delimiter;

        public GridBase(int[,] grid, string delimiter = " ")
        {
            Col = grid.GetLength(0);
            Row = grid.GetLength(1);
            Delimiter = delimiter;
            InitializeGrid(grid);
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
                    ColorPalette.Add(Pixels[i, j].Color);
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
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    str.Append(Pixels[i, j].Color.ToString());
                    str.Append(j != Row - 1 ? " " : Environment.NewLine);
                }
            }
            return str.ToString();
        }

        public abstract string CompressedString();
    }
}
