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
    /// Interaction logic for AddOrderedDishWindow.xaml
    /// </summary>
    public partial class AddOrderedDishWindow : Window
    {
        BE.Ordered_Dish  d;
        BL.IBL bl;
        public AddOrderedDishWindow()
        {
            InitializeComponent();
            d = new BE.Ordered_Dish();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            this.dishNumberComboBox.ItemsSource = bl.listDishes();
            this.dishNumberComboBox.DisplayMemberPath = "dishName";
            dishNumberComboBox.DataContext = d.dishNumber;//brirat mechdal

            this.orderNumberComboBox.ItemsSource = bl.listOreders();
            this.orderNumberComboBox.DisplayMemberPath = "orderNumber";
            orderNumberComboBox.DataContext = d.orderNumber;//brirat mechdal


        }

        private void dishNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object a = dishNumberComboBox.SelectedValue;
            BE.Dish di = a as BE.Dish;
            d.dishNumber = di.dishNumber;
      
        }

        private void orderNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = orderNumberComboBox.SelectedValue;
            BE.Order o = a as BE.Order;
            d.orderNumber = o.orderNumber;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                  bl.AddOrderedDish(d);
                MessageBox.Show("ordered dish "+d.orderNumber+" dish number: "+d.amountOfDish+" amount: "+d.amountOfDish+"  was added");
                //MessageBox.Show("הוספה בהצלחה" + d.orderNumber + " מנה מוזמנת ");

                if ( bl.freedesert(d.orderNumber))
                  MessageBox.Show("A free deset was added to your order");
                d = new BE.Ordered_Dish();
                this.DataContext = d;
                orderNumberComboBox.SelectedValue = d.orderNumber;
                dishNumberComboBox.SelectedValue = d.dishNumber;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
