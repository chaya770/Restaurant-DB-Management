using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ordered_Dish
    {
        public Ordered_Dish()
        {
            dishNumber = 0;

            orderNumber ="";

            amountOfDish = 0;
        }
        //constructor
        public Ordered_Dish(int dishnumber,string ordernumber, int amountofdish)
        {
           
            dishNumber = dishnumber;
           
            orderNumber = ordernumber;
           
            amountOfDish = amountofdish;
        }
        public int dishNumber { get; set; }
        public string orderNumber { get; set; }
        public int amountOfDish { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();

            //string s;
            //s = "dish number: " + dishNumber + "\n" +
            //    "Order number: " + orderNumber +"\n"+
            //    "Amount Of Dish: " + amountOfDish;
            //return s;
        }

    }
}
