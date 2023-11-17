using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternWPF
{
    internal class Director
    {
        private Builder builder;

        public Director(Builder b)
        {
            builder = b;
        }

        public void Build()
        {
            builder.BuildFirst();
            builder.BuildSecond();
            builder.BuildDrink();
            builder.BuildDessert();
        }
    }
}
