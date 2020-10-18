﻿using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec.Operations.FilesManagement;
using System.ComponentModel;

namespace CustomCodec_WPF.MVVM.ViewModels
{
    public class DecodingViewModel : INotifyPropertyChanged
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
            "Чтобы расшифровать сообщение, введите текст в поле слева вручную или считав из файла. " +
            "Нажмите на кнопку \"Расшифровать\", чтобы получить результат.";

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
                NotifyPropertyChanged(nameof(OutputHasText));
            }
        }

        private readonly FileManager fileManager;
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
