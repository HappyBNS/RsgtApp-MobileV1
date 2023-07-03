using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.BusinessLayer.BLConnect;
using static RsgtApp.Models.DashboardModel;

namespace RsgtApp.ViewModels
{
    public class DashboardTransporterViewModel : INotifyPropertyChanged
    {
        BLConnect objBl = new BLConnect();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<GETCOMMCREDENTIALS> lstrCredential = new List<GETCOMMCREDENTIALS>();
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;

        string LblInvoicingAmounts = "";

        public Command OnTappedReadytodeliver { get; set; }
        public Command OnTappedDetentionManagement { get; set; }
        public Command OnTappedBannedTruck { get; set; }
        public Command OnTappedEmptyUnitReturn { get; set; }
        public Command OnTapped { get; set; }
        public Command OnTappedDamageContainer { get; set; }
        public Command OnTappedTruckService { get; set; }
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

        private bool stackDashboardTransporter = true;
        public bool StackDashboardTransporter
        {
            get { return stackDashboardTransporter; }
            set
            {
                stackDashboardTransporter = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDashboardTransporter");
            }
        }

        private string imgDashboardIcon = "";
        public string ImgDashboardIcon
        {
            get { return imgDashboardIcon; }
            set
            {
                imgDashboardIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDashboardIcon");
            }
        }
        private string lblCountMsg = "";
        public string LblCountMsg
        {
            get { return lblCountMsg; }
            set
            {
                lblCountMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCountMsg");
            }
        }
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
        private string lblReadyDeliver = "";
        public string LblReadyDeliver
        {
            get { return lblReadyDeliver; }
            set
            {
                lblReadyDeliver = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReadyDeliver");
            }
        }
        private string lblNoOfUnits = "";
        public string LblNoOfUnits
        {
            get { return lblNoOfUnits; }
            set
            {
                lblNoOfUnits = value;
                OnPropertyChanged();
                RaisePropertyChange("LblNoOfUnits");
            }
        }
        private string lblReadytoDeliver = "";
        public string LblReadytoDeliver
        {
            get { return lblReadytoDeliver; }
            set
            {
                lblReadytoDeliver = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReadytoDeliver");
            }
        }
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
        private string lblDetention = "";
        public string LblDetention
        {
            get { return lblDetention; }
            set
            {
                lblDetention = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDetention");
            }
        }
        private string lblUnitUnder = "";
        public string LblUnitUnder
        {
            get { return lblUnitUnder; }
            set
            {
                lblUnitUnder = value;
                OnPropertyChanged();
                RaisePropertyChange("LblUnitUnder");
            }
        }
        private string lblUNITNEARDENTIONCOUNT = "";
        public string LblUNITNEARDENTIONCOUNT
        {
            get { return lblUNITNEARDENTIONCOUNT; }
            set
            {
                lblUNITNEARDENTIONCOUNT = value;
                OnPropertyChanged();
                RaisePropertyChange("LblUNITNEARDENTIONCOUNT");
            }
        }
        private string lblUnitNear = "";
        public string LblUnitNear
        {
            get { return lblUnitNear; }
            set
            {
                lblUnitNear = value;
                OnPropertyChanged();
                RaisePropertyChange("LblUnitNear");
            }
        }
        private string lblUNITSUNDERDENTIONCOUNT = "";
        public string LblUNITSUNDERDENTIONCOUNT
        {
            get { return lblUNITSUNDERDENTIONCOUNT; }
            set
            {
                lblUNITSUNDERDENTIONCOUNT = value;
                OnPropertyChanged();
                RaisePropertyChange("LblUNITSUNDERDENTIONCOUNT");
            }
        }
        private string imgBannedtruckIcon = "";
        public string ImgBannedtruckIcon
        {
            get { return imgBannedtruckIcon; }
            set
            {
                imgBannedtruckIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBannedtruckIcon");
            }
        }
        private string lblBannedTrucks = "";
        public string LblBannedTrucks
        {
            get { return lblBannedTrucks; }
            set
            {
                lblBannedTrucks = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBannedTrucks");
            }
        }
        private string lblBannedTruck = "";
        public string LblBannedTruck
        {
            get { return lblBannedTruck; }
            set
            {
                lblBannedTruck = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBannedTruck");
            }
        }
        private string lblBANNEDTRUCKSCOUNT = "";
        public string LblBANNEDTRUCKSCOUNT
        {
            get { return lblBANNEDTRUCKSCOUNT; }
            set
            {
                lblBANNEDTRUCKSCOUNT = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBANNEDTRUCKSCOUNT");
            }
        }
        private string imgUnitreturnIcon = "";
        public string ImgUnitreturnIcon
        {
            get { return imgUnitreturnIcon; }
            set
            {
                imgUnitreturnIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgUnitreturnIcon");
            }
        }
        private string lblEmptyUnit = "";
        public string LblEmptyUnit
        {
            get { return lblEmptyUnit; }
            set
            {
                lblEmptyUnit = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmptyUnit");
            }
        }
        private string lblRsgt = "";
        public string LblRsgt
        {
            get { return lblRsgt; }
            set
            {
                lblRsgt = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRsgt");
            }
        }
        private string lblEURRSGTCOUNT = "";
        public string LblEURRSGTCOUNT
        {
            get { return lblEURRSGTCOUNT; }
            set
            {
                lblEURRSGTCOUNT = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEURRSGTCOUNT");
            }
        }
        private string lblOutside = "";
        public string LblOutside
        {
            get { return lblOutside; }
            set
            {
                lblOutside = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOutside");
            }
        }
        private string lblEUROUTSIDEEDCOUNT = "";
        public string LblEUROUTSIDEEDCOUNT
        {
            get { return lblEUROUTSIDEEDCOUNT; }
            set
            {
                lblEUROUTSIDEEDCOUNT = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEUROUTSIDEEDCOUNT");
            }
        }
        private string imginvoiceIcon = "";
        public string ImginvoiceIcon
        {
            get { return imginvoiceIcon; }
            set
            {
                imginvoiceIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImginvoiceIcon");
            }
        }
        private string lblInvoicing = "";
        public string LblInvoicing
        {
            get { return lblInvoicing; }
            set
            {
                lblInvoicing = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInvoicing");
            }
        }
        private string lblNoOfInvoices = "";
        public string LblNoOfInvoices
        {
            get { return lblNoOfInvoices; }
            set
            {
                lblNoOfInvoices = value;
                OnPropertyChanged();
                RaisePropertyChange("LblNoOfInvoices");
            }
        }
        private string lblInvoicingCount = "";
        public string LblInvoicingCount
        {
            get { return lblInvoicingCount; }
            set
            {
                lblInvoicingCount = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInvoicingCount");
            }
        }
        private string lblTotalPayable = "";
        public string LblTotalPayable
        {
            get { return lblTotalPayable; }
            set
            {
                lblTotalPayable = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTotalPayable");
            }
        }
        private string lblInvoicingAmount = "";
        public string LblInvoicingAmount
        {
            get { return lblInvoicingAmount; }
            set
            {
                lblInvoicingAmount = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInvoicingAmount");
            }
        }
        private string imgDamagedcontainerIcon = "";
        public string ImgDamagedcontainerIcon
        {
            get { return imgDamagedcontainerIcon; }
            set
            {
                imgDamagedcontainerIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDamagedcontainerIcon");
            }
        }
        private string lblReportContainer = "";
        public string LblReportContainer
        {
            get { return lblReportContainer; }
            set
            {
                lblReportContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReportContainer");
            }
        }
        private string imgTruckserviceIcon = "";
        public string ImgTruckserviceIcon
        {
            get { return imgTruckserviceIcon; }
            set
            {
                imgTruckserviceIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTruckserviceIcon");
            }
        }
        private string lblTruckRequest = "";
        public string LblTruckRequest
        {
            get { return lblTruckRequest; }
            set
            {
                lblTruckRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTruckRequest");
            }
        }

