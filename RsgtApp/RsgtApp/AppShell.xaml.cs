using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.Themes;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System.Threading.Tasks;
using static RsgtApp.BusinessLayer.BLConnect;

namespace RsgtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private List<InfoItem> objCMS = new List<InfoItem>();
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();

        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = this;
            //prepareDictionary();
            assignCms();
            // await dbLayer.LoadContent("RM015", pageContent);
            //assignContent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                // showFlyoutitem.IsVisible = false;
            }

            getMenu();

            
            lblTermsCondition.IsVisible = false;
            lblCMS.Title = "CMS";

        }

        private async void onMyInvoiceandPaymentTapped(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "","N"));

        }

        //Begin - Code for Back Button - 20220429
        //1.When Back button clicked in Vessel Schedule (Inport/Arrival/Departure), screen navigate to MainPage.xaml
        //2.When Back button clicked in other pages like PageRegistraion1.aspx,PageRegistration2.aspx, screen should navigate each page by page
        protected async override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);


            var Token = await SecureStorage.GetAsync("V");
            if (Token == "VesselBack")
            {

                if (args.Source == ShellNavigationSource.Pop)
                {
                    args.Cancel();
                    Application.Current.MainPage = new AppShell();

                }
            }
        }
        //End - Code for Back Button - 20220429


        protected override bool OnBackButtonPressed()
        {
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
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
                    objCMS = await  dbLayer.LoadContent("RM015");
                }
                // objCMS = await App.Database.GetCmsAsyncAccessId("RM010");
              await  assignContent();

            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Method is for Assign Content
        /// </summary>
        public async Task assignContent()
        {
            
            enumDirection = FlowDirection.LeftToRight;
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }
            this.FlowDirection = enumDirection;

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                switch (App.gblLanguage)
                {
                    case "En":
                        mergedDictionaries.Add(new EnglishLTR());
                        break;
                    case "Ar":
                        mergedDictionaries.Add(new ArabicRTL());
                        break;

                }

            }
            lblMain.Title = dbLayer.getCaption("strMain", objCMS).ToString().Trim();
            lblMain.FlyoutIcon = dbLayer.getCaption("imgHomeMenu", objCMS);
            lblTheme.Title = dbLayer.getCaption("strThemes", objCMS).ToString().Trim();
            lblTheme.FlyoutIcon = dbLayer.getCaption("imgTheme", objCMS);
            //lblDashboard.Title = dbLayer.getCaption("strDashboard", objCMS).ToString().Trim();
            lblMyProfile1.Title = dbLayer.getCaption("strMyProfile", objCMS).ToString().Trim();
            lblMyProfile1.FlyoutIcon = dbLayer.getCaption("imgprofile", objCMS);
            lblTrack.Title = dbLayer.getCaption("strTrack", objCMS).ToString().Trim();
            //lblReleaseDeli.Title = dbLayer.getCaption("strReleaseDelivery", objCMS).ToString().Trim();
            // lblCustomerSupport.Title = dbLayer.getCaption("strCustomerSupport", objCMS).ToString().Trim();
            lblAccountSettings.Title = dbLayer.getCaption("strAccountSettings", objCMS).ToString().Trim();
            lblWallet.Title = dbLayer.getCaption("strWallet", objCMS).ToString().Trim();
            lblNotifications.Title = dbLayer.getCaption("strNotifications", objCMS).ToString().Trim();
            lblLogOut.Title = dbLayer.getCaption("strLogout", objCMS).ToString().Trim();
            //lblDashboard.FlyoutIcon = dbLayer.getCaption("imgdashboardicon", objCMS);
            lblFaq.Title = dbLayer.getCaption("strFAQ", objCMS).ToString().Trim();
            lblFaq.FlyoutIcon = dbLayer.getCaption("imgFaqMenuiconpng", objCMS);
            lblTrack.FlyoutIcon = dbLayer.getCaption("imgshipment", objCMS);
            // lblInvoicesPay.FlyoutIcon = pageContent["imginvoices"][lintIndex];
            // lblReleaseDeli.FlyoutIcon = dbLayer.getCaption("imgdelivery", objCMS);
            //lblCustomerSupport.FlyoutIcon = dbLayer.getCaption("imgcustomersupport", objCMS);
            lblAccountSettings.FlyoutIcon = dbLayer.getCaption("imgaccountsetting", objCMS);
            lblKeyFeatures.Title = dbLayer.getCaption("strKeyFeatures", objCMS).ToString().Trim();
            lblKeyFeatures.FlyoutIcon = dbLayer.getCaption("imgkeyfeaturesmenuicon", objCMS);
            lblWallet.FlyoutIcon = dbLayer.getCaption("imgwallet", objCMS);
            lblNotifications.FlyoutIcon = dbLayer.getCaption("imgnotification", objCMS);
            //lblLogOut.FlyoutIcon = dbLayer.getCaption("imglogout", objCMS);
            lblcontactus.FlyoutIcon = dbLayer.getCaption("imgContactIconpng", objCMS);
            lblcontactus.Title = dbLayer.getCaption("strContactUs", objCMS).ToString().Trim();
            lblAboutRSGT.Title = dbLayer.getCaption("strAboutRSGT", objCMS).ToString().Trim();
            lblAboutRSGT.FlyoutIcon = dbLayer.getCaption("imgAbouticonpng", objCMS);
            lblTermsCondition.Title = dbLayer.getCaption("strTermsConditions", objCMS).ToString().Trim();
            lblTermsCondition.FlyoutIcon = dbLayer.getCaption("imgTermsIconpng", objCMS);
            lblDashboardBroken.Title = dbLayer.getCaption("strDashboardBroker", objCMS).ToString().Trim();
            lblDashboardBroken.FlyoutIcon = dbLayer.getCaption("imgDashBoard", objCMS);
            lblDashboardConsignee.Title = dbLayer.getCaption("strDashboardConsignee", objCMS).ToString().Trim();
            lblDashboardConsignee.FlyoutIcon = dbLayer.getCaption("imgDashBoard", objCMS);
            lblDashboardTransporter.Title = dbLayer.getCaption("strDashboardTransporter", objCMS).ToString().Trim();
            lblDashboardTransporter.FlyoutIcon = dbLayer.getCaption("imgDashBoard", objCMS);
            lblInvoicePayment.Title = dbLayer.getCaption("strInvoicesPayments", objCMS).ToString().Trim();
            lblInvoicePayment.FlyoutIcon = dbLayer.getCaption("imginvoices", objCMS);
            lblRequestTicket.Title = dbLayer.getCaption("strRequests", objCMS).ToString().Trim();
            lblRequestTicket.FlyoutIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblLogOut.FlyoutIcon = dbLayer.getCaption("imgLogoutIcon", objCMS);
            lblOtherRequests.Title = dbLayer.getCaption("strAdditionalServices", objCMS).ToString().Trim();
            lblOtherRequests.FlyoutIcon = dbLayer.getCaption("imgAdditionalServices", objCMS);

            //["An"] = new List<string>() { "mnuMainPage", "mnuKeyfeatures", "mnuFAQ", "mnuAbout_RSGT", "mnuTC", "mnucontactus", "mnuLogout" },
            // ["M1"] = new List<string>() { "mnuMainPage", "mnuDashboard", "mnuMyprofile1", "mnuAccountsettings", "mnuKeyfeatures", "mnuFAQ", "mnuAbout_RSGT", "mnuTC", "mnucontactus", "mnuLogout" },

            var userName = "";
            userName = gblRegisteration.strLoginFirstName;
            if (App.gblLanguage == "Ar")
            {
                userName = gblRegisteration.strLoginFirstName1;
            }
            if (userName != null)
            {
                string strHi = dbLayer.getCaption("strHi", objCMS).ToString().Trim();
                lblloginUserName.Title = strHi + " " + userName.ToString();
            }
        }

        private List<GETCOMMCREDENTIALS> lstrCredential = new List<GETCOMMCREDENTIALS>();
        private async void getMenu()
        {
            HideMenus();

            lstrCredential = await objBl.getCommCredentials();
            if (lstrCredential.Count > 0)
            {
                if (lstrCredential[0].cc_axsrestrict_bookanappointment != "Y")
                {
                    AppSettings.brokerAppointmentShow = true;
                }
            }

            App.gblRole = "An";

            if (gblRegisteration.strLoginUser != null && gblRegisteration.strLoginUser.Length > 0)
            {
                App.gblRole = AppSettings.Milestone;

            }

            if (App.gblRole == "An")
            {
                lblMain.IsVisible = true;
                lblKeyFeatures.IsVisible = true;
                lblFaq.IsVisible = true;
                lblAboutRSGT.IsVisible = true;
                lblTermsCondition.IsVisible = true;
                lblcontactus.IsVisible = true;
                lblTheme.IsVisible = true;

            }

            var Milestone = 0;
            if (App.gblRole != "An")
            {
                var Menu = App.gblRole.ToString();

                Menu = Menu.Substring(1, Menu.Length - 1);

                Milestone = Convert.ToInt32(Menu);
            }

            if (Milestone > 0)
            {

                if (Milestone == 1)
                {
                    displayM1Screens();
                }

                if (Milestone == 2)
                {
                    displayM1Screens();
                    displayM2Screens();
                }
                //Phase-1 All screen
                if (Milestone == 3)
                {
                    displayM1Screens();
                    displayM2Screens();
                    displayM3Screens();

                }

                //Phase-1 & Phase-2 All screen
                if (Milestone == 4)
                {
                    displayM1Screens();
                    displayM2Screens();
                    displayM3Screens();
                    lblOtherRequests.IsVisible = true;

                }
                var WalletFlag = AppSettings.WalletFlag.ToString().Trim();
                if (WalletFlag == "Y")
                {
                    if((gblRegisteration.strLoginCustomerType.ToUpper().Trim()=="CONSIGNEE")||(gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "BROKER"))
                    {
                        lblWallet.IsVisible = true;
                    }
                    
                }

                //As Per Client Request to  enable based on customer type
                //User based Screen Restriction handled by Gokul on 20230413
                if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "STUDENTS") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "EMPLOYEES")
                    || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "AUTHORITIES"))
                {
                    lblOtherRequests.IsVisible = false;
                    lblRequestTicket.IsVisible = false;
                    lblWallet.IsVisible = false;
                    lblNotifications.IsVisible = false;
                }


            }
        }

        private void displayM1Screens()
        {
            lblMain.IsVisible = true;
            lblKeyFeatures.IsVisible = true;
            lblFaq.IsVisible = true;
            lblAboutRSGT.IsVisible = true;
            lblTermsCondition.IsVisible = true;
            lblcontactus.IsVisible = true;
            lblLogOut.IsVisible = true;
            lblMyProfile1.IsVisible = true;
            lblAccountSettings.IsVisible = true;
            lblNotifications.IsVisible = true;
        }


        private void displayM2Screens()
        {
            if (lstrCredential.Count > 0)
            {
                if (lstrCredential[0].cc_axsrestrict_advancetracking != "Y")
                {
                    lblTrack.IsVisible = true;
                }

            }


        }

        private void displayM3Screens()
        {
            string lstrCustomType = gblRegisteration.strLoginCustomerType.ToString().Trim();
            if (lstrCustomType == null) lstrCustomType = "";

            //if ((lstrCustomType == "Consignee") || (lstrCustomType == "Shipper") || (lstrCustomType == "Shipping Line"))

            if (lstrCustomType == "Consignee")
            {
                lblDashboardConsignee.IsVisible = true;
            }

            if ((lstrCustomType == "Broker") || (lstrCustomType == "Clearing Agent"))
            {
                lblDashboardBroken.IsVisible = true;
            }

            if (gblRegisteration.strLoginCustomerType.ToString().Trim() == "Transporter")
            {
                lblDashboardTransporter.IsVisible = true;
            }
            lblInvoicePayment.IsVisible = false;
            if ((lstrCustomType == "Broker") || (lstrCustomType == "Clearing Agent") || (lstrCustomType == "Transporter") || (lstrCustomType == "Consignee"))
            {
                if (lstrCredential.Count > 0)
                {
                    if (lstrCredential[0].cc_axsrestrict_requests != "Y")
                    {
                        lblRequestTicket.IsVisible = true;//20221227
                    }
                }
                if (lstrCredential.Count > 0)
                {
                    if (lstrCredential[0].cc_axsrestrict_invoicepayments != "Y")
                    {
                        lblInvoicePayment.IsVisible = true;
                    }
                }
            }
        }

        private void HideMenus()
        {
            lblCMS.IsVisible = false;
            //lblTheme.IsVisible = false;
            lblRequestTicket.IsVisible = false;
            //lblRegDeReg.IsVisible = false;
            lblMain.IsVisible = false;
            lblKeyFeatures.IsVisible = false; //added by Anand on 1st Apr 2022, this was missed by Palani
                                              // lblDashboard.IsVisible = false;
            lblMyProfile1.IsVisible = false;
            lblTrack.IsVisible = false;
            lblInvoicePayment.IsVisible = false;
            //lblReleaseDeli.IsVisible = false;
            //lblCustomerSupport.IsVisible = false;
            lblAccountSettings.IsVisible = false;
            // lblWallet.IsVisible = false;
            lblNotifications.IsVisible = false;
            lblLogOut.IsVisible = false;
            lblFaq.IsVisible = false;
            lblcontactus.IsVisible = false;
            lblAboutRSGT.IsVisible = false;
            lblTermsCondition.IsVisible = true;
            lblDashboardBroken.IsVisible = false;
            lblDashboardTransporter.IsVisible = false;
            lblDashboardConsignee.IsVisible = false;
            lblInvoicePayment.IsVisible = false;
            lblOtherRequests.IsVisible = false;
            lblWallet.IsVisible = false;
        }

        private void testclicked(object sender, EventArgs e)
        {

        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {

        }
    }


}