/*
 * ����GTK�������������ԭ��C#�ؼ�winform����Ŀ�ƽ̨���������
 * ʹ�ñ����GTKSystem.Windows.Forms����Microsoft.WindowsDesktop.App.WindowsForms��һ�α��룬��ƽ̨windows��linux��macos����
 * ����֧��438865652@qq.com��https://gitee.com/easywebfactory, https://github.com/easywebfactory, https://www.cnblogs.com/easywebfactory
 * author:chenhongjin
 */
using GLib;
using Gtk;
using GTKSystem.Windows.Forms.GTKControls.ControlBase;
using Pango;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    [DesignerCategory("Component")]
	[DefaultEvent("SelectedIndexChanged")]
	[DefaultProperty("Items")]
	[DefaultBindingProperty("SelectedValue")]
	public partial class ListBox : ListControl
    {
        protected Gtk.Viewport viewport = new Gtk.Viewport();
        public override object GtkControl => viewport;
        public readonly ListBoxBase self = new ListBoxBase();
        public override IGtkPainter IPainter { get => self; }
        protected override void UpdateStyle()
        {
            if(self.IsMapped) 
                SetStyle(self);
        }

        private ControlBindingsCollection _collect;
        private ObjectCollection _items;

        public ListBox():base()
		{
            self.Halign = Gtk.Align.Fill;
            self.Valign = Gtk.Align.Fill;
            self.Hexpand = true;
            self.Vexpand = true;
            Gtk.ScrolledWindow scrolledWindow = new Gtk.ScrolledWindow();
            scrolledWindow.Add(self);
            viewport.BorderWidth = 1;
            viewport.ShadowType = ShadowType.None;
            viewport.Child = scrolledWindow;

            _collect = new ControlBindingsCollection(this);
            _items = new ObjectCollection(this);
            self.Realized += Self_Realized;
            self.SelectedRowsChanged += ListBox_SelectedRowsChanged;
        }
        private void ListBox_SelectedRowsChanged(object sender, EventArgs e)
        {
            if (self.IsVisible)
            {
                ((EventHandler)Events["SelectedIndexChanged"])?.Invoke(this, e);
                ((EventHandler)Events["SelectedValueChanged"])?.Invoke(this, e);
                ((EventHandler)Events["SelectedItemChanged"])?.Invoke(this, e);
            }
        }

        private void Self_Realized(object sender, EventArgs e)
        {
            SetStyle(self);
            OnSetDataSource();
            foreach (Binding binding in DataBindings)
                self.AddNotification(binding.PropertyName, propertyNotity);
        }
        private void propertyNotity(object o, NotifyArgs args)
        {
            Binding binding = DataBindings[args.Property];
            binding.WriteValue();
        }
        #region listcontrol
        private object _DataSource;
        public override object DataSource
        {
            get => _DataSource;
            set {
                _DataSource = value;
                if (self.IsVisible)
                {
                    OnSetDataSource();
                }
            }
        }
        private void OnSetDataSource()
        {
            if (_DataSource != null)
            {
                if (_DataSource is IListSource listSource)
                {
                    IEnumerator list = listSource.GetList().GetEnumerator();
                    SetDataSource(list);
                }
                else if (_DataSource is IEnumerable list1)
                {
                    SetDataSource(list1.GetEnumerator());
                }
            }
        }
        private void SetDataSource(IEnumerator enumerator)
        {
            _items.Clear();
            if (enumerator != null)
            {
                if (string.IsNullOrWhiteSpace(DisplayMember))
                {
                    while (enumerator.MoveNext())
                    {
                        var o = enumerator.Current;
                        if (o is DataRowView row)
                            _items.Add(row[0]);
                        else
                            _items.Add(enumerator.Current);
                    }
                }
                else
                {
                    while (enumerator.MoveNext())
                    {
                        var o = enumerator.Current;
                        if (o is DataRowView row)
                            _items.Add(row[DisplayMember]);
                        else
                            _items.Add(o.GetType().GetProperty(DisplayMember)?.GetValue(o));
                    }
                }
            }
        }

        public override int SelectedIndex
        {
            get => self.SelectedRow == null ? -1 : self.SelectedRow.Index; set => SelectedItems.SetSelected(value, true);
        }

        [DefaultValue(null)]
        [Browsable(false)]
        public override object SelectedValue
        {
            get
            {
                int index = SelectedIndex;
                return index == -1 ? null : _items[SelectedIndex];
            }
            set
            {
                ClearSelected();
                int index = _items.IndexOf(value);
                SelectedItems.SetSelected(index, true);
            }
        }

        [Browsable(false)]
        [Bindable(true)]
        public object SelectedItem
        {
            get
            {
                int index = SelectedIndex;
                return index == -1 ? null : _items[SelectedIndex];
            }
            set
            {
                ClearSelected();
                int index = _items.IndexOf(value);
                SelectedItems.SetSelected(index, true);
            }
        }
        public override string GetItemText(object item)
        {
            if(item is ItemArray.Entry entry)
            {
                return entry.Item?.ToString();
            }
            return item?.ToString();
        }
        protected void NativeInsert(int index, object item)
        {
            Gtk.ListBoxRow row = new Gtk.ListBoxRow();
            row.HeightRequest = ItemHeight > 0 ? ItemHeight : DefaultItemHeight;
            row.Add(new Gtk.Label(item.ToString()) { Valign = Align.Center, Halign = Align.Start, Expand = true });
            self.Insert(row, index);
            if (self.IsVisible && !IsUpdateing)
            {
                self.ShowAll();
            }
        }
        protected void NativeAdd(object item)
        {
            Gtk.ListBoxRow row = new Gtk.ListBoxRow();
            row.HeightRequest = ItemHeight > 0 ? ItemHeight : DefaultItemHeight;
            row.Add(new Gtk.Label(item.ToString()) { Valign = Align.Center, Halign = Align.Start, Expand = true });
            self.Add(row);
            if (self.IsVisible && !IsUpdateing)
            {
                self.ShowAll();
            }
        }
        protected void NativeClear()
        {
            int count = self.Children.Length;
            while (count > 0)
            {
                self.Remove(self.GetRowAtIndex(count - 1));
                count--;
                //System.Threading.Thread.Sleep(3);
            }
        }
        protected void NativeRemoveAt(int index)
        {
            self.Remove(self.GetRowAtIndex(index));
        }
        protected string NativeGetItemText(int index)
        {
            Gtk.Label row = self.GetRowAtIndex(index).Child as Gtk.Label;
            return row?.Text;
        }
        protected void OnSelectedIndexChanged(EventArgs e) {
            if (self.SelectedRow != null)
                self.SelectRow(self.SelectedRow);
        }
        #endregion
        public override ControlBindingsCollection DataBindings { get => _collect; }
        internal bool ShowCheckBox { get; set; }
        internal bool ShowImage { get; set; }

        public const int NoMatches = -1;

		public const int DefaultItemHeight = 13;

        [DefaultValue(BorderStyle.Fixed3D)]
		[DispId(-504)]
		public override BorderStyle BorderStyle
        {
            get; set;
        }

        [Localizable(true)]
		[DefaultValue(0)]
		public int ColumnWidth
        {
            get; set;
        }

        [DefaultValue(false)]
		[Browsable(false)]
		public bool UseCustomTabOffsets
        {
            get; set;
        }

        [DefaultValue(DrawMode.Normal)]
		public virtual DrawMode DrawMode
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

        [DefaultValue(0)]
		[Localizable(true)]
		public int HorizontalExtent
        {
            get; set;
        }

        [DefaultValue(false)]
		[Localizable(true)]
		public bool HorizontalScrollbar
        {
            get; set;
        }

        [DefaultValue(true)]
		[Localizable(true)]
		public bool IntegralHeight
        {
            get; set;
        }

        [Localizable(true)]
		public virtual int ItemHeight
        {
            get; set;
        }

		[Localizable(true)]
		public ObjectCollection Items
        {
            get => _items;
        }

        [DefaultValue(false)]
		public bool MultiColumn
        {
            get; set;
        }

        [Browsable(false)]
		public int PreferredHeight
        {
            get; 
        }

        [DefaultValue(false)]
		[Localizable(true)]
		public bool ScrollAlwaysVisible
        {
            get; set;
        }

        [Browsable(false)]
		public SelectedIndexCollection SelectedIndices
        {
            get {
                SelectedIndexCollection indexs = new SelectedIndexCollection(this);
                return indexs;
            }
        }

        [Browsable(false)]
        public SelectedObjectCollection SelectedItems
        {
            get
            {
                SelectedObjectCollection indexs = new SelectedObjectCollection(this);
                return indexs;
            }
        }
        public SelectionMode _SelectionMode;
        [DefaultValue(SelectionMode.One)]
		public virtual SelectionMode SelectionMode
        {
            get {
                return _SelectionMode;
            }
            set {
                if (value == SelectionMode.None)
                {
                    self.SelectionMode = Gtk.SelectionMode.None;
                }
                else if (value == SelectionMode.One)
                {
                    self.SelectionMode = Gtk.SelectionMode.Single;
                }
                else if (value == SelectionMode.MultiSimple)
                {
                    self.SelectionMode = Gtk.SelectionMode.Multiple;
                }
                else if (value == SelectionMode.MultiExtended)
                {
                    self.SelectionMode = Gtk.SelectionMode.Multiple;
                }
            }
        }
        private void CheckNoDataSource()
        {
            //if (DataSource != null)
            //{
            //    throw new ArgumentException("SR.DataSourceLocksItems");
            //}
        }
        private bool _sorted;
        [DefaultValue(false)]
		public bool Sorted
        {
            get => _sorted; set => _sorted = value;
        }

        [Browsable(false)]
		public override string Text
        {
            get; set;
        }

		public int TopIndex
        {
            get; set;
        }

        [DefaultValue(true)]
		public bool UseTabStops
        {
            get; set;
        }

		public IntegerCollection CustomTabOffsets
        {
            get; 
        }

		public new Padding Padding
		{
			get;set;
		}
        public void ClearSelected()
        {
            self.UnselectAll();
        }
        internal bool IsUpdateing = false;
        public void BeginUpdate()
		{
            IsUpdateing = true;
        }

		public void EndUpdate()
		{
            IsUpdateing = false;
            self.ShowAll();
        }

		public int FindString(string s)
		{
			throw null;
		}

		public int FindString(string s, int startIndex)
		{
			throw null;
		}

		public int FindStringExact(string s)
		{
			throw null;
		}

		public int FindStringExact(string s, int startIndex)
		{
			throw null;
		}

		public int GetItemHeight(int index)
		{
			throw null;
		}

		public Drawing.Rectangle GetItemRectangle(int index)
		{
			throw null;
		}
		public bool GetSelected(int index)
		{
            return self.GetRowAtIndex(index).IsSelected;
        }

		public int IndexFromPoint(Drawing.Point p)
		{
			throw null;
		}

		public int IndexFromPoint(int x, int y)
		{
			throw null;
		}

		public override void Refresh()
		{
			self.ShowAll();
		}

		public override void ResetBackColor()
		{
			
		}

		public override void ResetForeColor()
		{
			
		}

		public void SetSelected(int index, bool value)
		{
            if (value == true)
                self.SelectRow(self.GetRowAtIndex(index));
            else
                self.UnselectRow(self.GetRowAtIndex(index));
        }
        public class ListBoxItem: Gtk.Label
        {
            public ListBoxItem() { 
               base.Xalign = 0;
            }
            public object DisplayText { get { return base.Text; } set { base.Text = value?.ToString(); } }
            public object ItemValue { get; set; }
            public object CheckValue { get; set; }

            public override string ToString()
            {
                return DisplayText?.ToString();
            }
        }
    }
}
