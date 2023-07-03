using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.NotificationMainModel;

namespace RsgtApp.ViewModels
{
    public class NotificationMainViewModel : INotifyPropertyChanged
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
      
       
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public ObservableCollection<NotificationmobileDt> lstMobileLst { get; set; }
        public ObservableCollection<NotificationmobileDt> lstNotificationmobile { get; set; }
       
        private BLConnect objBl = new BLConnect();
        public int fintPageNumber = 1;
        public int fintPageSize = 10000;
        public int intTotalCount { get; set; }
        public int gblRowCount { get; set; }
        public string strFilterData { get; set; }
        public Command MobileNotificationTapped { get; set; }
        public Command EmailNotificationTapped { get; set; }
        private string strServerSlowMsg = "";
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        private string imgMobileNotificationMsg = "";
        public string ImgMobileNotificationMsg
        {
            get { return imgMobileNotificationMsg; }
            set
            {
                imgMobileNotificationMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgMobileNotificationMsg");
            }
        }
        private string lblMobileNotifications = "";
        public string LblMobileNotifications
        {
            get { return lblMobileNotifications; }
            set
            {
                lblMobileNotifications = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMobileNotifications");
            }
        }
        private string lblShipmentsMsg = "";
        public string LblShipmentsMsg
        {
            get { return lblShipmentsMsg; }
            set
            {
                lblShipmentsMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShipmentsMsg");
            }
        }
        private string lblMmessageheading = "";
        public string LblMmessageheading
        {
            get { return lblMmessageheading; }
            set
            {
                lblMmessageheading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMmessageheading");
            }
        }
        private string imgMbellicon = "";
        public string ImgMbellicon
        {
            get { return imgMbellicon; }
            set
            {
                imgMbellicon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgMbellicon");
            }
        }
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
        //private string MMessagetimeMsg = "";
        //public string mMessagetimeMsg
        //{
        //    get { return mMessagetimeMsg; }
        //    set
        //    {
        //        mMessagetimeMsg = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("MMessagetimeMsg");
        //    }
        //}
        //private string MMessageinfoMsg = "";
        //public string mMessageinfoMsg
        //{
        //    get { return mMessageinfoMsg; }
        //    set
        //    {
        //        mMessageinfoMsg = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("MMessageinfoMsg");
        //    }
        //}
        private string imgEmailNotificationIcon = "";
        public string ImgEmailNotificationIcon
        {
            get { return imgEmailNotificationIcon; }
            set
            {
                imgEmailNotificationIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEmailNotificationIcon");
            }
        }
        private string lblEmailNotifications = "";
        public string LblEmailNotifications
        {
            get { return lblEmailNotifications; }
            set
            {
                lblEmailNotifications = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmailNotifications");
            }
        }
        private string lblShipmentsEmail = "";
        public string LblShipmentsEmail
        {
            get { return lblShipmentsEmail; }
            set
            {
                lblShipmentsEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShipmentsEmail");
            }
        }
        private string imgBellIconEmail = "";
        public string ImgBellIconEmail
        {
            get { return imgBellIconEmail; }
            set
            {
                imgBellIconEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBellIconEmail");
            }
        }
        private string lblGeneralEmail = "";
        public string LblGeneralEmail
        {
            get { return lblGeneralEmail; }
            set
            {
                lblGeneralEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGeneralEmail");
            }
        }
        private string imgBellGreyEmail = "";
        public string ImgBellGreyEmail
        {
            get { return imgBellGreyEmail; }
            set
            {
                imgBellGreyEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBellGreyEmail");
            }
        }

