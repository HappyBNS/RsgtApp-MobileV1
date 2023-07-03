using Microsoft.AppCenter.Analytics;
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
using static RsgtApp.Models.BOLModel;

namespace RsgtApp.ViewModels
{
    public class BOLViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
     
        private List<clsListofbillofladings> lstBOL = new List<clsListofbillofladings>();
        //To create Business layer Object
        BLConnect objCon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        string strBaynanNo = gblBayan.strgblBaynanNo;

        public List<clsListofbayandetails> lstBOLHeader { get; set; }
        public ObservableCollection<clsListofbillofladings> objDataSource { get; }
        public ObservableCollection<BOLDt> lstBolLocal { get; }
        public ObservableCollection<BOLDt> lstBolLocalExpander { get; }
        private string strLanguage = App.gblLanguage;
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        public int fintPageNumber = 1;
        public int fintPageSize = 10000;
        public int intTotalCount { get; set; }
        string lstrCaptionALL = "";
        //SearchAny Button Command
        public Command SearchAny { get; set; }
        //Filter_Clicked Button Command
        public Command Filter_Clicked { get; set; }
        //Container_list Button Command
        public Command Button_ClickedApply { get; set; }
        //gotoReset Button Command for Fliter
        public Command gotoReset { get; set; }
        //Button_ClickedCancel Button Command for Fliter
        public Command Button_ClickedCancel { get; set; }
        //gotoLoadMore Button Command
        public Command gotoLoadMore { get; set; }
        public string strSelectedBayanNo { get; set; }
        public string yardtotal { get; set; }
        public string AnywhereAll { get; set; }
        public string deptotal { get; set; }
        //To Declare Count Variable
        //private int totalRecordCount = 0;
        private string strtotalRecordCount = "";   
        public string TotalRecordCount
        {
            get { return strtotalRecordCount; }
        }
        //accountSettingsActivityIndicator purpose of using indicator varaiable
        bool accountSettingsActivityIndicator = false;
        public bool AccountSettingsActivityIndicator
        {
            get { return accountSettingsActivityIndicator; }
            set
            {
                accountSettingsActivityIndicator = value;
                OnPropertyChanged();
                RaisePropertyChange("AccountSettingsActivityIndicator");
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
        //ImgDownArrow2 purpose of using image varaiable
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
        //ImgCommodity purpose of using image varaiable
        private string imgCommodity = "";
        public string ImgCommodity
        {
            get { return imgCommodity; }
            set
            {
                imgCommodity = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCommodity");
            }
        }
        //ImgContainer purpose of using image varaiable
        private string imgContainer = "";
        public string ImgContainer
        {
            get { return imgContainer; }
            set
            {
                imgContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgContainer");
            }
        }
        //LblInYard purpose of using Label varaiable
        private string lblInYard = "";
        public string LblInYard
        {
            get { return lblInYard; }
            set
            {
                lblInYard = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInYard");
            }
        }
        //LblDeparted purpose of using Label varaiable
        private string lblDeparted = "";
        public string LblDeparted
        {
            get { return lblDeparted; }
            set
            {
                lblDeparted = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDeparted");
            }
        }
        //Expander purpose of using Boolean varaiable
        private bool expander = false;
        public bool Expander
        {
            get { return expander; }
            set
            {
                expander = value;
                OnPropertyChanged();
                RaisePropertyChange("Expander");
            }
        }
        //Lblchkmessage purpose of using checkbox varaiable
        private string lblchkmessage = "";
        public string Lblchkmessage
        {
            get { return lblchkmessage; }
            set
            {
                lblchkmessage = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblchkmessage");
            }
        }
        //lblok purpose of using checkbox varaiable
        private string lblok = "";
        public string Lblok
        {
            get { return lblok; }
            set
            {
                lblok = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblok");
            }
        }
        //LchkBolNo purpose of using checkbox varaiable
        private string lchkBolNo = "";
        public string LchkBolNo
        {
            get { return lchkBolNo; }
            set
            {
                lchkBolNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LchkBolNo");
            }
        }
        //Billoflading purpose of using Label varaiable
        private string billoflading = "";
        public string Billoflading
        {
            get { return billoflading; }
            set
            {
                billoflading = value;
                OnPropertyChanged();
                RaisePropertyChange("Billoflading");
            }
        }


        private ObservableCollection<BOLDt> _lstResultBol { get; set; }
        public ObservableCollection<BOLDt> lstResultBol
        {
            get { return _lstResultBol; }
            set
            {
                if (_lstResultBol == value)
                    return;
                _lstResultBol = value;
                OnPropertyChanged();
                RaisePropertyChange("lstResultBol");
            }
        }

        public string strServerSlowMsg = "";
        public string strNoRecord = "";
        private string strTotalCaption = "";
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
        //Two way Binding Property created
        //enumconsignee For Combovariable
        private string enumconsignee = "";
        public string Enumconsignee
        {
            get { return enumconsignee; }
            set
            {
                enumconsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("Enumconsignee");
            }
        }
        //EnumVessel For Combovariable
        private string enumVessel = "";
        public string EnumVessel
        {
            get { return enumVessel; }
            set
            {
                enumVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumVessel");
            }
        }
        //EnumCarriar For Combovariable
        private string enumCarriar = "";
        public string EnumCarriar
        {
            get { return enumCarriar; }
            set
            {
                enumCarriar = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumCarriar");
            }
        }
        //Enumstatus For Combovariable
        private string enumstatus = "";
        public string Enumstatus
        {
            get { return enumstatus; }
            set
            {
                enumstatus = value;
                OnPropertyChanged();
                RaisePropertyChange("Enumstatus");
            }
        }
        //To Handle Indicator
        private bool stackBOLFt = true;
        public bool StackBOLFt
        {
            get { return stackBOLFt; }
            set
            {
                stackBOLFt = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBOLFt");
            }
        }
        //To Handle Indicator
        private bool stackBOL = true;
        public bool StackBOL
        {
            get { return stackBOL; }
            set
            {
                stackBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBOL");
            }
        }
        //LblListofBOL purpose of using Label varaiable
        private string lblListofBOL = "";
        public string LblListofBOL
        {
            get { return lblListofBOL; }
            set
            {
                lblListofBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("LblListofBOL");
            }
        }
        //LblBayanNo purpose of using Label varaiable
        private string lblBayanNo = "";
        public string LblBayanNo
        {
            get { return lblBayanNo; }
            set
            {
                lblBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBayanNo");
            }
        }
        //LblValBayanNo purpose of using Label varaiable
        private string lblValBayanNo = "";
        public string LblValBayanNo
        {
            get { return lblValBayanNo; }
            set
            {
                lblValBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValBayanNo");
            }
        }
        //ImgDownArrow purpose of using Image varaiable
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
        //LblShippingLine purpose of using Label varaiable
        private string lblShippingLine = "";
        public string LblShippingLine
        {
            get { return lblShippingLine; }
            set
            {
                lblShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShippingLine");
            }
        }
        //ImgHapag purpose of using Image varaiable
        private string imgHapag = "";
        public string ImgHapag
        {
            get { return imgHapag; }
            set
            {
                imgHapag = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgHapag");
            }
        }
        //LblValShippingLineid purpose of using Label varaiable
        private string lblValShippingLineid = "";
        public string LblValShippingLineid
        {
            get { return lblValShippingLineid; }
            set
            {
                lblValShippingLineid = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValShippingLineid");
            }
        }
        //LblShipper purpose of using Label varaiable
        private string lblShipper = "";
        public string LblShipper
        {
            get { return lblShipper; }
            set
            {
                lblShipper = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShipper");
            }
        }
        //LblValShipper purpose of using Label varaiable
        private string lblValShipper = "";
        public string LblValShipper
        {
            get { return lblValShipper; }
            set
            {
                lblValShipper = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValShipper");
            }
        }
        //LblVesselVisit purpose of using Label varaiable
        private string lblVesselVisit = "";
        public string LblVesselVisit
        {
            get { return lblVesselVisit; }
            set
            {
                lblVesselVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVesselVisit");
            }
        }
        //LblValVesselVisitId purpose of using Label varaiable
        private string lblValVesselVisitId = "";
        public string LblValVesselVisitId
        {
            get { return lblValVesselVisitId; }
            set
            {
                lblValVesselVisitId = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValVesselVisitId");
            }
        }
        //LblBlCategory purpose of using Label varaiable
        private string lblBlCategory = "";
        public string LblBlCategory
        {
            get { return lblBlCategory; }
            set
            {
                lblBlCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBlCategory");
            }
        }
        //LblValBlCategory purpose of using Label varaiable
        private string lblValBlCategory = "";
        public string LblValBlCategory
        {
            get { return lblValBlCategory; }
            set
            {
                lblValBlCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValBlCategory");
            }
        }
        //LblPol purpose of using Label varaiable
        private string lblPol = "";
        public string LblPol
        {
            get { return lblPol; }
            set
            {
                lblPol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPol");
            }
        }
        //LblValPol purpose of using Label varaiable
        private string lblValPol = "";
        public string LblValPol
        {
            get { return lblValPol; }
            set
            {
                lblValPol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValPol");
            }
        }
        //LblPod purpose of using Label varaiable
        private string lblPod = "";
        public string LblPod
        {
            get { return lblPod; }
            set
            {
                lblPod = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPod");
            }
        }
        //LblValPod purpose of using Label varaiable
        private string lblValPod = "";
        public string LblValPod
        {
            get { return lblValPod; }
            set
            {
                lblValPod = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValPod");
            }
        }
        //TxtSearch purpose of using Textbox varaiable
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
        //ImgSearch purpose of using Image varaiable
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
        //ImgFilter purpose of using Image varaiable
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
        //Imgc purpose of using Image varaiable
        private string imgc = "";
        public string Imgc
        {
            get { return imgc; }
            set
            {
                imgc = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgc");
            }
        }
        //LblConsignee purpose of using Label varaiable
        private string lblConsignee = "";
        public string LblConsignee
        {
            get { return lblConsignee; }
            set
            {
                lblConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("LblConsignee");
            }
        }
        //LblCapListofBOL purpose of using Label varaiable
        private string lblCapListofBOL = "";
        public string LblCapListofBOL
        {
            get { return lblCapListofBOL; }
            set
            {
                lblCapListofBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCapListofBOL");
            }
        }
        //Searchbox purpose of using Textbox varaiable
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
        //BtnMoreDetails purpose of using Button varaiable
        private string btnMoreDetails = "";
        public string BtnMoreDetails
        {
            get { return btnMoreDetails; }
            set
            {
                btnMoreDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnMoreDetails");
            }
        }
        //BtnLoadMore purpose of using Button varaiable
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

        //PlaceSearch purpose of using Placeholder varaiable
        private string placeSearch = "";
        public string PlaceSearch
        {
            get { return placeSearch; }
            set
            {
                placeSearch = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceSearch");
            }
        }
        //ImgFilterBlue purpose of using Image varaiable
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
        //LblFilters purpose of using Label varaiable
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
        //BtnApply purpose of using Button varaiable
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
        //ImgRest purpose of using Image varaiable
        private string imgRest = "";
        public string ImgRest
        {
            get { return imgRest; }
            set
            {
                imgRest = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRest");
            }
        }
        //ImgDownArrow1 purpose of using Image varaiable
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
        //LblVessel purpose of using Label varaiable
        private string lblVessel = "";
        public string LblVessel
        {
            get { return lblVessel; }
            set
            {
                lblVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVessel");
            }
        }
        //LblCarrier purpose of using Label varaiable
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
        //ImgDownArrow3 purpose of using Image varaiable
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
        //LblStatus purpose of using Label varaiable
        private string lblStatus = "";
        public string LblStatus
        {
            get { return lblStatus; }
            set
            {
                lblStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("LblStatus");
            }
        }
        //ImgDownArrow4 purpose of using Image varaiable
        private string imgDownArrow4 = "";
        public string ImgDownArrow4
        {
            get { return imgDownArrow4; }
            set
            {
                imgDownArrow4 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow4");
            }
        }
        //LblAction purpose of using Label varaiable
        private string lblAction = "";
        public string LblAction
        {
            get { return lblAction; }
            set
            {
                lblAction = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAction");
            }
        }
        //ImgDownArrow5 purpose of using Image varaiable
        private string imgDownArrow5 = "";
        public string ImgDownArrow5
        {
            get { return imgDownArrow5; }
            set
            {
                imgDownArrow5 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow5");
            }
        }
        //LblValConsignee purpose of using Label varaiable
        private string lblValConsignee = "";
        public string LblValConsignee
        {
            get { return lblValConsignee; }
            set
            {
                lblValConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValConsignee");
            }
        }
        //lblArrived purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblarrived = "";
        public string lblArrived
        {
            get { return lblarrived; }
            set
            {
                lblarrived = value;
                OnPropertyChanged();
                RaisePropertyChange("lblArrived");
            }
        }
        //lblLoaded purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblloaded = "";
        public string lblLoaded
        {
            get { return lblloaded; }
            set
            {
                lblloaded = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLoaded");
            }
        }
        //lblImp purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblimp = "";
        public string lblImp
        {
            get { return lblimp; }
            set
            {
                lblimp = value;
                OnPropertyChanged();
                RaisePropertyChange("lblImp");
            }
        }
        //lblExp purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblexp = "";
        public string lblExp
        {
            get { return lblexp; }
            set
            {
                lblexp = value;
                OnPropertyChanged();
                RaisePropertyChange("lblExp");
            }
        }
        //To Handle Boolean Variable
        private bool btnEnableGI = false;
        public bool BtnEnableGI
        {
            get { return btnEnableGI; }
            set
            {
                btnEnableGI = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnEnableGI");
            }
        }
        //To Handle Boolean Variable
        private bool isBusy = false;
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
        //To Handle Boolean Variable
        private bool isvisibleExport = false; //12-01-2023-sanduru
        public bool isVisibleExport
        {
            get { return isvisibleExport; }
            set
            {
                isvisibleExport = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleExport");
            }
        }
        //To Handle Boolean Variable
        private bool isvisibleImport = false; //12-01-2023-sanduru
        public bool isVisibleImport
        {
            get { return isvisibleImport; }
            set
            {
                isvisibleImport = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleImport");
            }
        }
        List<clsconsigneefilter> lstConsignee = new List<clsconsigneefilter>();
        List<clsCarrierfilter> lstCarrier = new List<clsCarrierfilter>();
        List<clsVesselfilter> lstVessel = new List<clsVesselfilter>();
        public System.Windows.Input.ICommand Containerlist => new Command<BOLDt>(ContainerClick);
        public System.Windows.Input.ICommand ButtonGenerateInvoice => new Command<BOLDt>(GenerateInvoice);
        public System.Windows.Input.ICommand ButtonPayInvoice => new Command<BOLDt>(PayInvoice);
        public System.Windows.Input.ICommand ButtonBookunAppoinment => new Command<BOLDt>(BookunAppoinment);
        public System.Windows.Input.ICommand HoldgoodClicked => new Command<BOLDt>(Holdgood_Clicked);
        public System.Windows.Input.ICommand CommodityPopup => new Command<BOLDt>(OnTappedCommlist);
        public System.Windows.Input.ICommand BOLphotorequest => new Command<BOLDt>(BOLRequest);
        string strFilterFlag = "";
        public ObservableCollection<BOLFilterDtlist> lstBLFilterConsigneeData { get; set; } = new ObservableCollection<BOLFilterDtlist>();
        public ObservableCollection<BOLFilterDtlist> lstBLFilterVesselData { get; set; } = new ObservableCollection<BOLFilterDtlist>();
        public ObservableCollection<BOLFilterDtlist> lstBLFilterCarrierData { get; set; } = new ObservableCollection<BOLFilterDtlist>();
        public ObservableCollection<BOLFilterDtlist> lstBLFilterStatusData { get; set; } = new ObservableCollection<BOLFilterDtlist>();
        Dictionary<string, string> lobjpicStatus = new Dictionary<string, string>();
        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strBaynanNo"></param>
        /// <param name="strselectedConsignee"></param>
        /// <param name="strselectedVessel"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strselectedStatus"></param>
        /// <param name="fstrFilterFlag"></param>
        public BOLViewModel(string strSearchbox, string strBaynanNo, string strselectedConsignee, string strselectedVessel, string strselectedCarrier, string strselectedStatus, string fstrFilterFlag)
        {
            try
            {
               // Refresh();
                lstResultBol = new ObservableCollection<BOLDt>();
                lstBLFilterStatusData = new ObservableCollection<BOLFilterDtlist>();
                strTotalCaption = "";
                Analytics.TrackEvent("BOLViewModel");

                //Begin-Call Caption Function-Changed 20230322
                Task.Run(() => assignCms()).Wait();

                searchbox = strSearchbox;
                SearchAny = new Command(async () => await AnysearchBOL(strBaynanNo), () => !IsBusy);
                gotoLoadMore = new Command(async () => await BOLlist(strSearchbox, strBaynanNo, strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus), () => !IsBusy);
                Filter_Clicked = new Command(async () => await BOLfilter(), () => !IsBusy);
                Button_ClickedApply = new Command(async () => await ClickedApply(), () => !IsBusy);
                gotoReset = new Command(async () => await clear(), () => !IsBusy);
                Button_ClickedCancel = new Command(async () => await clear(), () => !IsBusy);

                strFilterFlag = fstrFilterFlag;
                if (fstrFilterFlag == "Y")
                {
                    Task.Run(() => ConsigneeFilterData()).Wait();
                    Task.Run(() => CarrierFilterData()).Wait();
                    Task.Run(() => VesselFilterData()).Wait();
                }
                else
                {
                    Task.Run(() => BolHeaderData(strBaynanNo)).Wait();
                    Task.Run(() => BOLlist(strSearchbox, strBaynanNo, strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus)).Wait();
                }
                if (fstrFilterFlag != "Y")
                {
                    if (lstResultBol == null || lstResultBol.Count == 0)
                    {
                        App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                    }
                }
            
                //End-Caption Function
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// To Refresh Function
        /// </summary>
        /// <returns></returns>
        private async Task Refresh()
        {
            IsBusy = true;
            StackBOL = false;
            await Task.Delay(1000);
            //if (gblTrackRequests.strWebInvoiceFlag == "Y")
            //{
            //    App.Current.MainPage?.Navigation.PushAsync(new BOL("", gblBayan.strgblBaynanNo, "", "", "", ""));
            //    gblTrackRequests.strWebInvoiceFlag = "N";
            //}

            StackBOL = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get Cleared Function
        /// </summary>
        /// <returns></returns>
        public async Task clear()
        {
            IsBusy = true;
            StackBOL = false;
            await Task.Delay(1000);
            // await Shell.Current.GoToAsync("..");
            await App.Current.MainPage?.Navigation.PushAsync(new BOL("", gblBayan.strgblBaynanNo, "", "", "", ""));
            StackBOL = true;
            IsBusy = false;

        }
        /// <summary>
        /// To get Container Clicked Function
        /// </summary>
        /// <param name="fobjBol"></param>
        public async void ContainerClick(BOLDt fobjBol)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                gblBol.strgblBolNo = fobjBol.Billoflading;
                Application.Current.MainPage?.Navigation.PushAsync(new Containerlist("", fobjBol.Billoflading, "", "", "", "", "", "", "","N"));
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to Filter Function
        /// </summary>
        /// <returns></returns>
        private async Task BOLfilter()
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new Views.BOLFilter());
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to Anywhere Search Function
        /// </summary>
        /// <param name="strBaynanNo"></param>
        /// <returns></returns>
        public async Task AnysearchBOL(string strBaynanNo)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new Views.BOL(searchbox, strBaynanNo, "", "", "", ""));
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }       
        /// <summary>
        /// To Get BOL List
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strBaynanNo"></param>
        /// <param name="strselectedConsignee"></param>
        /// <param name="strselectedVessel"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strselectedStatus"></param>
        /// <returns></returns>
        public async Task BOLlist(string strSearchbox, string strBaynanNo, string strselectedConsignee, string strselectedVessel, string strselectedCarrier, string strselectedStatus)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                string fstrFilterData = "";
                string fstrBayanNo = "";
                string lstrAnyWhere = "";
                string lstrBL_CONSIGNEEDESC1 = "";
                string lstrBL_VESSELNAME1 = "";
                string lstrBL_SHIPPINGLINEID = "";
                string lstrBL_BOLStatus = "";
                string strbtnCaption = "";
               
                bool blButactioncaptionGI = false;
                bool blButactioncaptionGIUP = false;
                bool blButactioncaptionNE = false;
                bool blChk = false;
                bool blButactioncaptionPI = false;
                bool blButactioncaptionPIUP = false;
                bool blButactioncaptionBuApp = false;
                if (strSearchbox != null) lstrAnyWhere = strSearchbox;
                if (strselectedConsignee != null) lstrBL_CONSIGNEEDESC1 = strselectedConsignee;
                if (strselectedVessel != null) lstrBL_VESSELNAME1 = strselectedVessel;
                if (strselectedCarrier != null) lstrBL_SHIPPINGLINEID = strselectedCarrier;
                if (strselectedStatus != null) lstrBL_BOLStatus = strselectedStatus;
                if (strBaynanNo != null) fstrBayanNo = strBaynanNo;
                var objRawData = new List<BOLDt>();
                fstrFilterData += "BD_BAYANNUMBER:" + fstrBayanNo + ";" + "fstrAnyWhere:" + lstrAnyWhere + ";" + "fstrBL_CONSIGNEEDESC1:" + lstrBL_CONSIGNEEDESC1 + ";" + "fstrBL_VESSELNAME1:" + lstrBL_VESSELNAME1 + ";" + "fstrBL_SHIPPINGLINEID:" + lstrBL_SHIPPINGLINEID + ";" + "fstrBL_BOLStatus:" + lstrBL_BOLStatus + ";";
                objRawData = objCon.getBillofLading(gblRegisteration.strLoginUser, fintPageSize, fintPageNumber, fstrFilterData);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                intTotalCount = objRawData.Count;
                strtotalRecordCount = strTotalCaption + " (" + intTotalCount + ")";
                string IH_INVOICESTATUS = "UnPaid";

                lstResultBol.Clear(); //20230322

                foreach (var item in objRawData)
                {
                    strbtnCaption = "Not Eligible";
                    blButactioncaptionGI = false;
                    blButactioncaptionGIUP = false;
                    blButactioncaptionPI = false;
                    blButactioncaptionPIUP = false;
                    blButactioncaptionBuApp = false;
                    blButactioncaptionNE = false;
                    //02022023
                    item.ihDisplayInVoiceNo = item.Proformainvoicenumber;
                    if (item.ihmop == "Wallet")
                    {
                        if (item.ihfasahstatus == "Paid")
                        {
                            IH_INVOICESTATUS = "Paid";
                            item.ihDisplayInVoiceNo = item.Invoicestatusinfo;
                        }
                    }
                    else
                    {
                        if (item.ihstatus == "FINAL")
                        {
                            IH_INVOICESTATUS = "Paid";
                            item.ihDisplayInVoiceNo = item.Invoicestatusinfo;
                        }

                    }

                    if (item.ihstatus == "FINAL") IH_INVOICESTATUS = "Paid";
                    if (item.BOLStatuscode == null) item.BOLStatuscode = "";
                    if ((item.BOLAction == "INVOICEABLE") && (item.BOLStatuscode == ""))
                    {
                        strbtnCaption = dbLayer.getCaption("strGenerateInvoice", objCMS);
                        blButactioncaptionGI = true;
                        blChk = true; //13-03-2023
                    }
                    if ((item.BOLAction == "INVOICEABLE") && (item.BOLStatuscode == "IN_UP"))
                    {
                        blChk = false;
                        strbtnCaption = dbLayer.getCaption("strGenerateInvoice", objCMS);
                        strbtnCaption += " - " + dbLayer.getCaption("strUnderprocess", objCMS);
                        blButactioncaptionGIUP = true;
                        
                    }
                    if ((item.BOLAction == "PAYABLE") && (item.BOLStatuscode == "") || (item.BOLAction == "PAYABLE") && (item.BOLStatuscode == "IN_UP"))
                    {
                        strbtnCaption = dbLayer.getCaption("strPayInvoice", objCMS);
                        blChk = true; //13-03-2023

                        blButactioncaptionPI = true;
                    }
                    if ((item.BOLAction == "PAYABLE") && (item.BOLStatuscode == "PM_UP") || (item.BOLAction == "INVOICEABLE") && (item.BOLStatuscode == "PM_UP"))
                    {
                        blChk = false;
                        strbtnCaption = dbLayer.getCaption("strPayInvoice", objCMS);
                        strbtnCaption += " - " + dbLayer.getCaption("strUnderprocess", objCMS);
                       
                        blButactioncaptionPIUP = true;
                    }
                    if (item.BOLAction == "NOT-ELIGIBLE")
                    {
                        blChk = false;
                        strbtnCaption = "";
                       
                        blButactioncaptionNE = false;
                    }
                    if (item.BOLAction == "APPOINTMENT")
                    {
                        strbtnCaption = dbLayer.getCaption("strBookanAppointment", objCMS);
                        blChk = true; //13-03-2023

                        blButactioncaptionBuApp = true;
                    }
                    string strAppoint = dbLayer.getCaption("strAppoint", objCMS);
                    string strBOLStatus = dbLayer.getCaption("strBOLStatus", objCMS);
                    string strDeparted = dbLayer.getCaption("strDeparted", objCMS);
                    string strDisc = dbLayer.getCaption("strDisc", objCMS);
                    string strHold = dbLayer.getCaption("strHold", objCMS);
                    string strInsp = dbLayer.getCaption("strInsp", objCMS);
                    string strInYard = dbLayer.getCaption("strInYard", objCMS);
                    string strProformaInvoice = dbLayer.getCaption("strProformaInvoice", objCMS);
                    string strPleaseClickTheCheckbox = dbLayer.getCaption("strPleaseClickTheCheckbox", objCMS);
                    //12-01-2023-Sanduru
                    string strloaded = dbLayer.getCaption("strLoadeddash", objCMS);
                    string strgated = dbLayer.getCaption("strGatedIn", objCMS);
                    string lstrCommodity = "";
                    if (item.Commodity.Length > 22)
                    {
                        lstrCommodity = item.Commodity.Substring(0, 22);
                    }
                    else
                    {
                        lstrCommodity = item.Commodity;
                    }
                    item.btnMoreDetails = btnMoreDetails;
                    item.imgDownArrow2 = imgDownArrow2;
                    item.imgCommodity = imgCommodity;
                    item.imgContainer = imgContainer;
                    item.lblInYard = lblInYard;
                    item.lblDeparted = lblDeparted;
                    item.lblArrived = lblArrived; //12-01-2023-Sanduru
                    item.lblLoaded = lblLoaded; //12-01-2023-Sanduru
                    item.lblchkmessage = lblchkmessage;
                    item.blchkBolNo = blChk;
                    item.blchkBolNo = blChk;
                    item.Commodity = lstrCommodity;
                    item.Loadingicon = "loading_icon.png";
                    item.Loadingstatusicon = "process_icon.png";
                    item.Loadingstatusinfo = strDisc;
                    item.Inspectionstatusicon = "Alert_icon.png";
                    item.Inspectionstatusinfo = strInsp;
                    item.Holdstatusinfo = strHold;
                    item.Invoiceicon = "money_icon.png";
                    item.Invoicestatusicon = "tick_icon.png";
                    item.Invoiceinfo = IH_INVOICESTATUS;
                    item.Appointmenticon = "appointment_icon.png";
                    item.Appointmentstatusicon = "";
                    item.Appointmentstatusinfo = strAppoint;
                    item.Departedicon = "gate_icon.png";
                    item.Departedstatusicon = "";
                    item.Departedstatusinfo = strDeparted;
                    //12-01-2023-Sanduru
                    item.Gatedstatusicon = "";
                    item.Gatedstatusinfo = strgated;
                    item.Loadedstatusicon = "";
                    item.Loadedstatusinfo = strloaded;
                    item.Butactioncaption = strbtnCaption;
                    item.Butaction = "Button_GenerateInvoice";
                    item.attchdinvoice = "http://eportalbeta.cielobot.com/rsgt_eportal5/Modified/pdf/invoice.pdf";
                    item.BtnactioncaptionGI = blButactioncaptionGI;
                    item.BtnactioncaptionGIUP = blButactioncaptionGIUP;
                    item.BtnactioncaptionPI = blButactioncaptionPI;
                    item.BtnactioncaptionPIUP = blButactioncaptionPIUP;
                    item.BtnactioncaptionBuApp = blButactioncaptionBuApp;
                    item.BtnactioncaptionNE = blButactioncaptionNE;
                    item.BtnEnableGI = blButactioncaptionGI;
                    item.BtnEnablePI = blButactioncaptionPI;
                    item.BtnEnableBuApp = blButactioncaptionBuApp;
                    //12-01-2023-Sanduru
                    item.isVisibleExport = false;
                    item.isVisibleImport = true;
                    item.chkBolNo = false;
                    if (LblValBlCategory == "EXPRT")
                    {
                        item.isVisibleExport = true;
                        item.isVisibleImport = false;
                    }
                    lstResultBol.Add(item);
                }
                if (lstResultBol == null || lstResultBol.Count == 0)
                {
                     App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                 App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM012");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM012");

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
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            try
            {
                await Task.Delay(1000);
                
             
                dbLayer.objInfoitems = objCMS;
                //filter

                lobjpicStatus = dbLayer.getLOV("strStatus", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                strTotalCaption = dbLayer.getCaption("strListofBillofLadings", objCMS);
                lblCapListofBOL = dbLayer.getCaption("strListofBillofLadings", objCMS);
                lblBayanNo = dbLayer.getCaption("strBayanNo", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                imgSearch = dbLayer.getCaption("imgsearch", objCMS);
                imgFilter = dbLayer.getCaption("imgfilter", objCMS);
                imgCommodity = dbLayer.getCaption("imgcommodity", objCMS);
                btnMoreDetails = dbLayer.getCaption("strMoreDetails", objCMS);
                lblShippingLine = dbLayer.getCaption("strShippingLine", objCMS);
                imgHapag = dbLayer.getCaption("imgHapag", objCMS);
                lblConsignee = dbLayer.getCaption("strConsignee", objCMS);
                lblShipper = dbLayer.getCaption("strShipper", objCMS);
                lblVesselVisit = dbLayer.getCaption("strVesselVisit", objCMS);
                lblBlCategory = dbLayer.getCaption("strBLCategory", objCMS);
                lblPol = dbLayer.getCaption("strPOL", objCMS);
                lblPod = dbLayer.getCaption("strPOD", objCMS);
                imgContainer = dbLayer.getCaption("imgcontainer", objCMS);
                //imgHapag = dbLayer.getCaption("imgHapag", objCMS);
                //lblConsignee = dbLayer.getCaption("strConsignees", objCMS);
                //lblShipper = dbLayer.getCaption("strShipper", objCMS);
               // lblVesselVisit = dbLayer.getCaption("strVesselVisit", objCMS);
                //lblPol = dbLayer.getCaption("strPOL", objCMS);
                //lblPod = dbLayer.getCaption("strPOD", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                txtSearch = dbLayer.getCaption("strBOLPlaceHolder", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                lblListofBOL = lblCapListofBOL + " (" + intTotalCount + ")";
                imgFilterBlue = dbLayer.getCaption("imgFilterBlue", objCMS);
                LblFilters = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgRest = dbLayer.getCaption("imgreset", objCMS);
                lblConsignee = dbLayer.getCaption("strConsignee", objCMS);
                imgDownArrow1 = dbLayer.getCaption("imgDownArrow", objCMS);
                lblVessel = dbLayer.getCaption("strVessel", objCMS);
                imgDownArrow2 = dbLayer.getCaption("imgDownArrow", objCMS);
                lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
                imgDownArrow3 = dbLayer.getCaption("imgDownArrow", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                imgDownArrow4 = dbLayer.getCaption("imgDownArrow", objCMS);
                lblAction = dbLayer.getCaption("strAction", objCMS);
                imgDownArrow5 = dbLayer.getCaption("imgDownArrow", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                imgCommodity = dbLayer.getCaption("imgcommodity", objCMS);
                imgContainer = dbLayer.getCaption("imgcontainer", objCMS);
                lblInYard = dbLayer.getCaption("strInYards", objCMS);
                lblDeparted = dbLayer.getCaption("strDepart", objCMS);
                lblchkmessage = dbLayer.getCaption("strPleaseClickTheCheckbox", objCMS);
                Lblok = dbLayer.getCaption("strOk", objCMSMsg); 
                //12-01-2023-Sanduru
                lblArrived = dbLayer.getCaption("strArrivedcolon", objCMS);
                lblLoaded = dbLayer.getCaption("strLoadedcolon", objCMS);
                await Task.Delay(1000); // Change 20220623
                if (strFilterFlag == "Y")
                {

                    //20230322 As per Mr.Raju Advice Select All Removed Temporary
                    //lstBLFilterStatusData.Add(new BOLFilterDtlist { CmbBLStatusData = lstrCaptionALL });
                    foreach (var dic in lobjpicStatus)
                    {
                        lstBLFilterStatusData.Add(new BOLFilterDtlist { CmbBLStatusData = dic.Key });
                    }
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Hold Good
        /// </summary>
        /// <param name="fobjBOL"></param>
        private async void Holdgood_Clicked(BOLDt fobjBOL)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                string strBOLNO = fobjBOL.Billoflading;
               
                gblBol.strgblBolNo = fobjBOL.Billoflading;
                Application.Current.MainPage?.Navigation.PushAsync(new Containerlist("", fobjBOL.Billoflading, "", "", "", "", "", "", "H","N"));
                await Task.Delay(1000);
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Header Data
        /// </summary>
        /// <param name="fstrBayanNumber"></param>
        /// <returns></returns>
        private async Task BolHeaderData(string fstrBayanNumber)
        {
            try
            {
                string fstrFilterData = "";
                string fstrBayanNo = fstrBayanNumber;
                //BayanNum
                if (fstrBayanNo != "")
                {
                    fstrFilterData += "BD_BAYANNUMBER:" + fstrBayanNo + ",";
                }
                lstBOLHeader = objCon.getBOLHeaderDetails(gblRegisteration.strLoginUser, fstrFilterData);
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((lstBOLHeader != null) && (lstBOLHeader.Count > 0))
                {
                    lblValBayanNo = lstBOLHeader.ToArray()[0].bd_bayannumber;
                    lblValBlCategory = lstBOLHeader.ToArray()[0].bd_category;
                    string lstrConsigneeName = lstBOLHeader.ToArray()[0].bd_consigneedesc1;
                    if (lstrConsigneeName.Length > 18)
                    {
                        lblValConsignee = lstrConsigneeName.Substring(0, 18);
                    }
                    else
                    {
                        lblValConsignee = lstrConsigneeName;
                    }
                    //16082022
                    string lstrshipperName = lstBOLHeader.ToArray()[0].bd_shipperdesc1;
                    if (lstrshipperName.Length > 18)
                    {
                        lblValShipper = lstrshipperName.Substring(0, 18);
                    }
                    else
                    {
                        lblValShipper = lstrshipperName;
                    }
                    lblValPod = lstBOLHeader.ToArray()[0].bd_portofdischarge;
                    lblValPol = lstBOLHeader.ToArray()[0].bd_portofloading;
                    imgHapag = lstBOLHeader.ToArray()[0].bd_shippinglineimage;
                    lblValShippingLineid = lstBOLHeader.ToArray()[0].bd_shippinglineid;
                    lblValVesselVisitId = lstBOLHeader.ToArray()[0].bd_vesselvisitid;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Consignee Filter Data
        /// </summary>
        /// <returns></returns>
        private async Task ConsigneeFilterData()
        {
            string strbaynNo = "";
            //string strBLNo = "";

            if ((gblBayan.strgblBaynanNo != null) && (gblBayan.strgblBaynanNo != ""))
            {
                strbaynNo = gblBayan.strgblBaynanNo;
            }
            string fstrfilter = "Gkey:" + gblRegisteration.strLoginUserLinkcode + ";" + "CustomerType:" + gblRegisteration.strLoginCustomerType + ";" + "BayanNo:" + strbaynNo + ";";
            lstConsignee = objCon.getBOLFilterConsigneeList(gblRegisteration.strLoginUser, fstrfilter);
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
              App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            try
            {

                var groupedResult = lstConsignee.GroupBy(x => new { x.value, x.text }).Select(x => x.Key).ToList();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstBLFilterConsigneeData.Add(new BOLFilterDtlist { CmbBLConsigneeData = lstrCaptionALL });
                foreach (var dic in groupedResult)
                {
                    if (dic.text != "")
                    {
                        lstBLFilterConsigneeData.Add(new BOLFilterDtlist { CmbBLConsigneeData = dic.text });
                    }
                }
            }
            catch (Exception ex)
            {
              App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Vessel Filter Data
        /// </summary>
        /// <returns></returns>
        private async Task VesselFilterData()
        {
            string strbaynNo = "";
           // string strBLNo = "";
            if ((gblBayan.strgblBaynanNo != null) && (gblBayan.strgblBaynanNo != ""))
            {
                strbaynNo = gblBayan.strgblBaynanNo;
            }
            string fstrfilter = "Gkey:" + gblRegisteration.strLoginUserLinkcode + ";" + "CustomerType:" + gblRegisteration.strLoginCustomerType + ";" + "BayanNo:" + strbaynNo + ";";
            lstVessel = objCon.getBOLFilterVesselList(gblRegisteration.strLoginUser, fstrfilter);
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            try
            {
                var groupedResult = lstVessel.GroupBy(x => new { x.value, x.text }).Select(x => x.Key).ToList();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstBLFilterVesselData.Add(new BOLFilterDtlist { CmbBLVesselData = lstrCaptionALL });
                foreach (var dic in groupedResult)
                {
                    lstBLFilterVesselData.Add(new BOLFilterDtlist { CmbBLVesselData = dic.text });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Carrier Filter Data
        /// </summary>
        /// <returns></returns>
        private async Task CarrierFilterData()
        {
            string strbaynNo = "";
           // string strBLNo = "";

            if ((gblBayan.strgblBaynanNo != null) && (gblBayan.strgblBaynanNo != ""))
            {
                strbaynNo = gblBayan.strgblBaynanNo;
            }
            string fstrfilter = "Gkey:" + gblRegisteration.strLoginUserLinkcode + ";" + "CustomerType:" +
                gblRegisteration.strLoginCustomerType + ";" + "BayanNo:" + strbaynNo + ";";

            lstCarrier = objCon.getBOLFilterCarrierList(gblRegisteration.strLoginUser, fstrfilter);
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            try
            {
                var groupedResult = lstCarrier.GroupBy(x => new { x.value, x.text }).Select(x => x.Key).ToList();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstBLFilterCarrierData.Add(new BOLFilterDtlist { CmbBLCarrierData = lstrCaptionALL });
                foreach (var dic in groupedResult)
                {
                    lstBLFilterCarrierData.Add(new BOLFilterDtlist { CmbBLCarrierData = dic.text });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Go Clicked Apply
        /// </summary>
        /// <returns></returns>
        private async Task ClickedApply()
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                var strselectedConsignee = "";
                var strselectedVessel = "";
                var strselectedCarrier = "";
                var strselectedStatus = "";
                if (lstBLFilterConsigneeData.Count > 0)
                {
                    foreach (var item in lstBLFilterConsigneeData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbBLConsigneeData.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedConsignee += item.CmbBLConsigneeData + ",";
                            }
                        }
                    }
                }
                if (lstBLFilterVesselData.Count > 0)
                {
                    foreach (var item in lstBLFilterVesselData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbBLVesselData.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedVessel += item.CmbBLVesselData + ",";
                            }
                        }
                    }
                }
                if (lstBLFilterCarrierData.Count > 0)
                {
                    foreach (var item in lstBLFilterCarrierData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbBLCarrierData.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedCarrier += item.CmbBLCarrierData + ",";
                            }
                        }
                    }
                }
                if (lstBLFilterStatusData.Count > 0)
                {
                    foreach (var item in lstBLFilterStatusData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbBLStatusData.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstStatus = lobjpicStatus.Where(x => x.Key.Contains(item.CmbBLStatusData)).ToList();
                                strselectedStatus += lstStatus[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                if (strselectedConsignee.Length > 0) strselectedConsignee = strselectedConsignee.Substring(0, strselectedConsignee.Length - 1);
                if (strselectedVessel.Length > 0) strselectedVessel = strselectedVessel.Substring(0, strselectedVessel.Length - 1);
                if (strselectedCarrier.Length > 0) strselectedCarrier = strselectedCarrier.Substring(0, strselectedCarrier.Length - 1);
                if (strselectedStatus.Length > 0) strselectedStatus = strselectedStatus.Substring(0, strselectedStatus.Length - 1);
                await App.Current.MainPage?.Navigation.PushAsync(new BOL("", strBaynanNo, strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus));
                await Task.Delay(1000); // Change 20220623
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Generate Invoice
        /// </summary>
        /// <param name="fobjBol"></param>
        private async void GenerateInvoice(BOLDt fobjBol)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                string lstrInputJson = "";
                string lstrResult = "";
                string lstrIDNO = "";
                if (lstResultBol.Count > 0)
                {
                    lstrIDNO = gblRegisteration.strIdNo;
                    if (gblRegisteration.strLoginCustomerType.ToUpper().ToString().Trim() == "CLEARING AGENT")
                    {
                        if (gblRegisteration.strru_clearingagentflag.ToUpper().ToString().Trim() == "FALSE")
                        {
                            gblRegisteration.strGenerateInvoiceflag = "CLEARING AGENT";

                            await App.Current.MainPage?.Navigation.PushAsync(new Generateinvoice_popup());
                            return;
                        }
                    }
                    if (gblRegisteration.strLoginCustomerType.ToUpper().ToString().Trim() == "BROKER")
                    {
                        if (gblRegisteration.strru_brokerflag.ToUpper().ToString().Trim() == "FALSE")
                        {
                            gblRegisteration.strGenerateInvoiceflag = "BROKER";
                            await App.Current.MainPage?.Navigation.PushAsync(new Generateinvoice_popup());
                            return;
                        }
                    }
                    foreach (var item in lstResultBol)
                    {
                        if (item.chkBolNo == true)
                        {
                            lstrInputJson = "{\"PA_API\": \"generate Invoice\",\"PA_STATUS\": \"Requested\",\"PA_PARAMETERS\": \"{'Invoice':{'billOfLading':'" + item.Billoflading + "','ID':'" + lstrIDNO + "','Language':'EN','Command':'Generate'}}\"}";
                            lstrResult = objWebApi.postWebApi("GenerateInvoice", lstrInputJson);

                            //Web Api Timeout
                            if (AppSettings.ErrorExceptionWebApi != "")
                            {
                               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                            }
                            string strJson = "{ \"BL_BOLSTATUSCODE\":\"IN_UP\" }";
                            string lstrBolNo = item.Billoflading;
                             lstrBolNo = lstrBolNo.Replace("/", "^");
                            lstrResult = objWebApi.putWebApi("UpdateBOLStatus", strJson, lstrBolNo);

                            //Web Api Timeout
                            if (AppSettings.ErrorExceptionWebApi != "")
                            {
                               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                            }
                        }
                    }
                }
                var lstItemSelected = fobjBol;
                var BLNo = lstItemSelected.Billoflading;
                if (lstrResult.ToUpper().Trim() == "TRUE")
                {                    
                    objWebApi.postWebApi("PostSendEmail", gblTrackRequests.GenerateInvoiceeMailData());

                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    await App.Current.MainPage?.Navigation.PushAsync(new Generateinvoice_popup());
                }
                else
                {
                    string lblchkmessage = dbLayer.getCaption("strPleaseClickTheCheckbox", objCMS);
                   App.Current.MainPage?.DisplayToastAsync(lblchkmessage, 3000);
                }
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Pay Invoice
        /// </summary>
        /// <param name="fobjBol"></param>
        private async void PayInvoice(BOLDt fobjBol)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);
                bool boolchkBolNo = false;
              //  string lstrInputJson = "";
                string lstrResult = "";
                if (lstResultBol.Count > 0)
                {
                    foreach (var item in lstResultBol)
                    {
                        if (item.chkBolNo == true)
                        {
                            boolchkBolNo = true;
                            string fstrDraftNo = item.Proformainvoicenumber;
                            int lintResult = 0;
                            lintResult = objCon.getDraftNoStatus(fstrDraftNo);
                            if (lintResult == 0)
                            {
                                string strJson = "{ \"BL_BOLSTATUSCODE\":\"\",\"BL_IHINVOICENUMBER\":\"\",\"BL_IHPROFORMAINVOICENUMBER\":\"\",\"BL_IHSTATUS\":\"Cancelled\" }";
                                lstrResult = objWebApi.putWebApi("UpdateBilloflading", strJson, item.Proformainvoicenumber);

                                //Web Api Timeout
                                if (AppSettings.ErrorExceptionWebApi != "")
                                {
                                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                                }

                                await App.Current.MainPage?.Navigation.PushAsync(new PayMessage());
                            }
                            if (lintResult == 1)
                            {                               
                                string fstrDraftNos = item.Proformainvoicenumber;
                                string fstrConsigneeName = item.Invoiceconsignee;
                                await App.Current.MainPage?.Navigation.PushAsync(new Payment(fstrDraftNos, fstrConsigneeName, "N"));
                            }

                        }
                    }

                    if (boolchkBolNo == false)
                    {
                        string lblchkmessage = dbLayer.getCaption("strPleaseClickTheCheckbox", objCMS);
                       App.Current.MainPage?.DisplayToastAsync(lblchkmessage, 3000);
                    }

                }
                IsBusy = false;
                StackBOL = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Book Appointment
        /// </summary>
        /// <param name="fobjBol"></param>
        private async void BookunAppoinment(BOLDt fobjBol)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000); // Change 20220623
               // string lstrInputJson = "";
               // string lstrResult = "";
                var lstItemSelected = fobjBol;
                var BLNo = lstItemSelected.Billoflading;
                App.Current.MainPage?.Navigation.PushAsync(new AppointmentBooking("", "", "", "", "", "", "","N"));
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get On Tapped Commlist
        /// </summary>
        /// <param name="fobjBOL"></param>
        private async void OnTappedCommlist(BOLDt fobjBOL)
        {
            try
            {
                IsBusy = true;
                StackBOL = false;
                await Task.Delay(1000);

                string strBOL = fobjBOL.Billoflading;
                 App.Current.MainPage?.Navigation.PushAsync(new Commoditypopup(strBOL));
                StackBOL = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get BOL Request
        /// </summary>
        /// <param name="fobjBOL"></param>
        private async void BOLRequest(BOLDt fobjBOL)
        {
            IsBusy = true;
            StackBOL = false;
            await Task.Delay(1000);
            string fstrRequest = fobjBOL.RequestFlag;
            gblBol.strBOL = fobjBOL.Billoflading;
            gblBol.strBayanNO = fobjBOL.BayanNo;
            //As Per Client Request to  enable based on customer type
            //User based Screen Restriction handled by Gokul on 20230413
            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "TRANSPORTER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CONSIGNEE") ||
                   (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CLEARING AGENT") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPER")
               || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "BROKER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPING LINE"))
            {

                if (fobjBOL.GateOutContainerFlag == "Y")
                {
                     App.Current.MainPage?.Navigation.PushAsync(new GatePhotoRequest(gblBol.strBOL, "", gblBol.strBayanNO, fstrRequest));
                }
            }
            StackBOL = true;
            IsBusy = false;
        }
    }
}