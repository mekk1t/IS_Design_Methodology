namespace CustomCodec.MVVM.Models.EncodingDecoding.Interfaces
{
    public interface ICodec
    {
        public void Encode();
        public void Decode();
        public string GetMessage();
    }
}