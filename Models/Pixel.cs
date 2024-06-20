namespace Models
{
    public class Pixel
    {
        public int Color;
        public int CurrentColor = 0;
        public bool Clicked = false;

        public Pixel()
        {
            Color = 0;
        }
        public Pixel(int color)
        {
            Color = color;
        }

        public void DrawnColor(int color)
        {
            CurrentColor = color;
        }

        public void ChangeCurrentColor(int color)
        {
            CurrentColor = color;
            Clicked = true;
        }
        public bool ColorsMatch() => Color == CurrentColor;
    }
}
