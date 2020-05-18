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
    /// Interaction logic for AllOrderedDishesWindow.xaml
    /// </summary>
    public partial class AllOrderedDishesWindow : Window
    {

        BL.IBL bl;
        DataGrid d;
        public AllOrderedDishesWindow()
        {
            d = new DataGrid();
            InitializeComponent();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            dataGrid.ItemsSource = bl.listorderedDishes();
            ordernumber.ItemsSource = bl.listOreders();
            ordernumber.DisplayMemberPath = "orderNumber";
            dishnumber.ItemsSource = bl.listDishes();
            dishnumber.DisplayMemberPath = "dishNumber";

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (searchbyordernumber.IsChecked == true)
            {
                if (ordernumber.Text == "")
                    MessageBox.Show("you must choose order number first..:)");
                else // (searchbyordernumber.IsEnabled == true)
                    dataGrid.ItemsSource = bl.ordereddishbyordernumber(ordernumber.Text);
            }
            if (searchbydishnumber.IsChecked==true)
            {
                if (dishnumber.Text == "")
                    MessageBox.Show("you must choose dish number first..:)");
                else // (searchbydishnumber.IsEnabled == true)
                    dataGrid.ItemsSource = bl.ordereddishbydishnumber(int.Parse(dishnumber.Text));
            }
            if (searchbynumberofdishes.IsChecked==true)
            {
                if (numofdishes.Text == ""|| numofdishes.Text == "enter amoutof dish:")
                    MessageBox.Show("you must choose num of dishes first..:)");
                else // (searchbynumberofdishes.IsEnabled == true)
                    dataGrid.ItemsSource = bl.ordereddishbyamount(int.Parse(numofdishes.Text));
            }
        }

        private void searchbyordernumber_Checked(object sender, RoutedEventArgs e)
        {
            searchbydishnumber.IsEnabled = true;
            searchbydishnumber.IsChecked = false;
            dishnumber.IsEnabled = false;
            searchbynumberofdishes.IsEnabled = true;
            searchbynumberofdishes.IsChecked = false;
            numofdishes.IsEnabled = false;

            searchbyordernumber.IsEnabled = true;
            ordernumber.IsEnabled = true;
        }
        private void searchbyordernumber_unChecked(object sender, RoutedEventArgs e)
        {
            searchbyordernumber.IsEnabled = true;
            ordernumber.IsEnabled = false;
            searchbydishnumber.IsEnabled = true;
            dishnumber.IsEnabled = false;
            searchbynumberofdishes.IsEnabled = true;
            numofdishes.IsEnabled = false;

        }

        private void searchbydishnumber_Checked(object sender, RoutedEventArgs e)
        {

            searchbyordernumber.IsEnabled = true;
            searchbyordernumber.IsChecked = false;
            ordernumber.IsEnabled = false;     
            searchbynumberofdishes.IsEnabled = true;
            searchbynumberofdishes.IsChecked = false;
            numofdishes.IsEnabled = false;
            searchbydishnumber.IsEnabled = true;
            dishnumber.IsEnabled = true;


        }
        private void searchbydishnumber_unChecked(object sender, RoutedEventArgs e)
        {

            searchbyordernumber.IsEnabled = true;
            ordernumber.IsEnabled = false;
            searchbydishnumber.IsEnabled = true;
            dishnumber.IsEnabled = false;
            searchbynumberofdishes.IsEnabled = true;
            numofdishes.IsEnabled = false;

        }

        private void searchbynumberofdishes_Checked(object sender, RoutedEventArgs e)
        {
            searchbyordernumber.IsEnabled = true;
            searchbyordernumber.IsChecked = false;
            ordernumber.IsEnabled = false;
            searchbydishnumber.IsEnabled = true;
            searchbydishnumber.IsChecked = false;
            dishnumber.IsEnabled = false;
            searchbynumberofdishes.IsEnabled = true;
            numofdishes.IsEnabled = true;
        }
        private void searchbynumberofdishes_unChecked(object sender, RoutedEventArgs e)
        {
            searchbyordernumber.IsEnabled = true;
            ordernumber.IsEnabled = false;
            searchbydishnumber.IsEnabled = true;
            dishnumber.IsEnabled = false;
            searchbynumberofdishes.IsEnabled = true;
            numofdishes.IsEnabled = false;
        }

        private void numofdishes_MouseEnter(object sender, MouseEventArgs e)
        {
            numofdishes.Text = "";
        }

        private void numofdishes_MouseLeave(object sender, MouseEventArgs e)
        {
           // numofdishes.Text = "Enter amount of Dish";
        }
    }
}
