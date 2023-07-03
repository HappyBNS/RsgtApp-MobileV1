using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class DwelldaysModel
    {
       // public static List<DwellDt> lstrDwellDays = new List<DwellDt>();
        //Begin Dwell Days Model
        public class DwellDt
        {
            public string AnywhereAll { get; set; }
            public string Sno { get; set; }
            public string ContainerNo { get; set; }
            public string Size { get; set; }
            public string Bayan { get; set; }
            public string BOL { get; set; }
            public string DischargedOn { get; set; }
            public string GatedOutOn { get; set; }
            public string DDays { get; set; }
            public string Carrier { get; set; }
            public string lblSno { get; set; }
            public string lblContainerNo { get; set; }
            public string lblSize { get; set; }
            public string lblBayan { get; set; }
            public string lblBOL { get; set; }
            public string lblDischargedOn { get; set; }
            public string lblGatedOutOn { get; set; }
            public string lblDDays { get; set; }
            public string lblCarrier { get; set; }
        }
        //End Dwell Days Model

        //Begin Dwell Days Filter
        public class DwellDaysFilterDlList
        {
            public string CmbSize { get; set; }
            public string CmbCarrier { get; set; }

            public bool isChecked { get; set; }
        }
        //End Dwell Days Filter
    }
}
