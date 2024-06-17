namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class PictureBoxBase : Gtk.Image, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal PictureBoxBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("PictureBox");
            this.Halign = Gtk.Align.Center;
            this.Valign = Gtk.Align.Center;
            this.Xalign = 0.5f;
            this.Yalign = 0.5f;
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
