using CustomCodec_WPF.MVVM.Views;
using System.Windows;

namespace CustomCodec
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new OperationSelection().Show();
        }
    }
}