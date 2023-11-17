using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternWPF
{
    internal class Order
    {
        public string First { get; set; }

        public string Second { get; set; }

        public string Drink { get; set; }

        public string Dessert { get; set; }

        public decimal Price { get; set; }

        public override string ToString() =>
            new StringBuilder()
            .Append(First)
            .Append("  ")
            .Append(Second)
            .Append("  ")
            .Append(Drink)
            .Append("  ")
            .Append(Dessert)
            .Append("  Цена заказа: ")
            .Append(Price)
            .ToString();
    }
}
