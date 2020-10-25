using System.ComponentModel;

namespace CustomCodec_WPF.MVVM.ViewModels
{
    public class ValuesViewModel : INotifyPropertyChanged
    {
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
                return !string.IsNullOrEmpty(Key);
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
