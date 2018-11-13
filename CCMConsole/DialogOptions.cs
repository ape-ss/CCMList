using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCMAddrBook
{
    public partial class DialogOptions : Form
    {
        public string SCCMPath { get; set; }

        public DialogOptions()
        {
            InitializeComponent();
            EdSCCMPath.Text = Properties.Settings.Default.CcmViewerPath;
            BtOk.DialogResult = DialogResult.OK;
        }

        public DialogOptions(string SCCMPath)
        {
            InitializeComponent();
            EdSCCMPath.Text = SCCMPath;
            BtOk.DialogResult = DialogResult.OK;
        }

        private void BtSelect_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "";
            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                EdSCCMPath.Text = openDialog.FileName;
                SCCMPath = openDialog.FileName;
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.CcmViewerPath = EdSCCMPath.Text;
            Properties.Settings.Default.Save();
        }

        private void BtApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
