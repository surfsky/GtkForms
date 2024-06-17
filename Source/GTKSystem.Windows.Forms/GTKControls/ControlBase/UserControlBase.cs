using Gtk;


namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class UserControlBase : Gtk.Viewport, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal UserControlBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("UserControl");
            this.MarginStart = 0;
            this.MarginTop = 0;
            this.BorderWidth = 0;
            this.ShadowType = ShadowType.None;
            this.Halign = Align.Start;
            this.Valign = Align.Start;
            this.Expand = false;
            this.Hexpand = false;
            this.Vexpand = false;
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
