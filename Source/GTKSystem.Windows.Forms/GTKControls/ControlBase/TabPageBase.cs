using System;

namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class TabPageBase : Gtk.Layout, IGtkPainter
    {
        public GtkControlPainter Painter { get; set; }
        internal TabPageBase() : base(new Gtk.Adjustment(IntPtr.Zero), new Gtk.Adjustment(IntPtr.Zero))
        {
            this.Painter = new GtkControlPainter(this);
            this.Painter.AddClass("TabPage");
            this.BorderWidth = 0;
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
