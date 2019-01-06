using GoogleDriveIntegrationWPFMVVM.Views;
using System.Windows;

namespace GoogleDriveIntegrationWPFMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppWindow.Instance.ShowDialog();
        }
    }
}
