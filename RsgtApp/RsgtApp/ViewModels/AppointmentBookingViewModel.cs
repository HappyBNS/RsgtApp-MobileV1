using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using static RsgtApp.Models.AppointmentBookingModel;   

namespace RsgtApp.ViewModels
{
    class AppointmentBookingViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
       
        private string strLanguage = App.gblLanguage;
        //gotoAnyWhereSearch Button 
        public Command gotoAnyWhereSearch { get; set; }
        //Filter_Clicked Button 
        public Command Filter_Clicked { get; set; }
        //gotoLoadMore Button
        public Command gotoLoadMore { get; set; }
        //ButtonClickedapply Button
        public Command ButtonClickedApply { get; set; }
        //gotoReset Button
        public Command gotoReset { get; set; }
        //ButtonClickedCancel Button 
        public Command ButtonClickedCancel { get; set; }
        private string strServerSlowMsg = "";
        //To create Collection Object used ObservableCollection
        public ObservableCollection<BookingDt> lstAppointmentlst { get; }
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        private string lstrAppDate = "";
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
        private string strTotalCaption = "";
        public int fintPageNumber = 1;
        public int fintPageSize = 100000;
        public int intTotalCount { get; set; }
        public string lblBayan = "";
        public string lblBillofLading = "";
        public string lblContainer = "";
        public string lblTmsBookingRef = "";
        public string lblAppDate = "";
        public string lblBookingStatus = "";
        //Indicator Color
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");

        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;

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
            }
        }
        //To Declare Count Variable
      //  private int totalRecordCount = 0;

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
        //Assign Property Two way Binding
        //Two way Binding Variable
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
        // enumStatus  combo variable
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
        //txtBilloflading purpose of using textbox varaiable
        public string txtBilloflading = "";
        public string TxtBilloflading
        {
            get { return txtBilloflading; }
            set
            {
                txtBilloflading = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBilloflading");
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
        //txtTmsBookingRef purpose of using textbox varaiable
        public string txtTmsBookingRef = "";
        public string TxtTmsBookingRef
        {
            get { return txtTmsBookingRef; }
            set
            {
                txtTmsBookingRef = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTmsBookingRef");
            }
        }
        //txtAppDate purpose of using textbox varaiable
        public string txtAppDate = "";
        public string TxtAppDate
        {
            get { return txtAppDate; }
            set
            {
                txtAppDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtAppDate");
            }
        }
        //txtAnyWhere purpose of using textbox varaiable
        public string txtAnyWhere = "";
        public string TxtAnyWhere
        {
            get { return txtAnyWhere; }
            set
            {
                txtAnyWhere = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtAnyWhere");
            }
        }
        //txtAppointments purpose of using textbox varaiable
        public string txtAppointments = "";
        public string TxtAppointments
        {
            get { return txtAppointments; }
            set
            {
                txtAppointments = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtAppointments");
            }
        }
        //txtTmsrefno purpose of using textbox varaiable
        public string txtTmsrefno = "";
        public string TxtTmsrefno
        {
            get { return txtTmsrefno; }
            set
            {
                txtTmsrefno = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTmsrefno");
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
                gotoAnyWhereSearch.ChangeCanExecute();
                Filter_Clicked.ChangeCanExecute();
                gotoLoadMore.ChangeCanExecute();
            }
        }
        //To handle Boolen variable
        bool stackAppointment = true;
        public bool StackAppointment
        {
            get { return stackAppointment; }
            set
            {
                stackAppointment = value;

                OnPropertyChanged();
                RaisePropertyChange("StackAppointment");
            }
        }
        //imgFashLogo purpose of using image varaiable
        private string imgFashLogo = "";
        public string ImgFashLogo
        {
            get { return imgFashLogo; }
            set
            {
                imgFashLogo = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgFashLogo");
            }
        }
        //lblMessage purpose of using label varaiable
        private string lblMessage = "";
        public string LblMessage
        {
            get { return lblMessage; }
            set
            {
                lblMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessage");
            }
        }
        //lblPleaseClickHere purpose of using label varaiable
        private string lblPleaseClickHere = "";
        public string LblPleaseClickHere
        {
            get { return lblPleaseClickHere; }
            set
            {
                lblPleaseClickHere = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPleaseClickHere");
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
        //stackAppointMent purpose of using textbox varaiable
        private string stackAppointMent = "";
        public string StackAppointMent
        {
            get { return stackAppointMent; }
            set
            {
                stackAppointMent = value;
                OnPropertyChanged();
                RaisePropertyChange("StackAppointMent");
            }
        }
        //lblFilters purpose of using label varaiable
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
        //txtBillofLadingNo purpose of using textbox varaiable
        private string txtBillofLadingNo = "";
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
        //placeBillofLadingNo purpose of using textbox varaiable
        private string placeBillofLadingNo = "";
        public string PlaceBillofLadingNo
        {
            get { return placeBillofLadingNo; }
            set
            {
                placeBillofLadingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBillofLadingNo");
            }
        }
        //txtAppData purpose of using textbox varaiable
        private string txtAppData = "";
        public string TxtAppData
        {
            get { return txtAppData; }
            set
            {
                txtAppData = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtAppData");
            }
        }
        //placeAppData purpose of using textbox varaiable
        private string placeAppData = "";
        public string PlaceAppData
        {
            get { return placeAppData; }
            set
            {
                placeAppData = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceAppData");
            }
        }
        //placeContainerNo purpose of using textbox varaiable
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
        //placeTmsReference purpose of using textbox varaiable
        private string placeTmsReference = "";
        public string PlaceTmsReference
        {
            get { return placeTmsReference; }
            set
            {
                placeTmsReference = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceTmsReference");
            }
        }
        //filterStatus purpose of using textbox varaiable
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
        //txtTmsReference purpose of using textbox varaiable
        private string txtTmsReference = "";
        public string TxtTmsReference
        {
            get { return txtTmsReference; }
            set
            {
                txtTmsReference = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTmsReference");
            }
        }
        //lstrAppointment purpose of using textbox varaiable
        private string lstrAppointment = "";
        public string LstrAppointment
        {
            get { return txtTmsReference; }
            set
            {
                lstrAppointment = value;
                OnPropertyChanged();
                RaisePropertyChange("LstrAppointment");
            }
        }
        //bgOverlayColor purpose of using textbox varaiable
        private string bgOverlayColor = "";
        public string BgOverlayColor
        {
            get { return bgOverlayColor; }
            set
            {
                bgOverlayColor = value;
                OnPropertyChanged();
                RaisePropertyChange("BgOverlayColor");
            }
        }
        //bgOverlayOpacity purpose of using textbox varaiable
        private string bgOverlayOpacity = "";
        public string BgOverlayOpacity
        {
            get { return bgOverlayOpacity; }
            set
            {
                bgOverlayOpacity = value;
                OnPropertyChanged();
                RaisePropertyChange("BgOverlayOpacity");
            }
        }
        private DateTime? dateApp = null;
        public DateTime? DateApp
        {
            get { return dateApp; }
            set
            {
                dateApp = value;
                OnPropertyChanged();
                RaisePropertyChange("DateApp");
            }
        }
        //Hide and Show AppointmentBooking 2023/03/18
        private bool isVisibleAppointmentBooking = false;
        public bool IsVisibleAppointmentBooking
        {
            get { return isVisibleAppointmentBooking; }
            set
            {
                isVisibleAppointmentBooking = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleAppointmentBooking");
            }
        }


        private bool isVisibleAppointFilter = false;
        public bool IsVisibleAppointFilter
        {
            get { return isVisibleAppointFilter; }
            set
            {
                isVisibleAppointFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleAppointFilter");
            }
        }
        //bgOverlayOpacity purpose of using textbox varaiable
        private string lblAppData = "";
        public string LblAppData
        {
            get { return lblAppData; }
            set
            {
                lblAppData = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAppData");
            }
        }
        //To handle Bool in Expander
        private bool _isExpandedStatus = false;
        public bool IsExpandedStatus
        {
            get { return _isExpandedStatus; }
            set { SetProperty(ref _isExpandedStatus, value); }
        }
        public string strNoRecord { get; set; }     
        public string lblAppointment { get; set; }
        public string btnLoadMore { get; set; }
        public string lstrCaptionALL = "";
        public ObservableCollection<AppointmentFilterDtlist> lstFilterStatusdata { get; set; } = new ObservableCollection<AppointmentFilterDtlist>();
        public ICommand TapInvoicePdfCommand => new Command<BookingDt>(OpenPdf);

        //20221223_Handled By Anand
        [Obsolete]
        public ICommand OpenURlCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
        void OpenPdf(BookingDt fobjBookingDt)
        {
            var fstrContainerNo = fobjBookingDt.Container;
            OpenPdfPINo(fstrContainerNo);
        }
        ContentPage Myview;
        /// <summary>
        /// To Open PDF
        /// </summary>
        public System.Windows.Input.ICommand MyInvoicePdf => new Command<string>((fstrContainerNo) =>
        {
            OpenPdfPINo(fstrContainerNo);
        });
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="strSearchbox">Searchbox</param>
        /// <param name="strBillofLadingNo">BillofLadingNo</param>
        /// <param name="strContainerNo">ContainerNo</param>
        /// <param name="strTmsReference">TmsReference</param>
        /// <param name="strAppDate">AppDate</param>
        /// <param name="strSelectedStatus">Status</param>
        /// <param name="lstrAppDate">AppDate</param>
        public AppointmentBookingViewModel(string strSearchbox, string strBillofLadingNo, string strContainerNo, string strTmsReference, string strAppDate, string strSelectedStatus,string lstrAppDate,string fstrFilterFlag, ContentPage view)
        {
            try
            {
                Myview = view;
                //Initiate Collection Object
                lstAppointmentlst = new ObservableCollection<BookingDt>();
                Task.Run(() => assignCMS()).Wait();
                
                searchbox = strSearchbox;
                if (fstrFilterFlag == "N")
                {
                    IsVisibleAppointmentBooking = true;
                    IsVisibleAppointFilter = false;
                }
                if (fstrFilterFlag == "Y")
                {
                    IsVisibleAppointmentBooking = false;
                    IsVisibleAppointFilter = true;                   
                }
                //Begin-All Command Buttons
                gotoAnyWhereSearch = new Command(async () => await AnywhereSearch(), () => !IsBusy);
                Filter_Clicked = new Command(async () => await FilterClicked(), () => !IsBusy);
                gotoLoadMore = new Command(async () => await BookingList(strSearchbox, strBillofLadingNo, strContainerNo, strTmsReference, strAppDate, strSelectedStatus, lstrAppDate), () => !IsBusy);
                ButtonClickedApply = new Command(async () => await ClickedApply(), () => !IsBusy);
                gotoReset = new Command(async () => await Clear(), () => !IsBusy);
                ButtonClickedCancel = new Command(async () => await Clear(), () => !IsBusy);
                //End-All Command Buttons
                Task.Run(() => BookingList(strSearchbox, strBillofLadingNo, strContainerNo, strTmsReference, strAppDate, strSelectedStatus, lstrAppDate)).Wait();
                if (lstAppointmentlst == null || lstAppointmentlst.Count == 0)
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
        ///  To Get Clear
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            IsBusy = true;
            StackAppointment = false;
            await Task.Delay(1000);
            // App.Current.MainPage?.Navigation.PushAsync(new AppointmentBooking("", "", "", "", "", "","",""));
           await BookingList("", "", "", "", "", "", "");
            await assignCMS();
            await assignContent();
            IsExpandedStatus = false;
            TxtBillofLadingNo = "";
            TxtContainerNo = "";
            TxtTmsReference = "";
            IsVisibleAppointmentBooking = true;
            IsVisibleAppointFilter = false;
            StackAppointment = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Navigate Appointment Filter Page 
        /// </summary>
        /// <returns></returns>
        private async Task FilterClicked()
        {
            try
            {
                IsBusy = true;
                StackAppointment = false;
                await Task.Delay(1000);
                // Application.Current.MainPage?.Navigation.PushAsync(new AppointmentFilter());
                IsVisibleAppointmentBooking = false;
                IsVisibleAppointFilter = true;
                StackAppointment = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Navigate AppointmentBooking AnyWhere Page
        /// </summary>
        /// <returns></returns>
        private async Task AnywhereSearch()
        {
            try
            {
                IsBusy = true;
                StackAppointment = false;
                await Task.Delay(1000);
                //Application.Current.MainPage?.Navigation.PushAsync(new AppointmentBooking(searchbox, "", "", "", "", "","",""));
                await BookingList(Searchbox, "", "", "", "", "", "");
                StackAppointment = true;
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
        /// <returns></returns>
        private async Task assignCMS()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM029");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM029");
                    objCMSMsg =await dbLayer.LoadContent("RM026");
                }
                await assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        /// <returns></returns>
        private async Task assignContent()
        {
            try
            {
                
               
                await Task.Delay(1000);
              
                dbLayer.objInfoitems = objCMS;
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                lblAppointment = dbLayer.getCaption("strAppointment", objCMS);
                imgFashLogo = dbLayer.getCaption("imgFasah", objCMS);
                lblMessage = dbLayer.getCaption("strToBookAppointment", objCMS);
                lblPleaseClickHere = dbLayer.getCaption("strPleaseClickHere", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS);
                lblBillofLading = dbLayer.getCaption("strBillofLading", objCMS);
                lblContainer = dbLayer.getCaption("strContainer", objCMS);
                lblTmsBookingRef = dbLayer.getCaption("strTMSBookingRef", objCMS);
                lblAppDate = dbLayer.getCaption("strAppDateTime", objCMS);
                lblBookingStatus = dbLayer.getCaption("strBookingStatus", objCMS);
                strTotalCaption = cms.getCaption("strAppointment", objCMS);
                txtSearch = dbLayer.getCaption("StrAppointmentPlaceHolder", objCMS);
                ImgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                LblFilter = dbLayer.getCaption("strFilters", objCMS);
                BtnApply = dbLayer.getCaption("strApply", objCMS);
                ImgRest = dbLayer.getCaption("imgReset", objCMS);
                PlaceBillofLadingNo = dbLayer.getCaption("strBillofLadingNo", objCMS);
                PlaceContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                PlaceTmsReference = dbLayer.getCaption("strTMSReference", objCMS);
                LblAppData = dbLayer.getCaption("strAppDateTime", objCMS);
                FilterStatus = dbLayer.getCaption("strStatus", objCMS);
                ImgDownArrow = dbLayer.getCaption("imgDownPng", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                PlaceAppData = dbLayer.getCaption("strAppDateTime", objCMS);
                Dictionary<string, string> lobjpicMop = dbLayer.getLOV("strStatusGrid", objCMS);
                lstFilterStatusdata.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterStatusdata.Add(new AppointmentFilterDtlist { CmbStatus = lstrCaptionALL });
                foreach (var dic in lobjpicMop)
                {
                    lstFilterStatusdata.Add(new AppointmentFilterDtlist { CmbStatus = dic.Key });
                }
                BgOverlayColor = RSGT_Resource.ResourceManager.GetString("BgOverlayColor");
                BgOverlayOpacity = RSGT_Resource.ResourceManager.GetString("BgOverlayOpacity");
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
        /// <param name="strBillofLadingNo"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strTmsReference"></param>
        /// <param name="strAppDate"></param>
        /// <param name="strSelectedStatus"></param>
        /// <param name="lstrAppDate"></param>
        /// <returns></returns>
        private async Task BookingList(string strSearchbox, string strBillofLadingNo, string strContainerNo, string strTmsReference, string strAppDate, string strSelectedStatus,string lstrAppDate)
        {
            try
            {
                IsBusy = true;
                StackAppointment = false;
                await Task.Delay(1000);
                string fstrAnyWhere = "";
                string fstrBLNumber = "";
                string fstrContainerNumber = "";
                string fstrTmsrefno = "";
                string fstrApptdate = "";
                string fstrApptstatus = "";
                if (strSearchbox != null) fstrAnyWhere = strSearchbox;
                if (strSelectedStatus != null) fstrApptstatus = strSelectedStatus;
                if (strBillofLadingNo != null) fstrBLNumber = strBillofLadingNo;
                if (strContainerNo != null) fstrContainerNumber = strContainerNo;
                if (lstrAppDate != null) fstrApptdate = lstrAppDate;              
                if (strTmsReference != null) fstrTmsrefno = strTmsReference;
                lstAppointmentlst.Clear();
                await Task.Delay(2000);
                var objRawData = new List<BookingDt>();
                string fstrFilter = "fstrAnyWhere:" + fstrAnyWhere + "; fstrBLNumber:" + fstrBLNumber + "; fstrContainerNumber:" + fstrContainerNumber + "; fstrTmsrefno:" + fstrTmsrefno + "; cd_fmtapptdate:" + fstrApptdate + "; fstrApptstatus:" + fstrApptstatus + ";";
                //To call bussinesslayer 
                objRawData = objBl.getAppointmentList(fstrFilter, fintPageNumber, fintPageSize); // 35
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
               
                foreach (var item in objRawData)
                {
                    item.lblAppDate = lblAppDate;
                    item.lblBayan = lblBayan;
                    item.lblBillofLading = lblBillofLading;
                    item.lblContainer = lblContainer;
                    item.lblTmsBookingRef = lblTmsBookingRef;
                    item.lblBookingStatus = lblBookingStatus;
                    lstAppointmentlst.Add(item);
                }
                await Task.Delay(1000);
                totalRecordCount = objRawData.Count.ToString();
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                if (lstAppointmentlst == null || lstAppointmentlst.Count == 0)
                {
                   App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                CollectionView cvAppointmentBooking = Myview.FindByName<CollectionView>("GridAppointment");
                cvAppointmentBooking.ItemsSource = null;
                cvAppointmentBooking.ItemsSource = lstAppointmentlst;
                cvAppointmentBooking.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                IsBusy = false;
                StackAppointment = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// open pedf url in function
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        private async void OpenPdfPINo(string fstrContainerNo)
        {
            await Task.Delay(1000);
            // https://localhost:44336/AppointBooking/OpenPDFInvoice?fstrPINNo=1589851&fstrProformaInvoiceFlag=N
            //https://localhost:44336/AppointBooking/OpenAppointmentPDFInvoice?fstrContainerNo=WHSU5243376&, string fstrMobileNo, string fstrIDNo, string fstrRecipient

            string strURL = AppSettings.MobWebUrl;
            var pdfUrl = strURL + "/AppointBooking/OpenAppointmentPDFInvoice?" + "fstrContainerNo=" + fstrContainerNo + "&fstrMobileNo=" + gblRegisteration.strLoginMobileNO + "&fstrIDNo=" + gblRegisteration.strIdNo + "&fstrRecipient=" + gblRegisteration.strLoginFirstName + "";
            await Browser.OpenAsync(pdfUrl, BrowserLaunchMode.SystemPreferred);
        }
        /// <summary>
        /// To handle open pdf web url Function
        /// </summary>
        /// <param name="fobjBookingDt"></param>
        private async void OpenUrl(BookingDt fobjBookingDt)
        {
            await Task.Delay(1000);
            var Url = "https://www.fasah.sa/trade/home/en/index.html";
            await Browser.OpenAsync(Url, BrowserLaunchMode.SystemPreferred);
        }
        /// <summary>
        /// ClickApply Event
        /// </summary>
        /// <returns></returns>
        private async Task ClickedApply()
        {
            try
            {
                IsBusy = true;
                StackAppointment = false;
                await Task.Delay(1000);
                var strSelectedStatus = "";
                var strBillofLadingNo = "";
                var strContainerNo = "";
                var strTmsReference = "";
                var strAppDate = "";
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
                if (txtBillofLadingNo != null)
                {
                    strBillofLadingNo = txtBillofLadingNo;
                }
                if (txtContainerNo != null)
                {
                    strContainerNo = txtContainerNo;
                }
                if (TxtTmsReference != null)
                {
                    strTmsReference = txtTmsReference;
                }
                if (LstrAppointment != null)
                {
                    strAppDate = lstrAppointment;
                }
                if (DateApp != null)
                {
                    lstrAppDate = DateApp.Value.ToString("yyyy-MM-dd");
                }
                if (strSelectedStatus.Length > 0) strSelectedStatus = strSelectedStatus.Substring(0, strSelectedStatus.Length - 1);
                //App.Current.MainPage?.Navigation.PushAsync(new AppointmentBooking("", strBillofLadingNo, strContainerNo, strTmsReference, strAppDate, strSelectedStatus, lstrAppDate,""));
               await BookingList("", strBillofLadingNo, strContainerNo, strTmsReference, strAppDate, strSelectedStatus, lstrAppDate);
                IsVisibleAppointFilter = false;
                IsVisibleAppointmentBooking = true;
                IsBusy = false;
                StackAppointment = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }  
        }
    }
}