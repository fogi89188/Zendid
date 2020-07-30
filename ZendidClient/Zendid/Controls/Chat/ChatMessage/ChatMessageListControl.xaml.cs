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
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            SingletonModel.Instance.UpdateRequest();
            ExtensionMethods.Refresh(this);
        }
        void Refresh(object sender, RoutedEventArgs e)
        {

        }
    }
}
