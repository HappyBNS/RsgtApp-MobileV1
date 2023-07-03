using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.ExtraCare;

namespace RsgtApp.ViewModels
{
    public class ExtraCareContainerlistViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        public List<ExtraCareContainer> lstExtraCare { get; set; } = new List<ExtraCareContainer>();
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Tapcontaineradd { get; set; }
        public Command Taprequesthistory { get; set; }
        public Command Buttonsubmitrequest { get; set; }
        public Command Editcontainer { get; set; }
        private string strServerSlowMsg = "";
        public List<EnumCombo> lobjExtracarecontainer { get; set; } = new List<EnumCombo>();
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on Propertychange Event
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        protected bool SetProperty<T>(ref T backfield, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //Indicator Color
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");

        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGColor");
            }
        }
        //Indicator Opacity
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");

        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGOpacity");
            }
        }
        //To handle indicator
        private bool stackextraCareContainerlist = true;
        public bool StackExtraCareContainerlist
        {
            get { return stackextraCareContainerlist; }
            set
            {
                stackextraCareContainerlist = value;
                OnPropertyChanged();
                RaisePropertyChange("StackExtraCareContainerlist");
            }
        }
        //imgExtracareMenuIcon purpose of using label varaiable
        private string imgextracareMenuIcon = "";
        public string imgExtracareMenuIcon
        {
            get { return imgextracareMenuIcon; }
            set
            {
                imgextracareMenuIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgExtracareMenuIcon");
            }
        }
        //lblExtraCareContainersList purpose of using label varaiable
        private string lblextraCareContainersList = "";
        public string lblExtraCareContainersList
        {
            get { return lblextraCareContainersList; }
            set
            {
                lblextraCareContainersList = value;
                OnPropertyChanged();
                RaisePropertyChange("lblExtraCareContainersList");
            }
        }
        //lblBOL purpose of using label varaiable
        private string lblbOL = "";
        public string lblBOL
        {
            get { return lblbOL; }
            set
            {
                lblbOL = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOL");
            }
        }
        //lblContainerNo purpose of using label varaiable
        private string lblcontainerNo = "";
        public string lblContainerNo
        {
            get { return lblcontainerNo; }
            set
            {
                lblcontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerNo");
            }
        }
        //lblShippingLine1 purpose of using label varaiable
        private string lblshippingLine1 = "";
        public string lblShippingLine1
        {
            get { return lblshippingLine1; }
            set
            {
                lblshippingLine1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLine1");
            }
        }
        //lblShippingLine2 purpose of using label varaiable
        private string lblshippingLine2 = "";
        public string lblShippingLine2
        {
            get { return lblshippingLine2; }
            set
            {
                lblshippingLine2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLine2");
            }
        }
        //lblShippingLineName purpose of using label varaiable
        private string lblshippingLineName = "";
        public string lblShippingLineName
        {
            get { return lblshippingLineName; }
            set
            {
                lblshippingLineName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLineName");
            }
        }
        //lblShippingLineName2 purpose of using label varaiable
        private string lblshippingLineName2 = "";
        public string lblShippingLineName2
        {
            get { return lblshippingLineName2; }
            set
            {
                lblshippingLineName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLineName2");
            }
        }
        //lblETA purpose of using label varaiable
        private string lbleTA = "";
        public string lblETA
        {
            get { return lbleTA; }
            set
            {
                lbleTA = value;
                OnPropertyChanged();
                RaisePropertyChange("lblETA");
            }
        }
        //lblETA2 purpose of using label varaiable
        private string lbleTA2 = "";
        public string lblETA2
        {
            get { return lbleTA2; }
            set
            {
                lbleTA2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblETA2");
            }
        }
        //lblStowagePlan purpose of using label varaiable
        private string lblstowagePlan = "";
        public string lblStowagePlan
        {
            get { return lblstowagePlan; }
            set
            {
                lblstowagePlan = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStowagePlan");
            }
        }
        //lblStowagePlan2 purpose of using label varaiable
        private string lblstowagePlan2 = "";
        public string lblStowagePlan2
        {
            get { return lblstowagePlan2; }
            set
            {
                lblstowagePlan2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStowagePlan2");
            }
        }
        //BtnDelete purpose of using Button varaiable
        private string Btndelete = "";
        public string BtnDelete
        {
            get { return Btndelete; }
            set
            {
                Btndelete = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnDelete");
            }
        }
        //BtnEdit purpose of using Button varaiable
        private string Btnedit = "";
        public string BtnEdit
        {
            get { return Btnedit; }
            set
            {
                Btnedit = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnEdit");
            }
        }
        //BtnSubmitRequest purpose of using label varaiable
        private string BtnsubmitRequest = "";
        public string BtnSubmitRequest
        {
            get { return BtnsubmitRequest; }
            set
            {
                BtnsubmitRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnSubmitRequest");
            }
        }
        //imgContainerAddIcon purpose of using Image varaiable
        private string imgcontainerAddIcon = "";
        public string imgContainerAddIcon
        {
            get { return imgcontainerAddIcon; }
            set
            {
                imgcontainerAddIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgContainerAddIcon");
            }
        }
        //lblAddContainer purpose of using label varaiable
        private string lbladdContainer = "";
        public string lblAddContainer
        {
            get { return lbladdContainer; }
            set
            {
                lbladdContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAddContainer");
            }
        }
        //imgHistoryicon purpose of using label varaiable
        private string imghistoryicon = "";
        public string imgHistoryicon
        {
            get { return imghistoryicon; }
            set
            {
                imghistoryicon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgHistoryicon");
            }
        }
        //lblRequestHistory purpose of using label varaiable
        private string lblrequestHistory = "";
        public string lblRequestHistory
        {
            get { return lblrequestHistory; }
            set
            {
                lblrequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestHistory");
            }
        }
        //TxtBOLNo purpose of using Textbox varaiable
        private string TxtbOLNo = "";
        public string TxtBOLNo
        {
            get { return TxtbOLNo; }
            set
            {
                TxtbOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOLNo");
            }
        }
        //TxtContainerNo purpose of using Textbox varaiable
        private string TxtcontainerNo = "";
        public string TxtContainerNo
        {
            get { return TxtcontainerNo; }
            set
            {
                TxtcontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainerNo");
            }
        }
        //TxtShipName1 purpose of using Textbox varaiable
        private string TxtshipName1 = "";
        public string TxtShipName1
        {
            get { return TxtshipName1; }
            set
            {
                TxtshipName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtShipName1");
            }
        }
        //TxtShipName2 purpose of using Textbox varaiable
        private string TxtshipName2 = "";
        public string TxtShipName2
        {
            get { return TxtshipName2; }
            set
            {
                TxtshipName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtShipName2");
            }
        }
        //TxtETA1 purpose of using Textbox varaiable
        private string TxteTA1 = "";
        public string TxtETA1
        {
            get { return TxteTA1; }
            set
            {
                TxteTA1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtETA1");
            }
        }
        //TxtETA2 purpose of using Textbox varaiable
        private string TxteTA2 = "";
        public string TxtETA2
        {
            get { return TxteTA2; }
            set
            {
                TxteTA2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtETA2");
            }
        }
        //TxtStowage1 purpose of using Textbox varaiable
        private string Txtstowage1 = "";
        public string TxtStowage1
        {
            get { return Txtstowage1; }
            set
            {
                Txtstowage1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtStowage1");
            }
        }
        //TxtStowage2 purpose of using Textbox varaiable
        private string Txtstowage2 = "";
        public string TxtStowage2
        {
            get { return Txtstowage2; }
            set
            {
                Txtstowage2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtStowage2");
            }
        }
        //To Handel Boolen Value
        bool isenableSubmit = false;
        public bool isEnableSubmit
        {
            get { return isenableSubmit; }
            set
            {
                isenableSubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("isEnableSubmit");
            }
        }
        //To Handel Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Tapcontaineradd.ChangeCanExecute();
                Taprequesthistory.ChangeCanExecute();
                Buttonsubmitrequest.ChangeCanExecute();
            }
        }
        public System.Windows.Input.ICommand ButtonEditcontainerlist => new Command<ExtraCareContainer>(fnEditContainer);
        public System.Windows.Input.ICommand ButtonDeletcontainerlist => new Command<ExtraCareContainer>(fnDeletContainer);
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public ExtraCareContainerlistViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ExtraCareContainerlistViewModel");
            Task.Run(() => assignCms()).Wait();
            Tapcontaineradd = new Command(async () => await tapcontaineradd(), () => !IsBusy);
            Taprequesthistory = new Command(async () => await taprequesthistory(), () => !IsBusy);
            Buttonsubmitrequest = new Command(async () => await buttonsubmitrequest(), () => !IsBusy);
            isEnableSubmit = false;
            if (ExtraCare.lstExtra.Count > 0) isEnableSubmit = true;
            Task.Run(() => fnBindListData()).Wait();
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM453");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM453");

                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
               
            //}
            lblExtraCareContainersList = dbLayer.getCaption("strExtraCareRequest1", objCMS);
            imgExtracareMenuIcon = dbLayer.getCaption("imgExtraCare", objCMS);
            lblBOL = dbLayer.getCaption("strBillofLading", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
            lblShippingLine1 = dbLayer.getCaption("strShippingLine1", objCMS);
            lblShippingLine2 = dbLayer.getCaption("strShippingLine2", objCMS);
            lblShippingLineName = dbLayer.getCaption("strShippingLineNameDetail", objCMS);
            lblShippingLineName2 = dbLayer.getCaption("strShippingLineNameDetail", objCMS);
            lblETA = dbLayer.getCaption("strEta", objCMS);
            lblETA2 = dbLayer.getCaption("strEta", objCMS);
            lblStowagePlan = dbLayer.getCaption("strStowagePlanDetailPage", objCMS);
            lblStowagePlan2 = dbLayer.getCaption("strStowagePlanDetailPage", objCMS);
            BtnDelete = dbLayer.getCaption("strDelete", objCMS);
            BtnEdit = dbLayer.getCaption("strEdit", objCMS);
            BtnSubmitRequest = dbLayer.getCaption("strSubmit", objCMS);
            imgContainerAddIcon = dbLayer.getCaption("imgAddConatiner", objCMS);
            lblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            imgHistoryicon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            lobjExtracarecontainer = dbLayer.getEnum("strExtraCareShipmentsRequestLov", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            await Task.Delay(1000);
        }
        /// <summary>
        /// To go to fnBindListData
        /// </summary>
        /// <returns></returns>
        private async Task fnBindListData()
        {
            if (ExtraCare.lstExtra.Count > 0)
            {
                foreach (var item in ExtraCare.lstExtra)
                {
                    item.lbl_ContainerNo = lblContainerNo;
                    item.lbl_BOL = lblBOL;
                    item.lbl_ShippingLine1 = lblShippingLine1;
                    item.lbl_ShippingLine2 = lblShippingLine2;
                    item.lbl_ETA = lblETA;
                    item.lbl_ETA2 = lblETA2;
                    item.lbl_StowagePlan = lblStowagePlan;
                    item.lbl_StowagePlan2 = lblStowagePlan2;
                    item.Btn_Edit = BtnEdit;
                    item.Btn_Delete = BtnDelete;
                    item.lbl_ShippingLineName = lblShippingLineName;
                    item.lbl_ShippingLineName2 = lblShippingLineName2;
                    lstExtraCare.Add(item);
                }
                await Task.Delay(1000);

                if (lstExtraCare.Count > 0) isEnableSubmit = true;
            }
        }
        /// <summary>
        /// To go to buttonsubmitrequest
        /// </summary>
        /// <returns></returns>
        private async Task buttonsubmitrequest()
        {
            IsBusy = true;
            StackExtraCareContainerlist = false;
            await Task.Delay(1000);
            await fnsubmitrequest();
            StackExtraCareContainerlist = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to fnsubmitrequest
        /// </summary>
        /// <returns></returns>
        private async Task fnsubmitrequest()
        {
            try
            {
                await Task.Delay(1000);
                string lstrResult = "";
                string ltxtContainerNumber = "";
                string ltxtBillofLadingNumber = "";
                string ltxtShippingLineName1 = "";
                string ltxtExpectedArrivaldateTime1 = "";
                string ltxtStowagePlan1 = "";
                string ltxtShippingLineName2 = "";
                string ltxtExpectedArrivaldateTime2 = "";
                string ltxtStowagePlan2 = "";
                string strTempdate = lobjExtracarecontainer[0].Value.ToString();
                string[] lstCaseCode = strTempdate.Split(':');
                string lstrCT_CATEGORYCODE = lstCaseCode[0].ToString();
                string lstrCT_CASETYPECODE = lstCaseCode[1].ToString();
                string lstrCT_CASESUBTYPECODE = lstCaseCode[2].ToString();
                string lstrCT_REQUESTTYPECODE = lstCaseCode[3].ToString();
                string lstrCT_MESSAGE = "{Container No:CMAU7826262;Bill of Lading No:ANT1462936;Shipping Line-1:CMA;Shipping Line Name:CMA;Expected Arrival Date & Time:20221103;Stowage Plan:Test}";
                string lstrCT_CASEGKEY = "";
                string lstrCT_TITLE = "";
                string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
                string lstrCT_USERNAME = gblRegisteration.strLoginUserLinkcode.ToString().Trim();
                string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (ExtraCare.lstExtra.Count > 0)
                {
                    foreach (var item in ExtraCare.lstExtra)
                    {
                        ltxtContainerNumber = item.CD_ContainerNo;
                        ltxtBillofLadingNumber = item.CD_BillofLading;
                        ltxtShippingLineName1 = item.CD_ShippingLineName1;
                        ltxtExpectedArrivaldateTime1 = item.CD_ETA1;
                        ltxtStowagePlan1 = item.CD_StowagePlan1;
                        ltxtShippingLineName2 = item.CD_ShippingLineName2;
                        ltxtExpectedArrivaldateTime2 = item.CD_ETA2;
                        ltxtStowagePlan2 = item.CD_StowagePlan2;
                        lstrCT_TITLE = "Extra Care & Hot Shipment Request –" + ltxtContainerNumber;//20221115
                        lstrCT_MESSAGE += "Container No:" + ltxtContainerNumber + ";Bill of Lading No:" + ltxtBillofLadingNumber + ";Shipping Line Name1:" + ltxtShippingLineName1 + ";Expected Arrival Date & Time:" + ltxtExpectedArrivaldateTime1 + ";Stowage Plan:" + ltxtStowagePlan1 + ";Shipping Line Name2:" + ltxtShippingLineName2 + ";Expected Arrival Date & Time:" + ltxtExpectedArrivaldateTime2 + ";Stowage Plan:" + ltxtStowagePlan2 + ";~";
                    }
                    lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                }
                if (lstrResult.ToUpper() == "TRUE")
                {
                    ExtraCare.lstExtra.Clear();
                    await App.Current.MainPage?.Navigation.PushAsync(new ExtracareRequestMsg());
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to fnEditContainer
        /// </summary>
        /// <param name="objExtraCare"></param>
        private async void fnEditContainer(ExtraCareContainer objExtraCare)
        {
            int lintSNO = objExtraCare.CD_SNO;
            foreach (var item in ExtraCare.lstExtra)
            {
                if (item.CD_SNO == lintSNO)
                {
                    ExtraCare.lstSelectedExtra.Clear();
                    ExtraCare.lstSelectedExtra.Add(item);
                    await App.Current.MainPage?.Navigation.PushAsync(new ExtracareAddcontainerstep2("", ""));
                }
            }
        }
        /// <summary>
        /// To go to fnDeletContainer
        /// </summary>
        /// <param name="objExtraCare"></param>
        private async void fnDeletContainer(ExtraCareContainer objExtraCare)
        {
            int lintSNO = objExtraCare.CD_SNO;
            var index = ExtraCare.lstExtra.FindIndex(x => x.CD_SNO == lintSNO);
            if (index > -1)
            {
                var lstTemp = ExtraCare.lstExtra[index];
                ExtraCare.lstExtra.Remove(lstTemp);
                await App.Current.MainPage?.Navigation.PushAsync(new ExtraCareContainerlist());
            }
        }
        /// <summary>
        /// To go to tapcontaineradd
        /// </summary>
        /// <returns></returns>
        private async Task tapcontaineradd()
        {
            IsBusy = true;
            StackExtraCareContainerlist = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Extracare_Addcontainer());
            StackExtraCareContainerlist = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to taprequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task taprequesthistory()
        {
            IsBusy = true;
            StackExtraCareContainerlist = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Extra Care & Hot Shipment"));
            StackExtraCareContainerlist = true;
            IsBusy = false;
        }
    }
}