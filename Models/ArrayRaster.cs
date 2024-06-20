namespace Models
{
    public class ArrayRaster : Raster
    {
        public ArrayRaster(int[,] grid, bool displayValues = true, bool displayColor = true, bool clickable = false)
            : base(new Grid(grid), displayValues, displayColor, clickable)
        {
        }

        public ArrayRaster(int[,] grid, int startingColor, bool displayValues = true, bool displayColor = true, bool clickable = false)
            : base(new Grid(grid, " ", startingColor), displayValues, displayColor, clickable)
        {
        }

        public ArrayRaster(int[,] grid, string delimiter, bool displayValues = true, bool displayColor = true, bool clickable = false)
            : base(new Grid(grid, delimiter, 0), displayValues, displayColor, clickable)
        {
        }

        public ArrayRaster(int[,] grid, string delimiter, int startingColor, bool displayValues = true, bool displayColor = true, bool clickable = false)
            : base(new Grid(grid, delimiter, startingColor), displayValues, displayColor, clickable)
        {
        }
    }
}
