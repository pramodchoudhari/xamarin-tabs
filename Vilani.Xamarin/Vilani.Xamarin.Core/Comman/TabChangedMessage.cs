
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilani.Xamarin.Core.New.Comman
{
    public class TabChangedMessage //: MvxMessage
    {
        public int CurrentPage { get; private set; }

        public TabChangedMessage(object sender, int currentPage) //: base(sender)
        {
            CurrentPage = currentPage;
        }
    }
}
