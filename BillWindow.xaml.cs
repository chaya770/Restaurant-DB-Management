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
    /// Interaction logic for BillWindow.xaml
    /// </summary>
    public partial class BillWindow : Window
    {
        //DataGrid d;
        BL.IBL bl;
        public BillWindow()
        {
            InitializeComponent();
           // d = new DataGrid();
            //this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            orderNumber.ItemsSource = bl.listOreders();
            orderNumber.DisplayMemberPath = "orderNumber";
           

        }

      

        private void orderNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                
                //BillDataGrid.ItemsSource = DS.DataSource.billList;
                object a = orderNumber.SelectedValue;
                BE.Order b = a as BE.Order;
                if (a == null)
                    throw new Exception("must select order first");

                else
                {
                    List<BE.Bill> bbb = bl.calcBill(b.orderNumber);
                    BillDataGrid.ItemsSource = bbb;
                    Price.Content = bl.totalprice(b.orderNumber);
                    //DS.DataSource.billList.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
