using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class DetentionManagementModelcs
    {
        //Begin Detention Management Model
        public class DetentionDt
        {
            public string Sno { get; set; }
            public string Size { get; set; }
            public string Bayan { get; set; }
            public string BOL { get; set; }
            public string Carrier { get; set; }
            public string DischargedOn { get; set; }
            public string GatedOutOn { get; set; }
            public string DwellDays { get; set; }
            public string Amount { get; set; }
            public string ContainerNo { get; set; }
            public string lblSno { get; set; }
            public string lblCarrier { get; set; }
            public string lblSize { get; set; }
            public string lblBayan { get; set; }
            public string lblContainerNo { get; set; }
            public string lblDischargedOn { get; set; }
            public string lblGatedOutOn { get; set; }
            public string lblDwellDays { get; set; }
            public string lblAmount { get; set; }
            public string btnpay { get; set; }
        }
        //End Detention Management Model
        //Begin Detention Management Filter Model
        public class DetentionManFilterDlList
        {
            public string CmbSize { get; set; }
            public string CmbCarrier { get; set; }
            public bool isChecked { get; set; }
        }
        //End Detention Management Filter Model
    }
}
