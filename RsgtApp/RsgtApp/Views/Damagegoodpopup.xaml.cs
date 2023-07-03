using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.Helpers;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Damagegoodpopup : ContentPage
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;

        private ObservableCollection<Damagepopup> lstDmagePopup { get; set; } = new ObservableCollection<Damagepopup>();

        private List<clsDAMAGEPOPUP> lstDamage = new List<clsDAMAGEPOPUP>();
        BLConnect objCon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();

        private string strLanguage = App.gblLanguage;
        string lstrContainerNo = "";
        string lstrBolNo = "";
        string lstrrflag = "";
        private string strServerSlowMsg = "";
        public System.Windows.Input.ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public string WebURL { get; private set; }
        /// <summary>
        /// To check internet connection
        /// </summary>
        protected async override void OnAppearing()
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                if (App.isinternetSlowEnablement == true)
                {
                    bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                    if (isConnectionFast)
                    { }
                    else
                        await this.DisplayToastAsync("Network Connection is slow", 3000);
                }
            }
            else
            {
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
            }

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBolNo"></param>
        /// <param name="fstrflag"></param>
        /// <param name="fstrDamageflag"></param>
        public Damagegoodpopup(string fstrContainerNo, string fstrBolNo, string fstrflag, string fstrDamageflag)
        {
            InitializeComponent();
            // await dbLayer.LoadContent("RM013", pageContent);
            //objCMS = await dbLayer.LoadContent("RM013");
            this.BindingContext = this;
            lstrContainerNo = fstrContainerNo;
            lstrBolNo = fstrBolNo;
            lstrrflag = fstrflag;
            if (fstrDamageflag == "Y")
            {
                chkIsChecked.IsVisible = false;
                lblMessage.IsVisible = false;
                btnAccept.IsVisible = false;
                btnReject.IsVisible = false;
                lblDesclaimerMsg.IsVisible = false;
                lblDesclaimer.IsVisible = false;

            }
            else
            {
                chkIsChecked.IsVisible = true;
                lblMessage.IsVisible = true;
                btnAccept.IsVisible = true;
                btnReject.IsVisible = true;
                lblDesclaimerMsg.IsVisible = true;
                lblDesclaimer.IsVisible = true;

            }

            btnAccept.IsEnabled = false;
            btnReject.IsEnabled = false;
            DamagePopupDetails();

            assignCms();


            //InitializeComponent();
            // this.BindingContext = this;
        }
        /// <summary>
        /// To Bind Cms
        /// </summary>
        public async void assignCms()
        {
            try
            {

                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM013");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM013");
                    objCMSMsg = await dbLayer.LoadContent("RM411");
                    objCMSMSG = await dbLayer.LoadContent("RM026");


                }
                assignContent();

            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {

            StackDamageGoodPopup.IsEnabled = false;
            DamageGoodPopupActivityIndicator.IsVisible = true;
            DamageGoodPopupActivityIndicator.IsRunning = true;
            aiLayout.IsVisible = true;
            await Task.Delay(1000);


            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;

            //}



            dbLayer.objInfoitems = objCMS;

            imgDamage.Source = dbLayer.getCaption("imgDamage", objCMS);
            lblDamageGoodDetails.Text = dbLayer.getCaption("strDamagedGoodsDetail", objCMS);
            // lblSNo.Text = dbLayer.getCaption("strSno", objCMS);
            //  lblPDFFile.Text = dbLayer.getCaption("strPDFfile", objCMS);
            lblMessage.Text = dbLayer.getCaption("strCurrentCondition", objCMS);
            btnAccept.Text = dbLayer.getCaption("strAccept", objCMS);
            btnReject.Text = dbLayer.getCaption("strReject", objCMS);
            lblDesclaimer.Text = dbLayer.getCaption("strDisclaimers", objCMSMsg);
            lblDesclaimerMsg.Text = dbLayer.getCaption("strDisclaimerPara", objCMSMsg);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            //  lblPDFContainer.Text = dbLayer.getCaption("strContainer", objCMSMsg);

            StackDamageGoodPopup.IsEnabled = true;
            DamageGoodPopupActivityIndicator.IsVisible = false;
            DamageGoodPopupActivityIndicator.IsRunning = false;
            aiLayout.IsVisible = false;
        }
        //public DamagePopupDetails()
        /// <summary>
        /// To get DamagePopupDetails
        /// </summary>
        private void DamagePopupDetails()
        {
           // int lintCount = 1;

          //  string lstrWebApi = "http://172.19.35.68:89/api/DataSource/getDamagePopupDetails?fstrAPIToken=&fstrFilter=CD_BLNUMBER:EGLV101100117869,CD_CONTAINERNUMBER:EITU0426514,BLFLAG:N,";

            string fstrFilter = "CD_BLNUMBER:" + lstrBolNo + ",CD_CONTAINERNUMBER:" + lstrContainerNo + ",BLFLAG:N,";


            lstDamage = objCon.getDamagePopupDetails(fstrFilter);
            foreach (var item in lstDamage)
            {


                lstDmagePopup.Add(new Damagepopup { SLNo = item.PDFSNO, ContainerNo = item.PDFContainerNo, PDF = item.PDFName, WebURL = item.SharePointWebUrl.ToString().Trim() });
            }

        }
        //https://localhost:44348/api/DataSource/getDamagePopupDetails?fstrAPIToken=&fstrFilter=CD_BLNUMBER:EGLV101100117869,CD_CONTAINERNUMBER:,BLFLAG:Y,
        /// <summary>
        /// To get Button_dismissBLpopup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_dismissBLpopup(object sender, EventArgs e)
        {
            StackDamageGoodPopup.IsEnabled = false;
            DamageGoodPopupActivityIndicator.IsVisible = true;
            DamageGoodPopupActivityIndicator.IsRunning = true;
            aiLayout.IsVisible = true;
            await Task.Delay(1000);
            //Dismiss(null);
            await App.Current.MainPage?.Navigation.PushAsync(new Containerlist("", "", "", "", "", "", "", "", "","N"));

            StackDamageGoodPopup.IsEnabled = true;
            DamageGoodPopupActivityIndicator.IsVisible = false;
            DamageGoodPopupActivityIndicator.IsRunning = false;
            aiLayout.IsVisible = false;
        }
        /// <summary>
        /// To get btn_AcceptPopup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_AcceptPopup(object sender, EventArgs e)
        {
            try
            {
                StackDamageGoodPopup.IsEnabled = false;
                DamageGoodPopupActivityIndicator.IsVisible = true;
                DamageGoodPopupActivityIndicator.IsRunning = true;
                aiLayout.IsVisible = true;
                await Task.Delay(1000);

                string lstrInputJson = "{\"CD_DAMAGESTATUS\": \"A\",\"CD_DAMAGESTATUSUPDATEDDATE\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH/mm/ss") + "\",\"CD_DAMAGESTATUSUPDATEDUSER\": \"" + gblRegisteration.strLoginUser + "\"}";

                // https://localhost:44348/api/DataSource/UpdateBOLDamageDetails/{BOLNO}  -----BOLNO

                lstrBolNo = lstrBolNo.Replace("/", "^");
                string lstrResult = objWebApi.putWebApi("UpdateBOLDamageDetails", lstrInputJson, lstrBolNo);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                //                {
                //                    "SMT_CODE":"Damage-Accept",
                //"mailto:ru_emailid":"16umec129@gmail.com",
                //"RU_FIRSTNAME1":"hari"}

                objWebApi.postWebApi("PostSendEmail", MailSettings.DamageAcceptMailData());
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                await Navigation.PushAsync(new DamagepopupMessage("A"));
                StackDamageGoodPopup.IsEnabled = true;
                DamageGoodPopupActivityIndicator.IsVisible = false;
                DamageGoodPopupActivityIndicator.IsRunning = false;
                aiLayout.IsVisible = false;
            }
            catch (Exception ex)
            {

                await this.DisplayToastAsync(ex.Message, 3000);
            }

        }
        /// <summary>
        /// To get btn_RejectPopup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void btn_RejectPopup(object sender, EventArgs e)
        {
            try
            {
                StackDamageGoodPopup.IsEnabled = false;
                DamageGoodPopupActivityIndicator.IsVisible = true;
                DamageGoodPopupActivityIndicator.IsRunning = true;
                aiLayout.IsVisible = true;
                await Task.Delay(1000);

                string lstrInputJson = "{\"CD_DAMAGESTATUS\": \"R\",\"CD_DAMAGESTATUSUPDATEDDATE\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH/mm/ss") + "\",\"CD_DAMAGESTATUSUPDATEDUSER\": \"" + gblRegisteration.strLoginUser + "\"}";

                // https://localhost:44348/api/DataSource/UpdateBOLDamageDetails/{BOLNO}  -----BOLNO
                string lstrResult = objWebApi.putWebApi("UpdateBOLDamageDetails", lstrInputJson, lstrBolNo);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                await Navigation.PushAsync(new DamagepopupMessage("R"));

                StackDamageGoodPopup.IsEnabled = true;
                DamageGoodPopupActivityIndicator.IsVisible = false;
                DamageGoodPopupActivityIndicator.IsRunning = false;
                aiLayout.IsVisible = false;
            }
            catch (Exception ex)
            {

                await this.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get clickTap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickTap(object sender, EventArgs e)
        {
            StackDamageGoodPopup.IsEnabled = false;
            DamageGoodPopupActivityIndicator.IsVisible = true;
            DamageGoodPopupActivityIndicator.IsRunning = true;
            aiLayout.IsVisible = true;
            await Task.Delay(1000);

            var lstItemSelected = (Damagepopup)((Label)sender).BindingContext;
            string url = lstItemSelected.WebURL;
            //var googleUrl = "https://docs.google.com/gview?embedded=true&url=";

            openPdf(url);
            // var googleUrl= "@microsoft.graph.downloadUrl";   //20220829 Bakar given URL
            // string strFinalUrl = googleUrl + url;
            //Navigation.PushAsync(new Container_PDF(url, "N"));

            // Device.OpenUri(new System.Uri(strFinalUrl));
            StackDamageGoodPopup.IsEnabled = true;
            DamageGoodPopupActivityIndicator.IsVisible = false;
            DamageGoodPopupActivityIndicator.IsRunning = false;
            aiLayout.IsVisible = false;

        }
        /// <summary>
        /// To get openPdf
        /// </summary>
        /// <param name="fstrUrl"></param>
        private async void openPdf(string fstrUrl)
        {
            StackDamageGoodPopup.IsEnabled = false;
            DamageGoodPopupActivityIndicator.IsVisible = true;
            DamageGoodPopupActivityIndicator.IsRunning = true;
            aiLayout.IsVisible = true;
            await Task.Delay(1000);

            // Device.OpenUri(new Uri("http://example.com"))
            await Browser.OpenAsync(fstrUrl, BrowserLaunchMode.SystemPreferred);
            StackDamageGoodPopup.IsEnabled = true;
            DamageGoodPopupActivityIndicator.IsVisible = false;
            DamageGoodPopupActivityIndicator.IsRunning = false;
            aiLayout.IsVisible = false;
        }


        /// <summary>
        /// Class for Damagepopup
        /// </summary>
        public class Damagepopup
        {
            public string SLNo { get; set; }
            public string ContainerNo { get; set; }
            public string PDF { get; set; }
            public string WebURL { get; set; }
        }

        private void CheckedDamageGood(object sender, CheckedChangedEventArgs e)
        {

            if (this.chkIsChecked.IsChecked == true)
            {
                btnAccept.IsEnabled = true;
                btnReject.IsEnabled = true;
            }
            else
            {
                btnAccept.IsEnabled = false;
                btnReject.IsEnabled = false;
            }

        }


    }
}