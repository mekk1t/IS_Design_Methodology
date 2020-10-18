using CustomCodec;
using System.Windows;

namespace CustomCodec_WPF.MVVM.Views
{
    public partial class OperationSelection : Window
    {
        public OperationSelection()
        {
            InitializeComponent();
        }

        private void OpenDecoding(object sender, RoutedEventArgs e)
        {
            new DecodingWindow().Show();
        }

        private void OpenEncoding(object sender, RoutedEventArgs e)
        {
            new EncodingWindow().Show();
        }
    }
}
