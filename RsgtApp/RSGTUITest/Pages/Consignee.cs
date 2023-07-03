using Xamarin.UITest;
using System.Resources;
using RsgtUITest.Resource;
using System.Threading;
using RsgtUITest.Pages;

namespace RsgtUITest.Pages
{
   public class ConsigneeUser : BasicSetup
    {
        ResourceManager fobjResource = new ResourceManager(typeof(DashBoardResource));
        ResourceManager objResource = new ResourceManager(typeof(LoginResource));
        ResourceManager pobjResouce = new ResourceManager(typeof(ConsigneeResource));


        public ConsigneeUser(Platform platform) : base(platform)
        {
        }

        public void ProcRegisterUserLoginConsignee(string fstrUserType)

        {
            app.Tap(c => c.Marked("AEnglish"));
            app.Screenshot("SplashPage_EnglishClick");
            Thread.Sleep(120000);
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AlblGetStart"));
                app.Screenshot("GetStarted_Click");
                Thread.Sleep(1000);
            }

            Tap("AlblLogin");
            Tap("ATxtUserName");


            string lstrUsername = objResource.GetString("Username_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtUserName", lstrUsername);
            app.Screenshot(fstrUserType + "_Userid");
            Thread.Sleep(1000);

            //password
            Tap("ATxtPassword");
            string lstrPassword = objResource.GetString("Password_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtPassword", lstrPassword);
            app.Screenshot(fstrUserType + "_Password");
            Thread.Sleep(1000);

            //UserLogin btn click
            Tap("AbtnLogIn");
            app.Screenshot(fstrUserType + "_Login_Click");
            Thread.Sleep(1000);

            //OTP Assign
            Tap("AtxtOtp");
            string lstrOTP = objResource.GetString("OTP_" + fstrUserType).ToString().Trim();
            EnterTextID("AtxtOtp", lstrOTP);
            app.Screenshot(fstrUserType + "_OTP");
            Thread.Sleep(1000);

            //Confirm
            Tap("AbtnConfirm");//
            app.Screenshot(fstrUserType + "Confirm");
            Thread.Sleep(1000);

            //Assert.IsTrue(true,"pass");

            // Tap("OK");
            // app.Screenshot(fstrUserType + "SlideMenu");
            //Landing to Login User Details


       
       // public void procDwelldays(string fstrUserType)
        
            string lstrSearch = "";
            string lstrContainer = "";
            string lstrBayan = "";
            string lstrBOL = "";
            string lstrDwelldays = "";
            //string lstrDischargeDate = "";
            //string lstrGatedoutDate = "";

            //AlblDwellDays
            //AlblEvaluateServices
            //AlblTerminalVisit
            //AlblPaymentHistory
            //AlblAddedServices

            Tap("OK");
            Tap("AlblDashboard");
            Tap("AlblDwellDays");
            Tap("ATxtSearch");
            lstrSearch = fobjResource.GetString("Search_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtSearch", lstrSearch);
            app.Screenshot(fstrUserType + "Conatainerno");
            Tap("AImgSearch");
            app.Screenshot("Search");
            Thread.Sleep(2000);
            Tap("AImgFilter");
            app.Screenshot("Filter");
            Thread.Sleep(3000);
            Tap("AFilterSize");
            Tap("AImgDownArrow");

            Thread.Sleep(3000);

            //Containerno
            Tap("ATxtContainerNo");
            lstrContainer = fobjResource.GetString("Container_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtContainerNo", lstrContainer);
            app.DismissKeyboard();
            app.Screenshot("Containerno");
            //Bayan no
            Tap("ATxtBayanNo");
            lstrBayan = fobjResource.GetString("Bayan_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtBayanNo", lstrBayan);
            app.DismissKeyboard();
            app.Screenshot("Bayanno");

            //Billof LadingNo
            Tap("ATxtBillOfLadingNo");
            lstrBOL = fobjResource.GetString("BOL_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtBillOfLadingNo", lstrBOL);
            app.DismissKeyboard();
            app.Screenshot("BOL no");

