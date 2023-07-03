using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
   public class ContainerModel

    {
        //Begin Containerlist Model
        public class ContainerDt
        {
            public string AnyWhere { get; set; }
            public string BayanNo { get; set; }
            public string Billoflading { get; set; }
            public string Containerno { get; set; }
            public string LicenseNo { get; set; }
            public string Containerno_Size { get; set; }
            public string Container_unitgkey { get; set; }
            public string Freighticon { get; set; }
            public string Freightinfo { get; set; }
            public string dgdetails { get; set; }
            public string containerpopup { get; set; }
            public string damagepopup { get; set; }
            public string Unitsizeicon { get; set; }
            public string Unitsizeinfo { get; set; }
            public string Temperaturecon { get; set; }
            public string Temperatureinfo { get; set; }
            public string Loadingicon { get; set; }
            public string Loadinginfo { get; set; }
            public string Inspectionicon { get; set; }
            public string Inspectioninfo { get; set; }
            public string Invoiceicon { get; set; }
            public string Invoiceinfo { get; set; }
            public string Appointmenticon { get; set; }
            public string Appointmentdate { get; set; }
            public string Appointmenttime { get; set; }
            public string Appointmentinfo { get; set; }
            public string Gateicon { get; set; }
            public string Gateinfo { get; set; }
            public string Damageflag { get; set; }
            public string emptydepot { get; set; }
            public string HoldPopupFlag { get; set; }
            public string lblFrightType { get; set; }
            public string lblContainerSize { get; set; }
            public string lblAppointment { get; set; }
            public string lblGate { get; set; }
            public string lblStatus { get; set; }
            public string lblOthers { get; set; }
            public string lblDamage { get; set; }
            public string lblAnyWhere { get; set; }
            public string lblBolNo { get; set; }
            public string Returndepoticon { get; set; }
            public string Returndepotinfo { get; set; }
            public string Status { get; set; }
            public string StatusColor { get; set; }
            public string statusCode { get; set; }
            public string btnMoreDetails { get; set; }
            public string imgDownArrow2 { get; set; }
            public string imgDangerRed { get; set; }
            public string imgDamage { get; set; }
            public string imgHoldIconRed { get; set; }
            public bool flagPopupFrame { get; set; }
            public bool flagDangerous { get; set; }
            public bool flagDamage { get; set; }
            public bool flagHold { get; set; }
            public bool Expander { get; set; }
            public string lblAppoint { get; set; }
            public string lblDepot { get; set; }
            public string lblLoaded { get; set; }
            public string lblGatedOut { get; set; }
            public string lblInsp { get; set; }
            public string lblDepot2 { get; set; }
            public string fstrRequest { get; set; }
            //12-01-2023-Sanduru
            public string lblGatedIn { get; set; }
            public string GatedInCount { get; set; }
            public string GatedInImage { get; set; }
            public string LoadedCount { get; set; }
            public string LoadedImage { get; set; }
            public string InspecCount { get; set; }
            public string InspecImage { get; set; }
            public bool isVisibleImport { get; set; }
            public bool isVisibleExport { get; set; }
        }
        public class ContainerFilterDlList
        {
            public string CmbFreightType { get; set; }
            public string CmbContainerSize { get; set; }
            public string CmbAppointment { get; set; }
            public string CmbGate { get; set; }
            public string CmbStatus { get; set; }
            public string CmbDamage { get; set; }
            public bool isChecked { get; set; }
        }
    }
}
