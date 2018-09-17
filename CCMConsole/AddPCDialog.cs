using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCMList
{
    public partial class AddPCDialog : Form
    {
        public string DomainName { get; set; }
        public string FrendlyName { get; set; }

        public AddPCDialog()
        {
            InitializeComponent();
            edIpAddress.Text = "";
            edFrendlyName.Text = "";
            btAddPC.DialogResult = DialogResult.OK;
        }

        public AddPCDialog(string domainName, string frendlyName)
        {
            InitializeComponent();
            edIpAddress.Text = domainName;
            edFrendlyName.Text = frendlyName;
            btAddPC.DialogResult = DialogResult.OK;
        }

        private void btAddPC_Click(object sender, EventArgs e)
        {
            FrendlyName = edFrendlyName.Text;
            DomainName = edIpAddress.Text;
        }

        private void edFrendlyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btAddPC.PerformClick();
            }
        }

        private void AddPCDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void AddPCDialog_KeyUp(object sender, KeyEventArgs e)
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
