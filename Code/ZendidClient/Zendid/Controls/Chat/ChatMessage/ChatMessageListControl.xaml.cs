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
using Zendid.ViewModels;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Media.TextFormatting;
using System.Windows.Threading;
using Org.BouncyCastle.Asn1.Cms;

namespace Zendid.Chat.ChatMessage
{
    /// <summary>
    /// Interaction logic for ChatMessageListControl.xaml
    /// </summary>
    public partial class ChatMessageListControl : UserControl
    {
        public ChatMessageListControl()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Load;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void Load(object sender, EventArgs e)
        {
            SingletonModel.Instance.UpdateRequest();
            this.scrollViewer.ScrollToEnd();
            ExtensionMethods.Refresh(this);
        }



        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            if (TextBox.Text != null && TextBox.Text != "")
            {
                SingletonModel.Instance.SendRequest(TextBox.Text);
                TextBox.Text = "";
            }
        }

        private void ButtonSend(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }
    }
}
