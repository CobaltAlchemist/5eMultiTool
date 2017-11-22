using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5eMultiTool
{
    class Monster : ObservableObject
    {
        string _name;
        public string Name { get {return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        CharSize _size;
        public string Size
        {
            get { return _size; }
            set { _size = value; OnPropertyChanged("Size"); }
        }
}
