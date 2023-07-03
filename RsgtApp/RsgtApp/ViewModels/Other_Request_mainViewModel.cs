using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using System.Reflection;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Models;
using static RsgtApp.BusinessLayer.BLConnect;

namespace RsgtApp.ViewModels
{
    public class OtherRequestmainViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private List<GETCOMMCREDENTIALS> lstrCredential = new List<GETCOMMCREDENTIALS>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command EIRrequest { get; set; }
        public Command ECrequest { get; set; }
        public Command MUrequest { get; set; }
        public Command OFFLrequest { get; set; }
        public Command OOGrequest { get; set; }
        public Command DDLrequest { get; set; }
        public Command AIrequest { get; set; }
        public Command ILErequest { get; set; }
        public Command ExtDetnrequest { get; set; }
        private string strServerSlowMsg = "";

        public event PropertyChangedEventHandler PropertyChanged;
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

        private bool stackOtherRequestMain = true;
        public bool StackOtherRequestMain
        {
            get { return stackOtherRequestMain; }
            set
            {
                stackOtherRequestMain = value;
                OnPropertyChanged();
                RaisePropertyChange("StackOtherRequestMain");
            }
        }

        private string imgaddService = "";
        public string imgAddService
        {
            get { return imgaddService; }
            set
            {
                imgaddService = value;
                OnPropertyChanged();
                RaisePropertyChange("imgAddService");
            }
        }
        private string lbladdService = "";
        public string lblAddService
        {
            get { return lbladdService; }
            set
            {
                lbladdService = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAddService");
            }
        }
        private string imgEIRIcon = "";
        public string ImgEIRIcon
        {
            get { return imgEIRIcon; }
            set
            {
                imgEIRIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEIRIcon");
            }
        }
        private string lbleIRRequest = "";
        public string lblEIRRequest
        {
            get { return lbleIRRequest; }
            set
            {
                lbleIRRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRRequest");
            }
        }
        private string imgextraCareMenuIcon = "";
        public string imgExtraCareMenuIcon
        {
            get { return imgextraCareMenuIcon; }
            set
            {
                imgextraCareMenuIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgExtraCareMenuIcon");
            }
        }
        private string lblextraCareRequest = "";
        public string lblExtraCareRequest
        {
            get { return lblextraCareRequest; }
            set
            {
                lblextraCareRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblExtraCareRequest");
            }
        }
        private string imgmanifestIcon = "";
        public string imgManifestIcon
        {
            get { return imgmanifestIcon; }
            set
            {
                imgmanifestIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgManifestIcon");
            }
        }
        private string lblmanifestUpdateRequest = "";
        public string lblManifestUpdateRequest
        {
            get { return lblmanifestUpdateRequest; }
            set
            {
                lblmanifestUpdateRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestUpdateRequest");
            }
        }
        private string imgoffloadIcon = "";
        public string imgOffloadIcon
        {
            get { return imgoffloadIcon; }
            set
            {
                imgoffloadIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgOffloadIcon");
            }
        }
        private string lbloffloadRequest = "";
        public string lblOffloadRequest
        {
            get { return lbloffloadRequest; }
            set
            {
                lbloffloadRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOffloadRequest");
            }
        }
        private string imgoOGIcon = "";
        public string imgOOGIcon
        {
            get { return imgoOGIcon; }
            set
            {
                imgoOGIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgOOGIcon");
            }
        }
        private string lbloOGRequest = "";
        public string lblOOGRequest
        {
            get { return lbloOGRequest; }
            set
            {
                lbloOGRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOOGRequest");
            }
        }
        private string imgdDLIcon = "";
        public string imgDDLIcon
        {
            get { return imgdDLIcon; }
            set
            {
                imgdDLIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDDLIcon");
            }
        }
        private string lbldDRequest = "";
        public string lblDDRequest
        {
            get { return lbldDRequest; }
            set
            {
                lbldDRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDDRequest");
            }
        }
        private string imgvisitorIcon = "";
        public string imgVisitorIcon
        {
            get { return imgvisitorIcon; }
            set
            {
                imgvisitorIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgVisitorIcon");
            }
        }
        private string lblattendInspection = "";
        public string lblAttendInspection
        {
            get { return lblattendInspection; }
            set
            {
                lblattendInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttendInspection");
            }
        }
        private string imgequipmentIcon = "";
        public string imgEquipmentIcon
        {
            get { return imgequipmentIcon; }
            set
            {
                imgequipmentIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEquipmentIcon");
            }
        }
        private string lblinlocation = "";
        public string lblInlocation
        {
            get { return lblinlocation; }
            set
            {
                lblinlocation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInlocation");
            }
        }

        private bool isVisibleinlocation = false;
        public bool IsVisibleinlocation
        {
            get { return isVisibleinlocation; }
            set
            {
                isVisibleinlocation = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleinlocation");
            }
        }


