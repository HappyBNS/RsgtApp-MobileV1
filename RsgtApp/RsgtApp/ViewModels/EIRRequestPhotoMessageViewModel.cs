using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.BusinessLayer.BLConnect;
using static RsgtApp.Models.GatePhotoDetailModel;

namespace RsgtApp.ViewModels
{
     public class EIRRequestPhotoMessageViewModel:INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
      
        WebApiMethod objBl = new WebApiMethod();
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect Bl = new BLConnect();
        private List<Gatephotodetaildt> lstGatephotodetail { get; set; } = new List<Gatephotodetaildt>();
        //ButtonClicked Button 
        public Command ButtonClicked { get; set; }
        public Command ButtonCancelClicked { get; set; }
        private string strServerSlowMsg = "";
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on RaisePropertyChange Event
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
        //To handle Boolen variable
        private bool stackBOLRequestData = true;
        public bool StackBOLRequestData
        {
            get { return stackBOLRequestData; }
            set
            {
                stackBOLRequestData = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBOLRequestData");
            }
        }
        //imgRegisterIcon purpose of using image varaiable
        private string imgRegisterIcon = "";
        public string ImgRegisterIcon
        {
            get { return imgRegisterIcon; }
            set
            {
                imgRegisterIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRegisterIcon");
            }
        }
        //lbldearCustomer purpose of using Label varaiable
        private string lbldearCustomer = "";
        public string lblDearCustomer
        {
            get { return lbldearCustomer; }
            set
            {
                lbldearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDearCustomer");
            }
        }
        //lblmessage purpose of using Label varaiable
        private string lblmessage = "";
        public string lblMessage
        {
            get { return lblmessage; }
            set
            {
                lblmessage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMessage");
            }
        }
        //btnOk purpose of using Label varaiable
        private string btnOk = "";
        public string BtnOk
        {
            get { return btnOk; }
            set
            {
                btnOk = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnOk");
            }
        }

        private string btnCancel = "";
        public string BtnCancel
        {
            get { return btnCancel; }
            set
            {
                btnCancel = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnCancel");
            }
        }
        private int lfintPageSize = Convert.ToInt32(RSGT_Resource.ResourceManager.GetString("ColletionViewPageSize").ToString().Trim());
        public int LfintPageSize
        {
            get { return lfintPageSize; }
            set
            {
                lfintPageSize = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageSize");
            }
        }
        // lfintPageNo variable
        private int lfintPageNo = 1;
        public int LfintPageNo
        {
            get { return lfintPageNo; }
            set
            {
                lfintPageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageNo");
            }
        }
        //To Handel Boolen Value
        //To Declare Indicator
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                ButtonClicked.ChangeCanExecute();
            }
        }
        public string gblBlNo { get; set; }
        public string gblContainerNo { get; set; }
        string fstrContainerNo = "";
        string fstrBillofladingNo = "";
        string fstrLicenseNo = "";
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="fstrContainernumber"></param>
        /// <param name="fstrBlnumber"></param>
        /// <param name="fstrTruckNo"></param>
        public EIRRequestPhotoMessageViewModel(string fstrContainernumber, string fstrBlnumber, string fstrTruckNo, string fstrRequestDt)
        {
            //To Call Caption Function 
            Task.Run(() => assignCms()).Wait();
            //Appcenter Track Event handler
            Analytics.TrackEvent("BOLRequestViewModel");

            //Begin-All Command Buttons
            ButtonClicked = new Command(async () => await buttonClicked(), () => !IsBusy);
            ButtonCancelClicked = new Command(async () => await buttonCancelClicked(fstrContainernumber, fstrBlnumber, fstrTruckNo, fstrRequestDt), () => !IsBusy);
            //End-All Command Buttons

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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM026");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
           
            
            ImgRegisterIcon = dbLayer.getCaption("imgregister", objCMS);
            lblDearCustomer = dbLayer.getCaption("strDearcustomer", objCMS);
            lblMessage = dbLayer.getCaption("strPhotoResyncMsg", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
            BtnCancel = dbLayer.getCaption("strcancel", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// Clicked Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonClicked()
        {
            IsBusy = true;
            StackBOLRequestData = false;
            await Task.Delay(1000);
            getContainerImage(fstrContainerNo, fstrBillofladingNo, fstrLicenseNo);
            StackBOLRequestData = true;
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
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }

            App.Current.MainPage?.Navigation.PushAsync(new EIRRequestMsg());
        }
        /// <summary>
        /// To get Cancel Clicked
        /// </summary>
        /// <param name="fstrContainernumber"></param>
        /// <param name="fstrBlnumber"></param>
        /// <param name="fstrTruckNo"></param>
        /// <returns></returns>
        private async Task buttonCancelClicked(string fstrContainernumber, string fstrBlnumber, string fstrTruckNo, string fstrRequestDt)
        {
            IsBusy = true;
            StackBOLRequestData = false;
            await Task.Delay(1000);
            App.Current.MainPage?.Navigation.PushAsync(new EIRPhotoDetail(fstrContainernumber, fstrBlnumber,fstrTruckNo, fstrRequestDt));
            StackBOLRequestData = true;
            IsBusy = false;
        }
    }
}
