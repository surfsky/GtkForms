namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class TableLayoutPanelBase : Gtk.Grid, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal TableLayoutPanelBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("TableLayoutPanel");
            this.RowHomogeneous = false;
            this.ColumnHomogeneous = false;
            this.BorderWidth = 1;
            this.BaselineRow = 0;
            this.ColumnSpacing = 0;
            this.RowSpacing = 0;
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
