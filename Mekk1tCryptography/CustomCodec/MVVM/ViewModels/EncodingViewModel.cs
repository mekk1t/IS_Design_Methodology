using CustomCodec.MVVM.Models.EncodingDecoding;
using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec.Operations.FilesManagement;
using CustomCodec_WPF.MVVM.Models;
using CustomCodec_WPF.MVVM.Models.Commands;
using CustomCodec_WPF.MVVM.ViewModels;
using CustomCodec_WPF.MVVM.Views;
using System.ComponentModel;
using System.Windows.Input;

namespace CustomCodec.MVVM.ViewModels
{
    public class EncodingViewModel : INotifyPropertyChanged
    {
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

        public ICommand readFromFileCommand { get; set; }
        public ICommand encodeCommand { get; set; }

        private readonly FileManager fileManager;
        private ICodec codec;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ReadFromFile()
        {
            Input = fileManager.ReadFromFile();
        }

        private void Encode()
        {
            var algorithmParameters = new AlgorithmParameters();
            var valuesWindow = new Values();
            if (valuesWindow.ShowDialog() == true)
            {
                var dataContext = (ValuesViewModel)valuesWindow.DataContext;
                algorithmParameters.Key = dataContext.Key;
                algorithmParameters.Mod = dataContext.Mod;
                algorithmParameters.Message = Input;
            }
            codec = new VernamAlgorithm(algorithmParameters);
            codec.Encode();
            Output = codec.GetEncodedMessage();
        }

        public EncodingViewModel()
        {
            fileManager = new FileManager();
            readFromFileCommand = new Command(ReadFromFile);
            encodeCommand = new Command(Encode);
        }
    }
}
