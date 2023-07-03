using Android.Provider;
using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
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
using static RsgtApp.Models.PaymentHistroyModel;
using Browser = Xamarin.Essentials.Browser;

namespace RsgtApp.ViewModels
{
    class PaymentHistroyViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //btnFilterClicked Button
        public Command btnAnyWhereSearch { get; set; }
        //btnFilterClicked Button 
        public Command btnFilterClicked { get; set; }
        // btnLoadMore Button
        public Command btnLoadMore { get; set; }
        //tapOpenPdfPINo Button
        public Command tapOpenPdfPINo { get; set; }
        //Apply Button
        public Command gotoApply { get; set; }
        // Applyclick Button
        public Command gotoClickedApply { get; set; }
        // Cancel Button
        public Command gotoClickedCancel { get; set; }
        //To create Collection Object used ObservableCollection
        public ObservableCollection<PaymentDt> lstPaymentHistroy { get; set; } = new ObservableCollection<PaymentDt>();
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
        //To Declare Count Variable
        //private int totalRecordCount = 0;
        //private string strtotalRecordCount = "";
        //public string TotalRecordCount
        //{
        //    get { return strtotalRecordCount; }
        //}
        private string totalRecordCount = "";
        public string TotalRecordCount
        {
            get { return totalRecordCount; }
            set
            {
                totalRecordCount = value;
                OnPropertyChanged();
                RaisePropertyChange("TotalRecordCount");
            }
        }
        private int fintPageSize = 1000;
        private int fintPageNo = 1;
        private string strTotalCaption = "";
        public string strNoRecord = "";
        public string lblSno = "";
        public string lblInvoiceNo = "";
        public string lblCustomer = "";
        public string lblBOL = "";
        public string lblBayan = "";
        public string lblAmount = "";
        public string lblCreatedOn = "";
        public string lblValidity = "";
        public string lblMOP = "";
        public string lblDueDate = "";
        public string lblPaymentRef = "";
        public string lblPaidOn = "";
        public string lblStatusColor = "";
        public string lblStatus = "";
        public string lstrCaptionALL = "";
        public string strServerSlowMsg = "";
        public string lstrfromDate = "";
        public string lstrToDate = "";
        // Begin -Two way Binding Variable
        //IndicatorBGColor purpose of using IndicatorBGColor varaiable
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
        //IndicatorBGOpacity of using IndicatorBGOpacity varaiable
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
        //dateGatedOut purpose of using textbox varaiable
        //private DateTime? dateFromdate = null;
        //public DateTime? DateFromdate
        //{
        //    get { return dateFromdate; }
        //    set
        //    {
        //        dateFromdate = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("DateFromdate");
        //    }
        //}
        ////dateGatedOut purpose of using textbox varaiable
        //private DateTime? dateToDate = null;
        //public DateTime? DateToDate
        //{
        //    get { return dateToDate; }
        //    set
        //    {
        //        dateToDate = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("DateToDate");
        //    }
        //}
        //Searchbox purpose of using Searchbox varaiable
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
        // enumType  combo variable
        private string enumType = "";
        public string EnumType
        {
            get { return enumType; }
            set
            {
                enumType = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumType");
            }
        }
        //txtInvoiceNo purpose of using textbox varaiable
        private string txtInvoiceNo = "";
        public string TxtInvoiceNo
        {
            get { return txtInvoiceNo; }
            set
            {
                txtInvoiceNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtInvoiceNo");
            }
        }
        //txtBOL purpose of using textbox varaiable
        private string txtBOL = "";
        public string TxtBOL
        {
            get { return txtBOL; }
            set
            {
                txtBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOL");
            }
        }
        //txtBayan purpose of using textbox varaiable
        private string txtBayan = "";
        public string TxtBayan
        {
            get { return txtBOL; }
            set
            {
                txtBayan = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBayan");
            }
        }
        //txtFromAmount purpose of using textbox varaiable
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
        //txtPaymentref purpose of using textbox varaiable
        private string txtPaymentref = "";
        public string TxtPaymentref
        {
            get { return txtPaymentref; }
            set
            {
                txtPaymentref = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtPaymentref");
            }
        }
        //enumStatus purpose of using comb varaiable
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
        //enumMOP purpose of using comb varaiable
        private string enumMOP = "";
        public string EnumMOP
        {
            get { return enumMOP; }
            set
            {
                enumMOP = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumMOP");
            }
        }
        //txtCreatedon purpose of using textbox varaiable
        private string txtCreatedon = "";
        public string TxtCreatedon
        {
            get { return txtCreatedon; }
            set
            {
                txtCreatedon = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCreatedon");
            }
        }
        //enumtype purpose of using comb varaiable
        private string enumtype = "";
        public string Enumtype
        {
            get { return enumtype; }
            set
            {
                enumtype = value;
                OnPropertyChanged();
                RaisePropertyChange("Enumtype");
            }
        }
        //txtConsigneename purpose of using textbox varaiable
        private string txtConsigneename = "";
        public string TxtConsigneename
        {
            get { return txtConsigneename; }
            set
            {
                txtConsigneename = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtConsigneename");
            }
        }
        private string lblType = "";
        public string LblType
        {
            get { return lblType; }
            set
            {
                lblType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblType");
            }
        }
        //txtFromDate purpose of using textbox varaiable
        private string txtFromDate = "";
        public string TxtFromDate
        {
            get { return txtFromDate; }
            set
            {
                txtFromDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFromDate");
            }
        }
        //txtCondTodate purpose of using textbox varaiable
        private string txtCondTodate = "";
        public string TxtCondTodate
        {
            get { return txtCondTodate; }
            set
            {
                txtCondTodate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCondTodate");
            }
        }
        //txtToAmount purpose of using textbox varaiable
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
        //txtBillOfLadingNo purpose of using textbox varaiable
        private string txtBillOfLadingNo = "";
        public string TxtBillOfLadingNo
        {
            get { return txtBillOfLadingNo; }
            set
            {
                txtBillOfLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("txtBillOfLadingNo");
            }
        }
        //txtCustomer purpose of using textbox varaiable
        private string txtCustomer = "";
        public string TxtCustomer
        {
            get { return txtCustomer; }
            set
            {
                txtCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCustomer");
            }
        }
        //txtPaymentRef purpose of using textbox varaiable
        private string txtPaymentRef = "";
        public string TxtPaymentRef
        {
            get { return txtPaymentRef; }
            set
            {
                txtPaymentRef = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtPaymentRef");
            }
        }
        //imgPaymentHistory purpose of using image varaiable
        private string imgPaymentHistory = "";
        public string ImgPaymentHistory
        {
            get { return imgPaymentHistory; }
            set
            {
                imgPaymentHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgPaymentHistory");
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
        //ImgFilter purpose of using image varaiable
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
        //ImgFilterBlue purpose of using image varaiable
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
        //filterlblStatus purpose of using label varaiable
        private string filterlblStatus = "";
        public string FilterlblStatus
        {
            get { return filterlblStatus; }
            set
            {
                filterlblStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterlblStatus");
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
        //filterlblMOP purpose of using textbox varaiable
        private string filterlblMOP = "";
        public string FilterlblMOP
        {
            get { return filterlblMOP; }
            set
            {
                filterlblMOP = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterlblMOP");
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
        //filterlblType purpose of using label varaiable
        private string filterlblType = "";
        public string FilterlblType
        {
            get { return filterlblType; }
            set
            {
                filterlblType = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterlblType");
            }
        }
        //imgDownArrow2 purpose of using image varaiable
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
        //placeCustomers purpose of using textbox varaiable
        private string placeCustomers = "";
        public string PlaceCustomers
        {
            get { return placeCustomers; }
            set
            {
                placeCustomers = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceCustomers");
            }
        }
        //placePaymentRefs purpose of using textbox varaiable
        private string placePaymentRefs = "";
        public string PlacePaymentRefs
        {
            get { return placePaymentRefs; }
            set
            {
                placePaymentRefs = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacePaymentRefs");
            }
        }
        //placeFromAmounts purpose of using textbox varaiable
        private string placeFromAmounts = "";
        public string PlaceFromAmounts
        {
            get { return placeFromAmounts; }
            set
            {
                placeFromAmounts = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceFromAmounts");
            }
        }
        //placeToAmounts purpose of using textbox varaiable
        private string placeToAmounts = "";
        public string PlaceToAmounts
        {
            get { return placeToAmounts; }
            set
            {
                placeToAmounts = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceToAmounts");
            }
        }
        //lblFromdate1 purpose of using label varaiable
        private string lblFromdate1 = "";
        public string LblFromdate1
        {
            get { return lblFromdate1; }
            set
            {
                lblFromdate1 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFromdate1");
            }
        }
        //lblToDate1 purpose of using label varaiable
        private string lblToDate1 = "";
        public string LblToDate1
        {
            get { return lblToDate1; }
            set
            {
                lblToDate1 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblToDate1");
            }
        }
        //placeInvoice purpose of using textbox varaiable
        private string placeInvoice = "";
        public string PlaceInvoice
        {
            get { return placeInvoice; }
            set
            {
                placeInvoice = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceInvoice");
            }
        }
        //To handle paymetEn variable
        bool paymetEn = true;
        public bool PaymetEn
        {
            get { return paymetEn; }
            set
            {
                paymetEn = value;
                OnPropertyChanged();
                RaisePropertyChange("PaymetEn");
            }
        }
        DateTime? _DateFromdate = null;
        public DateTime? DateFromdate
        {
            set { SetProperty(ref _DateFromdate, value); }
            get { return _DateFromdate; }
        }


        DateTime? _DateToDate = null;

        public DateTime? DateToDate
        {
            set { SetProperty(ref _DateToDate, value); }
            get { return _DateToDate; }
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
        private List<EnumCombo> _lobjpicType = new List<EnumCombo>();
        public List<EnumCombo> lobjpicType
        {
            get { return _lobjpicType; }
            set
            {
                _lobjpicType = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjpicType");
            }
        }
        //To Declare combo variable
        //private EnumCombo _SelectedType;
        //public EnumCombo SelectedType
        //{
        //    get { return _SelectedType; }
        //    set
        //    {
        //        SetProperty(ref _SelectedType, value);
        //    }
        //}
        //To Declare combo variable  -- ViewModel (Ln:711)

        //To Declare combo variable - 20230322
        private EnumCombo _SelectedType;
        public EnumCombo SelectedPaymentType
        {
            get { return _SelectedType; }
            set
            {
                SetProperty(ref _SelectedType, value);
                RaisePropertyChange("SelectedPaymentType");
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
        private bool _isExpandedMOP = false;
        public bool IsExpandedMOP
        {
            get { return _isExpandedMOP; }
            set { SetProperty(ref _isExpandedMOP, value); }
        }
        //To handle Boolen variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                btnAnyWhereSearch.ChangeCanExecute();
                btnFilterClicked.ChangeCanExecute();
                gotoApply.ChangeCanExecute();
                gotoClickedApply.ChangeCanExecute();
                gotoClickedCancel.ChangeCanExecute();
            }
        }
        ContentPage Myview;
        // End -Two way Binding Variable
        public ObservableCollection<PaymentHistoryFilterDtlist> lstFilterMopdata { get; set; } = new ObservableCollection<PaymentHistoryFilterDtlist>();
        public ObservableCollection<PaymentHistoryFilterDtlist> lstFilterTypedata { get; set; } = new ObservableCollection<PaymentHistoryFilterDtlist>();
        public ObservableCollection<PaymentHistoryFilterDtlist> lstFilterStatusdata { get; set; } = new ObservableCollection<PaymentHistoryFilterDtlist>();
        Dictionary<string, string> lobjpicMop = new Dictionary<string, string>();
        Dictionary<string, string> lobjpicStatus = new Dictionary<string, string>();
        //Dictionary<string, string> lobjpicType = new Dictionary<string, string>();
        public System.Windows.Input.ICommand OpenPdfPINo => new Command<PaymentDt>(Open_PdfPINo);
        //Begin-ViewModel Constructor 
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public PaymentHistroyViewModel(string strSearchbox, string strInvoiceNo, string strdBOLNo, string strCutomer, string strPaymentRef, string strSelectedStatus, string strSelectedMop, string strSelectedType, string lstrfromDate, string lstrToDate, string strFromAmount, string strToAmount, ContentPage view)
        {
            try
            {
                Analytics.TrackEvent("PaymentHistroyViewModel");
                Myview = view;
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;
                //Initiate Collection Object
                //   lstPaymentHistroy = new ObservableCollection<PaymentDt>();

                strTotalCaption = "";

                Searchbox = strSearchbox;
                //Begin-All Command Buttons
                btnFilterClicked = new Command(async () => await Paymentfilter(), () => !IsBusy);
             //   btnLoadMore = new Command(async () => await PaymentHistroylist(strSearchbox, strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strSelectedType, lstrfromDate, lstrToDate, strFromAmount, strToAmount), () => !IsBusy);

                btnAnyWhereSearch = new Command(async () => await paymentAnyWhere(), () => !IsBusy);
                //Filter
                gotoApply = new Command(async () => await ClickedApply(), () => !IsBusy);

                gotoClickedApply = new Command(async () => await Clear(), () => !IsBusy);

                gotoClickedCancel = new Command(async () => await Clear(), () => !IsBusy);
                //End-All Command Buttons



                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
                Task.Run(() => PaymentHistroylist(strSearchbox, strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strSelectedType, lstrfromDate, lstrToDate, strFromAmount, strToAmount)).Wait();
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To clear data 
        /// </summary>
        public async Task Clear()
        {
            IsBusy = true;
            PaymetEn = false;
            await Task.Delay(1000);
            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;
            lstFilterMopdata.Clear();
            Searchbox = "";
            await PaymentHistroylist("", "", "", "", "", "", "", "", "", "", "", "");
            assignCms();
            assignContent();
            IsExpandedStatus = false;
            IsExpandedMOP = false;
            TxtInvoiceNo = "";
            TxtBillOfLadingNo = "";
            TxtCustomer = "";
            TxtPaymentRef = "";
            TxtFromAmount = "";
            TxtToAmount = "";
            DateFromdate = null;
            DateToDate = null;


            //App.Current.MainPage?.Navigation.PushAsync(new PaymentHistory("","","","","","","","","","","",""));
            PaymetEn = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Navigate payment Filter Page
        /// </summary>
        //To Navigate payment Filter Page 
        private async Task Paymentfilter()
        {
            try
            {
                IsBusy = true;
                PaymetEn = false;
                await Task.Delay(1000);
                IsVisibleMainScreen = false;
                IsVisibleFilterScreen = true;
                DateFromdate = null;
                DateToDate = null;
                PaymetEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To Navigate payment AnyWhere Page
        /// <summary>
        /// To Navigate payment AnyWhere Page
        /// </summary>
        private async Task paymentAnyWhere()
        {
            try
            {
                IsBusy = true;
                PaymetEn = false;
                await Task.Delay(1000);
                await PaymentHistroylist(Searchbox, "", "", "", "", "", "", "", "", "", "", "");
                // Application.Current.MainPage?.Navigation.PushAsync(new PaymentHistory(searchbox, "", "", "", "", "", "", "", "", "", "", ""));
                PaymetEn = true;
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
        private async Task PaymentHistroylist(string strSearchbox, string strInvoiceNo, string strdBOLNo, string strCutomer, string strPaymentRef, string strSelectedStatus, string strSelectedMop, string strSelectedType, string lstrfromDate, string lstrToDate, string strFromAmount, string strToAmount)
        {
            try
            {
                string lstrAnyWhere = "";
                string lstrInvoiceNo = "";
                string lstrBOL = "";
                string lstrConsigneename = "";
                string lstrPaymentref = "";
                string lstrStatus = "";
                string lstrMOP = "";
                string lstrType = "";
                string lstrFromDate = "";
                string lstrCondTodate = "";
                string lstrFromAmount = "";
                string lstrToAmount = "";
                if (strSearchbox != null) lstrAnyWhere = strSearchbox;
                if (strInvoiceNo != null) lstrInvoiceNo = strInvoiceNo;
                if (strdBOLNo != null) lstrBOL = strdBOLNo;
                if (strCutomer != null) lstrConsigneename = strCutomer;
                if (strPaymentRef != null) lstrPaymentref = strPaymentRef;
                if (strSelectedStatus != null) lstrStatus = strSelectedStatus;
                if (strSelectedMop != null) lstrMOP = strSelectedMop;
                if (strSelectedType != null) lstrType = strSelectedType;
                if (lstrfromDate != null) lstrFromDate = lstrfromDate;
                if (lstrToDate != null) lstrCondTodate = lstrToDate;
                if (strFromAmount != null) lstrFromAmount = strFromAmount;
                if (strToAmount != null) lstrToAmount = strToAmount;
                var objRawData = new List<PaymentDt>();
                lstPaymentHistroy.Clear();
                string fstrFilter = "fstrAnyWhere:" + lstrAnyWhere + "; fstrInvoiceNo:" + lstrInvoiceNo + "; fstrBillofladingno:" + lstrBOL + "; fstrConsigneename:" + lstrConsigneename + "; fstrPaymentref:" + lstrPaymentref + "; fstrStatus:" + lstrStatus + "; fstrMop:" + lstrMOP + ";fstrType:" + lstrType + ";fstrFromDate:" + lstrFromDate + ";fstrCondTodate:" + lstrCondTodate + ";fstrFromAmount:" + lstrFromAmount + ";fstrToAmount:" + lstrToAmount + ";";
                //To call bussinesslayer 
                objRawData = objBl.getPaymentHistory(fstrFilter, fintPageNo, fintPageSize);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                await Task.Delay(1000);
                foreach (var item in objRawData)
                {
                    item.lblSno = lblSno;
                    item.lblInvoiceNo = lblInvoiceNo;
                    item.lblCustomer = lblCustomer;
                    item.lblBOL = lblBOL;
                    item.lblBayan = lblBayan;
                    item.lblAmount = lblAmount;
                    item.lblCreatedOn = lblCreatedOn;
                    item.lblValidity = lblValidity;
                    item.lblMOP = lblMOP;
                    item.lblDueDate = lblDueDate;
                    item.lblPaymentRef = lblPaymentRef;
                    item.lblPaidOn = lblPaidOn;
                    item.lblStatusColor = lblStatusColor;
                    item.lblStatus = lblStatus;
                    //  lstPaymentHistroy.Add(item);
                }
                lstPaymentHistroy = new ObservableCollection<PaymentDt>(objRawData);
                totalRecordCount = objRawData.Count.ToString();
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                if (lstPaymentHistroy.Count() > 0)
                {
                    CollectionView cvPaymentHistory = Myview.FindByName<CollectionView>("GridPaymentHistory");
                    cvPaymentHistory.ItemsSource = null;
                    cvPaymentHistory.ItemsSource = lstPaymentHistroy;
                    cvPaymentHistory.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                }


                if (lstPaymentHistroy == null || lstPaymentHistroy.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }


            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To bind CMS captions
        /// <summary>
		/// To bind CMS captions
		/// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM403");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM403");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                    assignContent();
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To assign CMS Content respect Captions
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
		/// </summary>
        public async void assignContent()
        {
            try
            {

                strTotalCaption = cms.getCaption("strPaymentHistory", objCMS);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblInvoiceNo = dbLayer.getCaption("strInvoiceNo", objCMS);
                lblCustomer = dbLayer.getCaption("strCustomer", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS);
                lblBOL = dbLayer.getCaption("strBillofLading", objCMS);
                lblAmount = dbLayer.getCaption("strAmount", objCMS);
                lblCreatedOn = dbLayer.getCaption("strCreatedOn", objCMS);
                lblValidity = dbLayer.getCaption("strValidity", objCMS);
                lblMOP = dbLayer.getCaption("strMOP", objCMS);
                lblDueDate = dbLayer.getCaption("strDueDate", objCMS);
                lblPaymentRef = dbLayer.getCaption("strPaymentRefNo", objCMS);
                lblPaidOn = dbLayer.getCaption("strPaidOn", objCMS);
                lblStatusColor = dbLayer.getCaption("strStatus", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                ImgPaymentHistory = dbLayer.getCaption("imgpaymentHistory", objCMS);
                ImgSearch = dbLayer.getCaption("imgSearch", objCMS);
                ImgFilter = dbLayer.getCaption("imgFilter", objCMS);
                TxtSearch = dbLayer.getCaption("StrPaymentHistoryPlaceHolder", objCMS);
                LoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                lobjpicMop = dbLayer.getLOV("strMOPLov", objCMS);//20230427
                lobjpicStatus = dbLayer.getLOV("strStatuslov", objCMS);
                ImgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                LblFilters = dbLayer.getCaption("strFilters", objCMS);
                ImgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterlblMOP = dbLayer.getCaption("strMOP", objCMS);
                ImgDownArrow1 = dbLayer.getCaption("imgDownArrow", objCMS);
                BtnApply = dbLayer.getCaption("strApply", objCMS);
                FilterlblStatus = dbLayer.getCaption("strStatus", objCMS);
                ImgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterlblType = dbLayer.getCaption("strType", objCMS);
                ImgDownArrow2 = dbLayer.getCaption("imgDownArrow", objCMS);
                PlaceInvoice = dbLayer.getCaption("strInvoiceNo", objCMS);
                PlaceBillOfLading = dbLayer.getCaption("strBillofLadingNo", objCMS);
                PlaceCustomers = dbLayer.getCaption("strCustomer", objCMS);
                PlacePaymentRefs = dbLayer.getCaption("strPaymentRef", objCMS);
                PlaceFromAmounts = dbLayer.getCaption("strFromAmount", objCMS);
                PlaceToAmounts = dbLayer.getCaption("strToAmount", objCMS);
                LblFromdate1 = dbLayer.getCaption("strFromDate", objCMS);
                LblToDate1 = dbLayer.getCaption("strToDate", objCMS);
                PlaceBillOfLading = dbLayer.getCaption("strBillofLadingNo", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                lobjpicType = dbLayer.getEnum("strTypelov", objCMS);
                LblType = dbLayer.getCaption("strType", objCMS);


                lstFilterMopdata.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterMopdata.Add(new PaymentHistoryFilterDtlist { CmbMop = lstrCaptionALL });
                foreach (var dic in lobjpicMop)
                {
                    lstFilterMopdata.Add(new PaymentHistoryFilterDtlist { CmbMop = dic.Key }); ;
                }

                lstFilterStatusdata.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterStatusdata.Add(new PaymentHistoryFilterDtlist { CmbStatus = lstrCaptionALL });
                foreach (var dic in lobjpicStatus)
                {
                    lstFilterStatusdata.Add(new PaymentHistoryFilterDtlist { CmbStatus = dic.Key }); ;
                }

                //lstFilterTypedata.Clear();
                ////lstFilterTypedata.Add(new PaymentHistoryFilterDtlist { CmbType = lstrCaptionALL });
                //foreach (var dic in lobjpicType)
                //{
                //    lstFilterTypedata.Add(new PaymentHistoryFilterDtlist { CmbType = dic.Key }); ;
                //}
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To get ClickedApply command property
        /// <summary>
        /// To get ClickedApply command property
        /// </summary>

        private async Task ClickedApply()
        {
            try
            {
                PaymetEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                var strSelectedStatus = "";
                var strSelectedMop = "";
                var lstrCategoryCode = "";
                var strInvoiceNo = "";
                var strdBOLNo = "";
                var strCutomer = "";
                var strPaymentRef = "";
                Searchbox = "";
                if (lstFilterStatusdata.Count > 0)
                {
                    foreach (var item in lstFilterStatusdata)
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
                if (lstFilterMopdata.Count > 0)
                {
                    foreach (var item in lstFilterMopdata)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbMop.ToString().Trim().ToUpper() != "ALL")
                            {
                                strSelectedMop += item.CmbMop + ",";
                            }
                        }
                    }
                }
                //if (lstFilterTypedata.Count > 0)
                //{
                //    foreach (var item in lstFilterTypedata)
                //    {
                //        if (item.isChecked == true)
                //        {
                //            if (item.CmbType.ToString().Trim().ToUpper() != "ALL")
                //            {
                //                strSelectedType += item.CmbType + ",";
                //            }
                //        }
                //    }
                //}
                if (TxtInvoiceNo != null)
                {
                    strInvoiceNo = TxtInvoiceNo;
                }
                if (TxtBillOfLadingNo != null)
                {
                    strdBOLNo = TxtBillOfLadingNo;
                }
                if (TxtCustomer != null)
                {
                    strCutomer = TxtCustomer;
                }
                if (TxtPaymentRef != null)
                {
                    strPaymentRef = TxtPaymentRef;
                }
                string strFromAmount = "";
                string strToAmount = "";
                if (TxtFromAmount != null)
                {
                    strFromAmount = TxtFromAmount;
                }

                if (TxtToAmount != null)
                {
                    strToAmount = TxtToAmount;
                }
                if (SelectedPaymentType != null)
                {
                    lstrCategoryCode = SelectedPaymentType.Value;
                }
                if (DateFromdate != null)
                {
                    lstrfromDate = DateFromdate.Value.ToString("yyyy-MM-dd");
                }
                if (DateToDate != null)
                {
                    lstrToDate = DateToDate.Value.ToString("yyyy-MM-dd");
                }
                if (strSelectedStatus.Length > 0) strSelectedStatus = strSelectedStatus.Substring(0, strSelectedStatus.Length - 1);
                if (strSelectedMop.Length > 0) strSelectedMop = strSelectedMop.Substring(0, strSelectedMop.Length - 1);
                // if (lstrCategoryCode. > 0) lstrCategoryCode = lstrCategoryCode.Substring(0, lstrCategoryCode.Length - 1);
                //Application.Current.MainPage?.Navigation.PushAsync(new PaymentHistory("", strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strSelectedType, lstrfromDate, lstrToDate, strFromAmount, strToAmount));
                await PaymentHistroylist("", strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, lstrCategoryCode, lstrfromDate, lstrToDate, strFromAmount, strToAmount);
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;
                PaymetEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Open PdfPINo
        /// </summary>

        private async void Open_PdfPINo(PaymentDt objpayment)
        {
            await Task.Delay(1000);
            string strINO = objpayment.InvoiceNo;
            //https://localhost:44336/AppointBooking/OpenPDFInvoice?fstrPINNo=1589851&fstrProformaInvoiceFlag=N
            //https://localhost:44336/AppointBooking/OpenPDFInvoice?fstrPINNo=CB1365629&fstrProformaInvoiceFlag=PH
            var fstrINo = strINO;
            string strURL = AppSettings.MobWebUrl;
            var pdfUrl = strURL + "/AppointBooking/OpenPDFInvoice?" + "fstrPINNo=" + fstrINo + "&fstrProformaInvoiceFlag=PH";
            openPdf(pdfUrl);
        }
        private async void openPdf(string fstrUrl)
        {

            await Task.Delay(1000);
            await Browser.OpenAsync(fstrUrl, BrowserLaunchMode.SystemPreferred);

        }
    }
}

