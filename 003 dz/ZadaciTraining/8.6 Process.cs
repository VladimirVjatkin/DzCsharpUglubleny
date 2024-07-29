using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public interface IProcessable : IDisposable
    {
        void Open();
        void Process();
        void Save();
    }

    public class TextProcessor : IProcessable
    {
        private string filePath;
        private string content;

        public TextProcessor(string filePath)
        {
            this.filePath = filePath;
        }

        public void Open()
        {
            content = File.ReadAllText(filePath);
            Console.WriteLine("Text file opened.");
        }

        public void Process()
        {
            content = content.ToUpper();
            Console.WriteLine("Text processed: converted to uppercase.");
        }

        public void Save()
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine("Processed text saved.");
        }

        public void Dispose()
        {
            content = null;
            Console.WriteLine("Text processor resources released.");
        }
    }

    public class ImageProcessor : IProcessable
    {
        private string filePath;
        private Bitmap image;

        public ImageProcessor(string filePath)
        {
            this.filePath = filePath;
        }

        public void Open()
        {
            image = new Bitmap(filePath);
            Console.WriteLine("Image file opened.");
        }

        public void Process()
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayScale = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    image.SetPixel(x, y, grayColor);
                }
            }
            Console.WriteLine("Image processed: converted to grayscale.");
        }

        public void Save()
        {
            image.Save(filePath);
            Console.WriteLine("Processed image saved.");
        }

        public void Dispose()
        {
            image?.Dispose();
            Console.WriteLine("Image processor resources released.");
        }
    }
}
