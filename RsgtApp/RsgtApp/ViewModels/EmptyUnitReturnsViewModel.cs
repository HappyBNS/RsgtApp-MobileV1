using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using static RsgtApp.Models.EmptyUnitReturnModel;

namespace RsgtApp.ViewModels
{
    public class EmptyUnitReturnsViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create Collection Object used ObservableCollection
        public ObservableCollection<EmptyUnitReturnDt> lstEmptyUnitReturn { get; }
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        BLConnect objCon = new BLConnect();
        //btnFilterClicked Button
        public Command gotosearch { get; set; }
        //btnFilterClicked Button 
        public Command FilterClicked { get; set; }
        // btnLoadMore Button
        public Command gotoLoadMore { get; set; }
        //tapOpenPdfPINo Button
        public Command ButtonClickedApply { get; set; }
        //Apply Button
        public Command gotoReset { get; set; }
        // Applyclick Button
        public Command ButtonClickedCancel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        //To Declare Count Variable
        private int totalRecordCount = 0;
        private string strtotalRecordCount = "";
        public string lstrDetanDate = "";
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
        string lstrCaptionALL = "";
        private string strTotalCaption = "";
        public int fintPageNumber = 1;
        public int fintPageSize = 100000;
        public string strNoRecord = "";
        public string strServerSlowMsg = "";
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
        //lblSno purpose of using textbox varaiable
        private string lblSno = "";
        public string LblSno
        {
            get { return lblSno; }
            set
            {
                lblSno = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSno");
            }
        }
        //lblContainerno purpose of using textbox varaiable
        private string lblContainerno = "";
        public string LblContainerno
        {
            get { return lblContainerno; }
            set
            {
                lblContainerno = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerno");
            }
        }
        //lblCarrier purpose of using textbox varaiable
        private string lblCarrier = "";
        public string LblCarrier
        {
            get { return lblCarrier; }
            set
            {
                lblCarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCarrier");
            }
        }
        //lblSize purpose of using textbox varaiable
        private string lblSize = "";
        public string LblSize
        {
            get { return lblSize; }
            set
            {
                lblSize = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSize");
            }
        }
        //lblBayan purpose of using textbox varaiable
        private string lblBayan = "";
        public string LblBayan
        {
            get { return lblBayan; }
            set
            {
                lblBayan = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBayan");
            }
        }
        //lblBOL purpose of using textbox varaiable
        private string lblBOL = "";
        public string LblBOL
        {
            get { return lblBOL; }
            set
            {
                lblBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBOL");
            }
        }
        //lblDischargedOn purpose of using textbox varaiable
        private string lblDischargedOn = "";
        public string LblDischargedOn
        {
            get { return lblDischargedOn; }
            set
            {
                lblDischargedOn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDischargedOn");
            }
        }
        //lblGatedOutOn purpose of using textbox varaiable
        private string lblGatedOutOn = "";
        public string LblGatedOutOn
        {
            get { return lblGatedOutOn; }
            set
            {
                lblGatedOutOn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGatedOutOn");
            }
        }
        //lblLastFreeDays purpose of using textbox varaiable
        private string lblLastFreeDays = "";
        public string LblLastFreeDays
        {
            get { return lblLastFreeDays; }
            set
            {
                lblLastFreeDays = value;
                OnPropertyChanged();
                RaisePropertyChange("LblLastFreeDays");
            }
        }
        //lblEmptyDepot purpose of using textbox varaiable
        private string lblEmptyDepot = "";
        public string LblEmptyDepot
        {
            get { return lblEmptyDepot; }
            set
            {
                lblEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmptyDepot");
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
        // enumSize  combo variable
        private string enumSize = "";
        public string EnumSize
        {
            get { return enumSize; }
            set
            {
                enumSize = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumSize");
            }
        }
        // enumCarrier  combo variable
        private string enumCarrier = "";
        public string EnumCarrier
        {
            get { return enumCarrier; }
            set
            {
                enumCarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("enumCarrier");
            }
        }
        // enumEmptyDepot  combo variable
        private string enumEmptyDepot = "";
        public string EnumEmptyDepot
        {
            get { return enumEmptyDepot; }
            set
            {
                enumEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("enumEmptyDepot");
            }
        }
        // txtBayanNo  purpose ofusing textbox variable
        //private string txtBayanNo = "";
        //public string TxtBayanNo
        //{
        //    get { return txtBayanNo; }
        //    set
        //    {
        //        txtBayanNo = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("TxtBayanNo");
        //    }
        //}
        // txtContainerNo  purpose ofusing textbox variable
        private string txtContainerNo = "";
        public string TxtContainerNo
        {
            get { return txtContainerNo; }
            set
            {
                txtContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainerNo");
            }
        }
        // txtBillofLadingNo  purpose ofusing textbox variable
        private string txtBillofLadingNo = "";
        public string TxtBillofLadingNo
        {
            get { return txtBillofLadingNo; }
            set
            {
                txtBillofLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBillofLadingNo");
            }
        }
        // txtDetentionDate  purpose ofusing textbox variable
        private string txtDetentionDate = "";
        public string TxtDetentionDate
        {
            get { return txtDetentionDate; }
            set
            {
                txtDetentionDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDetentionDate");
            }
        }
        // imgUnitreturnIcon  purpose ofusing image variable
        private string imgUnitreturnIcon = "";
        public string ImgUnitreturnIcon
        {
            get { return imgUnitreturnIcon; }
            set
            {
                imgUnitreturnIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgUnitreturnIcon");
            }
        }
        // lblEmptyUnit  purpose ofusing textbox variable
        private string lblEmptyUnit = "";
        public string LblEmptyUnit
        {
            get { return lblEmptyUnit; }
            set
            {
                lblEmptyUnit = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmptyUnit");
            }
        }
        // lblEmptyUnitReturn  purpose ofusing textbox variable
        private string lblEmptyUnitReturn = "";
        public string LblEmptyUnitReturn
        {
            get { return lblEmptyUnitReturn; }
            set
            {
                lblEmptyUnitReturn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmptyUnitReturn");
            }
        }
        // imgSearch  purpose ofusing image variable
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
        // imgFilter  purpose ofusing image variable
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
        // lblCaptionEmpty  purpose ofusing textbox variable
        private string lblCaptionEmpty = "";
        public string LblCaptionEmpty
        {
            get { return lblCaptionEmpty; }
            set
            {
                lblCaptionEmpty = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaptionEmpty");
            }
        }
        // btnLoadMore  purpose ofusing textbox variable
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
        // txtSearch  purpose ofusing textbox variable
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
        // imgEmptyUnitReturn  purpose ofusing image variable
        private string imgEmptyUnitReturn = "";
        public string ImgEmptyUnitReturn
        {
            get { return imgEmptyUnitReturn; }
            set
            {
                imgEmptyUnitReturn = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEmptyUnitReturn");
            }
        }
        // lblFilters  purpose ofusing textbox variable
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
        // btnApply  purpose ofusing textbox variable
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
        // imgReset  purpose ofusing image variable
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
        // filterSize  purpose ofusing textbox variable
        private string filterSize = "";
        public string FilterSize
        {
            get { return filterSize; }
            set
            {
                filterSize = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterSize");
            }
        }
        // imgDownA  purpose ofusing image variable
        private string imgDownA = "";
        public string ImgDownA
        {
            get { return imgDownA; }
            set
            {
                imgDownA = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownA");
            }
        }
        // filterCarrier  purpose ofusing textbox variable
        private string filterCarrier = "";
        public string FilterCarrier
        {
            get { return filterCarrier; }
            set
            {
                filterCarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterCarrier");
            }
        }
        // imgDownArrow  purpose ofusing image variable
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
        // filterEmptyDepot  purpose ofusing textbox variable
        private string filterEmptyDepot = "";
        public string FilterEmptyDepot
        {
            get { return filterEmptyDepot; }
            set
            {
                filterEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterEmptyDepot");
            }
        }
        // imgDownArr  purpose ofusing image variable
        private string imgDownArr = "";
        public string ImgDownArr
        {
            get { return imgDownArr; }
            set
            {
                imgDownArr = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArr");
            }
        }
        // txtContainer  purpose ofusing textbox variable
        private string txtContainer = "";
        public string TxtContainer
        {
            get { return txtContainer; }
            set
            {
                txtContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainer");
            }
        }
        // placeContainer  purpose ofusing textbox variable
        private string placeContainer = "";
        public string PlaceContainer
        {
            get { return placeContainer; }
            set
            {
                placeContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceContainer");
            }
        }
        // txtBayaNo  purpose ofusing textbox variable
        private string txtBayanNo = "";
        public string TxtBayanNo
        {
            get { return txtBayanNo; }
            set
            {
                txtBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBayanNo");
            }
        }
        // placeBayaNo  purpose ofusing textbox variable
        private string placeBayaNo = "";
        public string PlaceBayaNo
        {
            get { return placeBayaNo; }
            set
            {
                placeBayaNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBayaNo");
            }
        }
        // txtBillOfLading  purpose ofusing textbox variable
        private string txtBillOfLading = "";
        public string TxtBillOfLading
        {
            get { return txtBillOfLading; }
            set
            {
                txtBillOfLading = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBillOfLading");
            }
        }
        // placeBillOfLading  purpose ofusing textbox variable
        private string placeBillOfLading = "";
        public string PlaceBillOfLading
        {
            get { return placeBillOfLading; }
            set
            {
                placeBillOfLading = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBillOfLading");
            }
        }
        // txtLastDays  purpose ofusing textbox variable
        private string txtLastDays = "";
        public string TxtLastDays
        {
            get { return txtLastDays; }
            set
            {
                txtLastDays = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLastDays");
            }
        }
        // placeLastDays  purpose ofusing textbox variable
        private string placeLastDays = "";
        public string PlaceLastDays
        {
            get { return placeLastDays; }
            set
            {
                placeLastDays = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceLastDays");
            }
        }
        // lbldetanDate  purpose ofusing textbox variable
        private string lbldetanDate = "";
        public string LbldetanDate
        {
            get { return lbldetanDate; }
            set
            {
                lbldetanDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LbldetanDate");
            }
        }
        // strSearchbox  purpose ofusing textbox variable
        private string strSearchbox = "";
        public string StrSearchbox
        {
            get { return strSearchbox; }
            set
            {
                strSearchbox = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSearchbox");
            }
        }
        // strContainerNo  purpose ofusing textbox variable
        private string strContainerNo = "";
        public string StrContainerNo
        {
            get { return strContainerNo; }
            set
            {
                strContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("StrContainerNo");
            }
        }
        // strBayanNo  purpose ofusing textbox variable
        private string strBayanNo = "";
        public string StrBayanNo
        {
            get { return strBayanNo; }
            set
            {
                strBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("StrBayanNo");
            }
        }
        // strBillofLadingNo  purpose ofusing textbox variable
        private string strBillofLadingNo = "";
        public string StrBillofLadingNo
        {
            get { return strBillofLadingNo; }
            set
            {
                strBillofLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("StrBillofLadingNo");
            }
        }
        // strDetentionDate  purpose ofusing textbox variable
        private string strDetentionDate = "";
        public string StrDetentionDate
        {
            get { return strDetentionDate; }
            set
            {
                strDetentionDate = value;
                OnPropertyChanged();
                RaisePropertyChange("StrDetentionDate");
            }
        }
        // strSelectedSize  purpose ofusing textbox variable
        private string strSelectedSize = "";
        public string StrSelectedSize
        {
            get { return strSelectedSize; }
            set
            {
                strSelectedSize = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSelectedSize");
            }
        }
        // strSelectedcarrier  purpose ofusing textbox variable
        private string strSelectedcarrier = "";
        public string StrSelectedcarrier
        {
            get { return strSelectedcarrier; }
            set
            {
                strSelectedcarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSelectedcarrier");
            }
        }
        // strSelecteddepot  purpose ofusing textbox variable
        private string strSelecteddepot = "";
        public string StrSelecteddepot
        {
            get { return strSelecteddepot; }
            set
            {
                strSelecteddepot = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSelecteddepot");
            }
        }
        // emptyUnitEnl purpose for a indicator
        bool emptyUnitEnl = true;
        public bool EmptyUnitEnl
        {
            get { return emptyUnitEnl; }
            set
            {
                emptyUnitEnl = value;

                OnPropertyChanged();
                RaisePropertyChange("EmptyUnitEnl");
            }
        }
        //Date Picker
        private string DtDischargeDate = null;
        public string DtdischargeDate
        {
            get { return DtdischargeDate; }
            set
            {
                DtdischargeDate = value;
                OnPropertyChanged();
                RaisePropertyChange("DtDischargeDate");
            }
        }
        //Date Picker
        //private DateTime? detanDate = null;
        //public DateTime? DetanDate
        //{
        //    get { return detanDate; }
        //    set
        //    {
        //        detanDate = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("DetanDate");
        //    }
        //}

        string _DetanDate;
        public string DetanDate
        {
            set { SetProperty(ref _DetanDate, value); }
            get { return _DetanDate; }
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
        // lfintPageSize purpose for a pagesize indicator
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
        // lfintPageNumber purpose for a pagenumber indicator
        private int lfintPageNumber = 1;

        public int LfintPageNumber
        {
            get { return lfintPageNumber; }
            set
            {
                lfintPageNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageNumber");
            }
        }
        //To handle Bool in Expander
        private bool _isExpandedSize = false;
        public bool IsExpandedSize
        {
            get { return _isExpandedSize; }
            set { SetProperty(ref _isExpandedSize, value); }
        }

        //To handle Bool in Expander
        private bool _isExpandedCarrier = false;
        public bool IsExpandedCarrier
        {
            get { return _isExpandedCarrier; }
            set { SetProperty(ref _isExpandedCarrier, value); }
        }
        //To handle Bool in Expander
        private bool _isExpandedEmptyDeport = false;
        public bool IsExpandedEmptyDeport
        {
            get { return _isExpandedEmptyDeport; }
            set { SetProperty(ref _isExpandedEmptyDeport, value); }
        }
        //isBusy purpose of using indicator varaiable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotosearch.ChangeCanExecute();
                FilterClicked.ChangeCanExecute();
                ButtonClickedApply.ChangeCanExecute();
                ButtonClickedCancel.ChangeCanExecute();
                gotoReset.ChangeCanExecute();
            }
        }
        ContentPage Myview;
        //CMS caption List
        List<clsEMPTYUNITRETURNSIZEFILTER> lstSize = new List<clsEMPTYUNITRETURNSIZEFILTER>();
        public ObservableCollection<EmptyUnitReturnDlList> lstFilterSizeData { get; set; } = new ObservableCollection<EmptyUnitReturnDlList>();
        List<clsEMPTYUNITRETURNCARRIERFILTER> lstCarrier = new List<clsEMPTYUNITRETURNCARRIERFILTER>();
        public ObservableCollection<EmptyUnitReturnDlList> lstFilterCarrierData { get; set; } = new ObservableCollection<EmptyUnitReturnDlList>();
        List<clsEMPTYUNITRETURNEMPTYDEPOTFILTER> lstDepot = new List<clsEMPTYUNITRETURNEMPTYDEPOTFILTER>();
        public ObservableCollection<EmptyUnitReturnDlList> lstFilterDepotData { get; set; } = new ObservableCollection<EmptyUnitReturnDlList>();
        /// <summary>
        /// Begin- ViewModel Constructor
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strBayanNo"></param>
        /// <param name="strBillofLadingNo"></param>
        /// <param name="strSelectedSize"></param>
        /// <param name="strSelectedcarrier"></param>
        /// <param name="strSelecteddepot"></param>
        /// <param name="lstrDetanDate"></param>
        /// <param name="fstrFilterFlag"></param>
        public EmptyUnitReturnsViewModel(string strSearchbox, string strContainerNo, string strBayanNo, string strBillofLadingNo, string strSelectedSize, string strSelectedcarrier, string strSelecteddepot, string lstrDetanDate, string fstrFilterFlag, ContentPage view)
        {
            try
            {
                Myview = view;
                //Appcenter Track Event handler
                Analytics.TrackEvent("EmptyUnitReturnsViewModel");
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
                //To create Collection Object used ObservableCollection
                lstEmptyUnitReturn = new ObservableCollection<EmptyUnitReturnDt>();
                searchbox = strSearchbox;
                
                //Begin-All Command Buttons
                gotosearch = new Command(async () => await procAnywhereSSearch(), () => !IsBusy);
                FilterClicked = new Command(async () => await FilterEmptyUnit(), () => !IsBusy);
                ButtonClickedApply = new Command(async () => await ClickedApply(), () => !IsBusy);
                ButtonClickedCancel = new Command(async () => await clear(), () => !IsBusy);
                gotoReset = new Command(async () => await clear(), () => !IsBusy);
                //End-All Command Buttons
                Task.Run(() => SizeFilterData()).Wait();
                Task.Run(() => CarrierFilterData()).Wait();
                Task.Run(() => DepotFilterData()).Wait();
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;
                //Begin-Call Listview Get Funtion
                Task.Run(() => EmptyUnitReturnlist(strSearchbox, strContainerNo, strBayanNo, strBillofLadingNo, strSelectedSize, strSelectedcarrier, strSelecteddepot, lstrDetanDate)).Wait();
                //End-Call Listview Get Funtions
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// End-ViewModel Constructor 
        /// </summary>
        /// <returns></returns>
        public async Task clear()
        {
            IsBusy = true;
            EmptyUnitEnl = false;
            await Task.Delay(1000);
            await EmptyUnitReturnlist("", "", "", "", "", "", "", "");
            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;
            IsExpandedSize = false;
            IsExpandedCarrier = false;
            IsExpandedEmptyDeport = false;
            await SizeFilterData();
            await CarrierFilterData();
            await DepotFilterData();

            TxtContainer = "";
            TxtBayanNo = "";
            TxtBillOfLading = "";
            TxtLastDays = "";
            DetanDate = "";

            EmptyUnitEnl = true;
            IsBusy = false;

        }
        /// <summary>
        /// To Navigate EmptyUnit Filter Page 
        /// </summary>
        /// <returns></returns>
        public async Task FilterEmptyUnit()
        {
            try
            {
                IsBusy = true;
                EmptyUnitEnl = false;
                await Task.Delay(1000);
                IsVisibleFilterScreen = true;
                IsVisibleMainScreen = false;
                EmptyUnitEnl = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get the EmptyUnitReturnlist List
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strBayanNo"></param>
        /// <param name="strBillofLadingNo"></param>
        /// <param name="strSelectedSize"></param>
        /// <param name="strSelectedcarrier"></param>
        /// <param name="strSelecteddepot"></param>
        /// <param name="lstrDetanDate"></param>
        /// <returns></returns>
        private async Task EmptyUnitReturnlist(string strSearchbox, string strContainerNo, string strBayanNo, string strBillofLadingNo, string strSelectedSize, string strSelectedcarrier, string strSelecteddepot, string lstrDetanDate)
        {
            try
            {
                var objRawData = new List<EmptyUnitReturnDt>();
                lstEmptyUnitReturn.Clear();
                string fstrAnywhere = "";
                string fstrContainerNo = "";
                string fstrBayanNo = "";
                string fstrBillofLadingNo = "";
                string fstrSize = "";
                string fstrCarrier = "";
                string fstrDetentionDate = "";
                string fstrEmptyDepot = "";
                if (strSearchbox != null) fstrAnywhere = strSearchbox;
                if (strSelectedSize != null) fstrSize = strSelectedSize;
                if (strSelectedcarrier != null) fstrCarrier = strSelectedcarrier;
                if (strSelecteddepot != null) fstrEmptyDepot = strSelecteddepot;
                if (strBayanNo != null) fstrBayanNo = strBayanNo;
                if (strContainerNo != null) fstrContainerNo = strContainerNo;
                if (strBillofLadingNo != null) fstrBillofLadingNo = strBillofLadingNo;
                if (lstrDetanDate != null) fstrDetentionDate = lstrDetanDate;
                string fstrFilter = "fstrAnywhere:" + fstrAnywhere + ";fstrContainerNo:" + fstrContainerNo + ";fstrBayanNo:" + fstrBayanNo + ";fstrBillofLadingNo:" + fstrBillofLadingNo + ";fstrSize:" + fstrSize + ";fstrCarrier:" + fstrCarrier + ";fstrDetentionDate:" + fstrDetentionDate + ";fstrEmptyDepot:" + fstrEmptyDepot + "; ";
                fstrFilter = EncodeServerName(fstrFilter);
                objRawData = objCon.getEmptyReturnDetails(fstrFilter, lfintPageNumber, lfintPageSize);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);

                }
                totalRecordCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                await Task.Delay(1000);
                lstEmptyUnitReturn.Clear();
                foreach (var item in objRawData)
                {
                    item.lblSno = LblSno;
                    item.lblContainerno = LblContainerno;
                    item.lblCarrier = LblCarrier;
                    item.lblSize = LblSize;
                    item.lblBayan = LblBayan;
                    item.lblBOL = LblBOL;
                    item.lblDischargedOn = LblDischargedOn;
                    item.lblGatedOutOn = LblGatedOutOn;
                    item.lblLastFreeDays = LblLastFreeDays;
                    item.lblEmptyDepot = LblEmptyDepot;
                    lstEmptyUnitReturn.Add(item);
                }
                CollectionView cvEmptyReturn = Myview.FindByName<CollectionView>("GridEmptyReturn");
                cvEmptyReturn.ItemsSource = null;
                cvEmptyReturn.ItemsSource = lstEmptyUnitReturn;
                cvEmptyReturn.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;

                if (lstEmptyUnitReturn == null || lstEmptyUnitReturn.Count == 0)
                {
                   App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Encode Server Name
        /// </summary>
        /// <param name="fstrFilter"></param>
        /// <returns></returns>
        public string EncodeServerName(string fstrFilter)
        {
            string lstrdata = Convert.ToBase64String(Encoding.UTF8.GetBytes(fstrFilter));
            return lstrdata;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM414");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM414");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM414");
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
            try
            {
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
                dbLayer.objInfoitems = objCMS;
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                ImgUnitreturnIcon = dbLayer.getCaption("imgunitreturn", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                ImgSearch = dbLayer.getCaption("imgSearch", objCMS);
                ImgFilter = dbLayer.getCaption("imgFilter", objCMS);
                strTotalCaption = cms.getCaption("strEmptyUnitReturns", objCMS);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblContainerno = dbLayer.getCaption("strContainerNo", objCMS);
                lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
                lblSize = dbLayer.getCaption("strSize", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS);
                lblBOL = dbLayer.getCaption("strBillofLading", objCMS);
                lblDischargedOn = dbLayer.getCaption("strDischargedOn", objCMS);
                lblGatedOutOn = dbLayer.getCaption("strGatedOutOn", objCMS);
                lblLastFreeDays = dbLayer.getCaption("strLastFreeDays", objCMS);
                lblEmptyDepot = dbLayer.getCaption("strEmptyDepot", objCMS);
                lblEmptyUnitReturn = dbLayer.getCaption("strEmptyUnitReturns", objCMS);
                BtnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                TxtSearch = dbLayer.getCaption("StrEmptyUnitPlaceHolder", objCMS);
                LblFilters = dbLayer.getCaption("strFilters", objCMS);
                BtnApply = dbLayer.getCaption("strApply", objCMS);
                ImgEmptyUnitReturn = dbLayer.getCaption("imgFilters", objCMS);
                ImgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterSize = dbLayer.getCaption("strSize", objCMS);
                imgDownA = dbLayer.getCaption("imgDown", objCMS);
                FilterCarrier = dbLayer.getCaption("strCarrier", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDown", objCMS);
                FilterEmptyDepot = dbLayer.getCaption("strEmptyDepot", objCMS);
                imgDownArr = dbLayer.getCaption("imgDown", objCMS);
                PlaceContainer = dbLayer.getCaption("strContainerNo", objCMS);
                PlaceBayaNo = dbLayer.getCaption("strBayanNo", objCMS);
                PlaceBillOfLading = dbLayer.getCaption("strBillofLading", objCMS);
                PlaceLastDays = dbLayer.getCaption("strLastFreeDays", objCMS);
                ImgEmptyUnitReturn = dbLayer.getCaption("imgFilter", objCMS);
                LbldetanDate = dbLayer.getCaption("strDischargedOn", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                lblGatedOutOn = dbLayer.getCaption("strGatedOutOn", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To Navigate SizeFilterData Page 
        /// </summary>
        private async Task SizeFilterData()
        {
            try
            {
                lstSize = objBl.getEmptyUnitReturnSizeFilterList(gblRegisteration.strLoginUserLinkcode, "");
                await Task.Delay(1000);
                var groupedResult = from s in lstSize
                                    group s by s.text;
                lstFilterSizeData.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterSizeData.Add(new EmptyUnitReturnDlList { CmbSize = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterSizeData.Add(new EmptyUnitReturnDlList { CmbSize = item.Key });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Navigate CarrierFilterData Page 
        /// </summary>
        private async Task CarrierFilterData()
        {
            try
            {
                lstCarrier = objBl.getEmptyUnitReturnCarrierFilter(gblRegisteration.strLoginUserLinkcode, "");
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                var groupedResult = from s in lstCarrier
                                    group s by s.text;
                lstFilterCarrierData.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterCarrierData.Add(new EmptyUnitReturnDlList { CmbCarrier = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterCarrierData.Add(new EmptyUnitReturnDlList { CmbCarrier = item.Key });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }
        /// <summary>
        /// To Navigate DepotFilterData Page
        /// </summary>
        private async Task DepotFilterData()
        {
            try
            {
                lstDepot = objBl.getEmptyUnitReturnEmptyDepotFilter(gblRegisteration.strLoginUserLinkcode, "");
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                var groupedResult = from s in lstDepot
                                    group s by s.text;
                lstFilterDepotData.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterDepotData.Add(new EmptyUnitReturnDlList { CmbEmptyDepot = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterDepotData.Add(new EmptyUnitReturnDlList { CmbEmptyDepot = item.Key });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get ClickedApply Button
        /// </summary>
        /// <returns></returns>
        private async Task ClickedApply()
        {
            try
            {
                IsBusy = true;
                EmptyUnitEnl = false;
                await Task.Delay(1000);
                var strSelectedSize = "";
                var strSelectedcarrier = "";
                var strSelecteddepot = "";
                var strContainerNo = "";
                var strBayanNo = "";
                var strBillofLadingNo = "";
                var strDetentionDate = "";
                var lstrDischaregDate = "";
                if (lstFilterSizeData.Count > 0)
                {
                    foreach (var item in lstFilterSizeData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbSize.ToString().ToUpper().Trim() != "ALL")
                            {
                                strSelectedSize += item.CmbSize + ",";
                            }

                        }
                    }
                }
                if (lstFilterCarrierData.Count > 0)
                {
                    foreach (var item in lstFilterCarrierData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbCarrier.ToString().ToUpper().Trim() != "ALL")
                            {
                                strSelectedcarrier += item.CmbCarrier + ",";
                            }

                        }
                    }
                }
                if (lstFilterDepotData.Count > 0)
                {
                    foreach (var item in lstFilterDepotData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbEmptyDepot.ToString().ToUpper().Trim() != "ALL")
                            {
                                strSelecteddepot += item.CmbEmptyDepot + ",";
                            }
                        }
                    }
                }
                if (TxtContainerNo != null)
                {
                    strContainerNo = TxtContainerNo;
                }
                if (TxtBayanNo != null)
                {
                    strBayanNo = TxtBayanNo;
                }
                if (TxtBillOfLading != null)
                {
                    strBillofLadingNo = TxtBillOfLading;
                }
                if (TxtLastDays != null)
                {
                    strDetentionDate = TxtLastDays;
                }
                if (DtDischargeDate != null)
                {
                    lstrDischaregDate = DtDischargeDate;
                }
                if (DetanDate != null)
                {
                    lstrDetanDate = DetanDate;
                }
                if (strSelectedSize.Length > 0) strSelectedSize = strSelectedSize.Substring(0, strSelectedSize.Length - 1);
                if (strSelectedcarrier.Length > 0) strSelectedcarrier = strSelectedcarrier.Substring(0, strSelectedcarrier.Length - 1);
                if (strSelecteddepot.Length > 0) strSelecteddepot = strSelecteddepot.Substring(0, strSelecteddepot.Length - 1);
                //App.Current.MainPage?.Navigation.PushAsync(new EmptyUnitReturn("", strContainerNo, strBayanNo, strBillofLadingNo, strSelectedSize, strSelectedcarrier, strSelecteddepot, lstrDetanDate));
                await EmptyUnitReturnlist("", strContainerNo, strBayanNo, strBillofLadingNo, strSelectedSize, strSelectedcarrier, strSelecteddepot, lstrDetanDate);
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;
                EmptyUnitEnl = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To data search to anywhere search
        /// </summary>
        /// <returns></returns>
        private async Task procAnywhereSSearch()
        {
            try
            {
                IsBusy = true;
                EmptyUnitEnl = false;
                await Task.Delay(1000);
                //Begin-Call Listview Get Funtion
                await EmptyUnitReturnlist(searchbox, strContainerNo, strBayanNo, strBillofLadingNo, strSelectedSize, strSelectedcarrier, strSelecteddepot, lstrDetanDate);
                //End-Call Listview Get Funtions
                // Application.Current.MainPage?.Navigation.PushAsync(new DwellDays(searchbox, strselectedSize, strselectedCarrier, strContainerNo, strBayanNo, strBillofLadingNo, strDwellDays, lstrDischargedate, lstrGateOutdate));
                EmptyUnitEnl = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}