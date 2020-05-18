using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        static int s=0;
        public Order()
        {
            
            string temp = "";
            for (int i = 0; i < 8 - ((s.ToString()).Length); i++)
                temp += "0";
            temp += s.ToString();
            orderNumber = temp;
            s += 1;
            numWorkers = 1;//one worker needed foe every order
        }
        
        //construcot for order that gets name and not a costumer
        public Order (string Costuertz, DateTime d, int branchnumber, hechsher h, int numworkers)
        {
            costumerTz = Costuertz;
            string temp = "";
            for (int i = 0; i < 8 - ((s.ToString()).Length); i++)
                temp += "0";
            temp += s.ToString();
            orderNumber = temp;
            s += 1;
            //initializes the rest of the details
            date = d;
            branchNumber = branchnumber;
            Hechsher = h;
            numWorkers = numworkers;
            numWorkers = 1;//one worker needed foe every order


        }

        public static int ordercounter = 0;
        const float maxPriceOfOrder = 400;
        public string costumerTz { get; set; }
        public float MaxPriceOfOrder
        {
            get { return maxPriceOfOrder; }
            set { }
        }

        public string orderNumber { get; set; }
        public DateTime date { get; set; }
        public int branchNumber { get; set; }
        public hechsher Hechsher { get; set; }
        public int numWorkers { get; set; }
      
        public override string ToString()
        {
            return this.ToStringProperty();

            //{
            //    string s;
            //    s = "Num Order: " + orderNumber
            //         + " \n" + "Time: " + date
            //         + "\n" + "Branch number: " + branchNumber
            //         + "\n" + "Hechsher: " + Hechsher
            //         + "\n" + "Costumer's Name: " + costumer.costumerName
            //         + "\n" + "Costumer's Address Now: " + costumer.costumerAdressNow;
            //    +"/n" + "Costumer's Address: " + costumerAdress
            //     + "/n" + "Credit Card Number: " + CreditCard;
            //    return s;

        }

    }
}
