﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RsgtApp.Models
{
    class ForgetpasswordModel
    {

        //getRegisterUserDetails
        public class clsREGISTEREDUSERS
        {
            public string ru_createddate { get; set; }
            public string ru_activestatus { get; set; }
            public int ru_recid { get; set; }
            public string ru_firstname1 { get; set; }
            public string ru_firstname2 { get; set; }
            public string ru_lastname1 { get; set; }
            public string ru_lastname2 { get; set; }
            public int ru_cntrecid { get; set; }
            public string ru_cntcode { get; set; }
            public string ru_cntdesc1 { get; set; }
            public string ru_cntdesc2 { get; set; }
            public string ru_mobileno { get; set; }
            public string ru_emailid { get; set; }
            public string ru_preferredcomm1 { get; set; }
            public string ru_preferredcomm2 { get; set; }
            public string ru_jobtitle1 { get; set; }
            public string ru_jobtitle2 { get; set; }
            public string ru_jobfunction1 { get; set; }
            public string ru_jobfunction2 { get; set; }
            public string ru_password { get; set; }
            public string ru_companytype1 { get; set; }
            public string ru_companytype2 { get; set; }
            public string ru_companyname1 { get; set; }
            public string ru_companyname2 { get; set; }
            public string ru_buildingno { get; set; }
            public string ru_unitno { get; set; }
            public string ru_streetname1 { get; set; }
            public string ru_streetname2 { get; set; }
            public string ru_districtname1 { get; set; }
            public string ru_districtname2 { get; set; }
            public int ru_ctyrecid { get; set; }
            public string ru_ctycode { get; set; }
            public string ru_ctydesc1 { get; set; }
            public string ru_ctydesc2 { get; set; }
            public string ru_zipcode { get; set; }
            public string ru_additionalno { get; set; }
            public string ru_telephoneno { get; set; }
            public string ru_fax { get; set; }
            public string ru_customertype1 { get; set; }
            public string ru_customertype2 { get; set; }
            public string ru_licenseno { get; set; }
            public string ru_idno { get; set; }
            public string ru_tccheckbox { get; set; }
            public string ru_otp { get; set; }
            public int ru_createdtime { get; set; }
            public int ru_nacntrecid { get; set; }
            public string ru_nacntcode { get; set; }
            public string ru_nacntdesc1 { get; set; }
            public string ru_nacntdesc2 { get; set; }
            public string ru_language1 { get; set; }
            public string ru_language2 { get; set; }
            public string ru_currency1 { get; set; }
            public string ru_currency2 { get; set; }
            public string ru_temperature1 { get; set; }
            public string ru_temperature2 { get; set; }
            public string ru_weight1 { get; set; }
            public string ru_weight2 { get; set; }
            public string ru_sunday { get; set; }
            public string ru_monday { get; set; }
            public string ru_tuesday { get; set; }
            public string ru_wednesday { get; set; }
            public string ru_thursday { get; set; }
            public string ru_friday { get; set; }
            public string ru_saturday { get; set; }
            public string ru_apmt12to02 { get; set; }
            public string ru_apmt02to04 { get; set; }
            public string ru_apmt04to06 { get; set; }
            public string ru_apmt06to08 { get; set; }
            public string ru_apmt08to10 { get; set; }
            public string ru_apmt10to12 { get; set; }
            public string ru_apmt12to14 { get; set; }
            public string ru_apmt14to16 { get; set; }
            public string ru_apmt16to18 { get; set; }
            public string ru_apmt18to20 { get; set; }
            public string ru_apmt20to22 { get; set; }
            public string ru_apmt22to24 { get; set; }
            public string ru_licenseno1 { get; set; }
            public string ru_licenseno2 { get; set; }
            public string ru_licenseno3 { get; set; }
            public string ru_licenseno4 { get; set; }
            public string ru_licenseno5 { get; set; }
            public string ru_licenseno6 { get; set; }
            public string ru_licenseno7 { get; set; }
            public string ru_licenseno8 { get; set; }
            public string ru_licenseno9 { get; set; }
            public string ru_defaultlandingpage { get; set; }
            public string ru_linkcode { get; set; }
            public string ru_note1 { get; set; }
            public string ru_note2 { get; set; }
            public string ru_languagevalue { get; set; }
            public string ru_preferredcommvalue { get; set; }
            public string ru_jobfunctionvalue { get; set; }
            public string ru_companytypevalue { get; set; }
            public string ru_customertypevalue { get; set; }
            public string ru_currencyvalue { get; set; }
            public string ru_temperaturevalue { get; set; }
            public string ru_weightvalue { get; set; }
            public string ru_walletbalanace { get; set; }
            public int ru_dwelldaysavg { get; set; }
            public int ru_pendingpaymentinvoicescount { get; set; }
            public int ru_volumeupdatecontainerscount { get; set; }
            public int ru_rfdcontainerscount { get; set; }
            public int ru_rfdcontainersexpirycount { get; set; }
            public int ru_containerscount { get; set; }
            public int ru_mbcontainerscount { get; set; }
            public int ru_reviewscount { get; set; }
            public int ru_reviewspendingcount { get; set; }
            public int ru_avstruckamount { get; set; }
            public int ru_avscutomclearenceamount { get; set; }
            public int ru_readytodeliverunitcount { get; set; }
            public int ru_casesresolved { get; set; }
            public int ru_casesinprogress { get; set; }
            public int ru_invoicescount { get; set; }
            public int ru_invoicesamount { get; set; }
            public int ru_appoinmentscount { get; set; }
            public int ru_mibcontainerscount { get; set; }
            public int ru_r2dgatedoutcount { get; set; }
            public int ru_r2dyardcount { get; set; }
            public int ru_unitsunderdentioncount { get; set; }
            public int ru_unitneardentioncount { get; set; }
            public int ru_bannedtruckscount { get; set; }
            public int ru_eurrsgtcount { get; set; }
            public int ru_euroutsideedcount { get; set; }
            public string ru_crmcontactgkey { get; set; }
            public string ru_clearingagentflag { get; set; }
            public string ru_brokerflag { get; set; }
        }
    }
}