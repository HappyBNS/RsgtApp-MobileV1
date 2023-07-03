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
using static RsgtApp.Models.BayanModel;
using static RsgtApp.Views.BayanFilter;

namespace RsgtApp.ViewModels
{
    public class BayanViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();

        private string strTotalCaption = "";
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        public int fintPageNumber = 1;
        public int fintPageSize = 1000;
        string strBaynanNo = gblBayan.strgblBaynanNo;
        public int intTotalCount { get; set; }

        private List<BayanDt> lstBayanExpander = new List<BayanDt>();
        private List<BayanDt> objDataSource = new List<BayanDt>();
        Dictionary<string, string> lobjpicStatus = new Dictionary<string, string>();
        Dictionary<string, string> lobjpicCategory = new Dictionary<string, string>();//12-01-2023-Sanduru
        public ObservableCollection<BayanDt> lstBayanList { get; set; } = new ObservableCollection<BayanDt>();
        private string strNoRecord = "";
        public ObservableCollection<BayanDt> lstBayan { get; }
        //Assign Property Two way Binding
        //Two way Binding Variable
        public Command FilterClicked { get; set; }
        public Command gotoLoadMore { get; set; }
        public Command ButtonClickedApply { get; set; }
        public Command gotoReset { get; set; }
        public Command SearchAny { get; set; }
        public Command ButtonClickedCancel { get; set; }

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
        //To Declare Count Variable

