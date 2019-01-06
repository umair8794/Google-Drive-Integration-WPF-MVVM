using Google.Apis.Drive.v3.Data;
using GoogleDriveIntegrationWPFMVVM.ViewModels.Classes.Base;
using GoogleDriveIntegrationWPFMVVM.ViewModels.Helpers;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Text;

namespace GoogleDriveIntegrationWPFMVVM.ViewModels
{
    // Inheriting from ObservableObject class created to fire NotifyPropertyChanged events. See file for more details
    public class AppWindowVM : ObservableObject
    {
        // Data members
        private ObservableCollection<File> files;

        // Title for the App Window
        public string Title
        {
            get { return new StringBuilder("Google Drive Integration").ToString(); }
        }

        // Command to execute on OAuth2 Authentication button click
        public DelegateCommand OAuth2AuthenticationCommand { get; private set; }

        public ObservableCollection<File> Files
        {
            get { return files; }
            set
            {
                if (files != value)
                {
                    files = value;
                    NotifyPropertyChanged("Files");
                }
            }
        }

        public AppWindowVM()
        {
            // Initiating command with async lambda function that will call Helper class to perform authentication and then fetching files
            OAuth2AuthenticationCommand = new DelegateCommand(async () => { Files = await GoogleDriveHelper.GetFilesAsync(); });
        }
    }
}
