using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilani.Xamarin.Core.Model
{
    public class MenuVM
    {

        public int BillDetailsID { get; set; }
        public int SupplierBillID { get; set; }
        public int ProductItemID { get; set; }
        public string ProductItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitTypeID { get; set; }
        public string UnitTypeName { get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionDateString { get { return TransactionDate.HasValue ? TransactionDate.Value.ToString("dd/MMM/yyyy") : string.Empty; } }
        public int SrNo { get; set; }
        public int OperatedByID { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        //public ProductItemVM ProductItem { get; set; }
        //public StakeHoldersVM User { get; set; }
        public string QuantityFormatted
        {
            get
            {
                return string.Format("{0}-{1}", Quantity, (UnitTypeName.ToString()));
            }
        }
        public string ItemDesc1 { get; set; }
        public string ItemDesc2 { get; set; }
        public string ItemDesc3 { get; set; }
        public string ItemDesc4 { get; set; }
        public string ItemDesc5 { get; set; }

        public double Total
        {
            get
            {
                double total = 0;
                total = Quantity * Rate;
                if (Tax > 0)
                {
                    total = (total) + (total) * (Tax / 100);
                }
                if (Discount > 0)
                {
                    total = (total) - (total) * (Discount / 100);
                }
                return Math.Round(total, 2);
            }
        }

        public string ProductItemCode { get; set; }
        public int ChangedQuantity { get; set; }
        public bool IsDirty { get; set; }

        public bool? IsBypassPrinting { get; set; }

        public delegate void MenuAdded(object sender, MenuVM menu);
        public event MenuAdded onMenuAdded;


        public delegate void MenuRemoved(object sender, MenuVM menu);
        public event MenuRemoved onMenuRemoved;

        public MvxCommand MenuAddCommand => new MvxCommand(OnMenuAdded);
        public MvxCommand MenuRemoveCommand => new MvxCommand(OnMenuRemoved);

        private void OnMenuRemoved()
        {
            this.onMenuRemoved(this, this);
        }

        private void OnMenuAdded()
        {
            this.onMenuAdded(this, this);
        }
    }
}
