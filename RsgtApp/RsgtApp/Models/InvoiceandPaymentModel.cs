namespace RsgtApp.Models
{
    public class InvoiceandPaymentModel
    {
        //Begin InvoiceDt listView Model
        public class InvoiceDt
        {
            public string AnywhereAll { get; set; }
            public int intRowNo { get; set; }
            public string Sno { get; set; }
            public string InvoiceNo { get; set; }
            public string Customer { get; set; }
            public string blinvoiceconsignee { get; set; }
            public string ProformaInvoice { get; set; }
            public string BOL { get; set; }
            public string Amount { get; set; }
            public string CreatedOn { get; set; }
            public string Validity { get; set; }
            public string MOP { get; set; }
            public string DueDate { get; set; }
            public string PaymentRef { get; set; }
            public string PaidOn { get; set; }
            public string Status { get; set; }
            public string StatusEng { get; set; }
            public string StatusColor { get; set; }
            public bool isChecked { get; set; }
            public bool isCheckBoxVisible { get; set; }
            public bool btnboolRegenerate { get; set; }
            public string InvoicePDF { get; set; }
            public string ProformaInvoicePDF { get; set; }
            public string lblSno { get; set; }
            public string lblStatus { get; set; }
            public string lblBillOFLading { get; set; }
            public string lblCustomer { get; set; }
            public string lblProformaInvoice { get; set; }
            public string lblInvoiceNo { get; set; }
            public string lblAmount { get; set; }
            public string lblCreatedOn { get; set; }
            public string lblDueDate { get; set; }
            public string lblMOP { get; set; }
            public string lblPaidOn { get; set; }
            public string lblPaymentRef { get; set; }
            public string btnReGenerate { get; set; }
            public string cd_appbookable { get; set; }//GOKUL20230311
            public string bl_bolstatuscode { get; set; }//GOKUL20230311
            public string payinvoiceflag { get; set; }//GOKUL20230311
            public string bookanappointmentflag { get; set; }//GOKUL20230311
        }
        //End InvoiceDt listView Model
        //Begin InvoicesFilterDtlist Filter Model
        public class InvoicesFilterDtlist
        {
            public string CmbMop { get; set; }
            public string CmbStatus { get; set; }
            public string CmbType { get; set; }
            public bool isChecked { get; set; }
        }
        //End InvoicesFilterDtlist Filter Model
    }
}