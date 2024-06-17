namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class CheckBoxBase : Gtk.CheckButton, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal CheckBoxBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("CheckBox");
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
