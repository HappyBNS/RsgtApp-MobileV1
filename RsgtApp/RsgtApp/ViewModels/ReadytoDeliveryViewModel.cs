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
using static RsgtApp.Models.ReadytoDeliveryModel;

namespace RsgtApp.ViewModels
{
    class ReadytoDeliveryViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        public Command gotoAnySearch { get; set; }
        //Filter_Clicked Button 
        public Command Filter_Clicked { get; set; }
        //gotoLoadMore Button 
        public Command gotoLoadMore { get; set; }
        //gotoApply Butttion
        public Command gotoApply { get; set; }
        //gotoReset Buttion 
        public Command gotoReset { get; set; }
        //Button_ClickedCancel Button
        public Command Button_ClickedCancel { get; set; }
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //public ObservableCollection<ReadytodeliverDt> lstReadytoDeliverlist { get; }
        public ObservableCollection<ReadytodeliverDt> lstReadytoDeliverlist { get; set; } = new ObservableCollection<ReadytodeliverDt>();
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
        private int fintPageSize = 1000;
        private int fintPageNo = 1;
        private string lstrCaptionALL = "";
        private string strTotalCaption = "";
        string strNoRecord = "";
        string lblSno = "";
        string lblStatus = "";
        string lblSize = "";
        string lblBayan = "";
        string lblContainerNo = "";
        string lblBOL = "";
        string lblCarrier = "";
        string lblVessel = "";
        string lblVoyage = "";
        string lblCategory = "";
        string lblPOL = "";
        string lblPOD = "";
        string lblFreightkind = "";
        string lblTimeIn = "";
        string btnBookAppoint = "";
        string strServerSlowMsg = "";
        string btnLoadMore = "";
        //Assign Property Two way Binding
        //Two way Binding Variable
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
                RaisePropertyChange("EnumCarrier");
            }
        }

        // enumCategory  combo variable
        private string enumCategory = "";
        public string EnumCategory
        {
            get { return enumCategory; }
            set
            {
                enumCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumCategory");
            }
        }

        // enumFreight  combo variable
        private string enumFreight = "";
        public string EnumFreight
        {
            get { return enumFreight; }
            set
            {
                enumFreight = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumFreight");
            }
        }

        // enumPOL  combo variable
        private string enumPOL = "";
        public string EnumPOL
        {
            get { return enumPOL; }
            set
            {
                enumPOL = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumPOL");
            }
        }

        // enumPOD  combo variable
        private string enumPOD = "";
        public string EnumPOD
        {
            get { return enumPOD; }
            set
            {
                enumPOD = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumPOD");
            }
        }

        //strContainerNo purpose of using textbox varaiable
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

        //strBayan purpose of using textbox varaiable
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

        //txtBOLNo purpose of using textbox varaiable
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

        //txtBillLadingNo purpose of using textbox varaiable
        private string txtBillLadingNo = "";
        public string TxtBillLadingNo
        {
            get { return txtBillLadingNo; }
            set
            {
                txtBillLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBillLadingNo");
            }
        }

        //imgReadytoloadIcon purpose of using image varaiable
        private string imgReadytoloadIcon = "";
        public string ImgReadytoloadIcon
        {
            get { return imgReadytoloadIcon; }
            set
            {
                imgReadytoloadIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgReadytoloadIcon");
            }
        }

        //placeSearch purpose of using textbox varaiable
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

        //placeSearch purpose of using image varaiable
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

        //placeSearch purpose of using image varaiable
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

        //placeSearch purpose of using textbox varaiable
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

        //placeSearch purpose of using image varaiable
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

        //placeSearch purpose of using label varaiable
        private string iblFilters = "";
        public string LblFilters
        {
            get { return iblFilters; }
            set
            {
                iblFilters = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFilters");
            }
        }

        //placeSearch purpose of using textbox varaiable
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

        //placeSearch purpose of using image varaiable
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

        //placeSearch purpose of using textbox varaiable
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

        //placeSearch purpose of using image varaiable
        private string imgDownar = "";
        public string ImgDownar
        {
            get { return imgDownar; }
            set
            {
                imgDownar = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownar");
            }
        }

        //placeSearch purpose of using textbox varaiable
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

        //placeSearch purpose of using image varaiable
        private string imgDownRow = "";
        public string ImgDownRow
        {
            get { return imgDownRow; }
            set
            {
                imgDownRow = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownRow");
            }
        }

        //placeSearch purpose of using textbox varaiable
        private string filterCategory = "";
        public string FilterCategory
        {
            get { return filterCategory; }
            set
            {
                filterCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterCategory");
            }
        }

        //placeSearch purpose of using image varaiable
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

        //placeSearch purpose of using textbox varaiable
        private string filterFreight = "";
        public string FilterFreight
        {
            get { return filterFreight; }
            set
            {
                filterFreight = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterFreight");
            }
        }

        //placeSearch purpose of using image varaiable
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

        //filterPOL purpose of using textbox varaiable
        private string filterPOL = "";
        public string FilterPOL
        {
            get { return filterPOL; }
            set
            {
                filterPOL = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterPOL");
            }
        }

        //imgDowns purpose of using image varaiable
        private string imgDowns = "";
        public string ImgDowns
        {
            get { return imgDowns; }
            set
            {
                imgDowns = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDowns");
            }
        }

        //filterPOD purpose of using textbox varaiable
        private string filterPOD = "";
        public string FilterPOD
        {
            get { return filterPOD; }
            set
            {
                filterPOD = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterPOD");
            }
        }

        //imgDownArrs purpose of using image varaiable
        private string imgDownArrs = "";
        public string ImgDownArrs
        {
            get { return imgDownArrs; }
            set
            {
                imgDownArrs = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrs");
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

        //placeBillLading purpose of using textbox varaiable
        private string placeBillLading = "";
        public string PlaceBillLading
        {
            get { return placeBillLading; }
            set
            {
                placeBillLading = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBillLading");
            }
        }
        //Hide Show Main page
        private bool isVisibleRTDMain = false;
        public bool IsVisibleRTDMain
        {
            get { return isVisibleRTDMain; }
            set
            {
                isVisibleRTDMain = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleRTDMain");
            }
        }
        //Hide Show Filter page
        private bool isVisibleRTDFilter = false;
        public bool IsVisibleRTDFilter
        {
            get { return isVisibleRTDFilter; }
            set
            {
                isVisibleRTDFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleRTDFilter");
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
        //To handle Boolen variable
        bool readytoDeliveryEn = true;
        public bool ReadytoDeliveryEn
        {
            get { return readytoDeliveryEn; }
            set
            {
                readytoDeliveryEn = value;
                OnPropertyChanged();
                RaisePropertyChange("ReadytoDeliveryEn");
            }
        }
        private string strsearchbox = "";
        public string strSearchbox
        {
            get { return strsearchbox; }
            set
            {
                strsearchbox = value;
                OnPropertyChanged();
                RaisePropertyChange("strSearchbox");
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

        private bool _isExpandedFreight = false;
        public bool IsExpandedFreight
        {
            get { return _isExpandedFreight; }
            set { SetProperty(ref _isExpandedFreight, value); }
        }

        private bool _isExpandedPOL = false;
        public bool IsExpandedPOL
        {
            get { return _isExpandedPOL; }
            set { SetProperty(ref _isExpandedPOL, value); }
        }

        private bool _isExpandedPOD = false;
        public bool IsExpandedPOD
        {
            get { return _isExpandedPOD; }
            set { SetProperty(ref _isExpandedPOD, value); }
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
                gotoAnySearch.ChangeCanExecute();
                Filter_Clicked.ChangeCanExecute();
                gotoLoadMore.ChangeCanExecute();
                //gotoBookAppoinment.ChangeCanExecute();
                gotoApply.ChangeCanExecute();
                gotoReset.ChangeCanExecute();
                Button_ClickedCancel.ChangeCanExecute();
            }
        }
        ContentPage Myview;
        //ObservableCollection use to Data Binding list
        public ObservableCollection<ReadytoDeliveryFilterDlList> lstFilterCarrierData { get; set; } = new ObservableCollection<ReadytoDeliveryFilterDlList>();
        List<clsReadytoDeliveryCategoryFilter> lstCategory = new List<clsReadytoDeliveryCategoryFilter>();
        public ObservableCollection<ReadytoDeliveryFilterDlList> lstFilterCategoryData { get; set; } = new ObservableCollection<ReadytoDeliveryFilterDlList>();
        List<clsReadytoDeliverySizeFilter> lstSize = new List<clsReadytoDeliverySizeFilter>();
        public ObservableCollection<ReadytoDeliveryFilterDlList> lstFilterSizeData { get; set; } = new ObservableCollection<ReadytoDeliveryFilterDlList>();
        List<clsReadytoDeliveryFreightFilter> lstFreight = new List<clsReadytoDeliveryFreightFilter>();
        public ObservableCollection<ReadytoDeliveryFilterDlList> lstFilterFreightData { get; set; } = new ObservableCollection<ReadytoDeliveryFilterDlList>();
        List<clsReadytoDeliveryPOLFilter> lstPOL = new List<clsReadytoDeliveryPOLFilter>();
        public ObservableCollection<ReadytoDeliveryFilterDlList> lstFilterPOLData { get; set; } = new ObservableCollection<ReadytoDeliveryFilterDlList>();
        List<clsReadytoDeliveryPODFilter> lstPOD = new List<clsReadytoDeliveryPODFilter>();
        public ObservableCollection<ReadytoDeliveryFilterDlList> lstFilterPODData { get; set; } = new ObservableCollection<ReadytoDeliveryFilterDlList>();
        public System.Windows.Input.ICommand gotoBookAppoinment => new Command<ReadytodeliverDt>(BookAppoinment);
        //Begin-ViewModel Constructor 
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public ReadytoDeliveryViewModel(string strSearchbox, string strslectedSize, string strselectedCarrier, string strselsctedCategory, string strselectedFreightkind, string strselectedPOL, string strselectedPOD, string strselectedContainerNo, string strselectedBayanNo, string strselectedBOLNo, string fstrFilterFlag, ContentPage view)
        {
            try
            {
                Analytics.TrackEvent("ReadytoDeliveryViewModel");
                Myview = view;
                IsVisibleRTDFilter = false;
                IsVisibleRTDMain = false;
                if (fstrFilterFlag == "N")
                {
                    IsVisibleRTDMain = true;
                    IsVisibleRTDFilter = false;
                }
                if (fstrFilterFlag == "Y")
                {
                    IsVisibleRTDMain = false;
                    IsVisibleRTDFilter = true;
                }
                strTotalCaption = "";
               
                searchbox = strSearchbox;
                //Begin-All Command Buttons
                gotoAnySearch = new Command(async () => await ReadyAnyWhere(), () => !IsBusy);
                Filter_Clicked = new Command(async () => await Readyfilter(), () => !IsBusy);
                gotoLoadMore = new Command(async () => await ReadytoList(strSearchbox, strslectedSize, strselectedCarrier, strselsctedCategory, strselectedFreightkind, strselectedPOL, strselectedPOD, strselectedContainerNo, strselectedBayanNo, strselectedBOLNo), () => !IsBusy);
                gotoReset = new Command(async () => await Clear(), () => !IsBusy);
                Button_ClickedCancel = new Command(async () => await Clear(), () => !IsBusy);
                gotoApply = new Command(async () => await gotodApplybutton(), () => !IsBusy);
                //End-All Command Buttons
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function                

                Task.Run(() => assignContent()).Wait();
                Task.Run(() => SizeFilterData()).Wait();
                Task.Run(() => CarrierFilterData()).Wait();
                Task.Run(() => CategoryFilterData()).Wait();
                Task.Run(() => FreightFilterData()).Wait();
                Task.Run(() => POLFilterData()).Wait();
                Task.Run(() => PODFilterData()).Wait();
                //Begin-Call Filter Get Funtion

                //End-Call Filter Get Funtion


                //Begin-Call Listview Get Funtion
                Task.Run(() => ReadytoList(strSearchbox, strslectedSize, strselectedCarrier, strselsctedCategory, strselectedFreightkind, strselectedPOL, strselectedPOD, strselectedContainerNo, strselectedBayanNo, strselectedBOLNo)).Wait();
                //End-Call Listview Get Funtion
                if (lstReadytoDeliverlist == null || lstReadytoDeliverlist.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);

            }
        }

        //End-ViewModel Constructor 
        /// <summary>
        /// To Navigate Ready Filter Page
        /// </summary>

        private async Task Readyfilter()
        {
            try
            {
                IsBusy = true;
                ReadytoDeliveryEn = false;
                await Task.Delay(1000);

                IsVisibleRTDMain = false;
                IsVisibleRTDFilter = true;

                ReadytoDeliveryEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        ///  To Navigate Ready AnyWhere Page
        /// </summary>
        private async Task ReadyAnyWhere()
        {
            try
            {
                IsBusy = true;
                ReadytoDeliveryEn = false;
                await Task.Delay(1000);
                //Application.Current.MainPage?.Navigation.PushAsync(new ReadytoDelivery(searchbox, "", "", "", "", "", "", "", "", ""));
                LfintPageNo = 1;
                await ReadytoList(Searchbox, "", "", "", "", "", "", "", "", "");
                ReadytoDeliveryEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }

        }
        //End-ViewModel Constructor 
        /// <summary>
        ///  To Clear the data
        /// </summary>
        public async Task Clear()
        {
            try
            {
                IsBusy = true;
                ReadytoDeliveryEn = false;
                await Task.Delay(1000);
                await ReadytoList("", "", "", "", "", "", "", "", "", "");
                await SizeFilterData();
                await CarrierFilterData();
                await CategoryFilterData();
                await FreightFilterData();
                await POLFilterData();
                await PODFilterData();
                IsExpandedCategory = false;
                IsExpandedCarrier = false;
                IsExpandedFreight = false;
                IsExpandedPOD = false;
                IsExpandedPOL = false;
                IsExpandedSize = false;
                TxtContainerNo = "";
                TxtBayanNo = "";
                TxtBillLadingNo = "";
                IsVisibleRTDMain = true;
                IsVisibleRTDFilter = false;

                ReadytoDeliveryEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }


        }
        /// <summary>
        /// To Book Appoinment
        /// </summary>

        private async void BookAppoinment(ReadytodeliverDt FobjReadytodeliver)
        {
            try
            {
                IsBusy = true;
                ReadytoDeliveryEn = false;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new AppointmentBooking("", "", "", "", "", "", "", "N"));
                ReadytoDeliveryEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// To Get the Listview Data
        /// </summary>

        private async Task ReadytoList(string strSearchbox, string strslectedSize, string strselectedCarrier, string strselsctedCategory, string strselectedFreightkind, string strselectedPOL, string strselectedPOD, string strselectedContainerNo, string strselectedBayanNo, string strselectedBOLNo)
        {
            try
            {
                IsBusy = true;
                ReadytoDeliveryEn = false;
                string gblAnyWhere = "";
                string lstrContainerNo = "";
                string lstrBayanNo = "";
                string lstrBOLNo = "";
                string lstrSize = "";
                string lstrCarrier = "";
                string lstrCategory = "";
                string lstrFreight = "";
                string lstrPOL = "";
                string lstrPOD = "";
                if (strSearchbox != null) gblAnyWhere = strSearchbox;
                if (strslectedSize != null) lstrSize = strslectedSize;
                if (strselectedCarrier != null) lstrCarrier = strselectedCarrier;
                if (strselsctedCategory != null) lstrCategory = strselsctedCategory;
                if (strselectedFreightkind != null) lstrFreight = strselectedFreightkind;
                if (strselectedPOL != null) lstrPOL = strselectedPOL;
                if (strselectedPOD != null) lstrPOD = strselectedPOD;
                if (strselectedContainerNo != null) lstrContainerNo = strselectedContainerNo;
                if (strselectedBayanNo != null) lstrBayanNo = strselectedBayanNo;
                if (strselectedBOLNo != null) lstrBOLNo = strselectedBOLNo;

                var objRawData = new List<ReadytodeliverDt>();
                lstReadytoDeliverlist.Clear();
                string strFilterData = "fstrAnyWhere:" + gblAnyWhere + ";" + "fstrContainernumber:" + lstrContainerNo + ";" + "fstrBayannumber:" + lstrBayanNo + ";" + "fstrBLNumber:" + lstrBOLNo + ";" + "fstrSize:" + lstrSize + ";" + "fstrcarrier:" + lstrCarrier + ";" + "fstrCategory:" + lstrCategory + ";" + "fstrFreightKind:" + lstrFreight + ";" + "fstrPOL:" + lstrPOL + ";" + "fstrPOD:" + lstrPOD + ";";
                //To call bussinesslayer 
                objRawData = objBl.getReadyToDeliveryDetails(gblRegisteration.strLoginUser, fintPageNo, fintPageSize, strFilterData);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                await Task.Delay(1000);
                foreach (var item in objRawData)
                {
                    item.lblSno = lblSno;
                    item.lblStatus = lblStatus;
                    item.lblSize = lblSize;
                    item.lblBayan = lblBayan;
                    item.lblContainerNo = lblContainerNo;
                    item.lblBOL = lblBOL;
                    item.lblCarrier = lblCarrier;
                    item.lblVessel = lblVessel;
                    item.lblVoyage = lblVoyage;
                    item.lblCategory = lblCategory;
                    item.lblPOL = lblPOL;
                    item.lblPOD = lblPOD;
                    item.lblFreightkind = lblFreightkind;
                    item.lblTimeIn = lblTimeIn;
                    item.btnBookAppoint = btnBookAppoint;
                    // lstReadytoDeliverlist.Add(item);
                }
                lstReadytoDeliverlist = new ObservableCollection<ReadytodeliverDt>(objRawData);
                totalRecordCount = objRawData.Count.ToString();
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                if (lstReadytoDeliverlist.Count > 0)
                {
                    CollectionView cvReadttoDelivery = Myview.FindByName<CollectionView>("GridReadttoDelivery");
                    cvReadttoDelivery.ItemsSource = null;
                    cvReadttoDelivery.ItemsSource = lstReadytoDeliverlist;
                    cvReadttoDelivery.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                }
                if (lstReadytoDeliverlist == null || lstReadytoDeliverlist.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }

            ReadytoDeliveryEn = true;
            IsBusy = false;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM409");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM409");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
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

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}

                dbLayer.objInfoitems = objCMS;
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                lblSize = dbLayer.getCaption("strSize", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS);
                lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                lblBOL = dbLayer.getCaption("strBillofLading", objCMS);
                lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
                lblVessel = dbLayer.getCaption("strVessel", objCMS);
                lblVoyage = dbLayer.getCaption("strVoyage", objCMS);
                lblCategory = dbLayer.getCaption("strCategory", objCMS);
                lblPOL = dbLayer.getCaption("strPOL", objCMS);
                lblPOD = dbLayer.getCaption("strPOD", objCMS);
                lblFreightkind = dbLayer.getCaption("strFreightKind", objCMS);
                lblTimeIn = dbLayer.getCaption("strTimeIn", objCMS);
                btnBookAppoint = dbLayer.getCaption("strBookLoadingAppointment", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                strTotalCaption = cms.getCaption("strReadytoDeliver", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                ImgReadytoloadIcon = dbLayer.getCaption("imgReadytoload", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                ImgSearch = dbLayer.getCaption("imgSearch", objCMS);
                ImgFilter = dbLayer.getCaption("imgFilter", objCMS);
                PlaceSearch = dbLayer.getCaption("StrReadyToDeliverPlaceHolder", objCMS);
                LoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                ImgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                LblFilters = dbLayer.getCaption("strFilters", objCMS);
                BtnApply = dbLayer.getCaption("strApply", objCMS);
                ImgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterSize = dbLayer.getCaption("strSize", objCMS);
                ImgDownar = dbLayer.getCaption("imgDown", objCMS);
                FilterCarrier = dbLayer.getCaption("strCarrier", objCMS);
                ImgDownRow = dbLayer.getCaption("imgDown", objCMS);
                FilterCategory = dbLayer.getCaption("strCategory", objCMS);
                ImgDown = dbLayer.getCaption("imgDown", objCMS);
                FilterFreight = dbLayer.getCaption("strFreightKind", objCMS);
                ImgArrows = dbLayer.getCaption("imgDown", objCMS);
                FilterPOL = dbLayer.getCaption("strPOL", objCMS);
                ImgDowns = dbLayer.getCaption("imgDown", objCMS);
                FilterPOD = dbLayer.getCaption("strPOD", objCMS);
                ImgDownArrs = dbLayer.getCaption("imgDown", objCMS);
                PlaceContainer = dbLayer.getCaption("strContainerNo", objCMS);
                PlaceBayan = dbLayer.getCaption("strBayanNo", objCMS);
                PlaceBillLading = dbLayer.getCaption("strBillofLadingNo", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        //To Apply Filter Button
        /// <summary>
		/// To Apply Filter Button
		/// </summary>
        private async Task gotodApplybutton()
        {
            IsBusy = true;
            ReadytoDeliveryEn = false;

            await Task.Delay(1000);
            var strslectedSize = "";
            var strselectedCarrier = "";
            var strselsctedCategory = "";
            var strselectedFreightkind = "";
            var strselectedPOL = "";
            var strselectedPOD = "";
            var strselectedContainerNo = "";
            var strselectedBayanNo = "";
            var strselectedBOLNo = "";
            try
            {
                if (lstFilterSizeData.Count > 0)
                {
                    foreach (var item in lstFilterSizeData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbSize.ToString().ToUpper().Trim() != "ALL")
                            {
                                strslectedSize += item.CmbSize + ",";
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
                                strselectedCarrier += item.CmbCarrier + ",";
                            }
                        }
                    }
                }
                if (lstFilterCategoryData.Count > 0)
                {
                    foreach (var item in lstFilterCategoryData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbCategory.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselsctedCategory += item.CmbCategory + ",";
                            }
                        }
                    }
                }
                if (lstFilterFreightData.Count > 0)
                {
                    foreach (var item in lstFilterFreightData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbFreight.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedFreightkind += item.CmbFreight + ",";
                            }
                        }
                    }
                }
                if (lstFilterPOLData.Count > 0)
                {
                    foreach (var item in lstFilterPOLData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbPOL.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedPOL += item.CmbPOL + ",";
                            }
                        }
                    }
                }
                if (lstFilterPODData.Count > 0)
                {
                    foreach (var item in lstFilterPODData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbPOD.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedPOD += item.CmbPOD + ",";
                            }
                        }
                    }
                }
                if (txtContainerNo != null)
                {
                    strselectedContainerNo = txtContainerNo.Trim();
                }
                if (txtBayanNo != null)
                {
                    strselectedBayanNo = txtBayanNo.Trim();
                }
                if (txtBillLadingNo != null)
                {
                    strselectedBOLNo = txtBillLadingNo.Trim();
                }

                if (strslectedSize.Length > 0) strslectedSize = strslectedSize.Substring(0, strslectedSize.Length - 1);
                if (strselectedCarrier.Length > 0) strselectedCarrier = strselectedCarrier.Substring(0, strselectedCarrier.Length - 1);
                if (strselsctedCategory.Length > 0) strselsctedCategory = strselsctedCategory.Substring(0, strselsctedCategory.Length - 1);
                if (strselectedFreightkind.Length > 0) strselectedFreightkind = strselectedFreightkind.Substring(0, strselectedFreightkind.Length - 1);
                if (strselectedPOL.Length > 0) strselectedPOL = strselectedPOL.Substring(0, strselectedPOL.Length - 1);
                if (strselectedPOD.Length > 0) strselectedPOD = strselectedPOD.Substring(0, strselectedPOD.Length - 1);
                await ReadytoList("", strslectedSize, strselectedCarrier, strselsctedCategory, strselectedFreightkind, strselectedPOL, strselectedPOD, strselectedContainerNo, strselectedBayanNo, strselectedBOLNo);
                IsVisibleRTDFilter = false;
                IsVisibleRTDMain = true;
                // string fstrSize, string fstrCarrier, string fstrCategory, string fstrFreight, string fstrPOL, string fstrPOD, string fstrContainerNo, string fstrBayanNo, string fstrBOLNo
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ReadytoDeliveryEn = true;
            IsBusy = false;
        }


        /// <summary>
        /// To get Carrier Filter Data 
        /// </summary>
        private async Task CarrierFilterData()
        {
            List<clsReadytoDeliveryCarrierFilter> lstCarrier = new List<clsReadytoDeliveryCarrierFilter>();

            lstCarrier = objBl.getReadytoDeliveryFilterCarrierList(gblRegisteration.strLoginUser, "");
            lstFilterCarrierData.Clear();
            var groupedResult = from s in lstCarrier
                                group s by s.text;
            try
            {
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterCarrierData.Add(new ReadytoDeliveryFilterDlList { CmbCarrier = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterCarrierData.Add(new ReadytoDeliveryFilterDlList { CmbCarrier = item.Key });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }

        //To Get Catagory Filter Data
        /// <summary>
        /// To get Catagory Filter Data 
        /// </summary>
        private async Task CategoryFilterData()
        {
            try
            {
                lstCategory = objBl.getReadytoDeliveryFilterCategoryList(gblRegisteration.strLoginUser, "");
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                lstFilterCategoryData.Clear();
                var groupedResult = from s in lstCategory
                                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterCategoryData.Add(new ReadytoDeliveryFilterDlList { CmbCategory = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterCategoryData.Add(new ReadytoDeliveryFilterDlList { CmbCategory = item.Key });
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        //To get Size Filter Data
        /// <summary>
        /// To get Size Filter Data 
        /// </summary>
        private async Task SizeFilterData()
        {
            lstSize = objBl.getReadytoDeliveryFilterSizeList(gblRegisteration.strLoginUser, "");
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            lstFilterSizeData.Clear();
            var groupedResult = from s in lstSize
                                group s by s.text;
            try
            {
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterSizeData.Add(new ReadytoDeliveryFilterDlList { CmbSize = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterSizeData.Add(new ReadytoDeliveryFilterDlList { CmbSize = item.Key });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        //To get Freight Filter Data
        /// <summary>
        /// To get Freight Filter Data 
        /// </summary>
        private async Task FreightFilterData()
        {
            lstFreight = objBl.getReadytoDeliveryFilterFreightList(gblRegisteration.strLoginUser, "");
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            lstFilterFreightData.Clear();
            var groupedResult = from s in lstFreight
                                group s by s.text;
            try
            {
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterFreightData.Add(new ReadytoDeliveryFilterDlList { CmbFreight = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterFreightData.Add(new ReadytoDeliveryFilterDlList { CmbFreight = item.Key });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        //To get POL Filter Data
        /// <summary>
        /// To get POL Filter Data 
        /// </summary>
        private async Task POLFilterData()
        {
            lstPOL = objBl.getReadytoDeliveryFilterPOLList(gblRegisteration.strLoginUser, "");
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            lstFilterPOLData.Clear();
            var groupedResult = from s in lstPOL
                                group s by s.text;
            try
            {
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterPOLData.Add(new ReadytoDeliveryFilterDlList { CmbPOL = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterPOLData.Add(new ReadytoDeliveryFilterDlList { CmbPOL = item.Key });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To get POD Filter Data
        /// <summary>
        /// To get POD Filter Data 
        /// </summary>
        private async Task PODFilterData()
        {
            lstPOD = objBl.getReadytoDeliveryFilterPODList(gblRegisteration.strLoginUser, "");
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            lstFilterPODData.Clear();
            var groupedResult = from s in lstPOD
                                group s by s.text;
            try
            {
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterPODData.Add(new ReadytoDeliveryFilterDlList { CmbPOD = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterPODData.Add(new ReadytoDeliveryFilterDlList { CmbPOD = item.Key });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}