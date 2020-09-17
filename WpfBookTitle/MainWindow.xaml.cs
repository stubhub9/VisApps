using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBookTitle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  6.11  175 Executing Commands with [Keyboard] Input Gestures. 
        public MainWindow ()
        {
            //  Initialize the XAML component of the class [window].
            InitializeComponent ();

            //  3.5  73
            TextElement.SetFontStyle ( noCodeJustCommands, FontStyles.Italic );

            // in XAML;  Remap Help command to F2  
            /*
            this.InputBindings.Add ( new KeyBinding ( ApplicationCommands.Help, new KeyGesture ( Key.F2 ) ) );
            this.InputBindings.Add ( new KeyBinding ( ApplicationCommands.NotACommand, new KeyGesture ( Key.F1 ) ) );
             */

            /*
            //  The two XAML event attributes are equivalent to:
            this.AddHandler ( ListBox.SelectionChangedEvent, new SelectionChangedEventHandler ( ListBox_SelectionChanged ) );
            this.AddHandler ( Button.ClickEvent, new RoutedEventHandler ( Button_Click ) );
            */


        }



        //  Events     *****     Events     *****     Events     *****     Events     *****     Events     *****     Events     *****     Events     *****     Events     *****     Events     *****     Events     *****     

        void AboutDialog_MouseRightButtonDown ( object sender, MouseButtonEventArgs e )
        {
            // Display information about this event.
            this.Title = "Source =" + e.Source.GetType ().Name + ", OriginalSource  = " + e.OriginalSource.GetType ().Name + " @ " + e.Timestamp;

            //  In this example, all possible sources derive from Control.
            Control source = e.Source as Control;

            //  Toggle the border on the source control.
            if ( source.BorderThickness != new Thickness (5) )
            {
                source.BorderThickness = new Thickness ( 5 );
                source.BorderBrush = Brushes.Black;
            }

            else
            {
                source.BorderThickness = new Thickness ( 0 );
            }
        }




        void Help_CanExecute (object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        void Help_Executed (object sender, ExecutedRoutedEventArgs e)
        {
            System.Diagnostics.Process.Start ( "http://www.bing.com" );
            return;
        }


        //  6.4  with two attached Event Handlers on the the Root Window.
        void ListBox_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if ( e.AddedItems.Count > 0 )
                MessageBox.Show ( "You just selected " + e.AddedItems [ 0 ] );
        }

        void Button_Click (object sender, RoutedEventArgs e)
        {
            MessageBox.Show ( "You just clicked " + e.Source );

        }


        protected override void OnClosing ( CancelEventArgs e )
        {
            base.OnClosing ( e );

            if ( MessageBox.Show ("Buh Bye.","MessageBox.Annoying Prompt", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation ) == MessageBoxResult.Cancel)
            {
                //e.Cancel = true;
            }
        }

        protected override void OnClosed ( EventArgs e )
        {
            base.OnClosed ( e );

            //  Write the text to isolated storage.
            IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForAssembly ();
            using ( IsolatedStorageFileStream fileStream =
                new IsolatedStorageFileStream ( "myFile", FileMode.Create, storageFile ) )
            using ( StreamWriter streamWriter = new StreamWriter ( fileStream ) )
            {
                string text = textBox.Text;
                streamWriter.WriteLine ( text );
            }
        }

        protected override void OnInitialized ( EventArgs e )
        {
            base.OnInitialized ( e );

            //  Read the saved text back into textbox.
            IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForAssembly ();
            using ( IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream ( "myFile", FileMode.OpenOrCreate, storageFile ) )
            using ( StreamReader reader = new StreamReader ( fileStream ) )
            {
                textBox.Text = reader.ReadLine ();
            }
        }



        private void ShowCustomDialog_Click ( object sender, RoutedEventArgs e )
        {
            ShowMyMessageBox ();
        }

        //  MS Dialog boxes overview

        private void FormatMarginsMenuItem_Click ( object sender, RoutedEventArgs e )
        {
            //  Instantiate the dialog box, window.
            var customDialog = new CustomDialogBoxSep20 ();

            //  Configure the dialog.
            customDialog.Owner = this;

            //customDialog.DocumentMargin = this.documentTextBox.Margin

            //  Open the dialog window modally.
            customDialog.ShowDialog ();
        }


        //  Methods     *****     Methods     *****     Methods     *****     Methods     *****     Methods     *****     Methods     *****     Methods     *****     Methods     *****     
        void ShowMyMessageBox ()
        {
            string textBody = "Modeless Window called by Show method. " +
                " MessageBox is the only type of window that can be shown by applications that run within a partial trust security sandbox ";
            string caption = "My MessageBox";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Asterisk;
            //  Display message box.
            MessageBoxResult result =MessageBox.Show ( textBody, caption, button, icon );

            //  Process message box results.
            switch (result)
            {
                // Escape or Cancel.
                case MessageBoxResult.Cancel:
                    //  Who cares?
                    break;
                default:
                    break;
            }



        }






        /*  re:  Add a copyright or other symbol. 
        //  To get the character from its code, cast to char. To get the code of a character, cast to int.

        int code = 65;
        char c = ( char ) code;

        char c = 'A';
        int code = c;
        Note that you don't need to explicitly cast from char to int.
        */


    }
}
