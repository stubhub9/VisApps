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

namespace WpfDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent ();
        }
    }

    public class ShoppingCart : DependencyObject
    {
        public int ItemCount
        {
            get { return ( int ) GetValue ( ItemCountProperty );}
            set { SetValue ( ItemCountProperty, value ); }
        }

        //  This code sets a value of 0 as the default item count by using the PropertyMetadata object.
        public static readonly DependencyProperty ItemCountProperty =
            DependencyProperty.Register ( "ItemCount", typeof ( int ), typeof ( ShoppingCart ), new PropertyMetadata ( 0 ) );
    }
}
