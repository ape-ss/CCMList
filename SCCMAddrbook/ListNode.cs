using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SCCMAddrbook
{
    [Serializable]
    [XmlInclude(typeof(System.Windows.Controls.StackPanel))]
    public class ListNode
    {
        string name;
        object header;
        int level;
        int index;
        int parentIndex;

        public ListNode()
        {

        }

        public ListNode(string name, object header, int level, int index, int parentIndex = 0)
        {
            this.name = name;
            this.header = header;
            this.level = level;
            this.index = index;
            this.parentIndex = parentIndex;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Header
        {
            get { return header; }
            set { header = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public int ParentIndex
        {
            get { return parentIndex; }
            set { parentIndex = value; }
        }

    }
}
