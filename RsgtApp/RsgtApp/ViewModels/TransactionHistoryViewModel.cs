using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Foundation;
using Microsoft.AppCenter.Analytics;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RsgtApp.BusinessLayer;
using RsgtApp.Interfaces;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;

namespace RsgtApp.ViewModels
{
    public class TransactionHistoryViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;

        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public string strNoRecord = "";
        public Command ButtonClickedApply { get; set; }
        public Command ButtonClickedCancel { get; set; }
        public Command FilterClicked { get; set; }
        public Command AnyWhereSearch { get; set; }
        public Command BtnExcelClicked { get; set; }
        public Command gotoReset { get; set; }

    public int fintPageNumber = 1;
        public int fintPageSize = 100000;
        public int intTotalCount { get; set; }
        //  public List<TransDt> Transinfo { get => TransData(); }
        public System.Windows.Input.ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
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
        private string strTotalCaption = "";
        private ObservableCollection<clsTransactionHistory> lstTransactionHst { get; set; } = new ObservableCollection<clsTransactionHistory>();
        //public ObservableCollection<clsTransactionHistory> lstTransactionHst
        //{
        //    get { return _lstTransactionHst; }
        //    set
        //    {
        //        if (_lstTransactionHst == value)
        //            return;

        //        _lstTransactionHst = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("lstTransactionHst");
        //    }
        //}

        private string strServerSlowMsg = "";
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
        private bool stackTransHistory = true;
        public bool StackTransHistory
        {
            get { return stackTransHistory; }
            set
            {
                stackTransHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("StackTransHistory");
            }
        }

