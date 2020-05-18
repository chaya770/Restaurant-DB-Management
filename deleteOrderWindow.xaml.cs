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
    /// Interaction logic for deleteOrderWindow.xaml
    /// </summary>
    public partial class deleteOrderWindow : Window
    {
        BE.Order order;
        BL.IBL bl;
        public deleteOrderWindow()
        {
            InitializeComponent();
            order = new BE.Order();
            DataContext = order;
            bl = BL.FactoryBL.GetBL();
            orderNumberComboBox.ItemsSource = bl.listOreders();
            //orderNumberComboBox.DisplayMemberPath = "orderNumber";
            //orderNumberComboBox.DataContext = order.orderNumber;//brirat mechdal

        }



        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DeleteOrder(order.orderNumber);
                MessageBox.Show("order: " + order.orderNumber + "  was deleted");
                //MessageBox.Show("נמחקה בהצלחה" + order.orderNumber + " הזמנה ");

                //orderNumberComboBox.ItemsSource = bl.listOreders();
                //orderNumberComboBox.DisplayMemberPath = "orderNumber";

                order = new BE.Order();
                this.DataContext = order;

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
           
                if (a == null)
                    throw new Exception("must select order first");
                order.orderNumber = b.orderNumber;
           
            
        }
    }
}
