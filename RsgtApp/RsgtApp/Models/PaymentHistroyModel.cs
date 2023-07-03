using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class PaymentHistroyModel
    {
        //Begin Listview Model Class
        public class PaymentDt
        {
            public Int32 Sno { get; set; }
            public string InvoiceNo { get; set; }
            public string Customer { get; set; }
            public string Bayan { get; set; }
            public string BOL { get; set; }
            public string Amount { get; set; }
            public string CreatedOn { get; set; }
            public string FMTCreatedOn { get; set; }
            public string Validity { get; set; }
            public string MOP { get; set; }
            public string DueDate { get; set; }
            public string PaymentRef { get; set; }
            public string PaidOn { get; set; }
            public string Status { get; set; }
            public string StatusColor { get; set; }
            public string AnywhereAll { get; set; }
            public string InvoicePDF { get; set; }
            public string lblSno { get; set; }
            public string lblInvoiceNo { get; set; }
            public string lblCustomer { get; set; }
            public string lblBOL { get; set; }
            public string lblBayan { get; set; }
            public string lblAmount { get; set; }
            public string lblCreatedOn { get; set; }
            public string lblValidity { get; set; }
            public string lblMOP { get; set; }
            public string lblDueDate { get; set; }
            public string lblPaymentRef { get; set; }
            public string lblPaidOn { get; set; }
            public string lblStatusColor { get; set; }
            public string lblStatus { get; set; }
        }
        //To End Listview Model class 
        //To Begin Filter Model Class
        public class PaymentHistoryFilterDtlist
        {
            public string CmbMop { get; set; }
            public string CmbStatus { get; set; }
            public string CmbType { get; set; }
            public bool isChecked { get; set; }
        }
        //To End Filter Model Class
    }
}
