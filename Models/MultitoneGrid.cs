using System.Text;

namespace Models
{
    public class MultitoneGrid : GridBase
    {
        public MultitoneGrid(int[,] grid, string delimiter = "-")
            : base(grid, delimiter)
        {
        }

        public override string CompressedString()
        {
            StringBuilder str = new StringBuilder();

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

            return str.ToString();
        }
    }
}
