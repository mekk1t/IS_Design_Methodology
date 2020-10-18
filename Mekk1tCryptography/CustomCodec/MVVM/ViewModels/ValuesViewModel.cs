using System.ComponentModel;

namespace CustomCodec_WPF.MVVM.ViewModels
{
    public class ValuesViewModel : INotifyPropertyChanged
    {
        private byte _mod;
        public byte Mod
        {
            get
            {
                return _mod;
            }
            set
            {
                _mod = value;
                NotifyPropertyChanged(nameof(Mod));
                NotifyPropertyChanged(nameof(AreValuesTypedIn));
            }
        }

        private string _key;
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                NotifyPropertyChanged(nameof(Key));
                NotifyPropertyChanged(nameof(AreValuesTypedIn));
            }
        }

        public bool AreValuesTypedIn
        {
            get
            {
                return !string.IsNullOrEmpty(Key) && Mod != default;
            }
        }

        public ValuesViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
