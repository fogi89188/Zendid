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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zendid.Models;

namespace Zendid.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        public RegisterView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// If the button "I already have an account" is clicked, go to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/LoginView.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Gets the email and the password and creates a new account in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateUser(object sender, RoutedEventArgs e)
        {
            string email = $"{EmailTextBox.Text}";
            string password = $"{PasswordTextBox.Password}";

            DatabaseModel database = DatabaseModel.Instance;
            database.AddUser(email, password);
            this.NavigationService.Navigate(new Uri("Views/ControlView.xaml", UriKind.Relative));
        }
    }
}