            //DwellDays
            Tap("ATxtDwellDays");
            lstrDwelldays = fobjResource.GetString("Dwelldays_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtDwellDays", lstrDwelldays);
            app.DismissKeyboard();
            app.Screenshot(fstrUserType + "Dwelldays");

            //Dischargedate
            //app.Tap(c => c.Text("Done"));

            //Gated out date
            // app.Tap(c => c.Text("Done"));

            //Apply
            //Tap("ABtnApply");

            //Reset
            // Tap("AImgReset");

            //Cancel
            //Tap("AButtonClickedCancel");

      
            string lstrApplicantName = "";
            string lstrCompanyName = "";
            string lstrDesignation = "";
            string lstrNoofVisitors = "";
            string lstrVisitDuration = "";
            //string lstrPurposeofvisit = "";
            string lstrOpportunitiesIssueIdentified = "";

            //TerminalVisit
            Tap("OK");
            Tap("OK");

            //Terminalvisit
            Tap("AlblTerminalVisit");
            app.Screenshot("Terminalvisit");
            //Terminal visit  Application Name 
            Tap("AImgTxtAppliName");
            lstrApplicantName = fobjResource.GetString("ApplicantName_" + fstrUserType).ToString().Trim();
            EnterTextID("AImgTxtAppliName", lstrApplicantName);
            app.Screenshot("Terminalvisit1");

            // Terminal visit Company Name
            Tap("AImgTxtCmpyName");
            lstrCompanyName = fobjResource.GetString("CompanyName_" + fstrUserType).ToString().Trim();
            EnterTextID("AImgTxtCmpyName", lstrCompanyName);
            app.DismissKeyboard();

            //Terminal visit Designation
            Tap("AImgTxtDesg");
            lstrDesignation = fobjResource.GetString("Designation_" + fstrUserType).ToString().Trim();
            EnterTextID("AImgTxtDesg", lstrDesignation);
            app.DismissKeyboard();

            //Terminal no of Vistors
            Tap("AImgTxtVisitor");
            lstrNoofVisitors = fobjResource.GetString("NoofVisitors_" + fstrUserType).ToString().Trim();
            EnterTextID("AImgTxtVisitor", lstrNoofVisitors);
            app.DismissKeyboard();
            app.Screenshot("Terminalvisit1");


            Scrolldown("ATxtOpportun");

            //Terminal Visit Duration
            Tap("AImgTxtVisitDuration");
            lstrVisitDuration = fobjResource.GetString("VisitDuration_" + fstrUserType).ToString().Trim();
            EnterTextID("AImgTxtVisitDuration", lstrVisitDuration);
            app.DismissKeyboard();

            //Terminal Visit Purpose of Visit
            //Combobox
            //    Tap("APckPurposeVisit");
            //   app.Tap(c => c.Id("text1").Index(0)); //Android

            //Terminal visit opportunites/Issue Identified
            Tap("ATxtOpportun");
            lstrOpportunitiesIssueIdentified = fobjResource.GetString("OpportunitiesIssueIdentified_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtOpportun", lstrOpportunitiesIssueIdentified);
            app.DismissKeyboard();
            app.Screenshot("Terminalvisit2");

            //Terminal Visit Choose File
            //  app.Tap(c => c.Marked("NoResourceEntry-175"));

            //Terminal visit Submit Button
            //  app.Tap(c => c.Marked("NoResourceEntry-178"));
            //  


            //Payment history
            string lstrPaymentHistoryBOL = "";
            string lstrPaymentHistoryCustomer = "";
            string lstrPaymentHistoryFromAmount = "";
            string lstrPaymentHistoryInvoiceNo = "";
            string lstrPaymentHistoryPaymentRef = "";
            string lstrPaymentHistoryToAmount = "";


            Tap("OK");
            
            Tap("AlblPaymentHistory");
            Tap("ATxtSearch");
            lstrPaymentHistoryBOL = pobjResouce.GetString("PaymentHistoryBOL_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtSearch", lstrPaymentHistoryBOL);
            app.DismissKeyboard();
            Tap("AImgSearch");
            Tap("AImgFilter");

