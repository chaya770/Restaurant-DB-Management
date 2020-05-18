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
    /// Interaction logic for AllCostumersWindow.xaml
    /// </summary>
    public partial class AllCostumersWindow : Window
    {
        BL.IBL bl;
        DataGrid d;
        public AllCostumersWindow()
        {
            d = new DataGrid();
            //InitializeComponent();
            InitializeComponent();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            dataGrid.ItemsSource = bl.listCostumers();


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (namecheckbox.IsChecked == true)
                {
                    List<BE.Costumer> l = new List<BE.Costumer>();
                    l.Add(bl.CostumerByName(name.Text));
                    dataGrid.ItemsSource = l;
                }
                else if (ischeckbox.IsChecked == true)
                {
                    List<BE.Costumer> l = new List<BE.Costumer>();
                    l.Add(bl.CostumerById(id.Text));
                    dataGrid.ItemsSource = l;
                }
                else if (membershipcheckbox.IsChecked == true)
                    dataGrid.ItemsSource = bl.costumerUnderCondition(bl.ConCostumerMemberShip);
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
                   
        }

        private void namecheckbox_Checked(object sender, RoutedEventArgs e)
        {
            ischeckbox.IsEnabled = true;
            ischeckbox.IsChecked = false;
            id.IsEnabled = false;
            membershipcheckbox.IsEnabled = true;
            membershipcheckbox.IsChecked = false;
            namecheckbox.IsEnabled = true;
            name.IsEnabled = true;

        }
        private void namecheckbox_unChecked(object sender, RoutedEventArgs e)
        {
            namecheckbox.IsEnabled = true;
            name.IsEnabled = false;
            ischeckbox.IsEnabled = true;
            id.IsEnabled = false;
            membershipcheckbox.IsEnabled = true;
        }

        private void ischeckbox_Checked(object sender, RoutedEventArgs e)
        {
            namecheckbox.IsEnabled = true;
            namecheckbox.IsChecked = false;
            name.IsEnabled = false; 
            membershipcheckbox.IsEnabled = true;
            membershipcheckbox.IsChecked = false;
            ischeckbox.IsEnabled = true;
            id.IsEnabled = true;

        }
        private void ischeckbox_unChecked(object sender, RoutedEventArgs e)
        {
            namecheckbox.IsEnabled = true;
            name.IsEnabled = false;
            ischeckbox.IsEnabled = true;
            id.IsEnabled = false;
            membershipcheckbox.IsEnabled = true;
        }

        private void membershipcheckbox_Checked(object sender, RoutedEventArgs e)
        {
            namecheckbox.IsEnabled = true;
            namecheckbox.IsChecked = false;
            name.IsEnabled = false;
            ischeckbox.IsEnabled = true;
            ischeckbox.IsChecked = false;
            id.IsEnabled = false;
            membershipcheckbox.IsEnabled = true;

        }
        private void membershipcheckbox_unChecked(object sender, RoutedEventArgs e)
        {
            namecheckbox.IsEnabled = true;
            name.IsEnabled = false;
            ischeckbox.IsEnabled = true;
            id.IsEnabled = false;
            membershipcheckbox.IsEnabled = true;
        }

        private void name_MouseEnter(object sender, MouseEventArgs e)
        {
            name.Text = "";
        }

        private void name_MouseLeave(object sender, MouseEventArgs e)
        {
          //  name.Text = "Enter name for selection:";
        }

        private void id_MouseEnter(object sender, MouseEventArgs e)
        {
            id.Text = "";
        }

        private void id_MouseLeave(object sender, MouseEventArgs e)
        {
           // id.Text = "Enter Id for selection";
        }
    }
}
