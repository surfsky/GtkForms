using Gtk;


namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class LayoutBase: Gtk.Layout, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal LayoutBase(Adjustment hadjustment, Adjustment vadjustment) : base(hadjustment, vadjustment)
        {
            this.Painter = new GtkControlPainter(this);
        }
        protected override bool OnDrawn(Cairo.Context cr)
        {
            Gdk.Rectangle rec = new Gdk.Rectangle(0, 0, this.AllocatedWidth, this.AllocatedHeight);
            Painter.DrawnBackColor(cr, rec);
            return base.OnDrawn(cr);
        }
    }
}
