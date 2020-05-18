using BE;
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
    /// Interaction logic for AllDishesWindow.xaml
    /// </summary>
    public partial class AllDishesWindow : Window
    {
        BL.IBL bl;
        DataGrid d;
        public AllDishesWindow()
        {
            InitializeComponent();
            d = new DataGrid();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            allDishesDataGrid.ItemsSource = bl.listDishes();
            dishsize.ItemsSource = Enum.GetValues(typeof(BE.size));
            hechshercombobox.ItemsSource = Enum.GetValues(typeof(BE.hechsher));
            Dishnumber.ItemsSource = bl.listDishes();
            Dishnumber.DisplayMemberPath = "dishNumber";
            Dishname.ItemsSource = bl.listDishes();
            Dishname.DisplayMemberPath = "dishName";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (checkBoxDishnumber.IsChecked == true)
            {
                List<BE.Dish> l = new List<Dish>();
                if (((string)Dishnumber.Text == ""))
                    MessageBox.Show("You must Enter dish number");
                else
                {
                    l.Add(bl.DishByNumber(int.Parse(Dishnumber.Text)));
                    allDishesDataGrid.ItemsSource = l;
                }
            }
            else if (checkBoxDishName.IsChecked == true)
            {
                List<BE.Dish> l = new List<Dish>();
                if (((string)Dishname.Text == ""))
                    MessageBox.Show("You must Enter dish name");
                else
                {
                    l.Add(bl.DishByName(Dishname.Text));
                    allDishesDataGrid.ItemsSource = l;
                }

            }
            else if (checkBoxDishSize.IsChecked == true)
            {
                if ((BE.size)dishsize.SelectedValue == size.small)
                    allDishesDataGrid.ItemsSource = bl.dishUnderCondition(bl.ConDishesSizeSmall);
                else if ((BE.size)dishsize.SelectedValue == size.medium)
                    allDishesDataGrid.ItemsSource = bl.dishUnderCondition(bl.ConDishesSizeMedium);
                else if ((BE.size)dishsize.SelectedValue == size.large)
                    allDishesDataGrid.ItemsSource = bl.dishUnderCondition(bl.ConDishesSizeMediumLarge);

            }
            else if (checkBoxDishPrice.IsChecked == true)
            {
                if (((string)pricetextbx.Text == ""))
                    MessageBox.Show("You must enter price first");
                else
                {

                    allDishesDataGrid.ItemsSource = bl.DishesByMaxPrice(int.Parse(pricetextbx.Text));
                }
            }
            else if (checkBoxDishHechsher.IsChecked == true)
            {
                if ((BE.hechsher)hechshercombobox.SelectedValue == hechsher.best)
                    allDishesDataGrid.ItemsSource = bl.dishUnderCondition(bl.ConDishesHechsherBest);
                if ((BE.hechsher)hechshercombobox.SelectedValue == hechsher.medium)
                    allDishesDataGrid.ItemsSource = bl.dishUnderCondition(bl.ConDishesHechsherMedium);
                if ((BE.hechsher)hechshercombobox.SelectedValue == hechsher.regular)
                    allDishesDataGrid.ItemsSource = bl.dishUnderCondition(bl.ConDishesHechsherRegular);
            }
            else if (checkBoxDishCalories.IsChecked == true)
            {
                if (((string)calories.Text == ""))
                    MessageBox.Show("You must enter calories first");
                else
                {

                    allDishesDataGrid.ItemsSource = bl.DishesByMaxCalories(int.Parse(calories.Text));
                }
            }
            else if (checkBoxDishrate.IsChecked == true)
            {

                if (((string)rate.Text == ""))
                    MessageBox.Show("You must enter rate first");
                else

                    allDishesDataGrid.ItemsSource = bl.DishesByMinRate(int.Parse(rate.Text));
            }
        }

        private void checkBoxDishnumber_Checked(object sender, RoutedEventArgs e)
        {
           
            checkBoxDishName.IsEnabled = true;
            checkBoxDishName.IsChecked = false;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            checkBoxDishSize.IsChecked = false;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            checkBoxDishPrice.IsChecked = false;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            checkBoxDishHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            checkBoxDishCalories.IsChecked = false;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            checkBoxDishrate.IsChecked = false;
            rate.IsEnabled = false;
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = true;

        }
        private void checkBoxDishnumber_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = false;

        }

        private void checkBoxDishName_Checked(object sender, RoutedEventArgs e)
        {

            checkBoxDishnumber.IsEnabled = true;
            checkBoxDishnumber.IsChecked = false;
            Dishnumber.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            checkBoxDishSize.IsChecked = false;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            checkBoxDishPrice.IsChecked = false;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            checkBoxDishHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            checkBoxDishCalories.IsChecked = false;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            checkBoxDishrate.IsChecked = false;
            rate.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = true;

        }
        private void checkBoxDishName_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = false;

        }

        private void checkBoxDishHechsher_Checked(object sender, RoutedEventArgs e)
        {

            checkBoxDishnumber.IsEnabled = true;
            checkBoxDishnumber.IsChecked = false;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            checkBoxDishName.IsChecked = false;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            checkBoxDishSize.IsChecked = false;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            checkBoxDishPrice.IsChecked = false;
            pricetextbx.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            checkBoxDishCalories.IsChecked = false;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            checkBoxDishrate.IsChecked = false;
            rate.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = true;
        }
        private void checkBoxDishHechsher_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = false;
        }

        private void checkBoxDishSize_Checked(object sender, RoutedEventArgs e)
        {

            checkBoxDishnumber.IsEnabled = true;
            checkBoxDishnumber.IsChecked = false;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            checkBoxDishName.IsChecked = false;
            Dishname.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            checkBoxDishPrice.IsChecked = false;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            checkBoxDishHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            checkBoxDishCalories.IsChecked = false;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            checkBoxDishrate.IsChecked = false;
            rate.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = true;

        }
        private void checkBoxDishSize_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = false;
        }

        private void checkBoxDishPrice_Checked(object sender, RoutedEventArgs e)
        {

            checkBoxDishnumber.IsEnabled = true;
            checkBoxDishnumber.IsChecked = false;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            checkBoxDishName.IsChecked = false;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            checkBoxDishSize.IsChecked = false;
            dishsize.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            checkBoxDishHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            checkBoxDishCalories.IsChecked = false;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            checkBoxDishrate.IsChecked = false;
            rate.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = true;

        }
        private void checkBoxDishPrice_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = false;
        }

        private void checkBoxDishCalories_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = false;
        }
        private void checkBoxDishCalories_Checked(object sender, RoutedEventArgs e)
        {

            checkBoxDishnumber.IsEnabled = true;
            checkBoxDishnumber.IsChecked = false;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            checkBoxDishName.IsChecked = false;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            checkBoxDishSize.IsChecked = false;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            checkBoxDishPrice.IsChecked = false;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            checkBoxDishHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            checkBoxDishrate.IsChecked = false;
            rate.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = true;

        }

        private void checkBoxDishrate_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxDishnumber.IsEnabled = true;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = false;
        }
        private void checkBoxDishrate_Checked(object sender, RoutedEventArgs e)
        {

            checkBoxDishnumber.IsEnabled = true;
            checkBoxDishnumber.IsChecked = false;
            Dishnumber.IsEnabled = false;
            checkBoxDishName.IsEnabled = true;
            checkBoxDishName.IsChecked = false;
            Dishname.IsEnabled = false;
            checkBoxDishSize.IsEnabled = true;
            checkBoxDishSize.IsChecked = false;
            dishsize.IsEnabled = false;
            checkBoxDishPrice.IsEnabled = true;
            checkBoxDishPrice.IsChecked = false;
            pricetextbx.IsEnabled = false;
            checkBoxDishHechsher.IsEnabled = true;
            checkBoxDishHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxDishCalories.IsEnabled = true;
            checkBoxDishCalories.IsChecked = false;
            calories.IsEnabled = false;
            checkBoxDishrate.IsEnabled = true;
            rate.IsEnabled = true;

        }

      

        private void pricetextbx_MouseEnter(object sender, MouseEventArgs e)
        {
            pricetextbx.Text = "";
        }

        private void pricetextbx_MouseLeave(object sender, MouseEventArgs e)
        {
           // pricetextbx.Text = "Enter max price :";
        }

        private void calories_MouseEnter(object sender, MouseEventArgs e)
        {
            calories.Text = "";
        }

        private void calories_MouseLeave(object sender, MouseEventArgs e)
        {
            //calories.Text = "Enter max calories :";
        }

        private void rate_MouseEnter(object sender, MouseEventArgs e)
        {
            rate.Text = "";
        }

        private void rate_MouseLeave(object sender, MouseEventArgs e)
        {
           // rate.Text = "Enter min rate :";
        }
    }
}
