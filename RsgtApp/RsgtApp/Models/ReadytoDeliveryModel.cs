using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class ReadytoDeliveryModel
    {
        //Begin ReadytoDeliveryModel Model
        public class ReadytodeliverDt
        {
            public string AnywhereAll { get; set; }
            public int Sno { get; set; }
            public string ContainerNo { get; set; }
            public string Size { get; set; }
            public string Bayan { get; set; }
            public string BOL { get; set; }
            public string Carrier { get; set; }
            public string Vessel { get; set; }
            public string Voyage { get; set; }
            public string Category { get; set; }
            public string Freightkind { get; set; }
            public string POL { get; set; }
            public string POD { get; set; }
            public string Status { get; set; }
            public string StatusColor { get; set; }
            public string StatusCode { get; set; }
            public string TimeIn { get; set; }
            public string lblSno { get; set; }
            public string lblStatus { get; set; }
            public string lblSize { get; set; }
            public string lblBayan { get; set; }
            public string lblContainerNo { get; set; }
            public string lblBOL { get; set; }
            public string lblCarrier { get; set; }
            public string lblVessel { get; set; }
            public string lblVoyage { get; set; }
            public string lblCategory { get; set; }
            public string lblPOL { get; set; }
            public string lblPOD { get; set; }
            public string lblFreightkind { get; set; }
            public string lblTimeIn { get; set; }
            public string btnBookAppoint { get; set; }
        }
        //End Ready to Delivery Model
        //Begin Ready to Delivery Filter
        public class ReadytoDeliveryFilterDlList
        {
            public string CmbCarrier { get; set; }
            public string CmbCategory { get; set; }
            public string CmbSize { get; set; }
            public string CmbFreight { get; set; }
            public string CmbPOL { get; set; }
            public string CmbPOD { get; set; }
            public bool isChecked { get; set; }
        }
        //End Ready to Delivery Filter
    }
}
