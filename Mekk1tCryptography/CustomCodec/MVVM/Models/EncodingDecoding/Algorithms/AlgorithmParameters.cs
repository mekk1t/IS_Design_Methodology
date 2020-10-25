namespace CustomCodec_WPF.MVVM.Models
{
    public class AlgorithmParameters
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public bool UseRussian { get; set; } = true;

        public AlgorithmParameters()
        {
        }

        public AlgorithmParameters(AlgorithmParameters parameters)
        {
            Key = parameters.Key;
            Message = parameters.Message;
            UseRussian = parameters.UseRussian;
        }
    }
}