namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class TreeViewBase : Gtk.TreeView, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal TreeViewBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.BorderWidth = 0;
            this.Expand = true;
            this.HeadersVisible = false;
            this.ActivateOnSingleClick = true;
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
