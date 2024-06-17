﻿
using Gtk;
using GTKSystem.Windows.Forms.GTKControls.ControlBase;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.Design;

namespace System.Windows.Forms
{
    /// <summary>
    /// Control class with the same Winforms api 
    /// </summary>
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Designer(typeof(ControlDesigner))]
    [ToolboxItemFilter("System.Windows.Forms")]
    public partial class Control : Component, IControl, ISynchronizeInvoke, IComponent, IDisposable, ISupportInitialize
    {
        private Gtk.Application app = Application.Init();
        public string unique_key { get; protected set; }
        public virtual object GtkControl { get; set; }
        public virtual Gtk.Widget Widget     => GtkControl as Gtk.Widget;
        public virtual IGtkPainter IPainter  => GtkControl as IGtkPainter;

        public Control()
        {
            this.unique_key = Guid.NewGuid().ToString().ToLower();

            if (this.Widget != null)
            {
                this.Dock = DockStyle.None;
                this.Widget.StyleContext.AddClass("DefaultThemeStyle");
                Gtk.Widget widget = this.Widget;

                widget.ButtonPressEvent += Widget_ButtonPressEvent;
                widget.ButtonReleaseEvent += Widget_ButtonReleaseEvent;
                widget.EnterNotifyEvent += Widget_EnterNotifyEvent;
                widget.MotionNotifyEvent += Widget_MotionNotifyEvent;
                widget.LeaveNotifyEvent += Widget_LeaveNotifyEvent;
                widget.FocusInEvent += Widget_FocusInEvent;
                widget.FocusOutEvent += Widget_FocusOutEvent;
                widget.KeyPressEvent += Widget_KeyPressEvent;
                widget.KeyReleaseEvent += Widget_KeyReleaseEvent;
                widget.Realized += Widget_Realized;
            }
        }

        #region events

        private void Widget_Realized(object sender, EventArgs e)
        {
            SetStyle((Gtk.Widget)sender);
            if (Load != null)
                Load(this, e);
        }

        private void Widget_ButtonPressEvent(object o, ButtonPressEventArgs args)
        {
            if (MouseDown != null)
            {
                MouseButtons result = MouseButtons.None;
                if (args.Event.Button == 1)
                    result = MouseButtons.Left;
                else if (args.Event.Button == 3)
                    result = MouseButtons.Right;
                else if (args.Event.Button == 2)
                    result = MouseButtons.Middle;
                MouseDown(this, new MouseEventArgs(result, 1, (int)args.Event.X, (int)args.Event.Y, 0));
            }
        }
        private void Widget_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
        {
            if (MouseUp != null)
            {
                MouseButtons result = MouseButtons.None;
                if (args.Event.Button == 1)
                    result = MouseButtons.Left;
                else if (args.Event.Button == 3)
                    result = MouseButtons.Right;
                else if (args.Event.Button == 2)
                    result = MouseButtons.Middle;

                MouseUp(this, new MouseEventArgs(result, 1, (int)args.Event.X, (int)args.Event.Y, 0));
            }
        }
        private void Widget_FocusInEvent(object o, FocusInEventArgs args)
        {
            if (GotFocus != null)
                GotFocus(this, args);
        }
        private void Widget_FocusOutEvent(object o, FocusOutEventArgs args)
        {
            if (LostFocus != null)
                LostFocus(this, args);

            if (Validating != null)
                Validating(this, cancelEventArgs);
            if (Validated != null && cancelEventArgs.Cancel == false)
                Validated(this, cancelEventArgs);
        }
        private void Widget_EnterNotifyEvent(object o, EnterNotifyEventArgs args)
        {
            if (Enter != null)
                Enter(this, args);
            if (MouseEnter != null)
                MouseEnter(this, args);

            if (MouseHover != null)
                MouseHover(this, args);
        }
        private void Widget_MotionNotifyEvent(object o, MotionNotifyEventArgs args)
        {
            if (Move != null)
                Move(this, args);
            if (MouseMove != null)
                MouseMove(this, new MouseEventArgs(MouseButtons.None, 1, (int)args.Event.X, (int)args.Event.Y, 0));

        }
        private void Widget_LeaveNotifyEvent(object o, LeaveNotifyEventArgs args)
        {
            if (Leave != null)
                Leave(this, args);
            if (MouseLeave != null)
                MouseLeave(this, args);
        }
        private void Widget_KeyPressEvent(object o, Gtk.KeyPressEventArgs args)
        {
            if (KeyDown != null)
            {
                if (args.Event is Gdk.EventKey eventkey)
                {
                    Keys keys = (Keys)eventkey.HardwareKeycode;
                    KeyDown(this, new KeyEventArgs(keys));
                }
            }
        }
        private void Widget_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
        {
            if (KeyUp != null)
            {
                Keys keys = (Keys)args.Event.HardwareKeycode;
                KeyUp(this, new KeyEventArgs(keys));
            }
            if (KeyPress != null)
            {
                Keys keys = (Keys)args.Event.HardwareKeycode;
                KeyPress(this, new KeyPressEventArgs(Convert.ToChar(keys)));
            }
        }

        #endregion

        //===================

        protected virtual void UpdateStyle()
        {
            if (this.Widget != null && this.Widget.IsMapped)
                SetStyle(this.Widget);
        }
        protected virtual void UpdateBackgroundStyle()
        {
            if (this.Widget != null && this.Widget.IsMapped)
                IPainter.Painter.OnAddClass();
        }
        protected virtual void SetStyle(Gtk.Widget widget)
        {
            StringBuilder style = new StringBuilder();
            if (widget is Gtk.Image) { }
            else
            {
                if (this.Image != null && this.Image.PixbufData != null)
                {
                    string imguri = $"Resources/{widget.WidgetPath.IterGetName(0)}${widget.Name}_img.png";
                    if (!File.Exists(imguri))
                    {
                        Gdk.Pixbuf imagepixbuf = new Gdk.Pixbuf(this.Image.PixbufData);
                        imagepixbuf.Save(imguri, "png");
                    }
                    style.AppendFormat("background:url(\"{0}\")", imguri);
                    style.Append(" no-repeat");
                    if (this.ImageAlign == ContentAlignment.TopLeft)
                    {
                        style.Append(" top left");
                    }
                    else if (this.ImageAlign == ContentAlignment.TopCenter)
                    {
                        style.Append(" top center");
                    }
                    else if (this.ImageAlign == ContentAlignment.TopRight)
                    {
                        style.Append(" top right");
                    }
                    else if (this.ImageAlign == ContentAlignment.MiddleLeft)
                    {
                        style.Append(" center left");
                    }
                    else if (this.ImageAlign == ContentAlignment.MiddleCenter)
                    {
                        style.Append(" center center");
                    }
                    else if (this.ImageAlign == ContentAlignment.MiddleRight)
                    {
                        style.Append(" center right");
                    }
                    else if (this.ImageAlign == ContentAlignment.BottomLeft)
                    {
                        style.Append(" bottom left");
                    }
                    else if (this.ImageAlign == ContentAlignment.BottomCenter)
                    {
                        style.Append(" bottom center");
                    }
                    else if (this.ImageAlign == ContentAlignment.BottomRight)
                    {
                        style.Append(" bottom right");
                    }
                    else
                    {
                        style.Append(" center center");
                    }

                    if (this.BackgroundImage != null && this.BackgroundImage.PixbufData != null)
                    {
                        string bgimguri = $"Resources/{widget.WidgetPath.IterGetName(0)}${widget.Name}_bg.png";
                        if (!File.Exists(bgimguri))
                        {
                            Gdk.Pixbuf bgpixbuf = new Gdk.Pixbuf(this.BackgroundImage.PixbufData);
                            bgpixbuf.Save(bgimguri, "png");
                        }

                        style.AppendFormat(",url(\"Resources/{0}_bg.png\") repeat", widget.Name);
                    }
                    style.Append(";");
                    style.Append("background-origin: padding-box;");
                    style.Append("background-clip: padding-box;");
                }
                else if (this.BackgroundImage != null && this.BackgroundImage.PixbufData != null)
                {
                    Gdk.Pixbuf bgpixbuf = new Gdk.Pixbuf(this.BackgroundImage.PixbufData);
                    string bgimguri = $"Resources/{widget.WidgetPath.IterGetName(0)}${widget.Name}_bg.png";
                    if (!File.Exists(bgimguri))
                    {
                        bgpixbuf.Save(bgimguri, "png");
                    }
                    style.AppendFormat("background-image:url(\"{0}\");", bgimguri);
                    if (this.BackgroundImageLayout == ImageLayout.Tile)
                    {
                        style.Append("background-repeat:repeat;");
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Zoom)
                    {
                        style.Append("background-repeat:no-repeat;");
                        style.Append("background-size: contain;");
                        style.Append("background-position:center;");
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Stretch)
                    {
                        style.Append("background-repeat:no-repeat;");
                        style.Append("background-size: cover;");
                        style.Append("background-position:center;");
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Center)
                    {
                        style.Append("background-repeat:no-repeat;");
                        if (widget.HeightRequest < bgpixbuf.Height)
                            style.Append("background-position:top,center;");
                        else
                            style.Append("background-position:center,center;");

                    }
                    else
                    {
                        style.Append("background-repeat:no-repeat;");
                    }
                    style.Append("background-origin: padding-box;");
                    style.Append("background-clip: padding-box;");
                    if (this.BackColor.Name != "0")
                    {
                        Color backColor = this.BackColor;
                        string color = $"rgba({backColor.R},{backColor.G},{backColor.B},{backColor.A})";
                        style.AppendFormat("background-color:{0};", color);
                    }
                }
                else if (this.BackColor.Name != "0")
                {
                    Color backColor = this.BackColor;
                    string color = $"rgba({backColor.R},{backColor.G},{backColor.B},{backColor.A})";
                    style.AppendFormat("background-color:{0};background:{0};", color);
                }
                
                if (this.ForeColor.Name != "0")
                {
                    Color foreColor = this.ForeColor;
                    string color = $"rgba({foreColor.R},{foreColor.G},{foreColor.B},{foreColor.A})";
                    style.AppendFormat("color:{0};", color);
                }
                if (this.Font != null)
                {
                    Font font = this.Font;
                    if (font.Unit == GraphicsUnit.Pixel)
                        style.AppendFormat("font-size:{0}px;", font.Size);
                    else if (font.Unit == GraphicsUnit.Inch)
                        style.AppendFormat("font-size:{0}in;", font.Size);
                    else if (font.Unit == GraphicsUnit.Point)
                        style.AppendFormat("font-size:{0}pt;", font.Size);
                    else if (font.Unit == GraphicsUnit.Millimeter)
                        style.AppendFormat("font-size:{0}mm;", font.Size);
                    else if (font.Unit == GraphicsUnit.Document)
                        style.AppendFormat("font-size:{0}cm;", font.Size);
                    else if (font.Unit == GraphicsUnit.Display)
                        style.AppendFormat("font-size:{0}pc;", font.Size);
                    else
                        style.AppendFormat("font-size:{0}pt;", font.Size);

                    if (string.IsNullOrWhiteSpace(font.FontFamily.Name) == false)
                    {
                        style.AppendFormat("font-family:\"{0}\";", font.FontFamily.Name);
                    }

                    string[] fontstyle = font.Style.ToString().ToLower().Split(new char[] { ',', ' ' });
                    foreach (string sty in fontstyle)
                    {
                        if (sty == "bold")
                        {
                            style.Append("font-weight:bold;");
                        }
                        else if (sty == "italic")
                        {
                            style.Append("font-style:italic;");
                        }
                        else if (sty == "underline")
                        {
                            style.Append("text-decoration:underline;");
                        }
                        else if (sty == "strikeout")
                        {
                            style.Append("text-decoration:line-through;");
                        }
                    }
                }
                if (style.Length > 10)
                {
                    string styleClassName = $"s{unique_key}";
                    StringBuilder css = new StringBuilder();
                    css.AppendLine($".{styleClassName}{{{style.ToString()}}}");
                    if (widget is Gtk.TextView)
                    {
                        css.AppendLine($".{styleClassName} text{{{style.ToString()}}}");
                        css.AppendLine($".{styleClassName} .view{{{style.ToString()}}}");
                    }
                    CssProvider provider = new CssProvider();
                    if (provider.LoadFromData(css.ToString()))
                    {
                        if (widget.StyleContext.HasClass(styleClassName))
                            widget.StyleContext.RemoveProvider(provider);
                        widget.StyleContext.AddProvider(provider, 900);
                        widget.StyleContext.AddClass(styleClassName);
                    }
                }
            }
        }
        protected virtual void SetStyle(ControlStyles styles, bool value)
        {
        }

        #region 背景
        public virtual System.Drawing.Image Image { get; set; }
        public virtual System.Drawing.ContentAlignment ImageAlign { get; set; }

        public virtual bool UseVisualStyleBackColor { get; set; } = true;
        public virtual Color VisualStyleBackColor { get; }
        public virtual ImageLayout BackgroundImageLayout { get => IPainter == null ? ImageLayout.None : IPainter.Painter.BackgroundImageLayout; set { if (IPainter != null) { IPainter.Painter.BackgroundImageLayout = value; } } }
        public virtual Drawing.Image BackgroundImage { get => IPainter == null ? null : IPainter.Painter.BackgroundImage; set { if (IPainter != null) { IPainter.Painter.BackgroundImage = value; Refresh(); } } }
        public virtual Color BackColor
        {
            get
            {
                if (IPainter.Painter.BackColor.HasValue)
                    return IPainter.Painter.BackColor.Value;
                //else if (UseVisualStyleBackColor)
                //    return Color.FromName("0");
                //else
                //    return Color.Transparent; 
                else
                    return Color.FromName("0");
            }
            set {
                IPainter.Painter.BackColor = value;
                IPainter.Painter.OnAddClass();
                UpdateStyle();
                Refresh();
            }
        }
        public virtual event PaintEventHandler Paint
        {
            add { IPainter.Painter.Paint += value; }
            remove { IPainter.Painter.Paint -= value; }
        }
        #endregion
        public virtual AccessibleObject AccessibilityObject { get; }

        public virtual string AccessibleDefaultActionDescription { get; set; }
        public virtual string AccessibleDescription { get; set; }
        public virtual string AccessibleName { get; set; }
        public virtual AccessibleRole AccessibleRole { get; set; }
        public virtual bool AllowDrop { get; set; }
        public virtual AnchorStyles Anchor { get; set; }
        public virtual Point AutoScrollOffset { get; set; }
        public virtual bool AutoSize { get; set; }
        public virtual BindingContext BindingContext { get; set; }

        public virtual int Bottom { get; }

        public virtual Rectangle Bounds { get; set; }

        public virtual bool CanFocus { get { return Widget.CanFocus; } }

        public virtual bool CanSelect { get; }

        public virtual bool Capture { get; set; }
        public virtual bool CausesValidation { get; set; }
        public virtual string CompanyName { get; }

        public virtual bool ContainsFocus { get; }

        public virtual ContextMenuStrip ContextMenuStrip { get; set; }

        public virtual ControlCollection Controls { get; }

        public virtual bool Created => _Created;
        internal bool _Created;

        public virtual Cursor Cursor { get; set; }

        public virtual ControlBindingsCollection DataBindings { get; }

        public virtual int DeviceDpi { get; }

        public virtual Rectangle DisplayRectangle { get; }

        public virtual bool Disposing { get; }

        public virtual DockStyle Dock
        {
            get
            {
                if (Enum.TryParse(Widget.Data["Dock"].ToString(), false, out DockStyle result))
                    return result;
                else
                    return DockStyle.None;
            }
            set
            {
                Widget.Data["Dock"] = value.ToString();
            }
        }
        public virtual bool Enabled { get { return Widget.Sensitive; } set { Widget.Sensitive = value; } }

        public virtual bool Focused { get { return Widget.IsFocus; } }
        private Font _Font;
        public virtual Font Font {
            get
            {
                if (_Font == null)
                {
                    var fontdes = Widget.PangoContext.FontDescription;
                    int size = Convert.ToInt32(fontdes.Size / Pango.Scale.PangoScale);
                    return new Drawing.Font(new Drawing.FontFamily(fontdes.Family), size);
                }
                else
                    return _Font;
            }
            set { _Font = value; UpdateStyle(); }
        }
        private Color _ForeColor;
        public virtual Color ForeColor { 
            get { return _ForeColor; }
            set { _ForeColor = value; UpdateStyle(); } 
        }

        public virtual bool HasChildren { get; }

        public virtual int Height { get { return Widget.HeightRequest; } set { Widget.HeightRequest = value; } }
        public virtual ImeMode ImeMode { get; set; }

        public virtual bool InvokeRequired { get; }

        public virtual bool IsAccessible { get; set; }

        public virtual bool IsDisposed { get; }

        public virtual bool IsHandleCreated { get => true; }

        public virtual bool IsMirrored { get; }

        public virtual LayoutEngine LayoutEngine { get; }

        public virtual int Left { get; set; }

        public virtual Point Location
        {
            get
            {
                return new Point(Left, Top);
            }
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }
        //public virtual Padding Margin { get; set; }
        //public virtual Size MaximumSize { get; set; }
        //public virtual Size MinimumSize { get; set; }
        public virtual string Name { get { return Widget.Name; } set { Widget.Name = value; } }
        public virtual Padding Padding { get; set; }
        public virtual Control Parent { get; set; }
        public virtual Size PreferredSize { get; }
        public virtual string ProductName { get; }
        public virtual string ProductVersion { get; }
        public virtual bool RecreatingHandle { get; }
        public virtual Drawing.Region Region { get; set; }
        public virtual int Right { get; }

        public virtual RightToLeft RightToLeft { get; set; }
        //public override ISite Site { get => base.Site; set => base.Site = value; }
        public virtual Size Size
        {
            get
            {
                return new Size(Widget.WidthRequest, Widget.HeightRequest);
            }
            set
            {
                Widget.SetSizeRequest(value.Width, value.Height);
            }
        }
        public virtual int TabIndex { get; set; }
        public virtual bool TabStop { get; set; }
        public virtual object Tag { get; set; }
        public virtual string Text { get; set; }
        public virtual int Top { get; set; }
        public virtual Control TopLevelControl { get; }

        public virtual bool UseWaitCursor { get; set; }
        public virtual bool Visible { get { return Widget.Visible; } set { Widget.Visible = value; Widget.NoShowAll = value == false; } }
        public virtual int Width { get { return Widget.WidthRequest; } set { Widget.WidthRequest = value; } }
        public virtual IWindowTarget WindowTarget { get; set; }
        public virtual event EventHandler AutoSizeChanged;
        public virtual event EventHandler BackColorChanged;
        public virtual event EventHandler BackgroundImageChanged;
        public virtual event EventHandler BackgroundImageLayoutChanged;
        public virtual event EventHandler BindingContextChanged;
        public virtual event EventHandler CausesValidationChanged;
        public virtual event UICuesEventHandler ChangeUICues;
        public virtual event EventHandler Click;
        public virtual event EventHandler ClientSizeChanged;
        public virtual event EventHandler ContextMenuStripChanged;
        public virtual event ControlEventHandler ControlAdded;
        public virtual event ControlEventHandler ControlRemoved;
        public virtual event EventHandler CursorChanged;
        public virtual event EventHandler DockChanged;
        public virtual event EventHandler DoubleClick;
        public virtual event EventHandler DpiChangedAfterParent;
        public virtual event EventHandler DpiChangedBeforeParent;
        public virtual event DragEventHandler DragDrop;
        public virtual event DragEventHandler DragEnter;
        public virtual event EventHandler DragLeave;
        public virtual event DragEventHandler DragOver;
        public virtual event EventHandler EnabledChanged;
        public virtual event EventHandler Enter;
        public virtual event EventHandler FontChanged;
        public virtual event EventHandler ForeColorChanged;
        public virtual event GiveFeedbackEventHandler GiveFeedback;
        public virtual event EventHandler GotFocus;
        public virtual event EventHandler HandleCreated;
        public virtual event EventHandler HandleDestroyed;
        public virtual event HelpEventHandler HelpRequested;
        public virtual event EventHandler ImeModeChanged;
        public virtual event InvalidateEventHandler Invalidated;
        public virtual event KeyEventHandler KeyDown;
        public virtual event KeyPressEventHandler KeyPress;
        public virtual event KeyEventHandler KeyUp;
        public virtual event LayoutEventHandler Layout;
        public virtual event EventHandler Leave;
        public virtual event EventHandler LocationChanged;
        public virtual event EventHandler LostFocus;
        public virtual event EventHandler MarginChanged;
        public virtual event EventHandler MouseCaptureChanged;
        public virtual event MouseEventHandler MouseClick;
        public virtual event MouseEventHandler MouseDoubleClick;
        public virtual event MouseEventHandler MouseDown;
        public virtual event EventHandler MouseEnter;
        public virtual event EventHandler MouseHover;
        public virtual event EventHandler MouseLeave;
        public virtual event MouseEventHandler MouseMove;
        public virtual event MouseEventHandler MouseUp;
        public virtual event MouseEventHandler MouseWheel;
        public virtual event EventHandler Move;
        public virtual event EventHandler PaddingChanged;
        //public virtual event PaintEventHandler Paint;
        public virtual event EventHandler ParentChanged;
        public virtual event PreviewKeyDownEventHandler PreviewKeyDown;
        public virtual event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;
        public virtual event QueryContinueDragEventHandler QueryContinueDrag;
        public virtual event EventHandler RegionChanged;
        public virtual event EventHandler Resize;
        public virtual event EventHandler RightToLeftChanged;
        public virtual event EventHandler SizeChanged;
        public virtual event EventHandler StyleChanged;
        public virtual event EventHandler SystemColorsChanged;
        public virtual event EventHandler TabIndexChanged;
        public virtual event EventHandler TabStopChanged;
        public virtual event EventHandler TextChanged;

        CancelEventArgs cancelEventArgs = new CancelEventArgs(false);
        public virtual event EventHandler Validated;
        public virtual event CancelEventHandler Validating;
        public virtual event EventHandler VisibleChanged;
        //public event EventHandler Disposed;
        public virtual event EventHandler Load;

        public virtual IAsyncResult BeginInvoke(Delegate method, params object[] args)
        {
            System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Factory.StartNew(state =>
            {
                method.DynamicInvoke((object[])state);
            }, args);

            return task;
        }
        public virtual IAsyncResult BeginInvoke(Delegate method)
        {
            return BeginInvoke(method, null);
        }
        public virtual IAsyncResult BeginInvoke(Action method)
        {
            System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Factory.StartNew(method);
            return task;
        }
        public virtual object EndInvoke(IAsyncResult asyncResult)
        {
            if (asyncResult is System.Threading.Tasks.Task task)
            {
                if (task.IsCompleted == false && task.IsCanceled == false && task.IsFaulted == false)
                    task.GetAwaiter().GetResult();
            }
            return asyncResult.AsyncState;
        }

        public virtual void BringToFront()
        {

        }

        public virtual bool Contains(Control ctl)
        {
            return false;
        }

        public virtual void CreateControl()
        {

        }

        public virtual Graphics CreateGraphics()
        {
            Graphics g = new Graphics(this.Widget, new Cairo.Context(this.Widget.Handle, true), Widget.Allocation);
            return g;
        }

        public virtual DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects)
        {
            return DragDropEffects.None;
        }

        public virtual void DrawToBitmap(Bitmap bitmap, Rectangle targetBounds)
        {
        }

        public virtual Form FindForm()
        {
            Control control = this.Parent;
            while (control != null)
            {
                if (control is Form)
                    break;
                else
                    control = this.Parent;
            }
            return control as Form;
        }

        public virtual bool Focus()
        {
            if (this.Widget != null)
            {
                this.Widget.IsFocus = true;
                return this.Widget.IsFocus;
            }
            else { 
                return false; 
            }
        }

        public virtual Control GetChildAtPoint(Point pt)
        {
            return null;
        }

        public virtual Control GetChildAtPoint(Point pt, GetChildAtPointSkip skipValue)
        {
            return null;
        }

        public virtual IContainerControl GetContainerControl()
        {
            return null;
        }

        public virtual Control GetNextControl(Control ctl, bool forward)
        {
            return ctl;
        }

        public virtual Size GetPreferredSize(Size proposedSize)
        {
            return proposedSize;
        }

        public virtual void Invalidate()
        {
            Invalidate(true);
        }

        public virtual void Invalidate(bool invalidateChildren)
        {
            if (this.Widget != null && this.Widget.IsVisible)
            {
                Widget.Window.InvalidateRect(Widget.Allocation, invalidateChildren);
            }
        }

        public virtual void Invalidate(Rectangle rc)
        {
            Invalidate(rc, true);
        }

        public virtual void Invalidate(Rectangle rc, bool invalidateChildren)
        {
            if (this.Widget != null)
            {
                if (IPainter != null)
                    IPainter.Painter.OnAddClass();
                Widget.Window.InvalidateRect(new Gdk.Rectangle(rc.X, rc.Y, rc.Width, rc.Height), invalidateChildren);
            }
        }

        public virtual void Invalidate(Drawing.Region region)
        {
            Invalidate(region, true);
        }

        public virtual void Invalidate(Drawing.Region region, bool invalidateChildren)
        {
            if (this.Widget != null)
            {
                if (IPainter != null)
                    IPainter.Painter.OnAddClass();
                Widget.Window.InvalidateRect(Widget.Allocation, invalidateChildren);
            }
        }

        public virtual object Invoke(Delegate method)
        {
            return Invoke(method, null);
        }

        public virtual object Invoke(Delegate method, params object[] args)
        {
            object result = null;
            Gtk.Application.Invoke(delegate {
                result = method.DynamicInvoke(args);
            });
            return result;
        }
        public virtual void Invoke(Action method)
        {
            Gtk.Application.Invoke(delegate {
                method.Invoke();
            }); 
        }
        public virtual ENTRY Invoke<ENTRY>(Func<ENTRY> method)
        {
            ENTRY result = default(ENTRY);
            Gtk.Application.Invoke(delegate {
                result = method.Invoke();
            });
            return result;
        }
        public virtual int LogicalToDeviceUnits(int value)
        {
            return value;
        }

        public virtual Size LogicalToDeviceUnits(Size value)
        {
            return value;
        }

        public virtual Point PointToClient(Point p)
        {
            if (Widget != null)
            {
                Widget.Window.GetPosition(out int x, out int y);
                if (p.X > x && p.Y > y)
                    return new Point(p.X - x, p.Y - y);
            }
            return new Point(p.X, p.Y);
        }

        public virtual Point PointToScreen(Point p)
        {
            if (Widget != null)
            {
                Widget.Window.GetPosition(out int x, out int y);
                if (p.X < x && p.Y < y)
                    return new Point(p.X + x, p.Y + y);
            }
            return new Point(p.X, p.Y);
        }

        public virtual PreProcessControlState PreProcessControlMessage(ref Message msg)
        {
            return PreProcessControlState.MessageNotNeeded;
        }

        public virtual bool PreProcessMessage(ref Message msg)
        {
            return false;
        }

        public virtual Rectangle RectangleToClient(Rectangle r)
        {
            if (Widget != null)
            {
                Widget.Window.GetPosition(out int x, out int y);
                if (r.X > x && r.Y > y)
                    return new Rectangle(r.X - x, r.Y - y, r.Width, r.Height);
            }
            return new Rectangle(r.X, r.Y, r.Width, r.Height);
        }

        public virtual Rectangle RectangleToScreen(Rectangle r)
        {
            if (Widget != null)
            {
                Widget.Window.GetPosition(out int x, out int y);
                if (r.X < x && r.Y < y)
                    return new Rectangle(r.X + x, r.Y + y, r.Width, r.Height);
            }
            return new Rectangle(r.X, r.Y, r.Width, r.Height);
        }

        public virtual void Refresh()
        {
            if (this.Widget != null && this.Widget.IsVisible)
            {
                if (IPainter != null)
                    IPainter.Painter.ClearNativeBackground();
                Widget.QueueDraw();
            }
        }

        public virtual void ResetBackColor()
        {

        }

        public virtual void ResetBindings()
        {

        }

        public virtual void ResetCursor()
        {

        }

        public virtual void ResetFont()
        {

        }

        public virtual void ResetForeColor()
        {

        }

        public virtual void ResetImeMode()
        {

        }

        public virtual void ResetRightToLeft()
        {

        }

        public virtual void ResetText()
        {

        }

        public virtual void ResumeLayout()
        {
            _Created = true;
        }

        public virtual void ResumeLayout(bool performLayout)
        {
            _Created = performLayout == false;
        }

        public virtual void Scale(float ratio)
        {

        }

        public virtual void Scale(float dx, float dy)
        {

        }

        public virtual void Scale(SizeF factor)
        {

        }

        public virtual void ScaleBitmapLogicalToDevice(ref Bitmap logicalBitmap)
        {

        }

        public virtual void Select()
        {
            if (this.Widget != null)
                this.Widget.SetStateFlags(StateFlags.Selected, true);
        }

        public virtual bool SelectNextControl(Control ctl, bool forward, bool tabStopOnly, bool nested, bool wrap)
        {
            return false;
        }

        public virtual void SendToBack()
        {

        }

        public virtual void SetBounds(int x, int y, int width, int height)
        {
            SetBounds(x, y, width, height, BoundsSpecified.All);
        }

        public virtual void SetBounds(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.Widget != null)
            {
                Gdk.Rectangle rect = this.Widget.Clip;
                if (specified == BoundsSpecified.X)
                    rect.X = x;
                else if (specified == BoundsSpecified.Y)
                    rect.Y = y;
                else if (specified == BoundsSpecified.Width)
                    rect.Width = width;
                else if (specified == BoundsSpecified.Height)
                    rect.Height = height;
                else if (specified == BoundsSpecified.Size)
                {
                    rect.Width = width;
                    rect.Height = height;
                }
                else if (specified == BoundsSpecified.Location)
                {
                    rect.X = x;
                    rect.Y = y;
                }
                else
                {
                    rect.X = x;
                    rect.Y = y;
                    rect.Width = width;
                    rect.Height = height;
                }
                this.Widget.SetClip(rect);
            }
        }
        public virtual Rectangle ClientRectangle { get { if (Widget == null) { return new Rectangle(); } else { Widget.GetAllocatedSize(out Gdk.Rectangle allocation, out int baseline); return new Rectangle(allocation.X, allocation.Y, allocation.Width, allocation.Height); } } }

        public virtual Size ClientSize { get { Widget.GetSizeRequest(out int width,out int height); return new Size(width, height); } set { if (Widget != null) { Widget.SetSizeRequest(value.Width, value.Height); } } }

        public virtual IntPtr Handle { get => this.Widget == null ? IntPtr.Zero : this.Widget.Handle; }

        public virtual Padding Margin { get; set; }
        public virtual Size MaximumSize { get; set; }
        public virtual Size MinimumSize { get; set; }
        public virtual BorderStyle BorderStyle { get; set; }

        public virtual void Hide()
        {
            if (this.GtkControl is Misc con)
            {
                con.Hide();
                con.NoShowAll = true;
            }
        }

        public virtual void Show()
        {
            if (this.Widget != null)
            {
                Widget.ShowAll();
            }
        }
        protected virtual void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected virtual void OnParentChanged(EventArgs e)
        {
        }

        public virtual void SuspendLayout()
        {
            _Created = false;
        }

        public virtual void PerformLayout()
        {
            _Created = true;
        }

        public virtual void PerformLayout(Control affectedControl, string affectedProperty)
        {
            _Created = true;
        }

        public virtual void Update()
        {
            if (this.Widget != null)
            {
                this.Widget.Window.ProcessUpdates(true);
                this.Widget.QueueDraw();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual void BeginInit()
        {

        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual void EndInit()
        {

        }

        public new void Dispose()
        {
            Dispose(true);
            base.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (this.Widget != null)
                {
                    this.Widget.Destroy();
                    this.GtkControl = null;
                }
            }
            catch { }
            base.Dispose(disposing);
        }


        protected virtual CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = new CreateParams();
                createParams.ExStyle |= 32;
                return createParams;
            }
        }
        protected virtual void OnKeyDown(KeyEventArgs e)
        {

        }
        protected virtual void OnKeyUp(KeyEventArgs e)
        {

        }
        protected virtual void OnVisibleChanged(EventArgs e)
        {

        }
        protected virtual void OnSizeChanged(EventArgs e)
        {

        }
        protected virtual void Select(bool directed, bool forward)
        {

        }
        protected virtual void OnGotFocus(EventArgs e)
        {

        }
        protected virtual void WndProc(ref Message m)
        {
            //Console.WriteLine($"HWnd:{m.HWnd},WParam:{m.WParam},LParam:{m.LParam},Msg:{m.Msg}");
        }
    }
}
