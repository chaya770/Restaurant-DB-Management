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
    /// Interaction logic for addOrder.xaml
    /// </summary>
    public partial class addOrder : Window
    {
        BE.Order order;
        BL.IBL bl;
        public addOrder()
        {
            InitializeComponent();
          
            order = new BE.Order();
            DataContext = order;
            bl = BL.FactoryBL.GetBL();
            order.date = DateTime.Now;
            HechsherCampusComboBox.ItemsSource=Enum.GetValues(typeof(BE.hechsher));
            //BranchNumberTextBox will get the list of orders in the order list
            BranchNumberTextBox.ItemsSource = bl.listBranch();
            BranchNumberTextBox.DisplayMemberPath = "branchNumber";
            //BranchNumberTextBox.DataContext = order.branchNumber;//brirat mechdal
            //this.BranchNumberTextBox.SelectedValuePath = "branchNumber";
            // NumWorkersTextBox.Text=bl.listBranch.

            costumercombobox.ItemsSource = bl.listCostumers();
            costumercombobox.DisplayMemberPath = "tz";
            //costumercombobox.SelectedValuePath = "tz";

        }

        private void Addbutton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
               DateTime d= DateTime.Now;
                DateTime ed = (DateTime)OrderDateDatePicker.SelectedDate;
                if (ed.Year<d.Year|| (ed.Year == d.Year&& ed.Month < d.Month)||(ed.Year == d.Year && ed.Month == d.Month&& ed.Day < d.Day))
                    throw new Exception("canot add order with a date that already passed...");

                bl.AddOrder(order);
                MessageBox.Show("order: "+order.orderNumber+"  was added");
                //this.Resources["Add"]
                //if(App.Current.Resources.MergedDictionaries== EnglishDictonary.xaml)
                //MessageBox.Show("הוספה בהצלחה" + order.orderNumber + " הזמנה ");

                order = new BE.Order();
                this.DataContext = order;
                   new AddOrderedDishWindow().Show();
                HechsherCampusComboBox.DataContext = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void costumercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                BE.Costumer c = GetSelecetdCostumer();
                order.costumerTz = c.tz;
            }
        }
        private BE.Costumer GetSelecetdCostumer()
        {
            object a = costumercombobox.SelectedValue;
            //object b = DS.DataSource.costumerList.FirstOrDefault(s => s.tz == a.ToString());
            BE.Costumer c = a as BE.Costumer;
            if (a== null)
                throw new Exception("must select costumer first");
            else
                return c;
        }
        private void BranchNumberTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                order.branchNumber = GetSelectedBranchNumber();
          
        }
        private int GetSelectedBranchNumber()
        {
            object a = BranchNumberTextBox.SelectedValue;
            BE.Branch b = a as BE.Branch;
            if (a == null)
                throw new Exception("must select branch first");
            return b.branchNumber;
           

        }

     
    }
}
