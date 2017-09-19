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

        private void ninjaSelectListView_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}