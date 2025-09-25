using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace on_off_proj.ChatItems
{
    public partial class outGoing : UserControl
    {
        public outGoing()
        {
            InitializeComponent();
        }

        public string message
        {
            get
            {
                return label1.Text;
            }
            set
            {
                if (label1.InvokeRequired == true)
                {
                    label1.Invoke((MethodInvoker)delegate
                    {
                        label1.Text = value;
                        AdjustHeight();
                    });
                }
                else
                {
                    label1.Text = value;
                    AdjustHeight();
                }

            }
        }


        private void outGoing_DockChanged(object sender, EventArgs e)
        {
            AdjustHeight();
        }
        void AdjustHeight()
        {
            if (label1.InvokeRequired == true)
            {
                label1.Invoke((MethodInvoker)delegate
                {
                    label1.Height = Utils.GetTextHeight(label1) + 10;

                    panel1.Height = label1.Top + label1.Height;
                    this.Height = panel1.Bottom + 10;
                });
            }
            else
            {
                label1.Height = Utils.GetTextHeight(label1) + 10;

                panel1.Height = label1.Top + label1.Height;
                this.Height = panel1.Bottom + 10;
            }
        }
    }
}
