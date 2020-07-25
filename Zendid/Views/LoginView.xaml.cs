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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// if the button "I dont have an account" is clicked, go to registration page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/RegisterView.xaml", UriKind.Relative));
        }

        /// <summary>
        /// gets the email and the password, checks if they are correct and then logs you in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login(object sender, RoutedEventArgs e)
        {
            string email = $"{EmailTextBox.Text}";
            string password = $"{PasswordTextBox.Password}";
            if (DatabaseModel.Instance.Login(email, password) == true)
            {
                this.NavigationService.Navigate(new Uri("Views/ControlView.xaml", UriKind.Relative));
            }
            else
            {
                WrongPasswordTextBlock.Text = "Invalid email or password.";
            }
        }
    }
}
