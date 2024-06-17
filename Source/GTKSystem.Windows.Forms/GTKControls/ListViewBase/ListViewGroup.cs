
using Gtk;
//using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;

namespace System.Windows.Forms
{
	public sealed class ListViewGroup : ISerializable
	{
        public readonly string SerialGuid = Guid.NewGuid().ToString();
        public static readonly string defaultListViewGroupKey = "00000defaultListViewGroup";
        ListView.ListViewItemCollection _items;

        public static ListViewGroup GetDefaultListViewGroup() {
            ListViewGroup defaultGroup = new ListViewGroup("default", HorizontalAlignment.Left);
            defaultGroup.Header = "default";
            defaultGroup.Name = ListViewGroup.defaultListViewGroupKey;
            defaultGroup.Subtitle = "";
            return defaultGroup;
        }
        public ListViewGroup() : this("", "")
        {
        }

        public ListViewGroup(string key, string headerText)
        {
            this.Name = string.IsNullOrWhiteSpace(key) ? headerText : key;
            this.Header = headerText;
        }

        public ListViewGroup(string header) : this(header, header)
        {

        }

        public ListViewGroup(string header, HorizontalAlignment headerAlignment) : this(header, header)
        {
			this.HeaderAlignment = headerAlignment;

        }
        internal readonly Gtk.FlowBox FlowBox = new Gtk.FlowBox() { Orientation = Gtk.Orientation.Horizontal, Name = Guid.NewGuid().ToString() };
        public string Header
		{
            get;
            set;
        }

		public HorizontalAlignment HeaderAlignment
		{
            get;
            set;
        }

		public string Footer
		{
            get;
            set;
        }

		
		
		public HorizontalAlignment FooterAlignment
		{
            get;
            set;
        }
		 
		
		public ListViewGroupCollapsedState CollapsedState
		{
            get;
            set;
        }

		
		
		public string Subtitle
		{
            get;
            set;
        }

		
		
		public string TaskLink
		{
            get;
            set;
        }
 
		public int TitleImageIndex
		{
            get;
            set;
        }
 
		public string TitleImageKey
		{
            get;
            set;
        }
		 
		public ListView.ListViewItemCollection Items
		{
			get
			{
                ListView.ListViewItemCollection coll = new ListView.ListViewItemCollection(ListView);
                var all = ListView.Items.FindAll(m => m.Group.SerialGuid == this.SerialGuid);
                coll.AddRange(all);
                return coll;
			}
		}
 
		public ListView ListView
		{
			get;
			internal set;
		}

		public string Name
		{
            get;
            set;
        }

		public object Tag
		{
			get;
			set;
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			
		}
	}
}
