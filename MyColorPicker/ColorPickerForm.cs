using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyColorPicker
{
    public partial class ColorPickerForm : Form
    {
        public ColorPickerForm ()
        {
            InitializeComponent ();
        }

        private void PickColorButton_Click ( object sender, EventArgs e )
        {
            colorDialog1.Color = ColorPanel.BackColor;

            if (colorDialog1.ShowDialog () == DialogResult.OK )
            {
                ColorPanel.BackColor = colorDialog1.Color;
            }
        }

        private void AcceptColorButton_Click ( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            this.Close ();
        }

        public Color SelectedColor
        {
            get { return ColorPanel.BackColor; }
        }

        


    }
}
