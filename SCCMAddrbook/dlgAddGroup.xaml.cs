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
    /// Interaction logic for dlgAddGroup.xaml
    /// </summary>
    public partial class dlgAddGroup : Window
    {
        public string GroupName { get; set; }

        public dlgAddGroup()
        {
            InitializeComponent();
            Group.Focus();
        }

        public dlgAddGroup(string groupName)
        {
            InitializeComponent();
            Group.Text = groupName;
            Group.Focus();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            GroupName = Group.Text;
            this.DialogResult = true;
        }
    }
}
