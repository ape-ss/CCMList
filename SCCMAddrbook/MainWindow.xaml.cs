using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using Ini.Net;


namespace SCCMAddrbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public XmlDataProvider MainList { get; set; }
        public XmlDataProvider dataProvider { get; private set; }
        private XmlElement dragSource;
        private XmlElement dragTarget;
        TreeViewItem targetItem;
        TreeViewItem sourceItem;
        private IniFile iniFile;

        private string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\SCCMAddrbook\";
        private string exePath = AppDomain.CurrentDomain.BaseDirectory;
        private Point lastPoint;

        public MainWindow()
        {
            InitializeComponent();
            iniFile = new IniFile(exePath + "SCCMAddrbook.ini");
            if (iniFile.ReadBoolean("Window", "SavePosition") == true)
            {
                this.Left = iniFile.ReadDouble("Window","X");
                this.Top = iniFile.ReadDouble("Window", "Y");
            }
            if (iniFile.ReadBoolean("Window", "SaveSize") == true)
            {
                this.Width = iniFile.ReadDouble("Window", "Width");
                this.Height = iniFile.ReadDouble("Window", "Height");
            }
            try
            {
                TbTray.Visibility = (Visibility)iniFile.ReadInteger("Window", "ShowToolbar");
                switch ((Visibility)iniFile.ReadInteger("Window", "ShowToolbar"))
                {
                    case Visibility.Visible:
                        miViewToolbar.IsChecked = true;
                        break;
                    case Visibility.Collapsed:
                        miViewToolbar.IsChecked = false;
                        break;
                }
            }
            catch (Exception)
            {
                TbTray.Visibility = Visibility.Visible;
                miViewToolbar.IsChecked = true;
            }
            try
            {
                gbDetails.Visibility = (Visibility)iniFile.ReadInteger("Window", "ShowFullInfo");
                switch ((Visibility)iniFile.ReadInteger("Window", "ShowFullInfo"))
                {
                    case Visibility.Visible:
                        miViewFullinfo.IsChecked = true;
                        break;
                    case Visibility.Collapsed:
                        miViewFullinfo.IsChecked = false;
                        break;
                }
            }
            catch (Exception)
            {
                gbDetails.Visibility = Visibility.Visible;
                miViewFullinfo.IsChecked = true;
            }
            try
            {
                sbInfo.Visibility = (Visibility)iniFile.ReadInteger("Window", "ShowStatusBar");
                switch ((Visibility)iniFile.ReadInteger("Window", "ShowStatusBar"))
                {
                    case Visibility.Visible:
                        miViewStatusbar.IsChecked = true;
                        break;
                    case Visibility.Collapsed:
                        miViewStatusbar.IsChecked = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                sbInfo.Visibility = Visibility.Visible;
                miViewStatusbar.IsChecked = true;
            }
            MainList = this.FindResource("PCList") as XmlDataProvider;
            if (Directory.Exists(homeDir) == false)
            {
                Directory.CreateDirectory(homeDir);
            }
            if (File.Exists(exePath + "pclist.xml") == true)
            {
                MainList.Source = new Uri(exePath + "pclist.xml");
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmldec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmldec);
                XmlElement root = doc.CreateElement("pclist");
                doc.AppendChild(root);
                doc.Save(exePath + "pclist.xml");
                MainList.Source = new Uri(exePath + "pclist.xml");
            }
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveParams()
        {
            dlgOptions options = new dlgOptions(iniFile);
            options.Owner = this;
            if (options.ShowDialog() == true)
            {
                iniFile.WriteString("Clients", "SccmViewer", options.SCCMPath);
                iniFile.WriteBoolean("Window", "SavePosition", options.SavePosition);
                iniFile.WriteBoolean("Window", "SaveSize", options.SaveSize);
                iniFile.WriteInteger("ControlApp", "AppId", (int)options.RemoteControl);
                //Properties.Settings.Default.Save();
            }
        }

        private void NewGroup()
        {
            dlgAddGroup newGroup = new dlgAddGroup();
            newGroup.Owner = this;
            if (newGroup.ShowDialog() == true)
            {
                XmlElement node = MainList.Document.CreateElement("tvbv");
                node.SetAttribute("name", newGroup.GroupName);
                MainList.Document.DocumentElement.AppendChild(node);
                MainList.Document.Save(MainList.Source.OriginalString);
            }
        }

        private void NewNode()
        {
            XmlElement selection = mainList.SelectedItem as XmlElement;
            if (mainList.SelectedItem != null && selection.Name == "tvbv")
            {
                DlgAddNode newNode = new DlgAddNode();
                newNode.Owner = this;
                if (newNode.ShowDialog() == true)
                {                    
                    TreeViewItem newItem = new TreeViewItem();
                    string tvbv = selection.Attributes["name"].Value;
                    XmlElement pc = MainList.Document.CreateElement("pc");
                    pc.SetAttribute("name", newNode.FriendlyName);
                    pc.SetAttribute("ipaddress", newNode.IpAddress);
                    pc.SetAttribute("domain", newNode.DomainName);
                    MainList.Document.SelectSingleNode("/pclist/tvbv[@name='" + tvbv + "']").AppendChild(pc);
                    MainList.Document.Save(MainList.Source.OriginalString);
                }
            }
            else
            {
                MessageBox.Show(Lang.msgEmptySelection, Lang.msgEmptySelectionTitle);
            }
        }

        private void ConnectTo(XmlElement Pc)
        {
            try
            {
                switch ((RCApps)iniFile.ReadInteger("ControlApp", "AppId"))
                {
                    case RCApps.sccmviewer:
                        Process.Start(iniFile.ReadString("Clients", "SccmViewer"), Pc.GetAttribute("ipaddress"));
                        break;
                    case RCApps.rdp:
                        Process.Start("msra.exe", "/offerra " + Pc.GetAttribute("ipaddress"));
                        break;
                }
                statusLastConnect.Text = Pc.GetAttribute("ipaddress");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void DeleteSelectedNode()
        {
            XmlElement selection = mainList.SelectedItem as XmlElement;
            if (selection.HasChildNodes == false)
            {
                XmlNode parent = selection.ParentNode;
                parent.RemoveChild(selection);
                MainList.Document.Save(MainList.Source.OriginalString);
            }
            else
            {
                MessageBox.Show("Node has child elements!", "Can't delete node!");
            }
        }

        private void EditNode()
        {
            XmlElement selection = mainList.SelectedItem as XmlElement;
            if (selection.Name == "tvbv")
            {
                dlgAddGroup newGroup = new dlgAddGroup(selection.GetAttribute("name"));
                newGroup.Owner = this;
                if (newGroup.ShowDialog() == true)
                {
                    selection.SetAttribute("name", newGroup.GroupName);
                    MainList.Document.Save(MainList.Source.OriginalString);
                }
            }
            else if (selection.Name == "pc")
            {
                DlgAddNode newNode = new DlgAddNode(selection.GetAttribute("ipaddress"),
                    selection.GetAttribute("domain"),
                    selection.GetAttribute("name"));
                newNode.Owner = this;
                if (newNode.ShowDialog() == true)
                {
                    selection.SetAttribute("name", newNode.FriendlyName);
                    selection.SetAttribute("ipaddress", newNode.IpAddress);
                    selection.SetAttribute("domain", newNode.DomainName);
                    MainList.Document.Save(MainList.Source.OriginalString);
                }
            }
        }

        private void ExportPCList()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML Files|*.xml";
            if (saveDialog.ShowDialog() == true)
            {
                MainList.Document.Save(saveDialog.FileName);
            }
        }

        private void ImportPCList()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                MainList.Document = new XmlDocument();
                MainList.Document.Load(openFile.FileName);
                MainList.Document.Save(exePath + "pclist.xml");
                MainList.Refresh();
            }
        }

        private void RunSCCMViewer()
        {
            Process.Start(iniFile.ReadString("Clients", "SccmViewer"));
        }

        private void buttonAddGroup_Click(object sender, RoutedEventArgs e)
        {
            NewGroup();
        }

        private void buttonAddPC_Click(object sender, RoutedEventArgs e)
        {
            NewNode();
        }

        private void buttonExportList_Click(object sender, RoutedEventArgs e)
        {
            ExportPCList();
        }

        private void buttonImportList_Click(object sender, RoutedEventArgs e)
        {
            ImportPCList();
        }

        private void MainList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            XmlElement selection = e.NewValue as XmlElement;
            textDomainName.Text = selection.GetAttribute("domain");
            textIPAddress.Text = selection.GetAttribute("ipaddress");
        }

        private void MiNewGroup_Click(object sender, RoutedEventArgs e)
        {
            NewGroup();
        }

        private void MiNewPC_Click(object sender, RoutedEventArgs e)
        {
            NewNode();
        }

        private void MiDeleteNode_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedNode();
        }

        private void ButtonEditNode_Click(object sender, RoutedEventArgs e)
        {
            EditNode();
        }

        private void MiEditNode_Click(object sender, RoutedEventArgs e)
        {
            EditNode();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            int count = MainList.Document.SelectNodes("/pclist/tvbv/pc").Count;
            statusItems.Text = count.ToString();
        }

        private void MiImportAddressBook_Click(object sender, RoutedEventArgs e)
        {
            ImportPCList();
        }

        private void MiExportAddressBook_Click(object sender, RoutedEventArgs e)
        {
            ExportPCList();
        }

        private void MiOptions_Click(object sender, RoutedEventArgs e)
        {
            SaveParams();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (iniFile.ReadBoolean("Window", "SavePosition") == true && this.WindowState != WindowState.Minimized)
            {
                Point Location = new Point(this.Left, this.Top);
                //Properties.Settings.Default.WindowLocation = Location;
                iniFile.WriteDouble("Window", "X", Location.X);
                iniFile.WriteDouble("Window", "Y", Location.Y);
            }
            if (iniFile.ReadBoolean("Window", "SaveSize") == true && this.WindowState != WindowState.Minimized)
            {
                Size Dims = new Size(this.Width, this.Height);
                //Properties.Settings.Default.WindowSize = Dims;
                iniFile.WriteDouble("Window", "Width", Dims.Width);
                iniFile.WriteDouble("Window", "Height", Dims.Height);
            }
            //Properties.Settings.Default.Save();
        }

        private void ButtonConnectPC_Click(object sender, RoutedEventArgs e)
        {
            ConnectTo(mainList.SelectedItem as XmlElement);
        }

        private void MiConnectToPc_Click(object sender, RoutedEventArgs e)
        {
            ConnectTo(mainList.SelectedItem as XmlElement);
        }

        private void MainList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            XmlElement selected = mainList.SelectedItem as XmlElement;
            if (selected?.Name == "pc")
            {
                ConnectTo(selected);
            }            
        }

        private void MiViewToolbar_Checked(object sender, RoutedEventArgs e)
        {
            TbTray.Visibility = Visibility.Visible;
            //Properties.Settings.Default.ShowToolbar = Visibility.Visible;
            iniFile.WriteInteger("Window", "ShowToolbar", (int)Visibility.Visible);
        }

        private void MiViewToolbar_Unchecked(object sender, RoutedEventArgs e)
        {
            TbTray.Visibility = Visibility.Collapsed;
            //Properties.Settings.Default.ShowToolbar = Visibility.Collapsed;
            iniFile.WriteInteger("Window", "ShowToolbar", (int)Visibility.Collapsed);
        }

        private void MiViewFullinfo_Checked(object sender, RoutedEventArgs e)
        {
            gbDetails.Visibility = Visibility.Visible;
            //Properties.Settings.Default.ShowFullInfo = Visibility.Visible;
            iniFile.WriteInteger("Window", "ShowFullInfo", (int)Visibility.Visible);
        }

        private void MiViewFullinfo_Unchecked(object sender, RoutedEventArgs e)
        {
            gbDetails.Visibility = Visibility.Collapsed;
            //Properties.Settings.Default.ShowFullInfo = Visibility.Collapsed;
            iniFile.WriteInteger("Window", "ShowFullInfo", (int)Visibility.Collapsed);
        }

        private void MiViewStatusbar_Checked(object sender, RoutedEventArgs e)
        {
            sbInfo.Visibility = Visibility.Visible;
            //Properties.Settings.Default.ShowStatusBar = Visibility.Visible;
            iniFile.WriteInteger("Window", "ShowStatusBar", (int)Visibility.Visible);
        }

        private void MiViewStatusbar_Unchecked(object sender, RoutedEventArgs e)
        {
            sbInfo.Visibility = Visibility.Collapsed;
            //Properties.Settings.Default.ShowStatusBar = Visibility.Collapsed;
            iniFile.WriteInteger("Window", "ShowStatusBar", (int)Visibility.Collapsed);
        }

        private void ButtonOptions_Click(object sender, RoutedEventArgs e)
        {
            SaveParams();
        }

        private void MiLaunchSCCMViewer_Click(object sender, RoutedEventArgs e)
        {
            RunSCCMViewer();
        }

        private void MiAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.Owner = this;
            about.ShowDialog();
        }

        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        private void MainList_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        private void CmAddNode_Click(object sender, RoutedEventArgs e)
        {
            NewNode();
        }

        private void CmAddGroup_Click(object sender, RoutedEventArgs e)
        {
            NewGroup();
        }

        private void CmEditNode_Click(object sender, RoutedEventArgs e)
        {
            EditNode();
        }

        private void CmRemoveNode_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedNode();
        }

        private void CmCopyIp_Click(object sender, RoutedEventArgs e)
        {
            XmlElement selected = mainList.SelectedItem as XmlElement;
            Clipboard.Clear();
            Clipboard.SetText(selected.GetAttribute("ipaddress"));
        }

        private void CmDomainName_Click(object sender, RoutedEventArgs e)
        {
            XmlElement selected = mainList.SelectedItem as XmlElement;
            Clipboard.Clear();
            Clipboard.SetText(selected.GetAttribute("domain"));
        }

        #region Drag & Drop

        private void MainList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           lastPoint = e.GetPosition(mainList);
            sourceItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
        }

        private void MainList_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //Если зажата левая кнопка мыши
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    //Определяем текущую позицию
                    Point currentPoint = e.GetPosition(mainList);
                    //Если мышь ушла на достаточное расстояние от исходного элемента
                    if (Math.Abs(currentPoint.X - lastPoint.X) > SystemParameters.MinimumHorizontalDragDistance || 
                        Math.Abs(currentPoint.Y - lastPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                    {
                        //Запоминаем исходный элемент
                        dragSource = mainList.SelectedItem as XmlElement;
                        //Если элемент не пустой
                        if (dragSource != null)
                        {
                            //Выполняем Drag & Drop
                            DragDropEffects dropEffects = DragDrop.DoDragDrop(mainList, mainList.SelectedItem, DragDropEffects.Move);
                            if (dropEffects == DragDropEffects.Move && dragTarget != null)
                            {
                                targetItem.Focus();
                                dragTarget = mainList.SelectedItem as XmlElement;
                                if (dragTarget.Name == "tvbv" && dragSource.Name == "pc") 
                                {
                                    targetItem.IsExpanded = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void MoveItem(XmlElement dragSource, XmlElement dragTarget)
        {
            if (dragTarget.Name == "tvbv" && dragSource.Name == "pc")
            {
                string tvbv = dragTarget.Attributes["name"].Value;
                XmlElement pc = MainList.Document.CreateElement("pc");
                pc.SetAttribute("name", dragSource.GetAttribute("name"));
                pc.SetAttribute("ipaddress", dragSource.GetAttribute("ipaddress"));
                pc.SetAttribute("domain", dragSource.GetAttribute("domain"));
                MainList.Document.SelectSingleNode("/pclist/tvbv[@name='" + tvbv + "']").AppendChild(pc);
                XmlNode parent = dragSource.ParentNode;
                parent.RemoveChild(dragSource);
                MainList.Document.Save(homeDir + "pclist.xml");
            }
            else if (dragTarget.Name == "pc")
            {
                string tvbv = dragTarget.ParentNode.Attributes["name"].Value;
                XmlElement pc = MainList.Document.CreateElement("pc");
                pc.SetAttribute("name", dragSource.GetAttribute("name"));
                pc.SetAttribute("ipaddress", dragSource.GetAttribute("ipaddress"));
                pc.SetAttribute("domain", dragSource.GetAttribute("domain"));
                MainList.Document.SelectSingleNode("/pclist/tvbv[@name='" + tvbv + "']").InsertAfter(pc, dragTarget);
                XmlNode parent = dragSource.ParentNode;
                parent.RemoveChild(dragSource);
                MainList.Document.Save(homeDir + "pclist.xml");
            }
            else if (dragTarget.Name == "tvbv" && dragSource.Name == "tvbv")
            {
                XmlElement src = MainList.Document.CreateElement("tvbv");
                src.SetAttribute("name", dragSource.GetAttribute("name"));
                src.InnerXml = dragSource.InnerXml;
                MainList.Document.SelectSingleNode("/pclist").InsertAfter(src, dragTarget);
                XmlNode parent = dragSource.ParentNode;
                parent.RemoveChild(dragSource);
                MainList.Document.Save(homeDir + "pclist.xml");
            }
        }

        private void MainList_Drop(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
            if (targetItem != null)
            {
                e.Effects = DragDropEffects.None;
                MoveItem(dragSource, dragTarget);
                dragTarget = mainList.SelectedItem as XmlElement;
                if (dragTarget.Name == "tvbv" && dragSource.Name == "pc")
                {
                    targetItem.IsExpanded = true;
                }
                targetItem.Focus();
                targetItem.IsExpanded = true;
                targetItem = null;
            }

        }

        private void MainList_DragOver(object sender, DragEventArgs e)
        {
            Point currentPoint = e.GetPosition(mainList);
            if (Math.Abs(currentPoint.X - lastPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(currentPoint.Y - lastPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                targetItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
                if (targetItem != null)
                {
                    targetItem.Focus();
                    dragTarget = mainList.SelectedItem as XmlElement;
                    if(dragTarget.Name == "tvbv" && dragSource.Name == "pc")
                    {
                        targetItem.IsExpanded = true;
                    }
                }
            }

        }

        #endregion

        private void TmShowHide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TmExitApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConnectSccm_Click(object sender, RoutedEventArgs e)
        {
            XmlElement Pc = mainList.SelectedItem as XmlElement;
            Process.Start(iniFile.ReadString("Clients", "SccmViewer"), Pc.GetAttribute("ipaddress"));
            //Process.Start(Properties.Settings.Default.SccmPath, Pc.GetAttribute("ipaddress"));
        }

        private void ConnectRA_Click(object sender, RoutedEventArgs e)
        {
            XmlElement Pc = mainList.SelectedItem as XmlElement;
            Process.Start("msra.exe", "/offerra " + Pc.GetAttribute("ipaddress"));
        }
    }
}
;