using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CommandPatternWPF
{
    internal interface IBuilder
    {
        void BuildFirst();

        void BuildSecond();

        void BuildDrink();

        void BuildDessert();

        Order GetOrder();
    }
}
