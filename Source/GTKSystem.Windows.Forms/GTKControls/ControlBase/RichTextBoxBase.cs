using System.Drawing;

namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class RichTextBoxBase : Gtk.Viewport, IGtkPainter
    {
        internal Gtk.TextView TextView = new Gtk.TextView();
        public GtkControlPainter Painter { get; set; }
        internal RichTextBoxBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("RichTextBox");
            this.TextView.BorderWidth = 1;
            this.TextView.WrapMode = Gtk.WrapMode.Char;
            this.TextView.Halign = Gtk.Align.Fill;
            this.TextView.Valign = Gtk.Align.Fill;
            this.TextView.Hexpand = true;
            this.TextView.Vexpand = true;
            Gtk.ScrolledWindow scrolledWindow = new Gtk.ScrolledWindow();
            scrolledWindow.Child = this.TextView;
            this.Child = scrolledWindow;
        }
        public void AddClass(string cssClass)
        {
            this.Painter.AddClass(cssClass);
        }
        protected override void OnShown()
        {
            Painter.OnAddClass();
            base.OnShown();
        }
        protected override bool OnDrawn(Cairo.Context cr)
        {
            Gdk.Rectangle rec = new Gdk.Rectangle(0, 0, this.AllocatedWidth, this.AllocatedHeight);
            Painter.OnPaint(cr, rec);
            return base.OnDrawn(cr);
        }
    }
}
