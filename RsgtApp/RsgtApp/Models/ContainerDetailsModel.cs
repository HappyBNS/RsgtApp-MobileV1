using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class ContainerDtcls
    {
        //Begin ContainerDetails Model
        public class clsContainerDetails
        {
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
            public string cd_shippingicon { get; set; }
            public string cd_consigneedesc1 { get; set; }
            public string cd_consigneedesc2 { get; set; }
            public string cd_shipperdesc1 { get; set; }
            public string cd_shipperdesc2 { get; set; }
            public string cd_category { get; set; }
            public string cd_freightkind { get; set; }
            public string cd_size { get; set; }
            public string cd_weight { get; set; }
            public string cd_portofloading { get; set; }
            public string cd_portofdischarge { get; set; }
            public string cd_inspectionstatus { get; set; }
            public string cd_holdpermission { get; set; }
            public string cd_transitstatus { get; set; }
            public string cd_oogdetails { get; set; }
            public string cd_reeferdetails { get; set; }
            public string cd_dgdetails { get; set; }
            public string cd_damagedetails { get; set; }
            public string cd_platenbr { get; set; }
            public string cd_truckgkey { get; set; }
            public string cd_truckcogkey { get; set; }
            public string damagedetailspopup { get; set; }
            public string cd_damageflag { get; set; }
            public string cd_consigneegkey { get; set; }
            public string cd_shippergkey { get; set; }
            public string cd_custombrokeragent { get; set; }
            public string cd_transporter { get; set; }
            public string cd_shippinglineid { get; set; }
            public string cd_agentkey { get; set; }
            public string cd_emailid { get; set; }
            public string cd_linkcode { get; set; }
            public string cd_token { get; set; }
            public string cd_emptydepot_eng { get; set; }
            public string cd_emptydepot_ara { get; set; }
            public string cd_emptydepot { get; set; }
        }
        public class clsContainertimeline
        {
            public string cd_unitgkey { get; set; }
            public string cd_bayannumber { get; set; }
            public string cd_blgkey { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_vesselvisitgkey { get; set; }
            public string cd_fminspectionstatus { get; set; }
            public string cd_transitstatus { get; set; }
            public string timeline_arrived { get; set; }
            public string timeline_arrivedflag { get; set; }
            public string timeline_discharge { get; set; }
            public string timeline_dischargeflag { get; set; }
            public string timeline_underinspection { get; set; }
            public string timeline_underinspectionflag { get; set; }
            public string timeline_inspectioncomplete { get; set; }
            public string timeline_inspectioncompleteflag { get; set; }
            public string timeline_readyfordeliverytime { get; set; }
            public string timeline_readyfordeliverytimeflag { get; set; }
            public string timeline_prepickupissuedtime { get; set; }
            public string timeline_prepickupissuedtimeflag { get; set; }
            public string timeline_gatedouttime { get; set; }
            public string timeline_gatedouttimeflag { get; set; }
            public string cd_fmtexpectedtimeofarrival { get; set; }
            public string cd_fmtactualtimeofarrival { get; set; }
            public string cd_createddate { get; set; }
            public string cd_platenbr { get; set; }
            public string cd_truckgkey { get; set; }
            public string cd_truckcogkey { get; set; }
            public string cd_consigneegkey { get; set; }
            public string cd_shippergkey { get; set; }
            public string cd_custombrokeragent { get; set; }
            public string cd_transporter { get; set; }
            public string cd_shippinglineid { get; set; }
            public string cd_agentkey { get; set; }
            public string cd_linkcode { get; set; }
            public string cd_emailid { get; set; }
            public string cd_containerdocument { get; set; }
            public string timeline_waitingforportcharges { get; set; }
            //26-12-2022-Sanduru
            public string cd_category { get; set; }
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

        }
    }
}

