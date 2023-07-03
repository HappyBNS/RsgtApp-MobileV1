using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class VesselScheduleModel
    {
        //To begin Model class 
        public class InportDtlist
        {
            public int intPageNum { get; set; }
            public int intPagesize { get; set; }
            public string Vesselicon1 { get; set; }
            public string Vesselicon { get; set; }
            public string Vesselname { get; set; }
            public string AnywhereAll { get; set; }
            public string Visitid { get; set; }
            public string Voyage { get; set; }
            public string Serviceid { get; set; }
            public string Cargocutofftime { get; set; }
            public string Statusin { get; set; }
            public string Statuscolor { get; set; }
            public string scheduleType { get; set; }
            public string fmtactualtimeofdeparture { get; set; }
            public string fmtexpectedtimeofarrival { get; set; }
            public string fmtcargocutofftime { get; set; }
            public string lblVesselName { get; set; }
            public string lblStatus { get; set; }
            public string lblEta { get; set; }
            public string lblAtd { get; set; }
            public string imgDownArrow { get; set; }
            public string lblVisitId { get; set; }
            public string lblVoyage { get; set; }
            public string lblServiceId { get; set; }
            public string lblCutOffTime { get; set; }
            public bool blInport { get; set; }
            public bool blArrival { get; set; }
            public bool blDeparture { get; set; }
            public string CMS_VISITID1 { get; set; }
            public string CMS_IBVOYAGE1 { get; set; }
            public string CMS_VESSELNAME1 { get; set; }
            public string CMS_SERVICEID1 { get; set; }
            public string CMS_FMTCARGOCUTOFFTIME1 { get; set; }
            public string CMS_VISITSTATUS1 { get; set; }
            public string CMS_SHIPPINGLINEIMAGE1 { get; set; }
            public string CMS_VESSELSTAGE1 { get; set; }
            public string CMS_FMTACTUALTIMEOFDEPARTURE1 { get; set; }
            public string CMS_FMTEXPECTEDTIMEOFARRIVAL1 { get; set; }
            public string CMS_VISITID2 { get; set; }
            public string CMS_IBVOYAGE2 { get; set; }
            public string CMS_VESSELNAME2 { get; set; }
            public string CMS_SERVICEID2 { get; set; }
            public string CMS_FMTCARGOCUTOFFTIME2 { get; set; }
            public string CMS_VISITSTATUS2 { get; set; }
            public string CMS_SHIPPINGLINEIMAGE2 { get; set; }
            public string CMS_VESSELSTAGE2 { get; set; }
            public string CMS_FMTACTUALTIMEOFDEPARTURE2 { get; set; }
            public string CMS_FMTEXPECTEDTIMEOFARRIVAL2 { get; set; }
            public string VD_ACTUALTIMEOFDEPARTURE { get; set; }
            public string VD_EXPECTEDTIMEOFARRIVAL { get; set; }
            public bool Expander { get; set; }
        }
        //To End Model class 
    }
}
