using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleDriveIntegrationWPFMVVM.ViewModels.Helpers
{
    public static class GoogleDriveHelper
    {
        private static DriveService service;

        private static async Task AuthenticateAsync()
        {
            // Reading client secrets json file added in the project
            using (var clientSecretsStream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(

                    // Loading from input streama and passing client secrets to authorization flow call
                    GoogleClientSecrets.Load(clientSecretsStream).Secrets,

                    /* Scopes => See, edit, create and delete all your google drive files. This is for testing purpose, for real applications, 
                     * the scope should only be as required
                     */
                    new[] { DriveService.Scope.Drive }, 

                    // user to authorize. For testing purpose, this can be "user". But for real applications, this can be user's username/email.
                    "user",

                    // Cancellation token to cancel an operation
                    CancellationToken.None,

                    // Data store where the access token and refresh tokens should be stored
                    new FileDataStore("Drive.Api.Auth.Store")
                );

                // Initializing service with the user credentials
                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,

                    // This name can be anything. Not dependent on the project name created in console
                    ApplicationName = "Google Drive Integration WPF"
                });
            }
        }

        public static async Task<ObservableCollection<Google.Apis.Drive.v3.Data.File>> GetFilesAsync()
        {
            // Authenticate user
            await AuthenticateAsync();

            // Getting files from the user's Google drive
            var list = await service.Files.List().ExecuteAsync();

            // Returning the files as observable collection to be bound to control's items source
            return new ObservableCollection<Google.Apis.Drive.v3.Data.File>(list.Files);
        }
    }
}
