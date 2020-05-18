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
    /// Interaction logic for deleteCostumerWindow.xaml
    /// </summary>
    public partial class deleteCostumerWindow : Window
    {
        BE.Costumer c;
        BL.IBL bl;
        public deleteCostumerWindow()
        {
            InitializeComponent();
            c = new BE.Costumer();
            this.DataContext = c;
            bl = BL.FactoryBL.GetBL();
            tzComboBox.ItemsSource = bl.listCostumers();
            //tzComboBox.DisplayMemberPath = "tz";
            //tzComboBox.DataContext = c.tz;//brirat mechdal


        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DeleteCostumer(c.tz);
                MessageBox.Show("Costumer  " + c.tz + " was deleted successfully");
               // if((BE.language)MainWindow.LanguageProperty.PropertyType==  BE.language.עברית)
                //MessageBox.Show("נמחק בהצלחה" + c.tz + " לקוח ");

                //tzComboBox.ItemsSource = bl.listCostumers();
                //tzComboBox.DisplayMemberPath = "tz";

                c = new BE.Costumer();
                this.DataContext = c;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tzComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object a = tzComboBox.SelectedValue;
            BE.Costumer b = a as BE.Costumer;
           //if (a == null)
                //throw new Exception("must select costumer first");
            c.tz = b.tz;


        }
    }
}
