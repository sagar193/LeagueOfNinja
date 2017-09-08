using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LeagueOfNinja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEnumerable fullEquipmentList;
        public MainWindow()
        {
            InitializeComponent();
            fullEquipmentList = equipmentListView.ItemsSource;
        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LeagueOfNinjaEF.Models.Type test = (sender as ComboBox).SelectedItem as LeagueOfNinjaEF.Models.Type;
        }
    }
}
