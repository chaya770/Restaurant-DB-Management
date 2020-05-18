using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for deleteOrderedDishWindow.xaml
    /// </summary>
    public partial class deleteOrderedDishWindow : Window
    {
        BE.Ordered_Dish Od;
        BL.IBL bl;

        public deleteOrderedDishWindow()
        {
            InitializeComponent();
            Od = new BE.Ordered_Dish();
            this.DataContext = Od;
            bl = BL.FactoryBL.GetBL();
            orderNumberComboBox.ItemsSource = bl.listorderedDishes();
           // orderNumberComboBox.DisplayMemberPath = "orderNumber";
          //  orderNumberComboBox.DataContext = Od.orderNumber;//brirat mechdal



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SelectedItem="{Binding orderNumber}"
                //BE.Ordered_Dish o =bl.listorderedDishes(s =>( (s.orderNumber == Od.orderNumber)&&( s.dishNumber==Od.dishNumber))).FirstOrDefault();
                
                bl.DeleteOrderedDish(Od.dishNumber,Od.orderNumber);
                MessageBox.Show("ordered dish " + Od.orderNumber + " dish number: " + Od.amountOfDish     + "  was deleted");
                //MessageBox.Show(" נמחקה בהצלחה" + Od.orderNumber + " מנה מוזמנת ");

                orderNumberComboBox.ItemsSource = bl.listorderedDishes();

                Od = new BE.Ordered_Dish();
               this.DataContext = Od;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = orderNumberComboBox.SelectedValue;
            BE.Ordered_Dish b = a as BE.Ordered_Dish;
            //if (a == null)
             //   throw new Exception("must select order number first");
            Od.orderNumber = b.orderNumber;
            Od.dishNumber = b.dishNumber;
            Od.amountOfDish = b.amountOfDish;
        }
    }
}
