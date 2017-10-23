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

        private void updateTextboxColor(TextBlock textBlock)
        {
            if (textBlock.Text == "")
                return;
            if (Int32.Parse(textBlock.Text) < 0)
            {
                textBlock.Foreground = Brushes.Red;
            }
            else if (Int32.Parse(textBlock.Text) > 0)
            {
                textBlock.Foreground = Brushes.Green;
            }
            else
            {
                textBlock.Foreground = Brushes.Black;
            }
        }

        private void TextBox_Updated(object sender, DataTransferEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            updateTextboxColor(textBlock);
        }
    }
}
