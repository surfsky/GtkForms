namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class RadioButtonBase : Gtk.RadioButton, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal RadioButtonBase() : base(new Gtk.RadioButton("baseradio"))
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("RadioButton");
        }
        internal RadioButtonBase(Gtk.RadioButton radio_group_member) : base(radio_group_member)
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("RadioButton");
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
