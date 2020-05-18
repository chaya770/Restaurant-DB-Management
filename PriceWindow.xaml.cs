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
    /// Interaction logic for PriceWindow.xaml
    /// </summary>
    public partial class PriceWindow : Window
    {

       string Od;
        BL.IBL bl;
        public PriceWindow()
        {
            InitializeComponent();
           // Od = new BE.Order();
            this.DataContext = Od;
            bl = BL.FactoryBL.GetBL();

            this.orderNumberComboBox.ItemsSource = bl.listOreders();
            this.orderNumberComboBox.DisplayMemberPath = "orderNumber";
            orderNumberComboBox.DataContext = Od;//brirat mechdal

        }



        private void orderNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = orderNumberComboBox.SelectedValue;
            BE.Order b = a as BE.Order;
            if (a == null)
                throw new Exception("must select order number first");
            Od= b.orderNumber;
            float price = bl.totalprice(Od);
           
            if (chechboxtip.IsChecked==true)
                label1.Content = bl.totalPriceWithTip(Od,int.Parse(tiptextbox.Text));
            else
            label1.Content = bl.totalprice(Od);
            //MessageBox.Show("your total price for order: "+Od+"  is: "+price.ToString()); 
        }

        private void chechboxtip_Checked(object sender, RoutedEventArgs e)
        {
         tiptextbox.IsEnabled = true;
           
        }
        private void chechboxtip_unChecked(object sender, RoutedEventArgs e)
        {
            tiptextbox.IsEnabled =false;
        }

        private void button_Click(object sender, RoutedEventArgs e)//calculates total price with tip
        {
            try {
                object a = orderNumberComboBox.SelectedValue;
                BE.Order b = a as BE.Order;
                if (a == null)
                    throw new Exception("must select order number first");
                Od = b.orderNumber;
                string s = tiptextbox.Text;
                int.Parse(s);
                label1.Content = bl.totalPriceWithTip(Od, int.Parse(s));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
