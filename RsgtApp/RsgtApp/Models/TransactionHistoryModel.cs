using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class clsTransactionHistory
    {
        public int wt_recid { get; set; }
        public string wt_ruemailid { get; set; }
        public string fmt_trndatetime { get; set; }
        public string wt_trntype { get; set; } 
        public string fmt_trnamount { get; set; }
        public string wt_blnumber { get; set; }
        public string wt_payref { get; set; }
        public string wt_invoiceno { get; set; }
        public string wt_status { get; set; }

        public string LblInvoiceNo { get; set; }
        public string LblBillofLading { get; set; }
        public string LblCustomer { get; set; }
        public string LblAccountNo { get; set; }
        public string LblAmount { get; set; }
        public string LblRefNo { get; set; }
        public string LblTransDate { get; set; }
        public string LblTransType { get; set; }




        public string InvoiceNo { get; set; }
        public string Billoflading { get; set; }
        public string Customer { get; set; }
        public string AccountNo_Card { get; set; }
        public string Amount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionColor { get; set; }
        public string ReferenceNo { get; set; }
        public string TransactionDate { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }

    }
    public class TransactionHstDt
    {
        public string lblPeriodData { get; set; }
        public string lblTransactionType { get; set; }

        public bool isChecked { get; set; }

    }
}
