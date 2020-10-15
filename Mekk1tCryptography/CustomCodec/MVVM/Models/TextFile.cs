namespace CustomCodec.MVVM.Models
{
    public class TextFile
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] BinaryData { get; set; }
        public string Text { get; set; }
    }
}
