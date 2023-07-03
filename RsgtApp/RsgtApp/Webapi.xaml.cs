using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;

namespace RsgtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Webapi : ContentPage
    {
  
        public Webapi()
        {
            InitializeComponent();
            picWebAPI.Items.Add("Get BayanList");
            picWebAPI.Items.Add("Get BayanTrackingDetails");
            picWebAPI.Items.Add("Get BOLHeader");
            picWebAPI.Items.Add("Get BillofLading");
            picWebAPI.Items.Add("Get BOLPopupDetails");
            picWebAPI.Items.Add("Get ContainerDetailsHeader");
            picWebAPI.Items.Add("Get ContainerDetails");
            picWebAPI.Items.Add("Get Containers");
            picWebAPI.Items.Add("Get ContainerTimeLine");
            picWebAPI.Items.Add("Get InvoiceDetails");
            picWebAPI.Items.Add("Get AppointmentList");
            picWebAPI.Items.Add("Get DwelldaysDetails");
            picWebAPI.Items.Add("Get PaymentHistoryDetails");
            picWebAPI.Items.Add("Get ReeferFreeDaysDetails");
            picWebAPI.Items.Add("Get UnitDetails");
            picWebAPI.Items.Add("Get getEvaluateDetails");
            picWebAPI.Items.Add("Get getReadyToDeliveryDetails");
            picWebAPI.Items.Add("Get getBookforManualInspectionDetails");
            picWebAPI.Items.Add("Get getDetentionManagementDetails");
            picWebAPI.Items.Add("Get getBannedTrucksDetails");
            picWebAPI.Items.Add("Get getEmptyReturnDetails");

            picWebAPI.Items.Add("Get NotificationEmailUser");
            picWebAPI.Items.Add("Get NotificationSmsUser");
            picWebAPI.Items.Add("Get UserDetails");
            picWebAPI.Items.Add("Get CmsMailDetails");
            picWebAPI.Items.Add("Get CmsSmsDetails");
            picWebAPI.Items.Add("Get MailMessage");
            picWebAPI.Items.Add("Get SmsMessage");
            picWebAPI.Items.Add("Get WalletDetails");
            picWebAPI.Items.Add("Get RegisterApplicationDetails");
            picWebAPI.Items.Add("Get AppoinmentDetails");
            picWebAPI.Items.Add("Get VesselArrivalDetails");
            picWebAPI.Items.Add("Get VesselInportDetails");
            picWebAPI.Items.Add("Get VesselDepartureDetails");
            picWebAPI.Items.Add("Get RegisterUserDetails");
            
        }

        private void selectWebApiChoice(object sender, EventArgs e)
        {
            DisplayAlert("selected item", picWebAPI.SelectedItem.ToString(), "close");
            string Selecteditems = "";
            Selecteditems = picWebAPI.SelectedItem.ToString();
            BLConnect objBusiness = new BLConnect();

            /* commented by saravanan on 30th Apr 2022
            switch (Selecteditems)
            {
                case "Get BayanList":
                    List<clsBayan> lobjBayanList = new List<clsBayan>();
                   // lobjBayanList = objBusiness.getUserBayanList("bspldelivery@gmail.com");
                    break;

                case "Get BOLHeader":
                    List<clsListofbayandetails> lobjBOLHeader = new List<clsListofbayandetails>();
                    lobjBOLHeader = objBusiness.getBOLHeaderDetails("bspldelivery@gmail.com","");
                    break;

                case "Get BayanTrackingDetails":
                    List<clsListofbayandetails> lobjBayanTracking = new List<clsListofbayandetails>();
                    lobjBayanTracking = objBusiness.getBayanTrackingDetails("varun@gmail.com");
                    break;

                case "Get BillofLading":
                    List<clsListofbillofladings> lobjBillofLading = new List<clsListofbillofladings>();
                   // lobjBillofLading = objBusiness.getBillofLading("bspldelivery@gmail.com","");
                    break;

                case "Get BOLPopupDetails":
                    List<clsCommoditypopup> lobjBOLPopup = new List<clsCommoditypopup>();
                    lobjBOLPopup = objBusiness.getBOLPopupDetails("bspldelivery@gmail.com","");
                    break;

                case "Get ContainerDetailsHeader":
                    List<clsListofbillofladings> lobjContainerDetailsHeader = new List<clsListofbillofladings>();
                    lobjContainerDetailsHeader = objBusiness.getContainerDetailsHeader("hpyvthbns@gmail.com","");
                    break;

                case "Get ContainerDetails":
                    List<clsListofcontainer> lobjContainerDetails = new List<clsListofcontainer>();
                    lobjContainerDetails = objBusiness.getContainerDetails("hari785@gmail.com","");
                    break;

                // Need to clarify with palani    
                case "Get Containers":
                    List<clsListofcontainer> lobjContainer = new List<clsListofcontainer>();
                    lobjContainer = objBusiness.getContainers("hari785@gmail.com");
                    break;

                case "Get ContainerTimeLine":
                    List<clsContainertimeline> lobjContainerTimeLine = new List<clsContainertimeline>();
                    lobjContainerTimeLine = objBusiness.getContainerTimeLine("apk@gmail.com","");
                    break;


                case "Get InvoiceDetails":
                    List<clsPinvoiceheaderlistview> lobjInvoiceDetails = new List<clsPinvoiceheaderlistview>();
                    lobjInvoiceDetails = objBusiness.getInvoiceDetails("varun@gmail.com");
                    break;

                case "Get AppointmentList":
                    List<clsBayan> lobjAppointment = new List<clsBayan>();
                   // lobjAppointment = objBusiness.getUserBayanList("aravindrt@gmail.com");
                    break;

                case "Get DwelldaysDetails":
                    List<clsListviewdwelldays> lobjDwelldays = new List<clsListviewdwelldays>();
                    lobjDwelldays = objBusiness.getDwelldaysDetails("satkum@gmail.com");
                    break;

                case "Get PaymentHistoryDetails":
                    List<clsListviewpaymenthistory> lobjPaymentHistory = new List<clsListviewpaymenthistory>();
                    lobjPaymentHistory = objBusiness.getPaymentHistoryDetails("satkum@gmail.com");
                    break;

                case "Get ReeferFreeDaysDetails":
                    List<clsListviewdwelldays> lobjReeferList = new List<clsListviewdwelldays>();
                    lobjReeferList = objBusiness.getDwelldaysDetails("vedaerp@gmail.com");
                    break;

                case "Get UnitDetails":
                    List<clsListviewdwelldays> lobjUnitDetailsList = new List<clsListviewdwelldays>();
                    lobjUnitDetailsList = objBusiness.getDwelldaysDetails("sk@gmail.com");
                    break;


                //case "Get EvaluateDetails":
                case "Get getEvaluateDetails":
                    //List<clsBayan> lobjEvaluateDetailsList = new List<clsBayan>();
                    // lobjEvaluateDetailsList = objBusiness.getUserBayanList("varun@gmail.com");
                    List<clsEvaluateform> lobjEvaluateDetailsList = new List<clsEvaluateform>();
                    lobjEvaluateDetailsList = objBusiness.getEvaluateDetails("varun@gmail.com");
                    break;


                    // case "Get ReadyToDeliveryDetails":
                        case   "Get getReadyToDeliveryDetails":
                    List<clsReadytodelivery> lobjReadyToDeliveryDetailsList = new List<clsReadytodelivery>();
                    lobjReadyToDeliveryDetailsList = objBusiness.getReadyToDeliveryDetails("vedaerp@gmail.com");
                    break;

                //case "Get BookforManualInspectionDetails":
                case "Get getBookforManualInspectionDetails":
                    List<clsBookformanualinspection> lobjBookforManualInspectionDetailsList = new List<clsBookformanualinspection>();
                    lobjBookforManualInspectionDetailsList = objBusiness.getBookforManualInspectionDetails("cielobroker1@gmail.com");
                    break;

               // case "Get DetentionManagementDetails":
                case "Get getDetentionManagementDetails":
                    List<clsDetentionmanagement> lobjDetentionManagementDetailsList = new List<clsDetentionmanagement>();
                    lobjDetentionManagementDetailsList = objBusiness.getDetentionManagementDetails("neekr@gmail.com");
                    break;

               // case "Get BannedTrucksDetails":
                case "Get getBannedTrucksDetails":
                    List<clsBannedtrucks> lobjBannedTrucksDetailsList = new List<clsBannedtrucks>();
                    lobjBannedTrucksDetailsList = objBusiness.getBannedTrucksDetails("cieloclearingagent@gmail.com");
                    break;

                //case "Get EmptyReturnDetails":
                case "Get getEmptyReturnDetails":
                    List<clsEmptyreturn> lobjEmptyReturnDetailsList = new List<clsEmptyreturn>();
                    lobjEmptyReturnDetailsList = objBusiness.getEmptyReturnDetails("aravindrt@gmail.com");
                    break;
   
                //case "Get NotificationEmailUser":
                case "Get NotificationEmailUser":
                    List<clsEmailnotifications> lobjNtfyemailList = new List<clsEmailnotifications>();
                    lobjNtfyemailList = objBusiness.getNotificationEmailUser("aravindrt@gmail.com");
                    break;

                case "Get NotificationSmsUser":
                    List<clsSMSNotifications> lobjNtfysmsList = new List<clsSMSNotifications>();
                    lobjNtfysmsList = objBusiness.getNotificationSmsUser("aravindrt@gmail.com");
                    break;

                case "Get UserDetails":
                    List<clsUsersDetails> lobjUserDetailsList = new List<clsUsersDetails>();
                    lobjUserDetailsList = objBusiness.getUserDetails("aravindrt@gmail.com");
                    break;

                case "Get CmsMailDetails":
                    List<clsCMSMaildetail> lobjCmsMailDetailsList = new List<clsCMSMaildetail>();
                    lobjCmsMailDetailsList = objBusiness.getCmsMailDetails("aravindrt@gmail.com");
                    break;

                case "Get CmsSmsDetails":
                    List<clsCMSSMSDetail> lobjCmssmsDetailsList = new List<clsCMSSMSDetail>();
                    lobjCmssmsDetailsList = objBusiness.getCmsSmsDetails("aravindrt@gmail.com");
                    break;

                case "Get MailMessage":
                    List<clsMailtemplates> lobjMail = new List<clsMailtemplates>();
                    lobjMail = objBusiness.getMailMessage("aravindrt@gmail.com");
                    break;

                case "Get SmsMessage":
                    List<clsSMStemplates> lobjsms = new List<clsSMStemplates>();
                    lobjsms = objBusiness.getSmsMessage("aravindrt@gmail.com");
                    break;

            }
            */
        }
    }
}