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

namespace WpfManipulationEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            // 6.7, 6.8 165
            InitializeComponent ();
            //  Touch manipulation set in XAML.
            canvas.ManipulationDelta += Canvas_ManipulationDelta;
            //  Add for inertia properties.
            canvas.ManipulationInertiaStarting += Canvas_ManipulationInertiaStarting;
        }

        /* TODO:  Use the ManipulationBoundaryFeedback event to be notified
         * when an element reaches the boundary of the manipulation container.
         * Use Complete to dismiss event.
         To make the window bounce; use the ReportBoundaryFeedback method 
         of the passed in ManipulationDeltaEventArgs, which raises the 
         ManipulationBoundaryFeedback event, handled by the  WPF window.
         WPF page167*/

        private void Canvas_ManipulationInertiaStarting ( object sender, ManipulationInertiaStartingEventArgs e )
        {
            e.TranslationBehavior.DesiredDeceleration = 0.01;
            e.RotationBehavior.DesiredDeceleration = 0.01;
            e.ExpansionBehavior.DesiredDeceleration = 0.01;
        }

        private void Canvas_ManipulationDelta ( object sender, ManipulationDeltaEventArgs e )
        {
            MatrixTransform transform = photo.RenderTransform as MatrixTransform;
            if ( transform != null )
            {
                // Apply any deltas to the matrix, then apply the new Matrix as the MatrixTransform data;
                Matrix matrix = transform.Matrix;
                // Double X and Y from any source; but this sample uses Touch screen inputs
                matrix.Translate ( e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y );
                matrix.RotateAt ( e.DeltaManipulation.Rotation, e.ManipulationOrigin.X, e.ManipulationOrigin.Y );
                matrix.ScaleAt ( e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.Y, e.ManipulationOrigin.X, e.ManipulationOrigin.Y );
                transform.Matrix = matrix;
                e.Handled = true;
            }
        }



        private void Toolstrip_ImageManipulation ( object sender, EventArgs e )
        {
        }









    }
}
