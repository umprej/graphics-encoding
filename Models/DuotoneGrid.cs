using System.Text;

namespace Models
{
    public class DuotoneGrid : GridBase
    {
        public int StartingColor { get; set; }

        public DuotoneGrid(int[,] grid, string delimiter = " ", int startingColor = 0)
            : base(grid, delimiter)
        {
            StartingColor = startingColor;
        }

        public override string CompressedString()
        {
            StringBuilder str = new StringBuilder();

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

            return str.ToString();
        }
    }
}
