namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class NumericUpDownBase : Gtk.SpinButton, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal NumericUpDownBase() : base(0, 100, 1)
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("NumericUpDown");
            this.Value = 0;
            this.Orientation = Gtk.Orientation.Horizontal;
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
