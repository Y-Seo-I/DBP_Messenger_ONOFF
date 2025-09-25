﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace on_off_proj
{
    public static class Utils
    {
        public static int GetTextHeight(Label lbl)
        {
            using(Graphics g = lbl.CreateGraphics())
            {
                SizeF size = g.MeasureString(lbl.Text, lbl.Font, 350);
                return (int)Math.Ceiling(size.Height);
            }
        }
    }
}
