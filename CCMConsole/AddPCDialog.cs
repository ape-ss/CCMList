using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCMAddrBook
{
    public partial class AddPCDialog : Form
    {
        public string IPAddress { get; set; }
        public string DomainName { get; set; }
        public string FrendlyName { get; set; }

        public AddPCDialog()
        {
            InitializeComponent();
            edIpAddress.Text = "";
            edFrendlyName.Text = "";
            edDomainName.Text = "";
            btAddPC.DialogResult = DialogResult.OK;
        }

        public AddPCDialog(string ipAddress, string domainName, string frendlyName)
        {
            InitializeComponent();
            edIpAddress.Text = ipAddress;
            edDomainName.Text = domainName;
            edFrendlyName.Text = frendlyName;
            btAddPC.DialogResult = DialogResult.OK;
        }

        private void btAddPC_Click(object sender, EventArgs e)
        {
            IPAddress = edIpAddress.Text;
            FrendlyName = edFrendlyName.Text;
            DomainName = edDomainName.Text;
        }

        private void edFrendlyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btAddPC.PerformClick();
            }
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

        private void edIpAddress_Leave(object sender, EventArgs e)
        {
            if (edDomainName.Text == "")
            {
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(edIpAddress.Text);
                    string[] domain = host.HostName.Split(new char[] { '.' });
                    edDomainName.Text = domain[0];
                }
                catch (Exception)
                {
                    edDomainName.Text = "";
                }
            }
        }

        private void edDomainName_Leave(object sender, EventArgs e)
        {
            if (edIpAddress.Text == "")
            {
                try
                {
                    string ipAddress = Dns.GetHostEntry(edDomainName.Text).AddressList[0].ToString();
                    edIpAddress.Text = ipAddress;
                }
                catch (Exception)
                {
                    edIpAddress.Text = "";
                }
            }
        }
    }
}
