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
            InitializeComponent();
        }

        private void PriceChangeTextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (PriceChangeTextBox.Text == "")
                return;
            if (Int32.Parse(PriceChangeTextBox.Text) < 0)
            {
                PriceChangeTextBox.Foreground = Brushes.Red;
            } else if ( Int32.Parse(PriceChangeTextBox.Text) > 0)
            {
                PriceChangeTextBox.Foreground = Brushes.Green;
            } else
            {
                PriceChangeTextBox.Foreground = Brushes.Black;
            }
        }
    }
}
