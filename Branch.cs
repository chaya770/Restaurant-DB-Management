using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Branch
    {
        public Branch() { }
        //constructor
        public Branch(int branchnumber,city mycity, string branchname, string branchadress, string branchphonenumber, string manager, int branchnumworkers, int branchavailabledeliveryGuys, hechsher hhechsher)
        {
            branchNumber = branchnumber;
            branchName = branchname;
            Mycity = mycity;
            branchAdress = branchadress;
            branchPhoneNumber = branchphonenumber;
            Manager = manager;
            branchNumWorkers = branchnumworkers;
            branchAvailableDeliveryGuys = branchavailabledeliveryGuys;
            Hechsher = hhechsher;
        }
        public static int branchcounter=0;
        public int branchNumber { get; set; }
        public string branchName { get; set; }
        public string branchAdress { get; set; }
        //public enum city { jerusalem=1,TelAviv,RamatGan,BneiBrak,BeitShemesh,KiryatSefer};
        public city Mycity { get; set; }
        public string branchPhoneNumber { get; set; }
        public string Manager { get; set; }
        public int branchNumWorkers { get; set; }
        public int branchAvailableDeliveryGuys { get; set; }
        //enum hechsher { regular, medium, best };
        public hechsher Hechsher { get; set; }
        public override string ToString()
        {
            string s;
            s = "branch number: " + branchNumber + "\n"
                + "branch name: " + branchName + "\n"
                + "Address: " + branchAdress + "\n"
                + "Phone Number: " + branchPhoneNumber + "\n"
                + "manager: " + Manager + "\n"
                + "Number Of Workers: " + branchNumWorkers + "\n"
                + "Number Of available delivery guys: " + branchAvailableDeliveryGuys + "\n"
                + "Hechsher: " + Hechsher + "\n";
            return s;
        }
    }
}
