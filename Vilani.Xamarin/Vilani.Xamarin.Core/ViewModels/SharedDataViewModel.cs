using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilani.Xamarin.Core.Model;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class SharedDataViewModel : MvxViewModel
    {
        private TableVM _selectedTable;
        public TableVM SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
                RaisePropertyChanged(() => SelectedTable);
            }
        }

    }
}
