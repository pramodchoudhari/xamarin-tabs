using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilani.Xamarin.Core.Comman
{
    public class NavigationEventArgs : EventArgs
    {
        public object Sender { get; set; }
        public NavigationArgs Data { get; set; }
        public NavigationEventArgs()
        {

        }
        public NavigationEventArgs(object sender, NavigationArgs senderData)
        {
            Sender = sender;
            Data = senderData;
        }
    }

    public class NavigationArgs
    {
        public Tabs Sender { get; set; }
        public Tabs Destination { get; set; }
        public object Data { get; set; }

    }
}
