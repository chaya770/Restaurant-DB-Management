using BE;
using DS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace BL
{
    public class IBLbasiccs : IBL
    {

        DAL.Idal dal;
        public IBLbasiccs()
        {
            dal = DAL.FactoryDal.getDal();
            initializing();
        }
        public void initializing()
        {
            ////Costumer c = new Costumer("12345678","tehilla", 20, "55  fatal street", "same", 12352552, true);
            //this.AddCostumer(new Costumer("12345678", "tehilla", 19, "55  fatal street", "same", 69587458, false));
            //this.AddCostumer(new Costumer("54896588", "chaya", 20, "58 hachoze miloblin", "same", 65877485, true));
            //this.AddCostumer(new Costumer("25441578", "menachem", 22, "7 bet hadfos", "same", 25416352, true));
            //this.AddCostumer(new Costumer("36584557", "shani", 44, "9 hasavion", "same", 00236587, true));
            //this.AddCostumer(new Costumer("54875574", "odelya", 22, "44 shderot hadekel", "same", 87554784, false));

            //this.AddOrder(new Order("12345678", DateTime.Now, 123, hechsher.medium, 12));
            //this.AddOrder(new Order("25656556", DateTime.Now, 123, hechsher.medium, 4));

            //this.AddOrder(new Order("Haddas", DateTime.Parse("10/01/2016"), 123, hechsher.medium, 2));
            //this.AddOrder(new Order("Chani", DateTime.Parse("09/01/2016"), 124, hechsher.best, 12));

            //this.AddBranch(new Branch(123, city.BeitShemesh, "snif BeitShemesh", "yarkon 66", "026525485", "yosef", 4, 2, hechsher.best));
            //this.AddBranch(new Branch(122, city.KiryatSefer, "snif kiryat sefer", "fatal 66", "026885485", "netanel", 4, 2, hechsher.medium));

            //this.AddDish(new Dish(95, "pizza", size.large, 40, 6, hechsher.medium, 350));
            //this.AddDish(new Dish(96, "icecream", size.large, 18, 8, hechsher.best, 250));
            //this.AddDish(new Dish(97, "pasta", size.large, 62, 8, hechsher.regular, 500));
            //this.AddDish(new Dish(98, "falafel", size.large, 25, 7, hechsher.medium, 600));
            //this.AddDish(new Dish(99, "coffee", size.small, 10, 8, hechsher.best, 120));
            //this.AddDish(new Dish(94, "Salmon", size.small, 90, 8, hechsher.best, 120));
            //this.AddDish(new Dish(1, "free desert", size.large, 0, 10, hechsher.best, 250));//dish number 1 is a free dish


        }
        public bool AddDish(Dish dish)//adds a dish
        {
            if (dish.Calories <= 0)
                throw new Exception("dish calories not possible");
            if (dish.dishNumber < 0)
                throw new Exception("dish number not possible");
            if (dish.dishPrice < 0 && dish.dishPrice > 1000)
                throw new Exception("dish number not possible");
            if (dish.Rate <= 0 && dish.Rate > 10)
                throw new Exception("dish rate is in between 0 to 10");

            return dal.AddDish(dish);

        }
        public Dish getDish(int num)//find the first dish(for checking if it exist)
        {
            return dal.getDish(num);
        }
        public bool DeleteDish(int dishnumber)//delete a dish
        {
            return dal.DeleteDish(dishnumber);
        }
        public bool SetDish(Dish dish)//sets a dish
        {
            return dal.SetDish(dish);
        }

        public bool AddCostumer(Costumer c)//adds a Costumer
        {
            if(!(int.Parse(c.tz) >0&& (int.Parse(c.tz)<1000000000)))
                throw new Exception("costumer name numst be a string...try again please");
            
            if (c.costumerAge < 18)
                throw new Exception("costumer age under 18...try again please");

            return dal.AddCostumer(c);

        }
        public Costumer getCostumer(string num)//find the first Costumer(for checking if it exist)
        {
            return dal.getCostumer(num);
        }
        public bool DeleteCostumer(string dishnumber)//delete a Costumer
        {
            return dal.DeleteCostumer(dishnumber);
        }
        public bool SetCostumer(Costumer c)//sets a Costumer
        {
            return dal.SetCostumer(c);
        }

        public Branch getBranch(int num)//find the first branch(for checking if it exist)
        {
            return dal.getBranch(num);
        }
        public bool AddBranch(Branch branch)//adds a branch
        {
            if (branch.branchAvailableDeliveryGuys <= 0 )
                throw new Exception("branch num delivery guys must be a positive number");
            if (branch.branchNumber < 0)
                throw new Exception("branch num must be a positive number");
            if (branch.branchNumWorkers <= 0 )
                throw new Exception("branch num workers must be a positive number");

            return dal.AddBranch(branch);
        }
        public bool DeleteBranch(int numbranch)//delete a brech
        {
            return dal.DeleteBranch(numbranch);
        }
        public bool SetBranch(Branch branch)//sets a branch
        {
            return dal.SetBranch(branch);
        }

        public Order getOrder(string num)//find the first Order(for checking if it exists)
        {
            return dal.getOrder(num);
        }
        public bool AddOrder(Order order)//adds an Order
        {
            return dal.AddOrder(order);
        }
        public bool DeleteOrder(string orderNumber)//delete an order
        {
            return dal.DeleteOrder(orderNumber);
        }
        public bool SetOrder(Order order)//sets an Order-update
        {
            return dal.SetOrder(order);
        }

        public void AddOrderedDish(Ordered_Dish Odish)//adds an ordered dish
        {
            if (Odish.amountOfDish <= 0)
                throw new Exception("amount of dish isn't possible.. ");


            float p = totalprice(Odish.orderNumber);//total price be4 adding the new dish
            Dish d = dal.listDishes(s => s.dishNumber == Odish.dishNumber).FirstOrDefault();
            Order o =dal.listOreders(s => s.orderNumber == Odish.orderNumber).FirstOrDefault();
            DateTime dd = DateTime.Now;
            DateTime ed = o.date;
            if (ed.Year < dd.Year || (ed.Year == dd.Year && ed.Month < dd.Month) || (ed.Year == dd.Year && ed.Month == dd.Month && ed.Day < dd.Day))
                throw new Exception("cant add ordered dish to an old order");
            Branch b = dal.listBranch(t => t.branchNumber == o.branchNumber).FirstOrDefault();
            Ordered_Dish od = dal.listorderedDishes(s => (s.dishNumber == Odish.dishNumber) && (s.orderNumber == Odish.orderNumber)).FirstOrDefault();

            if ((p + (d.dishPrice * Odish.amountOfDish)) > o.MaxPriceOfOrder)//checking that the total order pride isn't out of range
            {
                throw new Exception("cannot add dish,price of order is out of range ");
            }
            else if (b.branchAvailableDeliveryGuys - o.numWorkers < 0)
                throw new Exception("cannot add dish,there aren't enough workers in the branch for this order ");

            else if (d.Hechsher < o.Hechsher)//if the hechsher of the dish is lower than the hechsher of the order
            {

                // throw exception 
                throw new Exception("cannot add dish,hechsher isn't good enough... ");

            }
            else if (!(dishExistInList(Odish.dishNumber) && branchExistInList(o.branchNumber)))//dish or branch do not exist
            {
                throw new Exception("cannot add dish,the dish or the branch don't exist... ");
            }
            if (od == null)
            {
                dal.AddOrderedDish(Odish);
            }
            else
            {
                Ordered_Dish odnew = new Ordered_Dish(od.dishNumber, od.orderNumber, od.amountOfDish + Odish.amountOfDish);
                dal.SetOrderedDish(odnew);
            }
        }
        public bool DeleteOrderedDish(int dishnumber, string numorder)//delete an ordered dish
        {
            return dal.DeleteOrderedDish(dishnumber, numorder);
        }
        public bool SetOrderedDish(Ordered_Dish dish)//sets an ordered dish
        {
            return dal.SetOrderedDish(dish);
        }

        public IEnumerable<Order> listOreders()//gets all orders
        {
            return dal.listOreders();
        }
        public IEnumerable<Dish> listDishes()//gets all dishes
        {
            return dal.listDishes();
        }
        public IEnumerable<Branch> listBranch()//gets all branches
        {
            return dal.listBranch();
        }
        public IEnumerable<Ordered_Dish> listorderedDishes(Func<Ordered_Dish, bool> predicat = null)//gets all ordered dishes 
        {
            return dal.listorderedDishes();
        }
        public IEnumerable<Costumer> listCostumers()
        {
            return dal.listCostumers();
        }
        public void AddLineToBill(Bill b)
        {

            dal.addLineToBill(b);

        }
        public List<Bill> listBill()
        {
            return dal.listBill();
        }
        public List<Bill> calcBill(string orderNum)
        {
            List<Bill> bbb = new List<Bill>();
            IEnumerable<Ordered_Dish> result = from Ordered_Dish item in dal.listorderedDishes()
                                               where item.orderNumber == orderNum
                                               select item;

            foreach (Ordered_Dish item in result)
            {
                Dish di = dal.listDishes(s => s.dishNumber == item.dishNumber).FirstOrDefault();
                Bill b = new Bill(di.dishName,item.amountOfDish,(int)di.dishPrice*item.amountOfDish);
                bbb.Add(b);
            }
           return bbb;

        }
        public float totalprice(string ordernumber)//total price
        {
            IEnumerable<Ordered_Dish> result = dal.listorderedDishes(item => item.orderNumber == ordernumber);//small list of all orders with the same order number
            float sum = 0;
            foreach (var item in result)
            {
                Dish d =dal.listDishes(s => s.dishNumber == item.dishNumber).FirstOrDefault();
                sum += ((d.dishPrice) * (item.amountOfDish));//calculates the total price
            }
            var result2 = from order in dal.listOreders()
                          where order.orderNumber == ordernumber
                          select order.costumerTz;

            foreach (var costumerr in result2)
            {
                Costumer cos = dal.listCostumers(item => item.tz == costumerr).FirstOrDefault();
                //IEnumerable<Costumer> cos = dal.listCostumers(item => item.tz == costumerr);//small list of all orders with the same order number
                if(cos!=null)
                if (cos.membership == true)//if he is a membership so it is 10 percent off
                {
                    sum -= sum / 10;
                    return sum;
                }
            }



            return sum;
        }
        public float totalPriceWithTip(string orderNumber, int tip)//total price
        {
            float withTip = totalprice(orderNumber) + tip;
            return withTip;

        }


        public bool dishExistInList(int dishnumber)
        {
            if (dal.listDishes(s => s.dishNumber == dishnumber).Any())
                return true;
            return false;
            //IEnumerable<Dish> existList = from Dish item in DataSource.dishList
            //                              where item.dishNumber == dishnumber
            //                              select item;

            //if (existList.Count() == 0)
            //    return false;
            //return true;

        }
        public bool branchExistInList(int branchNumber)
        {
            if (dal.listBranch(s => s.branchNumber == branchNumber).Any())
                return true;
            return false;
        }



        public IEnumerable<IGrouping<int, Ordered_Dish>> groupbyKindOfDish()//prints the benifits from every dish
        {
            //float sum;
            IEnumerable<IGrouping<int, Ordered_Dish>> result = from n in dal.listorderedDishes()
                                                               group n by n.dishNumber into g
                                                               select g;
            return result;
            //foreach (IGrouping<int, Ordered_Dish> item in result)
            //{
            //    sum = 0;
               
            //    Dish di = DataSource.dishList.FirstOrDefault(s => s.dishNumber == item.Key);
            //    foreach (Ordered_Dish item2 in item)
            //    {

            //        sum += di.dishPrice * item2.amountOfDish;

            //    }
               
            //    Console.WriteLine("the benifit for dish :" + di.dishName + " is: " + sum);
            //}
           

        }

        public IEnumerable<IGrouping<BE.hechsher, Dish>> groupByHechsher()//groups by dish hechsher
        {
            IEnumerable<IGrouping<BE.hechsher, Dish>> result = from n in dal.listDishes()
                         group n by n.Hechsher into g
                         select g;
            return result;
            //foreach (var g in result)
            //{
            //    switch (g.Key)
            //    {
            //        case hechsher.best:
            //            Console.WriteLine("hechsher best:");
            //            foreach (Dish n in g)
            //                Console.Write("{0}, ", n.dishName);
            //            Console.WriteLine('\n');
            //            break;
            //        case hechsher.medium:
            //            Console.WriteLine("hechsher medium:");
            //            foreach (Dish n in g)
            //                Console.Write("{0}, ", n.dishName);
            //            Console.WriteLine('\n');
            //            break;
            //        case hechsher.regular:
            //            Console.WriteLine("hechsher regular:");
            //            foreach (Dish n in g)
            //                Console.Write("{0}, ", n.dishName);
            //            Console.WriteLine('\n');
            //            break;
            //    }
          //  }
        }

        public IEnumerable<IGrouping<BE.city, Ordered_Dish>> groupByCity()//benifits from each city(there are 6 different citys)
        {

            IEnumerable<IGrouping<BE.city, Ordered_Dish>> result = from n in dal.listorderedDishes()
                                                                let or = dal.listOreders(s => s.orderNumber == n.orderNumber).FirstOrDefault()
                                                                let br = dal.listBranch(s => s.branchNumber == or.branchNumber).FirstOrDefault()
                                                                group n by br.Mycity  into g
                                                                select g;
            return result;
            //foreach (IGrouping<bool, Ordered_Dish> g in result)
            //{
            //    float sum = 0;
            //    if (g.Key == true)
            //    {
            //        foreach (Ordered_Dish item in result)
            //        {
            //            Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == item.dishNumber);
            //            sum += d.dishPrice * item.amountOfDish;
            //        }
            //    }
            //    Console.WriteLine("the prifot in your area is:" + sum);
            //    //switch (g.Key)
                //{
                //    case city.KiryatSefer:
                //         float sum1 = 0;
                //        Console.WriteLine("benifits in Kiryat Sefer:");
                //        foreach (Ordered_Dish n in g)
                //        {
                //            Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
                //             sum1+=d.dishPrice*n.amountOfDish;
                //        }
                //            Console.Write(sum1+ "shekel");
                //        Console.WriteLine('\n');
                //        break;
                //    case city.jerusalem:
                //        float sum2 = 0;
                //        Console.WriteLine("benifits in Jerusalem:");
                //        foreach (Ordered_Dish n in g)
                //        {
                //            Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
                //             sum2+=d.dishPrice*n.amountOfDish;
                //        }
                //            Console.Write(sum2+ "shekel");
                //        Console.WriteLine('\n');
                //    case city.TelAviv:
                //        float sum3 = 0;
                //        Console.WriteLine("benifits in Tel Aviv:");
                //        foreach (Ordered_Dish n in g)
                //        {
                //            Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
                //             sum3+=d.dishPrice*n.amountOfDish;
                //        }
                //            Console.Write(sum3+ "shekel");
                //        Console.WriteLine('\n');
                //    case city.RamatGan:
                //        float sum4 = 0;
                //        Console.WriteLine("benifits in Ramat Gan:");
                //        foreach (Ordered_Dish n in g)
                //        {
                //            Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
                //             sum4+=d.dishPrice*n.amountOfDish;
                //        }
                //            Console.Write(sum4+ "shekel");
                //        Console.WriteLine('\n');
                //    case city.BneiBrak:
                //        float sum5 = 0;
                //        Console.WriteLine("benifits in Bnei Brak:");
                //        foreach (Ordered_Dish n in g)
                //        {
                //            Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
                //             sum5+=d.dishPrice*n.amountOfDish;
                //        }
                //            Console.Write(sum5+ "shekel");
                //        Console.WriteLine('\n');
                //    case city.BeitShemesh:
                //        float sum6 = 0;
                //        Console.WriteLine("benifits in Beit Shemesh:");
                //        foreach (Ordered_Dish n in g)
                //        {
                //            Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
                //             sum6+=d.dishPrice*n.amountOfDish;
                //        }
                //            Console.Write(sum6+ "shekel");
                //        Console.WriteLine('\n');

                //}
            }
       

        public IEnumerable<IGrouping<int, Ordered_Dish>> groupByTime()//groups orders by days(time)
        {
            IEnumerable<IGrouping<int, Ordered_Dish>> result = from n in dal.listorderedDishes()
                                                               let or = dal.listOreders(s => s.orderNumber == n.orderNumber).FirstOrDefault()
                                                               let di = dal.listDishes(s => s.dishNumber == n.dishNumber).FirstOrDefault()
                                                               group n by ((int)or.date.DayOfWeek) into g
                                                               select g;

            return result;
            //foreach (IGrouping<int, Ordered_Dish> g in result)
            //{

            //    switch (g.Key)
            //    {


            //        case 1:
            //            float sum1 = 0;
            //            //Console.WriteLine("Orders on Sunday: ");
            //            foreach (Ordered_Dish n in g)
            //            {
            //                Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
            //                sum1 += d.dishPrice * n.amountOfDish;
            //                //Console.Write("{0}, ", n.ToString());//prints order details
            //            }
            //            Console.WriteLine("the total benifit on sundays is: " + sum1);
            //            Console.WriteLine('\n');
            //            break;

            //        case 2:
            //            float sum2 = 0;
            //            //Console.WriteLine("Orders on Monday: ");
            //            foreach (Ordered_Dish n in g)
            //            {
            //                Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
            //                sum2 += d.dishPrice * n.amountOfDish;
            //                //Console.Write("{0}, ", n.ToString());//prints order details
            //            }
            //            Console.WriteLine("the total benifit on Monday is: " + sum2);
            //            Console.WriteLine('\n');
            //            break;

            //        case 3:
            //            float sum3 = 0;
            //            //Console.WriteLine("Orders on Tuesday: ");
            //            foreach (Ordered_Dish n in g)
            //            {
            //                Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
            //                sum3 += d.dishPrice * n.amountOfDish;
            //                //Console.Write("{0}, ", n.ToString());//prints order details
            //            }
            //            Console.WriteLine("the total benifit on Tuesday is: " + sum3);
            //            Console.WriteLine('\n');
            //            break;

            //        case 4:
            //            float sum4 = 0;
            //            //Console.WriteLine("Orders on Wednsday: ");
            //            foreach (Ordered_Dish n in g)
            //            {
            //                Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
            //                sum4 += d.dishPrice * n.amountOfDish;
            //                //Console.Write("{0}, ", n.ToString());//prints order details
            //            }
            //            Console.WriteLine("the total benifit on Wednsday is: " + sum4);
            //            Console.WriteLine('\n');
            //            break;

            //        case 5:
            //            float sum5 = 0;
            //            //Console.WriteLine("Orders on Thursday: ");
            //            foreach (Ordered_Dish n in g)
            //            {
            //                Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
            //                sum5 += d.dishPrice * n.amountOfDish;
            //                //Console.Write("{0}, ", n.ToString());//prints order details
            //            }
            //            Console.WriteLine("the total benifit on Thursday is: " + sum5);
            //            Console.WriteLine('\n');
            //            break;

            //        case 6:
            //            float sum6 = 0;
            //            //Console.WriteLine("Orders on friday: ");
            //            foreach (Ordered_Dish n in g)
            //            {
            //                Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
            //                sum6 += d.dishPrice * n.amountOfDish;
            //                //Console.Write("{0}, ", n.ToString());//prints order details
            //            }
            //            Console.WriteLine("the total benifit on Friday is: " + sum6);
            //            break;

            //        case 7:
            //            float sum7 = 0;
            //            //Console.WriteLine("Orders on Sat. Night: ");
            //            foreach (Ordered_Dish n in g)
            //            {
            //                Dish d = DataSource.dishList.FirstOrDefault(s => s.dishNumber == n.dishNumber);
            //                sum7 += d.dishPrice * n.amountOfDish;
            //                //Console.Write("{0}, ", n.ToString());//prints order details
            //            }
            //            Console.WriteLine("the total benifit on Saterday Night (motzei shabbat)  is: " + sum7);
            //            Console.WriteLine('\n');
            //            break;

            //    }



            }
        

        public void groupBySize()//groups by dish size
        {
            IEnumerable<IGrouping<size, Dish>> result = from n in dal.listDishes()
                                                        group n by n.dishSize into g
                                                        select g;
            foreach (IGrouping<size, Dish> g in result)
            {
                switch (g.Key)
                {
                    case size.large:
                        Console.WriteLine("large size dishes:");
                        foreach (Dish n in g)
                            Console.Write("{0}, ", n.dishName);
                        Console.WriteLine('\n');
                        break;
                    case size.medium:
                        Console.WriteLine("medium size dishes:");
                        foreach (Dish n in g)
                            Console.Write("{0}, ", n.dishName);
                        Console.WriteLine('\n');
                        break;
                    case size.small:
                        Console.WriteLine("small size dishes:");
                        foreach (Dish n in g)
                            Console.Write("{0}, ", n.dishName);
                        Console.WriteLine('\n');
                        break;
                }
            }
        }

        public void groupByprice()//groups by dish price
        {
            IEnumerable<IGrouping<bool, Dish>> result = from n in dal.listDishes()
                                                        group n by n.dishPrice > 60 into g
                                                        select g;
            foreach (IGrouping<bool, Dish> g in result)
            {
                switch (g.Key)
                {
                    case true:
                        Console.WriteLine("dishes with price over 60 : ");
                        foreach (Dish n in g)
                            Console.Write("{0}, ", n.dishName);
                        Console.WriteLine('\n');
                        break;
                    case false:
                        Console.WriteLine("dishes with price under 60 :");
                        foreach (Dish n in g)
                            Console.Write("{0}, ", n.dishName);
                        break;


                }
            }
        }

        public int caloriesIndish(string Dishname)//returns the num of calories in specific dish
        {

            Dish d = dal.listDishes(s => s.dishName == Dishname).FirstOrDefault();
            return d.Calories;
        }
        public float averageCaloriesPerPerson(string orderNumber)//return the average of calories per person
        {

            IEnumerable<Ordered_Dish> result = dal.listorderedDishes(item => item.orderNumber == orderNumber);//small list of all orders with the same order number
            float sum = 0;
            int numdishes = 0;
            foreach (var item in result)
            {
                Dish d = dal.listDishes(s => s.dishNumber == item.dishNumber).FirstOrDefault();
                sum += (d.Calories * (item.amountOfDish));//calculates the total price
                numdishes += item.amountOfDish;
            }
            return sum / numdishes;
        }


        public int totalCalories(string orderNumber)//returns the tatal of calories in order
        {
            IEnumerable<Ordered_Dish> result = dal.listorderedDishes(item => item.orderNumber == orderNumber);//small list of all orders with the same order number
            int sum = 0;

            foreach (var item in result)
            {
                Dish d = dal.listDishes(s => s.dishNumber == item.dishNumber).FirstOrDefault();
                sum += ((d.Calories) * (item.amountOfDish));//calculates the total price
            }

            return sum;
        }

        public bool NumDisheBiggerThan8(string orderNumber)//checks if the order has 8 dishes or more
        {
            IEnumerable<Ordered_Dish> result = dal.listorderedDishes(item => item.orderNumber == orderNumber);//small list of all orders with the same order number
            int numdishes = 0;
            foreach (var item in result)
            {
                numdishes += item.amountOfDish;
            }
            if (numdishes >= 8)
                return true;
            return false;
        }

        public bool freedesert(string orderNumber)//if the order has 8 or more dishes or payed more than 300 for the orderhe gets a free desert
        {
            if (NumDisheBiggerThan8(orderNumber)||((totalprice(orderNumber)>=300)))
            {

                Dish freeDesert =  dal.listDishes(s => s.dishNumber == 1).FirstOrDefault();

                //AddDish(freeDesert);
                Ordered_Dish d = new Ordered_Dish(1, orderNumber, 1);
                AddOrderedDish(d);
                //System.Windows.Forms.MessageBox.Show("Test");
                return true;
            }
            return false;
        }

        //dish 
        public List<BE.Dish> dishListByOrderNumber(string o)
        {
            Dish dd;
            List<BE.Dish> d = new List<Dish>();
            List<BE.Ordered_Dish> v = new List<BE.Ordered_Dish>(listorderedDishes().Where(s => s.orderNumber == o));
            foreach (var item in v)
            {
                dd= dal.listDishes(s => s.dishNumber == item.dishNumber).FirstOrDefault();
                d.Add(dd);
            }
            return d;
        }
        List<BE.Dish> IBL.dishUnderCondition(Predicate<BE.Dish> condition)
        {
            List<BE.Dish> v = new List<BE.Dish>(listDishes().Where(s => condition(s)));
            return v;

        }
        public bool ConDishesHechsherBest(Dish d)//(condition for the delegate)checks if the hechsher is best
        {
            hechsher b = (hechsher)3;//best
            if (d.Hechsher == b)
                return true;
            return false;


        }
        public bool ConDishesHechsherMedium(Dish d)//(condition for the delegate)checks if the hechsher is medium
        {
            hechsher b = (hechsher)2;
            if (d.Hechsher == b)
                return true;
            return false;


        }
        public bool ConDishesHechsherRegular(Dish d)//(condition for the delegate)checks if the hechsher is regular
        {
            hechsher b = (hechsher)1;
            if (d.Hechsher == b)
                return true;
            return false;


        }
        public bool ConDishesMaxPrice(Dish d, int MaxPrice)//NO NEED THIS FUNCTION
        {
            if (d.dishPrice <= MaxPrice)
                return true;
            return false;
        }
        public List<BE.Dish> DishesByMaxPrice(int MaxPrice)
        {

            List<BE.Dish> v = new List<BE.Dish>(listDishes().Where(s => s.dishPrice <= MaxPrice));
            return v;

        }
        public List<BE.Dish> DishesByMinRate(int rate)
        {

            List<BE.Dish> v = new List<BE.Dish>(listDishes().Where(s => s.Rate >= rate));
            return v;

        }
        public List<BE.Dish> DishesByMaxCalories(int MaxCalories)
        {

            List<BE.Dish> v = new List<BE.Dish>(listDishes().Where(s => s.Calories <= MaxCalories));
            return v;

        }
        public bool ConDishesSizeSmall(Dish d)//(condition for the delegate)checks if the size is small
        {
            size s = (size)1;//small
            if (d.dishSize == s)
                return true;
            return false;


        }
        public bool ConDishesSizeMedium(Dish d)//(condition for the delegate)checks if the size is medium
        {
            size s = (size)2;//medium
            if (d.dishSize == s)
                return true;
            return false;



        }
        public bool ConDishesSizeMediumLarge(Dish d)//(condition for the delegate)checks if the size is large
        {
            size s = (size)3;//large
            if (d.dishSize == s)
                return true;
            return false;


        } 
        public Dish DishByNumber(int num)
        {
           return dal.listDishes(s => s.dishNumber == num).FirstOrDefault();
        }
        public Dish DishByName(string name)
        {
            return dal.listDishes(s => s.dishName==name).FirstOrDefault();
        }

        //brunch
        public Branch BranchByNumber(int num)
        {
            Branch b= dal.listBranch(s => s.branchNumber == num).FirstOrDefault();
            if (b==null)
                throw new Exception("no such branch number, try again:)");
            return b;
        }
        public List<BE.Branch> BranchByName(string name)
        {
            List<BE.Branch> v = new List<BE.Branch>(listBranch().Where(s => s.branchName == name));
            if (v.Count == 0)
                throw new Exception("no such name of branch, try again:)");
            return v;
        }
        List<BE.Branch> IBL.branchUnderCondition(Predicate<BE.Branch> condition)
        {
            List<BE.Branch> v = new List<BE.Branch>(listBranch().Where(s => condition(s)));
            return v;

        }
        public bool ConBranchHechsherBest(Branch d)//(condition for the delegate)checks if the hechsher is best
        {
            hechsher b = (hechsher)3;//best
            if (d.Hechsher == b)
                return true;
            return false;


        }
        public bool ConBranchHechsherMedium(Branch d)//(condition for the delegate)checks if the hechsher is medium
        {
            hechsher b = (hechsher)2;
            if (d.Hechsher == b)
                return true;
            return false;


        }
        public bool ConBranchHechsherRegular(Branch d)//(condition for the delegate)checks if the hechsher is regular
        {
            hechsher b = (hechsher)1;
            if (d.Hechsher == b)
                return true;
            return false;


        }
        public bool ConBranchCityJerysalem(Branch d)
        {
           city c= (city)1;
            if (d.Mycity == c)
                return true;
            return false;
        }
        public  bool ConBranchCityTelAviv(Branch d)
        {
            city c = (city)2;
            if (d.Mycity == c)
                return true;
            return false;
        }
        public bool ConBranchCityJRamatGan(Branch d)
        {
            city c = (city)3;
            if (d.Mycity == c)
                return true;
            return false;
        }
        public bool ConBranchCityBneiBrak(Branch d)
        {
            city c = (city)4;
            if (d.Mycity == c)
                return true;
            return false;
        }
        public bool ConBranchCityBeitShemesh(Branch d)
        {
            city c = (city)5;
            if (d.Mycity == c)
                return true;
            return false;
        }
        public  bool ConBranchCityKiryatSefer(Branch d)
        {
            city c = (city)6;
            if (d.Mycity == c)
                return true;
            return false;
        }
        //costumer
        public Costumer CostumerById(string id)
        {
            Costumer c= dal.listCostumers(s => s.tz == id).FirstOrDefault();
            if (c == null)
                throw new Exception("no costumer with such id, try again:)");
            return c;
        }
        public Costumer CostumerByName(string name)
        {
            Costumer v = dal.listCostumers(s => s.costumerName == name).FirstOrDefault();
            if (v == null)
                throw new Exception("no such name of costumer, try again:)");
            return v;
        }
        List<BE.Costumer> IBL.costumerUnderCondition(Predicate<BE.Costumer> condition)
        {
            List<BE.Costumer> v = new List<BE.Costumer>(listCostumers().Where(s => condition(s)));
            return v;

        }
        public bool ConCostumerMemberShip(Costumer c)
        {
            if (c.membership)
                return true;
            else return false;
        }
        //order 
        public Order OrderByNumber(string num)
        {
            return dal.listOreders(s => s.orderNumber == num).FirstOrDefault();
        }
        public List<BE.Order> OrderByBranch(int num)
        {

            List<BE.Order> v = new List<BE.Order>(listOreders().Where(s => s.branchNumber == num));
            return v;
        }
        List<BE.Order> IBL.orderUnderCondition(Predicate<BE.Order> condition)
        {
            List<BE.Order> v = new List<BE.Order>(listOreders().Where(s => condition(s)));
            return v;
        }
        public bool conOrderHechsher1(Order or)//(condition for the delegate)checks if the hechsher is best
        {
            hechsher b = (hechsher)3;
            if (or.Hechsher == b)
                return true;
            return false;


        }
        public bool conOrderHechsher2(Order or)//(condition for the delegate)checks if the hechsher is medium
        {
            hechsher b = (hechsher)2;
            if (or.Hechsher == b)
                return true;
            return false;


        }
        public bool conOrderHechsher3(Order or)//(condition for the delegate)checks if the hechsher is regular
        {
            hechsher b = (hechsher)1;
            if (or.Hechsher == b)
                return true;
            return false;


        }
        public List<BE.Order> conOrderMonth(DateTime d)
        {
            List<BE.Order> v = new List<BE.Order>(listOreders().Where(s =>( s.date.Day == d.Day)&& (s.date.Month== d.Month)&&(s.date.Year==d.Year)));
            return v;
        }

        //orderd dish
        public List<BE.Ordered_Dish> ordereddishbydishnumber(int st)
        {
            List<BE.Ordered_Dish> v = new List<BE.Ordered_Dish>(listorderedDishes().Where(s => s.dishNumber == st));
            return v;

        }
        public List<BE.Ordered_Dish> ordereddishbyordernumber(string st)
        {
            List<BE.Ordered_Dish> v = new List<BE.Ordered_Dish>(listorderedDishes().Where(s => s.orderNumber == st));

            return v;

        }
        public List<BE.Ordered_Dish> ordereddishbyamount(int st)
        {
            List<BE.Ordered_Dish> v = new List<BE.Ordered_Dish>(listorderedDishes().Where(s => s.amountOfDish == st));
            return v;

        }
    }
}
//our functions
//total price with tip
//10 percent off for membership
//calories per dish
//avg of calories
//total calories
//free desert
//grouping dishes by size(3 groups)
//grouping dishes by hechsher(3 groups)
//grouping dishes by price(2 groups:more than 60 and under..)
//bill
