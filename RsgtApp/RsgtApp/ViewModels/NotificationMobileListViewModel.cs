using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.NotificationMainModel;

namespace RsgtApp.ViewModels
{
    public class NotificationMobileListViewModel
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
      
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        //public List<NotificationmobileDt> lstMobileLst = new List<NotificationmobileDt>();
        BLConnect objCon = new BLConnect();
        public int fintPageNumber = 1;
        public int fintPageSize = 10000;
        public int intTotalCount { get; set; }
        public int gblRowCount { get; set; }
        public string strFilterData { get; set; }
        public Command gotoAnyWhereSearch { get; set; }
        private string strServerSlowMsg = "";
        public ObservableCollection<NotificationmobileDt> lstMobileLst { get; set; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
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
        public string imgMobileNotification = "";
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
        public string lblMobileNotifications = "";
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
        public string lblShipments = "";
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
        public string lblMmessageheading = "";
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
        public string imgAvatar = "";
        public string ImgAvatar
        {
            get { return imgAvatar; }
            set
            {
                imgAvatar = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgAvatar");
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
            }
        }
        bool mobileEn = true;
        public bool MobileEn
        {
            get { return mobileEn; }
            set
            {
                mobileEn = value;
                OnPropertyChanged();
                RaisePropertyChange("MobileEn");
            }
        }
        string strCategoryCode = "";
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="CategoryCode"></param>
        public NotificationMobileListViewModel(string CategoryCode)
        {
            strCategoryCode = CategoryCode;
            Analytics.TrackEvent("NotificationMobileListViewModel");
            Task.Run(() => assignCms()).Wait();
            lstMobileLst = new ObservableCollection<NotificationmobileDt>();
            Task.Run(() => NotificationmobileData(CategoryCode, fintPageNumber, fintPageSize)).Wait();
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
          
            dbLayer.objInfoitems = objCMS;
            ImgMobileNotification = dbLayer.getCaption("imgMobileNotificationIconDarkBlue", objCMS);
            LblMobileNotifications = dbLayer.getCaption("strMobile Notifications", objCMS);
            LblShipments = dbLayer.getCaption("strGeneral", objCMS);
            if (strCategoryCode == "SP")
            {
                LblShipments = dbLayer.getCaption("strShipments", objCMS);
            }
            LblMmessageheading = dbLayer.getCaption("strRSGT", objCMS);
            ImgAvatar = dbLayer.getCaption("imgAvatar", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            await Task.Delay(1000);

        }
        /// <summary>
        /// To get Notification mobile Data
        /// </summary>
        /// <param name="CategoryCode"></param>
        /// <param name="fintPageNumber"></param>
        /// <param name="fintPageSize"></param>
        /// <returns></returns>
        private async Task NotificationmobileData(string CategoryCode, int fintPageNumber, int fintPageSize)
        {
            IsBusy = true;
            MobileEn = false;
            await Task.Delay(1000);
            var objRawData = new List<NotificationmobileDt>();
            //http://172.19.35.68:89/api/DataSource/getNodificationSmsUser?fstrMobileNo=9790857304&CategoryCode=GE&fstrPageNumber=1&fstrPageSize=20
            objRawData = objCon.getNodificationSmsUser(CategoryCode, fintPageNumber, fintPageSize);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            foreach (var item in objRawData)
            {
                var CurrentSendDate = item.SM_MDATE;
                var Year = CurrentSendDate.Substring(0, 4);
                var Month = CurrentSendDate.Substring(4, 2);
                var Date = CurrentSendDate.Substring(6, 2);
                int lintyear = Convert.ToInt32(Year);
                int lintMonth = Convert.ToInt32(Month);
                int lintDate = Convert.ToInt32(Date);
                DateTime CurrentMonth = DateTime.Now;
                var Currentmonth = CurrentMonth.ToString("MMMM");
                var CurrentYear = CurrentMonth.ToString("yyyy");
                DateTime NotificationMonth = new DateTime(lintyear, lintMonth, lintDate);
                var SelectedNotificationMonth = NotificationMonth.ToString("MMMM");
                item.lblMmessageheading = lblMmessageheading;
                item.imgAvatar = imgAvatar;
                item.imgMbellicon = dbLayer.getCaption("imgBellGreyIcon", objCMS);
                if ((SelectedNotificationMonth == Currentmonth) && (CurrentYear == Year))
                {
                    item.imgMbellicon = dbLayer.getCaption("imgBellIcon", objCMS).ToString();
                }
                lstMobileLst.Add(item);
            }
            MobileEn = true;
            IsBusy = false;
        }

        /// <summary>
        ///  Replace \n to Environtment.NewLine
        /// </summary>
        /// <param name="sentences"></param>
        /// <returns></returns>
        public string StringUpdateNewLineFormat(string sentences)
        {
            return Regex.Replace(sentences, @"^""|""$|\\n?|<br>?", System.Environment.NewLine);
        }
    }
}
