namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class PanelBase: Gtk.Viewport, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal PanelBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("Panel");
            this.ShadowType = Gtk.ShadowType.None;
            this.BorderWidth = 0;
        }
        protected override void OnShown()
        {
            Painter.OnAddClass();
            base.OnShown();
        }
        protected override bool OnDrawn(Cairo.Context cr)
        {
            Gdk.Rectangle rec = new Gdk.Rectangle(0, 0, this.AllocatedWidth, this.AllocatedHeight);
            Painter.OnDrawnBackground(cr, rec);
            Painter.OnPaint(cr, rec);
            return base.OnDrawn(cr);
        }
    }
}
