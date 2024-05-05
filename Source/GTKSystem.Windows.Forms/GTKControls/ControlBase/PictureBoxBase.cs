﻿using Gtk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class PictureBoxBase : Gtk.Image, IControlGtk
    {
        public GtkControlOverride Override { get; set; }
        internal PictureBoxBase() : base()
        {
            this.Override = new GtkControlOverride(this);
            this.Override.AddClass("PictureBox");
            this.Halign = Gtk.Align.Center;
            this.Valign = Gtk.Align.Center;
            this.Xalign = 0.5f;
            this.Yalign = 0.5f;
        }
        protected override void OnShown()
        {
            Override.OnAddClass();
            base.OnShown();
        }
        protected override bool OnDrawn(Cairo.Context cr)
        {
            Gdk.Rectangle rec = new Gdk.Rectangle(3, 3, this.WidthRequest - 3, this.HeightRequest - 3);
            Override.OnDrawnBackground(cr, rec);
            Override.OnPaint(cr, rec);
            return base.OnDrawn(cr);
        }
    }
}
