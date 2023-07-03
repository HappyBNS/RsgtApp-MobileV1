using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
   public class BayanModel
    {
        //Begin Bayan Listview Model
        public class BayanDt
        {
            public string AnywhereAll { get; set; }
            public string BayanNo { get; set; }
            public string Servicehead { get; set; }
            public string Serviceinfo { get; set; }
            public string Icon { get; set; }
            public string Status { get; set; }
            public string StatusColor { get; set; }
            public string statuscode { get; set; }           
            public string Billoflading { get; set; }
            public string Inyard { get; set; }
            public string Departed { get; set; }
            //12-01-2023-Sanduru
            public string lblCategory { get; set; }
            public string Gatedincount { get; set; }
            public string Loadedcount { get; set; }
            public string Arrived { get; set; }
            public string Loaded { get; set; }
            public string ExpbayanstatusCode { get; set; }
            public string Expbayanstatus { get; set; }
            public string Expbayandgatedincount { get; set; }
            public string Expbayandloadedcount { get; set; }
            public string Expbayancategory { get; set; }
            public string Shippingline { get; set; }
            public string ShippingIcon { get; set; }
            public string Consignee { get; set; }
            public string VesselName { get; set; }
            public string Shipper { get; set; }
            public string CustomsAgent { get; set; }
            public string Importer { get; set; }
            public string POL { get; set; }
            public string POD { get; set; }
            public string btnMoreDetails { get; set; }
            public string imgDownArrow1 { get; set; }
            public string imgContainer { get; set; }
            public string imgShippingLine7 { get; set; }
            public string imgConsignee { get; set; }
            public string imgCustomagent { get; set; }
            public string imgShipper { get; set; }
            public string imgImporter { get; set; }
            public string imgPol { get; set; }
            public string lblInYard { get; set; }
            public string lblDeparted { get; set; }
            public bool Expander { get; set; }
        }
        //End Bayan Listview Model

        //Begin Bayan Filter Model
        public class BayanFilterDtlist
        {
            public string lblConsigneeData { get; set; }
            public string lblVesselData { get; set; }
            public string lblCarrierData { get; set; }
            public string lblStatus { get; set; }
            public string lblContainerCategoryCMB { get; set; } //12-01-2023-Sanduru
            public bool isChecked { get; set; }
        }
        //End Bayan Filter Model

    }
}
