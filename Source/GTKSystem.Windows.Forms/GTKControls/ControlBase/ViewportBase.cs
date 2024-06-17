namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class ViewportBase : Gtk.Viewport, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal ViewportBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
        }
        protected override bool OnDrawn(Cairo.Context cr)
        {
            Gdk.Rectangle rec = new Gdk.Rectangle(0, 0, this.AllocatedWidth, this.AllocatedHeight);
            Painter.OnDrawnBackground(cr, rec);
            return base.OnDrawn(cr);
        }
    }
}
