using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.BannedTruckModel;

namespace RsgtApp.ViewModels
{
    public class BannedTrucksViewModel : INotifyPropertyChanged
    {
        //To create bussinessLayer Object
        BLConnect objCon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
       
       
        string strBanDate = "";
        public Command gotoAnyWhere { get; set; }
        //btn Filter Clicked Button 
        public Command gotoFilterClicked { get; set; }
        //btn Load More Button 
        public Command gotoLoadMore { get; set; }
        //go to Clicked Apply Button 
        public Command gotoClickedApply { get; set; }
        //go to Reset Button 
        public Command gotoReset { get; set; }
        //go to Clicked Cancel Button 
        public Command gotoClickedCancel { get; set; }
        //go to Submit Button 
        public Command gotoSubmit { get; set; }
        //To Declare Static Variables
        public int fintPageNumber = 1;
        public int fintPageSize = 10;
        public int intTotalCount { get; set; }
        public string gblfilter { get; set; }
        private string strNoRecord = "";
        public string TxtBanReason = "";
        public string TxtBanDate = "";
        string strServerSlowMsg = "";
        string lblBannedTruck = "";
        string lblSno = "";
        string lblStatus = "";
        string lblTruckNo = "";
        string lblBanDate = "";
        string lblBanReason = "";
        string lblBanType = "";
        string lblbtnRequestBanRelease = "";
        //To Declare Count Variable
        private string strTotalCaption = "";
        string lstrBannedDate = "";
        //To create Collection Object used ObservableCollection
        public ObservableCollection<BannedTruckDt> lstBannedTruck { get; }
        //Property Changed Event Handler
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
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
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
            }
        }
        //lblBannedTrucks purpose of using Label varaiable
        private string lblBannedTrucks = "";
        public string LblBannedTrucks
        {
            get { return lblBannedTrucks; }
            set
            {
                lblBannedTrucks = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBannedTrucks");
            }
        }
        //imgSearch purpose of using Image varaiable
        private string imgSearch = "";
        public string ImgSearch
        {
            get { return imgSearch; }
            set
            {
                imgSearch = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgSearch");
            }
        }
        //txtSearch purpose of using textbox varaiable
        private string txtSearch = "";
        public string TxtSearch
        {
            get { return txtSearch; }
            set
            {
                txtSearch = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtSearch");
            }
        }
        //btnLoadMore purpose of using Button varaiable
        private string btnLoadMore = "";
        public string BtnLoadMore
        {
            get { return btnLoadMore; }
            set
            {
                btnLoadMore = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnLoadMore");
            }
        }
        //imgBannedtruckIconDarkBlue purpose of using Image varaiable
        private string imgBannedtruckIconDarkBlue = "";
        public string ImgBannedtruckIconDarkBlue
        {
            get { return imgBannedtruckIconDarkBlue; }
            set
            {
                imgBannedtruckIconDarkBlue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBannedtruckIconDarkBlue");
            }
        }
        //imgFFilter purpose of using Image varaiable
        private string imgFFilter = "";
        public string ImgFFilter
        {
            get { return imgFFilter; }
            set
            {
                imgFFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgFFilter");
            }
        }
        //imgFilter purpose of using Image varaiable
        private string imgFilter = "";
        public string ImgFilter
        {
            get { return imgFilter; }
            set
            {
                imgFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgFilter");
            }
        }
        //lblFilters purpose of using Label varaiable
        private string lblFilters = "";
        public string LblFilters
        {
            get { return lblFilters; }
            set
            {
                lblFilters = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFilters");
            }
        }
        //btnApply purpose of using Button varaiable
        private string btnApply = "";
        public string BtnApply
        {
            get { return btnApply; }
            set
            {
                btnApply = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnApply");
            }
        }
        //imgReset purpose of using Image varaiable
        private string imgReset = "";
        public string ImgReset
        {
            get { return imgReset; }
            set
            {
                imgReset = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgReset");
            }
        }
        // enumStatus  combo variable
        private string enumStatus = "";
        public string EnumStatus
        {
            get { return enumStatus; }
            set
            {
                enumStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumStatus");
            }
        }
        //imgDownArrow purpose of using Image varaiable
        private string imgDownArrow = "";
        public string ImgDownArrow
        {
            get { return imgDownArrow; }
            set
            {
                imgDownArrow = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow");
            }
        }
        // enumBanType  combo variable
        private string enumBanType = "";
        public string EnumBanType
        {
            get { return enumBanType; }
            set
            {
                enumBanType = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumBanType");
            }
        }
        //imgDownArs purpose of using Image varaiable
        private string imgDownArs = "";
        public string ImgDownArs
        {
            get { return imgDownArs; }
            set
            {
                imgDownArs = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArs");
            }
        }
        //txtBillofLadingNo purpose of using textbox varaiable
        private string textBanReason = "";
        public string TextBanReason
        {
            get { return lblBanReason; }
            set
            {
                textBanReason = value;
                OnPropertyChanged();
                RaisePropertyChange("textBanReason");
            }
        }
        //imgDownAr purpose of using Image varaiable
        private string imgDownAr = "";
        public string ImgDownAr
        {
            get { return imgDownAr; }
            set
            {
                imgDownAr = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownAr");
            }
        }
        //txtTruckNo purpose of using textbox varaiable
        private string txtTruckNo = "";
        public string TxtTruckNo
        {
            get { return txtTruckNo; }
            set
            {
                txtTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTruckNo");
            }
        }
        //lstrCaptionALL purpose of using textbox varaiable
        private string lstrCaptionALL = "";
        public string LstrCaptionALL
        {
            get { return lstrCaptionALL; }
            set
            {
                lstrCaptionALL = value;
                OnPropertyChanged();
                RaisePropertyChange("LstrCaptionALL");
            }
        }
        //lblBannedTruckRelease purpose of using Label varaiable
        private string lblBannedTruckRelease = "";
        public string LblBannedTruckRelease
        {
            get { return lblBannedTruckRelease; }
            set
            {
                lblBannedTruckRelease = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBannedTruckRelease");
            }
        }
        //textTruckNo purpose of using textbox varaiable
        private string textTruckNo = "";
        public string TextTruckNo
        {
            get { return textTruckNo; }
            set
            {
                textTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("textTruckNo");
            }
        }
        //lblTruckNumber purpose of using Label varaiable
        private string lblTruckNumber = "";
        public string LblTruckNumber
        {
            get { return lblTruckNumber; }
            set
            {
                lblTruckNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTruckNumber");
            }
        }
        //textBanDate purpose of using textbox varaiable
        private string textBanDate = "";
        public string TextBanDate
        {
            get { return textBanDate; }
            set
            {
                textBanDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TextBanDate");
            }
        }
        //lblBannedDate purpose of using Label varaiable
        private string lblBannedDate = "";
        public string LblBannedDate
        {
            get { return lblBannedDate; }
            set
            {
                lblBannedDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBannedDate");
            }
        }
        //lblTypeofBan purpose of using Label varaiable
        private string lblTypeofBan = "";
        public string LblTypeofBan
        {
            get { return lblTypeofBan; }
            set
            {
                lblTypeofBan = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTypeofBan");
            }
        }
        //lblTypeofBanned purpose of using Label varaiable
        private string lblTypeofBanned = "";
        public string LblTypeofBanned
        {
            get { return lblTypeofBanned; }
            set
            {
                lblTypeofBanned = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTypeofBanned");
            }
        }
        //lblReason purpose of using Label varaiable
        private string lblReason = "";
        public string LblReason
        {
            get { return lblReason; }
            set
            {
                lblReason = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReason");
            }
        }
        //lblReasons purpose of using Label varaiable
        private string lblReasons = "";
        public string LblReasons
        {
            get { return lblReasons; }
            set
            {
                lblReasons = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReasons");
            }
        }
        //btnSubmit purpose of using Label varaiable
        private string btnSubmit = "";
        public string BtnSubmit
        {
            get { return btnSubmit; }
            set
            {
                btnSubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnSubmit");
            }
        }
        //lblRequestNote purpose of using Label varaiable
        private string lblRequestNote = "";
        public string LblRequestNote
        {
            get { return lblRequestNote; }
            set
            {
                lblRequestNote = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRequestNote");
            }
        }
        //txtRequestNotes purpose of using textbox varaiable
        private string txtRequestNotes = "";
        public string TxtRequestNotes
        {
            get { return txtRequestNotes; }
            set
            {
                txtRequestNotes = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtRequestNotes");
            }
        }
        //imgConfirmtick purpose of using Image varaiable
        private string imgConfirmtick = "";
        public string ImgConfirmtick
        {
            get { return imgConfirmtick; }
            set
            {
                imgConfirmtick = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgConfirmtick");
            }
        }
        //lblCustomername purpose of using Label varaiable
        private string lblCustomername = "";
        public string LblCustomername
        {
            get { return lblCustomername; }
            set
            {
                lblCustomername = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCustomername");
            }
        }
        //lbldisplayMessages purpose of using Label varaiable
        private string lbldisplayMessages = "";
        public string LbldisplayMessages
        {
            get { return lbldisplayMessages; }
            set
            {
                lbldisplayMessages = value;
                OnPropertyChanged();
                RaisePropertyChange("LbldisplayMessages");
            }
        }
        //btnOk purpose of using button varaiable
        private string btnOk = "";
        public string BtnOk
        {
            get { return BtnOk; }
            set
            {
                btnOk = value;
                OnPropertyChanged();
                RaisePropertyChange("btnOk");
            }
        }
        //searchbox purpose of using textbox varaiable
        private string searchbox = "";
        public string Searchbox
        {
            get { return searchbox; }
            set
            {
                searchbox = value;
                OnPropertyChanged();
                RaisePropertyChange("Searchbox");
            }
        }
        //filterStatus purpose of using Filter varaiable
        private string filterStatus = "";
        public string FilterStatus
        {
            get { return filterStatus; }
            set
            {
                filterStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterStatus");
            }
        }
        //filterBanType purpose of using Filter varaiable
        private string filterBanType = "";
        public string FilterBanType
        {
            get { return filterBanType; }
            set
            {
                filterBanType = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterBanType");
            }
        }
        //filterBanReason purpose of using Filter varaiable
        private string filterBanReason = "";
        public string FilterBanReason
        {
            get { return filterBanReason; }
            set
            {
                filterBanReason = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterBanReason");
            }
        }
        //dateDischarge purpose of using textbox varaiable
        //private DateTime? bannedDate = null;
        //public DateTime? BannedDate
        //{
        //    get { return bannedDate; }
        //    set
        //    {
        //        bannedDate = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("BannedDate");
        //    }
        //}
        //placeTruckNo purpose of using textbox varaiable
        private string placeTruckNo = "";
        public string PlaceTruckNo
        {
            get { return placeTruckNo; }
            set
            {
                placeTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceTruckNo");
            }
        }
        //lblBanDateNo purpose of using Label varaiable
        private string lblBanDateNo = "";
        public string LblBanDateNo
        {
            get { return lblBanDateNo; }
            set
            {
                lblBanDateNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBanDateNo");
            }
        }
        //lblBanDateNo purpose of using Label varaiable
        private string strTuckNo = "";
        public string StrTuckNo
        {
            get { return strTuckNo; }
            set
            {
                strTuckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("StrTuckNo");
            }
        }
        //To Declare Count Variable
      
        private string strtotalRecordCount = "";
        public string TotalRecordCount
        {
            get { return strtotalRecordCount; }
            set
            {
                strtotalRecordCount = value;
                OnPropertyChanged();
                RaisePropertyChange("TotalRecordCount");
            }
        }
        //lblBanDateNo purpose of using Label varaiable
        private string strSelectedBanReason = "";
        public string StrSelectedBanReason
        {
            get { return strSelectedBanReason; }
            set
            {
                strSelectedBanReason = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSelectedBanReason");
            }
        }
        //lblBanDateNo purpose of using Label varaiable
        private string strSelectedBanType = "";
        public string StrSelectedBanType
        {
            get { return strSelectedBanType; }
            set
            {
                strSelectedBanType = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSelectedBanType");
            }
        }

        //lblBanDateNo purpose of using Label varaiable
        private string strSelectedStatus = "";
        public string StrSelectedStatus
        {
            get { return strSelectedStatus; }
            set
            {
                strSelectedStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSelectedStatus");
            }
        }
        DateTime? _BannedDate=null;
        public DateTime? BannedDate
        {
            set { SetProperty(ref _BannedDate, value); }
            get { return _BannedDate; }
        }
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
                gotoFilterClicked.ChangeCanExecute();
                gotoAnyWhere.ChangeCanExecute();
                gotoLoadMore.ChangeCanExecute();
                gotoClickedApply.ChangeCanExecute();
                gotoReset.ChangeCanExecute();
                gotoSubmit.ChangeCanExecute();
            }
        }
        private bool isVisibleFilterScreen = false;
        public bool IsVisibleFilterScreen
        {
            get { return isVisibleFilterScreen; }
            set
            {
                isVisibleFilterScreen = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilterScreen");
            }
        }
        private bool isVisibleMainScreen = false;
        public bool IsVisibleMainScreen
        {
            get { return isVisibleMainScreen; }
            set
            {
                isVisibleMainScreen = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleMainScreen");
            }
        }
        //To Declare Indicator
        bool bannedTruck = true;
        public bool BannedTruck
        {
            get { return bannedTruck; }
            set
            {
                bannedTruck = value;
                OnPropertyChanged();
                RaisePropertyChange("BannedTruck");
            }
        }

        //To handle Bool in Expander
        private bool _isExpandedStatus = false;
        public bool IsExpandedStatus
        {
            get { return _isExpandedStatus; }
            set { SetProperty(ref _isExpandedStatus, value); }
        }

        //To handle Bool in Expander
        private bool _isExpandedBanType = false;
        public bool IsExpandedBanType
        {
            get { return _isExpandedBanType; }
            set { SetProperty(ref _isExpandedBanType, value); }
        }
        //To handle Bool in Expander
        private bool _isExpandedBannedReason = false;
        public bool IsExpandedBannedReason
        {
            get { return _isExpandedBannedReason; }
            set { SetProperty(ref _isExpandedBannedReason, value); }
        }
        ContentPage Myview;
        //To declare List variable
        List<clsBannedtrucksBanType> lstBanType = new List<clsBannedtrucksBanType>();
        List<clsBannedtrucksBanReason> lstBanReason = new List<clsBannedtrucksBanReason>();
        //Collection Object Creation
        public ObservableCollection<BannedTrucksFilterDlList> lstFilterBanTypeData { get; set; } = new ObservableCollection<BannedTrucksFilterDlList>();
        public ObservableCollection<BannedTrucksFilterDlList> lstFilterBanReasonData { get; set; } = new ObservableCollection<BannedTrucksFilterDlList>();
        public ObservableCollection<BannedTrucksFilterDlList> lstFilterStatusData { get; set; } = new ObservableCollection<BannedTrucksFilterDlList>();
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strTuckNo"></param>
        /// <param name="strBanDate"></param>
        /// <param name="strSelectedBanReason"></param>
        /// <param name="strSelectedBanType"></param>
        /// <param name="strSelectedStatus"></param>
        public BannedTrucksViewModel(string strSearchbox, string strTuckNo, string strBanDate, string strSelectedBanReason, string strSelectedBanType, string strSelectedStatus, ContentPage view)
        {
            try
            {
                Myview = view;
                //Initiate Collection Object
                lstBannedTruck = new ObservableCollection<BannedTruckDt>();
                strTotalCaption = "";
                searchbox = strSearchbox;
                //Begin-All Command Buttons
                gotoFilterClicked = new Command(async () => await FilterClicked(), () => !IsBusy);
                gotoAnyWhere = new Command(async () => await AnyWhere(), () => !IsBusy);
                gotoLoadMore = new Command(async () => await BannedTruckslist(strSearchbox, strTuckNo, strBanDate, strSelectedBanReason, strSelectedBanType, strSelectedStatus), () => !IsBusy);
                gotoClickedApply = new Command(async () => await gotoApply(), () => !IsBusy);
                gotoReset = new Command(async () => await Clear(), () => !IsBusy);
                gotoClickedCancel = new Command(async () => await Clear(), () => !IsBusy);
                gotoSubmit = new Command(async () => await Submitfrom(), () => !IsBusy);
                //End-Call Command Button

                //Begin-Call Caption Function      
                Task.Run(() => assignCms()).Wait();
                Task.Run(() => BanTypeFilterData()).Wait();
                Task.Run(() => BanReasonFilterData()).Wait();
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;

                Task.Run(() => BannedTruckslist(strSearchbox, strTuckNo, strBanDate, strSelectedBanReason, strSelectedBanType, strSelectedStatus)).Wait();
                if (lstBannedTruck == null || lstBannedTruck.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                //End-Call Caption Function
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To click AnyWhere search button function
        /// </summary>
        /// <returns></returns>
        public async Task AnyWhere()
        {
            try
            {
                BannedTruck = false;
                IsBusy = true;
                await Task.Delay(1000);
                await BannedTruckslist(Searchbox, strTuckNo, strBanDate, strSelectedBanReason, strSelectedBanType, strSelectedStatus);
                IsBusy = false;
                BannedTruck = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To click Cancel button function
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            try
            {
                IsBusy = true;
                BannedTruck = false;
                await Task.Delay(1000);
                await BannedTruckslist("", "", "", "", "", "Banned");
                assignCms();
                await BanReasonFilterData();
                await BanTypeFilterData();
                IsExpandedBannedReason = false;
                IsExpandedBanType = false;
                IsExpandedStatus = false;
                BannedDate = null;
                TxtTruckNo = "";
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;
                IsBusy = false;
                BannedTruck = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To click Filter button function
        /// </summary>
        /// <returns></returns>
        public async Task FilterClicked()
        {
            try
            {
                IsBusy = true;
                BannedTruck = false;
                await Task.Delay(1000);
                IsVisibleFilterScreen = true;
                IsVisibleMainScreen = false;
                IsBusy = false;
                BannedTruck = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get the Listview Data
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strTruckNo"></param>
        /// <param name="strBanDate"></param>
        /// <param name="strSelectedBanReason"></param>
        /// <param name="strSelectedBanType"></param>
        /// <param name="strSelectedStatus"></param>
        /// <returns></returns>
        public async Task BannedTruckslist(string strSearchbox, string strTruckNo, string strBanDate, string strSelectedBanReason, string strSelectedBanType, string strSelectedStatus)
        {
            try
            {
                string lstrAnywhere = "";
                string lstrTruckNo = "";
                string lstrBanDate = "";
                string lstrBanReason = "";
                string lstrBanType = "";
                string lstrStatus = "";
                if (strSearchbox != null) lstrAnywhere = strSearchbox;
                if (strSelectedStatus != null) lstrStatus = strSelectedStatus;
                if (strSelectedBanType != null) lstrBanType = strSelectedBanType;
                if (strSelectedBanReason != null) lstrBanReason = strSelectedBanReason;
                if (strTruckNo != null) lstrTruckNo = strTruckNo;
                if (strBanDate != null) lstrBanDate = strBanDate;
                if (lstBannedTruck != null)
                {
                    lstBannedTruck.Clear();
                }
                var objRawData = new List<BannedTruckDt>();
                gblfilter = "";
                gblfilter += "fstrAnyWhere:" + lstrAnywhere + ";" + "fstrTruckNo:" + lstrTruckNo + ";" + "fsrtBanDate:" + lstrBanDate + ";" + "fstrBanReason:" + lstrBanReason + ";" + "fstrBanType:" + lstrBanType + ";" + "fstrStatus:" + lstrStatus + ";";
                objRawData = objBl.getBannedTrucksDetails(gblRegisteration.strLoginUser, fintPageNumber, fintPageSize, gblfilter);
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                intTotalCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + intTotalCount + ")";
                foreach (var item in objRawData)
                {
                    item.lblSno = lblSno;
                    item.lblStatus = lblStatus;
                    item.lblTruckNo = lblTruckNo;
                    item.lblBanDate = lblBanDate;
                    item.lblBanReason = lblBanReason;
                    item.lblBanType = lblBanType;
                    lstBannedTruck.Add(item);
                }
                if (lstBannedTruck == null || lstBannedTruck.Count == 0)
                {
                   App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                CollectionView cvBannedTruck = Myview.FindByName<CollectionView>("GridBannedTruck");
                cvBannedTruck.ItemsSource = null;
                cvBannedTruck.ItemsSource = lstBannedTruck;
                cvBannedTruck.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Begin assignCms function
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM413");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM413");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }

                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignCms function
        /// <summary>
        /// Begin assignContent function
        /// </summary>
        public async void assignContent()
        {
            try
            {
                
                           
                dbLayer.objInfoitems = objCMS;
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                imgBannedtruckIconDarkBlue = dbLayer.getCaption("imgBannedtruck", objCMS);
                strTotalCaption = dbLayer.getCaption("strBannedTrucks", objCMS);
                lblBannedTruck = dbLayer.getCaption("strBannedTrucks", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                TxtSearch = dbLayer.getCaption("StrBannedTruckPlaceHolder", objCMS);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                lblTruckNo = dbLayer.getCaption("strTruckNo", objCMS);
                LblBanDateNo = dbLayer.getCaption("strBanDate", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                lblBanReason = dbLayer.getCaption("strBanReason", objCMS);
                lblBanType = dbLayer.getCaption("strBanType", objCMS);
                lblbtnRequestBanRelease = dbLayer.getCaption("strRequestBanRelease", objCMS);
                //filters
                ImgFFilter = dbLayer.getCaption("imgFilters", objCMS);
                lblFilters = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterStatus = dbLayer.getCaption("strStatus", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterBanType = dbLayer.getCaption("strBanType", objCMS);
                imgDownArs = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterBanReason = dbLayer.getCaption("strBanReason", objCMS);
                imgDownAr = dbLayer.getCaption("imgDownArrow", objCMS);
                PlaceTruckNo = dbLayer.getCaption("strTruckNo", objCMS);
                lblBanDate = dbLayer.getCaption("strBanDate", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                imgConfirmtick = dbLayer.getCaption("imgConfirmTick", objCMS);
                LblCustomername = dbLayer.getCaption("strDearCustomer", objCMSMsg);
                lbldisplayMessages = dbLayer.getCaption("strNTBannedTruckNotificationMsg", objCMS);
                btnOk = dbLayer.getCaption("strOk", objCMSMsg);
                lblBannedTruckRelease = dbLayer.getCaption("strBannedTruckReleaseFrom", objCMS);
                lblTruckNo = dbLayer.getCaption("strRequestTruckNo", objCMS);
                lblTruckNumber = gblBannedTruck.strgblTruckNumber;
                lblBanDate = dbLayer.getCaption("strRequestBanDate", objCMS);
                lblBannedDate = gblBannedTruck.strgblBannedDate;
                lblTypeofBan = dbLayer.getCaption("strRequestTypeofBan", objCMS);
                lblTypeofBanned = gblBannedTruck.strgblTypeOfBanned;
                lblReason = dbLayer.getCaption("strRequestReason", objCMS);
                lblReasons = gblBannedTruck.strgblReason;
                btnSubmit = dbLayer.getCaption("strRequestSubmit", objCMS);
                lblRequestNote = dbLayer.getCaption("strRequestNotes", objCMS);
                txtRequestNotes = dbLayer.getCaption("strRequestNotes", objCMS);
                //strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
              
                dbLayer.objInfoitems = objCMS;
                Dictionary<string, string> lobjpicStatus = dbLayer.getLOV("strStatusLov", objCMS);

                lstFilterStatusData.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterStatusData.Add(new BannedTrucksFilterDlList { CmbStatus = lstrCaptionALL });
                foreach (var dic in lobjpicStatus)
                {
                    if ((dic.Key == "Banned"))
                    {
                        lstFilterStatusData.Add(new BannedTrucksFilterDlList { CmbStatus = dic.Key, isChecked = true });
                    }
                    else
                    {
                        lstFilterStatusData.Add(new BannedTrucksFilterDlList { CmbStatus = dic.Key });
                    }
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignContent function
        /// <summary>
        /// To go the BanTypeFilterData function
        /// </summary>
        private async Task BanTypeFilterData()
        {
            
            lstBanType = objBl.getBannedTrucksFilterBanTypeList(gblRegisteration.strLoginUserLinkcode, "");
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            var groupedResult = from s in lstBanType
                                group s by s.text;

            lstFilterBanTypeData.Clear();
            try
            {
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterBanTypeData.Add(new BannedTrucksFilterDlList { CmbBanType = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterBanTypeData.Add(new BannedTrucksFilterDlList { CmbBanType = item.Key });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go the BanReasonFilterData function
        /// </summary>
        private async Task BanReasonFilterData()
        {
            lstBanReason = objBl.getBannedTrucksFilterBanReasonList(gblRegisteration.strLoginUserLinkcode, "");
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            var groupedResult = from s in lstBanReason
                                group s by s.text;
            lstFilterBanReasonData.Clear();
            try
            {
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterBanReasonData.Add(new BannedTrucksFilterDlList { CmbBanReason = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterBanReasonData.Add(new BannedTrucksFilterDlList { CmbBanReason = item.Key });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To click Apply button funtion
        /// </summary>
        /// <returns></returns>
        private async Task gotoApply()
        {
            BannedTruck = false;
            IsBusy = true;
            await Task.Delay(1000);
            var strTruckNo = "";
            var strBanDate = "";
            var strSelectedBanReason = "";
            var strSelectedBanType = "";
            var strSelectedStatus = "";
            try
            {
                if (TxtTruckNo != null)
                {
                    strTruckNo = TxtTruckNo;
                }
                if (lstrBannedDate != null)
                {
                    strBanDate = lstrBannedDate.Trim();
                }
                if (lstFilterBanReasonData.Count > 0)
                {
                    foreach (var item in lstFilterBanReasonData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbBanReason.ToString().Trim().ToUpper() != "ALL")
                            {
                                strSelectedBanReason += item.CmbBanReason + ",";
                            }
                        }
                    }
                }
                if (lstFilterBanTypeData.Count > 0)
                {
                    foreach (var item in lstFilterBanTypeData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbBanType.ToString().Trim().ToUpper() != "ALL")
                            {
                                strSelectedBanType += item.CmbBanType + ",";
                            }
                        }
                    }
                }
                if (lstFilterStatusData.Count > 0)
                {
                    foreach (var item in lstFilterStatusData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbStatus.ToString().Trim().ToUpper() != "ALL")
                            {
                                strSelectedStatus += item.CmbStatus + ",";
                            }
                        }
                    }
                }
                if (BannedDate != null)
                {
                    strBanDate = BannedDate.Value.ToString("yyyy-MM-dd");
                }
                if (strSelectedStatus.Length > 0) strSelectedStatus = strSelectedStatus.Substring(0, strSelectedStatus.Length - 1);
                if (strSelectedBanType.Length > 0) strSelectedBanType = strSelectedBanType.Substring(0, strSelectedBanType.Length - 1);
                if (strSelectedBanReason.Length > 0) strSelectedBanReason = strSelectedBanReason.Substring(0, strSelectedBanReason.Length - 1);
                await BannedTruckslist("", strTruckNo, strBanDate, strSelectedBanReason, strSelectedBanType, strSelectedStatus);
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            BannedTruck = true;
        }
        /// <summary>
        /// to click Ok button function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void gotoOk(object sender, EventArgs e)
        {
            try
            {
                BannedTruck = false;
                IsBusy = true;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            BannedTruck = true;
        }
        /// <summary>
        /// To click Submit button function 
        /// </summary>
        /// <returns></returns>
        private async Task Submitfrom()
        {
            try
            {
                BannedTruck = false;
                IsBusy = true;
                await Task.Delay(1000);
               // int lintResult = 0;
                string lstrResult = "";
                string fstrCondition = "";
                string strTuckNo = gblBannedTruck.strgblTruckNumber;
                string strTransporterGkey = gblBannedTruck.strgblTransporterGkey;

                // https://localhost:44348/api/DataSource/UpdateBannedTruckStatus/5134557409/5843251075

                fstrCondition = strTransporterGkey + "/" + strTuckNo;
                string strJson = "{ \"BANT_STATUS\":\"Requested\"}";
                lstrResult = objWebApi.putWebApi("UpdateBannedTruckStatus", strJson, fstrCondition);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                  App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                string lstrMsg = TxtRequestNotes;
                gblBannedTruck.strgblRequestMSG = lstrMsg;
                await gblRegisteration.getreguser();
                string lstrDate = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");

                if (lstrResult == "True")
                {
                    objWebApi.postWebApi("PostSendEmail", gblBannedTruck.BannedMailData(lstrDate, lstrMsg));

                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                }
                await App.Current.MainPage?.Navigation.PushAsync(new BannedMessage());

                IsBusy = false;
                BannedTruck = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}