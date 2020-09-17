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

namespace WpfCh6SpinWheel2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent ();

            grid.ManipulationStarting += Grid_ManipulationStarting;
            grid.ManipulationDelta += Grid_ManipulationDelta;
            grid.ManipulationInertiaStarting += Grid_ManipulationInertiaStarting;
            grid.ManipulationCompleted += Grid_ManipulationCompleted;

        }

        private void Grid_ManipulationCompleted ( object sender, ManipulationCompletedEventArgs e )
        {
            //  Post manipulation event; eg:  What is the result on the wheel.
        }

        private void Grid_ManipulationDelta ( object sender, ManipulationDeltaEventArgs e )
        {
            ( prizeWheel.RenderTransform as RotateTransform ).Angle += e.DeltaManipulation.Rotation;
        }

        private void Grid_ManipulationInertiaStarting ( object sender, ManipulationInertiaStartingEventArgs e )
        {
            e.RotationBehavior.DesiredDeceleration = 0.001;
        }

        private void Grid_ManipulationStarting ( object sender, ManipulationStartingEventArgs e )
        {
            //  Many controls [ScrollViewer] have a PanningMode 
            e.Mode = ManipulationModes.Rotate;  //  Only allow rotation.
        }
    }
}
