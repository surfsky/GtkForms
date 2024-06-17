namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class DataGridViewBase : Gtk.Viewport, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        private Gtk.ScrolledWindow scroll = new Gtk.ScrolledWindow();
        internal Gtk.TreeView GridView = new Gtk.TreeView();
        internal DataGridViewBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("DataGridView");
            this.Painter.BackColor = System.Drawing.Color.White;
            this.BorderWidth = 0;
            this.ShadowType = Gtk.ShadowType.Out;
            GridView.Valign = Gtk.Align.Fill;
            GridView.Halign = Gtk.Align.Fill;
            GridView.Expand = true;
            GridView.BorderWidth = 0;
            scroll.Child = GridView;
            this.Child = scroll;
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
