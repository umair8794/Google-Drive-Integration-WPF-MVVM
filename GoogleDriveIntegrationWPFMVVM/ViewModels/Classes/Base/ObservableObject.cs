using System.ComponentModel;

namespace GoogleDriveIntegrationWPFMVVM.ViewModels.Classes.Base
{
    public class ObservableObject : INotifyPropertyChanged
    {
        protected ObservableObject()
        {

        }

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
