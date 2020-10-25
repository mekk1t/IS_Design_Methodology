namespace CustomCodec_WPF.MVVM.Models
{
    public class AlgorithmParameters
    {
        public byte Mod { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }

        public AlgorithmParameters()
        {

        }

        public AlgorithmParameters(AlgorithmParameters parameters)
        {
            Mod = parameters.Mod;
            Key = parameters.Key;
            Message = parameters.Message;
        }
    }
}