
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
    public class InLocationRequest2ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonreset { get; set; }
        public Command Buttonsubmitrequest { get; set; }
        public Command Tapmanifestrequesthistory { get; set; }
        private string strServerSlowMsg = "";
        public List<EnumCombo> lobjInlocation { get; set; } = new List<EnumCombo>();
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Two way binding process on Propertychange Event
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
        private bool stackinLocationrequest2 = true;
        public bool StackInLocationrequest2
        {
            get { return stackinLocationrequest2; }
            set
            {
                stackinLocationrequest2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackInLocationrequest2");
            }
        }
        private string txtTruckPlateNo = "";
        public string TxtTruckPlateNo
        {
            get { return txtTruckPlateNo; }
            set
            {
                txtTruckPlateNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTruckPlateNo");
            }
        }
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
        private string imgequipmentIcon = "";
        public string imgEquipmentIcon
        {
            get { return imgequipmentIcon; }
            set
            {
                imgequipmentIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEquipmentIcon");
            }
        }
        private string lblinlocationRequest = "";
        public string lblInlocationRequest
        {
            get { return lblinlocationRequest; }
            set
            {
                lblinlocationRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInlocationRequest");
            }
        }
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
        private string lblinlocationRequestForm = "";
        public string lblInlocationRequestForm
        {
            get { return lblinlocationRequestForm; }
            set
            {
                lblinlocationRequestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInlocationRequestForm");
            }
        }
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
        private string lblappointmentNo = "";
        public string lblAppointmentNo
        {
            get { return lblappointmentNo; }
            set
            {
                lblappointmentNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAppointmentNo");
            }
        }
        private string lblpleaseEntertheBelowInformation = "";
        public string lblPleaseEntertheBelowInformation
        {
            get { return lblpleaseEntertheBelowInformation; }
            set
            {
                lblpleaseEntertheBelowInformation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPleaseEntertheBelowInformation");
            }
        }
        private string lbltruckPlateNo = "";
        public string lblTruckPlateNo
        {
            get { return lbltruckPlateNo; }
            set
            {
                lbltruckPlateNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTruckPlateNo");
            }
        }
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
        private string lblequipmentNotAvailable = "";
        public string lblEquipmentNotAvailable
        {
            get { return lblequipmentNotAvailable; }
            set
            {
                lblequipmentNotAvailable = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEquipmentNotAvailable");
            }
        }
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
        private string lblvalAppointmentno = "";
        public string lblValAppointmentno
        {
            get { return lblvalAppointmentno; }
            set
            {
                lblvalAppointmentno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValAppointmentno");
            }
        }
        private bool isvalidatedTruckPlateNo = false;
        public bool IsvalidatedTruckPlateNo
        {
            get { return isvalidatedTruckPlateNo; }
            set
            {
                isvalidatedTruckPlateNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedTruckPlateNo");
            }
        }
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
        private string MsglocationInYard = "";
        public string MsgLocationInYard
        {
            get { return MsglocationInYard; }
            set
            {
                MsglocationInYard = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLocationInYard");
            }
        }
        private string msgTruckPlateNo = "";
        public string MsgTruckPlateNo
        {
            get { return msgTruckPlateNo; }
            set
            {
                msgTruckPlateNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTruckPlateNo");
            }
        }
        private string msgIsChecked = "";
        public string MsgIsChecked
        {
            get { return msgIsChecked; }
            set
            {
                msgIsChecked = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgIsChecked");
            }
        }
        private bool Ischecked = false;
        public bool IsChecked
        {
            get { return Ischecked; }
            set
            {
                Ischecked = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChecked");
            }
        }
        private bool checkMandatory = false;
        public bool CheckMandatory
        {
            get { return checkMandatory; }
            set
            {
                checkMandatory = value;
                OnPropertyChanged();
                RaisePropertyChange("CheckMandatory");
            }
        }
        private string Checkmandatory = "";
        public string checkmandatory
        {
            get { return Checkmandatory; }
            set
            {
                Checkmandatory = value;
                OnPropertyChanged();
                RaisePropertyChange("checkmandatory");
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
                Tapmanifestrequesthistory.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="fstrContainerno"></param>
        /// <param name="fstrAppointmentno"></param>
        public InLocationRequest2ViewModel(string fstrContainerno, string fstrAppointmentno)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("InLocationRequest2ViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonreset = new Command(async () => await buttonreset(fstrContainerno, fstrAppointmentno), () => !IsBusy);
            Buttonsubmitrequest = new Command(async () => await buttonsubmitrequest(), () => !IsBusy);
            Tapmanifestrequesthistory = new Command(async () => await tapmanifestrequesthistory(), () => !IsBusy);
            lblValContainerno = fstrContainerno;
            lblValAppointmentno = fstrAppointmentno;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM460");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM460");
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
           
           
            lobjInlocation = dbLayer.getEnum("InLocationeEuipmentLov", objCMS);
            imgEquipmentIcon = dbLayer.getCaption("imgEquipment", objCMS);
            lblInlocationRequest = dbLayer.getCaption("strInLocationEquipmentRequest1", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblInlocationRequestForm = dbLayer.getCaption("strInLocationRequestForm", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
            lblAppointmentNo = dbLayer.getCaption("strAppointmentNumber", objCMS);
            lblPleaseEntertheBelowInformation = dbLayer.getCaption("strPleaseEnterBelowInformation", objCMS);
            lblTruckPlateNo = dbLayer.getCaption("strTruckPlateNumber", objCMS);
            lblLocationInYard = dbLayer.getCaption("strLocationInYard", objCMS);
            lblEquipmentNotAvailable = dbLayer.getCaption("strEquipmentNotAvailableInLocation", objCMS);
            BtnSubmit = dbLayer.getCaption("strSubmit", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            BtnReset = dbLayer.getCaption("strReset", objCMS);
            MsgLocationInYard = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgTruckPlateNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgIsChecked = dbLayer.getCaption("strMandatory", objCMSMSG);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// Reset Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonreset(string fstrContainerno, string fstrAppointmentno)
        {
            IsBusy = true;
            StackInLocationrequest2 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            TxtTruckPlateNo = "";
            TxtLocationInYard = "";
           // await App.Current.MainPage?.Navigation.PushAsync(new InLocationEquipmentrequest2(fstrContainerno, fstrAppointmentno));
            StackInLocationrequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// Button for Submit Request
        /// </summary>
        /// <returns></returns>
        private async Task buttonsubmitrequest()
        {
            var TrackPlateNo = TxtTruckPlateNo.ToString().Trim();
            var LocationInYard = TxtLocationInYard.ToString().Trim();
            var checkmandatory = IsChecked;
            await Hidevalidtion();
            bool blResult = true;
            if (blResult == true)
            {
                if ((TxtTruckPlateNo == null) || (TxtTruckPlateNo == ""))
                {
                    IsvalidatedTruckPlateNo = true;
                }
                else
                {
                    blResult = true;
                    IsvalidatedTruckPlateNo = false;
                }
                if ((TxtLocationInYard == null) || (TxtLocationInYard == ""))
                {
                    IsvalidatedLocationInYard = true;
                }
                else
                {
                    blResult = true;
                    IsvalidatedLocationInYard = false;
                }
                if ((TrackPlateNo != "") && (LocationInYard != ""))
                {
                    await fnReteriveInlocation(TrackPlateNo, LocationInYard);
                }
            }
        }
        /// <summary>
        /// Function for Reterive Inlocation
        /// </summary>
        /// <param name="TrackPlateNo"></param>
        /// <param name="LocationInYard"></param>
        /// <returns></returns>
        private async Task fnReteriveInlocation(string TrackPlateNo, string LocationInYard)
        {
            //20221115
            string lstrResult = "true";
            bool blResult = true;
            if (blResult == true)
            {
                string strTempdate = lobjInlocation[0].Value.ToString();
                string[] lstCaseCode = strTempdate.Split(':');
                string lstrCT_CATEGORYCODE = lstCaseCode[0].ToString();
                string lstrCT_CASETYPECODE = lstCaseCode[1].ToString();
                string lstrCT_CASESUBTYPECODE = lstCaseCode[2].ToString();
                string lstrCT_REQUESTTYPECODE = lstCaseCode[3].ToString();
                //string lstrCT_MESSAGE = "";
                string lstrCT_CASEGKEY = "";
                //  string lstrct_reference = "mailto:cielotransporter@gmail.com_20220826142355";
                string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
                string lstrCT_USERNAME = gblRegisteration.strLoginUserLinkcode.ToString().Trim();
                string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
                string lstrCT_TITLE = "Equipment Not Available in Location - " + lblValContainerno;
                string lstrCT_MESSAGE = "";
                lstrCT_MESSAGE = "Container No:" + lblValContainerno + ";Bill of Lading No:" + lblValAppointmentno + ";Truck BOT No:" + TrackPlateNo + ";Location in Yard:" + LocationInYard + ";~";
                lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                //if (lstrResult.ToUpper() == "TRUE")
                //{
                await App.Current.MainPage?.Navigation.PushAsync(new InLocationRequestMsg());
                //  return Redirect("ExportoffLoadRequestSubmitInfo");
                //}
            }
        }
        /// <summary>
        /// To go to Request History
        /// </summary>
        /// <returns></returns>
        private async Task tapmanifestrequesthistory()
        {
            IsBusy = true;
            StackInLocationrequest2 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Equipment Not Available in Location"));
            StackInLocationrequest2 = true;
            IsBusy = false;
        }

        public async Task Hidevalidtion()
        {
            await Task.Delay(1000);
            IsvalidatedTruckPlateNo = false;
            IsvalidatedLocationInYard = false;
        }
    }
}
