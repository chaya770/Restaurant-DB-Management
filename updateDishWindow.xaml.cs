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
    /// Interaction logic for updateDishWindow.xaml
    /// </summary>
    public partial class updateDishWindow : Window
    {

        BE.Dish d;
        BL.IBL bl;

        public updateDishWindow()
        {
            InitializeComponent();
            d = new BE.Dish();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.hechsher));
            dishSizeComboBox.ItemsSource = Enum.GetValues(typeof(BE.size));
            dishNumberComboBox.ItemsSource = bl.listDishes();
            dishNumberComboBox.DisplayMemberPath = "dishNumber";
            dishNumberComboBox.DataContext = d.dishNumber;//brirat mechdal

        }

        private void UPDATE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.SetDish(d);
                MessageBox.Show("Dish number: " + d.dishNumber + " was updated successfully");
                //   MessageBox.Show("עודכנה בהצלחה"+d.dishNumber + " מנה ");

                d = new BE.Dish();
                this.DataContext = d;
                hechsherComboBox.DataContext = "";
                dishSizeComboBox.DataContext = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dishNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = dishNumberComboBox.SelectedValue;
            BE.Dish b = a as BE.Dish;
            if (a == null)
                throw new Exception("must select branch first");
            d.dishNumber= b.dishNumber;
            d = b;
            DataContext = b;
        }

        private void caloriesTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (caloriesTextBox.Text != "0")
                {
                    if (!int.TryParse(caloriesTextBox.Text, out a))
                    {
                        caloriesTextBox.Text = "0";
                        throw new Exception("calories textbox must contain only numbers");
                    }
                    if (a < 0)
                    {
                        caloriesTextBox.Text = "0";
                        throw new Exception(" calories textbox must be at lest 0");
                    }
                    if (a > 2000)
                    {
                        caloriesTextBox.Text = "0";
                        throw new Exception("calories can not be over 2000 (otherwise you will be very fat...)");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dishNameTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            try
            {
                Char[] help = dishNameTextBox.Text.ToCharArray();
                if (dishNameTextBox.Text != "")
                {
                    for (int i = 0; i < help.Length; i++)
                    {
                        if (!((help[i] >= 'a' && help[i] <= 'z') || (help[i] >= 'A' && help[i] <= 'Z') || ((help[i] >= 'א' && help[i] <= 'ת')) || (help[i] == ' ')))
                        {
                            dishNameTextBox.Text = "";
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

        private void dishPriceTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (dishPriceTextBox.Text != "0")
                {
                    if (!int.TryParse(dishPriceTextBox.Text, out a))
                    {
                        dishPriceTextBox.Text = "0";
                        throw new Exception("dish price must contain only numbers");
                    }
                    if (a < 0)
                    {
                        dishPriceTextBox.Text = "0";
                        throw new Exception(" dish price must be at lest 0");
                    }
                    if (a > 200)
                    {
                        dishPriceTextBox.Text = "0";
                        throw new Exception("dish price can't be over 200 ");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rateTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                int a;
                if (rateTextBox.Text != "0")
                {
                    if (!int.TryParse(rateTextBox.Text, out a))
                    {
                        rateTextBox.Text = "0";
                        throw new Exception("rate must contain only numbers");
                    }
                    if (a < 0)
                    {
                        rateTextBox.Text = "0";
                        throw new Exception(" rate must be at lest 0");
                    }
                    if (a > 10)
                    {
                        rateTextBox.Text = "0";
                        throw new Exception("rate can't be over 10 ");
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
