using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SCCMAddrbook
{

    class Controller
    {
        //private string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\SCCMAddrBook\";
        private string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\SCCMAddrBook\";

        /// <summary>
        /// Метод сохраняет дерево из TreeView в XML файл
        /// </summary>
        /// <param name="Nodes">Коллекция веток дерева</param>
        public void SaveTree(ItemCollection Nodes, string fileName)
        {
            List<ListNode> list = new List<ListNode>();
            FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Nodes.Cast<object>().ToArray());
            //Открываем на запись новый XML файл
            //TextWriter fileXml = new StreamWriter(fileName);
            ////Инстанцируем сериализатор
            //XmlSerializer xml = new XmlSerializer(typeof(List<ListNode>));
            ////Собственно сериализация
            //try
            //{
            //    xml.Serialize(fileXml, list);
            //}
            //catch (System.Runtime.Serialization.SerializationException e)
            //{
            //    MessageBox.Show(e.Message);
            //}
            //fileXml.Close();
        }


        public void SaveData(TreeView tree)
        {
            XElement xml = new XElement("PCList");
            xml = tree.DataContext as XElement;
            xml.Save("Test.xml");
        }

    }
}
