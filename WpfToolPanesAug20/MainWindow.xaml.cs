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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfToolPanesAug20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  Dummy columns for layers 0 and 1.
        ColumnDefinition column1CloneForLayer0;
        ColumnDefinition column2CloneForLayer0;
        ColumnDefinition column2CloneForLayer1;

        public MainWindow ()
        {
            InitializeComponent ();

            //  Initialize the dummy columns used when docking.
            column1CloneForLayer0 = new ColumnDefinition ();
            column1CloneForLayer0.SharedSizeGroup = "column1";
            column2CloneForLayer0 = new ColumnDefinition ();
            column2CloneForLayer0.SharedSizeGroup = "column2";
            column2CloneForLayer1 = new ColumnDefinition ();
            column2CloneForLayer1.SharedSizeGroup = "column1";
        }

        //  Events      ******     Events      ******     Events      ******     Events      ******     Events      ******     Events      ******     Events      ******     Events      ******     

        //  Hide any undocked panes when the mouse enters Layer 0.
        private void Layer0_MouseEnter ( object sender, MouseEventArgs e )
        {
            if ( pane1Button.Visibility == Visibility.Visible )
            {
                layer1.Visibility = Visibility.Collapsed;
            }

            if ( pane2Button.Visibility == Visibility.Visible )
            {
                layer2.Visibility = Visibility.Collapsed;
            }
        }


        //  Hide the other pane if undocked when the mouse enters Pane 1.
        public void Pane1_MouseEnter ( object sender, RoutedEventArgs e )
        {
            //  Ensure the other pane is hidden if it is undocked.
            if ( pane2Button.Visibility == Visibility.Visible )
            {
                layer2.Visibility = Visibility.Collapsed;
            }
        }


        //  Hide the other pane if undocked when the mouse enters Pane 2.
        public void Pane2_MouseEnter ( object sender, RoutedEventArgs e )
        {
            //  Ensure the other pane is hidden if it is undocked.
            if ( pane1Button.Visibility == Visibility.Visible )
            {
                layer1.Visibility = Visibility.Collapsed;
            }
        }



        //  Show Pane 1 when hovering over its button.
        private void Pane1Button_MouseEnter ( object sender, MouseEventArgs e )
        {
            layer1.Visibility = Visibility.Visible;

            //  Adjust Z order to ensure the pane is on top.
            Grid.SetZIndex ( layer1, 1 );
            Grid.SetZIndex ( layer2, 0 );

            //  Ensure the other pane is hidden if it is undocked.
            if ( pane2Button.Visibility == Visibility.Visible )
            {
                layer2.Visibility = Visibility.Collapsed;
            }
        }

        //  Show Pane 2 when hovering over its button.
        private void Pane2Button_MouseEnter ( object sender, MouseEventArgs e )
        {
            layer2.Visibility = Visibility.Visible;

            //  Adjust Z order to ensure the pane is on top.
            Grid.SetZIndex ( layer2, 1 );
            Grid.SetZIndex ( layer1, 0 );

            //  Ensure the other pane is hidden if it is undocked.
            if ( pane1Button.Visibility == Visibility.Visible )
            {
                layer1.Visibility = Visibility.Collapsed;
            }
        }


        //  Toggle between docked and undocked states (Pane 1).
        private void Pane1Pin_Click ( object sender, RoutedEventArgs e )
        {
            if ( pane1Button.Visibility == Visibility.Collapsed )
            {
                UndockPane ( 1 );
            }
            else
                DockPane ( 1 );
        }

        //  Toggle between docked and undocked states (Pane 1).
        private void Pane2Pin_Click ( object sender, RoutedEventArgs e )
        {
            if ( pane2Button.Visibility == Visibility.Collapsed )
            {
                UndockPane ( 2 );
            }
            else
                DockPane ( 2 );
        }



        //  Methods     *****     Methods     *****     Methods     *****     Methods     *****     Methods     *****     Methods     *****     Methods     *****     


            
            //  Docks a pane, which hides the corresponding  pane button
        private void DockPane ( int paneNumber )
        {
            if ( paneNumber == 1 )
            {
                pane1Button.Visibility = Visibility.Collapsed;
                pane1PinImage.Source = new BitmapImage ( new Uri ( "Pointer32.png", UriKind.Relative ) );

                //  Add the cloned column to layer 0.
                layer0.ColumnDefinitions.Add ( column1CloneForLayer0 );
                //  Add the cloned column to layer 1, but only if pane 2 is docked.
                if ( pane2Button.Visibility == Visibility.Collapsed )
                {
                    layer1.ColumnDefinitions.Add ( column2CloneForLayer1 );
                }
            }

            else if ( paneNumber == 2 )
            {
                pane2Button.Visibility = Visibility.Collapsed;
                pane2PinImage.Source = new BitmapImage ( new Uri ( "Pointer32.png", UriKind.Relative ) );


                //  Add the cloned column to layer 0.
                layer0.ColumnDefinitions.Add ( column2CloneForLayer0 );
                //  Add the cloned column to layer 1, but only if pane 1 is docked.
                if ( pane1Button.Visibility == Visibility.Collapsed )
                {
                    layer1.ColumnDefinitions.Add ( column2CloneForLayer1 );
                }

            }
        }

        private void UndockPane ( int paneNumber )
        {
            if ( paneNumber == 1 )
            {
                layer1.Visibility = Visibility.Visible;
                pane1Button.Visibility = Visibility.Visible;
                //pane1PinImage.Source = new BitmapImage
                //    ( new Uri ( "PointerRight32.png", UriKind.Relative ) );
                pane1PinImage.Source = new BitmapImage
                    ( new Uri ( "PointerRight32.png", UriKind.Relative ) );

                //  Remove the cloned columns from layers 0 and 1.
                layer0.ColumnDefinitions.Remove ( column1CloneForLayer0 );
                //  Remove is safe to use when empty.
                    layer1.ColumnDefinitions.Remove ( column2CloneForLayer1 );
            }

            else if ( paneNumber == 2 )
            {
                layer2.Visibility = Visibility.Visible;
                pane2Button.Visibility = Visibility.Visible;
                pane2PinImage.Source = new BitmapImage 
                    ( new Uri ( "PointerRight32.png", UriKind.Relative ) );

                //  Remove the cloned columns from layers 0 and 1.
                layer0.ColumnDefinitions.Remove ( column2CloneForLayer0 );
                //  Remove is safe to use when empty.
                layer1.ColumnDefinitions.Remove ( column2CloneForLayer1 );

            }

        }
    }
}
