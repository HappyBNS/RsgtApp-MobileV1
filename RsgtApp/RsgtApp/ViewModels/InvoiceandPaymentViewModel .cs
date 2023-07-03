using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using static RsgtApp.Models.InvoiceandPaymentModel;
namespace RsgtApp.ViewModels
{
    public class InvoiceandPaymentViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        BLConnect objCon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //public int fintPageNumber = 1;
        //public int fintPageSize = 1000000;
        public int intTotalCount { get; set; }
        public string gblfilter { get; set; }
        public string fstrINNo { get; set; }
        public string fstrProFormaFlag { get; set; }
        public string strNoRecord = "";
        string strServerSlowMsg = "";
        string strbtnReGenerate = "";
        string strCapInvoiceNo = "";
        string lstrFromDate = "";
        string lstrToDate = "";
        public ObservableCollection<InvoiceDt> lstInvoice { get; set; } = new ObservableCollection<InvoiceDt>();
        public List<InvoiceDt> lstInvoiceLocal = new List<InvoiceDt>();
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //btnAnyWhereSearch Button
        public Command gotoAnyWhereSearch { get; set; }
        //FilterClicked Button
        public Command FilterClicked { get; set; }
        //ButtonActionPopup Button 
        public Command ButtonActionPopup { get; set; }
        //btnRegenerateInvoice Button 

