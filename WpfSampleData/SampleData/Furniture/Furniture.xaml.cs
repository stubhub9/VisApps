﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.Furniture
{
    using System; 
    using System.ComponentModel;

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
    internal class Furniture { }
#else

    public class Furniture : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Furniture()
        {
            try
            {
                Uri resourceUri = new Uri("/WpfSampleData;component/SampleData/Furniture/Furniture.xaml", UriKind.RelativeOrAbsolute);
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private Chairs _Chairs = new Chairs();

        public Chairs Chairs
        {
            get
            {
                return this._Chairs;
            }
        }
    }

    public class ChairsItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Price = string.Empty;

        public string Price
        {
            get
            {
                return this._Price;
            }

            set
            {
                if (this._Price != value)
                {
                    this._Price = value;
                    this.OnPropertyChanged("Price");
                }
            }
        }

        private double _SKU = 0;

        public double SKU
        {
            get
            {
                return this._SKU;
            }

            set
            {
                if (this._SKU != value)
                {
                    this._SKU = value;
                    this.OnPropertyChanged("SKU");
                }
            }
        }

        private string _Description = string.Empty;

        public string Description
        {
            get
            {
                return this._Description;
            }

            set
            {
                if (this._Description != value)
                {
                    this._Description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }

        private System.Windows.Media.ImageSource _Image = null;

        public System.Windows.Media.ImageSource Image
        {
            get
            {
                return this._Image;
            }

            set
            {
                if (this._Image != value)
                {
                    this._Image = value;
                    this.OnPropertyChanged("Image");
                }
            }
        }
    }

    public class Chairs : System.Collections.ObjectModel.ObservableCollection<ChairsItem>
    { 
    }
#endif
}
