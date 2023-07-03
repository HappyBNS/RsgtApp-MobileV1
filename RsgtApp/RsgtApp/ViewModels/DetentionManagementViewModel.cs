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
using static RsgtApp.Models.DetentionManagementModelcs;

namespace RsgtApp.ViewModels
{
    public class DetentionManagementViewModel : INotifyPropertyChanged
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        //private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        private BLConnect objCon = new BLConnect();
        public Command gotoClickedApply { get; set; }
        public Command gotoReset { get; set; }
        public Command gotoClickedCancel { get; set; }
        public Command gotoAnyWhereSearch { get; set; }
        public Command FilterClicked { get; set; }
        public Command gotoLoadMore { get; set; }
        public string gblfilter { get; set; }
        public int intTotalCount { get; set; }
        //To Declare Static Variables
        string lstrCaptionALL = "";
        public string strNoRecord = "";
        public string strServerSlowMsg = "";
        public string lblSno = "";
        public string lblCarrier = "";
        public string lblSize = "";
        public string lblBayan = "";
        public string lblContainerNo = "";
        public string lblDischargedOn = "";
        public string lblGatedOutOn = "";
        public string lblDwellDays = "";
        public string lblAmount = "";
        string lblDetentionManagements = "";
        private int fintPageSize = 1000000;
        private int fintPageNo = 1;
        public ObservableCollection<DetentionDt> lstDetentionManagementlocal { get; }
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
        private string strTotalCaption = "";
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
        private string imgDetentionIcon = "";
        public string ImgDetentionIcon
        {
            get { return imgDetentionIcon; }
            set
            {
                imgDetentionIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDetentionIcon");
            }
        }
        private string lblDetentionManagement = "";
        public string LblDetentionManagement
        {
            get { return lblDetentionManagement; }
            set
            {
                lblDetentionManagement = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDetentionManagement");
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
        private string imgDown = "";
        public string ImgDown
        {
            get { return imgDown; }
            set
            {
                imgDown = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDown ");
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
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoClickedApply.ChangeCanExecute();
                gotoReset.ChangeCanExecute();
                gotoClickedCancel.ChangeCanExecute();
                gotoAnyWhereSearch.ChangeCanExecute();
                FilterClicked.ChangeCanExecute();
                gotoLoadMore.ChangeCanExecute();
            }
        }

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
        bool detentionManagementEn = true;
        public bool DetentionManagementEn
        {
            get { return detentionManagementEn; }
            set
            {
                detentionManagementEn = value;

                OnPropertyChanged();
                RaisePropertyChange("DetentionManagementEn");

            }
        }

        List<clsDetentionManSizeFilter> lstSize = new List<clsDetentionManSizeFilter>();
        public ObservableCollection<DetentionManFilterDlList> lstFilterSizeData { get; set; } = new ObservableCollection<DetentionManFilterDlList>();
        List<clsDetentionManCarrierFilter> lstCarrier = new List<clsDetentionManCarrierFilter>();
        public ObservableCollection<DetentionManFilterDlList> lstFilterCarrierData { get; set; } = new ObservableCollection<DetentionManFilterDlList>();
        /// <summary>
        /// ViewModel - Constructor
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strselectedSize"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strBayanNo"></param>
        /// <param name="fstrFilterFlag"></param>
        public DetentionManagementViewModel(string strSearchbox, string strselectedSize, string strselectedCarrier, string strContainerNo, string strBayanNo, string fstrFilterFlag)
        {
            try
            {
                lstDetentionManagementlocal = new ObservableCollection<DetentionDt>();
                Analytics.TrackEvent("DetentionManagementViewModel");
                strTotalCaption = "";
                searchbox = strSearchbox;
               
                //To Call Caption Function
                gotoClickedApply = new Command(async () => await gotoApply(), () => !IsBusy);
                gotoReset = new Command(async () => await Clear(), () => !IsBusy);
                gotoClickedCancel = new Command(async () => await Clear(), () => !IsBusy);
                gotoAnyWhereSearch = new Command(async () => await AnyWhere(), () => !IsBusy);
                FilterClicked = new Command(async () => await FilterClick(), () => !IsBusy);
                gotoLoadMore = new Command(async () => await DetentionManagementlist(strSearchbox, strselectedSize, strselectedCarrier, strContainerNo, strBayanNo), () => !IsBusy);
                Task.Run(() => assignCms()).Wait();
                Task.Run(() => SizeFilterData()).Wait();
                Task.Run(() => CarrierFilterData()).Wait();
                Task.Run(() => DetentionManagementlist(strSearchbox, strselectedSize, strselectedCarrier, strContainerNo, strBayanNo)).Wait();
                if (lstDetentionManagementlocal == null || lstDetentionManagementlocal.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;

               
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Clear
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            IsBusy = true;
            DetentionManagementEn = false;
            await Task.Delay(1000);
            await DetentionManagementlist("", "", "", "", "");

            await SizeFilterData();
            await CarrierFilterData();
            TxtBayanNo = "";
            TxtContainerNo = "";
            IsVisibleFilterScreen = false;
            IsVisibleMainScreen = true;
            DetentionManagementEn = true;
            IsBusy = false;
        }

        /// <summary>
        /// To get AnyWhere
        /// </summary>
        /// <returns></returns>
        public async Task AnyWhere()
        {
            try
            {
                IsBusy = true;
                DetentionManagementEn = false;
                await Task.Delay(1000);
                await DetentionManagementlist(Searchbox, "", "", "", "");
                DetentionManagementEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to Filter
        /// </summary>
        /// <returns></returns>
        public async Task FilterClick()
        {
            try
            {
                IsBusy = true;
                DetentionManagementEn = false;
                await Task.Delay(1000);
                IsVisibleFilterScreen = true;
                IsVisibleMainScreen = false;

                IsBusy = false;
                DetentionManagementEn = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Detention Management list
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strselectedSize"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strBayanNo"></param>
        /// <returns></returns>
        public async Task DetentionManagementlist(string strSearchbox, string strselectedSize, string strselectedCarrier, string strContainerNo, string strBayanNo)
        {
            try
            {
                IsBusy = true;
                DetentionManagementEn = false;
                await Task.Delay(1000);
                string lstrAnywhere = "";
                string lstrContainerNo = "";
                string lstrBayanNo = "";
                string lstrSize = "";
                string lstrCarrier = "";
                if (strSearchbox != null) lstrAnywhere = strSearchbox;
                if (strselectedSize != null) lstrSize = strselectedSize;
                if (strselectedCarrier != null) lstrCarrier = strselectedCarrier;
                if (strContainerNo != null) lstrContainerNo = strContainerNo;
                if (strBayanNo != null) lstrBayanNo = strBayanNo;
                var objRawData = new List<DetentionDt>();
                lstDetentionManagementlocal.Clear();
                gblfilter = "";
                gblfilter += "fstrAnyWhere:" + lstrAnywhere + ";" + "fstrContainernumber:" + lstrContainerNo + ";" + "fstrBayannumber:" + lstrBayanNo + ";" + "fstrSize:" + lstrSize + ";" + "fstrCarrier:" + lstrCarrier + ";";
                objRawData = objCon.getDetentionManagementDetails(gblRegisteration.strLoginUser, fintPageNo, fintPageSize, gblfilter);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                intTotalCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + intTotalCount + ")";
                foreach (var item in objRawData)
                {
                    item.lblSno = lblSno;
                    item.lblCarrier = lblCarrier;
                    item.lblSize = lblSize;
                    item.lblBayan = lblBayan;
                    item.lblContainerNo = lblContainerNo;
                    item.lblDischargedOn = lblDischargedOn;
                    item.lblGatedOutOn = lblGatedOutOn;
                    item.lblDwellDays = lblDwellDays;
                    item.lblAmount = lblAmount;
                    lstDetentionManagementlocal.Add(item);
                }
                totalRecordCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                if (lstDetentionManagementlocal == null || lstDetentionManagementlocal.Count == 0)
                {
                   App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                DetentionManagementEn = true;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM412");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM412");
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
              
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                imgDetentionIcon = dbLayer.getCaption("imgDetention", objCMS);
                strTotalCaption = dbLayer.getCaption("strDetentionManagement", objCMS);
                lblDetentionManagements = dbLayer.getCaption("strDetentionManagement", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblCarrier = dbLayer.getCaption("strCarrier", objCMS);
                lblSize = dbLayer.getCaption("strSize", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS);
                lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                lblDischargedOn = dbLayer.getCaption("strDischargedOn", objCMS);
                lblGatedOutOn = dbLayer.getCaption("strGatedOutOn", objCMS);
                lblDwellDays = dbLayer.getCaption("strDwellDays", objCMS);
                lblAmount = dbLayer.getCaption("strAmount", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                txtSearch = dbLayer.getCaption("StrDetentionPlaceHolder", objCMS);
                ImgFilter = dbLayer.getCaption("imgFilter", objCMS);
                lblFilters = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterSize = dbLayer.getCaption("strSize", objCMS);
                imgDown = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterCarrier = dbLayer.getCaption("strCarrier", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                PlaceBayanNo = dbLayer.getCaption("strBayanNo", objCMS);
                placeContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Size Filter Data
        /// </summary>
        private async Task SizeFilterData()
        {

            lstSize = objBl.getDetentionManFilterSizeList(gblRegisteration.strLoginUserLinkcode);
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            var groupedResult = from s in lstSize
                                group s by s.text;

            lstFilterSizeData.Clear();
            //20230322 As per Mr.Raju Advice Select All Removed Temporary
            //lstFilterSizeData.Add(new DetentionManFilterDlList { CmbSize = lstrCaptionALL });
            foreach (var item in groupedResult)
            {
                lstFilterSizeData.Add(new DetentionManFilterDlList { CmbSize = item.Key });
            }
        }
        /// <summary>
        /// To get Carrier Filter Data
        /// </summary>
        private async Task CarrierFilterData()
        {
            lstCarrier = objBl.getDetentionManFilterCarrierList(gblRegisteration.strLoginUserLinkcode);
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            var groupedResult = from s in lstCarrier
                                group s by s.text;

            lstFilterCarrierData.Clear();
            //20230322 As per Mr.Raju Advice Select All Removed Temporary
            // lstFilterCarrierData.Add(new DetentionManFilterDlList { CmbCarrier = lstrCaptionALL });

            foreach (var item in groupedResult)
            {
                lstFilterCarrierData.Add(new DetentionManFilterDlList { CmbCarrier = item.Key });
            }
        }
        /// <summary>
        /// To go to Apply Function
        /// </summary>
        /// <returns></returns>
        private async Task gotoApply()
        {
            try
            {
                IsBusy = true;
                DetentionManagementEn = false;
                await Task.Delay(1000);
                var strselectedSize = "";
                var strselectedCarrier = "";
                var strBayanNo = "";
                var strContainerNo = "";
                if (lstFilterSizeData.Count > 0)
                {
                    foreach (var item in lstFilterSizeData)
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
                if (TxtBayanNo != null)
                {
                    strBayanNo = TxtBayanNo;
                }
                if (TxtContainerNo != null)
                {
                    strContainerNo = TxtContainerNo;
                }
                if (strselectedSize.Length > 0) strselectedSize = strselectedSize.Substring(0, strselectedSize.Length - 1);
                if (strselectedCarrier.Length > 0) strselectedCarrier = strselectedCarrier.Substring(0, strselectedCarrier.Length - 1);
                await DetentionManagementlist("", strselectedSize, strselectedCarrier, strContainerNo, strBayanNo);
                IsVisibleFilterScreen = false;
                IsVisibleMainScreen = true;
                IsBusy = false;
                DetentionManagementEn = true;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}
