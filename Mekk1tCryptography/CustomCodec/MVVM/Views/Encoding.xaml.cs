using CustomCodec_WPF.MVVM.Views;
using System.Windows;
using System.ComponentModel;

namespace CustomCodec
{
    public partial class EncodingWindow : Window
    {
        public EncodingWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            new OperationSelection().Show();
        }
    }
}