        private string imgTransHistoryDarkblue = "";
        public string ImgTransHistoryDarkblue
        {
            get { return imgTransHistoryDarkblue; }
            set
            {
                imgTransHistoryDarkblue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTransHistoryDarkblue");
            }
        }
        private string lblTransHistory = "";
        public string LblTransHistory
        {
            get { return lblTransHistory; }
            set
            {
                lblTransHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTransHistory");
            }
        }
        private string imgExcelIcon = "";
        public string ImgExcelIcon
        {
            get { return imgExcelIcon; }
            set
            {
                imgExcelIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgExcelIcon");
            }
        }
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
        private string lblInvoiceNo = "";
        public string LblInvoiceNo
        {
            get { return lblInvoiceNo; }
            set
            {
                lblInvoiceNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInvoiceNo");
            }
        }
        private string lblBillofLading = "";
        public string LblBillofLading
        {
            get { return lblBillofLading; }
            set
            {
                lblBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBillofLading");
            }
        }
        private string lblCustomer = "";
        public string LblCustomer
        {
            get { return lblCustomer; }
            set
            {
                lblCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCustomer");
            }
        }
        private string lblAccountNo = "";
        public string LblAccountNo
        {
            get { return lblAccountNo; }
            set
            {
                lblAccountNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAccountNo");
            }
        }
        private string lblAmount = "";
        public string LblAmount
        {
            get { return lblAmount; }
            set
            {
                lblAmount = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAmount");
            }
        }
        private string lblRefNo = "";
        public string LblRefNo
        {
            get { return lblRefNo; }
            set
            {
                lblRefNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRefNo");
            }
        }
        private string lblTransDate = "";
        public string LblTransDate
        {
            get { return lblTransDate; }
            set
            {
                lblTransDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTransDate");
            }
        }
        private string lblTransType = "";
        public string LblTransType
        {
            get { return lblTransType; }
            set
            {
                lblTransType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTransType");
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


        //Transaction Filter
        private bool stackTransactionFilter = true;
        public bool StackTransactionFilter
        {
            get { return stackTransactionFilter; }
            set
            {
                stackTransactionFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("StackTransactionFilter");
            }
        }
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
        private string lblPeriod = "";
        public string LblPeriod
        {
            get { return lblPeriod; }
            set
            {
                lblPeriod = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPeriod");
            }
        }
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
        private string imgDownArrow2 = "";
        public string ImgDownArrow2
        {
            get { return imgDownArrow2; }
            set
            {
                imgDownArrow2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow2");
            }
        }
        private string imgUpArrow = "";
        public string ImgUpArrow
        {
            get { return imgUpArrow; }
            set
            {
                imgUpArrow = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgUpArrow");
            }
        }
        private string imgUpArrow2 = "";
        public string ImgUpArrow2
        {
            get { return imgUpArrow2; }
            set
            {
                imgUpArrow2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgUpArrow2");
            }
        }
        private string lblSelectAllRecords = "";
        public string LblSelectAllRecords
        {
            get { return lblSelectAllRecords; }
            set
            {
                lblSelectAllRecords = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSelectAllRecords");
            }
        }
        private string lblSelectAll = "";
        public string LblSelectAll
        {
            get { return lblSelectAll; }
            set
            {
                lblSelectAll = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSelectAll");
            }
        }
        private string lblAddedtoWallet = "";
        public string LblAddedtoWallet
        {
            get { return lblAddedtoWallet; }
            set
            {
                lblAddedtoWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAddedtoWallet");
            }
        }
        private string placeFromDate = "";
        public string PlaceFromDate
        {
            get { return placeFromDate; }
            set
            {
                placeFromDate = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceFromDate");
            }
        }
        private string placeToDate = "";
        public string PlaceToDate
        {
            get { return placeToDate; }
            set
            {
                placeToDate = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceToDate");
            }
        }
        private string placeFromAmount = "";
        public string PlaceFromAmount
        {
            get { return placeFromAmount; }
            set
            {
                placeFromAmount = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceFromAmount");
            }
        }
        private string placeToAmount = "";
        public string PlaceToAmount
        {
            get { return placeToAmount; }
            set
            {
                placeToAmount = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceToAmount");
            }
        }
        private DateTime? txtFromDate = null;
        public DateTime? TxtFromDate
        {
            get { return txtFromDate; }
            set
            {
                txtFromDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFromDate");
            }
        }
        private DateTime? txtToDate = null;
        public DateTime? TxtToDate
        {
            get { return txtToDate; }
            set
            {
                txtToDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtToDate");
            }
        }

        // searchbox represents textbox variable
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
        private string txtFromAmount = "";
        public string TxtFromAmount
        {
            get { return txtFromAmount; }
            set
            {
                txtFromAmount = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFromAmount");
            }
        }
        private string txtToAmount = "";
        public string TxtToAmount
        {
            get { return txtToAmount; }
            set
            {
                txtToAmount = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtToAmount");
            }
        }
        private string lblTransactionType = "";
        public string LblTransactionType
        {
            get { return lblTransactionType; }
            set
            {
                lblTransactionType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTransactionType");
            }
        }
        private string lblFromDate = "";
        public string LblFromDate
        {
            get { return lblFromDate; }
            set
            {
                lblFromDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFromDate");
            }
        }
        private string lblToDate = "";
        public string LblToDate
        {
            get { return lblToDate; }
            set
            {
                lblToDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblToDate");
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
        //private DateTime? fromdate = null;
        //public DateTime? Fromdate
        //{
        //    get { return fromdate; }
        //    set
        //    {
        //        fromdate = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("Fromdate");
        //    }
        //}
        //private DateTime? todate = null;
        //public DateTime? Todate
        //{
        //    get { return todate; }
        //    set
        //    {
        //        todate = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("Todate");
        //    }
        //}
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
        //From Date Picker
        DateTime? _Fromdate=null;
        public DateTime? Fromdate
        {
            set { SetProperty(ref _Fromdate, value); }
            get { return _Fromdate; }
        }

        //To Date Picker
        DateTime? _Todate=null;
        public DateTime? Todate
        {
            set { SetProperty(ref _Todate, value); }
            get { return _Todate; }
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
                FilterClicked.ChangeCanExecute();
                ButtonClickedApply.ChangeCanExecute();
                ButtonClickedCancel.ChangeCanExecute();
                AnyWhereSearch.ChangeCanExecute();
                gotoReset.ChangeCanExecute();
            }
        }
        ContentPage Myview;
        public ObservableCollection<TransactionHstDt> lstFilterPeriodData { get; set; } = new ObservableCollection<TransactionHstDt>();
        public ObservableCollection<TransactionHstDt> lstFilterTransactionTypeData { get; set; } = new ObservableCollection<TransactionHstDt>();
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public TransactionHistoryViewModel(string strSearchbox, string strSelectedPeriod, string strSelectedTransactionType, string strFromDate, string strToDate, string strFromAmount, string strToAmount, ContentPage view)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("TransactionHistoryViewModel");
            Myview = view;
            Task.Run(() => assignCms()).Wait();
            Searchbox = strSearchbox;
            strTotalCaption = "";
            FilterClicked = new Command(async () => await filterClicked(), () => !IsBusy);
            AnyWhereSearch = new Command(async () => await AnyWheresearch(), () => !IsBusy);
            BtnExcelClicked = new Command(async () => await btnExcelClicked(), () => !IsBusy);
            ButtonClickedApply = new Command(async () => await buttonClickedApply(), () => !IsBusy);
            ButtonClickedCancel = new Command(async () => await Clear(), () => !IsBusy);
            gotoReset = new Command(async () => await Clear(), () => !IsBusy);
            Task.Run(() => TransactionHstLst(Searchbox, strSelectedPeriod, strSelectedTransactionType, strFromDate, strToDate, strFromAmount, strToAmount).Wait());


            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;
            if (lstTransactionHst == null || lstTransactionHst.Count == 0)
            {
                App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
            }
        }

        /// <summary>
        /// To get Clear
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            IsBusy = true;
            StackTransHistory = false;
            await Task.Delay(1000);
            await TransactionHstLst("", "" , "", "", "", "", "");
            assignCms();
            assignContent();
            TxtFromAmount = "";
            TxtToAmount = "";

            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;

            StackTransHistory = true;
            IsBusy = false;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM431");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM431");
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
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            dbLayer.objInfoitems = objCMS;
            Dictionary<string, string> lobjpicPeriod = dbLayer.getLOV("strperiodLov", objCMS);
            //20230322 As per Mr.Raju Advice Select All Removed Temporary
            //lstFilterPeriodData.Add(new TransactionHstDt { lblPeriodData = lstrCaptionALL });
            lstFilterPeriodData.Clear();
            foreach (var dic in lobjpicPeriod)
            {
                lstFilterPeriodData.Add(new TransactionHstDt { lblPeriodData = dic.Key });
            }


            Dictionary<string, string> lobjpicTransactionType = dbLayer.getLOV("strtransactiontypeLov", objCMS);
            //20230322 As per Mr.Raju Advice Select All Removed Temporary
            // lstFilterTransactionTypeData.Add(new TransactionHstDt { lblTransactionType = lstrCaptionALL });
            lstFilterTransactionTypeData.Clear();
            foreach (var dic in lobjpicTransactionType)
            {
                lstFilterTransactionTypeData.Add(new TransactionHstDt { lblTransactionType = dic.Key });
            }

            await Task.Delay(1000);
            strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);

