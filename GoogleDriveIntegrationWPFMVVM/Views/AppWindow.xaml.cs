using GoogleDriveIntegrationWPFMVVM.ViewModels;
using System.Windows;

namespace GoogleDriveIntegrationWPFMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        // Data members
        private static AppWindow _Instance;

        // Public properties
        public static AppWindow Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AppWindow();

                return _Instance;
            }
        }

        private AppWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = AppWindowVM.Instance;
        }
    }
}
