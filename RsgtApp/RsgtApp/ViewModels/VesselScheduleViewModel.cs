using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
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
using static RsgtApp.Models.VesselScheduleModel;

namespace RsgtApp.ViewModels
{
    public class VesselScheduleViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();

       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //OnVesselArrival Button 
        public Command OnTappedVesselArrival { get; set; }

        //OnVesselInport Button 
        public Command OnTappedVesselInport { get; set; }

        //OnVesselDeparture Button 
        public Command OnTappedVesselDeparture { get; set; }

        //Search Button 
        public Command ApplySearch { get; set; }

        //To create Collection Object used ObservableCollection
        //public ObservableCollection<InportDtlist> lstVesselDTLs { get; set; } = new ObservableCollection<InportDtlist>();
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
        private string vesselTitle = "VesselSchedule";

        //Readonly Property
        public string VesselTitle
        {
            get { return vesselTitle; }

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
        //To Declare Static Variables
        private string strInport = "Inport";
        private string strArrival = "Arrival";
        private string strDeparture = "Departure";
        private int fintPageSize = 1000;
        private int fintPageNo = 1;
        public string strNoRecord = "";
        public string lblstrVesselName = "";
        public string lblstrStatus = "";
        public string lblstrEta = "";
        public string lblstrAtd = "";
        public string strimgDownArrow = "";
        public string lblstrVisitId = "";
        public string lblstrVoyage = "";
        public string lblstrServiceId = "";
        public string lblstrCutOffTime = "";
        public string strServerSlowMsg = "";

        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;

            }
        }
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;

            }
        }

        private ObservableCollection<InportDtlist> _lstVesselDTLs { get; set; } = new ObservableCollection<InportDtlist>();
     
        public ObservableCollection<InportDtlist> lstVesselDTLs
        {
            get { return _lstVesselDTLs; }
            set
            {
                _lstVesselDTLs = value;
                OnPropertyChanged();
                RaisePropertyChange("lstVesselDTLs");
            }
        }
        //To Declare activeInport Text Variable
        private string activeInport = "";
        public string ActiveInport
        {
            get { return activeInport; }
            set
            {
                activeInport = value;
                OnPropertyChanged();
                RaisePropertyChange("ActiveInport");
            }
        }
        private string strTotalCaption = "";
        //To Declare searchbox Text Variable
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
        //To Declare strOrgin Text Variable
        private string strOrgin = "";
        public string StrOrgin
        {
            get { return strOrgin; }
            set
            {
                strOrgin = value;
                OnPropertyChanged();
                RaisePropertyChange("StrOrgin");
            }
        }
        //To Declare activeArrival Text Variable
        private string activeArrival = "";
        public string ActiveArrival
        {
            get { return activeArrival; }
            set
            {
                activeArrival = value;
                OnPropertyChanged();
                RaisePropertyChange("ActiveArrival");
            }
        }
        //To Declare activeDeparture Text Variable
        private string activeDeparture = "";
        public string ActiveDeparture
        {
            get { return activeDeparture; }
            set
            {
                activeDeparture = value;
                OnPropertyChanged();
                RaisePropertyChange("ActiveDeparture");
            }
        }
        //To Declare imgTabInportIcon image
        private string imgTabInportIcon = "";
        public string ImgTabInportIcon
        {
            get { return imgTabInportIcon; }
            set
            {
                imgTabInportIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTabInportIcon");
            }
        }
        //To Declare lblInPort label
        private string lblInPort = "";
        public string LblInPort
        {
            get { return lblInPort; }
            set
            {
                lblInPort = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInPort");
            }
        }
        //To Declare imgTabArrivalIcon image
        private string imgTabArrivalIcon = "";
        public string ImgTabArrivalIcon
        {
            get { return imgTabArrivalIcon; }
            set
            {
                imgTabArrivalIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTabArrivalIcon");
            }
        }
        //To Declare lblArrival label
        private string lblArrival = "";
        public string LblArrival
        {
            get { return lblArrival; }
            set
            {
                lblArrival = value;
                OnPropertyChanged();
                RaisePropertyChange("LblArrival");
            }
        }
        //To Declare imgTabInportDepature image
        private string imgTabInportDepature = "";
        public string ImgTabInportDepature
        {
            get { return imgTabInportDepature; }
            set
            {
                imgTabInportDepature = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTabInportDepature");
            }
        }
        //To Declare lblDeparture label
        private string lblDeparture = "";
        public string LblDeparture
        {
            get { return lblDeparture; }
            set
            {
                lblDeparture = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDeparture");
            }
        }
        //To Declare btnLoadMore button
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
        //To Declare txtSearch text
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

        //To Declare Indicator
        bool vesselEn = true;
        public bool VesselEn
        {
            get { return vesselEn; }
            set
            {
                vesselEn = value;

                OnPropertyChanged();
                RaisePropertyChange("VesselEn");
            }
        }

        //To Declare Indicator
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                OnTappedVesselArrival.ChangeCanExecute();
                OnTappedVesselInport.ChangeCanExecute();
                OnTappedVesselDeparture.ChangeCanExecute();
            }
        }

        //To Declare Indicator
        bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;

                OnPropertyChanged();
                RaisePropertyChange("IsRefreshing");
                OnTappedVesselArrival.ChangeCanExecute();
                OnTappedVesselInport.ChangeCanExecute();
                OnTappedVesselDeparture.ChangeCanExecute();
            }
        }


       
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        //ViewModel Constructor For VesselSchedule 
        public VesselScheduleViewModel(string fstrOrgin)
        {
            try
            {
               //Myview = view;
                //Appcenter Track Event handler
                Analytics.TrackEvent("VesselScheduleViewModel");
                //Begin-Call Caption Function
                Task.Run(() => assignCMS()).Wait();
                //End-Caption Function

                //Begin-All Command Buttons
                //OnTappedVesselInport = new Command(async () => await VesselBindData(fintPageSize, fintPageNo, strInport, ""), () => !IsBusy);
                OnTappedVesselInport = new Command(async () => await VesselFetchData(strInport), () => !IsBusy);
                OnTappedVesselArrival = new Command(async () => await VesselFetchData(strArrival), () => !IsBusy);
                OnTappedVesselDeparture = new Command(async () => await VesselFetchData(strDeparture), () => !IsBusy);
                ApplySearch = new Command(async () => await VesselBindData(fintPageSize, fintPageNo, strOrgin, searchbox), () => !IsBusy);
                //End-All Command Buttons
                
                

                //Web Api Data call method
                Task.Run(() => VesselBindData(fintPageSize, fintPageNo, fstrOrgin, "")).Wait();
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 

        //To Bind Data Color change
        private async Task VesselBindData(int fintPageSize, int fintPageNumber, string fstrOrgin, string fstrFilter)
        {
            try
            {
                string lstrGreenTheme = "#2fa66c";
                string lstrLightTheme = "#0073a2";
               // string lstrSelectedTheme = "#01adef";
                string lstrSelectedNewTheme = "#8daeba";

                IsBusy = true;
                VesselEn = false;
              
                //Initiate Collection Object
                _lstVesselDTLs.Clear();
                 await Task.Delay(2000);
                var objRawData = new List<InportDtlist>();
                strOrgin = fstrOrgin;
                if (App.gblSelectedTheme == "3")
                {
                    ActiveInport = lstrGreenTheme;
                    ActiveDeparture = lstrGreenTheme;
                    ActiveArrival = lstrGreenTheme;
                }
                else
                {
                    ActiveInport = lstrLightTheme;
                    ActiveDeparture = lstrLightTheme;
                    ActiveArrival = lstrLightTheme;
                }
                
                //Selected Tap
                if (fstrOrgin == "Inport")
                {
                    ActiveInport = lstrSelectedNewTheme;
                    
                }
                else if (fstrOrgin == "Arrival")
                {
                    ActiveArrival = lstrSelectedNewTheme;
                   
                }
                else if (fstrOrgin == "Departure")
                {
                    ActiveDeparture = lstrSelectedNewTheme;
                   
                }               

                Searchbox = fstrFilter;
                //To call bussinesslayer 
                objRawData = objBl.getVesselScheduleDetails(fintPageSize, fintPageNumber, fstrFilter, fstrOrgin);
                objRawData = objRawData.Where(x => x.scheduleType.StartsWith(fstrOrgin.ToUpper())).ToList();



               // objRawData = objRawData.OrderByDescending(x => x.VD_ACTUALTIMEOFDEPARTURE).ToList();
                if (fstrOrgin == "Arrival")
                {
                   // objRawData = objRawData.OrderBy(x => x.VD_EXPECTEDTIMEOFARRIVAL).ToList();
                }

                totalRecordCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                foreach (var item in objRawData)
                {
                    lstVesselDTLs.Add(item);
                    
                }
                //CollectionView cvVesselSchedule = Myview.FindByName<CollectionView>("GridVesselSchedule");
                //cvVesselSchedule.ItemsSource = null;
                //cvVesselSchedule.ItemsSource = lstVesselDTLs;
                //cvVesselSchedule.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;

                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                if (lstVesselDTLs == null || lstVesselDTLs.Count == 0)
                {
                   App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            VesselEn = true;
            IsBusy = false;           
        }

       
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async Task assignCMS()
        {
            try
            {
                
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM007");
                    objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                     objCMS = await dbLayer.LoadContent("RM007");
                     objCMSMSG =await dbLayer.LoadContent("RM026");
                }
               await assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        // Method is for Assign Content
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async Task assignContent()
        {
            try
            {
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
               
              
                dbLayer.objInfoitems = objCMS;
                imgTabInportIcon = dbLayer.getCaption("imgInporticon", objCMS);
                lblInPort = dbLayer.getCaption("strInPort", objCMS);
                imgTabArrivalIcon = dbLayer.getCaption("imgArrivalicon", objCMS);
                lblArrival = dbLayer.getCaption("strArrival", objCMS);
                imgTabInportDepature = dbLayer.getCaption("imgDepartureicon", objCMS);
                lblDeparture = dbLayer.getCaption("strDeparture", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                txtSearch = dbLayer.getCaption("strPlaceHolderVessel", objCMS);
                strTotalCaption = dbLayer.getCaption("strVesselSchedules", objCMS);
                lblstrVesselName = dbLayer.getCaption("strVesselName", objCMS);
                lblstrStatus = dbLayer.getCaption("strStatus", objCMS);
                lblstrEta = dbLayer.getCaption("strETA", objCMS);
                lblstrAtd = dbLayer.getCaption("strATD", objCMS);
                strimgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                lblstrVisitId = dbLayer.getCaption("strVisitId", objCMS);
                lblstrVoyage = dbLayer.getCaption("strVoyage", objCMS);
                lblstrServiceId = dbLayer.getCaption("strServiceId", objCMS);
                lblstrCutOffTime = dbLayer.getCaption("strCutOffTime", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMSG);
                await SecureStorage.GetAsync("V");
                
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get VesselFetchData
        /// </summary>
        /// <returns></returns>
        private async Task VesselFetchData(string fstrOrgin)
        {
            IsBusy = true;
            VesselEn = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new VesselSchedule(fstrOrgin));           
            VesselEn = true;
            IsBusy = false;
        }
    }
}


