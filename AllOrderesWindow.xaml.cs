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
using BE;
namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for AllOrderesWindow.xaml
    /// </summary>
    public partial class AllOrderesWindow : Window
    {
        BL.IBL bl;
        DataGrid d;
        public AllOrderesWindow()
        {
            d = new DataGrid();
            InitializeComponent();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            dataGrid.ItemsSource = bl.listOreders();
            orderdate.SelectedDate = DateTime.Now;//brerat mechdal for date
            orderHechser.ItemsSource= Enum.GetValues(typeof(BE.hechsher));
            //orderHechser.SelectedItem = BE.hechsher;
            OrderNumber.ItemsSource = bl.listOreders();
            OrderNumber.DisplayMemberPath = "orderNumber";
            branchNumber.ItemsSource = bl.listBranch();
            branchNumber.DisplayMemberPath = "branchNumber";



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(checkBoxordernumber.IsChecked==true)
            {
                if(((string)OrderNumber.Text == ""))
                   MessageBox.Show("You must Enter order number");
                else
                {
                 List<BE.Order> l = new List<BE.Order>();
                l.Add(bl.OrderByNumber(OrderNumber.Text));
                dataGrid.ItemsSource = l;
                }
               
            }
            if(checkBoxbranchNumber.IsChecked==true)
            {
                if (branchNumber.Text == "")
                              MessageBox.Show("You must Enter branch number");
                else
                {

                    dataGrid.ItemsSource = bl.OrderByBranch(int.Parse(branchNumber.Text));
                   }


            }
            if (checkBoxhechsher.IsChecked == true)
            {
                if((BE.hechsher)orderHechser.SelectedValue == (BE.hechsher)0)
                   MessageBox.Show("You must Enter Hechsher");
                if ((BE.hechsher)orderHechser.SelectedValue == BE.hechsher.best)
                    dataGrid.ItemsSource = bl.orderUnderCondition(bl.conOrderHechsher1);
                if ((BE.hechsher)orderHechser.SelectedValue == BE.hechsher.medium)
                    dataGrid.ItemsSource = bl.orderUnderCondition(bl.conOrderHechsher2);
                if ((BE.hechsher)orderHechser.SelectedValue == BE.hechsher.regular)
                    dataGrid.ItemsSource = bl.orderUnderCondition(bl.conOrderHechsher3);
                orderHechser.SelectedItem = (BE.hechsher)0;

            }
            if (checkBoxorderDate.IsChecked == true)
                    dataGrid.ItemsSource = bl.conOrderMonth((DateTime)orderdate.SelectedDate);
        }

        private void checkBoxordernumber_Checked(object sender, RoutedEventArgs e)
        {
           // checkBoxordernumber.IsEnabled = true;
            checkBoxbranchNumber.IsEnabled = true;
            checkBoxbranchNumber.IsChecked = false;
            branchNumber.IsEnabled = false;
            checkBoxhechsher.IsEnabled = true;
            checkBoxhechsher.IsChecked = false;
            orderHechser.IsEnabled = false;
            checkBoxorderDate.IsEnabled = true;
            checkBoxorderDate.IsChecked = false;
            orderdate.IsEnabled = false;
            OrderNumber.IsEnabled = true;

        }
        private void checkBoxordernumber_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxordernumber.IsEnabled = true;
            OrderNumber.IsEnabled = false;
            checkBoxbranchNumber.IsEnabled = true;
            branchNumber.IsEnabled = false;
            checkBoxhechsher.IsEnabled = true;
            orderHechser.IsEnabled = false;
            checkBoxorderDate.IsEnabled = true;
            orderdate.IsEnabled = false;
        }
       

        private void checkBoxbranchNumber_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxordernumber.IsEnabled = true;
            checkBoxordernumber.IsChecked = false;
            OrderNumber.IsEnabled = false;     
            checkBoxhechsher.IsEnabled = true;
            orderHechser.IsEnabled = false;
            checkBoxhechsher.IsChecked = false;
            checkBoxorderDate.IsEnabled = true;
            checkBoxorderDate.IsChecked = false;
            orderdate.IsEnabled = false;
            checkBoxbranchNumber.IsEnabled = true;
            branchNumber.IsEnabled = true;

        }
        private void checkBoxbranchNumber_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxordernumber.IsEnabled = true;
            OrderNumber.IsEnabled = false;
            checkBoxbranchNumber.IsEnabled = true;
            branchNumber.IsEnabled = false;
            checkBoxhechsher.IsEnabled = true;
            orderHechser.IsEnabled = false;
            checkBoxorderDate.IsEnabled = true;
            orderdate.IsEnabled = false;
        }

        private void checkBoxhechsher_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxordernumber.IsEnabled = true;
            checkBoxordernumber.IsChecked = false;
            OrderNumber.IsEnabled = false;
            checkBoxbranchNumber.IsEnabled = true;
            checkBoxbranchNumber.IsChecked = false;
            branchNumber.IsEnabled = false;
            checkBoxorderDate.IsEnabled = true;
            checkBoxorderDate.IsChecked = false;
            orderdate.IsEnabled = false;
            checkBoxhechsher.IsEnabled = true;
            orderHechser.IsEnabled = true;

        }
        private void checkBoxhechsher_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxordernumber.IsEnabled = true;
            OrderNumber.IsEnabled = false;
            checkBoxbranchNumber.IsEnabled = true;
            branchNumber.IsEnabled = false;
            checkBoxhechsher.IsEnabled = true;
            orderHechser.IsEnabled = false;
            checkBoxorderDate.IsEnabled = true;
            orderdate.IsEnabled = false;
        }

        private void checkBoxorderDate_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxordernumber.IsEnabled = true;
            checkBoxordernumber.IsChecked = false;
            OrderNumber.IsEnabled = false;
            checkBoxbranchNumber.IsEnabled = true;
            checkBoxbranchNumber.IsChecked = false;
            branchNumber.IsEnabled = false;
            checkBoxhechsher.IsEnabled = true;
            checkBoxhechsher.IsChecked = false;
            orderHechser.IsEnabled = false;
            checkBoxorderDate.IsEnabled = true;
            orderdate.IsEnabled = true;

        }
        private void checkBoxorderDate_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxordernumber.IsEnabled = true;
            OrderNumber.IsEnabled = false;
            checkBoxbranchNumber.IsEnabled = true;
            branchNumber.IsEnabled = false;
            checkBoxhechsher.IsEnabled = true;
            orderHechser.IsEnabled = false;
            checkBoxorderDate.IsEnabled = true;
            orderdate.IsEnabled = false;

        }

     

       
    }
    }
