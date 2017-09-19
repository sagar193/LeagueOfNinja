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
        List<LeagueOfNinjaEF.Models.Equipment> fullEquipmentList;
        public MainWindow()
        {
            InitializeComponent();
            fullEquipmentList = equipmentListView.ItemsSource as List<LeagueOfNinjaEF.Models.Equipment>;
        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LeagueOfNinjaEF.Models.Type selectedType = (sender as ComboBox).SelectedItem as LeagueOfNinjaEF.Models.Type;

            List<LeagueOfNinjaEF.Models.Equipment> filteredEquipmentList = new List<LeagueOfNinjaEF.Models.Equipment>();
            foreach(var equipment in fullEquipmentList)
            {
                if (equipment.Type == selectedType)
                    filteredEquipmentList.Add(equipment);
            }

            equipmentListView.ItemsSource = filteredEquipmentList;
        }

        private void equipmentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LeagueOfNinjaEF.Models.Equipment selectedEquipment = (sender as ListView).SelectedItem as LeagueOfNinjaEF.Models.Equipment;
            healthPointsTextBox.Text = selectedEquipment.Health.ToString();
            manaTextBox.Text = selectedEquipment.Mana.ToString();
            staminaTextBox.Text = selectedEquipment.Stamina.ToString();
            StrengthTextBox.Text = selectedEquipment.Strength.ToString();
            IntelligenceTextBox.Text = selectedEquipment.Intelligence.ToString();
            AgilityTextBox.Text = selectedEquipment.Dexterity.ToString();
            PriceTextBox.Text = selectedEquipment.Price.ToString();
        }
    }
}
