using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternWPF
{
    internal class Builder : IBuilder
    {
        private Order _order;
        private List<Food> _foodList;

        public Builder(ObservableCollection<Food> foodlist) 
        {
            _foodList = foodlist.ToList();
            _order = new Order();
        }

        public void BuildFirst()
        {
            foreach (var item in _foodList)
            {
                if (item.Description == "First")
                {
                    _order.First += item.Name + " ";
                    _order.Price += item.Price;
                }
            }
        }
        public void BuildSecond()
        {
            foreach (var item in _foodList)
            {
                if (item.Description == "Second")
                {
                    _order.Second += item.Name + " ";
                    _order.Price += item.Price;
                }
            }
        }

        public void BuildDessert()
        {
            foreach (var item in _foodList)
            {
                if (item.Description == "Dessert")
                {
                    _order.Dessert += item.Name + " ";
                    _order.Price += item.Price;
                }
            }
        }

        public void BuildDrink()
        {
            foreach (var item in _foodList)
            {
                if (item.Description == "Drink")
                {
                    _order.Drink += item.Name + " ";
                    _order.Price += item.Price;
                }
            }
        }

        public Order GetOrder()
        {
            Order tmp = _order;
            _order = new Order();
            return tmp;
        }
    }
}
