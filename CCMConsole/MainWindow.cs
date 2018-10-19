using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Diagnostics;

namespace CCMList
{
    public partial class MainWindow : Form
    {

        //private string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\CCMList\";
        private string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CCMList\";
        private string PcAddress;
        private string DomainName;
        /// <summary>
        /// Метод сохраняет дерево из TreeView в XML файл
        /// </summary>
        /// <param name="Nodes">Коллекция веток дерева</param>
        private void SaveTree(TreeNodeCollection Nodes, string fileName)
        {
            List<ListNode> list = new List<ListNode>();
            // Компонуем список для сериализации
            foreach (TreeNode item in Nodes)
            {
                list.Add(new ListNode(item.Name, item.Text, item.Level, item.ImageIndex, item.SelectedImageIndex, (item.Parent == null)?0:item.Parent.Index));
                if (item.Nodes != null)
                {
                    foreach (TreeNode citem in item.Nodes)
                    {
                        list.Add(new ListNode(citem.Name, citem.Text, citem.Level, citem.ImageIndex, citem.SelectedImageIndex, (citem.Parent == null) ? 0 : citem.Parent.Index));
                    }
                }
            }
            //Открываем на запись новый XML файл
            TextWriter fileXml = new StreamWriter(fileName);
            //Инстанцируем сериализатор
            XmlSerializer xml = new XmlSerializer(typeof(List<ListNode>));
            //Собственно сериализация
            try
            {
                xml.Serialize(fileXml, list);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                MessageBox.Show(e.Message);
            }
            fileXml.Close();
        }

        /// <summary>
        /// Метод загружает дерево из XML файла в TreeView
        /// </summary>
        /// <param name="Nodes">Коллекция веток дерева</param>
        private void LoadTree(TreeNodeCollection Nodes, string fileName)
        {
            if (File.Exists(fileName))
            {
                Stream file = File.Open(fileName, FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(List<ListNode>));
                List<ListNode> list = null;
                try
                {
                    list = xml.Deserialize(file) as List<ListNode>;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                file.Close();
                foreach (ListNode item in list)
                {
                    TreeNode tmp = new TreeNode(item.Text, item.ImageIndex, item.SelectedImageIndex);
                    tmp.Name = item.Name;
                    if (item.Level == 0)
                    {
                        Nodes.Add(tmp);
                    }
                    if (item.Level == 1)
                    {
                        Nodes[item.Index].Nodes.Add(tmp);
                    }
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            if (Directory.Exists(homeDir) == false)
            {
                Directory.CreateDirectory(homeDir);
            }
            if (File.Exists(homeDir + "pclist.xml") == true)
            {
                LoadTree(mainList.Nodes, homeDir + "pclist.xml");
            }
            if(!Properties.Settings.Default.MainFormLocation.IsEmpty)
            {
                StartPosition = FormStartPosition.Manual;
                Location = Properties.Settings.Default.MainFormLocation;
            }
            if (!Properties.Settings.Default.MainFormSize.IsEmpty)
            {
                Size = Properties.Settings.Default.MainFormSize;
            }
            PcAddress = labelIPAddress.Text;
            DomainName = labelDomainName.Text;
            toolBar.Visible = Properties.Settings.Default.ToolBarState;
            statusBar.Visible = Properties.Settings.Default.StatusBarState;
            groupDetails.Visible = Properties.Settings.Default.DetailsState;
            menuToolbarStatus.Checked = Properties.Settings.Default.ToolBarState;
            menuDetailsState.Checked = Properties.Settings.Default.DetailsState;
            menuStatusbarState.Checked = Properties.Settings.Default.StatusBarState; ;
        }

        private void AddFolder()
        {
            AddFolderDialog fd = new AddFolderDialog();
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                mainList.Nodes.Add(new TreeNode(fd.FolderName, 4, 5));
            }
        }

        private void AddPC()
        {
            AddPCDialog pcd = new AddPCDialog();
            if (pcd.ShowDialog(this) == DialogResult.OK)
            {
                TreeNode node = new TreeNode(pcd.FrendlyName, 3, 3);
                node.Name = pcd.DomainName;
                try
                {
                    mainList.SelectedNode.Nodes.Add(node);
                }
                catch (Exception E)
                {
                    MessageBox.Show(this, ResMessages.addFolder, ResMessages.addFolderCaption);
                }
            }
        }

        private void buttonNewFolder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void buttonNewNode_Click(object sender, EventArgs e)
        {
            AddPC();
        }

        private void mainList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                mainList.SelectedNode = e.Node;
            }

            if (e.Node.Level != 0)
            {
                statusIpAddress.Text = e.Node.Name;
            }
        }

        private void buttonSaveList_Click(object sender, EventArgs e)
        {
            saveDialog.Filter = "XML Files|*.xml";
            if (saveDialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveTree(mainList.Nodes, saveDialog.FileName);
            }            
        }