        private string imgNotificationMenuicon = "";
        public string ImgNotificationMenuicon
        {
            get { return imgNotificationMenuicon; }
            set
            {
                imgNotificationMenuicon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgNotificationMenuicon");
            }
        }
        private string lblNotifications = "";
        public string LblNotifications
        {
            get { return lblNotifications; }
            set
            {
                lblNotifications = value;
                OnPropertyChanged();
                RaisePropertyChange("LblNotifications");
            }
        }
        private string imgEmailNotification = "";
        public string ImgEmailNotification
        {
            get { return imgEmailNotification; }
            set
            {
                imgEmailNotification = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEmailNotification");
            }
        }
        private string lblEmail = "";
        public string LblEmail
        {
            get { return lblEmail; }
            set
            {
                lblEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmail");
            }
        }
        private string imgBellIconMain = "";
        public string ImgBellIconMain
        {
            get { return imgBellIconMain; }
            set
            {
                imgBellIconMain = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBellIconMain");
            }
        }
        private string imgMobileNotification = "";
        public string ImgMobileNotification
        {
            get { return imgMobileNotification; }
            set
            {
                imgMobileNotification = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgMobileNotification");
            }
        }
        private string lblMobile = "";
        public string LblMobile
        {
            get { return lblMobile; }
            set
            {
                lblMobile = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMobile");
            }
        }
        private string imgBellGrey = "";
        public string ImgBellGrey
        {
            get { return imgBellGrey; }
            set
            {
                imgBellGrey = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBellGrey");
            }
        }
        private string imgMobileNotifi = "";
        public string ImgMobileNotifi
        {
            get { return imgMobileNotifi; }
            set
            {
                imgMobileNotifi = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgMobileNotifi");
            }
        }
        private string lblMobileNot = "";
        public string LblMobileNot
        {
            get { return lblMobileNot; }
            set
            {
                lblMobileNot = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMobileNot");
            }
        }
        private string lblShipments = "";
        public string LblShipments
        {
            get { return lblShipments; }
            set
            {
                lblShipments = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShipments");
            }
        }
        private string imgBellIcon = "";
        public string ImgBellIcon
        {
            get { return imgBellIcon; }
            set
            {
                imgBellIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBellIcon");
            }
        }
        private string lblGeneral = "";
        public string LblGeneral
        {
            get { return lblGeneral; }
            set
            {
                lblGeneral = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGeneral");
            }
        }
        private string imgBellGreyIcon = "";
        public string ImgBellGreyIcon
        {
            get { return imgBellGreyIcon; }
            set
            {
                imgBellGreyIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBellGreyIcon");
            }
        }
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                MobileNotificationTapped.ChangeCanExecute();
                EmailNotificationTapped.ChangeCanExecute();
            }
        }
        bool mainEn = true;
        public bool MainEn
        {
            get { return mainEn; }
            set
            {
                mainEn = value;
                OnPropertyChanged();
                RaisePropertyChange("MainEn");
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="fstrCategoryCode"></param>
        public NotificationMainViewModel(string fstrCategoryCode)
        {
            Analytics.TrackEvent("MobileNotificationListViewModel");
            Task.Run(() => assignCms()).Wait();
            string fstrEmailid = gblRegisteration.strLoginUser;
            MobileNotificationTapped = new Command(async () => await MobileNotification_Tapped(), () => !IsBusy);
            EmailNotificationTapped = new Command(async () => await EmailNotification_Tapped(), () => !IsBusy);
            string fstrMobileNo = gblRegisteration.strLoginMobileNO;
            Task.Run(() => NotificationData(fstrEmailid)).Wait();
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM420");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM420");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                await assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        /// <returns></returns>
        public async Task assignContent()
        {
             
          
            dbLayer.objInfoitems = objCMS;
            //Notification_main
            imgNotificationMenuicon = dbLayer.getCaption("imgNotificationMenuIcon", objCMS);
            lblNotifications = dbLayer.getCaption("strNotifications", objCMS);
            imgEmailNotification = dbLayer.getCaption("imgEmailNotification", objCMS);
            lblEmail = dbLayer.getCaption("strEmail", objCMS);
            imgBellIcon = dbLayer.getCaption("imgBellIcon", objCMS);
            imgMobileNotification = dbLayer.getCaption("imgMobileNotificationIconDarkBlue", objCMS);
            lblMobile = dbLayer.getCaption("strMobile", objCMS);
            imgBellGrey = dbLayer.getCaption("imgBellGreyIcon", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            await Task.Delay(1000);
        }
        /// <summary>
        /// To get Notification Data
        /// </summary>
        /// <param name="fstrEmailid"></param>
        /// <returns></returns>
        public async Task NotificationData(string fstrEmailid)
        {
            try
            {
                IsBusy = true;
                MainEn = false;
                //output varible Declaration
                List<NotificationCountdata> objRawData = new List<NotificationCountdata>();
                //http://172.19.35.68:89/api/DataSource/getNotificationCount?fstrEmailid=cielotransporter1@gmail.com
                objRawData = objBl.getNotificationCount(fstrEmailid);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lblEmail += "(" + objRawData[0].Emailcount + ")";
                lblMobile += "(" + objRawData[0].SMScount + ")";
                ImgBellIcon = dbLayer.getCaption("imgBellGreyIcon", objCMS);
                ImgBellGrey = dbLayer.getCaption("imgBellGreyIcon", objCMS);
                if (objRawData[0].BELLICON == "Y")
                {
                    ImgBellIcon = dbLayer.getCaption("imgBellIcon", objCMS);
                    ImgBellGrey = dbLayer.getCaption("imgBellIcon", objCMS);
                }
               IsBusy = false;
                MainEn = true;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage?.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        /// <summary>
        /// To get Email Notification Tapped
        /// </summary>
        /// <returns></returns>
        private async Task EmailNotification_Tapped()
        {
            try
            {
                MainEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                await App.Current.MainPage?.Navigation.PushAsync(new Notification_email_submenu("E"));
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            MainEn = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get Mobile Notification Tapped
        /// </summary>
        /// <returns></returns>
        private async Task MobileNotification_Tapped()
        {
            MainEn = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                await App.Current.MainPage?.Navigation.PushAsync(new Notification_mobile_submenu("M"));
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            MainEn = true;
            IsBusy = false;
        }
    }
}