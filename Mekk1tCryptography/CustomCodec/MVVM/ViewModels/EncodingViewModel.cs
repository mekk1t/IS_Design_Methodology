using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec.MVVM.Models.FilesManagement.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace CustomCodec.MVVM.ViewModels
{
    public class EncodingViewModel : INotifyPropertyChanged
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
                return !string.IsNullOrEmpty(EncodedText);
            }
        }
        public bool Decoded
        {
            get
            {
                return !string.IsNullOrEmpty(DecodedText);
            }
        }

        public string WelcomeText { get; } =
            "Чтобы зашифровать сообщение, введите текст в поле слева вручную или считав из файла." +
            "Нажмите на кнопку \"Зашифровать\", чтобы получить результат.";
        public string Title { get; } = "kit.kalimov © 2020 All Rights Reserved";

        private string _decodedText;
        public string DecodedText
        {
            get
            {
                return _decodedText;
            }
            set
            {
                _decodedText = value;
                NotifyPropertyChanged(nameof(DecodedText));
            }
        }

        private string _encodedText;
        public string EncodedText {
            get
            {
                return _encodedText;
            }
            set
            {
                _encodedText = value;
                NotifyPropertyChanged(nameof(EncodedText));
            }
        }

        private readonly IFileManager fileManager;
        private readonly ICodec codec;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EncodingViewModel()
        {
        }
    }
}
