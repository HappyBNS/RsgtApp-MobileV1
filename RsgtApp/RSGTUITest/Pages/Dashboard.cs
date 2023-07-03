using Xamarin.UITest;
using System.Resources;
using RsgtUITest.Resource;
using System.Threading;



namespace RsgtUITest.Pages
{
    public class Dashboard : BasicSetup
    {
        //Arrange-to creation of object
        ResourceManager fobjResource = new ResourceManager(typeof(DashBoardResource));
        ResourceManager objTResource = new ResourceManager(typeof(RequestResource));
        public Dashboard(Platform platform) : base(platform)
        {
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// Dwelldays
        /// This method Use to three different type of users.
        /// This page is listing eligible containers for logged in user with dwell days for each container.
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.    
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent user
        /// 3.Consignee User 
        /// </param>
        /// Obsolete Date:
        /// Category:Method
      
        public void procDwelldays(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrSearch = "";
            //string lstrContainer = "";
            //string lstrBayan = "";
            //string lstrBOL = "";
            //string lstrDwelldays = "";
            //string lstrDischargeDate = "";
            //string lstrGatedoutDate = "";

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            Thread.Sleep(1000);
            //Act-focus on dwell days button click
            Tap("AlblDwellDays");
            Thread.Sleep(1000);
            //Act-focus on search button click
            Tap("ATxtSearch");
            Thread.Sleep(1000);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("DwellDays_" + fstrUserType);

            //Act-focus on search button click
            /*    Tap("ATxtSearch");
                
                //Act-reading value from the resource file
                lstrSearch = fobjResource.GetString("Search_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                EnterTextID("ATxtSearch", lstrSearch);
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "Conatainerno");
                //Act-focus on search button click
                Tap("AImgSearch");
                // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
                app.Screenshot("Search");
                Thread.Sleep(2000);
               //Act-focus on filter button click
                Tap("AImgFilter");
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("Filter");
                Thread.Sleep(3000);
               //Act-focus on filter size control
                Tap("AFilterSize");
              //Act-focus on expand collapse control
                Tap("AImgDownArrow");

                Thread.Sleep(3000);

                //Act-focus on container number control
                Tap("ATxtContainerNo");
                //Act-reading value from the resource file
                lstrContainer = fobjResource.GetString("Container_" + fstrUserType).ToString().Trim();
                //Act-assigning value to the control
                EnterTextID("ATxtContainerNo", lstrContainer);
                 //Act-dismiss keyboard
                app.DismissKeyboard();
              // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
                app.Screenshot("Containerno");

                //Act-focus on bayan number control
                Tap("ATxtBayanNo");
                //Act-reading value from the resource file
                lstrBayan = fobjResource.GetString("Bayan_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
                EnterTextID("ATxtBayanNo", lstrBayan);
                //Act-dismiss keyboard
                app.DismissKeyboard();
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("Bayanno");

                //Act-focus on bill of ladingNo number control 
                Tap("ATxtBillOfLadingNo");
                //Act-reading value from the resource file
                lstrBOL = fobjResource.GetString("BOL_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
                EnterTextID("ATxtBillOfLadingNo", lstrBOL);
               //Act-dismiss keyboard
                app.DismissKeyboard();
                  // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("BOL no");

                //Act-focus on dwell days button click 
                Tap("ATxtDwellDays");
                //Act-reading value from the resource file
                lstrDwelldays = fobjResource.GetString("Dwelldays_" + fstrUserType).ToString().Trim();
                //Act-assigning value to the control
                EnterTextID("ATxtDwellDays", lstrDwelldays);
                //Act-dismiss keyboard
                app.DismissKeyboard();
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "Dwelldays");

                //Act-focus on discharge date control
                //app.Tap(c => c.Text("Done"));

                //Act-focus on gated out date control
                // app.Tap(c => c.Text("Done"));

                //Act-focus on apply button click
                //Tap("ABtnApply");

                 //Act-focus on reset button click
                // Tap("AImgReset");

                 //Act-focus on cancel button click
                //Tap("AButtonClickedCancel");
            */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// Terminalvisit
        /// This method Use to Consignee user only.
        /// This page is to request for terminal visit.
        /// Information page will show with respective information.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Consignee User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procTerminalvisit(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrApplicantName = "";
            //string lstrCompanyName = "";
            //string lstrDesignation = "";
            //string lstrNoofVisitors = "";
            //string lstrVisitDuration = "";
            //string lstrPurposeofvisit = "";
            //string lstrOpportunitiesIssueIdentified = "";

            //DashBoard
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");

            //Act-focus on terminal vsit button click
            Tap("AlblTerminalVisit");
            Thread.Sleep(1000);

            //  Thread.Sleep(1000);
            //Act-focus on application name  control
            Tap("AImgTxtAppliName");
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Terminalvisit_" + fstrUserType);
            //Act-reading value from the resource file
            /*  lstrApplicantName = fobjResource.GetString("ApplicantName_" + fstrUserType).ToString().Trim();
             //Act-assigning value to the control
            EnterTextID("AImgTxtAppliName",lstrApplicantName);     
             // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Terminalvisit1");

            //Act-focus on terminal vsit company name control 
            Tap("AImgTxtCmpyName");
            //Act-reading value from the resource file
            lstrCompanyName = fobjResource.GetString("CompanyName_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AImgTxtCmpyName",lstrCompanyName);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on terminal vsit designation control 
            Tap("AImgTxtDesg");
            //Act-reading value from the resource file
            lstrDesignation = fobjResource.GetString("Designation_" + fstrUserType).ToString().Trim();
           //Act-assigning value to the control
            EnterTextID("AImgTxtDesg",lstrDesignation);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on terminal visit number of vistors control
            Tap("AImgTxtVisitor");
            //Act-reading value from the resource file
            lstrNoofVisitors = fobjResource.GetString("NoofVisitors_" + fstrUserType).ToString().Trim();
           //Act-assigning value to the control
            EnterTextID("AImgTxtVisitor",lstrNoofVisitors);
            //Act-dismiss keyboard
            app.DismissKeyboard();
             // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Terminalvisit1");

            //Act-scroll down to opportunities issue identified
            Scrolldown("ATxtOpportun");

            //Act-focus on terminal vist duration control 
            Tap("AImgTxtVisitDuration");
            //Act-reading value from the resource file
            lstrVisitDuration = fobjResource.GetString("VisitDuration_" + fstrUserType).ToString().Trim();
           //Act-assigning value to the control
            EnterTextID("AImgTxtVisitDuration",lstrVisitDuration);           
           //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on terminal purpose of visit control  
            //Act-focus on combo box control
          //    Tap("APckPurposeVisit");
           //   app.Tap(c => c.Id("text1").Index(0)); //Android

            //Terminal visit opportunites/Issue Identified
            Tap("ATxtOpportun");
            //Act-reading value from the resource file
            lstrOpportunitiesIssueIdentified = fobjResource.GetString("OpportunitiesIssueIdentified_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("ATxtOpportun",lstrOpportunitiesIssueIdentified);
            //Act-dismiss keyboard
            app.DismissKeyboard();
             // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Terminalvisit2");

           //Act-focus on terminal vist choose file control  
            //  app.Tap(c => c.Marked("NoResourceEntry-175"));

             //Act-focus on terminal vist submit button click
            //  app.Tap(c => c.Marked("NoResourceEntry-178"));    
         */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// EvaluateServices
        /// This method Use to three different type of users.
        /// This page is to evaluate service for selected bayan & bill of lading.
        /// Click “Start” button to do the survey.
        /// Survey Page:
        ///User has to fill the survey page with ratings and comments
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Consignee User
        /// 2.Broker User
        /// 3ClearingAgent user  
        /// </param>
        /// Obsolete Date:
        /// Category:Method 
        public void procEvaluateServices(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrEvaluatebayan = "";
           // string lstrEScomments1 = "";
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            Tap("AlblDashboard");
            //Act-focus on evaluate services control
            Tap("AlblEvaluateServices");

            //Act-focus on search box button click
            Tap("AEntSearchBox");
            //Act-dismiss keyboard
            app.DismissKeyboard();
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Evaluateservice" + fstrUserType);
            Thread.Sleep(1000);
            /*   //Act-reading value from the resource file
                lstrEvaluatebayan = fobjResource.GetString("Evaluatebayan_" + fstrUserType).ToString().Trim();
                //Act-assigning value to the control
                EnterTextID("AEntSearchBox", lstrEvaluatebayan);
                //Act-dismiss keyboard
                app.DismissKeyboard();
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "Evalaute");
                Thread.Sleep(1000);
                 //Act-focus on search button click
                Tap("AImgButSearch");

                Thread.Sleep(5000);

               //Act-focus on start button click
                Tap("AlblStart");
                app.Screenshot("Startclick");

                //Act-focus on billing & paymentservice control
                app.Tap(c => c.Class("ImageRenderer").Index(3));//Android
               //Act-focus on comments 1 control
                Tap("ATxtComments1");
               //Act-reading value from the resource file
                lstrEScomments1 = fobjResource.GetString("EScomments1_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
                EnterTextID("ATxtComments1", lstrEScomments1);
               //Act-dismiss keyboard
                app.DismissKeyboard();
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "EScomments1");
            */
            //Act-scroll down to submit button click
            // Scrolldown("AbtnSubmit");

            //Act-focus on submit button click
            // Tap("AbtnSubmit");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// ReadyforDeliver
        /// This method Use to three different type of users.
        /// This page is listing eligible containers ready for delivery for logged in.
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent user 
        /// 3.Transporter User   
        /// </param>
        /// Obsolete Date:
        /// Category:Method 
        public void procReadyforDeliver(string fstrUserType)
        {

            //Arrange-variable initalization
            //string lstrContainer = "";
            //string lstrBayan = "";
            //string lstrBOL = "";
            //string lstrSearch = "";
            //Dashboard
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            Thread.Sleep(2000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Dashboard");

            //Act-focus on ready to deliver button click 
            Tap("AlblReadyToDeliver");
            Thread.Sleep(2000);

            //Act-focus on label control
            Tap("APlaceSearch");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "ReadyToDeliver");
            //Act-reading value from the resource file
            /*   lstrSearch = fobjResource.GetString("Search_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("APlaceSearch", lstrSearch);
               //Act-dismiss keyboard
               app.DismissKeyboard();

               //Act-focus on search button click
               Tap("AImgSearch");


               //Act-focus on filters button click
               Tap("AImgFilter");

               //Size
               //Act-focus on size control
               //app.Tap("AlblSize");
               //Act-focus on expand collapse control
               Tap("AImgDownar");
               Thread.Sleep(1000);
               //All
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
                   {
                   app.Tap(c => c.Marked("AisCheckedval").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("Size");
                   }
               //Act-focus on expand collapse control
               Tap("AImgDownar");


               //Act-focus on expand carrier collapse control
               Tap("AimgDownRow");
               Thread.Sleep(1000);
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("AisCheckedvalue").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("Carrier");
               }
               //Act-focus on expand carrier collapse control
               Tap("AimgDownRow");


               //Act-focus on expand category collapse control
               //Tap("AimgDown");
               Thread.Sleep(1000);
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("ACkeckData").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("Category");
               }
               //Act-focus on expand category collapse control
               Tap("AimgDown");


               //Act-focus on expand freight kind collapse control
               Tap("AimgArrows");
               Thread.Sleep(1000);
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("ACheck").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("FreightKind");
               }
               //Act-focus on expand freight kind collapse control
               Tap("AimgArrows");

               //Act-scroll down to bill lading number
               Scrolldown("ATxtBillLadingNo");


               //Act-focus on expand pol collapse control
               Tap("AimgDowns");
               Thread.Sleep(1000);
               //All
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("Achecks").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("pol");
               }
               //Act-focus on expand pol collapse control
               Tap("AimgDowns");

               //Act-focus on expand pod collapse control
               Tap("AimgDownArrs");
               Thread.Sleep(1000);
               //All
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("Acheckdata").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("pod");
               }
               //Act-focus on expand pod collapse control
               Tap("AimgDownArrs");

               //Act-focus on container number control
               Tap("ATxtContainerNo");
               //Act-reading value from the resource file
               lstrContainer = fobjResource.GetString("Container_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("ATxtContainerNo",lstrContainer);
               //Act-dismiss keyboard
               app.DismissKeyboard();

               //Act-focus on bayan number control 
               Tap("ATxtBayanNo");
               //Act-reading value from the resource file
               lstrBayan = fobjResource.GetString("Bayan_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("ATxtBayanNo",lstrBayan);
               //Act-dismiss keyboard
               app.DismissKeyboard();

               //Act-focus on bill of lading number control 
               Tap("ATxtBillLadingNo");
               //Act-reading value from the resource file
               lstrBOL = fobjResource.GetString("BOL_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("ATxtBillLadingNo",lstrBOL);
               //Act-dismiss keyboard
               app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot(fstrUserType + "ReadyfordeliveryFilter");

               //Act-focus on apply button click
               //Tap("ABtnApply");
               //Act-focus on reset button click
               //Tap("AImgReset");

               //Act-focus on cancel button click
               //Tap("AXs");

               */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// Appoinments
        /// This method Use to two different type of users.
        /// This page is listing eligible containers ready for book an appointment for logged in user with dwell days for each container.
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent user  
        /// </param>
        /// Obsolete Date:
        /// Category:Method 
        public void procAppoinments(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrAppoinmentContainer = "";
            //string lstrAppoinmentBOL = "";
            //string lstrAppoinmentTMSReference = "";
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Dashboard");
            //Act-focus on appointments button click
            Tap("AlblAppointments");
            Thread.Sleep(1000);
            //Act-focus on search button click 
            Tap("AlobjSearchbox");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Appointments");
            //Act-reading value from the resource file
            /*  lstrAppoinmentContainer = fobjResource.GetString("AppoinmentContainer_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("AlobjSearchbox", lstrAppoinmentContainer);
               //Act-dismiss keyboard
               app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot(fstrUserType + "Searchbox");

              //Act-focus on search button click 
              Tap("AImgButSearch");
               

             //Act-focus on filter button click 
              Tap("AImgButFilter");


              //Act-focus on bill of lading Number control
              Tap("AEtyBillofLadingNo");
              //Act-reading value from the resource file
              lstrAppoinmentBOL = fobjResource.GetString("AppoinmentBOL_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEtyBillofLadingNo", lstrAppoinmentBOL);
              //Act-dismiss keyboard
              app.DismissKeyboard();
              
             //Act-focus on container Number control
              Tap("AEtyContainerNo");
             //Act-reading value from the resource file
              lstrAppoinmentContainer = fobjResource.GetString("AppoinmentContainer_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEtyContainerNo", lstrAppoinmentContainer);
              //Act-dismiss keyboard
               app.DismissKeyboard();
              // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
              app.Screenshot(fstrUserType + "Searchbox");

              //Act-focus on tms reference control
              Tap("AEtyTmsReference");
              //Act-reading value from the resource file
              lstrAppoinmentTMSReference = fobjResource.GetString("AppoinmentTMSReference_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEtyTmsReference", lstrAppoinmentTMSReference);
               //Act-dismiss keyboard
              app.DismissKeyboard();


            //Act-focus on expand collapse control
              Tap("AImgDownArrow");
              //Validating the ios or android 
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("AChkColor").Index(1));
                   // The screenshot can be inspected after the test run to verify
                    // the visual correctness of the screen.
                  app.Screenshot("Broker_Appoiments");
              }

            //Act-focus on expand collapse control
              Tap("AImgDownArrow");

              //Act-focus on apply button click
              //  Tap("AlButApply");
             //Act-focus on reset button click
              //  Tap("AIMgButRest");
             //Act-focus on cancel button click
              // Tap("AButtonClickedCancel");  

              */
        }

        /// <summary>
        /// RegisterUserLogin Dashboard
        /// This method Use to three different type of users.
        ///	This page is listing eligible all tickets of logged in user.
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent user  
        /// </param>
        public void procCashManagement(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrSearchBxValue = "Service Request";
            //string lstrTicketNo = "456879844";

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on login button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            app.Screenshot(fstrUserType + "Menu");
            Thread.Sleep(2000);
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            //Act-focus on case management button click
            Tap("AlblCaseManagement");
            //Act-focus on search box button click
            //Tap("ASearchbox");
            //Act-focus on search button click
            //Tap("AImgSearch");
            //Act-focus on filter button click
            // Tap("AImgFilter");
            //Act-focus on search box control
            Tap("ASearchbox");
            app.Screenshot(fstrUserType + "CaseManagement");
            //Act-assigning value to the control
            /* EnterTextID("ASearchbox", lstrSearchBxValue);
             //Act-dismiss keyboard
             app.DismissKeyboard();

             //Act-focus on search button  click
             Tap("AImgSearch");

             //Act-focus on filter icon button click
             Tap("AImgFilter");

             //Act-focus on expand collapse status control
             Tap("AImgDownArrow1");
             //Validating the ios or android 
             if (AppManager.AppManager.Platform == Platform.Android)
             {
                 app.Tap(c => c.Marked("AisChecked1").Index(0));
                 // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot("Status");
             }
             //Act-focus on expand collapse status control
             Tap("AImgDownArrow1");

             //Act-focus on expand collapse categorys control 
             Tap("AImgDownArrow2");
             //Validating the ios or android 
             if (AppManager.AppManager.Platform == Platform.Android)
             {
                 app.Tap(c => c.Marked("AisChecked2").Index(0));
                 // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot("Category");
             }
             //Act-focus on expand collapse categorys control 
             Tap("AImgDownArrow2");

             //Act-focus on expand collapse type control 
             Tap("AImgDownArrow3");
             //Validating the ios or android 
             if (AppManager.AppManager.Platform == Platform.Android)
             {
                 app.Tap(c => c.Marked("AisChecked3").Index(0));
                 // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot("Type");
             }
             //Act-focus on expand collapse type control 
             Tap("AImgDownArrow3");
             //Act-dismiss keyboard
             app.DismissKeyboard();

             //Act-focus on ticket number control
             Tap("AEtyTicketno");
             //Act-assigning value to the control
             EnterTextID("AEtyTicketno", lstrTicketNo);
             //Act-dismiss keyboard
             app.DismissKeyboard();

             //Act-focus on apply button click
             // Tap("AImgApplyId");
             //Act-focus on Refresh button click  
             // Tap("AImgReset");

             //Act-focus on cancel button click  
             // Tap("AButtonClickedCancel");
            */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// Invoice
        /// This method Use to three different type of users.
        /// This page is to list all the invoices for logged in user.
        ///	The user can cancel and re-generate yet to paid invoices.
        ///	The user can pay for invoices.
        ///	The user can book an appointment.
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// </summary>
        /// <param name="fstrUserType">  
        /// 1.Broker User
        /// 2.ClearingAgent user
        /// 3.Consignee User
        /// </param>
        /// Obsolete Date:
        /// Category:Method 
        public void procInvoice(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrInvoiceBOL = "";
            //string lstrInvoiceno = "";
            //string lstrCustomer = "";
            //string lstrPayment = "";
            //string lstrFromAmount = "";
            //string lstrToAmount = "";

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on login button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            //Act-focus on invoicing button click
            Tap("AlblInvoicing");

            //Act-focus on search box control
            Tap("AButTxtSearch");
            app.Screenshot(fstrUserType + "Invoice");
             
        /*    //Act-reading value from the resource file
            lstrInvoiceBOL = fobjResource.GetString("InvoiceBOL_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AButTxtSearch", lstrInvoiceBOL);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            //Act-focus on search button click
            Tap("AImgSearch");
            Thread.Sleep(1000);
            //Act-focus on filter button click
            Tap("AIMGButFilter");
            //  Tap("AImgbutDotsicon");

            //Act-focus on expand collapse status control 
            Tap("AImgDownArrowtxt");
            app.Tap(c => c.Marked("AButIsCheck").Index(0));
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Status");
            //Act-focus on expand collapse status control 
            Tap("AImgDownArrowtxt");

            //Act-focus on expand collapse mop control 
            Tap("AImgDownArrow2txt");
            app.Tap(c => c.Marked("AButCheck").Index(0));
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("MOP");
            //Act-focus on expand collapse mop control 
            Tap("AImgDownArrow2txt");

            //Act-focus on expand collapse type control
            Tap("AImgDownArrow3txt");
            app.Tap(c => c.Marked("AButIsCheck").Index(0));
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Type");
            //Act-focus on expand collapse type control
            Tap("AImgDownArrow3txt");

            //Act-focus on invoice number control
            Tap("AButTxtInvoiceno");
            //Act-reading value from the resource file
            lstrInvoiceno = fobjResource.GetString("Invoiceno_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AButTxtInvoiceno", lstrInvoiceno);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on bill of lading number control
            Tap("AButTxtBolNo");
            //Act-reading value from the resource file
            lstrInvoiceBOL = fobjResource.GetString("InvoiceBOL_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AButTxtBolNo", lstrInvoiceBOL);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on customer control
            Tap("AButTxtCus2");
            //Act-reading value from the resource file
            lstrCustomer = fobjResource.GetString("Customer_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AButTxtCus2", lstrCustomer);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on payment ref control
            Tap("AButPaymentRef");
            //Act-reading value from the resource file
            lstrPayment = fobjResource.GetString("Payment_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AButPaymentRef", lstrPayment);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Invoice1");

            //Act-scroll down to to date control
            Scrolldown("APckTodate");

            //Act-focus on from amount control
            Tap("AButFromAmt");
            //Act-reading value from the resource file
            lstrFromAmount = fobjResource.GetString("FromAmount_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AButFromAmt", lstrFromAmount);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on to amount control
            Tap("AButToAmt");
            //Act-reading value from the resource file
            lstrToAmount = fobjResource.GetString("ToAmount_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AButToAmt", lstrToAmount);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on from date control
            Tap("AButFormdate");
            //Act-focus on to date control
            Tap("APckTodate");





            //Act-focus on apply button click
            //  Tap("AButApply");
            //Act-focus on reset button click
            //  Tap("AButImgReset");
            //Act-focus on cancel button click
            //  Tap("AButtonClickedCancel");
            //  "AImgFltBlue"
        */
        }

        /// <summary> 
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Settings
        /// This method Use to Four different type of users.       
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procAccountsettings(string fstrUserType)

        {
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on account settings control
            Tap("AlblAccountSettings");

            //Act-focus on temperature control
            Tap("AlobjTemperature");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Id("text1").Index(0));
                // the visual correctness of the screen.
                app.Screenshot("Temerature");
            }
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                app.Tap(c => c.Class("UIPickerTableView").Child("UIPickerTableViewTitledCell").Index(1));
            }
            // The screenshot can be inspected after the test run to verify
            //Act-focus on weight control
            Tap("AlobjWeight");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Id("text1").Index(0));
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                app.Tap(c => c.Class("UIPickerTableView").Child("UIPickerTableViewTitledCell").Index(1));
            }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("weight");

            //Act-focus on save button click
            //  Tap("ABtnSave");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// This method Use to three different type of users.
        /// This page is listing eligible containers of logged in user to book for manual inspection.
        /// Select containers and click “Disclaimer” button, the selected containers are saved for manual inspection.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent user 
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        /// 
        public void procBookForManualInspection(string fstrUserType)
        {

            //Arrange-variable initalization
            //string lstrBookForManualcontainer = "";
            //string lstrBookForManualBayan = "";
            //string lstrBookForManualBOL = "";

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on login button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
          
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on login button click
                Scrolldown("AlblBookForManual");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Scrolldown("AlblBookForManual");
            }
            //Act-focus on book for manual button click
            Tap("AlblBookForManual");

            //Act-focus on search box button control
            Tap("AEntSearchBox");
            app.Screenshot(fstrUserType + "BookForManual");
            //Act-reading value from the resource file
          /*  lstrBookForManualcontainer = fobjResource.GetString("BookForManualcontainer_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AEntSearchBox",lstrBookForManualcontainer);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Searchbox");
            //Act-focus on search button click
            Tap("AImgSearch");
            //Act-focus on filter button click
            Tap("AButImgFliter");
            Thread.Sleep(1000);

            //Act-focus on expand collapse size control
            Tap("AImgArrowIns");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkChecked6Ins").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "Size");
            }
            //Act-focus on expand collapse size control
            Tap("AImgArrowIns");

            //Act-focus on expand collapse carrier control
            Tap("AImgDownarsins");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkChecked2Ins").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "Carrier");
            }
            //Act-focus on expand collapse carrier control
            Tap("AImgDownarsins");

            //Act-focus on expand collapse category control
            Tap("AImgArrowDowIns");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkChecked5Ins").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "Category");
            }
            //Act-focus on expand collapse category control
            Tap("AImgArrowDowIns");

            //Act-focus on expand collapse freight kind control
            Tap("AImgDownRowsIns");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkChecked8Ins").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "FreightKind");
            }
            //Act-focus on expand collapse freight kind control
            Tap("AImgDownRowsIns");

            //Act-focus on expand collapse pol control
            Tap("AImgArrsIns");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkChecked3Ins").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "POL");
            }
            //Act-focus on expand collapse pol control
            Tap("AImgArrsIns");

            //Act-focus on expand collapse pod control
            Tap("AImgArrows1Ins");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkChecked4Ins").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot(fstrUserType + "POD");
            }
            //Act-focus on expand collapse pod control
            Tap("AImgArrows1Ins");

            //Act-scroll down to bill of lading number control
            Scrolldown("ATxtBillOfLadingNo");

               //Act-focus on container number control 
               Tap("ATxtContainerNo");
               //Act-reading value from the resource file
               lstrBookForManualcontainer = fobjResource.GetString("BookForManualcontainer_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("ATxtContainerNo", lstrBookForManualcontainer);
               //Act-dismiss keyboard
               app.DismissKeyboard();

            //Act-focus on bayan number control 
            Tap("ATxtBayanNo");
            //Act-reading value from the resource file
            lstrBookForManualBayan = fobjResource.GetString("BookForManualBayan_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("ATxtBayanNo", lstrBookForManualBayan);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on bill of lading number control 
            Tap("ATxtBillOfLadingNo");
            //Act-reading value from the resource file
            lstrBookForManualBOL = fobjResource.GetString("BookForManualBOL_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("ATxtBillOfLadingNo", lstrBookForManualBOL);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on apply button click
            //  Tap("AButApply");
            //Act-focus on refresh button click
            //  Tap("AImgButImgRestIns");
            //Act-focus on cancel button click
            //  Tap("AButton_ClickedCancel");


            */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// This method Use to Transporter User only.
        /// List Page:
        /// This page is to request truck service, user has to fill required data and submit.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Transporter User
        ///  </param>
        ///  Obsolete Date:
        /// Category:Method
        public void procTruckServiceRequest(string fstrUserType)
        {
            //Arrange-variable initalization
           // string lstrTruckNo = "";
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Dashboard");

            Scrolldown("AlblTruckRequest");
            //Act-focus on truck request button click
            Tap("AlblTruckRequest");

            //Act-focus on truck number control 
            Tap("AEtyTruckNo");
            app.Screenshot(fstrUserType + "TruckServiceRequest");
            //Act-reading value from the resource file
            /*      lstrTruckNo = fobjResource.GetString("TruckNo_" + fstrUserType).ToString().Trim();
                   //Act-assigning value to the control
                   EnterTextID("AEtyTruckNo", lstrTruckNo);
                   //Act-dismiss keyboard
                   app.DismissKeyboard();
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot(fstrUserType + "Searchbox");

                   //Act-focus on location control 
                   Tap("APckLocation");
                   //Validating the ios or android 
                   if (AppManager.AppManager.Platform == Platform.Android)
                   {
                       app.Tap(c => c.Marked("text1").Index(0));
                       // The screenshot can be inspected after the test run to verify
                       // the visual correctness of the screen.
                       app.Screenshot("Location");
                   }

                   //Act-focus on type of damage control 
                   Tap("APckTypeDamage1");
                   //Validating the ios or android 
                   if (AppManager.AppManager.Platform == Platform.Android)
                   {
                       app.Tap(c => c.Marked("text1").Index(0));
                       // The screenshot can be inspected after the test run to verify
                       // the visual correctness of the screen.
                       app.Screenshot("TypeOfDamage");
                   }
            */
            /*Reportdate
             //Act-focus on report date control 
            Tap("APckReportDate");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("text1").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("Reportdate");
            }*/

            //Act-focus on list of equiments control 
            /*     Tap("APckListOfEqu");
                 //Validating the ios or android 
                 if (AppManager.AppManager.Platform == Platform.Android)
                 {
                     app.Tap(c => c.Marked("text1").Index(0));
                     // The screenshot can be inspected after the test run to verify
                     // the visual correctness of the screen.
                     app.Screenshot("Equiments");
                 }
                 //Act-focus on submit button click
                 //Tap("AButSubmit");
                 */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// List Page:
        ///This page is listing eligible trucks of logged in user, user can request to release banned truck.
        ///Filter Page:
        ///To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procBannedTrucks(string fstrUserType)
        {
           
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Dashboard");

            //Act-focus on banned trucks button click
            Tap("AlblBannedTrucks");
            //Act-focus on search box control
            Tap("AETYSearchBox");
            app.Screenshot(fstrUserType + "BannedTruck");
            //Act-reading value from the resource file
           /* lstrBannedtrucksContainer = fobjResource.GetString("BannedtrucksContainer_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AETYSearchBox", lstrBannedtrucksContainer);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Searchbox");

            //Act-focus on search button click
            Tap("AIMGButSearch");
            //Act-focus on fliter button click
            Tap("AIMGButFliter");

            //Act-focus on expand collapse Status control
            Tap("AImgDownArrow");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkIschecked1").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("Location");
            }
            //Act-focus on expand collapse Status control
            Tap("AImgDownArrow");

            //Act-focus on expand collapse ban type control
            Tap("AImgDownArs");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkIschecked2").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("Location");
            }
            //Act-focus on expand collapse ban type control
            Tap("AImgDownArs");

            //Act-focus on expand collapse ban reason control
            Tap("AImgDownAr");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("AChkIschecked3").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("Location");
            }
            //Act-focus on expand collapse ban reason control
            Tap("AImgDownAr");

            //Act-focus on truck number control
            Tap("AEnttruckNo");
            //Act-reading value from the resource file
            lstrBannedTruckNo = fobjResource.GetString("BannedTruckNo_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AEnttruckNo", lstrBannedTruckNo);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "TruckNo");

            //Act-focus on date picker control
            // Tap("APCkDate");

            //Act-focus on apply button click
            // Tap("AButApply");
            //Act-focus on refresh button click
            // Tap("AImgButReset");
            //Act-focus on cancel button click
            //Tap("AAgotoClickedCancel");
            //Act-focus on filter button click
            // Tap("AButFliter"); 
           */
        }
   
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// This method Use to Transporter User only.
        /// This page is listing eligible trucks of logged in user, user can request to release banned truck.
        /// Filter Page: 
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// </summary>
        /// <param name="fstrUserType">
        ///  1.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procDetention(string fstrUserType)
        {

            //Arrange-variable initalization
            //string lstrDetentionBayan = "";
            //string lstrDetentionBOL = "";
            //string lstrDetentionContainer = "";
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Dashboard");

            //Act-focus on detention button click
            Tap("AlblDetention");

            //Act-focus on search box control
            Tap("ASearchbox");
            app.Screenshot(fstrUserType + "Detention");
            //Act-reading value from the resource file
            /*   lstrDetentionContainer = fobjResource.GetString("DetentionContainer_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("ASearchbox", lstrDetentionContainer);
               //Act-dismiss keyboard
               app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot(fstrUserType + "Searchbox");

               //Act-focus on search button click
               Tap("AImgSearch");
               //Act-focus on filter button click
               Tap("AImgFilter");



               //Act-focus on expand collapse size control
               Tap("AImgDown");
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("AFilterSizeData").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("Size");
               }
               //Act-focus on expand collapse size control
               Tap("AImgDown");

               //Act-focus on expand collapse carrier control
               Tap("AImgDownArrow");
               //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("AFilterCarrierData").Index(0));
                   // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                   app.Screenshot("Carrier");
               }
               //Act-focus on expand collapse carrier control
               Tap("AImgDownArrow");

               //Act-focus on bayan number control
               Tap("ATxtBayanNo");
               //Act-reading value from the resource file
               lstrDetentionBayan = fobjResource.GetString("DetentionBayan_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("ATxtBayanNo", lstrDetentionBayan);
               //Act-dismiss keyboard
               app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot(fstrUserType + "Searchbox");

               //Act-focus on container number control
               Tap("ATxtContainerNo");
               //Act-reading value from the resource file
               lstrDetentionContainer = fobjResource.GetString("DetentionContainer_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
               EnterTextID("ATxtContainerNo", lstrDetentionContainer);
               //Act-dismiss keyboard
               app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot(fstrUserType + "Searchbox");

               //Act-focus on apply button click
               // Tap("ABtnApply");
               //Act-focus on refresh button click
               // Tap("AImgReset");
               //Act-focus on cancel button click
               // Tap("AgotoClickedCancel");
            */
        }
     
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// 
        /// </summary>
        /// <param name="fstrUserType">
        ///  1.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        /// 
        public void procEmptyUnitReturns(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrEmptyuintContainer = "";
            //string lstrEmptyunitBayan = "";
            //string lstrEmptyunitBOL = "";
            //string lstrEmptyunitLastfreeDays = "";

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Dashboard");
            //Act-focus on empty unit button click
            Tap("AlblEmptyUnit");

            //Act-focus on search box control
            Tap("ATxtSearch");
            app.Screenshot(fstrUserType + "EmptyUnitReturns");
            /*  //Act-reading value from the resource file
              lstrEmptyuintContainer = fobjResource.GetString("EmptyuintContainer_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("ATxtSearch", lstrEmptyuintContainer);
              //Act-dismiss keyboard
              app.DismissKeyboard();
              // The screenshot can be inspected after the test run to verify
              // the visual correctness of the screen.
              app.Screenshot(fstrUserType + "Searchbox");
              //Act-focus on search button click
              Tap("AImgSearch");
              //Act-focus on filter button click
              Tap("AImgFilter");

              //Act-focus on expand collapse size control
              Tap("AImgDownA");
              //Validating the ios or android
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("AChkIschecked1").Index(0));
                  // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                  app.Screenshot("Size");
              }
              //Act-focus on expand collapse size control
              Tap("AImgDownA");

              //Act-focus on expand collapse carrier control
              Tap("AImgDownArrow");
              //Validating the ios or android
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("AChkIschecked2").Index(0));
                  // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                  app.Screenshot("Carrier");
              }
              //Act-focus on expand collapse carrier control
              Tap("AImgDownArrow");

              //Act-focus on expand collapse empty depot control
              Tap("AImgDownArr");
              //Validating the ios or android
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("AChkIschecked3").Index(0));
                  // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                  app.Screenshot("EmptyDepot");
              }
              //Act-focus on expand collapse empty depot control
              Tap("AImgDownArr");

              //Act-focus on container number control 
              Tap("AEntContainer");
              //Act-reading value from the resource file
              lstrEmptyuintContainer = fobjResource.GetString("EmptyuintContainer_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEntContainer", lstrEmptyuintContainer);
              //Act-dismiss keyboard
              app.DismissKeyboard();

              //Act-focus on bayan number control 
              Tap("AEntBayanNo");
              //Act-reading value from the resource file
              lstrEmptyunitBayan = fobjResource.GetString("EmptyunitBayan_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEntBayanNo", lstrEmptyunitBayan);
              //Act-dismiss keyboard
              app.DismissKeyboard();

              //Act-focus on bill of lading number control 
              Tap("AEntBillofLading");
              //Act-reading value from the resource file
              lstrEmptyunitBOL = fobjResource.GetString("EmptyunitBOL_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEntBillofLading", lstrEmptyunitBOL);
              //Act-dismiss keyboard
              app.DismissKeyboard();

              //Act-focus on empty unit last free days control 
              Tap("AEntLastDays");
              //Act-reading value from the resource file
              lstrEmptyunitLastfreeDays = fobjResource.GetString("EmptyunitLastfreeDays_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEntLastDays", lstrEmptyunitLastfreeDays);
              //Act-dismiss keyboard
              app.DismissKeyboard();
              // The screenshot can be inspected after the test run to verify
              // the visual correctness of the screen.
              app.Screenshot("EmptyUnitreturns");


              //Act-focus on apply button click
              // Tap("AButApply");
              //Act-focus on refresh button click
              // Tap("AImgReset");
              //Act-focus on cancel button click
              // Tap("AButtonClickedCancel");
            */
        }
      
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// This method Use to Transporter User only.
        /// List Page:
        /// This page is listing eligible containers ready for empty unit returns of logged in user.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// </summary>
        /// <param name="fstrUserType">
        ///  1.Transporter User
        /// </param>
        /// Obsolete Date:
        ///  Category:Method
        public void procReportdamageContainer(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrReportDamageContainerNo = "";
            //string lstrReportDamageBayanNo = "";
            //string lstrReportDamageinwords = "";

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "Dashboard");
            //Act-focus on report damage container button click  
            Tap("AlblReportContainer");
            //Act-focus on report damage container number control 
            Tap("ATxtContainerNo");
            app.Screenshot(fstrUserType + "ReportdamageContainer");
            //Act-reading value from the resource file
         /*   lstrReportDamageContainerNo = fobjResource.GetString("ReportDamageContainerNo_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("ATxtContainerNo", lstrReportDamageContainerNo);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on report damage container bill of lading number control 
            Tap("ATxtBOLNo");
            //Act-reading value from the resource file
            lstrReportDamageBayanNo = fobjResource.GetString("ReportDamageBayanNo_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("ATxtBOLNo", lstrReportDamageBayanNo);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on type of damage control
            Tap("AlobjTypeOfDamage");//Combo
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Id("text1").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("TypeOfDamage");
            }
            //Act-focus on report date control
            //Tap("ADtReportDate");

            //Act-focus on cause damage control
            Tap("AlobjCauseDamage");//Combo
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Id("text1").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
                app.Screenshot("CauseDamage");
            }
            //Act-focus on retreive detail button click
            // Tap("AbtnRetreiveDetail");//Button
            //Act-scroll down to submit button
            Scrolldown("AlblSubmit");

            //Act-focus on report damage in words control
            Tap("ATxtDescribtion");
            //Act-reading value from the resource file
            lstrReportDamageinwords = fobjResource.GetString("ReportDamageinwords_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("ATxtDescribtion", lstrReportDamageinwords);
            //Act-dismiss keyboard
            app.DismissKeyboard();

            //Act-focus on submit button click
            Tap("AlblSubmit");
         */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLoginMenu
        /// Notification
        /// This method Use to Four different type of users.  
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        public void procEmailNotificationShippments(string fstrUserType)
        {
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            app.Screenshot(fstrUserType + "Menu");
            Thread.Sleep(2000);
            //Act-focus on notifications menu click
            Tap("AlblNotifications");
            //Act-focus on email notification control
            Tap("AImgEmailNotification");
            //Tap("AImangleicon"); >

            //Act-focus on shippments control 
            Tap("AIangleicon");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("EmailNotificationShippments_" + fstrUserType);
            Thread.Sleep(1000);

        }

        /// <summary>    
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Notification
        /// This method Use to Four different type of users.
        /// 1.Consignee User
        /// 2.Broker User
        /// 3ClearingAgent user    
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        /// 
        public void procEmailNotificationGeneral(string fstrUserType)
        {
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            app.Screenshot(fstrUserType + "Menu");
            Thread.Sleep(2000);
            //Act-focus on notifications menu click
            Tap("AlblNotifications");
            //Act-focus on email notification control
            Tap("AImgEmailNotification");
            //Tap("AImangleicon"); >
            //Act-focus on general control
            Tap("AImgangleicon");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("EmailNotificationGeneral_" + fstrUserType);
            Thread.Sleep(1000);

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Notification
        /// This method Use to Four different type of users.
        /// 1.Consignee User
        /// 2.Broker User
        /// 3ClearingAgent user    
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procMobileNotificationShipments(string fstrUserType)
        {
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            app.Screenshot(fstrUserType + "Menu");
            Thread.Sleep(2000);
            //Act-focus on notifications menu click
            Tap("AlblNotifications");
            //Act-focus on mobile notification menu click
            Tap("AImgMobileNotification");
            //  Tap("Aangleiconn"); >

            //Act-focus on shippments control 
            Tap("AIconangleicon");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("MobileNotificationShippments_" + fstrUserType);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Notification
        /// This method Use to Four different type of users.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procMobileNotificationGeneral(string fstrUserType)
        {
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            app.Screenshot(fstrUserType + "Menu");
            Thread.Sleep(2000);
            //Act-focus on notifications menu click
            Tap("AlblNotifications");
            //Act-focus on mobile notification menu click
            Tap("AImgMobileNotification");
            //  Tap("Aangleiconn"); >

            //Act-focus on general control
            Tap("Aangleiconons");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("MobileNotificationGeneral_" + fstrUserType);
            Thread.Sleep(1000);

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// InvoiceandPayments
        /// This method Use to Four different type of users. 
        /// </summary>
        /// <param name="fstrUserType">
        ///  1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procInvoiceandPayments(string fstrUserType)
        {

            //Arrange-variable initalization
            //string lstrInvoiceBOL = "";
            //string lstrInvoiceno = "";
            //string lstrCustomer = "";
            //string lstrPayment = "";
            //string lstrFromAmount = "";
            //string lstrToAmount = "";
            //Validating the ios or android
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on invoice payment control
            Tap("AlblInvoicePayment");
            //Act-focus on search box control
            Tap("AButTxtSearch");
            //Act-dismiss keyboard
            app.DismissKeyboard();
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("InvoicePayment_" + fstrUserType);
            Thread.Sleep(1000);
            //Act-reading value from the resource file
            /*  lstrInvoiceBOL = fobjResource.GetString("InvoiceBOL_" + fstrUserType).ToString().Trim();
                  //Act-assigning value to the control
                 EnterTextID("AButTxtSearch", lstrInvoiceBOL);
                  //Act-dismiss keyboard
                 app.DismissKeyboard();
                  //Act-focus on search button click 
                 Tap("AImgSearch");
                 Thread.Sleep(1000);
                 //Act-focus on filter button click 
                 Tap("AIMGButFilter");
                 //  Tap("AImgbutDotsicon");

                 //Act-focus on expand collapse status control
                 Tap("AImgDownArrowtxt");
                 app.Tap(c => c.Marked("AButIsCheck").Index(0));
                 // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot("Status");
                 //Act-focus on expand collapse status control
                 Tap("AImgDownArrowtxt");

                 //Act-focus on expand collapse mop control
                 Tap("AImgDownArrow2txt");
                 app.Tap(c => c.Marked("AButCheck").Index(0));
                  // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot("MOP");
                 //Act-focus on expand collapse mop control
                 Tap("AImgDownArrow2txt");

                 //Act-focus on expand collapse type control
                 Tap("AImgDownArrow3txt");
                 app.Tap(c => c.Marked("AButIsCheck").Index(0));
                  // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot("Type");
                 //Act-focus on expand collapse type control
                 Tap("AImgDownArrow3txt");

                 //Act-focus on invoice number control
                 Tap("AButTxtInvoiceno");
                 //Act-reading value from the resource file
                 lstrInvoiceno = fobjResource.GetString("Invoiceno_" + fstrUserType).ToString().Trim();
                  //Act-assigning value to the control
                 EnterTextID("AButTxtInvoiceno", lstrInvoiceno);
                  //Act-dismiss keyboard
                 app.DismissKeyboard();

                 //Act-focus on invoice bill of lading number control
                 Tap("AButTxtBolNo");
                 //Act-reading value from the resource file
                 lstrInvoiceBOL = fobjResource.GetString("InvoiceBOL_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                 EnterTextID("AButTxtBolNo", lstrInvoiceBOL);
                  //Act-dismiss keyboard
                 app.DismissKeyboard();

                 //Act-focus on invoice customer control
                 Tap("AButTxtCus2");
                  //Act-reading value from the resource file
                 lstrCustomer = fobjResource.GetString("Customer_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                 EnterTextID("AButTxtCus2", lstrCustomer);
                 //Act-dismiss keyboard
                 app.DismissKeyboard();

                //Act-focus on payment ref control
                 Tap("AButPaymentRef");
                  //Act-reading value from the resource file
                 lstrPayment = fobjResource.GetString("Payment_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                 EnterTextID("AButPaymentRef", lstrPayment);
                 //Act-dismiss keyboard
                 app.DismissKeyboard();
                 // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot(fstrUserType + "Invoice1");

                 //Act-scroll down to date picker control
                 Scrolldown("APckTodate");
                
                 //Act-focus on from amount control
                 Tap("AButFromAmt");
                  //Act-reading value from the resource file
                 lstrFromAmount = fobjResource.GetString("FromAmount_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                 EnterTextID("AButFromAmt", lstrFromAmount);
                 //Act-dismiss keyboard
                 app.DismissKeyboard();

                 //Act-focus on to amount control
                 Tap("AButToAmt");
                 //Act-reading value from the resource file 
                 lstrToAmount = fobjResource.GetString("ToAmount_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                 EnterTextID("AButToAmt", lstrToAmount);
                 //Act-dismiss keyboard
                 app.DismissKeyboard();
              */
            //Act-focus on form date button click
            // Tap("AButFormdate");
            //Act-focus on to date control
            // Tap("APckTodate");

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// InvoiceandPayments
        /// This method Use to four different type of users.
        /// </summary>
        /// <param name="fstrUserType"> 
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        /// 
        public void procInvoiceandPaymentSelectanAction(string fstrUserType)
        {
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on invoice payment control
            Tap("AlblInvoicePayment");
            Thread.Sleep(1000);
            //Act-focus on invoice payment dot icon control
            Tap("AImgbutDotsicon");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("InvoicePayment_" + fstrUserType);
            Thread.Sleep(1000);

            //Act-focus on pay invoice control
              Tap("AbtnPayInvoice");
            app.Screenshot("PayInvoice_" + fstrUserType);
            Thread.Sleep(1000);
            /*    //Act-focus on book an appointment control
             Tap("AbtnBookAnAppointment");

              //Act-focus on generate invoice control
             Tap("AbtnGenerateInvoice");
             //Act-focus on cancel button click
             Tap("AbtnCancel");
           */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Dashboard
        /// This method Use to three different type of users.
        ///This page is listing paid bill of ladings.
        ///To view a specific Bayan/list of Bayan, by providing several filters and sorting options.  
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Consignee User
        /// 2.Broker User
        /// 3.ClearingAgent user   
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procPaymentHistory(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrPaymentHistoryBOL = "";
            //string lstrPaymentHistoryCustomer = "";
            //string lstrPaymentHistoryFromAmount = "";
            //string lstrPaymentHistoryInvoiceNo = "";
            //string lstrPaymentHistoryPaymentRef = "";
            //string lstrPaymentHistoryToAmount = "";

            //Arrange-to creation of object
            ResourceManager pobjResouce = new ResourceManager(typeof(ConsigneeResource));
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            //Act-focus on payment history button click
            Tap("AlblPaymentHistory");
            Thread.Sleep(1000);
            //Act-focus on search box control
            Tap("ATxtSearch");
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("PaymentHistory_" + fstrUserType);
            Thread.Sleep(1000);
            //Act-reading value from the resource file
            /*   lstrPaymentHistoryBOL = pobjResouce.GetString("PaymentHistoryBOL_" + fstrUserType).ToString().Trim();
                //Act-assigning value to the control
               EnterTextID("ATxtSearch", lstrPaymentHistoryBOL);
                //Act-dismiss keyboard
               app.DismissKeyboard();
               //Act-focus on search button click
               Tap("AImgSearch");
               //Act-focus on filter button click
               Tap("AImgFilter");

               //Act-focus on expand collapse status control
               Tap("AImgDownArrow");
               app.Tap(c => c.Marked("AisChecked").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
               app.Screenshot("Status");
               //Act-focus on expand collapse status control
               Tap("AImgDownArrow");

               //Act-focus on expand collapse mop control
               Tap("AImgDownArrow1");
               app.Tap(c => c.Marked("AisChecked2").Index(0));
                // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot("MOP");
              //Act-focus on expand collapse mop control
               Tap("AImgDownArrow1");

              //Act-focus on expand collapse type control
               Tap("AImgDownArrow2");
               app.Tap(c => c.Marked("AisChecked3").Index(0));
                // The screenshot can be inspected after the test run to verify
                // the visual correctness of the screen.
               app.Screenshot("Type");
              //Act-focus on expand collapse type control
               Tap("AImgDownArrow2");
              
                //Act-focus on invoice number control
               Tap("ATxtInvoiceNo");
               //Act-reading value from the resource file
               lstrPaymentHistoryInvoiceNo = pobjResouce.GetString("PaymentHistoryInvoiceNo_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control 
               EnterTextID("ATxtInvoiceNo", lstrPaymentHistoryInvoiceNo);
               //Act-dismiss keyboard
               app.DismissKeyboard();

               //Act-focus on bill of lading number control
               Tap("ATxtBillOfLadingNo");
              //Act-reading value from the resource file
               lstrPaymentHistoryBOL = pobjResouce.GetString("PaymentHistoryBOL_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control 
               EnterTextID("ATxtBillOfLadingNo", lstrPaymentHistoryBOL);
               //Act-dismiss keyboard
               app.DismissKeyboard();

              //Act-focus on customer control
               Tap("ATxtCustomer");
               //Act-reading value from the resource file
               lstrPaymentHistoryCustomer = pobjResouce.GetString("PaymentHistoryCustomer_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control 
               EnterTextID("ATxtCustomer", lstrPaymentHistoryCustomer);
              //Act-dismiss keyboard
               app.DismissKeyboard();

               //Act-focus on payment ref control
               Tap("ATxtPaymentRef");
              //Act-reading value from the resource file
               lstrPaymentHistoryPaymentRef = pobjResouce.GetString("PaymentHistoryPaymentRef_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control 
               EnterTextID("ATxtPaymentRef", lstrPaymentHistoryPaymentRef);
               //Act-dismiss keyboard
               app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
              // the visual correctness of the screen.
               app.Screenshot(fstrUserType + "Paymenyhistory1");

              //Act-scroll down to to date
               Scrolldown("AToDate");

               //Act-focus on from amount control
               Tap("ATxtFromAmount");
               //Act-reading value from the resource file
               lstrPaymentHistoryFromAmount = pobjResouce.GetString("PaymentHistoryFromAmount_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control 
               EnterTextID("ATxtFromAmount", lstrPaymentHistoryFromAmount);
               //Act-dismiss keyboard
               app.DismissKeyboard();

               //Act-focus on to amount control
               Tap("ATxtToAmount");
                //Act-reading value from the resource file
               lstrPaymentHistoryToAmount = pobjResouce.GetString("PaymentHistoryToAmount_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control 
               EnterTextID("ATxtToAmount", lstrPaymentHistoryToAmount);
               //Act-dismiss keyboard
               app.DismissKeyboard();
                // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot("Paymenthistory2");
              
               //Act-focus on from date control
               // Tap("AFromdate");
              //Act-focus on to date control
               // Tap("AToDate");

               //Act-focus on apply button click
               // Tap("ABtnApply");
                //Act-focus on refresh button click
               // Tap("AImgReset");
               //Act-focus on cancel button click
               // Tap("AgotoClickedCancel");



   */


        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Requests Menu
        /// </summary>
        /// <param name="fstrUserType">
        /// This method Use to four different type of users.
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User</param>
        public void procRequestTickets(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrTicketno = "";
            //string lstrTicketSearchBox = "";

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                    Tap("OK");
            }
            //Validating the ios or iOS
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-scroll down to request ticket control
            // Scrolldown("AlblRequestTicket");
            //Act-focus on request ticket control
            Tap("AlblRequestTicket");
            //  Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("Request");
            //  Thread.Sleep(3000);

            //Act-focus on ticket icon button click  
            Tap("AImgTicketIcon");

            //Act-focus on search box control
            Tap("ASearchbox");
            //Act-dismiss keyboard
            app.DismissKeyboard();
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("RequestTickets");
            //Act-reading value from the resource file
            /*   lstrTicketSearchBox = objTResource.GetString("TicketSearchBox_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
              EnterTextID("ASearchbox", lstrTicketSearchBox);
              //Act-dismiss keyboard 
              app.DismissKeyboard();
              //Act-focus on search button  click
              Tap("AImgSearch");

              //Act-focus on filter icon click
              Tap("AImgFilter");

               //Act-focus on expand collapse status control
              Tap("AImgDownArrow1");
                //Validating the ios or android 
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("AisChecked1").Index(0));
                  // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                  app.Screenshot("Status");
              }
              //Act-focus on expand collapse status control
              Tap("AImgDownArrow1");

               //Act-focus on expand category status control 
              Tap("AImgDownArrow2");
              //Validating the ios or android 
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("AisChecked2").Index(0));
                  // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                  app.Screenshot("Category");
              }
             //Act-focus on expand category status control 
              Tap("AImgDownArrow2");

              //Act-focus on expand type control 
              Tap("AImgDownArrow3");
              //Validating the ios or android 
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("AisChecked3").Index(0));
                  // The screenshot can be inspected after the test run to verify
                   // the visual correctness of the screen.
                  app.Screenshot("Type");
              }
              //Act-focus on expand type control 
              Tap("AImgDownArrow3");
              //Act-dismiss keyboard
              app.DismissKeyboard();

              //Act-focus on ticket number control 
              Tap("AEtyTicketno");
              //Act-reading value from the resource file
              lstrTicketno = objTResource.GetString("Ticketno_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AEtyTicketno", lstrTicketno);
              //Act-dismiss keyboard
              app.DismissKeyboard();
              // The screenshot can be inspected after the test run to verify
              // the visual correctness of the screen.
              app.Screenshot("Tickets screen");

               //Act-focus on apply button click
              // Tap("AImgApplyId");
              //Act-focus on refresh button click
              // Tap("AImgReset");

               //Act-focus on cancel button click
              // Tap("AButtonClickedCancel");

              */

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Requests Menu
        /// </summary>
        /// <param name="fstrUserType">
        /// This method Use to four different type of users.
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procRequestForInfo(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrRequestInfoMessage = "";
            //string lstrRequestInfoTitle = "";
            //Validating the ios or android
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                 //Act-focus on ok button click
                     Tap("OK");
            }
            //Validating the ios or iOS
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-scroll down to request ticet control
            //   Scrolldown("AlblRequestTicket");
            //Act-focus on request ticet control
            Tap("AlblRequestTicket");
              Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //   app.Screenshot("Request");
            //   Thread.Sleep(3000);

            //Act-focus on request for info icon control
            Tap("AImgRequestInfo");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("RequestForInfo");
            Thread.Sleep(1000);

            //Act-focus on title control
            Tap("AButTITLE2");
            //Act-dismiss keyboard
            app.DismissKeyboard();
              Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("RequestForInformation");
            Thread.Sleep(1000);
            //Act-reading value from the resource file
            /*  lstrRequestInfoTitle = objTResource.GetString("RequestInfoTitle_" + fstrUserType).ToString().Trim();
               //Act-assigning value to the control
              EnterTextID("AButTITLE2", lstrRequestInfoTitle);
              //Act-dismiss keyboard
              app.DismissKeyboard();

              //Act-focus on case type control
              Tap("AButCaseType");
              //Validating the ios or android 
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Id("text1").Index(0));
                  // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                  app.Screenshot("Casetype");
              }

              //Act-focus on case sub type control
              Tap("AButsybtypes");
               //Validating the ios or android 
              if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Id("text1").Index(1));
                   // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                  app.Screenshot("Casesubtype");
              }

              //Act-scroll submit button control
              Scrolldown("AButfilechoose");

              //Act-focus on message control
              Tap("AmsgMessage");
              //Act-reading value from the resource file
              lstrRequestInfoMessage = objTResource.GetString("RequestInfoMessage_" + fstrUserType).ToString().Trim();
              //Act-assigning value to the control
              EnterTextID("AmsgMessage",lstrRequestInfoMessage);
              //Act-dismiss keyboard
              app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
              app.Screenshot("Request For Information");

               //Act-focus on choose file button click
              // Tap("AButfilechoose");

               //Act-focus on send request button click
              // Tap("AButSubmit");
            */
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Requests Menu
        /// </summary>
        /// <param name="fstrUserType">
        /// This method Use to four different type of users.
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procRequestForService(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrRequestForMessge = "";
            //string lstrRequestForService = "";
            //Validating the ios or android
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Validating the ios or iOS
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-Scroll down to request ticket control
            // Scrolldown("AlblRequestTicket");

            //Act-focus on request ticket control
            Tap("AlblRequestTicket");
            // Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Request");
            // Thread.Sleep(3000);

            //Act-focus on request service icon control
            Tap("AImgRequestService");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("RequestService");
            Thread.Sleep(1000);
            //Act-focus on title button click
            Tap("AEntTitle");
            //Act-dismiss keyboard
            app.DismissKeyboard();
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("RequestServiceForm");
            Thread.Sleep(1000);
            //Act-reading value from the resource file
            /*  lstrRequestForService = objTResource.GetString("RequestForService_" + fstrUserType).ToString().Trim();
                //Act-assigning value to the control
                EnterTextID("AEntTitle", lstrRequestForService);
                //Act-dismiss keyboard
                app.DismissKeyboard();

                //Act-focus on case type control
                Tap("APckCaseType");
                //Validating the ios or android
                if (AppManager.AppManager.Platform == Platform.Android)
                {
                    app.Tap(c => c.Id("text1").Index(0));
                    // The screenshot can be inspected after the test run to verify
                    // the visual correctness of the screen.
                    app.Screenshot("Casetype");
                }

                //Act-focus on case sub type control
                Tap("APckSubType");
                //Validating the ios or android
                if (AppManager.AppManager.Platform == Platform.Android)
                {
                    app.Tap(c => c.Id("text1").Index(1));
                     // The screenshot can be inspected after the test run to verify
                    // the visual correctness of the screen.
                    app.Screenshot("Casesubtype");
                }

                //Act-scroll down to choose file button control
                //Scrolldown("AButChsFile");

                //Act-focus on message control
                Tap("ATxtMessage");
                 //Act-reading value from the resource file
                lstrRequestForMessge = objTResource.GetString("RequestForMessge_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                EnterTextID("ATxtMessage", lstrRequestForMessge);
                 //Act-dismiss keyboard
                app.DismissKeyboard();
                // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                app.Screenshot("Request For service");

                 //Act-focus on choose file button click
                // Tap("AButChsFile");

                //Act-focus on send request button click
                // Tap("AButSubmit");
              */

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RegisterUserLogin Menu
        /// Requests Menu
        /// 
        /// </summary>
        /// <param name="fstrUserType">
        /// This method Use to four different type of users.
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User  
        /// 4.Transporter User
        /// <param>
        /// Obsolete Date:
        /// Category:Method
        public void procRequestFileAComplaint(string fstrUserType)
        {
            //Arrange-variable initalization
            //string lstrRequestFileComplaintTitle = "";
            //string lstrRequestFileComplaintMessage = "";
            //Validating the ios or android
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Validating the ios or iOS
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Act-Scroll down to request ticket control
            // Scrolldown("AlblRequestTicket");
            //Act-focus on request ticet control
            Tap("AlblRequestTicket");
            //  Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("Request");
            //  Thread.Sleep(3000);

            //Act-focus on request for service icon control
            Tap("AImgComplaintIcon");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("FileAComplaint");
            //Act-focus on title button click
            Tap("AtxtTitle1");
                Thread.Sleep(1000);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Complaints");
            //Act-reading value from the resource file
            /*   lstrRequestFileComplaintTitle = objTResource.GetString("RequestFileComplaintTitle_" + fstrUserType).ToString().Trim();
                 //Act-assigning value to the control
                 EnterTextID("AtxtTitle1", lstrRequestFileComplaintTitle); //"File Complaint for 3rd party Service");
                  //Act-dismiss keyboard
                 app.DismissKeyboard();

                //Act-focus on case type control
               Tap("ApicCaseType1");

                //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Id("text1").Index(0));
                    // The screenshot can be inspected after the test run to verify
                    // the visual correctness of the screen.
                   app.Screenshot("Casetype");
               }

               //Act-focus on case sub type control
               Tap("AlobjSubType1");
                //Validating the ios or android 
               if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Id("text1").Index(1));
                   // The screenshot can be inspected after the test run to verify
                    // the visual correctness of the screen.
                   app.Screenshot("Casesubtype");
               }

               //Act-scroll down to choose file button click
               Scrolldown("AbtnChooseFile");

               //Act-focus on message1 control
               Tap("AtxtMessage1");
                //Act-reading value from the resource file
               lstrRequestFileComplaintMessage = objTResource.GetString("RequestFileComplaintMessage_" + fstrUserType).ToString().Trim();
                //Act-assigning value to the control
               EnterTextID("AtxtMessage1", lstrRequestFileComplaintMessage);// "Inilization of Cloud Server");
                //Act-dismiss keyboard
               app.DismissKeyboard();
               // The screenshot can be inspected after the test run to verify
               // the visual correctness of the screen.
               app.Screenshot("Request for complaint");

               //Act-focus on choose file button click
               // Tap("AbtnChooseFile");

               //Act-focus on send request button click
               // Tap("AbtnSubmit");

               */
        }

    } 
}

