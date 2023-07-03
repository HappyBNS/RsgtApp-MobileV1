using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net;
using Nancy.Json;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;



using static RsgtApp.Models.VesselScheduleModel;
using RsgtApp.Helpers;
using static RsgtApp.Models.DwelldaysModel;
using static RsgtApp.Models.PaymentHistroyModel;
using static RsgtApp.Models.ReadytoDeliveryModel;
using static RsgtApp.Models.AppointmentBookingModel;
using static RsgtApp.Models.EmptyUnitReturnModel;
using static RsgtApp.Models.BannedTruckModel;
using static RsgtApp.Models.DetentionManagementModelcs;
using static RsgtApp.Models.ManuallnspectionModel;
using static RsgtApp.Models.InvoiceandPaymentModel;
using static RsgtApp.Models.DamageContainerModel;
using static RsgtApp.Models.BayanModel;
using static RsgtApp.Models.BOLModel;
using static RsgtApp.Models.EvaluateModel;
using static RsgtApp.Models.ContainerModel;
using static RsgtApp.Models.TicketsListModel;

using static RsgtApp.Views.Dashboard_Consignee;
using static RsgtApp.Models.DashboardModel;
using RsgtApp.Models;
using static RsgtApp.Models.NotificationMainModel;
using static RsgtApp.Models.DirectDeliveryModel;
using static RsgtApp.Models.EirRequestHistoryModel;
using static RsgtApp.Models.Manifest;
using static RsgtApp.Models.GatePhotoDetailModel;
using static RsgtApp.Models.ContainerInspectionModel;
using static RsgtApp.Models.Tracking;
using System.Threading.Tasks;
using static RsgtApp.Models.ExtendedDetentionModel;

namespace RsgtApp.BusinessLayer
{
    public interface INetwork
    {
        bool IsConnected();
        bool IsConnectedFast();

    }

    public class BLConnect
    {
        //tested
        WebApiMethod objWebApi = new WebApiMethod();


        public string NewRegisterUserOld(string ApiName, string objstringJson)
        {
            string lstrResult = "";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;
            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;



            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);
                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }





        public string updateRegisterUserOld(string ApiName, string objstringJson, string fstrEmailid)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName + "/" + fstrEmailid;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            string lstrInput = objstringJson;
            //UpadteRegisterUser
            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");


                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PutAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                }
                bool BoolResult = result.IsSuccessStatusCode;
                if (BoolResult == true)
                {
                    lstrResult = "true";
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return lstrResult;
        }

        public string fnPutOld(string ApiName, string objstringJson, string fstrCondition)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName + "/" + fstrCondition;
            string strApiKey = AppSettings.getApiKey;

            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            string lstrInput = objstringJson;
            //UpadteRegisterUser
            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");


                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PutAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                }
                bool BoolResult = result.IsSuccessStatusCode;
                if (BoolResult == true)
                {
                    lstrResult = "true";
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return lstrResult;
        }



        public List<EvaluateDt> getEvaluateDetails(string fstrFilter, int fintPageNumber, int fintPageSize)
        {
            //http://172.19.35.68:89/api/DataSource/getEvaluateDetailsCieloUser?fstrAPIToken=&fstrMailId=cieloconsignee@gmail.com&fstrAnyWordSearch=&fstrPageNumber=1&fstrPageSize=30
            List<EvaluateDt> llstResult = new List<EvaluateDt>();
            string lstrApiName = "getEvaluateDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);
            lobjInParams.Add("fstrAnyWordSearch", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjEvaluateBrokerRow in lobjApiData)
            {
                // Info object
                EvaluateDt lobjEvaluate = new EvaluateDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjEvaluateBrokerRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bl_bayannumber":
                            lobjEvaluate.Bayan = strColumnValue;
                            break;

                        case "bl_blnumber":
                            lobjEvaluate.BOL = strColumnValue;
                            break;
                        case "bl_statusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjEvaluate.StatusDesc = strColumnValue;
                            }

                            break;
                        case "bl_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjEvaluate.StatusDesc = strColumnValue;
                            }

                            break;

                        case "bl_statuscode":
                            lobjEvaluate.StatusCode = strColumnValue;
                            break;

                        case "bl_gkey":
                            lobjEvaluate.Blgkey = strColumnValue;
                            break;






                    }

                    lobjEvaluate.AnywhereAll += strColumnValue;

                }

                //  CMS_INFODESC CMS_CODE
                //Completed   103
                //In Yard 101
                //In Progress 102
                //On Vessel   100

                if (lobjEvaluate.StatusCode.ToString().ToUpper().Trim() == "103")
                {
                    lobjEvaluate.StatusColor = "#5cb85c";
                }
                if (lobjEvaluate.StatusCode.ToString().ToUpper().Trim() == "101")
                {
                    lobjEvaluate.StatusColor = "#777";
                }

                if (lobjEvaluate.StatusCode.ToString().ToUpper().Trim() == "102")
                {
                    lobjEvaluate.StatusColor = "#5bc0de";
                }
                if (lobjEvaluate.StatusCode.ToString().ToUpper().Trim() == "100")
                {
                    lobjEvaluate.StatusColor = "#777";
                }

                lobjEvaluate.Sno = lintSLNo;
                llstResult.Add(lobjEvaluate);

                lintSLNo++;
            }
            return llstResult;

        }


        public List<TicketdetailDt> getCrmTicketActivites(string fstrCasegkey)
        {

            // http://172.19.35.68:89/api/DataSource/getCrmTicketActivites?fstrCasegkey=82bec09d-fcb3-ec11-8214-005056880719


            int lintRowNo = 1;
            List<TicketdetailDt> llstResult = new List<TicketdetailDt>();
            string lstrApiName = "getCrmTicketActivites";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrCasegkey", fstrCasegkey);


            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            // int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
            {
                // Info object
                TicketdetailDt lobjTicketActivites = new TicketdetailDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {


                        case "cta_decsc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjTicketActivites.MMessageinfo = strColumnValue;
                            }
                            break;

                        case "cta_decsc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjTicketActivites.MMessageinfo = strColumnValue;
                            }
                            break;
                        case "cta_attachment":
                            lobjTicketActivites.Attachment_file = strColumnValue;
                            break;

                        case "cta_fmtcreateddatetime":
                            lobjTicketActivites.MMessagetime = strColumnValue;
                            break;




                    }

                }

                lobjTicketActivites.SNO = lintRowNo;
                llstResult.Add(lobjTicketActivites);

                lintRowNo++;
            }
            return llstResult;

        }



        public List<EvaluateDt> getEvaluateDetailsBrokerUser(string fstrFilter, int fintPageNumber, int fintPageSize)
        {
            // http://172.19.35.68:89/api/DataSource/getEvaluateDetailsBrokerUser?fstrAPIToken=&fstrMailId=cielobroker1@gmail.com&fstrFilter=&fstrPageNumber=1&fstrPageSize=30
            List<EvaluateDt> llstResult = new List<EvaluateDt>();
            string lstrApiName = "getEvaluateDetailsBrokerUser";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjEvaluateBrokerRow in lobjApiData)
            {
                // Info object
                EvaluateDt lobjEvaluate = new EvaluateDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjEvaluateBrokerRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bl_bayannumber":
                            lobjEvaluate.Bayan = strColumnValue;
                            break;

                        case "bl_blnumber":
                            lobjEvaluate.BOL = strColumnValue;
                            break;
                        case "bl_statuscode":
                            lobjEvaluate.StatusDesc = strColumnValue;
                            break;





                    }

                }



                lobjEvaluate.Sno = lintSLNo;
                llstResult.Add(lobjEvaluate);

                lintSLNo++;
            }
            return llstResult;

        }


        public List<clsDAMAGEPOPUP> getDamagePopupDetails(string fstrFilter)
        {
            //http://172.19.35.68:89/api/DataSource/getDamagePopupDetails?fstrAPIToken=&fstrFilter=CD_BLNUMBER:EGLV101100117869,CD_CONTAINERNUMBER:EITU0426514,BLFLAG:N,
            List<clsDAMAGEPOPUP> llstResult = new List<clsDAMAGEPOPUP>();
            string lstrApiName = "getDamagePopupDetails";

            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");

            lobjInParams.Add("fstrFilter", fstrFilter);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsDAMAGEPOPUP Damagepopup = new clsDAMAGEPOPUP();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "pdfsno":
                            Damagepopup.PDFSNO = strColumnValue;
                            break;

                        case "pdfContainerNo":
                            Damagepopup.PDFContainerNo = strColumnValue;
                            break;

                        case "pdfName":
                            Damagepopup.PDFName = strColumnValue;
                            break;
                        case "sharePointWebUrl":
                            Damagepopup.SharePointWebUrl = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(Damagepopup);

            }
            return llstResult;

        }



        public List<RequesttDt> getTickets(string fstrRegisterUsercode, string fstrFilter, int fintPageNumber, int fintPageSize)
        {

            int lintRowNo = 1;
            List<RequesttDt> llstResult = new List<RequesttDt>();
            string lstrApiName = "getTickets";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserCode", fstrRegisterUsercode);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());


            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            // int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
            {
                // Info object
                RequesttDt lobjTickets = new RequesttDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ct_ticketnumber":
                            lobjTickets.TicketNo = strColumnValue;
                            break;

                        case "ct_categorydesc1":
                            lobjTickets.Category = strColumnValue;
                            break;
                        case "ct_statusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjTickets.Status = strColumnValue;
                            }
                            break;

                        case "ct_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjTickets.Status = strColumnValue;
                            }
                            break;
                        case "ct_casetypedesc1":
                            lobjTickets.CaseType = strColumnValue;
                            break;
                        case "ct_title":
                            lobjTickets.Casetitle = strColumnValue;
                            break;

                        case "ct_casesubtypedesc1":
                            lobjTickets.SubType = strColumnValue;
                            break;

                        case "ct_fmtcreateddatetime":
                            lobjTickets.CreatedOn = strColumnValue;
                            break;
                        case "ct_fmtmodifieddatetime":
                            if (strColumnValue == "0") strColumnValue = "";
                            lobjTickets.CompletedOn = strColumnValue;
                            break;

                        case "ct_caseorigindesc1":
                            lobjTickets.Origin = strColumnValue;
                            break;
                        case "ct_casegkey":
                            lobjTickets.casegkey = strColumnValue;
                            break;

                        case "ct_statuscode":
                            lobjTickets.StatusCode = strColumnValue;
                            break;






                    }

                   // lobjTickets.AnywhereAll += strColumnValue;

                }
                var strtiCketStatus = "";
                strtiCketStatus = lobjTickets.Status;


                lobjTickets.StatusColor = "##d9534f";
                if (lobjTickets.StatusCode == "1")
                {
                    lobjTickets.StatusColor = "#777";
                }


                if (lobjTickets.StatusCode == "1000")
                {
                    lobjTickets.StatusColor = "#5bc0de";
                }

                if (lobjTickets.StatusCode == "3")
                {
                    lobjTickets.StatusColor = "#f0ad4e";
                }

                if (lobjTickets.StatusCode == "5")
                {
                    lobjTickets.StatusColor = "#5cb85c";
                }

                if (lobjTickets.StatusCode == "")
                {
                    lobjTickets.StatusColor = "#134e96";
                }


                lobjTickets.Sno = lintRowNo;
                llstResult.Add(lobjTickets);

                lintRowNo++;
            }
            return llstResult;

        }

        public List<clsTICKETSTYPEFILTER> getTicketsTypeFilter()
        {

            // http://172.19.35.68:89/api/DataSource/getTicketsTypeFilter

            List<clsTICKETSTYPEFILTER> llstResult = new List<clsTICKETSTYPEFILTER>();
            string lstrApiName = "getTicketsTypeFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsTICKETSTYPEFILTER lobjFilter = new clsTICKETSTYPEFILTER();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ct_casetypecode":
                            lobjFilter.ct_casetypecode = strColumnValue;
                            break;


                        case "ct_casetypedesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjFilter.ct_casetypedesc1 = strColumnValue;
                            }

                            break;

                        case "ct_casetypedesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjFilter.ct_casetypedesc1 = strColumnValue;
                            }

                            break;
                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }


        public List<ClsTICKETSCATEGORYFILTER> getTicketsCategoryFilter()
        {

            //http://172.19.35.68:89/api/DataSource/getTicketsCategoryFilter

            List<ClsTICKETSCATEGORYFILTER> llstResult = new List<ClsTICKETSCATEGORYFILTER>();
            string lstrApiName = "getTicketsCategoryFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                ClsTICKETSCATEGORYFILTER lobjFilter = new ClsTICKETSCATEGORYFILTER();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ct_categorycode":
                            lobjFilter.ct_categorycode = strColumnValue;
                            break;


                        case "ct_categorydesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjFilter.ct_categorydesc1 = strColumnValue;
                            }

                            break;

                        case "ct_categorydesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjFilter.ct_categorydesc1 = strColumnValue;
                            }

                            break;
                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public List<clsTICKETSSTATUSFILTER> getTicketsStatusFilter()
        {

            //http://172.19.35.68:89/api/DataSource/getTicketsStatusFilter

            List<clsTICKETSSTATUSFILTER> llstResult = new List<clsTICKETSSTATUSFILTER>();
            string lstrApiName = "getTicketsStatusFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsTICKETSSTATUSFILTER lobjFilter = new clsTICKETSSTATUSFILTER();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ct_statuscode":
                            lobjFilter.ct_statuscode = strColumnValue;
                            break;


                        case "ct_statusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjFilter.ct_statusdesc1 = strColumnValue;
                            }

                            break;

                        case "ct_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjFilter.ct_statusdesc1 = strColumnValue;
                            }

                            break;
                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public List<EmptyUnitReturnDt> getEmptyReturnDetails(string fstrFilter, int fintPageNumber, int fintPageSize)
        {
            // http://172.19.35.68:89/api/DataSource/getEmptyReturnDetails?fstrAPIToken&fstrMailId=cielotransporter1@gmail.com&fstrFilter=fstrAnywhere:;fstrContainerNo:;fstrBayanNo:;fstrBillofLadingNo:;fstrSize:;fstrCarrier:;fstrDetentionDate:;fstrEmptyDepot:;&fstrPageNumber=1&fstrPageSize=20


            List<EmptyUnitReturnDt> llstResult = new List<EmptyUnitReturnDt>();
            string lstrApiName = "getEmptyReturnDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();

            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjEmptyreturnRow in lobjApiData)
            {
                // Info object
                EmptyUnitReturnDt lobjEmptyreturn = new EmptyUnitReturnDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjEmptyreturnRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_shipperdesc1":
                            lobjEmptyreturn.Carrier = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjEmptyreturn.Containerno = strColumnValue;
                            break;
                        case "cd_size":
                            lobjEmptyreturn.Size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjEmptyreturn.Bayan = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjEmptyreturn.BOL = strColumnValue;
                            break;
                        case "cd_fmtdetention":
                            lobjEmptyreturn.DischargedOn = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjEmptyreturn.EmptyDepot = strColumnValue;
                            break;

                        case "cd_gatedouttime":
                            lobjEmptyreturn.GatedOutOn = strColumnValue;
                            break;



                    }

                    lobjEmptyreturn.AnywhereAll += strColumnValue;

                }
                lobjEmptyreturn.Sno = lintSLNo;
                llstResult.Add(lobjEmptyreturn);

                lintSLNo++;
            }
            return llstResult;

        }

        public List<clsEMPTYUNITRETURNSIZEFILTER> getEmptyUnitReturnSizeFilterList(string fstrTransporterGkey, string fstrAPIToken)
        {
            // http://172.19.35.68:89/api/DataSource/getEmptyUnitReturnSizeFilter?fstrAPIToken&fstrFilter=TransporterGkey:5134557409;
            List<clsEMPTYUNITRETURNSIZEFILTER> llstResult = new List<clsEMPTYUNITRETURNSIZEFILTER>();
            string lstrApiName = "getEmptyUnitReturnSizeFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");

            string fstrFilter = "TransporterGkey:" + fstrTransporterGkey + "";

            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsEMPTYUNITRETURNSIZEFILTER lobjFilter = new clsEMPTYUNITRETURNSIZEFILTER();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;


                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }


        public List<clsEMPTYUNITRETURNCARRIERFILTER> getEmptyUnitReturnCarrierFilter(string fstrTransporterGkey, string fstrAPIToken)
        {
            // http://172.19.35.68:89/api/DataSource/getEmptyUnitReturnCarrierFilter?fstrAPIToken&fstrFilter=TransporterGkey:5134557409;
            List<clsEMPTYUNITRETURNCARRIERFILTER> llstResult = new List<clsEMPTYUNITRETURNCARRIERFILTER>();
            string lstrApiName = "getEmptyUnitReturnCarrierFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            string fstrFilter = "TransporterGkey:" + fstrTransporterGkey + "";

            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsEMPTYUNITRETURNCARRIERFILTER lobjFilter = new clsEMPTYUNITRETURNCARRIERFILTER();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;


                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }


        public List<clsEMPTYUNITRETURNEMPTYDEPOTFILTER> getEmptyUnitReturnEmptyDepotFilter(string fstrTransporterGkey, string fstrAPIToken)
        {

            // http://172.19.35.68:89/api/DataSource/getEmptyUnitReturnEmptyDepotFilter?fstrAPIToken&fstrFilter=TransporterGkey:5134557409;
            List<clsEMPTYUNITRETURNEMPTYDEPOTFILTER> llstResult = new List<clsEMPTYUNITRETURNEMPTYDEPOTFILTER>();
            string lstrApiName = "getEmptyUnitReturnEmptyDepotFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            string fstrFilter = "TransporterGkey:" + fstrTransporterGkey + "";

            lobjInParams.Add("fstrFilter", fstrFilter);


            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsEMPTYUNITRETURNEMPTYDEPOTFILTER lobjFilter = new clsEMPTYUNITRETURNEMPTYDEPOTFILTER();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;


                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }


        public List<PaymentDt> getPaymentHistory(string fstrFilter, int fintPageNumber, int fintPageSize)
        {
            //http://172.19.35.68:89/api/DataSource/getPaymentHistoryDetails?fstrAPIToken&fstrMailId=vedaerp@gmail.com&fstrFilter=fstrAnyWhere:;fstrInvoiceNo:;fstrBillofladingno:;fstrConsigneename:;fstrPaymentref:;fstrStatus:;fstrMop:;&fstrPageNumber=1&fstrPageSize=20

            List<PaymentDt> llstResult = new List<PaymentDt>();
            string lstrApiName = "getPaymentHistoryDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjpaymentRow in lobjApiData)
            {
                // Info object
                PaymentDt lobjpayment = new PaymentDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjpaymentRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ih_invoiceno":
                            lobjpayment.InvoiceNo = strColumnValue;
                            break;
                        case "bl_bayannumber":
                            lobjpayment.Bayan = strColumnValue;
                            break;
                        case "bl_blnumber":
                            lobjpayment.BOL = strColumnValue;
                            break;
                        case "ih_consigneename":
                            lobjpayment.Customer = strColumnValue;
                            break;
                        case "ih_grandtotal":

                            lobjpayment.Amount = string.Format("{0:0.00}", Column.Value);
                            break;

                        case "ih_fmtcreateddate":
                            lobjpayment.CreatedOn = strColumnValue;
                            break;
                        case "ih_validity":
                            lobjpayment.Validity = strColumnValue;
                            break;
                        case "ih_status":
                            if (App.gblLanguage == "En")
                            {
                                lobjpayment.Status = strColumnValue;
                            }
                            break;

                        case "ih_statusar":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjpayment.Status = strColumnValue;
                            }
                            break;


                        case "ih_mop":
                            lobjpayment.MOP = strColumnValue;
                            break;

                        case "ih_fmtproformainvoiceduedate":
                            lobjpayment.DueDate = strColumnValue;
                            break;
                        case "ih_paymentref":
                            lobjpayment.PaymentRef = strColumnValue;
                            break;
                        case "ih_fmtpaidon":
                            lobjpayment.PaidOn = strColumnValue;
                            break;








                    }

                    lobjpayment.AnywhereAll += strColumnValue;
                }
                lobjpayment.StatusColor = "#777777"; // unpaid color handled
                if (lobjpayment.Status.ToString().ToUpper().Trim() == "PAID")//PAID color handled
                {
                    lobjpayment.StatusColor = "#5cb85c";
                }

                lobjpayment.Sno = lintSLNo;
                llstResult.Add(lobjpayment);

                lintSLNo++;
            }
            return llstResult;

        }

        public List<clsdashboardCountlist> getDashboard(string fstrEmailID)
        {
            ////http://172.19.35.68:89/api/DataSource/getDashboard?fstrMailId=cieloconsignee@gmail.com

            List<clsdashboardCountlist> llstResult = new List<clsdashboardCountlist>();
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            string lstrApiName = "getDashboard";
            lobjInParams.Add("fstrMailId", fstrEmailID.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                clsdashboardCountlist lobjDashBoard = new clsdashboardCountlist();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "ru_emailid":
                            lobjDashBoard.emailid = strColumnValue;
                            break;
                        case "ru_linkcode":
                            lobjDashBoard.linkcode = strColumnValue;
                            break;
                        case "ru_idno":
                            lobjDashBoard.idno = strColumnValue;
                            break;
                        case "ru_dwelldaysavg":
                            lobjDashBoard.dwelldaysavg = strColumnValue;
                            break;
                        case "ru_pendingpaymentinvoicescount":
                            lobjDashBoard.pendingpaymentinvoicescount = strColumnValue;
                            break;
                        case "ru_volumeupdatecontainerscount":
                            lobjDashBoard.volumeupdatecontainerscount = strColumnValue;
                            break;
                        case "ru_rfdcontainerscount":
                            lobjDashBoard.rfdcontainerscount = strColumnValue;
                            break;
                        case "ru_rfdcontainersexpirycount":
                            lobjDashBoard.rfdcontainersexpirycount = strColumnValue;
                            break;
                        case "ru_containerscount":
                            lobjDashBoard.containerscount = strColumnValue;
                            break;
                        case "ru_mbcontainerscount":
                            lobjDashBoard.mbcontainerscount = strColumnValue;
                            break;
                        case "ru_reviewscount":
                            lobjDashBoard.reviewscount = strColumnValue;
                            break;
                        case "ru_reviewspendingcount":
                            lobjDashBoard.reviewspendingcount = strColumnValue;
                            break;
                        case "ru_avstruckamount":
                            lobjDashBoard.avstruckamount = strColumnValue;
                            break;
                        case "ru_avscutomclearenceamount":
                            lobjDashBoard.avscutomclearenceamount = strColumnValue;
                            break;
                        case "ru_readytodeliverunitcount":
                            lobjDashBoard.readytodeliverunitcount = strColumnValue;
                            break;
                        case "ru_walletbalanace":
                            lobjDashBoard.walletbalanace = strColumnValue;
                            break;
                        case "ru_casesresolved":
                            lobjDashBoard.casesinprogress = strColumnValue;
                            break;
                        case "ru_casesinprogress":
                            lobjDashBoard.casesresolved = strColumnValue;
                            break;
                        case "ru_invoicescount":
                            lobjDashBoard.invoicescount = strColumnValue;
                            break;
                        case "ru_invoicesamount":
                            lobjDashBoard.invoicesamount = Convert.ToDecimal(strColumnValue);
                            break;
                        case "ru_appoinmentscount":
                            lobjDashBoard.appoinmentscount = strColumnValue;
                            break;
                        case "ru_mibcontainerscount":
                            lobjDashBoard.mibcontainerscount = strColumnValue;
                            break;
                        case "ru_r2dgatedoutcount":
                            lobjDashBoard.r2dgatedoutcount = strColumnValue;
                            break;
                        case "ru_r2dyardcount":
                            lobjDashBoard.r2dyardcount = strColumnValue;
                            break;
                        case "ru_unitsunderdentioncount":
                            lobjDashBoard.unitsunderdentioncount = strColumnValue;
                            break;
                        case "ru_unitneardentioncount":
                            lobjDashBoard.unitneardentioncount = strColumnValue;
                            break;
                        case "ru_bannedtruckscount":
                            lobjDashBoard.bannedtruckscount = strColumnValue;
                            break;
                        case "ru_eurrsgtcount":
                            lobjDashBoard.eurrsgtcount = strColumnValue;
                            break;
                        case "ru_euroutsideedcount":
                            lobjDashBoard.euroutsideedcount = strColumnValue;
                            break;
                        case "ru_voltoday":
                            lobjDashBoard.voltoday = strColumnValue;
                            break;
                        case "ru_volthisweek":
                            lobjDashBoard.volthisweek = strColumnValue;
                            break;
                        case "ru_volthismonth":
                            lobjDashBoard.volthismonth = strColumnValue;
                            break;
                        case "ru_volcurrentyear":
                            lobjDashBoard.volcurrentyear = strColumnValue;
                            break;
                        case "ru_volpreviousyear":
                            lobjDashBoard.volpreviousyear = strColumnValue;
                            break;
                        case "ru_ytd20inchpercentage":
                            lobjDashBoard.ytd20inchpercentage = strColumnValue;
                            break;
                        case "ru_ytd40inchpercentage":
                            lobjDashBoard.ytd40inchpercentage = strColumnValue;
                            break;
                        case "ru_ytdreeferpercentage":
                            lobjDashBoard.ytdreeferpercentage = strColumnValue;
                            break;
                        case "ru_ytdinyardcount":
                            lobjDashBoard.ytdinyardcount = strColumnValue;
                            break;
                        case "ru_ytdgatedoutcount":
                            lobjDashBoard.ytdgatedoutcount = strColumnValue;
                            break;
                    }

                }

                llstResult.Add(lobjDashBoard);

            }
            return llstResult;

        }

        private int getWebApiDraftNoStatus(string ApiName, Dictionary<string, string> fstrParams)
        {
            int lintResult = 0;
            string ApiKey = AppSettings.getApiKey;
            string AuthorizationKey = AppSettings.getApiAuthorizationKey;
            ObservableCollection<Object> objData = new ObservableCollection<object>();
            string lstrUrlParams = "";
            string lstramb = "";
            if (fstrParams.Count > 1)
            {
                lstramb = "&";
            }
            foreach (var objParam in fstrParams)
            {
                lstrUrlParams += objParam.Key + "=" + objParam.Value + lstramb;
            }
            if (fstrParams.Count > 1)
            {
                lstrUrlParams = lstrUrlParams.Remove(lstrUrlParams.Length - 1);
            }

            string url = AppSettings.getContentUrl + ApiName + "?" + lstrUrlParams;
            try
            {
                // prepare header parameters as per RSGT inputs
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                    Headers = {
                        { "X-Version", "1" }, // HERE IS HOW TO ADD HEADERS,
                       // { HttpRequestHeader.Authorization.ToString(), ApiKey },
                        { HttpRequestHeader.Authorization.ToString(), AuthorizationKey },
                        { HttpRequestHeader.Accept.ToString(), "application/json, application/xml" },
                        { HttpRequestHeader.ContentType.ToString(), "application/json" },  //use this content type if you want to send more than one content type
                    },
                };

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("ApiKey", ApiKey);
                client.DefaultRequestHeaders.Add("Authorization", AuthorizationKey);//20220531


                var responseTask = client.SendAsync(request).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var objOutputTask = responseTask.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    var jss = new JavaScriptSerializer();
                    string lstrTemp = objOutputTask.Result;
                    lintResult = Convert.ToInt32(lstrTemp);



                }
            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }
            return lintResult;
        }

        public ObservableCollection<Object> getWebApiDataOld(string ApiName, Dictionary<string, string> fstrParams)
        {
            string ApiKey = AppSettings.getApiKey;
            AppSettings.ErrorExceptionWebApi = "";
            string AuthorizationKey = AppSettings.getApiAuthorizationKey;
            ObservableCollection<Object> objData = new ObservableCollection<object>();
            string lstrUrlParams = "";
            string lstramb = "";
            if (fstrParams.Count > 1)
            {
                lstramb = "&";
            }
            foreach (var objParam in fstrParams)
            {
                lstrUrlParams += objParam.Key + "=" + objParam.Value + lstramb;
            }
            if (fstrParams.Count > 1)
            {
                lstrUrlParams = lstrUrlParams.Remove(lstrUrlParams.Length - 1);
            }

            string url = AppSettings.getContentUrl + ApiName + "?" + lstrUrlParams;

            try
            {
                // prepare header parameters as per RSGT inputs
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                    Headers = {
                        { "X-Version", "1" }, // HERE IS HOW TO ADD HEADERS,
                       // { HttpRequestHeader.Authorization.ToString(), ApiKey },
                        { HttpRequestHeader.Authorization.ToString(), AuthorizationKey },
                        { HttpRequestHeader.Accept.ToString(), "application/json, application/xml" },
                        { HttpRequestHeader.ContentType.ToString(), "application/json" },  //use this content type if you want to send more than one content type
                    },
                };

                //Api call and API process
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("ApiKey", ApiKey);
                client.DefaultRequestHeaders.Add("Authorization", AuthorizationKey);//20220531

                int lintTimeOut = 30;

                lintTimeOut = AppSettings.WepApiTimeOut;

                client.Timeout = TimeSpan.FromSeconds(lintTimeOut);
                var responseTask = client.SendAsync(request).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var objOutputTask = responseTask.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    var jss = new JavaScriptSerializer();
                    string lstrTemp = objOutputTask.Result;

                    objData = JsonConvert.DeserializeObject<ObservableCollection<Object>>(lstrTemp);
                    ////var json = Newtonsoft.Json.Linq.JObject.Parse(lstrTemp);

                }
            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
                //if (lstrError == "One or more errors occurred. (A task was canceled.)")
                //{

                //}
                // Handle timeout exception
                AppSettings.ErrorExceptionWebApi = lstrError;

            }
            return objData;
        }

        public string GetMailOtpBUpold(string ApiName, string objstringJson)
        {
            string lstrResult = "";
            string ApiKey = AppSettings.getApiKey;
            string AuthorizationKey = AppSettings.getApiAuthorizationKey;
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            //client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization =
                //new AuthenticationHeaderValue(HttpRequestHeader.Authorization.ToString(), strApiKey);
                //client.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                //var result = client.PostAsync(strURL, content).Result;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", "hl4bA4nB4yI0fC8fH7eT6");
                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    lstrResult = result.IsSuccessStatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        public string GetMailOtp1old(string ApiName, string objstringJson)
        {
            string lstrResult = "";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;

            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;

            client.DefaultRequestHeaders.Add("ApiKey", strApiKey);
            client.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization =
                //new AuthenticationHeaderValue(HttpRequestHeader.Authorization.ToString(), strApiKey);
                client.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                var result = client.PostAsync(strURL, content).Result;




                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    lstrResult = result.IsSuccessStatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        public string SendTruckMailold(string ApiName, string objstringJson)
        {
            string lstrResult = "";
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            //client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization =
                //new AuthenticationHeaderValue(HttpRequestHeader.Authorization.ToString(), strApiKey);
                //client.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                //var result = client.PostAsync(strURL, content).Result;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    lstrResult = result.IsSuccessStatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        public List<AttendInspectiondt> RetreiveAttendInspectionDetails(string fstrContainernumber, string fstrBlnumber)
        {
            //https://webgw.rsgt.com:8080/eportal_api/getReportDamageRetreiveContainer?fstrTransporter=5134557409&fstrContainernumber=PCIU1410397&fstrBlnumber=KHI100327600
            List<AttendInspectiondt> llstResult = new List<AttendInspectiondt>();
            string lstrApiName = "getCRMRetreive";
            string fstrUserCode = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserCode", fstrUserCode);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber);
            lobjInParams.Add("fstrBlnumber", fstrBlnumber);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                AttendInspectiondt lobjDamageContainer = new AttendInspectiondt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_fmtdiscrecivaltime":
                            lobjDamageContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDamageContainer.cd_fmtgatedouttime = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjDamageContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjDamageContainer.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjDamageContainer.cd_transporter = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDamageContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDamageContainer.cd_blnumber = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDamageContainer);

            }
            return llstResult;

        }

        public class AttendInspectiondt
        {
            public string cd_fmtdiscrecivaltime { get; set; }
            public string cd_fmtgatedouttime { get; set; }
            public string cd_emptydepot { get; set; }
            public string cd_damagedetails { get; set; }
            public string cd_transporter { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
        }
        public string createRequest(string fstrCategory, string fstrCaseType, string fstrSubCaseType, string fstrRequestType, string fstrMsg, string strCaseGKey
 , string fstrUserName, string fstrUserCode, string fstrTitle, string fstrRef)
        {
            string lstrResult = "";
            try
            {


                string lstrInput = "{\"CT_CATEGORYCODE\" : \"" + fstrCategory + "\",\"CT_CASETYPECODE\" : \"" + fstrCaseType + "\",";
                lstrInput += "\"CT_CASESUBTYPECODE\" : \"" + fstrSubCaseType + "\" ,";
                lstrInput += "\"CT_REQUESTTYPECODE\" :\"" + fstrRequestType + "\",";
                lstrInput += "\"CT_MESSAGE\" : \"" + fstrMsg + "\",";
                lstrInput += "\"CT_USERCODE\" : \"" + fstrUserCode + "\",";
                lstrInput += "\"CT_USERNAME\" : \"" + fstrUserName + "\",";
                lstrInput += "\"CT_CASEGKEY\" : \"" + strCaseGKey + "\",";
                lstrInput += "\"CT_TITLE\" : \"" + fstrTitle + "\",";
                lstrInput += "\"CT_REFERENCE\" : \"" + fstrRef + "\"}";

                lstrResult = objWebApi.postWebApi("NewCRMTickets", lstrInput);


            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.ToString();

            }
            return lstrResult;
        }



        public string OOGRequest(string fstrCategory, string fstrCaseType, string fstrSubCaseType, string fstrRequestType, string fstrMsg, string strCaseGKey, string fstrUserName, string fstrUserCode, string fstrTitle, string fstrRef, string fstrTYPEOFCARGO, string fstrCATEGORYOFCARGO, string fstrOVERLENGTH,
                    string fstrOVERWIDTH, string fstrOVERHEIGHT, string fstrWEIGHT, string fstrDANGEROUSCARGO, string fstrBASECOST, string fstrDGADDLCHARGE)
        {
            string lstrResult = "";
            try
            {


                string lstrInput = "{\"CT_CATEGORYCODE\" : \"" + fstrCategory + "\",\"CT_CASETYPECODE\" : \"" + fstrCaseType + "\",";
                lstrInput += "\"CT_CASESUBTYPECODE\" : \"" + fstrSubCaseType + "\" ,";
                lstrInput += "\"CT_REQUESTTYPECODE\" :\"" + fstrRequestType + "\",";
                lstrInput += "\"CT_MESSAGE\" : \"" + fstrMsg + "\",";
                lstrInput += "\"CT_USERCODE\" : \"" + fstrUserCode + "\",";
                lstrInput += "\"CT_USERNAME\" : \"" + fstrUserName + "\",";
                lstrInput += "\"CT_CASEGKEY\" : \"" + strCaseGKey + "\",";
                lstrInput += "\"CT_TITLE\" : \"" + fstrTitle + "\",";
                lstrInput += "\"CT_REFERENCE\" : \"" + fstrRef + "\",";

                lstrInput += "\"CT_TYPEOFCARGO\" : \"" + fstrTYPEOFCARGO + "\",";
                lstrInput += "\"CT_CATEGORYOFCARGO\" : \"" + fstrCATEGORYOFCARGO + "\",";
                lstrInput += "\"CT_OVERLENGTH\" : \"" + fstrOVERLENGTH + "\",";
                lstrInput += "\"CT_OVERWIDTH\" : \"" + fstrOVERWIDTH + "\",";
                lstrInput += "\"CT_OVERHEIGHT\" : \"" + fstrOVERHEIGHT + "\",";
                lstrInput += "\"CT_WEIGHT\" : \"" + fstrWEIGHT + "\",";
                lstrInput += "\"CT_DANGEROUSCARGO\" : \"" + fstrDANGEROUSCARGO + "\",";
                lstrInput += "\"CT_BASECOST\" : \"" + fstrBASECOST + "\",";
                lstrInput += "\"CT_DGADDLCHARGE\" : \"" + fstrDGADDLCHARGE + "\"}";

                lstrResult = objWebApi.postWebApi("OOGCRMRequest", lstrInput);


            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.ToString();

            }
            return lstrResult;
        }

        public class ExctraCareDt
        {
            public string cd_fmtdiscrecivaltime { get; set; }
            public string cd_fmtgatedouttime { get; set; }
            public string cd_emptydepot { get; set; }
            public string cd_damagedetails { get; set; }
            public string cd_transporter { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
        }


        public List<InlocationDt> RetreiveInlocation(string fstrContainernumber, string fstrAppoinmentnumber)
        {
            //https://webgw.rsgt.com:8080/eportal_api/getReportDamageRetreiveContainer?fstrTransporter=5134557409&fstrContainernumber=PCIU1410397&fstrBlnumber=KHI100327600
            //https://webgateway.rsgt.com:9090/eportal_api/getInLocationRetreive?fstrcontainerNo=MNBU0563944&fstrAppointmentNo=2168610
            List<InlocationDt> llstResult = new List<InlocationDt>();
            string lstrApiName = "getInLocationRetreive";
            string fstrUserCode = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserCode", fstrUserCode);
            lobjInParams.Add("fstrcontainerNo", fstrContainernumber);
            lobjInParams.Add("fstrAppointmentNo", fstrAppoinmentnumber);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                InlocationDt lobjDamageContainer = new InlocationDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "cd_locationinyard":
                            lobjDamageContainer.cd_locationinyard = strColumnValue;
                            break;
                        case "cd_truckbotno":
                            lobjDamageContainer.cd_truckbotno = strColumnValue;
                            break;
                        case "cd_timeslab":
                            lobjDamageContainer.cd_timeslab = strColumnValue;
                            break;
                        case "cd_appointmentNumber":
                            lobjDamageContainer.cd_appointmentNumber = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDamageContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDamageContainer.cd_blnumber = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDamageContainer);

            }
            return llstResult;
        }
        public class InlocationDt
        {
            public string cd_locationinyard { get; set; }
            public string cd_truckbotno { get; set; }
            public string cd_timeslab { get; set; }
            public string cd_appointmentNumber { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
        }
        public List<EIRDt> RetreiveContainerDetail(string fstrContainernumber, string fstrBlnumber, string fstrTruckNo)
        {
            // https://webgateway.rsgt.com:9090/eportal_api/getContainer?fstrUserCode=5134557409&fstrContainernumber=PCIU1100344&fstrBlnumber=KHI100327600&fstrTruckNo=2464ERA
            // https://webgateway.rsgt.com:9090/eportal_api/getContainer?fstrUserCode=5134557409&fstrContainernumber=AIDU5010098 &fstrBlnumber=914521686&fstrTruckNo=9926DJA
            List<EIRDt> llstResult = new List<EIRDt>();
            string lstrApiName = "getContainer";
            string fstrUserCode = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserCode", fstrUserCode);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber);
            lobjInParams.Add("fstrBlnumber", fstrBlnumber);
            lobjInParams.Add("fstrTruckNo", fstrTruckNo);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                EIRDt lobjEit = new EIRDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_fmtdiscrecivaltime":
                            lobjEit.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjEit.cd_fmtgatedouttime = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjEit.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjEit.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjEit.cd_transporter = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjEit.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjEit.cd_blnumber = strColumnValue;
                            break;
                        case "cd_platenbr":
                            lobjEit.cd_platenbr = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjEit);

            }
            return llstResult;
        }

        public class EIRDt
        {
            public string cd_fmtdiscrecivaltime { get; set; }
            public string cd_fmtgatedouttime { get; set; }
            public string cd_emptydepot { get; set; }
            public string cd_damagedetails { get; set; }
            public string cd_transporter { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_truckno { get; set; }
            public string cd_platenbr { get; set; }

        }
        public List<ManifestContainerDt> ManifestupdateRequest(string fstrContainernumber)
        {
            //webgateway.rsgt.com:9090/eportal_api/getManiFestMandatorycheck?fstrContainerNo=MSKU7616040
            List<ManifestContainerDt> llstResult = new List<ManifestContainerDt>();
            string lstrApiName = "getManiFestMandatorycheck";
            string fstrUserCode = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrContainerNo", fstrContainernumber);
            lobjInParams.Add("fstrUserCode", fstrUserCode);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjManiFestHeaderRow in lobjApiData)
            {
                // Info object
                ManifestContainerDt lobjManiFest = new ManifestContainerDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjManiFestHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "vd_visitid":
                            lobjManiFest.vd_visitid = strColumnValue;
                            break;
                        case "vd_ibvoyage":
                            lobjManiFest.vd_ibvoyage = strColumnValue;
                            break;
                        case "vd_obvoyage":
                            lobjManiFest.vd_obvoyage = strColumnValue;
                            break;
                        case "vd_serviceid":
                            lobjManiFest.vd_serviceid = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjManiFest.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjManiFest.cd_blnumber = strColumnValue;
                            break;
                        case "cd_category":
                            lobjManiFest.cd_category = strColumnValue;
                            break;
                        case "cd_commodity":
                            lobjManiFest.cd_commodity = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjManiFest);

            }
            return llstResult;

        }

        public List<ExctraCareDt> RetreiveExctraCareDetails(string fstrContainernumber, string fstrBlnumber)
        {
            //https://webgw.rsgt.com:8080/eportal_api/getReportDamageRetreiveContainer?fstrTransporter=5134557409&fstrContainernumber=PCIU1410397&fstrBlnumber=KHI100327600
            List<ExctraCareDt> llstResult = new List<ExctraCareDt>();
            string lstrApiName = "getCRMRetreive";
            string fstrUserCode = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserCode", fstrUserCode);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber.Trim());
            lobjInParams.Add("fstrBlnumber", fstrBlnumber.Trim());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                ExctraCareDt lobjDamageContainer = new ExctraCareDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_fmtdiscrecivaltime":
                            lobjDamageContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDamageContainer.cd_fmtgatedouttime = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjDamageContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjDamageContainer.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjDamageContainer.cd_transporter = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDamageContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDamageContainer.cd_blnumber = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDamageContainer);

            }
            return llstResult;
        }

        public List<EirRequestHistoryModelDt> getEirRequestHistory(string fstrFilter, string fintPageNumber, string fintPageSize, string fstrOrderBy)
        {
            // string fstrUserCode,string fstrTitle, string fstrFilter, string fstrPageNumber, string fstrPageSize
            List<EirRequestHistoryModelDt> llstResult = new List<EirRequestHistoryModelDt>();
            try
            {
                // https://webgateway.rsgt.com:9090/eportal_api/getGateListview?fstrFilter=fstrAnyWhere:;fstrContainerNo:;fstrBOLNo:;fstrRequestDate:;fstrStatus:;

                //https://webgateway.rsgt.com:9090/eportal_api/getGateListview?fstrFilter=fstrAnyWhere:;fstrContainerNo:;fstrBOLNo:;fstrRequestDate:;fstrStatus:;&fstrPageNumber=1&fstrPageSize=5&fstrOrderBy

                int lintRowNo = 1;


                string lstrApiName = "getGateListview";
                Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
                string fstrMailId = gblRegisteration.strLoginUser;
                lobjInParams.Add("fstrMailId", fstrMailId);
                lobjInParams.Add("fstrFilter", fstrFilter);
                lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
                lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
                lobjInParams.Add("fstrOrderBy", fstrOrderBy.ToString());

                IEnumerable<Object> lobjApiData;
                lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


                // int lintSLNo = 1;
                foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
                {
                    // Info object
                    EirRequestHistoryModelDt lobjEIRRequest = new EirRequestHistoryModelDt();

                    foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                    {
                        //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                        string strColumnName = Column.Name;
                        string strColumnValue = Column.Value.ToString();

                        switch (strColumnName)
                        {
                            case "gpr_licenseno":
                                lobjEIRRequest.gpr_licenseno = strColumnValue;
                                break;

                            case "gpr_containernumber":
                                lobjEIRRequest.gpr_containernumber = strColumnValue;
                                break;
                            case "gpr_blnumber":
                                lobjEIRRequest.gpr_blnumber = strColumnValue;
                                break;

                            case "gpr_requesteddate":
                                lobjEIRRequest.gpr_requesteddate = strColumnValue;
                                break;
                            case "gpr_status":
                                lobjEIRRequest.gpr_status = strColumnValue;
                                break;
                            case "gp_reqreference":
                                lobjEIRRequest.gp_reqreference = strColumnValue;
                                break;

                            case "gpr_photosflag":
                                lobjEIRRequest.gpr_photosflag = strColumnValue;
                                break;


                            case "trcount":
                                lobjEIRRequest.TRCOUNT = Convert.ToInt64(strColumnValue);
                                break;

                            case "serialno":
                                lobjEIRRequest.SNO = Convert.ToInt64(strColumnValue);
                                break;


                        }
                    }

                    //20230531 - Sanduru
                    lobjEIRRequest.StatusColorEIR = "#5bc0de";// Banned color handled


                    if (lobjEIRRequest.gpr_status.ToUpper().Trim() == "RESOLVED")
                    {
                        lobjEIRRequest.StatusColorEIR = "#5cb85c";
                    }

                    llstResult.Add(lobjEIRRequest);

                    lintRowNo++;
                }

            }
            catch (Exception ex)
            {
                string strError = ex.Message.ToString();
            }
            return llstResult;
        }
        public List<EirRequestHistoryModelDt> getImages(string fstrReqreference)
        {
            // string fstrUserCode,string fstrTitle, string fstrFilter, string fstrPageNumber, string fstrPageSize
            List<EirRequestHistoryModelDt> llstResult = new List<EirRequestHistoryModelDt>();
            try
            {
                // https://webgateway.rsgt.com:9090/eportal_api/getEIRPhotos?fstrReqreference=255500_225500_LMCU9111972
                //License+BOL+Container
                //2_JEDIMPSP4144E_MRSU3922594
                int lintRowNo = 1;

                string lstrApiName = "getEIRPhotos";
                Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
                lobjInParams.Add("fstrReqreference", fstrReqreference);

                IEnumerable<Object> lobjApiData;
                lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


                //  int lintSLNo = 1;
                foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
                {
                    // Info object
                    EirRequestHistoryModelDt lobjEIRRequest = new EirRequestHistoryModelDt();

                    foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                    {
                        //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                        string strColumnName = Column.Name;
                        string strColumnValue = Column.Value.ToString();

                        switch (strColumnName)
                        {
                            case "gpr_licenseno":
                                lobjEIRRequest.gpr_licenseno = strColumnValue;
                                break;

                            case "gpr_containernumber":
                                lobjEIRRequest.gpr_containernumber = strColumnValue;
                                break;
                            case "gpr_blnumber":
                                lobjEIRRequest.gpr_blnumber = strColumnValue;
                                break;

                            case "gpr_requesteddate":
                                lobjEIRRequest.gpr_requesteddate = strColumnValue;
                                break;
                            case "gpr_status":
                                lobjEIRRequest.gpr_status = strColumnValue;
                                break;
                            case "gp_reqreference":
                                lobjEIRRequest.gp_reqreference = strColumnValue;
                                break;

                            case "gp_image":
                                lobjEIRRequest.gp_image = strColumnValue;
                                lobjEIRRequest.Gate_Image = strColumnValue;
                                break;
                        }
                    }

                    lobjEIRRequest.SNO = lintRowNo;
                    llstResult.Add(lobjEIRRequest);

                    lintRowNo++;
                }
                return llstResult;
            }
            catch (Exception ex)
            {
                string strSQLErrorMessage = ex.ToString();
                // return RedirectToAction("Error", "Error", new { fstrException = strSQLErrorMessage });
            }
            return llstResult;
        }

        public List<DirectDeliverydt> RetreiveDirectDeliveryDetails(string fstrBayanNo)
        {
            //https://portalmobapi.rsgt.com:8443/api/DataSource/getRetreiveBayn?fstrlinkcode=4088749006&fstrCustomerType=ClearingAgent&fstrBayanNo=100609
            List<DirectDeliverydt> llstResult = new List<DirectDeliverydt>();
            string lstrApiName = "getRetreiveBayn";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrlinkcode", gblRegisteration.strLoginUserLinkcode);
            lobjInParams.Add("fstrCustomerType", gblRegisteration.strLoginCustomerType);
            lobjInParams.Add("fstrBayanNo", fstrBayanNo);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                DirectDeliverydt lobjDamageContainer = new DirectDeliverydt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_fmtdiscrecivaltime":
                            lobjDamageContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDamageContainer.cd_fmtgatedouttime = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjDamageContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjDamageContainer.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjDamageContainer.cd_transporter = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDamageContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDamageContainer.cd_blnumber = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDamageContainer);

            }
            return llstResult;
        }

        public List<ExtendedDetention> RetreiveExtendedDetention(string fstrContainernumber, string fstrBlnumber)
        {
            // https://webgateway.rsgt.com:9090/eportal_api/getRetriveEextendDetention?fstrUserCode=1302898&fstrContainernumber=TCKU1270125&fstrBlnumber=225486745
            List<ExtendedDetention> llstResult = new List<ExtendedDetention>();
            string lstrApiName = "getRetriveEextendDetention";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserCode", gblRegisteration.strLoginUserLinkcode);
            // lobjInParams.Add("fstrCustomerType", gblRegisteration.strLoginCustomerType);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber);
            lobjInParams.Add("fstrBlnumber", fstrBlnumber);
            // lobjInParams.Add("fstrEmailID", gblRegisteration.strLoginUser);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                ExtendedDetention lobjExtendedDetention = new ExtendedDetention();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_containernumber":
                            lobjExtendedDetention.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjExtendedDetention.cd_blnumber = strColumnValue;
                            break;
                        case "cd_consigneegkey":
                            lobjExtendedDetention.cd_consigneegkey = strColumnValue;
                            break;
                        case "cd_agentkey":
                            lobjExtendedDetention.cd_agentkey = strColumnValue;
                            break;
                        case "cd_shippergkey":
                            lobjExtendedDetention.cd_shippergkey = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjExtendedDetention.cd_transporter = strColumnValue;
                            break;
                        case "cd_custombrokeragent":
                            lobjExtendedDetention.cd_custombrokeragent = strColumnValue;
                            break;
                        case "bl_linegkey":
                            lobjExtendedDetention.bl_linegkey = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjExtendedDetention);

            }
            return llstResult;
        }


        public async Task<List<GETCOMMCREDENTIALS>> getCommCredentials()
        {

            List<GETCOMMCREDENTIALS> llstResult = new List<GETCOMMCREDENTIALS>();
            string lstrApiName = "GETCommCredentials";
            string fstrUserCode = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);
            await Task.Delay(2000);

            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                GETCOMMCREDENTIALS lobjCOMMCREDENTIALS = new GETCOMMCREDENTIALS();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cc_showoog":
                            lobjCOMMCREDENTIALS.cc_showoog = strColumnValue;
                            break;
                        case "cc_showeircopy":
                            lobjCOMMCREDENTIALS.cc_showeircopy = strColumnValue;
                            break;
                        case "cc_showextracare":
                            lobjCOMMCREDENTIALS.cc_showextracare = strColumnValue;
                            break;
                        case "cc_showmanifest":
                            lobjCOMMCREDENTIALS.cc_showmanifest = strColumnValue;
                            break;
                        case "cc_showoffload":
                            lobjCOMMCREDENTIALS.cc_showoffload = strColumnValue;
                            break;
                        case "cc_showdirectdelivery":
                            lobjCOMMCREDENTIALS.cc_showdirectdelivery = strColumnValue;
                            break;
                        case "cc_showattendinspection":
                            lobjCOMMCREDENTIALS.cc_showattendinspection = strColumnValue;
                            break;
                        case "cc_showinlocation":
                            lobjCOMMCREDENTIALS.cc_showinlocation = strColumnValue;
                            break;
                        case "cc_showbookformanualinspection":
                            lobjCOMMCREDENTIALS.cc_showbookformanualinspection = strColumnValue;
                            break;
                        case "cc_showreportdamagecontainer":
                            lobjCOMMCREDENTIALS.cc_showreportdamagecontainer = strColumnValue;
                            break;
                        case "cc_showtruckservicerequest":
                            lobjCOMMCREDENTIALS.cc_showtruckservicerequest = strColumnValue;
                            break;
                        case "cc_recid":
                            lobjCOMMCREDENTIALS.cc_recid = strColumnValue;
                            break;
                        case "cc_smsapi":
                            lobjCOMMCREDENTIALS.cc_smsapi = strColumnValue;
                            break;
                        case "cc_smsuserid":
                            lobjCOMMCREDENTIALS.cc_smsuserid = strColumnValue;
                            break;
                        case "cc_smspassword":
                            lobjCOMMCREDENTIALS.cc_smspassword = strColumnValue;
                            break;
                        case "cc_smtpserver":
                            lobjCOMMCREDENTIALS.cc_smtpserver = strColumnValue;
                            break;

                        case "cc_smtpport":
                            lobjCOMMCREDENTIALS.cc_smtpport = strColumnValue;
                            break;
                        case "cc_emailuserid":
                            lobjCOMMCREDENTIALS.cc_emailuserid = strColumnValue;
                            break;
                        case "cc_emailpassword":
                            lobjCOMMCREDENTIALS.cc_emailpassword = strColumnValue;
                            break;
                        case "cc_emailhistoryflag":
                            lobjCOMMCREDENTIALS.cc_emailhistoryflag = strColumnValue;
                            break;
                        case "cc_emailhistory":
                            lobjCOMMCREDENTIALS.cc_emailhistory = strColumnValue;
                            break;
                        case "cc_smshistoryflag":
                            lobjCOMMCREDENTIALS.cc_smshistoryflag = strColumnValue;
                            break;
                        case "cc_smshistory":
                            lobjCOMMCREDENTIALS.cc_smshistory = strColumnValue;
                            break;

                        case "cc_sessionlogflag":
                            lobjCOMMCREDENTIALS.cc_sessionlogflag = strColumnValue;
                            break;
                        case "cc_sessionlog":
                            lobjCOMMCREDENTIALS.cc_sessionlog = strColumnValue;
                            break;
                        case "cc_sqllogflag":
                            lobjCOMMCREDENTIALS.cc_sqllogflag = strColumnValue;
                            break;
                        case "cc_sqllog":
                            lobjCOMMCREDENTIALS.cc_sqllog = strColumnValue;
                            break;
                        case "cc_errorlogflag":
                            lobjCOMMCREDENTIALS.cc_errorlogflag = strColumnValue;
                            break;
                        case "cc_errorlog":
                            lobjCOMMCREDENTIALS.cc_errorlog = strColumnValue;
                            break;
                        case "cc_internetconnflag":
                            lobjCOMMCREDENTIALS.cc_internetconnflag = strColumnValue;
                            break;
                        case "cc_internetconn":
                            lobjCOMMCREDENTIALS.cc_internetconn = strColumnValue;
                            break;
                        case "cc_smtpissueflag":
                            lobjCOMMCREDENTIALS.cc_smtpissueflag = strColumnValue;
                            break;
                        case "cc_smtpissue":
                            lobjCOMMCREDENTIALS.cc_smtpissue = strColumnValue;
                            break;
                        case "cc_apidatapullflag":
                            lobjCOMMCREDENTIALS.cc_apidatapullflag = strColumnValue;
                            break;
                        case "cc_apidatapull":
                            lobjCOMMCREDENTIALS.cc_apidatapull = strColumnValue;
                            break;

                        case "cc_smsissueflag":
                            lobjCOMMCREDENTIALS.cc_smsissueflag = strColumnValue;
                            break;
                        case "cc_smsissue":
                            lobjCOMMCREDENTIALS.cc_smsissue = strColumnValue;
                            break;
                        case "cc_sqlserverconnissueflag":
                            lobjCOMMCREDENTIALS.cc_sqlserverconnissueflag = strColumnValue;
                            break;
                        case "cc_sqlserverconnissue":
                            lobjCOMMCREDENTIALS.cc_sqlserverconnissue = strColumnValue;
                            break;
                        case "cc_rsgtnewsflag":
                            lobjCOMMCREDENTIALS.cc_rsgtnewsflag = strColumnValue;
                            break;
                        case "cc_newsenglish":
                            lobjCOMMCREDENTIALS.cc_newsenglish = strColumnValue;
                            break;
                        case "cc_newsarabic":
                            lobjCOMMCREDENTIALS.cc_newsarabic = strColumnValue;
                            break;
                        case "cc_msgbgcolour":
                            lobjCOMMCREDENTIALS.cc_msgbgcolour = strColumnValue;
                            break;
                        case "cc_paymentflag":
                            lobjCOMMCREDENTIALS.cc_paymentflag = strColumnValue;
                            break;
                        case "cc_paymentlog":
                            lobjCOMMCREDENTIALS.cc_paymentlog = strColumnValue;
                            break;
                        case "cc_apikeyexpirydaysflag":
                            lobjCOMMCREDENTIALS.cc_apikeyexpirydaysflag = strColumnValue;
                            break;
                        case "cc_apikeyexpirydayslog":
                            lobjCOMMCREDENTIALS.cc_apikeyexpirydayslog = strColumnValue;
                            break;
                        case "cc_cmslistviewpagesize":
                            lobjCOMMCREDENTIALS.cc_cmslistviewpagesize = strColumnValue;
                            break;

                        case "cc_axsrestrict_advancetracking":
                            lobjCOMMCREDENTIALS.cc_axsrestrict_advancetracking = strColumnValue;
                            break;
                        case "cc_axsrestrict_invoicepayments":
                            lobjCOMMCREDENTIALS.cc_axsrestrict_invoicepayments = strColumnValue;
                            break;
                        case "cc_axsrestrict_requests":
                            lobjCOMMCREDENTIALS.cc_axsrestrict_requests = strColumnValue;
                            break;
                        case "cc_axsrestrict_bookanappointment":
                            lobjCOMMCREDENTIALS.cc_axsrestrict_bookanappointment = strColumnValue;
                            break;
                        case "cc_jsonftp_servername":
                            lobjCOMMCREDENTIALS.cc_jsonftp_servername = strColumnValue;
                            break;
                        case "cc_jsonftp_userid":
                            lobjCOMMCREDENTIALS.cc_jsonftp_userid = strColumnValue;
                            break;
                        case "cc_jsonftp_password":
                            lobjCOMMCREDENTIALS.cc_jsonftp_password = strColumnValue;
                            break;
                        case "cc_jsonftp_androidpath":
                            lobjCOMMCREDENTIALS.cc_jsonftp_androidpath = strColumnValue;
                            break;
                        case "cc_jsonftp_iospath":
                            lobjCOMMCREDENTIALS.cc_jsonftp_iospath = strColumnValue;
                            break;
                        case "cc_versionno":
                            lobjCOMMCREDENTIALS.cc_versionno = strColumnValue;
                            break;

                    }
                }
                llstResult.Add(lobjCOMMCREDENTIALS);

            }
            return llstResult;

        }
        public class GETCOMMCREDENTIALS
        {
            public string cc_showoog { get; set; }
            public string cc_showeircopy { get; set; }
            public string cc_showextracare { get; set; }
            public string cc_showmanifest { get; set; }
            public string cc_showoffload { get; set; }
            public string cc_showdirectdelivery { get; set; }
            public string cc_showattendinspection { get; set; }
            public string cc_showinlocation { get; set; }
            public string cc_showbookformanualinspection { get; set; }
            public string cc_showreportdamagecontainer { get; set; }
            public string cc_showtruckservicerequest { get; set; }
            //09-03-2023
            public string cc_recid { get; set; }
            public string cc_smsapi { get; set; }
            public string cc_smsuserid { get; set; }
            public string cc_smspassword { get; set; }
            public string cc_smtpserver { get; set; }
            public string cc_smtpport { get; set; }
            public string cc_emailuserid { get; set; }
            public string cc_emailpassword { get; set; }
            public string cc_emailhistoryflag { get; set; }
            public string cc_emailhistory { get; set; }
            public string cc_smshistoryflag { get; set; }
            public string cc_smshistory { get; set; }
            public string cc_sessionlogflag { get; set; }
            public string cc_sessionlog { get; set; }
            public string cc_sqllogflag { get; set; }
            public string cc_sqllog { get; set; }
            public string cc_errorlogflag { get; set; }
            public string cc_errorlog { get; set; }
            public string cc_internetconnflag { get; set; }
            public string cc_internetconn { get; set; }
            public string cc_smtpissueflag { get; set; }
            public string cc_smtpissue { get; set; }
            public string cc_apidatapullflag { get; set; }
            public string cc_apidatapull { get; set; }
            public string cc_smsissueflag { get; set; }
            public string cc_smsissue { get; set; }
            public string cc_sqlserverconnissueflag { get; set; }
            public string cc_sqlserverconnissue { get; set; }
            public string cc_rsgtnewsflag { get; set; }
            public string cc_newsenglish { get; set; }
            public string cc_newsarabic { get; set; }
            public string cc_msgbgcolour { get; set; }
            public string cc_paymentflag { get; set; }
            public string cc_paymentlog { get; set; }
            public string cc_apikeyexpirydaysflag { get; set; }
            public string cc_apikeyexpirydayslog { get; set; }
            public string cc_cmslistviewpagesize { get; set; }
            public string cc_axsrestrict_advancetracking { get; set; }
            public string cc_axsrestrict_invoicepayments { get; set; }
            public string cc_axsrestrict_requests { get; set; }
            public string cc_axsrestrict_bookanappointment { get; set; }
            public string cc_jsonftp_servername { get; set; }
            public string cc_jsonftp_userid { get; set; }
            public string cc_jsonftp_password { get; set; }
            public string cc_jsonftp_androidpath { get; set; }
            public string cc_jsonftp_iospath { get; set; }
            public string cc_versionno { get; set; }



        }
        public List<OffloadrequestDt> RetreiveOffloadRequest(string fstrContainernumber, string fstrBlnumber)
        {
            //https://webgw.rsgt.com:8080/eportal_api/getReportDamageRetreiveContainer?fstrTransporter=5134557409&fstrContainernumber=PCIU1410397&fstrBlnumber=KHI100327600
            List<OffloadrequestDt> llstResult = new List<OffloadrequestDt>();
            string lstrApiName = "getCRMRetreive";
            string fstrUserCode = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserCode", fstrUserCode);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber);
            lobjInParams.Add("fstrBlnumber", fstrBlnumber);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                OffloadrequestDt lobjDamageContainer = new OffloadrequestDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_fmtdiscrecivaltime":
                            lobjDamageContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDamageContainer.cd_fmtgatedouttime = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjDamageContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjDamageContainer.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjDamageContainer.cd_transporter = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDamageContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDamageContainer.cd_blnumber = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDamageContainer);

            }
            return llstResult;

        }

        public class OffloadrequestDt
        {
            public string cd_fmtdiscrecivaltime { get; set; }
            public string cd_fmtgatedouttime { get; set; }
            public string cd_emptydepot { get; set; }
            public string cd_damagedetails { get; set; }
            public string cd_transporter { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
        }

        public List<RETRIVECONTAINER> ReteriveDirectDelivery(string fstrbayanNo, string fstrBlnumber, string fstrContainernumber)
        {

            // https://webgateway.rsgt.com:9090/eportal_api/getDirectdelivery?fstrbayanNo=48406&fstrBlnumber=2659416050&fstrContainernumber=OOLU6422438

            List<RETRIVECONTAINER> llstResult = new List<RETRIVECONTAINER>();
            string lstrApiName = "getDirectdelivery";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();

            lobjInParams.Add("fstrbayanNo", fstrbayanNo);
            lobjInParams.Add("fstrBlnumber", fstrBlnumber);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber);


            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                RETRIVECONTAINER lobjDirectDelivery = new RETRIVECONTAINER();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_bayannumber":
                            lobjDirectDelivery.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDirectDelivery.cd_blnumber = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDirectDelivery.cd_containernumber = strColumnValue;
                            break;
                        case "cd_apptdate":
                            lobjDirectDelivery.cd_apptdate = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjDirectDelivery.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_discrecivaltime":
                            lobjDirectDelivery.cd_discrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjDirectDelivery.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDirectDelivery.cd_fmtgatedouttime = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDirectDelivery);

            }
            return llstResult;

        }
        public class RETRIVECONTAINER
        {
            public string cd_bayannumber { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_apptdate { get; set; }
            public string cd_damagedetails { get; set; }
            public string cd_discrecivaltime { get; set; }
            public string cd_fmtdiscrecivaltime { get; set; }
            public string cd_fmtgatedouttime { get; set; }

        }
        public List<ExtraCareDt> getExtraCare(string fstrRegisterUsercode, string fstrTitle, int fintPageNumber, int fintPageSize, string fstrOrderBy, string fstrFilter)
        {
            // https://webgateway.rsgt.com:9090/eportal_api/getCRMRequest?fstrUserCode=20a880e6-8511-ed11-b7fb-d566c50e2c51&fstrTitle=EXTRA
            // CARE&fstrFilter=fstrTicketNumber:;fstrAnywhere:;fstrCasetype:;fstrCategory:;fstrStatus:;&fstrPageSize=1&fstrPageNumber=10&fstrOrderBy

            // https://webgateway.rsgt.com:9090/eportal_api/getCRMRequest?fstrUserCode=0518a1f7-7b73-ec11-8214-005056880719&fstrTitle=Extra
            // Care & Hot Shipment&fstrPageNumber=1&fstrPageSize=1000&fstrOrderBy=&fstrFilter=fstrAnyWordSearch:;fstrTicketNumer:;fstrTickettype:;fstrCategory:;fstrStatus:;

            int lintRowNo = 1;
            List<ExtraCareDt> llstResult = new List<ExtraCareDt>();
            string lstrApiName = "getCRMRequest";
            fstrTitle = fstrTitle.Replace("&", "%26");
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();

            lobjInParams.Add("fstrUserCode", fstrRegisterUsercode);
            lobjInParams.Add("fstrTitle", fstrTitle);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
            lobjInParams.Add("fstrOrderBy", "");
            lobjInParams.Add("fstrFilter", fstrFilter);



            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            //int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
            {
                // Info object
                ExtraCareDt lobjTickets = new ExtraCareDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ct_ticketnumber":
                            lobjTickets.TicketNo = strColumnValue;
                            break;

                        case "ct_categorydesc1":
                            lobjTickets.Category = strColumnValue;
                            break;
                        case "ct_statusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjTickets.Status = strColumnValue;
                            }
                            break;

                        case "ct_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjTickets.Status = strColumnValue;
                            }
                            break;
                        case "ct_casetypedesc1":
                            lobjTickets.CaseType = strColumnValue;
                            break;
                        case "ct_title":
                            lobjTickets.Casetitle = strColumnValue;
                            break;

                        case "ct_casesubtypedesc1":
                            lobjTickets.SubType = strColumnValue;
                            break;

                        case "ct_createddatetime":
                            lobjTickets.CreatedOn = strColumnValue;
                            break;
                        case "ct_modifieddatetime":
                            if (strColumnValue == "0") strColumnValue = "";
                            lobjTickets.CompletedOn = strColumnValue;
                            break;

                        case "ct_caseorigindesc1":
                            lobjTickets.Origin = strColumnValue;
                            break;
                        case "ct_casegkey":
                            lobjTickets.casegkey = strColumnValue;
                            break;

                        case "ct_statuscode":
                            lobjTickets.StatusCode = strColumnValue;
                            break;

                        case "ct_typeofcargo":
                            lobjTickets.CT_TYPEOFCARGO = strColumnValue;
                            break;
                        case "ct_categoryofcargo":
                            lobjTickets.CT_CATEGORYOFCARGO = strColumnValue; //typeofcargo,categoryofcargo,overlength,overwidth
                            break;
                        case "ct_overlength":
                            lobjTickets.CT_OVERLENGTH = strColumnValue;
                            break;
                        case "ct_overwidth":
                            lobjTickets.CT_OVERWIDTH = strColumnValue;
                            break;
                        case "ct_overheight":
                            lobjTickets.CT_OVERHEIGHT = strColumnValue;
                            break;
                        case "ct_weight":
                            lobjTickets.CT_WEIGHT = strColumnValue;
                            break;
                        case "ct_dangerouscargo":
                            lobjTickets.CT_DANGEROUSCARGO = strColumnValue;
                            break;
                        case "ct_basecost":
                            lobjTickets.CT_BASECOST = strColumnValue;
                            break;
                        case "ct_dgaddlcharge":
                            lobjTickets.CT_DGADDLCHARGE = strColumnValue;
                            break;





                    }

                    lobjTickets.AnywhereAll += strColumnValue;

                }
                var strtiCketStatus = "";
                strtiCketStatus = lobjTickets.Status;


                lobjTickets.StatusColor = "##d9534f";
                if (lobjTickets.StatusCode == "1")
                {
                    lobjTickets.StatusColor = "#777";
                }


                if (lobjTickets.StatusCode == "1000")
                {
                    lobjTickets.StatusColor = "#5bc0de";
                }

                if (lobjTickets.StatusCode == "3")
                {
                    lobjTickets.StatusColor = "#f0ad4e";
                }

                if (lobjTickets.StatusCode == "5")
                {
                    lobjTickets.StatusColor = "#5cb85c";
                }

                if (lobjTickets.StatusCode == "")
                {
                    lobjTickets.StatusColor = "#134e96";
                }


                lobjTickets.Sno = lintRowNo;
                llstResult.Add(lobjTickets);

                lintRowNo++;
            }
            return llstResult;

        }
        public List<BookingDt> getAppointmentList(string fstrFilter, int fintPageNumber, int fintPageSize)
        {
            // http://172.19.35.68:89/api/DataSource/getAppointmentList?fstrAPIToken&fstrMailId=vedaerp@gmail.com&fstrFilter=fstrAnyWhere:;fstrBLNumber:;fstrContainerNumber:;fstrTmsrefno:;fstrApptdate:;fstrApptstatus:;&fstrPageNumber=1&fstrPageSize=20

            List<BookingDt> llstResult = new List<BookingDt>();
            string lstrApiName = "getAppointmentList";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjAppointRow in lobjApiData)
            {
                // Info object
                BookingDt lobjAppoint = new BookingDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjAppointRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_containernumber":
                            lobjAppoint.Container = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjAppoint.BayanNo = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjAppoint.Billoflading = strColumnValue;
                            break;

                        case "cd_fmtapptdate":
                            lobjAppoint.AppDate = strColumnValue;
                            break;
                        case "cd_apptstatus":
                            if (App.gblLanguage == "En")
                            {
                                lobjAppoint.Status = strColumnValue;
                            }
                            break;

                        case "cd_apptstatusar":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjAppoint.Status = strColumnValue;
                            }
                            break;

                        case "cd_tmsrefno":
                            lobjAppoint.TmsBookingRef = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjAppoint.Shippingline = strColumnValue;
                            break;

                        case "cd_shippingicon":
                            lobjAppoint.ShippingIcon = strColumnValue;
                            break;

                        case "cd_consigneedesc1":
                            lobjAppoint.Consignee = strColumnValue;
                            break;

                        case "cd_shipperdesc1":
                            lobjAppoint.Shipper = strColumnValue;
                            break;
                        case "cd_statuscode":
                            lobjAppoint.statuscode = strColumnValue;
                            break;







                    }

                    lobjAppoint.StatusColor = "#f0ad4e"; // unpaid color handled
                    if (lobjAppoint.statuscode == "GO")//PAID color handled
                    {
                        lobjAppoint.StatusColor = "#5bc0de";
                    }
                    lobjAppoint.AnywhereAll += strColumnValue;
                }
                lobjAppoint.Sno = lintSLNo;
                llstResult.Add(lobjAppoint);

                lintSLNo++;
            }
            return llstResult;

        }





        public string SendTerminalVisitMailold(string ApiName, string objstringJson)
        {
            string lstrResult = "";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            string lstrInput = objstringJson;

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    lstrResult = result.IsSuccessStatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }


        public string GetMailOtpold(string ApiName, string objstringJson)
        {
            string lstrResult = "";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;
            //client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    lstrResult = result.IsSuccessStatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        public string GetSMSOtpold(string ApiName, string objstringJson)
        {
            string lstrResult = "";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            //client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return lstrResult;
        }
        public List<BayanDt> getUserBayanList(string fstrRegisterEmailID, int fintPageSize, int fintPageNumber, string fstrFilter)
        {
            List<BayanDt> llstResult = new List<BayanDt>();
            string lstrApiName = "getBayanListphase2";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBayanRow in lobjApiData)
            {
                // if (lintIndex > 2) break;
                // Info object
                BayanDt lobjBayan = new BayanDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBayanRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "bd_bayannumber":
                            lobjBayan.BayanNo = strColumnValue;
                            break;

                        case "bd_vesselname1":
                            if (App.gblLanguage == "En")
                            {
                                lobjBayan.VesselName = strColumnValue;
                            }
                            break;
                        case "bd_vesselname2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBayan.VesselName = strColumnValue;
                            }
                            break;

                        case "bd_shippinglineid":
                            lobjBayan.Shippingline = strColumnValue;
                            break;
                        case "bd_shippinglineimage":
                            lobjBayan.ShippingIcon = strColumnValue;
                            break;
                        case "bd_consigneedesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjBayan.Consignee = strColumnValue;
                            }
                            break;
                        case "bd_consigneedesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBayan.Consignee = strColumnValue;
                            }
                            break;

                        case "bd_shipperdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjBayan.Shipper = strColumnValue;
                            }
                            break;
                        case "bd_shipperdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBayan.Shipper = strColumnValue;
                            }
                            break;
                        case "bd_custombrokeragent":
                            lobjBayan.CustomsAgent = strColumnValue;
                            break;
                        case "bd_portofloading":
                            lobjBayan.POL = strColumnValue;
                            break;
                        case "bd_portofdischarge":
                            lobjBayan.POD = strColumnValue;
                            break;

                        case "bd_bolnodisplay":
                            lobjBayan.Billoflading = strColumnValue;
                            break;

                        case "bd_yardcount":
                            lobjBayan.Inyard = strColumnValue;
                            break;
                        case "bd_departedcount":
                            lobjBayan.Departed = strColumnValue;
                            break;

                        case "bd_bayanstatusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjBayan.Status = strColumnValue;
                            }
                            break;

                        case "bd_bayanstatusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBayan.Status = strColumnValue;
                            }
                            break;
                        case "statuscode":
                            lobjBayan.statuscode = strColumnValue;
                            break;

                        //Export
                        //12-01-2023-Sanduru
                        case "bd_expbayanstatuscode":
                            lobjBayan.ExpbayanstatusCode = strColumnValue;
                            break;

                        case "bd_expbayanstatusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjBayan.Expbayanstatus = strColumnValue;
                            }
                            break;

                        case "bd_expbayanstatusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBayan.Expbayanstatus = strColumnValue;
                            }
                            break;

                        case "bd_bdgatedincount":
                            lobjBayan.Gatedincount = strColumnValue;
                            break;

                        case "bd_bdloadedcount":
                            lobjBayan.Loadedcount = strColumnValue;
                            break;

                        case "bd_blcategory":
                            lobjBayan.Expbayancategory = strColumnValue;
                            break;

                    }

                    lobjBayan.AnywhereAll += strColumnValue;
                }
                lobjBayan.StatusColor = "#5bc0de";// Banned color handled
                if (lobjBayan.statuscode == "103")//Release color handled
                {
                    lobjBayan.StatusColor = "#5cb85c";
                }
                if (lobjBayan.statuscode == "101")//Release color handled
                {
                    lobjBayan.StatusColor = "#777";
                }
                if (lobjBayan.statuscode == "102")//Release color handled
                {
                    lobjBayan.StatusColor = "#5bc0de";
                }
                if (lobjBayan.statuscode == "100")//Release color handled
                {
                    lobjBayan.StatusColor = "#5bc0de";
                }


                if (lobjBayan.statuscode == "104")//Release color handled -12-01-2023
                {
                    lobjBayan.StatusColor = "#5bc0de";
                }
                if (lobjBayan.statuscode == "105")//Release color handled -12-01-2023
                {
                    lobjBayan.StatusColor = "#5bc0de";
                }

                llstResult.Add(lobjBayan);
                //  
            }
            return llstResult;

        }
        public List<clsBayan> getUserBayanListOld(string fstrRegisterEmailID, int fintPageSize, int fintPageNumber, string fstrFilter)
        {
            List<clsBayan> llstResult = new List<clsBayan>();
            string lstrApiName = "getBayanList";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBayanRow in lobjApiData)
            {
                // if (lintIndex > 2) break;
                // Info object
                clsBayan lobjBayan = new clsBayan();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBayanRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "bd_bayannumber":
                            lobjBayan.bd_bayannumber = strColumnValue;
                            break;

                        case "bd_vesselvisitgkey":
                            lobjBayan.bd_vesselvisitgkey = strColumnValue;
                            break;
                        case "bd_vesselvisitid":
                            lobjBayan.bd_vesselvisitid = strColumnValue;
                            break;
                        case "bd_vesselname1":
                            lobjBayan.bd_vesselname1 = strColumnValue;
                            break;
                        case "bd_vesselname2":
                            lobjBayan.bd_vesselname2 = strColumnValue;
                            break;
                        case "bd_transitcountcontainer":
                            lobjBayan.bd_transitcountcontainer = strColumnValue;
                            break;
                        case "bd_shippinglineid":
                            lobjBayan.bd_shippinglineid = strColumnValue;
                            break;
                        case "bd_shippinglineimage":
                            lobjBayan.bd_shippinglineimage = strColumnValue;
                            break;
                        case "bd_consigneegkey":
                            lobjBayan.bd_consigneegkey = strColumnValue;
                            break;
                        case "bd_consigneedesc1":
                            lobjBayan.bd_consigneedesc1 = strColumnValue;
                            break;
                        case "bd_consigneedesc2":
                            lobjBayan.bd_consigneedesc2 = strColumnValue;
                            break;
                        case "bd_shippergkey":
                            lobjBayan.bd_shippergkey = strColumnValue;
                            break;
                        case "bd_shipperdesc1":
                            lobjBayan.bd_shipperdesc1 = strColumnValue;
                            break;
                        case "bd_shipperdesc2":
                            lobjBayan.bd_shipperdesc2 = strColumnValue;
                            break;
                        case "bd_custombrokeragent":
                            lobjBayan.bd_custombrokeragent = strColumnValue;
                            break;
                        case "bd_transporter":
                            lobjBayan.bd_transporter = strColumnValue;
                            break;
                        case "bd_portofloading":
                            lobjBayan.bd_portofloading = strColumnValue;
                            break;
                        case "bd_portofdischarge":
                            lobjBayan.bd_portofdischarge = strColumnValue;
                            break;
                        case "bd_category":
                            lobjBayan.bd_category = strColumnValue;
                            break;
                        case "bd_vsloperatorname":
                            lobjBayan.bd_vsloperatorname = strColumnValue;
                            break;
                        case "bd_linegkey":
                            lobjBayan.bd_linegkey = strColumnValue;
                            break;
                        case "bd_bolcount":
                            lobjBayan.bd_bolcount = strColumnValue;
                            break;
                        case "bd_bolnodisplay":
                            lobjBayan.bd_bolnodisplay = strColumnValue;
                            break;
                        case "bd_containercount":
                            lobjBayan.bd_containercount = strColumnValue;
                            break;
                        case "bd_invesselcount":
                            lobjBayan.bd_invesselcount = strColumnValue;
                            break;
                        case "bd_yardcount":
                            lobjBayan.bd_yardcount = strColumnValue;
                            break;
                        case "bd_departedcount":
                            lobjBayan.bd_departedcount = strColumnValue;
                            break;
                        case "bd_bayanstatuscode":
                            lobjBayan.bd_bayanstatuscode = strColumnValue;
                            break;
                        case "bd_bayanstatusdesc1":
                            lobjBayan.bd_bayanstatusdesc1 = strColumnValue;
                            break;
                        case "bd_bayanstatusdesc2":
                            lobjBayan.bd_bayanstatusdesc2 = strColumnValue;
                            break;
                        case "bd_containerstatus":
                            lobjBayan.bd_containerstatus = strColumnValue;
                            break;
                        case "popupofbillofladings":
                            lobjBayan.popupofbillofladings = strColumnValue;
                            break;



                    }


                    lobjBayan.AnywhereAll += strColumnValue;
                }

                llstResult.Add(lobjBayan);
                //  
            }
            return llstResult;

        }

        public List<clsListofbayandetails> getBayanTrackingDetails(string fstrRegisterEmailID)
        {

            List<clsListofbayandetails> llstResult = new List<clsListofbayandetails>();
            string lstrApiName = "getBayanTrackingDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBayanTrakRow in lobjApiData)
            {
                // Info object
                clsListofbayandetails lobjBayanTraking = new clsListofbayandetails();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBayanTrakRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bd_bayannumber":
                            lobjBayanTraking.bd_bayannumber = strColumnValue;
                            break;
                        case "bd_vesselvisitgkey":
                            lobjBayanTraking.bd_vesselvisitgkey = strColumnValue;
                            break;
                        case "bd_vesselvisitid":
                            lobjBayanTraking.bd_vesselvisitid = strColumnValue;
                            break;
                        case "bd_vesselname1":
                            lobjBayanTraking.bd_vesselname1 = strColumnValue;
                            break;
                        case "bd_vesselname2":
                            lobjBayanTraking.bd_vesselname2 = strColumnValue;
                            break;
                        case "bd_transitcountcontainer":
                            lobjBayanTraking.bd_transitcountcontainer = strColumnValue;
                            break;
                        case "bd_shippinglineid":
                            lobjBayanTraking.bd_shippinglineid = strColumnValue;
                            break;
                        case "bd_shippinglineimage":
                            lobjBayanTraking.bd_shippinglineimage = strColumnValue;
                            break;
                        case "bd_consigneegkey":
                            lobjBayanTraking.bd_consigneegkey = strColumnValue;
                            break;
                        case "bd_consigneedesc1":
                            lobjBayanTraking.bd_consigneedesc1 = strColumnValue;
                            break;
                        case "bd_consigneedesc2":
                            lobjBayanTraking.bd_consigneedesc2 = strColumnValue;
                            break;
                        case "bd_shippergkey":
                            lobjBayanTraking.bd_shippergkey = strColumnValue;
                            break;
                        case "bd_shipperdesc1":
                            lobjBayanTraking.bd_shipperdesc1 = strColumnValue;
                            break;
                        case "bd_shipperdesc2":
                            lobjBayanTraking.bd_shipperdesc2 = strColumnValue;
                            break;
                        case "bd_custombrokeragent":
                            lobjBayanTraking.bd_custombrokeragent = strColumnValue;
                            break;
                        case "bd_portofloading":
                            lobjBayanTraking.bd_portofloading = strColumnValue;
                            break;
                        case "bd_portofdischarge":
                            lobjBayanTraking.bd_portofdischarge = strColumnValue;
                            break;
                        case "bd_category":
                            lobjBayanTraking.bd_category = strColumnValue;
                            break;
                        case "bd_vsloperatorname":
                            lobjBayanTraking.bd_vsloperatorname = strColumnValue;
                            break;
                        case "containerstatus":
                            lobjBayanTraking.containerstatus = strColumnValue;
                            break;
                        case "blcount":
                            lobjBayanTraking.blcount = strColumnValue;
                            break;
                        case "bd_emailid":
                            lobjBayanTraking.bd_emailid = strColumnValue;
                            break;
                        case "bd_linkcode":
                            lobjBayanTraking.bd_linkcode = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjBayanTraking);

            }
            return llstResult;

        }

        public List<clsconsigneefilter> getBayanFilterConsigneeList(string fstrFilter)
        {
            List<clsconsigneefilter> llstResult = new List<clsconsigneefilter>();
            string lstrApiName = "getConsigneeFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsconsigneefilter lobjFilter = new clsconsigneefilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;

                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }



        public List<EnumCombo> RequestFilterData(string fstrAPIName, string fstrType)
        {
            List<EnumCombo> llstResult = new List<EnumCombo>();
            string lstrApiName = fstrAPIName;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrType", fstrType);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                EnumCombo lobjFilter = new EnumCombo();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cms_info1":
                            lobjFilter.Key = strColumnValue;
                            break;

                        case "cms_code":
                            lobjFilter.Value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public List<EnumCombo> RequestSubFilterData(string fstrAPIName, string fstrcategorycode, string fstrCaseType)
        {
            List<EnumCombo> llstResult = new List<EnumCombo>();
            string lstrApiName = fstrAPIName;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrType", fstrCaseType);
            lobjInParams.Add("fstrcategorycode", fstrcategorycode);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                EnumCombo lobjFilter = new EnumCombo();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cms_info1":
                            lobjFilter.Key = strColumnValue;
                            break;

                        case "cms_code":
                            lobjFilter.Value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public List<clsVesselfilter> getBayanFilterVesselList(string fstrFilter)
        {
            List<clsVesselfilter> llstResult = new List<clsVesselfilter>();
            string lstrApiName = "getVesselFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsVesselfilter lobjFilter = new clsVesselfilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;

                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsCarrierfilter> getBayanFilterCarrierList(string fstrFilter)
        {
            List<clsCarrierfilter> llstResult = new List<clsCarrierfilter>();
            string lstrApiName = "getCarrierFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsCarrierfilter lobjFilter = new clsCarrierfilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;

                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsconsigneefilter> getBOLFilterConsigneeList(string fstrRegisterEmailID, string fstrFilter)
        {
            List<clsconsigneefilter> llstResult = new List<clsconsigneefilter>();
            string lstrApiName = "getConsigneeFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            //  lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsconsigneefilter lobjFilter = new clsconsigneefilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;

                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsVesselfilter> getBOLFilterVesselList(string fstrRegisterEmailID, string fstrFilter)
        {
            List<clsVesselfilter> llstResult = new List<clsVesselfilter>();
            string lstrApiName = "getVesselFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            // lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsVesselfilter lobjFilter = new clsVesselfilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;

                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsCarrierfilter> getBOLFilterCarrierList(string fstrRegisterEmailID, string fstrFilter)
        {
            List<clsCarrierfilter> llstResult = new List<clsCarrierfilter>();
            string lstrApiName = "getCarrierFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            //  lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsCarrierfilter lobjFilter = new clsCarrierfilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;

                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsContainerStatusFilter> getContainerFilterStatusList(string fstrRegisterEmailID, string fstrFilter)
        {
            //https://localhost:44348/api/DataSource/getContainerStatusFilter?fstrCD_BAYANNUMBER:113521,fstrCD_BLNUMBER:LITSOKJED2200067;
            //https://localhost:44348/api/DataSource/getContainerStatusFilter?fstrFilter=fstrcontainerNo:10021837,10022604;&fstrAPIToken
            List<clsContainerStatusFilter> llstResult = new List<clsContainerStatusFilter>();
            string lstrApiName = "getContainerStatusFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();

            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsContainerStatusFilter lobjFilter = new clsContainerStatusFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            if (App.gblLanguage != "Ar")
                            {
                                lobjFilter.text = strColumnValue;
                            }
                            break;

                        case "texta":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjFilter.text = strColumnValue;
                            }
                            break;

                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsContainerDamageGoodFt> getContainerFtDamageList(string fstrRegisterEmailID, string fstrFilter, string fstrBLNumber)
        {
            List<clsContainerDamageGoodFt> llstResult = new List<clsContainerDamageGoodFt>();
            string lstrApiName = "getContainerDamageGoodFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            //lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrBLNumber", fstrBLNumber);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //  if (lintIndex > 10) break;
                // Info object
                clsContainerDamageGoodFt lobjFilter = new clsContainerDamageGoodFt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_blnumber":
                            lobjFilter.cd_blnumber = strColumnValue;
                            break;

                        case "cd_commodity":
                            lobjFilter.cd_commodity = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public List<clsDwellDaysSizeFilter> getDwellDaysFilterSizeList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsDwellDaysSizeFilter> llstResult = new List<clsDwellDaysSizeFilter>();
            string lstrApiName = "DwellDaysSizeFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {

                // Info object
                clsDwellDaysSizeFilter lobjFilter = new clsDwellDaysSizeFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsDwellDaysCarrierFilter> getDwellDaysFilterCarrierList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsDwellDaysCarrierFilter> llstResult = new List<clsDwellDaysCarrierFilter>();
            string lstrApiName = "DwellDaysCarrierFilters";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsDwellDaysCarrierFilter lobjFilter = new clsDwellDaysCarrierFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsReadytoDeliveryCarrierFilter> getReadytoDeliveryFilterCarrierList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsReadytoDeliveryCarrierFilter> llstResult = new List<clsReadytoDeliveryCarrierFilter>();
            string lstrApiName = "ReadyToDeliveryCarrierFilters";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsReadytoDeliveryCarrierFilter lobjFilter = new clsReadytoDeliveryCarrierFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsReadytoDeliveryCategoryFilter> getReadytoDeliveryFilterCategoryList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsReadytoDeliveryCategoryFilter> llstResult = new List<clsReadytoDeliveryCategoryFilter>();
            string lstrApiName = "ReadyToDeliveryCategoryFilters";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsReadytoDeliveryCategoryFilter lobjFilter = new clsReadytoDeliveryCategoryFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsReadytoDeliverySizeFilter> getReadytoDeliveryFilterSizeList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsReadytoDeliverySizeFilter> llstResult = new List<clsReadytoDeliverySizeFilter>();
            string lstrApiName = "ReadyToDeliverySizeFilters";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsReadytoDeliverySizeFilter lobjFilter = new clsReadytoDeliverySizeFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsReadytoDeliveryFreightFilter> getReadytoDeliveryFilterFreightList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsReadytoDeliveryFreightFilter> llstResult = new List<clsReadytoDeliveryFreightFilter>();
            string lstrApiName = "ReadyToDeliveryFreightkindFilters";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsReadytoDeliveryFreightFilter lobjFilter = new clsReadytoDeliveryFreightFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsReadytoDeliveryPOLFilter> getReadytoDeliveryFilterPOLList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsReadytoDeliveryPOLFilter> llstResult = new List<clsReadytoDeliveryPOLFilter>();
            string lstrApiName = "ReadyToDeliveryPolFilters";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsReadytoDeliveryPOLFilter lobjFilter = new clsReadytoDeliveryPOLFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsReadytoDeliveryPODFilter> getReadytoDeliveryFilterPODList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsReadytoDeliveryPODFilter> llstResult = new List<clsReadytoDeliveryPODFilter>();
            string lstrApiName = "ReadyToDeliveryPodFilters";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsReadytoDeliveryPODFilter lobjFilter = new clsReadytoDeliveryPODFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public List<clsListofbayandetails> getBOLHeaderDetails(string fstrRegisterEmailID, string fstrFilter)
        {
            if (fstrFilter == null) fstrFilter = "";
            List<clsListofbayandetails> llstResult = new List<clsListofbayandetails>();
            //string lstrApiName = "getBOLHeaderDetails";
            string lstrApiName = "getBOLHeader";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            //lobjInParams.Add("fstrAPIToken", "");
            if (fstrFilter != "")
            {
                lobjInParams.Add("fstrFilter", fstrFilter);
            }
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBolRow in lobjApiData)
            {
                // Info object
                clsListofbayandetails lobjBOLHeader = new clsListofbayandetails();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBolRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bd_bayannumber":
                            lobjBOLHeader.bd_bayannumber = strColumnValue;
                            break;
                        case "bd_vesselvisitgkey":
                            lobjBOLHeader.bd_vesselvisitgkey = strColumnValue;
                            break;
                        case "bd_vesselvisitid":
                            lobjBOLHeader.bd_vesselvisitid = strColumnValue;
                            break;
                        case "bd_vesselname1":
                            lobjBOLHeader.bd_vesselname1 = strColumnValue;
                            break;
                        case "bd_vesselname2":
                            lobjBOLHeader.bd_vesselname2 = strColumnValue;
                            break;
                        case "bd_transitcountcontainer":
                            lobjBOLHeader.bd_transitcountcontainer = strColumnValue;
                            break;
                        case "bd_shippinglineid":
                            lobjBOLHeader.bd_shippinglineid = strColumnValue;
                            break;
                        case "bd_shippinglineimage":
                            lobjBOLHeader.bd_shippinglineimage = strColumnValue;
                            break;
                        case "bd_consigneegkey":
                            lobjBOLHeader.bd_consigneegkey = strColumnValue;
                            break;
                        case "bd_consigneedesc1":
                            lobjBOLHeader.bd_consigneedesc1 = strColumnValue;
                            break;
                        case "bd_consigneedesc2":
                            lobjBOLHeader.bd_consigneedesc2 = strColumnValue;
                            break;
                        case "bd_shippergkey":
                            lobjBOLHeader.bd_shippergkey = strColumnValue;
                            break;
                        case "bd_shipperdesc1":
                            lobjBOLHeader.bd_shipperdesc1 = strColumnValue;
                            break;
                        case "bd_shipperdesc2":
                            lobjBOLHeader.bd_shipperdesc2 = strColumnValue;
                            break;
                        case "bd_custombrokeragent":
                            lobjBOLHeader.bd_custombrokeragent = strColumnValue;
                            break;
                        case "bd_portofloading":
                            lobjBOLHeader.bd_portofloading = strColumnValue;
                            break;
                        case "bd_portofdischarge":
                            lobjBOLHeader.bd_portofdischarge = strColumnValue;
                            break;
                        case "bd_category":
                            lobjBOLHeader.bd_category = strColumnValue;
                            break;
                        case "bd_vsloperatorname":
                            lobjBOLHeader.bd_vsloperatorname = strColumnValue;
                            break;
                        case "containerstatus":
                            lobjBOLHeader.containerstatus = strColumnValue;
                            break;
                        case "blcount":
                            lobjBOLHeader.blcount = strColumnValue;
                            break;
                            //case "bd_emailid":
                            //    lobjBOLHeader.bd_emailid = strColumnValue;
                            //    break;
                            //case "bd_linkcode":
                            //    lobjBOLHeader.bd_linkcode = strColumnValue;
                            //    break;

                    }

                }
                llstResult.Add(lobjBOLHeader);

            }
            return llstResult;

        }


        public List<BOLDt> getBillofLading(string fstrRegisterEmailID, int fintPageSize, int fintPageNumber, string fstrFilter)
        {

            if (fstrRegisterEmailID == null) fstrRegisterEmailID = "";
            if (fstrFilter == null) fstrFilter = "";
            List<BOLDt> llstResult = new List<BOLDt>();
            string lstrApiName = "getBillofLadingPhase2";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            //Emailid
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            // lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjBLRow in lobjApiData)
            {
                // Info object
                BOLDt lobjBLList = new BOLDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBLRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bl_bayannumber":
                            lobjBLList.BayanNo = strColumnValue;
                            break;

                        case "bl_blnumber":
                            lobjBLList.Billoflading = strColumnValue;
                            break;

                        case "bl_bolstatuscode":
                            lobjBLList.BOLStatuscode = strColumnValue;
                            break;
                        case "bl_shippingline":
                            lobjBLList.Carrier = strColumnValue;
                            break;

                        case "bl_consigneedesc1":
                            lobjBLList.ConsigneeName = strColumnValue;
                            break;

                        case "bl_vesselname1":
                            lobjBLList.Vesselname1 = strColumnValue;
                            break;



                        case "bl_loaddischargecount":
                            lobjBLList.Loadingdischargecount = strColumnValue;
                            break;
                        case "bl_inspectioncount":
                            lobjBLList.InspectionCount = strColumnValue;
                            break;
                        case "bl_inspectionimage":
                            lobjBLList.Inspectionicon = strColumnValue;
                            break;
                        case "bl_holdcount":
                            lobjBLList.Holdcount = strColumnValue;
                            break;
                        case "bl_holdimage":
                            lobjBLList.Holdicon = strColumnValue;
                            break;
                        case "bl_statuscode":
                            lobjBLList.StatuCode = strColumnValue;
                            break;
                        case "bl_statusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjBLList.Status = strColumnValue;
                            }
                            break;
                        case "bl_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBLList.Status = strColumnValue;
                            }
                            break;
                        case "bl_proformainvoicenumber":
                            lobjBLList.InvoiceNumber = strColumnValue;
                            break;
                        case "bl_appointments":
                            lobjBLList.Appointmentinfo = strColumnValue;
                            break;
                        case "bl_departedcount":
                            lobjBLList.Departedinfo = strColumnValue;
                            break;

                        case "cd_appbookable":
                            lobjBLList.BOLAction = strColumnValue;
                            break;
                        case "bl_ihproformainvoicenumber":
                            lobjBLList.Proformainvoicenumber = strColumnValue;
                            break;
                        case "bl_ihinvoicenumber":
                            lobjBLList.Invoicestatusinfo = strColumnValue;
                            break;
                        case "bl_commodity":
                            lobjBLList.Commodity = strColumnValue;
                            break;



                        case "bl_invoiceconsignee":
                            lobjBLList.Invoiceconsignee = strColumnValue;
                            break;

                        case "bl_transporter":
                            lobjBLList.Transporter = strColumnValue;
                            break;
                        case "bl_shippinglineid":
                            lobjBLList.Shippinglineid = strColumnValue;
                            break;
                        case "bl_custombrokeragent":
                            lobjBLList.Custombrokeragent = strColumnValue;
                            break;
                        case "bl_Statuscolour":
                            lobjBLList.StatusColor = strColumnValue;
                            break;

                        case "yardtotal":
                            lobjBLList.Inyard = strColumnValue;
                            break;
                        case "deptotal":
                            lobjBLList.Departed = strColumnValue;
                            break;
                        case "bl_ihstatus":
                            lobjBLList.ihstatus = strColumnValue;
                            break;

                        //12-01-2023-Sanduru
                        case "bl_gatedincount":
                            lobjBLList.GatedInCount = strColumnValue;
                            break;
                        case "bl_loadedcount":
                            lobjBLList.LoadCount = strColumnValue;
                            break;
                        case "bl_gatedinimage":
                            lobjBLList.GatedImage = strColumnValue;
                            break;
                        case "bl_loadedimage":
                            lobjBLList.LoadedImage = strColumnValue;
                            break;
                        case "bl_expstatuscode":
                            lobjBLList.ExpStatusCode = strColumnValue;
                            break;
                        case "bl_expstatusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjBLList.ExpStatus = strColumnValue;
                            }
                            break;
                        case "bl_expstatusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBLList.ExpStatus = strColumnValue;
                            }
                            break;
                        case "bl_ihfasahstatus":
                            lobjBLList.ihfasahstatus = strColumnValue;
                            break;
                        case "bl_ihmop":
                            lobjBLList.ihmop = strColumnValue;
                            break;
                        case "bl_eirequest":
                            lobjBLList.RequestFlag = strColumnValue;
                            break;
                        case "bl_gatedoutcontainerflag":
                            lobjBLList.GateOutContainerFlag = strColumnValue;
                            break;
                    }



                    lobjBLList.AnywhereAll += strColumnValue;
                }

                if (lobjBLList.StatuCode == "103")
                {

                    lobjBLList.StatusColor = "#5cb85c";
                }


                if (lobjBLList.StatuCode == "101")
                {
                    lobjBLList.StatusColor = "#777";
                }

                if (lobjBLList.StatuCode == "102")
                {
                    lobjBLList.StatusColor = "#5bc0de";
                }

                if (lobjBLList.StatuCode == "100")
                {
                    lobjBLList.StatusColor = "#777";
                }



                llstResult.Add(lobjBLList);

            }
            return llstResult;

        }


        public List<INSPECTIONPHOTOS> getInspection(string fstrApiName, string strHDNBOLNO, string strHDNContainerno)
        {
            List<INSPECTIONPHOTOS> lstImageResult = new List<INSPECTIONPHOTOS>();
            ObservableCollection<Object> objData = new ObservableCollection<object>();
            try
            {
                // bool lresult = false;
                string lstrInput = "";

                //  string lstrResult = objWebApi.putWebApi("UpdateAccountSettings", gblRegisteration.UpdateAccountSetting(fstrMonday, fstrTuesday, fstrWednesday, fstrThursday, fstrFriday, fstrSatday, fstrSunday), gblRegisteration.strLoginUser);
                lstrInput = "{\"ContainerNumber\" : \"" + strHDNContainerno + "\",\"UserName\" : \"" + "abcd1234567" + "\",\"Password\" : \"" + "abcd1234567" + "\"}";//SHAREPOINTIMAGE


                if (strHDNContainerno == "N")
                {
                    lstrInput = "{\"ContainerNumber\" : \"" + strHDNBOLNO + "\",\"UserName\" : \"" + "abcd1234567" + "\",\"Password\" : \"" + "abcd1234567" + "\"}";//SHAREPOINTIMAGE
                }


                objData = objWebApi.getPostWebApi(fstrApiName, lstrInput, strHDNBOLNO);





                // int lintSLNo = 1;
                foreach (IEnumerable<Object> lobjTicketsRow in objData)
                {
                    // Info object
                    INSPECTIONPHOTOS lobjBOLRequest = new INSPECTIONPHOTOS();

                    foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                    {
                        //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                        //bolNo containerNumber imgURL
                        string strColumnName = Column.Name;
                        string strColumnValue = Column.Value.ToString();

                        switch (strColumnName)
                        {
                            case "imageURL":
                                lobjBOLRequest.ImageURL = strColumnValue;
                                break;
                            case "containerNumber":
                                lobjBOLRequest.ContainerNumber = strColumnValue;
                                break;
                            case "bolNo":
                                lobjBOLRequest.BOLNo = strColumnValue;
                                break;

                        }
                    }

                    lstImageResult.Add(lobjBOLRequest);


                }


            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.ToString();

            }
            return lstImageResult;


        }


        public int getDraftNoStatus(string fstrDraftNo)
        {
            //http://172.19.35.68:89/api/DataSource/getDraftNoStatus?fstrDraftNo=1504487

            int lintResult = 0;
            string lstrApiName = "getDraftNoStatus";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();

            lobjInParams.Add("fstrDraftNo", fstrDraftNo);


            lintResult = getWebApiDraftNoStatus(lstrApiName, lobjInParams);


            return lintResult;

        }


        public List<clsListofbillofladings> getContainerDetailsHeader(string fstrRegisterEmailID, string fstrFilter)
        {

            List<clsListofbillofladings> llstResult = new List<clsListofbillofladings>();
            string lstrApiName = "getContainerDetailsHeader";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            if (fstrFilter != "")
            {
                lobjInParams.Add("fstrFilter", fstrFilter);
            }
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                clsListofbillofladings lobjContainerHeader = new clsListofbillofladings();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bl_bayannumber":
                            lobjContainerHeader.bl_bayannumber = strColumnValue;
                            break;
                        case "bl_gkey":
                            lobjContainerHeader.bl_gkey = strColumnValue;
                            break;
                        case "bl_blnumber":
                            lobjContainerHeader.bl_blnumber = strColumnValue;
                            break;
                        case "bl_visitgkey":
                            lobjContainerHeader.bl_visitgkey = strColumnValue;
                            break;
                        case "bl_bolstatuscode":
                            lobjContainerHeader.bl_bolstatuscode = strColumnValue;
                            break;
                        case "bl_shippingline":
                            lobjContainerHeader.bl_shippingline = strColumnValue;
                            break;
                        case "bl_shippinglineimage":
                            lobjContainerHeader.bl_shippinglineimage = strColumnValue;
                            break;
                        case "bl_portofload":
                            lobjContainerHeader.bl_portofload = strColumnValue;
                            break;
                        case "bl_portofdischsrge":
                            lobjContainerHeader.bl_portofdischsrge = strColumnValue;
                            break;
                        case "bl_consigneedesc1":
                            lobjContainerHeader.bl_consigneedesc1 = strColumnValue;
                            break;
                        case "bl_shipperdesc1":
                            lobjContainerHeader.bl_shipperdesc1 = strColumnValue;
                            break;
                        case "bl_vesselvisitid":
                            lobjContainerHeader.bl_vesselvisitid = strColumnValue;
                            break;
                        case "bl_blcategory":
                            lobjContainerHeader.bl_blcategory = strColumnValue;
                            break;
                        case "bl_transitcountcontainer":
                            lobjContainerHeader.bl_transitcountcontainer = strColumnValue;
                            break;
                        case "bl_commodity":
                            lobjContainerHeader.bl_commodity = strColumnValue;
                            break;
                        case "bl_consigneegkey":
                            lobjContainerHeader.bl_consigneegkey = strColumnValue;
                            break;
                        case "bl_shippergkey":
                            lobjContainerHeader.bl_shippergkey = strColumnValue;
                            break;
                        case "bl_loaddischargecount":
                            lobjContainerHeader.bl_loaddischargecount = strColumnValue;
                            break;
                        case "bl_inspectioncount":
                            lobjContainerHeader.bl_inspectioncount = strColumnValue;
                            break;
                        case "bl_inspectionimage":
                            lobjContainerHeader.bl_inspectionimage = strColumnValue;
                            break;
                        case "bl_holdcount":
                            lobjContainerHeader.bl_holdcount = strColumnValue;
                            break;
                        case "bl_holdimage":
                            lobjContainerHeader.bl_holdimage = strColumnValue;
                            break;
                        case "bl_statuscode":
                            lobjContainerHeader.bl_statuscode = strColumnValue;
                            break;
                        case "bl_statusdesc1":
                            lobjContainerHeader.bl_statusdesc1 = strColumnValue;
                            break;
                        case "bl_statusdesc2":
                            lobjContainerHeader.bl_statusdesc2 = strColumnValue;
                            break;
                        case "bl_proformainvoicenumber":
                            lobjContainerHeader.bl_proformainvoicenumber = strColumnValue;
                            break;
                        case "bl_appointments":
                            lobjContainerHeader.bl_appointments = strColumnValue;
                            break;
                        case "bl_departedcount":
                            lobjContainerHeader.bl_departedcount = strColumnValue;
                            break;
                        case "bl_departedimage":
                            lobjContainerHeader.bl_departedimage = strColumnValue;
                            break;
                        case "ntotal":
                            lobjContainerHeader.ntotal = strColumnValue;
                            break;
                        case "yardtotal":
                            lobjContainerHeader.yardtotal = strColumnValue;
                            break;
                        case "deptotal":
                            lobjContainerHeader.deptotal = strColumnValue;
                            break;
                        case "containerstatus":
                            lobjContainerHeader.containerstatus = strColumnValue;
                            break;
                        case "popupbolcommodity":
                            lobjContainerHeader.popupbolcommodity = strColumnValue;
                            break;
                        case "cd_invoiceable":
                            lobjContainerHeader.cd_invoiceable = strColumnValue;
                            break;
                        case "cd_payable":
                            lobjContainerHeader.cd_payable = strColumnValue;
                            break;
                        case "cd_appbookable":
                            lobjContainerHeader.cd_appbookable = strColumnValue;
                            break;
                        case "bl_ihproformainvoicenumber":
                            lobjContainerHeader.bl_ihproformainvoicenumber = strColumnValue;
                            break;
                        case "bl_ihinvoicenumber":
                            lobjContainerHeader.bl_ihinvoicenumber = strColumnValue;
                            break;
                        case "bl_ihstatus":
                            lobjContainerHeader.bl_ihstatus = strColumnValue;
                            break;
                        case "bl_damageflag":
                            lobjContainerHeader.bl_damageflag = strColumnValue;
                            break;
                            //case "bl_emailid":
                            //    lobjContainerHeader.bl_emailid = strColumnValue;
                            //    break;
                            //case "bl_linkcode":
                            //    lobjContainerHeader.bl_linkcode = strColumnValue;
                            //    break;

                    }
                }
                llstResult.Add(lobjContainerHeader);

            }
            return llstResult;

        }

        public List<clsCommoditypopup> getBOLPopupDetails(string fstrRegisterEmailID, string fstrFilter)
        {
            List<clsCommoditypopup> llstResult = new List<clsCommoditypopup>();
            string lstrApiName = "getBOLPopupDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            // lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjCommodityRow in lobjApiData)
            {
                // Info object
                clsCommoditypopup lobjCommodity = new clsCommoditypopup();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjCommodityRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_commodity":
                            lobjCommodity.cd_commodity = strColumnValue;
                            break;
                        case "code":
                            lobjCommodity.code = strColumnValue;
                            break;
                        case "description":
                            lobjCommodity.description = strColumnValue;
                            break;
                        case "cd_blgkey":
                            lobjCommodity.cd_blgkey = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjCommodity.cd_blnumber = strColumnValue;
                            break;
                            //case "cd_emailid":
                            //    lobjCommodity.cd_emailid = strColumnValue;
                            //    break;
                            //case "cd_linkcode":
                            //    lobjCommodity.cd_linkcode = strColumnValue;
                            //    break;

                    }

                }
                llstResult.Add(lobjCommodity);

            }
            return llstResult;

        }

        public List<clsBayanpopup> getBayanPopupDetails(string fstrRegisterEmailID, string fstrFilter)
        {
            List<clsBayanpopup> llstResult = new List<clsBayanpopup>();
            string lstrApiName = "getBayanPopupDetail";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            // lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);


            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBayanPopupRow in lobjApiData)
            {
                // Info object
                clsBayanpopup lobjPopupRow = new clsBayanpopup();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBayanPopupRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bld_count":
                            lobjPopupRow.bld_count = Convert.ToInt32(strColumnValue);
                            break;
                        case "bld_blnumber":
                            lobjPopupRow.bld_blnumber = strColumnValue;
                            break;
                            //case "cd_bayannumber":
                            //    lobjPopupRow.cd_bayannumber = strColumnValue;
                            //    break;
                    }

                }
                llstResult.Add(lobjPopupRow);

            }
            return llstResult;

        }

        public List<clsHoldgoodPopup> getHolgoodPopupDetails(string fstrRegisterEmailID, string fstrApiName, string fstrFilter)
        {
            //https://webgateway.rsgt.com:9090/eportal_api/getHoldPopupDetails?fstrFilter=HL_UNITGKEY:6641142868;

            List<clsHoldgoodPopup> llstResult = new List<clsHoldgoodPopup>();
            string lstrApiName = fstrApiName;// "getHoldPopupDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            // lobjInParams.Add("fstrAPIToken", "");
            // lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBayanPopupRow in lobjApiData)
            {
                // Info object
                clsHoldgoodPopup lobjPopupRow = new clsHoldgoodPopup();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBayanPopupRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    //"hl_unitgkey": "5965538076",
                    //"ht_desc1": "FINANCE HOLD",
                    //"ht_desc2": "FINANCE HOLD (A)",
                    //"ca_name1": "Waiting for RSGT payment",
                    //"ca_name2": "في انتظار دفع RSGT",
                    //"hl_applieddate": "27-10-2021",
                    //"hl_appliedtime": "11:41"

                    switch (strColumnName)
                    {
                        case "hl_unitgkey":
                            lobjPopupRow.hl_unitgkey = strColumnName;
                            break;
                        case "ht_desc1":
                            lobjPopupRow.ht_desc1 = strColumnValue;
                            break;
                        case "ht_desc2":
                            lobjPopupRow.ht_desc2 = strColumnName;
                            break;
                        case "ca_name1":
                            lobjPopupRow.ca_name1 = strColumnValue;
                            break;
                        case "ca_name2":
                            lobjPopupRow.ca_name2 = strColumnName;
                            break;
                        case "hl_applieddate":
                            lobjPopupRow.hl_applieddate = strColumnValue;
                            break;
                        case "hl_appliedtime":
                            lobjPopupRow.hl_appliedtime = strColumnValue;
                            break;
                        case "ht_category":
                            lobjPopupRow.ht_category = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjPopupRow);

            }
            return llstResult;

        }
        public List<ContainerDt> getContainerDetails(string fstrRegisterEmailID, int fintPageNumber, int fintPageSize, string fstrFilter, string fstrHoldPopup)
        {

            List<ContainerDt> llstResult = new List<ContainerDt>();
            string lstrApiName = "getContainerListviewPhas2";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
            if (fstrFilter != "")
            {
                lobjInParams.Add("fstrFilter", fstrFilter);
            }
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjContainerDetailRow in lobjApiData)
            {
                // Info object
                ContainerDt lobjContainer = new ContainerDt();
                string strColumnName = "";
                string strHoldFlag = "";
                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjContainerDetailRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();


                    switch (strColumnName)
                    {
                        case "cd_unitgkey":
                            lobjContainer.Container_unitgkey = strColumnValue;
                            break;

                        case "cd_containernumber":
                            lobjContainer.Containerno = strColumnValue;
                            break;

                        case "cd_bayannumber":
                            lobjContainer.BayanNo = strColumnValue;
                            break;

                        case "cd_blnumber":
                            lobjContainer.Billoflading = strColumnValue;
                            break;

                        case "cd_freightkind":
                            lobjContainer.Freightinfo = strColumnValue;
                            break;
                        case "cd_size":
                            lobjContainer.Containerno_Size = strColumnValue;
                            break;

                        case "cd_dgdetails":
                            lobjContainer.dgdetails = strColumnValue;
                            break;

                        case "cd_dischargeimage":
                            lobjContainer.Loadingicon = strColumnValue;
                            break;

                        case "cd_fmtinspectioncomplete":
                            lobjContainer.Inspectioninfo = strColumnValue;
                            break;
                        case "cd_dryreefer":
                            lobjContainer.Temperatureinfo = strColumnValue;
                            break;

                        case "cd_apptstatus":
                            lobjContainer.Appointmentinfo = strColumnValue;
                            break;

                        case "cd_platenbr":
                            lobjContainer.LicenseNo = strColumnValue;
                            break;

                        case "cd_statuscode":
                            lobjContainer.statusCode = strColumnValue;
                            break;
                        case "cd_statusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjContainer.Status = strColumnValue;
                            }
                            break;
                        case "cd_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjContainer.Status = strColumnValue;
                            }
                            break;
                        case "cd_discrecivaltime_month":
                            lobjContainer.Loadinginfo = strColumnValue;
                            break;
                        case "cd_prepickupissuedtime_month":
                            lobjContainer.Appointmentdate = strColumnValue;
                            break;
                        case "cd_gatedouttime_month":
                            lobjContainer.Gateinfo = strColumnValue;
                            break;
                        case "popupcontainer":
                            lobjContainer.containerpopup = strColumnValue;
                            break;
                        case "damagedetailspopup":
                            lobjContainer.damagepopup = strColumnValue;
                            break;

                        case "cd_damageflag":
                            lobjContainer.Damageflag = strColumnValue;
                            break;


                        //case "cd_emailid":
                        //    lobjContainer.cd_emailid = strColumnValue;
                        //    break;
                        //case "cd_linkcode":
                        //    lobjContainer.cd_linkcode = strColumnValue;
                        //    break;
                        case "cd_freightkindapiimage":
                            lobjContainer.Freighticon = strColumnValue;
                            break;
                        case "cd_gaugeunitsizeapiimage":
                            lobjContainer.Unitsizeicon = strColumnValue;
                            break;
                        case "cd_dryreeferapiimage":
                            lobjContainer.Temperaturecon = strColumnValue;
                            break;

                        case "cd_movetoinspectiontimeapiimage":
                            lobjContainer.Inspectionicon = strColumnValue;
                            break;
                        case "cd_fmprepickissuedtimeapiimage":
                            lobjContainer.Appointmenticon = strColumnValue;
                            break;
                        case "cd_gatedouttimeapiimage":
                            lobjContainer.Gateicon = strColumnValue;
                            break;

                        case "cd_emptydepot_eng":
                            if (App.gblLanguage == "En")
                            {
                                lobjContainer.emptydepot = strColumnValue;
                            }
                            break;
                        case "cd_emptydepot_ara":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjContainer.emptydepot = strColumnValue;
                            }
                            break;
                        //case "cd_size":
                        //    lobjContainer.Unitsizeinfo = strColumnValue;
                        //    break;
                        case "cd_holdpermission":
                            lobjContainer.HoldPopupFlag = strColumnValue;
                            strHoldFlag = strColumnValue;
                            break;


                        //12-01-2023-Sanduru
                        case "cd_expunitintime":
                            lobjContainer.GatedInCount = strColumnValue;
                            break;
                        case "cd_gatedinimage":
                            lobjContainer.GatedInImage = strColumnValue;
                            break;
                        case "cd_expunitloadtime":
                            lobjContainer.LoadedCount = strColumnValue;
                            break;
                        case "cd_loadedimage":
                            lobjContainer.LoadedImage = strColumnValue;
                            break;
                        case "cd_expbookforinsptime":
                            lobjContainer.InspecCount = strColumnValue;
                            break;
                        case "cd_expinspectionimage":
                            lobjContainer.InspecImage = strColumnValue;
                            break;

                        case "cd_eirequest":
                            lobjContainer.fstrRequest = strColumnValue;
                            break;



                    }
                    lobjContainer.AnyWhere += strColumnValue;
                }
                lobjContainer.StatusColor = "#5bc0de";
                //Compeleted 103
                if (lobjContainer.statusCode == "103")
                {
                    lobjContainer.StatusColor = "#5bc0de";
                }
                //In Pending 101
                if (lobjContainer.statusCode == "101")
                {
                    lobjContainer.StatusColor = "#777";
                }
                //In Progress 102
                if (lobjContainer.statusCode == "102")
                {
                    lobjContainer.StatusColor = "#5bc0de";
                }

                //On Vessel   100
                if (lobjContainer.statusCode == "100")
                {
                    lobjContainer.StatusColor = "#5bc0de";
                }

                if ((fstrHoldPopup == "H") && (strHoldFlag == "HOLD"))
                {
                    llstResult.Add(lobjContainer);
                }

                if (fstrHoldPopup != "H")
                {
                    llstResult.Add(lobjContainer);
                }




            }
            return llstResult;

        }

        public List<Gatephotodetaildt> getGatedoutImage(string fstrFilter, int lfintPageNo, int lfintPageSize)
        {
            // string fstrUserCode,string fstrTitle, string fstrFilter, string fstrPageNumber, string fstrPageSize
            List<Gatephotodetaildt> llstResult = new List<Gatephotodetaildt>();

            // https://webgateway.rsgt.com:9090/eportal_api/getGatedoutImage?fstrFilter=fstrBOLNo:23156487PO;fstrContainerNo::&fstrPageNumber=1&fstrPageSize=20
            //License+BOL+Container
            //2_JEDIMPSP4144E_MRSU3922594
            int lintRowNo = 1;

            string lstrApiName = "getGatedoutImage";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", lfintPageNo.ToString());
            lobjInParams.Add("fstrPageSize", lfintPageSize.ToString());


            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
            {
                // Info object
                Gatephotodetaildt lobjGatephotodetail = new Gatephotodetaildt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "gpr_licenseno":
                            lobjGatephotodetail.gpr_licenseno = strColumnValue;
                            break;

                        case "gpr_containernumber":
                            lobjGatephotodetail.gpr_containernumber = strColumnValue;
                            break;
                        case "gpr_blnumber":
                            lobjGatephotodetail.gpr_blnumber = strColumnValue;
                            break;

                        case "gpr_requesteddate":
                            lobjGatephotodetail.gpr_requesteddate = strColumnValue;
                            break;
                        case "gpr_status":
                            lobjGatephotodetail.gpr_status = strColumnValue;
                            break;
                        case "gp_reqreference":
                            lobjGatephotodetail.gp_reqreference = strColumnValue;
                            break;

                        case "gp_image":
                            lobjGatephotodetail.gp_image = strColumnValue;
                            lobjGatephotodetail.Gate_Image = strColumnValue;
                            break;


                    }
                }

                lobjGatephotodetail.SNO = lintRowNo;
                llstResult.Add(lobjGatephotodetail);

                lintRowNo++;
            }


            return llstResult;
        }




        public List<Gatephotodetaildt> getContainerGatedoutImage(string fstrFilter, int lfintPageNo, int lfintPageSize)
        {
            // string fstrUserCode,string fstrTitle, string fstrFilter, string fstrPageNumber, string fstrPageSize
            List<Gatephotodetaildt> llstResult = new List<Gatephotodetaildt>();

            // https://webgateway.rsgt.com:9090/eportal_api/getGatedoutImage?fstrFilter=fstrBOLNo:23156487PO;fstrContainerNo::&fstrPageNumber=1&fstrPageSize=20
            //License+BOL+Container
            //2_JEDIMPSP4144E_MRSU3922594
            int lintRowNo = 1;

            string lstrApiName = "getGatedoutImage";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", lfintPageNo.ToString());
            lobjInParams.Add("fstrPageSize", lfintPageSize.ToString());


            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            //int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
            {
                // Info object
                Gatephotodetaildt lobjGatephotodetail = new Gatephotodetaildt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "gpr_licenseno":
                            lobjGatephotodetail.gpr_licenseno = strColumnValue;
                            break;

                        case "gpr_containernumber":
                            lobjGatephotodetail.gpr_containernumber = strColumnValue;
                            break;
                        case "gpr_blnumber":
                            lobjGatephotodetail.gpr_blnumber = strColumnValue;
                            break;

                        case "gpr_requesteddate":
                            lobjGatephotodetail.gpr_requesteddate = strColumnValue;
                            break;
                        case "gpr_status":
                            lobjGatephotodetail.gpr_status = strColumnValue;
                            break;
                        case "gp_reqreference":
                            lobjGatephotodetail.gp_reqreference = strColumnValue;
                            break;

                        case "gp_image":
                            lobjGatephotodetail.gp_image = strColumnValue;
                            lobjGatephotodetail.Gate_Image = strColumnValue;
                            break;


                    }
                }

                lobjGatephotodetail.SNO = lintRowNo;
                llstResult.Add(lobjGatephotodetail);

                lintRowNo++;
            }


            return llstResult;
        }

        public string getContainerImage(string fstrLicenseNo, string fstrBillofladingNo, string fstrContainerNo)
        {
            string llstResult = "";
            //

            //https://webgateway.rsgt.com:9090/eportal_api/getContainerImage?fstrLicenseNo=255500&fstrBillofladingNo=225500&fstrContainerNo=LMCU9111972

            string lstrApiName = "getContainerImage";

            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrLicenseNo", fstrLicenseNo);
            lobjInParams.Add("fstrBillofladingNo", fstrBillofladingNo);
            lobjInParams.Add("fstrContainerNo", fstrContainerNo);
            llstResult = objWebApi.getWebstringApiData(lstrApiName, lobjInParams);

            return llstResult;
        }


        public string getBOLGatedImage(string fstrBillofladingNo)
        {
            string llstResult = "";
            //https://webgateway.rsgt.com:9090/eportal_api/getBOLGatedImage?fstrBillofladingNo=914521686

            string lstrApiName = "getBOLGatedImage";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrBillofladingNo", fstrBillofladingNo);
            llstResult = objWebApi.getWebstringApiData(lstrApiName, lobjInParams);

            return llstResult;
        }

        public List<clsListofcontainer> getContainers(string fstrRegisterEmailID)
        {

            List<clsListofcontainer> llstResult = new List<clsListofcontainer>();
            string lstrApiName = "getContainers";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjContainerRow in lobjApiData)
            {
                // Info object
                clsListofcontainer lobjContainer = new clsListofcontainer();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjContainerRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_unitgkey":
                            lobjContainer.cd_unitgkey = strColumnValue;
                            break;
                        case "cd_ufvgkey":
                            lobjContainer.cd_ufvgkey = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_vesselvisitgkey":
                            lobjContainer.cd_vesselvisitgkey = strColumnValue;
                            break;
                        case "cd_vesselvisitid":
                            lobjContainer.cd_vesselvisitid = strColumnValue;
                            break;
                        case "cd_vesselname1":
                            lobjContainer.cd_vesselname1 = strColumnValue;
                            break;
                        case "cd_vesselname2":
                            lobjContainer.cd_vesselname2 = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjContainer.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blgkey":
                            lobjContainer.cd_blgkey = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjContainer.cd_blnumber = strColumnValue;
                            break;
                        case "cd_commodity":
                            lobjContainer.cd_commodity = strColumnValue;
                            break;
                        case "cd_obvoyage":
                            lobjContainer.cd_obvoyage = strColumnValue;
                            break;
                        case "cd_ibvoyage":
                            lobjContainer.cd_ibvoyage = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjContainer.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_shippingicon":
                            lobjContainer.cd_shippingicon = strColumnValue;
                            break;
                        case "cd_consigneegkey":
                            lobjContainer.cd_consigneegkey = strColumnValue;
                            break;
                        case "cd_consigneedesc1":
                            lobjContainer.cd_consigneedesc1 = strColumnValue;
                            break;
                        case "cd_consigneedesc2":
                            lobjContainer.cd_consigneedesc2 = strColumnValue;
                            break;
                        case "cd_shippergkey":
                            lobjContainer.cd_shippergkey = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            lobjContainer.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_shipperdesc2":
                            lobjContainer.cd_shipperdesc2 = strColumnValue;
                            break;
                        case "cd_custombrokeragent":
                            lobjContainer.cd_custombrokeragent = strColumnValue;
                            break;
                        case "cd_category":
                            lobjContainer.cd_category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjContainer.cd_freightkind = strColumnValue;
                            break;
                        case "cd_size":
                            lobjContainer.cd_size = strColumnValue;
                            break;
                        case "cd_weight":
                            lobjContainer.cd_weight = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjContainer.cd_portofloading = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjContainer.cd_portofdischarge = strColumnValue;
                            break;
                        case "cd_inspectionstatus":
                            lobjContainer.cd_inspectionstatus = strColumnValue;
                            break;
                        case "cd_fminspectionstatus":
                            lobjContainer.cd_fminspectionstatus = strColumnValue;
                            break;
                        case "cd_holdpermission":
                            lobjContainer.cd_holdpermission = strColumnValue;
                            break;
                        case "cd_transitstatus":
                            lobjContainer.cd_transitstatus = strColumnValue;
                            break;
                        case "cd_oogdetails":
                            lobjContainer.cd_oogdetails = strColumnValue;
                            break;
                        case "cd_reeferdetails":
                            lobjContainer.cd_reeferdetails = strColumnValue;
                            break;
                        case "cd_dgdetails":
                            lobjContainer.cd_dgdetails = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjContainer.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_arrived":
                            lobjContainer.cd_arrived = strColumnValue;
                            break;
                        case "cd_fmarrived":
                            lobjContainer.cd_fmarrived = strColumnValue;
                            break;
                        case "cd_discrecivaltime":
                            lobjContainer.cd_discrecivaltime = strColumnValue;
                            break;
                        case "cd_dischargeimage":
                            lobjContainer.cd_dischargeimage = strColumnValue;
                            break;
                        case "cd_timeout":
                            lobjContainer.cd_timeout = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_movetoinspectiontime":
                            lobjContainer.cd_movetoinspectiontime = strColumnValue;
                            break;
                        case "cd_inspectionimage":
                            lobjContainer.cd_inspectionimage = strColumnValue;
                            break;
                        case "cd_fmtmovetoinspectiontime":
                            lobjContainer.cd_fmtmovetoinspectiontime = strColumnValue;
                            break;
                        case "cd_inspectioncomplete":
                            lobjContainer.cd_inspectioncomplete = strColumnValue;
                            break;
                        case "cd_fmtinspectioncomplete":
                            lobjContainer.cd_fmtinspectioncomplete = strColumnValue;
                            break;
                        case "cd_readyfordeliverytime":
                            lobjContainer.cd_readyfordeliverytime = strColumnValue;
                            break;
                        case "cd_fmreadyfordeliverytime":
                            lobjContainer.cd_fmreadyfordeliverytime = strColumnValue;
                            break;
                        case "cd_prepickupissuedtime":
                            lobjContainer.cd_prepickupissuedtime = strColumnValue;
                            break;
                        case "cd_fmprepickissuedtime":
                            lobjContainer.cd_fmprepickissuedtime = strColumnValue;
                            break;
                        case "cd_appointmentimage":
                            lobjContainer.cd_appointmentimage = strColumnValue;
                            break;
                        case "cd_gatedouttime":
                            lobjContainer.cd_gatedouttime = strColumnValue;
                            break;
                        case "cd_gateimage":
                            lobjContainer.cd_gateimage = strColumnValue;
                            break;
                        case "cd_depotimage":
                            lobjContainer.cd_depotimage = strColumnValue;
                            break;
                        case "cd_fmgatedouttime":
                            lobjContainer.cd_fmgatedouttime = strColumnValue;
                            break;
                        case "cd_gaugeunitsize":
                            lobjContainer.cd_gaugeunitsize = strColumnValue;
                            break;
                        case "cd_dryreefer":
                            lobjContainer.cd_dryreefer = strColumnValue;
                            break;
                        case "cd_detention":
                            lobjContainer.cd_detention = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_apptnbr":
                            lobjContainer.cd_apptnbr = strColumnValue;
                            break;
                        case "cd_apptdate":
                            lobjContainer.cd_apptdate = strColumnValue;
                            break;
                        case "cd_apptstatus":
                            lobjContainer.cd_apptstatus = strColumnValue;
                            break;
                        case "cd_createddate":
                            lobjContainer.cd_createddate = strColumnValue;
                            break;
                        case "cd_agentkey":
                            lobjContainer.cd_agentkey = strColumnValue;
                            break;
                        case "cd_lastmodifieddate":
                            lobjContainer.cd_lastmodifieddate = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjContainer.cd_transporter = strColumnValue;
                            break;
                        case "cd_priorityholdtypeno":
                            lobjContainer.cd_priorityholdtypeno = strColumnValue;
                            break;
                        case "cd_priorityholdtype":
                            lobjContainer.cd_priorityholdtype = strColumnValue;
                            break;
                        case "cd_statuscode":
                            lobjContainer.cd_statuscode = strColumnValue;
                            break;
                        case "cd_statusdesc1":
                            lobjContainer.cd_statusdesc1 = strColumnValue;
                            break;
                        case "cd_statusdesc2":
                            lobjContainer.cd_statusdesc2 = strColumnValue;
                            break;
                        case "cd_discrecivaltime_month":
                            lobjContainer.cd_discrecivaltime_month = strColumnValue;
                            break;
                        case "cd_prepickupissuedtime_month":
                            lobjContainer.cd_prepickupissuedtime_month = strColumnValue;
                            break;
                        case "cd_gatedouttime_month":
                            lobjContainer.cd_gatedouttime_month = strColumnValue;
                            break;
                        case "popupcontainer":
                            lobjContainer.popupcontainer = strColumnValue;
                            break;
                        case "damagedetailspopup":
                            lobjContainer.damagedetailspopup = strColumnValue;
                            break;
                        case "cd_invoiceflag":
                            lobjContainer.cd_invoiceflag = strColumnValue;
                            break;
                        case "cd_invoicetext":
                            lobjContainer.cd_invoicetext = strColumnValue;
                            break;
                        case "cd_damageflag":
                            lobjContainer.cd_damageflag = strColumnValue;
                            break;
                        case "cd_platenbr":
                            lobjContainer.cd_platenbr = strColumnValue;
                            break;
                        case "cd_truckgkey":
                            lobjContainer.cd_truckgkey = strColumnValue;
                            break;
                        case "cd_truckcogkey":
                            lobjContainer.cd_truckcogkey = strColumnValue;
                            break;


                    }

                }
                llstResult.Add(lobjContainer);

            }
            return llstResult;

        }

        public List<ContainerDtcls.clsContainertimeline> getContainerTimeLine(string fstrRegisterEmailID, string fstrFilter)
        {

            List<ContainerDtcls.clsContainertimeline> llstResult = new List<ContainerDtcls.clsContainertimeline>();
            string lstrApiName = "getContainerTimeLinePhas2";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);
            // lobjInParams.Add("fstrAPIToken", "");            
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjContainerTimeeRow in lobjApiData)
            {
                // Info object
                ContainerDtcls.clsContainertimeline lobjContainerTime = new ContainerDtcls.clsContainertimeline();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjContainerTimeeRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_unitgkey":
                            lobjContainerTime.cd_unitgkey = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjContainerTime.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blgkey":
                            lobjContainerTime.cd_blgkey = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjContainerTime.cd_blnumber = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjContainerTime.cd_containernumber = strColumnValue;
                            break;
                        case "cd_vesselvisitgkey":
                            lobjContainerTime.cd_vesselvisitgkey = strColumnValue;
                            break;
                        case "cd_fminspectionstatus":
                            lobjContainerTime.cd_fminspectionstatus = strColumnValue;
                            break;
                        case "cd_transitstatus":
                            lobjContainerTime.cd_transitstatus = strColumnValue;
                            break;
                        case "timeline_arrived":
                            lobjContainerTime.timeline_arrived = strColumnValue;
                            break;
                        case "timeline_arrivedflag":
                            lobjContainerTime.timeline_arrivedflag = strColumnValue;
                            break;
                        case "timeline_discharge":
                            lobjContainerTime.timeline_discharge = strColumnValue;
                            break;
                        case "timeline_dischargeflag":
                            lobjContainerTime.timeline_dischargeflag = strColumnValue;
                            break;
                        case "timeline_underinspection":
                            lobjContainerTime.timeline_underinspection = strColumnValue;
                            break;
                        case "timeline_underinspectionflag":
                            lobjContainerTime.timeline_underinspectionflag = strColumnValue;
                            break;
                        case "timeline_inspectioncomplete":
                            lobjContainerTime.timeline_inspectioncomplete = strColumnValue;
                            break;
                        case "timeline_inspectioncompleteflag":
                            lobjContainerTime.timeline_inspectioncompleteflag = strColumnValue;
                            break;
                        case "timeline_readyfordeliverytime":
                            lobjContainerTime.timeline_readyfordeliverytime = strColumnValue;
                            break;
                        case "timeline_readyfordeliverytimeflag":
                            lobjContainerTime.timeline_readyfordeliverytimeflag = strColumnValue;
                            break;
                        case "timeline_prepickupissuedtime":
                            lobjContainerTime.timeline_prepickupissuedtime = strColumnValue;
                            break;
                        case "timeline_prepickupissuedtimeflag":
                            lobjContainerTime.timeline_prepickupissuedtimeflag = strColumnValue;
                            break;
                        case "timeline_gatedouttime":
                            lobjContainerTime.timeline_gatedouttime = strColumnValue;
                            break;
                        case "timeline_gatedouttimeflag":
                            lobjContainerTime.timeline_gatedouttimeflag = strColumnValue;
                            break;
                        case "cd_fmtexpectedtimeofarrival":
                            lobjContainerTime.cd_fmtexpectedtimeofarrival = strColumnValue;
                            break;
                        case "cd_fmtactualtimeofarrival":
                            lobjContainerTime.cd_fmtactualtimeofarrival = strColumnValue;
                            break;
                        case "cd_createddate":
                            lobjContainerTime.cd_createddate = strColumnValue;
                            break;
                        case "cd_platenbr":
                            lobjContainerTime.cd_platenbr = strColumnValue;
                            break;
                        case "cd_truckgkey":
                            lobjContainerTime.cd_truckgkey = strColumnValue;
                            break;
                        case "cd_truckcogkey":
                            lobjContainerTime.cd_truckcogkey = strColumnValue;
                            break;
                        case "cd_consigneegkey":
                            lobjContainerTime.cd_consigneegkey = strColumnValue;
                            break;
                        case "cd_shippergkey":
                            lobjContainerTime.cd_shippergkey = strColumnValue;
                            break;
                        case "cd_custombrokeragent":
                            lobjContainerTime.cd_custombrokeragent = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjContainerTime.cd_transporter = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjContainerTime.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_agentkey":
                            lobjContainerTime.cd_agentkey = strColumnValue;
                            break;
                        case "cd_containerdocument":
                            lobjContainerTime.cd_containerdocument = strColumnValue;
                            break;
                        case "timeline_waitingforportcharges":
                            lobjContainerTime.timeline_waitingforportcharges = strColumnValue;
                            break;

                        //12-01-2023-Sanduru
                        case "cd_category":
                            lobjContainerTime.cd_category = strColumnValue;
                            break;
                        case "timeline_expunitintime":
                            lobjContainerTime.timeline_expunitintime = strColumnValue;
                            break;
                        case "timeline_expunitintimeflag":
                            lobjContainerTime.timeline_expunitintimeflag = strColumnValue;
                            break;
                        case "timeline_expbookforinsptime":
                            lobjContainerTime.timeline_expbookforinsptime = strColumnValue;
                            break;
                        case "timeline_expbookforinsptimeflag":
                            lobjContainerTime.timeline_expbookforinsptimeflag = strColumnValue;
                            break;
                        case "timeline_expinspcompletedtime":
                            lobjContainerTime.timeline_expinspcompletedtime = strColumnValue;
                            break;
                        case "timeline_expinspcompletedtimeflag":
                            lobjContainerTime.timeline_expinspcompletedtimeflag = strColumnValue;
                            break;
                        case "timeline_expexcesscargoholdtime":
                            lobjContainerTime.timeline_expexcesscargoholdtime = strColumnValue;
                            break;
                        case "timeline_expexcesscargoholdtimeflag":
                            lobjContainerTime.timeline_expexcesscargoholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expdetentionholdtime":
                            lobjContainerTime.timeline_expdetentionholdtime = strColumnValue;
                            break;
                        case "timeline_expdetentionholdtimeflag":
                            lobjContainerTime.timeline_expdetentionholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expcoldstorepayholdtime":
                            lobjContainerTime.timeline_expcoldstorepayholdtime = strColumnValue;
                            break;
                        case "timeline_expcoldstorepayholdtimeflag":
                            lobjContainerTime.timeline_expcoldstorepayholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expfinholdtime":
                            lobjContainerTime.timeline_expfinholdtime = strColumnValue;
                            break;
                        case "timeline_expfinholdtimeflag":
                            lobjContainerTime.timeline_expfinholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expreadytoloadtime":
                            lobjContainerTime.timeline_expreadytoloadtime = strColumnValue;
                            break;
                        case "timeline_expreadytoloadtimeflag":
                            lobjContainerTime.timeline_expreadytoloadtimeflag = strColumnValue;
                            break;
                        case "timeline_expunitloadtime":
                            lobjContainerTime.timeline_expunitloadtime = strColumnValue;
                            break;
                        case "timeline_expunitloadtimeflag":
                            lobjContainerTime.timeline_expunitloadtimeflag = strColumnValue;
                            break;


                    }

                }
                llstResult.Add(lobjContainerTime);

            }
            return llstResult;

        }

        public List<ContainerDtcls.clsContainerDetails> getContainerDetailsSection(string fstrRegisterEmailID, string fstrFilter)
        {

            List<ContainerDtcls.clsContainerDetails> llstResult = new List<ContainerDtcls.clsContainerDetails>();
            string lstrApiName = "getContainerDetailsSection";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);
            // lobjInParams.Add("fstrAPIToken", "");            
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjContainerTimeeRow in lobjApiData)
            {
                // Info object
                ContainerDtcls.clsContainerDetails lobjContainerTime = new ContainerDtcls.clsContainerDetails();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjContainerTimeeRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_unitgkey":
                            lobjContainerTime.cd_unitgkey = strColumnValue;
                            break;

                        case "cd_ufvgkey":
                            lobjContainerTime.cd_ufvgkey = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjContainerTime.cd_containernumber = strColumnValue;
                            break;
                        case "cd_vesselvisitgkey":
                            lobjContainerTime.cd_vesselvisitgkey = strColumnValue;
                            break;
                        case "cd_vesselvisitid":
                            lobjContainerTime.cd_vesselvisitid = strColumnValue;
                            break;
                        case "cd_vesselname1":
                            lobjContainerTime.cd_vesselname1 = strColumnValue;
                            break;
                        case "cd_vesselname2":
                            lobjContainerTime.cd_vesselname2 = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjContainerTime.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blgkey":
                            lobjContainerTime.cd_blgkey = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjContainerTime.cd_blnumber = strColumnValue;
                            break;
                        case "cd_commodity":
                            lobjContainerTime.cd_commodity = strColumnValue;
                            break;
                        case "cd_obvoyage":
                            lobjContainerTime.cd_obvoyage = strColumnValue;
                            break;
                        case "cd_ibvoyage":
                            lobjContainerTime.cd_ibvoyage = strColumnValue;
                            break;
                        case "cd_shippingicon":
                            lobjContainerTime.cd_shippingicon = strColumnValue;
                            break;
                        case "cd_consigneedesc1":
                            lobjContainerTime.cd_consigneedesc1 = strColumnValue;
                            break;
                        case "cd_consigneedesc2":
                            lobjContainerTime.cd_consigneedesc2 = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            lobjContainerTime.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_shipperdesc2":
                            lobjContainerTime.cd_shipperdesc2 = strColumnValue;
                            break;
                        case "cd_category":
                            lobjContainerTime.cd_category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjContainerTime.cd_freightkind = strColumnValue;
                            break;
                        case "cd_size":
                            lobjContainerTime.cd_size = strColumnValue;
                            break;
                        case "cd_weight":
                            lobjContainerTime.cd_weight = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjContainerTime.cd_portofloading = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjContainerTime.cd_portofdischarge = strColumnValue;
                            break;
                        case "cd_inspectionstatus":
                            lobjContainerTime.cd_inspectionstatus = strColumnValue;
                            break;
                        case "cd_holdpermission":
                            lobjContainerTime.cd_holdpermission = strColumnValue;
                            break;
                        case "cd_transitstatus":
                            lobjContainerTime.cd_transitstatus = strColumnValue;
                            break;
                        case "cd_oogdetails":
                            lobjContainerTime.cd_oogdetails = strColumnValue;
                            break;
                        case "cd_reeferdetails":
                            lobjContainerTime.cd_reeferdetails = strColumnValue;
                            break;
                        case "cd_dgdetails":
                            lobjContainerTime.cd_dgdetails = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjContainerTime.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_platenbr":
                            lobjContainerTime.cd_platenbr = strColumnValue;
                            break;
                        case "cd_truckgkey":
                            lobjContainerTime.cd_truckgkey = strColumnValue;
                            break;
                        case "cd_truckcogkey":
                            lobjContainerTime.cd_truckcogkey = strColumnValue;
                            break;
                        case "damagedetailspopup":
                            lobjContainerTime.damagedetailspopup = strColumnValue;
                            break;
                        case "cd_damageflag":
                            lobjContainerTime.cd_damageflag = strColumnValue;
                            break;
                        case "cd_consigneegkey":
                            lobjContainerTime.cd_consigneegkey = strColumnValue;
                            break;

                        case "cd_shippergkey":
                            lobjContainerTime.cd_shippergkey = strColumnValue;
                            break;

                        case "cd_custombrokeragent":
                            lobjContainerTime.cd_custombrokeragent = strColumnValue;
                            break;

                        case "cd_transporter":
                            lobjContainerTime.cd_transporter = strColumnValue;
                            break;

                        case "cd_shippinglineid":
                            lobjContainerTime.cd_shippinglineid = strColumnValue;
                            break;

                        case "cd_agentkey":
                            lobjContainerTime.cd_agentkey = strColumnValue;
                            break;

                        case "cd_token":
                            lobjContainerTime.cd_token = strColumnValue;
                            break;

                        case "cd_emptydepot":
                            lobjContainerTime.cd_emptydepot = strColumnValue;
                            break;

                        case "cd_emptydepot_eng":
                            lobjContainerTime.cd_emptydepot_eng = strColumnValue;
                            break;

                        case "cd_emptydepot_ara":
                            lobjContainerTime.cd_emptydepot_ara = strColumnValue;
                            break;






                    }

                }
                llstResult.Add(lobjContainerTime);

            }
            return llstResult;

        }


        public List<InvoiceDt> getInvoiceDetails(string fstrRegisterEmailID, int fintPageNumber, int fintPageSize, string fstrFilter)
        {
            List<InvoiceDt> llstResult = new List<InvoiceDt>();
            string lstrApiName = "getInvoiceDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjInvoiceRow in lobjApiData)
            {
                // Info object
                InvoiceDt lobjInvoice = new InvoiceDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjInvoiceRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ih_proformainvoiceno":
                            lobjInvoice.ProformaInvoice = strColumnValue;
                            break;
                        case "ih_billofladingno":
                            lobjInvoice.BOL = strColumnValue;
                            break;
                        case "ih_consigneename":
                            lobjInvoice.Customer = strColumnValue;
                            break;
                        case "ih_grandtotal":
                            lobjInvoice.Amount = string.Format("{0:0.00}", Column.Value);
                            break;

                        case "ih_fmtinvoicedate":
                            lobjInvoice.Validity = strColumnValue;
                            break;

                        case "ih_fmtproformainvoicedate":
                            lobjInvoice.CreatedOn = strColumnValue;
                            break;
                        case "ih_status":
                            if (App.gblLanguage == "En")
                            {
                                lobjInvoice.Status = strColumnValue;
                            }
                            lobjInvoice.StatusEng = strColumnValue;
                            break;
                        case "ih_statusar":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjInvoice.Status = strColumnValue;
                            }
                            break;
                        case "ih_mop":
                            lobjInvoice.MOP = strColumnValue;
                            break;

                        case "ih_paymentref":
                            lobjInvoice.PaymentRef = strColumnValue;
                            break;
                        case "ih_fmtpaidon":
                            lobjInvoice.PaidOn = strColumnValue;
                            break;


                        case "ih_statuscolour":
                            lobjInvoice.StatusColor = strColumnValue;
                            break;

                        case "ih_invoiceno":
                            lobjInvoice.InvoiceNo = strColumnValue;
                            break;
                        case "bl_invoiceconsignee":
                            lobjInvoice.blinvoiceconsignee = strColumnValue;
                            break;
                        case "bl_payinvoiceflag":
                            lobjInvoice.payinvoiceflag = strColumnValue;
                            break;
                        case "bl_bookanappointmentflag":
                            lobjInvoice.bookanappointmentflag = strColumnValue;
                            break;



                    }

                }

                lobjInvoice.StatusColor = "#777777"; // unpaid color handled
                if (lobjInvoice.Status.ToString().ToUpper().Trim() == "PAID")//PAID color handled
                {
                    lobjInvoice.StatusColor = "#5cb85c";
                }

                llstResult.Add(lobjInvoice);

            }
            return llstResult;

        }


        public List<ManualInspectionDt> getBookforManualInspectionDetails(string fstrRegisterEmailID, int fstrPageNumber, int fstrPageSize, string fstrAPIToken, string fstrFilter)
        {
            //http://172.19.35.68:89/api/DataSource/getBookforManualInspectionDetails?fstrAPIToken&fstrMailId=cieloclearingagent@gmail.com&fstrFilter=fstrAnywhere:;fstrContainerNo:;fstrBayanNo:;fstrBillofLadingNo:;fstrSize:;fstrCarrier:;fstrCategory:;fstrFreightKind:;fstrPOL:;fstrPOD:;&fstrPageNumber=1&fstrPageSize=20
            List<ManualInspectionDt> llstResult = new List<ManualInspectionDt>();
            string lstrApiName = "getBookforManualInspectionDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);


            lobjInParams.Add("fstrPageNumber", fstrPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fstrPageSize.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBookManualRow in lobjApiData)
            {
                // Info object
                ManualInspectionDt lobjBookManual = new ManualInspectionDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBookManualRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "cd_containernumber":
                            lobjBookManual.ContainerNo = strColumnValue;
                            break;
                        case "cd_size":
                            lobjBookManual.Size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjBookManual.Bayan = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjBookManual.BOL = strColumnValue;
                            break;

                        case "cd_shipperdesc1":
                            lobjBookManual.Carrier = strColumnValue;
                            break;

                        case "cd_vesselname1":
                            lobjBookManual.Vessel = strColumnValue;
                            break;

                        case "cd_obvoyage":
                            lobjBookManual.Voyage = strColumnValue;
                            break;
                        case "cd_category":
                            lobjBookManual.Category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjBookManual.Freightkind = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjBookManual.POL = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjBookManual.POD = strColumnValue;
                            break;

                        case "cd_statuscode":
                            lobjBookManual.statuscode = strColumnValue;
                            lobjBookManual.StatusColor = "#f0ad4e";
                            if (lobjBookManual.statuscode == "VCG")
                            {
                                lobjBookManual.StatusColor = "#777";
                            }
                            break;
                        case "cd_statusdesc1":
                            lobjBookManual.Status = strColumnValue;
                            break;
                        case "cd_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBookManual.Status = strColumnValue;
                            }
                            break;

                        case "cd_fmtdiscrecivaltime":
                            lobjBookManual.TimeIn = strColumnValue;
                            break;

                        case "cd_unitgkey":
                            lobjBookManual.ContainerUnitGKey = strColumnValue;
                            break;


                    }



                }
                llstResult.Add(lobjBookManual);

            }
            return llstResult;

        }


        public List<clsManualInsCarrierFilter> getManualInsFilterCarrierList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsManualInsCarrierFilter> llstResult = new List<clsManualInsCarrierFilter>();
            string lstrApiName = "getBookforManualInspectionCarrierFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailID", gblRegisteration.strLoginUser);
            //lobjInParams.Add("fstrAPIToken", "");
            // lobjInParams.Add("fstrFilter", fstrFilter);

            // http://172.19.35.68:89/api/DataSource/etBookforManualInspectionCarrierFilter?fstrAPIToken&fstrFilter=Agentkey:4085137016;

            //  string fstrFilter = "Agentkey:" + Agentkey + ";";

            //lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsManualInsCarrierFilter lobjFilter = new clsManualInsCarrierFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }


        public List<clsManualInsSizeFilter> getManualInsFilterSizeList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsManualInsSizeFilter> llstResult = new List<clsManualInsSizeFilter>();
            string lstrApiName = "getBookforManualInspectionSizeFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);

            // lobjInParams.Add("fstrFilter", fstrFilter);

            // http://172.19.35.68:89/api/DataSource/etBookforManualInspectionSizeFilter?fstrAPIToken&fstrFilter=Agentkey:4085137016;
            // http://172.19.35.68:89/api/DataSource/getBookforManualInspectionCarrierFilter?fstrAPIToken=&fstrMailId=cielobroker1@gmail.com

            //string fstrFilter = "Agentkey:" + Agentkey + ";";

            //lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsManualInsSizeFilter lobjFilter = new clsManualInsSizeFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsManualInsCategoryFilter> getManualInsFilterCategoryList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsManualInsCategoryFilter> llstResult = new List<clsManualInsCategoryFilter>();
            string lstrApiName = "getBookforManualInspectionCategoryFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);

            // lobjInParams.Add("fstrFilter", fstrFilter);

            // http://172.19.35.68:89/api/DataSource/etBookforManualInspectionCategoryFilter?fstrAPIToken&fstrFilter=Agentkey:4085137016;

            //string fstrFilter = "Agentkey:" + Agentkey + ";";

            //lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsManualInsCategoryFilter lobjFilter = new clsManualInsCategoryFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsManualInsFreightKindFilter> getManualInsFilterFreightKindList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsManualInsFreightKindFilter> llstResult = new List<clsManualInsFreightKindFilter>();
            string lstrApiName = "getBookforManualInspectionFreightKindFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);

            // lobjInParams.Add("fstrFilter", fstrFilter);

            // http://172.19.35.68:89/api/DataSource/etBookforManualInspectionFreightKindFilter?fstrAPIToken&fstrFilter=Agentkey:4085137016;

            //string fstrFilter = "Agentkey:" + Agentkey + ";";

            //lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsManualInsFreightKindFilter lobjFilter = new clsManualInsFreightKindFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsManualInsPolFilter> getManualInsFilterPolList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsManualInsPolFilter> llstResult = new List<clsManualInsPolFilter>();
            string lstrApiName = "getBookforManualInspectionPOLFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);

            // lobjInParams.Add("fstrFilter", fstrFilter);

            // http://172.19.35.68:89/api/DataSource/etBookforManualInspectionPOLFilter?fstrAPIToken&fstrFilter=Agentkey:4085137016;

            //string fstrFilter = "Agentkey:" + Agentkey + ";";

            //lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsManualInsPolFilter lobjFilter = new clsManualInsPolFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public string getbalance(string fstrCustomerId, string fstrCustomerType)
        {
            //https://webgateway.rsgt.com:9090/ewallet_data_dev/getbalance/{Consignee_ID}---old
            // https://webgateway.rsgt.com:9090/eportal_api/getbalance?fstrCustomerId=7491765718&fstrCustomerType=Consignee
            //  https://webgateway.rsgt.com:9090/eportal_api/getbalance?fstrCustomerId=3907885576&fstrCustomerType=Broker



            string llstResult = "";
            string lstrApiName = "getbalance";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrCustomerId", fstrCustomerId);
            lobjInParams.Add("fstrCustomerType", fstrCustomerType);
            llstResult = objWebApi.getWebstringApiData(lstrApiName, lobjInParams);




            return llstResult;
        }

        public List<clsManualInsPodFilter> getManualInsFilterPodList(string fstrRegisterEmailID, string fstrAPIToken)
        {
            List<clsManualInsPodFilter> llstResult = new List<clsManualInsPodFilter>();
            string lstrApiName = "getBookforManualInspectionPODFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);

            // lobjInParams.Add("fstrFilter", fstrFilter);

            // http://172.19.35.68:89/api/DataSource/etBookforManualInspectionPODFilter?fstrAPIToken&fstrFilter=Agentkey:4085137016;

            //string fstrFilter = "Agentkey:" + Agentkey + ";";

            //lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                //if (lintIndex > 10) break;
                // Info object
                clsManualInsPodFilter lobjFilter = new clsManualInsPodFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public string getHOLDbalance(string fstrCustomerId)
        {
            string llstResult = "";
            string lstrApiName = "";
            //https://webgateway.rsgt.com:9090/eportal_api/getHoldBalancedetails?fstrusercode=3745278978
            lstrApiName = "getHoldBalancedetails";
            Dictionary<string, string> lobjInParams1 = new Dictionary<string, string>();
            lobjInParams1.Add("fstrusercode", fstrCustomerId);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams1);
            List<GETHOLDAMOUNT> lstHoldResult = new List<GETHOLDAMOUNT>();

            foreach (IEnumerable<Object> lobjTicketsRow in lobjApiData)
            {
                // Info object
                GETHOLDAMOUNT lobjHold = new GETHOLDAMOUNT();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTicketsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();
                    switch (strColumnName)
                    {
                        case "holdbalance":
                            lobjHold.holdbalance = Convert.ToDecimal(strColumnValue);
                            break;
                    }
                }

                lstHoldResult.Add(lobjHold);
            }
            if (lstHoldResult.Count > 0)
            {
                decimal dclHoldBalance = lstHoldResult[0].holdbalance;

                llstResult = dclHoldBalance.ToString().Trim();
            }
            return llstResult;
        }

        public class GETHOLDAMOUNT
        {
            public string linkcode { get; set; }
            public string ah_usrid { get; set; }
            public string ih_consigneeid { get; set; }
            public decimal holdbalance { get; set; }
        }
        public List<clsDetentionmanagement> getDetentionManagementDetails(string fstrRegisterEmailID)
        {

            List<clsDetentionmanagement> llstResult = new List<clsDetentionmanagement>();
            string lstrApiName = "getDetentionManagementDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjDetenRow in lobjApiData)
            {
                // Info object
                clsDetentionmanagement lobjDetentention = new clsDetentionmanagement();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjDetenRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_blnumber":
                            lobjDetentention.cd_blnumber = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDetentention.cd_containernumber = strColumnValue;
                            break;
                        case "cd_size":
                            lobjDetentention.cd_size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjDetentention.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_discrecivaltime":
                            lobjDetentention.cd_discrecivaltime = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjDetentention.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            lobjDetentention.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_shipperdesc2":
                            lobjDetentention.cd_shipperdesc2 = strColumnValue;
                            break;
                        case "cd_detention":
                            lobjDetentention.cd_detention = strColumnValue;
                            break;
                        case "cd_fmtdetention":
                            lobjDetentention.cd_fmtdetention = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjDetentention.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDetentention.cd_fmtgatedouttime = strColumnValue;
                            break;
                        //case "cd_dwelldays":
                        //    lobjDetentention.cd_dwelldays = strColumnValue;
                        //    break;
                        case "cd_transporter":
                            lobjDetentention.cd_transporter = strColumnValue;
                            break;
                        case "cd_statuscode":
                            lobjDetentention.cd_statuscode = strColumnValue;
                            break;
                        case "cd_gatedouttime":
                            lobjDetentention.cd_gatedouttime = strColumnValue;
                            break;
                        case "cd_platenbr":
                            lobjDetentention.cd_platenbr = strColumnValue;
                            break;
                        case "cd_truckgkey":
                            lobjDetentention.cd_truckgkey = strColumnValue;
                            break;
                        case "cd_truckcogkey":
                            lobjDetentention.cd_truckcogkey = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjDetentention);

            }
            return llstResult;

        }
        public string ManualInsPostStatus(string ApiName, string fstrContainerNo, string objstringJson)
        {
            //http://172.19.35.68:89/api/DataSource/UpdateManualInspectionStatus/BEAU6375660
            //{"CD_ADDTIONALSTATUS":"BFM-Requested"}
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName + "/" + fstrContainerNo;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            string lstrInput = objstringJson;
            //UpadteRegisterUser
            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");


                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PutAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                }
                bool BoolResult = result.IsSuccessStatusCode;
                if (BoolResult == true)
                {
                    lstrResult = "true";
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return lstrResult;
        }

        public List<DwellDt> getDwelldaysDetails(string fstrRegisterEmailID, int fintPageNo, int fintPageSize, string fstrFilter)
        {

            List<DwellDt> llstResult = new List<DwellDt>();
            string lstrApiName = "getDwelldaysDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrPageNumber", fintPageNo.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
            if (fstrFilter != "")
            {
                lobjInParams.Add("fstrFilter", fstrFilter);
            }
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjDwelldaysRow in lobjApiData)
            {
                // Info object
                DwellDt lobjDwelldays = new DwellDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjDwelldaysRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();



                    switch (strColumnName)
                    {
                        case "cd_containernumber":
                            lobjDwelldays.ContainerNo = strColumnValue;
                            break;
                        case "cd_size":
                            lobjDwelldays.Size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjDwelldays.Bayan = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDwelldays.BOL = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjDwelldays.DischargedOn = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDwelldays.GatedOutOn = strColumnValue;
                            break;
                        case "cd_dwelldays":
                            lobjDwelldays.DDays = strColumnValue;
                            break;

                        case "cd_shipperdesc1":
                            lobjDwelldays.Carrier = strColumnValue;
                            break;


                    }

                    lobjDwelldays.AnywhereAll += strColumnValue;

                }
                llstResult.Add(lobjDwelldays);

            }
            return llstResult;

        }


        public List<clsListviewpaymenthistory> getPaymentHistoryDetails(string fstrRegisterEmailID)
        {

            List<clsListviewpaymenthistory> llstResult = new List<clsListviewpaymenthistory>();
            string lstrApiName = "getPaymentHistoryDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjPaymentRow in lobjApiData)
            {
                // Info object
                clsListviewpaymenthistory lobjPayment = new clsListviewpaymenthistory();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjPaymentRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ih_invoiceno":
                            lobjPayment.ih_invoiceno = strColumnValue;
                            break;
                        case "bl_bayannumber":
                            lobjPayment.bl_bayannumber = strColumnValue;
                            break;
                        case "bl_blnumber":
                            lobjPayment.bl_blnumber = strColumnValue;
                            break;
                        case "ih_consigneename":
                            lobjPayment.ih_consigneename = strColumnValue;
                            break;
                        case "ih_grandtotal":
                            lobjPayment.ih_grandtotal = strColumnValue;
                            break;
                        case "ih_createddate":
                            lobjPayment.ih_createddate = strColumnValue;
                            break;
                        case "ih_fmtcreateddate":
                            lobjPayment.ih_fmtcreateddate = strColumnValue;
                            break;
                        case "ih_validity":
                            lobjPayment.ih_validity = strColumnValue;
                            break;
                        case "ih_status":
                            lobjPayment.ih_status = strColumnValue;
                            break;
                        case "ih_mop":
                            lobjPayment.ih_mop = strColumnValue;
                            break;
                        case "ih_proformainvoiceduedate":
                            lobjPayment.ih_proformainvoiceduedate = strColumnValue;
                            break;
                        case "ih_fmtproformainvoiceduedate":
                            lobjPayment.ih_fmtproformainvoiceduedate = strColumnValue;
                            break;
                        case "ih_paymentref":
                            lobjPayment.ih_paymentref = strColumnValue;
                            break;
                        case "ih_paidon":
                            lobjPayment.ih_paidon = strColumnValue;
                            break;
                        case "bl_consigneegkey":
                            lobjPayment.bl_consigneegkey = strColumnValue;
                            break;
                        case "bl_shippergkey":
                            lobjPayment.bl_shippergkey = strColumnValue;
                            break;
                        case "bl_custombrokeragent":
                            lobjPayment.bl_custombrokeragent = strColumnValue;
                            break;
                        case "bl_transporter":
                            lobjPayment.bl_transporter = strColumnValue;
                            break;
                        case "bl_linegkey":
                            lobjPayment.bl_linegkey = strColumnValue;
                            break;
                        case "ih_nationalid":
                            lobjPayment.ih_nationalid = strColumnValue;
                            break;
                        case "ih_invoicedate":
                            lobjPayment.ih_invoicedate = strColumnValue;
                            break;
                        case "ih_fmtinvoicedate":
                            lobjPayment.ih_fmtinvoicedate = strColumnValue;
                            break;


                    }

                }
                llstResult.Add(lobjPayment);

            }
            return llstResult;

        }


        //  Detentionmanagement: Details & Filter
        //============================================

        public List<DetentionDt> getDetentionManagementDetails(string fstrRegisterEmailID, int fstrPageNumber, int fstrPageSize, string fstrFilter)
        {
            // https://localhost:44348/api/DataSource/getDetentionManagementDetails?fstrAPIToken&fstrMailId=cieloconsignee@gmail.com&fstrFilter=fstrAnyWhere:;fstrContainernumber:;fstrBayannumber:;fstrSize:;fstrCarrier:;&fstrPageNumber=1&fstrPageSize=10
            List<DetentionDt> llstResult = new List<DetentionDt>();
            string lstrApiName = "getDetentionManagementDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            lobjInParams.Add("fstrPageNumber", fstrPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fstrPageSize.ToString());


            //fstrFilter = fstrAnyWhere:; fstrContainernumber:; fstrBayannumber:; fstrSize:; fstrCarrier:;
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjDetenRow in lobjApiData)
            {
                // Info object
                DetentionDt lobjDetentention = new DetentionDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjDetenRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "cd_containernumber":
                            lobjDetentention.ContainerNo = strColumnValue;
                            break;
                        case "cd_size":
                            lobjDetentention.Size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjDetentention.Bayan = strColumnValue;
                            break;

                        //case "cd_shippinglineid":
                        //    lobjDetentention.Carrier = strColumnValue;
                        //    break;

                        case "cd_fmtdiscrecivaltime":
                            lobjDetentention.DischargedOn = strColumnValue;
                            break;

                        case "cd_dwelldays":
                            lobjDetentention.DwellDays = strColumnValue;
                            break;

                        case "cd_gatedouttime":
                            lobjDetentention.GatedOutOn = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjDetentention.Carrier = strColumnValue;
                            }
                            break;
                        case "cd_shipperdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjDetentention.Carrier = strColumnValue;
                            }
                            break;
                    }

                }
                llstResult.Add(lobjDetentention);

            }
            return llstResult;

        }
        public List<clsDetentionManSizeFilter> getDetentionManFilterSizeList(string fstrTransporterGkey)
        {
            List<clsDetentionManSizeFilter> llstResult = new List<clsDetentionManSizeFilter>();
            string lstrApiName = "DetentionManagementSizeFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            // lobjInParams.Add("fstrAPIToken", "");
            string fstrFilter = "TransporterGkey:" + fstrTransporterGkey + ";";

            lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsDetentionManSizeFilter lobjFilter = new clsDetentionManSizeFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsDetentionManCarrierFilter> getDetentionManFilterCarrierList(string fstrTransporterGkey)
        {
            List<clsDetentionManCarrierFilter> llstResult = new List<clsDetentionManCarrierFilter>();
            string lstrApiName = "DetentionManagementCarrierFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            // lobjInParams.Add("fstrAPIToken", "");
            // lobjInParams.Add("fstrFilter", fstrFilter);
            //lobjInParams.Add("TransporterGkey", fstrTransporterGkey);
            //lobjInParams.Add("fstrFilter", fstrFilter);
            string fstrFilter = "TransporterGkey:" + fstrTransporterGkey + ";";

            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsDetentionManCarrierFilter lobjFilter = new clsDetentionManCarrierFilter();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }

        public List<clsTransactionHistory> getTransactionHistory(string fstrMailID, string fstrFilter, int fstrPageNumber, int fstrPageSize)
        {
            // https://webgateway.rsgt.com:9090/eportal_api/getTransactionHistory?fstrMailID=cieloconsignee@gmail.com&fstrFilter=fstrAnyWhere:;fstrFromDate:;fstrToDate:;fstrPeriod:;fstrFromAmount:;fstrToAmount:;FstrTranscationType:;&fstrPageNumber=1&fstrPageSize=10
            List<clsTransactionHistory> llstResult = new List<clsTransactionHistory>();
            string lstrApiName = "getTransactionHistory?";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrMailID);
            lobjInParams.Add("fstrFilter", fstrFilter);
            lobjInParams.Add("fstrPageNumber", fstrPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fstrPageSize.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjTransactionRow in lobjApiData)
            {
                // Info object
                clsTransactionHistory lobjTransaction = new clsTransactionHistory();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjTransactionRow)
                {
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        //case "wt_recid":
                        //    lobjTransaction.wt_recid = strColumnValue;
                        //    break;
                        case "wt_ruemailid":
                            lobjTransaction.wt_ruemailid = strColumnValue;
                            break; ;
                        case "fmt_trndatetime":
                            lobjTransaction.fmt_trndatetime = strColumnValue;
                            break;
                        case "wt_trntype":
                            lobjTransaction.wt_trntype = strColumnValue;
                            break;
                        case "fmt_trnamount":
                            lobjTransaction.fmt_trnamount = strColumnValue;
                            break;
                        case "wt_blnumber":
                            lobjTransaction.wt_blnumber = strColumnValue;
                            break;
                        case "wt_payref":
                            lobjTransaction.wt_payref = strColumnValue;
                            break;
                        case "wt_invoiceno":
                            lobjTransaction.wt_invoiceno = strColumnValue;
                            break;
                        case "wt_status":
                            lobjTransaction.wt_status = strColumnValue;
                            break;
                    }

                }
                llstResult.Add(lobjTransaction);

            }
            return llstResult;

        }


        // Banned Trucks:Details &  Filter
        //=======================

        public List<BannedTruckDt> getBannedTrucksDetails(string fstrRegisterEmailID, int fstrPageNumber, int fstrPageSize, string fstrFilter)
        {
            // https://localhost:44348/api/DataSource/getBannedTrucksDetails?fstrAPIToken&fstrMailId=cielotransporter1@gmail.com&fstrFilter=fstrAnywhere:;fstrTruckNo:;fstrBanDate:;fstrBanReason:;fstrBanType:;fstrStatus:;&fstrPageNumber=1&fstrPageSize=20
            List<BannedTruckDt> llstResult = new List<BannedTruckDt>();
            string lstrApiName = "getBannedTrucksDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrFilter", fstrFilter);

            lobjInParams.Add("fstrPageNumber", fstrPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fstrPageSize.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBannedRow in lobjApiData)
            {
                // Info object
                BannedTruckDt lobjBanned = new BannedTruckDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBannedRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bant_truckno":
                            lobjBanned.TruckNo = strColumnValue;
                            break;

                        case "bant_fmtbandate":
                            lobjBanned.BanDate = strColumnValue;
                            break;
                        case "bant_typeofban":
                            lobjBanned.BanType = strColumnValue;
                            break;
                        case "bant_reason":
                            lobjBanned.BanReason = strColumnValue;
                            break;
                        case "bant_status":
                            if (App.gblLanguage == "En")
                            {
                                lobjBanned.Status = strColumnValue;
                            }
                            break;

                        case "bant_statusar":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjBanned.Status = strColumnValue;
                            }
                            break;

                        case "bant_transportergkey":
                            lobjBanned.transporterGkey = strColumnValue;
                            break;

                        case "bant_statuscolor":
                            lobjBanned.StatusColor = strColumnValue;
                            break;

                    }
                    lobjBanned.AnywhereAll += strColumnValue;

                }
                lobjBanned.StatusColor = "#777";// Banned color handled
                if (lobjBanned.Status.ToString().ToUpper().Trim() == "RELEASE")//Release color handled
                {
                    lobjBanned.StatusColor = "#5bc0de";
                }
                if (lobjBanned.Status.ToString().ToUpper().Trim() == "BANNED")//Release color handled
                {
                    lobjBanned.StatusColor = "#d9534f";// Banned color handled
                }
                llstResult.Add(lobjBanned);

            }
            return llstResult;

        }
        public List<clsBannedtrucksBanType> getBannedTrucksFilterBanTypeList(string fstrTransporterGkey, string fstrAPIToken)
        {
            // https://localhost:44348/api/DataSource/getBannedTruckTypeOfBanFilter?fstrAPIToken&fstrFilter=TransporterGkey:5134557409;
            List<clsBannedtrucksBanType> llstResult = new List<clsBannedtrucksBanType>();
            string lstrApiName = "getBannedTruckTypeOfBanFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            string fstrFilter = "TransporterGkey:" + fstrTransporterGkey + "";

            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsBannedtrucksBanType lobjFilter = new clsBannedtrucksBanType();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }
        public List<clsBannedtrucksBanReason> getBannedTrucksFilterBanReasonList(string fstrTransporterGkey, string fstrAPIToken)
        {
            // https://localhost:44348/api/DataSource/getBannedTruckReasonFilter?fstrAPIToken&fstrFilter=TransporterGkey:5134557409;
            List<clsBannedtrucksBanReason> llstResult = new List<clsBannedtrucksBanReason>();
            string lstrApiName = "getBannedTruckReasonFilter";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrAPIToken", "");
            string fstrFilter = "TransporterGkey:" + fstrTransporterGkey + "";

            lobjInParams.Add("fstrFilter", fstrFilter);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjFilterRow in lobjApiData)
            {
                // if (lintIndex > 10) break;
                // Info object
                clsBannedtrucksBanReason lobjFilter = new clsBannedtrucksBanReason();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjFilterRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "text":
                            lobjFilter.text = strColumnValue;
                            break;


                        case "value":
                            lobjFilter.value = strColumnValue;
                            break;



                    }

                }

                llstResult.Add(lobjFilter);

            }
            return llstResult;

        }








        public List<ReadytodeliverDt> getReadyToDeliveryDetails(string fstrRegisterEmailID, int fstrPageNumber, int fstrPageSize, string fstrFilter)
        {

            List<ReadytodeliverDt> llstResult = new List<ReadytodeliverDt>();
            string lstrApiName = "getReadyToDeliveryDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            lobjInParams.Add("fstrPageNumber", fstrPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fstrPageSize.ToString());
            if (fstrFilter != "")
            {
                lobjInParams.Add("fstrFilter", fstrFilter);
            }

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBayanRow in lobjApiData)
            {
                // Info object
                ReadytodeliverDt lobjReadytodelivery = new ReadytodeliverDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBayanRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();



                    switch (strColumnName)
                    {
                        case "cd_containernumber":
                            lobjReadytodelivery.ContainerNo = strColumnValue;
                            break;
                        case "cd_size":
                            lobjReadytodelivery.Size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjReadytodelivery.Bayan = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjReadytodelivery.BOL = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjReadytodelivery.POD = strColumnValue;
                            break;
                        case "cd_statuscode":
                            lobjReadytodelivery.StatusCode = strColumnValue;
                            break;

                        case "cd_shipperdesc1":
                            lobjReadytodelivery.Carrier = strColumnValue;
                            break;

                        case "cd_vesselname1":
                            lobjReadytodelivery.Vessel = strColumnValue;
                            break;
                        case "cd_obvoyage":
                            lobjReadytodelivery.Voyage = strColumnValue;
                            break;
                        case "cd_category":
                            lobjReadytodelivery.Category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjReadytodelivery.Freightkind = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjReadytodelivery.POL = strColumnValue;
                            break;
                        case "cd_statusdesc1":
                            if (App.gblLanguage == "En")
                            {
                                lobjReadytodelivery.Status = strColumnValue;
                            }

                            break;
                        case "cd_statusdesc2":
                            if (App.gblLanguage == "Ar")
                            {
                                lobjReadytodelivery.Status = strColumnValue;
                            }

                            break;


                        case "cd_fmtdiscrecivaltime":
                            lobjReadytodelivery.TimeIn = strColumnValue;
                            break;


                    }
                    lobjReadytodelivery.AnywhereAll += strColumnValue;
                }
                lobjReadytodelivery.StatusColor = "#5bc0de"; // unpaid color handled
                if (lobjReadytodelivery.StatusCode == "103")//PAID color handled
                {
                    lobjReadytodelivery.StatusColor = "#5cb85c";
                }
                if (lobjReadytodelivery.StatusCode == "101")
                {
                    lobjReadytodelivery.StatusColor = "#777";
                }
                if (lobjReadytodelivery.StatusCode == "102")
                {
                    lobjReadytodelivery.StatusColor = "#5bc0de";
                }
                if (lobjReadytodelivery.StatusCode == "100")
                {
                    lobjReadytodelivery.StatusColor = "#5bc0de";
                }




                llstResult.Add(lobjReadytodelivery);

            }
            return llstResult;

        }


        public List<clsBookformanualinspection> getBookforManualInspectionDetails(string fstrRegisterEmailID)
        {

            List<clsBookformanualinspection> llstResult = new List<clsBookformanualinspection>();
            string lstrApiName = "getBookforManualInspectionDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBookManualRow in lobjApiData)
            {
                // Info object
                clsBookformanualinspection lobjBookManual = new clsBookformanualinspection();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBookManualRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "hl_appliedtime":
                            lobjBookManual.hl_appliedtime = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjBookManual.cd_containernumber = strColumnValue;
                            break;
                        case "cd_size":
                            lobjBookManual.cd_size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjBookManual.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjBookManual.cd_blnumber = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjBookManual.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            lobjBookManual.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_shipperdesc2":
                            lobjBookManual.cd_shipperdesc2 = strColumnValue;
                            break;
                        case "cd_vesselvisitgkey":
                            lobjBookManual.cd_vesselvisitgkey = strColumnValue;
                            break;
                        case "cd_vesselvisitid":
                            lobjBookManual.cd_vesselvisitid = strColumnValue;
                            break;
                        case "cd_vesselname1":
                            lobjBookManual.cd_vesselname1 = strColumnValue;
                            break;
                        case "cd_vesselname2":
                            lobjBookManual.cd_vesselname2 = strColumnValue;
                            break;
                        case "cd_obvoyage":
                            lobjBookManual.cd_obvoyage = strColumnValue;
                            break;
                        case "cd_category":
                            lobjBookManual.cd_category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjBookManual.cd_freightkind = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjBookManual.cd_portofloading = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjBookManual.cd_portofdischarge = strColumnValue;
                            break;
                        case "cd_transitstatus":
                            lobjBookManual.cd_transitstatus = strColumnValue;
                            break;
                        case "cd_statuscode":
                            lobjBookManual.cd_statuscode = strColumnValue;
                            break;
                        case "cd_statusdesc1":
                            lobjBookManual.cd_statusdesc1 = strColumnValue;
                            break;
                        case "cd_statusdesc2":
                            lobjBookManual.cd_statusdesc2 = strColumnValue;
                            break;
                        case "cd_discrecivaltime":
                            lobjBookManual.cd_discrecivaltime = strColumnValue;
                            break;
                        case "cd_custombrokeragent":
                            lobjBookManual.cd_custombrokeragent = strColumnValue;
                            break;
                        case "cd_addtionalstatus":
                            lobjBookManual.cd_addtionalstatus = strColumnValue;
                            break;
                        case "hl_fmtappliedtime":
                            lobjBookManual.hl_fmtappliedtime = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjBookManual.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_platenbr":
                            lobjBookManual.cd_platenbr = strColumnValue;
                            break;
                        case "cd_truckgkey":
                            lobjBookManual.cd_truckgkey = strColumnValue;
                            break;
                        case "cd_truckcogkey":
                            lobjBookManual.cd_truckcogkey = strColumnValue;
                            break;


                    }

                }
                llstResult.Add(lobjBookManual);

            }
            return llstResult;

        }



        public List<clsBannedtrucks> getBannedTrucksDetails(string fstrRegisterEmailID)
        {
            List<clsBannedtrucks> llstResult = new List<clsBannedtrucks>();
            string lstrApiName = "getBannedTrucksDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjBannedRow in lobjApiData)
            {
                // Info object
                clsBannedtrucks lobjBanned = new clsBannedtrucks();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjBannedRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "bant_truckno":
                            lobjBanned.bant_truckno = strColumnValue;
                            break;
                        case "bant_bandate":
                            lobjBanned.bant_bandate = strColumnValue;
                            break;
                        case "bant_fmtbandate":
                            lobjBanned.bant_fmtbandate = strColumnValue;
                            break;
                        case "bant_typeofban":
                            lobjBanned.bant_typeofban = strColumnValue;
                            break;
                        case "bant_reason":
                            lobjBanned.bant_reason = strColumnValue;
                            break;
                        case "bant_status":
                            lobjBanned.bant_status = strColumnValue;
                            break;
                        case "bant_action":
                            lobjBanned.bant_action = strColumnValue;
                            break;
                        case "bant_transportergkey":
                            lobjBanned.bant_transportergkey = strColumnValue;
                            break;
                        case "bant_releaserequestdatetime":
                            lobjBanned.bant_releaserequestdatetime = strColumnValue;
                            break;
                        case "bant_requestnotes":
                            lobjBanned.bant_requestnotes = strColumnValue;
                            break;
                        case "bant_createddate":
                            lobjBanned.bant_createddate = strColumnValue;
                            break;
                        case "bant_modifieddate":
                            lobjBanned.bant_modifieddate = strColumnValue;
                            break;



                    }

                }
                llstResult.Add(lobjBanned);

            }
            return llstResult;

        }

        public List<clsEmptyreturn> getEmptyReturnDetails(string fstrRegisterEmailID)
        {

            List<clsEmptyreturn> llstResult = new List<clsEmptyreturn>();
            string lstrApiName = "getEmptyReturnDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjEmptyreturnRow in lobjApiData)
            {
                // Info object
                clsEmptyreturn lobjEmptyreturn = new clsEmptyreturn();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjEmptyreturnRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_shipperdesc1":
                            lobjEmptyreturn.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjEmptyreturn.cd_containernumber = strColumnValue;
                            break;
                        case "cd_size":
                            lobjEmptyreturn.cd_size = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjEmptyreturn.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjEmptyreturn.cd_blnumber = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjEmptyreturn.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_detention":
                            lobjEmptyreturn.cd_detention = strColumnValue;
                            break;
                        case "cd_fmtdetention":
                            lobjEmptyreturn.cd_fmtdetention = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjEmptyreturn.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjEmptyreturn.cd_transporter = strColumnValue;
                            break;
                        case "cd_statuscode":
                            lobjEmptyreturn.cd_statuscode = strColumnValue;
                            break;
                        case "cd_gatedouttime":
                            lobjEmptyreturn.cd_gatedouttime = strColumnValue;
                            break;
                        case "cd_platenbr":
                            lobjEmptyreturn.cd_platenbr = strColumnValue;
                            break;
                        case "cd_truckgkey":
                            lobjEmptyreturn.cd_truckgkey = strColumnValue;
                            break;
                        case "cd_truckcogkey":
                            lobjEmptyreturn.cd_truckcogkey = strColumnValue;
                            break;


                    }

                }
                llstResult.Add(lobjEmptyreturn);

            }
            return llstResult;

        }

        //2021/12/31
        public List<clsWallat> getWalletDetails(string fstrRegisterEmailID)
        {
            List<clsWallat> llstResult = new List<clsWallat>();
            string lstrApiName = "getWalletDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjwalletRow in lobjApiData)
            {
                // Info object
                clsWallat lobjWallet = new clsWallat();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjwalletRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "wt_recid":
                            //  lobjWallet.wt_recid = strColumnValue;
                            break;
                        case "wt_ruemailid":
                            lobjWallet.wt_ruemailid = strColumnValue;
                            break;
                        case "wt_trndate":
                            lobjWallet.wt_trndate = strColumnValue;
                            break;
                        case "fmt_trndate":
                            lobjWallet.fmt_trndate = strColumnValue;
                            break;
                        case "fmt_trndatetime":
                            lobjWallet.fmt_trndatetime = strColumnValue;
                            break;
                        case "wt_trntype":
                            lobjWallet.wt_trntype = strColumnValue;
                            break;
                        case "wt_trnamount":
                            lobjWallet.wt_trnamount = strColumnValue;
                            break;
                        case "fmt_trnamountdec":
                            //  lobjWallet.fmt_trnamountdec = strColumnValue;
                            break;
                        case "fmt_trnamount":
                            lobjWallet.fmt_trnamount = strColumnValue;
                            break;
                        case "wt_invoiceno":
                            lobjWallet.wt_invoiceno = strColumnValue;
                            break;
                        case "wt_blnumber":
                            lobjWallet.wt_blnumber = strColumnValue;
                            break;
                        case "wt_rufirstname":
                            lobjWallet.wt_rufirstname = strColumnValue;
                            break;
                        case "wt_payref":
                            lobjWallet.wt_payref = strColumnValue;
                            break;
                        case "wt_proformainvoiceno":
                            lobjWallet.wt_proformainvoiceno = strColumnValue;
                            break;
                        case "wt_status":
                            lobjWallet.wt_status = strColumnValue;
                            break;



                    }

                }
                llstResult.Add(lobjWallet);

            }
            return llstResult;

        }

        public List<clsEmailnotifications> getNotificationEmailUser(string fstrRegisterEmailID)
        {
            List<clsEmailnotifications> llstResult = new List<clsEmailnotifications>();
            string lstrApiName = "getNodificationEmailUser";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjEmailNotRow in lobjApiData)
            {
                // Info object
                clsEmailnotifications lobjMailnotfy = new clsEmailnotifications();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjEmailNotRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "smt_code":
                            lobjMailnotfy.smt_code = strColumnValue;
                            break;
                        case "smt_categorycode":
                            lobjMailnotfy.smt_categorycode = strColumnValue;
                            break;
                        case "smt_categorydesc1":
                            lobjMailnotfy.smt_categorydesc1 = strColumnValue;
                            break;
                        case "smt_categorydesc2":
                            lobjMailnotfy.smt_categorydesc2 = strColumnValue;
                            break;
                        case "smt_subject1":
                            lobjMailnotfy.smt_subject1 = strColumnValue;
                            break;
                        case "smt_subject2":
                            lobjMailnotfy.smt_subject2 = strColumnValue;
                            break;
                        case "smm_tomailid":
                            lobjMailnotfy.smm_tomailid = strColumnValue;
                            break;
                        case "smm_sentdt":
                            lobjMailnotfy.smm_sentdt = strColumnValue;
                            break;
                        case "smm_message1":
                            lobjMailnotfy.smm_message1 = strColumnValue;
                            break;
                        case "smm_message2":
                            lobjMailnotfy.smm_message2 = strColumnValue;
                            break;
                        case "smm_displaysentdt":
                            lobjMailnotfy.smm_displaysentdt = strColumnValue;
                            break;
                            //case "smm_fmtdisplaysentdt":
                            //    lobjMailnotfy.smm_fmtdisplaysentdt = strColumnValue;
                            //    break;

                    }

                }
                llstResult.Add(lobjMailnotfy);

            }
            return llstResult;

        }

        public List<clsSMSNotifications> getNotificationSmsUser(string fstrMobNo)
        {
            List<clsSMSNotifications> llstResult = new List<clsSMSNotifications>();
            string lstrApiName = "getNodificationSmsUser";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMobileNo", fstrMobNo);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjsmsNotyRow in lobjApiData)
            {
                // Info object
                clsSMSNotifications lobjsmsnotify = new clsSMSNotifications();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjsmsNotyRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "sst_categorycode":
                            lobjsmsnotify.sst_categorycode = strColumnValue;
                            break;
                        case "sst_categorydesc1":
                            lobjsmsnotify.sst_categorydesc1 = strColumnValue;
                            break;
                        case "sst_categorydesc2":
                            lobjsmsnotify.sst_categorydesc2 = strColumnValue;
                            break;
                        case "sm_mobileno":
                            lobjsmsnotify.sm_mobileno = strColumnValue;
                            break;
                        case "sm_message1":
                            lobjsmsnotify.sm_message1 = strColumnValue;
                            break;
                        case "sm_message2":
                            lobjsmsnotify.sm_message2 = strColumnValue;
                            break;
                        case "sm_displaysentdt":
                            lobjsmsnotify.sm_displaysentdt = strColumnValue;
                            break;
                        case "sm_sentdt":
                            lobjsmsnotify.sm_sentdt = strColumnValue;
                            break;
                        case "sm_fmtdisplaysentdt":
                            // lobjsmsnotify.sm_fmtdisplaysentdt = strColumnValue;
                            break;
                    }

                }
                llstResult.Add(lobjsmsnotify);

            }
            return llstResult;

        }

        public List<clsUsersDetails> getUserDetails(string fstrRegisterEmailID)
        {
            List<clsUsersDetails> llstResult = new List<clsUsersDetails>();
            string lstrApiName = "getUserDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjuserRow in lobjApiData)
            {
                // Info object
                clsUsersDetails lobjuser = new clsUsersDetails();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjuserRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "u_recid":
                            lobjuser.u_recid = strColumnValue;
                            break;
                        case "u_grpid":
                            lobjuser.u_grpid = strColumnValue;
                            break;
                        case "u_code":
                            lobjuser.u_code = strColumnValue;
                            break;
                        case "u_name1":
                            lobjuser.u_name1 = strColumnValue;
                            break;
                        case "u_name2":
                            lobjuser.u_name2 = strColumnValue;
                            break;
                        case "u_pwd":
                            lobjuser.u_pwd = strColumnValue;
                            break;
                        case "u_language":
                            lobjuser.u_language = strColumnValue;
                            break;
                        case "u_email":
                            lobjuser.u_email = strColumnValue;
                            break;
                        case "u_mobile":
                            lobjuser.u_mobile = strColumnValue;
                            break;
                        case "u_disable":
                            lobjuser.u_disable = strColumnValue;
                            break;
                        case "u_sec":
                            lobjuser.u_sec = strColumnValue;
                            break;
                        case "u_comm1":
                            lobjuser.u_comm1 = strColumnValue;
                            break;
                        case "u_comm2":
                            lobjuser.u_comm2 = strColumnValue;
                            break;
                        case "g_recid":
                            //  lobjuser.g_recid = strColumnValue;
                            break;
                        case "g_name1":
                            lobjuser.g_name1 = strColumnValue;
                            break;
                        case "g_name2":
                            lobjuser.g_name2 = strColumnValue;
                            break;
                        case "g_code":
                            lobjuser.g_code = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjuser);

            }
            return llstResult;

        }

        public List<clsCMSMaildetail> getCmsMailDetails(string fstrRegisterEmailID)
        {
            List<clsCMSMaildetail> llstResult = new List<clsCMSMaildetail>();
            string lstrApiName = "getCmsMailDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjmailRow in lobjApiData)
            {
                // Info object
                clsCMSMaildetail lobjMail = new clsCMSMaildetail();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjmailRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "smm_recid":
                            // lobjMail.smm_recid = strColumnValue;
                            break;
                        case "smm_smtrecid":
                            // lobjMail.smm_smtrecid = strColumnValue;
                            break;
                        case "smm_rurecid":
                            // lobjMail.smm_rurecid = strColumnValue;
                            break;
                        case "smm_curecid":
                            // lobjMail.smm_curecid = strColumnValue;
                            break;
                        case "smm_sbrecid":
                            // lobjMail.smm_sbrecid = strColumnValue;
                            break;
                        case "smm_code":
                            lobjMail.smm_code = strColumnValue;
                            break;
                        case "smm_tomailid":
                            lobjMail.smm_tomailid = strColumnValue;
                            break;
                        case "smm_subject1":
                            lobjMail.smm_subject1 = strColumnValue;
                            break;
                        case "smm_subject2":
                            lobjMail.smm_subject2 = strColumnValue;
                            break;
                        case "smm_message1":
                            lobjMail.smm_message1 = strColumnValue;
                            break;
                        case "smm_message2":
                            lobjMail.smm_message2 = strColumnValue;
                            break;
                        case "smm_attachment":
                            //lobjMail.smm_attachment = strColumnValue;
                            break;
                        case "smm_senderemailid":
                            lobjMail.smm_senderemailid = strColumnValue;
                            break;
                        case "smm_displayname1":
                            lobjMail.smm_displayname1 = strColumnValue;
                            break;
                        case "smm_displayname2":
                            lobjMail.smm_displayname2 = strColumnValue;
                            break;
                        case "smm_scheduleddt":
                            //  lobjMail.smm_scheduleddt = strColumnValue;
                            break;
                        case "smm_sentdt":
                            // lobjMail.smm_sentdt = strColumnValue;
                            break;
                        case "smm_status":
                            lobjMail.smm_status = strColumnValue;
                            break;
                        case "smm_statusmessage":
                            lobjMail.smm_statusmessage = strColumnValue;
                            break;
                        case "smm_type":
                            lobjMail.smm_type = strColumnValue;
                            break;
                        case "smm_displaysentdt":
                            lobjMail.smm_displaysentdt = strColumnValue;
                            break;
                        case "smt_emailcc":
                            lobjMail.smt_emailcc = strColumnValue;
                            break;
                        case "smt_recid":
                            //  lobjMail.smt_recid = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjMail);

            }
            return llstResult;

        }

        public List<clsCMSSMSDetail> getCmsSmsDetails(string fstrRegisterEmailID)
        {
            List<clsCMSSMSDetail> llstResult = new List<clsCMSSMSDetail>();
            string lstrApiName = "getCmsSmsDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjsmsRow in lobjApiData)
            {
                // Info object
                clsCMSSMSDetail lobjsms = new clsCMSSMSDetail();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjsmsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "sm_recid":
                            // lobjsms.sm_recid = strColumnValue;
                            break;
                        case "sm_sstrecid":
                            // lobjsms.sm_sstrecid = strColumnValue;
                            break;
                        case "sm_rurecid":
                            //  lobjsms.sm_rurecid = strColumnValue;
                            break;
                        case "sm_curecid":
                            //  lobjsms.sm_curecid = strColumnValue;
                            break;
                        case "sm_sbrecid":
                            //  lobjsms.sm_sbrecid = strColumnValue;
                            break;
                        case "sm_code":
                            lobjsms.sm_code = strColumnValue;
                            break;
                        case "sm_mobileno":
                            lobjsms.sm_mobileno = strColumnValue;
                            break;
                        case "sm_message1":
                            lobjsms.sm_message1 = strColumnValue;
                            break;
                        case "sm_message2":
                            lobjsms.sm_message2 = strColumnValue;
                            break;
                        case "sm_query":
                            lobjsms.sm_query = strColumnValue;
                            break;
                        case "sm_mobilefield1":
                            lobjsms.sm_mobilefield1 = strColumnValue;
                            break;
                        case "sm_mobilefield2":
                            lobjsms.sm_mobilefield2 = strColumnValue;
                            break;
                        case "sm_mobilefield3":
                            lobjsms.sm_mobilefield3 = strColumnValue;
                            break;
                        case "sm_comm1":
                            lobjsms.sm_comm1 = strColumnValue;
                            break;
                        case "sm_comm2":
                            lobjsms.sm_comm2 = strColumnValue;
                            break;
                        case "sm_scheduleddt":
                            // lobjsms.sm_scheduleddt = strColumnValue;
                            break;
                        case "sm_sentdt":
                            // lobjsms.sm_sentdt = strColumnValue;
                            break;
                        case "sm_status":
                            lobjsms.sm_status = strColumnValue;
                            break;
                        case "sm_statusmessage":
                            lobjsms.sm_statusmessage = strColumnValue;
                            break;
                        case "sm_type":
                            lobjsms.sm_type = strColumnValue;
                            break;
                        case "sm_displaysentdt":
                            lobjsms.sm_displaysentdt = strColumnValue;
                            break;


                    }

                }
                llstResult.Add(lobjsms);

            }
            return llstResult;

        }

        public List<clsRegisterapplications> getRegisterAppDetails(string fstrRegisterEmailID)
        {
            List<clsRegisterapplications> llstResult = new List<clsRegisterapplications>();
            string lstrApiName = "getRegisterApplicationDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjRegRow in lobjApiData)
            {
                // Info object
                clsRegisterapplications lobjRegApp = new clsRegisterapplications();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjRegRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ra_recid":
                            //lobjRegApp.ra_recid = strColumnValue;
                            break;
                        case "ra_applicationname":
                            lobjRegApp.ra_applicationname = strColumnValue;
                            break;
                        case "ra_pocname":
                            lobjRegApp.ra_pocname = strColumnValue;
                            break;
                        case "ra_pocmobile":
                            lobjRegApp.ra_pocmobile = strColumnValue;
                            break;
                        case "ra_pocemail":
                            lobjRegApp.ra_pocemail = strColumnValue;
                            break;
                        case "ra_acname":
                            lobjRegApp.ra_acname = strColumnValue;
                            break;
                        case "ra_acmobile":
                            lobjRegApp.ra_acmobile = strColumnValue;
                            break;
                        case "ra_acemail":
                            lobjRegApp.ra_acemail = strColumnValue;
                            break;
                        case "ra_requestpageurl":
                            lobjRegApp.ra_requestpageurl = strColumnValue;
                            break;
                        case "ra_landingpageurl":
                            lobjRegApp.ra_landingpageurl = strColumnValue;
                            break;
                        case "ra_ssourl":
                            lobjRegApp.ra_ssourl = strColumnValue;
                            break;
                        case "ra_expiryapplicable":
                            lobjRegApp.ra_expiryapplicable = strColumnValue;
                            break;
                        case "ra_expirydate":
                            lobjRegApp.ra_expirydate = strColumnValue;
                            break;
                        case "ra_licensekey":
                            lobjRegApp.ra_licensekey = strColumnValue;
                            break;
                        case "ra_fmtexpirydate":
                            lobjRegApp.ra_fmtexpirydate = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjRegApp);

            }
            return llstResult;

        }

        public List<clsAppointmentcardview> getAppoinmentCardview(string fstrRegisterEmailID)
        {
            List<clsAppointmentcardview> llstResult = new List<clsAppointmentcardview>();
            string lstrApiName = "getAppoinmentDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjAppointmentRow in lobjApiData)
            {
                // Info object
                clsAppointmentcardview lobjAppointment = new clsAppointmentcardview();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjAppointmentRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    //switch (strColumnName)
                    //{
                    //    //    case "bant_truckno":
                    //    //        lobjBanned.bant_truckno = strColumnValue;
                    //    //        break;
                    //    //    case "bant_bandate":
                    //    //        lobjBanned.bant_bandate = strColumnValue;
                    //    //        break;
                    //}

                }
                llstResult.Add(lobjAppointment);

            }
            return llstResult;

        }

        public List<clsVesselArrival> getVesselArrivalDetails(int fintPageSize, int fintPageNum, string fstrFilter)
        {
            List<clsVesselArrival> llstResult = new List<clsVesselArrival>();
            string lstrApiName = "getVesselArrivalDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            if (fstrFilter == null) fstrFilter = "";
            lobjInParams.Add("fstrPageNumber", fintPageNum.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
            lobjInParams.Add("fstrFilter", fstrFilter.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                clsVesselArrival lobjVessel = new clsVesselArrival();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "vd_vgkey":
                            lobjVessel.vd_vgkey = strColumnValue;
                            break;
                        case "vd_gkey":
                            lobjVessel.vd_gkey = strColumnValue;
                            break;
                        case "vd_visitid":
                            lobjVessel.vd_visitid = strColumnValue;
                            break;
                        case "vd_vesselname1":
                            lobjVessel.vd_vesselname1 = strColumnValue;
                            break;
                        case "cardview_vesselname":
                            lobjVessel.cardview_vesselname = strColumnValue;
                            break;
                        case "vd_vesselname2":
                            lobjVessel.vd_vesselname2 = strColumnValue;
                            break;
                        case "vd_ibvoyage":
                            lobjVessel.vd_ibvoyage = strColumnValue;
                            break;
                        case "vd_obvoyage":
                            lobjVessel.vd_obvoyage = strColumnValue;
                            break;
                        case "vd_serviceid":
                            lobjVessel.vd_serviceid = strColumnValue;
                            break;
                        case "vd_expectedtimeofarrival":
                            lobjVessel.vd_expectedtimeofarrival = strColumnValue;
                            break;
                        case "vd_fmtexpectedtimeofarrival":
                            lobjVessel.vd_fmtexpectedtimeofarrival = strColumnValue;
                            break;
                        case "vd_expectedtimeofdeparture":
                            lobjVessel.vd_expectedtimeofdeparture = strColumnValue;
                            break;
                        case "vd_fmtexpectedtimeofdeparture":
                            lobjVessel.vd_fmtexpectedtimeofdeparture = strColumnValue;
                            break;
                        case "vd_actualtimeofarrival":
                            lobjVessel.vd_actualtimeofarrival = strColumnValue;
                            break;
                        case "vd_startwork":
                            lobjVessel.vd_startwork = strColumnValue;
                            break;
                        case "vd_endwork":
                            lobjVessel.vd_endwork = strColumnValue;
                            break;
                        case "vd_fmtactualtimeofarrival":
                            lobjVessel.vd_fmtactualtimeofarrival = strColumnValue;
                            break;
                        case "vd_actualtimeofdeparture":
                            lobjVessel.vd_actualtimeofdeparture = strColumnValue;
                            break;
                        case "vd_fmtactualtimeofdeparture":
                            lobjVessel.vd_fmtactualtimeofdeparture = strColumnValue;
                            break;
                        case "vd_cargocutofftime":
                            lobjVessel.vd_cargocutofftime = strColumnValue;
                            break;
                        case "vd_fmtcargocutofftime":
                            lobjVessel.vd_fmtcargocutofftime = strColumnValue;
                            break;
                        case "vd_visitstatus":
                            lobjVessel.vd_visitstatus = strColumnValue;
                            break;
                        case "vd_vsloperator":
                            lobjVessel.vd_vsloperator = strColumnValue;
                            break;
                        case "vd_createddate":
                            lobjVessel.vd_createddate = strColumnValue;
                            break;
                        case "vd_lastmodifieddate":
                            lobjVessel.vd_lastmodifieddate = strColumnValue;
                            break;
                        case "vd_vesselstatus":
                            lobjVessel.vd_vesselstatus = strColumnValue;
                            break;
                        case "vd_vsloperatorname":
                            lobjVessel.vd_vsloperatorname = strColumnValue;
                            break;
                        case "vd_shippinglineimage":
                            lobjVessel.vd_shippinglineimage = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjVessel);

            }
            return llstResult;

        }

        public List<InportDtlist> getVesselScheduleDetails(int fstrPageSize, int fstrPageNumber, string fstrFilter, string fstrOrigin)
        {
            List<clsInportport> llstResult1 = new List<clsInportport>();
            List<InportDtlist> llstResult = new List<InportDtlist>();
            if (fstrFilter == null) fstrFilter = "";
            string lstrApiName = "getVesselScheduleDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrPageNumber", fstrPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fstrPageSize.ToString());
            lobjInParams.Add("fstrFilter", fstrFilter.ToString());
            lobjInParams.Add("fstrOrigin", fstrOrigin.ToString().ToUpper());

            IEnumerable<Object> lobjApiData;
            //Web api calling using Helper Folder to added WebApimethod.cs 
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                clsInportport lobjVesselInport = new clsInportport();

                InportDtlist lobjInport = new InportDtlist();
                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "vd_visitid":
                            lobjInport.Visitid = strColumnValue;
                            break;
                        case "vd_ibvoyage":
                            lobjInport.Voyage = strColumnValue;
                            break;
                        case "vd_vesselname1":
                            lobjInport.Vesselname = strColumnValue;
                            break;
                        case "vd_serviceid":
                            lobjInport.Serviceid = strColumnValue;
                            break;
                        case "vd_fmtcargocutofftime": //vd_fmtcargocutofftime   //vd_cargocutofftime
                            lobjInport.Cargocutofftime = strColumnValue;
                            break;
                        case "vd_visitstatus":
                            lobjInport.Statusin = strColumnValue;
                            lobjInport.Statuscolor = "#5cb85c";
                            if (strColumnValue.Trim().ToUpper() == "COMPLETED")//DEPARTURE,  INPORT, ARRIVAL
                            {
                                lobjInport.Statuscolor = "#dd7581";

                            }
                            break;
                        case "vd_shippinglineimage":
                            lobjInport.Vesselicon = strColumnValue;
                            break;
                        case "vd_vesselstage":
                            lobjInport.scheduleType = strColumnValue;
                            if (strColumnValue.Trim().ToUpper() == "DEPARTURE")//DEPARTURE,  INPORT, ARRIVAL
                            {
                                lobjInport.blDeparture = true;
                            }
                            if (strColumnValue.Trim().ToUpper() == "ARRIVAL")//DEPARTURE,  INPORT, ARRIVAL
                            {
                                lobjInport.blArrival = true;
                            }
                            if (strColumnValue.Trim().ToUpper() == "INPORT")//DEPARTURE,  INPORT, ARRIVAL
                            {
                                lobjInport.blInport = true;
                            }
                            break;
                        case "vd_fmtactualtimeofdeparture":
                            lobjInport.fmtactualtimeofdeparture = strColumnValue;
                            break;
                        case "vd_fmtexpectedtimeofarrival":
                            lobjInport.fmtexpectedtimeofarrival = strColumnValue;
                            break;

                        case "cms_visitid1":
                            lobjInport.CMS_VISITID1 = strColumnValue;
                            break;
                        case "cms_ibvoyage1":
                            lobjInport.CMS_IBVOYAGE1 = strColumnValue;
                            break;
                        case "cms_vesselname1":
                            lobjInport.CMS_VESSELNAME1 = strColumnValue;
                            break;
                        case "cms_serviceid1":
                            lobjInport.CMS_SERVICEID1 = strColumnValue;
                            break;
                        case "cms_fmtcargocutofftime1":
                            lobjInport.CMS_FMTCARGOCUTOFFTIME1 = strColumnValue;
                            break;
                        case "cms_visitstatus1":
                            lobjInport.CMS_VISITSTATUS1 = strColumnValue;
                            break;
                        case "cms_shippinglineimage1":
                            lobjInport.CMS_SHIPPINGLINEIMAGE1 = strColumnValue;
                            break;
                        case "cms_vesselstage1":
                            lobjInport.CMS_VESSELSTAGE1 = strColumnValue;
                            break;
                        case "cms_fmtactualtimeofdeparture1":
                            lobjInport.CMS_FMTACTUALTIMEOFDEPARTURE1 = strColumnValue;
                            break;
                        case "cms_fmtexpectedtimeofarrival1":
                            lobjInport.CMS_FMTEXPECTEDTIMEOFARRIVAL1 = strColumnValue;
                            break;
                        case "cms_visitid2":
                            lobjInport.CMS_VISITID2 = strColumnValue;
                            break;
                        case "cms_ibvoyage2":
                            lobjInport.CMS_IBVOYAGE2 = strColumnValue;
                            break;
                        case "cms_vesselname2":
                            lobjInport.CMS_VESSELNAME2 = strColumnValue;
                            break;
                        case "cms_serviceid2":
                            lobjInport.CMS_SERVICEID2 = strColumnValue;
                            break;
                        case "cms_fmtcargocutofftime2":
                            lobjInport.CMS_FMTCARGOCUTOFFTIME2 = strColumnValue;
                            break;
                        case "cms_visitstatus2":
                            lobjInport.CMS_VISITSTATUS2 = strColumnValue;
                            break;
                        case "cms_shippinglineimage2":
                            lobjInport.CMS_SHIPPINGLINEIMAGE2 = strColumnValue;
                            break;
                        case "cms_vesselstage2":
                            lobjInport.CMS_VESSELSTAGE2 = strColumnValue;
                            break;
                        case "cms_fmtactualtimeofdeparture2":
                            lobjInport.CMS_FMTACTUALTIMEOFDEPARTURE2 = strColumnValue;
                            break;
                        case "cms_fmtexpectedtimeofarrival2":
                            lobjInport.CMS_FMTEXPECTEDTIMEOFARRIVAL2 = strColumnValue;
                            break;
                        case "vd_actualtimeofdeparture":
                            lobjInport.VD_ACTUALTIMEOFDEPARTURE = strColumnValue;
                            break;
                        case "vd_expectedtimeofarrival":
                            lobjInport.VD_EXPECTEDTIMEOFARRIVAL = strColumnValue;
                            break;





                    }

                    lobjInport.AnywhereAll += strColumnValue;
                }

                //  lobjInport.Vesselicon = "maersk.jpg";
                if (App.gblLanguage.ToUpper() == "AR")
                {
                    lobjInport.CMS_VISITID1 = lobjInport.CMS_VISITID2;

                    lobjInport.CMS_IBVOYAGE1 = lobjInport.CMS_IBVOYAGE2;

                    lobjInport.CMS_VESSELNAME1 = lobjInport.CMS_VESSELNAME2;

                    lobjInport.CMS_SERVICEID1 = lobjInport.CMS_SERVICEID2;

                    lobjInport.CMS_FMTCARGOCUTOFFTIME1 = lobjInport.CMS_FMTCARGOCUTOFFTIME2;

                    lobjInport.CMS_VISITSTATUS1 = lobjInport.CMS_VISITSTATUS2;

                    lobjInport.CMS_SHIPPINGLINEIMAGE1 = lobjInport.CMS_SHIPPINGLINEIMAGE2;

                    lobjInport.CMS_VESSELSTAGE1 = lobjInport.CMS_VESSELSTAGE2;

                    lobjInport.CMS_FMTACTUALTIMEOFDEPARTURE1 = lobjInport.CMS_FMTACTUALTIMEOFDEPARTURE2;

                    lobjInport.CMS_FMTEXPECTEDTIMEOFARRIVAL1 = lobjInport.CMS_FMTEXPECTEDTIMEOFARRIVAL2;




                }


                llstResult.Add(lobjInport);

            }
            return llstResult;

        }


        public List<clsInportport> getVesselInportDetailsOld()
        {
            List<clsInportport> llstResult = new List<clsInportport>();
            string lstrApiName = "getVesselInportDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            // lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                clsInportport lobjVesselInport = new clsInportport();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "vd_vgkey":
                            lobjVesselInport.vd_vgkey = strColumnValue;
                            break;
                        case "vd_gkey":
                            lobjVesselInport.vd_gkey = strColumnValue;
                            break;
                        case "vd_visitid":
                            lobjVesselInport.vd_visitid = strColumnValue;
                            break;
                        case "vd_vesselname1":
                            lobjVesselInport.vd_vesselname1 = strColumnValue;
                            break;
                        case "cardview_vesselname":
                            lobjVesselInport.cardview_vesselname = strColumnValue;
                            break;
                        case "vd_vesselname2":
                            lobjVesselInport.vd_vesselname2 = strColumnValue;
                            break;
                        case "vd_ibvoyage":
                            lobjVesselInport.vd_ibvoyage = strColumnValue;
                            break;
                        case "vd_obvoyage":
                            lobjVesselInport.vd_obvoyage = strColumnValue;
                            break;
                        case "vd_serviceid":
                            lobjVesselInport.vd_serviceid = strColumnValue;
                            break;
                        case "vd_expectedtimeofarrival":
                            lobjVesselInport.vd_expectedtimeofarrival = strColumnValue;
                            break;
                        case "vd_fmtexpectedtimeofarrival":
                            lobjVesselInport.vd_fmtexpectedtimeofarrival = strColumnValue;
                            break;
                        case "vd_expectedtimeofdeparture":
                            lobjVesselInport.vd_expectedtimeofdeparture = strColumnValue;
                            break;
                        case "vd_fmtexpectedtimeofdeparture":
                            lobjVesselInport.vd_fmtexpectedtimeofdeparture = strColumnValue;
                            break;
                        case "vd_actualtimeofarrival":
                            lobjVesselInport.vd_actualtimeofarrival = strColumnValue;
                            break;
                        case "vd_startwork":
                            lobjVesselInport.vd_startwork = strColumnValue;
                            break;
                        case "vd_endwork":
                            lobjVesselInport.vd_endwork = strColumnValue;
                            break;
                        case "vd_fmtactualtimeofarrival":
                            lobjVesselInport.vd_fmtactualtimeofarrival = strColumnValue;
                            break;
                        case "vd_actualtimeofdeparture":
                            lobjVesselInport.vd_actualtimeofdeparture = strColumnValue;
                            break;
                        case "vd_fmtactualtimeofdeparture":
                            lobjVesselInport.vd_fmtactualtimeofdeparture = strColumnValue;
                            break;
                        case "vd_cargocutofftime":
                            lobjVesselInport.vd_cargocutofftime = strColumnValue;
                            break;
                        case "vd_fmtcargocutofftime":
                            lobjVesselInport.vd_fmtcargocutofftime = strColumnValue;
                            break;
                        case "vd_visitstatus":
                            lobjVesselInport.vd_visitstatus = strColumnValue;
                            break;
                        case "vd_vsloperator":
                            lobjVesselInport.vd_vsloperator = strColumnValue;
                            break;
                        case "vd_createddate":
                            lobjVesselInport.vd_createddate = strColumnValue;
                            break;
                        case "vd_lastmodifieddate":
                            lobjVesselInport.vd_lastmodifieddate = strColumnValue;
                            break;
                        case "vd_vesselstatus":
                            lobjVesselInport.vd_vesselstatus = strColumnValue;
                            break;
                        case "vd_vsloperatorname":
                            lobjVesselInport.vd_vsloperatorname = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjVesselInport);

            }
            return llstResult;

        }

        public List<clsDeparture> getVesselDepartureDetails(int fintPageSize, int fintPageNumber, string fstrFilter)
        {
            List<clsDeparture> llstResult = new List<clsDeparture>();
            string lstrApiName = "getVesselDepartureDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            if (fstrFilter == null) fstrFilter = "";
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());
            lobjInParams.Add("fstrFilter", fstrFilter.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                clsDeparture lobjVesselDep = new clsDeparture();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "vd_vgkey":
                            lobjVesselDep.vd_vgkey = strColumnValue;
                            break;
                        case "vd_gkey":
                            lobjVesselDep.vd_gkey = strColumnValue;
                            break;
                        case "vd_visitid":
                            lobjVesselDep.vd_visitid = strColumnValue;
                            break;
                        case "vd_vesselname1":
                            lobjVesselDep.vd_vesselname1 = strColumnValue;
                            break;
                        case "vd_vesselname2":
                            lobjVesselDep.vd_vesselname2 = strColumnValue;
                            break;
                        case "vd_ibvoyage":
                            lobjVesselDep.vd_ibvoyage = strColumnValue;
                            break;
                        case "vd_obvoyage":
                            lobjVesselDep.vd_obvoyage = strColumnValue;
                            break;
                        case "vd_serviceid":
                            lobjVesselDep.vd_serviceid = strColumnValue;
                            break;
                        case "vd_expectedtimeofdeparture":
                            lobjVesselDep.vd_expectedtimeofdeparture = strColumnValue;
                            break;
                        case "vd_fmtexpectedtimeofdeparture":
                            lobjVesselDep.vd_fmtexpectedtimeofdeparture = strColumnValue;
                            break;
                        case "vd_actualtimeofarrival":
                            lobjVesselDep.vd_actualtimeofarrival = strColumnValue;
                            break;
                        case "vd_startwork":
                            lobjVesselDep.vd_startwork = strColumnValue;
                            break;
                        case "vd_endwork":
                            lobjVesselDep.vd_endwork = strColumnValue;
                            break;
                        case "vd_fmtactualtimeofarrival":
                            lobjVesselDep.vd_fmtactualtimeofarrival = strColumnValue;
                            break;
                        case "vd_actualtimeofdeparture":
                            lobjVesselDep.vd_actualtimeofdeparture = strColumnValue;
                            break;
                        case "vd_fmtactualtimeofdeparture":
                            lobjVesselDep.vd_fmtactualtimeofdeparture = strColumnValue;
                            break;
                        case "vd_cargocutofftime":
                            lobjVesselDep.vd_cargocutofftime = strColumnValue;
                            break;
                        case "vd_fmtcargocutofftime":
                            lobjVesselDep.vd_fmtcargocutofftime = strColumnValue;
                            break;
                        case "vd_visitstatus":
                            lobjVesselDep.vd_visitstatus = strColumnValue;
                            break;
                        case "vd_vsloperator":
                            lobjVesselDep.vd_vsloperator = strColumnValue;
                            break;
                        case "vd_createddate":
                            lobjVesselDep.vd_createddate = strColumnValue;
                            break;
                        case "vd_lastmodifieddate":
                            lobjVesselDep.vd_lastmodifieddate = strColumnValue;
                            break;
                        case "vd_vesselstatus":
                            lobjVesselDep.vd_vesselstatus = strColumnValue;
                            break;
                        case "vd_vsloperatorname":
                            lobjVesselDep.vd_vsloperatorname = strColumnValue;
                            break;
                        case "vd_shippinglineimage":
                            lobjVesselDep.vd_shippinglineimage = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjVesselDep);

            }
            return llstResult;

        }



        public List<NotificationCountdata> getNotificationCount(string fstrEmailid)
        {
            ////http://172.19.35.68:89/api/DataSource/getNotificationCount?fstrEmailid=cielotransporter1@gmail.com

            List<NotificationCountdata> llstResult = new List<NotificationCountdata>();
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            string lstrApiName = "getNotificationCount";
            lobjInParams.Add("fstrEmailid", fstrEmailid.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                NotificationCountdata lobjNotification = new NotificationCountdata();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "smm_tomailid":
                            lobjNotification.ToEmailId = strColumnValue;
                            break;
                        case "emailcount":
                            lobjNotification.Emailcount = strColumnValue;
                            break;
                        case "smscount":
                            lobjNotification.SMScount = strColumnValue;
                            break;
                        case "bellicon":
                            lobjNotification.BELLICON = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjNotification);

            }
            return llstResult;

        }

        public List<clsNOTIFICATIONEMAILCOUNT> getNotificationEmailCategoryCount(string fstrEmailid)
        {
            ////http://172.19.35.68:89/api/DataSource/getNotificationEmailCategoryCount?fstrEmailid=cielotransporter1@gmail.com

            List<clsNOTIFICATIONEMAILCOUNT> llstResult = new List<clsNOTIFICATIONEMAILCOUNT>();
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            string lstrApiName = "getNotificationEmailCategoryCount";
            lobjInParams.Add("fstrEmailid", fstrEmailid.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                clsNOTIFICATIONEMAILCOUNT lobjNotifiMailcount = new clsNOTIFICATIONEMAILCOUNT();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();


                    switch (strColumnName)
                    {

                        case "smm_tomailid":
                            lobjNotifiMailcount.smm_tomailid = strColumnValue;
                            break;
                        case "smt_categorycode":
                            lobjNotifiMailcount.smt_categorycode = strColumnValue;
                            break;
                        case "smt_categorydesc1":
                            lobjNotifiMailcount.smt_categorydesc1 = strColumnValue;
                            break;
                        case "smt_categorydesc2":
                            lobjNotifiMailcount.smt_categorydesc2 = strColumnValue;
                            break;


                        case "mailcount":
                            lobjNotifiMailcount.mailcount = strColumnValue;
                            break;

                        case "belliconcat":
                            lobjNotifiMailcount.belliconcat = strColumnValue;
                            break;

                    }


                }

                llstResult.Add(lobjNotifiMailcount);

            }
            return llstResult;

        }

        public List<clsNOTIFICATIONMOBILECOUNT> getNotificationMobileCategoryCount(string fstrMobileNo)
        {
            ////http://172.19.35.68:89/api/DataSource/getNotificationMobileCategoryCount?fstrMobileNo=9790857304

            List<clsNOTIFICATIONMOBILECOUNT> llstResult = new List<clsNOTIFICATIONMOBILECOUNT>();
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            string lstrApiName = "getNotificationMobileCategoryCount";
            lobjInParams.Add("fstrMobileNo", fstrMobileNo.ToString());
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                clsNOTIFICATIONMOBILECOUNT lobjNotifiMobilecount = new clsNOTIFICATIONMOBILECOUNT();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();


                    switch (strColumnName)
                    {

                        case "sm_mobileno":
                            lobjNotifiMobilecount.sm_mobileno = strColumnValue;
                            break;
                        case "sst_categorycode":
                            lobjNotifiMobilecount.sst_categorycode = strColumnValue;
                            break;
                        case "sst_categorydesc1":
                            lobjNotifiMobilecount.sst_categorydesc1 = strColumnValue;
                            break;
                        case "sst_categorydesc2":
                            lobjNotifiMobilecount.sst_categorydesc2 = strColumnValue;
                            break;


                        case "msgcount":
                            lobjNotifiMobilecount.msgcount = strColumnValue;
                            break;
                        case "belliconcatsms":
                            lobjNotifiMobilecount.belliconcatsms = strColumnValue;
                            break;

                    }

                }

                llstResult.Add(lobjNotifiMobilecount);

            }
            return llstResult;

        }

        public List<NotificationemailDt> getNodificationEmailUser(string fstrCategoryCode, int fintPageNumber, int fintPageSize)
        {
            //http://172.19.35.68:89/api/DataSource/getNodificationEmailUser?fstrMailID=cielotransporter1@gmail.com&CategoryCode=GE&fstrPageNumber=1&fstrPageSize=100

            List<NotificationemailDt> llstResult = new List<NotificationemailDt>();
            string lstrApiName = "getNodificationEmailUser";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailId", gblRegisteration.strLoginUser);
            lobjInParams.Add("CategoryCode", fstrCategoryCode);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjpaymentRow in lobjApiData)
            {
                // Info object
                NotificationemailDt lobjEmailList = new NotificationemailDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjpaymentRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "smt_subject1":
                            lobjEmailList.messageheading = strColumnValue;
                            break;

                        case "smm_message1":
                            lobjEmailList.Messageinfo = strColumnValue;
                            break;

                        case "smm_displaysentdt":
                            lobjEmailList.Messagetime = strColumnValue;
                            break;
                        case "smm_sentdt":
                            lobjEmailList.Date = strColumnValue;
                            break;







                    }

                }
                lobjEmailList.Sno = lintSLNo;
                llstResult.Add(lobjEmailList);

                lintSLNo++;
            }
            return llstResult;

        }


        public List<NotificationmobileDt> getNodificationSmsUser(string fstrCategoryCode, int fintPageNumber, int fintPageSize)
        {
            //http://172.19.35.68:89/api/DataSource/getNodificationSmsUser?fstrMobileNo=9790857304&CategoryCode=GE&fstrPageNumber=1&fstrPageSize=20

            List<NotificationmobileDt> llstResult = new List<NotificationmobileDt>();
            string lstrApiName = "getNodificationSmsUser";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMobileNo", gblRegisteration.strLoginMobileNO);
            lobjInParams.Add("CategoryCode", fstrCategoryCode);
            lobjInParams.Add("fstrPageNumber", fintPageNumber.ToString());
            lobjInParams.Add("fstrPageSize", fintPageSize.ToString());

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            int lintSLNo = 1;
            foreach (IEnumerable<Object> lobjpaymentRow in lobjApiData)
            {
                // Info object
                NotificationmobileDt lobjMobileList = new NotificationmobileDt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjpaymentRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {


                        case "sm_message1":
                            lobjMobileList.SM_MMessageinfo = strColumnValue;
                            break;



                        case "sm_sentdt":
                            lobjMobileList.SM_MDATE = strColumnValue;
                            break;

                        case "sm_fmtdisplaysentdt":
                            lobjMobileList.SM_MMessagetime = strColumnValue;
                            break;








                    }

                }
                lobjMobileList.SNO = lintSLNo;
                llstResult.Add(lobjMobileList);

                lintSLNo++;
            }
            return llstResult;

        }

        public List<clsMailtemplates> getMailMessage(string fstrRegisterEmailID)
        {
            List<clsMailtemplates> llstResult = new List<clsMailtemplates>();
            string lstrApiName = "getMailMessage";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjMailRow in lobjApiData)
            {
                // Info object
                clsMailtemplates lobjMail = new clsMailtemplates();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjMailRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "smt_recid":
                            //  lobjMail.smt_recid = strColumnValue;
                            break;
                        case "smt_code":
                            lobjMail.smt_code = strColumnValue;
                            break;
                        case "smt_subject1":
                            lobjMail.smt_subject1 = strColumnValue;
                            break;
                        case "smt_subject2":
                            lobjMail.smt_subject2 = strColumnValue;
                            break;
                        case "smt_message1":
                            lobjMail.smt_message1 = strColumnValue;
                            break;
                        case "smt_message2":
                            lobjMail.smt_message2 = strColumnValue;
                            break;
                        case "smt_attachment":
                            lobjMail.smt_attachment = strColumnValue;
                            break;
                        case "smt_senderemailid":
                            lobjMail.smt_senderemailid = strColumnValue;
                            break;
                        case "smt_senderpassword":
                            lobjMail.smt_senderpassword = strColumnValue;
                            break;
                        case "smt_displayname1":
                            lobjMail.smt_displayname1 = strColumnValue;
                            break;
                        case "smt_displayname2":
                            lobjMail.smt_displayname2 = strColumnValue;
                            break;
                        case "smt_query":
                            lobjMail.smt_query = strColumnValue;
                            break;
                        case "smt_emailfield1":
                            lobjMail.smt_emailfield1 = strColumnValue;
                            break;
                        case "smt_emailfield2":
                            lobjMail.smt_emailfield2 = strColumnValue;
                            break;
                        case "smt_emailfield3":
                            lobjMail.smt_emailfield3 = strColumnValue;
                            break;
                        case "smt_comm1":
                            lobjMail.smt_comm1 = strColumnValue;
                            break;
                        case "smt_comm2":
                            lobjMail.smt_comm2 = strColumnValue;
                            break;
                        case "smt_sort":
                            //  lobjMail.smt_sort = strColumnValue;
                            break;
                        case "smt_disable":
                            lobjMail.smt_disable = strColumnValue;
                            break;
                        case "smt_emailcc":
                            lobjMail.smt_emailcc = strColumnValue;
                            break;


                    }

                }
                llstResult.Add(lobjMail);

            }
            return llstResult;

        }

        public List<clsContactUS> getContactUs(string fstrRegisterEmailID)
        {
            List<clsContactUS> llstResult = new List<clsContactUS>();
            string lstrApiName = "getContactUs";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailId", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjMailRow in lobjApiData)
            {
                // Info object
                clsContactUS lobjCont = new clsContactUS();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjMailRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cu_createddate":
                            lobjCont.cu_createddate = Convert.ToInt32(strColumnValue);
                            break;
                        case "cu_createdtime":
                            lobjCont.cu_createdtime = Convert.ToInt32(strColumnValue);
                            break;
                        case "cu_emailid":
                            lobjCont.cu_emailid = strColumnValue;
                            break;
                        case "cu_message1":
                            lobjCont.cu_message1 = strColumnValue;
                            break;
                        case "cu_message2":
                            lobjCont.cu_message2 = strColumnValue;
                            break;
                        case "cu_name1":
                            lobjCont.cu_name1 = strColumnValue;
                            break;
                        case "cu_name2":
                            lobjCont.cu_name2 = strColumnValue;
                            break;
                        case "cu_subject1":
                            lobjCont.cu_subject1 = strColumnValue;
                            break;
                        case "cu_subject2":
                            lobjCont.cu_subject2 = strColumnValue;
                            break;
                    }

                }
                llstResult.Add(lobjCont);

            }
            return llstResult;

        }



        public List<clsSMStemplates> getSmsMessage(string fstrRegisterEmailID)
        {
            List<clsSMStemplates> llstResult = new List<clsSMStemplates>();
            string lstrApiName = "getSmsMessage";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjsmsRow in lobjApiData)
            {
                // Info object
                clsSMStemplates lobjsms = new clsSMStemplates();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjsmsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "sst_recid":
                            //lobjsms.sst_recid = strColumnValue;
                            break;
                        case "sst_code":
                            lobjsms.sst_code = strColumnValue;
                            break;
                        case "sst_message1":
                            lobjsms.sst_message1 = strColumnValue;
                            break;
                        case "sst_message2":
                            lobjsms.sst_message2 = strColumnValue;
                            break;
                        case "sst_query":
                            lobjsms.sst_query = strColumnValue;
                            break;
                        case "sst_mobilefield1":
                            lobjsms.sst_mobilefield1 = strColumnValue;
                            break;
                        case "sst_mobilefield2":
                            lobjsms.sst_mobilefield2 = strColumnValue;
                            break;
                        case "sst_mobilefield3":
                            lobjsms.sst_mobilefield3 = strColumnValue;
                            break;
                        case "sst_comm1":
                            lobjsms.sst_comm1 = strColumnValue;
                            break;
                        case "sst_comm2":
                            lobjsms.sst_comm2 = strColumnValue;
                            break;
                        case "sst_sort":
                            // lobjsms.sst_sort = strColumnValue;
                            break;
                        case "sst_disable":
                            lobjsms.sst_disable = strColumnValue;
                            break;

                    }

                }
                llstResult.Add(lobjsms);

            }
            return llstResult;

        }

        public List<AccountSettings> getAccountSettingDetails(string fstrRegisterEmailID)
        {

            https://portalmobapi.rsgt.com:8443/api/DataSource/getAccountSettings?fstrMailId=TEST@GMAIL.COM
            List<AccountSettings> llstResult = new List<AccountSettings>();
            string lstrApiName = "getAccountSettings";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjAccountSettingRow in lobjApiData)
            {
                // Info object
                AccountSettings lobjAccountSetting = new AccountSettings();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjAccountSettingRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {


                        case "ru_emailid":
                            lobjAccountSetting.ru_emailid = strColumnValue;
                            break;
                        case "ru_defaultlandingpage":
                            lobjAccountSetting.ru_defaultlandingpage = strColumnValue;
                            break;
                        case "ru_language1":
                            lobjAccountSetting.ru_language1 = strColumnValue;
                            break;
                        case "ru_language2":
                            lobjAccountSetting.ru_language2 = strColumnValue;
                            break;
                        case "ru_languagevalue":
                            lobjAccountSetting.ru_languagevalue = strColumnValue;
                            break;
                        case "ru_temperature1":
                            lobjAccountSetting.ru_temperature1 = strColumnValue;
                            break;
                        case "ru_temperature2":
                            lobjAccountSetting.ru_temperature2 = strColumnValue;
                            break;
                        case "ru_temperaturevalue":
                            lobjAccountSetting.ru_temperaturevalue = strColumnValue;
                            break;
                        case "ru_weight1":
                            lobjAccountSetting.ru_weight1 = strColumnValue;
                            break;
                        case "ru_weight2":
                            lobjAccountSetting.ru_weight2 = strColumnValue;
                            break;
                        case "ru_weightvalue":
                            lobjAccountSetting.ru_weightvalue = strColumnValue;
                            break;
                        case "ru_currency1":
                            lobjAccountSetting.ru_currency1 = strColumnValue;
                            break;
                        case "ru_currency2":
                            lobjAccountSetting.ru_currency2 = strColumnValue;
                            break;
                        case "ru_currencyvalue":
                            lobjAccountSetting.ru_currencyvalue = strColumnValue;
                            break;
                    }

                }
                llstResult.Add(lobjAccountSetting);

            }
            return llstResult;

        }

        public class AccountSettings
        {
            public string ru_emailid { get; set; }
            public string ru_defaultlandingpage { get; set; }
            public string ru_monday { get; set; }
            public string ru_tuesday { get; set; }
            public string ru_wednesday { get; set; }
            public string ru_thursday { get; set; }
            public string ru_friday { get; set; }
            public string ru_saturday { get; set; }
            public string ru_sunday { get; set; }
            public string ru_language1 { get; set; }
            public string ru_language2 { get; set; }
            public string ru_languagevalue { get; set; }
            public string ru_currency1 { get; set; }
            public string ru_currency2 { get; set; }
            public string ru_currencyvalue { get; set; }
            public string ru_temperature1 { get; set; }
            public string ru_temperature2 { get; set; }
            public string ru_temperaturevalue { get; set; }
            public string ru_weight1 { get; set; }
            public string ru_weight2 { get; set; }
            public string ru_weightvalue { get; set; }


        }

        public List<clsREGISTEREDUSERS> getRegisterUserDetails(string fstrRegisterEmailID)
        {
            List<clsREGISTEREDUSERS> llstResult = new List<clsREGISTEREDUSERS>();
            string lstrApiName = "getRegisterUserDetails";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjRegsiteUserRow in lobjApiData)
            {
                // Info object
                clsREGISTEREDUSERS lobjRegsiteUser = new clsREGISTEREDUSERS();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjRegsiteUserRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ru_createddate":
                            lobjRegsiteUser.ru_createddate = strColumnValue;
                            break;
                        case "ru_activestatus":
                            lobjRegsiteUser.ru_activestatus = strColumnValue;
                            break;
                        case "ru_recid":
                            lobjRegsiteUser.ru_recid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_firstname1":
                            lobjRegsiteUser.ru_firstname1 = strColumnValue;
                            break;
                        case "ru_firstname2":
                            lobjRegsiteUser.ru_firstname2 = strColumnValue;
                            break;
                        case "ru_lastname1":
                            lobjRegsiteUser.ru_lastname1 = strColumnValue;
                            break;
                        case "ru_lastname2":
                            lobjRegsiteUser.ru_lastname2 = strColumnValue;
                            break;
                        case "ru_cntrecid":
                            lobjRegsiteUser.ru_cntrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_cntcode":
                            lobjRegsiteUser.ru_cntcode = strColumnValue;
                            break;
                        case "ru_cntdesc1":
                            lobjRegsiteUser.ru_cntdesc1 = strColumnValue;
                            break;
                        case "ru_cntdesc2":
                            lobjRegsiteUser.ru_cntdesc2 = strColumnValue;
                            break;
                        case "ru_mobileno":
                            lobjRegsiteUser.ru_mobileno = strColumnValue;
                            break;
                        case "ru_emailid":
                            lobjRegsiteUser.ru_emailid = strColumnValue;
                            break;
                        case "ru_preferredcomm1":
                            lobjRegsiteUser.ru_preferredcomm1 = strColumnValue;
                            break;
                        case "ru_preferredcomm2":
                            lobjRegsiteUser.ru_preferredcomm2 = strColumnValue;
                            break;
                        case "ru_jobtitle1":
                            lobjRegsiteUser.ru_jobtitle1 = strColumnValue;
                            break;
                        case "ru_jobtitle2":
                            lobjRegsiteUser.ru_jobtitle2 = strColumnValue;
                            break;
                        case "ru_jobfunction1":
                            lobjRegsiteUser.ru_jobfunction1 = strColumnValue;
                            break;
                        case "ru_jobfunction2":
                            lobjRegsiteUser.ru_jobfunction2 = strColumnValue;
                            break;
                        case "ru_password":
                            lobjRegsiteUser.ru_password = strColumnValue;
                            break;
                        case "ru_companytype1":
                            lobjRegsiteUser.ru_companytype1 = strColumnValue;
                            break;
                        case "ru_companytype2":
                            lobjRegsiteUser.ru_companytype2 = strColumnValue;
                            break;
                        case "ru_companyname1":
                            lobjRegsiteUser.ru_companyname1 = strColumnValue;
                            break;
                        case "ru_companyname2":
                            lobjRegsiteUser.ru_companyname2 = strColumnValue;
                            break;
                        case "ru_buildingno":
                            lobjRegsiteUser.ru_buildingno = strColumnValue;
                            break;
                        case "ru_unitno":
                            lobjRegsiteUser.ru_unitno = strColumnValue;
                            break;
                        case "ru_streetname1":
                            lobjRegsiteUser.ru_streetname1 = strColumnValue;
                            break;
                        case "ru_streetname2":
                            lobjRegsiteUser.ru_streetname2 = strColumnValue;
                            break;
                        case "ru_districtname1":
                            lobjRegsiteUser.ru_districtname1 = strColumnValue;
                            break;
                        case "ru_districtname2":
                            lobjRegsiteUser.ru_districtname2 = strColumnValue;
                            break;
                        case "ru_ctyrecid":
                            lobjRegsiteUser.ru_ctyrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_ctycode":
                            lobjRegsiteUser.ru_ctycode = strColumnValue;
                            break;
                        case "ru_ctydesc1":
                            lobjRegsiteUser.ru_ctydesc1 = strColumnValue;
                            break;
                        case "ru_ctydesc2":
                            lobjRegsiteUser.ru_ctydesc2 = strColumnValue;
                            break;
                        case "ru_zipcode":
                            lobjRegsiteUser.ru_zipcode = strColumnValue;
                            break;
                        case "ru_additionalno":
                            lobjRegsiteUser.ru_additionalno = strColumnValue;
                            break;
                        case "ru_telephoneno":
                            lobjRegsiteUser.ru_telephoneno = strColumnValue;
                            break;
                        case "ru_fax":
                            lobjRegsiteUser.ru_fax = strColumnValue;
                            break;
                        case "ru_customertype1":
                            lobjRegsiteUser.ru_customertype1 = strColumnValue;
                            break;
                        case "ru_customertype2":
                            lobjRegsiteUser.ru_customertype2 = strColumnValue;
                            break;
                        case "ru_licenseno":
                            lobjRegsiteUser.ru_licenseno = strColumnValue;
                            break;
                        case "ru_idno":
                            lobjRegsiteUser.ru_idno = strColumnValue;
                            break;
                        case "ru_tccheckbox":
                            lobjRegsiteUser.ru_tccheckbox = strColumnValue;
                            break;
                        case "ru_otp":
                            lobjRegsiteUser.ru_otp = strColumnValue;
                            break;
                        case "ru_createdtime":
                            //   lobjRegsiteUser.ru_createdtime = strColumnValue;
                            break;
                        case "ru_nacntrecid":
                            lobjRegsiteUser.ru_nacntrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_nacntcode":
                            lobjRegsiteUser.ru_nacntcode = strColumnValue;
                            break;
                        case "ru_nacntdesc1":
                            lobjRegsiteUser.ru_nacntdesc1 = strColumnValue;
                            break;
                        case "ru_nacntdesc2":
                            lobjRegsiteUser.ru_nacntdesc2 = strColumnValue;
                            break;
                        case "ru_language1":
                            lobjRegsiteUser.ru_language1 = strColumnValue;
                            break;
                        case "ru_language2":
                            lobjRegsiteUser.ru_language2 = strColumnValue;
                            break;
                        case "ru_currency1":
                            lobjRegsiteUser.ru_currency1 = strColumnValue;
                            break;
                        case "ru_currency2":
                            lobjRegsiteUser.ru_currency2 = strColumnValue;
                            break;
                        case "ru_temperature1":
                            lobjRegsiteUser.ru_temperature1 = strColumnValue;
                            break;
                        case "ru_temperature2":
                            lobjRegsiteUser.ru_temperature2 = strColumnValue;
                            break;
                        case "ru_weight1":
                            lobjRegsiteUser.ru_weight1 = strColumnValue;
                            break;
                        case "ru_weight2":
                            lobjRegsiteUser.ru_weight2 = strColumnValue;
                            break;
                        case "ru_sunday":
                            lobjRegsiteUser.ru_sunday = strColumnValue;
                            break;
                        case "ru_monday":
                            lobjRegsiteUser.ru_monday = strColumnValue;
                            break;
                        case "ru_tuesday":
                            lobjRegsiteUser.ru_tuesday = strColumnValue;
                            break;
                        case "ru_wednesday":
                            lobjRegsiteUser.ru_wednesday = strColumnValue;
                            break;
                        case "ru_thursday":
                            lobjRegsiteUser.ru_thursday = strColumnValue;
                            break;
                        case "ru_friday":
                            lobjRegsiteUser.ru_friday = strColumnValue;
                            break;
                        case "ru_saturday":
                            lobjRegsiteUser.ru_saturday = strColumnValue;
                            break;
                        case "ru_apmt12to02":
                            lobjRegsiteUser.ru_apmt12to02 = strColumnValue;
                            break;
                        case "ru_apmt02to04":
                            lobjRegsiteUser.ru_apmt02to04 = strColumnValue;
                            break;
                        case "ru_apmt04to06":
                            lobjRegsiteUser.ru_apmt04to06 = strColumnValue;
                            break;
                        case "ru_apmt06to08":
                            lobjRegsiteUser.ru_apmt06to08 = strColumnValue;
                            break;
                        case "ru_apmt08to10":
                            lobjRegsiteUser.ru_apmt08to10 = strColumnValue;
                            break;
                        case "ru_apmt10to12":
                            lobjRegsiteUser.ru_apmt10to12 = strColumnValue;
                            break;
                        case "ru_apmt12to14":
                            lobjRegsiteUser.ru_apmt12to14 = strColumnValue;
                            break;
                        case "ru_apmt14to16":
                            lobjRegsiteUser.ru_apmt14to16 = strColumnValue;
                            break;
                        case "ru_apmt16to18":
                            lobjRegsiteUser.ru_apmt16to18 = strColumnValue;
                            break;
                        case "ru_apmt18to20":
                            lobjRegsiteUser.ru_apmt18to20 = strColumnValue;
                            break;
                        case "ru_apmt20to22":
                            lobjRegsiteUser.ru_apmt20to22 = strColumnValue;
                            break;
                        case "ru_apmt22to24":
                            lobjRegsiteUser.ru_apmt22to24 = strColumnValue;
                            break;
                        case "ru_licenseno1":
                            lobjRegsiteUser.ru_licenseno1 = strColumnValue;
                            break;
                        case "ru_licenseno2":
                            lobjRegsiteUser.ru_licenseno2 = strColumnValue;
                            break;
                        case "ru_licenseno3":
                            lobjRegsiteUser.ru_licenseno3 = strColumnValue;
                            break;
                        case "ru_licenseno4":
                            lobjRegsiteUser.ru_licenseno4 = strColumnValue;
                            break;
                        case "ru_licenseno5":
                            lobjRegsiteUser.ru_licenseno5 = strColumnValue;
                            break;
                        case "ru_licenseno6":
                            lobjRegsiteUser.ru_licenseno6 = strColumnValue;
                            break;
                        case "ru_licenseno7":
                            lobjRegsiteUser.ru_licenseno7 = strColumnValue;
                            break;
                        case "ru_licenseno8":
                            lobjRegsiteUser.ru_licenseno8 = strColumnValue;
                            break;
                        case "ru_licenseno9":
                            lobjRegsiteUser.ru_licenseno9 = strColumnValue;
                            break;
                        case "ru_defaultlandingpage":
                            lobjRegsiteUser.ru_defaultlandingpage = strColumnValue;
                            break;
                        case "ru_linkcode":
                            lobjRegsiteUser.ru_linkcode = strColumnValue;
                            break;
                        case "ru_note1":
                            lobjRegsiteUser.ru_note1 = strColumnValue;
                            break;
                        case "ru_note2":
                            lobjRegsiteUser.ru_note2 = strColumnValue;
                            break;
                        case "ru_languagevalue":
                            lobjRegsiteUser.ru_languagevalue = strColumnValue;
                            break;
                        case "ru_preferredcommvalue":
                            lobjRegsiteUser.ru_preferredcommvalue = strColumnValue;
                            break;
                        case "ru_jobfunctionvalue":
                            lobjRegsiteUser.ru_jobfunctionvalue = strColumnValue;
                            break;
                        case "ru_companytypevalue":
                            lobjRegsiteUser.ru_companytypevalue = strColumnValue;
                            break;
                        case "ru_customertypevalue":
                            lobjRegsiteUser.ru_customertypevalue = strColumnValue;
                            break;
                        case "ru_currencyvalue":
                            lobjRegsiteUser.ru_currencyvalue = strColumnValue;
                            break;
                        case "ru_temperaturevalue":
                            lobjRegsiteUser.ru_temperaturevalue = strColumnValue;
                            break;
                        case "ru_weightvalue":
                            lobjRegsiteUser.ru_weightvalue = strColumnValue;
                            break;
                        case "ru_walletbalanace":
                            lobjRegsiteUser.ru_walletbalanace = strColumnValue;
                            break;
                        case "ru_crmcontactgkey":
                            lobjRegsiteUser.ru_crmcontactgkey = strColumnValue;
                            break;
                        case "ru_brokerflag":
                            lobjRegsiteUser.ru_brokerflag = strColumnValue;
                            break;
                        case "ru_clearingagentflag":
                            lobjRegsiteUser.ru_clearingagentflag = strColumnValue;
                            break;



                    }

                }
                llstResult.Add(lobjRegsiteUser);

            }
            return llstResult;

        }


        public List<DamageContainerdt> DamageContainerBody(string fstrContainernumber, string fstrBlnumber)
        {
            //https://webgw.rsgt.com:8080/eportal_api/getReportDamageRetreiveContainer?fstrTransporter=5134557409&fstrContainernumber=PCIU1410397&fstrBlnumber=KHI100327600
            List<DamageContainerdt> llstResult = new List<DamageContainerdt>();
            string lstrApiName = "getReportDamageRetreiveContainer";
            string fstrTransporter = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrTransporter", fstrTransporter);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber);
            lobjInParams.Add("fstrBlnumber", fstrBlnumber);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                DamageContainerdt lobjDamageContainer = new DamageContainerdt();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_fmtdiscrecivaltime":
                            lobjDamageContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDamageContainer.cd_fmtgatedouttime = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjDamageContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjDamageContainer.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjDamageContainer.cd_transporter = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDamageContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDamageContainer.cd_blnumber = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDamageContainer);

            }
            return llstResult;

        }


        public List<clsDamageContainers> DamageContainerBodyold(string fstrContainernumber, string fstrBlnumber)
        {
            //https://webgw.rsgt.com:8080/eportal_api/getReportDamageRetreiveContainer?fstrTransporter=5134557409&fstrContainernumber=PCIU1410397&fstrBlnumber=KHI100327600
            List<clsDamageContainers> llstResult = new List<clsDamageContainers>();
            string lstrApiName = "getReportDamageRetreiveContainer";
            string fstrTransporter = gblRegisteration.strLoginUserLinkcode;
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrTransporter", fstrTransporter);
            lobjInParams.Add("fstrContainernumber", fstrContainernumber);
            lobjInParams.Add("fstrBlnumber", fstrBlnumber);

            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);


            foreach (IEnumerable<Object> lobjcontainerHeaderRow in lobjApiData)
            {
                // Info object
                clsDamageContainers lobjDamageContainer = new clsDamageContainers();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjcontainerHeaderRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_fmtdiscrecivaltime":
                            lobjDamageContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_fmtgatedouttime":
                            lobjDamageContainer.cd_fmtgatedouttime = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjDamageContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_damagedetails":
                            lobjDamageContainer.cd_damagedetails = strColumnValue;
                            break;
                        case "cd_transporter":
                            lobjDamageContainer.cd_transporter = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjDamageContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjDamageContainer.cd_blnumber = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjDamageContainer);

            }
            return llstResult;

        }



        public List<clsREGISTEREDUSERS> getValidateUserDetails(string fstrInput)
        {
            List<clsREGISTEREDUSERS> llstResult = new List<clsREGISTEREDUSERS>();
            string lstrApiName = "getValidUserInput";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrUserInput", fstrInput);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjRegsiteUserRow in lobjApiData)
            {
                // Info object
                clsREGISTEREDUSERS lobjRegsiteUser = new clsREGISTEREDUSERS();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjRegsiteUserRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ru_createddate":
                            lobjRegsiteUser.ru_createddate = strColumnValue;
                            break;
                        case "ru_activestatus":
                            lobjRegsiteUser.ru_activestatus = strColumnValue;
                            break;
                        case "ru_recid":
                            lobjRegsiteUser.ru_recid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_firstname1":
                            lobjRegsiteUser.ru_firstname1 = strColumnValue;
                            break;
                        case "ru_firstname2":
                            lobjRegsiteUser.ru_firstname2 = strColumnValue;
                            break;
                        case "ru_lastname1":
                            lobjRegsiteUser.ru_lastname1 = strColumnValue;
                            break;
                        case "ru_lastname2":
                            lobjRegsiteUser.ru_lastname2 = strColumnValue;
                            break;
                        case "ru_cntrecid":
                            lobjRegsiteUser.ru_cntrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_cntcode":
                            lobjRegsiteUser.ru_cntcode = strColumnValue;
                            break;
                        case "ru_cntdesc1":
                            lobjRegsiteUser.ru_cntdesc1 = strColumnValue;
                            break;
                        case "ru_cntdesc2":
                            lobjRegsiteUser.ru_cntdesc2 = strColumnValue;
                            break;
                        case "ru_mobileno":
                            lobjRegsiteUser.ru_mobileno = strColumnValue;
                            break;
                        case "ru_emailid":
                            lobjRegsiteUser.ru_emailid = strColumnValue;
                            break;
                        case "ru_preferredcomm1":
                            lobjRegsiteUser.ru_preferredcomm1 = strColumnValue;
                            break;
                        case "ru_preferredcomm2":
                            lobjRegsiteUser.ru_preferredcomm2 = strColumnValue;
                            break;
                        case "ru_jobtitle1":
                            lobjRegsiteUser.ru_jobtitle1 = strColumnValue;
                            break;
                        case "ru_jobtitle2":
                            lobjRegsiteUser.ru_jobtitle2 = strColumnValue;
                            break;
                        case "ru_jobfunction1":
                            lobjRegsiteUser.ru_jobfunction1 = strColumnValue;
                            break;
                        case "ru_jobfunction2":
                            lobjRegsiteUser.ru_jobfunction2 = strColumnValue;
                            break;
                        case "ru_password":
                            lobjRegsiteUser.ru_password = strColumnValue;
                            break;
                        case "ru_companytype1":
                            lobjRegsiteUser.ru_companytype1 = strColumnValue;
                            break;
                        case "ru_companytype2":
                            lobjRegsiteUser.ru_companytype2 = strColumnValue;
                            break;
                        case "ru_companyname1":
                            lobjRegsiteUser.ru_companyname1 = strColumnValue;
                            break;
                        case "ru_companyname2":
                            lobjRegsiteUser.ru_companyname2 = strColumnValue;
                            break;
                        case "ru_buildingno":
                            lobjRegsiteUser.ru_buildingno = strColumnValue;
                            break;
                        case "ru_unitno":
                            lobjRegsiteUser.ru_unitno = strColumnValue;
                            break;
                        case "ru_streetname1":
                            lobjRegsiteUser.ru_streetname1 = strColumnValue;
                            break;
                        case "ru_streetname2":
                            lobjRegsiteUser.ru_streetname2 = strColumnValue;
                            break;
                        case "ru_districtname1":
                            lobjRegsiteUser.ru_districtname1 = strColumnValue;
                            break;
                        case "ru_districtname2":
                            lobjRegsiteUser.ru_districtname2 = strColumnValue;
                            break;
                        case "ru_ctyrecid":
                            lobjRegsiteUser.ru_ctyrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_ctycode":
                            lobjRegsiteUser.ru_ctycode = strColumnValue;
                            break;
                        case "ru_ctydesc1":
                            lobjRegsiteUser.ru_ctydesc1 = strColumnValue;
                            break;
                        case "ru_ctydesc2":
                            lobjRegsiteUser.ru_ctydesc2 = strColumnValue;
                            break;
                        case "ru_zipcode":
                            lobjRegsiteUser.ru_zipcode = strColumnValue;
                            break;
                        case "ru_additionalno":
                            lobjRegsiteUser.ru_additionalno = strColumnValue;
                            break;
                        case "ru_telephoneno":
                            lobjRegsiteUser.ru_telephoneno = strColumnValue;
                            break;
                        case "ru_fax":
                            lobjRegsiteUser.ru_fax = strColumnValue;
                            break;
                        case "ru_customertype1":
                            lobjRegsiteUser.ru_customertype1 = strColumnValue;
                            break;
                        case "ru_customertype2":
                            lobjRegsiteUser.ru_customertype2 = strColumnValue;
                            break;
                        case "ru_licenseno":
                            lobjRegsiteUser.ru_licenseno = strColumnValue;
                            break;
                        case "ru_idno":
                            lobjRegsiteUser.ru_idno = strColumnValue;
                            break;
                        case "ru_tccheckbox":
                            lobjRegsiteUser.ru_tccheckbox = strColumnValue;
                            break;
                        case "ru_otp":
                            lobjRegsiteUser.ru_otp = strColumnValue;
                            break;
                        case "ru_createdtime":
                            //   lobjRegsiteUser.ru_createdtime = strColumnValue;
                            break;
                        case "ru_nacntrecid":
                            lobjRegsiteUser.ru_nacntrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_nacntcode":
                            lobjRegsiteUser.ru_nacntcode = strColumnValue;
                            break;
                        case "ru_nacntdesc1":
                            lobjRegsiteUser.ru_nacntdesc1 = strColumnValue;
                            break;
                        case "ru_nacntdesc2":
                            lobjRegsiteUser.ru_nacntdesc2 = strColumnValue;
                            break;
                        case "ru_language1":
                            lobjRegsiteUser.ru_language1 = strColumnValue;
                            break;
                        case "ru_language2":
                            lobjRegsiteUser.ru_language2 = strColumnValue;
                            break;
                        case "ru_currency1":
                            lobjRegsiteUser.ru_currency1 = strColumnValue;
                            break;
                        case "ru_currency2":
                            lobjRegsiteUser.ru_currency2 = strColumnValue;
                            break;
                        case "ru_temperature1":
                            lobjRegsiteUser.ru_temperature1 = strColumnValue;
                            break;
                        case "ru_temperature2":
                            lobjRegsiteUser.ru_temperature2 = strColumnValue;
                            break;
                        case "ru_weight1":
                            lobjRegsiteUser.ru_weight1 = strColumnValue;
                            break;
                        case "ru_weight2":
                            lobjRegsiteUser.ru_weight2 = strColumnValue;
                            break;
                        case "ru_sunday":
                            lobjRegsiteUser.ru_sunday = strColumnValue;
                            break;
                        case "ru_monday":
                            lobjRegsiteUser.ru_monday = strColumnValue;
                            break;
                        case "ru_tuesday":
                            lobjRegsiteUser.ru_tuesday = strColumnValue;
                            break;
                        case "ru_wednesday":
                            lobjRegsiteUser.ru_wednesday = strColumnValue;
                            break;
                        case "ru_thursday":
                            lobjRegsiteUser.ru_thursday = strColumnValue;
                            break;
                        case "ru_friday":
                            lobjRegsiteUser.ru_friday = strColumnValue;
                            break;
                        case "ru_saturday":
                            lobjRegsiteUser.ru_saturday = strColumnValue;
                            break;
                        case "ru_apmt12to02":
                            lobjRegsiteUser.ru_apmt12to02 = strColumnValue;
                            break;
                        case "ru_apmt02to04":
                            lobjRegsiteUser.ru_apmt02to04 = strColumnValue;
                            break;
                        case "ru_apmt04to06":
                            lobjRegsiteUser.ru_apmt04to06 = strColumnValue;
                            break;
                        case "ru_apmt06to08":
                            lobjRegsiteUser.ru_apmt06to08 = strColumnValue;
                            break;
                        case "ru_apmt08to10":
                            lobjRegsiteUser.ru_apmt08to10 = strColumnValue;
                            break;
                        case "ru_apmt10to12":
                            lobjRegsiteUser.ru_apmt10to12 = strColumnValue;
                            break;
                        case "ru_apmt12to14":
                            lobjRegsiteUser.ru_apmt12to14 = strColumnValue;
                            break;
                        case "ru_apmt14to16":
                            lobjRegsiteUser.ru_apmt14to16 = strColumnValue;
                            break;
                        case "ru_apmt16to18":
                            lobjRegsiteUser.ru_apmt16to18 = strColumnValue;
                            break;
                        case "ru_apmt18to20":
                            lobjRegsiteUser.ru_apmt18to20 = strColumnValue;
                            break;
                        case "ru_apmt20to22":
                            lobjRegsiteUser.ru_apmt20to22 = strColumnValue;
                            break;
                        case "ru_apmt22to24":
                            lobjRegsiteUser.ru_apmt22to24 = strColumnValue;
                            break;
                        case "ru_licenseno1":
                            lobjRegsiteUser.ru_licenseno1 = strColumnValue;
                            break;
                        case "ru_licenseno2":
                            lobjRegsiteUser.ru_licenseno2 = strColumnValue;
                            break;
                        case "ru_licenseno3":
                            lobjRegsiteUser.ru_licenseno3 = strColumnValue;
                            break;
                        case "ru_licenseno4":
                            lobjRegsiteUser.ru_licenseno4 = strColumnValue;
                            break;
                        case "ru_licenseno5":
                            lobjRegsiteUser.ru_licenseno5 = strColumnValue;
                            break;
                        case "ru_licenseno6":
                            lobjRegsiteUser.ru_licenseno6 = strColumnValue;
                            break;
                        case "ru_licenseno7":
                            lobjRegsiteUser.ru_licenseno7 = strColumnValue;
                            break;
                        case "ru_licenseno8":
                            lobjRegsiteUser.ru_licenseno8 = strColumnValue;
                            break;
                        case "ru_licenseno9":
                            lobjRegsiteUser.ru_licenseno9 = strColumnValue;
                            break;
                        case "ru_defaultlandingpage":
                            lobjRegsiteUser.ru_defaultlandingpage = strColumnValue;
                            break;
                        case "ru_linkcode":
                            lobjRegsiteUser.ru_linkcode = strColumnValue;
                            break;
                        case "ru_note1":
                            lobjRegsiteUser.ru_note1 = strColumnValue;
                            break;
                        case "ru_note2":
                            lobjRegsiteUser.ru_note2 = strColumnValue;
                            break;
                        case "ru_languagevalue":
                            lobjRegsiteUser.ru_languagevalue = strColumnValue;
                            break;
                        case "ru_preferredcommvalue":
                            lobjRegsiteUser.ru_preferredcommvalue = strColumnValue;
                            break;
                        case "ru_jobfunctionvalue":
                            lobjRegsiteUser.ru_jobfunctionvalue = strColumnValue;
                            break;
                        case "ru_companytypevalue":
                            lobjRegsiteUser.ru_companytypevalue = strColumnValue;
                            break;
                        case "ru_customertypevalue":
                            lobjRegsiteUser.ru_customertypevalue = strColumnValue;
                            break;
                        case "ru_currencyvalue":
                            lobjRegsiteUser.ru_currencyvalue = strColumnValue;
                            break;
                        case "ru_temperaturevalue":
                            lobjRegsiteUser.ru_temperaturevalue = strColumnValue;
                            break;
                        case "ru_weightvalue":
                            lobjRegsiteUser.ru_weightvalue = strColumnValue;
                            break;
                        case "ru_walletbalanace":
                            lobjRegsiteUser.ru_walletbalanace = strColumnValue;
                            break;
                            //case "ru_dwelldaysavg":
                            //    lobjRegsiteUser.ru_dwelldaysavg = strColumnValue;
                            //    break;
                            //case "ru_pendingpaymentinvoicescount":
                            //    lobjRegsiteUser.ru_pendingpaymentinvoicescount = strColumnValue;
                            //    break;
                            //case "ru_volumeupdatecontainerscount":
                            //    lobjRegsiteUser.ru_volumeupdatecontainerscount = strColumnValue;
                            //    break;
                            //case "ru_rfdcontainerscount":
                            //    lobjRegsiteUser.ru_rfdcontainerscount = strColumnValue;
                            //    break;
                            //case "ru_rfdcontainersexpirycount":
                            //    lobjRegsiteUser.ru_rfdcontainersexpirycount = strColumnValue;
                            //    break;
                            //case "ru_containerscount":
                            //    lobjRegsiteUser.ru_containerscount = strColumnValue;
                            //    break;
                            //case "ru_mbcontainerscount":
                            //    lobjRegsiteUser.ru_mbcontainerscount = strColumnValue;
                            //    break;
                            //case "ru_reviewscount":
                            //    lobjRegsiteUser.ru_reviewscount = strColumnValue;
                            //    break;
                            //case "ru_reviewspendingcount":
                            //    lobjRegsiteUser.ru_reviewspendingcount = strColumnValue;
                            //    break;
                            //case "ru_avstruckamount":
                            //    lobjRegsiteUser.ru_avstruckamount = strColumnValue;
                            //    break;
                            //case "ru_avscutomclearenceamount":
                            //    lobjRegsiteUser.ru_avscutomclearenceamount = strColumnValue;
                            //    break;
                            //case "ru_readytodeliverunitcount":
                            //    lobjRegsiteUser.ru_readytodeliverunitcount = strColumnValue;
                            //    break;
                            //case "ru_casesresolved":
                            //    lobjRegsiteUser.ru_casesresolved = strColumnValue;
                            //    break;
                            //case "ru_casesinprogress":
                            //    lobjRegsiteUser.ru_casesinprogress = strColumnValue;
                            //    break;
                            //case "ru_invoicescount":
                            //    lobjRegsiteUser.ru_invoicescount = strColumnValue;
                            //    break;
                            //case "ru_invoicesamount":
                            //    lobjRegsiteUser.ru_invoicesamount = strColumnValue;
                            //    break;
                            //case "ru_appoinmentscount":
                            //    lobjRegsiteUser.ru_appoinmentscount = strColumnValue;
                            //    break;
                            //case "ru_mibcontainerscount":
                            //    lobjRegsiteUser.ru_mibcontainerscount = strColumnValue;
                            //    break;
                            //case "ru_r2dgatedoutcount":
                            //    lobjRegsiteUser.ru_r2dgatedoutcount = strColumnValue;
                            //    break;
                            //case "ru_r2dyardcount":
                            //    lobjRegsiteUser.ru_r2dyardcount = strColumnValue;
                            //    break;
                            //case "ru_unitsunderdentioncount":
                            //    lobjRegsiteUser.ru_unitsunderdentioncount = strColumnValue;
                            //    break;
                            //case "ru_unitneardentioncount":
                            //    lobjRegsiteUser.ru_unitneardentioncount = strColumnValue;
                            //    break;
                            //case "ru_bannedtruckscount":
                            //    lobjRegsiteUser.ru_bannedtruckscount = strColumnValue;
                            //    break;
                            //case "ru_eurrsgtcount":
                            //    lobjRegsiteUser.ru_eurrsgtcount = strColumnValue;
                            //    break;
                            //case "ru_euroutsideedcount":
                            //    lobjRegsiteUser.ru_euroutsideedcount = strColumnValue;
                            //    break;


                    }

                }
                llstResult.Add(lobjRegsiteUser);

            }
            return llstResult;

        }

        public List<clsREGISTEREDUSERS> getForgetPasswordDetails(string fstrEmail, string fstrMobile)
        {
            List<clsREGISTEREDUSERS> llstResult = new List<clsREGISTEREDUSERS>();
            string lstrApiName = "getRecoverPassword";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrEmailId", fstrEmail);
            lobjInParams.Add("fstrMobile", fstrMobile);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjRegsiteUserRow in lobjApiData)
            {
                // Info object
                clsREGISTEREDUSERS lobjRegsiteUser = new clsREGISTEREDUSERS();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjRegsiteUserRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "ru_createddate":
                            lobjRegsiteUser.ru_createddate = strColumnValue;
                            break;
                        case "ru_activestatus":
                            lobjRegsiteUser.ru_activestatus = strColumnValue;
                            break;
                        case "ru_recid":
                            lobjRegsiteUser.ru_recid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_firstname1":
                            lobjRegsiteUser.ru_firstname1 = strColumnValue;
                            break;
                        case "ru_firstname2":
                            lobjRegsiteUser.ru_firstname2 = strColumnValue;
                            break;
                        case "ru_lastname1":
                            lobjRegsiteUser.ru_lastname1 = strColumnValue;
                            break;
                        case "ru_lastname2":
                            lobjRegsiteUser.ru_lastname2 = strColumnValue;
                            break;
                        case "ru_cntrecid":
                            lobjRegsiteUser.ru_cntrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_cntcode":
                            lobjRegsiteUser.ru_cntcode = strColumnValue;
                            break;
                        case "ru_cntdesc1":
                            lobjRegsiteUser.ru_cntdesc1 = strColumnValue;
                            break;
                        case "ru_cntdesc2":
                            lobjRegsiteUser.ru_cntdesc2 = strColumnValue;
                            break;
                        case "ru_mobileno":
                            lobjRegsiteUser.ru_mobileno = strColumnValue;
                            break;
                        case "ru_emailid":
                            lobjRegsiteUser.ru_emailid = strColumnValue;
                            break;
                        case "ru_preferredcomm1":
                            lobjRegsiteUser.ru_preferredcomm1 = strColumnValue;
                            break;
                        case "ru_preferredcomm2":
                            lobjRegsiteUser.ru_preferredcomm2 = strColumnValue;
                            break;
                        case "ru_jobtitle1":
                            lobjRegsiteUser.ru_jobtitle1 = strColumnValue;
                            break;
                        case "ru_jobtitle2":
                            lobjRegsiteUser.ru_jobtitle2 = strColumnValue;
                            break;
                        case "ru_jobfunction1":
                            lobjRegsiteUser.ru_jobfunction1 = strColumnValue;
                            break;
                        case "ru_jobfunction2":
                            lobjRegsiteUser.ru_jobfunction2 = strColumnValue;
                            break;
                        case "ru_password":
                            lobjRegsiteUser.ru_password = strColumnValue;
                            break;
                        case "ru_companytype1":
                            lobjRegsiteUser.ru_companytype1 = strColumnValue;
                            break;
                        case "ru_companytype2":
                            lobjRegsiteUser.ru_companytype2 = strColumnValue;
                            break;
                        case "ru_companyname1":
                            lobjRegsiteUser.ru_companyname1 = strColumnValue;
                            break;
                        case "ru_companyname2":
                            lobjRegsiteUser.ru_companyname2 = strColumnValue;
                            break;
                        case "ru_buildingno":
                            lobjRegsiteUser.ru_buildingno = strColumnValue;
                            break;
                        case "ru_unitno":
                            lobjRegsiteUser.ru_unitno = strColumnValue;
                            break;
                        case "ru_streetname1":
                            lobjRegsiteUser.ru_streetname1 = strColumnValue;
                            break;
                        case "ru_streetname2":
                            lobjRegsiteUser.ru_streetname2 = strColumnValue;
                            break;
                        case "ru_districtname1":
                            lobjRegsiteUser.ru_districtname1 = strColumnValue;
                            break;
                        case "ru_districtname2":
                            lobjRegsiteUser.ru_districtname2 = strColumnValue;
                            break;
                        case "ru_ctyrecid":
                            lobjRegsiteUser.ru_ctyrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_ctycode":
                            lobjRegsiteUser.ru_ctycode = strColumnValue;
                            break;
                        case "ru_ctydesc1":
                            lobjRegsiteUser.ru_ctydesc1 = strColumnValue;
                            break;
                        case "ru_ctydesc2":
                            lobjRegsiteUser.ru_ctydesc2 = strColumnValue;
                            break;
                        case "ru_zipcode":
                            lobjRegsiteUser.ru_zipcode = strColumnValue;
                            break;
                        case "ru_additionalno":
                            lobjRegsiteUser.ru_additionalno = strColumnValue;
                            break;
                        case "ru_telephoneno":
                            lobjRegsiteUser.ru_telephoneno = strColumnValue;
                            break;
                        case "ru_fax":
                            lobjRegsiteUser.ru_fax = strColumnValue;
                            break;
                        case "ru_customertype1":
                            lobjRegsiteUser.ru_customertype1 = strColumnValue;
                            break;
                        case "ru_customertype2":
                            lobjRegsiteUser.ru_customertype2 = strColumnValue;
                            break;
                        case "ru_licenseno":
                            lobjRegsiteUser.ru_licenseno = strColumnValue;
                            break;
                        case "ru_idno":
                            lobjRegsiteUser.ru_idno = strColumnValue;
                            break;
                        case "ru_tccheckbox":
                            lobjRegsiteUser.ru_tccheckbox = strColumnValue;
                            break;
                        case "ru_otp":
                            lobjRegsiteUser.ru_otp = strColumnValue;
                            break;
                        case "ru_createdtime":
                            //   lobjRegsiteUser.ru_createdtime = strColumnValue;
                            break;
                        case "ru_nacntrecid":
                            lobjRegsiteUser.ru_nacntrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "ru_nacntcode":
                            lobjRegsiteUser.ru_nacntcode = strColumnValue;
                            break;
                        case "ru_nacntdesc1":
                            lobjRegsiteUser.ru_nacntdesc1 = strColumnValue;
                            break;
                        case "ru_nacntdesc2":
                            lobjRegsiteUser.ru_nacntdesc2 = strColumnValue;
                            break;
                        case "ru_language1":
                            lobjRegsiteUser.ru_language1 = strColumnValue;
                            break;
                        case "ru_language2":
                            lobjRegsiteUser.ru_language2 = strColumnValue;
                            break;
                        case "ru_currency1":
                            lobjRegsiteUser.ru_currency1 = strColumnValue;
                            break;
                        case "ru_currency2":
                            lobjRegsiteUser.ru_currency2 = strColumnValue;
                            break;
                        case "ru_temperature1":
                            lobjRegsiteUser.ru_temperature1 = strColumnValue;
                            break;
                        case "ru_temperature2":
                            lobjRegsiteUser.ru_temperature2 = strColumnValue;
                            break;
                        case "ru_weight1":
                            lobjRegsiteUser.ru_weight1 = strColumnValue;
                            break;
                        case "ru_weight2":
                            lobjRegsiteUser.ru_weight2 = strColumnValue;
                            break;
                        case "ru_sunday":
                            lobjRegsiteUser.ru_sunday = strColumnValue;
                            break;
                        case "ru_monday":
                            lobjRegsiteUser.ru_monday = strColumnValue;
                            break;
                        case "ru_tuesday":
                            lobjRegsiteUser.ru_tuesday = strColumnValue;
                            break;
                        case "ru_wednesday":
                            lobjRegsiteUser.ru_wednesday = strColumnValue;
                            break;
                        case "ru_thursday":
                            lobjRegsiteUser.ru_thursday = strColumnValue;
                            break;
                        case "ru_friday":
                            lobjRegsiteUser.ru_friday = strColumnValue;
                            break;
                        case "ru_saturday":
                            lobjRegsiteUser.ru_saturday = strColumnValue;
                            break;
                        case "ru_apmt12to02":
                            lobjRegsiteUser.ru_apmt12to02 = strColumnValue;
                            break;
                        case "ru_apmt02to04":
                            lobjRegsiteUser.ru_apmt02to04 = strColumnValue;
                            break;
                        case "ru_apmt04to06":
                            lobjRegsiteUser.ru_apmt04to06 = strColumnValue;
                            break;
                        case "ru_apmt06to08":
                            lobjRegsiteUser.ru_apmt06to08 = strColumnValue;
                            break;
                        case "ru_apmt08to10":
                            lobjRegsiteUser.ru_apmt08to10 = strColumnValue;
                            break;
                        case "ru_apmt10to12":
                            lobjRegsiteUser.ru_apmt10to12 = strColumnValue;
                            break;
                        case "ru_apmt12to14":
                            lobjRegsiteUser.ru_apmt12to14 = strColumnValue;
                            break;
                        case "ru_apmt14to16":
                            lobjRegsiteUser.ru_apmt14to16 = strColumnValue;
                            break;
                        case "ru_apmt16to18":
                            lobjRegsiteUser.ru_apmt16to18 = strColumnValue;
                            break;
                        case "ru_apmt18to20":
                            lobjRegsiteUser.ru_apmt18to20 = strColumnValue;
                            break;
                        case "ru_apmt20to22":
                            lobjRegsiteUser.ru_apmt20to22 = strColumnValue;
                            break;
                        case "ru_apmt22to24":
                            lobjRegsiteUser.ru_apmt22to24 = strColumnValue;
                            break;
                        case "ru_licenseno1":
                            lobjRegsiteUser.ru_licenseno1 = strColumnValue;
                            break;
                        case "ru_licenseno2":
                            lobjRegsiteUser.ru_licenseno2 = strColumnValue;
                            break;
                        case "ru_licenseno3":
                            lobjRegsiteUser.ru_licenseno3 = strColumnValue;
                            break;
                        case "ru_licenseno4":
                            lobjRegsiteUser.ru_licenseno4 = strColumnValue;
                            break;
                        case "ru_licenseno5":
                            lobjRegsiteUser.ru_licenseno5 = strColumnValue;
                            break;
                        case "ru_licenseno6":
                            lobjRegsiteUser.ru_licenseno6 = strColumnValue;
                            break;
                        case "ru_licenseno7":
                            lobjRegsiteUser.ru_licenseno7 = strColumnValue;
                            break;
                        case "ru_licenseno8":
                            lobjRegsiteUser.ru_licenseno8 = strColumnValue;
                            break;
                        case "ru_licenseno9":
                            lobjRegsiteUser.ru_licenseno9 = strColumnValue;
                            break;
                        case "ru_defaultlandingpage":
                            lobjRegsiteUser.ru_defaultlandingpage = strColumnValue;
                            break;
                        case "ru_linkcode":
                            lobjRegsiteUser.ru_linkcode = strColumnValue;
                            break;
                        case "ru_note1":
                            lobjRegsiteUser.ru_note1 = strColumnValue;
                            break;
                        case "ru_note2":
                            lobjRegsiteUser.ru_note2 = strColumnValue;
                            break;
                        case "ru_languagevalue":
                            lobjRegsiteUser.ru_languagevalue = strColumnValue;
                            break;
                        case "ru_preferredcommvalue":
                            lobjRegsiteUser.ru_preferredcommvalue = strColumnValue;
                            break;
                        case "ru_jobfunctionvalue":
                            lobjRegsiteUser.ru_jobfunctionvalue = strColumnValue;
                            break;
                        case "ru_companytypevalue":
                            lobjRegsiteUser.ru_companytypevalue = strColumnValue;
                            break;
                        case "ru_customertypevalue":
                            lobjRegsiteUser.ru_customertypevalue = strColumnValue;
                            break;
                        case "ru_currencyvalue":
                            lobjRegsiteUser.ru_currencyvalue = strColumnValue;
                            break;
                        case "ru_temperaturevalue":
                            lobjRegsiteUser.ru_temperaturevalue = strColumnValue;
                            break;
                        case "ru_weightvalue":
                            lobjRegsiteUser.ru_weightvalue = strColumnValue;
                            break;
                        case "ru_walletbalanace":
                            lobjRegsiteUser.ru_walletbalanace = strColumnValue;
                            break;
                            //case "ru_dwelldaysavg":
                            //    lobjRegsiteUser.ru_dwelldaysavg = strColumnValue;
                            //    break;
                            //case "ru_pendingpaymentinvoicescount":
                            //    lobjRegsiteUser.ru_pendingpaymentinvoicescount = strColumnValue;
                            //    break;
                            //case "ru_volumeupdatecontainerscount":
                            //    lobjRegsiteUser.ru_volumeupdatecontainerscount = strColumnValue;
                            //    break;
                            //case "ru_rfdcontainerscount":
                            //    lobjRegsiteUser.ru_rfdcontainerscount = strColumnValue;
                            //    break;
                            //case "ru_rfdcontainersexpirycount":
                            //    lobjRegsiteUser.ru_rfdcontainersexpirycount = strColumnValue;
                            //    break;
                            //case "ru_containerscount":
                            //    lobjRegsiteUser.ru_containerscount = strColumnValue;
                            //    break;
                            //case "ru_mbcontainerscount":
                            //    lobjRegsiteUser.ru_mbcontainerscount = strColumnValue;
                            //    break;
                            //case "ru_reviewscount":
                            //    lobjRegsiteUser.ru_reviewscount = strColumnValue;
                            //    break;
                            //case "ru_reviewspendingcount":
                            //    lobjRegsiteUser.ru_reviewspendingcount = strColumnValue;
                            //    break;
                            //case "ru_avstruckamount":
                            //    lobjRegsiteUser.ru_avstruckamount = strColumnValue;
                            //    break;
                            //case "ru_avscutomclearenceamount":
                            //    lobjRegsiteUser.ru_avscutomclearenceamount = strColumnValue;
                            //    break;
                            //case "ru_readytodeliverunitcount":
                            //    lobjRegsiteUser.ru_readytodeliverunitcount = strColumnValue;
                            //    break;
                            //case "ru_casesresolved":
                            //    lobjRegsiteUser.ru_casesresolved = strColumnValue;
                            //    break;
                            //case "ru_casesinprogress":
                            //    lobjRegsiteUser.ru_casesinprogress = strColumnValue;
                            //    break;
                            //case "ru_invoicescount":
                            //    lobjRegsiteUser.ru_invoicescount = strColumnValue;
                            //    break;
                            //case "ru_invoicesamount":
                            //    lobjRegsiteUser.ru_invoicesamount = strColumnValue;
                            //    break;
                            //case "ru_appoinmentscount":
                            //    lobjRegsiteUser.ru_appoinmentscount = strColumnValue;
                            //    break;
                            //case "ru_mibcontainerscount":
                            //    lobjRegsiteUser.ru_mibcontainerscount = strColumnValue;
                            //    break;
                            //case "ru_r2dgatedoutcount":
                            //    lobjRegsiteUser.ru_r2dgatedoutcount = strColumnValue;
                            //    break;
                            //case "ru_r2dyardcount":
                            //    lobjRegsiteUser.ru_r2dyardcount = strColumnValue;
                            //    break;
                            //case "ru_unitsunderdentioncount":
                            //    lobjRegsiteUser.ru_unitsunderdentioncount = strColumnValue;
                            //    break;
                            //case "ru_unitneardentioncount":
                            //    lobjRegsiteUser.ru_unitneardentioncount = strColumnValue;
                            //    break;
                            //case "ru_bannedtruckscount":
                            //    lobjRegsiteUser.ru_bannedtruckscount = strColumnValue;
                            //    break;
                            //case "ru_eurrsgtcount":
                            //    lobjRegsiteUser.ru_eurrsgtcount = strColumnValue;
                            //    break;
                            //case "ru_euroutsideedcount":
                            //    lobjRegsiteUser.ru_euroutsideedcount = strColumnValue;
                            //    break;


                    }

                }
                llstResult.Add(lobjRegsiteUser);

            }
            return llstResult;

        }

        public List<clscmsEmailTemplatecount> getCmsMailTemplateCount(string fstrRegisterEmailID)
        {
            List<clscmsEmailTemplatecount> llstResult = new List<clscmsEmailTemplatecount>();
            string lstrApiName = "getCmsMailTemplateCount";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjMailRow in lobjApiData)
            {
                // Info object
                clscmsEmailTemplatecount lobjMail = new clscmsEmailTemplatecount();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjMailRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {

                        case "smt_recid":
                            lobjMail.smt_recid = Convert.ToInt32(strColumnValue);
                            break;
                        case "smt_code":
                            lobjMail.smt_code = strColumnValue;
                            break;
                        case "smm_smtrecid":
                            lobjMail.smm_smtrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "totalmessage":
                            lobjMail.totalmessage = Convert.ToInt32(strColumnValue);
                            break;

                    }

                }
                llstResult.Add(lobjMail);

            }
            return llstResult;

        }

        public List<clscmsSMSTemplatecount> getCmsSmsTemplateCount(string fstrRegisterEmailID)
        {
            List<clscmsSMSTemplatecount> llstResult = new List<clscmsSMSTemplatecount>();
            string lstrApiName = "getCmsSmsTemplateCount";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            //lobjInParams.Add("fstrMailID", fstrRegisterEmailID);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjsmsRow in lobjApiData)
            {
                // Info object
                clscmsSMSTemplatecount lobjsms = new clscmsSMSTemplatecount();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjsmsRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "sst_recid":
                            lobjsms.sst_recid = Convert.ToInt32(strColumnValue);
                            break;
                        case "sst_code":
                            lobjsms.sst_code = strColumnValue;
                            break;
                        case "sm_sstrecid":
                            lobjsms.sm_sstrecid = Convert.ToInt32(strColumnValue);
                            break;
                        case "totalmessage":
                            lobjsms.totalmessage = Convert.ToInt32(strColumnValue);
                            break;

                    }

                }
                llstResult.Add(lobjsms);

            }
            return llstResult;

        }

        public List<BasicTrakingDetail> getBasicTrakingBayanDetail(string fstrBayanNo)
        {
            List<BasicTrakingDetail> llstResult = new List<BasicTrakingDetail>();
            string lstrApiName = "getBayanDetail";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrBayanNo", fstrBayanNo);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjRow in lobjApiData)
            {
                // Info object
                BasicTrakingDetail lobjBayan = new BasicTrakingDetail();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_unitgkey":
                            lobjBayan.cd_unitgkey = strColumnValue;
                            break;
                        case "cd_ufvgkey":
                            lobjBayan.cd_ufvgkey = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjBayan.cd_containernumber = strColumnValue;
                            break;
                        case "cd_vesselvisitgkey":
                            lobjBayan.cd_vesselvisitgkey = strColumnValue;
                            break;
                        case "cd_vesselvisitid":
                            lobjBayan.cd_vesselvisitid = strColumnValue;
                            break;
                        case "cd_vesselname1":
                            lobjBayan.cd_vesselname1 = strColumnValue;
                            break;
                        case "cd_vesselname2":
                            lobjBayan.cd_vesselname2 = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjBayan.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blgkey":
                            lobjBayan.cd_blgkey = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjBayan.cd_blnumber = strColumnValue;
                            break;
                        case "cd_commodity":
                            lobjBayan.cd_commodity = strColumnValue;
                            break;
                        case "cd_obvoyage":
                            lobjBayan.cd_obvoyage = strColumnValue;
                            break;
                        case "cd_ibvoyage":
                            lobjBayan.cd_ibvoyage = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjBayan.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_shippingicon":
                            lobjBayan.cd_shippingicon = strColumnValue;
                            break;
                        case "cd_consigneegkey":
                            lobjBayan.cd_consigneegkey = strColumnValue;
                            break;
                        case "cd_consigneedesc1":
                            lobjBayan.cd_consigneedesc1 = strColumnValue;
                            break;
                        case "cd_consigneedesc2":
                            lobjBayan.cd_consigneedesc2 = strColumnValue;
                            break;
                        case "cd_shippergkey":
                            lobjBayan.cd_shippergkey = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            lobjBayan.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_shipperdesc2":
                            lobjBayan.cd_shipperdesc2 = strColumnValue;
                            break;
                        case "cd_custombrokeragent":
                            lobjBayan.cd_custombrokeragent = strColumnValue;
                            break;
                        case "cd_category":
                            lobjBayan.cd_category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjBayan.cd_freightkind = strColumnValue;
                            break;
                        case "cd_size":
                            lobjBayan.cd_size = strColumnValue;
                            break;
                        case "cd_weight":
                            lobjBayan.cd_weight = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjBayan.cd_portofloading = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjBayan.cd_portofdischarge = strColumnValue;
                            break;
                        case "cd_inspectionstatus":
                            lobjBayan.cd_inspectionstatus = strColumnValue;
                            break;
                        case "cd_fminspectionstatus":
                            lobjBayan.cd_fminspectionstatus = strColumnValue;
                            break;
                        case "cd_holdpermission":
                            lobjBayan.cd_holdpermission = strColumnValue;
                            break;
                        case "cd_transitstatus":
                            lobjBayan.cd_transitstatus = strColumnValue;
                            break;
                        case "cd_oogdetails":
                            lobjBayan.cd_oogdetails = strColumnValue;
                            break;
                        case "cd_reeferdetails":
                            lobjBayan.cd_reeferdetails = strColumnValue;
                            break;
                        case "cd_dgdetails":
                            lobjBayan.cd_dgdetails = strColumnValue;
                            break;
                        case "cd_arrived":
                            lobjBayan.cd_arrived = strColumnValue;
                            break;
                        case "cd_fmarrived":
                            lobjBayan.cd_fmarrived = strColumnValue;
                            break;
                        case "cd_discrecivaltime":
                            lobjBayan.cd_discrecivaltime = strColumnValue;
                            break;
                        case "cd_timeout":
                            lobjBayan.cd_timeout = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjBayan.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_movetoinspectiontime":
                            lobjBayan.cd_movetoinspectiontime = strColumnValue;
                            break;
                        case "cd_fmtmovetoinspectiontime":
                            lobjBayan.cd_fmtmovetoinspectiontime = strColumnValue;
                            break;
                        case "cd_inspectioncomplete":
                            lobjBayan.cd_inspectioncomplete = strColumnValue;
                            break;
                        case "cd_fmtinspectioncomplete":
                            lobjBayan.cd_fmtinspectioncomplete = strColumnValue;
                            break;
                        case "cd_readyfordeliverytime":
                            lobjBayan.cd_readyfordeliverytime = strColumnValue;
                            break;
                        case "cd_fmreadyfordeliverytime":
                            lobjBayan.cd_fmreadyfordeliverytime = strColumnValue;
                            break;
                        case "cd_prepickupissuedtime":
                            lobjBayan.cd_prepickupissuedtime = strColumnValue;
                            break;
                        case "cd_fmprepickissuedtime":
                            lobjBayan.cd_fmprepickissuedtime = strColumnValue;
                            break;
                        case "cd_gatedouttime":
                            lobjBayan.cd_gatedouttime = strColumnValue;
                            break;
                        case "cd_fmgatedouttime":
                            lobjBayan.cd_fmgatedouttime = strColumnValue;
                            break;
                        case "cd_gaugeunitsize":
                            lobjBayan.cd_gaugeunitsize = strColumnValue;
                            break;
                        case "cd_dryreefer":
                            lobjBayan.cd_dryreefer = strColumnValue;
                            break;
                        case "cd_detention":
                            lobjBayan.cd_detention = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjBayan.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_apptnbr":
                            lobjBayan.cd_apptnbr = strColumnValue;
                            break;
                        case "cd_apptdate":
                            lobjBayan.cd_apptdate = strColumnValue;
                            break;
                        case "cd_apptstatus":
                            lobjBayan.cd_apptstatus = strColumnValue;
                            break;
                        case "cd_createddate":
                            lobjBayan.cd_createddate = strColumnValue;
                            break;
                        case "cd_agentkey":
                            lobjBayan.cd_agentkey = strColumnValue;
                            break;
                        case "cd_lastmodifieddate":
                            lobjBayan.cd_lastmodifieddate = strColumnValue;
                            break;
                        case "cd_expectedtimeofarrival":
                            lobjBayan.cd_expectedtimeofarrival = strColumnValue;
                            break;
                        case "cd_actualtimeofarrival":
                            lobjBayan.cd_actualtimeofarrival = strColumnValue;
                            break;
                        case "cd_fmtexpectedtimeofarrival":
                            lobjBayan.cd_fmtexpectedtimeofarrival = strColumnValue;
                            break;
                        case "cd_fmtactualtimeofarrival":
                            lobjBayan.cd_fmtactualtimeofarrival = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjBayan);

            }
            return llstResult;

        }

        public string NotifyToUserold(string ApiName, string objstringJson)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;



            // client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531
                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    lstrResult = "true";
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        public List<BasicTrakingDetail> getBasicTrakingBillofladingDetail(string fstrBLNo)
        {
            List<BasicTrakingDetail> llstResult = new List<BasicTrakingDetail>();
            string lstrApiName = "getBillofladingDetail";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrBillofladingNo", fstrBLNo);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjRow in lobjApiData)
            {
                // Info object
                BasicTrakingDetail lobjBL = new BasicTrakingDetail();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_unitgkey":
                            lobjBL.cd_unitgkey = strColumnValue;
                            break;
                        case "cd_ufvgkey":
                            lobjBL.cd_ufvgkey = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjBL.cd_containernumber = strColumnValue;
                            break;
                        case "cd_vesselvisitgkey":
                            lobjBL.cd_vesselvisitgkey = strColumnValue;
                            break;
                        case "cd_vesselvisitid":
                            lobjBL.cd_vesselvisitid = strColumnValue;
                            break;
                        case "cd_vesselname1":
                            lobjBL.cd_vesselname1 = strColumnValue;
                            break;
                        case "cd_vesselname2":
                            lobjBL.cd_vesselname2 = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjBL.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blgkey":
                            lobjBL.cd_blgkey = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjBL.cd_blnumber = strColumnValue;
                            break;
                        case "cd_commodity":
                            lobjBL.cd_commodity = strColumnValue;
                            break;
                        case "cd_obvoyage":
                            lobjBL.cd_obvoyage = strColumnValue;
                            break;
                        case "cd_ibvoyage":
                            lobjBL.cd_ibvoyage = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjBL.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_shippingicon":
                            lobjBL.cd_shippingicon = strColumnValue;
                            break;
                        case "cd_consigneegkey":
                            lobjBL.cd_consigneegkey = strColumnValue;
                            break;
                        case "cd_consigneedesc1":
                            lobjBL.cd_consigneedesc1 = strColumnValue;
                            break;
                        case "cd_consigneedesc2":
                            lobjBL.cd_consigneedesc2 = strColumnValue;
                            break;
                        case "cd_shippergkey":
                            lobjBL.cd_shippergkey = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            lobjBL.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_shipperdesc2":
                            lobjBL.cd_shipperdesc2 = strColumnValue;
                            break;
                        case "cd_custombrokeragent":
                            lobjBL.cd_custombrokeragent = strColumnValue;
                            break;
                        case "cd_category":
                            lobjBL.cd_category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjBL.cd_freightkind = strColumnValue;
                            break;
                        case "cd_size":
                            lobjBL.cd_size = strColumnValue;
                            break;
                        case "cd_weight":
                            lobjBL.cd_weight = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjBL.cd_portofloading = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjBL.cd_portofdischarge = strColumnValue;
                            break;
                        case "cd_inspectionstatus":
                            lobjBL.cd_inspectionstatus = strColumnValue;
                            break;
                        case "cd_fminspectionstatus":
                            lobjBL.cd_fminspectionstatus = strColumnValue;
                            break;
                        case "cd_holdpermission":
                            lobjBL.cd_holdpermission = strColumnValue;
                            break;
                        case "cd_transitstatus":
                            lobjBL.cd_transitstatus = strColumnValue;
                            break;
                        case "cd_oogdetails":
                            lobjBL.cd_oogdetails = strColumnValue;
                            break;
                        case "cd_reeferdetails":
                            lobjBL.cd_reeferdetails = strColumnValue;
                            break;
                        case "cd_dgdetails":
                            lobjBL.cd_dgdetails = strColumnValue;
                            break;
                        case "cd_arrived":
                            lobjBL.cd_arrived = strColumnValue;
                            break;
                        case "cd_fmarrived":
                            lobjBL.cd_fmarrived = strColumnValue;
                            break;
                        case "cd_discrecivaltime":
                            lobjBL.cd_discrecivaltime = strColumnValue;
                            break;
                        case "cd_timeout":
                            lobjBL.cd_timeout = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjBL.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_movetoinspectiontime":
                            lobjBL.cd_movetoinspectiontime = strColumnValue;
                            break;
                        case "cd_fmtmovetoinspectiontime":
                            lobjBL.cd_fmtmovetoinspectiontime = strColumnValue;
                            break;
                        case "cd_inspectioncomplete":
                            lobjBL.cd_inspectioncomplete = strColumnValue;
                            break;
                        case "cd_fmtinspectioncomplete":
                            lobjBL.cd_fmtinspectioncomplete = strColumnValue;
                            break;
                        case "cd_readyfordeliverytime":
                            lobjBL.cd_readyfordeliverytime = strColumnValue;
                            break;
                        case "cd_fmreadyfordeliverytime":
                            lobjBL.cd_fmreadyfordeliverytime = strColumnValue;
                            break;
                        case "cd_prepickupissuedtime":
                            lobjBL.cd_prepickupissuedtime = strColumnValue;
                            break;
                        case "cd_fmprepickissuedtime":
                            lobjBL.cd_fmprepickissuedtime = strColumnValue;
                            break;
                        case "cd_gatedouttime":
                            lobjBL.cd_gatedouttime = strColumnValue;
                            break;
                        case "cd_fmgatedouttime":
                            lobjBL.cd_fmgatedouttime = strColumnValue;
                            break;
                        case "cd_gaugeunitsize":
                            lobjBL.cd_gaugeunitsize = strColumnValue;
                            break;
                        case "cd_dryreefer":
                            lobjBL.cd_dryreefer = strColumnValue;
                            break;
                        case "cd_detention":
                            lobjBL.cd_detention = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjBL.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_apptnbr":
                            lobjBL.cd_apptnbr = strColumnValue;
                            break;
                        case "cd_apptdate":
                            lobjBL.cd_apptdate = strColumnValue;
                            break;
                        case "cd_apptstatus":
                            lobjBL.cd_apptstatus = strColumnValue;
                            break;
                        case "cd_createddate":
                            lobjBL.cd_createddate = strColumnValue;
                            break;
                        case "cd_agentkey":
                            lobjBL.cd_agentkey = strColumnValue;
                            break;
                        case "cd_lastmodifieddate":
                            lobjBL.cd_lastmodifieddate = strColumnValue;
                            break;
                        case "cd_expectedtimeofarrival":
                            lobjBL.cd_expectedtimeofarrival = strColumnValue;
                            break;
                        case "cd_actualtimeofarrival":
                            lobjBL.cd_actualtimeofarrival = strColumnValue;
                            break;
                        case "cd_fmtexpectedtimeofarrival":
                            lobjBL.cd_fmtexpectedtimeofarrival = strColumnValue;
                            break;
                        case "cd_fmtactualtimeofarrival":
                            lobjBL.cd_fmtactualtimeofarrival = strColumnValue;
                            break;
                    }
                }
                llstResult.Add(lobjBL);

            }
            return llstResult;

        }



        public bool postMethodold(string fstrAPIName, string objstringJson)
        {
            bool lstrResult = false;
            HttpClient client = new HttpClient();
            string ApiName = fstrAPIName;
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;

            // client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;
            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");


                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);
                var result = client1.PostAsync(strURL, content).Result;


                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    lstrResult = result.IsSuccessStatusCode;
                    objOutputTask.Wait();

                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }


        public List<BasicTrakingDetail> getBasicTrakingContainerDetail(string fstrContainerNo)
        {
            List<BasicTrakingDetail> llstResult = new List<BasicTrakingDetail>();
            string lstrApiName = "getBasicTrackingPhase2";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrContainerNo", fstrContainerNo);
            IEnumerable<Object> lobjApiData;
            lobjApiData = objWebApi.getWebApiData(lstrApiName, lobjInParams);

            foreach (IEnumerable<Object> lobjRow in lobjApiData)
            {
                // Info object
                BasicTrakingDetail lobjContainer = new BasicTrakingDetail();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);
                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cd_unitgkey":
                            lobjContainer.cd_unitgkey = strColumnValue;
                            break;
                        case "cd_ufvgkey":
                            lobjContainer.cd_ufvgkey = strColumnValue;
                            break;
                        case "cd_containernumber":
                            lobjContainer.cd_containernumber = strColumnValue;
                            break;
                        case "cd_vesselvisitgkey":
                            lobjContainer.cd_vesselvisitgkey = strColumnValue;
                            break;
                        case "cd_vesselvisitid":
                            lobjContainer.cd_vesselvisitid = strColumnValue;
                            break;
                        case "cd_vesselname1":
                            lobjContainer.cd_vesselname1 = strColumnValue;
                            break;
                        case "cd_vesselname2":
                            lobjContainer.cd_vesselname2 = strColumnValue;
                            break;
                        case "cd_bayannumber":
                            lobjContainer.cd_bayannumber = strColumnValue;
                            break;
                        case "cd_blgkey":
                            lobjContainer.cd_blgkey = strColumnValue;
                            break;
                        case "cd_blnumber":
                            lobjContainer.cd_blnumber = strColumnValue;
                            break;
                        case "cd_commodity":
                            lobjContainer.cd_commodity = strColumnValue;
                            break;
                        case "cd_obvoyage":
                            lobjContainer.cd_obvoyage = strColumnValue;
                            break;
                        case "cd_ibvoyage":
                            lobjContainer.cd_ibvoyage = strColumnValue;
                            break;
                        case "cd_shippinglineid":
                            lobjContainer.cd_shippinglineid = strColumnValue;
                            break;
                        case "cd_shippingicon":
                            lobjContainer.cd_shippingicon = strColumnValue;
                            break;
                        case "cd_consigneegkey":
                            lobjContainer.cd_consigneegkey = strColumnValue;
                            break;
                        case "cd_consigneedesc1":
                            lobjContainer.cd_consigneedesc1 = strColumnValue;
                            break;
                        case "cd_consigneedesc2":
                            lobjContainer.cd_consigneedesc2 = strColumnValue;
                            break;
                        case "cd_shippergkey":
                            lobjContainer.cd_shippergkey = strColumnValue;
                            break;
                        case "cd_shipperdesc1":
                            lobjContainer.cd_shipperdesc1 = strColumnValue;
                            break;
                        case "cd_shipperdesc2":
                            lobjContainer.cd_shipperdesc2 = strColumnValue;
                            break;
                        case "cd_custombrokeragent":
                            lobjContainer.cd_custombrokeragent = strColumnValue;
                            break;
                        case "cd_category":
                            lobjContainer.cd_category = strColumnValue;
                            break;
                        case "cd_freightkind":
                            lobjContainer.cd_freightkind = strColumnValue;
                            break;
                        case "cd_size":
                            lobjContainer.cd_size = strColumnValue;
                            break;
                        case "cd_weight":
                            lobjContainer.cd_weight = strColumnValue;
                            break;
                        case "cd_portofloading":
                            lobjContainer.cd_portofloading = strColumnValue;
                            break;
                        case "cd_portofdischarge":
                            lobjContainer.cd_portofdischarge = strColumnValue;
                            break;
                        case "cd_inspectionstatus":
                            lobjContainer.cd_inspectionstatus = strColumnValue;
                            break;
                        case "cd_fminspectionstatus":
                            lobjContainer.cd_fminspectionstatus = strColumnValue;
                            break;
                        case "cd_holdpermission":
                            lobjContainer.cd_holdpermission = strColumnValue;
                            break;
                        case "cd_transitstatus":
                            lobjContainer.cd_transitstatus = strColumnValue;
                            break;
                        case "cd_oogdetails":
                            lobjContainer.cd_oogdetails = strColumnValue;
                            break;
                        case "cd_reeferdetails":
                            lobjContainer.cd_reeferdetails = strColumnValue;
                            break;
                        case "cd_dgdetails":
                            lobjContainer.cd_dgdetails = strColumnValue;
                            break;
                        case "cd_arrived":
                            lobjContainer.cd_arrived = strColumnValue;
                            break;
                        case "cd_fmarrived":
                            lobjContainer.cd_fmarrived = strColumnValue;
                            break;
                        case "cd_discrecivaltime":
                            lobjContainer.cd_discrecivaltime = strColumnValue;
                            break;
                        case "cd_timeout":
                            lobjContainer.cd_timeout = strColumnValue;
                            break;
                        case "cd_fmtdiscrecivaltime":
                            lobjContainer.cd_fmtdiscrecivaltime = strColumnValue;
                            break;
                        case "cd_movetoinspectiontime":
                            lobjContainer.cd_movetoinspectiontime = strColumnValue;
                            break;
                        case "cd_fmtmovetoinspectiontime":
                            lobjContainer.cd_fmtmovetoinspectiontime = strColumnValue;
                            break;
                        case "cd_inspectioncomplete":
                            lobjContainer.cd_inspectioncomplete = strColumnValue;
                            break;
                        case "cd_fmtinspectioncomplete":
                            lobjContainer.cd_fmtinspectioncomplete = strColumnValue;
                            break;
                        case "cd_readyfordeliverytime":
                            lobjContainer.cd_readyfordeliverytime = strColumnValue;
                            break;
                        case "cd_fmreadyfordeliverytime":
                            lobjContainer.cd_fmreadyfordeliverytime = strColumnValue;
                            break;
                        case "cd_prepickupissuedtime":
                            lobjContainer.cd_prepickupissuedtime = strColumnValue;
                            break;
                        case "cd_fmprepickissuedtime":
                            lobjContainer.cd_fmprepickissuedtime = strColumnValue;
                            break;
                        case "cd_gatedouttime":
                            lobjContainer.cd_gatedouttime = strColumnValue;
                            break;
                        case "cd_fmgatedouttime":
                            lobjContainer.cd_fmgatedouttime = strColumnValue;
                            break;
                        case "cd_gaugeunitsize":
                            lobjContainer.cd_gaugeunitsize = strColumnValue;
                            break;
                        case "cd_dryreefer":
                            lobjContainer.cd_dryreefer = strColumnValue;
                            break;
                        case "cd_detention":
                            lobjContainer.cd_detention = strColumnValue;
                            break;
                        case "cd_emptydepot":
                            lobjContainer.cd_emptydepot = strColumnValue;
                            break;
                        case "cd_apptnbr":
                            lobjContainer.cd_apptnbr = strColumnValue;
                            break;
                        case "cd_apptdate":
                            lobjContainer.cd_apptdate = strColumnValue;
                            break;
                        case "cd_apptstatus":
                            lobjContainer.cd_apptstatus = strColumnValue;
                            break;
                        case "cd_createddate":
                            lobjContainer.cd_createddate = strColumnValue;
                            break;
                        case "cd_agentkey":
                            lobjContainer.cd_agentkey = strColumnValue;
                            break;
                        case "cd_lastmodifieddate":
                            lobjContainer.cd_lastmodifieddate = strColumnValue;
                            break;
                        case "cd_expectedtimeofarrival":
                            lobjContainer.cd_expectedtimeofarrival = strColumnValue;
                            break;
                        case "cd_actualtimeofarrival":
                            lobjContainer.cd_actualtimeofarrival = strColumnValue;
                            break;
                        case "cd_fmtexpectedtimeofarrival":
                            lobjContainer.cd_fmtexpectedtimeofarrival = strColumnValue;
                            break;
                        case "cd_fmtactualtimeofarrival":
                            lobjContainer.cd_fmtactualtimeofarrival = strColumnValue;
                            break;
                        case "cd_statusdesc1":
                            lobjContainer.cd_statusdesc1 = strColumnValue;
                            break;
                        case "cd_statusdesc2":
                            lobjContainer.cd_statusdesc2 = strColumnValue;
                            break;

                        case "cd_emptydepot_eng":
                            lobjContainer.cd_emptydepot_eng = strColumnValue;
                            break;
                        case "cd_emptydepot_ara":
                            lobjContainer.cd_emptydepot_ara = strColumnValue;
                            break;

                        case "timeline_waitingforportcharges":
                            lobjContainer.timeline_waitingforportcharges = strColumnValue;
                            break;


                        //12-01-2023-export
                        case "timeline_expunitintime":
                            lobjContainer.timeline_expunitintime = strColumnValue;
                            break;
                        case "timeline_expunitintimeflag":
                            lobjContainer.timeline_expunitintimeflag = strColumnValue;
                            break;
                        case "timeline_expbookforinsptime":
                            lobjContainer.timeline_expbookforinsptime = strColumnValue;
                            break;
                        case "timeline_expbookforinsptimeflag":
                            lobjContainer.timeline_expbookforinsptimeflag = strColumnValue;
                            break;
                        case "timeline_expinspcompletedtime":
                            lobjContainer.timeline_expinspcompletedtime = strColumnValue;
                            break;
                        case "timeline_expinspcompletedtimeflag":
                            lobjContainer.timeline_expinspcompletedtimeflag = strColumnValue;
                            break;
                        case "timeline_expexcesscargoholdtime":
                            lobjContainer.timeline_expexcesscargoholdtime = strColumnValue;
                            break;
                        case "timeline_expexcesscargoholdtimeflag":
                            lobjContainer.timeline_expexcesscargoholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expdetentionholdtime":
                            lobjContainer.timeline_expdetentionholdtime = strColumnValue;
                            break;
                        case "timeline_expdetentionholdtimeflag":
                            lobjContainer.timeline_expdetentionholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expcoldstorepayholdtime":
                            lobjContainer.timeline_expcoldstorepayholdtime = strColumnValue;
                            break;
                        case "timeline_expcoldstorepayholdtimeflag":
                            lobjContainer.timeline_expcoldstorepayholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expfinholdtime":
                            lobjContainer.timeline_expfinholdtime = strColumnValue;
                            break;
                        case "timeline_expfinholdtimeflag":
                            lobjContainer.timeline_expfinholdtimeflag = strColumnValue;
                            break;
                        case "timeline_expreadytoloadtime":
                            lobjContainer.timeline_expreadytoloadtime = strColumnValue;
                            break;
                        case "timeline_expreadytoloadtimeflag":
                            lobjContainer.timeline_expreadytoloadtimeflag = strColumnValue;
                            break;
                        case "timeline_expunitloadtime":
                            lobjContainer.timeline_expunitloadtime = strColumnValue;
                            break;
                        case "timeline_expunitloadtimeflag":
                            lobjContainer.timeline_expunitloadtimeflag = strColumnValue;
                            break;



                    }
                }
                llstResult.Add(lobjContainer);

            }
            return llstResult;

        }

        public string updatePassword(string ApiName, string objstringJson, string fstrEmailid)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName + "/" + fstrEmailid;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;
            //UpadteRegisterUser
            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PutAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                }
                bool BoolResult = result.IsSuccessStatusCode;
                if (BoolResult == true)
                {
                    lstrResult = "true";
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return lstrResult;
        }

        public string portaltoAPIold(string ApiName, string objstringJson)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;



            //lstrInput = "{\"PA_API\": \"generate Invoice\",\"PA_STATUS\": \"Requested\",\"PA_PARAMETERS\": \"{'Invoice':{'billOfLading':'" + gblRegisteration.Api_BLNO + "','ID':'" + gblRegisteration.strIdNo + "','Language':'EN','Command':'Generate'}}\"}";


            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    lstrResult = "True";
                    objOutputTask.Wait();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        public string TrackServiceReqOld(string ApiName, string objstringJson)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    lstrResult = "True";
                    objOutputTask.Wait();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }
        public string PostserviceWebApiold(string ApiName, string objstringJson)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    lstrResult = "True";
                    objOutputTask.Wait();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        public string TerminalVisitold(string ApiName, string objstringJson)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization =
                //new AuthenticationHeaderValue(HttpRequestHeader.Authorization.ToString(), strApiKey);
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                //var result = client.PostAsync(strURL, content).Result;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531

                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    lstrResult = "True";
                    objOutputTask.Wait();
                }
            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return lstrResult;
        }
    }

    public class CMSUPDATES
    {

        public string cmsu_accessid { get; set; }

        public string cmsu_lastupdateddatetime { get; set; }


    }

    //getCmsSmsDetails
    public class clsCMSSMSDetail
    {
        public int sm_recid { get; set; }
        public int sm_sstrecid { get; set; }
        public int sm_rurecid { get; set; }
        public int sm_curecid { get; set; }
        public int sm_sbrecid { get; set; }
        public string sm_code { get; set; }
        public string sm_mobileno { get; set; }
        public string sm_message1 { get; set; }
        public string sm_message2 { get; set; }
        public string sm_query { get; set; }
        public string sm_mobilefield1 { get; set; }
        public string sm_mobilefield2 { get; set; }
        public string sm_mobilefield3 { get; set; }
        public string sm_comm1 { get; set; }
        public string sm_comm2 { get; set; }
        public int sm_scheduleddt { get; set; }
        public int sm_sentdt { get; set; }
        public string sm_status { get; set; }
        public string sm_statusmessage { get; set; }
        public string sm_type { get; set; }
        public string sm_displaysentdt { get; set; }

    }

    public class clsWallat
    {
        public int wt_recid { get; set; }
        public string wt_ruemailid { get; set; }
        public string wt_trndate { get; set; }
        public string fmt_trndate { get; set; }
        public string fmt_trndatetime { get; set; }
        public string wt_trntype { get; set; }
        public string wt_trnamount { get; set; }
        public decimal fmt_trnamountdec { get; set; }
        public string fmt_trnamount { get; set; }
        public string wt_invoiceno { get; set; }
        public string wt_blnumber { get; set; }
        public string wt_rufirstname { get; set; }
        public string wt_payref { get; set; }
        public string wt_proformainvoiceno { get; set; }
        public string wt_status { get; set; }

    }

    public class clsBayan
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
        public string bd_transporter { get; set; }
        public string bd_portofloading { get; set; }
        public string bd_portofdischarge { get; set; }
        public string bd_category { get; set; }
        public string bd_vsloperatorname { get; set; }
        public string bd_linegkey { get; set; }
        public string bd_bolcount { get; set; }
        public string bd_bolnodisplay { get; set; }
        public string bd_containercount { get; set; }
        public string bd_invesselcount { get; set; }
        public string bd_yardcount { get; set; }
        public string bd_departedcount { get; set; }
        public string bd_bayanstatuscode { get; set; }
        public string bd_bayanstatusdesc1 { get; set; }
        public string bd_bayanstatusdesc2 { get; set; }
        public string bd_containerstatus { get; set; }
        public string popupofbillofladings { get; set; }
        public string bd_emailid { get; set; }
        public string bd_linkcode { get; set; }
        public string AnywhereAll { get; set; }
        public string BayanNo { get; internal set; }
        public bool Expander { get; internal set; }
    }

    public class clsDashboard
    {
        public string ru_emailid { get; set; }
        public string ru_linkcode { get; set; }
        public string ru_idno { get; set; }
        //change to string 
        public string ru_dwelldaysavg { get; set; }
        public string ru_pendingpaymentinvoicescount { get; set; }
        public string ru_volumeupdatecontainerscount { get; set; }
        public string ru_rfdcontainerscount { get; set; }
        public string ru_rfdcontainersexpirycount { get; set; }
        public string ru_containerscount { get; set; }
        public string ru_mbcontainerscount { get; set; }
        public string ru_reviewscount { get; set; }
        public string ru_reviewspendingcount { get; set; }
        public string ru_avstruckamount { get; set; }
        public string ru_avscutomclearenceamount { get; set; }
        public string ru_readytodeliverunitcount { get; set; }
        public string ru_walletbalanace { get; set; }
        public string ru_casesresolved { get; set; }
        public string ru_casesinprogress { get; set; }
        public string ru_invoicescount { get; set; }
        public string ru_invoicesamount { get; set; }
        public string ru_appoinmentscount { get; set; }
        public string ru_mibcontainerscount { get; set; }
        public string ru_r2dgatedoutcount { get; set; }
        public string ru_r2dyardcount { get; set; }
        public string ru_unitsunderdentioncount { get; set; }
        public string ru_unitneardentioncount { get; set; }
        public string ru_bannedtruckscount { get; set; }
        public string ru_eurrsgtcount { get; set; }
        public string ru_euroutsideedcount { get; set; }
        public string ru_voltoday { get; set; }
        public string ru_volthisweek { get; set; }
        public string ru_volthismonth { get; set; }
        public string ru_volcurrentyear { get; set; }
        public string ru_volpreviousyear { get; set; }
        public string ru_ytd20inchpercentage { get; set; }
        public string ru_ytd40inchpercentage { get; set; }
        public string ru_ytdreeferpercentage { get; set; }
        public string ru_ytdinyardcount { get; set; }
        public string ru_ytdgatedoutcount { get; set; }

    }
    public class clsPaymentHistory
    {
        public string ih_invoiceno { get; set; }
        public string bl_bayannumber { get; set; }
        public string bl_blnumber { get; set; }
        public string ih_consigneename { get; set; }
        public string ih_grandtotal { get; set; }
        public string ih_createddate { get; set; }
        public string ih_fmtcreateddate { get; set; }
        public string ih_validity { get; set; }
        public string ih_status { get; set; }
        public string ih_mop { get; set; }
        public string ih_proformainvoiceduedate { get; set; }
        public string ih_fmtproformainvoiceduedate { get; set; }
        public string ih_paymentref { get; set; }
        public string ih_paidon { get; set; }
        public string bl_consigneegkey { get; set; }
        public string bl_shippergkey { get; set; }
        public string bl_custombrokeragent { get; set; }
        public string bl_shippinglineid { get; set; }
        public string bl_transporter { get; set; }
        public string bl_linegkey { get; set; }
        public string ih_nationalid { get; set; }
        public string ih_invoicedate { get; set; }
        public string ih_fmtinvoicedate { get; set; }
        public string ih_emailid { get; set; }
        public string ih_linkcode { get; set; }
        public string ih_token { get; set; }
        public string ih_statusar { get; set; }

    }



    public class clsAPPOINTMENTLIST
    {
        public string cd_containernumber { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string cd_apptnbr { get; set; }
        public string cd_apptdate { get; set; }
        public string cd_fmtapptdate { get; set; }
        public string cd_apptstatus { get; set; }
        public string cd_groupname { get; set; }
        public string cd_tmsrefno { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_shippingicon { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_consigneedesc1 { get; set; }
        public string cd_consigneedesc2 { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_shipperdesc1 { get; set; }
        public string cd_shipperdesc2 { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_lastmodifieddate { get; set; }
        public string cd_transporter { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }

    }

    // API Name 
    // --getBayanTrackingDetails
    //--getBOLHeader

    // API Name
    //--getBillofLading
    //  --getContainerDetailsHeader
    public class clsListofbillofladings
    {
        public string AnywhereAll { get; set; }
        public string bl_bayannumber { get; set; }
        public string bl_transporter { get; set; }
        public string bl_shippinglineid { get; set; }
        public string bl_custombrokeragent { get; set; }
        public string bl_invoiceconsignee { get; set; }

        public string bl_gkey { get; set; }
        public string bl_blnumber { get; set; }
        public string bl_visitgkey { get; set; }
        public string bl_bolstatuscode { get; set; }
        public string bl_shippingline { get; set; }
        public string bl_shippinglineimage { get; set; }
        public string bl_portofload { get; set; }
        public string bl_portofdischsrge { get; set; }
        public string bl_consigneedesc1 { get; set; }
        public string bl_shipperdesc1 { get; set; }
        public string bl_vesselvisitid { get; set; }
        public string bl_vesselname1 { get; set; }
        public string bl_blcategory { get; set; }
        public string bl_transitcountcontainer { get; set; }
        public string bl_commodity { get; set; }
        public string bl_consigneegkey { get; set; }
        public string bl_shippergkey { get; set; }
        public string bl_loaddischargecount { get; set; }
        public string bl_inspectioncount { get; set; }
        public string bl_inspectionimage { get; set; }
        public string bl_holdcount { get; set; }
        public string bl_holdimage { get; set; }
        public string bl_statuscode { get; set; }
        public string bl_statusdesc1 { get; set; }
        public string bl_statusdesc2 { get; set; }
        public string bl_proformainvoicenumber { get; set; }
        public string bl_appointments { get; set; }
        public string bl_departedcount { get; set; }
        public string bl_departedimage { get; set; }
        public string ntotal { get; set; }
        public string yardtotal { get; set; }
        public string deptotal { get; set; }
        public string containerstatus { get; set; }
        public string popupbolcommodity { get; set; }
        public string cd_invoiceable { get; set; }
        public string cd_payable { get; set; }
        public string cd_appbookable { get; set; }
        public string bl_ihproformainvoicenumber { get; set; }
        public string bl_ihinvoicenumber { get; set; }
        public string bl_ihstatus { get; set; }
        public string bl_damageflag { get; set; }
        public int bl_damagepopup { get; set; }
        public string bl_emailid { get; set; }
        public string bl_linkcode { get; set; }
        public string bl_Statuscolour { get; set; }

    }

    public class clsBayanpopup
    {

        public string bld_bayannumber { get; set; }
        public string bld_blnumber { get; set; }
        public int bld_count { get; set; }
        //public string cd_shippergkey { get; set; }
        //public string cd_bayannumber { get; set; }

        //public string bld_billoflading { get; set; }
        //public string cd_emailid { get; set; }
        //public string cd_linkcode { get; set; }
        //public string cd_token { get; set; }

    }

    public class clsHoldgoodPopup
    {
        public string hl_unitgkey { get; set; }
        public string ht_desc1 { get; set; }
        public string ht_desc2 { get; set; }
        public string ca_name1 { get; set; }
        public string ca_name2 { get; set; }
        public string hl_applieddate { get; set; }
        public string hl_appliedtime { get; set; }
        public string ht_category { get; set; }
        public string ExpCategory { get; set; }
    }

    // API Name
    //---getBOLPopupDetails
    public class clsCommoditypopup
    {
        public string cd_commodity { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string cd_blgkey { get; set; }
        public string cd_blnumber { get; set; }

    }

    //    API Name
    // --getContainerDetails
    //--getContainers
    public class clsListofcontainer
    {
        public string AnyWhere { get; set; }
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
        public string cd_damagedetails { get; set; }
        public string cd_arrived { get; set; }
        public string cd_fmarrived { get; set; }
        public string cd_discrecivaltime { get; set; }
        public string cd_dischargeimage { get; set; }
        public string cd_timeout { get; set; }
        public string cd_fmtdiscrecivaltime { get; set; }
        public string cd_movetoinspectiontime { get; set; }
        public string cd_inspectionimage { get; set; }
        public string cd_fmtmovetoinspectiontime { get; set; }
        public string cd_inspectioncomplete { get; set; }
        public string cd_fmtinspectioncomplete { get; set; }
        public string cd_readyfordeliverytime { get; set; }
        public string cd_fmreadyfordeliverytime { get; set; }
        public string cd_prepickupissuedtime { get; set; }
        public string cd_fmprepickissuedtime { get; set; }
        public string cd_appointmentimage { get; set; }
        public string cd_gatedouttime { get; set; }
        public string cd_gateimage { get; set; }
        public string cd_depotimage { get; set; }
        public string cd_fmgatedouttime { get; set; }
        public string cd_gaugeunitsize { get; set; }
        public string cd_dryreefer { get; set; }
        public string cd_detention { get; set; }
        public string cd_emptydepot { get; set; }
        public string cd_emptydepot_eng { get; set; }
        public string cd_emptydepot_ara { get; set; }

        public string cd_apptnbr { get; set; }
        public string cd_apptdate { get; set; }
        public string cd_apptstatus { get; set; }
        public string cd_createddate { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_lastmodifieddate { get; set; }
        public string cd_transporter { get; set; }
        public string cd_priorityholdtypeno { get; set; }
        public string cd_priorityholdtype { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_statusdesc1 { get; set; }
        public string cd_statusdesc2 { get; set; }
        public string cd_discrecivaltime_month { get; set; }
        public string cd_prepickupissuedtime_month { get; set; }
        public string cd_gatedouttime_month { get; set; }
        public string popupcontainer { get; set; }
        public string damagedetailspopup { get; set; }
        public string cd_invoiceflag { get; set; }
        public string cd_invoicetext { get; set; }
        public string cd_damageflag { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_freightkindapiimage { get; set; }
        public string cd_gaugeunitsizeapiimage { get; set; }
        public string cd_dryreeferapiimage { get; set; }
        public string cd_discrecivaltimeapiimage { get; set; }
        public string cd_movetoinspectiontimeapiimage { get; set; }
        public string cd_fmprepickissuedtimeapiimage { get; set; }
        public string cd_gatedouttimeapiimage { get; set; }


    }

    public class clsDAMAGEPOPUP
    {
        public string PDFSNO { get; set; }
        public string PDFContainerNo { get; set; }
        public string PDFName { get; set; }
        public string SharePointWebUrl { get; set; }


    }




    public class ClsEMAILNOTIFICATIONSLIST
    {
        public int SNO { get; set; }
        public string smt_code { get; set; }
        public string smt_categorycode { get; set; }
        public string smt_categorydesc1 { get; set; }
        public string smt_categorydesc2 { get; set; }
        public string smt_subject1 { get; set; }
        public string smt_subject2 { get; set; }
        public string smm_tomailid { get; set; }
        public string smm_sentdt { get; set; }
        public string smm_message1 { get; set; }
        public string smm_message2 { get; set; }
        public string smm_displaysentdt { get; set; }
        public string smm_fmtdisplaysentdt { get; set; }

    }

    public class clsEMPTYUNITRETURNCARRIERFILTER
    {
        public string value { get; set; }
        public string text { get; set; }
        public string bd_shippinglinedesc2 { get; set; }
        public string cd_transporter { get; set; }

    }

    public class clsEMPTYUNITRETURNEMPTYDEPOTFILTER
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_transporter { get; set; }

    }

    public class clsEMPTYUNITRETURNSIZEFILTER
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_transporter { get; set; }

    }



    public class clsEMPTYRETURNUSERDTO
    {
        public string cd_shipperdesc1 { get; set; }
        public string cd_containernumber { get; set; }
        public string cd_size { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_detention { get; set; }
        public string cd_fmtdetention { get; set; }
        public string cd_emptydepot { get; set; }
        public string cd_transporter { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_gatedouttime { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }


    }


    //     API Name
    //---getAppointmentList
    public class clsAppointmentlist
    {
        public string cd_containernumber { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string cd_apptnbr { get; set; }
        public string cd_apptdate { get; set; }
        public string cd_fmtapptdate { get; set; }
        public string cd_apptstatus { get; set; }
        public string cd_groupname { get; set; }
        public string cd_tmsrefno { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_shippingicon { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_consigneedesc1 { get; set; }
        public string cd_consigneedesc2 { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_shipperdesc1 { get; set; }
        public string cd_shipperdesc2 { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_lastmodifieddate { get; set; }
        public string cd_transporter { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }

    }

    //  API Name
    //--getDwelldaysDetails
    //--getReeferFreeDaysDetails
    //--getUnitDetails

    public class clsListviewdwelldays
    {
        public string AnywhereAll { get; set; }
        public string cd_containernumber { get; set; }
        public string cd_size { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string cd_portofdischarge { get; set; }
        public string cd_gatedouttime { get; set; }
        public string cd_fmtgatedouttime { get; set; }
        public string cd_dwelldays { get; set; }
        public string cd_reeferdwelldays { get; set; }
        public string cd_shipperdesc1 { get; set; }
        public string cd_nooffreedays { get; set; }
        public string cd_freedays { get; set; }
        public string cd_lastfreedays { get; set; }
        public string cd_vesselname1 { get; set; }
        public string cd_obvoyage { get; set; }
        public string cd_category { get; set; }
        public string cd_freightkind { get; set; }
        public string cd_portofloading { get; set; }
        public string cd_statusdesc1 { get; set; }
        public string cd_statusdesc2 { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_transporter { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_dgdetails { get; set; }
        public string cd_emptydepot { get; set; }
        public string cd_discrecivaltime { get; set; }
        public string cd_fmtdiscrecivaltime { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_dryreefer { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }

    }

    public class clsListViewInvoices
    {
        public string ih_proformainvoiceno { get; set; }
        public string ih_billofladingno { get; set; }
        public string ih_consigneename { get; set; }
        public string ih_grandtotal { get; set; }
        public string ih_proformainvoicedate { get; set; }
        public string ih_fmtproformainvoicedate { get; set; }
        public string ih_invoicedate { get; set; }
        public string ih_fmtinvoicedate { get; set; }
        public string ih_status { get; set; }
        public string ih_mop { get; set; }
        public string ih_invoiceno { get; set; }
        public string ih_paymentref { get; set; }
        public string ih_paidon { get; set; }
        public string ih_fmtpaidon { get; set; }
        public string ih_nationalid { get; set; }
        public string ih_proformainvoicedocument { get; set; }
        public string ih_invoicedocument { get; set; }
        public string AnywhereAll { get; set; }
        public string bl_invoiceconsignee { get; set; }
    }


    //    API Name
    //--getPaymentHistoryDetails
    public class clsListviewpaymenthistory
    {
        public string ih_invoiceno { get; set; }
        public string bl_bayannumber { get; set; }
        public string bl_blnumber { get; set; }
        public string ih_consigneename { get; set; }
        public string ih_grandtotal { get; set; }
        public string ih_createddate { get; set; }
        public string ih_fmtcreateddate { get; set; }
        public string ih_validity { get; set; }
        public string ih_status { get; set; }
        public string ih_mop { get; set; }
        public string ih_proformainvoiceduedate { get; set; }
        public string ih_fmtproformainvoiceduedate { get; set; }
        public string ih_paymentref { get; set; }
        public string ih_paidon { get; set; }
        public string bl_consigneegkey { get; set; }
        public string bl_shippergkey { get; set; }
        public string bl_custombrokeragent { get; set; }
        public string bl_transporter { get; set; }
        public string bl_linegkey { get; set; }
        public string ih_nationalid { get; set; }
        public string ih_invoicedate { get; set; }
        public string ih_fmtinvoicedate { get; set; }
        public string ih_emailid { get; set; }
        public string ih_linkcode { get; set; }

    }

    //    API Name
    //--getEvaluateDetails
    public class clsEvaluateform
    {
        public string bl_bayannumber { get; set; }
        public string bl_gkey { get; set; }
        public string bl_blnumber { get; set; }
        public string bl_statuscode { get; set; }
        public int bl_action { get; set; }
        public string bl_ratings1 { get; set; }
        public string bl_ratings2 { get; set; }
        public string bl_ratings3 { get; set; }
        public string bl_ratings4 { get; set; }
        public string bl_comments1 { get; set; }
        public string bl_comments2 { get; set; }
        public string bl_comments3 { get; set; }
        public string bl_comments4 { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_transporter { get; set; }
        public string cd_shippinglineid { get; set; }
        public string bl_linkcode { get; set; }
        public string bl_emailid { get; set; }

    }

    //     API Name
    //--getReadyToDeliveryDetails
    public class clsReadytodelivery
    {
        public string AnywhereAll { get; set; }
        public string cd_containernumber { get; set; }
        public string cd_size { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string cd_portofdischarge { get; set; }
        public string cd_gatedouttime { get; set; }
        public string cd_fmtgatedouttime { get; set; }
        public string cd_dwelldays { get; set; }
        public string cd_reeferdwelldays { get; set; }
        public string cd_shipperdesc1 { get; set; }
        public string cd_nooffreedays { get; set; }
        public string cd_freedays { get; set; }
        public string cd_lastfreedays { get; set; }
        public string cd_vesselname1 { get; set; }
        public string cd_obvoyage { get; set; }
        public string cd_category { get; set; }
        public string cd_freightkind { get; set; }
        public string cd_portofloading { get; set; }
        public string cd_statusdesc1 { get; set; }
        public string cd_statusdesc2 { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_transporter { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_dgdetails { get; set; }
        public string cd_emptydepot { get; set; }
        public string cd_discrecivaltime { get; set; }
        public string cd_fmtdiscrecivaltime { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_dryreefer { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_emailid { get; set; }

    }

    //     API Name
    //--getBookforManualInspectionDetails
    public class clsBookformanualinspection
    {
        public string hl_appliedtime { get; set; }
        public string cd_containernumber { get; set; }
        public string cd_size { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_shipperdesc1 { get; set; }
        public string cd_shipperdesc2 { get; set; }
        public string cd_vesselvisitgkey { get; set; }
        public string cd_vesselvisitid { get; set; }
        public string cd_vesselname1 { get; set; }
        public string cd_vesselname2 { get; set; }
        public string cd_obvoyage { get; set; }
        public string cd_category { get; set; }
        public string cd_freightkind { get; set; }
        public string cd_portofloading { get; set; }
        public string cd_portofdischarge { get; set; }
        public string cd_transitstatus { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_statusdesc1 { get; set; }
        public string cd_statusdesc2 { get; set; }
        public string cd_discrecivaltime { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_addtionalstatus { get; set; }
        public string hl_fmtappliedtime { get; set; }
        public string cd_fmtdiscrecivaltime { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }
        public string cd_unitgkey { get; set; }
    }
    public class clsManualInsCarrierFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string bd_shippinglinedesc2 { get; set; }
        public string cd_agentkey { get; set; }
    }
    public class clsManualInsSizeFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_agentkey { get; set; }
    }
    public class clsManualInsCategoryFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_agentkey { get; set; }
    }
    public class clsManualInsFreightKindFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_agentkey { get; set; }
    }
    public class clsManualInsPolFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_agentkey { get; set; }
    }
    public class clsManualInsPodFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_agentkey { get; set; }
    }



    //   Banned Trucks : Class Files:
    //=================================
    public class clsBannedtrucks
    {
        public string AnywhereAll { get; set; }
        public string bant_truckno { get; set; }
        public string bant_bandate { get; set; }
        public string bant_fmtbandate { get; set; }
        public string bant_typeofban { get; set; }
        public string bant_reason { get; set; }
        public string bant_status { get; set; }
        public string bant_action { get; set; }
        public string bant_transportergkey { get; set; }
        public string bant_releaserequestdatetime { get; set; }
        public string bant_requestnotes { get; set; }
        public string bant_createddate { get; set; }
        public string bant_modifieddate { get; set; }
        public string bant_emailid { get; set; }
        public string bant_linkcode { get; set; }
        public string bant_token { get; set; }

    }
    public class clsBannedtrucksBanType
    {
        public string value { get; set; }
        public string text { get; set; }
        public string bant_transportergkey { get; set; }

    }
    public class clsBannedtrucksBanReason
    {
        public string value { get; set; }
        public string text { get; set; }
        public string bant_transportergkey { get; set; }

    }

    public class clsEVALUATEFORM
    {
        public string bl_bayannumber { get; set; }
        public string bl_gkey { get; set; }
        public string bl_blnumber { get; set; }
        public string bl_statuscode { get; set; }
        public string bl_statusdesc1 { get; set; }
        public string bl_statusdesc2 { get; set; }
        public int bl_action { get; set; }
        public string bl_ratings1 { get; set; }
        public string bl_ratings2 { get; set; }
        public string bl_ratings3 { get; set; }
        public string bl_ratings4 { get; set; }
        public string bl_comments1 { get; set; }
        public string bl_comments2 { get; set; }
        public string bl_comments3 { get; set; }
        public string bl_comments4 { get; set; }
        public string bl_consigneegkey { get; set; }
        public string bl_shippergkey { get; set; }
        public string bl_custombrokeragent { get; set; }
        public string bl_transporter { get; set; }
        public string bl_shippinglineid { get; set; }
        public string bl_linkcode { get; set; }
        public string bl_emailid { get; set; }
        public string bl_token { get; set; }

    }

    public class clsDamageContainers
    {
        public string cd_fmtdiscrecivaltime { get; set; }
        public string cd_fmtgatedouttime { get; set; }
        public string cd_emptydepot { get; set; }
        public string cd_damagedetails { get; set; }
        public string cd_transporter { get; set; }

        public string cd_containernumber { get; set; }
        public string cd_blnumber { get; set; }
    }


    //      API Name
    //--getEmptyReturnDetails
    public class clsEmptyreturn
    {
        public string cd_shipperdesc1 { get; set; }
        public string cd_containernumber { get; set; }
        public string cd_size { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_detention { get; set; }
        public string cd_fmtdetention { get; set; }
        public string cd_emptydepot { get; set; }
        public string cd_transporter { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_gatedouttime { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }

    }


    //getNodificationEmailUser
    public class clsEmailnotifications
    {
        public string smt_code { get; set; }
        public string smt_categorycode { get; set; }
        public string smt_categorydesc1 { get; set; }
        public string smt_categorydesc2 { get; set; }
        public string smt_subject1 { get; set; }
        public string smt_subject2 { get; set; }
        public string smm_tomailid { get; set; }
        public string smm_sentdt { get; set; }
        public string smm_message1 { get; set; }
        public string smm_message2 { get; set; }
        public string smm_displaysentdt { get; set; }
        public DateTime smm_fmtdisplaysentdt { get; set; }

    }


    //getNodificationSmsUser

    public class clsSMSNotifications
    {
        public string sst_categorycode { get; set; }
        public string sst_categorydesc1 { get; set; }
        public string sst_categorydesc2 { get; set; }
        public string sm_mobileno { get; set; }
        public string sm_message1 { get; set; }
        public string sm_message2 { get; set; }
        public string sm_displaysentdt { get; set; }
        public string sm_sentdt { get; set; }
        public DateTime sm_fmtdisplaysentdt { get; set; }

    }


    //getUserDetails
    public class clsUsersDetails
    {
        public string u_recid { get; set; }
        public string u_grpid { get; set; }
        public string u_code { get; set; }
        public string u_name1 { get; set; }
        public string u_name2 { get; set; }
        public string u_pwd { get; set; }
        public string u_language { get; set; }
        public string u_email { get; set; }
        public string u_mobile { get; set; }
        public string u_disable { get; set; }
        public string u_sec { get; set; }
        public string u_comm1 { get; set; }
        public string u_comm2 { get; set; }
        public int g_recid { get; set; }
        public string g_name1 { get; set; }
        public string g_name2 { get; set; }
        public string g_code { get; set; }

    }


    //getCmsMailDetails
    public class clsCMSMaildetail
    {
        public int smm_recid { get; set; }
        public int smm_smtrecid { get; set; }
        public int smm_rurecid { get; set; }
        public int smm_curecid { get; set; }
        public int smm_sbrecid { get; set; }
        public string smm_code { get; set; }
        public string smm_tomailid { get; set; }
        public string smm_subject1 { get; set; }
        public string smm_subject2 { get; set; }
        public string smm_message1 { get; set; }
        public string smm_message2 { get; set; }
        // public string smm_attachment { get; set; }
        public string smm_senderemailid { get; set; }
        public string smm_displayname1 { get; set; }
        public string smm_displayname2 { get; set; }
        public int smm_scheduleddt { get; set; }
        public int smm_sentdt { get; set; }
        public string smm_status { get; set; }
        public string smm_statusmessage { get; set; }
        public string smm_type { get; set; }
        public string smm_displaysentdt { get; set; }
        public string smt_emailcc { get; set; }
        public int smt_recid { get; set; }
    }


    //getMailMessage
    public class clsMailtemplates
    {
        public int smt_recid { get; set; }
        public string smt_code { get; set; }
        public string smt_subject1 { get; set; }
        public string smt_subject2 { get; set; }
        public string smt_message1 { get; set; }
        public string smt_message2 { get; set; }
        public string smt_attachment { get; set; }
        public string smt_senderemailid { get; set; }
        public string smt_senderpassword { get; set; }
        public string smt_displayname1 { get; set; }
        public string smt_displayname2 { get; set; }
        public string smt_query { get; set; }
        public string smt_emailfield1 { get; set; }
        public string smt_emailfield2 { get; set; }
        public string smt_emailfield3 { get; set; }
        public string smt_comm1 { get; set; }
        public string smt_comm2 { get; set; }
        public int smt_sort { get; set; }
        public string smt_disable { get; set; }
        public string smt_emailcc { get; set; }

    }

    //getSmsMessage

    public class clsSMStemplates
    {
        public int sst_recid { get; set; }
        public string sst_code { get; set; }
        public string sst_message1 { get; set; }
        public string sst_message2 { get; set; }
        public string sst_query { get; set; }
        public string sst_mobilefield1 { get; set; }
        public string sst_mobilefield2 { get; set; }
        public string sst_mobilefield3 { get; set; }
        public string sst_comm1 { get; set; }
        public string sst_comm2 { get; set; }
        public int sst_sort { get; set; }
        public string sst_disable { get; set; }

    }


    //getRegisterApplicationDetails

    public class clsRegisterapplications
    {
        public int ra_recid { get; set; }
        public string ra_applicationname { get; set; }
        public string ra_pocname { get; set; }
        public string ra_pocmobile { get; set; }
        public string ra_pocemail { get; set; }
        public string ra_acname { get; set; }
        public string ra_acmobile { get; set; }
        public string ra_acemail { get; set; }
        public string ra_requestpageurl { get; set; }
        public string ra_landingpageurl { get; set; }
        public string ra_ssourl { get; set; }
        public string ra_expiryapplicable { get; set; }
        public string ra_expirydate { get; set; }
        public string ra_licensekey { get; set; }
        public string ra_fmtexpirydate { get; set; }

    }

    //getAppoinmentDetails
    public class clsAppointmentcardview
    {
        public int app_recid { get; set; }
        public string app_billofladingnumber { get; set; }
        public string app_containernumber { get; set; }
        public int app_shippingcompanyrecid { get; set; }
        public string app_shippingcompanycode { get; set; }
        public string cd_category { get; set; }
        public string app_shippingcompanyname1 { get; set; }
        public string app_shippingcompanyname2 { get; set; }
        public string app_fmtappointmentdate { get; set; }
        public string app_appointmentdate { get; set; }
        public string app_slot1 { get; set; }
        public string app_slot2 { get; set; }
        public string app_slot3 { get; set; }
        public string app_slot4 { get; set; }
        public string app_slot5 { get; set; }
        public string app_slot6 { get; set; }
        public string app_slot7 { get; set; }
        public string app_slot8 { get; set; }
        public string app_slot9 { get; set; }
        public string app_slot10 { get; set; }
        public string app_slot11 { get; set; }
        public string app_slot12 { get; set; }
        public string app_quarter { get; set; }
        public string app_bookeduserid { get; set; }
        public string app_bookeddatetime { get; set; }
        public string app_emailid { get; set; }
        public string cd_apptstatus { get; set; }
        public string cd_statuscode { get; set; }
        public string app_transporter { get; set; }
        public string cd_unitgkey { get; set; }
        public string national_id { get; set; }
        public string cd_apptdate { get; set; }
        public string cd_apptnbr { get; set; }
        public string cd_groupname { get; set; }
        public string cd_tmsrefno { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_transporter { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_agentkey { get; set; }

    }

    public class ClsCRMTICKETACTIVITIES
    {
        public string cta_casegkey { get; set; }
        public string cta_origiontype { get; set; }
        public string cta_id { get; set; }
        public string cta_decsc1 { get; set; }
        public string cta_decsc2 { get; set; }
        public string cta_attachment { get; set; }
        public string cta_createddatetime { get; set; }
        public string cta_fmtcreateddatetime { get; set; }

    }



    //getVesselArrivalDetails
    public class clsVesselArrival
    {
        public string vd_vgkey { get; set; }
        public string vd_gkey { get; set; }
        public string vd_visitid { get; set; }
        public string vd_vesselname1 { get; set; }
        public string cardview_vesselname { get; set; }
        public string vd_vesselname2 { get; set; }
        public string vd_ibvoyage { get; set; }
        public string vd_obvoyage { get; set; }
        public string vd_serviceid { get; set; }
        public string vd_expectedtimeofarrival { get; set; }
        public string vd_fmtexpectedtimeofarrival { get; set; }
        public string vd_expectedtimeofdeparture { get; set; }
        public string vd_fmtexpectedtimeofdeparture { get; set; }
        public string vd_actualtimeofarrival { get; set; }
        public string vd_startwork { get; set; }
        public string vd_endwork { get; set; }
        public string vd_fmtactualtimeofarrival { get; set; }
        public string vd_actualtimeofdeparture { get; set; }
        public string vd_fmtactualtimeofdeparture { get; set; }
        public string vd_cargocutofftime { get; set; }
        public string vd_fmtcargocutofftime { get; set; }
        public string vd_visitstatus { get; set; }
        public string vd_vsloperator { get; set; }
        public string vd_createddate { get; set; }
        public string vd_lastmodifieddate { get; set; }
        public string vd_vesselstatus { get; set; }
        public string vd_vsloperatorname { get; set; }

        public string vd_shippinglineid { get; set; }
        public string vd_shippinglineimage { get; set; }
    }


    //Detentionmanagement: Class Files
    //=====================================		




    public class clsDetentionmanagement
    {
        public string cd_blnumber { get; set; }
        public string cd_containernumber { get; set; }
        public string cd_size { get; set; }
        public string cd_bayannumber { get; set; }
        public string cd_discrecivaltime { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_shipperdesc1 { get; set; }
        public string cd_shipperdesc2 { get; set; }
        public string cd_detention { get; set; }
        public string cd_fmtdetention { get; set; }
        public string cd_fmtdiscrecivaltime { get; set; }
        public string cd_fmtgatedouttime { get; set; }
        public int cd_dwelldays { get; set; }
        public string cd_transporter { get; set; }
        public string cd_statuscode { get; set; }
        public string cd_gatedouttime { get; set; }
        public string cd_platenbr { get; set; }
        public string cd_truckgkey { get; set; }
        public string cd_truckcogkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }


    }
    public class clsDetentionManSizeFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_transporter { get; set; }
    }
    public class clsDetentionManCarrierFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string bd_shippinglinedesc2 { get; set; }
        public string cd_transporter { get; set; }
    }


    //getVesselInportDetails

    public class clsInportport
    {
        public string vd_vgkey { get; set; }
        public string vd_gkey { get; set; }
        public string vd_visitid { get; set; }
        public string vd_vesselname1 { get; set; }
        public string cardview_vesselname { get; set; }
        public string vd_vesselname2 { get; set; }
        public string vd_ibvoyage { get; set; }
        public string vd_obvoyage { get; set; }
        public string vd_serviceid { get; set; }
        public string vd_expectedtimeofarrival { get; set; }
        public string vd_fmtexpectedtimeofarrival { get; set; }
        public string vd_expectedtimeofdeparture { get; set; }
        public string vd_fmtexpectedtimeofdeparture { get; set; }
        public string vd_actualtimeofarrival { get; set; }
        public string vd_startwork { get; set; }
        public string vd_endwork { get; set; }

        public string vd_fmtactualtimeofarrival { get; set; }
        public string vd_actualtimeofdeparture { get; set; }
        public string vd_fmtactualtimeofdeparture { get; set; }
        public string vd_cargocutofftime { get; set; }
        public string vd_fmtcargocutofftime { get; set; }
        public string vd_visitstatus { get; set; }
        public string vd_vsloperator { get; set; }
        public string vd_createddate { get; set; }
        public string vd_lastmodifieddate { get; set; }
        public string vd_vesselstatus { get; set; }
        public string vd_vsloperatorname { get; set; }

        public string vd_shippinglineid { get; set; }
        public string vd_shippinglineimage { get; set; }
        public string vd_vesselstage { get; set; }

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

    }


    //getVesselDepartureDetails

    public class clsDeparture
    {
        public string vd_vgkey { get; set; }
        public string vd_gkey { get; set; }
        public string vd_visitid { get; set; }
        public string vd_vesselname1 { get; set; }
        public string cardview_vesselname { get; set; }
        public string vd_vesselname2 { get; set; }
        public string vd_ibvoyage { get; set; }
        public string vd_obvoyage { get; set; }
        public string vd_serviceid { get; set; }
        public string vd_expectedtimeofdeparture { get; set; }
        public string vd_fmtexpectedtimeofdeparture { get; set; }
        public string vd_actualtimeofarrival { get; set; }
        public string vd_startwork { get; set; }
        public string vd_endwork { get; set; }
        public string vd_fmtactualtimeofarrival { get; set; }
        public string vd_actualtimeofdeparture { get; set; }
        public string vd_fmtactualtimeofdeparture { get; set; }
        public string vd_cargocutofftime { get; set; }
        public string vd_fmtcargocutofftime { get; set; }
        public string vd_visitstatus { get; set; }
        public string vd_vsloperator { get; set; }
        public string vd_createddate { get; set; }
        public string vd_lastmodifieddate { get; set; }
        public string vd_vesselstatus { get; set; }
        public string vd_vsloperatorname { get; set; }

        public string vd_shippinglineid { get; set; }
        public string vd_shippinglineimage { get; set; }
    }

    //Ticket Screen 
    public class clsTickets
    {
        public int SNO { get; set; }
        public int ct_recid { get; set; }
        public string ct_ticketnumber { get; set; }
        public string ct_categorycode { get; set; }
        public string ct_categorydesc1 { get; set; }
        public string ct_categorydesc2 { get; set; }
        public string ct_statuscode { get; set; }
        public string ct_statusdesc1 { get; set; }
        public string ct_statusdesc2 { get; set; }
        public string ct_casetypecode { get; set; }
        public string ct_casetypedesc1 { get; set; }
        public string ct_casetypedesc2 { get; set; }
        public string ct_casesubtypecode { get; set; }
        public string ct_casesubtypedesc1 { get; set; }
        public string ct_casesubtypedesc2 { get; set; }
        public string ct_createddatetime { get; set; }
        public string ct_modifieddatetime { get; set; }
        public string ct_usercode { get; set; }
        public string ct_username { get; set; }
        public string ct_message { get; set; }
        public string ct_fmtcreateddatetime { get; set; }
        public string ct_fmtmodifieddatetime { get; set; }
        public string ct_bellflag { get; set; }
        public string ct_title { get; set; }
        public string ct_caseorigincode { get; set; }
        public string ct_caseorigindesc1 { get; set; }
        public string ct_caseorigindesc2 { get; set; }
        public string ct_comments { get; set; }
        public string ct_titlebellicon { get; set; }
        public string ct_casegkey { get; set; }
        public string crm_queue { get; set; }


    }




    //Api name :-
    //getCmsMailTemplateCount
    public class clscmsEmailTemplatecount
    {
        public int smt_recid { get; set; }
        public string smt_code { get; set; }
        public int smm_smtrecid { get; set; }
        public int totalmessage { get; set; }

    }
    // Api name :-
    //getCmsSmsTemplateCount
    public class clscmsSMSTemplatecount
    {
        public int sst_recid { get; set; }
        public string sst_code { get; set; }
        public int sm_sstrecid { get; set; }
        public int totalmessage { get; set; }

    }




    public class clsconsigneefilter
    {
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string value { get; set; }
        public string text { get; set; }
        public string bd_consigneedesc2 { get; set; }
        public Boolean cd_consigneevalue { get; set; }

    }

    public class clsNOTIFICATIONEMAILCOUNT
    {
        public string smm_tomailid { get; set; }
        public string smt_categorycode { get; set; }
        public string smt_categorydesc1 { get; set; }
        public string smt_categorydesc2 { get; set; }
        public string mailcount { get; set; }
        public string belliconcat { get; set; }

    }

    public class clsNOTIFICATIONMOBILECOUNT
    {
        public string sm_mobileno { get; set; }
        public string sst_categorycode { get; set; }
        public string sst_categorydesc1 { get; set; }
        public string sst_categorydesc2 { get; set; }
        public string msgcount { get; set; }
        public string belliconcatsms { get; set; }

    }

    public class clsSMSNOTIFICATIONSList
    {
        public int SNO { get; set; }
        public string sst_categorycode { get; set; }
        public string sst_categorydesc1 { get; set; }
        public string sst_categorydesc2 { get; set; }
        public string sm_mobileno { get; set; }
        public string sm_message1 { get; set; }
        public string sm_message2 { get; set; }
        public string sm_displaysentdt { get; set; }
        public string sm_sentdt { get; set; }
        public string sm_fmtdisplaysentdt { get; set; }

    }



    public class clsClsEMAILNOTIFICATIONSLIST
    {
        public int SNO { get; set; }
        public string smt_code { get; set; }
        public string smt_categorycode { get; set; }
        public string smt_categorydesc1 { get; set; }
        public string smt_categorydesc2 { get; set; }
        public string smt_subject1 { get; set; }
        public string smt_subject2 { get; set; }
        public string smm_tomailid { get; set; }
        public string smm_sentdt { get; set; }
        public string smm_message1 { get; set; }
        public string smm_message2 { get; set; }
        public string smm_displaysentdt { get; set; }
        public string smm_fmtdisplaysentdt { get; set; }

    }
    public class clsVesselfilter
    {
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string value { get; set; }
        public string text { get; set; }
        public string bd_vesselname2 { get; set; }

    }
    public class clsCarrierfilter
    {
        public string cd_bayannumber { get; set; }
        public string cd_blnumber { get; set; }
        public string value { get; set; }
        public string text { get; set; }
        public string bd_shippinglinedesc2 { get; set; }


    }



    public class clsContactUS
    {
        public string cu_name1 { get; set; }
        public string cu_name2 { get; set; }
        public string cu_emailid { get; set; }
        public string cu_subject1 { get; set; }
        public string cu_subject2 { get; set; }
        public string cu_message1 { get; set; }
        public string cu_message2 { get; set; }
        public int cu_createddate { get; set; }
        public int cu_createdtime { get; set; }
    }
    public class clsContainerStatusFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string texta { get; set; }
    }

    public class clsContainerDamageGoodFt
    {
        public string cd_blnumber { get; set; }
        public string cd_commodity { get; set; }
    }


    public class clsDwellDaysSizeFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }
    }
    public class clsDwellDaysCarrierFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string bd_shippinglinedesc2 { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }


    }
    public class clsReadytoDeliveryCarrierFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string bd_shippinglinedesc2 { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }
    }
    public class clsReadytoDeliveryCategoryFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }
    }
    public class clsReadytoDeliverySizeFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }
    }
    public class clsReadytoDeliveryFreightFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }
    }
    public class clsReadytoDeliveryPOLFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }

    }
    public class clsReadytoDeliveryPODFilter
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cd_consigneegkey { get; set; }
        public string cd_shippergkey { get; set; }
        public string cd_custombrokeragent { get; set; }
        public string cd_shippinglineid { get; set; }
        public string cd_transporter { get; set; }
        public string cd_agentkey { get; set; }
        public string cd_emailid { get; set; }
        public string cd_linkcode { get; set; }
        public string cd_token { get; set; }

    }


}
