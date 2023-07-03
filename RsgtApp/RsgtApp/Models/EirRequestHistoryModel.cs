using System;
using Xamarin.Forms;

namespace RsgtApp.Models
{
    public class EirRequestHistoryModel
    {
        public class EirRequestHistoryModelDt
        {
            public string lblSno { get; set; }
            public string lblContainerNo { get; set; }
            public string lblBillofLading { get; set; }
            public string lblRequestedOn { get; set; }
            public string lblStatus { get; set; }
            public string imgPhoto { get; set; }
            public string imgPdf { get; set; }
            public string imgHistoryIcon { get; set; }
            public string CRM_QUEUE { get; set; }
            public Int64 SNO { get; set; }
            public string gpr_licenseno { get; set; }
            public string gpr_containernumber { get; set; }
            public string gpr_blnumber { get; set; }
            public string gpr_requesteddate { get; set; }
            public string gpr_status { get; set; }
            public string gp_reqreference { get; set; }
            public string gp_image { get; set; }
            public ImageSource Gate_Image { get; set; }
            public Int64 TRCOUNT { get; set; }
            public string gpr_photosflag { get; set; }
            public string StatusColorEIR { get; set; }
        }
        //To Begin Filter Model Class
        public class EITRequesthistoryFilter
        {
            public string gkStatus { get; set; }      
            public bool isChecked { get; set; }
        }
        //To End Filter Model Class
    }
}