namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class ListViewBase : Gtk.Box, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal ListViewBase() : base(Gtk.Orientation.Vertical, 0)
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("ListView");
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
