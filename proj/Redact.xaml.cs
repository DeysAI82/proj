using proj.Models.Entities;
using proj.ViewModels;
using System.Windows;

namespace proj
{
    public partial class Redact : Window
    {
        public Redact()
        {
            InitializeComponent();
            DataContext = new RedactViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();

            this.Close();
        }
    }
}