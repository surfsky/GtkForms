namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class LabelBase : Gtk.Label, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal LabelBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("Label");
            this.Xalign = 0.0f;
            this.Yalign = 0.0f;
        }

        internal LabelBase(string text) : base(text)
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("Label");
            this.Xalign = 0.0f;
            this.Yalign = 0.0f;
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
