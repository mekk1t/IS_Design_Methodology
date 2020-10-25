using Microsoft.Win32;
using System;
using System.IO;

namespace CustomCodec.Operations.FilesManagement
{
    public class FileManager
    {
        public string ReadFromFile()
        {
            var ofd = new OpenFileDialog();

            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (ofd.ShowDialog() == true)
            {
                return File.ReadAllText(ofd.FileName);
            }
            return null;
        }
    }
}
