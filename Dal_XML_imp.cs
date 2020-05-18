using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace DAL
{
    class Dal_XML_imp:Idal
    {
       // static int dishnumber = 100;
       // static int branchnumber = 1;

        XElement countersRoot;
        string countersPath = @"configXml.xml";

        XElement costumerRoot;
        string costumerPath = @"CostumerXml.xml";

        XElement ordereddishRoot;
        string ordereddishPath = @"OrderedDishXml.xml";

        XElement branchRoot;
        string branchPath = @"BranchXml.xml";

        XElement orderRoot;
        string orderPath = @"OrderXml.xml";


        XElement dishRoot;
        string dishPath = @"DishXml.xml";

        //temp counters to update...
        BE.Counter branch_id_counter = new Counter("branch_id_counter", 0);
        BE.Counter dish_id_counter = new Counter("dish_id_counter", 0);
        BE.Counter order_id_counter = new Counter("order_id_counter", 0);
        #region counter
        private void loadCountersFiles()
        {
            try
            {
                countersRoot = XElement.Load(countersPath);
            }
            catch
            {
                throw new Exception("Counters File upload problem");
            }
        }

        XElement ConvertCounter(BE.Counter counter)//converts for Counter to XElement
        {
            XElement counterElement = new XElement("counter");
            foreach (PropertyInfo item in typeof(Counter).GetProperties())
            {
                counterElement.Add(new XElement(item.Name, item.GetValue(counter, null)));
            }
            return counterElement;
        }
        BE.Counter ConvertCounter(XElement element)//converts for XElement to Counter  
        {
            Counter counter = new Counter();
            foreach (PropertyInfo item in typeof(BE.Counter).GetProperties())
            {
                TypeConverter typeconverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeconverter.ConvertFromString(element.Element(item.Name).Value);
                item.SetValue(counter, convertValue);
            }
            return counter;
        }
#endregion

        public Dal_XML_imp()
        {
           
            CreateFiles();
            LoadData();

            if (!File.Exists(countersPath))
            {
                countersRoot = new XElement("counters");
                countersRoot.Save(countersPath);
                BE.Counter branch_id_counter = new Counter("branch_id_counter", 0);
                BE.Counter dish_id_counter = new Counter("dish_id_counter", 0);
                BE.Counter order_id_counter = new Counter("order_id_counter", 0);
                countersRoot.Add(ConvertCounter(branch_id_counter));
                countersRoot.Add(ConvertCounter(dish_id_counter));
                countersRoot.Add(ConvertCounter(order_id_counter));
                countersRoot.Save(countersPath);
            }
            else {

                loadCountersFiles();
               
                XElement d = (from item in countersRoot.Elements()
                              where item.Element("name").Value == "dish_id_counter"
                              select item).FirstOrDefault();
                BE.Dish.dishnumbercounter = ConvertCounter(d).value;

                XElement b = (from item in countersRoot.Elements()
                              where item.Element("name").Value == "branch_id_counter"
                              select item).FirstOrDefault();
                BE.Branch.branchcounter = ConvertCounter(b).value;

                XElement o = (from item in countersRoot.Elements()
                              where item.Element("name").Value == "order_id_counter"
                              select item).FirstOrDefault();
                BE.Order.ordercounter = ConvertCounter(o).value;
            }
          

        }
    
        private void CreateFiles()
        {
            if (!File.Exists(costumerPath))
            {
                costumerRoot = new XElement("Cosumer");
                costumerRoot.Save(costumerPath);
            }
            if (!File.Exists(branchPath))
            {

                branchRoot = new XElement("Branch");
                branchRoot.Save(branchPath);
            }
            if (!File.Exists(ordereddishPath))
            {
                ordereddishRoot = new XElement("Ordered_Dish");
                ordereddishRoot.Save(ordereddishPath);
            }
            if (!File.Exists(orderPath))
            {
                orderRoot = new XElement("Order");
                orderRoot.Save(orderPath);
            }
            if (!File.Exists(dishPath))
            {
                dishRoot = new XElement("Dish");
                dishRoot.Save(dishPath);
            }
        }


        private void LoadData()
        {
            try
            { 
                ordereddishRoot = XElement.Load(ordereddishPath);
                costumerRoot = XElement.Load(costumerPath);
                dishRoot = XElement.Load(dishPath);
                branchRoot = XElement.Load(branchPath);
                orderRoot = XElement.Load(orderPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
       
        #region Costumer
        public XElement ConvertCostemer(BE.Costumer d)//converts from  to Costumer to Exelemnt 
        {
            XElement costumerElement = new XElement("Costumer");

            foreach (PropertyInfo item in typeof(BE.Costumer).GetProperties())
                costumerElement.Add
                    (
                    new XElement(item.Name, item.GetValue(d, null))
                    );

            return costumerElement;
        }
        public BE.Costumer ConvertCostemer(XElement element)//converts from XElement to Costumer 
        {
            Costumer d = new Costumer();

            foreach (PropertyInfo item in typeof(BE.Costumer).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(d, convertValue);
            }

            return d;
        }
        public IEnumerable<Costumer> listCostumers(Func<Costumer, bool> predicat = null)
        {

            LoadData();
            if (predicat == null)
            {
                List<Costumer> cost;
                try
                {
                    cost = (from p in costumerRoot.Elements()
                            select new Costumer()
                            {
                                tz = p.Element("tz").Value,
                                costumerName = p.Element("costumerName").Value,
                                costumerAge = Convert.ToInt32(p.Element("costumerAge").Value),
                                costumerAdress = p.Element("costumerAdress").Value,
                                costumerAdressNow = p.Element("costumerAdressNow").Value,
                                CreditCard = Convert.ToInt32(p.Element("CreditCard").Value),
                                membership = Convert.ToBoolean(p.Element("membership").Value)
                            }).ToList();
                }
                catch
                {
                    cost = null;
                }
                return cost;
            }
            else 
            {
                return from item in costumerRoot.Elements()
                       let s = ConvertCostemer(item)
                       where predicat(s)
                       select s;
            }
            
        }
        public Costumer getCostumer(string num)//checks if the Costumer  already exist
        {
            LoadData();
            Costumer c;
            try
            {
                c = (from p in costumerRoot.Elements()
                           where p.Element("tz").Value == num
                           select new Costumer()
                           {
                               tz = p.Element("tz").Value,
                               costumerName = p.Element("costumerName").Value,
                               costumerAge = Convert.ToInt32(p.Element("costumerAge").Value),
                               costumerAdress = p.Element("costumerAdress").Value,
                               costumerAdressNow = p.Element("costumerAdressNow").Value,
                               CreditCard = Convert.ToInt32(p.Element("CreditCard").Value),
                               membership = Convert.ToBoolean(p.Element("membership").Value)
                           }).FirstOrDefault();
            }
            catch
            {
                c = null;
            }
            return c;
            
        }
        public bool AddCostumer(Costumer c)//adds a Costumer
        {

                if (c.costumerAge < 18)
                throw new Exception("costumer age under 18...try again please");
            if (c.tz != " 00000000")
            {
                Costumer d = getCostumer(c.tz);
                if (d == null)
                {
                    XElement tz = new XElement("tz", c.tz);
                    XElement costumerName = new XElement("costumerName", c.costumerName);
                    XElement costumerAge = new XElement("costumerAge", c.costumerAge);
                    XElement costumerAdress = new XElement("costumerAdress", c.costumerAdress);
                    XElement costumerAdressNow = new XElement("costumerAdressNow", c.costumerAdressNow);
                    XElement CreditCard = new XElement("CreditCard", c.CreditCard);
                    XElement membership = new XElement("membership", c.membership);
                    costumerRoot.Add(new XElement("costumer", tz, costumerName, costumerAge, costumerAdress, costumerAdressNow, CreditCard, membership));
                    costumerRoot.Save(costumerPath);

                    return true;
                }
                else throw new Exception("can not add costumer,costumer already exists");
                //return false;//already exist in the list
            }
            else
            {

                //c.tz = "brerat-mechdal";
                XElement tz = new XElement("tz", c.tz);
                XElement costumerName = new XElement("costumerName", c.costumerName);
                XElement costumerAge = new XElement("costumerAge", c.costumerAge);
                XElement costumerAdress = new XElement("costumerAdress", c.costumerAdress);
                XElement costumerAdressNow = new XElement("costumerAdressNow", c.costumerAdressNow);
                XElement CreditCard = new XElement("CreditCard", c.CreditCard);
                XElement membership = new XElement("membership", c.membership);
                costumerRoot.Add(new XElement("costumer", tz, costumerName, costumerAge, costumerAdress, costumerAdressNow, CreditCard, membership));
                costumerRoot.Save(costumerPath);

                return true;
            }
        }
        public bool DeleteCostumer(string costnum)//delete a Costumer
        {
     


            XElement costumerElement;
            try
            {
                costumerElement = (from p in costumerRoot.Elements()
                                  where p.Element("tz").Value == costnum
                                  select p).FirstOrDefault();
                if (costumerElement != null)
               
                    costumerElement.Remove();
                    costumerRoot.Save(costumerPath);
                    return true;
                
            }
            catch
            {
                return false;
            }
        
    }
        public bool SetCostumer(Costumer c)//sets a Costumer
        {
           

            XElement costumerElement = (from p in costumerRoot.Elements()
                                       where p.Element("tz").Value == c.tz
                                       select p).FirstOrDefault();
            if (costumerElement != null)
            {
                costumerElement.Element("costumerName").Value = c.costumerName;
                costumerElement.Element("costumerAge").Value = Convert.ToString(c.costumerAge);
                costumerElement.Element("tz").Value = c.tz;
                costumerElement.Element("costumerAdress").Value = c.costumerAdress;
                costumerElement.Element("costumerAdressNow").Value = c.costumerAdressNow;
                costumerElement.Element("CreditCard").Value = Convert.ToString(c.CreditCard);
                costumerElement.Element("membership").Value = Convert.ToString(c.membership);

                costumerRoot.Save(costumerPath);
                return true;
            }
            return false;
        }
        #endregion
        #region Dish
        public XElement ConvertDish(BE.Dish d)//converts form XElement Dish  
        {
            XElement dishElement = new XElement("Dish");

            foreach (PropertyInfo item in typeof(BE.Dish).GetProperties())
                dishElement.Add
                    (
                    new XElement(item.Name, item.GetValue(d, null))
                    );

            return dishElement;
        }
        public BE.Dish ConvertDish(XElement element)//converts from Dish to XElement
        {
            Dish d = new Dish();

            foreach (PropertyInfo item in typeof(BE.Dish).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(d, convertValue);
            }

            return d;
        }
        public Dish getDish(int dishnum)
        {
            XElement d = null;

            try
            {
                d = (from item in dishRoot.Elements()
                       where int.Parse(item.Element("dishNumber").Value) == dishnum
                     select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (d == null)
                return null;

            return ConvertDish(d);
        }//checks if the dish  already exist
        public bool AddDish(Dish dish)//adds a dish
        {


            int id = dish.dishNumber;
            Dish d = getDish(dish.dishNumber);

                if (dish.dishNumber == 0)
                dish.dishNumber =BE.Dish.dishnumbercounter += 1;
               else if (d != null)
                    throw new Exception("dish with the same dish umber already exists...");
            if (id.CompareTo(dish.dishNumber) == 0 && BE.Dish.dishnumbercounter < id)//i have not given a running number and the given number is bigger that the running one, update the running number to be the biggest code
            {
                BE.Dish.dishnumbercounter = id;
            }

            dishRoot.Add(ConvertDish(dish));

                dishRoot.Save(dishPath);




            //  AddDish(dish);??


        
            dish_id_counter.value = BE.Dish.dishnumbercounter;
            loadCountersFiles();
            XElement toUpdate = (from item in countersRoot.Elements()
                                 where item.Element("name").Value == "dish_id_counter"
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Counter not found");

            foreach (PropertyInfo item in typeof(BE.Counter).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(dish_id_counter));

            countersRoot.Save(countersPath);
           return true;
            
           
 
        }
        public bool DeleteDish(int dishnumber)//delets a dish
        {
            XElement toRemove = (from item in dishRoot.Elements()
                                 where int.Parse(item.Element("dishNumber").Value) == dishnumber
                                 select item).FirstOrDefault();

            if (toRemove == null)
            {
                throw new Exception("Dish with this dish number does not exist...");
                //return false;
            }
            else
            {
                toRemove.Remove();

                dishRoot.Save(dishPath);
             
            }
            //delete all order dishes with this dish
            IEnumerable<XElement> toRemove2 = (from item in ordereddishRoot.Elements()
                                               where int.Parse(item.Element("dishNumber").Value) == dishnumber
                                               select item);

            if (toRemove2 == null)
            {
                throw new Exception("Ordered Dish doesn't exist...");

            }
            else
            {
                int size = toRemove2.Count();
                for (int i = 0; i < size; i++)
                {
                    toRemove2.ElementAt(0).Remove();
                }
                ordereddishRoot.Save(ordereddishPath);
                return true;
            }
        }
        public bool SetDish(Dish dish)//sets a dish
        {
            XElement toUpdate = (from item in dishRoot.Elements()
                                 where int.Parse(item.Element("dishNumber").Value) == dish.dishNumber
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Dish with this dish number isn't found...");

            foreach (PropertyInfo item in typeof(BE.Dish).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(dish));

            dishRoot.Save(dishPath);
            return true;
        }
        public IEnumerable<Dish> listDishes(Func<Dish, bool> predicat = null)//gets all dishes
        {
            if (predicat == null)
            {
                return from item in dishRoot.Elements()
                       select ConvertDish(item);
            }
           
                return from item in dishRoot.Elements()
                       let s = ConvertDish(item)
                       where predicat(s)
                       select s;
            
        }
        #endregion
        #region Branch
        public XElement ConvertBranch(BE.Branch b)//converts fromm XElemen to Branch 
        {
            XElement branchElement = new XElement("Branch");

            foreach (PropertyInfo item in typeof(Branch).GetProperties())
                branchElement.Add
                    (
                    new XElement(item.Name, item.GetValue(b, null))
                    );

            return branchElement;
        }
        public Branch ConvertBranch(XElement element)//converts for Branch to XElemen
        {
            Branch b = new Branch();

            foreach (PropertyInfo item in typeof(BE.Branch).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(b, convertValue);
            }

            return b;
        }
        public Branch getBranch(int num)
        {
            XElement d = null;

            try
            {
                d = (from item in branchRoot.Elements()
                     where int.Parse(item.Element("branchNumber").Value) == num
                     select item).FirstOrDefault();


            }
            catch (Exception)
            {
                return null;
            }

            if (d == null)
                return null;

            return ConvertBranch(d);
        }
        public bool AddBranch(Branch branch)//adds a branch
        {
         
            BE.Branch.branchcounter++;
            branch.branchNumber = BE.Branch.branchcounter;
           
            branchRoot.Add(ConvertBranch(branch));
            branchRoot.Save(branchPath);
            //  update counter file 
            branch_id_counter.value = BE.Branch.branchcounter;
            loadCountersFiles();
            XElement toUpdate = (from item in countersRoot.Elements()
                                 where item.Element("name").Value == "branch_id_counter"
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Counter not found");

            foreach (PropertyInfo item in typeof(BE.Counter).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(branch_id_counter));
            
            countersRoot.Save(countersPath);
            return true;
            //if (branch.branchNumber != 0)
            //{

            //    Branch d = getBranch(branch.branchNumber);
            //    if (d != null)
            //    {
            //        throw new Exception("branch with the same branch number already exists...");
            //        //return false;
            //    }

            //    branchRoot.Add(ConvertBranch(branch));

            //    branchRoot.Save(branchPath);
            //    return true;
            //}

            //else//need to give a new code
            //{
            //    branchnumber += 1;
            //    branch.branchNumber = branchnumber;
            //    AddBranch(branch);
            //מפה היה מיורק גם קודם
            //Branch d = getBranch(branch.branchNumber);
            //if (d != null)
            //    throw new Exception("branch with the same branch number already exists...");

            //branchRoot.Add(ConvertBranch(branch));

            //branchRoot.Save(branchPath);
            //return true;
            


       


        }
        public bool DeleteBranch(int numbranch)//delete a brech
        {
            XElement toRemove = (from item in branchRoot.Elements()
                                 where int.Parse(item.Element("branchNumber").Value) == numbranch
                                 select item).FirstOrDefault();

            if (toRemove == null)
            {
                throw new Exception("branch doesn't exist...");
                //return false;
            }
            else
            {
                toRemove.Remove();

                branchRoot.Save(branchPath);
                return true;
            }
         
        }
        public bool SetBranch(Branch branch)//sets a branch
        {
            XElement toUpdate = (from item in branchRoot.Elements()
                                 where int.Parse(item.Element("branchNumber").Value) == branch.branchNumber
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("branch with this branch number doesn't exist...");

            foreach (PropertyInfo item in typeof(BE.Branch).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(branch));

            branchRoot.Save(branchPath);
            return true;
        }
        public IEnumerable<Branch> listBranch(Func<Branch, bool> predicat = null)//gets all branches
        {
            if (predicat == null)
            {
                return from item in branchRoot.Elements()
                       select ConvertBranch(item);
            }

            return from item in branchRoot.Elements()
                   let s = ConvertBranch(item)
                   where predicat(s)
                   select s;
            

        }
        #endregion
        #region Order
        public XElement ConvertOrder(BE.Order b)//converts from XElement to Order
        {
            XElement orderElement = new XElement("Order");

            foreach (PropertyInfo item in typeof(Order).GetProperties())
                orderElement.Add
                    (
                    new XElement(item.Name, item.GetValue(b, null))
                    );

            return orderElement;
        }
        public Order ConvertOrder(XElement element)//converts from Order to XElemen
        {
            Order b = new Order();

            foreach (PropertyInfo item in typeof(BE.Order).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(b, convertValue);
            }

            return b;
        }
        public Order getOrder(string num)//find the first Order(for checking if it exists)
        {
            XElement d = null;

            try
            {
                d = (from item in orderRoot.Elements()
                     where item.Element("orderNumber").Value == num
                     select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (d == null)
                return null;

            return ConvertOrder(d);
        }
        public bool AddOrder(Order order)//adds an Order
        {

            BE.Order.ordercounter++;
            order.orderNumber = BE.Order.ordercounter.ToString().PadLeft(8, '0');
          


            orderRoot.Add(ConvertOrder(order));
            orderRoot.Save(orderPath);

            order_id_counter.value = BE.Order.ordercounter;
            loadCountersFiles();
            XElement toUpdate = (from item in countersRoot.Elements()
                                 where item.Element("name").Value == "order_id_counter"
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Counter not found");

            foreach (PropertyInfo item in typeof(BE.Counter).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(order_id_counter));

            countersRoot.Save(countersPath);

            return true;
        
            ////if (order.orderNumber != "00000000")
            ////{

            //    Order d = getOrder(order.orderNumber);
            //if (d == null)
            //{
            //    orderRoot.Add(ConvertOrder(order));
            //    orderRoot.Save(orderPath);
            //    return true;
            //}


            //else
            //{
            //    throw new Exception("Order with the same Order number already exists...");
            //    return false;

            //}



        }
        public bool DeleteOrder(string orderNumber)//delete an order
        {

            XElement toRemove = (from item in orderRoot.Elements()
                                 where item.Element("orderNumber").Value == orderNumber
                                 select item).FirstOrDefault();

            if (toRemove == null)
            {
                throw new Exception("Order doesn't exist...");
                //return false;
            }
            else
            {
                toRemove.Remove();

                orderRoot.Save(orderPath);
              
            }
            //delete all orderd dish with the same order number
            IEnumerable<XElement> toRemove2 = (from item in ordereddishRoot.Elements()
                                               where item.Element("orderNumber").Value == orderNumber
                                               select item);

            if (toRemove2 == null)
            {
                throw new Exception("Ordered Dish doesn't exist...");
              
            }
            else

            {
                int size = toRemove2.Count();
                for (int i = 0; i < size; i++)
                {
                    toRemove2.ElementAt(0).Remove();
                }
                ordereddishRoot.Save(ordereddishPath);

                return true;
            }
        }
        public bool SetOrder(Order order)//sets an Order
        {
            XElement toUpdate = (from item in orderRoot.Elements()
                                 where item.Element("orderNumber").Value == order.orderNumber
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("can not update order, order number does not exist");

            foreach (PropertyInfo item in typeof(BE.Order).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(order));

            orderRoot.Save(orderPath);
            return true;
            //Order d = getOrder(order.orderNumber);

            //if (d != null)
            //{
            //    DataSource.orderList.Remove(d);
            //    DataSource.orderList.Add(order);
            //    return true;
            //}
            //throw new Exception("can not update order, order number does not exist ");
            ////return false;
        }
        public IEnumerable<Order> listOreders(Func<Order, bool> predicat = null)//gets all orders
        {

            if (predicat == null)
            {
                return from item in orderRoot.Elements()
                       select ConvertOrder(item);
            }

            return from item in orderRoot.Elements()
                   let s = ConvertOrder(item)
                   where predicat(s)
                   select s;
            
        }
        #endregion
        #region OrderDish
        public XElement ConvertOrdered_Dish(BE.Ordered_Dish b)//converts from XElement to Ordered Dish
        {
            XElement ordereddishElement = new XElement("Ordered-Dish");

            foreach (PropertyInfo item in typeof(Ordered_Dish).GetProperties())
                ordereddishElement.Add
                    (
                    new XElement(item.Name, item.GetValue(b, null))
                    );

            return ordereddishElement;
        }
        public Ordered_Dish ConvertOrdered_Dish(XElement element)//converts for Orderd dish to XElemen
        {
            Ordered_Dish b = new Ordered_Dish();

            foreach (PropertyInfo item in typeof(BE.Ordered_Dish).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(b, convertValue);
            }

            return b;
        }
        public Ordered_Dish getOrderedDish(int numDish, string numOrder)//checks if the branch  already exist
        {
            XElement d = null;

            try
            {
                d = (from item in ordereddishRoot.Elements()
                     where ((int.Parse(item.Element("dishNumber").Value) == numDish)&&(item.Element("orderNumber").Value==numOrder))
                     select item).FirstOrDefault();


            }
            catch (Exception)
            {
                return null;
            }

            if (d == null)
                return null;

            return ConvertOrdered_Dish(d);
        }
        public void AddOrderedDish(Ordered_Dish orderDish)//adds an ordered dish
        {

            Ordered_Dish d = getOrderedDish(orderDish.dishNumber, orderDish.orderNumber);
            if (d == null)
            {
                ordereddishRoot.Add(ConvertOrdered_Dish(orderDish));
                ordereddishRoot.Save(ordereddishPath);
            }


            else
            {
                throw new Exception("Order with the same Order number already exists...");
               

            }
            //Ordered_Dish d = getOrderedDish(orderDish.dishNumber, orderDish.orderNumber);
            //if (d == null)//doesnt exist
            //{
            //    DataSource.orderedDishList.Add(orderDish);
            //}
            //else//exist(only need to increase the amount of the dish)
            //{

            //    DataSource.orderedDishList.Remove(d);
            //    d.amountOfDish += orderDish.amountOfDish;//the dish is on the table, we r only increasing amount of dish
            //    
            // DataSource.orderedDishList.Add(orderDish);

        }
        public bool DeleteOrderedDish(int dishnumber, string numorder)//delete an ordered dish
        {
            XElement toRemove = (from item in ordereddishRoot.Elements()
                                 where int.Parse(item.Element("dishNumber").Value )== dishnumber &&(item.Element("orderNumber").Value== numorder)
                                 select item).FirstOrDefault();

            if (toRemove == null)
            {
                throw new Exception("Ordered Dish doesn't exist...");
                //return false;
            }
            else
            {
                toRemove.Remove();

                ordereddishRoot.Save(ordereddishPath);
                return true;
            }
        }
        public bool SetOrderedDish(Ordered_Dish orderDish)//sets an ordered dish
        {
            XElement toUpdate = (from item in ordereddishRoot.Elements()
                                 where int.Parse(item.Element("dishNumber").Value) == orderDish.dishNumber && (item.Element("orderNumber").Value == orderDish.orderNumber)
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("can not update ordered Dish, order number does not exist");

            foreach (PropertyInfo item in typeof(BE.Ordered_Dish).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(orderDish));

            ordereddishRoot.Save(ordereddishPath);
            return true;
        } 
        public IEnumerable<Ordered_Dish> listorderedDishes(Func<Ordered_Dish, bool> predicat = null)//gets all orderedDishes
        {
            if (predicat == null)
            {
                return from item in ordereddishRoot.Elements()
                       select ConvertOrdered_Dish(item);
            }

            return from item in ordereddishRoot.Elements()
                   let s = ConvertOrdered_Dish(item)
                   where predicat(s)
                   select s;
        }
        #endregion



        public List<Bill> listBill()
        {
            return DataSource.billList;
        }
        public void addLineToBill(Bill b)
        {
            DataSource.billList.Add(b);
        }

        
    }
}
