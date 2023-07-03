using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using AppManager;
using System.Threading;
using System.Resources;
using RsgtUITest.Resource;
using RsgtUITest.Pages;


namespace RsgtUITest
{

    public class Tests : BasicSetup

    {
       

        // Object Declaration OR Inilization

        Pages.Login objLogin = null;
        Pages.Dashboard objDashboard = null;
        Pages.Mainpage objBasictracking = null;
     

        /// <summary>
        /// Class Contructor 
        /// </summary>
        /// <param name="platform"> Android/iOS</param>
           public Tests(Platform platform) : base(platform)
        {
            //Device Validation for respective pages
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                // object creation for needed pages
                objLogin = new Pages.Login(Platform.Android);
                objDashboard = new Pages.Dashboard(Platform.Android);
                objBasictracking = new Pages.Mainpage(Platform.Android);
            }

            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                objLogin = new Pages.Login(Platform.iOS);
                objDashboard = new Pages.Dashboard(Platform.iOS);
                objBasictracking = new Pages.Mainpage(Platform.iOS);
            }
        }

        /// <summary>     	
        /// Starts an interactive REPL(Read-Eval-Print-Loop) for app exploration.
        /// To check the AutomationId in tree structure
        /// </summary>
       // [Test]
          public void AARepl()
            {
            app.Repl();
            }

        #region Consignee Dashbord Workflow

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Dwelldays
        /// List Page:
        /// This page is listing eligible containers for logged in user with dwell days for each container.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        ///	Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ConsigneeLoginDwelldaysEnglish()
            {
            //App Startup
            procAppStartUpEnglish();
            
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
            
            //calling procDwelldays Method Information in details
            objDashboard.procDwelldays("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Dwelldays
        /// List Page
        /// This page is listing eligible containers for logged in user with dwell days for each container.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        ///	Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ConsigneeLoginDwelldaysArabic()
            {
            //App Startup
            procAppStartUpArabic();
                
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");
                
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
               
            //calling Dwelldays Information in details
            objDashboard.procDwelldays("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EvaluateService
        /// List Page:
        /// This page is to evaluate service for selected bayan & bill of lading.
        /// Click “Start” button to do the survey.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ConsigneeLoginEvaluateServiceEnglish()
            {               
            //App Startup
            procAppStartUpEnglish();
              
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");
               
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
               
            //calling Dwelldays Information in details
            objDashboard.procEvaluateServices("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EvaluateService
        ///  List Page:
        /// This page is to evaluate service for selected bayan & bill of lading.
        /// Click “Start” button to do the survey.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ConsigneeLoginEvaluateServiceArabic()
            {
            //App Startup
            procAppStartUpArabic();
               
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");
              
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
              
            //calling Dwelldays Information in details
            objDashboard.procEvaluateServices("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Terminalvisit
        /// List Page:
        ///	This page is to request for terminal visit.
        ///	Information Page:
        ///	Information page will show with respective information.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ConsigneeLoginTerminalvisitEnglish()
            {
            //App Startup
            procAppStartUpEnglish();
                
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Terminalvisit Information in details
            objDashboard.procTerminalvisit("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Terminalvisit
        /// List Page:
        ///	This page is to request for terminal visit.
        ///	Information Page:
        ///	Information page will show with respective information.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
            public void ConsigneeLoginTerminalvisitArabic()
            {
            //App Startup
            procAppStartUpArabic();
                
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Terminalvisit Information in details
            objDashboard.procTerminalvisit("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - PaymentHistory
        /// List Page:
        ///	This page is listing paid bill of ladings.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.            
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ConsigneeLoginPaymentHistoryArabic()
            {
            //App Startup
            procAppStartUpArabic();
                
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling PaymentHistory Information details
            objDashboard.procPaymentHistory("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - PaymentHistory
        /// List Page:
        ///	This page is listing paid bill of ladings.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.  
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ConsigneeLoginPaymentHistoryEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling PaymentHistory Information details
            objDashboard.procPaymentHistory("Consignee");
            }

        #endregion

        #region Register user Login menu
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Menu List Workflow for every menus
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Menu
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
            public void RegisterUserLoginMenuEnglish()
            {
            //App Startup
            procAppStartUpEnglish();
               
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");
               
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
                
            //calling Dwelldays Information in details
            objLogin.RegisterUserLoginMenu("Consignee");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Menu List Workflow for every menus
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Menu
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        
        [Test]
            public void RegisterUserLoginMenuArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Dwelldays Information in details
            objLogin.RegisterUserLoginMenu("Consignee");
            }

        #endregion


        #region Broker Dashboard Workflow


        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Dwelldays
        /// List Page
        /// This page is listing eligible containers for logged in user with dwell days for each container.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
            public void BrokerLoginDwelldaysEnglish()
            {
            //App Startup
            procAppStartUpEnglish();
           
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            // //calling procDwelldays Method Information in details
            objDashboard.procDwelldays("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Dwelldays
        /// List Page
        /// This page is listing eligible containers for logged in user with dwell days for each container.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginDwelldaysArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procDwelldays Method Information in details
            objDashboard.procDwelldays("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReadyforDeliver
        /// List Page:
        /// This page is listing eligible containers ready for delivery for logged in.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
            public void BrokerLoginReadyforDeliverEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
          
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procDwelldays Method Information in details
            objDashboard.procReadyforDeliver("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReadyforDeliver
        /// List Page:
        /// This page is listing eligible containers ready for delivery for logged in.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginReadyforDeliverArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procReadyforDeliver Method Information in details
            objDashboard.procReadyforDeliver("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Appoinments
        /// List Page:
        /// This page is listing eligible containers ready for book an appointment for logged in user with dwell days for each container.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginAppoinmentsEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //calling procAppoinments Method Information in details
            objDashboard.procAppoinments("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Appoinments 				
        /// List Page:
        /// This page is listing eligible containers ready for book an appointment for logged in user with dwell days for each container.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginAppoinmentsArabic()
            {
            //App Startup
            procAppStartUpArabic();
            
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
          
            //Waiting for 2000 milliseconds
            Thread.Sleep(1000);
          
            //calling procAppoinments Method Information in details
            objDashboard.procAppoinments("Broker");

            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EvaluateServices
        /// List Page:
        /// This page is to evaluate service for selected bayan & bill of lading.
        /// Click “Start” button to do the survey.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginEvaluateServiceEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procEvaluateServices Method Information in details
            objDashboard.procEvaluateServices("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EvaluateServices
        /// List Page:
        /// This page is to evaluate service for selected bayan & bill of lading.
        /// Click “Start” button to do the survey.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginEvaluateServiceArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procEvaluateServices Method Information in details
            objDashboard.procEvaluateServices("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Invoice
        ///  List Page:
        ///	This page is to list all the invoices for logged in user.
        ///	The user can cancel and re-generate yet to paid invoices.
        ///	The user can pay for invoices.
        ///	The user can book an appointment.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginInvoiceEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procInvoice Method Information in details
            objDashboard.procInvoice("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Invoice
        /// List Page:
        ///	This page is to list all the invoices for logged in user.
        ///	The user can cancel and re-generate yet to paid invoices.
        ///	The user can pay for invoices.
        ///	The user can book an appointment.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginInvoiceArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procInvoice Method Information in details
            objDashboard.procInvoice("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - CashManagement
        /// List Page:
        /// This page is listing eligible all tickets of logged in user.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginCashManagementEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procCashManagement Method Information in details
            objDashboard.procCashManagement("Broker");
             }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - CashManagement
        /// List Page:
        /// This page is listing eligible all tickets of logged in user.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginCashManagementArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procCashManagement Method Information in details
            objDashboard.procCashManagement("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - BooKForManualInspection
        /// List Page:
        /// This page is listing eligible containers of logged in user to book for manual inspection.
        /// Select containers and click “Disclaimer” button, the selected containers are saved for manual inspection.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginBooKForManualInspectionArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procBookForManualInspection Method Information in details
            objDashboard.procBookForManualInspection("Broker");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - BooKForManualInspection
        /// List Page:
        /// This page is listing eligible containers of logged in user to book for manual inspection.
        /// Select containers and click “Disclaimer” button, the selected containers are saved for manual inspection.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void BrokerLoginBooKForManualInspectionEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procBookForManualInspection Method Information in details
            objDashboard.procBookForManualInspection("Broker");
            }
        #endregion


        #region ClearingAgent Workflow
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Dwelldays
        /// List Page
        /// This page is listing eligible containers for logged in user with dwell days for each container.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginDwelldaysEnglish()
            {

            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Method For procDwelldays Work flow
            objDashboard.procDwelldays("Agent");
            }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Dwelldays
        /// List Page
        /// This page is listing eligible containers for logged in user with dwell days for each container.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginDwelldaysArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Method For procDwelldays Work flow
            objDashboard.procDwelldays("Agent");
            }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReadyforDeliver
        /// List Page:
        /// This page is listing eligible containers ready for delivery for logged in.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
        public void ClearingAgentLoginReadyforDeliverEnglish()  
        {

            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procReadyforDeliver Method Information in details
            objDashboard.procReadyforDeliver("Agent");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReadyforDeliver
        /// List Page:
        /// This page is listing eligible containers ready for delivery for logged in.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void ClearingAgentLoginReadyforDeliverArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");
          
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procReadyforDeliver Method Information in details
            objDashboard.procReadyforDeliver("Agent");
        }


        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Appoinments       				
        /// List Page:
        /// This page is listing eligible containers ready for book an appointment for logged in user with dwell days for each container.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginAppoinmentsEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");
          
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //calling Method For procAppoinments Work flow
            objDashboard.procAppoinments("Agent");

            }
      
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Appoinments       				
        /// List Page:
        /// This page is listing eligible containers ready for book an appointment for logged in user with dwell days for each container.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginAppoinmentsArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");
            Thread.Sleep(1000);

            //calling Method For procAppoinments Work flow
            objDashboard.procAppoinments("Agent");

            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - CashManagement
        /// List Page:
        /// This page is listing eligible all tickets of logged in user.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void ClearingAgentLoginCashManagementEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //calling procCashManagement Method Information in details
            objDashboard.procCashManagement("Agent");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - CashManagement
        /// List Page:
        /// This page is listing eligible all tickets of logged in user.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void ClearingAgentLoginCashManagementArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procCashManagement Method Information in details
            objDashboard.procCashManagement("Agent");
        }


        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Invoice
        /// List Page:
        /// This page is to list all the invoices for logged in user.
        /// The user can cancel and re-generate yet to paid invoices.
        /// The user can pay for invoices.
        /// The user can book an appointment.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void ClearingAgentLoginInvoiceEnglish()
        {
            //App Startup
            procAppStartUpEnglish();
           
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procInvoice Method Information in details
            objDashboard.procInvoice("Agent");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Invoice
        /// List Page:
        /// This page is to list all the invoices for logged in user.
        /// The user can cancel and re-generate yet to paid invoices.
        /// The user can pay for invoices.
        /// The user can book an appointment.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void ClearingAgentLoginInvoiceArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling procInvoice Method Information in details
            objDashboard.procInvoice("Agent");
        }


        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EvaluateServices
        /// List Page:
        /// This page is to evaluate service for selected bayan & bill of lading.
        /// Click “Start” button to do the survey.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginEvaluateServiceEnglish()
            {

            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");
            Thread.Sleep(2000);

            //calling Method For procEvaluateServices Work flow
            objDashboard.procEvaluateServices("Agent");
            }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EvaluateServices
        /// List Page:
        /// This page is to evaluate service for selected bayan & bill of lading.
        /// Click “Start” button to do the survey.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginEvaluateServiceArabic()
            {

            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Method For procEvaluateServices Work flow
            objDashboard.procEvaluateServices("Agent");
            }


        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - BooKForManualInspection
        /// List Page:
        /// This page is listing eligible containers of logged in user to book for manual inspection.
        /// Select containers and click “Disclaimer” button, the selected containers are saved for manual inspection.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginBooKForManualInspectionArabic()
            {
            //App Startup
            procAppStartUpArabic();
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Method For procBookForManualInspection Work flow
            objDashboard.procBookForManualInspection("Agent");
            }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - BooKForManualInspection
        /// List Page:
        /// This page is listing eligible containers of logged in user to book for manual inspection.
        /// Select containers and click “Disclaimer” button, the selected containers are saved for manual inspection.
        /// Survey Page:
        /// User has to fill the survey page with ratings and comments.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void ClearingAgentLoginBooKForManualInspectionEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Agent");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //calling Method For procBookForManualInspection Work flow
            objDashboard.procBookForManualInspection("Agent");
            }
        #endregion


        #region Transporter Dashboard Workflow
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReadyforDeliver
        /// List Page:
        /// This page is listing eligible containers ready for delivery for logged in.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginReadyToDeliverEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");


            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procEmptyUnitReturns Work flow
            objDashboard.procReadyforDeliver("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReadyforDeliver
        /// List Page:
        /// This page is listing eligible containers ready for delivery for logged in.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginReadyToDeliverArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");


            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procReadyforDeliver Work flow
            objDashboard.procReadyforDeliver("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Invoice
        /// List Page:
        ///	This page is to list all the invoices for logged in user.
        ///	The user can cancel and re-generate yet to paid invoices.
        ///	The user can pay for invoices.
        ///	The user can book an appointment.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginInvoiceEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");


            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procInvoice Work flow
            objDashboard.procInvoice("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Invoice
        /// List Page:
        ///	This page is to list all the invoices for logged in user.
        ///	The user can cancel and re-generate yet to paid invoices.
        ///	The user can pay for invoices.
        ///	The user can book an appointment.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginInvoiceArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procInvoice Work flow
            objDashboard.procInvoice("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - TruckServiceRequest
        /// List Page:
        /// This page is to request truck service, user has to fill required data and submit.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginTruckServiceRequestArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procTruckServiceRequest Work flow
            objDashboard.procTruckServiceRequest("Transporter");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - TruckServiceRequest
        /// List Page:
        /// This page is to request truck service, user has to fill required data and submit.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginTruckServiceRequestEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procTruckServiceRequest Work flow
            objDashboard.procTruckServiceRequest("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - BannedTrucks
        /// List Page:
        /// This page is listing eligible trucks of logged in user, user can request to release banned truck.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginBannedTruckEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procBannedTrucks Work flow
            objDashboard.procBannedTrucks("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - BannedTrucks
        /// List Page:
        /// This page is listing eligible trucks of logged in user, user can request to release banned truck.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginBannedTruckArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procBannedTrucks Work flow
            objDashboard.procBannedTrucks("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Detention
        /// Detention refers to the charge that the merchant pays for the use of the container outside of the terminal or depot.
        /// beyond the free time period.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginDetentionManagementArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procDetention Work flow
            objDashboard.procDetention("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - Detention
        /// Detention refers to the charge that the merchant pays for the use of the container outside of the terminal or depot.
        /// beyond the free time period.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginDetentionManagementEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procDetention Work flow
            objDashboard.procDetention("Transporter");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EmptyUnitReturns
        /// List Page:
        ///	This page is listing eligible containers ready for empty unit returns of logged in user.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginEmptyUnitReturnsEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procEmptyUnitReturns Work flow
            objDashboard.procEmptyUnitReturns("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - EmptyUnitReturns
        /// List Page:
        ///	This page is listing eligible containers ready for empty unit returns of logged in user.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
            public void TransporterLoginEmptyUnitReturnsArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procEmptyUnitReturns Work flow
            objDashboard.procEmptyUnitReturns("Transporter");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReportdamageContainer
        /// List Page:
        ///	This page is to report damage container, user has to fill the required details with or without attachment.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginReportdamageContainerArabic()
            {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procReportdamageContainer Work flow
            objDashboard.procReportdamageContainer("Transporter");
            }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// 1.Spalash Page
        /// 2.Startup Page
        /// 3.Main Page
        /// 4.Login Page
        /// 5.OTP Page
        /// 6.MainPage
        /// 7.Dashboard - ReportdamageContainer
        /// List Page:
        ///	This page is to report damage container, user has to fill the required details with or without attachment.
        /// Filter Page:
        ///	To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
            public void TransporterLoginReportdamageContainerEnglish()
            {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Transporter");
           
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //calling Method For procReportdamageContainer Work flow
            objDashboard.procReportdamageContainer("Transporter");
        }
        #endregion


        #region Newuser Registeration
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// New user English
        /// The user needs to register to use & enjoy the all the features of mobile app.
        ///	Option to add multiple importers ID for one user.Objects have to be designed.
        /// The mandatory field in additional information depends on the customer type.
        ///	The user must agree to RSGT terms & conditions and click continue.
        ///	As soon as user clicks NEXT, he comes to the next page where he can review the information he entered.  
        ///	Obsolete Date:
        /// Category:Method
        /// </summary>
        // [Test]
        public void RegisterUserEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //calling Method For procNewRegisterations Work flow
            objLogin.procNewRegisterations();
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// New user Arabic
        /// The user needs to register to use & enjoy the all the features of mobile app.
        ///	Option to add multiple importers ID for one user.Objects have to be designed.
        /// The mandatory field in additional information depends on the customer type.
        ///	The user must agree to RSGT terms & conditions and click continue.
        ///	As soon as user clicks NEXT, he comes to the next page where he can review the information he entered.   
        ///	Obsolete Date:
        /// Category:Method
        /// </summary>
        // [Test]
        public void RegisterUserArabic()
        {
            //App Startup
            procAppStartUpArabic();
           
            //calling Method For procNewRegisterations Work flow
            objLogin.procNewRegisterations();
        }
        #endregion

        #region Myprofile
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// App will show the registered details as default, if user wants to change anything, they can change and save.
        /// If anything changed in “Additional Information” section, the user activation has been de-activated.
        /// Then activation process to be done again by RSGT team. 
        /// After activation only respective user will use logged in features of this App.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        //[Test]
        public void RegisterUserMyprofileMenuEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procMyProfile validation with Work flow
            objLogin.procMyProfile("Consignee");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// App will show the registered details as default, if user wants to change anything, they can change and save.
        /// If anything changed in “Additional Information” section, the user activation has been de-activated.
        /// Then activation process to be done again by RSGT team. 
        /// After activation only respective user will use logged in features of this App.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        //[Test]
        public void RegisterUserMyprofileMenuArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Consignee");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procMyProfile validation with Work flow
            objLogin.procMyProfile("Consignee");
        }
        #endregion




        #region Invoice payments
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// List Page:
        /// The user can see list of paid and unpaid invoices from this screen.
        /// If user wish to do a payment he can select and invoice and proceed for payment.
        /// Also, customer has option to book an appointment from this page.
        /// User can see PDF of proforma invoice and final invoice by click on the invoice number.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void IvoiceandpaymentMenuEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procInvoiceandPayments validation with Work flow
            objDashboard.procInvoiceandPayments("Broker");
           
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// List Page:
        /// The user can see list of paid and unpaid invoices from this screen.
        /// If user wish to do a payment he can select and invoice and proceed for payment.
        /// Also, customer has option to book an appointment from this page.
        /// User can see PDF of proforma invoice and final invoice by click on the invoice number.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void IvoiceandpaymentMenuArabic()
        {
            //App Startup
            procAppStartUpArabic();
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
            //Calling  Method for procInvoiceandPayments validation with Work flow
            objDashboard.procInvoiceandPayments("Broker");

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// List Page:
        /// The user can see list of paid and unpaid invoices from this screen.
        /// If user wish to do a payment he can select and invoice and proceed for payment.
        /// Also, customer has option to book an appointment from this page.
        /// User can see PDF of proforma invoice and final invoice by click on the invoice number.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void IvoiceandpaymentSelectanActionEnglish()
        {
            //App Startup
            procAppStartUpEnglish();
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
            //Calling  Method for procInvoiceandPaymentSelectanAction validation with Work flow
            objDashboard.procInvoiceandPaymentSelectanAction("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// List Page:
        /// The user can see list of paid and unpaid invoices from this screen.
        /// If user wish to do a payment he can select and invoice and proceed for payment.
        /// Also, customer has option to book an appointment from this page.
        /// User can see PDF of proforma invoice and final invoice by click on the invoice number.
        /// Filter Page:
        /// To view a specific Bayan/list of Bayan, by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
        public void IvoiceandpaymentSelectanActionArabic()
        {
            //App Startup
            procAppStartUpArabic();
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
            //Calling  Method for procInvoiceandPaymentSelectanAction validation with Work flow
            objDashboard.procInvoiceandPaymentSelectanAction("Broker");
        }
        #endregion

        #region Login user TrackShipment
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Tracking shipment feature will be useful to find status of given container number. If the given container number is valid, then app will show the details about the container. 
        /// If the given container number is not valid or not available in database, then we will show “No record found” information.
        /// The captions will be modifiable through CMS.
        /// Notification:
        /// Will be settings for container status notification to given mobile #, when respective container’s status being changed up to gated out
        /// Notification to Mobile
        /// Obsolete Date:
        /// Category:Method
        ///</summary>
        [Test]
        public void RegisterUserTrackShipmentEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procTrackShipment validation with Work flow
            objLogin.procTrackShipment("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Tracking shipment feature will be useful to find status of given container number. If the given container number is valid, then app will show the details about the container. 
        /// If the given container number is not valid or not available in database, then we will show “No record found” information.
        /// The captions will be modifiable through CMS.
        /// Notification:
        /// Will be settings for container status notification to given mobile #, when respective container’s status being changed up to gated out
        /// Notification to Mobile
        /// Obsolete Date:
        /// Category:Method
        ///</summary>

        [Test]
        public void RegisterUserTrackShipmentArabic()
        {
            //App Startup
            procAppStartUpArabic();
            
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procTrackShipment validation with Work flow
            objLogin.procTrackShipment("Broker");
        }


        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Track
        /// Advance Tracking
        /// It is for navigating Bayan, Bill of lading and Container pages and seeing respective records for logged in user.
        /// Generate Invoice, pay invoice and appointment will be done for respective eligible bill of lading #.
        /// Can see the container detail PDF and can mail the same PDF through mail.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
        public void RegisterUserAdvanceTrackingArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procAdvancedTracking validation with Work flow
            objLogin.procAdvancedTracking("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Track
        /// Advance Tracking
        /// It is for navigating Bayan, Bill of lading and Container pages and seeing respective records for logged in user.
        /// Generate Invoice, pay invoice and appointment will be done for respective eligible bill of lading #.
        /// Can see the container detail PDF and can mail the same PDF through mail.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
        public void RegisterUserAdvanceTrackingEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procAdvancedTracking validation with Work flow
            objLogin.procAdvancedTracking("Broker");
        }

        #endregion

        #region Loginuser Requests



        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// RequestTickets
        /// List Page:
        ///	This page is to Tickets, user has to fill the required details with or without attachment.
        /// Filter Page:
        ///	To view a specific Status/category/Type,and Ticket no by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserRequestTicketsEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestTickets validation with Work flow
            objDashboard.procRequestTickets("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022
        /// RequestTickets
        /// List Page:
        ///	This page is to Tickets, user has to fill the required details with or without attachment.
        /// Filter Page:
        ///	To view a specific Status/category/Type,and Ticket no by providing several filters and sorting options.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserRequestTicketsArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestTickets validation with Work flow
            objDashboard.procRequestTickets("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Request for Informtion
		/// List Page:
        ///	This page is to Request for Informtion, user has to fill the required details with or without attachment.
        /// Obsolete Date:
        /// Category:Method 
        /// </summary>
        [Test]
        public void RegisterUserRequestForInfoEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestForInfo validation with Work flow
            objDashboard.procRequestForInfo("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022
        /// Request for Informtion
		/// List Page:
        ///	This page is to Request for Informtion, user has to fill the required details with or without attachment.
        /// Obsolete Date:
        /// Category:Method 
        /// </summary>
        [Test]
        public void RegisterUserRequestForInfoArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestForInfo validation with Work flow
            objDashboard.procRequestForInfo("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Request for service
        /// List Page:
        ///	This page is to Request for service form, user has to fill the required details with or without attachment.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserRequestForServiceEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestForService validation with Work flow
            objDashboard.procRequestForService("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Request for service
        /// List Page:
        ///	This page is to Request for service form, user has to fill the required details with or without attachment.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserRequestForServiceArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestForService validation with Work flow
            objDashboard.procRequestForService("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022
        /// File a complaint
        /// List Page:
        ///	This page is to Complaints, user has to fill the required details with or without attachment.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserRequestFileAComplaintEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestFileAComplaint validation with Work flow
            objDashboard.procRequestFileAComplaint("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// File a complaint
        /// List Page:
        ///	This page is to Complaints, user has to fill the required details with or without attachment.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserRequestFileAComplaintArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //Calling  Method for procRequestFileAComplaint validation with Work flow
            objDashboard.procRequestFileAComplaint("Broker");
        }
        #endregion



        #region Loginuser Notifications

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// EmailNotificationShippments
        /// Email Notifications shipments related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void EmailNotificationShippmentsEnglish()
        {
            //App Startup
            procAppStartUpEnglish();
           
            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procEmailNotificationShippments  Work flow
            objDashboard.procEmailNotificationShippments("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// EmailNotificationShippments
        /// Email Notifications shipments related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void EmailNotificationShippmentsArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procEmailNotificationShippments  Work flow
            objDashboard.procEmailNotificationShippments("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// EmailNotificationGeneral
        /// Email Notifications General related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void EmailNotificationGeneralEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procEmailNotificationGeneral  Work flow
            objDashboard.procEmailNotificationGeneral("Broker");
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// EmailNotificationGeneral
        /// Email Notifications General related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void EmailNotificationGeneralArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procEmailNotificationGeneral  Work flow
            objDashboard.procEmailNotificationGeneral("Broker");
        }
    

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// MobileNotificationShippments
        /// Mobile Notifications shipments related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void MobileNotificationShippmentsEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procMobileNotificationShipments  Work flow
            objDashboard.procMobileNotificationShipments("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// MobileNotificationShippments
        /// Mobile Notifications shipments related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void MobileNotificationShippmentsArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procMobileNotificationShipments  Work flow
            objDashboard.procMobileNotificationShipments("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// MobileNotificationGeneral
        /// Mobile Notifications General related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void MobileNotificationGeneralEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procMobileNotificationGeneral  Work flow
            objDashboard.procMobileNotificationGeneral("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// MobileNotificationGeneral
        /// Mobile Notifications General related message  details  view to the Respective user
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void MobileNotificationGeneralArabic()
        {
            //App Startup
            procAppStartUpArabic();

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling Method for procMobileNotificationGeneral  Work flow
            objDashboard.procMobileNotificationGeneral("Broker");
        }
     
        #endregion


        #region Register user Settings
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Settings
        /// Based on the above settings App will perform as default.
        /// The captions will be modifiable through CMS.
        /// Default currency will be set here.
        /// Default temperature will be set here.
        /// Default weight will be set here.
        /// Default landing page Main/ Dashboard will be set here.
        /// Set “Biometric login” on or off here.
        /// Set “Push Notification” on or off here.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserAccountSettingsEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            //Waiting for 2000 milliseconds
            Thread.Sleep(1000);

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling  user procAccountsettings validation with Work flow
            objDashboard.procAccountsettings("Broker");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Settings
        /// Based on the above settings App will perform as default.
        /// The captions will be modifiable through CMS.
        /// Default currency will be set here.
        /// Default temperature will be set here.
        /// Default weight will be set here.
        /// Default landing page Main/ Dashboard will be set here.
        /// Set “Biometric login” on or off here.
        /// Set “Push Notification” on or off here.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void RegisterUserAccountSettingsArabic()
        {
            //App Startup
            procAppStartUpArabic();
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(1000);

            //Calling resgister user Login validation with Work flow
            objLogin.ProcRegisterUserLogin("Broker");

            //Calling  user procAccountsettings validation with Work flow
            objDashboard.procAccountsettings("Broker");
        }

        #endregion


        #region AnonyumsUser work Flow

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Tracking shipment feature will be useful to find status of given container number. If the given container number is valid, then app will show the details about the container. 
        /// If the given container number is not valid or not available in database, then we will show “No record found” information.
        /// The captions will be modifiable through CMS.
        /// Notification:
        /// Will be settings for container status notification to given mobile #, when respective container’s status being changed up to gated out
        /// Notification to Mobile
        /// Obsolete Date:
        /// Category:Method
        ///</summary>

        [Test]
        public void AnonyumsUser_BasicTrackingEnglish()
        {
            //App Startup
            procAppStartUpEnglish();

            // Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //The method is calling to procBasicTracking deatils.
            objBasictracking.procBasicTracking();
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Register user Workflow
        /// Spalash Page
        /// Startup Page
        /// Main Page
        /// Tracking shipment feature will be useful to find status of given container number. If the given container number is valid, then app will show the details about the container. 
        /// If the given container number is not valid or not available in database, then we will show “No record found” information.
        /// The captions will be modifiable through CMS.
        /// Notification:
        /// Will be settings for container status notification to given mobile #, when respective container’s status being changed up to gated out
        /// Notification to Mobile
        /// Obsolete Date:
        /// Category:Method
        ///</summary>
        [Test]
        public void AnonyumsUser_BasicTrackingArabic()
        {
           
             //App Startup
             procAppStartUpArabic();

            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                app.Tap(c => c.Marked("AlblGetStart"));
                app.Screenshot("GetStarted_Click");
                Thread.Sleep(2000);
            }
            //The method is calling to procBasicTracking deatils.
            objBasictracking.procBasicTracking();
         
        }



        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// AnonyumsUser_Menus Check
        /// 1.Key Features
        /// 2.FAQs
        /// 3.About RSGT
        /// 4.Contact Us
        /// 5.Theme
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
        public void AnonyumsUser_MenusEnglish()

        {          
            //App Startup
            procAppStartUpEnglish();

            //The method is calling to AnonyumsUserDetails
            objLogin.AnonyumsUser();   
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// AnAnonyumsUser_Menus Check
        /// 1.Key Features
        /// 2.FAQs
        /// 3.About RSGT
        /// 4.Contact Us
        /// 5.Theme
        /// Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
        public void AnonyumsUser_MenusArabic()
        {           
            //App Startup
            procAppStartUpArabic();

            //The method is calling to AnonyumsUserDetails
            objLogin.AnonyumsUser();
          

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Contact Us details
        /// We can send  information about the Rsgt company with given Email
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void GeneralContactusEnglish()
        {           
            //App Startup
            procAppStartUpEnglish();

            // Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //Capture the contact information
            objLogin.procContactUS();

            // Waiting for 1000 milliseconds
            Thread.Sleep(1000);
           
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Contact Us details
        /// We can send  information about the Rsgt company with given Email
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void GeneralContactusArabic()
        {
            //App Startup
            procAppStartUpArabic();
            // Waiting for 1000 milliseconds
            Thread.Sleep(2000);

            //Capture the contact information
            objLogin.procContactUS();

            // Waiting for 1000 milliseconds
            Thread.Sleep(1000);     
        }

        /// <summary>
        ///  Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Vesssel Schedule
        /// 1.Inport Vesssel details
        /// 2.Arrival Vesssel details
        /// 3.Departure Vesssel details
        ///  This will display an overview of last 72hr Vessels scheduled for: 
        /// a.In-Port(Vessel Name, Shipping Line) - Show All vessels
        /// b.Arrival(Estimated time of arrival, Vessel Name & Shipping Line, Voyage Number) – Have a facility of showing up to 30 days arrival vessel schedule. (Note: Only MSK line is sharing 30 days schedule)
        /// c.Departure(Actual time of departure, Vessel Name & shipping Line, Voyage Number). The cutoff time will be around 6 hours - Show 3 Days
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        [Test]
        public void Vesselschedule_English()
        {

            //App Startup            
            procAppStartUpEnglish();

            // Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //This method calling to procVesselschedule details
            objBasictracking.procVesselschedule();
          
            // Waiting for 1000 milliseconds
            Thread.Sleep(1000);
           
         }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Vesssel Schedule
        /// 1.Inport Vesssel details
        /// 2.Arrival Vesssel details
        /// 3.Departure Vesssel details
        /// This will display an overview of last 72hr Vessels scheduled for: 
        /// a.In-Port(Vessel Name, Shipping Line) - Show All vessels
        /// b.Arrival(Estimated time of arrival, Vessel Name & Shipping Line, Voyage Number) – Have a facility of showing up to 30 days arrival vessel schedule. (Note: Only MSK line is sharing 30 days schedule)
        /// c.Departure(Actual time of departure, Vessel Name & shipping Line, Voyage Number). The cutoff time will be around 6 hours - Show 3 Days
        ///  Obsolete Date:
        /// Category:Method
        /// </summary>

        [Test]
        public void Vesselschedule_Arabic()
            {          
            //App Startup
            procAppStartUpArabic();

            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);

            //This method calling to procVesselschedule details
            objBasictracking.procVesselschedule();

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);          
            }

        #endregion

        #region App startup
        /// <summary>
        /// Spalash page and Getstartpage Inilization
        /// </summary>

        private void procAppStartUpEnglish()
        {
            // Calling the English Button
            procEnglish();
            Thread.Sleep(6000);
            //Calling the GetStarted Button
             procGetstart();
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
        }
        private void procAppStartUpArabic()
        {
            // Calling the English Button
            procArabic();
            Thread.Sleep(6000);
            //Calling the GetStarted Button
             procGetstart();
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
        }
        #endregion


      
      

       
    }
}


