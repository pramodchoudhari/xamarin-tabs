using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Vilani.Xamarin.Core.ViewModels;
using Vilani.Xamarin.Core.Comman;
using Vilani.Xamarin.Core.Model;

namespace Vilani.Xamarin.Droid.Common
{
    public class TabHandler
    {
        public TabLayout MainTabLayout { get; set; }
        public TabLayout.Tab CurrentTab { get; set; }
        public int CurrentTabIndex { get; set; }
        public MainViewModel MasterViewModel { get; set; }

        public TabHandler(TabLayout tabLayout, MainViewModel masterViewModel)
        {
            MainTabLayout = tabLayout;
            MasterViewModel = masterViewModel;
        }

        private void SetTab(int tabIndex)
        {
            CurrentTab = MainTabLayout.GetTabAt(tabIndex);
            CurrentTab.Select();
        }

        public void HandleAction(object sender, NavigationEventArgs actionArgs)
        {
            //SetTab((int)actionArgs.Data.Destination);

            switch (actionArgs.Data.Destination)
            {
                case Tabs.Tables:
                    break;
                case Tabs.Menu:
                    MenuTabActions(actionArgs);
                    break;
                case Tabs.Orders:
                    break;
                default:
                    break;
            }

        }

        private void MenuTabActions(NavigationEventArgs actionArgs)
        {
            SetTab((int)actionArgs.Data.Destination);
        }
    }
}