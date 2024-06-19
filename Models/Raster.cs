namespace Models
{
    public abstract class Raster
    {
        public Grid Grid { get; set; }

        public bool DisplayValues { get; set; }
        public bool DisplayColor { get; set; }
        public bool Clickable { get; set; }

        protected Raster()
        {
        }

        protected Raster(Grid grid, bool displayValues = true, bool displayColor = true, bool clickable = false)
        {
            Grid = grid;
            DisplayValues = displayValues;
            DisplayColor = displayColor;
            Clickable = clickable;
        }
    }
}