        private void buttonOpenList_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "XML Files|*.xml";
            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadTree(mainList.Nodes, openDialog.FileName);
            }
        }

        private bool CheckCcmViewer()
        {
            if (Properties.Settings.Default.CcmViewerPath == "")
            {
                return false;
            }
            return true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTree(mainList.Nodes, homeDir + "pclist.xml");
            if (this.WindowState == FormWindowState.Minimized)
            {
                Properties.Settings.Default.MainFormLocation = Properties.Settings.Default.MainFormLocation;
                Properties.Settings.Default.MainFormSize = Properties.Settings.Default.MainFormSize;
            }
            else
            {
                Properties.Settings.Default.MainFormLocation = Location;
                Properties.Settings.Default.MainFormSize = Size;
            }
            Properties.Settings.Default.Save();
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            if (!CheckCcmViewer())
            {
                openDialog.Filter = "";
                if (openDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Properties.Settings.Default.CcmViewerPath = openDialog.FileName;
                }
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show(Properties.Settings.Default.CcmViewerPath, ResMessages.optCcmPathCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mainList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ConnectToPC();
        }

        private void ConnectToPC()
        {
            if (!CheckCcmViewer())
            {
                MessageBox.Show(ResMessages.msgEmptyCcmPath, ResMessages.msgEmptyCcmPathCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                openDialog.Filter = "";
                if (openDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Properties.Settings.Default.CcmViewerPath = openDialog.FileName;
                }
                Properties.Settings.Default.Save();
            }
            if (mainList.SelectedNode.Level != 0)
            {
                Process.Start(Properties.Settings.Default.CcmViewerPath, mainList.SelectedNode.Name);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectToPC();
        }

        private void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainList.SelectedNode.Level == 0 && mainList.SelectedNode.Nodes != null)
            {
                MessageBox.Show(ResMessages.msgChildNodes, ResMessages.msgChildNodesCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                mainList.SelectedNode.Remove();
            }
        }

        private void EditNode()
        {
            if (mainList.SelectedNode.Level == 0)
            {
                AddFolderDialog fd = new AddFolderDialog(mainList.SelectedNode.Text);
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    mainList.SelectedNode.Name = fd.FolderName;
                    mainList.SelectedNode.Text = fd.FolderName;
                }
            }
            else
            {
                AddPCDialog pcd = new AddPCDialog(mainList.SelectedNode.Name, mainList.SelectedNode.Text);
                if (pcd.ShowDialog(this) == DialogResult.OK)
                {
                    mainList.SelectedNode.Text = pcd.FrendlyName;
                    mainList.SelectedNode.Name = pcd.DomainName;
                }
            }
        }

        private void editNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNode();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                trayIcon.Visible = true;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mainList_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    buttonConnect.PerformClick();
                    break;
            }
        }

        private void mainList_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    editNodeToolStripMenuItem.PerformClick();
                    break;
            }
        }

        private void mainList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //TODO: Добавить определение хоста по айпи
            if (e.Node.Level != 0)
            {
                statusIpAddress.Text = e.Node.Name;
                labelIPAddress.Text = PcAddress + e.Node.Name;
                //IPAddress addr = IPAddress.Parse(e.Node.Name);
                IPHostEntry host = Dns.GetHostByAddress(e.Node.Name);
                string[] domain = host.HostName.Split(new char[] { '.' });
                labelDomainName.Text = DomainName + domain[0];
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EditNode();
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonNewNode.PerformClick();
        }

        private void trayMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusbarToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            statusBar.Visible = menuStatusbarState.Checked;
            Properties.Settings.Default.StatusBarState = menuStatusbarState.Checked;
            Properties.Settings.Default.Save();
        }

        private void menuToolbarStatus_CheckStateChanged(object sender, EventArgs e)
        {
            toolBar.Visible = menuToolbarStatus.Checked;
            Properties.Settings.Default.ToolBarState = menuToolbarStatus.Checked;
            Properties.Settings.Default.Save();
        }

        private void detailsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            groupDetails.Visible = menuDetailsState.Checked;
            Properties.Settings.Default.DetailsState = menuDetailsState.Checked;
            Properties.Settings.Default.Save();
        }

        private void newgroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void newPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPC();
        }

        private void menuLaunchSCCM_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.CcmViewerPath);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuProperties_Click(object sender, EventArgs e)
        {
            EditNode();
        }

        private void menuDeleteNode_Click(object sender, EventArgs e)
        {
            deleteNodeToolStripMenuItem.PerformClick();
        }

        private void menuOptions_Click(object sender, EventArgs e)
        {
            buttonOptions.PerformClick();
        }

        private void menuImportPCList_Click(object sender, EventArgs e)
        {
            buttonOpenList.PerformClick();
        }

        private void menuExportPCList_Click(object sender, EventArgs e)
        {
            buttonSaveList.PerformClick();
        }
    }
}
