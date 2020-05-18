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
    /// Interaction logic for updateCostumerWindow.xaml
    /// </summary>
    public partial class updateCostumerWindow : Window
    {

        BE.Costumer c;
        BL.IBL bl;

        public updateCostumerWindow()
        {
            InitializeComponent();
            c = new BE.Costumer();
            this.DataContext = c;
            bl = BL.FactoryBL.GetBL();

            tzComboBox.ItemsSource = bl.listCostumers();
            tzComboBox.DisplayMemberPath = "tz";
            tzComboBox.DataContext = c.tz;//brirat mechdal



        }



        private void tzComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = tzComboBox.SelectedValue;
            BE.Costumer b = a as BE.Costumer;
            if (a == null)
                throw new Exception("must select costumer first");
                 c = b;
            DataContext = b;

        }
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                   bl.SetCostumer(c);
                MessageBox.Show("Costumer  " + c.costumerName + " was updated successfully");
                //MessageBox.Show("עודכן בהצלחה" + c.costumerName + " לקוח ");

                c = new BE.Costumer();
                this.DataContext = c;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void costumerAgeTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            try
            {
                int a;
                if (costumerAgeTextBox.Text != "0")
                {
                    if (!int.TryParse(costumerAgeTextBox.Text, out a))
                    {
                        costumerAgeTextBox.Text = "0";
                        throw new Exception("age must contain only numbers");
                    }
                    if (a < 18)
                    {
                        costumerAgeTextBox.Text = "0";
                        throw new Exception("costumer age must be over 18");
                    }
                    if (a > 120)
                    {
                        costumerAgeTextBox.Text = "0";
                        throw new Exception("costumer age not possible");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void costumerNameTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                Char[] help = costumerNameTextBox.Text.ToCharArray();
                if (costumerNameTextBox.Text != "")
                {
                    for (int i = 0; i < help.Length; i++)
                    {
                        if (!((help[i] >= 'a' && help[i] <= 'z') || (help[i] >= 'A' && help[i] <= 'Z') || ((help[i] >= 'א' && help[i] <= 'ת')) || (help[i] == ' ')))
                            {
                            costumerNameTextBox.Text = "";
                            throw new Exception("name must contain letters only");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void creditCardTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (creditCardTextBox.Text != "0")
                {
                    if (!int.TryParse(creditCardTextBox.Text, out a))
                    {
                        creditCardTextBox.Text = "0";
                        throw new Exception("credit card must contain only numbers");
                    }
                    if (a < 10000 || a > 1000000000)
                    {
                        creditCardTextBox.Text = "0";
                        throw new Exception("impossible number of digits for credit card");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
         }
    }
}
