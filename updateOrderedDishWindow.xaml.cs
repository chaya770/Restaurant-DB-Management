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
    /// Interaction logic for updateOrderedDishWindow.xaml
    /// </summary>
    public partial class updateOrderedDishWindow : Window
    {

        BE.Ordered_Dish Od;
        BL.IBL bl;

        public updateOrderedDishWindow()
        {
            InitializeComponent();
            Od = new BE.Ordered_Dish();
            this.DataContext = Od;
            bl = BL.FactoryBL.GetBL();
           
            this.orderNumberComboBox.ItemsSource = bl.listOreders();
            this.orderNumberComboBox.DisplayMemberPath = "orderNumber";
            //orderNumberComboBox.DataContext = Od.orderNumber;//brirat mechdal
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Od.dishNumber==0)
                throw new Exception("must select dish name first");
                if (Od.orderNumber == "")
                    throw new Exception("must select order number first");

                bl.SetOrderedDish(Od);
                MessageBox.Show("ordered dish " + Od.orderNumber + " dish number: " + Od.amountOfDish + " amount: " + Od.amountOfDish + "  was updated");
                //MessageBox.Show("עודכנה בהצלחה" + Od.orderNumber + " מנה מוזמנת ");

                Od = new BE.Ordered_Dish();
                DataContext = Od;
                //orderNumberComboBox.SelectedValue = Od.orderNumber;
               //dishNumberComboBox.SelectedValue = Od.dishNumber;
               // amountOfDishTextBox.SelectedText = "0";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = orderNumberComboBox.SelectedValue;
            BE.Order b = a as BE.Order;
           Od.orderNumber = b.orderNumber;
           // Od = b;
          // DataContext = b;
            dishNumberComboBox.ItemsSource = bl.dishListByOrderNumber(b.orderNumber);
            dishNumberComboBox.DisplayMemberPath = "dishName";
            if (bl.dishListByOrderNumber(b.orderNumber).Count==0)
               MessageBox.Show("there are no disheses in this order");
           // Od.dishNumber = dishNumberComboBox.SelectedItem;
            //dishNumberComboBox.DataContext = Od.dishNumber;//brirat mechdal

        }

        private void dishNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = dishNumberComboBox.SelectedValue;
            BE.Dish b = a as BE.Dish;
            //if (a == null)
            //    throw new Exception("must select dish number first");
            
            Od.dishNumber = b.dishNumber;


        }

        private void amountOfDishTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (amountOfDishTextBox.Text != "0")
                {
                    if (!int.TryParse(amountOfDishTextBox.Text, out a))
                    {
                        amountOfDishTextBox.Text = "0";
                        throw new Exception("amount of dish must contain only numbers");
                    }
                    if (a < 0)
                    {
                        amountOfDishTextBox.Text = "0";
                        throw new Exception(" amount of dish must be at lest 0");
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
