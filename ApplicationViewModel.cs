using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandPatternWPF
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Food selectedFood;
        private decimal overalPrice;
        public ObservableCollection<Food> Menu { get; set; }
        public ObservableCollection<Food> Order {  get; set; }
        // команда добавления нового объекта
        private RelayCommand orderCommand;
        public RelayCommand OrderCommand
        {
            get{
                return orderCommand ?? (orderCommand = new RelayCommand(obj =>
                {
                    Builder builder = new Builder(Order);
                    Director director = new Director(builder);

                    director.Build();
                    var order = builder.GetOrder();
                    string str = order.ToString();
                    MessageBox.Show(order.ToString());
                }
                ));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get{
                return addCommand ??
                  (addCommand = new RelayCommand(obj => { Order.Add(SelectedFood);
                        UpPriceCommand.Execute(Order);
                  }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get{
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj => { Order.Remove(SelectedFood);
                        DownPriceCommand.Execute(Order);
                    }));
            }
        }

        private RelayCommand downPriceCommand;
        public RelayCommand DownPriceCommand
        {
            get
            {
                return downPriceCommand ??
                    (downPriceCommand = new RelayCommand(obj =>
                    {
                        decimal tmp = 0;
                        foreach (var item in Order)
                        {
                            tmp += item.Price;
                        }
                        OveralPrice = tmp;
                    }));
            }
        }

        private RelayCommand upPriceCommand;
        public RelayCommand UpPriceCommand
        {
            get
            {
                return upPriceCommand ??
                    (upPriceCommand = new RelayCommand(obj =>
                    {
                        OveralPrice = 0;
                        foreach (var item in Order)
                        {
                            OveralPrice += item.Price;
                        }
                    }));
            }
        }

        public decimal OveralPrice
        {
            get { return overalPrice; }
            set { overalPrice = value; OnPropertyChanged("OveralPrice"); }
        }

        public Food SelectedFood
        {
            get { return selectedFood; }
            set { selectedFood = value; OnPropertyChanged("SelectedFood"); }
        }

        public ApplicationViewModel()
        {
            Menu = new ObservableCollection<Food>
            {
                new Food {Name="Borsh", Price=55, Description="First"},
                new Food {Name="Solyanka", Price =50, Description="First"},
                new Food {Name="the Kiev's cutlet", Price=60, Description = "Second"},
                new Food {Name="Pasta", Price =40, Description = "Second"},
                new Food {Name="Milk", Price=40, Description = "Drink"},
                new Food {Name="Compot", Price=25, Description = "Drink"},
                new Food {Name="Cake", Price=35, Description = "Dessert"},
                new Food {Name="Cookie", Price=15, Description = "Dessert"}
            };
            Order = new ObservableCollection<Food> { };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
