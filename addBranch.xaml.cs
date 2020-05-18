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
    /// Interaction logic for addBranch.xaml
    /// </summary>
    public partial class addBranch : Window
    {
        BE.Branch br;
        BL.IBL bl;

        public addBranch()
        {
            InitializeComponent();
            br = new BE.Branch();
            this.DataContext = br;

            bl = BL.FactoryBL.GetBL();
            hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.hechsher));
            mycityComboBox.ItemsSource = Enum.GetValues(typeof(BE.city));
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
             

                bl.AddBranch(br);
                MessageBox.Show("branch name: "+br.branchName+" branch number: "+br.branchNumber+" was added");
                //MessageBox.Show("הוסף בהצלחה" + br.branchName + " סניף ");

                br = new BE.Branch();
                this.DataContext = br;
                hechsherComboBox.DataContext = "";
                mycityComboBox.DataContext = "";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void branchAvailableDeliveryGuysTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (branchAvailableDeliveryGuysTextBox.Text != "0")
                {
                    if (!int.TryParse(branchAvailableDeliveryGuysTextBox.Text, out a))
                    {
                        branchAvailableDeliveryGuysTextBox.Text = "0";
                        throw new Exception("delivery guys textbox must contain only numbers");
                    }
                    if (a < 0)
                    {
                        branchAvailableDeliveryGuysTextBox.Text = "0";
                        throw new Exception("delivery guys textbox must be at lest 0");
                    }
                    if (a > 100)
                    {
                        branchAvailableDeliveryGuysTextBox.Text = "0";
                        throw new Exception("delivery guys textbox cant be more than 100");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void branchNameTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                Char[] help = branchNameTextBox.Text.ToCharArray();
                if (branchNameTextBox.Text != "")
                {
                    for (int i = 0; i < help.Length; i++)
                    {
                        if (!((help[i] >= 'a' && help[i] <= 'z') || (help[i] >= 'A' && help[i] <= 'Z') || ((help[i] >= 'א' && help[i] <= 'ת')) || (help[i] == ' ')))
                        {
                            branchNameTextBox.Text = "";
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

        private void branchNumberTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            try
            {
                int a;
                if (branchNumberTextBox.Text != "0")
                {
                    if (!int.TryParse(branchNumberTextBox.Text, out a))
                    {
                        branchNumberTextBox.Text = "0";
                        throw new Exception("banch number must contain only numbers");
                    }
                    if (a < 0)
                    {
                        branchNumberTextBox.Text = "0";
                        throw new Exception("impossible branch number");
                    }
                  
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void branchNumWorkersTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (branchNumWorkersTextBox.Text != "0")
                {
                    if (!int.TryParse(branchNumWorkersTextBox.Text, out a))
                    {
                        branchNumWorkersTextBox.Text = "0";
                        throw new Exception("num workers must contain only numbers");
                    }
                    if (a < 0)
                    {
                        branchNumWorkersTextBox.Text = "0";
                        throw new Exception("num workers must be at lest 0");
                    }
                    if (a > 100)
                    {
                        branchNumWorkersTextBox.Text = "0";
                        throw new Exception("num workers cant be more than 100");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void branchPhoneNumberTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;

                if ((!int.TryParse(branchPhoneNumberTextBox.Text, out a)) && branchPhoneNumberTextBox.Text != "")
                {
                    branchPhoneNumberTextBox.Text = "";
                    throw new Exception("phone number must iclude only numbers");
                }
                if ((a < 10000000 || a > 999999999) && branchPhoneNumberTextBox.Text != "")
                {
                    branchPhoneNumberTextBox.Text = "";
                    throw new Exception("phone number must be up to 10 digits ");
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void managerTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                Char[] help = managerTextBox.Text.ToCharArray();
                if (managerTextBox.Text != "")
                {
                    for (int i = 0; i < help.Length; i++)
                    {
                        if (!((help[i] >= 'a' && help[i] <= 'z') || (help[i] >= 'A' && help[i] <= 'Z') || ((help[i] >= 'א' && help[i] <= 'ת')) || (help[i] == ' ')))
                        {
                            managerTextBox.Text = "";
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
    }
}
