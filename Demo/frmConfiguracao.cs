using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpennextUploader
{
    public partial class frmConfiguracao : Form
    {
        private readonly Configuration _configuration;
        public frmConfiguracao()
        {
            InitializeComponent();
        }


        void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var settings = _configuration.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                _configuration.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
