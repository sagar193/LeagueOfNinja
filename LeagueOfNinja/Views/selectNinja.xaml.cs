using System.Windows;

namespace LeagueOfNinja.Views
{
    /// <summary>
    /// Description for selectNinja.
    /// </summary>
    public partial class selectNinja : Window
    {
        /// <summary>
        /// Initializes a new instance of the selectNinja class.
        /// </summary>
        public selectNinja()
        {
            InitializeComponent();
        }

        private void ninjaSelectOkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ninjaSelectListView.SelectedItem != null)
            {
                this.Close();
            }
        }
    }
}