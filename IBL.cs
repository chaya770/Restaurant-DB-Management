using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
   public interface IBL
    {
        /// <summary>
        /// adds a dish
        /// </summary>
        /// <param name="dish">an object of a dish</param>
        /// <returns>true if the dish was added successfully</returns>
        bool AddDish(Dish dish);
        /// <summary>
        /// find the first dish(for checking if it exist)
        /// </summary>
        /// <param name="num">represents dish number</param>
        /// <returns>a dish</returns>
        Dish getDish(int num);
        /// <summary>
        /// delete a dish
        /// </summary>
        /// <param name="dishnumber">dish number</param>
        /// <returns>true if the dish was deleted successfully</returns>
        bool DeleteDish(int dishnumber);
        /// <summary>
        /// sets a dish
        /// </summary>
        /// <param name="dish">an object of a Dish</param>
        /// <returns>true if the dish was seted successfully</returns>
        bool SetDish(Dish dish);
        /// <summary>
        /// find the first branch(for checking if it exist)
        /// </summary>
        /// <param name="num">represents branch number</param>
        /// <returns>the branch</returns>
        Branch getBranch(int num);
        /// <summary>
        /// adds a branch
        /// </summary>
        /// <param name="branch">an object of a branch</param>
        /// <returns>branch</returns>
        bool AddBranch(Branch branch);
        /// <summary>
        /// delete a branch
        /// </summary>
        /// <param name="numbranch">represents branhch number</param>
        /// <returns>true if the branch was deleted successfully</returns>
        bool DeleteBranch(int numbranch);
        /// <summary>
        /// sets a branch
        /// </summary>
        /// <param name="branch">an object of a Branch</param>
        /// <returns>true if the branch wasseted successfully</returns>
        bool SetBranch(Branch branch);
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
        /// <param name="order">an object of an Order</param>
        /// <returns>true if the order setted successfully</returns>
        bool SetOrder(Order order);
        /// <summary>
        /// adds an order dish
        /// </summary>
        /// <param name="dish">an object of an ordered dish</param>
        void AddOrderedDish(Ordered_Dish dish);
        /// <summary>
        /// delete an ordered dish
        /// </summary>
        /// <param name="dishnumber">represents dish number</param>
        /// <param name="numorder">represents order number</param>
        /// <returns>true if the order dish was deleted successfully</returns>
        bool DeleteOrderedDish(int dishnumber, string numorder);
        /// <summary>
        /// sets an ordered dish
        /// </summary>
        /// <param name="dish">an object of an ordered dish</param>
        /// <returns>true if the order dish was seted successfully</returns>
        bool SetOrderedDish(Ordered_Dish dish);
        /// <summary>
        /// find the first costumer(for checking if it exists)
        /// </summary>
        /// <param name="num">represents costumer tz</param>
        /// <returns>costumer</returns>
        Costumer getCostumer(string num);
        /// <summary>
        /// adds a costumer
        /// </summary>
        /// <param name="costumer">an object of a costumer</param>
        /// <returns>true if the costumer was added successfully</returns>
        bool AddCostumer(Costumer cos);
        /// <summary>
        /// delete a costumer
        /// </summary>
        /// <param name="costTZ">represents costumer tz</param>
        /// <returns>true if the costumer was deleted successfully</returns>
        bool DeleteCostumer(string costTZ);
        /// <summary>
        /// sets a costumer
        /// </summary>
        /// <param name="cos">an object of a costumer</param>
        /// <returns>true if the costumer was seted successfully</returns>
        bool SetCostumer(Costumer cos);

        /// <summary>
      /// gets all orders
      /// </summary>
      /// <returns>all orders</returns>
        IEnumerable<Order> listOreders();
        /// <summary>
    /// gets all dishes
    /// </summary>
    /// <returns>all dishes</returns>
        IEnumerable<Dish> listDishes();
        /// <summary>
        /// get all branches
        /// </summary>
        /// <returns>all branches</returns>
        IEnumerable<Branch> listBranch();
        /// <summary>
        /// gets all order dishes with the condition
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns>all order dishes with the condition</returns>
        IEnumerable<Ordered_Dish> listorderedDishes(Func<Ordered_Dish, bool> predicat = null);
        /// <summary>
        /// gets all costumers
        /// </summary>
        /// <returns>all costumers wuth the condition</returns>
        IEnumerable<Costumer> listCostumers();
        /// <summary>
        /// gets the list biil
        /// </summary>
        /// <returns>list of bills</returns>
        List<Bill> listBill();
        /// <summary>
        /// adds a line(bill class) to the bill list
        /// </summary>
        /// <param name="b">an object of a Bill</param>
        void AddLineToBill(Bill b);
        /// <summary>
        /// calculate total price for a specific order
        /// </summary>
        /// <param name="orderNumber">represents order number</param>
        /// <returns>the total price</returns>
        float totalprice(string orderNumber);//total price
        /// <summary>
        /// calculate total price including a tip for a specific order
        /// </summary>
        /// <param name="orderNumber">represents order number</param>
        /// <param name="tip">represents tip</param>
        /// <returns>the total price including the tip</returns>
        float totalPriceWithTip(string orderNumber, int tip);
        /// <summary>
        /// add all lines to bill acording to the spesipic order
        /// </summary>
        /// <param name="orderNumber">order number</param>
        /// <returns>list bill</returns>
        List<Bill> calcBill(string orderNumber);
        /// <summary>
        /// checks if the dish is already exist
        /// </summary>
        /// <param name="dishNumber">dish number</param>
        /// <returns>true if the dish is already exist</returns>
        bool dishExistInList(int dishNumber);
        /// <summary>
        /// checks if the branch is already exist
        /// </summary>
        /// <param name="branchNumber">represents dish number</param>
        /// <returns>true if the branch is already exist</returns>
        bool branchExistInList(int branchNumber);
        /// <summary>
        /// calculate the number of calories in specific dish
        /// </summary>
        /// <param name="Dishname">represents dish name</param>
        /// <returns>the number of calories in specific dish</returns>
        int caloriesIndish(string Dishname);
        /// <summary>
        /// calaulate  the average of calories per person
        /// </summary>
        /// <param name="orderNumber">represents order number</param>
        /// <returns> the average of calories per person</returns>
        float averageCaloriesPerPerson(string orderNumber);
        /// <summary>
        /// calaulate the tatal of calories in order
        /// </summary>
        /// <param name="orderNumber">represents order number</param>
        /// <returns>the tatal of calories in order</returns>
        int totalCalories(string orderNumber);
        /// <summary>
        /// checks if the order has 8 dishes or more
        /// </summary>
        /// <param name="orderNumber">represents order number</param>
        /// <returns>true if  the order has 8 dishes or more</returns>
        bool NumDisheBiggerThan8(string orderNumber);
        /// <summary>
        /// adds a free desert if the order has 8 or more dishes 
        /// </summary>
        /// <param name="orderNumber">represents ordre number</param>
        /// <returns>true if the add of the dish was succesfuly</returns>
        bool freedesert(string orderNumber);
        /// <summary>
        /// grouping by kind od dish
        /// </summary>
        /// <returns>a groups by kind of dish</returns>
        IEnumerable<IGrouping<int, Ordered_Dish>> groupbyKindOfDish();
        /// <summary>
        /// gouping dishes by hechsher
        /// </summary>
        /// <returns>groups of dishes by hechsher</returns>
        IEnumerable<IGrouping<BE.hechsher, Dish>> groupByHechsher();
        /// <summary>
        /// grouping ordered dish by city
        /// </summary>
        /// <returns>groups of orderd dish by hechsher</returns>
        IEnumerable<IGrouping<BE.city, Ordered_Dish>> groupByCity();
        /// <summary>
        /// groups orders by days(time)
        /// </summary>
        /// <returns>groups of orders by days(time)</returns>
        IEnumerable<IGrouping<int, Ordered_Dish>> groupByTime();
        /// <summary>
        /// prints the groups of dishes by size
        /// </summary>
         void groupBySize();
        /// <summary>
        /// prints groups of dish by price
        /// </summary>
         void groupByprice();


        //dish
        /// <summary>
        /// return the specific dish(enter it to list befor)
        /// </summary>
        /// <param name="o">represents order number</param>
        /// <returns> return the specific dish</returns>
        List<BE.Dish> dishListByOrderNumber(string o);
        /// <summary>
        /// return the dishes with the condition
        /// </summary>
        /// <param name="condition">represents predicate for the delegate</param>
        /// <returns>return the dishes with the condition</returns>
        List<Dish> dishUnderCondition(Predicate<Dish> condition);
        /// <summary>
        /// (condition for the delegate)checks if the hechsher is best
        /// </summary>
        /// <param name="d">Dish</param>
        /// <returns>true if the condition is real</returns>
        bool ConDishesHechsherBest(Dish d);
        /// <summary>
        /// (condition for the delegate)checks if the hechsher is medium
        /// </summary>
        /// <param name="d">object of Dish</param>
        /// <returns>true if the condition is real</returns>
        bool ConDishesHechsherMedium(Dish d);
        /// <summary>
        /// (condition for the delegate)checks if the hechsher is regular
        /// </summary>
        /// <param name="d">object of Dish</param>
        /// <returns>true if the condition is real</returns>
        bool ConDishesHechsherRegular(Dish d);
        /// <summary>
        /// condition for delegate acording to max price
        /// </summary>
        /// <param name="d">object of Dish</param>
        /// <param name="MaxPrice">represents max price</param>
        /// <returns>true if the condition is real</returns>
        bool ConDishesMaxPrice(Dish d, int MaxPrice);
        /// <summary>
        /// return dishes with price under the parameter "maxPrice"
        /// </summary>
        /// <param name="MaxPrice">represets max price</param>
        /// <returns>list of dishes</returns>
        List<BE.Dish> DishesByMaxPrice(int MaxPrice);
        /// <summary>
        /// return dishes with rate more than parameter "rate"
        /// </summary>
        /// <param name="rate">represents rate</param>
        /// <returns>list of dishes</returns>
        List<BE.Dish> DishesByMinRate(int rate);
        /// <summary>
        /// return dishes with calories under the parameter "MaxCalories"
        /// </summary>
        /// <param name="MaxCalories">reoresents max calories</param>
        /// <returns>list of dishes</returns>
        List<BE.Dish> DishesByMaxCalories(int MaxCalories);
        /// <summary>
        /// condition for the delegate-checks if the size is small
        /// </summary>
        /// <param name="d">object of Dish</param>
        /// <returns>true if the condition ia real</returns>
        bool ConDishesSizeSmall(Dish d);
        /// <summary>
        /// condition for the delegate-checks if the size is mrdium
        /// </summary>
        /// <param name="d">object of Dish</param>
        /// <returns>true if the condition ia real</returns>
        bool ConDishesSizeMedium(Dish d);
        /// <summary>
        /// condition for the delegate-checks if the size is large
        /// </summary>
        /// <param name="d">object of Dish</param>
        /// <returns>true if the condition ia real</returns>
        bool ConDishesSizeMediumLarge(Dish d);
        /// <summary>
        /// find the specipic dish according to the number
        /// </summary>
        /// <param name="num">represents dish number</param>
        /// <returns>dish</returns>
        Dish DishByNumber(int num);
        /// <summary>
        /// find the specipic dish according to the name
        /// </summary>
        /// <param name="name">represents dish name</param>
        /// <returns>the dish</returns>
        Dish DishByName(string name);

        //branch
        /// <summary>
        /// find the specipic brnch according to the number
        /// </summary>
        /// <param name="num">represents branch number</param>
        /// <returns>the branch</returns>
        Branch BranchByNumber(int num);
        /// <summary>
        /// find the specipic brnch according to the name and enter it to list
        /// </summary>
        /// <param name="name">represents branch number</param>
        /// <returns>list with one branch</returns>
        List<BE.Branch> BranchByName(string name);
        /// <summary>
        /// find all branches with the condition
        /// </summary>
        /// <param name="condition">predicate</param>
        /// <returns>list of branch</returns>
        List<BE.Branch> branchUnderCondition(Predicate<BE.Branch> condition);
        /// <summary>
        /// (condition for the delegate)checks if the hechsher is best
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the hechsher is best</returns>
        bool ConBranchHechsherBest(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the hechsher is medium
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the hechsher is medium</returns>
        bool ConBranchHechsherMedium(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the hechsher is regular
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the hechsher is regular</returns>
        bool ConBranchHechsherRegular(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the city of the branch is jerusalem
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the city is jerusalem</returns>
        bool ConBranchCityJerysalem(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the city of the branch is ramat gan
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the city is ramat gan</returns>
        bool ConBranchCityJRamatGan(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the city of the branch is bnei brak
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the city is bnei brak</returns>
        bool ConBranchCityBneiBrak(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the city of the branch is beit shemesh
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the city is beit shemesh</returns>
        bool ConBranchCityBeitShemesh(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the city of the branch is kiryat sefer
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the city is kiryat sefer</returns>
        bool ConBranchCityKiryatSefer(Branch d);
        /// <summary>
        /// (condition for the delegate)checks if the city of the branch is tel aviv
        /// </summary>
        /// <param name="d">object of Branch</param>
        /// <returns>true if the city is tel aviv</returns>
        bool ConBranchCityTelAviv(Branch d);
        //costumer
        /// <summary>
        /// find a specific costumer according to id
        /// </summary>
        /// <param name="id">represents costumer id</param>
        /// <returns>costumer</returns>
        Costumer CostumerById(string id);
        /// <summary>
        /// find a specific costumer according to name
        /// </summary>
        /// <param name="name">represents costumer name</param>
        /// <returns>costumer</returns>
        Costumer CostumerByName(string name);
        /// <summary>
        /// cheks if the costumer is a member ship
        /// </summary>
        /// <param name="c">an object of a Costumer</param>
        /// <returns>true if the costumer is a member ship</returns>
        bool ConCostumerMemberShip(Costumer c);
        /// <summary>
        /// gets all costumer wuth the condition
        /// </summary>
        /// <param name="condition">predicate</param>
        /// <returns>list of costumers</returns>
        List<BE.Costumer> costumerUnderCondition(Predicate<BE.Costumer> condition);
        //order  ** 
        /// <summary>
        /// find all orders with the condition
        /// </summary>
        /// <param name="condition">predicate</param>
        /// <returns>list of orders</returns>
        List<BE.Order> orderUnderCondition(Predicate<BE.Order> condition);
        /// <summary>
        /// condition for the delegate-checks if the hechsher is best
        /// </summary>
        /// <param name="or">an object of an Order</param>
        /// <returns>true if the hechsher is best </returns>
        bool conOrderHechsher1(Order or);
        /// <summary>
        /// condition for the delegate-checks if the hechsher is medium
        /// </summary>
        /// <param name="or">an object of an Order</param>
        /// <returns>true if the hechsher is medium </returns>
        bool conOrderHechsher2(Order or);
        /// <summary>
        /// condition for the delegate-checks if the hechsher is regular
        /// </summary>
        /// <param name="or">an object of an Order</param>
        /// <returns>true if the hechsher is regular </returns>
        bool conOrderHechsher3(Order or);
        /// <summary>
        /// find a sprsific order according to order number
        /// </summary>
        /// <param name="num">order number</param>
        /// <returns>an order</returns>
        Order OrderByNumber(string num);
        /// <summary>
        /// find all orders in the sprcific branch accordint to number of branch
        /// </summary>
        /// <param name="num">order number</param>
        /// <returns>list of orders</returns>
        List<BE.Order> OrderByBranch(int num);
        /// <summary>
        /// find all order in the specific month
        /// </summary>
        /// <param name="d">time of order</param>
        /// <returns>list of orders</returns>
        List<BE.Order> conOrderMonth( DateTime d);

        //ordered dish
        /// <summary>
        /// return all ordered dish with the same number of dish
        /// </summary>
        /// <param name="s">represents ordered dish dish number</param>
        /// <returns>list of order dish</returns>
        List<BE.Ordered_Dish> ordereddishbydishnumber(int s);
        /// <summary>
        /// returns all ordered dishes with the same order number
        /// </summary>
        /// <param name="s">represents ordered dish order number</param>
        /// <returns></returns>
        List<BE.Ordered_Dish> ordereddishbyordernumber(string s);
        /// <summary>
        /// returns all ordered dishes with the same amount
        /// </summary>
        /// <param name="st">represents ordered dish amounts</param>
        /// <returns></returns>
        List<BE.Ordered_Dish> ordereddishbyamount(int st);


    }
}
