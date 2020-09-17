using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Windows.Controls;

namespace WpfBookTitle
{
    public class CustomDialogValidationRule : ValidationRule
    {
        double minValue;
        double maxValue;

        public double MinValue
        {
            get { return this.minValue; }
            set { this.minValue = value; }
        }

        public double MaxValue
        {
            get { return this.maxValue; }
            set { this.maxValue = value; }
        }

        public CustomDialogValidationRule ()
        { }


        public override ValidationResult Validate ( object value, CultureInfo cultureInfo )
        {
            double newValue;

            //  Is a number?
            if ( !double.TryParse ( ( string ) value, out newValue ) )
            {
                return new ValidationResult ( false, "Not a number." );
            }

            // Is in range?
            if ( ( newValue < this.minValue ) ||  (newValue > this.maxValue) )
            {
                string msg = string.Format ( "Value must be between {0} and {1}.", minValue, maxValue );
                return new ValidationResult ( false, msg );
            }

            //  Number is valid.
            return new ValidationResult ( true, null );
        }
    }
}
