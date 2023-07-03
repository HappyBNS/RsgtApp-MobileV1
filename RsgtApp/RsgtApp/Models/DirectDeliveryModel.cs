using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RsgtApp.Models
{
    public class DirectDeliveryModel
    {
        public static int lintDirectDeliverySno { get; set; }

        public static List<DirectDeliverydt> lstDelivery = new List<DirectDeliverydt>();
        public static List<DirectDeliverydt> lstSelectedDelivery = new List<DirectDeliverydt>();


        public static string strBayanNo { get; set; }
        public static string strApproveattachfilename { get; set; }
        public static string strApproveattachimage { get; set; }
        public static string strLicattachfilename { get; set; }
        public static string strLicattachfileimage { get; set; }


        public class DirectDeliverydt
        {
            public string cd_fmtdiscrecivaltime { get; set; }
            public string cd_fmtgatedouttime { get; set; }
            public string cd_emptydepot { get; set; }
            public string cd_damagedetails { get; set; }
            public string cd_transporter { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_bayannumber { get; set; }

            public string cd_DriverName { get; set; }
            public string cd_MobileNo { get; set; }
            public int CD_SNO { get; set; }

            public string lbl_Bol { get; set; }
            public string lbl_ContainerNo { get; set; }
            public string lbl_DriverDetail { get; set; }
            public string lbl_DriverName { get; set; }
            public string lbl_MobileNo { get; set; }
            public string lbl_DriverLicense { get; set; }
            public string btn_Delet { get; set; }
            public string btn_Edit { get; set; }
                
            //Image section
            public byte[] cd_approveattach { get; set; }
            public string cd_approveattachfilename { get; set; }
            public string cd_approveattachimage { get; set; }
          

            public byte[] cd_licattach { get; set; }
            public string cd_licattachfilename { get; set; }
            public string cd_licattachfileimage { get; set; }

            public ImageSource licattachfileimage { get; set; }



        }

    }
}
