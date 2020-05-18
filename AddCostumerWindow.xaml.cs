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
    /// Interaction logic for AddCostumerWindow.xaml
    /// </summary>
    public partial class AddCostumerWindow : Window
    {
        BE.Costumer costumerr;
        BL.IBL bl;

        public AddCostumerWindow()
        {
            try { 
            InitializeComponent();
            costumerr = new BE.Costumer();
            this.DataContext = costumerr;

            bl = BL.FactoryBL.GetBL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

        private void addcostumerbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                
                    bl.AddCostumer(costumerr);
                MessageBox.Show("Costumer  " + costumerr.costumerName + " was added successfully");
                //MessageBox.Show("הוסף בהצלחה" + costumerr.costumerName + " לקוח ");

                costumerr = new BE.Costumer();
                this.DataContext = costumerr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tzTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;

                if ((!int.TryParse(tzTextBox.Text, out a)) && tzTextBox.Text != "")
                {
                    tzTextBox.Text = "";
                    throw new Exception("id must iclude only numbers");
                }
                if ((a < 100000000 || a > 999999999) && tzTextBox.Text != "")
                {
                    tzTextBox.Text = "";
                    throw new Exception("id must be 9 digits");
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
               // else
                //    costumerNameTextBox.BorderBrush = Brushes.Yellow;

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

        private void creditCardTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (creditCardTextBox.Text != "0")
                {
                    if (!int.TryParse(creditCardTextBox.Text, out a))
                    {
                        creditCardTextBox.Text = "";
                        throw new Exception("credit card must contain only numbers");
                    }
                    if (a < 10000 || a > 1000000000)
                    {
                        creditCardTextBox.Text = "";
                        throw new Exception("impossible number of digits for credit card");
                    }
                }
                //else if (creditCardTextBox.Text == "0")
                  //  throw new Exception("you must enter credit card number");
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
