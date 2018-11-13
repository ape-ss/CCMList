using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMAddrBook
{
    [Serializable]
    public class ListNode
    {
        string name;
        string text;
        string domainName;
        int level;
        int imageIndex;
        int selectedImageIndex;
        int index;
        ListNode parent;

        public ListNode()
        {

        }

        public ListNode(string name, string text, string domain, int level, int imageIndex, int selectedImageIndex, int index, ListNode parent = null)
        {
            this.name = name;
            this.text = text;
            this.level = level;
            this.imageIndex = imageIndex;
            this.selectedImageIndex = selectedImageIndex;
            this.index = index;
            this.domainName = domain;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }

        public int SelectedImageIndex
        {
            get { return selectedImageIndex; }
            set { selectedImageIndex = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public ListNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }

    }
}
