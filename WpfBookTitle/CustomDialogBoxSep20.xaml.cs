using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfBookTitle
{
    /// <summary>
    /// Interaction logic for CustomDialogBoxSep20.xaml
    /// </summary>
    public partial class CustomDialogBoxSep20 : Window
    {
        //  MS  Dialog Boxes Overview

        /*  
The user interface for a typical dialog box includes the following:
The various controls that are required to gather the desired data.
An OK,  Cancel,  Close, button,  icon.
Minimize, Maximize, and Restore buttons.
A System menu to minimize, maximize, restore, and close the dialog box.
A position above and in the center of the window that opened the dialog box.
The ability to be resized where possible to prevent the dialog box from being too small, 
and to provide the user with a useful default size. 
The ESC key  causes the Cancel,  ENTER  causes the OK button to be pressed. .*/

        public CustomDialogBoxSep20 ()
        {
            InitializeComponent ();
            //  Dialogs should return True if successful; and False if Canceled or failed.
        }




        private void OkButton_Click ( object sender, RoutedEventArgs e )
        {
            this.DialogResult = true;
        }





    }
}
