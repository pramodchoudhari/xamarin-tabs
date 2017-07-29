using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilani.Xamarin.Core.Model
{
    public class TableVM : MvxViewModel
    {
        public int BillID { get; set; }
        public int IndividualPlotID { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(() => IsSelected);
            }
        }

        public bool IsMerged { get; set; }
        public List<TableVM> MergedTables { get; set; }
        public bool IsSplitted { get; set; }
        public List<TableVM> SplitTables { get; set; }

        public delegate void TableSelected(object sender, TableVM table);
        public event TableSelected onTableSelected;

        public MvxCommand LinkTableCommand => new MvxCommand(OnTableSelection);
        public MvxCommand TestCommand => new MvxCommand(OnLinkClicked);

        private void OnLinkClicked()
        {
            Name += " Link";
        }

        private void OnTableSelection()
        {
            IsSelected = !IsSelected;
            onTableSelected(this, this);
        }


    }
}

