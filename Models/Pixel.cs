namespace Models
{
    public class Pixel
    {
        public int Color;
        public int CurrentColor = 0;

        public Pixel()
        {
            Color = 0;
        }
        public Pixel (int color)
        {
            Color = color;
        }

        public void DrawnColor(int color)
        {
            CurrentColor = color;
        }

        public bool ColorsMatch() => Color == CurrentColor;
    }
}
