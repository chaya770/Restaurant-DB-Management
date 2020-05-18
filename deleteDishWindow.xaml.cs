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
    /// Interaction logic for deleteDishWindow.xaml
    /// </summary>
    public partial class deleteDishWindow : Window
    {
        BE.Dish d;
        BL.IBL bl;
        public deleteDishWindow()
        {
            InitializeComponent();
            InitializeComponent();
            d = new BE.Dish();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            dishNumberComboBox.ItemsSource = bl.listDishes();
            //dishNumberComboBox.DisplayMemberPath = "dishNumber";
            //dishNumberComboBox.DataContext = d.dishNumber;//brirat mechdal

        }


        private void dishNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = dishNumberComboBox.SelectedValue;
            BE.Dish b = a as BE.Dish;
            if (a == null)
                throw new Exception("must select dish first");
            d.dishNumber = b.dishNumber;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (d.dishNumber == 1)
                    throw new Exception("can not delete the free desert...");
                bl.DeleteDish(d.dishNumber);
                MessageBox.Show("Dish number: " + d.dishNumber + " was deleted successfully");
                //MessageBox.Show("נמחקה בהצלחה" + d.dishNumber + " מנה ");

                //dishNumberComboBox.ItemsSource = bl.listDishes();
                //dishNumberComboBox.DisplayMemberPath = "dishNumber";

                d = new BE.Dish();
                this.DataContext = d;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
