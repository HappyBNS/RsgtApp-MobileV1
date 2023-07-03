using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Helpers;
namespace RsgtApp.ViewModels
{
    public class EIRRequeststep2ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        WebApiMethod  objBl = new WebApiMethod();
        public Command TapEIRrequesthistory { get; set; }
        public Command Buttonsubmitrequest { get; set; }
        public Command ButtonPRINTClick { get; set; }
        private string strServerSlowMsg = "";
        [Obsolete]
        public System.Windows.Input.ICommand MyPdftapcont => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
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
        private bool stackEIRRequeststep2 = true;
        public bool StackEIRRequeststep2
        {
            get { return stackEIRRequeststep2; }
            set
            {
                stackEIRRequeststep2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackEIRRequeststep2");
            }
        }
        //imgEIRIcon purpose of using image varaiable
        private string imgeIRIcon = "";
        public string imgEIRIcon
        {
            get { return imgeIRIcon; }
            set
            {
                imgeIRIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEIRIcon");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string lbleIRRequest = "";
        public string lblEIRRequest
        {
            get { return lbleIRRequest; }
            set
            {
                lbleIRRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRRequest");
            }
        }
        //imgContainer purpose of using image varaiable
        private string imgcontainer = "";
        public string imgContainer
        {
            get { return imgcontainer; }
            set
            {
                imgcontainer = value;
                OnPropertyChanged();
                RaisePropertyChange("imgContainer");
            }
        }
        //lblContainerNo purpose of using lable varaiable
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
        //imgBLIcon purpose of using image varaiable
        private string imgbLIcon = "";
        public string imgBLIcon
        {
            get { return imgbLIcon; }
            set
            {
                imgbLIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgBLIcon");
            }
        }
        //lblBLNo purpose of using lable varaiable
        private string lblbLNo = "";
        public string lblBLNo
        {
            get { return lblbLNo; }
            set
            {
                lblbLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBLNo");
            }
        }
        //lblDischarge purpose of using lable varaiable
        private string lbldischarge = "";
        public string lblDischarge
        {
            get { return lbldischarge; }
            set
            {
                lbldischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDischarge");
            }
        }
        //lblGateOut purpose of using lable varaiable
        private string lblgateOut = "";
        public string lblGateOut
        {
            get { return lblgateOut; }
            set
            {
                lblgateOut = value;
                OnPropertyChanged();
                RaisePropertyChange("lblGateOut");
            }
        }
        //BtnPrintEIR purpose of using Button varaiable
        private string BtnprintEIR = "";
        public string BtnPrintEIR
        {
            get { return BtnprintEIR; }
            set
            {
                BtnprintEIR = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnPrintEIR");
            }
        }
        //BtnRequestPhoto purpose of using Button varaiable
        private string BtnrequestPhoto = "";
        public string BtnRequestPhoto
        {
            get { return BtnrequestPhoto; }
            set
            {
                BtnrequestPhoto = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnRequestPhoto");
            }
        }
        //imgHistoryIcon purpose of using image varaiable
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
        //lblRequestHistory purpose of using lable varaiable
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
        //lblValContainerno purpose of using validation
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
        //lblValBOLno purpose of using validation
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
        //lblvalTruckno purpose of using validation
        private string lblvaltruckno = "";
        public string lblvalTruckno
        {
            get { return lblvaltruckno; }
            set
            {
                lblvaltruckno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblvalTruckno");
            }
        }
        //lblTruckNo purpose of using lable varaiable
        private string lbltruckNo = "";
        public string lblTruckNo
        {
            get { return lbltruckNo; }
            set
            {
                lbltruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTruckNo");
            }
        }
        //lblValDischarge purpose of using validation
        private string lblvalDischarge = "";
        public string lblValDischarge
        {
            get { return lblvalDischarge; }
            set
            {
                lblvalDischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValDischarge");
            }
        }
        //lblValGateout purpose of using validation
        private string lblvalGateout = "";
        public string lblValGateout
        {
            get { return lblvalGateout; }
            set
            {
                lblvalGateout = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValGateout");
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
                TapEIRrequesthistory.ChangeCanExecute();
                Buttonsubmitrequest.ChangeCanExecute();
                ButtonPRINTClick.ChangeCanExecute();
            }
        }
        public string gblBlNo { get; set; }
        public string gblContainerNo { get; set; }
        //string fstrContainerNo = "";
        //string fstrBillofladingNo = "";
        string fstrLicenseNo = "";
        /// <summary>
        /// View Model-Constructor
        /// </summary>
        /// <param name="fstrContainerno"></param>
        /// <param name="fstrBOLno"></param>
        /// <param name="fstrValDischarge"></param>
        /// <param name="fstrValGateout"></param>
        /// <param name="fstrTruckNo"></param>
        public EIRRequeststep2ViewModel(string fstrContainerno, string fstrBOLno, string fstrValDischarge, string fstrValGateout, string fstrTruckNo)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("EIRRequeststep2ViewModel");
            Task.Run(() => assignCms()).Wait();
            TapEIRrequesthistory = new Command(async () => await tapEIRrequesthistory(), () => !IsBusy);
            Buttonsubmitrequest = new Command(async () => await buttonsubmitrequest(), () => !IsBusy);
            ButtonPRINTClick = new Command(async () => await buttonclicked(), () => !IsBusy);
            lblValContainerno = fstrContainerno;
            lblValBOLno = fstrBOLno;
            lblValDischarge = fstrValDischarge;
            lblValGateout = fstrValGateout;
            lblvalTruckno = fstrTruckNo;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM452");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM452");

                    objCMSMsg = await dbLayer.LoadContent("RM026");
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
            await Task.Delay(1000);
          
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
               
            //}
            imgEIRIcon = dbLayer.getCaption("imgEIR", objCMS);
            lblEIRRequest = dbLayer.getCaption("strEirCopyRequestHeading", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
            lblBLNo = dbLayer.getCaption("strBLNumber", objCMS);
            lblDischarge = dbLayer.getCaption("strDischarge", objCMS);
            lblGateOut = dbLayer.getCaption("strGateOut", objCMS);
            BtnPrintEIR = dbLayer.getCaption("strPrintEir", objCMS);
            BtnRequestPhoto = dbLayer.getCaption("strRequestPhoto", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            lblTruckNo = dbLayer.getCaption("strTruckNo", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// To go to EIR Request History
        /// </summary>
        /// <returns></returns>
        private async Task tapEIRrequesthistory()
        {
            IsBusy = true;
            StackEIRRequeststep2 = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new EIRRequestHistory("","","","",""));
            StackEIRRequeststep2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Submit Request
        /// </summary>
        /// <returns></returns>
        private async Task buttonsubmitrequest()
        {
            IsBusy = true;
            StackEIRRequeststep2 = false;
            await Task.Delay(1000);
            getContainerImage(lblValContainerno, lblValBOLno, lblvalTruckno);
            StackEIRRequeststep2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get Container Image
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBillofladingNo"></param>
        /// <param name="fstrTruckNo"></param>
        public void getContainerImage(string fstrContainerNo, string fstrBillofladingNo, string fstrTruckNo)
        {
           // string llstResult = "";
            // https://webgateway.rsgt.com:9090/eportal_api/getContainerImage?fstrLicenseNo=255500&fstrBillofladingNo=225500&fstrContainerNo=LMCU9111972
            string lstrApiName = "getContainerImage";
            Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
            lobjInParams.Add("fstrLicenseNo", fstrLicenseNo);
            lobjInParams.Add("fstrBillofladingNo", fstrBillofladingNo);
            lobjInParams.Add("fstrContainerNo", fstrContainerNo);
            lobjInParams.Add("fstrTruckNo", fstrTruckNo);
            IEnumerable<Object> lobjApiData;    
            lobjApiData = objBl.getWebApiData(lstrApiName, lobjInParams);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            App.Current.MainPage?.Navigation.PushAsync(new EIRRequestMsg());    
        }
        /// <summary>
        /// To Go to Open PDF
        /// </summary>
        /// <param name="fstrUrl"></param>
        private async void openPdf(string fstrUrl)
        {
            await Task.Delay(1000);           
            await Browser.OpenAsync(fstrUrl, BrowserLaunchMode.SystemPreferred);
        }
        /// <summary>
        /// To get button cliked
        /// </summary>
        /// <returns></returns>
        private async Task buttonclicked()
        {
            IsBusy = true;
            StackEIRRequeststep2 = false;
            await Task.Delay(1000);
            await getPDF();
            StackEIRRequeststep2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get PDF Function
        /// </summary>
        /// <returns></returns>
        private async Task getPDF()
        {
            IsBusy = true;
            StackEIRRequeststep2 = false;
            await Task.Delay(1000);
            //EIR copy Request
            string strURL = AppSettings.MobWebUrl;
            gblContainerNo = lblValContainerno;
            gblBlNo = lblValBOLno;
            string fstrTruckNo = lblvalTruckno;
            var pdfUrl = strURL + "/EIRCopyRequestForm/OpenPDF?" + "fstrContainerNo=" + gblContainerNo + "&fstrBlnNo=" + gblBlNo + "&fstrTruckNo=" + fstrTruckNo + "";
            openPdf(pdfUrl);
            StackEIRRequeststep2 = true;
            IsBusy = false;
        }
       
       
    }
}