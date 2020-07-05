namespace OneDrive_OpenNext
{
    partial class Form1
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
            this.AccessTokenValidLabel = new System.Windows.Forms.Label();
            this.AccessTokenValidTextBox = new System.Windows.Forms.TextBox();
            this.RefreshTokenLabel = new System.Windows.Forms.Label();
            this.RefreshTokenTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenLabel = new System.Windows.Forms.Label();
            this.AccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.AuthorizationCodeLabel = new System.Windows.Forms.Label();
            this.AuthorizationCodeTextBox = new System.Windows.Forms.TextBox();
            this.CurrentUrlLabel = new System.Windows.Forms.Label();
            this.CurrentUrlTextBox = new System.Windows.Forms.TextBox();
            this.OneDriveTypeCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AccessTokenValidLabel
            // 
            this.AccessTokenValidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenValidLabel.AutoSize = true;
            this.AccessTokenValidLabel.Location = new System.Drawing.Point(29, 396);
            this.AccessTokenValidLabel.Name = "AccessTokenValidLabel";
            this.AccessTokenValidLabel.Size = new System.Drawing.Size(154, 17);
            this.AccessTokenValidLabel.TabIndex = 26;
            this.AccessTokenValidLabel.Text = "Access Token Valid Till";
            // 
            // AccessTokenValidTextBox
            // 
            this.AccessTokenValidTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessTokenValidTextBox.Location = new System.Drawing.Point(28, 415);
            this.AccessTokenValidTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccessTokenValidTextBox.Name = "AccessTokenValidTextBox";
            this.AccessTokenValidTextBox.Size = new System.Drawing.Size(1412, 22);
            this.AccessTokenValidTextBox.TabIndex = 25;
            // 
            // RefreshTokenLabel
            // 
            this.RefreshTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshTokenLabel.AutoSize = true;
            this.RefreshTokenLabel.Location = new System.Drawing.Point(30, 352);
            this.RefreshTokenLabel.Name = "RefreshTokenLabel";
            this.RefreshTokenLabel.Size = new System.Drawing.Size(102, 17);
            this.RefreshTokenLabel.TabIndex = 24;
            this.RefreshTokenLabel.Text = "Refresh Token";
            // 
            // RefreshTokenTextBox
            // 
            this.RefreshTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshTokenTextBox.Location = new System.Drawing.Point(29, 371);
            this.RefreshTokenTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshTokenTextBox.Name = "RefreshTokenTextBox";
            this.RefreshTokenTextBox.Size = new System.Drawing.Size(1412, 22);
            this.RefreshTokenTextBox.TabIndex = 23;
            // 
            // AccessTokenLabel
            // 
            this.AccessTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenLabel.AutoSize = true;
            this.AccessTokenLabel.Location = new System.Drawing.Point(29, 440);
            this.AccessTokenLabel.Name = "AccessTokenLabel";
            this.AccessTokenLabel.Size = new System.Drawing.Size(97, 17);
            this.AccessTokenLabel.TabIndex = 22;
            this.AccessTokenLabel.Text = "Access Token";
            // 
            // AccessTokenTextBox
            // 
            this.AccessTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessTokenTextBox.Location = new System.Drawing.Point(28, 459);
            this.AccessTokenTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccessTokenTextBox.Name = "AccessTokenTextBox";
            this.AccessTokenTextBox.Size = new System.Drawing.Size(1412, 22);
            this.AccessTokenTextBox.TabIndex = 21;
            // 
            // AuthorizationCodeLabel
            // 
            this.AuthorizationCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AuthorizationCodeLabel.AutoSize = true;
            this.AuthorizationCodeLabel.Location = new System.Drawing.Point(29, 307);
            this.AuthorizationCodeLabel.Name = "AuthorizationCodeLabel";
            this.AuthorizationCodeLabel.Size = new System.Drawing.Size(128, 17);
            this.AuthorizationCodeLabel.TabIndex = 20;
            this.AuthorizationCodeLabel.Text = "Authorization Code";
            // 
            // AuthorizationCodeTextBox
            // 
            this.AuthorizationCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorizationCodeTextBox.Location = new System.Drawing.Point(28, 325);
            this.AuthorizationCodeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AuthorizationCodeTextBox.Name = "AuthorizationCodeTextBox";
            this.AuthorizationCodeTextBox.Size = new System.Drawing.Size(1412, 22);
            this.AuthorizationCodeTextBox.TabIndex = 19;
            // 
            // CurrentUrlLabel
            // 
            this.CurrentUrlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentUrlLabel.AutoSize = true;
            this.CurrentUrlLabel.Location = new System.Drawing.Point(30, 255);
            this.CurrentUrlLabel.Name = "CurrentUrlLabel";
            this.CurrentUrlLabel.Size = new System.Drawing.Size(87, 17);
            this.CurrentUrlLabel.TabIndex = 18;
            this.CurrentUrlLabel.Text = "Current URL";
            // 
            // CurrentUrlTextBox
            // 
            this.CurrentUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentUrlTextBox.Location = new System.Drawing.Point(29, 275);
            this.CurrentUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CurrentUrlTextBox.Name = "CurrentUrlTextBox";
            this.CurrentUrlTextBox.Size = new System.Drawing.Size(1412, 22);
            this.CurrentUrlTextBox.TabIndex = 17;
            // 
            // OneDriveTypeCombo
            // 
            this.OneDriveTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OneDriveTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OneDriveTypeCombo.FormattingEnabled = true;
            this.OneDriveTypeCombo.Items.AddRange(new object[] {
            "Consumer OneDrive",
            "OneDrive for Business O365",
            "Graph API (Consumer & Business)"});
            this.OneDriveTypeCombo.Location = new System.Drawing.Point(29, 206);
            this.OneDriveTypeCombo.Margin = new System.Windows.Forms.Padding(4);
            this.OneDriveTypeCombo.Name = "OneDriveTypeCombo";
            this.OneDriveTypeCombo.Size = new System.Drawing.Size(257, 24);
            this.OneDriveTypeCombo.TabIndex = 27;
            this.OneDriveTypeCombo.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 736);
            this.Controls.Add(this.OneDriveTypeCombo);
            this.Controls.Add(this.AccessTokenValidLabel);
            this.Controls.Add(this.AccessTokenValidTextBox);
            this.Controls.Add(this.RefreshTokenLabel);
            this.Controls.Add(this.RefreshTokenTextBox);
            this.Controls.Add(this.AccessTokenLabel);
            this.Controls.Add(this.AccessTokenTextBox);
            this.Controls.Add(this.AuthorizationCodeLabel);
            this.Controls.Add(this.AuthorizationCodeTextBox);
            this.Controls.Add(this.CurrentUrlLabel);
            this.Controls.Add(this.CurrentUrlTextBox);
            this.Name = "Form1";
            this.Text = "OpenNext Uploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AccessTokenValidLabel;
        private System.Windows.Forms.TextBox AccessTokenValidTextBox;
        private System.Windows.Forms.Label RefreshTokenLabel;
        private System.Windows.Forms.TextBox RefreshTokenTextBox;
        private System.Windows.Forms.Label AccessTokenLabel;
        private System.Windows.Forms.TextBox AccessTokenTextBox;
        private System.Windows.Forms.Label AuthorizationCodeLabel;
        private System.Windows.Forms.TextBox AuthorizationCodeTextBox;
        private System.Windows.Forms.Label CurrentUrlLabel;
        private System.Windows.Forms.TextBox CurrentUrlTextBox;
        private System.Windows.Forms.ComboBox OneDriveTypeCombo;
    }
}

