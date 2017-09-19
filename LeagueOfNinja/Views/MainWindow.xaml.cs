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
        public MainWindow()
        {
            Views.selectNinja popupWindow = new Views.selectNinja();
            InitializeComponent();
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
