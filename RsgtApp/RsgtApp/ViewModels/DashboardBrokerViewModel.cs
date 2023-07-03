using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
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
    public class DashboardBrokerViewModel : INotifyPropertyChanged
    {
        BLConnect objBl = new BLConnect();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<GETCOMMCREDENTIALS> lstrCredential = new List<GETCOMMCREDENTIALS>();
        //To Get Flow Direction for languages
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        string LblInvoicingAmounts = "";

        public Command OnTappedDwelldays { get; set; }
        public Command OnTappedReadytodeliver { get; set; }
        public Command OnTapped { get; set; }
        public Command OnTappedCaseManagement { get; set; }
        public Command OnTappedInvoiceList { get; set; }
        public Command OnTappedAppointment { get; set; }
        public Command OnTappedManualInspection { get; set; }
        public Command OnTappedEvaluate { get; set; }
        private string strServerSlowMsg = "";


        //Property Changed Event Handler
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

        //To handle Indicator
        private bool stackDashboardBroker = true;
        public bool StackDashboardBroker
        {
            get { return stackDashboardBroker; }
            set
            {
                stackDashboardBroker = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDashboardBroker");
            }
        }
        

        //To handle Indicator
        private bool isVisibleAppointment = false;
        public bool IsVisibleAppointment
        {
            get { return isVisibleAppointment; }
            set
            {
                isVisibleAppointment = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleAppointment");
            }
        }

        private string imgDashboardMenu = "";
        public string ImgDashboardMenu
        {
            get { return imgDashboardMenu; }
            set
            {
                imgDashboardMenu = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDashboardMenu");
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
        private string imgDwelldaysIcon = "";
        public string ImgDwelldaysIcon
        {
            get { return imgDwelldaysIcon; }
            set
            {
                imgDwelldaysIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDwelldaysIcon");
            }
        }
        private string lblDwellDays = "";
        public string LblDwellDays
        {
            get { return lblDwellDays; }
            set
            {
                lblDwellDays = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDwellDays");
            }
        }
        private string imgReadytoload = "";
        public string ImgReadytoload
        {
            get { return imgReadytoload; }
            set
            {
                imgReadytoload = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgReadytoload");
            }
        }
        private string lblReadyToDeliver = "";
        public string LblReadyToDeliver
        {
            get { return lblReadyToDeliver; }
            set
            {
                lblReadyToDeliver = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReadyToDeliver");
            }
        }
        private string imgWalletDash = "";
        public string ImgWalletDash
        {
            get { return imgWalletDash; }
            set
            {
                imgWalletDash = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgWalletDash");
            }
        }
        private string lblMyWallet = "";
        public string LblMyWallet
        {
            get { return lblMyWallet; }
            set
            {
                lblMyWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMyWallet");
            }
        }
        private string imgCaseIcon = "";
        public string ImgCaseIcon
        {
            get { return imgCaseIcon; }
            set
            {
                imgCaseIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCaseIcon");
            }
        }
        private string lblCaseManagement = "";
        public string LblCaseManagement
        {
            get { return lblCaseManagement; }
            set
            {
                lblCaseManagement = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseManagement");
            }
        }
        private string imgEvaluateIcon = "";
        public string ImgEvaluateIcon
        {
            get { return imgEvaluateIcon; }
            set
            {
                imgEvaluateIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEvaluateIcon");
            }
        }
        private string lblEvaluateServices = "";
        public string LblEvaluateServices
        {
            get { return lblEvaluateServices; }
            set
            {
                lblEvaluateServices = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEvaluateServices");
            }
        }
        private string imgInvoiceIcon = "";
        public string ImgInvoiceIcon
        {
            get { return imgInvoiceIcon; }
            set
            {
                imgInvoiceIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgInvoiceIcon");
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
        private string imgAppointmentDash = "";
        public string ImgAppointmentDash
        {
            get { return imgAppointmentDash; }
            set
            {
                imgAppointmentDash = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgAppointmentDash");
            }
        }
        private string lblAppointments = "";
        public string LblAppointments
        {
            get { return lblAppointments; }
            set
            {
                lblAppointments = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAppointments");
            }
        }
        private string imgInspectionDash = "";
        public string ImgInspectionDash
        {
            get { return imgInspectionDash; }
            set
            {
                imgInspectionDash = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgInspectionDash");
            }
        }
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
        private string lblAverage = "";
        public string LblAverage
        {
            get { return lblAverage; }
            set
            {
                lblAverage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAverage");
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
        private string lblCasesResolved = "";
        public string LblCasesResolved
        {
            get { return lblCasesResolved; }
            set
            {
                lblCasesResolved = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCasesResolved");
            }
        }
        private string lblCasesIn = "";
        public string LblCasesIn
        {
            get { return lblCasesIn; }
            set
            {
                lblCasesIn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCasesIn");
            }
        }
        private string lblReviewed = "";
        public string LblReviewed
        {
            get { return lblReviewed; }
            set
            {
                lblReviewed = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReviewed");
            }
        }
        private string lblWaiting = "";
        public string LblWaiting
        {
            get { return lblWaiting; }
            set
            {
                lblWaiting = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWaiting");
            }
        }
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
        private string lblContainers = "";
        public string LblContainers
        {
            get { return lblContainers; }
            set
            {
                lblContainers = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainers");
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
        private string lblDweldaysAVG = "";
        public string LblDweldaysAVG
        {
            get { return lblDweldaysAVG; }
            set
            {
                lblDweldaysAVG = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDweldaysAVG");
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
        private string lblCaseInProgress = "";
        public string LblCaseInProgress
        {
            get { return lblCaseInProgress; }
            set
            {
                lblCaseInProgress = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseInProgress");
            }
        }
        private string lblCaseResolved = "";
        public string LblCaseResolved
        {
            get { return lblCaseResolved; }
            set
            {
                lblCaseResolved = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseResolved");
            }
        }
        private string lblReviewCount = "";
        public string LblReviewCount
        {
            get { return lblReviewCount; }
            set
            {
                lblReviewCount = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReviewCount");
            }
        }
        private string lblreviewspendingcount = "";
        public string Lblreviewspendingcount
        {
            get { return lblreviewspendingcount; }
            set
            {
                lblreviewspendingcount = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblreviewspendingcount");
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
                RaisePropertyChange("LblInvoicingCount ");
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
        private string lblAppointmentCount = "";
        public string LblAppointmentCount
        {
            get { return lblAppointmentCount; }
            set
            {
                lblAppointmentCount = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAppointmentCount");
            }
        }
        private string lblMIBContainerCount = "";
        public string LblMIBContainerCount
        {
            get { return lblMIBContainerCount; }
            set
            {
                lblMIBContainerCount = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMIBContainerCount");
            }
        }
        private bool isVisibleBookForManual = false;
        public bool IsVisibleBookForManual
        {
            get { return isVisibleBookForManual; }
            set
            {
                isVisibleBookForManual = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleBookForManual");
            }
        }
        private string lblDays = "";
        public string LblDays
        {
            get { return lblDays; }
            set
            {
                lblDays = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDays");
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
                OnTappedDwelldays.ChangeCanExecute();
                OnTappedReadytodeliver.ChangeCanExecute();
                OnTapped.ChangeCanExecute();
                OnTappedCaseManagement.ChangeCanExecute();
                OnTappedInvoiceList.ChangeCanExecute();
                OnTappedAppointment.ChangeCanExecute();
                OnTappedManualInspection.ChangeCanExecute();
                OnTappedEvaluate.ChangeCanExecute();

            }
        }
        /// <summary>
        /// ViewModel - Constructor
        /// </summary>
        public DashboardBrokerViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DashboardBrokerViewModel");
            Task.Run(() => assignCms()).Wait();
            OnTappedDwelldays = new Command(async () => await onTappedDwelldays(), () => !IsBusy);
            OnTappedReadytodeliver = new Command(async () => await onTappedReadytodeliver(), () => !IsBusy);
            OnTapped = new Command(async () => await onTapped(), () => !IsBusy);
            OnTappedCaseManagement = new Command(async () => await onTappedCaseManagement(), () => !IsBusy);
            OnTappedInvoiceList = new Command(async () => await onTappedInvoiceList(), () => !IsBusy);
            OnTappedAppointment = new Command(async () => await onTappedAppointment(), () => !IsBusy);
            OnTappedManualInspection = new Command(async () => await onTappedManualInspection(), () => !IsBusy);
            OnTappedEvaluate = new Command(async () => await onTappedEvaluate(), () => !IsBusy);
            string fstrMailId = gblRegisteration.strLoginUser;
            Task.Run(() => dashboardData(fstrMailId)).Wait();
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
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {

            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            dbLayer.objInfoitems = objCMS;
           await HideShowCredentials();

            ImgDashboardMenu = dbLayer.getCaption("imgDashboard", objCMS);
            LblDashboard = dbLayer.getCaption("strDashboard", objCMS);
            ImgDwelldaysIcon = dbLayer.getCaption("imgDwelldays", objCMS);
            LblDwellDays = dbLayer.getCaption("strDwellDays", objCMS);
            ImgReadytoload = dbLayer.getCaption("imgReadytoload", objCMS);
            LblReadyToDeliver = dbLayer.getCaption("strReadytoDeliver", objCMS);
            ImgWalletDash = dbLayer.getCaption("imgWallet", objCMS);
            LblMyWallet = dbLayer.getCaption("strMyWallet", objCMS);
            ImgCaseIcon = dbLayer.getCaption("imgCase", objCMS);
            LblCaseManagement = dbLayer.getCaption("strCaseManagement", objCMS);

            ImgEvaluateIcon = dbLayer.getCaption("imgEvaluate", objCMS);
            LblEvaluateServices = dbLayer.getCaption("strEvaluateServices", objCMS);
            ImgInvoiceIcon = dbLayer.getCaption("imgInvoice", objCMS);
            LblInvoicing = dbLayer.getCaption("strInvoicing", objCMS);
            ImgAppointmentDash = dbLayer.getCaption("imgAppointment", objCMS);
            LblAppointments = dbLayer.getCaption("strAppointments", objCMS);
            ImgInspectionDash = dbLayer.getCaption("imgInspection", objCMS);
            LblBookForManual = dbLayer.getCaption("strBookforManualInspection", objCMS);
            LblAverage = dbLayer.getCaption("strAverage", objCMS);
            LblNoOfUnits = dbLayer.getCaption("strNoofUnits", objCMS);
            LblCasesResolved = dbLayer.getCaption("strCasesResolved", objCMS);
            LblCasesIn = dbLayer.getCaption("strCasesInProgress", objCMS);
            LblReviewed = dbLayer.getCaption("strReviewed", objCMS);
            LblWaiting = dbLayer.getCaption("strWaiting", objCMS);
            LblContainer = dbLayer.getCaption("strContainerNeedsBooking", objCMS);
            LblNoOfInvoices = dbLayer.getCaption("strNoofUnits", objCMS);
            LblTotalPayable = dbLayer.getCaption("strTotalPayable", objCMS);
            LblInvoicingAmounts = dbLayer.getCaption("strSAR", objCMS);
            LblContainers = dbLayer.getCaption("strNoofContainers", objCMS);
            LblCountMsg = dbLayer.getCaption("strCountMsg", objCMS);
            LblDays = dbLayer.getCaption("strDays", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            //  Appointment screen hide and show
            IsVisibleAppointment = AppSettings.brokerAppointmentShow;
        }
        /// <summary>
        /// To get dashboard data
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
                    LblDweldaysAVG = objRawData[0].dwelldaysavg;
                    LblReadytoDeliver = objRawData[0].readytodeliverunitcount;
                    LblCaseInProgress = objRawData[0].casesinprogress;
                    LblCaseResolved = objRawData[0].casesresolved;
                    LblReviewCount = objRawData[0].reviewscount;
                    Lblreviewspendingcount = objRawData[0].reviewspendingcount;
                    LblInvoicingCount = objRawData[0].invoicescount;
                    var invoicesamount = string.Format("{0:0.00}", objRawData[0].invoicesamount);

                    LblInvoicingAmount = LblInvoicingAmounts + " " + invoicesamount;
                    LblAppointmentCount = objRawData[0].appoinmentscount;
                    LblMIBContainerCount = objRawData[0].mibcontainerscount;
                }
            }
            catch (Exception ex)
            {

                await App.Current.MainPage?.DisplayAlert("Error", ex.Message, "OK");
            }


        }
        /// <summary>
        /// Hide show credentials Function
        /// </summary>
        /// <returns></returns>
        private async Task HideShowCredentials()
        {
            lstrCredential = await objBl.getCommCredentials();
            await Task.Delay(1000);
        }
        /// <summary>
        /// on Tapped Function
        /// </summary>
        /// <returns></returns>
        private async Task onTapped()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Bayan("", "", "", "", "", ""));
            StackDashboardBroker = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Dwelldays
        /// </summary>
        /// <returns></returns>
        private async Task onTappedDwelldays()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new DwellDays("", "", "", "", "", "", "", "", "","N"));
            StackDashboardBroker = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Ready to deliver
        /// </summary>
        /// <returns></returns>
        private async Task onTappedReadytodeliver()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ReadytoDelivery("", "", "", "", "", "", "", "", "", "","N"));
            StackDashboardBroker = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Request TicketsList
        /// </summary>
        /// <returns></returns>
        private async Task onTappedCaseManagement()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Request_TicketsList("", "", "", "", "","N"));
            StackDashboardBroker = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Appointment Booking
        /// </summary>
        /// <returns></returns>
        private async Task onTappedAppointment()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new AppointmentBooking("", "", "", "", "", "", "","N"));
            StackDashboardBroker = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Manual Inspection
        /// </summary>
        /// <returns></returns>
        private async Task onTappedManualInspection()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Manuallnspection("", "", "", "", "", "", "", "", "","N"));
            StackDashboardBroker = true;
            IsBusy = false;
        }
        /// <summary>
        /// To got to Evaluate
        /// </summary>
        /// <returns></returns>
        private async Task onTappedEvaluate()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Evaluate(""));
            StackDashboardBroker = true;
            IsBusy = false;
        }
        /// <summary>
        /// to get on Tapped Invoice List
        /// </summary>
        /// <returns></returns>
        private async Task onTappedInvoiceList()
        {
            IsBusy = true;
            StackDashboardBroker = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "","N"));
            StackDashboardBroker = true;
            IsBusy = false;
        }

    }
}
