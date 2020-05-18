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
    /// Interaction logic for caloriesWindow.xaml
    /// </summary>
    public partial class caloriesWindow : Window
    {

        string Od;
        BL.IBL bl;
        public caloriesWindow()
        {
            InitializeComponent();
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
            Od = b.orderNumber;
           int totalCalories = bl.totalCalories(b.orderNumber);
            float averageCalories = bl.averageCaloriesPerPerson(b.orderNumber);
            
                label3.Content = bl.totalCalories(b.orderNumber);

            label4.Content = bl.averageCaloriesPerPerson(b.orderNumber);
           
        }

    }
}

