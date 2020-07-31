using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
using System.Windows.Threading;
using Zendid.Models;

namespace Zendid.Chat
{
    /// <summary>
    /// Interaction logic for ChatListControl.xaml
    /// </summary>
    public partial class ChatListControl : UserControl
    {
        public ChatListControl()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Load;
            timer.Interval = TimeSpan.FromSeconds(1.1);
            timer.Start();
        }

        public void Load(object sender, EventArgs e)
        {
            ListBox.ItemsSource = SingletonModel.Users;
        }
    }
}
