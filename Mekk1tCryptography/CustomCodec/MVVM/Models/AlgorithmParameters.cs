namespace CustomCodec_WPF.MVVM.Models
{
    public class AlgorithmParameters
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public AlgorithmParameters()
        {
        }

        public AlgorithmParameters(AlgorithmParameters parameters)
        {
            Key = parameters.Key;
            Message = parameters.Message;
        }
    }
}