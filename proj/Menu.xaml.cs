using proj.ViewModels;
using System;
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

namespace proj
{

    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new MenuViewModel();
            }
        }

        private void btnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnRedact_Click(object sender, RoutedEventArgs e)
        {
            Redact redactWindow = new Redact();
            redactWindow.Show();
            this.Close();


        }
        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            Rent rentWindow = new Rent();
            rentWindow.Show();
            this.Close();
        }
    }
}