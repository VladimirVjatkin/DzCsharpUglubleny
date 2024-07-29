using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public interface IFile : IDisposable
    {
        void Open();
        string Read();
        void Close();
    }

    public class TextFile : IFile
    {
        private string filePath;
        private StreamReader reader;

        public TextFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void Open()
        {
            reader = new StreamReader(filePath);
        }

        public string Read()
        {
            return reader?.ReadToEnd();
        }

        public void Close()
        {
            reader?.Close();
        }

        public void Dispose()
        {
            Close();
        }
    }

    public class ImageFile : IFile
    {
        private string filePath;
        private FileStream fileStream;

        public ImageFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void Open()
        {
            fileStream = new FileStream(filePath, FileMode.Open);
        }

        public string Read()
        {
            // В реальном приложении здесь был бы код для чтения изображения
            return "Image data";
        }

        public void Close()
        {
            fileStream?.Close();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
