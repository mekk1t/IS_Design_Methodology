using System.Windows;
using System.ComponentModel;

namespace CustomCodec_WPF.MVVM.Views
{
    public partial class DecodingWindow : Window
    {
        public DecodingWindow()
        {
            InitializeComponent();
        }

        private void ReturnToSelection(object sender, CancelEventArgs e)
        {
            new OperationSelection().Show();
        }
    }
}
