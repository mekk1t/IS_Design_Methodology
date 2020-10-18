using System.Windows;

namespace CustomCodec_WPF.MVVM.Views
{
    public partial class Values : Window
    {
        public Values()
        {
            InitializeComponent();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
