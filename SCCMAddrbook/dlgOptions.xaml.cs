using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SCCMAddrbook
{
    /// <summary>
    /// Interaction logic for dlgOptions.xaml
    /// </summary>
    public partial class dlgOptions : Window
    {
        public string SCCMPath { get; set; }
        public bool SavePosition { get; set; }
        public bool SaveSize { get; set; }
        public RCApps RemoteControl { get; set; }

        public dlgOptions()
        {
            InitializeComponent();
            EdSccmPath.Text = Properties.Settings.Default.SccmPath;
            CbSavePosition.IsChecked = Properties.Settings.Default.SavePosition;
            CbSaveSize.IsChecked = Properties.Settings.Default.SaveSize;
            switch(Properties.Settings.Default.RCApplication)
            {
                case RCApps.rdp:
                    RbRdp.IsChecked = true;
                    break;
                case RCApps.sccmviewer:
                    RbSccmViewer.IsChecked = true;
                    break;
            }
        }

        private void SaveSettings()
        {
            SCCMPath = EdSccmPath.Text;
            SavePosition = CbSavePosition.IsChecked ?? false;
            SaveSize = CbSaveSize.IsChecked ?? false;
            if (RbSccmViewer.IsChecked == true)
            {
                RemoteControl = RCApps.sccmviewer;
            }
            else if (RbRdp.IsChecked == true)
            {
                RemoteControl = RCApps.rdp;
            }
        }

        private void BtBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                EdSccmPath.Text = openFile.FileName;
            }
        }

        private void BtConfirm_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            this.DialogResult = true;
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }
    }
}
