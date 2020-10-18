using Microsoft.Win32;
using System.IO;

namespace CustomCodec.Operations.FilesManagement
{
    public class FileManager
    {
        public string ReadFromFile()
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                return File.ReadAllText(ofd.FileName);
            }
            return null;
        }
    }
}
