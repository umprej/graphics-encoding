using System.Text;

namespace Models
{
    public class Grid
    {
        public Pixel[,] Pixels { get; set; }

        public int Col { get; private set; }
        public int Row { get; private set; }
        public int MaxColor { get; private set; }
        public SortedSet<int> ColorPalette { get; private set; } = new SortedSet<int>();

        public int StartingColor;
        public bool IsDuotone { get; private set; }

        private string Delimiter { get; set; }

        public Grid(int[,] grid, string delimiter = " ", int startingColor = 0)
        {
            Col = grid.GetLength(0);
            Row = grid.GetLength(1);
            Delimiter = delimiter;
            StartingColor = startingColor;
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

            IsDuotone = ColorPalette.Count == 2 ? true : false;
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

        public string CompressedString()
        {
            StringBuilder str = new StringBuilder();
            if (IsDuotone)
            {
                int currColor;
                int currColorCount;

                for (int i = 0; i < Col; i++)
                {
                    currColor = StartingColor;
                    currColorCount = 0;
                    List<int> row = new List<int>();

                    for (int j = 0; j < Row; j++)
                    {
                        if (Pixels[i, j].Color == currColor)
                        {
                            currColorCount++;
                        }
                        else
                        {
                            row.Add(currColorCount);
                            currColorCount = 1;
                            currColor = currColor == 0 ? 1 : 0;

                        }
                    }
                    row.Add(currColorCount);

                    str.AppendLine(string.Join(Delimiter, row));
                }
            }
            else
            {
                int currColor;
                int currColorCount;
                for (int i = 0; i < Col; i++)
                {
                    currColor = Pixels[i, 0].Color;
                    currColorCount = 0;
                    string row = "";

                    for (int j = 0; j < Row; j++)
                    {
                        if (Pixels[i, j].Color == currColor)
                        {
                            currColorCount++;
                        }
                        else
                        {
                            row += currColor + Delimiter + currColorCount + " ";
                            currColorCount = 1;
                            currColor = Pixels[i, j].Color;

                        }
                    }
                    row += currColor + Delimiter + currColorCount + " ";

                    str.AppendLine(row);
                }
            }
            return str.ToString();
        }
    }
}