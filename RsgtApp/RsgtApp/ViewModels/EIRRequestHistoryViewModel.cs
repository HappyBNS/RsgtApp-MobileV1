using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
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
using static RsgtApp.Models.EirRequestHistoryModel;
namespace RsgtApp.ViewModels
{
    public class EIRRequestHistoryViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private string strLanguage = App.gblLanguage;
        [Obsolete]
        public System.Windows.Input.ICommand MyPdftapcont => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command TapEIRrequest { get; set; }
        public Command FilterClicked { get; set; }
        public Command AnywhrerSerch { get; set; }
        public Command ButtonClickedApply { get; set; }
        public Command ButtonClickedCancel { get; set; }
        private string strServerSlowMsg = "";
        private string lstrCaptionALL = "";
      
       // private List<EirRequestHistoryModelDt> objDataSource = new List<EirRequestHistoryModelDt>();
        public event PropertyChangedEventHandler PropertyChanged;
        public int gblRowCount { get; set; }
        public string fintPageNumber = "1";
        private int intTotalCount = 0;
        public string fintPageSize = RSGT_Resource.ResourceManager.GetString("ColletionViewPageSize").ToString().Trim();
     
      
        string fstrOrdrby = "";      
       
        public string gblfilter { get; set; }
        public string gblAnyWhere = "";
        public string gblBlNo { get; set; }
        public string gblContainerNo { get; set; }
        private ObservableCollection<EirRequestHistoryModelDt> _lstrEirRequestHistory = new ObservableCollection<EirRequestHistoryModelDt>();
        public ObservableCollection<EirRequestHistoryModelDt> lstrEirRequestHistory
        {
            get { return _lstrEirRequestHistory; }
            set
            {
                if (_lstrEirRequestHistory == value)
                    return;
                _lstrEirRequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("lstrEirRequestHistory");
            }
        }


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
        //To handle indicator
        private bool stackEIRRequestHistory = true;
        public bool StackEIRRequestHistory
        {
            get { return stackEIRRequestHistory; }
            set
            {
                stackEIRRequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("StackEIRRequestHistory");
            }
        }
        private string _strNoRecord = "";
        public string strNoRecord
        {
            get { return _strNoRecord; }
            set
            {
                _strNoRecord = value;
                OnPropertyChanged();
                RaisePropertyChange("strNoRecord");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string imghistoryIcon = "";
        public string imgHistoryIcon
        {
            get { return imghistoryIcon; }
            set
            {
                imghistoryIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgHistoryIcon");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string lbleIRCopyRequestHistory = "";
        public string lblEIRCopyRequestHistory
        {
            get { return lbleIRCopyRequestHistory; }
            set
            {
                lbleIRCopyRequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRCopyRequestHistory");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string imgsearch = "";
        public string imgSearch
        {
            get { return imgsearch; }
            set
            {
                imgsearch = value;
                OnPropertyChanged();
                RaisePropertyChange("imgSearch");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string imgfilter = "";
        public string imgFilter
        {
            get { return imgfilter; }
            set
            {
                imgfilter = value;
                OnPropertyChanged();
                RaisePropertyChange("imgFilter");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string lblsno = "";
        public string lblSno
        {
            get { return lblsno; }
            set
            {
                lblsno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSno");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string lblcontainerNo = "";
        public string lblContainerNo
        {
            get { return lblcontainerNo; }
            set
            {
                lblcontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerNo");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string lblbillofLading = "";
        public string lblBillofLading
        {
            get { return lblbillofLading; }
            set
            {
                lblbillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBillofLading");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string lblrequestedOn = "";
        public string lblRequestedOn
        {
            get { return lblrequestedOn; }
            set
            {
                lblrequestedOn = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestedOn");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string Lblstatus = "";
        public string LblStatus
        {
            get { return Lblstatus; }
            set
            {
                Lblstatus = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblstatus");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string imgphoto = "";
        public string imgPhoto
        {
            get { return imgphoto; }
            set
            {
                imgphoto = value;
                OnPropertyChanged();
                RaisePropertyChange("imgPhoto");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string imgeIRIconWhite = "";
        public string imgEIRIconWhite
        {
            get { return imgeIRIconWhite; }
            set
            {
                imgeIRIconWhite = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEIRIconWhite");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string lbleIRCopyRequest = "";
        public string lblEIRCopyRequest
        {
            get { return lbleIRCopyRequest; }
            set
            {
                lbleIRCopyRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRCopyRequest");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
        private string imgpdf = "";
        public string imgPdf
        {
            get { return imgpdf; }
            set
            {
                imgpdf = value;
                OnPropertyChanged();
                RaisePropertyChange("imgPdf");
            }
        }
        //lblEIRRequest purpose of using lable varaiable
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
        //imgFilterBlue Filter Captions 
        private string imgfilterBlue = "";
        public string imgFilterBlue
        {
            get { return imgfilterBlue; }
            set
            {
                imgfilterBlue = value;
                OnPropertyChanged();
                RaisePropertyChange("imgFilterBlue");
            }
        }
        //lblFilters purpose of using lable varaiable
        private string lblfilters = "";
        public string lblFilters
        {
            get { return lblfilters; }
            set
            {
                lblfilters = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilters");
            }
        }
        //BtnApply purpose of using button varaiable
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
        private string imgreset = "";
        public string imgReset
        {
            get { return imgreset; }
            set
            {
                imgreset = value;
                OnPropertyChanged();
                RaisePropertyChange("imgReset");
            }
        }
        //lblType purpose of using lable varaiable
        private string lbltype = "";
        public string lblType
        {
            get { return lbltype; }
            set
            {
                lbltype = value;
                OnPropertyChanged();
                RaisePropertyChange("lblType");
            }
        }
        //TxtTicketNo purpose of using Textbox varaiable
        private string txtTicketNo = "";
        public string TxtTicketNo
        {
            get { return txtTicketNo; }
            set
            {
                txtTicketNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTicketNo");
            }
        }
        //imgDownArrow purpose of using image varaiable
        private string imgdownArrow = "";
        public string imgDownArrow
        {
            get { return imgdownArrow; }
            set
            {
                imgdownArrow = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDownArrow");
            }
        }
        //lblSelectAll purpose of using lable varaiable
        private string lblselectAll = "";
        public string lblSelectAll
        {
            get { return lblselectAll; }
            set
            {
                lblselectAll = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSelectAll");
            }
        }
        //lblClaim purpose of using lable varaiable
        private string lblclaim = "";
        public string lblClaim
        {
            get { return lblclaim; }
            set
            {
                lblclaim = value;
                OnPropertyChanged();
                RaisePropertyChange("lblClaim");
            }
        }
        //lblCustomerService purpose of using lable varaiable
        private string lblcustomerService = "";
        public string lblCustomerService
        {
            get { return lblcustomerService; }
            set
            {
                lblcustomerService = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerService");
            }
        }
        //lblLogistics purpose of using lable varaiable
        private string lbllogistics = "";
        public string lblLogistics
        {
            get { return lbllogistics; }
            set
            {
                lbllogistics = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLogistics");
            }
        }
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
        //lblStevedoring purpose of using lable varaiable
        private string lblstevedoring = "";
        public string lblStevedoring
        {
            get { return lblstevedoring; }
            set
            {
                lblstevedoring = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStevedoring");
            }
        }
        //lblCarrier purpose of using lable varaiable
        private string lblcarrier = "";
        public string lblCarrier
        {
            get { return lblcarrier; }
            set
            {
                lblcarrier = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCarrier");
            }
        }
        //imgDownArrow1 purpose of using Image varaiable
        private string imgdownArrow1 = "";
        public string imgDownArrow1
        {
            get { return imgdownArrow1; }
            set
            {
                imgdownArrow1 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDownArrow1");
            }
        }
        //lblSelectAll1 purpose of using lable varaiable
        private string lblselectAll1 = "";
        public string lblSelectAll1
        {
            get { return lblselectAll1; }
            set
            {
                lblselectAll1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSelectAll1");
            }
        }
        //lblMaersk purpose of using lable varaiable
        private string lblmaersk = "";
        public string lblMaersk
        {
            get { return lblmaersk; }
            set
            {
                lblmaersk = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMaersk");
            }
        }
        //lblNYK purpose of using lable varaiable
        private string lblnYK = "";
        public string lblNYK
        {
            get { return lblnYK; }
            set
            {
                lblnYK = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNYK");
            }
        }
        //lblHapagLloyd purpose of using lable varaiable
        private string lblhapagLloyd = "";
        public string lblHapagLloyd
        {
            get { return lblhapagLloyd; }
            set
            {
                lblhapagLloyd = value;
                OnPropertyChanged();
                RaisePropertyChange("lblHapagLloyd");
            }
        }
        //lblEvergreen purpose of using lable varaiable
        private string lblevergreen = "";
        public string lblEvergreen
        {
            get { return lblevergreen; }
            set
            {
                lblevergreen = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEvergreen");
            }
        }
        //lblOOCL purpose of using lable varaiable
        private string lbloOCL = "";
        public string lblOOCL
        {
            get { return lbloOCL; }
            set
            {
                lbloOCL = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOOCL");
            }
        }
        //lblStatus purpose of using lable varaiable
        private string lblstatus = "";
        public string lblStatus
        {
            get { return lblstatus; }
            set
            {
                lblstatus = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStatus");
            }
        }
        //imgDownArrow2 purpose of using Image varaiable
        private string imgdownArrow2 = "";
        public string imgDownArrow2
        {
            get { return imgdownArrow2; }
            set
            {
                imgdownArrow2 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDownArrow2");
            }
        }
        //lblSelectAll2 purpose of using lable varaiable
        private string lblselectAll2 = "";
        public string lblSelectAll2
        {
            get { return lblselectAll2; }
            set
            {
                lblselectAll2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSelectAll2");
            }
        }
        //lblActive purpose of using lable varaiable
        private string lblactive = "";
        public string lblActive
        {
            get { return lblactive; }
            set
            {
                lblactive = value;
                OnPropertyChanged();
                RaisePropertyChange("lblActive");
            }
        }
        //lblResolved purpose of using lable varaiable
        private string lblresolved = "";
        public string lblResolved
        {
            get { return lblresolved; }
            set
            {
                lblresolved = value;
                OnPropertyChanged();
                RaisePropertyChange("lblResolved");
            }
        }
        //TxtBolNo purpose of using Textbox varaiable
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
        //PlaceBolNo purpose of using placeholder varaiable
        private string placeBolNo = "";
        public string PlaceBolNo
        {
            get { return placeBolNo; }
            set
            {
                placeBolNo = value;
                OnPropertyChanged();
                RaisePropertyChange("placeBolNo");
            }
        }
        //TxtContainerNo purpose of using Textbox varaiable
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
        //PlaceContainerNo purpose of using placeholder varaiable
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
        //lblRequestedDate purpose of using lable varaiable
        private string lblrequestedDate = "";
        public string lblRequestedDate
        {
            get { return lblrequestedDate; }
            set
            {
                lblrequestedDate = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestedDate");
            }
        }
        //RequestedDate purpose of using textbox varaiable
        private DateTime? requestedDate = null;
        public DateTime? RequestedDate
        {
            get { return requestedDate; }
            set
            {
                requestedDate = value;
                OnPropertyChanged();
                RaisePropertyChange("RequestedDate");
            }
        }
        //lblValContainerNo purpose of using lable varaiable
        private string lblvalContainerNo = "";
        public string lblValContainerNo
        {
            get { return lblvalContainerNo; }
            set
            {
                lblvalContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValContainerNo");
            }
        }
        //lblValBOLNo purpose of using lable varaiable
        private string lblvalBOLNo = "";
        public string lblValBOLNo
        {
            get { return lblvalBOLNo; }
            set
            {
                lblvalBOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValBOLNo");
            }
        }
        //lblValRequestDate purpose of using lable varaiable
        private string lblvalrequestDate = "";
        public string lblValRequestDate
        {
            get { return lblvalrequestDate; }
            set
            {
                lblvalrequestDate = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValRequestDate");
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
        //TotalRecordCount
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
        private string strTotalCaption = "";
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
                TapEIRrequest.ChangeCanExecute();
                FilterClicked.ChangeCanExecute();
                AnywhrerSerch.ChangeCanExecute();
            }
        }
        //To handle Bool in Expander
        private bool _isExpandedStatus = false;
        public bool IsExpandedStatus
        {
            get { return _isExpandedStatus; }
            set { SetProperty(ref _isExpandedStatus, value); }
        }
        ContentPage Myview;
        public System.Windows.Input.ICommand PhotodetailClicked => new Command<EirRequestHistoryModelDt>(photodetailClicked);
        public ObservableCollection<EITRequesthistoryFilter> lstFilterStatusdata { get; set; } = new ObservableCollection<EITRequesthistoryFilter>();
        Dictionary<string, string> lobjpicStatus = new Dictionary<string, string>();
        public System.Windows.Input.ICommand EIRPDF => new Command<EirRequestHistoryModelDt>(EIRPdf);
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrRequestDate"></param>
        /// <param name="fstrSelectedStatus"></param>
        public EIRRequestHistoryViewModel(string fstrsearch, string fstrContainerNo, string fstrBOLNo, string fstrRequestDate, string fstrSelectedStatus, ContentPage view)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("EIRRequestHistoryViewModel");
            Myview = view;
            fstrsearch = Searchbox;
            Task.Run(() => assignCms()).Wait();
            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;
            TapEIRrequest = new Command(async () => await tapEIRrequest(), () => !IsBusy);
            FilterClicked = new Command(async () => await filterClicked(), () => !IsBusy);
            AnywhrerSerch = new Command(async () => await anywhrerSerch(), () => !IsBusy);
            ButtonClickedApply = new Command(async () => await buttonClickedApply(), () => !IsBusy);
            ButtonClickedCancel = new Command(async () => await buttonClickedCancel(), () => !IsBusy);

            Task.Run(() => EirRequestHistory(Searchbox, fstrContainerNo, fstrBOLNo, fstrRequestDate, fstrSelectedStatus)).Wait();
        }

        /// <summary>
        /// To get filter Clicked
        /// </summary>
        /// <returns></returns>
        private async Task filterClicked()
        {
            try
            {


                IsBusy = true;
                StackEIRRequestHistory = false;
                await Task.Delay(1000);
                IsVisibleMainScreen = false;
                IsVisibleFilterScreen = true;
                RequestedDate = null;
                StackEIRRequestHistory = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To Declare Count Variable
        private int totalRecordCount = 0;

        /// <summary>
        /// to get buttoClicked Cancel
        /// </summary>
        /// <returns></returns>
        private async Task buttonClickedCancel()
        {
            try
            {


                IsBusy = true;
                StackEIRRequestHistory = false;
                await Task.Delay(1000);
                IsVisibleMainScreen = true;
                IsVisibleFilterScreen = false;
                await EirRequestHistory("", "", "", "", "");
                assignCms();
                assignContent();
                IsExpandedStatus = false;
                TxtBolNo = "";
                TxtContainerNo = "";
                //RequestedDate = DateTime.Now.Date.AddDays(-90);
                StackEIRRequestHistory = true;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM452");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM452");
                }
                objCMSMsg = await dbLayer.LoadContent("RM026");
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

            await Task.Delay(1000);

            strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblEIRCopyRequestHistory = dbLayer.getCaption("strEIRCopyampGatePhotoRequestHistory", objCMS);
            imgSearch = dbLayer.getCaption("imgSearch", objCMS);
            imgFilter = dbLayer.getCaption("imgFilter", objCMS);
            lblSno = dbLayer.getCaption("strSno", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNo1", objCMS);
            lblBillofLading = dbLayer.getCaption("strBillofLading1", objCMS);
            lblRequestedOn = dbLayer.getCaption("strRequestedOn", objCMS);
            lblStatus = dbLayer.getCaption("strStatus", objCMS);
            imgPhoto = dbLayer.getCaption("imgPhoto", objCMS);
            imgEIRIconWhite = dbLayer.getCaption("imgEIRiconwhite", objCMS);
            lblEIRCopyRequest = dbLayer.getCaption("strEIRCopyampGatePhotoRequest", objCMS);
            strTotalCaption = cms.getCaption("strEirCopyRequestHeading", objCMS);
            imgPdf = dbLayer.getCaption("imgPdf", objCMS);
            //Filter Page
            PlaceBolNo = dbLayer.getCaption("strBillofLading1", objCMS);
            PlaceContainerNo = dbLayer.getCaption("strContainerNo1", objCMS);
            lblRequestedDate = dbLayer.getCaption("strRequestedOn", objCMS);
            lobjpicStatus = dbLayer.getLOV("strStatusLov", objCMS);
            imgFilterBlue = dbLayer.getCaption("imgFilterblue", objCMS);
            lblFilters = dbLayer.getCaption("strFilters", objCMS);
            BtnApply = dbLayer.getCaption("strApply", objCMS);
            imgReset = dbLayer.getCaption("imgReset", objCMS);
            lblType = dbLayer.getCaption("strType", objCMS);
            imgDownArrow = dbLayer.getCaption("imgDown", objCMS);
            lblSelectAll = dbLayer.getCaption("strSelectAll", objCMS);
            lblClaim = dbLayer.getCaption("strClaim", objCMS);
            lblCustomerService = dbLayer.getCaption("strCustomerService", objCMS);
            lblLogistics = dbLayer.getCaption("strLogistics", objCMS);
            lblStevedoring = dbLayer.getCaption("strStevedoring", objCMS);
            lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
            imgDownArrow1 = dbLayer.getCaption("imgDown", objCMS);
            lblSelectAll1 = dbLayer.getCaption("strSelectAll", objCMS);
            lblMaersk = dbLayer.getCaption("strMaersk", objCMS);
            lblNYK = dbLayer.getCaption("strNYK", objCMS);
            lblHapagLloyd = dbLayer.getCaption("strHapagLloyd", objCMS);
            lblEvergreen = dbLayer.getCaption("strEvergreen", objCMS);
            lblOOCL = dbLayer.getCaption("strOOCL", objCMS);
            lblStatus = dbLayer.getCaption("strStatus", objCMS);
            imgDownArrow2 = dbLayer.getCaption("imgDown", objCMS);
            lblSelectAll2 = dbLayer.getCaption("strSelectAll", objCMS);
            lblActive = dbLayer.getCaption("strActive", objCMS);
            lblResolved = dbLayer.getCaption("strResolved", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            PlaceSearch = dbLayer.getCaption("strContainerNo1", objCMS) + "/" + dbLayer.getCaption("strBillofLading1", objCMS) + "/" + dbLayer.getCaption("strRequestedOn", objCMS) + "/" + dbLayer.getCaption("strStatus", objCMS); //20230324-Sanduru
            lstFilterStatusdata.Clear();
            //lstFilterStatusdata.Add(new EITRequesthistoryFilter { gkStatus = lstrCaptionALL });
            foreach (var dic in lobjpicStatus)
            {
                lstFilterStatusdata.Add(new EITRequesthistoryFilter { gkStatus = dic.Key }); ;
            }
        }
        /// <summary>
        /// To open Pdf
        /// </summary>
        /// <param name="fstrUrl"></param>
        private async void openPdf(string fstrUrl)
        {
            await Task.Delay(1000);
            //Device.OpenUri(new Uri("http://example.com"));
            await Browser.OpenAsync(fstrUrl, BrowserLaunchMode.SystemPreferred);
        }
        /// <summary>
        /// To go to EIRPdf
        /// </summary>
        /// <param name="fobjEIR"></param>
        private async void EIRPdf(EirRequestHistoryModelDt fobjEIR)
        {
            IsBusy = true;
            StackEIRRequestHistory = false;
            await Task.Delay(1000);
            //EIR copy Request
            string strURL = AppSettings.MobWebUrl;
            gblContainerNo = fobjEIR.gpr_containernumber;
            gblBlNo = fobjEIR.gpr_blnumber;
            string fstrTruckNo = fobjEIR.gpr_licenseno;
            var pdfUrl = strURL + "/EIRCopyRequestForm/OpenPDF?" + "fstrContainerNo=" + gblContainerNo + "&fstrBlnNo=" + gblBlNo + "&fstrTruckNo=" + fstrTruckNo + "";
            openPdf(pdfUrl);
            StackEIRRequestHistory = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get EIR Request
        /// </summary>
        /// <returns></returns>
        private async Task tapEIRrequest()
        {
            IsBusy = true;
            StackEIRRequestHistory = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new EIR_Request_step1());
            StackEIRRequestHistory = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to EirRequestHistory
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrRequestDate"></param>
        /// <param name="fstrSelectedStatus"></param>
        /// <returns></returns>
        private async Task EirRequestHistory(string fstrSearchbox, string fstrContainerNo, string fstrBOLNo, string fstrRequestDate, string fstrSelectedStatus)
        {
            IsBusy = true;
            StackEIRRequestHistory = false;
            await Task.Delay(1000);
            string lstrAnyWhere = "";
            string lstrContainerNo = "";
            string lstrBOLNo = "";
            string lstrRequestedOn = "";
            string lstrStatus = "";
           
            if (fstrSearchbox != null) lstrAnyWhere = fstrSearchbox;
            if (fstrContainerNo != null) lstrContainerNo = fstrContainerNo;
            if (fstrBOLNo != null) lstrBOLNo = fstrBOLNo;
            if (fstrRequestDate != null) lstrRequestedOn = fstrRequestDate;
            if (fstrSelectedStatus != null) lstrStatus = fstrSelectedStatus;
            
            gblfilter = "";
            gblfilter += "fstrAnyWhere:" + lstrAnyWhere + ";" + "fstrContainerNo:" + lstrContainerNo + ";" + "fstrBOLNo:" + lstrBOLNo + ";" + "fstrRequestDate:" + lstrRequestedOn + ";" + "fstrStatus:" + lstrStatus + ";";
            lstrEirRequestHistory.Clear();
            // string fstrFilter = "fstrFilter" = fstrAnyWhere:; fstrContainerNo:; fstrBOLNo:; fstrRequestDate:; fstrStatus:;
            var objDataSource = new List<EirRequestHistoryModelDt>();
            objDataSource = objBl.getEirRequestHistory(gblfilter, fintPageNumber, fintPageSize, fstrOrdrby);
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }

            await Task.Delay(1000);
            foreach (var item in objDataSource)
            {
                item.lblSno = lblsno;
                item.lblContainerNo = lblcontainerNo;
                item.lblBillofLading = lblbillofLading;
                item.lblRequestedOn = lblrequestedOn;
                item.lblStatus = lblstatus;
                item.imgPhoto = imgphoto;
                item.imgPdf = imgpdf;
                item.imgHistoryIcon = imghistoryIcon;
               // lstrEirRequestHistory.Add(item);
            }
            lstrEirRequestHistory = new ObservableCollection<EirRequestHistoryModelDt>(objDataSource);
            totalRecordCount = objDataSource.Count;
            TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
            if (lstrEirRequestHistory.Count > 0)
            {
                CollectionView cvEIRRequestHistory = Myview.FindByName<CollectionView>("GridEIRRequestHistory");
                cvEIRRequestHistory.ItemsSource = null;
                cvEIRRequestHistory.ItemsSource = lstrEirRequestHistory;
                cvEIRRequestHistory.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
            }

            if (lstrEirRequestHistory == null || lstrEirRequestHistory.Count == 0)
            {
               App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
            }

            await Task.Delay(1000);
            StackEIRRequestHistory = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to AnywhereSerch
        /// </summary>
        /// <returns></returns>
        private async Task anywhrerSerch()
        {
            IsBusy = true;
            StackEIRRequestHistory = false;
            await Task.Delay(1000);
            await EirRequestHistory(Searchbox, "", "", "", "");
            StackEIRRequestHistory = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to PhotodetailClicked
        /// </summary>
        /// <param name="fobjEIR"></param>
        private async void photodetailClicked(EirRequestHistoryModelDt fobjEIR)
        {
            IsBusy = true;
            StackEIRRequestHistory = false;
            await Task.Delay(1000);
            string ContainerNo = fobjEIR.gpr_containernumber;
            string BOLNo = fobjEIR.gpr_blnumber;
            string TruckNo = fobjEIR.gpr_licenseno;
            string RequestDt = fobjEIR.gpr_requesteddate;

            if (fobjEIR.gpr_photosflag == "Y")
            {

                await App.Current.MainPage?.Navigation.PushAsync(new EIRRequestPhotoMessage(ContainerNo, BOLNo, TruckNo, RequestDt));
            }
            else
            {
                await App.Current.MainPage?.Navigation.PushAsync(new EIRRequestMsg());
            }
            StackEIRRequestHistory = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get button Clicked Apply
        /// </summary>
        /// <returns></returns>
        private async Task buttonClickedApply()
        {
            IsBusy = true;
            StackEIRRequestHistory = false;
            await Task.Delay(1000);
            var strBOLNo = "";
            var strContainerNo = "";
            var strRequestedDate = "";
            var strSelectedStatus = "";
            if (lstFilterStatusdata.Count > 0)
            {
                foreach (var item in lstFilterStatusdata)
                {
                    if (item.isChecked == true)
                    {
                        if (item.gkStatus.ToString().Trim().ToUpper() != "ALL")
                        {
                            strSelectedStatus += item.gkStatus + ",";
                        }
                    }
                }
            }
            if (TxtBolNo != null)
            {
                strBOLNo = TxtBolNo;
            }
            if (TxtContainerNo != null)
            {
                strContainerNo = TxtContainerNo;
            }
            if (RequestedDate != null)
            {
                strRequestedDate = RequestedDate.Value.ToString("yyyy-MM-dd");
            }
            if (strSelectedStatus.Length > 0) strSelectedStatus = strSelectedStatus.Substring(0, strSelectedStatus.Length - 1);
            await EirRequestHistory("", strContainerNo, strBOLNo, strRequestedDate, strSelectedStatus);
            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;
            StackEIRRequestHistory = true;
            IsBusy = false;
        }

    }

}