using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilani.Xamarin.Core.Model;

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
    public class Notifications : PubSubEvent<NavigationArgs>
    {

    }
    public sealed class OrderInfo
    {
        public IEventAggregator eventHanlder;
        private OrderInfo()
        {

        }

        private static OrderInfo _instance = null;
        private static object lockObj { get; set; }
        public static OrderInfo Instance
        {
            get
            {
                //lock (lockObj)
                //{
                if (_instance == null)
                {
                    _instance = new OrderInfo();
                    _instance.eventHanlder = new EventAggregator();
                }
                //}
                return _instance;
            }
        }
    }
}
