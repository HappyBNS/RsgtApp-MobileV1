using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Models;

namespace RsgtApp.ViewModels
{
    public class Offloadrequest2ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonreset { get; set; }
        public Command Buttonsubmitrequest { get; set; }
        public Command Tapoffloadrequesthistory { get; set; }
        private string strServerSlowMsg = "";
        public List<EnumCombo> lobjOffloadRequest { get; set; } = new List<EnumCombo>();
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
        private bool stackOffloadrequest2 = true;
        public bool StackOffloadrequest2
        {
            get { return stackOffloadrequest2; }
            set
            {
                stackOffloadrequest2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackOffloadrequest1");
            }
        }
        //TxtLocationInYard purpose of using Textbox varaiable
        private string TxtlocationInYard = "";
        public string TxtLocationInYard
        {
            get { return TxtlocationInYard; }
            set
            {
                TxtlocationInYard = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLocationInYard");
            }
        }
        //imgOffLoadIcon purpose of using Image varaiable
        private string imgoffLoadIcon = "";
        public string imgOffLoadIcon
        {
            get { return imgoffLoadIcon; }
            set
            {
                imgoffLoadIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgOffLoadIcon");
            }
        }
        //lblOffloadRequest purpose of using Label varaiable
        private string lbloffloadRequest = "";
        public string lblOffloadRequest
        {
            get { return lbloffloadRequest; }
            set
            {
                lbloffloadRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOffloadRequest");
            }
        }
        //imgRequestIcon purpose of using Image varaiable
        private string imgrequestIcon = "";
        public string imgRequestIcon
        {
            get { return imgrequestIcon; }
            set
            {
                imgrequestIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRequestIcon");
            }
        }
        //lblOffloadRequestForm purpose of using Label varaiable
        private string lbloffloadRequestForm = "";
        public string lblOffloadRequestForm
        {
            get { return lbloffloadRequestForm; }
            set
            {
                lbloffloadRequestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOffloadRequestForm");
            }
        }
        //lblContainerNo purpose of using Label varaiable
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
        //lblBOL purpose of using Label varaiable
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
        //lblInformation1 purpose of using Label varaiable
        private string lblinformation1 = "";
        public string lblInformation1
        {
            get { return lblinformation1; }
            set
            {
                lblinformation1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInformation1");
            }
        }
        //lblInformation2 purpose of using Label varaiable
        private string lblinformation2 = "";
        public string lblInformation2
        {
            get { return lblinformation2; }
            set
            {
                lblinformation2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInformation2");
            }
        }
        //lblPleaseEnter purpose of using Label varaiable
        private string lblpleaseEnter = "";
        public string lblPleaseEnter
        {
            get { return lblpleaseEnter; }
            set
            {
                lblpleaseEnter = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPleaseEnter");
            }
        }
        //lblLocationInYard purpose of using Label varaiable
        private string lbllocationInYard = "";
        public string lblLocationInYard
        {
            get { return lbllocationInYard; }
            set
            {
                lbllocationInYard = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLocationInYard");
            }
        }
        //BtnReset purpose of using Button varaiable
        private string Btnreset = "";
        public string BtnReset
        {
            get { return Btnreset; }
            set
            {
                Btnreset = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnReset");
            }
        }
        //BtnSubmit purpose of using Button varaiable
        private string Btnsubmit = "";
        public string BtnSubmit
        {
            get { return Btnsubmit; }
            set
            {
                Btnsubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnSubmit");
            }
        }
        //imgHistoryIcon purpose of using Image varaiable
        private string imghistoryIcon = "";
        public string imgHistoryIcon
        {
            get { return imghistoryIcon; }
            set
            {
                imghistoryIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgHistoryIcon");
            }
        }
        //lblRequestHistory purpose of using Label varaiable
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
        //lblValContainerno purpose of using Validation
        private string lblvalContainerno = "";
        public string lblValContainerno
        {
            get { return lblvalContainerno; }
            set
            {
                lblvalContainerno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValContainerno");
            }
        }
        //lblValBOLno purpose of using Validation
        private string lblvalBOLno = "";
        public string lblValBOLno
        {
            get { return lblvalBOLno; }
            set
            {
                lblvalBOLno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValBOLno");
            }
        }
        //IsvalidatedLocationInYard purpose of using Validation
        private bool isvalidatedLocationInYard = false;
        public bool IsvalidatedLocationInYard
        {
            get { return isvalidatedLocationInYard; }
            set
            {
                isvalidatedLocationInYard = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedLocationInYard");
            }
        }
        //MsgLocationInYard purpose of using Label varaiable
        private string msgLocationInYard = "";
        public string MsgLocationInYard
        {
            get { return msgLocationInYard; }
            set
            {
                msgLocationInYard = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLocationInYard");
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
                Buttonreset.ChangeCanExecute();
                Buttonsubmitrequest.ChangeCanExecute();
                Tapoffloadrequesthistory.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Viewmodel- Constructor
        /// </summary>
        /// <param name="fstrContainerno"></param>
        /// <param name="fstrlblValBOLno"></param>
        public Offloadrequest2ViewModel(string fstrContainerno, string fstrlblValBOLno)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("Offloadrequest2ViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonreset = new Command(async () => await buttonreset(), () => !IsBusy);
            Buttonsubmitrequest = new Command(async () => await buttonsubmitrequest(), () => !IsBusy);
            Tapoffloadrequesthistory = new Command(async () => await tapoffloadrequesthistory(), () => !IsBusy);
            lblValContainerno = fstrContainerno;
            lblValBOLno = fstrlblValBOLno;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM455");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM455");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
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
            await Task.Delay(1000);
            lobjOffloadRequest = dbLayer.getEnum("strOffloadRequestLov", objCMS); 
             imgOffLoadIcon = dbLayer.getCaption("imgOffloadiconBlue", objCMS);
            lblOffloadRequest = dbLayer.getCaption("strOffloadRequest", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequestDarkBlue", objCMS);
            lblOffloadRequestForm = dbLayer.getCaption("strOffloadRequestForm", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
            lblBOL = dbLayer.getCaption("strBillOfLading", objCMS);
            lblInformation1 = dbLayer.getCaption("strInformation1", objCMS);
            lblInformation2 = dbLayer.getCaption("strInformation2", objCMS);
            lblPleaseEnter = dbLayer.getCaption("strEnterBelowInformation", objCMS);
            lblLocationInYard = dbLayer.getCaption("strEnterLocationInYard", objCMS);
            BtnReset = dbLayer.getCaption("strReset", objCMS);
            BtnSubmit = dbLayer.getCaption("strSubmit", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryiconWwhite", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            MsgLocationInYard = dbLayer.getCaption("strMandatory", objCMSMSG);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To go to buttonreset
        /// </summary>
        /// <returns></returns>
        private async Task buttonreset()
        {
            IsBusy = true;
            StackOffloadrequest2 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            TxtLocationInYard = "";
            //await App.Current.MainPage?.Navigation.PushAsync(new Offloadrequest_1());
            StackOffloadrequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to buttonsubmitrequest
        /// </summary>
        /// <returns></returns>
        private async Task buttonsubmitrequest()
        {
            var LocationInYard = TxtLocationInYard;
            bool blResult = true;
            await Hidevalidtion();
            if (blResult == true)
            {
                if ((TxtLocationInYard == null) || (TxtLocationInYard == ""))
                {
                    IsvalidatedLocationInYard = true;
                }
                else
                {
                    blResult = true;
                    IsvalidatedLocationInYard = false;
                    await fnReteriveOffloadrequest(LocationInYard);
                }
            }
        }
        /// <summary>
        /// To go to fnReteriveOffloadrequest
        /// </summary>
        /// <param name="LocationInYard"></param>
        /// <returns></returns>
        private async Task fnReteriveOffloadrequest(string LocationInYard)
        {
            //20221115
            string lstrResult = "true";
            bool blResult = true;
            if (blResult == true)
            {
                string strTempdate = lobjOffloadRequest[0].Value.ToString();
                string[] lstCaseCode = strTempdate.Split(':');
                string lstrCT_CATEGORYCODE = lstCaseCode[0].ToString();
                string lstrCT_CASETYPECODE = lstCaseCode[1].ToString();
                string lstrCT_CASESUBTYPECODE = lstCaseCode[2].ToString();
                string lstrCT_REQUESTTYPECODE = lstCaseCode[3].ToString();
              //  string lstrCT_MESSAGE = "";
                string lstrCT_CASEGKEY = "";
                //  string lstrct_reference = "cielotransporter@gmail.com_20220826142355";
                string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
                string lstrCT_USERNAME = gblRegisteration.strLoginUser.ToString().Trim();
                string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
                string lstrCT_TITLE = "Offload Request – " + TxtLocationInYard;//20221115
                string lstrCT_MESSAGE = "";
                lstrCT_MESSAGE = "Container No:" + lblValContainerno + ";Bill of Lading No:" + lblValBOLno + ";Location in Yard: " + LocationInYard + ";~";
                lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                //if (lstrResult.ToUpper() == "TRUE")
                //{
                await App.Current.MainPage?.Navigation.PushAsync(new OffloadRequestMsg());
                //  return Redirect("ExportoffLoadRequestSubmitInfo");
                //}
            }
        }
        /// <summary>
        /// To got to tapoffloadrequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task tapoffloadrequesthistory()
        {
            IsBusy = true;
            StackOffloadrequest2 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Offload"));
            StackOffloadrequest2 = true;
            IsBusy = false;
        }
        public async Task Hidevalidtion()
        {
            IsvalidatedLocationInYard = false;
        }
    }
}