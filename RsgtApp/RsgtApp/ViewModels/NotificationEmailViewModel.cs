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
    public class NotificationEmailViewModel : INotifyPropertyChanged
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        private List<ClsEMAILNOTIFICATIONSLIST> lstEmail = new List<ClsEMAILNOTIFICATIONSLIST>();
        BLConnect objCon = new BLConnect();
        public int fintPageNumber = 1;
        public int fintPageSize = 10000;
        public int intTotalCount { get; set; }
        public int gblRowCount { get; set; }
        public string strFilterData { get; set; }
        public Command gotoAnyWhereSearch { get; set; }
        private string strServerSlowMsg = "";
        public ObservableCollection<NotificationemailDt> lstEmailLst { get; set; }
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
        public string imgEmailIcon = "";
        public string ImgEmailIcon
        {
            get { return imgEmailIcon; }
            set
            {
                imgEmailIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEmailIcon");
            }
        }
        public string lblEmailNotifications = "";
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
        public string lblMessageheading = "";
        public string LblMessageheading
        {
            get { return lblMessageheading; }
            set
            {
                lblMessageheading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessageheading");
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
        public string imgbellicon = "";
        public string Imgbellicon
        {
            get { return imgbellicon; }
            set
            {
                imgbellicon = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgbellicon");
            }
        }
        bool emailEn = true;
        public bool EmailEn
        {
            get { return emailEn; }
            set
            {
                emailEn = value;
                OnPropertyChanged();
                RaisePropertyChange("EmailEn");
            }
        }
        string strCategoryCode = "";
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="CategoryCode"></param>
        public NotificationEmailViewModel(string CategoryCode)
        {
            strCategoryCode = CategoryCode;
            Analytics.TrackEvent("NotificationEmailViewModel");
            Task.Run(() => assignCms()).Wait();
            lstEmailLst = new ObservableCollection<NotificationemailDt>();
            Task.Run(() => NotificationemailData(CategoryCode, fintPageNumber, fintPageSize)).Wait();
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
            await Task.Delay(1000);
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            dbLayer.objInfoitems = objCMS;
            ImgEmailIcon = dbLayer.getCaption("imgEmailNotificationIcon", objCMS);
            LblEmailNotifications = dbLayer.getCaption("strEmailNotifications", objCMS);
            LblShipments = dbLayer.getCaption("strGeneral", objCMS);
            if (strCategoryCode == "SP")
            {
                LblShipments = dbLayer.getCaption("strShipments", objCMS);
            }
            LblMessageheading = dbLayer.getCaption("strRSGT", objCMS);
            ImgAvatar = dbLayer.getCaption("imgAvatar",objCMS);
            LblMessageheading = dbLayer.getCaption("strRSGT", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// To get Notification email Data
        /// </summary>
        /// <param name="CategoryCode"></param>
        /// <param name="fintPageNumber"></param>
        /// <param name="fintPageSize"></param>
        /// <returns></returns>
        private async Task NotificationemailData(string CategoryCode, int fintPageNumber, int fintPageSize)
        {
            IsBusy = true;
            EmailEn = false;
            var objRawData = new List<NotificationemailDt>();
            //http://172.19.35.68:89/api/DataSource/getNodificationEmailUser?fstrMailID=cielotransporter1@gmail.com&CategoryCode=GE&fstrPageNumber=1&fstrPageSize=100
            objRawData = objCon.getNodificationEmailUser(CategoryCode, fintPageNumber, fintPageSize);
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            foreach (var item in objRawData)
            {
                var CurrentSendDate = item.Date;
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
                item.imgAvatar = imgAvatar;
                item.lblMessageheading = lblMessageheading;
                item.imgbellicon = dbLayer.getCaption("imgBellGreyIcon", objCMS);
                if ((SelectedNotificationMonth == Currentmonth) && (CurrentYear == Year))
                {
                    item.imgbellicon = dbLayer.getCaption("imgBellIcon", objCMS).ToString();
                }
                lstEmailLst.Add(item);
            }
            EmailEn = true;
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
