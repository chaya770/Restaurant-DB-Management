using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Dish 

    {
        public Dish()
        { }
       
        //constructor
        public Dish(int dishnumber, string dishname, size dishsize, float dishprice, int rate, hechsher hechsherr, int calories)
        {
            dishNumber = dishnumber;
            dishName = dishname;
            dishSize = dishsize;
            dishPrice = dishprice;
            Hechsher = hechsherr;
            Calories = calories;
            Rate = rate;
        }

        public static int dishnumbercounter = 0;
       
        public int dishNumber { get; set; }
        public int Rate { get; set; }//dirog
        public string dishName { get; set; }
        public size dishSize { get; set; }
        public float dishPrice { get; set; }
        public hechsher Hechsher { get; set; }
        public int Calories { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();

            //string s;
            //s = "dish number: " + dishNumber + "\n"
            //    + "name: " + dishName + "\n"
            //    + "size: " + dishSize + "\n"
            //    + "Price: " + dishPrice + "\n"
            //    + "hechsher: " + Hechsher + "\n";
            //return s;
        }
    }
}
