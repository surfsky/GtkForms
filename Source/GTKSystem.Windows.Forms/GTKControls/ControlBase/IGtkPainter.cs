using System;


namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public interface IGtkPainter : IDisposable
    {
        GtkControlPainter Painter { get; set; }
    }
}
