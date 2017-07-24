using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vilani.Xamarin.Core.Comman;
using Vilani.Xamarin.Core.Model;
using Vilani.Xamarin.Core.New.Comman;
using Vilani.Xamarin.Core.Service;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class TablesViewModel : TabsBaseViewModel
    {
        public TablesViewModel(string name = "default")
        {
            Name = name;
            IsSingleValid = true;
            TableName = "Table name is ";
            Task.Run(() => test());
        }

        public ICommand GoToMenu => new MvxCommand(() =>
        {
            var currentPage = 10; //Your logic here
            TabChangeds(Tabs.Menu);
        });

        public async void test()
        {
            Tables = new ObservableCollection<TableVM>(await new TableService().GetTables());
        }


        private string _tablename;
        public string TableName
        {
            get { return _tablename; }
            set
            {
                _tablename = value;
                RaisePropertyChanged(() => TableName);
            }
        }

        private bool _isSingleValid;
        public bool IsSingleValid
        {
            get { return _isSingleValid; }
            set
            {
                _isSingleValid = value;
                RaisePropertyChanged(() => IsSingleValid);
            }
        }

        private ObservableCollection<TableVM> tables;
        public ObservableCollection<TableVM> Tables
        {
            get
            {
                return tables;
            }
            set
            {
                tables = value;
                RaisePropertyChanged(() => Tables);
            }
        }

        public MvxCommand<TableVM> SelectedTableCommand => new MvxCommand<TableVM>(OnTableSelection);

        private void OnTableSelection(TableVM selectedTable)
        {
            TableName = selectedTable.Name + "Selected";
        }
    }

}
