using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec.MVVM.Models.FilesManagement.Interfaces;
using System.ComponentModel;

namespace CustomCodec_WPF.MVVM.ViewModels
{
    public class DecodingViewModel : INotifyPropertyChanged
    {
        private bool _didUserInputText;
        public bool DidUserInputText
        {
            get
            {
                return _didUserInputText;
            }
            set
            {
                _didUserInputText = value;
                NotifyPropertyChanged(nameof(DidUserInputText));
            }
        }
        public bool Encoded
        {
            get
            {
                return !string.IsNullOrEmpty(Input);
            }
        }
        public bool Decoded
        {
            get
            {
                return !string.IsNullOrEmpty(Output);
            }
        }

        public string WelcomeText { get; } =
            "Чтобы зашифровать сообщение, введите текст в поле слева вручную или считав из файла." +
            "Нажмите на кнопку \"Зашифровать\", чтобы получить результат.";
        public string Title { get; } = "kit.kalimov © 2020 All Rights Reserved";

        private string _output;
        public string Output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
                NotifyPropertyChanged(nameof(Output));
            }
        }

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

                if (!string.IsNullOrEmpty(_input))
                    DidUserInputText = true;

                NotifyPropertyChanged(nameof(Input));
            }
        }

        private readonly IFileManager fileManager;
        private readonly ICodec codec;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DecodingViewModel()
        {

        }
    }
}
