using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCenter.ViewModels
{
    class MaterialFilter : INotifyPropertyChanged
    {
        public bool _isChecked = false;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if(_isChecked != value)
                {
                    _isChecked = value;
                    PropertyChange("IsChecked");
                }
            }
        }
        public Material Material { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void PropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
