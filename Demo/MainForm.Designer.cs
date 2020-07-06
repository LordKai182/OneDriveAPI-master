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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AuthenticationBrowser = new System.Windows.Forms.WebBrowser();
            this.Step1Button = new System.Windows.Forms.Button();
            this.CurrentUrlLabel = new System.Windows.Forms.Label();
            this.AuthorizationCodeLabel = new System.Windows.Forms.Label();
            this.AccessTokenLabel = new System.Windows.Forms.Label();
            this.JsonResultTextBox = new System.Windows.Forms.TextBox();
            this.RefreshTokenButton = new System.Windows.Forms.Button();
            this.RefreshTokenLabel = new System.Windows.Forms.Label();
            this.AccessTokenValidLabel = new System.Windows.Forms.Label();
            this.CreateFolderButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.UseProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.OneDriveTypeCombo = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurarAmbiente = new System.Windows.Forms.ToolStripMenuItem();
            this.Log = new System.Windows.Forms.ToolStripMenuItem();
            this.TokenReFresh = new System.Windows.Forms.ToolStripMenuItem();
            this.Sair = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CurrentUrlTextBox = new System.Windows.Forms.TextBox();
            this.AuthorizationCodeTextBox = new System.Windows.Forms.TextBox();
            this.RefreshTokenTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenValidTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.AuthenticationBrowser.Size = new System.Drawing.Size(785, 168);
            this.AuthenticationBrowser.TabIndex = 0;
            this.AuthenticationBrowser.Visible = false;
            this.AuthenticationBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.AuthenticationBrowser_Navigated);
            // 
            // Step1Button
            // 
            this.Step1Button.Location = new System.Drawing.Point(243, 52);
            this.Step1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Step1Button.Name = "Step1Button";
            this.Step1Button.Size = new System.Drawing.Size(107, 41);
            this.Step1Button.TabIndex = 1;
            this.Step1Button.Text = "Autorizar";
            this.Step1Button.UseVisualStyleBackColor = true;
            this.Step1Button.Click += new System.EventHandler(this.Step1Button_Click);
            // 
            // CurrentUrlLabel
            // 
            this.CurrentUrlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentUrlLabel.AutoSize = true;
            this.CurrentUrlLabel.Location = new System.Drawing.Point(15, 443);
            this.CurrentUrlLabel.Name = "CurrentUrlLabel";
            this.CurrentUrlLabel.Size = new System.Drawing.Size(87, 17);
            this.CurrentUrlLabel.TabIndex = 5;
            this.CurrentUrlLabel.Text = "Current URL";
            // 
            // AuthorizationCodeLabel
            // 
            this.AuthorizationCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AuthorizationCodeLabel.AutoSize = true;
            this.AuthorizationCodeLabel.Location = new System.Drawing.Point(14, 499);
            this.AuthorizationCodeLabel.Name = "AuthorizationCodeLabel";
            this.AuthorizationCodeLabel.Size = new System.Drawing.Size(128, 17);
            this.AuthorizationCodeLabel.TabIndex = 7;
            this.AuthorizationCodeLabel.Text = "Authorization Code";
            // 
            // AccessTokenLabel
            // 
            this.AccessTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenLabel.AutoSize = true;
            this.AccessTokenLabel.Location = new System.Drawing.Point(14, 682);
            this.AccessTokenLabel.Name = "AccessTokenLabel";
            this.AccessTokenLabel.Size = new System.Drawing.Size(97, 17);
            this.AccessTokenLabel.TabIndex = 9;
            this.AccessTokenLabel.Text = "Access Token";
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
            this.JsonResultTextBox.Size = new System.Drawing.Size(784, 261);
            this.JsonResultTextBox.TabIndex = 10;
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
            this.RefreshTokenLabel.Location = new System.Drawing.Point(14, 563);
            this.RefreshTokenLabel.Name = "RefreshTokenLabel";
            this.RefreshTokenLabel.Size = new System.Drawing.Size(102, 17);
            this.RefreshTokenLabel.TabIndex = 14;
            this.RefreshTokenLabel.Text = "Refresh Token";
            // 
            // AccessTokenValidLabel
            // 
            this.AccessTokenValidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenValidLabel.AutoSize = true;
            this.AccessTokenValidLabel.Location = new System.Drawing.Point(13, 624);
            this.AccessTokenValidLabel.Name = "AccessTokenValidLabel";
            this.AccessTokenValidLabel.Size = new System.Drawing.Size(154, 17);
            this.AccessTokenValidLabel.TabIndex = 16;
            this.AccessTokenValidLabel.Text = "Access Token Valid Till";
            // 
            // CreateFolderButton
            // 
            this.CreateFolderButton.Location = new System.Drawing.Point(130, 52);
            this.CreateFolderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateFolderButton.Name = "CreateFolderButton";
            this.CreateFolderButton.Size = new System.Drawing.Size(107, 41);
            this.CreateFolderButton.TabIndex = 25;
            this.CreateFolderButton.Text = "Criar Pasta";
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
            this.UseProxyCheckBox.Size = new System.Drawing.Size(99, 21);
            this.UseProxyCheckBox.TabIndex = 18;
            this.UseProxyCheckBox.Text = "Usar Proxy";
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
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.Menu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "One Drive OpenNext";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Abrir,
            this.ConfigurarAmbiente,
            this.Log,
            this.TokenReFresh,
            this.Sair});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(218, 124);
            // 
            // Abrir
            // 
            this.Abrir.Name = "Abrir";
            this.Abrir.Size = new System.Drawing.Size(217, 24);
            this.Abrir.Text = "Abrir";
            // 
            // ConfigurarAmbiente
            // 
            this.ConfigurarAmbiente.Name = "ConfigurarAmbiente";
            this.ConfigurarAmbiente.Size = new System.Drawing.Size(217, 24);
            this.ConfigurarAmbiente.Text = "Configurar Ambiente";
            this.ConfigurarAmbiente.Click += new System.EventHandler(this.ConfigurarAmbiente_Click);
            // 
            // Log
            // 
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(217, 24);
            this.Log.Text = "Exibir Log";
            // 
            // TokenReFresh
            // 
            this.TokenReFresh.Name = "TokenReFresh";
            this.TokenReFresh.Size = new System.Drawing.Size(217, 24);
            this.TokenReFresh.Text = "Refresh Token";
            // 
            // Sair
            // 
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(217, 24);
            this.Sair.Text = "Sair";
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Path = "C:\\temp";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 48);
            this.button1.TabIndex = 26;
            this.button1.Text = "Executar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::OpennextUploader.Properties.Resources.e9291eaddacd460280a34a151dcc5cc4;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(797, 362);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // CurrentUrlTextBox
            // 
            this.CurrentUrlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUrlTextBox.Location = new System.Drawing.Point(15, 400);
            this.CurrentUrlTextBox.Multiline = true;
            this.CurrentUrlTextBox.Name = "CurrentUrlTextBox";
            this.CurrentUrlTextBox.ReadOnly = true;
            this.CurrentUrlTextBox.Size = new System.Drawing.Size(777, 28);
            this.CurrentUrlTextBox.TabIndex = 33;
            // 
            // AuthorizationCodeTextBox
            // 
            this.AuthorizationCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorizationCodeTextBox.Location = new System.Drawing.Point(14, 468);
            this.AuthorizationCodeTextBox.Multiline = true;
            this.AuthorizationCodeTextBox.Name = "AuthorizationCodeTextBox";
            this.AuthorizationCodeTextBox.ReadOnly = true;
            this.AuthorizationCodeTextBox.Size = new System.Drawing.Size(777, 28);
            this.AuthorizationCodeTextBox.TabIndex = 34;
            // 
            // RefreshTokenTextBox
            // 
            this.RefreshTokenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshTokenTextBox.Location = new System.Drawing.Point(14, 543);
            this.RefreshTokenTextBox.Multiline = true;
            this.RefreshTokenTextBox.Name = "RefreshTokenTextBox";
            this.RefreshTokenTextBox.ReadOnly = true;
            this.RefreshTokenTextBox.Size = new System.Drawing.Size(777, 28);
            this.RefreshTokenTextBox.TabIndex = 35;
            // 
            // AccessTokenValidTextBox
            // 
            this.AccessTokenValidTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessTokenValidTextBox.Location = new System.Drawing.Point(14, 619);
            this.AccessTokenValidTextBox.Multiline = true;
            this.AccessTokenValidTextBox.Name = "AccessTokenValidTextBox";
            this.AccessTokenValidTextBox.ReadOnly = true;
            this.AccessTokenValidTextBox.Size = new System.Drawing.Size(777, 28);
            this.AccessTokenValidTextBox.TabIndex = 36;
            this.AccessTokenValidTextBox.TextChanged += new System.EventHandler(this.AccessTokenValidTextBox_TextChanged_2);
            // 
            // AccessTokenTextBox
            // 
            this.AccessTokenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessTokenTextBox.Location = new System.Drawing.Point(14, 689);
            this.AccessTokenTextBox.Multiline = true;
            this.AccessTokenTextBox.Name = "AccessTokenTextBox";
            this.AccessTokenTextBox.ReadOnly = true;
            this.AccessTokenTextBox.Size = new System.Drawing.Size(777, 28);
            this.AccessTokenTextBox.TabIndex = 37;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(966, 913);
            this.Controls.Add(this.AccessTokenTextBox);
            this.Controls.Add(this.AccessTokenValidTextBox);
            this.Controls.Add(this.RefreshTokenTextBox);
            this.Controls.Add(this.AuthorizationCodeTextBox);
            this.Controls.Add(this.CurrentUrlTextBox);
            this.Controls.Add(this.AccessTokenValidLabel);
            this.Controls.Add(this.RefreshTokenLabel);
            this.Controls.Add(this.AuthorizationCodeLabel);
            this.Controls.Add(this.CurrentUrlLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CreateFolderButton);
            this.Controls.Add(this.OneDriveTypeCombo);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.UseProxyCheckBox);
            this.Controls.Add(this.RefreshTokenButton);
            this.Controls.Add(this.JsonResultTextBox);
            this.Controls.Add(this.AccessTokenLabel);
            this.Controls.Add(this.Step1Button);
            this.Controls.Add(this.AuthenticationBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(381, 309);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OneDrive API OpenNext";
            this.MinimumSizeChanged += new System.EventHandler(this.MainForm_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser AuthenticationBrowser;
        private System.Windows.Forms.Button Step1Button;
        private System.Windows.Forms.Label CurrentUrlLabel;
        private System.Windows.Forms.Label AuthorizationCodeLabel;
        private System.Windows.Forms.Label AccessTokenLabel;
        private System.Windows.Forms.TextBox JsonResultTextBox;
        private System.Windows.Forms.Button RefreshTokenButton;
        private System.Windows.Forms.Label RefreshTokenLabel;
        private System.Windows.Forms.Label AccessTokenValidLabel;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button CreateFolderButton;
        private System.Windows.Forms.CheckBox UseProxyCheckBox;
        private System.Windows.Forms.ComboBox OneDriveTypeCombo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem Abrir;
        private System.Windows.Forms.ToolStripMenuItem ConfigurarAmbiente;
        private System.Windows.Forms.ToolStripMenuItem Log;
        private System.Windows.Forms.ToolStripMenuItem TokenReFresh;
        private System.Windows.Forms.ToolStripMenuItem Sair;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox CurrentUrlTextBox;
        private System.Windows.Forms.TextBox AuthorizationCodeTextBox;
        private System.Windows.Forms.TextBox RefreshTokenTextBox;
        private System.Windows.Forms.TextBox AccessTokenTextBox;
        private System.Windows.Forms.TextBox AccessTokenValidTextBox;
    }
}