        //gotoLoadMore Button 
        public Command gotoLoadMore { get; set; }
        //ButtonClickedApply Button 
        public Command ButtonClickedApply { get; set; }
        //gotoReset Button
        public Command gotoReset { get; set; }
        public Command BtnReset { get; set; }
        //ButtonClickedCancel Button
        public Command ButtonClickedCancel { get; set; }
        private string strTotalCaption = "";
        string lstrCaptionALL = "";
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
        //imgInvoiceIconDark purpose of using Image
        private string imgInvoiceIconDark = "";
        public string ImgInvoiceIconDark
        {
            get { return imgInvoiceIconDark; }
            set
            {
                imgInvoiceIconDark = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgInvoiceIconDark");
            }
        }
        //lblListOfInvoices purpose of using Label
        private string lblListOfInvoices = "";
        public string LblListOfInvoices
        {
            get { return lblListOfInvoices; }
            set
            {
                lblListOfInvoices = value;
                OnPropertyChanged();
                RaisePropertyChange("LblListOfInvoices");
            }
        }
        //imgWallet purpose of using Image
        private DateTime? fromdate = null;
        public DateTime? Fromdate
        {
            get { return fromdate; }
            set
            {
                fromdate = value;
                OnPropertyChanged();
                RaisePropertyChange("Fromdate");
            }
        }
        //imgWallet purpose of using Image
        private DateTime? todate = null;
        public DateTime? Todate
        {
            get { return todate; }
            set
            {
                todate = value;
                OnPropertyChanged();
                RaisePropertyChange("Todate");
            }
        }
        //imgWallet purpose of using Image
        private string imgWallet = "";
        public string ImgWallet
        {
            get { return imgWallet; }
            set
            {
                imgWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgWallet");
            }
        }
        //lblMyWallet purpose of using Label
        private string lblMyWallet = "";
        public string LblMyWallet
        {
            get { return lblMyWallet; }
            set
            {
                lblMyWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMyWallet");
            }
        }
        //lblSar purpose of using Label
        private string lblSar = "";
        public string LblSar
        {
            get { return lblSar; }
            set
            {
                lblSar = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSar");
            }
        }
        //txtSearch purpose of using textbox variable
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
        //imgSearch purpose of using Image
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
        //imgFilter purpose of using Image
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
        //imgWhiteDotsIcon purpose of using Image
        private string imgWhiteDotsIcon = "";
        public string ImgWhiteDotsIcon
        {
            get { return imgWhiteDotsIcon; }
            set
            {
                imgWhiteDotsIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgWhiteDotsIcon");
            }
        }
        //lblStatus purpose of using Label
        private string lblStatus = "";
        public string LblStatus
        {
            get { return lblStatus; }
            set
            {
                lblStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStatus");
            }
        }
        private string statusColor = "";
        public string StatusColor
        {
            get { return statusColor; }
            set
            {
                statusColor = value;
                OnPropertyChanged();
                RaisePropertyChange("StatusColor");
            }
        }
        //lblBillOFLading purpose of using Label
        private string lblBillOFLading = "";
        public string LblBillOFLading
        {
            get { return lblBillOFLading; }
            set
            {
                lblBillOFLading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBillOFLading");
            }
        }
        //lblCustomer purpose of using Label
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
        //lblProformaInvoice purpose of using Label
        private string lblProformaInvoice = "";
        public string LblProformaInvoice
        {
            get { return lblProformaInvoice; }
            set
            {
                lblProformaInvoice = value;
                OnPropertyChanged();
                RaisePropertyChange("LblProformaInvoice");
            }
        }
        //lblInvoiceNo purpose of using Label
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
        //lblAmount purpose of using Label
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
        //lblCreatedOn purpose of using Label
        private string lblCreatedOn = "";
        public string LblCreatedOn
        {
            get { return lblCreatedOn; }
            set
            {
                lblCreatedOn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCreatedOn");
            }
        }
        //CreatedOn purpose of using Label
        private string createdOn = "";
        public string CreatedOn
        {
            get { return createdOn; }
            set
            {
                createdOn = value;
                OnPropertyChanged();
                RaisePropertyChange("CreatedOn");
            }
        }
        //lblDueDate purpose of using Label
        private string lblDueDate = "";
        public string LblDueDate
        {
            get { return lblDueDate; }
            set
            {
                lblDueDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDueDate");
            }
        }
        //DueDate purpose of using Label
        private string dueDate = "";
        public string DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                OnPropertyChanged();
                RaisePropertyChange("DueDate");
            }
        }
        //lblMOP purpose of using Label
        private string lblMOP = "";
        public string LblMOP
        {
            get { return LblMOP; }
            set
            {
                lblMOP = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMOP");
            }
        }
        //lblPaidOn purpose of using Label
        private string lblPaidOn = "";
        public string LblPaidOn
        {
            get { return lblPaidOn; }
            set
            {
                lblPaidOn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPaidOn");
            }
        }
        //lblPaymentRef purpose of using Label
        private string lblPaymentRef = "";
        public string LblPaymentRef
        {
            get { return lblPaymentRef; }
            set
            {
                lblPaymentRef = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPaymentRef");
            }
        }
        //btnRegenerate purpose of using Button
        private string btnRegenerate = "";
        public string BtnRegenerate
        {
            get { return btnRegenerate; }
            set
            {
                btnRegenerate = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnRegenerate");
            }
        }
        //btnLoadMore purpose of using Button
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
        //Filter Page
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
        //lblFilter purpose of using Label
        private string lblFilter = "";
        public string LblFilter
        {
            get { return lblFilter; }
            set
            {
                lblFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFilter");
            }
        }
        //btnApply purpose of using Button
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
        //imgReset purpose of using Image
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
        //Filter Page
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
        //imgDownArrow purpose of using Image
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
        //Filter Page
        private string filterMop = "";
        public string FilterMop
        {
            get { return filterMop; }
            set
            {
                filterMop = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterMop");
            }
        }
        //imgDownArrow2 purpose of using Image
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
        //Filter Page
        private string filterType = "";
        public string FilterType
        {
            get { return filterType; }
            set
            {
                filterType = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterType");
            }
        }
        //imgDownArrow3 purpose of using Image
        private string imgDownArrow3 = "";
        public string ImgDownArrow3
        {
            get { return imgDownArrow3; }
            set
            {
                imgDownArrow3 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow3");
            }
        }
        //txtInvoiceNo purpose of using textbox variable
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
        //txtBolNo purpose of using textbox variable
        private string txtBolNo = "";
        public string TxtBolNo
        {
            get { return txtBolNo; }
            set
            {
                txtBolNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBolNo");
            }
        }
        //txtCustomer2 purpose of using textbox variable
        private string txtCustomer2 = "";
        public string TxtCustomer2
        {
            get { return txtCustomer2; }
            set
            {
                txtCustomer2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCustomer2");
            }
        }
        //txtPymentRef purpose of using textbox variable
        private string txtPymentRef = "";
        public string TxtPymentRef
        {
            get { return txtPymentRef; }
            set
            {
                txtPymentRef = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtPymentRef");
            }
        }
        //txtFromAmount purpose of using textbox variable
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
        //txtToAmount purpose of using textbox variable
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
        //lblFromDate purpose of using Label
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
        //lblToDate purpose of using Label
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
        //enumStatus  combo variable
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
        //enumMop  combo variable
        private string enumMop = "";
        public string EnumMop
        {
            get { return enumMop; }
            set
            {
                enumMop = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumMop");
            }
        }
        //enumType  combo variable
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
        //txtBOLNo purpose of using textbox variable
        private string txtBOLNo = "";
        public string TxtBOLNo
        {
            get { return txtBOLNo; }
            set
            {
                txtBOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOLNo");
            }
        }
        //txtPaymentref purpose of using textbox variable
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
        //txtCustomer purpose of using textbox variable
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
        //txtFromDate purpose of using textbox variable
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
        //txtrDueDate purpose of using textbox variable
        private string txtrDueDate = "";
        public string TxtrDueDate
        {
            get { return txtrDueDate; }
            set
            {
                txtrDueDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtrDueDate");
            }
        }
        //txtToDate purpose of using textbox variable
        private string txtToDate = "";
        public string TxtToDate
        {
            get { return txtToDate; }
            set
            {
                txtToDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtrDueDate");
            }
        }
        //lblSno purpose of using Label
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

        //lblSno purpose of using Label
        private string lblRegenerate = "";
        public string LblRegenerate
        {
            get { return lblRegenerate; }
            set
            {
                lblRegenerate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRegenerate");
            }
        }


        //PlaceInvoiceNo purpose of using Label
        private string placeInvoiceNo = "";
        public string PlaceInvoiceNo
        {
            get { return placeInvoiceNo; }
            set
            {
                placeInvoiceNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceInvoiceNo");
            }
        }
        //PlaceBolNo purpose of using Label
        private string placeBolNo = "";
        public string PlaceBolNo
        {
            get { return placeBolNo; }
            set
            {
                placeBolNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBolNo");
            }
        }
        //PlaceCustomer2 purpose of using Label
        private string placeCustomer2 = "";
        public string PlaceCustomer2
        {
            get { return placeCustomer2; }
            set
            {
                placeCustomer2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceCustomer2");
            }
        }
        //PlacePymentRef purpose of using Label
        private string placePymentRef = "";
        public string PlacePymentRef
        {
            get { return placePymentRef; }
            set
            {
                placePymentRef = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacePymentRef");
            }
        }
        //PlaceFromAmount purpose of using Label
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
        //PlaceToAmount purpose of using Label
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

        //To handle Boolen variable
        bool _isVisibleWallet = false;

        public bool isVisibleWallet
        {
            get { return _isVisibleWallet; }
            set
            {
                _isVisibleWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
            }
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
                RaisePropertyChange("IsBusy");
                gotoAnyWhereSearch.ChangeCanExecute();
                FilterClicked.ChangeCanExecute();
                gotoLoadMore.ChangeCanExecute();
                ButtonClickedApply.ChangeCanExecute();
                gotoReset.ChangeCanExecute();
                ButtonClickedCancel.ChangeCanExecute();
                ButtonActionPopup.ChangeCanExecute();
            }
        }


        public System.Windows.Input.ICommand btnRegenerateInvoice => new Command<InvoiceDt>(RegenerateInvoice);

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
        //To handel  page number
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

        //To handel in getHoldBallance decmal value
        private string getHoldBallance = "0.00";
        public string GetHoldBallance
        {
            get { return getHoldBallance; }
            set
            {
                getHoldBallance = value;
                OnPropertyChanged();
                RaisePropertyChange("GetHoldBallance");
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
        //To handel in getWalletBallance decmal value
        private string getWalletBallance = "0.00";
        public string GetWalletBallance
        {
            get { return getWalletBallance; }
            set
            {
                getWalletBallance = value;
                OnPropertyChanged();
                RaisePropertyChange("GetWalletBallance");
            }
        }
        //To handle Boolen variable
        bool stackInvoicePay = true;
        public bool StackInvoicePay
        {
            get { return stackInvoicePay; }
            set
            {
                stackInvoicePay = value;
                OnPropertyChanged();
                RaisePropertyChange("StackInvoicePay");
            }
        }
        //To handel in lblOnhold lable variable
        private string lblOnhold = "";
        public string lblOnHold
        {
            get { return lblOnhold; }
            set
            {
                lblOnhold = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOnHold");
            }
        }
        private bool isVisibleInvoiceMain = false;
        public bool IsVisibleInvoiceMain
        {
            get { return isVisibleInvoiceMain; }
            set
            {
                isVisibleInvoiceMain = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleInvoiceMain");
            }
        }


        private bool isVisibleInvoiceFilter = false;
        public bool IsVisibleInvoiceFilter
        {
            get { return isVisibleInvoiceFilter; }
            set
            {
                isVisibleInvoiceFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleInvoiceFilter");
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
        //To handle Bool in Expander
        private bool _isExpandedType = false;
        public bool IsExpandedType
        {
            get { return _isExpandedType; }
            set { SetProperty(ref _isExpandedType, value); }
        }
        ContentPage Myview;
        //Collection Object Creation
        public ObservableCollection<InvoicesFilterDtlist> lstFilterMopdata { get; set; } = new ObservableCollection<InvoicesFilterDtlist>();
        public ObservableCollection<InvoicesFilterDtlist> lstFilterStatusdata { get; set; } = new ObservableCollection<InvoicesFilterDtlist>();
        public ObservableCollection<InvoicesFilterDtlist> lstFilterTypedata { get; set; } = new ObservableCollection<InvoicesFilterDtlist>();
        public System.Windows.Input.ICommand TapInvoicePdfCommand => new Command<InvoiceDt>(OpenPdfPINo);
        public System.Windows.Input.ICommand TapInvoiceOpenPdfINo => new Command<InvoiceDt>(OpenPdfINo);
        /// <summary>
        ///  To Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="strsearchbox">search Box value</param>
        /// <param name="strInvoiceNo">Invoice Number value</param>
        /// <param name="strdBOLNo">BOL Number value</param>
        /// <param name="strCutomer">Customer</param>
        /// <param name="strPaymentRef">Payment ref</param>
        /// <param name="strSelectedStatus">Filter selected status value</param>
        /// <param name="strSelectedMop">Filter Selected Method of payment value</param>
        /// <param name="strFromDate">From date</param>
        /// <param name="strToDate">To date</param>
        /// <param name="strFromAmount">From Amount</param>
        /// <param name="strToAmount">To Amount</param>
        /// <param name="strSelectedType"></param>
        /// <param name="strDueDate">Due Date</param>
        public InvoiceandPaymentViewModel(string strsearchbox, string strInvoiceNo, string strdBOLNo, string strCutomer, string strPaymentRef, string strSelectedStatus, string strSelectedMop, string strFromDate, string strToDate, string strFromAmount, string strToAmount, string strSelectedType, string strDueDate, string strFilterflag, ContentPage view)
        {
            try
            {
                Myview = view;
                lstInvoice = new ObservableCollection<InvoiceDt>();
                IsVisibleInvoiceFilter = false;
                IsVisibleInvoiceMain = false;
                if (strFilterflag == "N")
                {
                    IsVisibleInvoiceMain = true;
                    IsVisibleInvoiceFilter = false;
                }
                if (strFilterflag == "Y")
                {
                    IsVisibleInvoiceFilter = true;
                    IsVisibleInvoiceMain = false;
                }
                Task.Run(() => assignCms()).Wait();
                //Analytics track event
                Analytics.TrackEvent("InvoiceandPaymentViewModel");
                searchbox = strsearchbox;
                gotoAnyWhereSearch = new Command(async () => await AnywhereSearch(), () => !IsBusy);
                FilterClicked = new Command(async () => await invoiceClicked(), () => !IsBusy);
                gotoLoadMore = new Command(async () => await InvoiceandPaymentlst(strsearchbox, strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strFromDate, strToDate, strFromAmount, strToAmount, strSelectedType, strDueDate), () => !IsBusy);
                ButtonClickedApply = new Command(async () => await ClickedApply(), () => !IsBusy);
                gotoReset = new Command(async () => await Reset(), () => !IsBusy);
                ButtonClickedCancel = new Command(async () => await ButtonCancel(), () => !IsBusy);
                ButtonActionPopup = new Command(async () => await Button_ActionPopup(), () => !IsBusy);
                BtnReset = new Command(async () => await btnReset(), () => !IsBusy);


                Task.Run(() => InvoiceandPaymentlst(strsearchbox, strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strFromDate, strToDate, strFromAmount, strToAmount, strSelectedType, strDueDate)).Wait();
                if (lstInvoice == null || lstInvoice.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                isVisibleWallet = false;
                if (AppSettings.WalletFlag == "Y")
                {
                    getBallance();
                    isVisibleWallet = true;
                }

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Reset Button Function
        /// </summary>
        /// <returns></returns>
        private async Task Reset()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            // Application.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "", "", "", "", "", "", "", ""));
            await InvoiceandPaymentlst("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "");
            await assignCms();
            assignContent();
            IsExpandedType = false;
            IsExpandedStatus = false;
            IsExpandedMOP = false;
            TxtInvoiceNo = "";
            TxtBolNo = "";
            TxtCustomer2 = "";
            TxtPymentRef = "";
            TxtFromAmount = "";
            TxtToAmount = "";
            fromdate = null;
            Todate = null;
            IsVisibleInvoiceMain = true;
            IsVisibleInvoiceFilter = false;
            StackInvoicePay = true;
            IsBusy = false;
        }
        /// <summary>
        /// Cancel Button Function
        /// </summary>
        /// <returns></returns>
        private async Task ButtonCancel()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            //  Application.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "", "", "", "", "", "", "", ""));
            await InvoiceandPaymentlst("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "");
            IsExpandedType = false;
            IsExpandedStatus = false;
            IsExpandedMOP = false;
            TxtInvoiceNo = "";
            TxtBolNo = "";
            TxtCustomer2 = "";
            TxtPymentRef = "";
            TxtFromAmount = "";
            TxtToAmount = "";
            fromdate = null;
            Todate = null;
            IsVisibleInvoiceMain = true;
            IsVisibleInvoiceFilter = false;
            StackInvoicePay = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Navigate InvoiceandPayment AnyWhere Page
        /// </summary>
        /// <returns></returns>
        private async Task AnywhereSearch()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            //  Application.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment(searchbox, "", "", "", "", "", "", "", "", "", "", "", ""));
            await InvoiceandPaymentlst(Searchbox, "", "", "", "", "", "", "", "", "", "", "", "");
            StackInvoicePay = true;
            IsBusy = false;
        }
        /// <summary>
        ///To Navigate InvoiceandPayment Filter Page  
        /// </summary>
        /// <returns></returns>
        private async Task invoiceClicked()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            IsVisibleInvoiceFilter = true;
            IsVisibleInvoiceMain = false;
            //  Application.Current.MainPage?.Navigation.PushAsync(new Invoicelist_filter());
            StackInvoicePay = true;
            IsBusy = false;
        }

        /// <summary>
        /// To Get the Listview Data
        /// </summary>
        /// <param name="strsearchbox">Search Box</param>
        /// <param name="strInvoiceNo">Invoice Number</param>
        /// <param name="strdBOLNo">BOL Number</param>
        /// <param name="strCutomer">Custmer</param>
        /// <param name="strPaymentRef">Payment Ref</param>
        /// <param name="strSelectedStatus">Filter Selected Status</param>
        /// <param name="strSelectedMop">Filter Selected Method of payment</param>
        /// <param name="strFromDate">from Date</param>
        /// <param name="strToDate">To Date</param>
        /// <param name="strFromAmount">From Amount</param>
        /// <param name="strToAmount">To Amount</param>
        /// <param name="strSelectedType">Filter Selected Type of value</param>
        /// <param name="strDueDate">Due Date</param>
        /// <returns></returns>

        public async Task InvoiceandPaymentlst(string strsearchbox, string strInvoiceNo, string strdBOLNo, string strCutomer, string strPaymentRef, string strSelectedStatus, string strSelectedMop, string strFromDate, string strToDate, string strFromAmount, string strToAmount, string strSelectedType, string strDueDate)
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            try
            {
                var objRawData = new List<InvoiceDt>();
                string gblAnyWhere = "";
                string lstrInvoiceNo = "";
                string lstrBOLNo = "";
                string lstrCustomer = "";
                string lstrPaymentref = "";
                string lstrStatus = "";
                string lstrMop = "";
                string lstrFromDate = "";
                string lstrToDate = "";
                string lstrFromAmount = "";
                string lstrToAmount = "";
                string lstrType = "";
                if (strsearchbox != null) gblAnyWhere = strsearchbox;
                if (strInvoiceNo != null) lstrInvoiceNo = strInvoiceNo;
                if (strdBOLNo != null) lstrBOLNo = strdBOLNo;
                if (strCutomer != null) lstrCustomer = strCutomer;
                if (strPaymentRef != null) lstrPaymentref = strPaymentRef;
                if (strFromDate != null) lstrFromDate = strFromDate;
                if (strToDate != null) lstrToDate = strToDate;
                if (strSelectedStatus != null && (strSelectedStatus != "")) lstrStatus = strSelectedStatus;
                if (strSelectedMop != null) lstrMop = strSelectedMop;
                if (strSelectedType != null) lstrType = strSelectedType;
                if (strFromAmount != null) lstrFromAmount = strFromAmount;
                if (strToAmount != null) lstrToAmount = strToAmount;
                lstInvoice.Clear();
                gblfilter = "";
                gblfilter += "fstrAnywhere:" + gblAnyWhere + ";" + "fstrInvoiceNo:" + lstrInvoiceNo + ";" + "fstrBillofladingno:" + lstrBOLNo + ";" + "fstrCustomer:" + lstrCustomer + ";" + "fstrPaymentref:" + lstrPaymentref + ";" + "fstrStatus:" + lstrStatus + ";" + "fstrMop:" + lstrMop + ";" + "fstrCondFromDate:" + lstrFromDate + ";" + "fstrCondTodate:" + lstrToDate + ";" + "fstrCondFromAmount:" + lstrFromAmount + ";" + "fstrCondToAmount:" + lstrToAmount + ";" + "fstrType:" + lstrType + ";";
                objRawData = objCon.getInvoiceDetails(gblRegisteration.strLoginUser, lfintPageNumber, lfintPageSize, gblfilter);
                totalRecordCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                await Task.Delay(1000);
                foreach (var item in objRawData)
                {

                    bool lboolRegenerate = false;
                    bool lboolCheckBoxVisible = false;

                    //  if((CD_APPBOOKABLE == "PAYABLE")&&(BL_BOLSTATUSCODE == "")||(BL_BOLSTATUSCODE == "IN_UP"))

                    if ((item.InvoiceNo != null) && (item.InvoiceNo != ""))
                    {
                        strInvoiceNo = item.InvoiceNo;
                    }

                    if (item.StatusEng.ToUpper() == "READY TO PAY")
                    {


                        if (item.Customer == item.blinvoiceconsignee)
                        {
                            lboolRegenerate = true;
                            lboolCheckBoxVisible = true;
                        }

                    }
                    var strStatusColor = "";
                    strStatusColor = "#777777"; // unpaid color handled
                    if (item.Status.ToString().ToUpper().Trim() == "PAID")//PAID color handled
                    {
                        strStatusColor = "#5cb85c";
                    }


                    item.lblSno = lblSno;
                    item.lblStatus = lblStatus;
                    item.lblBillOFLading = lblBillOFLading;
                    item.lblCustomer = lblCustomer;
                    item.lblProformaInvoice = lblProformaInvoice;
                    item.lblInvoiceNo = lblInvoiceNo;
                    item.lblAmount = lblAmount;
                    item.lblCreatedOn = lblCreatedOn;
                    item.lblDueDate = lblDueDate;
                    item.lblMOP = lblMOP;
                    item.lblPaidOn = lblPaidOn;
                    item.lblPaymentRef = lblPaymentRef;
                    item.btnboolRegenerate = lboolRegenerate;
                    item.btnReGenerate = LblRegenerate;
                    item.StatusColor = strStatusColor;
                    item.isCheckBoxVisible = lboolCheckBoxVisible;
                    lstInvoice.Add(item);
                }
                CollectionView cvinvoicePayment = Myview.FindByName<CollectionView>("GridInvoicePayment");
                cvinvoicePayment.ItemsSource = null;
                cvinvoicePayment.ItemsSource = lstInvoice;
                cvinvoicePayment.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                if (lstInvoice == null || lstInvoice.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }


            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackInvoicePay = true;
            IsBusy = false;
        }

        /// <summary>
        /// To bind CMS captions
        /// </summary>
        /// <returns></returns>
        public async Task assignCms()
        {
            await Task.Delay(1000);
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM028");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM028");
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
            try
            {

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}

                dbLayer.objInfoitems = objCMS;
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                imgInvoiceIconDark = dbLayer.getCaption("imgInvoice", objCMS);
                lblListOfInvoices = dbLayer.getCaption("strListofInvoices", objCMS);
                strTotalCaption = dbLayer.getCaption("strListofInvoices", objCMS);
                imgWallet = dbLayer.getCaption("imgWallet", objCMS);
                lblMyWallet = dbLayer.getCaption("strMyWallet", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                imgWhiteDotsIcon = dbLayer.getCaption("imgWhite", objCMS);
                lblSar = dbLayer.getCaption("strSAR", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                txtSearch = dbLayer.getCaption("StrInvoicePlaceHolder", objCMS);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                LblRegenerate = dbLayer.getCaption("strReGenerate", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                lblBillOFLading = dbLayer.getCaption("strBillofLading", objCMS);
                lblCustomer = dbLayer.getCaption("strCustomer", objCMS);
                lblProformaInvoice = dbLayer.getCaption("strProformaInvoiceNo", objCMS);
                strCapInvoiceNo = dbLayer.getCaption("strInvoiceNo", objCMS);
                lblAmount = dbLayer.getCaption("strAmount", objCMS);
                lblCreatedOn = dbLayer.getCaption("strCreatedOn", objCMS);
                lblDueDate = dbLayer.getCaption("strDueDate", objCMS);
                lblMOP = dbLayer.getCaption("strMOP", objCMS);
                lblInvoiceNo = dbLayer.getCaption("strInvoiceNo", objCMS);
                lblPaidOn = dbLayer.getCaption("strPaidOn", objCMS);
                lblPaymentRef = dbLayer.getCaption("strPaymentRef", objCMS);
                strbtnReGenerate = dbLayer.getCaption("strReGenerate", objCMS);
                imgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                lblFilter = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterStatus = dbLayer.getCaption("strStatus", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDown", objCMS);
                FilterMop = dbLayer.getCaption("strMOP", objCMS);
                imgDownArrow2 = dbLayer.getCaption("imgDown", objCMS);
                FilterType = dbLayer.getCaption("strType", objCMS);
                imgDownArrow3 = dbLayer.getCaption("imgDown", objCMS);
                PlaceInvoiceNo = dbLayer.getCaption("strInvoiceNo", objCMS);
                placeBolNo = dbLayer.getCaption("strBillofLadingNo", objCMS);
                placeCustomer2 = dbLayer.getCaption("strCustomer", objCMS);
                placePymentRef = dbLayer.getCaption("strPayment", objCMS);
                placeFromAmount = dbLayer.getCaption("strFromAmount", objCMS);
                placeToAmount = dbLayer.getCaption("strToAmount", objCMS);
                lblFromDate = dbLayer.getCaption("strFromDate", objCMS);
                lblToDate = dbLayer.getCaption("strToDate", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                lblOnHold = dbLayer.getCaption("strHold", objCMS);
                Dictionary<string, string> lobjpicMop = dbLayer.getLOV("strMOP", objCMS);
                lstFilterMopdata.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterMopdata.Add(new InvoicesFilterDtlist { CmbMop = lstrCaptionALL });
                foreach (var dic in lobjpicMop)
                {
                    lstFilterMopdata.Add(new InvoicesFilterDtlist { CmbMop = dic.Key });
                }
                Dictionary<string, string> lobjpicStatus = dbLayer.getLOV("strStatus", objCMS);
                lstFilterStatusdata.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterStatusdata.Add(new InvoicesFilterDtlist { CmbStatus = lstrCaptionALL });
                foreach (var dic in lobjpicStatus)
                {
                    if ((dic.Value == "Ready to pay"))
                    {
                        lstFilterStatusdata.Add(new InvoicesFilterDtlist { CmbStatus = dic.Key, isChecked = true });
                    }
                    else
                    {
                        lstFilterStatusdata.Add(new InvoicesFilterDtlist { CmbStatus = dic.Key });
                    }
                }
                Dictionary<string, string> lobjpicType = dbLayer.getLOV("strType", objCMS);
                lstFilterTypedata.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterTypedata.Add(new InvoicesFilterDtlist { CmbType = lstrCaptionALL });
                foreach (var dic in lobjpicType)
                {
                    lstFilterTypedata.Add(new InvoicesFilterDtlist { CmbType = dic.Key });
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Apply Button Function
        /// </summary>
        /// <returns></returns>
        private async Task ClickedApply()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            var strSelectedStatus = "";
            var strSelectedMop = "";
            var strSelectedType = "";
            var strInvoiceNo = "";
            var strdBOLNo = "";
            var strCutomer = "";
            var strPaymentRef = "";
            try
            {
                if (lstFilterStatusdata.Count > 0)
                {
                    foreach (var item in lstFilterStatusdata)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbStatus.ToString().ToUpper().Trim() != "ALL")
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
                            if (item.CmbMop.ToString().ToUpper().Trim() != "ALL")
                            {
                                strSelectedMop += item.CmbMop + ",";
                            }
                        }
                    }
                }
                if (lstFilterTypedata.Count > 0)
                {
                    foreach (var item in lstFilterTypedata)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbType.ToString().ToUpper().Trim() != "ALL")
                            {
                                strSelectedType += item.CmbType + ",";
                            }
                        }
                    }
                }
                if (txtInvoiceNo != null)
                {
                    strInvoiceNo = txtInvoiceNo;
                }
                if (txtBolNo != null)
                {
                    strdBOLNo = txtBolNo;
                }
                if (txtCustomer2 != null)
                {
                    strCutomer = txtCustomer2;
                }
                if (txtPymentRef != null)
                {
                    strPaymentRef = txtPymentRef;
                }
                string strFromDate = "";
                string strToDate = "";
                string strFromAmount = "";
                string strToAmount = "";
                string strDueDate = "";
                if (Fromdate != null)
                {
                    lstrFromDate = fromdate.Value.ToString("yyyy-MM-dd");
                }
                if (Todate != null)
                {
                    lstrToDate = Todate.Value.ToString("yyyy-MM-dd");
                }
                if (txtFromAmount != null)
                {
                    strFromAmount = txtFromAmount;
                }
                if (txtToAmount != null)
                {
                    strToAmount = txtToAmount;
                }
                if (strSelectedStatus.Length > 0) strSelectedStatus = strSelectedStatus.Substring(0, strSelectedStatus.Length - 1);
                if (strSelectedMop.Length > 0) strSelectedMop = strSelectedMop.Substring(0, strSelectedMop.Length - 1);
                if (strSelectedType.Length > 0) strSelectedType = strSelectedType.Substring(0, strSelectedType.Length - 1);

                // App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strFromDate, strToDate, strFromAmount, strToAmount, strSelectedType, strDueDate));
                await InvoiceandPaymentlst("", strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strFromDate, strToDate, strFromAmount, strToAmount, strSelectedType, strDueDate);
                IsVisibleInvoiceMain = true;
                IsVisibleInvoiceFilter = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackInvoicePay = true;
            IsBusy = false;
        }
        /// <summary>
        /// To clicked RegenerateInvoice
        /// </summary>
        /// <param name="fobjInvoiceDt">Invoice list class</param>
        private async void RegenerateInvoice(InvoiceDt fobjInvoiceDt)
        {
            try
            {
                IsBusy = true;
                StackInvoicePay = false;
                await Task.Delay(1000);
                var BLNo = fobjInvoiceDt.BOL;
                var Proformainvoicenumber = fobjInvoiceDt.ProformaInvoice;//20221012
                string lstrInputJson = "";
                string lstrResult = "";


                lstrInputJson = "{\"PA_API\": \"generate Invoice\",\"PA_STATUS\": \"Requested\",\"PA_PARAMETERS\": \"{'Invoice':{'billOfLading':'" + BLNo + "','ID':'" + gblRegisteration.strIdNo + "','Language':'EN','Command':'Generate'}}\"}";
                lstrResult = objWebApi.postWebApi("GenerateInvoice", lstrInputJson);
                string strJson = "{ \"BL_BOLSTATUSCODE\":\"IN_UP\" }";
                string lstrBolNo = BLNo.Replace("/", "^");
                lstrResult = objWebApi.putWebApi("UpdateBOLStatus", strJson, BLNo);

                strJson = "{ \"BL_BOLSTATUSCODE\":\"\",\"BL_IHINVOICENUMBER\":\"\",\"BL_IHPROFORMAINVOICENUMBER\":\"\",\"BL_IHSTATUS\":\"Cancelled\" }";
                lstrResult = objWebApi.putWebApi("UpdateBilloflading", strJson, Proformainvoicenumber);


                if (lstrResult.ToUpper().ToString().Trim() == "TRUE")
                {
                    objWebApi.postWebApi("PostSendEmail", gblTrackRequests.GenerateInvoiceeMailData());
                    await App.Current.MainPage?.Navigation.PushAsync(new Generateinvoice_popup());

                }
                StackInvoicePay = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To open PPDF
        /// </summary>
        /// <param name="fobjInvdt"></param>
        private async void OpenPdfPINo(InvoiceDt fobjInvdt)
        {
            await Task.Delay(1000);
            var fstrProformaINo = fobjInvdt.ProformaInvoice;
            string strURL = AppSettings.MobWebUrl;
            var pdfUrl = strURL + "/AppointBooking/OpenPDFInvoice?" + "fstrPINNo=" + fstrProformaINo + "&fstrProformaInvoiceFlag=Y";
            openPdf(pdfUrl);
            // Navigation.PushAsync(new Invoice(fstrProformaINo, "Y"));
        }
        /// <summary>
        /// To open IPDF
        /// </summary>
        /// <param name="fobjInvdt"></param>
        private async void OpenPdfINo(InvoiceDt fobjInvdt)
        {
            await Task.Delay(1000);
            //https://localhost:44336/AppointBooking/OpenPDFInvoice?fstrPINNo=1589851&fstrProformaInvoiceFlag=N
            var fstrINo = fobjInvdt.InvoiceNo;
            string strURL = AppSettings.MobWebUrl;
            var pdfUrl = strURL + "/AppointBooking/OpenPDFInvoice?" + "fstrPINNo=" + fstrINo + "&fstrProformaInvoiceFlag=PH";
            openPdf(pdfUrl);
        }
        /// <summary>
        /// opening url using PDF
        /// </summary>
        /// <param name="fstrUrl"></param>
        private async void openPdf(string fstrUrl)
        {
            await Task.Delay(1000);
            // Device.OpenUri(new Uri("http://example.com"))
            await Browser.OpenAsync(fstrUrl, BrowserLaunchMode.SystemPreferred);
        }
        /// <summary>
        /// To click Actionpopup
        /// </summary>
        /// <returns></returns>
        private async Task Button_ActionPopup()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            gblBol.lstInvoice = new List<InvoiceDt>(lstInvoice);
            await App.Current.MainPage?.Navigation.PushAsync(new Action_popup());
            StackInvoicePay = true;
            IsBusy = false;
        }
        /// <summary>
        /// To handel in get wallet balance
        /// </summary>
        /// <returns></returns>
        private async void getBallance()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            string fstrCustomerId = gblRegisteration.strLoginUserLinkcode;
            string fstrCustomerType = gblRegisteration.strLoginCustomerType;
            string lstrWalletBalance = objBl.getbalance(fstrCustomerId, fstrCustomerType);
            string lstrHoldBalance = objBl.getHOLDbalance(fstrCustomerId);
            GetWalletBallance = lblSar + " " + Decimal.Parse(lstrWalletBalance).ToString("#,##0.00");
            GetHoldBallance = lblSar + " " + Decimal.Parse(lstrHoldBalance).ToString("#,##0.00");
            StackInvoicePay = true;
            IsBusy = false;


        }
        /// <summary>
        /// to handel in page Reset event
        /// </summary>
        /// <returns></returns>
        private async Task btnReset()
        {
            IsBusy = true;
            StackInvoicePay = false;
            await Task.Delay(1000);
            getBallance();
            StackInvoicePay = true;
            IsBusy = false;

        }
    }
}