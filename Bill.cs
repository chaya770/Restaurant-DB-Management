using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bill
    {
        public Bill(string d,int a,int p)
        {
            dishName = d;
            amount = a;
            price = p;
                }
        public string dishName { get; set; }
        public int amount { get; set; }
        public int price { get; set; }

        public override string ToString()
        { return this.ToStringProperty(); }

    }
}
