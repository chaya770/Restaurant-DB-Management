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
    /// Interaction logic for deleteBranchWindow.xaml
    /// </summary>
    public partial class deleteBranchWindow : Window
    {

        BE.Branch br;
        BL.IBL bl;

        public deleteBranchWindow()
        {
            InitializeComponent();
            br = new BE.Branch();
            this.DataContext = br;
            bl = BL.FactoryBL.GetBL();
            branchNumberComboBox.ItemsSource = bl.listBranch();
            branchNumberComboBox.DisplayMemberPath = "branchNumber";
            branchNumberComboBox.DataContext = br.branchNumber;//brirat mechdal

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DeleteBranch(br.branchNumber);
                MessageBox.Show( " branch number: " + br.branchNumber + " was deleted");
                //MessageBox.Show("נמחק בהצלחה" + br.branchName + " סניף ");


                //branchNumberComboBox.ItemsSource = bl.listBranch();
                //branchNumberComboBox.DisplayMemberPath = "branchNumber";

                br = new BE.Branch();
                this.DataContext = br;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void branchNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = branchNumberComboBox.SelectedValue;
            BE.Branch b = a as BE.Branch;
            if (a == null)
               throw new Exception("must select branch first");
            br.branchNumber = b.branchNumber;
        }
    }
}
