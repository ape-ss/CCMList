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
using System.Net.Sockets;

namespace CCMAddrBook
{
    public partial class MainWindow : Form
    {

        //private string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\CCMAddrBook\";
        private string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CCMAddrBook\";
        private string PcAddress;
        private string DomainName;
        public string SelectedDomainName { get; set; }
        public string SelectedIPAddress { get; set; }

        /// <summary>
        /// Метод сохраняет дерево из TreeView в XML файл
        /// </summary>
        /// <param name="Nodes">Коллекция веток дерева</param>
        private void SaveTree(TreeNodeCollection Nodes, string fileName)
        {
            List<ListNode> list = new List<ListNode>();
            // Компонуем список для сериализации
            for (int i = 0; i < mainList.Nodes.Count; i++)
            {
                list.Add(new ListNode(mainList.Nodes[i].Name, mainList.Nodes[i].Text, mainList.Nodes[i].Tag as string, mainList.Nodes[i].Level, mainList.Nodes[i].ImageIndex, mainList.Nodes[i].SelectedImageIndex, (mainList.Nodes[i].Parent == null) ? 0 : mainList.Nodes[i].Parent.Index));
                if (mainList.Nodes[i].Nodes != null)
                {
                    for (int j = 0; j < mainList.Nodes[i].Nodes.Count; j++)
                    {
                        list.Add(new ListNode(mainList.Nodes[i].Nodes[j].Name, mainList.Nodes[i].Nodes[j].Text, mainList.Nodes[i].Nodes[j].Tag as string, mainList.Nodes[i].Nodes[j].Level, mainList.Nodes[i].Nodes[j].ImageIndex, mainList.Nodes[i].Nodes[j].SelectedImageIndex, (mainList.Nodes[i].Nodes[j].Parent == null) ? 0 : mainList.Nodes[i].Nodes[j].Parent.Index));
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
                    tmp.Tag = item.DomainName;
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

        /// <summary>
        /// Конструктор главного окна приложения
        /// </summary>
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

        /// <summary>
        /// Метод добавления узла в дерево рабочих станций
        /// </summary>
        private void AddFolder()
        {
            AddFolderDialog fd = new AddFolderDialog();
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                mainList.Nodes.Add(new TreeNode(fd.FolderName, 4, 5));
            }
        }

        /// <summary>
        /// Метод добавления компьютера в узел дерева рабочих станций
        /// </summary>
        private void AddPC()
        {
            if (mainList.SelectedNode.Level == 0)
            {
                AddPCDialog pcd = new AddPCDialog();
                if (pcd.ShowDialog(this) == DialogResult.OK)
                {
                    TreeNode node = new TreeNode(pcd.FrendlyName, 3, 3);
                    node.Name = pcd.IPAddress;
                    node.Tag = pcd.DomainName;
                    try
                    {
                        mainList.SelectedNode.Nodes.Add(node);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, ResMessages.addFolder, ResMessages.addFolderCaption);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "You can add PC only in folders");
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

        private void SaveListFromTree()
        {
            saveDialog.Filter = "XML Files|*.xml";
            if (saveDialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveTree(mainList.Nodes, saveDialog.FileName);
            }
        }

        private void LoadListToTree()
        {
            openDialog.Filter = "XML Files|*.xml";
            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadTree(mainList.Nodes, openDialog.FileName);
            }
        }

        private void buttonSaveList_Click(object sender, EventArgs e)
        {
            SaveListFromTree();
        }

        private void buttonOpenList_Click(object sender, EventArgs e)
        {
            LoadListToTree();
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
            if (WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default.MainFormLocation = Location;
                Properties.Settings.Default.MainFormSize = Size;
            }
            Properties.Settings.Default.Save();
        }

        private void SetSettings()
        {
            DialogOptions Settings = new DialogOptions();
            Settings.ShowDialog();
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            SetSettings();
        }

        private void mainList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ConnectToPC();
        }

        /// <summary>
        /// Метод, который запускает подключение к удаленному компьютеру
        /// </summary>
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
                AddPCDialog pcd = new AddPCDialog(mainList.SelectedNode.Name, mainList.SelectedNode.Tag as string, mainList.SelectedNode.Text);
                if (pcd.ShowDialog(this) == DialogResult.OK)
                {
                    mainList.SelectedNode.Text = pcd.FrendlyName;
                    mainList.SelectedNode.Name = pcd.IPAddress;
                    mainList.SelectedNode.Tag = new String(pcd.DomainName.ToCharArray());
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
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
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
                    ConnectToPC();
                    break;
            }
        }

        private void mainList_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    EditNode();
                    break;
            }
        }

        /// <summary>
        /// Сразу после выбора нового текущего элемента в списке определяем
        /// доменное имя по IP-адресу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level != 0)
            {
                IP.Text = e.Node.Name;
                SelectedIPAddress = e.Node.Name;
                DNSName.Text = e.Node.Tag.ToString();
                SelectedDomainName = e.Node.Tag.ToString();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EditNode();
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPC();
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
            SetSettings();
        }

        private void menuImportPCList_Click(object sender, EventArgs e)
        {
            LoadListToTree();
        }

        private void menuExportPCList_Click(object sender, EventArgs e)
        {
            SaveListFromTree();
        }

        private void mainList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void mainList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            mainList.SelectedNode = ((TreeView)sender).GetNodeAt(pt);
        }

        private void mainList_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode newNode;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode",false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destNode = ((TreeView)sender).GetNodeAt(pt);
                newNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (destNode.Level == 0)
                {
                    destNode.Nodes.Add((TreeNode)newNode.Clone());
                    destNode.Expand();
                    //Remove Original Node
                    newNode.Remove();
                }
                if (destNode.Level == 1)
                {
                    destNode.Parent.Nodes.Insert(destNode.Index + 1, (TreeNode)newNode.Clone());
                    destNode.Parent.Expand();
                    newNode.Remove();
                }
            }
        }

        private void copyIPAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(IP.Text);
        }

        private void copyDomainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(DNSName.Text);
        }

        private void mainList_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            mainList.SelectedNode = ((TreeView)sender).GetNodeAt(pt);
        }

        private void mainList_DragOver(object sender, DragEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            mainList.SelectedNode = ((TreeView)sender).GetNodeAt(pt);
        }

        private void copyIPAddressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(SelectedIPAddress);
        }

        private void copyDomainNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(SelectedDomainName);
        }
    }
}
