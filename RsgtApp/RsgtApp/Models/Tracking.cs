using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
     public class Tracking
    {
        public static List<BasicTrakingDetail> lstTracking = new List<BasicTrakingDetail>();
        public class BasicTrakingDetail
        {
            public string cd_statusdesc1 { get; set; }
            public string cd_statusdesc2 { get; set; }
            public string cd_unitgkey { get; set; }
            public string cd_ufvgkey { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_vesselvisitgkey { get; set; }
            public string cd_vesselvisitid { get; set; }
            public string cd_vesselname1 { get; set; }
            public string cd_vesselname2 { get; set; }
            public string cd_bayannumber { get; set; }
            public string cd_blgkey { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_commodity { get; set; }
            public string cd_obvoyage { get; set; }
            public string cd_ibvoyage { get; set; }
            public string cd_shippinglineid { get; set; }
            public string cd_shippingicon { get; set; }
            public string cd_consigneegkey { get; set; }
            public string cd_consigneedesc1 { get; set; }
            public string cd_consigneedesc2 { get; set; }
            public string cd_shippergkey { get; set; }
            public string cd_shipperdesc1 { get; set; }
            public string cd_shipperdesc2 { get; set; }
            public string cd_custombrokeragent { get; set; }
            public string cd_category { get; set; }
            public string cd_freightkind { get; set; }
            public string cd_size { get; set; }
            public string cd_weight { get; set; }
            public string cd_portofloading { get; set; }
            public string cd_portofdischarge { get; set; }
            public string cd_inspectionstatus { get; set; }
            public string cd_fminspectionstatus { get; set; }
            public string cd_holdpermission { get; set; }
            public string cd_transitstatus { get; set; }
            public string cd_oogdetails { get; set; }
            public string cd_reeferdetails { get; set; }
            public string cd_dgdetails { get; set; }
            public string cd_arrived { get; set; }
            public string cd_fmarrived { get; set; }
            public string cd_discrecivaltime { get; set; }
            public string cd_timeout { get; set; }
            public string cd_fmtdiscrecivaltime { get; set; }
            public string cd_movetoinspectiontime { get; set; }
            public string cd_fmtmovetoinspectiontime { get; set; }
            public string cd_inspectioncomplete { get; set; }
            public string cd_fmtinspectioncomplete { get; set; }
            public string cd_readyfordeliverytime { get; set; }
            public string cd_fmreadyfordeliverytime { get; set; }
            public string cd_prepickupissuedtime { get; set; }
            public string cd_fmprepickissuedtime { get; set; }
            public string cd_gatedouttime { get; set; }
            public string cd_fmgatedouttime { get; set; }
            public string cd_gaugeunitsize { get; set; }
            public string cd_dryreefer { get; set; }
            public string cd_detention { get; set; }
            public string cd_emptydepot { get; set; }
            public string cd_apptnbr { get; set; }
            public string cd_apptdate { get; set; }
            public string cd_apptstatus { get; set; }
            public string cd_createddate { get; set; }
            public string cd_agentkey { get; set; }
            public string cd_lastmodifieddate { get; set; }
            public string cd_expectedtimeofarrival { get; set; }
            public string cd_actualtimeofarrival { get; set; }
            public string cd_fmtexpectedtimeofarrival { get; set; }
            public string cd_fmtactualtimeofarrival { get; set; }

            public string cd_emptydepot_eng { get; set; }
            public string cd_emptydepot_ara { get; set; }
            public string timeline_waitingforportcharges { get; set; }


            //12-01-2023-Sanduru
            public string timeline_expunitintime { get; set; }
            public string timeline_expunitintimeflag { get; set; }
            public string timeline_expbookforinsptime { get; set; }
            public string timeline_expbookforinsptimeflag { get; set; }
            public string timeline_expinspcompletedtime { get; set; }
            public string timeline_expinspcompletedtimeflag { get; set; }
            public string timeline_expexcesscargoholdtime { get; set; }
            public string timeline_expexcesscargoholdtimeflag { get; set; }
            public string timeline_expdetentionholdtime { get; set; }
            public string timeline_expdetentionholdtimeflag { get; set; }
            public string timeline_expcoldstorepayholdtime { get; set; }
            public string timeline_expcoldstorepayholdtimeflag { get; set; }
            public string timeline_expfinholdtime { get; set; }
            public string timeline_expfinholdtimeflag { get; set; }
            public string timeline_expreadytoloadtime { get; set; }
            public string timeline_expreadytoloadtimeflag { get; set; }
            public string timeline_expunitloadtime { get; set; }
            public string timeline_expunitloadtimeflag { get; set; }
            public bool isVisibleEmptyDept { get; set; }
            public bool isVisibleFreeDays { get; set; }

        }
    }
}
