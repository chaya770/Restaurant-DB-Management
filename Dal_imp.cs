using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{
    public class Dal_imp// : Idal
    {
        static int dishnumber = 100;
        static int branchnumber = 1;
        //static int ordernumber = 50;
        public  bool AddDish(Dish dish)//adds a dish
        {
           
             
             if (dish.dishNumber != 0)
             {
            Dish d = getDish(dish.dishNumber);
            if (d != null)//already exists
                return false;
            DataSource.dishList.Add(dish);
            return true; 
            }
        
        else//need to give a new code
            {
                dishnumber += 1;
                dish.dishNumber = dishnumber ;
                DataSource.dishList.Add(dish);
                return true; 
            }

        }
        public Dish getDish(int num)//checks if the dish  already exist
        {
            return DataSource.dishList.FirstOrDefault(s => s.dishNumber == num);
        }
        public bool DeleteDish(int dishnumber)//delete a dish
        {
            Dish d = getDish(dishnumber);
            if (d != null)
            {
                DataSource.dishList.Remove(d);
                return true;
            }
            return false;
        }
        public bool SetDish(Dish dish)//sets a dish
        {
            Dish d = getDish(dish.dishNumber);

            if (d != null)
            {
                DataSource.dishList.Remove(d);
                DataSource.dishList.Add(dish);
                return true;
            }
            return false; //does not exist in the list 
        }


        public Branch getBranch(int num)//checks if the branch  already exist
        {
            return DataSource.branchList.FirstOrDefault(s => s.branchNumber == num);
        }
        public bool AddBranch(Branch branch)//adds a branch
        {
            if (branch.branchNumber != 0)
            {
                Branch d = getBranch(branch.branchNumber);
                if (d == null)
                {
                    DataSource.branchList.Add(branch);
                    return true;
                }
                throw new Exception("can not add order with this branch number,branch number alresdy exists. try agin ");
               // return false;//already exist in the list
            }
            else
            {
                branchnumber += 1;
                branch.branchNumber = branchnumber;
                //DataSource.branchList.
                    AddBranch(branch);
                return true;


            }
        }
        public bool DeleteBranch(int numbranch)//delete a brech
        {
            Branch d = getBranch(numbranch);
            if (d != null)//exists
            {
                DataSource.branchList.Remove(d);
                return true;
            }
            return false;//does not exist

        }
        public  bool SetBranch(Branch branch)//sets a branch
        {
            Branch d = getBranch(branch.branchNumber);

            if (d != null)
            {
                DataSource.branchList.Remove(d);
                DataSource.branchList.Add(branch);
                return true;
            }
            return false; //does not exist in the list 
        }


        public Costumer getCostumer(string num)//checks if the Costumer  already exist
        {
            return DataSource.costumerList.FirstOrDefault(s => s.tz == num);
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
                        DataSource.costumerList.Add(c);
                        return true;
                    }
                    return false;//already exist in the list
                }
                else
                {

                    c.tz = "brerat-mechdal";
                    DataSource.costumerList.Add(c);
                    return true;
                }
        }
        public bool DeleteCostumer(string numbranch)//delete a Costumer
        {
            Costumer c = getCostumer(numbranch);
            if (c != null)//exists
            {
                DataSource.costumerList.Remove(c);
                return true;
            }
            return false;//does not exist

        }
        public bool SetCostumer(Costumer c)//sets a Costumer
        {
            Costumer d = getCostumer(c.tz);

            if (d != null)
            {
                DataSource.costumerList.Remove(d);
                DataSource.costumerList.Add(c);
                return true;
            }
            return false; //does not exist in the list 
        }

        public Order getOrder(string num)//find the first Order(for checking if it exists)
        {
            return DataSource.orderList.FirstOrDefault(s => s.orderNumber == num);
        }
        public  bool AddOrder(Order order)//adds an Order
        {
            //if (order.orderNumber!="00000000")
            //{
                Order d = getOrder(order.orderNumber);
                if (d == null)
                {
                    DataSource.orderList.Add(order);
                    return true;
                }
                
                return false;//already exist in the list
           // }
            //else
            //{
            //    //ordernumber += 1;
            //    //int numDigit;
            //    //ordernumber.
            //    //

            //}

        }
        public  bool DeleteOrder(string orderNumber)//delete an order
        {
            Order d = getOrder(orderNumber);
            if (d != null)//exists
            {
                DataSource.orderList.Remove(d);
                return true;
            }
            return false;//does not exist
        }
        public bool SetOrder(Order order)//sets an Order
        {
            Order d = getOrder(order.orderNumber);

            if (d != null)
            {
                DataSource.orderList.Remove(d);
                DataSource.orderList.Add(order);
                return true;
            }
            throw new Exception("can not update order, order number does not exist ");
            //return false;
        }



        public Ordered_Dish getOrderedDish(int numDish,string numOrder)//checks if the branch  already exist
        {
            return DataSource.orderedDishList.FirstOrDefault(s =>( (s.orderNumber == numOrder) && (s.dishNumber == numDish)));
        }
        public void AddOrderedDish(Ordered_Dish orderDish)//adds an ordered dish
        {
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
            DataSource.orderedDishList.Add(orderDish);
            
        }
        public bool DeleteOrderedDish(int dishnumber, string numorder)//delete an ordered dish
        {
            Ordered_Dish d = getOrderedDish(dishnumber, numorder);
            if (d != null)//exists
            {
                DataSource.orderedDishList.Remove(d);
                return true;
            }
            return false;//does not exist

        }
        public bool SetOrderedDish(Ordered_Dish orderDish)//sets an ordered dish
        {
            Ordered_Dish d = getOrderedDish(orderDish.dishNumber, orderDish.orderNumber);

            if (d != null)
            {
                DataSource.orderedDishList.Remove(d);
                DataSource.orderedDishList.Add(orderDish);
                return true;
            }
            return false; //does not exist in the list 
        }
        public IEnumerable<Order> listOreders()//gets all orders
        {
            return DataSource.orderList;
        }
        public IEnumerable<Dish> listDishes()//gets all dishes
        {
            return DataSource.dishList;
        }
        public IEnumerable<Branch> listBranch()//gets all branches
        {
            return DataSource.branchList;
        }
        public IEnumerable<Ordered_Dish> listorderedDishes()//gets all orderedDishes
        {
            return DataSource.orderedDishList;
        }
        public IEnumerable<Costumer> listCostumers()
        {
            return DataSource.costumerList;
        }

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
