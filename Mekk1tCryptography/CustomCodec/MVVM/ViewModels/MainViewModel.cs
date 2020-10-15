using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace CustomCodec.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string urlToImage = @"D:\Repositories\IS_Design_Methodology\Mekk1tCryptography\CustomCodec\icon.ico";
        public BitmapFrame Icon { get; } = BitmapFrame.Create(new Uri(urlToImage, UriKind.Absolute));
        public string Title { get; } = "kit.kalimov © 2020 All Rights Reserved";
        public bool DidUserInputText { get; set; } = false;

        public MainViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
