using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestbedForm
{
    public partial class Form1 : Form
    {
        enum TestEnum
        {  First, Second, Third }

        //static struct EnumStruct
        //{
        //    TestEnum TestE;
        //}

        public Form1 ()
        {
            InitializeComponent ();
            BeginTest ();
        }


        private void button1_Click ( object sender, EventArgs e )
        {

        }

        void BeginTest ()
        {
            Point point = new Point ();
            label1.Text = $"Point = {point.ToString ()}";
        }


    }
}
