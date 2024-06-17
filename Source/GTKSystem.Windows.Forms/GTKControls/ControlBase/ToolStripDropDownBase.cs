namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class ToolStripDropDownBase : Gtk.Menu, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal ToolStripDropDownBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
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
