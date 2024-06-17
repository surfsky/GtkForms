﻿using Gtk;
using System.Drawing;
using System.Windows.Forms;

namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public interface IControlPainter
    {
        event DrawnHandler DrawnBackground;
        event PaintEventHandler Paint;
        Color? BackColor { get; set; }
        System.Drawing.Image BackgroundImage { get; set; }
        ImageLayout BackgroundImageLayout { get; set; }
        void AddClass(string cssClass);
        void OnAddClass();
        void OnDrawnBackground(Cairo.Context cr, Gdk.Rectangle area);
        void OnPaint(Cairo.Context cr, Gdk.Rectangle area);
    }
}
