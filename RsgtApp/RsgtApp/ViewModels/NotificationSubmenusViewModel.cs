using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class NotificationSubmenusViewModel : INotifyPropertyChanged
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
       
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
       
        private BLConnect objBl = new BLConnect();
        public Command ShipmentsMobile { get; set; }
        public Command GeneralMobile { get; set; }
        public Command ShipmentEmail { get; set; }
        public Command GeneralEmail { get; set; }
        public int fintPageNumber = 1;
        public int fintPageSize = 10000;
        public int intTotalCount { get; set; }
        public int gblRowCount { get; set; }
        public string strFilterData { get; set; }
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
                ShipmentsMobile.ChangeCanExecute();
                GeneralMobile.ChangeCanExecute();
                ShipmentEmail.ChangeCanExecute();
                GeneralEmail.ChangeCanExecute();
            }
        }
        bool ensubmenuM = true;
        public bool EnsubmenuM
        {
            get { return ensubmenuM; }
            set
            {
                ensubmenuM = value;
                OnPropertyChanged();
                RaisePropertyChange("EnsubmenuM");
            }
        }
        bool mobileSubEn = true;
        public bool MobileSubEn
        {
            get { return mobileSubEn; }
            set
            {
                mobileSubEn = value;
                OnPropertyChanged();
                RaisePropertyChange("MobileSubEn");
            }
        }
        private string lstrFlag = "";
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="fstrFlag"></param>
        public NotificationSubmenusViewModel(string fstrFlag)
        {
            lstrFlag = fstrFlag;
            Analytics.TrackEvent("NotificationSubmenusViewModel");
            Task.Run(() => assignCms()).Wait();
            ShipmentsMobile = new Command(async () => await Shipments_Mob(), () => !IsBusy);
            GeneralMobile = new Command(async () => await General_Mob(), () => !IsBusy);
            ShipmentEmail = new Command(async () => await Shipments_Email(), () => !IsBusy);
            GeneralEmail = new Command(async () => await General_Email(), () => !IsBusy);
            if (lstrFlag == "E")
            {
                string fstrEmailid = gblRegisteration.strLoginUser;
                Task.Run(() => NotificationEmailData(fstrEmailid)).Wait();
            }
            if (lstrFlag == "M")
            {
                string fstrMobileNo = gblRegisteration.strLoginMobileNO;
                Task.Run(() => NotificationMobileData(fstrMobileNo)).Wait();
            }
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
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM420");
                await assignContent();
            }
            catch (Exception ex)
            {
                //await this.DisplayToastAsync(ex.Message);
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        /// <returns></returns>
        public async Task assignContent()
        {
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            dbLayer.objInfoitems = objCMS;
            //Email sub menu
            await Task.Delay(1000);
            ImgEmailNotificationIcon = dbLayer.getCaption("imgEmailNotification", objCMS);
            LblEmailNotifications = dbLayer.getCaption("strEmailNotifications", objCMS);
            LblShipments = dbLayer.getCaption("strShipments", objCMS);
            ImgBellIcon = dbLayer.getCaption("imgBellIcon", objCMS);
            LblGeneral = dbLayer.getCaption("strGeneral", objCMS);
            ImgBellGrey = dbLayer.getCaption("imgBellGreyIcon", objCMS);
            //Mobile submenu
            ImgMobileNotifi = dbLayer.getCaption("imgMobileNotificationIconDarkBlue", objCMS);
            LblMobileNot = dbLayer.getCaption("strMobile Notifications", objCMS);
            LblShipments = dbLayer.getCaption("strShipments", objCMS);
            ImgBellIcon = dbLayer.getCaption("imgBellIcon", objCMS);
            LblGeneral = dbLayer.getCaption("strGeneral", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            ImgBellGreyIcon = dbLayer.getCaption("imgBellGreyIcon", objCMS);
           
        }
        /// <summary>
        /// To get Notification Email Data
        /// </summary>
        /// <param name="fstrEmailid"></param>
        /// <returns></returns>
        private async Task NotificationEmailData(string fstrEmailid)
        {
            try
            {
                IsBusy = true;
                MobileSubEn = false;
                await Task.Delay(1000);
                List<clsNOTIFICATIONEMAILCOUNT> objRawData = new List<clsNOTIFICATIONEMAILCOUNT>();
                objRawData = objBl.getNotificationEmailCategoryCount(fstrEmailid);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (objRawData.Count > 0)
                {
                    LblGeneral += "(" + objRawData[0].mailcount + ")";
                    LblShipments += "(" + objRawData[1].mailcount + ")";
                }
                ImgBellIcon = dbLayer.getCaption("imgBellGreyIcon", objCMS);//Shippment
                ImgBellGrey = dbLayer.getCaption("imgBellGreyIcon", objCMS);//General
                if (objRawData[0].belliconcat == "Y")//General
                {
                    ImgBellGrey = dbLayer.getCaption("imgBellIcon", objCMS);
                }
                if (objRawData[1].belliconcat == "Y")//Shippment
                {
                    ImgBellIcon = dbLayer.getCaption("imgBellIcon", objCMS);
                }
                IsBusy = false;
                MobileSubEn = true;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage?.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        /// <summary>
        /// To get Shipments Email
        /// </summary>
        /// <returns></returns>
        private async Task Shipments_Email()
        {
            EnsubmenuM = false;
            IsBusy = true;
            //await Task.Delay(3000);
            await App.Current.MainPage?.Navigation.PushAsync(new Email_Notification_List("SP"));
            EnsubmenuM = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get General Email
        /// </summary>
        /// <returns></returns>
        private async Task General_Email()
        {
            EnsubmenuM = false;
            IsBusy = true;
           // await Task.Delay(3000);
            await App.Current.MainPage?.Navigation.PushAsync(new Email_Notification_List("GE"));
            EnsubmenuM = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get Notification Mobile Data
        /// </summary>
        /// <param name="fstrMobileNo"></param>
        /// <returns></returns>
        private async Task NotificationMobileData(string fstrMobileNo)
        {
            try
            {
                IsBusy = true;
                MobileSubEn = false;
                await Task.Delay(1000);
                List<clsNOTIFICATIONMOBILECOUNT> objRawData = new List<clsNOTIFICATIONMOBILECOUNT>();
                string lstrshipmentCount = "0";
                string lstrGeneralCount = "0";
                objRawData = objBl.getNotificationMobileCategoryCount(fstrMobileNo);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (objRawData.Count > 0)
                {
                    if (objRawData.Count > 0)
                    {
                        lstrGeneralCount = objRawData[0].msgcount;
                    }

                    if (objRawData.Count > 1)
                    {
                        lstrshipmentCount = objRawData[1].msgcount;
                    }
                }
                LblGeneral += "(" + lstrGeneralCount + ")";
                LblShipments += "(" + lstrshipmentCount + ")";
                ImgBellIcon = dbLayer.getCaption("imgBellGreyIcon", objCMS);
                ImgBellGreyIcon = dbLayer.getCaption("imgBellGreyIcon", objCMS);
                if (objRawData[0].belliconcatsms == "Y")//General
                {
                    ImgBellGreyIcon = dbLayer.getCaption("imgBellIcon", objCMS);
                }
                if (objRawData[1].belliconcatsms == "Y")//Shipment
                {
                    ImgBellIcon = dbLayer.getCaption("imgBellIcon", objCMS);

                }
                IsBusy = false;
                MobileSubEn = true;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage?.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        /// <summary>
        /// To get Shipments_Mob
        /// </summary>
        /// <returns></returns>
        private async Task Shipments_Mob()
        {
            MobileSubEn = false;
            IsBusy = true;
            //await Task.Delay(3000);
            await App.Current.MainPage?.Navigation.PushAsync(new Mobile_Notification_List("SP"));
            MobileSubEn = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get General_Mob
        /// </summary>
        /// <returns></returns>
        private async Task General_Mob()
        {
            MobileSubEn = false;
            IsBusy = true;
            //await Task.Delay(3000);
            await App.Current.MainPage?.Navigation.PushAsync(new Mobile_Notification_List("GE"));
            MobileSubEn = true;
            IsBusy = false;
        }
    }
}