            //Status
            Tap("AImgDownArrow");
            app.Tap(c => c.Marked("AisChecked").Index(0));
            app.Screenshot("Status");
            Tap("AImgDownArrow");

            //MOP
            Tap("AImgDownArrow1");
            app.Tap(c => c.Marked("AisChecked2").Index(0));
            app.Screenshot("MOP");
            Tap("AImgDownArrow1");

            //Type
            Tap("AImgDownArrow2");
            app.Tap(c => c.Marked("AisChecked3").Index(0));
            app.Screenshot("Type");
            Tap("AImgDownArrow2");

            Tap("ATxtInvoiceNo");
            lstrPaymentHistoryInvoiceNo = pobjResouce.GetString("PaymentHistoryInvoiceNo_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtInvoiceNo", lstrPaymentHistoryInvoiceNo);
            app.DismissKeyboard();

            Tap("ATxtBillOfLadingNo");
            lstrPaymentHistoryBOL = pobjResouce.GetString("PaymentHistoryBOL_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtBillOfLadingNo", lstrPaymentHistoryBOL);
            app.DismissKeyboard();

            Tap("ATxtCustomer");
            lstrPaymentHistoryCustomer = pobjResouce.GetString("PaymentHistoryCustomer_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtCustomer", lstrPaymentHistoryCustomer);
            app.DismissKeyboard();

            Tap("ATxtPaymentRef");
            lstrPaymentHistoryPaymentRef = pobjResouce.GetString("PaymentHistoryPaymentRef_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtPaymentRef", lstrPaymentHistoryPaymentRef);
            app.DismissKeyboard();
            app.Screenshot(fstrUserType + "Paymenyhistory1");

            Scrolldown("AToDate");

            Tap("ATxtFromAmount");
            lstrPaymentHistoryFromAmount = pobjResouce.GetString("PaymentHistoryFromAmount_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtFromAmount", lstrPaymentHistoryFromAmount);
            app.DismissKeyboard();


            Tap("ATxtToAmount");
            lstrPaymentHistoryToAmount = pobjResouce.GetString("PaymentHistoryToAmount_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtToAmount", lstrPaymentHistoryToAmount);
            app.DismissKeyboard();

            app.Screenshot("Paymenthistory2");
            // Tap("AFromdate");
            // Tap("AToDate");


            // Tap("ABtnApply");
            // Tap("AImgReset");
            // Tap("AgotoClickedCancel");

            //Evaluate service
           // string lstrEvaluatebayan = "";
            string lstrEScomments1 = "";

            Tap("OK");
            Tap("OK");
            Tap("OK");
            Tap("AlblEvaluateServices");
            app.Screenshot("Evaluateservice" + fstrUserType);
            /*    Tap("AEntSearchBox");
                lstrEvaluatebayan = fobjResource.GetString("Evaluatebayan_" + fstrUserType).ToString().Trim();
                EnterTextID("AEntSearchBox", lstrEvaluatebayan);
                app.DismissKeyboard();
                app.Screenshot(fstrUserType + "Evalaute");
                Thread.Sleep(1000);

                Tap("AImgButSearch");
            */
            Thread.Sleep(5000);


            Tap("AlblStart");
            app.Screenshot("Startclick");

            //Billing & Paymentservice
            app.Tap(c => c.Class("ImageRenderer").Index(3));//Android
            Tap("ATxtComments1");
            lstrEScomments1 = fobjResource.GetString("EScomments1_" + fstrUserType).ToString().Trim();
            EnterTextID("ATxtComments1", lstrEScomments1);
            app.DismissKeyboard();
            app.Screenshot(fstrUserType + "EScomments1");

            // Scrolldown("AbtnSubmit");

            // Tap("AbtnSubmit");




        }



        public void ProcConsigneeDashBoard(string fstrUserType)
        {

        }
    }
}
