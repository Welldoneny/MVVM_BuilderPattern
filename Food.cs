using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternWPF
{
    class Food : INotifyPropertyChanged
    {
        private string name;
        //private int amount;
        private decimal price;
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }
        public string Name
        {
            get { return name; }
            set
            { name = value; OnPropertyChanged("Name");}
        }
        //public int Amount
        //{
        //    get {return amount; }
        //    set
        //    {
        //        amount = value;
        //        OnPropertyChanged("Amount");
        //    }
        //}
        public decimal Price
        {
            get { return price; }
            set
            { price = value; OnPropertyChanged("Price"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
