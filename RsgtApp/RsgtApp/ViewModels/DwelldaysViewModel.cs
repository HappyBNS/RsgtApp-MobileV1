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
using Xamarin.Forms;
using static RsgtApp.Models.DwelldaysModel;

namespace RsgtApp.ViewModels
{
    public class DwelldaysViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        string strServerSlowMsg = "";
        //btnAnyWhereSearch Button 
        public Command btnAnyWhereSearch { get; set; }
        //btnFilterClicked Button 
        public Command btnFilterClicked { get; set; }
        //btnLoadMore Button 
        public Command btnLoadMore { get; set; }
        //gotoApplybutton Button 
        public Command gotoApplybutton { get; set; }
        //ButtonClickedReset Button 
        public Command ButtonClickedReset { get; set; }
        //ButtonClickedCancel Button 
        public Command ButtonClickedCancel { get; set; }
        public ObservableCollection<DwellDt> lstTempDwellDays { get; set; } = new ObservableCollection<DwellDt>();
        public ObservableCollection<DwellDt> lstDwellDays { get; set; } = new ObservableCollection<DwellDt>();
        //private ObservableCollection<DwellDt> _lstDwellDays = new ObservableCollection<DwellDt>();
        //public ObservableCollection<DwellDt> lstDwellDays
        //{
        //    get { return _lstDwellDays; }
        //    set
        //    {
        //        if (_lstDwellDays == value)
        //            return;

        //        _lstDwellDays = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("lstDwellDays");
        //    }
        //}
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
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

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //To Declare IndicatorBGColor Variable
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

        //To Declare indicatorBGOpacity Variable
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
        //To Declare Count Variable
        private int totalRecordCount = 0;

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

        // lfintPageSize variable

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
        //Declare variable 
        public string strNoRecord = "";
        private string strTotalCaption = "";
        public string lblSno = "";
        public string lblContainerNo = "";
        public string lblSize = "";
        public string lblBayan = "";
        public string lblBOL = "";
        public string lblDischargedOn = "";
        public string lblGatedOutOn = "";
        public string lblDDays = "";
        public string lblCarrier = "";
        public string lstrCaptionALL = "";
        private string lstrDischargedate = "";
        private string lstrGateOutdate = "";
        //Assign Property Two way Binding
        //Two way Binding Variable
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
        public string enumSize = "";
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
        public string enumCarrier = "";
        public string EnumCarrier
        {
            get { return enumCarrier; }
            set
            {
                enumCarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumCarrier");
            }
        }
        //txtContainerNo purpose of using textbox varaiable
        public string txtContainerNo = "";
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
        //txtBayanNo purpose of using textbox varaiable
        public string txtBayanNo = "";
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
        public string txtBillOfLadingNo = "";
        public string TxtBillOfLadingNo
        {
            get { return txtBillOfLadingNo; }
            set
            {
                txtBillOfLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBillOfLadingNo");
            }
        }

