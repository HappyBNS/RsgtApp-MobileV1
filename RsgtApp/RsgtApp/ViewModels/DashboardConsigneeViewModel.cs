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
using static RsgtApp.Models.DashboardModel;

namespace RsgtApp.ViewModels
{
    public class DashboardConsigneeViewModel : INotifyPropertyChanged
    {
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();

      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        public int intTotalCount { get; set; }
        public int fintPageNumber { get; set; }
        public int fintPageSize { get; set; }
        public string DASHBOARD { get; private set; }
        private string strServerSlowMsg = "";
        
        public List<clsdashboardCountlist> objDashboardCountDataSource = new List<clsdashboardCountlist>();

        public Command OnTapped { get; set; }
        public Command OnTappedDwelldays { get; set; }
        public Command OnTappedPaymenthistory { get; set; }
        public Command OnTappedEvaluate { get; set; }
        public Command OnTappedTerminalVisit { get; set; }
        public Command OnTappedVASmain { get; set; }

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

        private bool stackDashboardConsignee = true;
        public bool StackDashboardConsignee
        {
            get { return stackDashboardConsignee; }
            set
            {
                stackDashboardConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDashboardConsignee");
            }
        }

        private string imgDashboardMenuIcon = "";
        public string ImgDashboardMenuIcon
        {
            get { return imgDashboardMenuIcon; }
            set
            {
                imgDashboardMenuIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDashboardMenuIcon");
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
        private string imgDwellDaysIcon = "";
        public string ImgDwellDaysIcon
        {
            get { return imgDwellDaysIcon; }
            set
            {
                imgDwellDaysIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDwellDaysIcon");
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
        private string imgPaymentHistory = "";
        public string ImgPaymentHistory
        {
            get { return imgPaymentHistory; }
            set
            {
                imgPaymentHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgPaymentHistory");
            }
        }
        private string lblPaymentHistory = "";
        public string LblPaymentHistory
        {
            get { return lblPaymentHistory; }
            set
            {
                lblPaymentHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPaymentHistory");
            }
        }
        private string lblInvoicesIssuse = "";
        public string LblInvoicesIssuse
        {
            get { return lblInvoicesIssuse; }
            set
            {
                lblInvoicesIssuse = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInvoicesIssuse");
            }
        }
        private string lblPaymentHistoryData = "";
        public string LblPaymentHistoryData
        {
            get { return lblPaymentHistoryData; }
            set
            {
                lblPaymentHistoryData = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPaymentHistoryData");
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
        private string imgVisitorIcon = "";
        public string ImgVisitorIcon
        {
            get { return imgVisitorIcon; }
            set
            {
                imgVisitorIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgVisitorIcon");
            }
        }
        private string lblTerminalVisit = "";
        public string LblTerminalVisit
        {
            get { return lblTerminalVisit; }
            set
            {
                lblTerminalVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTerminalVisit");
            }
        }
        private string imgAddedServiceIcon = "";
        public string ImgAddedServiceIcon
        {
            get { return imgAddedServiceIcon; }
            set
            {
                imgAddedServiceIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgAddedServiceIcon");
            }
        }
        private string lblAddedServices = "";
        public string LblAddedServices
        {
            get { return lblAddedServices; }
            set
            {
                lblAddedServices = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAddedServices");
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
                OnTapped.ChangeCanExecute();
                OnTappedDwelldays.ChangeCanExecute();
                OnTappedPaymenthistory.ChangeCanExecute();
                OnTappedEvaluate.ChangeCanExecute();
                OnTappedTerminalVisit.ChangeCanExecute();
                OnTappedVASmain.ChangeCanExecute();

            }
        }
        /// <summary>
        /// ViewModel - Constructor
        /// </summary>
        public DashboardConsigneeViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DashboardConsigneeViewModel");
            Task.Run(() => assignCms()).Wait();
            OnTapped = new Command(async () => await onTapped(), () => !IsBusy);
            OnTappedDwelldays = new Command(async () => await onTappedDwelldays(), () => !IsBusy);
            OnTappedPaymenthistory = new Command(async () => await onTappedPaymenthistory(), () => !IsBusy);
            OnTappedEvaluate = new Command(async () => await onTappedEvaluate(), () => !IsBusy);
            OnTappedTerminalVisit = new Command(async () => await onTappedTerminalVisit(), () => !IsBusy);
            OnTappedVASmain = new Command(async () => await onTappedVASmain(), () => !IsBusy);

            string fstrMailId = gblRegisteration.strLoginUser;
            Task.Run(() => dashboardData(fstrMailId)).Wait();
        }
        /// <summary>
        /// To assign cms with Access id
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
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM401");
                assignContent();

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To bind cms
        /// </summary>
        public async void assignContent()
        {

            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}


          
            dbLayer.objInfoitems = objCMS;
            await Task.Delay(1000);
            ImgDashboardMenuIcon = dbLayer.getCaption("imgDashboard", objCMS);
            LblDashboard = dbLayer.getCaption("strDashboard", objCMS);
            ImgDwellDaysIcon = dbLayer.getCaption("imgDwelldays", objCMS);
            LblDwellDays = dbLayer.getCaption("strDwellDays", objCMS);
            ImgPaymentHistory = dbLayer.getCaption("imgPaymentHistory", objCMS);
            LblPaymentHistory = dbLayer.getCaption("strPaymentHistory", objCMS);
            ImgEvaluateIcon = dbLayer.getCaption("imgEvaluate", objCMS);
            LblEvaluateServices = dbLayer.getCaption("strEvaluateServices", objCMS);
            // imgRefundIcon.Source = dbLayer.getCaption("imgRefund");
            // lblRefund.Text = dbLayer.getCaption("strRefund");
            ImgVisitorIcon = dbLayer.getCaption("imgVisitor", objCMS);
            LblTerminalVisit = dbLayer.getCaption("strTerminalVisit", objCMS);
            ImgAddedServiceIcon = dbLayer.getCaption("imgValueaddedservice", objCMS);
            LblAddedServices = dbLayer.getCaption("strAddedValueServices", objCMS);
            LblAverage = dbLayer.getCaption("strAverage", objCMS);
            LblInvoicesIssuse = dbLayer.getCaption("strInvoiceIssued", objCMS);
            LblReviewed = dbLayer.getCaption("strReviewed", objCMS);
            LblWaiting = dbLayer.getCaption("strWaiting", objCMS);
            LblCountMsg = dbLayer.getCaption("strCountMsg", objCMS);
            LblDays = dbLayer.getCaption("strDays", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
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
                    LblDweldaysAVG = objRawData[0].dwelldaysavg;
                    LblPaymentHistoryData = objRawData[0].pendingpaymentinvoicescount;
                    LblReviewCount = objRawData[0].reviewscount;
                    Lblreviewspendingcount = objRawData[0].reviewspendingcount;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage?.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        /// <summary>
        /// To get Tapped
        /// </summary>
        /// <returns></returns>
        private async Task onTapped()
        {
            IsBusy = true;
            StackDashboardConsignee = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Bayan("", "", "", "", "", ""));
            StackDashboardConsignee = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Dwell days
        /// </summary>
        /// <returns></returns>
        private async Task onTappedDwelldays()
        {
            IsBusy = true;
            StackDashboardConsignee = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new DwellDays("", "", "", "", "", "", "", "", "","N"));
            StackDashboardConsignee = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Payment History
        /// </summary>
        /// <returns></returns>
        private async Task onTappedPaymenthistory()
        {
            IsBusy = true;
            StackDashboardConsignee = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new PaymentHistory("", "", "", "", "", "", "", "", "", "", "", ""));
            StackDashboardConsignee = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Evaluate
        /// </summary>
        /// <returns></returns>
        private async Task onTappedEvaluate()
        {
            IsBusy = true;
            StackDashboardConsignee = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Evaluate(""));
            StackDashboardConsignee = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Terminal Visit
        /// </summary>
        /// <returns></returns>
        private async Task onTappedTerminalVisit()
        {
            IsBusy = true;
            StackDashboardConsignee = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new TerminalVisit());
            StackDashboardConsignee = true;
            IsBusy = false;

        }
        /// <summary>
        /// To go to Value Added Servcice
        /// </summary>
        /// <returns></returns>
        private async Task onTappedVASmain()
        {
            IsBusy = true;
            StackDashboardConsignee = false;
            await Task.Delay(1000);
           App.Current.MainPage?.DisplayToastAsync("Coming Soon", 3000);
            StackDashboardConsignee = true;
            IsBusy = false;
            //DashConsigneelyout.IsEnabled = false;
            //ConsigneeActivityIndicator.IsRunning = true;
            //Navigation.PushAsync(new VAS_main());
            //await Task.Delay(1000);
            //ConsigneeActivityIndicator.IsRunning = false;
            //DashConsigneelyout.IsEnabled = true;
        }

    }
}
