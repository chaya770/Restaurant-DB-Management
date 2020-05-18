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
    /// Interaction logic for AllBranchesWindow.xaml
    /// </summary>
    public partial class AllBranchesWindow : Window
    {

        BL.IBL bl;
        DataGrid d;
        public AllBranchesWindow()
        {
            InitializeComponent();
            d = new DataGrid();
            this.DataContext = d;
            bl = BL.FactoryBL.GetBL();
            dataGrid.ItemsSource = bl.listBranch();
            Branchcity.ItemsSource= Enum.GetValues(typeof(BE.city));
            hechshercombobox.ItemsSource= Enum.GetValues(typeof(BE.hechsher));
        }

        private void checkBoxBranchnumber_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchName.IsEnabled = true;
            checkBoxBranchName.IsChecked = false;
            Branchname.IsEnabled = false;
            checkBoxBranchcity.IsEnabled = true;
            checkBoxBranchcity.IsChecked = false;
            Branchcity.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            checkBoxBranchHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxBranchnumber.IsEnabled = true;
            Branchnumber.IsEnabled = true;

        }
        private void checkBoxBranchnumber_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchnumber.IsEnabled = true;
            Branchnumber.IsEnabled = false;
            checkBoxBranchName.IsEnabled = true;
            Branchname.IsEnabled = false;
            checkBoxBranchcity.IsEnabled = true;
            Branchcity.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
        }

        private void checkBoxBranchName_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchnumber.IsEnabled = true;
            checkBoxBranchnumber.IsChecked = false;
            Branchnumber.IsEnabled = false;
             checkBoxBranchcity.IsEnabled = true;
            checkBoxBranchcity.IsChecked = false;
            Branchcity.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            checkBoxBranchHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxBranchName.IsEnabled = true;
            Branchname.IsEnabled = true;

        }
        private void checkBoxBranchName_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchnumber.IsEnabled = true;
            Branchnumber.IsEnabled = false;
            checkBoxBranchName.IsEnabled = true;
            Branchname.IsEnabled = false;
            checkBoxBranchcity.IsEnabled = true;
            Branchcity.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;

        }

        private void checkBoxBranchcity_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchnumber.IsEnabled = true;
            checkBoxBranchnumber.IsChecked = false;
            Branchnumber.IsEnabled = false;
            checkBoxBranchName.IsEnabled = true;
            checkBoxBranchName.IsChecked = false;
            Branchname.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            checkBoxBranchHechsher.IsChecked = false;
            hechshercombobox.IsEnabled = false;
            checkBoxBranchcity.IsEnabled = true;
            Branchcity.IsEnabled = true;


        }
        private void checkBoxBranchcity_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchnumber.IsEnabled = true;
            Branchnumber.IsEnabled = false;
            checkBoxBranchName.IsEnabled = true;
            Branchname.IsEnabled = false;
            checkBoxBranchcity.IsEnabled = true;
            Branchcity.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;

        }

        private void checkBoxBranchHechsher_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchnumber.IsEnabled = true;
            checkBoxBranchnumber.IsChecked = false;
            Branchnumber.IsEnabled = false;
            checkBoxBranchName.IsEnabled = true;
            checkBoxBranchName.IsChecked = false;
            Branchname.IsEnabled = false;
            checkBoxBranchcity.IsEnabled = true;
            checkBoxBranchcity.IsChecked = false;
            Branchcity.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = true;
        }
        private void checkBoxBranchHechsher_unChecked(object sender, RoutedEventArgs e)
        {
            checkBoxBranchnumber.IsEnabled = true;
            Branchnumber.IsEnabled = false;
            checkBoxBranchName.IsEnabled = true;
            Branchname.IsEnabled = false;
            checkBoxBranchcity.IsEnabled = true;
            Branchcity.IsEnabled = false;
            checkBoxBranchHechsher.IsEnabled = true;
            hechshercombobox.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkBoxBranchnumber.IsChecked == true)
                {
                    List<BE.Branch> l = new List<BE.Branch>();
                    l.Add(bl.BranchByNumber(int.Parse(Branchnumber.Text)));
                    dataGrid.ItemsSource = l;
                }
                else if (checkBoxBranchName.IsChecked == true)
                {
                    //BE.Branch = Branchnumber.Text;
                    bl.BranchByName(Branchname.Text);
                    dataGrid.ItemsSource = bl.BranchByName(Branchname.Text);

                }
                else if (checkBoxBranchcity.IsChecked == true)
                {
                    if ((BE.city)Branchcity.SelectedItem == BE.city.BeitShemesh)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchCityBeitShemesh);
                    else if ((BE.city)Branchcity.SelectedItem == BE.city.BneiBrak)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchCityBneiBrak);
                    else if ((BE.city)Branchcity.SelectedItem == BE.city.jerusalem)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchCityJerysalem);
                    else if ((BE.city)Branchcity.SelectedItem == BE.city.KiryatSefer)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchCityKiryatSefer);
                    else if ((BE.city)Branchcity.SelectedItem == BE.city.RamatGan)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchCityJRamatGan);
                    else if ((BE.city)Branchcity.SelectedItem == BE.city.TelAviv)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchCityTelAviv);

                }
                else if (checkBoxBranchHechsher.IsChecked == true)
                {
                    if ((BE.hechsher)hechshercombobox.SelectedItem == BE.hechsher.best)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchHechsherBest);
                    else if ((BE.hechsher)hechshercombobox.SelectedItem == BE.hechsher.medium)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchHechsherMedium);
                    if ((BE.hechsher)hechshercombobox.SelectedItem == BE.hechsher.regular)
                        dataGrid.ItemsSource = bl.branchUnderCondition(bl.ConBranchHechsherRegular);


                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
        }

     

        private void Branchnumber_MouseEnter(object sender, MouseEventArgs e)
        {
           Branchnumber.Text = "";
        }

        private void Branchnumber_MouseLeave(object sender, MouseEventArgs e)
        {
            //Branchnumber.Text = "Enter branch Number:";
        }

        private void Branchname_MouseEnter(object sender, MouseEventArgs e)
        {
            Branchname.Text = "";
        }

        private void Branchname_MouseLeave(object sender, MouseEventArgs e)
        {
           // Branchname.Text = "Enter branch Name:";

        }
    }
}
