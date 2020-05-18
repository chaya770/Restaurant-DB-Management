using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Costumer
    {
       //constructor
       public Costumer()
        {

        }
       public Costumer(string tzz,string costumername, int costumerage, string costumeradress,string costumeradressnow, int creditcard, bool mmembership)
       {
            tz = tzz;
           costumerName = costumername;
            if (costumerage < 18)
                throw new Exception("costumer age must be over 18...");
           costumerAge = costumerage;
           costumerAdress = costumeradress;
           costumerAdressNow = costumeradressnow;
           CreditCard = creditcard;
           membership = mmembership;
       }
        public string costumerName { get; set; }
        public string tz { get; set; }
        public int costumerAge { get; set; }
        public string costumerAdress { get; set; }
        public string costumerAdressNow { get; set; }
        public int CreditCard { get; set; }
        public bool membership { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();


        }
    }
    }
