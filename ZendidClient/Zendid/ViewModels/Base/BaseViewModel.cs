using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zendid.ViewModels.Base
{
    /// <summary>
    /// A base view model that fires PropertyChanged events
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// When any child property changes its value, this event is fired
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (IChannelSender, e) => { };

        /// <summary>
        /// Call this to fire a Property Changed event
        /// </summary>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
