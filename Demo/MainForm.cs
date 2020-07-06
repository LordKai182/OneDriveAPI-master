using Ionic.Zip;
using KoenZomers.OneDrive.Api;
using KoenZomers.OneDrive.Api.Entities;
using OpennextUploader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

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

            var MyIni = new IniFile("Settings.ini");

            MyIni.Write("CNPJ", "88888888888888","USUARIO");
            MyIni.Write("NOME", "Teste", "USUARIO");

            MyIni.Write("PASTABKP", "C:/temp", "CONFIG");
            MyIni.Write("NOMEARQUIVOBKP", "BKP", "CONFIG");

            MyIni.Write("CLIID", "233d9409-2bc0-404a-8f1e-c122a81615dc", "CONFIG");
            MyIni.Write("SECRET", "3tqjw~T_eb5VDft82NC9LV6ME~v9.k~cIj", "CONFIG");
            MyIni.Write("URLREDIRECT", "https://apps.zomers.eu", "CONFIG");

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
            //OneDriveCommandsPanel.Enabled = accessTokenAvailable;
            AuthenticationBrowser.Visible = !accessTokenAvailable;
            JsonResultTextBox.Visible = accessTokenAvailable;
           
           
        }

        public static string ExecutarCMD(string comando)
        {
           System.Diagnostics.Process.Start("CMD.exe", @"/C " + comando).WaitForExit();

           return "Foi";
  
        }

        /// <summary>
        /// Allows picking a file which will be uploaded to the OneDrive root
        /// </summary>
        private async void UploadButton_Click(object sender, EventArgs e)
        {
            var fileToUpload = SelectLocalFile();
            var MyIni = new IniFile("Settings.ini");
            // Reset the output field
            JsonResultTextBox.Text = $"Starting upload{Environment.NewLine}";

            // Define the anonynous method to respond to the file upload progress events
            EventHandler <OneDriveUploadProgressChangedEventArgs> progressHandler = delegate(object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

            // Subscribe to the upload progress event
            OneDriveApi.UploadProgressChanged += progressHandler;

            // Upload the file to the root of the OneDrive
            var data = await OneDriveApi.UploadFile(fileToUpload, await OneDriveApi.GetFolderOrCreate(MyIni.Read("CNPJ", "USUARIO")));

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
        /// Creates a new folder structure in OneDrive. It will check to ensure the whole path exists and create each folder in the path if it doesn't exist yet.
        /// </summary>
        private async void CreateFolderButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetFolderOrCreate("Test\\sub1\\sub2");
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        private async void CreateNamedFolder(string NameFolder)
        {
            var data = await OneDriveApi.GetFolderOrCreate(NameFolder);
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

      

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void MainForm_MinimumSizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("sdsddsd");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Cancelar o fechamento do form
            Hide(); // Ocultar o form
                    // use this.WindowState = FormWindowState.Minimized; para minimizar
            notifyIcon1.Visible = true; // Mostrar o notify icon
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
            }
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void ConfigurarAmbiente_Click(object sender, EventArgs e)
        {
            frmConfiguracao frm = new frmConfiguracao();
            frm.Show();
        }

        private void UseProxyCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        void AddUpdateAppSettings(string key, string value)
        {
            try
            {
               // var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = _configuration.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                _configuration.Save(ConfigurationSaveMode.Full,true);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private async void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            string nomeCOncatenado = string.Empty;
            if (e.Name.Contains(".sql"))
            {
                nomeCOncatenado = e.Name.Substring(0, e.Name.Length - 4) + DateTime.Now.ToString("ddMMyyyy") + ".zip";
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(e.FullPath, "");
                    zip.Save(@"C:/temp/" + nomeCOncatenado);

                }
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = @"C:\\PostgreSQL\\pg10\bin\\pg_dump.exe -h 127.0.0.1 -p 5432 -U postgres -F c -b -v -f C:\\temp\\BkpSql.sql SwitchDB";
            string saida = ExecutarCMD(command);
            File.WriteAllText("NomeArquivo.txt", saida);
        }

        private async void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            string nomeCOncatenado = string.Empty;
            if (e.Name.Contains(".sql"))
            {
                nomeCOncatenado = e.Name.Substring(0, e.Name.Length - 4) + DateTime.Now.ToString("ddMMyyyy") + ".zip";
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(e.FullPath, "");
                    zip.Save(@"C:/temp/" + nomeCOncatenado);

                }
            }
           
               
            
         
        }

        private void AccessTokenValidTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void RefreshTokenTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccessTokenValidTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (AccessTokenValidTextBox.Text != "")
            {
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                JsonResultTextBox.Text = "Conectado com Sucesso...";
                notifyIcon1.BalloonTipTitle = "OneDrive OpenNext";
                notifyIcon1.BalloonTipText = "Conectado com Sucesso...";
                pictureBox1.Visible = false;
                notifyIcon1.ShowBalloonTip(20000);
            }
        }

        private async void AccessTokenValidTextBox_TextChanged_2(object sender, EventArgs e)
        {
            if (AccessTokenValidTextBox.Text != "")
            {
                var MyIni = new IniFile("Settings.ini");
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                JsonResultTextBox.Text = "Conectado com Sucesso...";
                notifyIcon1.BalloonTipTitle = "OneDrive OpenNext";
                notifyIcon1.BalloonTipText = "Conectado com Sucesso...";
                pictureBox1.Visible = false;
                notifyIcon1.ShowBalloonTip(20000);
                var data = await OneDriveApi.GetFolderOrCreate(MyIni.Read("CNPJ", "USUARIO"));
            }
        }

        private async void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {

            if (e.Name.Substring(e.Name.Length - 4, 4).ToString() == ".zip")
            {
                var MyIni = new IniFile("Settings.ini");
                var data = await OneDriveApi.UploadFileAs(e.FullPath, e.Name, await OneDriveApi.GetFolderOrCreate(MyIni.Read("CNPJ", "USUARIO")));

                EventHandler<OneDriveUploadProgressChangedEventArgs> progressHandler = delegate (object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

                OneDriveApi.UploadProgressChanged -= progressHandler;

                //JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
            }
        }
    }
}