using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class EmptyUnitReturnModel
    {
        //Begin EmptyUnitReturn Model
        public class EmptyUnitReturnDt
        {
            public string AnywhereAll { get; set; }
            public int Sno { get; set; }
            public string Size { get; set; }
            public string Bayan { get; set; }
            public string BOL { get; set; }
            public string Containerno { get; set; }
            public string Carrier { get; set; }
            public string DischargedOn { get; set; }
            public string GatedOutOn { get; set; }
            public string LastFreeDays { get; set; }
            public string EmptyDepot { get; set; }
            public string lblSno { get; set; }
            public string lblContainerno { get; set; }
            public string lblCarrier { get; set; }
            public string lblSize { get; set; }
            public string lblBayan { get; set; }
            public string lblBOL { get; set; }
            public string lblDischargedOn { get; set; }
            public string lblGatedOutOn { get; set; }
            public string lblLastFreeDays { get; set; }
            public string lblEmptyDepot { get; set; }
            public string cd_shipperdesc1 { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_size { get; set; }
            public string cd_bayannumber { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_detention { get; set; }
            public string cd_fmtdetention { get; set; }
            public string cd_emptydepot { get; set; }
            public string cd_gatedouttime { get; set; }
        }
        //End EmptyUnitReturn Model
        //Begin EmptyUnitReturn Filter Model
        public class EmptyUnitReturnDlList
        {
            public string CmbSize { get; set; }
            public string CmbCarrier { get; set; }
            public string CmbEmptyDepot { get; set; }
            public bool isChecked { get; set; }
        }
        //End EmptyUnitReturn Filter  Model
    }
}
