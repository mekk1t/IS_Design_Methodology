namespace CustomCodec.MVVM.Models.FilesManagement.Interfaces
{
    public interface IFileManager
    {
        public void SelectFile();
        public void UnselectFile();
        public void ReadFromFile(string filePath);
        public void SaveToFile(string filePath);
    }
}