        //txtBillofLadingNo purpose of using textbox varaiable
        public string txtBillofLadingNo = "";
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
        //txtDwellDays purpose of using textbox varaiable
        public string txtDwellDays = "";
        public string TxtDwellDays
        {
            get { return txtDwellDays; }
            set
            {
                txtDwellDays = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDwellDays");
            }
        }
        //txtDiscrivalDate purpose of using textbox varaiable
        public string txtDiscrivalDate = "";
        public string TxtDiscrivalDate
        {
            get { return txtDiscrivalDate; }
            set
            {
                txtDiscrivalDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDiscrivalDate");
            }
        }
        //txtGatedOutDate purpose of using textbox varaiable
        public string txtGatedOutDate = "";
        public string TxtGatedOutDate
        {
            get { return txtGatedOutDate; }
            set
            {
                txtGatedOutDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtGatedOutDate");
            }
        }
        //MyDate purpose of using textbox varaiable
        private string myDate = "";
        public string MyDate
        {
            get { return myDate; }
            set
            {
                myDate = value;
                OnPropertyChanged();
                RaisePropertyChange("MyDate");
            }
        }
        ////dateDischarge purpose of using textbox varaiable
        //private DateTime? dateDischarge =null;
        //public DateTime? DateDischarge
        //{
        //    get { return dateDischarge; }
        //    set
        //    {
        //        dateDischarge = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("DateDischarge");
        //    }
        //}
        ////dateGatedOut purpose of using textbox varaiable
        //private DateTime? dateGatedOut = null;
        //public DateTime? DateGatedOut
        //{
        //    get { return dateGatedOut; }
        //    set
        //    {
        //        dateGatedOut = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("DateGatedOut");
        //    }
        //}
        //To handle Boolen variable
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                btnAnyWhereSearch.ChangeCanExecute();
                btnFilterClicked.ChangeCanExecute();
                //btnLoadMore.ChangeCanExecute();
                gotoApplybutton.ChangeCanExecute();
                ButtonClickedReset.ChangeCanExecute();
                ButtonClickedCancel.ChangeCanExecute();
            }
        }
        //To handle Boolen variable
        bool dwellDaysEn = true;
        public bool DwellDaysEn
        {
            get { return dwellDaysEn; }
            set
            {
                dwellDaysEn = value;
                OnPropertyChanged();
                RaisePropertyChange("DwellDaysEn");

            }
        }
        //imgDwelldaysDarkBlue purpose of using image varaiable
        private string imgDwelldaysDarkBlue = "";

        public string ImgDwelldaysDarkBlue
        {
            get { return imgDwelldaysDarkBlue; }
            set
            {
                imgDwelldaysDarkBlue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDwelldaysDarkBlue");
            }
        }
        //imgSearch purpose of using image varaiable
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
        //imgFilter purpose of using image varaiable
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
        //loadMore purpose of using textbox varaiable
        private string loadMore = "";
        public string LoadMore
        {
            get { return loadMore; }
            set
            {
                loadMore = value;
                OnPropertyChanged();
                RaisePropertyChange("LoadMore");
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
        //imgFilterBlue purpose of using image varaiable
        private string imgFilterBlue = "";
        public string ImgFilterBlue
        {
            get { return imgFilterBlue; }
            set
            {
                imgFilterBlue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgFilterBlue");
            }
        }
        //lblFilters purpose of using label varaiable
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
        //btnApply purpose of using textbox varaiable
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
        //filterSize purpose of using textbox varaiable
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
        //imgDownArrow purpose of using image varaiable
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
        //filterCarrier purpose of using textbox varaiable
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
        //imgDownArrow1 purpose of using image varaiable
        private string imgDownArrow1 = "";
        public string ImgDownArrow1
        {
            get { return imgDownArrow1; }
            set
            {
                imgDownArrow1 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow1");
            }
        }
        //placeContainer purpose of using textbox varaiable
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
        //placeBayan purpose of using textbox varaiable
        private string placeBayan = "";
        public string PlaceBayan
        {
            get { return placeBayan; }
            set
            {
                placeBayan = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBayan");
            }
        }
        //placeBillOfLading purpose of using textbox varaiable
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
        //placeDwell purpose of using textbox varaiable
        private string placeDwell = "";
        public string PlaceDwell
        {
            get { return placeDwell; }
            set
            {
                placeDwell = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceDwell");
            }
        }
        //lblDischargeDate purpose of using label varaiable
        private string lblDischargeDate = "";
        public string LblDischargeDate
        {
            get { return lblDischargeDate; }
            set
            {
                lblDischargeDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDischargeDate");
            }
        }
        //lblGatedOutDate purpose of using label varaiable
        private string lblGatedOutDate = "";
        public string LblGatedOutDate
        {
            get { return lblGatedOutDate; }
            set
            {
                lblGatedOutDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGatedOutDate");
            }
        }
        //imgReset purpose of using image varaiable
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

        //strselectedSize purpose of using image varaiable
        private string strselectedSize = "";
        public string StrselectedSize
        {
            get { return strselectedSize; }
            set
            {
                strselectedSize = value;
                OnPropertyChanged();
                RaisePropertyChange("StrselectedSize");
            }
        }

        //StrselectedCarrier purpose of using image varaiable
        private string strselectedCarrier = "";
        public string StrselectedCarrier
        {
            get { return strselectedCarrier; }
            set
            {
                strselectedCarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("StrselectedCarrier");
            }
        }

        //StrContainerNo purpose of using image varaiable
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

        //StrBayanNo purpose of using image varaiable
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

        //20230316 To hilde Main Page
        private bool isVisibleMain = false;
        public bool IsVisibleMain
        {
            get { return isVisibleMain; }
            set
            {
                isVisibleMain = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleMain");
            }
        }
        private bool isVisibleFilter = false;
        public bool IsVisibleFilter
        {
            get { return isVisibleFilter; }
            set
            {
                isVisibleFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilter");
            }
        }
        private bool isVisibleBackButton = false;
        public bool IsVisibleBackButton
        {
            get { return isVisibleBackButton; }
            set
            {
                isVisibleBackButton = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleBackButton");
            }
        }
        //StrBillofLadingNo purpose of using image varaiable
        private string strBillofLadingNo = "";
        public string StrBillofLadingNo
        {
            get { return strBillofLadingNo; }
            set
            {
                strBillofLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("strBillofLadingNo");
            }
        }

        //StrDwellDays purpose of using image varaiable
        private string strDwellDays = "";
        public string StrDwellDays
        {
            get { return strDwellDays; }
            set
            {
                strDwellDays = value;
                OnPropertyChanged();
                RaisePropertyChange("StrDwellDays");
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
        DateTime? _DateDischarge = null;
        public DateTime? DateDischargeCT
        {
            get { return _DateDischarge; }
            set
            {
                _DateDischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("DateDischargeCT");
            }

        }
        DateTime? _DateGatedOut = null;
        public DateTime? DateGatedOut
        {
            get { return _DateGatedOut; }
            set
            {
                _DateGatedOut = value;
                OnPropertyChanged();
                RaisePropertyChange("DateGatedOut");
            }
        }
        ContentPage Myview;
        /// <summary>
        /// Collection Object Creation
        /// </summary>
        public ObservableCollection<Models.DwelldaysModel.DwellDaysFilterDlList> lstFilterSizeData { get; set; } = new ObservableCollection<Models.DwelldaysModel.DwellDaysFilterDlList>();
        public ObservableCollection<Models.DwelldaysModel.DwellDaysFilterDlList> lstFilterCarrierData { get; set; } = new ObservableCollection<Models.DwelldaysModel.DwellDaysFilterDlList>();
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="fstrSearch"></param>
        /// <param name="fstrselectedSize"></param>
        /// <param name="fstrselectedCarrier"></param>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBayanNo"></param>
        /// <param name="fstrBillofLadingNo"></param>
        /// <param name="fstrDwellDays"></param>
        /// <param name="flstrDischargedate"></param>
        /// <param name="flstrGateOutdate"></param>
        /// <param name="fstrFilterFlag"></param>
        public DwelldaysViewModel(string fstrSearch, string fstrselectedSize, string fstrselectedCarrier, string fstrContainerNo, string fstrBayanNo, string fstrBillofLadingNo, string fstrDwellDays, string flstrDischargedate, string flstrGateOutdate, string fstrFilterFlag, ContentPage view)
        {
            try
            {
                Myview = view;
                //Appcenter Track Event handler
                Analytics.TrackEvent("DwelldaysViewModel");
                IsVisibleBackButton = false;
                IsVisibleMain = false;
                IsVisibleFilter = false;

                //Clear all filter Value.
                TxtContainerNo = "";
                TxtBayanNo = "";
                TxtBillOfLadingNo = "";
                TxtDwellDays = "";



                if (fstrFilterFlag == "N")
                {
                    IsVisibleMain = true;
                    IsVisibleFilter = false;
                }
                if (fstrFilterFlag == "Y")
                {
                    IsVisibleMain = false;
                    IsVisibleFilter = true;
                    IsVisibleBackButton = true;
                }
                strTotalCaption = "";
                //Begin-All Command Buttons
                btnFilterClicked = new Command(async () => await Dwelldaysfilter(), () => !IsBusy);
                //btnLoadMore = new Command(async () => await procloadMore(), () => !IsBusy);
                btnAnyWhereSearch = new Command(async () => await procAnywhereSSearch(), () => !IsBusy);
                gotoApplybutton = new Command(async () => await applybutton(), () => !IsBusy);
                ButtonClickedReset = new Command(async () => await Clear(), () => !IsBusy);
                ButtonClickedCancel = new Command(async () => await Clear(), () => !IsBusy);
                //End-All Command Buttons

                //Begin-Call Caption Function
                Task.Run(() => assignCMS()).Wait();
                Task.Run(() => assignCmsMsg()).Wait();
                //End-Caption Function
                //Begin-Call Filter GetData Funtion
                Task.Run(() => SizeFilterData()).Wait();
                Task.Run(() => CarrierFilterData()).Wait();
                //End-Call Filter GetData Funtion
                //}

                //Begin-Call Listview GetData Funtion                   
                Task.Run(() => DwellDayslist(fstrSearch, fstrselectedSize, fstrselectedCarrier, fstrContainerNo, fstrBayanNo, fstrBillofLadingNo, fstrDwellDays, flstrDischargedate, flstrGateOutdate)).Wait();
                //End-Call Listview GetData Funtions
                if (lstDwellDays == null || lstDwellDays.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To get Clear
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            IsBusy = true;
            DwellDaysEn = false;
            await Task.Delay(1000);
            await DwellDayslist("", "", "", "", "", "", "", "", "");
            await SizeFilterData();
            await CarrierFilterData();
            //To Collapse the Expander
            IsExpandedSize = false;
            IsExpandedCarrier = false;
            TxtBayanNo = "";
            TxtContainerNo = "";
            TxtBillOfLadingNo = "";
            TxtDwellDays = "";
            IsVisibleMain = true;
            IsVisibleFilter = false;
            DwellDaysEn = true;
            IsBusy = false;
        }

        /// <summary>
        /// To Navigate DwellDays Filter Page 
        /// </summary>
        /// <returns></returns>
        private async Task Dwelldaysfilter()
        {
            try
            {
                IsBusy = true;
                DwellDaysEn = false;
                await Task.Delay(1000);

                // await App.Current.MainPage?.Navigation.PushAsync(new DwellDays("", "", "", "", "", "", "", "", "", "Y"));
                //SizeFilterData();
                //CarrierFilterData();
                DateDischargeCT = null;
                DateGatedOut = null;
                IsVisibleMain = false;
                IsVisibleFilter = true;
                IsVisibleBackButton = true;

                DwellDaysEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// LoadMore Button Function
        /// </summary>
        /// <returns></returns>
        private async Task procloadMore()
        {
            try
            {
                IsBusy = true;
                DwellDaysEn = false;
                await Task.Delay(1000);
                LfintPageNo += 1;
                //Begin-Call Listview Get Funtion
                Task.Run(() => DwellDayslist(searchbox, strselectedSize, strselectedCarrier, strContainerNo, strBayanNo, strBillofLadingNo, strDwellDays, lstrDischargedate, lstrGateOutdate)).Wait();
                //End-Call Listview Get Funtions

                // Application.Current.MainPage?.Navigation.PushAsync(new DwellDays(searchbox, strselectedSize, strselectedCarrier, strContainerNo, strBayanNo, strBillofLadingNo, strDwellDays, lstrDischargedate, lstrGateOutdate));
                DwellDaysEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Anywhere Search Button Function
        /// </summary>
        /// <returns></returns>
        private async Task procAnywhereSSearch()
        {
            try
            {
                IsBusy = true;
                DwellDaysEn = false;
                await Task.Delay(1000);
                LfintPageNo = 1;
                //Begin-Call Listview Get Funtion
                await DwellDayslist(searchbox, strselectedSize, strselectedCarrier, strContainerNo, strBayanNo, strBillofLadingNo, strDwellDays, lstrDischargedate, lstrGateOutdate);
                //End-Call Listview Get Funtions
                DwellDaysEn = true;
                IsBusy = false;
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
        /// <param name="strselectedSize"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strBayanNo"></param>
        /// <param name="strBillofLadingNo"></param>
        /// <param name="strDwellDays"></param>
        /// <param name="lstrDischargedate"></param>
        /// <param name="lstrGateOutdate"></param>
        /// <returns></returns>
        private async Task DwellDayslist(string strSearchbox, string strselectedSize, string strselectedCarrier, string strContainerNo, string strBayanNo, string strBillofLadingNo, string strDwellDays, string lstrDischargedate, string lstrGateOutdate)
        {
            try
            {

                //Initiate Collection Object
                if (lfintPageNo == 1)
                {
                    if (lstDwellDays != null)
                    {
                        lstDwellDays.Clear();
                    }
                }

                string fstranywhere = "";
                string fstrContainerNo = "";
                string fstrBayanNo = "";
                string fstrBlno = "";
                string fstrSize = "";
                string fstrDwellDays = "";
                string fstrCarrier = "";
                string fstrDiscrivalDate = "";
                string fstrGateOutDate = "";

                if (strSearchbox != null) fstranywhere = strSearchbox;
                if (strContainerNo != null) fstrContainerNo = strContainerNo;
                if (strBayanNo != null) fstrBayanNo = strBayanNo;
                if (strBillofLadingNo != null) fstrBlno = strBillofLadingNo;
                if (strselectedSize != null) fstrSize = strselectedSize;
                if (strDwellDays != null) fstrDwellDays = strDwellDays;
                if (strselectedCarrier != null) fstrCarrier = strselectedCarrier;
                if (lstrDischargedate != null) fstrDiscrivalDate = lstrDischargedate;
                if (lstrGateOutdate != null) fstrGateOutDate = lstrGateOutdate;
                //lstDwellDays.Clear();
                string strFilterData = "fstrAnyWordSearch:" + fstranywhere + ";" + "fstrCD_CONTAINERNUMBER:" + fstrContainerNo + ";" + "fstrCD_BAYANNUMBER:" + fstrBayanNo + ";" + "fstrCD_BLNUMBER:" + fstrBlno + ";" + "fstrCD_SIZE:" + fstrSize + ";" + "fstrCD_DWELLDAYS:" + fstrDwellDays + ";" + "fstrCarrier:" + fstrCarrier + ";" + "fstrDiscrevalTime:" + fstrDiscrivalDate + ";" + "fstrGatedOutTime:" + fstrGateOutDate + "; ";

                var objRawData = new List<DwellDt>();
                //To call bussinesslayer 
                objRawData = objBl.getDwelldaysDetails(gblRegisteration.strLoginUser, lfintPageNo, lfintPageSize, strFilterData);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);

                }

                await Task.Delay(1000);
                foreach (var item in objRawData)
                {
                    item.lblSno = lblSno;
                    item.lblContainerNo = lblContainerNo;
                    item.lblSize = lblSize;
                    item.lblBayan = lblBayan;
                    item.lblBOL = lblBOL;
                    item.lblDischargedOn = lblDischargedOn;
                    item.lblGatedOutOn = lblGatedOutOn;
                    item.lblDDays = lblDDays;
                    item.lblCarrier = lblCarrier;
                }
                lstDwellDays = new ObservableCollection<DwellDt>(objRawData);
                totalRecordCount = lstDwellDays.Count;
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";

                if (lstDwellDays == null || lstDwellDays.Count == 0)
                {
                   App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                if(lstDwellDays.Count()>0)
                {
                    CollectionView cvDwellDays = Myview.FindByName<CollectionView>("GridDwellDays");
                    cvDwellDays.ItemsSource = null;
                    cvDwellDays.ItemsSource = lstDwellDays;
                    cvDwellDays.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                }
               




                //DwSearch.Focus();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        /// <returns></returns>
        private async Task assignCMS()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM402");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM402");
                }
                assignContent();

                strTotalCaption = cms.getCaption("strDwellDays", objCMS);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                lblSize = dbLayer.getCaption("strSize", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS);
                lblBOL = dbLayer.getCaption("strBillofLading", objCMS);
                lblDischargedOn = dbLayer.getCaption("strDischargedOn", objCMS);
                lblGatedOutOn = dbLayer.getCaption("strGatedOutOn", objCMS);
                lblDDays = dbLayer.getCaption("strDwellDays", objCMS);
                lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// To bind CMS Error Messages
        /// </summary>
        private async void assignCmsMsg()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        private async void assignContent()
        {
            try
            {

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}

                //dbLayer.objInfoitems = objCMS;
                await Task.Delay(1000);
                imgDwelldaysDarkBlue = dbLayer.getCaption("imgdwelldays", objCMS);
                imgSearch = dbLayer.getCaption("imgsearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                loadMore = dbLayer.getCaption("strLoadMore", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                txtSearch = dbLayer.getCaption("StrDwellDaysPlaceHolder", objCMS);
                imgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                lblFilters = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterSize = dbLayer.getCaption("strSize", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterCarrier = dbLayer.getCaption("strCarrier", objCMS);
                imgDownArrow1 = dbLayer.getCaption("imgDownArrow", objCMS);
                PlaceContainer = dbLayer.getCaption("strContainerNumber", objCMS);
                PlaceBayan = dbLayer.getCaption("strBayanNo", objCMS);
                PlaceBillOfLading = dbLayer.getCaption("strBillofLadingNo", objCMS);
                PlaceDwell = dbLayer.getCaption("strDwellDays", objCMS);
                lblDischargeDate = dbLayer.getCaption("strDischargeDate", objCMS);
                lblGatedOutDate = dbLayer.getCaption("strGatedOutDate", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);

                //  strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                // lblDwellDays.Text = dbLayer.getCaption("strDwellDays", objCMS);
                //lblCaptionDwellDay = dbLayer.getCaption("strDwellDays", objCMS);
                // lblDwellDays.Text = lblCaptionDwellDay + " (" + intTotalCount + ")";
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To get Size Filter Data
        /// </summary>
        /// <returns></returns>
        private async Task SizeFilterData()
        {
            try
            {
                List<clsDwellDaysSizeFilter> lstSize = new List<clsDwellDaysSizeFilter>();
                lstSize = objBl.getDwellDaysFilterSizeList(gblRegisteration.strLoginUser, "");
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstFilterSizeData.Clear();
                var groupedResult = from s in lstSize
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterSizeData.Add(new Models.DwelldaysModel.DwellDaysFilterDlList { CmbSize = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterSizeData.Add(new Models.DwelldaysModel.DwellDaysFilterDlList { CmbSize = item.Key });
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage?.DisplayAlert("", ex.Message, "OK");
            }

        }

        /// <summary>
        /// To get Carrier Filter Data
        /// </summary>
        /// <returns></returns>
        private async Task CarrierFilterData()
        {
            try
            {
                List<clsDwellDaysCarrierFilter> lstCarrier = new List<clsDwellDaysCarrierFilter>();

                lstCarrier = objBl.getDwellDaysFilterCarrierList(gblRegisteration.strLoginUser, "");
                await Task.Delay(1000);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstFilterCarrierData.Clear();
                var groupedResult = from s in lstCarrier.Where(s => s.text != "")
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterCarrierData.Add(new Models.DwelldaysModel.DwellDaysFilterDlList { CmbCarrier = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterCarrierData.Add(new Models.DwelldaysModel.DwellDaysFilterDlList { CmbCarrier = item.Key });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// Filter Apply Button Function
        /// </summary>
        /// <returns></returns>
        private async Task applybutton()
        {
            try
            {
                IsBusy = true;
                DwellDaysEn = false;
                await Task.Delay(1000);

                var strselectedSize = "";
                var strselectedCarrier = "";
                var strContainerNo = "";
                var strBayanNo = "";
                var strBillofLadingNo = "";
                var strDwellDays = "";

                if (lstFilterSizeData.Count > 0)
                {
                    foreach (var item in lstFilterSizeData)
                    {
                        if (item.isChecked == true)
                        {

                            if (item.CmbSize.ToString().Trim().ToUpper() != "ALL")
                            {
                                strselectedSize += item.CmbSize + ",";
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
                            if (item.CmbCarrier.ToString().Trim().ToUpper() != "ALL")
                            {
                                strselectedCarrier += item.CmbCarrier + ",";
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
                if (TxtBillofLadingNo != null)
                {
                    strBillofLadingNo = TxtBillofLadingNo;
                }
                if (TxtDwellDays != null)
                {
                    strDwellDays = TxtDwellDays;
                }
                if (DateDischargeCT != null)
                {
                    lstrDischargedate = DateDischargeCT.Value.ToString("yyyy-MM-dd");
                }

                if (DateGatedOut != null)
                {
                    lstrGateOutdate = DateGatedOut.Value.ToString("yyyy-MM-dd");
                }

                if (strselectedSize.Length > 0) strselectedSize = strselectedSize.Substring(0, strselectedSize.Length - 1);
                if (strselectedCarrier.Length > 0) strselectedCarrier = strselectedCarrier.Substring(0, strselectedCarrier.Length - 1);
                await DwellDayslist("", strselectedSize, strselectedCarrier, strContainerNo, strBayanNo, strBillofLadingNo, strDwellDays, lstrDischargedate, lstrGateOutdate);
                IsVisibleFilter = false;
                IsVisibleMain = true;
                IsBusy = false;
                DwellDaysEn = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}