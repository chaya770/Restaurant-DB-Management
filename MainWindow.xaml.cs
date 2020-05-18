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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL bl;
        public MainWindow()
        {
            bl = BL.FactoryBL.GetBL();
            InitializeComponent();
            languagecomboBox.ItemsSource= Enum.GetValues(typeof(BE.language));
            
        }

        private void AddCostumerButton_Click(object sender, RoutedEventArgs e)
        {
            new AddCostumerWindow().Show();
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Window addorderwindow = new addOrder();
            addorderwindow.Show();
        }

        private void SetOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Window updateorderwindow = new updateOrderWindow();
            updateorderwindow.Show();

        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            new deleteOrderWindow().Show();
        }

        private void AddBranchButton_Click(object sender, RoutedEventArgs e)
        {
            new addBranch().Show();
        }

        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            new addDishWindow().Show();
        }

        private void AddOrderedDishButton_Click(object sender, RoutedEventArgs e)
        {
            new AddOrderedDishWindow().Show();
        }

        private void SetBranchButton_Click(object sender, RoutedEventArgs e)//update
        {
            new updateBranchWindow().Show();
        }

        private void SetDishButton_Click(object sender, RoutedEventArgs e)
        {
            new updateDishWindow().Show();
        }

        private void SetCostumerButton_Click(object sender, RoutedEventArgs e)
        {
            new updateCostumerWindow().Show();
        }

        private void DeleteDishButton_Click(object sender, RoutedEventArgs e)
        {
            new deleteDishWindow().Show();
        }

        private void DeleteBranchButton_Click(object sender, RoutedEventArgs e)
        {
            new deleteBranchWindow().Show();
        }

        private void DeleteCostumerButton_Click(object sender, RoutedEventArgs e)
        {
            new deleteCostumerWindow().Show();
        }

        private void DeleteOrderedDishButton_Click(object sender, RoutedEventArgs e)
        {
            new deleteOrderedDishWindow().Show();
        }

        private void SetOrderedDishButton_Click(object sender, RoutedEventArgs e)
        {
            new updateOrderedDishWindow().Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new PriceWindow().Show();
        }

        private void languagecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((BE.language)languagecomboBox.SelectedValue) == BE.language.עברית)
            {
            Uri dictUri = new Uri("HebrewDictonary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            else if (((BE.language)languagecomboBox.SelectedValue) == BE.language.English)

            {
                Uri dictUri = new Uri("EnglishDictionary.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

                //Application.Current.Resources.MergedDictionaries.Clear();
                //Application.Current.Resources.MergedDictionaries.Add(EnglishDictonary.xaml);

                //Uri d=("EnglishDictonary.xaml", UriKind.Relative);
                //// ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
                // Application.Current.Resources.MergedDictionaries.Clear();
                // Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            new AllDishesWindow().Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            new AllOrderesWindow().Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            new AllBranchesWindow().Show();
        }

        private void button4_Click(object sende, RoutedEventArgs e)
        {
            new AllCostumersWindow().Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            new AllOrderedDishesWindow().Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            GroupingorderedDishByDish uc = new GroupingorderedDishByDish();
            uc.Source = bl.groupbyKindOfDish();

            this.page.Content = uc;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            GroupingorderedDishByCity uc = new GroupingorderedDishByCity();
            uc.Source = bl.groupByCity();

            this.page.Content = uc;
        }

        private void buttonGroupDish_Click(object sender, RoutedEventArgs e)
        {
            GrouporderedDishByDays uc = new GrouporderedDishByDays();
            uc.Source = bl.groupByTime();

            this.page.Content = uc;
        }

        private void buttonGroupHechsher_Click(object sender, RoutedEventArgs e)
        {
            Grouping_OrderedDishByHechsher uc = new Grouping_OrderedDishByHechsher();
            uc.Source = bl.groupByHechsher();

            this.page.Content = uc;
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            new BillWindow().Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            new caloriesWindow().Show();
        }
    }
}
