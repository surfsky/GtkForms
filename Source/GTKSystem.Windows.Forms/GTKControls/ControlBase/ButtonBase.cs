using Gtk;
using System;


namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class ButtonBase: Gtk.Button, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal ButtonBase() : base()
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("Button");
        }
        internal ButtonBase(Widget widget) : base(widget)
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("Button");
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