        private string strtotalRecordCount = "";
        public string TotalRecordCount
        {
            get { return strtotalRecordCount; }
        }
        //LblLstofBayan purpose of using Label varaiable
        private string lblLstofBayan = "";
        public string LblLstofBayan
        {
            get { return lblLstofBayan; }
            set
            {
                lblLstofBayan = value;
                OnPropertyChanged();
                RaisePropertyChange("LblLstofBayan");
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
        //Searchbox represents textbox variable
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
        //TxtSearch purpose of using textbox varaiable
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
        //LblFilter purpose of using Label varaiable
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
        //ImgDownArrow2 purpose of using Image varaiable
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
        //LstrCaptionALL purpose of using Combo Variable
        private string lstrCaptionALL = "";
        public string LstrCaptionALL
        {
            get { return lstrCaptionALL; }
            set
            {
                lstrCaptionALL = value;
                OnPropertyChanged();
                RaisePropertyChange("LstrCaptionALL ");
            }
        }
        //Enumconsignee purpose of using combo varaiable
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
        //EnumVessel purpose of using combo varaiable
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
        }//EnumCarriar purpose of using combo varaiable
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
        //Enumstatus purpose of using combo varaiable
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
        //StrServerSlowMsg purpose of using Label varaiable
        private string strServerSlowMsg = "";
        public string StrServerSlowMsg
        {
            get { return strServerSlowMsg; }
            set
            {
                strServerSlowMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StrServerSlowMsg");
            }
        }
        //LblMoreDetails purpose of using Label varaiable
        private string lblMoreDetails = "";
        public string LblMoreDetails
        {
            get { return lblMoreDetails; }
            set
            {
                lblMoreDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMoreDetails");
            }
        }
        //LblContainer purpose of using Label varaiable
        private string lblContainer = "";
        public string LblContainer
        {
            get { return lblContainer; }
            set
            {
                lblContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainer");
            }
        }
        //LblShippingLine7 purpose of using Label varaiable
        private string lblShippingLine7 = "";
        public string LblShippingLine7
        {
            get { return lblShippingLine7; }
            set
            {
                lblShippingLine7 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShippingLine7");
            }
        }
        //LblCustomagent purpose of using Label varaiable
        private string lblCustomagent = "";
        public string LblCustomagent
        {
            get { return lblCustomagent; }
            set
            {
                lblCustomagent = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCustomagent");
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
        //LblImporter purpose of using Label varaiable
        private string lblImporter = "";
        public string LblImporter
        {
            get { return lblImporter; }
            set
            {
                lblImporter = value;
                OnPropertyChanged();
                RaisePropertyChange("LblImporter");
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
        //ImgContainer purpose of using Image varaiable
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
        //ImgShippingLine7 purpose of using Image varaiable
        private string imgShippingLine7 = "";
        public string ImgShippingLine7
        {
            get { return imgShippingLine7; }
            set
            {
                imgShippingLine7 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgShippingLine7");
            }
        }
        //ImgConsignee purpose of using Image varaiable
        private string imgConsignee = "";
        public string ImgConsignee
        {
            get { return imgConsignee; }
            set
            {
                imgConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgConsignee");
            }
        }
        //ImgCustomagent purpose of using Image varaiable
        private string imgCustomagent = "";
        public string ImgCustomagent
        {
            get { return imgCustomagent; }
            set
            {
                imgCustomagent = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCustomagent");
            }
        }
        //ImgShipper purpose of using Image varaiable
        private string imgShipper = "";
        public string ImgShipper
        {
            get { return imgShipper; }
            set
            {
                imgShipper = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgShipper");
            }
        }
        //ImgImporter purpose of using Image varaiable
        private string imgImporter = "";
        public string ImgImporter
        {
            get { return imgImporter; }
            set
            {
                imgImporter = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgImporter");
            }
        }
        //ImgPol purpose of using Image varaiable
        private string imgPol = "";
        public string ImgPol
        {
            get { return imgPol; }
            set
            {
                imgPol = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgPol");
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
        //To Handle Indicator
        private bool stackBayan = true;
        public bool StackBayan
        {
            get { return stackBayan; }
            set
            {
                stackBayan = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBayan");
            }
        }
        //ImgBLIcon purpose of using Image varaiable
        private string imgBLIcon = "";
        public string ImgBLIcon
        {
            get { return imgBLIcon; }
            set
            {
                imgBLIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBLIcon");
            }
        }
        //isSearchEnable purpose of using Enable varaiable
        private bool _isSearchEnable = true;//20221228
        public bool isSearchEnable
        {
            get { return _isSearchEnable; }
            set
            {
                _isSearchEnable = value;
                OnPropertyChanged();
                RaisePropertyChange("isSearchEnable");
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
        //ImgDownArrow5 purpose of using Image varaiable
        //12-01-2023-sanduru
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
        //lblAction purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblaction = "";
        public string lblAction
        {
            get { return lblaction; }
            set
            {
                lblaction = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAction");
            }
        }
        //ImgDownArrow6 purpose of using Image varaiable
        //12-01-2023-sanduru
        private string imgDownArrow6 = "";
        public string ImgDownArrow6
        {
            get { return imgDownArrow6; }
            set
            {
                imgDownArrow6 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow6");
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
        //lblCategory purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblcategory = "";
        public string lblCategory
        {
            get { return lblcategory; }
            set
            {
                lblcategory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCategory");
            }
        }
        //ContainerCat purpose of using Label varaiable
        //12-01-2023-sanduru
        private string containerCat = "";
        public string ContainerCat
        {
            get { return containerCat; }
            set
            {
                containerCat = value;
                OnPropertyChanged();
                RaisePropertyChange("ContainerCat");
            }
        }
        //lblGatedIn purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblgatedIn = "";
        public string lblGatedIn
        {
            get { return lblgatedIn; }
            set
            {
                lblgatedIn = value;
                OnPropertyChanged();
                RaisePropertyChange("lblGatedIn");
            }
        }
        //lblNotStarted purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblnotStarted = "";
        public string lblNotStarted
        {
            get { return lblnotStarted; }
            set
            {
                lblnotStarted = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNotStarted");
            }
        }
        //lblContainerCategory purpose of using Label varaiable
        //12-01-2023-sanduru
        private string lblcontainerCategory = "";
        public string lblContainerCategory
        {
            get { return lblcontainerCategory; }
            set
            {
                lblcontainerCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerCategory");
            }
        }
        private bool isvisibleCategory = false;
        public bool IsvisibleCategory
        {
            get { return isvisibleCategory; }
            set
            {
                isvisibleCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleCategory");
            }
        }
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
                SearchAny.ChangeCanExecute();
                gotoReset.ChangeCanExecute();

            }
        }

        List<clsconsigneefilter> lstConsignee = new List<clsconsigneefilter>();
        List<clsVesselfilter> lstVessel = new List<clsVesselfilter>();
        List<clsCarrierfilter> lstCarrier = new List<clsCarrierfilter>();
        public ObservableCollection<BayanFilterDtlist> lstFilterConsigneeData { get; set; } = new ObservableCollection<BayanFilterDtlist>();
        public ObservableCollection<BayanFilterDtlist> lstFilterVesselData { get; set; } = new ObservableCollection<BayanFilterDtlist>();
        public ObservableCollection<BayanFilterDtlist> lstFilterCarrierData { get; set; } = new ObservableCollection<BayanFilterDtlist>();
        public ObservableCollection<BayanFilterDtlist> lstFilterStatusData { get; set; } = new ObservableCollection<BayanFilterDtlist>();
        //12-02-2023-sanduru
        public ObservableCollection<BayanFilterDtlist> lstFilterCategoryData { get; set; } = new ObservableCollection<BayanFilterDtlist>();
        public System.Windows.Input.ICommand BOlclick => new Command<BayanDt>(BOL);
        public System.Windows.Input.ICommand BOlPageclick => new Command<BayanDt>(BolPage);
        /// <summary>
        /// Begin Bayan View Model Constructor Function
        /// </summary>
        /// <param name="strsearhbox"></param>
        /// <param name="strselectedConsignee"></param>
        /// <param name="strselectedVessel"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strselectedStatus"></param>
        /// <param name="fstrFilterFlag"></param>
        /// <param name="strselectedCategory"></param>
        public BayanViewModel(string strsearhbox, string strselectedConsignee, string strselectedVessel, string strselectedCarrier, string strselectedStatus, string fstrFilterFlag, string strselectedCategory)
        {
            Task.Run(() => assignCms()).Wait();
            lstBayan = new ObservableCollection<BayanDt>();
            searchbox = strsearhbox;
            //To Call Caption Function
            FilterClicked = new Command(async () => await FilterClick(), () => !IsBusy);
            //Anywhere Search Button Command
            SearchAny = new Command(async () => await Anywhere(), () => !IsBusy);
            //Cancel/Reset  Button Command
            ButtonClickedCancel = new Command(async () => await BayanList(strsearhbox, strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus, strselectedCategory), () => !IsBusy);
            //Apply Filter Button Command
            ButtonClickedApply = new Command(async () => await gotoApply(), () => !IsBusy);
            gotoReset = new Command(async () => await clear(), () => !IsBusy);
            ButtonClickedCancel = new Command(async () => await clear(), () => !IsBusy);

            if (fstrFilterFlag == "Y")
            {
                Task.Run(() => ConsigneeFilterData()).Wait();
                Task.Run(() => VesselFilterData()).Wait();
                Task.Run(() => CarrierFilterData()).Wait();
                var Milestone = AppSettings.Milestone;
                IsvisibleCategory = false;
                if ((Milestone == "M5") || (Milestone == "M4"))
                {
                    IsvisibleCategory = true;
                }
            }
            else
            {
                Task.Run(() => BayanList(strsearhbox, strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus, strselectedCategory)).Wait();

            }
            if (fstrFilterFlag != "Y")
            {
                if (lstBayan == null || lstBayan.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
           

        }
        //End Bayan View Model Constructor Function

        //To get Clear Function
        public async Task clear()
        {
            IsBusy = true;
            StackBayan = false;
            await Task.Delay(1000);
            //await Shell.Current.GoToAsync("..");
            await App.Current.MainPage?.Navigation.PushAsync(new Bayan("", "", "", "", "", ""));
            StackBayan = true;
            IsBusy = false;
        }

        /// <summary>
        /// To get Bol Page
        /// </summary>
        /// <param name="fobjBayan"></param>
        public async void BolPage(BayanDt fobjBayan)
        {
            try
            {
                IsBusy = true;
                StackBayan = false;
                await Task.Delay(1000);
                gblBayan.strgblBaynanNo = fobjBayan.BayanNo;
                Application.Current.MainPage?.Navigation.PushAsync(new BOL("", fobjBayan.BayanNo, "", "", "", ""));
                StackBayan = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To get BOL
        /// </summary>
        /// <param name="fojbayanNo"></param>
        public async void BOL(BayanDt fojbayanNo)
        {
            IsBusy = true;
            StackBayan = false;
            await Task.Delay(1000); // Change 20220623
            try
            {
                string strBayanNo = fojbayanNo.BayanNo;
                App.Current.MainPage?.Navigation.PushAsync(new BOL_list_popup(strBayanNo));
                StackBayan = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                string lstrmsg = ex.Message;
            }
        }

        /// <summary>
        /// To get Anywhere Function
        /// </summary>
        /// <returns></returns>
        public async Task Anywhere()
        {
            try
            {
                IsBusy = true;
                StackBayan = false;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new Bayan(searchbox, "", "", "", "", ""));
                StackBayan = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Fliter Page
        /// </summary>
        /// <returns></returns>
        public async Task FilterClick()
        {
            try
            {
                if (isSearchEnable == true)
                {
                    IsBusy = true;
                    StackBayan = false;
                    await Task.Delay(1000);
                    Application.Current.MainPage?.Navigation.PushAsync(new BayanFilter());
                    StackBayan = true;
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Bayan List Page
        /// </summary>
        /// <param name="strsearhbox"></param>
        /// <param name="strselectedConsignee"></param>
        /// <param name="strselectedVessel"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strselectedStatus"></param>
        /// <param name="strselectedCategory"></param>
        /// <returns></returns>
        public async Task BayanList(string strsearhbox, string strselectedConsignee, string strselectedVessel, string strselectedCarrier, string strselectedStatus, string strselectedCategory)
        {
            IsBusy = true;
            StackBayan = false;
            await Task.Delay(1000);
            try
            {
                lstBayan.Clear();
                string fstrfilter = "";
                string lstrAnyWhere = "";
                string lstrBD_CONSIGNEEDESC1 = "";
                string lstrBD_VESSELNAME1 = "";
                string lstrBL_SHIPPINGLINEID = "";
                string lstrBD_Bayanstatus = "";
                string lstrBD_Category = ""; //05-05-2023

                if (strsearhbox != null) lstrAnyWhere = strsearhbox;
                if (strselectedConsignee != null) lstrBD_CONSIGNEEDESC1 = strselectedConsignee;
                if (strselectedVessel != null) lstrBD_VESSELNAME1 = strselectedVessel;
                if (strselectedCarrier != null) lstrBL_SHIPPINGLINEID = strselectedCarrier;
                if (strselectedStatus != null) lstrBD_Bayanstatus = strselectedStatus;

                if (strselectedCategory != null) lstrBD_Category = strselectedCategory;//05-05-2023

                var objRawData = new List<BayanDt>();
                fstrfilter += "fstrAnyWhere:" + lstrAnyWhere + ";" + "fstrBD_CONSIGNEEDESC1:" + lstrBD_CONSIGNEEDESC1 + ";" + "fstrBD_VESSELNAME1:" + lstrBD_VESSELNAME1 + ";" + "fstrBL_SHIPPINGLINEID:" + lstrBL_SHIPPINGLINEID + ";" + "fstrBD_Bayanstatus:" + lstrBD_Bayanstatus + ";" + "fstrContainerCategories:"+ lstrBD_Category + ";"; 

                objRawData = objCon.getUserBayanList(gblRegisteration.strLoginUser, fintPageSize, fintPageNumber, fstrfilter);

                intTotalCount = objRawData.Count;
                strtotalRecordCount = strTotalCaption + " (" + intTotalCount + ")";
                foreach (var item in objRawData)
                {
                    item.imgDownArrow1 = imgDownArrow1;
                    item.imgContainer = imgContainer;
                    item.imgShippingLine7 = imgShippingLine7;
                    item.imgConsignee = imgConsignee;
                    item.imgCustomagent = imgCustomagent;
                    item.imgShipper = imgShipper;
                    item.imgImporter = imgImporter;
                    item.imgPol = imgPol;
                    item.lblInYard = lblInYard;
                    item.lblDeparted = lblDeparted;
                    //12-01-2022-Sanduru
                    item.lblCategory = lblImp;
                    if (item.Expbayancategory.ToString().Trim().ToUpper() == "EXPRT")
                    {
                        item.lblInYard = lblArrived;
                        item.lblDeparted = lblLoaded;
                        item.lblCategory = lblExp;
                        item.Inyard = item.Gatedincount;
                        item.Departed = item.Loadedcount;
                    }
                    item.btnMoreDetails = btnMoreDetails;
                    lstBayan.Add(item);

                }
                if (lstBayan == null || lstBayan.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                StackBayan = true;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM011");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM011");
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
        /// Function for caption and flowdirection(English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            try
            {
                
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                lblLstofBayan = dbLayer.getCaption("strListofBayan", objCMS);
                strTotalCaption = dbLayer.getCaption("strListofBayan", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgfilter", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                txtSearch = dbLayer.getCaption("strBayanPlaceHolder", objCMS);
                //12-02-2023-sanduru
                ContainerCat = dbLayer.getCaption("strContainerCategory", objCMS);
                lblImp = dbLayer.getCaption("strIMP", objCMS);
                lblExp = dbLayer.getCaption("strEXP", objCMS);
                lblGatedIn = dbLayer.getCaption("strGatedIn", objCMS);
                lblNotStarted = dbLayer.getCaption("strNotStarted", objCMS);
                lblCategory = dbLayer.getCaption("strContainerCategory", objCMS);
                lblArrived = dbLayer.getCaption("strArrivedcolon", objCMS);
                lblLoaded = dbLayer.getCaption("strLoadedcolon", objCMS);
                btnMoreDetails = dbLayer.getCaption("strMoreDetails", objCMS);
                imgDownArrow1 = dbLayer.getCaption("imgdownArrow", objCMS);
                imgContainer = dbLayer.getCaption("imgcontainer", objCMS);
                imgShippingLine7 = dbLayer.getCaption("imgshippingline", objCMS);
                imgConsignee = dbLayer.getCaption("imgconsignee", objCMS);
                imgCustomagent = dbLayer.getCaption("imgcustomagent", objCMS);
                imgShipper = dbLayer.getCaption("imgshipper", objCMS);
                imgImporter = dbLayer.getCaption("imgimporter", objCMS);
                imgPol = dbLayer.getCaption("imgpol", objCMS);
                lblInYard = dbLayer.getCaption("strInYard", objCMS);
                lblDeparted = dbLayer.getCaption("strDeparted", objCMS);
                //Bayan Filter
                imgFilterBlue = dbLayer.getCaption("imgfilterBlue", objCMS);
                lblFilter = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgRest = dbLayer.getCaption("imgreset", objCMS);
                lblConsignee = dbLayer.getCaption("strConsignee", objCMS);
                imgDownArrow1 = dbLayer.getCaption("imgdownArrow", objCMS);
                lblVessel = dbLayer.getCaption("strVessel", objCMS);
                imgDownArrow2 = dbLayer.getCaption("imgdownArrow", objCMS);
                lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
                imgDownArrow3 = dbLayer.getCaption("imgdownArrow", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                imgDownArrow4 = dbLayer.getCaption("imgdownArrow", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                //04-01-2023-Sanduru
                lblContainerCategory = dbLayer.getCaption("strContainerCategory", objCMS);
                ImgDownArrow5 = dbLayer.getCaption("imgdownArrow", objCMS);
                lobjpicStatus = dbLayer.getLOV("strStatus", objCMS);//Here We are using CMS_Code
                lstFilterStatusData.Add(new BayanFilterDtlist { lblStatus = lstrCaptionALL });
                Lblok = dbLayer.getCaption("strOk", objCMSMsg);
                lstFilterStatusData.Clear();
                // //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterStatusData.Add(new BayanFilterDtlist { lblStatus = lstrCaptionALL });
                foreach (var dic in lobjpicStatus)
                {
                    // "In Progress,In Yard"
                    if ((dic.Value == "101") || (dic.Value == "102") || (dic.Value == "105"))
                    {
                        lstFilterStatusData.Add(new BayanFilterDtlist { lblStatus = dic.Key, isChecked = true });
                    }
                    else
                    {
                        lstFilterStatusData.Add(new BayanFilterDtlist { lblStatus = dic.Key });
                    }
                }
                string lstrCustomType = gblRegisteration.strLoginCustomerType.ToString().Trim();
                if ((lstrCustomType == "Employees") || (lstrCustomType == "Students") || (lstrCustomType == "Authorities"))
                {
                    isSearchEnable = false;
                }
                //12-01-2023-Sanduru-Category Filter
                lobjpicCategory = dbLayer.getLOV("strSelectAllCategoriesLov",objCMS);
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterCategoryData.Add(new BayanFilterDtlist { lblContainerCategoryCMB = lstrCaptionALL });
                foreach (var dic in lobjpicCategory)
                {
                    lstFilterCategoryData.Add(new BayanFilterDtlist { lblContainerCategoryCMB = dic.Key });
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Filter Page start
        /// </summary>
        private async void ConsigneeFilterData()
        {
            try
            {
                // string strbaynNo = "";
                // string strBLNo = "";
                string strEmpty = "";
                string fstrfilter = "Gkey:" + gblRegisteration.strLoginUserLinkcode + ";" + "CustomerType:" + gblRegisteration.strLoginCustomerType + ";" + "BayanNo:" + strEmpty + ";";
                lstConsignee = objBl.getBayanFilterConsigneeList(fstrfilter);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                var groupedResult = lstConsignee.GroupBy(x => new { x.value, x.text }).Select(x => x.Key).ToList();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterConsigneeData.Add(new BayanFilterDtlist { lblConsigneeData = lstrCaptionALL });

                foreach (var dic in groupedResult)
                {
                    lstFilterConsigneeData.Add(new BayanFilterDtlist { lblConsigneeData = dic.text });
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                string fstrCondition = "fstrCode=" + "RM011Bayan" + "&fstrCustomMsg=" + "" + "&fstrSystemMsg=" + ex.Message + "&fstrSuggestion=" + "Exception" + "&fstrsource=" + "MobileApp" + "";
                string lstrResult = objWebApi.getstringPostWebApi("procWriteApiTraceLog", "", fstrCondition);
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Vessel Filter Data
        /// </summary>
        private async void VesselFilterData()
        {
            //string strbaynNo = "";
            //string strBLNo = "";
            string strEmpty = "";
            string fstrfilter = "Gkey:" + gblRegisteration.strLoginUserLinkcode + ";" + "CustomerType:" + gblRegisteration.strLoginCustomerType + ";" + "BayanNo:" + strEmpty + ";";
            lstVessel = objBl.getBayanFilterVesselList(fstrfilter);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            try
            {
                var groupedResult = lstVessel.GroupBy(x => new { x.value, x.text }).Select(x => x.Key).ToList();
                //var groupedResult = from s in lstVessel
                //                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterVesselData.Add(new BayanFilterDtlist { lblVesselData = lstrCaptionALL });
                foreach (var dic in groupedResult)
                {
                    lstFilterVesselData.Add(new BayanFilterDtlist { lblVesselData = dic.text });
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                string fstrCondition = "fstrCode=" + "RM011Bayan" + "&fstrCustomMsg=" + "" + "&fstrSystemMsg=" + ex.Message + "&fstrSuggestion=" + "Exception" + "&fstrsource=" + "MobileApp" + "";
                string lstrResult = objWebApi.getstringPostWebApi("procWriteApiTraceLog", "", fstrCondition);
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Carrier Filter Data
        /// </summary>
        private async void CarrierFilterData()
        {
            // string strbaynNo = "";
            // string strBLNo = "";
            string strEmpty = "";
            string fstrfilter = "Gkey:" + gblRegisteration.strLoginUserLinkcode + ";" + "CustomerType:" + gblRegisteration.strLoginCustomerType + ";" + "BayanNo:" + strEmpty + ";";
            lstCarrier = objBl.getBayanFilterCarrierList(fstrfilter);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            try
            {
                var groupedResult = lstCarrier.GroupBy(x => new { x.value, x.text }).Select(x => x.Key).ToList();
                //var groupedResult = from s in lstCarrier
                //                    group s by s.text;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterCarrierData.Add(new BayanFilterDtlist { lblCarrierData = lstrCaptionALL });
                foreach (var dic in groupedResult)
                {
                    lstFilterCarrierData.Add(new BayanFilterDtlist { lblCarrierData = dic.text });
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                string fstrCondition = "fstrCode=" + "RM011Bayan" + "&fstrCustomMsg=" + "" + "&fstrSystemMsg=" + ex.Message + "&fstrSuggestion=" + "Exception" + "&fstrsource=" + "MobileApp" + "";
                string lstrResult = objWebApi.getstringPostWebApi("procWriteApiTraceLog", "", fstrCondition);
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Click Apply
        /// </summary>
        /// <returns></returns>
        private async Task gotoApply()
        {
            try
            {
                IsBusy = true;
                StackBayan = false;
                await Task.Delay(1000); // Change 20220623
                var strselectedConsignee = "";
                var strselectedVessel = "";
                var strselectedCarrier = "";
                var strselectedStatus = "";
                var strselectedCategory = ""; //12-10-2023-Sanduru
                if (lstFilterConsigneeData.Count > 0)
                {
                    foreach (var item in lstFilterConsigneeData)
                    {
                        if (item.isChecked == true) //20220809
                        {
                            if (item.lblConsigneeData.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedConsignee += item.lblConsigneeData + ",";
                            }
                        }
                    }
                }
                if (lstFilterVesselData.Count > 0)
                {
                    foreach (var item in lstFilterVesselData)
                    {
                        if (item.isChecked == true) //20220809
                        {
                            if (item.lblVesselData.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedVessel += item.lblVesselData + ",";
                            }
                        }
                    }
                }
                if (lstFilterCarrierData.Count > 0)
                {
                    foreach (var item in lstFilterCarrierData)
                    {
                        if (item.isChecked == true) //20220809
                        {
                            if (item.lblCarrierData.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedCarrier += item.lblCarrierData + ",";
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
                            if (item.lblStatus.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstStatus = lobjpicStatus.Where(x => x.Key.Contains(item.lblStatus)).ToList();


                                strselectedStatus += lstStatus[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                //12-10-2023-Sanduru
                if (lstFilterCategoryData.Count > 0)
                {
                    foreach (var item in lstFilterCategoryData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.lblContainerCategoryCMB.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstCategory = lobjpicCategory.Where(x => x.Key.Contains(item.lblContainerCategoryCMB)).ToList();
                                strselectedCategory += lstCategory[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                if (strselectedConsignee.Length > 0) strselectedConsignee = strselectedConsignee.Substring(0, strselectedConsignee.Length - 1);
                if (strselectedVessel.Length > 0) strselectedVessel = strselectedVessel.Substring(0, strselectedVessel.Length - 1);
                if (strselectedCarrier.Length > 0) strselectedCarrier = strselectedCarrier.Substring(0, strselectedCarrier.Length - 1);
                if (strselectedStatus.Length > 0) strselectedStatus = strselectedStatus.Substring(0, strselectedStatus.Length - 1);
                //12-10-2023-Sanduru
                if (strselectedCategory.Length > 0) strselectedCategory = strselectedCategory.Substring(0, strselectedCategory.Length - 1);

                 App.Current.MainPage?.Navigation.PushAsync(new Bayan("", strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus, strselectedCategory));
                StackBayan = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}