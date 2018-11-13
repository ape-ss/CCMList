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
    public partial class AddFolderDialog : Form
    {
        public string FolderName { get; set; }

        public AddFolderDialog()
        {
            InitializeComponent();
            edFolderName.Text = "";
            btAddFolder.DialogResult = DialogResult.OK;
        }

        public AddFolderDialog(string folderName)
        {
            InitializeComponent();
            edFolderName.Text = folderName;
            btAddFolder.DialogResult = DialogResult.OK;
        }

        private void btAddFolder_Click(object sender, EventArgs e)
        {
            FolderName = edFolderName.Text;
        }

        private void AddFolderDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void edFolderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btAddFolder.PerformClick();
            }
        }

        private void AddFolderDialog_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
