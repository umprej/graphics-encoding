namespace Models
{
    public class ArrayRaster : Raster
    {
        public ArrayRaster(int[,] grid, bool displayValues = true, bool displayColor = true, bool clickable = false)
            : base(new Grid(grid), displayValues, displayColor, clickable)
        {
        }
    }
}
