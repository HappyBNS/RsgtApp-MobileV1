using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class BOLModel
    {
        public class BOLDt
        {
            public string BayanNo { get; set; }
            public string Billoflading { get; set; }
            public string Inyard { get; set; }
            public string Departed { get; set; }
            public string Arrived { get; set; } //12-01-2023-sanduru
            public string Loaded { get; set; } //12-01-2023-sanduru
            public bool isVisibleImport { get; set; } //12-01-2023-sanduru
            public bool isVisibleExport { get; set; } //12-01-2023-sanduru
            public string Commodity { get; set; }
            public string Vesselname1 { get; set; }
            public string ConsigneeName { get; set; }
            public string Carrier { get; set; }
            public string AnywhereAll { get; set; }
            public bool chkBolNo { get; set; }
            public bool blchkBolNo { get; set; }
            public string Loadingicon { get; set; }
            public string Loadingstatusicon { get; set; }
            public string Loadingstatusinfo { get; set; }
            public string Loadingdischargecount { get; set; }
            public string Inspectionicon { get; set; }
            public string Inspectionstatusicon { get; set; }
            public string Inspectionstatusinfo { get; set; }
            public string InspectionCount { get; set; }
            public string Holdicon { get; set; }
            public string Holdstatusicon { get; set; }
            public string Holdstatusinfo { get; set; }
            public string Holdcount { get; set; }
            public string Invoiceicon { get; set; }
            public string Invoicestatusicon { get; set; }
            public string Invoicestatusinfo { get; set; }
            public string Invoiceinfo { get; set; }
            public string Proformainvoicenumber { get; set; }
            public string Appointmenticon { get; set; }
            public string Appointmentstatusicon { get; set; }
            public string Appointmentstatusinfo { get; set; }
            public string Appointmentinfo { get; set; }
            public string InvoiceNumber { get; set; }  
            public string ihDisplayInVoiceNo { get; set; }
            public string ihstatus { get; set; }
            public string Departedicon { get; set; }
            public string Departedstatusicon { get; set; }
            public string Departedstatusinfo { get; set; }
            public string Departedinfo { get; set; }
            public string Status { get; set; }
            public string StatusColor { get; set; }
            public string StatuCode { get; set; }
            public string Butactioncaption { get; set; }
            public string Butaction { get; set; }
            public string BOLAction { get; set; }
            public string Transporter { get; set; }
            public string Shippinglineid { get; set; }
            public string Custombrokeragent { get; set; }
            public string Invoiceconsignee { get; set; }
            public string boolable { get; set; }
            public bool BtnactioncaptionGI { get; set; }
            public bool BtnactioncaptionGIUP { get; set; }
            public bool BtnactioncaptionPI { get; set; }
            public bool BtnactioncaptionPIUP { get; set; }
            public bool BtnactioncaptionBuApp { get; set; }
            public bool BtnactioncaptionNE { get; set; }
            public bool BtnEnableGI { get; set; }
            public bool BtnEnableGIUP { get; set; }
            public bool BtnEnablePI { get; set; }
            public bool BtnEnablePIUP { get; set; }
            public bool BtnEnableBuApp { get; set; }
            public bool BtnEnableNE { get; set; }
            public string BOLStatuscode { get; set; }
            public string attchdinvoice { get; set; }
            public string btnMoreDetails { get; set; }
            public string imgDownArrow2 { get; set; }
            public string imgCommodity { get; set; }
            public string imgContainer { get; set; }
            public string lblInYard { get; set; }
            public string lblDeparted { get; set; }
            public bool Expander { get; set; }
            public string lblchkmessage { get; set; }
            //12-01-2022-Sanduru
            public string lblArrived { get; set; }
            public string lblLoaded { get; set; }
            public string Expbolcategory { get; set; }
            public string lblCategory { get; set; }
            public string GatedInCount { get; set; }
            public string LoadCount { get; set; }
            public string GatedImage { get; set; }
            public string LoadedImage { get; set; }
            public string ExpStatusCode { get; set; }
            public string ExpStatus { get; set; }
            public string Gatedstatusicon { get; set; }
            public string Gatedstatusinfo { get; set; }
            public string Loadedstatusicon { get; set; }
            public string Loadedstatusinfo { get; set; }
            public string ihfasahstatus { get; set; }
            public string ihmop { get; set; }
            public string RequestFlag { get; set; }
            public string GateOutContainerFlag { get; set; }
           

        }
        public class BOLFilterDtlist
        {
            public string CmbBLConsigneeData { get; set; }
            public string CmbBLVesselData { get; set; }
            public string CmbBLCarrierData { get; set; }
            public string CmbBLStatusData { get; set; }
            public bool isChecked { get; set; }
        }
        public class clsListofbayandetails
        {
            public string bd_bayannumber { get; set; }
            public string bd_vesselvisitgkey { get; set; }
            public string bd_vesselvisitid { get; set; }
            public string bd_vesselname1 { get; set; }
            public string bd_vesselname2 { get; set; }
            public string bd_transitcountcontainer { get; set; }
            public string bd_shippinglineid { get; set; }
            public string bd_shippinglineimage { get; set; }
            public string bd_consigneegkey { get; set; }
            public string bd_consigneedesc1 { get; set; }
            public string bd_consigneedesc2 { get; set; }
            public string bd_shippergkey { get; set; }
            public string bd_shipperdesc1 { get; set; }
            public string bd_shipperdesc2 { get; set; }
            public string bd_custombrokeragent { get; set; }
            public string bd_portofloading { get; set; }
            public string bd_portofdischarge { get; set; }
            public string bd_category { get; set; }
            public string bd_vsloperatorname { get; set; }
            public string containerstatus { get; set; }
            public string blcount { get; set; }
            public string bd_emailid { get; set; }
            public string bd_linkcode { get; set; }

        }

    }
}
