using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DlgAddNode : Window
    {
        public string IpAddress { get; set; }
        public string DomainName { get; set; }
        public string FriendlyName { get; set; }

        public DlgAddNode()
        {
            InitializeComponent();
            fieldIPAddress.Focus();
        }

        public DlgAddNode(string ipAddress, string domainName, string friendlyName)
        {
            InitializeComponent();
            fieldIPAddress.Text = ipAddress;
            fieldDomainName.Text = domainName;
            fieldFriendlyName.Text = friendlyName;
            fieldIPAddress.Focus();
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            IpAddress = fieldIPAddress.Text;
            DomainName = fieldDomainName.Text;
            FriendlyName = fieldFriendlyName.Text;
            this.DialogResult = true;
        }

        private void FieldIPAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fieldDomainName.Text == "")
            {
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(fieldIPAddress.Text);
                    string[] domain = host.HostName.Split(new char[] { '.' });
                    fieldDomainName.Text = domain[0];
                }
                catch (Exception)
                {
                    fieldDomainName.Text = "";
                }
            }
        }

        private void FieldDomainName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fieldIPAddress.Text == "")
            {
                try
                {
                    string ipAddress = Dns.GetHostEntry(fieldDomainName.Text).AddressList[0].ToString();
                    fieldIPAddress.Text = ipAddress;
                }
                catch (Exception)
                {
                    fieldIPAddress.Text = "";
                }
            }
        }
    }
}
