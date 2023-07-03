using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class BannedTruckModel
    {
        //Begin Banned Truck Model
        public class BannedTruckDt
        {
            public string AnywhereAll { get; set; }
            public string Sno { get; set; }
            public string TruckNo { get; set; }
            public string BanDate { get; set; }
            public string BanReason { get; set; }
            public string BanType { get; set; }
            public string transporterGkey { get; set; }
            public string Status { get; set; }
            public bool btnStatus { get; set; }
            public string StatusColor { get; set; }
            public string lblSno { get; set; }
            public string lblStatus { get; set; }
            public string lblTruckNo { get; set; }
            public string lblBanDate { get; set; }
            public string lblBanReason { get; set; }
            public string lblBanType { get; set; }
            public string btnRequestBanRelease { get; set; }
        }
        //End Banned Truck Model
        //Begin Banned Truck Filter
        public class BannedTrucksFilterDlList
        {
            public string CmbBanType { get; set; }
            public string CmbBanReason { get; set; }
            public string CmbStatus { get; set; }
            public bool isChecked { get; set; }
        }
        //End Banned Truck Filter
    }
}