            ImgTransHistoryDarkblue = dbLayer.getCaption("imgtransactionhistory", objCMS);
            strTotalCaption = cms.getCaption("strTransactionHistory", objCMS);
            ImgExcelIcon = dbLayer.getCaption("imgexcel", objCMS);
            ImgSearch = dbLayer.getCaption("imgsearch", objCMS);
            ImgFilter = dbLayer.getCaption("imgfilter", objCMS);
            LblInvoiceNo = dbLayer.getCaption("strInvoiceNo", objCMS);
            LblBillofLading = dbLayer.getCaption("strBillofLading", objCMS);
            LblCustomer = dbLayer.getCaption("strCustomer", objCMS);
            LblAccountNo = dbLayer.getCaption("strAccountNoCard", objCMS);
            LblAmount = dbLayer.getCaption("strAmount", objCMS);
            LblRefNo = dbLayer.getCaption("strReferenceNo", objCMS);
            LblTransDate = dbLayer.getCaption("strTransactionDate", objCMS);
            LblTransType = dbLayer.getCaption("strTransactionType", objCMS);
            strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);

            //TransactionFilter
            ImgFilterBlue = dbLayer.getCaption("imgFilterBlue", objCMS);
            LblFilters = dbLayer.getCaption("strFilters", objCMS);
            BtnApply = dbLayer.getCaption("strApply", objCMS);
            ImgReset = dbLayer.getCaption("imgReset", objCMS);
            LblPeriod = dbLayer.getCaption("strPeriod", objCMS);
            ImgDownArrow = dbLayer.getCaption("imgdownArrow", objCMS);
            ImgDownArrow2 = dbLayer.getCaption("imgdownArrow", objCMS);
            ImgUpArrow = dbLayer.getCaption("imgupArrow", objCMS);
            ImgUpArrow2 = dbLayer.getCaption("imgupArrow", objCMS);
            LblSelectAllRecords = dbLayer.getCaption("strSelectAllRecords", objCMS);
            LblSelectAll = dbLayer.getCaption("strSelectAll", objCMS);
            PlaceFromDate = dbLayer.getCaption("strFromDate", objCMS);
            PlaceToDate = dbLayer.getCaption("strToDate", objCMS);
            PlaceFromAmount = dbLayer.getCaption("strFromAmount", objCMS);
            PlaceToAmount = dbLayer.getCaption("strToAmount", objCMS);
            LblTransactionType = dbLayer.getCaption("strTransactionType", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            LblFromDate = dbLayer.getCaption("strFromDate", objCMS);
            LblToDate = dbLayer.getCaption("strToDate", objCMS);
        }
        /// <summary>
        /// To get ListView Function
        /// </summary>
        /// <returns></returns>
        public async Task TransactionHstLst(string strSearchbox, string strSelectedPeriod, string strSelectedTransactionType, string strFromDate, string strToDate, string strFromAmount, string strToAmount)
        {

            //Initiate Collection Object
            if (lfintPageNo == 1)
            {
                if (lstTransactionHst != null)
                {
                    lstTransactionHst.Clear();
                }
            }
            string gblAnyWhere = "";
            string lstrSelectedPeriod = "";
            string lstrSelectedTransactionType = "";
            string lstrFromDate = "";
            string lstrToDate = "";
           // string lstrPeriod = "";
            string lstrFromAmount = "";
            string lstrToAmount = "";
          //  string lstrTranscationType = "";
            if (strSearchbox != null) gblAnyWhere = strSearchbox;
            if (strSelectedPeriod != null) lstrSelectedPeriod = strSelectedPeriod;
            if (strSelectedTransactionType != null) lstrSelectedTransactionType = strSelectedTransactionType;
            if (strFromDate != null) lstrFromDate = strFromDate;
            if (strToDate != null) lstrToDate = strToDate;
            if (strFromAmount != null) lstrFromAmount = strFromAmount;
            if (strToAmount != null) lstrToAmount = strToAmount;
            // https://webgateway.rsgt.com:9090/eportal_api/getTransactionHistory?
            // fstrMailID=cieloconsignee@gmail.com&fstrFilter=fstrAnyWhere:;fstrFromDate:;
            // fstrToDate:;fstrPeriod:;fstrFromAmount:;fstrToAmount:;FstrTranscationType:;
            // &fstrPageNumber=1&fstrPageSize=10
            await Task.Delay(1000);
            var objRawData = new List<clsTransactionHistory>();
            string gblfilter = "";
            gblfilter += "fstrAnyWhere:" + gblAnyWhere + ";" + "fstrFromDate:" + lstrFromDate + ";" + "fstrToDate:" + lstrToDate + ";" + "fstrPeriod:" + lstrSelectedPeriod + ";" + "fstrFromAmount:" + lstrFromAmount + ";" + "fstrToAmount:" + lstrToAmount + ";" + "FstrTranscationType:" + lstrSelectedTransactionType + ";";
            objRawData = objBl.getTransactionHistory(gblRegisteration.strLoginUser, gblfilter, fintPageNumber, fintPageSize);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
              App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            foreach (var item in objRawData)
            {
                item.LblInvoiceNo = lblInvoiceNo;
                item.LblBillofLading = lblBillofLading;
                item.LblCustomer = lblCustomer;
                item.LblAccountNo = lblAccountNo;
                item.LblAmount = lblAmount;
                item.LblRefNo = lblRefNo;
                item.LblTransDate = lblTransDate;
                item.LblTransType = lblTransType;
                //lstTransactionHst.Add(item);
            }
            lstTransactionHst = new ObservableCollection<clsTransactionHistory>(objRawData);
            totalRecordCount = lstTransactionHst.Count;
            TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
            if (lstTransactionHst.Count() > 0)
            {
                CollectionView cvTransactionhistory = Myview.FindByName<CollectionView>("GridTransactionHistory");
                cvTransactionhistory.ItemsSource = null;
                cvTransactionhistory.ItemsSource = lstTransactionHst;
                cvTransactionhistory.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
            }
          

            if (lstTransactionHst == null || lstTransactionHst.Count == 0)
            {
              App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
            }
        }
        /// <summary>
        /// To get AnyWheresearch Function
        /// </summary>
        /// <returns></returns>
        private async Task AnyWheresearch()
        {
            IsBusy = true;
            StackTransHistory = false;
            await Task.Delay(1000);
            LfintPageNo = 1;
            Application.Current.MainPage?.Navigation.PushAsync(new TransactionHistory(Searchbox, "", "", "", "", "", ""));
            StackTransHistory = true;
            IsBusy = false;

        }
        /// <summary>
        /// To get filterClicked Function
        /// </summary>
        /// <returns></returns>
        private async Task filterClicked()
        {
            IsBusy = true;
            StackTransHistory = false;
            await Task.Delay(1000);
            
            await TransactionHstLst("", "", "", "", "", "", "");
            assignCms();
            assignContent();

            IsVisibleFilterScreen = true;
            IsVisibleMainScreen = false;

            StackTransHistory = true;
            IsBusy = false;

            //App.Current.MainPage?.Navigation.PushAsync(new TransactionFilter());
        }
        /// <summary>
        /// To get Apply Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonClickedApply()
        {
            IsBusy = true;
            StackTransactionFilter = false;
            await Task.Delay(1000);
            var strSelectedPeriod = "";
            var strSelectedTransactionType = "";
            var strFromDate = "";
            var strToDate = "";
            var strFromAmount = "";
            var strToAmount = "";

            if (lstFilterPeriodData.Count > 0)
            {
                foreach (var item in lstFilterPeriodData)
                {
                    if (item.isChecked == true)
                    {
                        if (item.lblPeriodData.ToString().ToUpper().Trim() != "ALL")
                        {
                            strSelectedPeriod += item.lblPeriodData + ",";
                        }
                    }
                }
            }
            if (lstFilterTransactionTypeData.Count > 0)
            {
                foreach (var item in lstFilterTransactionTypeData)
                {
                    if (item.isChecked == true)
                    {
                        if (item.lblTransactionType.ToString().ToUpper().Trim() != "ALL")
                        {
                            strSelectedTransactionType += item.lblTransactionType + ",";
                        }
                    }
                }
            }
            if (Fromdate != null)
            {
                strFromDate = Fromdate.Value.ToString("yyyy-MM-dd");
            }
            if (Todate != null)
            {
                strToDate = Todate.Value.ToString("yyyy-MM-dd");
            }
            //if (TxtFromDate != null)
            //{
            //    strFromDate = TxtFromDate.Value.ToString("yyyy-MM-dd");
            //}
            //if (TxtToDate != null)
            //{
            //    strToDate = TxtToDate.Value.ToString("yyyy-MM-dd");
            //}
            if (TxtFromAmount != null)
            {
                strFromAmount = TxtFromAmount;
            }
            if (TxtToAmount != null)
            {
                strToAmount = TxtToAmount;
            }
            if (strSelectedPeriod.Length > 0) strSelectedPeriod = strSelectedPeriod.Substring(0, strSelectedPeriod.Length - 1);
            if (strSelectedTransactionType.Length > 0) strSelectedTransactionType = strSelectedTransactionType.Substring(0, strSelectedTransactionType.Length - 1);


            //App.Current.MainPage?.Navigation.PushAsync(new TransactionHistory(Searchbox, strSelectedPeriod, strSelectedTransactionType, strFromDate, strToDate, strFromAmount, strToAmount));
            await TransactionHstLst("", strSelectedPeriod, strSelectedTransactionType, strFromDate, strToDate, strFromAmount, strToAmount);
            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;

            StackTransactionFilter = true;
            IsBusy = false;
        }

        /* Get Xamarin developers list from Service*/
        public async System.Threading.Tasks.Task btnExcelClicked()
        {
            // Granted storage permission
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (storageStatus != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
                storageStatus = results[Permission.Storage];
            }

            if (lstTransactionHst.Count() > 0)
            {
                try
                {
                    string date = DateTime.Now.ToShortDateString();
                    date = date.Replace("/", "_");
                    // var path = "";
                    var path = "";
                    if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
                    {
                        // var path = "";
                        path = DependencyService.Get<IExportFilesToLocation>().GetFolderLocation();
                        
                    }
                    else
                    {
                        // var path = "";
                        path = DependencyService.Get<IExportFilesToLocation>().GetFolderLocation();

                    }

                    //string fileName = "Excel" + "_" + DateTime.Now.ToString("yyyyMMddhhmmss").Trim() +".xlsx";
                    //// path = NSBundle.MainBundle.PathForResource(fileName, ofType: "xlsx");
                    //string strFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //string filePath = path + fileName;
                    //FilePath = filePath;

                    string fileName = "Excel" + "_" + DateTime.Now.ToString("yyyyMMddhhmmss").Trim() + ".xlsx";
                    // path = NSBundle.MainBundle.PathForResource(fileName, ofType: "xlsx");
                    string strFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    path = path + fileName;
                    FilePath = path;
                    // FileStream outStream = new FileStream(path, FileMode.OpenOrCreate);
                    using (SpreadsheetDocument document = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
                    {

                        WorkbookPart workbookPart = document.AddWorkbookPart();


                        workbookPart.Workbook = new Workbook();

                        WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                        worksheetPart.Worksheet = new Worksheet();

                        Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                        Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Xamarin Forms developers list" };
                        sheets.Append(sheet);

                        workbookPart.Workbook.Save();

                        SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                        // Constructing header
                        Row row = new Row();

                        row.Append(
                             ConstructCell("LblInvoiceNo", CellValues.String),
                             ConstructCell("LblBillofLading", CellValues.String),
                             ConstructCell("LblAmount", CellValues.String),
                             ConstructCell("LblRefNo", CellValues.String),
                             ConstructCell("LblTransDate", CellValues.String),
                             ConstructCell("LblTransType", CellValues.String)
                            );

                        // Insert the header row to the Sheet Data
                        sheetData.AppendChild(row);

                        // Add each product
                        foreach (var d in lstTransactionHst)
                        {
                            row = new Row();
                            row.Append(
                                ConstructCell(d.wt_invoiceno.ToString(), CellValues.String),
                                ConstructCell(d.wt_blnumber.ToString(), CellValues.String),
                                ConstructCell(d.fmt_trnamount.ToString(), CellValues.String),
                                ConstructCell(d.wt_payref.ToString(), CellValues.String),
                                ConstructCell(d.fmt_trndatetime.ToString(), CellValues.String),
                                ConstructCell(d.wt_trntype.ToString(), CellValues.String));
                            sheetData.AppendChild(row);
                        }

                        worksheetPart.Worksheet.Save();
                        MessagingCenter.Send(this, "DataExportedSuccessfully");
                        await App.Current.MainPage?.DisplayAlert("Info", "Data exported Successfully. The location is :" + FilePath, "OK");

                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ERROR: " + ex.Message);
                }
            }
            else
            {
                MessagingCenter.Send(this, "NoDataToExport");
            }
        }
        /* To create cell in Excel */
        private Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }
        public ICommand ExportToExcelCommand { get; set; }

        private string _filePath = "";
        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value); }
        }
    }
}
