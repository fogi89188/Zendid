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
using ZendidCommons;

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
        private async void CreateUser(object sender, RoutedEventArgs e)
        {

            RegisterRequest registerRequest = new RegisterRequest
            {
                UserName = $"{EmailTextBox.Text}",
                Password = $"{PasswordTextBox.Password}"
            };
            var res = await ApiClient.RequestServerPost<RegisterRequest, RegisterResponse>
                ("https://zendid.in.kutiika.net/account/register", registerRequest);
            SingletonModel.token = res.Token;
            //("https://localhost:44373/account/register", loginRequest).Result;
            if (res.Status == "success")
            {
                this.NavigationService.Navigate(new Uri("Views/ChatView.xaml", UriKind.Relative));
            }
            else
            {

            }
        }
    }
}
