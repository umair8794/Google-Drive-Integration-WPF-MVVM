using System.Text;

namespace GoogleDriveIntegrationWPFMVVM.ViewModels
{
    public class AppWindowVM
    {
        // Data members
        private static AppWindowVM _Instance;

        // Public properties
        public static AppWindowVM Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AppWindowVM();

                return _Instance;
            }
        }

        public string Title
        {
            get { return new StringBuilder("Google Drive Integration").ToString(); }
        }

        private AppWindowVM()
        {

        }
    }
}
