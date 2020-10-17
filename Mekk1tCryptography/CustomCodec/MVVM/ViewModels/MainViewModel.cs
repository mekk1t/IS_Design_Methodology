using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec.MVVM.Models.FilesManagement.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace CustomCodec.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string urlToImage = @"D:\Repositories\IS_Design_Methodology\Mekk1tCryptography\CustomCodec\icon.ico";
        public BitmapFrame Icon { get; } = BitmapFrame.Create(new Uri(urlToImage, UriKind.Absolute));

        public bool DidUserInputText { get; set; } = false;
        public bool IsEncoded { get; set; } = false;
        public bool NotEncoded
        {
            get
            {
                return !IsEncoded;
            }
            set
            {
                NotEncoded = value;
            }
        }

        public string WelcomeText { get; } =
            "Чтобы зашифровать сообщение, введите текст в поле слева вручную или считав из файла." +
            "Нажмите на кнопку \"Зашифровать\", чтобы получить результат.";

        public string Title { get; } = "kit.kalimov © 2020 All Rights Reserved";
        public string Input { get; set; }
        public string Output { get; set; }

        private readonly IFileManager fileManager;
        private readonly ICodec codec;

        public MainViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
