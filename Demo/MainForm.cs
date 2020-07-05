using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using KoenZomers.OneDrive.Api;
using KoenZomers.OneDrive.Api.Entities;
using KoenZomers.OneDrive.Api.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace KoenZomers.OneDrive.AuthenticatorApp
{
    public partial class MainForm : Form
    {
        #region Properties

        /// <summary>
        /// Application configuration
        /// </summary>
        private readonly Configuration _configuration;

        /// <summary>
        /// OneDriveApi instance to work with
        /// </summary>
        public OneDriveApi OneDriveApi;

        /// <summary>
        /// The refresh token stored in the App Config
        /// </summary>
        public string RefreshToken;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            RefreshToken = _configuration.AppSettings.Settings["OneDriveApiRefreshToken"].Value;

            RefreshTokenTextBox.Text = RefreshToken;
            OneDriveTypeCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// Creates a new instance of the OneDrive API
        /// </summary>
        private void InitiateOneDriveApi()
        {
            // Define the type of OneDrive API to instantiate based on the dropdown list selection    
            switch (OneDriveTypeCombo.SelectedIndex)
            {
                case 0:
                    OneDriveApi = new OneDriveConsumerApi(_configuration.AppSettings.Settings["OneDriveConsumerApiClientID"].Value, _configuration.AppSettings.Settings["OneDriveConsumerApiClientSecret"].Value);
                    if(!string.IsNullOrEmpty(_configuration.AppSettings.Settings["OneDriveConsumerApiRedirectUri"].Value))
                    {
                        OneDriveApi.AuthenticationRedirectUrl = _configuration.AppSettings.Settings["OneDriveConsumerApiRedirectUri"].Value;
                    }
                    break;

                case 1:
                    OneDriveApi = new OneDriveForBusinessO365Api(_configuration.AppSettings.Settings["OneDriveForBusinessO365ApiClientID"].Value, _configuration.AppSettings.Settings["OneDriveForBusinessO365ApiClientSecret"].Value);
                    break;

                case 2:
                    OneDriveApi = new OneDriveGraphApi(_configuration.AppSettings.Settings["GraphApiApplicationId"].Value);
                    break;
            }

            OneDriveApi.ProxyConfiguration = UseProxyCheckBox.Checked ? System.Net.WebRequest.DefaultWebProxy : null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Reset any possible access tokens we may already have
       
            // Make the Graph API the default choice
            OneDriveTypeCombo.SelectedIndex = OneDriveTypeCombo.Items.Count - 1;
            var teste = GetAuthCode();
            AccessTokenTextBox.Text = teste.Result;

            // Create a new instance of the OneDriveApi framework
            InitiateOneDriveApi();

            // First sign the current user out to make sure he/she needs to authenticate again
            var signoutUri = OneDriveApi.GetSignOutUri();
            AuthenticationBrowser.Navigate(signoutUri);
        }

        private async void AuthenticationBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Get the currently displayed URL and show it in the textbox
            CurrentUrlTextBox.Text = e.Url.ToString();            

            // Check if the current URL contains the authorization token
            AuthorizationCodeTextBox.Text = OneDriveApi.GetAuthorizationTokenFromUrl(e.Url.ToString());

            // Verify if an authorization token was successfully extracted
            if (!string.IsNullOrEmpty(AuthorizationCodeTextBox.Text))
            {
                // Get an access token based on the authorization token that we now have
                await OneDriveApi.GetAccessToken();
                if (OneDriveApi.AccessToken != null)
                {
                    // Show the access token information in the textboxes
                    AccessTokenTextBox.Text = OneDriveApi.AccessToken.AccessToken;
                    RefreshTokenTextBox.Text = OneDriveApi.AccessToken.RefreshToken;
                    AccessTokenValidTextBox.Text = OneDriveApi.AccessTokenValidUntil.HasValue ? OneDriveApi.AccessTokenValidUntil.Value.ToString("dd-MM-yyyy HH:mm:ss") : "Not valid";
                    
                    // Store the refresh token in the AppSettings so next time you don't have to log in anymore
                    _configuration.AppSettings.Settings["OneDriveApiRefreshToken"].Value = RefreshTokenTextBox.Text;
                    _configuration.Save(ConfigurationSaveMode.Modified);
                    return;
                }
            }

            // If we're on this page, but we didn't get an authorization token, it means that we just signed out, proceed with signing in again
            if (CurrentUrlTextBox.Text.StartsWith(OneDriveApi.SignoutUri))
            {
                var authenticateUri = OneDriveApi.GetAuthenticationUri();
                AuthenticationBrowser.Navigate(authenticateUri);
            }
        }

        /// <summary>
        /// Starts the process to interactively authenticate a user and get an Access and Refresh token
        /// </summary>
        private void Step1Button_Click(object sender, EventArgs e)
        {
            // Reset any possible access tokens we may already have
            var teste = GetAuthCode();
            AccessTokenTextBox.Text = teste.Result;
            
            // Create a new instance of the OneDriveApi framework
            InitiateOneDriveApi();

            // First sign the current user out to make sure he/she needs to authenticate again
            var signoutUri = OneDriveApi.GetSignOutUri();
            AuthenticationBrowser.Navigate(signoutUri);
        }

        /// <summary>
        /// Uses the RefreshToken from the RefreshToken textbox to authenticate without user interaction
        /// </summary>
        private async void RefreshTokenButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefreshTokenTextBox.Text))
            {
                MessageBox.Show("You need to enter a refresh token first in the refresh token field in order to be able to retrieve a new access token based on a refresh token.", "OneDrive API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Create a new instance of the OneDriveApi framework
            InitiateOneDriveApi();

            // Get a new access token based on the refresh token entered in the textbox
            await OneDriveApi.AuthenticateUsingRefreshToken(RefreshTokenTextBox.Text);

            if (OneDriveApi.AccessToken != null)
            {
                // Display the information of the new access token in the textboxes
                AccessTokenTextBox.Text = OneDriveApi.AccessToken.AccessToken;
                RefreshTokenTextBox.Text = OneDriveApi.AccessToken.RefreshToken;
                AccessTokenValidTextBox.Text = OneDriveApi.AccessTokenValidUntil.HasValue ? OneDriveApi.AccessTokenValidUntil.Value.ToString("dd-MM-yyyy HH:mm:ss") : "Not valid";
            }
        }

        private void AccessTokenTextBox_TextChanged(object sender, EventArgs e)
        {
            var accessTokenAvailable = !string.IsNullOrEmpty(((TextBox) sender).Text);
            OneDriveCommandsPanel.Enabled = accessTokenAvailable;
            AuthenticationBrowser.Visible = !accessTokenAvailable;
            JsonResultTextBox.Visible = accessTokenAvailable;
            JsonResultTextBox.Text = "Connected";
        }

        /// <summary>
        /// Gets the metadata of the OneDrive drive
        /// </summary>
        private async void GetDriveButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetDrive();
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets the metadata of the root folder in OneDrive
        /// </summary>
        private async void GetRoodFolderButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetDriveRoot();
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets the OneDrive items in the root of the OneDrive
        /// </summary>
        private async void GetRootChildren_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetDriveRootChildren();
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets the OneDrive items in the Documents folder. If it doesn't exist yet, it will create the folder automatically.
        /// </summary>
        private async void GetDocumentsButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetDriveDocumentsFolder();
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets the OneDrive items in the Camera folder. If it doesn't exist yet, it will create the folder automatically.
        /// </summary>
        private async void GetCameraRollButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetDriveCameraRollFolder();
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets the OneDrive items in the Photos folder. If it doesn't exist yet, it will create the folder automatically.
        /// </summary>
        private async void GetPhotos_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetDrivePhotosFolder();
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets the OneDrive items in the Public folder. If it doesn't exist yet, it will create the folder automatically.
        /// </summary>
        private async void GetPublicButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetDrivePublicFolder();
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Allows picking a file which will be uploaded to the OneDrive root
        /// </summary>
        private async void UploadButton_Click(object sender, EventArgs e)
        {
            var fileToUpload = SelectLocalFile();

            // Reset the output field
            JsonResultTextBox.Text = $"Starting upload{Environment.NewLine}";

            // Define the anonynous method to respond to the file upload progress events
            EventHandler <OneDriveUploadProgressChangedEventArgs> progressHandler = delegate(object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

            // Subscribe to the upload progress event
            OneDriveApi.UploadProgressChanged += progressHandler;

            // Upload the file to the root of the OneDrive
            var data = await OneDriveApi.UploadFile(fileToUpload, await OneDriveApi.GetDriveRoot());

            // Unsubscribe from the upload progress event
            OneDriveApi.UploadProgressChanged -= progressHandler;

            // Display the result of the upload
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        private string SelectLocalFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Upload to OneDrive";
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.CheckFileExists = true;
            var response = dialog.ShowDialog();

            return response != DialogResult.OK ? null : dialog.FileName;
        }

        /// <summary>
        /// Gets the items in the OneDrive folder called 'Demo'
        /// </summary>
        private async void GetByPathButton_Click(object sender, EventArgs e)
        {            
            var data = await OneDriveApi.GetChildrenByPath("Demo");
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets the items in the OneDrive folder with the ID 'E499210E61A71FF3!3635'
        /// </summary>
        private async void GetByIdButton_Click(object sender, EventArgs e)
        {
            var data1 = await OneDriveApi.GetChildrenByFolderId("E499210E61A71FF3!3635");
            JsonResultTextBox.Text = data1 != null ? data1.OriginalJson : "Not found";
        }
        
        /// <summary>
        /// Downloads the file Test.txt from the OneDrive root and displays its contents in the output box
        /// </summary>
        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            // Retrieve the items in the root of the OneDrive
            var items = await OneDriveApi.GetDriveRootChildren();

            // Ensure there are items in the root of this OneDrive
            if(items.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "OneDrive is empty, nothing to download";
                return;
            }

            // Find the first file of which its filename ends with .txt
            var firstTextFileItem = items.Collection.FirstOrDefault(i => i.Name.EndsWith(".txt"));
            if (firstTextFileItem == null)
            {
                JsonResultTextBox.Text = "No .txt file found in the root of this OneDrive to download";
                return;
            }

            // Download the .txt file and render its contents in the output window
            using (var stream = await OneDriveApi.DownloadItem(firstTextFileItem))
            {
                using (var writer = new StreamReader(stream))
                {
                    JsonResultTextBox.Text = await writer.ReadToEndAsync();
                }
            }
        }

        /// <summary>
        /// Downloads the file Test.txt from the OneDrive root to the folder from where this application is being run
        /// </summary>
        private async void DownloadToButton_Click(object sender, EventArgs e)
        {
            var item = await OneDriveApi.GetItem("Test.txt");
            if (item != null)
            {
                var localFolder = new FileInfo(Application.ExecutablePath).DirectoryName;
                var success = await OneDriveApi.DownloadItem(item, localFolder);
                JsonResultTextBox.Text = success ? "Downloaded successfully to " + localFolder : "Download failed";
            }
            else
            {
                JsonResultTextBox.Text = "Unable to find Test.txt in the OneDrive root";
            }
        }

        /// <summary>
        /// Searches for the word 'photo' inside OneDrive
        /// </summary>
        private async void SearchButton_Click(object sender, EventArgs e)
        {
            var searchQuery = "photo";
            var data = await OneDriveApi.Search(searchQuery);
            JsonResultTextBox.Text = data.Count.ToString();
        }

        /// <summary>
        /// Deletes the file Test.txt from the OneDrive root
        /// </summary>
        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.Delete("Test.txt");
            JsonResultTextBox.Text = data.ToString();
        }

        /// <summary>
        /// Creates a new folder structure in OneDrive. It will check to ensure the whole path exists and create each folder in the path if it doesn't exist yet.
        /// </summary>
        private async void CreateFolderButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetFolderOrCreate("Test\\sub1\\sub2");
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Shares the folder Test in the OneDrive root by creating an anonymous link with Edit permissions
        /// </summary>
        private async void ShareButton_Click(object sender, EventArgs e)
        {
            var data = await ((OneDriveGraphApi) OneDriveApi).ShareItem("Test", OneDriveLinkType.Edit, OneDriveSharingScope.Anonymous);
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Copies the file Test.txt from the OneDrive root to a subfolder called Test and renames it to 'Copied Test.txt'
        /// </summary>
        private async void CopyButton_Click(object sender, EventArgs e)
        {
            var success = await OneDriveApi.Copy("Test.txt", "Test", "Copied Test.txt");
            JsonResultTextBox.Text = success ? "Copy Successfull" : "Copy Failed";
        }

        /// <summary>
        /// Moves the file Test.txt from the OneDrive root to a subfolder called Test
        /// </summary>
        private async void MoveButton_Click(object sender, EventArgs e)
        {
            var success = await OneDriveApi.Move("Test.txt", "Test");
            JsonResultTextBox.Text = success ? "Move Successfull" : "Move Failed";
        }

        /// <summary>
        /// Renames the file Test.txt in the OneDrive root to 'Renamed Test.txt'
        /// </summary>
        private async void RenameButton_Click(object sender, EventArgs e)
        {
            var success = await OneDriveApi.Rename("Test.txt", "Renamed Test.txt");
            JsonResultTextBox.Text = success ? "Rename Successfull" : "Rename Failed";
        }

        /// <summary>
        /// Gets all items in OneDrive that have been shared with the current user
        /// </summary>
        private async void SharedWithMeButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetSharedWithMe();
            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Gets the root SharePoint site belonging to the current user
        /// </summary>
        private async void RootSiteButton_Click(object sender, EventArgs e)
        {
            if(!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var data = await ((OneDriveGraphApi) OneDriveApi).GetSiteRoot();

            if(data == null)
            {
                JsonResultTextBox.Text = "No data returned. Did you connect using a work or school account?";
                return;
            }

            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Gets the permissions on the Test folder in the OneDrive root
        /// </summary>
        private async void GetPermissionsButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var data = await((OneDriveGraphApi)OneDriveApi).ListPermissions("Test");

            if (data == null)
            {
                JsonResultTextBox.Text = "No data returned. Did you connect using a work or school account?";
                return;
            }

            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Adds permissions for test@zomers.eu to access the folder Test in the OneDrive root with View/ReadOnly rights and it will require test@zomers.eu to be signed in and this account will receive an e-mail stating the folder has been shared with this user
        /// </summary>
        private async void AddPermissionButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var data = await((OneDriveGraphApi)OneDriveApi).AddPermission("Test", true, true, OneDriveLinkType.View, "Testing of sharing this item", new[] { "test@zomers.eu" });

            if (data == null)
            {
                JsonResultTextBox.Text = "No data returned. Did you connect using a work or school account?";
                return;
            }

            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Changes the permissions to the first assigned permission on the Test folder in the OneDrive root to become Edit if it was read or to become View if it was Edit
        /// </summary>
        private async void ChangePermissionButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var currentPermissions = await ((OneDriveGraphApi)OneDriveApi).ListPermissions("Test");
            var data = await((OneDriveGraphApi)OneDriveApi).ChangePermission("Test", currentPermissions.Collection[0].Id, currentPermissions.Collection[0].Roles[0] == "read" ? OneDriveLinkType.Edit : OneDriveLinkType.View);

            if (data == null)
            {
                JsonResultTextBox.Text = "No data returned. Did you connect using a work or school account?";
                return;
            }

            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Removes the first sharing permissions that it can find on the Test folder in the OneDrive root
        /// </summary>
        private async void RemovePermissionsButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var currentPermissions = await ((OneDriveGraphApi)OneDriveApi).ListPermissions("Test");

            if(currentPermissions.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "No permissions are set";
                return;
            }

            var result = await ((OneDriveGraphApi)OneDriveApi).RemovePermission("Test", currentPermissions.Collection[0].Id);

            JsonResultTextBox.Text = result ? "Removing permissions successful" : "Removing permissions failed";
        }

        /// <summary>
        /// Gets the metadata of the AppFolder root folder
        /// </summary>
        private async void GetAppFolderMetadataButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var data = await((OneDriveGraphApi)OneDriveApi).GetAppFolderMetadata();
            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Gets the files in the root of the AppFolder
        /// </summary>
        private async void GetAppFolderFilesButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var data = await((OneDriveGraphApi)OneDriveApi).GetAppFolderChildren();
            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Creates a new folder in the root of the AppFolder
        /// </summary>
        private async void AppFolderCreateFolderButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var data = await((OneDriveGraphApi)OneDriveApi).GetAppFolderFolderOrCreate("Test");
            JsonResultTextBox.Text = data.OriginalJson;
        }

        /// <summary>
        /// Allows picking a file which will be uploaded to the AppFolder its root folder
        /// </summary>
        private async void UploadToAppFolderButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var fileToUpload = SelectLocalFile();

            // Reset the output field
            JsonResultTextBox.Text = $"Starting upload{Environment.NewLine}";

            // Define the anonynous method to respond to the file upload progress events
            EventHandler<OneDriveUploadProgressChangedEventArgs> progressHandler = delegate (object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

            // Subscribe to the upload progress event
            OneDriveApi.UploadProgressChanged += progressHandler;

            // Upload the file to the root of the OneDrive
            var data = await((OneDriveGraphApi)OneDriveApi).UploadFileToAppFolder(fileToUpload);

            // Unsubscribe from the upload progress event
            OneDriveApi.UploadProgressChanged -= progressHandler;

            // Display the result of the upload
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Downloads the first file from the AppFolder and displays its contents in the output box
        /// </summary>
        private async void DownloadFromAppFolderButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var items = await((OneDriveGraphApi)OneDriveApi).GetAppFolderChildren();

            // Check that there are items in the AppFolder and that it contains at least one file
            if (items != null && items.Collection != null && items.Collection.Any(i => i.Folder == null))
            {
                // Get the first item which is not a folder
                var item = items.Collection.First(i => i.Folder == null);

                // Download the item its contents
                using (var stream = await OneDriveApi.DownloadItem(item))
                {
                    using (var writer = new StreamReader(stream))
                    {
                        // Write the file contents to the output box
                        JsonResultTextBox.Text = await writer.ReadToEndAsync();
                    }
                }
            }
            else
            {
                JsonResultTextBox.Text = "No files found in the AppFolder root";
            }
        }

        /// <summary>
        /// Returns all OneDrive items in the first subfolder in the AppFolder
        /// </summary>
        private async void GetFilesInFolderInAppFolderButton_Click(object sender, EventArgs e)
        {
            if (!(OneDriveApi is OneDriveGraphApi))
            {
                JsonResultTextBox.Text = "Only possible when connecting to Graph API";
                return;
            }

            var items = await ((OneDriveGraphApi)OneDriveApi).GetAppFolderChildren();

            // Check for a folder in the AppRoot
            if (items != null && items.Collection != null && items.Collection.Any(i => i.Folder != null))
            {
                // Get the first item which is a folder
                var item = items.Collection.First(i => i.Folder != null);

                // Get the items in the folder under the AppFolder root
                var itemsInFolderUnderAppFolder = await OneDriveApi.GetChildrenByParentItem(item);
                JsonResultTextBox.Text = itemsInFolderUnderAppFolder.OriginalJson;
            }
            else
            {
                JsonResultTextBox.Text = "No folder found in the AppFolder root";
            }
        }

        /// <summary>
        /// Returns all OneDrive items in a folder on another drive that has been shared with the current user
        /// </summary>
        private async void GetChildrenFromOtherDriveButton_Click(object sender, EventArgs e)
        {
            // Retrieve the items shared with the current user
            var sharedWithMe = await OneDriveApi.GetSharedWithMe();

            // Check if any items are shared and if so if there's a shared folder among it
            if(sharedWithMe.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "No items are shared with this user";
                return;
            }
            if(sharedWithMe.Collection.All(item => item.RemoteItem.Folder != null))
            {
                JsonResultTextBox.Text = "No folder is shared with this user";
                return;
            }

            // Take the first folder item shared with the current user and retrieve its children
            var sharedWithMeItem = sharedWithMe.Collection.First(item => item.RemoteItem.Folder != null);
            var data = await OneDriveApi.GetChildrenFromDriveByFolderId(sharedWithMeItem.RemoteItem.ParentReference.DriveId, sharedWithMeItem.Id);
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        /// <summary>
        /// Gets another drive which has an item shared with the current user
        /// </summary>
        private async void GetOtherDriveButton_Click(object sender, EventArgs e)
        {
            // Retrieve the items shared with the current user
            var sharedWithMe = await OneDriveApi.GetSharedWithMe();

            // Check if any items are shared and if so if there's a shared folder among it
            if (sharedWithMe.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "No items are shared with this user";
                return;
            }

            // Take the first item shared with the current user and retrieve the drive information on which it is stored
            var data = await OneDriveApi.GetDrive(sharedWithMe.Collection[0].RemoteItem.ParentReference.DriveId);
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        private static Task<string> GetAuthCode()
        {
            TaskCompletionSource<string> completion = new TaskCompletionSource<string>();
            string code = null;

            //var authUriString = string.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={1}&response_type=code&redirect_uri={2}", clientId, Uri.EscapeDataString(scopesString), Uri.EscapeDataString(redirectUri));
            //var authUriString = client.GetAuthorizationRequestUrl(scopes);

            var browser = new Web.Class1();
            browser.Navigating += (sender, eventArgs) => Console.WriteLine("Navigating: " + eventArgs.Uri);
            browser.Navigated += (sender, eventArgs) =>
            {
                /*
                 * Navigating: https://login.live.com/oauth20_authorize.srf?client_id=00000000480FBA5F&redirect_uri=https:%2F%2Flogin.live.com%2Foauth20_desktop.srf&scope=wl.signin wl.basic wl.skydrive&response_type=code&display=windesktop&locale=en-US&state=&theme=win7
                 * Navigated: https://login.live.com/oauth20_authorize.srf?client_id=00000000480FBA5F&redirect_uri=https:%2F%2Flogin.live.com%2Foauth20_desktop.srf&scope=wl.signin wl.basic wl.skydrive&response_type=code&display=windesktop&locale=en-US&state=&theme=win7
                 * Navigating: https://account.live.com/Consent/Update?ru=https://login.live.com/oauth20_authorize.srf%3flc%3d1033%26client_id%3d00000000480FBA5F%26redirect_uri%3dhttps%253A%252F%252Flogin.live.com%252Foauth20_desktop.srf%26scope%3dwl.signin%2520wl.basic%2520wl.skydrive%26response_type%3dcode%26display%3dwindesktop%26locale%3den-US%26state%3d%26theme%3dwin7%26mkt%3dEN-US%26scft%3dCtXDfhkaGJ68YBd6T1M!t4Qm3mQ31srlcyMC3z7hrYSNVo6nVNA0HXdY4BF8JWZDQYLjyoldXbRA3zPqAmhyEUDnX9BcDwStjFHkBQ2J7I!NqdNbiwXMngTKIt4C3fDQjccXbx3RMIE41mpmvSG6saU%2524&mkt=EN-US&uiflavor=windesktop&id=279469&client_id=00000000480FBA5F&scope=wl.signin+wl.basic+wl.skydrive

                 * Navigated: https://account.live.com/Consent/Update?ru=https://login.live.com/oauth20_authorize.srf%3flc%3d1033%26client_id%3d00000000480FBA5F%26redirect_uri%3dhttps%253A%252F%252Flogin.live.com%252Foauth20_desktop.srf%26scope%3dwl.signin%2520wl.basic%2520wl.skydrive%26response_type%3dcode%26display%3dwindesktop%26locale%3den-US%26state%3d%26theme%3dwin7%26mkt%3dEN-US%26scft%3dCtXDfhkaGJ68YBd6T1M!t4Qm3mQ31srlcyMC3z7hrYSNVo6nVNA0HXdY4BF8JWZDQYLjyoldXbRA3zPqAmhyEUDnX9BcDwStjFHkBQ2J7I!NqdNbiwXMngTKIt4C3fDQjccXbx3RMIE41mpmvSG6saU%2524&mkt=EN-US&uiflavor=windesktop&id=279469&client_id=00000000480FBA5F&scope=wl.signin+wl.basic+wl.skydrive
                 * Navigating: https://account.live.com/Consent/Update?ru=https://login.live.com/oauth20_authorize.srf%3flc%3d1033%26client_id%3d00000000480FBA5F%26redirect_uri%3dhttps%253A%252F%252Flogin.live.com%252Foauth20_desktop.srf%26scope%3dwl.signin%2520wl.basic%2520wl.skydrive%26response_type%3dcode%26display%3dwindesktop%26locale%3den-US%26state%3d%26theme%3dwin7%26mkt%3dEN-US%26scft%3dCtXDfhkaGJ68YBd6T1M!t4Qm3mQ31srlcyMC3z7hrYSNVo6nVNA0HXdY4BF8JWZDQYLjyoldXbRA3zPqAmhyEUDnX9BcDwStjFHkBQ2J7I!NqdNbiwXMngTKIt4C3fDQjccXbx3RMIE41mpmvSG6saU%2524&mkt=EN-US&uiflavor=windesktop&id=279469&client_id=00000000480FBA5F&scope=wl.signin+wl.basic+wl.skydrive

                 * Navigating: https://login.live.com/oauth20_authorize.srf?lc=1033&client_id=00000000480FBA5F&redirect_uri=https:%2f%2flogin.live.com%2foauth20_desktop.srf&scope=wl.signin+wl.basic+wl.skydrive&response_type=code&display=windesktop&locale=en-US&state=&theme=win7&mkt=EN-US&scft=CtXDfhkaGJ68YBd6T1M!t4Qm3mQ31srlcyMC3z7hrYSNVo6nVNA0HXdY4BF8JWZDQYLjyoldXbRA3zPqAmhyEUDnX9BcDwStjFHkBQ2J7I!NqdNbiwXMngTKIt4C3fDQjccXbx3RMIE41mpmvSG6saU%24&res=success
                 * Navigating: https://login.live.com/oauth20_desktop.srf?code=4df80f16-2c7a-eb03-778e-f276c1dc95ee&lc=1033
                 * Navigated: https://login.live.com/oauth20_desktop.srf?code=4df80f16-2c7a-eb03-778e-f276c1dc95ee&lc=1033
                 */
                var uri = eventArgs.Uri.OriginalString;
                if (uri.Contains("code="))
                {
                    code = uri.Split(new[] { "code=" }, StringSplitOptions.None)[1];
                    code = code.Split(new[] { "&lc=" }, StringSplitOptions.None)[0];
                    Console.WriteLine("Authorized: " + code);
                    browser.Close();
                }
                else
                {
                    Console.WriteLine("Navigated: " + eventArgs.Uri);
                }
            };

            browser.Show("https://login.live.com/oauth20_authorize.srf?pretty=false&client_id=233d9409-2bc0-404a-8f1e-c122a81615dc&scope=wl.basic+wl.signin+wl.skydrive&response_type=code&redirect_uri=https:%2f%2flogin.microsoftonline.com%2fcommon%2foauth2%2fnativeclient");
            completion.SetResult(code);

            return completion.Task;
        }
    }
}