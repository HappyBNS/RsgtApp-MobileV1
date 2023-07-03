using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
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
using static RsgtApp.Models.ManuallnspectionModel;
namespace RsgtApp.ViewModels
{
    public class ManualInspectionViewModel : INotifyPropertyChanged
    {
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        List<ManualInspectionDt> lstManuallspectionlocal = new List<ManualInspectionDt>();
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
        //imgInspectionIcon purpose of using image varaiable
        private string imgInspectionIcon = "";
        public string ImgInspectionIcon
        {
            get { return imgInspectionIcon; }
            set
            {
                imgInspectionIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgInspectionIcon");
            }
        }
        //lblBookForManual purpose of using label varaiable
        private string lblBookForManual = "";
        public string LblBookForManual
        {
            get { return lblBookForManual; }
            set
            {
                lblBookForManual = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBookForManual");
            }
        }
        //To Declare Count Variable
        // private int totalRecordCount = 0;
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
        //manualInspectioninfo purpose of using group reference varaiable
        private string manualInspectioninfo = "";
        public string ManualInspectioninfo
        {
            get { return manualInspectioninfo; }
            set
            {
                manualInspectioninfo = value;
                OnPropertyChanged();
                RaisePropertyChange("ManualInspectioninfo");
            }
        }
        //lblStatus purpose of using Label varaiable
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
        //statusColor purpose of using group reference varaiable
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
        //lblContainerNo purpose of using Label varaiable
        private string lblContainerNo = "";
        public string LblContainerNo
        {
            get { return lblContainerNo; }
            set
            {
                lblContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerNo");
            }
        }
        //lblSize purpose of using Label varaiable
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
        //lblBayan purpose of using Label varaiable
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
        //lblBOL purpose of using Label varaiable
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
        //lblCarrier purpose of using Label varaiable
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
        //lblVessel purpose of using Label varaiable
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
        //lblVoyage purpose of using Label varaiable
        private string lblVoyage = "";
        public string LblVoyage
        {
            get { return lblVoyage; }
            set
            {
                lblVoyage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVoyage");
            }
        }
        //lblCategory purpose of using Label varaiable
        private string lblCategory = "";
        public string LblCategory
        {
            get { return lblCategory; }
            set
            {
                lblCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCategory");
            }
        }
        //lblPOL purpose of using Label varaiable
        private string lblPOL = "";
        public string LblPOL
        {
            get { return lblPOL; }
            set
            {
                lblPOL = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPOL");
            }
        }
        //lblPOD purpose of using Label varaiable
        private string lblPOD = "";
        public string LblPOD
        {
            get { return lblPOD; }
            set
            {
                lblPOD = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPOD");
            }
        }
        //imgArrows purpose of using image varaiable
        private string imgArrows = "";
        public string ImgArrows
        {
            get { return imgArrows; }
            set
            {
                imgArrows = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgArrows");
            }
        }
        //placeContainerNo purpose of using data varaiable
        private string placeContainerNo = "";
        public string PlaceContainerNo
        {
            get { return placeContainerNo; }
            set
            {
                placeContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceContainerNo");
            }
        }
        //placeBayanNo purpose of using data varaiable
        private string placeBayanNo = "";
        public string PlaceBayanNo
        {
            get { return placeBayanNo; }
            set
            {
                placeBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBayanNo");
            }
        }
        //placeBillOfLadingNo purpose of using data
        //varaiable
        private string placeBillOfLadingNo = "";
        public string PlaceBillOfLadingNo
        {
            get { return placeBillOfLadingNo; }
            set
            {
                placeBillOfLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBillOfLadingNo");
            }
        }
        //lblFreightkind purpose of using Label varaiable
        private string lblFreightkind = "";
        public string LblFreightkind
        {
            get { return lblFreightkind; }
            set
            {
                lblFreightkind = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFreightkind");
            }
        }
        //lblTimeIn purpose of using Label varaiable
        private string lblTimeIn = "";
        public string LblTimeIn
        {
            get { return lblTimeIn; }
            set
            {
                lblTimeIn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTimeIn");
            }
        }
        //btnDisclamer purpose of using button varaiable
        private string btnDisclamer = "";
        public string BtnDisclamer
        {
            get { return btnDisclamer; }
            set
            {
                btnDisclamer = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnDisclamer");
            }
        }
        //btnLoadMore purpose of using button varaiable
        private string btnLoadMore = "";
        public string BtnLoadMore
        {
            get { return btnLoadMore; }
            set
            {
                btnLoadMore = value;
                OnPropertyChanged();
                RaisePropertyChange("btnLoadMore");
            }
        }
        //To assign boolean variable
        private bool manualnspectionEN = true;
        public bool ManualnspectionEN
        {
            get { return manualnspectionEN; }
            set
            {
                manualnspectionEN = value;
                OnPropertyChanged();
                RaisePropertyChange("ManualnspectionEN");
            }
        }
        //Filter
        //To assign boolean variable
        private bool manuallEn = true;
        public bool ManuallEn
        {
            get { return manuallEn; }
            set
            {
                manuallEn = value;
                OnPropertyChanged();
                RaisePropertyChange("ManuallEn");
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
        //btnApply purpose of using button varaiable
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
        //lblFLStatus purpose of using Label varaiable
        private string lblFLStatus = "";
        public string LblFLStatus
        {
            get { return lblFLStatus; }
            set
            {
                lblFLStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFLStatus");
            }
        }
        //imgDown purpose of using image varaiable
        private string imgDown = "";
        public string ImgDown
        {
            get { return imgDown; }
            set
            {
                imgDown = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDown");
            }
        }
        //lblSelectAllStatus purpose of using Label varaiable
        private string lblSelectAllStatus = "";
        public string LblSelectAllStatus
        {
            get { return lblSelectAllStatus; }
            set
            {
                lblSelectAllStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSelectAllStatus");
            }
        }
        //cmbStatus purpose of using combo varaiable
        private string cmbStatus = "";
        public string CmbStatus
        {
            get { return cmbStatus; }
            set
            {
                cmbStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("CmbStatus");
            }
        }
        //cmbSize purpose of using combo varaiable
        private string cmbSize = "";
        public string CmbSize
        {
            get { return cmbSize; }
            set
            {
                cmbSize = value;
                OnPropertyChanged();
                RaisePropertyChange("CmbSize");
            }
        }
        //imgArrow purpose of using image varaiable
        private string imgArrow = "";
        public string ImgArrow
        {
            get { return imgArrow; }
            set
            {
                imgArrow = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgArrow");
            }
        }
        //cmbCarrier purpose of using combo varaiable
        private string cmbCarrier = "";
        public string CmbCarrier
        {
            get { return cmbCarrier; }
            set
            {
                cmbCarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("CmbCarrier");
            }
        }
        //imgDownArs purpose of using image varaiable
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
        //cmbCategory purpose of using combo varaiable
        private string cmbCategory = "";
        public string CmbCategory
        {
            get { return cmbCategory; }
            set
            {
                cmbCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("CmbCategory");
            }
        }
        //lblFreightKind purpose of using Label varaiable
        private string lblFreightKind = "";
        public string LblFreightKind
        {
            get { return lblFreightKind; }
            set
            {
                lblFreightKind = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFreightKind");
            }
        }
        //imgArrowDown purpose of using image varaiable
        private string imgArrowDown = "";
        public string ImgArrowDown
        {
            get { return imgArrowDown; }
            set
            {
                imgArrowDown = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgArrowDown");
            }
        }
        //cmbFreightKind purpose of using combo varaiable
        private string cmbFreightKind = "";
        public string CmbFreightKind
        {
            get { return cmbFreightKind; }
            set
            {
                cmbFreightKind = value;
                OnPropertyChanged();
                RaisePropertyChange("CmbFreightKind");
            }
        }
        //imgDownRows purpose of using image varaiable
        private string imgDownRows = "";
        public string ImgDownRows
        {
            get { return imgDownRows; }
            set
            {
                imgDownRows = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownRows");
            }
        }
        //cmbPOL purpose of using combo varaiable
        private string cmbPOL = "";
        public string CmbPOL
        {
            get { return cmbPOL; }
            set
            {
                cmbPOL = value;
                OnPropertyChanged();
                RaisePropertyChange("CmbPOL");
            }
        }
        //imgArros purpose of using image varaiable
        private string imgArros = "";
        public string ImgArros
        {
            get { return imgArros; }
            set
            {
                imgArros = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgArros");
            }
        }
        //cmbPOD purpose of using combo varaiable
        private string cmbPOD = "";
        public string CmbPOD
        {
            get { return cmbPOD; }
            set
            {
                cmbPOD = value;
                OnPropertyChanged();
                RaisePropertyChange("CmbPOD");
            }
        }
        //txtContainerNo purpose of using text varaiable
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
        //txtBayanNo purpose of using text varaiable
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
        //txtBillOfLadingNo purpose of using text varaiable
        private string txtBillOfLadingNo = "";
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
        //Hide and Show Manuallnspection 2023/03/18
        private bool isVisibleManualInsMain = false;
        public bool IsVisibleManualInsMain
        {
            get { return isVisibleManualInsMain; }
            set
            {
                isVisibleManualInsMain = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleManualInsMain");
            }
        }


        private bool isVisibleManualInsFilter = false;
        public bool IsVisibleManualInsFilter
        {
            get { return isVisibleManualInsFilter; }
            set
            {
                isVisibleManualInsFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleManualInsFilter");
            }
        }
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
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //CMS Caption List
        private List<InfoItem> objCMS = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        string lstrCaptionALL = "";
        //ObservableCollection use to Data Binding list
        List<clsManualInsSizeFilter> lstSize = new List<clsManualInsSizeFilter>();
        public ObservableCollection<ManualInspectionFilterDlList> lstManualSizeFilter { get; set; } = new ObservableCollection<ManualInspectionFilterDlList>();
        List<clsManualInsCarrierFilter> lstCarrier = new List<clsManualInsCarrierFilter>();
        public ObservableCollection<ManualInspectionFilterDlList> lstManualCarrierFilter { get; set; } = new ObservableCollection<ManualInspectionFilterDlList>();
        List<clsManualInsCategoryFilter> lstCategory = new List<clsManualInsCategoryFilter>();
        public ObservableCollection<ManualInspectionFilterDlList> lstManualCategoryFilter { get; set; } = new ObservableCollection<ManualInspectionFilterDlList>();
        List<clsManualInsFreightKindFilter> lstFreightkind = new List<clsManualInsFreightKindFilter>();
        public ObservableCollection<ManualInspectionFilterDlList> lstManualFreightkindFilter { get; set; } = new ObservableCollection<ManualInspectionFilterDlList>();
        List<clsManualInsPolFilter> lstPol = new List<clsManualInsPolFilter>();
        public ObservableCollection<ManualInspectionFilterDlList> lstManualPolFilter { get; set; } = new ObservableCollection<ManualInspectionFilterDlList>();
        List<clsManualInsPodFilter> lstPod = new List<clsManualInsPodFilter>();
        public ObservableCollection<ManualInspectionFilterDlList> lstManualPodFilter { get; set; } = new ObservableCollection<ManualInspectionFilterDlList>();
        //private string lstrResult = "";
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        //ObservableCollection in ManualInspection List
        public ObservableCollection<ManualInspectionDt> lstManuallspection { get; set; } = new ObservableCollection<ManualInspectionDt>();
        private List<ManualInspectionDt> objDataSource = new List<ManualInspectionDt>();
        //To declare Variable
        public int gblRowCount { get; set; }
        public int fintPageNumber { get; set; }
        public int fintPageSize { get; set; }
        public int intTotalCount { get; set; }
        public string strFilterData { get; set; }
        public string gblAnyWhere = "";
        public string gblfilter { get; set; }
        public string lstrStatus = "";
        public string lstrSize = "";
        public string lstrCarrier = "";
        public string lstrCategory = "";
        public string lstrFreightkind = "";
        public string lstrPol = "";
        public string lstrPod = "";
        public string lstrContainerNo = "";
        public string lstrBayanNo = "";
        public string lstrBOLNo = "";
        string strSno = "";
        string strStatus = "";
        string strContainerNo = "";
        string strSize = "";
        string strBayan = "";
        string strBOL = "";
        string strCarrier = "";
        string strVessel = "";
        string strVoyage = "";
        string strCategory = "";
        string strPOL = "";
        string strPOD = "";
        string strFreightkind = "";
        string strTimeIn = "";
        string strServerSlowMsg = "";
        private string strNoRecord = "";
        string strSelect = "";
        //Button_ClickedApply Button Command
        public Command Button_ClickedApply { get; set; }
        public Command Disclaimer_Clicked { get; set; }
        //LoadMore Button Command
        public Command GotoLoadMore { get; set; }
        //Button_ClickedCancel Button Command
        public Command Button_ClickedCancel { get; set; }
        //Filter Button Command
        public Command FilterClicked { get; set; }
        //Anywhere Search Button Command
        public Command gotoAnywheresearch { get; set; }
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
                FilterClicked.ChangeCanExecute();
                gotoAnywheresearch.ChangeCanExecute();
                Button_ClickedCancel.ChangeCanExecute();
                Button_ClickedApply.ChangeCanExecute();
                Disclaimer_Clicked.ChangeCanExecute();
            }
        }
        //To handle Boolen variable
        private bool disclamer = false;
        public bool Disclamer
        {
            get { return disclamer; }
            set
            {
                disclamer = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
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
        private bool _isExpandedPOL = false;
        public bool IsExpandedPOL
        {
            get { return _isExpandedPOL; }
            set { SetProperty(ref _isExpandedPOL, value); }
        }
        //To handle Bool in Expander
        private bool _isExpandedPOD = false;
        public bool IsExpandedPOD
        {
            get { return _isExpandedPOD; }
            set { SetProperty(ref _isExpandedPOD, value); }
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
        private bool _isExpandedCategory = false;
        public bool IsExpandedCategory
        {
            get { return _isExpandedCategory; }
            set { SetProperty(ref _isExpandedCategory, value); }
        }
        //To handle Bool in Expander
        private bool _isExpandedFreightKind = false;
        public bool IsExpandedFreightKind
        {
            get { return _isExpandedFreightKind; }
            set { SetProperty(ref _isExpandedFreightKind, value); }
        }
       
        ContentPage Myview;
        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBayanNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrSize"></param>
        /// <param name="fstrCarrier"></param>
        /// <param name="fstrCategory"></param>
        /// <param name="fstrFreightkind"></param>
        /// <param name="fstrPol"></param>
        /// <param name="fstrPod"></param>
        /// <param name="fstrFilterFlag"></param>        
        public ManualInspectionViewModel(string fstrContainerNo, string fstrBayanNo, string fstrBOLNo, string fstrSize, string fstrCarrier, string fstrCategory, string fstrFreightkind, string fstrPol, string fstrPod, string fstrFilterFlag, ContentPage view)
        {
            try
            {
                Myview = view;
                //Appcenter Track Event handler
                Analytics.TrackEvent("ManualInspectionViewModel");
                IsVisibleManualInsMain = false;
                IsVisibleManualInsFilter = false;
                if (fstrFilterFlag == "N")
                {
                    IsVisibleManualInsMain = true;
                    IsVisibleManualInsFilter = false;
                }
                if (fstrFilterFlag == "Y")
                {
                    IsVisibleManualInsMain = false;
                    IsVisibleManualInsFilter = true;
                }
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
                //Anywhere Search Button Command function call
                gotoAnywheresearch = new Command(async () => await fnAnywheresearch(), () => !IsBusy);
                //Filter Button Command function call
                FilterClicked = new Command(async () => await Filter_Clicked(), () => !IsBusy);
                //Cancel/Reset  Button Command function call
                Button_ClickedCancel = new Command(async () => await ButtonCancel(), () => !IsBusy);
                //Apply Filter Button Command function call
                Button_ClickedApply = new Command(async () => await ButtondApply(), () => !IsBusy);
                Disclaimer_Clicked = new Command(async () => await DisclaimerClicked(), () => !IsBusy);
                //End-All Command Buttons

                //Begin-Call Filter Get Funtion
                Task.Run(() => PodFilterData()).Wait();
                Task.Run(() => SizeFilterData()).Wait();
                Task.Run(() => CarrierFilterData()).Wait();
                Task.Run(() => CategoryFilterData()).Wait();
                Task.Run(() => FreightkindFilterData()).Wait();
                Task.Run(() => PolFilterData()).Wait();
                //End-Call Filter Get Funtion

                //Listview Get Data
                Task.Run(() => ManualInspectionData("", fstrContainerNo, fstrBayanNo, fstrBOLNo, fstrSize, fstrCarrier, fstrCategory, fstrFreightkind, fstrPol, fstrPod)).Wait();

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Begin assignCms function
        /// </summary>
        /// <returns></returns>
        public async Task assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM411");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM411");

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
                await Task.Delay(1000);
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
                dbLayer.objInfoitems = objCMS;
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                imgInspectionIcon = dbLayer.getCaption("imgInspection", objCMS);
                lblBookForManual = dbLayer.getCaption("strBookforManualInspection", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                btnDisclamer = dbLayer.getCaption("strDisclamer", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                strSno = dbLayer.getCaption("strSno", objCMS);
                strStatus = dbLayer.getCaption("strStatus", objCMS);
                strContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                strSize = dbLayer.getCaption("strSize", objCMS);
                strBayan = dbLayer.getCaption("strBayan", objCMS);
                strBOL = dbLayer.getCaption("strBillofLading", objCMS);
                strCarrier = dbLayer.getCaption("strCarrier", objCMS);
                strVessel = dbLayer.getCaption("strVessel", objCMS);
                strVoyage = dbLayer.getCaption("strVoyage", objCMS);
                strCategory = dbLayer.getCaption("strCategory", objCMS);
                strPOL = dbLayer.getCaption("strPOL", objCMS);
                strPOD = dbLayer.getCaption("strPOD", objCMS);
                strFreightkind = dbLayer.getCaption("strFreightKind", objCMS);
                strTimeIn = dbLayer.getCaption("strTimeIn", objCMS);
                strSelect = dbLayer.getCaption("StrSelectContainer", objCMSMsg);
                txtSearch = dbLayer.getCaption("StrInspectionPlaceHolder", objCMS);
                ImgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                lblFilters = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgReset = dbLayer.getCaption("imgReset", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                imgDown = dbLayer.getCaption("imgDownArrow", objCMS);
                lblSize = dbLayer.getCaption("strSize", objCMS);
                imgArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
                imgDownArs = dbLayer.getCaption("imgDownArrow", objCMS);
                lblCategory = dbLayer.getCaption("strCategory", objCMS);
                imgArrowDown = dbLayer.getCaption("imgDownArrow", objCMS);
                lblFreightKind = dbLayer.getCaption("strFreightKind", objCMS);
                imgDownRows = dbLayer.getCaption("imgDownArrow", objCMS);
                lblPOL = dbLayer.getCaption("strPOL", objCMS);
                imgArros = dbLayer.getCaption("imgDownArrow", objCMS);
                lblPOD = dbLayer.getCaption("strPOD", objCMS);
                imgArrows = dbLayer.getCaption("imgDownArrow", objCMS);
                PlaceContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                PlaceBayanNo = dbLayer.getCaption("strBayanNo", objCMS);
                PlaceBillOfLadingNo = dbLayer.getCaption("strBillofLadingNo", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignContent function
        /// <summary>
        /// TO function call to API in Listview Data GetFunction
        /// </summary>
        /// <param name="fintPageSize"></param>
        /// <param name="fintPageNumber"></param>
        /// <param name="fstrAnywhere"></param>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBayanNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrSize"></param>
        /// <param name="fstrCarrier"></param>
        /// <param name="fstrCategory"></param>
        /// <param name="fstrFreightkind"></param>
        /// <param name="fstrPol"></param>
        /// <param name="fstrPod"></param>
        /// <returns></returns>
        private async Task ManualInspectionData(string fstrAnywhere, string fstrContainerNo, string fstrBayanNo, string fstrBOLNo, string fstrSize, string fstrCarrier, string fstrCategory, string fstrFreightkind, string fstrPol, string fstrPod)
        {
            try
            {
                await Task.Delay(1000);
                if ((fstrSize != null) && (fstrSize != ""))
                {
                    lstrSize = fstrSize;
                }
                if ((fstrCarrier != null) && (fstrCarrier != ""))
                {
                    lstrCarrier = fstrCarrier;
                }
                if ((fstrCategory != null) && (fstrCategory != ""))
                {
                    lstrCategory = fstrCategory;
                }
                if ((fstrFreightkind != null) && (fstrFreightkind != ""))
                {
                    lstrFreightkind = fstrFreightkind;
                }
                if ((fstrPol != null) && (fstrPol != ""))
                {
                    lstrPol = fstrPol;
                }
                if ((fstrPod != null) && (fstrPod != ""))
                {
                    lstrPod = fstrPod;
                }
                if ((fstrContainerNo != null) && (fstrContainerNo != ""))
                {
                    lstrContainerNo = fstrContainerNo;
                }
                if ((fstrBayanNo != null) && (fstrBayanNo != ""))
                {
                    lstrBayanNo = fstrBayanNo;
                }
                if ((fstrBOLNo != null) && (fstrBOLNo != ""))
                {
                    lstrBOLNo = fstrBOLNo;
                }
                if ((fstrAnywhere != null) && (fstrAnywhere != ""))
                {
                    gblAnyWhere = fstrAnywhere;
                }
                gblfilter = "";
                gblfilter += "fstrAnyWhere:" + gblAnyWhere + ";" + "fstrContainerNo:" + lstrContainerNo + ";" + "fstrBayanNo:" + lstrBayanNo + ";" + "fstrBOLNo:" + lstrBOLNo + ";" + "fstrSize:" + lstrSize + ";" + "fstrCarrier:" + lstrCarrier + ";" + "fstrCategory:" + lstrCategory + ";" + "fstrFreightkind:" + lstrFreightkind + ";" + "fstrPol:" + lstrPol + ";" + "fstrPod:" + lstrPod + ";";
                objDataSource = objBl.getBookforManualInspectionDetails(gblRegisteration.strLoginUser, lfintPageNo, lfintPageSize, "", gblfilter);

                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstManuallspection.Clear();
                foreach (var item in objDataSource)
                {
                    item.lblStatus = lblStatus;
                    item.lblContainerNo = strContainerNo;
                    item.lblSize = lblSize;
                    item.lblBayan = strBayan;
                    item.lblBOL = strBOL;
                    item.lblCarrier = strCarrier;
                    item.lblVessel = strVessel;
                    item.lblVoyage = strVoyage;
                    item.lblCategory = lblCategory;
                    item.lblPOL = lblPOL;
                    item.lblPOD = lblPOD;
                    item.lblFreightkind = strFreightkind;
                    item.lblTimeIn = strTimeIn;
                    lstManuallspection.Add(item);
                }
                CollectionView cvManuallnspection = Myview.FindByName<CollectionView>("GridManuallnspection");
                cvManuallnspection.ItemsSource = null;
                cvManuallnspection.ItemsSource = lstManuallspection;
                cvManuallnspection.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                totalRecordCount = lstManuallspection.Count.ToString();
                TotalRecordCount = lblBookForManual + " (" + totalRecordCount + ")";
                Disclamer = false;
                if (lstManuallspection.Count > 0 || (objDataSource.Count > 0))
                {
                    Disclamer = true;
                }
                if (objDataSource == null || objDataSource.Count == 0)
                {
                   App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                   App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Click the Filter Buttion
        /// </summary>
        /// <returns></returns>
        public async Task Filter_Clicked()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                await Task.Delay(1000);
                IsVisibleManualInsFilter = true;
                IsVisibleManualInsMain = false;
                ManualnspectionEN = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Click the Disclaimer Button
        /// </summary>
        /// <returns></returns>
        public async Task DisclaimerClicked()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                await Task.Delay(1000);
                var lstrCheked = 'N';
                foreach (var item in lstManuallspection)
                {
                    if (item.IsCheked == true)
                    {
                        lstManuallspectionlocal.Add(item);
                        lstrCheked = 'Y';
                    }
                }
                if (lstrCheked == 'Y')
                {
                    await App.Current.MainPage?.Navigation.PushAsync(new Disclaimer_page(lstManuallspectionlocal));
                }
                else
                {
                   App.Current.MainPage?.DisplayToastAsync(strSelect, 3000);
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ManualnspectionEN = true;
            IsBusy = false;
        }
        /// <summary>
        /// To click the AnywhereSearch button
        /// </summary>
        /// <returns></returns>
        private async Task fnAnywheresearch()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                await Task.Delay(1000);
                LfintPageNo = 1;
                //string lstrAnyWhere = "";
                //lstrSize = "";
                //lstrCarrier = "";
                //lstrCategory = "";
                //lstrFreightkind = "";
                //lstrPol = "";
                //lstrPod = "";
                //lstrContainerNo = "";
                //lstrBayanNo = "";
                //lstrBOLNo = "";
                //gblAnyWhere = "";
                //string lstrSearch = searchbox.ToString().Trim();
                //if ((lstrSearch != null) && (lstrSearch != ""))
                //{
                //    gblAnyWhere = lstrSearch;
                //}
                // Dictionary<string, string> fobjparmes = null;
                //lstManuallspection.Clear();
                await ManualInspectionData(gblAnyWhere, lstrContainerNo, lstrBayanNo, lstrBOLNo, lstrSize, lstrCarrier, lstrCategory, lstrFreightkind, lstrPol, lstrPod);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ManualnspectionEN = true;
            IsBusy = false;
        }


        //Filter Page start
        /// <summary>
        /// To apply size filter button
        /// </summary>
        private void SizeFilterData()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                lstSize = objBl.getManualInsFilterSizeList("", gblRegisteration.strLoginUser);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstManualSizeFilter.Clear();
                var groupedResult = from s in lstSize
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstManualSizeFilter.Add(new ManualInspectionFilterDlList { CmbSize = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstManualSizeFilter.Add(new ManualInspectionFilterDlList { CmbSize = item.Key });
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ManualnspectionEN = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Apply carrier Filter Button
        /// </summary>
        private void CarrierFilterData()
        {
            try
            {
                lstCarrier = objBl.getManualInsFilterCarrierList("", gblRegisteration.strLoginUser);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstManualCarrierFilter.Clear();
                var groupedResult = from s in lstCarrier
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstManualCarrierFilter.Add(new ManualInspectionFilterDlList { CmbCarrier = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstManualCarrierFilter.Add(new ManualInspectionFilterDlList { CmbCarrier = item.Key });
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Apply Category Filter Button
        /// </summary>
        private void CategoryFilterData()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                ManuallEn = false;
                lstCategory = objBl.getManualInsFilterCategoryList("", gblRegisteration.strLoginUser);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstManualCategoryFilter.Clear();
                var groupedResult = from s in lstCategory
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstManualCategoryFilter.Add(new ManualInspectionFilterDlList { CmbCategory = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstManualCategoryFilter.Add(new ManualInspectionFilterDlList { CmbCategory = item.Key });
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ManuallEn = true;
            ManualnspectionEN = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Apply Freightkind Filter Data Button
        /// </summary>
        private void FreightkindFilterData()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                ManuallEn = false;
                lstFreightkind = objBl.getManualInsFilterFreightKindList("", gblRegisteration.strLoginUser);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstManualFreightkindFilter.Clear();
                var groupedResult = from s in lstFreightkind
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstManualFreightkindFilter.Add(new ManualInspectionFilterDlList { CmbFreightkind = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstManualFreightkindFilter.Add(new ManualInspectionFilterDlList { CmbFreightkind = item.Key });
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ManuallEn = true;
            ManualnspectionEN = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Apply Filter Button
        /// </summary>
        private void PolFilterData()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                ManuallEn = false;
                lstPol = objBl.getManualInsFilterPolList("", gblRegisteration.strLoginUser);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstManualPolFilter.Clear();
                var groupedResult = from s in lstPol
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstManualPolFilter.Add(new ManualInspectionFilterDlList { CmbPol = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstManualPolFilter.Add(new ManualInspectionFilterDlList { CmbPol = item.Key });
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ManuallEn = true;
            ManualnspectionEN = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Apply POD Filter Data Button
        /// </summary>
        /// <returns></returns>
        private async Task PodFilterData()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                ManuallEn = false;
                lstPod = objBl.getManualInsFilterPodList("", gblRegisteration.strLoginUser);
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstManualPodFilter.Clear();
                var groupedResult = from s in lstPod
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstManualPodFilter.Add(new ManualInspectionFilterDlList { CmbPod = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstManualPodFilter.Add(new ManualInspectionFilterDlList { CmbPod = item.Key });
                }
            }
            catch (Exception ex)
            {
             App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ManualnspectionEN = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Click the Apply Button
        /// </summary>
        /// <returns></returns>
        private async Task ButtondApply()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                ManuallEn = false;
                await Task.Delay(1000);
                var strselectedSize = "";
                var strselectedCarrier = "";
                var strselectedCategory = "";
                var strselectedFreightKind = "";
                var strselectedPol = "";
                var strselectedPod = "";
                var strContainerNo = "";
                var strBayanNo = "";
                var strBOLNo = "";
                if (lstManualSizeFilter.Count > 0)
                {
                    foreach (var item in lstManualSizeFilter)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbSize.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedSize += item.CmbSize + ",";
                            }
                        }
                    }
                }
                if (lstManualCarrierFilter.Count > 0)
                {
                    foreach (var item in lstManualCarrierFilter)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbCarrier.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedCarrier += item.CmbCarrier + ",";
                            }
                        }
                    }
                }
                if (lstManualCategoryFilter.Count > 0)
                {
                    foreach (var item in lstManualCategoryFilter)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbCategory.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedCategory += item.CmbCategory + ",";
                            }
                        }
                    }
                }
                if (lstManualFreightkindFilter.Count > 0)
                {
                    foreach (var item in lstManualFreightkindFilter)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbFreightkind.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedFreightKind += item.CmbFreightkind + ",";
                            }
                        }
                    }
                }
                if (lstManualPolFilter.Count > 0)
                {
                    foreach (var item in lstManualPolFilter)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbPol.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedPol += item.CmbPol + ",";
                            }
                        }
                    }
                }
                if (lstManualPodFilter.Count > 0)
                {
                    foreach (var item in lstManualPodFilter)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbPod.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedPod += item.CmbPod + ",";
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
                if (TxtBillOfLadingNo != null)
                {
                    strBOLNo = TxtBillOfLadingNo;
                }
                if (strselectedSize.Length > 0) strselectedSize = strselectedSize.Substring(0, strselectedSize.Length - 1);
                if (strselectedCarrier.Length > 0) strselectedCarrier = strselectedCarrier.Substring(0, strselectedCarrier.Length - 1);
                if (strselectedCategory.Length > 0) strselectedCategory = strselectedCategory.Substring(0, strselectedCategory.Length - 1);
                if (strselectedFreightKind.Length > 0) strselectedFreightKind = strselectedFreightKind.Substring(0, strselectedFreightKind.Length - 1);
                if (strselectedPol.Length > 0) strselectedPol = strselectedPol.Substring(0, strselectedPol.Length - 1);
                if (strselectedPod.Length > 0) strselectedPod = strselectedPod.Substring(0, strselectedPod.Length - 1);
                // App.Current.MainPage?.Navigation.PushAsync(new Manuallnspection(strContainerNo, strBayanNo, strBOLNo, strselectedSize, strselectedCarrier, strselectedCategory, strselectedFreightKind, strselectedPol, strselectedPod,""));
                await ManualInspectionData("", strContainerNo, strBayanNo, strBOLNo, strselectedSize, strselectedCarrier, strselectedCategory, strselectedFreightKind, strselectedPol, strselectedPod);
                IsVisibleManualInsMain = true;
                IsVisibleManualInsFilter = false;
            }
            catch (Exception ex)
            {
              App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

            ManuallEn = true;
            ManualnspectionEN = true;
            IsBusy = false;
        }
        /// <summary>
        /// click the cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task ButtonCancel()
        {
            try
            {
                IsBusy = true;
                ManualnspectionEN = false;
                ManuallEn = false;
                await Task.Delay(1000);
                IsVisibleManualInsFilter = false;
                IsVisibleManualInsMain = true;
                await PodFilterData();
                SizeFilterData();
                CarrierFilterData();
                CategoryFilterData();
                FreightkindFilterData();
                PolFilterData();
                IsExpandedPOD = false;
                IsExpandedStatus = false;
                IsExpandedSize = false;
                IsExpandedPOL = false;
                IsExpandedCarrier = false;
                IsExpandedCategory = false;
                IsExpandedFreightKind = false;
                TxtContainerNo = "";
                TxtBayanNo = "";
                TxtBillOfLadingNo = "";
                //App.Current.MainPage?.Navigation.PushAsync(new Manuallnspection("", "", "", "", "", "", "", "", "","N"));
                ManuallEn = true;
                ManualnspectionEN = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}
