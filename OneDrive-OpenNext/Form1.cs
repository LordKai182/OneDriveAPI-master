using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using KoenZomers.OneDrive.Api;
using KoenZomers.OneDrive.Api.Entities;
using KoenZomers.OneDrive.Api.Enums;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Collections.Generic;

namespace OneDrive_OpenNext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OneDriveTypeCombo.SelectedIndex = OneDriveTypeCombo.Items.Count - 1;
            var teste = GetAuthCode();
            AccessTokenTextBox.Text = teste.Result;
            InitiateOneDriveApi();

            // First sign the current user out to make sure he/she needs to authenticate again
            var signoutUri = OneDriveApi.GetSignOutUri();
            AuthenticationBrowser.Navigate(signoutUri);
        }
        private static Task<string> GetAuthCode()
        {
            TaskCompletionSource<string> completion = new TaskCompletionSource<string>();
            string code = null;

            //var authUriString = string.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={1}&response_type=code&redirect_uri={2}", clientId, Uri.EscapeDataString(scopesString), Uri.EscapeDataString(redirectUri));
            // var authUriString = client.GetAuthorizationRequestUrl(scopes);

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
        private async void AuthenticationBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Get the currently displayed URL and show it in the textbox
            CurrentUrlTextBox.Text = e.Url.ToString();
            // WebRequest request = WebRequest.Create("https://login.live.com/oauth20_authorize.srf?pretty=false&client_id=233d9409-2bc0-404a-8f1e-c122a81615dc&scope=wl.basic+wl.signin+wl.skydrive&response_type=code&redirect_uri=https:%2f%2flogin.microsoftonline.com%2fcommon%2foauth2%2fnativeclient");
            // WebResponse response = request.GetResponse();
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
    }
}
