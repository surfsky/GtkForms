namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class TrackBarBase : Gtk.Viewport, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal TrackBarBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("TrackBar");
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
            Painter.OnDrawnBackground(cr, rec);
            Painter.OnPaint(cr, rec);
            return base.OnDrawn(cr);
        }
    }
}
