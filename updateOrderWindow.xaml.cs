using System;
using System.Collections;
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
    /// Interaction logic for updateOrderWindow.xaml
    /// </summary>
    public partial class updateOrderWindow : Window
    {
        BE.Order order;
        BL.IBL bl;
        public updateOrderWindow()
        {
            InitializeComponent();
            order = new BE.Order();
            DataContext = order;
            bl = BL.FactoryBL.GetBL();
            hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.hechsher));

            branchNumberComboBox.ItemsSource = bl.listBranch();
            branchNumberComboBox.DisplayMemberPath = "branchNumber";
            //branchNumberComboBox.DataContext = order.branchNumber;//brirat mechdal

            orderNumberCombotBox.ItemsSource = bl.listOreders();
            orderNumberCombotBox.DisplayMemberPath = "orderNumber";
            //orderNumberCombotBox.DataContext = order.orderNumber;//brirat mechdal

            comboBox_Copy.ItemsSource = bl.listCostumers();
            comboBox_Copy.DisplayMemberPath = "tz";

        }



        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((DateTime)dateDatePicker.SelectedDate < DateTime.Now)
                    throw new Exception("canot udate order with a date that already passed...");

                object b = branchNumberComboBox.SelectedValue;
                BE.Branch bb = b as BE.Branch;
                object c = comboBox_Copy.SelectedValue;
                BE.Costumer cc = c as BE.Costumer;
              

                order.branchNumber = bb.branchNumber;
                order.costumerTz = cc.tz;
                order.Hechsher = (BE.hechsher)hechsherComboBox.SelectedValue;
                order.date = (DateTime)dateDatePicker.SelectedDate;
                //DataContext = b;
                bl.SetOrder(order);
                MessageBox.Show("order: " + order.orderNumber + "  was updated");
                //MessageBox.Show("עודכנה בהצלחה" + order.orderNumber + " הזמנה ");

                order = new BE.Order();
                this.DataContext = order;
                branchNumberComboBox.DataContext = "";
                hechsherComboBox.DataContext = "";
                dateDatePicker.DataContext = DateTime.Now;
                orderNumberCombotBox.DataContext = "";
                comboBox_Copy.DataContext = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderNumberCombotBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                object a = orderNumberCombotBox.SelectedValue;
                BE.Order b = a as BE.Order;
                if (a == null)
                    throw new Exception("must select order first");
                order.orderNumber = b.orderNumber;
                order.branchNumber = b.branchNumber;
                order.costumerTz = b.costumerTz;
                order.Hechsher = b.Hechsher;
                    DataContext = b;
                branchNumberComboBox.DataContext = b.branchNumber;
                comboBox_Copy.DataContext = b.costumerTz;
            }

        }
    }
}
