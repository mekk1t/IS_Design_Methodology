using CustomCodec.MVVM.Models.EncodingDecoding;
using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec.Operations.FilesManagement;
using CustomCodec_WPF.MVVM.Models;
using CustomCodec_WPF.MVVM.Models.Commands;
using CustomCodec_WPF.MVVM.ViewModels;
using CustomCodec_WPF.MVVM.Views;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace CustomCodec.MVVM.ViewModels
{
    public class EncodingViewModel : INotifyPropertyChanged
    {
        public bool CanTestEncoding
        {
            get
            {
                return !InputHasText && OutputHasText;
            }
        }
        public bool OutputHasText
        {
            get
            {
                return !string.IsNullOrEmpty(Output);
            }
        }
        public bool InputHasText
        {
            get
            {
                return !string.IsNullOrEmpty(Input);
            }
        }

        public string WelcomeText { get; } =
            "Чтобы зашифровать сообщение, введите текст в поле слева вручную или считав из файла. " +
            "Нажмите на кнопку \"Зашифровать\", чтобы получить результат.";

        private string _input;
        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                NotifyPropertyChanged(nameof(Input));
                NotifyPropertyChanged(nameof(InputHasText));
            }
        }

        private AlgorithmParameters cachedParameters { get; set; }

        private string _output;
        public string Output {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
                NotifyPropertyChanged(nameof(Output));
                NotifyPropertyChanged(nameof(OutputHasText));
            }
        }

        public ICommand saveToFileCommand { get; set; }
        public ICommand clearInputCommand { get; set; }
        public ICommand readFromFileCommand { get; set; }
        public ICommand encodeCommand { get; set; }
        public ICommand testEncodingCommand { get; set; }

        private readonly FileManager fileManager;
        private ICodec codec;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClearInput()
        {
            Input = null;
            NotifyPropertyChanged(nameof(CanTestEncoding));
        }

        private void ReadFromFile()
        {
            Input = fileManager.ReadFromFile();
        }

        private void CacheParameters(AlgorithmParameters parameters)
        {
            cachedParameters = new AlgorithmParameters(parameters);
        }

        private void Encode()
        {
            var algorithmParameters = new AlgorithmParameters();
            var valuesWindow = new Values();
            if (valuesWindow.ShowDialog() == true)
            {
                var dataContext = (ValuesViewModel)valuesWindow.DataContext;

                algorithmParameters.Key = dataContext.Key;
                algorithmParameters.Message = Input;

                CacheParameters(algorithmParameters);

                codec = new VernamAlgorithm(algorithmParameters);
                codec.Encode();

                Output = codec.GetEncodedMessage();

                cachedParameters.Message = Output;
                NotifyPropertyChanged(nameof(CanTestEncoding));
            }
        }

        private void TestEncoding()
        {
            if (cachedParameters != null)
            {
                Input = default;
                NotifyPropertyChanged(nameof(Input));
                Thread.Sleep(1000);

                codec = new VernamAlgorithm(cachedParameters);
                codec.Decode();
                Input = codec.GetDecodedMessage();

                NotifyPropertyChanged(nameof(CanTestEncoding));
            }
        }

        private void SaveToFile()
        {
            fileManager.SaveToFile(Output);
        }

        public EncodingViewModel()
        {
            fileManager = new FileManager();
            readFromFileCommand = new Command(ReadFromFile);
            encodeCommand = new Command(Encode);
            testEncodingCommand = new Command(TestEncoding);
            clearInputCommand = new Command(ClearInput);
            saveToFileCommand = new Command(SaveToFile);
        }
    }
}