        private bool isvisibleInLocation = false;
        public bool IsvisibleInLocation
        {
            get { return isvisibleInLocation; }
            set
            {
                isvisibleInLocation = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleInLocation");
            }
        }
        private bool isvisibleAttendInspection = false;
        public bool IsvisibleAttendInspection
        {
            get { return isvisibleAttendInspection; }
            set
            {
                isvisibleAttendInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleAttendInspection");
            }
        }
        private bool isvisibleDirectDelivery = false;
        public bool IsvisibleDirectDelivery
        {
            get { return isvisibleDirectDelivery; }
            set
            {
                isvisibleDirectDelivery = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleDirectDelivery");
            }
        }
        private bool isvisibleOOG = false;
        public bool IsvisibleOOG
        {
            get { return isvisibleOOG; }
            set
            {
                isvisibleOOG = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleOOG");
            }
        }
        private bool isvisibleOffLoad = false;
        public bool IsvisibleOffLoad
        {
            get { return isvisibleOffLoad; }
            set
            {
                isvisibleOffLoad = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleOffLoad");
            }
        }
        private bool isvisibleManiFest = false;
        public bool IsvisibleManiFest
        {
            get { return isvisibleManiFest; }
            set
            {
                isvisibleManiFest = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleManiFest");
            }
        }
        private bool isvisibleExtraCare = false;
        public bool IsvisibleExtraCare
        {
            get { return isvisibleExtraCare; }
            set
            {
                isvisibleExtraCare = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleExtraCare");
            }
        }
        private bool isvisibleEIR = false;
        public bool IsvisibleEIR
        {
            get { return isvisibleEIR; }
            set
            {
                isvisibleEIR = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleEIR");
            }
        }
        private bool isVisibleExtendedDetention = false;
        public bool IsVisibleExtendedDetention
        {
            get { return isVisibleExtendedDetention; }
            set
            {
                isVisibleExtendedDetention = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleExtendedDetention");
            }
        }
        private string imgdetentionIcon = "";
        public string imgdetentionicon
        {
            get { return imgdetentionIcon; }
            set
            {
                imgdetentionIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgdetentionicon");
            }
        }
        private string lblExtenddetention = "";
        public string lblExtendDetention
        {
            get { return lblExtenddetention; }
            set
            {
                lblExtenddetention = value;
                OnPropertyChanged();
                RaisePropertyChange("lblExtendDetention");
            }
        }

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
                EIRrequest.ChangeCanExecute();
                ECrequest.ChangeCanExecute();
                MUrequest.ChangeCanExecute();
                OFFLrequest.ChangeCanExecute();
                OOGrequest.ChangeCanExecute();
                DDLrequest.ChangeCanExecute();
                AIrequest.ChangeCanExecute();
                ILErequest.ChangeCanExecute();
                ExtDetnrequest.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public OtherRequestmainViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("OtherRequestmainViewModel");
            Task.Run(() => assignCms()).Wait();
            EIRrequest = new Command(async () => await EIrrequest(), () => !IsBusy);
            ECrequest = new Command(async () => await Ecrequest(), () => !IsBusy);
            MUrequest = new Command(async () => await Murequest(), () => !IsBusy);
            OFFLrequest = new Command(async () => await OFFlrequest(), () => !IsBusy);
            OOGrequest = new Command(async () => await OOgrequest(), () => !IsBusy);
            DDLrequest = new Command(async () => await DDlrequest(), () => !IsBusy);
            AIrequest = new Command(async () => await Airequest(), () => !IsBusy);
            ILErequest = new Command(async () => await ILerequest(), () => !IsBusy);
            ExtDetnrequest = new Command(async () => await Extdetnrequest(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM015");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM015");

                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
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
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            await HideShowCredentials();
            //As per Mr.Anand Advised
            //User based Screen Restriction handled by Gokul on20221219 



            //As Per Client Request to  enable based on customer type
            //User based Screen Restriction handled by Gokul on 20230413

            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "TRANSPORTER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CONSIGNEE") ||
                    (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CLEARING AGENT") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPER")
                || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "BROKER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPING LINE"))
            {
                if (lstrCredential.Count > 0)
                {
                    if (lstrCredential[0].cc_showdirectdelivery == "Y")
                    {
                        IsvisibleDirectDelivery = true;
                    }
                }
            }

            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "TRANSPORTER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CONSIGNEE") ||
                (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CLEARING AGENT") ||
            (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "BROKER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPING LINE"))
            {
                if (lstrCredential.Count > 0)
                {


                    if (lstrCredential[0].cc_showeircopy == "Y")
                    {
                        IsvisibleEIR = true;
                    }

                }

            }
            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "TRANSPORTER"))
            {
                if (lstrCredential.Count > 0)
                {
                    if (lstrCredential[0].cc_showinlocation == "Y")
                    {
                        IsvisibleInLocation = true;
                    }
                }
            }
            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPING LINE"))
            {
                if (lstrCredential.Count > 0)
                {
                    if (lstrCredential[0].cc_showextracare == "Y")
                    {
                        IsvisibleExtraCare = true;
                    }
                    if (lstrCredential[0].cc_showmanifest == "Y")
                    {
                        IsvisibleManiFest = true;
                    }
                    if (lstrCredential[0].cc_showoog == "Y")
                    {
                        IsvisibleOOG = true;
                    }
                }
            }

            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPING LINE") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "TRANSPORTER"))
            {

                if (lstrCredential.Count > 0)
                {

                    if (lstrCredential[0].cc_showoffload == "Y")
                    {
                        IsvisibleOffLoad = true;
                    }



                }
            }
            if (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPING LINE")
            {

                if (lstrCredential.Count > 0)
                {

                    if (lstrCredential[0].cc_showoffload == "Y")
                    {
                        IsVisibleExtendedDetention = true;
                    }

                }
            }
            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CONSIGNEE") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CLEARING AGENT") ||
                    (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "BROKER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPER"))
            {
                if (lstrCredential.Count > 0)
                {
                    if (lstrCredential[0].cc_showattendinspection == "Y")
                    {
                        IsvisibleAttendInspection = true;
                    }
                }

            }
            
            imgAddService = dbLayer.getCaption("imgAdditionalServices", objCMS);
            lblAddService = dbLayer.getCaption("strAdditionalServices", objCMS);
            ImgEIRIcon = dbLayer.getCaption("imgEIR", objCMS);
            lblEIRRequest = dbLayer.getCaption("strEIRRequest", objCMS);
            imgExtraCareMenuIcon = dbLayer.getCaption("imgExtracare", objCMS);
            lblExtraCareRequest = dbLayer.getCaption("strExtraCareRequest", objCMS);
            imgManifestIcon = dbLayer.getCaption("imgManifest", objCMS);
            lblManifestUpdateRequest = dbLayer.getCaption("strManifestUpdateRequest", objCMS);
            imgOffloadIcon = dbLayer.getCaption("imgoffload", objCMS);
            lblOffloadRequest = dbLayer.getCaption("strOffloadRequest", objCMS);
            imgOOGIcon = dbLayer.getCaption("imgOOGbreakbulk", objCMS);
            lblOOGRequest = dbLayer.getCaption("strOOGBreakbulkRequest", objCMS);
            imgDDLIcon = dbLayer.getCaption("imgDDLicon", objCMS);
            lblDDRequest = dbLayer.getCaption("strDirectDeliveryRequest", objCMS);
            imgVisitorIcon = dbLayer.getCaption("imgvisitor", objCMS);
            lblAttendInspection = dbLayer.getCaption("strAttendInspectionRequest", objCMS);
            imgEquipmentIcon = dbLayer.getCaption("imgEquipmentLightblue", objCMS);
            lblInlocation = dbLayer.getCaption("strInlocationEquipmentRequest", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            lblExtendDetention = dbLayer.getCaption("strExtendDetention", objCMS);
            imgdetentionicon = dbLayer.getCaption("imgDetention", objCMS);

            await Task.Delay(1000);
        }
        private async Task Extdetnrequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ExtendDetentionMain());
            StackOtherRequestMain = true;
            IsBusy = false;
        }


        /// <summary>
        /// To go to EIR Request
        /// </summary>
        /// <returns></returns>
        private async Task EIrrequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new EIR_Request_step1());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Extra care Addcontainer
        /// </summary>
        /// <returns></returns>
        private async Task Ecrequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Extracare_Addcontainer());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Manifest Update Request
        /// </summary>
        /// <returns></returns>
        private async Task Murequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ManifestUpdateRequest1());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Offload Request
        /// </summary>
        /// <returns></returns>
        private async Task OFFlrequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Offloadrequest_1());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Oog BreakBulk Request
        /// </summary>
        /// <returns></returns>
        private async Task OOgrequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new OogBreakBulkRequest());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Direct Delivery Request
        /// </summary>
        /// <returns></returns>
        private async Task DDlrequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryRequest1());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Attend Inspection Request
        /// </summary>
        /// <returns></returns>
        private async Task Airequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Attendinspection_request1());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Inlocation Request
        /// </summary>
        /// <returns></returns>
        private async Task ILerequest()
        {
            IsBusy = true;
            StackOtherRequestMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Inlocationequipment_request1());
            StackOtherRequestMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get HideShowCredentials
        /// </summary>
        /// <returns></returns>
        private async Task HideShowCredentials()
        {
            lstrCredential = await objBl.getCommCredentials();
            await Task.Delay(1000);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
        }
    }
}
