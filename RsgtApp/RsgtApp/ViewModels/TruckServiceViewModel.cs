using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    class TruckServiceViewModel : INotifyPropertyChanged
    {
        //To assign CMS
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
     //   private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        BLConnect objBl = new BLConnect();
        WebApiMethod objWeb = new WebApiMethod();
        Dictionary<string, string> lobjServiceRequest { get; set; } = new Dictionary<string, string>();
        public Command Button_TruckService_Message { get; set; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        private string strServerSlowMsg = "";

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

        public List<EnumCombo> _lobjLocation { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjLocation
        {
            get { return _lobjLocation; }
            set
            {
                if (_lobjLocation == value)
                    return;
                _lobjLocation = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjLocation");
            }
        }

        public List<EnumCombo> _lobjTypeDamage1 { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjTypeDamage1
        {
            get { return _lobjTypeDamage1; }
            set
            {
                if (_lobjTypeDamage1 == value)
                    return;
                _lobjTypeDamage1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjTypeDamage1");
            }
        }

        public List<EnumCombo> _lobjListOfEqu { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjListOfEqu
        {
            get { return _lobjListOfEqu; }
            set
            {
                if (_lobjListOfEqu == value)
                    return;
                _lobjListOfEqu = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjListOfEqu");
            }
        }

        //SelectedLocation For Combovariable
        private EnumCombo _selectedLocation;
        public EnumCombo SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                SetProperty(ref _selectedLocation, value);
            }
        }
        //SelectedTypeDamage1 For Combovariable
        private EnumCombo _selectedTypeDamage1;
        public EnumCombo SelectedTypeDamage1
        {
            get { return _selectedTypeDamage1; }
            set
            {
                SetProperty(ref _selectedTypeDamage1, value);
            }
        }
        //SelectedListOfEqu For Combovariable
        private EnumCombo _selectedListOfEqu;
        public EnumCombo SelectedListOfEqu
        {
            get { return _selectedListOfEqu; }
            set
            {
                SetProperty(ref _selectedListOfEqu, value);
            }
        }
        //imgRequestIcon purpose of using lable varaiable
        private string imgrequestIcon = "";
        public string imgRequestIcon
        {
            get { return imgrequestIcon; }
            set
            {
                imgrequestIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRequestIcon");
            }
        }
        //lblTruckService purpose of using lable varaiable
        private string lbltruckService = "";
        public string lblTruckService
        {
            get { return lbltruckService; }
            set
            {
                lbltruckService = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTruckService");
            }
        }
        //lblTruckNo purpose of using lable varaiable
        private string lbltruckNo = "";
        public string lblTruckNo
        {
            get { return lbltruckNo; }
            set
            {
                lbltruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTruckNo");
            }
        }
        //TxtTruckNo purpose of using Textbox varaiable
        private string txtTruckNo = "";
        public string TxtTruckNo
        {
            get { return txtTruckNo; }
            set
            {
                txtTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTruckNo");
            }
        }
        //PlaceTruckNo purpose of using Placeholder
        private string placeTruckNo = "";
        public string PlaceTruckNo
        {
            get { return placeTruckNo; }
            set
            {
                placeTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceTruckNo");
            }
        }
        //MsgTrckNo purpose of using lable varaiable
        private string msgTrckNo = "";
        public string MsgTrckNo
        {
            get { return msgTrckNo; }
            set
            {
                msgTrckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTrckNo");
            }
        }
        //lblLocation purpose of using lable varaiable
        private string lbllocation = "";
        public string lblLocation
        {
            get { return lbllocation; }
            set
            {
                lbllocation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLocation");
            }
        }
        //MsgLocation purpose of using lable varaiable
        private string msgLocation = "";
        public string MsgLocation
        {
            get { return msgLocation; }
            set
            {
                msgLocation = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLocation");
            }
        }
        //lblTypeDamage purpose of using lable varaiable
        private string lbltypeDamage = "";
        public string lblTypeDamage
        {
            get { return lbltypeDamage; }
            set
            {
                lbltypeDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTypeDamage");
            }
        }
        //MsgTypeDamage purpose of using lable varaiable
        private string msgTypeDamage = "";
        public string MsgTypeDamage
        {
            get { return msgTypeDamage; }
            set
            {
                msgTypeDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTypeDamage");
            }
        }
        //lblReportDate purpose of using lable varaiable
        private string lblreportDate = "";
        public string lblReportDate
        {
            get { return lblreportDate; }
            set
            {
                lblreportDate = value;
                OnPropertyChanged();
                RaisePropertyChange("lblReportDate");
            }
        }
        //lblListOfEqu purpose of using lable varaiable
        private string lbllistOfEqu = "";
        public string lblListOfEqu
        {
            get { return lbllistOfEqu; }
            set
            {
                lbllistOfEqu = value;
                OnPropertyChanged();
                RaisePropertyChange("lblListOfEqu");
            }
        }
        //btnSubmit purpose of using Button varaiable
        private string btnsubmit = "";
        public string btnSubmit
        {
            get { return btnsubmit; }
            set
            {
                btnsubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("btnSubmit");
            }
        }
        //TruckEn purpose of using lable varaiable
        private bool truckEn = true;
        public bool TruckEn
        {
            get { return truckEn; }
            set
            {
                truckEn = value;
                OnPropertyChanged();
                RaisePropertyChange("TruckEn");
            }
        }
        //IsvalidatedTruckNo purpose of using Validation
        private bool isvalidatedTruckNo = false;
        public bool IsvalidatedTruckNo
        {
            get { return isvalidatedTruckNo; }
            set
            {
                isvalidatedTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedTruckNo");
            }
        }
        //IsvalidatedLocation purpose of using Validation
        private bool isvalidatedLocation = false;
        public bool IsvalidatedLocation
        {
            get { return isvalidatedLocation; }
            set
            {
                isvalidatedLocation = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedLocation");
            }
        }
        //IsvalidatedDamage purpose of using Validation
        private bool isvalidatedDamage = false;
        public bool IsvalidatedDamage
        {
            get { return isvalidatedDamage; }
            set
            {
                isvalidatedDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedDamage");
            }
        }
        //Date Picker 
        private DateTime? reportDate = null;
        public DateTime? ReportDate
        {
            get { return reportDate; }
            set
            {
                reportDate = value;
                OnPropertyChanged();
                RaisePropertyChange("ReportDate");
            }
        }
        //To Handle Boolean Variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Button_TruckService_Message.ChangeCanExecute();
            }
        }
        //ViewModel Constructor
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public TruckServiceViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("TruckServiceViewModel");
            Task.Run(() => assignCms()).Wait();
            Button_TruckService_Message = new Command(async () => await button_truckService_message(), () => !IsBusy); 
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM432");
                    objCMSMsg = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM432");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
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
              
                dbLayer.objInfoitems = objCMS;
                lobjLocation = dbLayer.getEnum("strLocationlov", objCMS);
                lobjTypeDamage1 = dbLayer.getEnum("strTypeofDamagelov", objCMS);
                lobjListOfEqu = dbLayer.getEnum("strListofEquipmentslov", objCMS);
                imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
                lblTruckService = dbLayer.getCaption("strTruckServiceRequestForm", objCMS);
                lblTruckNo = dbLayer.getCaption("strTruckNo", objCMS);
                lblLocation = dbLayer.getCaption("strLocation", objCMS);
                lblTypeDamage = dbLayer.getCaption("strTypeofDamage", objCMS);
                lblReportDate = dbLayer.getCaption("strReportDate", objCMS);
                lblListOfEqu = dbLayer.getCaption("strListofEquipments", objCMS);
                btnSubmit = dbLayer.getCaption("strSubmit", objCMS);
                lobjServiceRequest =  dbLayer.getRequestLOV("strTruckServiceRequestlov", objCMS);
                msgTrckNo = dbLayer.getCaption("strMandatory", objCMSMsg);
                msgLocation = dbLayer.getCaption("strMandatory", objCMSMsg);
                msgTypeDamage = dbLayer.getCaption("strMandatory", objCMSMsg);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
       
        /// <summary>
        /// To get truckService message
        /// </summary>
        /// <returns></returns>
        private async Task button_truckService_message()
        {
            IsBusy = true;
            TruckEn = false;
            await Task.Delay(1000);
            var lstrTruckNo = "";
            var lstrTypeOfDamage = "";
            var lstrLocation = "";
            var lstrListOfEqu = "";
            var lstrDate = "";
            var lstrResult = "";
            string lstrTicketmsg = "";
            try
            {
                if ((TxtTruckNo == null) || (TxtTruckNo == ""))
                {
                    IsvalidatedTruckNo = true;
                }
                else
                {
                    lstrTruckNo = TxtTruckNo;
                    gblTrackRequests.strTruckNo = TxtTruckNo;
                    IsvalidatedTruckNo = false;
                }
                if (_selectedTypeDamage1 == null)
                {               
                    IsvalidatedDamage = true;
                }
                else
                {
                    gblTrackRequests.strTypeOfDamage = SelectedTypeDamage1.Value;
                    IsvalidatedDamage = false;
                }
                if (_selectedLocation == null)
                {
                    IsvalidatedLocation = true;
                }
                else
                {
                    gblTrackRequests.strLocation = SelectedLocation.Value;
                    IsvalidatedLocation = false;
                }
                if (_selectedListOfEqu != null)
                {
                  lstrListOfEqu = _selectedListOfEqu.Value;
                }
                if (ReportDate != null)
                {
                    //lstrDate = ReportDate;
                     lstrDate = ReportDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "T" + DateTime.Now.ToString("HH:mm:ss") + "Z";
                }
                lstrTicketmsg = "Truck Number:" + lstrTruckNo + "<br> Location:" 
                    + lstrLocation + "<br> Type of Damage:"
                    + lstrTypeOfDamage + "<br>Report Date:" + lstrDate +
                    "<br> List of Equipments:" + lstrListOfEqu + "<br>";
                if ((IsvalidatedDamage != true) && (IsvalidatedLocation != true) && (IsvalidatedTruckNo != true))
                {
                    string lstrTruckService = "";
                    foreach (var item in lobjServiceRequest)
                    {
                        lstrTruckService = item.Key;
                    }
                    string[] lstrTemp = lstrTruckService.Split(':');
                    gblTrackRequests.strTitle = "Truck Service Request";
                    gblTrackRequests.strCategoryCode = lstrTemp[0];
                    gblTrackRequests.strCategoryDesc1 = "";
                    gblTrackRequests.strCategoryDesc2 = "";
                    gblTrackRequests.strCaseCode = lstrTemp[1];
                    gblTrackRequests.strCaseDesc1 = "";
                    gblTrackRequests.strCaseDesc2 = "";
                    gblTrackRequests.strRequestTypeCode = lstrTemp[2];
                    gblTrackRequests.strRequestTypeDesc1 = "";
                    gblTrackRequests.strRequestTypeDesc2 = "";
                    gblTrackRequests.strSubCaseCode = lstrTemp[3];
                    gblTrackRequests.strSubCaseDesc1 = "";
                    gblTrackRequests.strSubCaseDesc2 = "";
                    await gblRegisteration.getreguser();
                    lstrResult = objWeb.postWebApi("NewTruckService", gblTrackRequests.TruckRequest(lstrTicketmsg, lstrDate));
                    if (lstrResult == "True")
                    {
                        objWeb.postWebApi("PostSendEmail", gblTrackRequests.TruckServiceMailData(lstrDate, lstrListOfEqu));
                        await App.Current.MainPage?.Navigation.PushAsync(new TruckService_Message());
                    }
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    await Task.Delay(1000);
                }
                IsBusy = false;
                TruckEn = true;        
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}