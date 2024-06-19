namespace Models
{
    public class FileRaster : Raster
    {
        public FileRaster(string filename, int startColor, bool displayValues = true, bool displayColor = true, bool clickable = false)
        {
            try
            {
                using StreamReader reader = new("/Data/" + filename);
                string text = reader.ReadToEnd();
                StringRaster stringRaster = new StringRaster(text, startColor, displayValues, displayColor, clickable);
                Grid = stringRaster.Grid;
                DisplayValues = stringRaster.DisplayValues;
                DisplayColor = stringRaster.DisplayColor;
                Clickable = stringRaster.Clickable;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}