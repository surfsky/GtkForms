namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class ToolStripBase : Gtk.MenuBar, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal ToolStripBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("ToolStrip");
            this.Hexpand = false;
            this.Vexpand = false;
            this.Valign = Gtk.Align.Start;
            this.Halign = Gtk.Align.Start;
            this.HeightRequest = 20;
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
    }
}
