using CustomCodec.MVVM.Models;
using CustomCodec.MVVM.Models.FilesManagement.Interfaces;
using Microsoft.Win32;

namespace CustomCodec.Operations.FilesManagement
{
    public class FileManager : IFileManager
    {
        private TextFile inputFile;
        private TextFile outputFile;

        public void ReadFromFile(string filePath)
        {
        }

        public void SaveToFile(string filePath)
        {
        }

        public void SelectFile()
        {
            var ofd = new OpenFileDialog();

            inputFile = new TextFile();
        }

        public void UnselectFile()
        {
            inputFile = null;
        }
    }
}