        private bool isVisibleReportContainer = false;
        public bool IsVisibleReportContainer
        {
            get { return isVisibleReportContainer; }
            set
            {
                isVisibleReportContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleReportContainer");
            }
        }
        private bool isVisibleTruckRequest = false;
        public bool IsVisibleTruckRequest
        {
            get { return isVisibleTruckRequest; }
            set
            {
                isVisibleTruckRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleTruckRequest");
            }
        }
        private string lblDashboard = "";
        public string LblDashboard
        {
            get { return lblDashboard; }
            set
            {
                lblDashboard = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDashboard");
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
                OnTappedReadytodeliver.ChangeCanExecute();
                OnTappedDetentionManagement.ChangeCanExecute();
                OnTappedBannedTruck.ChangeCanExecute();
                OnTappedEmptyUnitReturn.ChangeCanExecute();
                OnTapped.ChangeCanExecute();
                OnTappedDamageContainer.ChangeCanExecute();
                OnTappedTruckService.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel - Constructor
        /// </summary>
        public DashboardTransporterViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DashboardTransporterViewModel");
            Task.Run(() => assignCms()).Wait();
            OnTappedReadytodeliver = new Command(async () => await onTappedReadytodeliver(), () => !IsBusy);
            OnTappedDetentionManagement = new Command(async () => await onTappedDetentionManagement(), () => !IsBusy);
            OnTappedBannedTruck = new Command(async () => await onTappedBannedTruck(), () => !IsBusy);
            OnTappedEmptyUnitReturn = new Command(async () => await onTappedEmptyUnitReturn(), () => !IsBusy);
            OnTapped = new Command(async () => await onTapped(), () => !IsBusy);
            OnTappedDamageContainer = new Command(async () => await onTappedDamageContainer(), () => !IsBusy);
            OnTappedTruckService = new Command(async () => await onTappedTruckService(), () => !IsBusy);
            string fstrMailId = gblRegisteration.strLoginUser;
            Task.Run(() => dashboardData(fstrMailId)).Wait();
        }
        /// <summary>
        /// To bind assign cms
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM401");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM401");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM415");
                assignContent();

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To assign cms Captions
        /// </summary>
        public async void assignContent()
        {


            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;

            //}

            dbLayer.objInfoitems = objCMS;
             HideShowCredentials();
            await Task.Delay(5000);
            if (gblRegisteration.strLoginCustomerType == "Transporter")
            {
                if (lstrCredential.Count > 0)
                {
                    if (lstrCredential[0].cc_showreportdamagecontainer == "Y")
                    {
                        IsVisibleReportContainer = true;
                    }
                    if (lstrCredential[0].cc_showtruckservicerequest == "Y")
                    {
                        IsVisibleTruckRequest = true;
                    }
                }
            }

            ImgDashboardIcon = dbLayer.getCaption("imgDashboard", objCMS);
            LblDashboard = dbLayer.getCaption("strDashboard", objCMS);
            ImgReadytoloadIcon = dbLayer.getCaption("imgReadytoload", objCMS);
            LblReadyDeliver = dbLayer.getCaption("strReadytoDeliver", objCMS);
            // imgReeferiIcon = dbLayer.getCaption("imgReeferfree");
            // lblReeferDays = dbLayer.getCaption("strReeferFreeDays");
            // imgVolumeIcon = dbLayer.getCaption("imgVolumeupdate");
            //lblVolumeUpdate = dbLayer.getCaption("strVolumeUpdate");
            ImgDetentionIcon = dbLayer.getCaption("imgDetention", objCMS);
            LblDetention = dbLayer.getCaption("strDetention", objCMS);
            ImgBannedtruckIcon = dbLayer.getCaption("imgBannedtruck", objCMS);
            LblBannedTrucks = dbLayer.getCaption("strBannedTrucks", objCMS);
            ImgUnitreturnIcon = dbLayer.getCaption("imgUnitreturn", objCMS);
            LblEmptyUnit = dbLayer.getCaption("strEmptyUnitReturns", objCMS);
            ImginvoiceIcon = dbLayer.getCaption("imgInvoice", objCMS);
            LblInvoicing = dbLayer.getCaption("strInvoicing", objCMS);
            ImgDamagedcontainerIcon = dbLayer.getCaption("imgDamagedcontainer", objCMS);
            LblReportContainer = dbLayer.getCaption("strReportDamageContainer", objCMS);
            ImgTruckserviceIcon = dbLayer.getCaption("imgTruckservice", objCMS);
            LblTruckRequest = dbLayer.getCaption("strTruckServiceRequest", objCMS);
            LblNoOfUnits = dbLayer.getCaption("strNoofUnits", objCMS);
            LblInYard = dbLayer.getCaption("strInYard", objCMS);
            LblUnitUnder = dbLayer.getCaption("strDetentionSubHeading1", objCMS);
            LblUnitNear = dbLayer.getCaption("strDetentionSubHeading2", objCMS);
            LblBannedTruck = dbLayer.getCaption("strNoofbannedtrucks", objCMS);
            LblRsgt = dbLayer.getCaption("strRSGT", objCMS);
            LblOutside = dbLayer.getCaption("strOutsideDeport", objCMS);
            LblNoOfInvoices = dbLayer.getCaption("strNoofUnits", objCMS);
            LblTotalPayable = dbLayer.getCaption("strTotalPayable", objCMS);
            LblInvoicingAmounts = dbLayer.getCaption("strSAR", objCMS);
            LblCountMsg = dbLayer.getCaption("strCountMsg", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            await Task.Delay(1000);

        }
        /// <summary>
        /// To get Dashboard Data
        /// </summary>
        /// <param name="fstrMailId"></param>
        /// <returns></returns>
        private async Task dashboardData(string fstrMailId)
        {
            try
            {
                //output varible Declaration
                List<clsdashboardCountlist> objRawData = new List<clsdashboardCountlist>();

                //http://172.19.35.68:89/api/DataSource/getDashboard?fstrMailId=cieloconsignee@gmail.com

                objRawData = objBl.getDashboard(fstrMailId);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                if (objRawData.Count > 0)
                {
                    lblReadytoDeliver = objRawData[0].readytodeliverunitcount;
                    lblUNITNEARDENTIONCOUNT = objRawData[0].unitneardentioncount;
                    lblUNITSUNDERDENTIONCOUNT = objRawData[0].unitsunderdentioncount;
                    lblBANNEDTRUCKSCOUNT = objRawData[0].bannedtruckscount;
                    lblEURRSGTCOUNT = objRawData[0].eurrsgtcount;
                    lblEUROUTSIDEEDCOUNT = objRawData[0].euroutsideedcount;
                    lblInvoicingCount = objRawData[0].invoicescount;

                    var invoicesamount = string.Format("{0:0.00}", objRawData[0].invoicesamount);


                    lblInvoicingAmount = LblInvoicingAmounts + invoicesamount;

                }


            }
            catch (Exception ex)
            {

                await App.Current.MainPage?.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        /// <summary>
        /// To get Hide Show Credentials
        /// </summary>
        /// <returns></returns>
        private async void HideShowCredentials()
        {
            await Task.Delay(2000);
            lstrCredential = await objBl.getCommCredentials();
        }
        /// <summary>
        /// To get Tapped
        /// </summary>
        /// <returns></returns>
        private async Task onTapped()
        {
            IsBusy = true;
            StackDashboardTransporter = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "", "N"));
            //App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "", "", "", "", "", "", "", "","N"));
            StackDashboardTransporter = true;
            IsBusy = false;

        }
        /// <summary>
        /// To go to Detention Management
        /// </summary>
        /// <returns></returns>
        private async Task onTappedDetentionManagement()
        {
            IsBusy = true;
            StackDashboardTransporter = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new DetentionManagement("", "", "", "", ""));
            StackDashboardTransporter = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Ready to deliver
        /// </summary>
        /// <returns></returns>
        private async Task onTappedReadytodeliver()
        {
            IsBusy = true;
            StackDashboardTransporter = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ReadytoDelivery("", "", "", "", "", "", "", "", "", "", "N"));
            StackDashboardTransporter = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Empty Unit Return
        /// </summary>
        /// <returns></returns>
        private async Task onTappedEmptyUnitReturn()
        {
            IsBusy = true;
            StackDashboardTransporter = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new EmptyUnitReturn("", "", "", "", "", "", "", ""));
            StackDashboardTransporter = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Banned Truck
        /// </summary>
        /// <returns></returns>
        private async Task onTappedBannedTruck()
        {
            IsBusy = true;
            StackDashboardTransporter = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new BannedTrucks("", "", "", "", "", "Banned"));
            StackDashboardTransporter = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Damage Container
        /// </summary>
        /// <returns></returns>
        private async Task onTappedDamageContainer()
        {
            IsBusy = true;
            StackDashboardTransporter = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new DamageContainer());
            StackDashboardTransporter = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Truck Service
        /// </summary>
        /// <returns></returns>
        private async Task onTappedTruckService()
        {
            IsBusy = true;
            StackDashboardTransporter = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new TruckService());
            StackDashboardTransporter = true;
            IsBusy = false;
        }
    }
}
