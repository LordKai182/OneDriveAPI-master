namespace KoenZomers.OneDrive.AuthenticatorApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AuthenticationBrowser = new System.Windows.Forms.WebBrowser();
            this.Step1Button = new System.Windows.Forms.Button();
            this.CurrentUrlTextBox = new System.Windows.Forms.TextBox();
            this.CurrentUrlLabel = new System.Windows.Forms.Label();
            this.AuthorizationCodeLabel = new System.Windows.Forms.Label();
            this.AuthorizationCodeTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenLabel = new System.Windows.Forms.Label();
            this.AccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.JsonResultTextBox = new System.Windows.Forms.TextBox();
            this.RefreshTokenButton = new System.Windows.Forms.Button();
            this.RefreshTokenLabel = new System.Windows.Forms.Label();
            this.RefreshTokenTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenValidLabel = new System.Windows.Forms.Label();
            this.AccessTokenValidTextBox = new System.Windows.Forms.TextBox();
            this.CreateFolderButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.UseProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.OneDriveTypeCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AuthenticationBrowser
            // 
            this.AuthenticationBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthenticationBrowser.Location = new System.Drawing.Point(12, 202);
            this.AuthenticationBrowser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AuthenticationBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.AuthenticationBrowser.Name = "AuthenticationBrowser";
            this.AuthenticationBrowser.ScriptErrorsSuppressed = true;
            this.AuthenticationBrowser.Size = new System.Drawing.Size(494, 304);
            this.AuthenticationBrowser.TabIndex = 0;
            this.AuthenticationBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.AuthenticationBrowser_Navigated);
            // 
            // Step1Button
            // 
            this.Step1Button.Location = new System.Drawing.Point(243, 52);
            this.Step1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Step1Button.Name = "Step1Button";
            this.Step1Button.Size = new System.Drawing.Size(107, 41);
            this.Step1Button.TabIndex = 1;
            this.Step1Button.Text = "Authorize";
            this.Step1Button.UseVisualStyleBackColor = true;
            this.Step1Button.Click += new System.EventHandler(this.Step1Button_Click);
            // 
            // CurrentUrlTextBox
            // 
            this.CurrentUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentUrlTextBox.Location = new System.Drawing.Point(12, 537);
            this.CurrentUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CurrentUrlTextBox.Name = "CurrentUrlTextBox";
            this.CurrentUrlTextBox.Size = new System.Drawing.Size(494, 22);
            this.CurrentUrlTextBox.TabIndex = 4;
            // 
            // CurrentUrlLabel
            // 
            this.CurrentUrlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentUrlLabel.AutoSize = true;
            this.CurrentUrlLabel.Location = new System.Drawing.Point(13, 517);
            this.CurrentUrlLabel.Name = "CurrentUrlLabel";
            this.CurrentUrlLabel.Size = new System.Drawing.Size(87, 17);
            this.CurrentUrlLabel.TabIndex = 5;
            this.CurrentUrlLabel.Text = "Current URL";
            // 
            // AuthorizationCodeLabel
            // 
            this.AuthorizationCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AuthorizationCodeLabel.AutoSize = true;
            this.AuthorizationCodeLabel.Location = new System.Drawing.Point(12, 569);
            this.AuthorizationCodeLabel.Name = "AuthorizationCodeLabel";
            this.AuthorizationCodeLabel.Size = new System.Drawing.Size(128, 17);
            this.AuthorizationCodeLabel.TabIndex = 7;
            this.AuthorizationCodeLabel.Text = "Authorization Code";
            // 
            // AuthorizationCodeTextBox
            // 
            this.AuthorizationCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorizationCodeTextBox.Location = new System.Drawing.Point(11, 587);
            this.AuthorizationCodeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AuthorizationCodeTextBox.Name = "AuthorizationCodeTextBox";
            this.AuthorizationCodeTextBox.Size = new System.Drawing.Size(494, 22);
            this.AuthorizationCodeTextBox.TabIndex = 6;
            // 
            // AccessTokenLabel
            // 
            this.AccessTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenLabel.AutoSize = true;
            this.AccessTokenLabel.Location = new System.Drawing.Point(12, 702);
            this.AccessTokenLabel.Name = "AccessTokenLabel";
            this.AccessTokenLabel.Size = new System.Drawing.Size(97, 17);
            this.AccessTokenLabel.TabIndex = 9;
            this.AccessTokenLabel.Text = "Access Token";
            // 
            // AccessTokenTextBox
            // 
            this.AccessTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessTokenTextBox.Location = new System.Drawing.Point(11, 721);
            this.AccessTokenTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccessTokenTextBox.Name = "AccessTokenTextBox";
            this.AccessTokenTextBox.Size = new System.Drawing.Size(494, 22);
            this.AccessTokenTextBox.TabIndex = 8;
            this.AccessTokenTextBox.TextChanged += new System.EventHandler(this.AccessTokenTextBox_TextChanged);
            // 
            // JsonResultTextBox
            // 
            this.JsonResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JsonResultTextBox.Location = new System.Drawing.Point(12, 202);
            this.JsonResultTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JsonResultTextBox.Multiline = true;
            this.JsonResultTextBox.Name = "JsonResultTextBox";
            this.JsonResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.JsonResultTextBox.Size = new System.Drawing.Size(493, 302);
            this.JsonResultTextBox.TabIndex = 10;
            this.JsonResultTextBox.Visible = false;
            // 
            // RefreshTokenButton
            // 
            this.RefreshTokenButton.Location = new System.Drawing.Point(355, 52);
            this.RefreshTokenButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshTokenButton.Name = "RefreshTokenButton";
            this.RefreshTokenButton.Size = new System.Drawing.Size(107, 41);
            this.RefreshTokenButton.TabIndex = 12;
            this.RefreshTokenButton.Text = "Refresh";
            this.RefreshTokenButton.UseVisualStyleBackColor = true;
            this.RefreshTokenButton.Click += new System.EventHandler(this.RefreshTokenButton_Click);
            // 
            // RefreshTokenLabel
            // 
            this.RefreshTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshTokenLabel.AutoSize = true;
            this.RefreshTokenLabel.Location = new System.Drawing.Point(13, 614);
            this.RefreshTokenLabel.Name = "RefreshTokenLabel";
            this.RefreshTokenLabel.Size = new System.Drawing.Size(102, 17);
            this.RefreshTokenLabel.TabIndex = 14;
            this.RefreshTokenLabel.Text = "Refresh Token";
            // 
            // RefreshTokenTextBox
            // 
            this.RefreshTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshTokenTextBox.Location = new System.Drawing.Point(12, 633);
            this.RefreshTokenTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshTokenTextBox.Name = "RefreshTokenTextBox";
            this.RefreshTokenTextBox.Size = new System.Drawing.Size(494, 22);
            this.RefreshTokenTextBox.TabIndex = 13;
            // 
            // AccessTokenValidLabel
            // 
            this.AccessTokenValidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenValidLabel.AutoSize = true;
            this.AccessTokenValidLabel.Location = new System.Drawing.Point(12, 658);
            this.AccessTokenValidLabel.Name = "AccessTokenValidLabel";
            this.AccessTokenValidLabel.Size = new System.Drawing.Size(154, 17);
            this.AccessTokenValidLabel.TabIndex = 16;
            this.AccessTokenValidLabel.Text = "Access Token Valid Till";
            // 
            // AccessTokenValidTextBox
            // 
            this.AccessTokenValidTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessTokenValidTextBox.Location = new System.Drawing.Point(11, 677);
            this.AccessTokenValidTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccessTokenValidTextBox.Name = "AccessTokenValidTextBox";
            this.AccessTokenValidTextBox.Size = new System.Drawing.Size(494, 22);
            this.AccessTokenValidTextBox.TabIndex = 15;
            // 
            // CreateFolderButton
            // 
            this.CreateFolderButton.Location = new System.Drawing.Point(130, 52);
            this.CreateFolderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateFolderButton.Name = "CreateFolderButton";
            this.CreateFolderButton.Size = new System.Drawing.Size(107, 41);
            this.CreateFolderButton.TabIndex = 25;
            this.CreateFolderButton.Text = "Create Folder";
            this.CreateFolderButton.UseVisualStyleBackColor = true;
            this.CreateFolderButton.Click += new System.EventHandler(this.CreateFolderButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(17, 52);
            this.UploadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(107, 41);
            this.UploadButton.TabIndex = 19;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // UseProxyCheckBox
            // 
            this.UseProxyCheckBox.AutoSize = true;
            this.UseProxyCheckBox.Location = new System.Drawing.Point(368, 15);
            this.UseProxyCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UseProxyCheckBox.Name = "UseProxyCheckBox";
            this.UseProxyCheckBox.Size = new System.Drawing.Size(94, 21);
            this.UseProxyCheckBox.TabIndex = 18;
            this.UseProxyCheckBox.Text = "Use Proxy";
            this.UseProxyCheckBox.UseVisualStyleBackColor = true;
            this.UseProxyCheckBox.CheckedChanged += new System.EventHandler(this.UseProxyCheckBox_CheckedChanged);
            // 
            // OneDriveTypeCombo
            // 
            this.OneDriveTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OneDriveTypeCombo.FormattingEnabled = true;
            this.OneDriveTypeCombo.Items.AddRange(new object[] {
            "Consumer OneDrive",
            "OneDrive for Business O365",
            "Graph API (Consumer & Business)"});
            this.OneDriveTypeCombo.Location = new System.Drawing.Point(15, 12);
            this.OneDriveTypeCombo.Margin = new System.Windows.Forms.Padding(4);
            this.OneDriveTypeCombo.Name = "OneDriveTypeCombo";
            this.OneDriveTypeCombo.Size = new System.Drawing.Size(335, 24);
            this.OneDriveTypeCombo.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 761);
            this.Controls.Add(this.CreateFolderButton);
            this.Controls.Add(this.OneDriveTypeCombo);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.UseProxyCheckBox);
            this.Controls.Add(this.AccessTokenValidLabel);
            this.Controls.Add(this.AccessTokenValidTextBox);
            this.Controls.Add(this.RefreshTokenLabel);
            this.Controls.Add(this.RefreshTokenTextBox);
            this.Controls.Add(this.RefreshTokenButton);
            this.Controls.Add(this.JsonResultTextBox);
            this.Controls.Add(this.AccessTokenLabel);
            this.Controls.Add(this.AccessTokenTextBox);
            this.Controls.Add(this.AuthorizationCodeLabel);
            this.Controls.Add(this.AuthorizationCodeTextBox);
            this.Controls.Add(this.CurrentUrlLabel);
            this.Controls.Add(this.CurrentUrlTextBox);
            this.Controls.Add(this.Step1Button);
            this.Controls.Add(this.AuthenticationBrowser);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(381, 309);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OneDrive API OpenNext";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser AuthenticationBrowser;
        private System.Windows.Forms.Button Step1Button;
        private System.Windows.Forms.TextBox CurrentUrlTextBox;
        private System.Windows.Forms.Label CurrentUrlLabel;
        private System.Windows.Forms.Label AuthorizationCodeLabel;
        private System.Windows.Forms.TextBox AuthorizationCodeTextBox;
        private System.Windows.Forms.Label AccessTokenLabel;
        private System.Windows.Forms.TextBox AccessTokenTextBox;
        private System.Windows.Forms.TextBox JsonResultTextBox;
        private System.Windows.Forms.Button RefreshTokenButton;
        private System.Windows.Forms.Label RefreshTokenLabel;
        private System.Windows.Forms.TextBox RefreshTokenTextBox;
        private System.Windows.Forms.Label AccessTokenValidLabel;
        private System.Windows.Forms.TextBox AccessTokenValidTextBox;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button CreateFolderButton;
        private System.Windows.Forms.CheckBox UseProxyCheckBox;
        private System.Windows.Forms.ComboBox OneDriveTypeCombo;
    }
}

