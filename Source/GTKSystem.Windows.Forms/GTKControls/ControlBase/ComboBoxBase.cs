namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class ComboBoxBase : Gtk.ComboBoxText, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal ComboBoxBase() : base(true)
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("ComboBox");
        }
        internal ComboBoxBase(bool hasEntry) : base(hasEntry)
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("ComboBox");
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
