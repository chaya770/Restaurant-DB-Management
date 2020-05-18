using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;

namespace DAL
{
    public interface Idal
    {
        /// <summary>
        /// adds a dish
        /// </summary>
        /// <param name="dish">oject of a Dish</param>
        /// <returns>true if the dish was added successfully</returns>
        bool AddDish(Dish dish);//adds a dish
        /// <summary>
        /// find the first dish(for checking if it exist)
        /// </summary>
        /// <param name="num">represents dish number</param>
        /// <returns>a dish</returns>
        Dish getDish(int num);
        /// <summary>
        /// delete a dish
        /// </summary>
        /// <param name="dishnumber">represents dish number</param>
        /// <returns>true if the dish was deleted successfully</returns>
        bool DeleteDish(int dishnumber);
        /// <summary>
        /// sets a dish
        /// </summary>
        /// <param name="dish">oject of a Dish</param>
        /// <returns>true if the dish was seted successfully</returns>
        bool SetDish(Dish dish);
        //XElement ConvertDish(BE.Dish d);//converts from dish to xelement
        //BE.Dish ConvertDish(XElement element);//converts from xelement to dish
        /// <summary>
        /// gets all dishes
        /// </summary>
        /// <param name="predicat">predicate</param>
        /// <returns>all dushes with the condition</returns>
        IEnumerable<Dish> listDishes(Func<Dish, bool> predicat = null);

        /// <summary>
        /// find the first branch(for checking if it exist)
        /// </summary>
        /// <param name="num">represents branch number</param>
        /// <returns>the branch</returns>
        Branch getBranch(int num);
        /// <summary>
        /// adds a branch
        /// </summary>
        /// <param name="branch">an object of a Branch</param>
        /// <returns>branch</returns>
        bool AddBranch(Branch branch);
        /// <summary>
        /// delete a branch
        /// </summary>
        /// <param name="numbranch">represents branch number</param>
        /// <returns>true if the branch was deleted successfully</returns>
        bool DeleteBranch(int numbranch);
        /// <summary>
        /// sets a branch
        /// </summary>
        /// <param name="branch">an object of a Branch</param>
        /// <returns>true if the branch wasseted successfully</returns>
        bool SetBranch(Branch branch);
        /// <summary>
        /// gets all branches
        /// </summary>
        /// <param name="predicat">predicate for the delegate</param>
        /// <returns>all branches with the condition</returns>
        IEnumerable<Branch> listBranch(Func<Branch, bool> predicat = null);


        /// <summary>
        /// find the first Order(for checking if it exists)
        /// </summary>
        /// <param name="num">represents order number</param>
        /// <returns>order</returns>
        Order getOrder(string num);
        /// <summary>
        /// adds an Order
        /// </summary>
        /// <param name="order">an object of a Order</param>
        /// <returns>true if the order added successfully</returns>
        bool AddOrder(Order order);
        /// <summary>
        /// delete an order
        /// </summary>
        /// <param name="orderNumber">represents order number</param>
        /// <returns>true if the order deleted successfully</returns>
        bool DeleteOrder(string orderNumber);
        /// <summary>
        /// sets an Order
        /// </summary>
        /// <param name="order">an object of a Order</param>
        /// <returns>true if the order setted successfully</returns>
        bool SetOrder(Order order);
        /// <summary>
        /// gets all orders
        /// </summary>
        /// <param name="predicat">predicate</param>
        /// <returns>all orders with the condition</returns>
        IEnumerable<Order> listOreders(Func<Order, bool> predicat = null);


        /// <summary>
        /// find the first costumer(for checking if it exists)
        /// </summary>
        /// <param name="num">represents costumer TZ</param>
        /// <returns>costumer</returns>
        Costumer getCostumer(string num);
        /// <summary>
        /// adds a costumer
        /// </summary>
        /// <param name="costumer">an object of a Costumer</param>
        /// <returns>true if the costumer was added successfully</returns>
        bool AddCostumer(Costumer c);
        /// <summary>
        /// delete a costumer
        /// </summary>
        /// <param name="tz">represents costumer TZ</param>
        /// <returns>true if the costumer was deleted successfully</returns>
        bool DeleteCostumer(string tz);
        /// <summary>
        /// sets an costumer
        /// </summary>
        /// <param name="costumer">an object of a Costumer</param>
        /// <returns>true if the costumer was seted successfully</returns>
        bool SetCostumer(Costumer c);
        //BE.Costumer ConvertCostemer(XElement element);
        //XElement ConvertCostemer(BE.Costumer d);
        /// <summary>
        /// gets all costumers
        /// </summary>
        /// <param name="predicat">predicate</param>
        /// <returns>all costumers with the condition</returns>
        IEnumerable<Costumer> listCostumers(Func<Costumer, bool> predicat = null);


        // XElement ConvertOrdered_Dish(BE.Ordered_Dish b);
        // Ordered_Dish ConvertOrdered_Dish(XElement element);
        /// <summary>
        /// get ordered dish
        /// </summary>
        /// <param name="numDish">represents dish number</param>
        /// <param name="numOrder">represents order number</param>
        /// <returns>the specific ordered dish </returns>
        Ordered_Dish getOrderedDish(int numDish, string numOrder);
        /// <summary>
        /// adds an order dish
        /// </summary>
        /// <param name="dish">an object of an ordered dish</param>
        void AddOrderedDish(Ordered_Dish dish);
        /// <summary>
        /// delete an ordered dish
        /// </summary>
        /// <param name="dishnumber">represents dish number</param>
        /// <param name="numorder">v order number</param>
        /// <returns>true if the order dish was deleted successfully</returns>
        bool DeleteOrderedDish(int dishnumber, string numorder);
        /// <summary>
        /// sets an ordered dish
        /// </summary>
        /// <param name="dish">an object of an ordereddish</param>
        /// <returns>true if the order dish was seted successfully</returns>
        bool SetOrderedDish(Ordered_Dish dish);
        /// <summary>
        /// gets all ordered dishes
        /// </summary>
        /// <param name="predicat">predicate</param>
        /// <returns>all ordered dishes with the condition</returns>
        IEnumerable<Ordered_Dish> listorderedDishes(Func<Ordered_Dish, bool> predicat = null);


        /// <summary>
        /// gets the list biil
        /// </summary>
        /// <returns>list of bills</returns>
        List<Bill> listBill();
        /// <summary>
        /// adds a line(bill class) to the bill list
        /// </summary>
        /// <param name="b">an object of a Bill</param>
        void addLineToBill(Bill b);
       

    }
}
