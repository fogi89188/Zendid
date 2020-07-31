using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
        /// log in with teh given email and password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Login(object sender, RoutedEventArgs e)
        {
            LoginRequest loginRequest = new LoginRequest
            {
                UserName = $"{EmailTextBox.Text}",
                Password = $"{PasswordTextBox.Password}"
            };
            var res = await ApiClient.RequestServerPost<LoginRequest, LoginResponse>
                ("https://zendid.in.kutiika.net/account/login", loginRequest);
            SingletonModel.token = res.Token;
            //("https://localhost:44373/account/login", loginRequest).Result;
            if (res.Status == "success")
            {
                this.NavigationService.Navigate(new Uri("Views/ChatView.xaml", UriKind.Relative));
            }
            else
            {
                WrongPasswordTextBlock.Text = "Invalid username or password!";
            }
        }
    }
}
