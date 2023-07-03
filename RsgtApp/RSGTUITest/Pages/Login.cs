using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RsgtUITest;
using Xamarin.UITest;
using NUnit.Framework;
using System.Resources;
using RsgtUITest.Resource;
using System.Threading;

namespace RsgtUITest.Pages
{
    public class Login : BasicSetup
    {
        //Arrange-to creation of object
        ResourceManager objResource = new ResourceManager(typeof(LoginResource));       
        public Login(Platform platform) : base(platform)
        {
        }
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 12-Nov-2022 
        /// Register user login work flow
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        /// <param name="fstrUserType">
        /// User Type(Consignee/Broker/Agent/Transporter)
        /// </param>
        public void ProcRegisterUserLogin(string fstrUserType)         
        {
            //Act-focus on login button click
            Tap("AlblLogin");
            //Act-focus on user namecontrol
            Tap("ATxtUserName");

            //Act-reading value from the resource file
            string lstrUsername = objResource.GetString("Username_" + fstrUserType).ToString().Trim();
           
            //Act-assigning value to the control
            EnterTextID("ATxtUserName", lstrUsername);
           
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "_Userid");
           
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //Act-focus on password control
            Tap("ATxtPassword");
           
            //Act-reading value from the resource file
            string lstrPassword = objResource.GetString("Password_" + fstrUserType).ToString().Trim();
           
            //Act-assigning value to the control
            EnterTextID("ATxtPassword", lstrPassword);
            
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "_Password");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //Act-focus on login button click           
            Tap("AbtnLogIn");
           
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "_Login_Click");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //Act-focus on otp assigning value to the control
            Tap("AtxtOtp");
           
            //Act-reading value from the resource file
            string lstrOTP = objResource.GetString("OTP_" + fstrUserType).ToString().Trim();
           
            //Act-assigning value to the control           
            EnterTextID("AtxtOtp", lstrOTP);
           
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot(fstrUserType + "_OTP");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //Act-focus on confirm button click
            Tap("AbtnConfirm");
           
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.            
            app.Screenshot(fstrUserType + "Confirm");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            //Assert-verified the userrname and password
            //Assert.IsTrue(true,"pass");

            //Act-focus on ok button click
            // Tap("OK");

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot(fstrUserType + "SlideMenu");
            //Landing to Login User Details
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 12-Nov-2022 
        /// Register user dashboard detail
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        /// <param name="fstrUserType">
        /// User Type(Consignee/Broker/Agent/Transporter)
        /// </param>
        public void RegisterUserLoginMenu(string fstrUserType)
        {
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }
            //Act-focus on dashboard menu  click
            Tap("AlblDashboard");
            
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);
            
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Dahboard_Menu");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }


            //Act-focus on track button click
            Tap("AlblTrack");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Track_Menu");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on myprofile menu  click
            Tap("AlblMyProfile1");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("MyProfile_Menu");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on accountsettings menu  click
            Tap("AlblAccountSettings");

            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Settings_Menu");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
          
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on notifications menu  click
            Tap("AlblNotifications");
           
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Notification_Menu");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on key features menu  click
            Tap("AlblKeyFeatures");
            
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);
           
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("KeyFeature_Menu");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on faq menu  click
            Tap("AlblFaq");
           
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);
            
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("FAQ_Menu");
           
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on request ticket menu  click
            Tap("AlblRequestTicket");
            
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Request_Menu");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on about rsgt menu  click
            Tap("AlblAboutRSGT");
            
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000); ;
           
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("AboutRSGT_Menu");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
            
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }
            //Act-scroll down to last name
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Scrolldown("AlblLogOut");
            }
            //Act-focus on contact us menu  click
            Tap("Alblcontactus");
           
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);
           
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Contactus_Menu");
            
            //Waiting for 2000 milliseconds
            Thread.Sleep(2000);
           
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }
        
            
            //Act-focus on theme menu  click
            Tap("AlblTheme");
            
            //Waiting for 1000 milliseconds
            Thread.Sleep(1000);

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Theme_Menu");
           
            //Waiting for 3000 milliseconds
            Thread.Sleep(3000);
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-scroll up to first name
            ScrollUp("AlblMain");

            //Act-focus on main menu click
            Tap("AlblMain");

            //Act-focus on log out menu click
            // Tap("AlblLogOut");
        }



        /// <summary>
        ///  Author: VENGATESHWARAN.S
        /// Date: 08-Nov-2022 
        /// Key features will show the main features about RSGT.
        /// Frequently Asked Questions(FAQ) of user are listed here to help user(s) to clear their doubt or clarifications then & there.
        /// AboutRSGT:Information about RSGT will be listed here.
        /// A feature to contact RSGT either registered user or anonymous user for any query or requirement.
        /// Themes:Feature to change the App’s theme to 3 different styles, Light (Default theme) or Green (National Day theme) or Dark theme
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        public void AnonyumsUser()
        {
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

            //Act-focus on key features menu click
            Tap("AlblKeyFeatures");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("KeyFeature_Menu");
            Thread.Sleep(3000);
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                Tap("OK");
            }

                //Act-focus on faq menu click
                Tap("AlblFaq");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("FAQ_Menu");
            Thread.Sleep(3000);
            //Act-focus on ok button click
            Tap("OK");

            //Act-focus on about rsgt menu click
            Tap("AlblAboutRSGT");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("AboutRSGT_Menu");
            Thread.Sleep(3000);
            //Act-focus on ok button click
            Tap("OK");

            //Act-focus on contact us menu click
            Tap("Alblcontactus");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Contactus_Menu");
            Thread.Sleep(3000);
            //Act-focus on ok button click
            Tap("OK");

            //Act-focus on theme menu click
            Tap("AlblTheme");
            Thread.Sleep(1000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Theme_Menu");
            Thread.Sleep(3000);
            //Act-focus on ok button click
            Tap("OK");

            //Act-focus on main menu click
            Tap("AlblMain");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 08-Nov-2022 
        /// A feature to contact RSGT either registered user or anonymous user for any query or requirement.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        public void procContactUS()
        {
            //Arrange-to creation of object
            ResourceManager objContact= new ResourceManager(typeof(ContactusResource));

            //Arrange-variable initalization
            string lstrContactusEmail = "";
           // string lstrContactusMessage = "";
            string lstrContactusName = "";
            string lstrContactusSubject = "";
            //Act-focus on ok button click
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }

            //Act-focus on contact us menu click
            Tap("Alblcontactus");
            Thread.Sleep(1000);
            //Act-focus on contact name control
            Tap("AEntName");
            //Act-reading value from the resource file
            lstrContactusName = objContact.GetString("ContactusName").ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AEntName", lstrContactusName);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Contactus_Name");
            Thread.Sleep(1000);

            //Act-focus on E-mail name control
            Tap("AEntEmail");
            //Act-reading value from the resource file
            lstrContactusEmail = objContact.GetString("ContactusEmail").ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AEntEmail", lstrContactusEmail);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Contactus_Email");
            Thread.Sleep(1000);

            //Act-focus on subject control
            Tap("AEntSubject");
            //Act-reading value from the resource file
            lstrContactusSubject = objContact.GetString("ContactusSubject").ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AEntSubject", lstrContactusSubject);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Contactus_Subject");
            Thread.Sleep(1000);

            //Act-scroll down to send button
            // Scrolldown("AButSend");

            //Act-focus on message control
            app.Tap("ATxtMessage");
            //Act-reading value from the resource file
            //lstrContactusMessage = objContact.GetString("ContactusMessage").ToString().Trim();
            //Act-assigning value to the control
            //EnterTextID("ATxtMessage", lstrContactusMessage);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("Contactus_Message");
            //Thread.Sleep(1000);

            //Act-focus on send button click
            // Tap("AButSend");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("SEND");

            //Act-focus on ok button click
            //OkButton
            // Tap(AbtnOk);

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("OkButton");


        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 12-Nov-2022 
        /// The user needs to register to use & enjoy the all the features of mobile app.
        /// Option to add multiple importers ID for one user.Objects have to be designed.
        /// If same entities having multiple stakeholder functionalities, still they need to have a login each stakeholder role separately.
        /// The mandatory field in additional information depends on the customer type.
        /// The user must agree to RSGT terms & conditions and click continue.
        /// As soon as user clicks NEXT, he comes to the next page where he can review the information he entere
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        public void procNewRegisterations()
        {
            //Act-focus on login button click
            Tap("AlblLogin");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Login Click");


            //Act-focus on click event
            Tap("AbtnRegister");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Register Link Click");


            //Act-focus on first name control
            Tap("AfocusFirstName");
            //Act-reading value from the resource file
            string lstrPerFirstNameEnglish = RegisterUserEnglish.ResourceManager.GetString("PerFirstNameEnglish");
            //Act-assigning value to the control
            EnterTextID("AfocusFirstName", lstrPerFirstNameEnglish);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("FirstnameEnglish");

            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.ScrollDownTo(c => c.Marked("ATxtLastName"));
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-scroll up to last name
                app.ScrollDownTo(c => c.Marked("ATxtLastName"));
            }

            //Act-focus on first name control in arabic
            Tap("ATxtFirstName1");
            //Act-reading value from the resource file
            string lstrPerFirstNameArabic = RegisterUserEnglish.ResourceManager.GetString("PerFirstNameArabic");
            //Act-assigning value to the control
            EnterTextID("ATxtFirstName1", lstrPerFirstNameArabic);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("FirstnameArabic");

            //Act-Validating the mandatary controls
            //   Tap("AbtnNext");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //   app.Screenshot("Nextbutton");

            //Act-focus on last name english
            Tap("ATxtLastName");
            //Act-reading value from the resource file
            string lstrPerLastNameEnglish = RegisterUserEnglish.ResourceManager.GetString("PerLastNameEnglish");
            //Act-assigning value to the control
            EnterTextID("ATxtLastName", lstrPerLastNameEnglish);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("LastnameEnglish");

            //Act-focus on last name arabic
            Tap("ATxtLastName2");
            //Act-reading value from the resource file
            string lstrPerLastNameArabic = RegisterUserEnglish.ResourceManager.GetString("PerLastNameArabic");
            //Act-assigning value to the control
            EnterTextID("ATxtLastName2", lstrPerLastNameArabic);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("LastnameArabic");

            //Act-scroll up to mobile number
            Scrolldown("ATxtMobileNumber");

            //Act-default country code selection
           /* Tap("AlobjContryMobCode");
            //Validating the ios or android 
              if (AppManager.AppManager.Platform == Platform.Android)
               {
                   app.Tap(c => c.Marked("text1").Index(7)); 
               }
              if (AppManager.AppManager.Platform == Platform.iOS)
                {
               
                }*/
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("Country");

            //Act-focus on mobile Number
            Tap("ATxtMobileNumber");
            //Act-reading value from the resource file
            string lstrPer_Mobile = RegisterUserEnglish.ResourceManager.GetString("PerMobile");
            //Act-assigning value to the control
            EnterTextID("ATxtMobileNumber", lstrPer_Mobile);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Mobile");

            //Act-scroll up to E-mail control
            Scrolldown("ATxtEmailAddress");

            //Act-focus on e-mail 
            Tap("ATxtEmailAddress");
            //Act-reading value from the resource file
            string lstrPerEmailAddress = RegisterUserEnglish.ResourceManager.GetString("PerEmailAddress");
            //Act-assigning value to the control
            EnterTextID("ATxtEmailAddress", lstrPerEmailAddress);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("RegEmail");

            Scrolldown("AbtnNext");
            //Act-focus on preffered communication
            Tap("AlobjPrefer");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("text1").Index(1));
              }
           
           if (AppManager.AppManager.Platform == Platform.iOS)
            {
                app.Tap(c => c.Class("UIPickerTableView").Child("UIPickerTableViewTitledCell").Index(3));
                Thread.Sleep(2000);
            }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("PrefCommunication");


            //Act-foucs on job title
            Tap("ATxtJobTitle");
            //Act-reading value from the resource file
            string lstrPerJobTitle = RegisterUserEnglish.ResourceManager.GetString("PerJobTitle");
            //Act-assigning value to the control
            EnterTextID("ATxtJobTitle", lstrPerJobTitle);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("PerJobTitle");

            //Act-scroll up to password control
            //Scrolldown("ATxtPassword");

            //Act-focus on job function
            Tap("AlobJobFunction");
            //Validating the ios or android 
             if (AppManager.AppManager.Platform == Platform.Android)
              {
                  app.Tap(c => c.Marked("text1").Index(6));
              }
              
             if (AppManager.AppManager.Platform == Platform.iOS)
              {
                app.Tap(c => c.Class("UIPickerTableView").Child("UIPickerTableViewTitledCell").Index(1));
                Thread.Sleep(3000);
             }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("JobFunction");

            //Act-foucs on password control
            Tap("ATxtPassword");
            //Act-reading value from the resource file
            string lstrPerPassword = RegisterUserEnglish.ResourceManager.GetString("PerPassword");
            //Act-assigning value to the control
            EnterTextID("ATxtPassword", lstrPerPassword);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("PerPassword");

            //Act-scroll up to next button 
            //  Scrolldown("AbtnNext");


            //Act-focus on confirm password control
            Tap("ATxtConfirmPassword");
            //Act-reading value from the resource file
            string lstrPerConfirmPassword = RegisterUserEnglish.ResourceManager.GetString("PerConfirmPassword");
            //Act-assigning value to the control
            EnterTextID("ATxtConfirmPassword", lstrPerConfirmPassword);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("PerConFirmPassword");


            //Act-focus on next button control
            Tap("AbtnNext");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Nextbutton");

            // Already have an account? Login
            // app.Tap(c => c.Marked("NoResourceEntry-276"));


            // Company information
            // Act-focus on company type selection
            Tap("AlobjCompanyType");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
             {
                   app.Tap(c => c.Marked("text1").Index(8));
             }
          
           if (AppManager.AppManager.Platform == Platform.iOS)
            {
                app.Tap(c => c.Class("UIPickerTableView").Child("UIPickerTableViewTitledCell").Index(1));
                Thread.Sleep(1000);
            }

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("CompanyType");

            //Act-Scroll up to next button
            //Scrolldown("AbtnNextP2");

            //Act-focus on company name control
            Tap("ATxtCompanyName");
            //Act-reading value from the resource file
            string lstrCom_CompanyName = RegisterUserEnglish.ResourceManager.GetString("Com_CompanyName");
            //Act-assigning value to the control
            EnterTextID("ATxtCompanyName", lstrCom_CompanyName);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("CompanyName");

            //Act-focus on next button control
            Tap("AbtnNextP2");

            // Act- focus on Previous button control
            //  Tap("AbtnPreviousP2");


            // Already have an account? Login
            // app.Tap(c => c.Marked("NoResourceEntry-276"));

            // National Address Page 
            // Act-focus on country control
           /* Tap("AlobjCountry");
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                app.Tap(c => c.Marked("text1").Index(7));
                   
            }           
           if (AppManager.AppManager.Platform == Platform.iOS)
            {
               
            }
           */
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("NationalCountry");
            // Act-focus on building number control
            Tap("ATxtBuildingNo");
            //Act-reading value from the resource file
            string lstrNan_Buildno = RegisterUserEnglish.ResourceManager.GetString("Nan_Buildno");
            //Act-assigning value to the control
            EnterTextID("ATxtBuildingNo", lstrNan_Buildno);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Buildingno");

            //Act-scroll up to district name
            Scrolldown("ATxtDistrict");

            //Act-focus on unit no control
            Tap("ATxtUnitNo");
            //Act-reading value from the resource file
            string lstrNan_Unitno = RegisterUserEnglish.ResourceManager.GetString("Nan_Unitno");
            //Act-assigning value to the control
            EnterTextID("ATxtUnitNo", lstrNan_Unitno);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Unitno");

            //Act-validating the mandatary controls
            // Tap("AbtnNextP3");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Nationaladdressvalidation");

            //Act-focus on street name control
            Tap("ATxtStreetName");
            //Act-reading value from the resource file
            string lstrNan_Streetname = RegisterUserEnglish.ResourceManager.GetString("Nan_Streetname");
            //Act-assigning value to the control
            EnterTextID("ATxtStreetName", lstrNan_Streetname);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Streetname");

            //Act-focus on district name control
            Tap("ATxtDistrict");
            //Act-reading value from the resource file
            string lstrNan_Districtname = RegisterUserEnglish.ResourceManager.GetString("Nan_Districtname");
            //Act-assigning value to the control
            EnterTextID("ATxtDistrict", lstrNan_Districtname);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Districtname");

            //Act-scroll up to fax
            Scrolldown("ATxtFax");

            //Act-focus on city name control
            Tap("AlobjCity");
            //Validating the ios or android 
           if (AppManager.AppManager.Platform == Platform.Android)
            {
                 app.Tap(c => c.Marked("text1").Index(7));
            }
           if (AppManager.AppManager.Platform == Platform.iOS)
            {
                app.Tap(c => c.Class("UIPickerTableView").Child("UIPickerTableViewTitledCell").Index(1));
                Thread.Sleep(1000);
            }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Cityname");

            //Act-focus on zip code control
            Tap("ATxtZipCode");
            //Act-reading value from the resource file
            string lstrNan_Zipcode = RegisterUserEnglish.ResourceManager.GetString("Nan_Zipcode");
            //Act-assigning value to the control
            EnterTextID("ATxtZipCode", lstrNan_Zipcode);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Zipcode");



            //Act-focus on additional no control
            Tap("ATxtAdditionalNo");
            //Act-reading value from the resource file
            string lstrNan_Additionalno = RegisterUserEnglish.ResourceManager.GetString("Nan_Additionalno");
            //Act-assigning value to the control
            EnterTextID("ATxtAdditionalNo", lstrNan_Additionalno);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Additionalno");

            // Act-focus on Telephone number control
            Tap("ATxtTelephone");
            //Act-reading value from the resource file
            string lstrNan_Telephone = RegisterUserEnglish.ResourceManager.GetString("Nan_Telephone");
            //Act-assigning value to the control
            EnterTextID("ATxtTelephone", lstrNan_Telephone);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Telephone");

            //Act-focus on fax number control
            Tap("ATxtFax");
            //Act-reading value from the resource file
            string lstrNan_Fax = RegisterUserEnglish.ResourceManager.GetString("Nan_Fax");
            //Act-assigning value to the control
            EnterTextID("ATxtFax", lstrNan_Fax);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Fax");

            //Act-scroll up to next button 
            Scrolldown("AbtnNextP3");

            //Act-focus on next button control
            Tap("AbtnNextP3");

            // Act- focus on previous button control 
            //  Tap("AbtnPreviousP3");

            // Already have an account? Login
            //  app.Tap(c => c.Marked("NoResourceEntry-276"));


            // Additional Information

            //Act- focus on customer type control
            Tap("AlobjCustomerType");
          
            if (AppManager.AppManager.Platform == Platform.Android)
            {
               
                app.Tap(c => c.Marked("text1").Index(8));
                Thread.Sleep(1000);
                    
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                app.Tap(c => c.Class("UIPickerTableView").Child("UIPickerTableViewTitledCell").Index(4));
                Thread.Sleep(1000);
            }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Customertype");
            //Act-focus on national address control
            Tap("ATxtIDNo");
            //Act-reading value from the resource file
            string lstrAddi_NationalAddress = RegisterUserEnglish.ResourceManager.GetString("Addi_NationalAddress");
            //Act-assigning value to the control
            EnterTextID("ATxtIDNo", lstrAddi_NationalAddress);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("NationalAddress");

            //Act-focus on import export license Number control
            Tap("AFocusImpExpLicNo");
            //Act-reading value from the resource file
            string lstrAddi_Import_Export_LicenseNo = RegisterUserEnglish.ResourceManager.GetString("Addi_Import_Export_LicenseNo");
            //Act-assigning value to the control
            EnterTextID("AFocusImpExpLicNo", lstrAddi_Import_Export_LicenseNo);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("AddiImportExportLicenseNo");


            //Act- foucs on + to expand the page
            Tap("AbtnPlus");

            //Act-focus on additional Licence no 1 control
            Tap("ATxtlicenceNo2");
            //Act-reading value from the resource file    
            string lstrAddi_import_Export_AdditionNo1 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo1");//Addi_import_Export_AdditionNo1
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo2", lstrAddi_import_Export_AdditionNo1);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo1");

            //Act-focus on additional Licence no 2 control
            Tap("ATxtlicenceNo3");
            //Act-reading value from the resource file   
            string lstrAddi_import_Export_AdditionNo2 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo2");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo3", lstrAddi_import_Export_AdditionNo2);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo2");

            //Act-focus on additional Licence no 3 control
            Tap("ATxtlicenceNo4");
            //Act-reading value from the resource file  
            string lstrAddi_import_Export_AdditionNo3 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo3");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo4", lstrAddi_import_Export_AdditionNo3);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo3");


            //Act-scroll down to 7
            Scrolldown("ATxtlicenceNo7");

            //Act-focus on additional Licence no 4 control
            Tap("ATxtlicenceNo5");
            //Act-reading value from the resource file 
            string lstrAddi_import_Export_AdditionNo4 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo4");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo5", lstrAddi_import_Export_AdditionNo4);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo4");

            //Act-focus on additional Licence no 5 control
            Tap("ATxtlicenceNo6");
            //Act-reading value from the resource file
            string lstrAddi_import_Export_AdditionNo5 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo5");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo6", lstrAddi_import_Export_AdditionNo5);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo5");

            //Act-focus on additional Licence no 6 control
            Tap("ATxtlicenceNo7");
            //Act-reading value from the resource file
            string lstrAddi_import_Export_AdditionNo6 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo6");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo7", lstrAddi_import_Export_AdditionNo6);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo6");

            //Act-focus on additional Licence no 7 control
            Tap("ATxtlicenceNo8");
            //Act-reading value from the resource file
            string lstrAddi_import_Export_AdditionNo7 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo7");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo8", lstrAddi_import_Export_AdditionNo7);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo7");

            //Act-focus on additional Licence no 8 control
            Tap("ATxtlicenceNo9");
            //Act-reading value from the resource file
            string lstrAddi_import_Export_AdditionNo8 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo8");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo9", lstrAddi_import_Export_AdditionNo8);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo8");

            //Act-focus on additional Licence no 9 control
            Tap("ATxtlicenceNo10");
            //Act-reading value from the resource file
            string lstrAddi_import_Export_AdditionNo9 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo9");
            //Act-assigning value to the control
            EnterTextID("ATxtlicenceNo10", lstrAddi_import_Export_AdditionNo9);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo");


            //Act-scroll  down the page 
            Scrolldown("AbtnOk");


            //Act- focus on button "ok" control
            Tap("AbtnOk");
            app.Screenshot("AdditionalInformation");

            //Act-focus on " terms & conditions" control
            Tap("AChkMandatoryterms");

            //Act-focus on next button control
            Tap("AbtnNextP4");

            // Previous
            //  Tap("AbtnPreviousP4");

            // Already have an account? Login
            //  Tap("AbtnAlreadyLogIn");


            //Act-scroll up to customer registeration
            Scrolldown("AbtnSentOTP");
            app.Screenshot("CustomerInformation");
            //Act-dismiss keyboard
            app.DismissKeyboard();


        }


        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 12-Nov-2022 
        /// App will show the registered details as default, if user wants to change anything, they can change and save.
        /// If anything changed in “Additional Information” section, the user activation has been de-activated. 
        /// Then activation process to be done again by RSGT team.
        /// After activation only respective user will use logged in features of this App.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker
        /// 2.ClearingAgent
        /// 3.Consignee
        /// 4.Transporter
        /// </param>
        /// Obsolete Date:
        /// Category:Method 
        public void procMyProfile(string fstrUserType)
        {
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button control
                Tap("OK");
            }
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button control
                Tap("OK");
            }
            //Act-focus on MyProfile menu button click
            Tap("AlblMyProfile1");
            Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("MyProfile_Menu");
            Thread.Sleep(3000);

            //Act-focus on first name control
            Tap("AEntFcsFirstName");
            app.ClearText("AEntFcsFirstName");
            //Act-reading value from the resource file
            //  string lstrPerFirstNameEnglish = RegisterUserEnglish.ResourceManager.GetString("PerFirstNameEnglish");
            string lstrPerFirstNameEnglish = "Abdul Nabi";
            //Act-assigning value to the control
            EnterTextID("AEntFcsFirstName", lstrPerFirstNameEnglish);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("FirstnameEnglish");


            //Act-scroll up to last name
            Scrolldown("AEntLastName");


            //Act-focus on first name control in arabic
            Tap("AEntFrstName1");
            app.ClearText("AEntFrstName1");
            //Act-reading value from the resource file
            //  string lstrPerFirstNameArabic = RegisterUserEnglish.ResourceManager.GetString("PerFirstNameArabic");
            string lstrPerFirstNameArabic = "Abdul Nabi-A";
            //Act-assigning value to the control
            EnterTextID("AEntFrstName1", lstrPerFirstNameArabic);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("FirstnameArabic");


            //Act-focus on last name english
            // Tap("AEntLastName");
            //Act-reading value from the resource file
            // string lstrPerLastNameEnglish = RegisterUserEnglish.ResourceManager.GetString("PerLastNameEnglish");
            //Act-assigning value to the control
            // EnterTextID("AEntLastName", lstrPerLastNameEnglish);
            //Act-dismiss keyboard
            //  app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("LastnameEnglish");

            //Act-focus on last name arabic
            //  Tap("AEntLastName1");
            //Act-reading value from the resource file
            // string lstrPerLastNameArabic = RegisterUserEnglish.ResourceManager.GetString("PerLastNameArabic");
            //Act-assigning value to the control
            //  EnterTextID("AEntLastName1", lstrPerLastNameArabic);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("LastnameArabic");

            //Act-scroll up to mobile number
            Scrolldown("AEntMobileNo");

            //Act-default country code selection
            //   Tap("APckCuntryCode");
            //Validating the ios or android 
            //  if (AppManager.AppManager.Platform == Platform.Android)
            // {
            //      app.Tap(c => c.Marked("text1").Index(7));

            //  }
            //  if(AppManager.AppManager.Platform==Platform.iOS)
            //  {

            //  }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //      app.Screenshot("Country");
            // app.ScrollDownTo(c => c.Marked("NoResourceEntry-93"));
            // app.ScrollDown(c => c.Marked("NoResourceEntry-93"));

            // app.ScrollDownTo(c => c.All().Class("PickerEditText").Index(10));
            // app.ScrollDown(c => c.Marked("NoResourceEntry-93"));
            // app.TapCoordinates(540, 1622);
            // app.Tap(c => c.Class("AppCompatTextView").Text("India (+91)"));



            //Act-focus on mobile Number
            Tap("AEntMobileNo");
            app.ClearText("AEntMobileNo");
            //Act-reading value from the resource file
            //  string lstrPer_Mobile = RegisterUserEnglish.ResourceManager.GetString("PerMobile");
            string lstrPer_Mobile = "65712398";
            //Act-assigning value to the control
            EnterTextID("AEntMobileNo", lstrPer_Mobile);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Mobile");

            //Act-scroll up to E-mail control
            Scrolldown("AEntEmailAddPlc");

            //Act-focus on e-mail 
            // Tap("AEntEmailAddPlc");
            //Act-reading value from the resource file
            //  string lstrPerEmailAddress = RegisterUserEnglish.ResourceManager.GetString("PerEmailAddress");
            //Act-assigning value to the control
            //  EnterTextID("AEntEmailAddPlc", lstrPerEmailAddress);
            //Act-dismiss keyboard
            //  app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("RegEmail");


            //Act-focus on preffered communication
            // Tap("APckPrefComm");
            //Validating the ios or android 
            //  if (AppManager.AppManager.Platform == Platform.Android)
            //  {
            //       app.Tap(c => c.Marked("text1").Index(1));

            //  }

            //  if(AppManager.AppManager.Platform==Platform.iOS)
            //  {

            //  }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //       app.Screenshot("PrefCommunication");
            //Act-foucs on job title
            //   Tap("AEntJobTitlePlc");
            //Act-reading value from the resource file
            // string lstrPerJobTitle = RegisterUserEnglish.ResourceManager.GetString("PerJobTitle");
            //Act-assigning value to the control
            // EnterTextID("AEntJobTitlePlc", lstrPerJobTitle);
            //Act-dismiss keyboard
            //   app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("PerJobTitle");

            //Act-scroll up to password control
            Scrolldown("AEntPwdPlc");

            //Act-focus on job function
            // Tap("ApckJobFunct");
            //Validating the ios or android 
            // if (AppManager.AppManager.Platform == Platform.Android)
            //  {
            //      app.Tap(c => c.Marked("text1").Index(6));
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //      app.Screenshot("JobFunction");
            //  }


            //Act-foucs on password control
            // Tap("AEntPwdPlc");
            //Act-reading value from the resource file
            // string lstrPerPassword = RegisterUserEnglish.ResourceManager.GetString("PerPassword");
            //Act-assigning value to the control
            // EnterTextID("AEntPwdPlc", lstrPerPassword);
            //Act-dismiss keyboard
            //   app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("PerPassword");

            //Act-scroll up to next button 
            Scrolldown("AButNxt");


            //Act-focus on confirm password control
            // Tap("AEntCnfrmPwd");
            //Act-reading value from the resource file
            //  string lstrPerConfirmPassword = RegisterUserEnglish.ResourceManager.GetString("PerConfirmPassword");
            //Act-assigning value to the control
            //  EnterTextID("AEntCnfrmPwd", lstrPerConfirmPassword);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("PerConFirmPassword");


            //Act-focus on next button control
            Tap("AButNxt");

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("Nextbutton");

            // Already have an account? Login
            // app.Tap(c => c.Marked("NoResourceEntry-276"));


            // Company information
            // Act-focus on company type selection
            //   Tap("APckCompyType");
            //Validating the ios or android 
            // if (AppManager.AppManager.Platform == Platform.Android)
            //  {
            //      app.Tap(c => c.Marked("text1").Index(8));
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //      app.Screenshot("CompanyType");
            // }
            //Act-dismiss keyboard
            app.DismissKeyboard();
            //Act-Scroll up to next button
            //Scrolldown("AButNxt2");

            //Act-focus on company name control
            //  Tap("AEntCmpyNameplc");
            //Act-reading value from the resource file
            // string lstrCom_CompanyName = RegisterUserEnglish.ResourceManager.GetString("Com_CompanyName");
            //Act-assigning value to the control
            // EnterTextID("AEntCmpyNameplc", lstrCom_CompanyName);
            //Act-dismiss keyboard
            //  app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("CompanyName");

            //Act-focus on next button control
            Tap("AButNxt2");

            // Act- focus on Previous button control
            //  Tap("AbtnPreviousP2");


            // Already have an account? Login
            // app.Tap(c => c.Marked("NoResourceEntry-276"));

            // National Address Page 
            // Act-focus on country control
            // Tap("APckContrylobj");
            //Validating the ios or android 
            //  if (AppManager.AppManager.Platform == Platform.Android)
            //  {
            //      app.Tap(c => c.Marked("text1").Index(7));
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //     app.Screenshot("NationalCountry");
            // }


            // Act-focus on building number control
            Tap("AEntBuildingNo");
            //Act-reading value from the resource file
            //  string lstrNan_Buildno = RegisterUserEnglish.ResourceManager.GetString("Nan_Buildno");
            //Act-assigning value to the control
            //  EnterTextID("AEntBuildingNo", lstrNan_Buildno);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("Buildingno");

            //Act-scroll up to district name
            Scrolldown("AEntStreetName");

            //Act-focus on unit no control
            //  Tap("AEntUnitNo");
            //Act-reading value from the resource file
            // string lstrNan_Unitno = RegisterUserEnglish.ResourceManager.GetString("Nan_Unitno");
            //Act-assigning value to the control
            // EnterTextID("AEntUnitNo", lstrNan_Unitno);
            //Act-dismiss keyboard
            //   app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //   app.Screenshot("Unitno");



            //Act-focus on street name control
            // Tap("AEntStreetName");
            //Act-reading value from the resource file
            // string lstrNan_Streetname = RegisterUserEnglish.ResourceManager.GetString("Nan_Streetname");
            //Act-assigning value to the control
            //  EnterTextID("AEntStreetName", lstrNan_Streetname);
            //Act-dismiss keyboard
            //app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Streetname");

            //Act-focus on district name control
            // Tap("AEntDistName");
            //Act-reading value from the resource file
            // string lstrNan_Districtname = RegisterUserEnglish.ResourceManager.GetString("Nan_Districtname");
            //Act-assigning value to the control
            // EnterTextID("AEntDistName", lstrNan_Districtname);
            //Act-dismiss keyboard
            //  app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("Districtname");

            //Act-scroll up to fax
            Scrolldown("AEntFax");

            //Act-focus on city name control
            //   Tap("APckCitylobj");
            //Validating the ios or android 
            //  if (AppManager.AppManager.Platform == Platform.Android)
            // {
            //    app.Tap(c => c.Marked("text1").Index(7));
            // }
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("Cityname");

            //Act-focus on zip code control
            //    Tap("AEntZipCodeplace");
            //Act-reading value from the resource file
            //string lstrNan_Zipcode = RegisterUserEnglish.ResourceManager.GetString("Nan_Zipcode");
            //Act-assigning value to the control
            // EnterTextID("AEntZipCodeplace", lstrNan_Zipcode);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Zipcode");



            //Act-focus on additional no control
            //   Tap("AEntAdditionalNo");
            //Act-reading value from the resource file
            // string lstrNan_Additionalno = RegisterUserEnglish.ResourceManager.GetString("Nan_Additionalno");
            //Act-assigning value to the control
            //  EnterTextID("AEntAdditionalNo", lstrNan_Additionalno);
            //Act-dismiss keyboard
            //  app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Additionalno");

            // Act-focus on Telephone number control
            //  Tap("AEntReg");
            //Act-reading value from the resource file
            // string lstrNan_Telephone = RegisterUserEnglish.ResourceManager.GetString("Nan_Telephone");
            //Act-assigning value to the control
            // EnterTextID("AEntReg", lstrNan_Telephone);
            //Act-dismiss keyboard
            //  app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Telephone");

            //Act-focus on fax number control
            // Tap("AEntFax");
            //Act-reading value from the resource file
            // string lstrNan_Fax = RegisterUserEnglish.ResourceManager.GetString("Nan_Fax");
            //Act-assigning value to the control
            // EnterTextID("AEntFax", lstrNan_Fax);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Fax");

            //Act-scroll up to next button 
            Scrolldown("AButNxt3");

            //Act-focus on next button control
            Tap("AButNxt3");

            // Act- focus on previous button control 
            //  Tap("AbtnPreviousP3");

            // Already have an account? Login
            //  app.Tap(c => c.Marked("NoResourceEntry-276"));


            // Additional Information

            //Act- focus on customer type control
            //  Tap("APckCustType");
            //Validating the ios or android 
            //  if (AppManager.AppManager.Platform == Platform.Android)
            // {
            //     app.Tap(c => c.Marked("text1").Index(3));
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //     app.Screenshot("Customertype");
            // }
            //Act-dismiss keyboard
            app.DismissKeyboard();
            //Act-focus on national address control
            // Tap("AEntFcsTxtIdNo");
            //Act-reading value from the resource file
            // string lstrAddi_NationalAddress = RegisterUserEnglish.ResourceManager.GetString("Addi_NationalAddress");
            //Act-assigning value to the control
            // EnterTextID("AEntFcsTxtIdNo", lstrAddi_NationalAddress);
            //Act-dismiss keyboard
            //  app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("NationalAddress");

            //Act-focus on import export license Number control
            Tap("AEntImpExplicNo");
            app.ClearText("AEntImpExplicNo");
            //Act-reading value from the resource file
            // string lstrAddi_Import_Export_LicenseNo = RegisterUserEnglish.ResourceManager.GetString("Addi_Import_Export_LicenseNo");
            string lstrAddi_Import_Export_LicenseNo = "Abc865";
            //Act-assigning value to the control
            EnterTextID("AEntImpExplicNo", lstrAddi_Import_Export_LicenseNo);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("AddiImportExportLicenseNo");


            //Act- foucs on + to expand the page
            Tap("AbtnPlus");

            //Act-focus on additional Licence no 1 control
            Tap("AEntFocuslicenseNo2");
            app.ClearText("AEntFocuslicenseNo2");
            //Act-reading value from the resource file    
            // string lstrAddi_import_Export_AdditionNo1 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo1");//Addi_import_Export_AdditionNo1
            string lstrAddi_import_Export_AdditionNo1 = "Def543";
            //Act-assigning value to the control
            EnterTextID("AEntFocuslicenseNo2", lstrAddi_import_Export_AdditionNo1);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Addi_Import_Export_LicenseNo1");

            //Act-focus on additional Licence no 2 control
            //  Tap("AEntLicNo3");
            //Act-reading value from the resource file   
            //  string lstrAddi_import_Export_AdditionNo2 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo2");
            //Act-assigning value to the control
            //  EnterTextID("AEntLicNo3", lstrAddi_import_Export_AdditionNo2);
            //Act-dismiss keyboard
            //app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Addi_Import_Export_LicenseNo2");

            //Act-focus on additional Licence no 3 control
            //  Tap("AEntLicNo4");
            //Act-reading value from the resource file  
            //  string lstrAddi_import_Export_AdditionNo3 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo3");
            //Act-assigning value to the control
            //  EnterTextID("AEntLicNo4", lstrAddi_import_Export_AdditionNo3);
            //Act-dismiss keyboard
            //app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("Addi_Import_Export_LicenseNo3");


            //Act-scroll down to 7
            Scrolldown("AEntLicNo7");

            //Act-focus on additional Licence no 4 control
            //Tap("AEntLicNo5");
            //Act-reading value from the resource file 
            //  string lstrAddi_import_Export_AdditionNo4 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo4");
            //Act-assigning value to the control
            //  EnterTextID("AEntLicNo5", lstrAddi_import_Export_AdditionNo4);
            //Act-dismiss keyboard
            //   app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("Addi_Import_Export_LicenseNo4");

            //Act-focus on additional Licence no 5 control
            //  Tap("AEntLicNo6");
            //Act-reading value from the resource file
            //  string lstrAddi_import_Export_AdditionNo5 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo5");
            //Act-assigning value to the control
            // EnterTextID("AEntLicNo6", lstrAddi_import_Export_AdditionNo5);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Addi_Import_Export_LicenseNo5");

            //Act-focus on additional Licence no 6 control
            //Tap("AEntLicNo7");
            //Act-reading value from the resource file
            //   string lstrAddi_import_Export_AdditionNo6 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo6");
            //Act-assigning value to the control
            //  EnterTextID("AEntLicNo7", lstrAddi_import_Export_AdditionNo6);
            //Act-dismiss keyboard
            //app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //app.Screenshot("Addi_Import_Export_LicenseNo6");

            //Act-focus on additional Licence no 7 control
            //  Tap("AEntLicNo8");
            //Act-reading value from the resource file
            //   string lstrAddi_import_Export_AdditionNo7 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo7");
            //Act-assigning value to the control
            // EnterTextID("AEntLicNo8", lstrAddi_import_Export_AdditionNo7);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //  app.Screenshot("Addi_Import_Export_LicenseNo7");

            //Act-focus on additional Licence no 8 control
            //  Tap("AEntLicNo9");
            //Act-reading value from the resource file
            //  string lstrAddi_import_Export_AdditionNo8 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo8");
            //Act-assigning value to the control
            //  EnterTextID("AEntLicNo9", lstrAddi_import_Export_AdditionNo8);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Addi_Import_Export_LicenseNo8");

            //Act-focus on additional Licence no 9 control
            //Tap("AEntLicNo10");
            //Act-reading value from the resource file
            // string lstrAddi_import_Export_AdditionNo9 = RegisterUserEnglish.ResourceManager.GetString("Addi_import_Export_AdditionNo9");
            //Act-assigning value to the control
            // EnterTextID("ATxtlicenceNo10", lstrAddi_import_Export_AdditionNo9);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Addi_Import_Export_LicenseNo9");

            //Act-focus on button ok the scroll down the page 
             Scrolldown("AButOK1");


            //Act- focus on  ok  button control
              Tap("AButOK1");
            app.Screenshot(fstrUserType + "ImportExportLicenseNo");

            Tap("AEntImpExplicNo");
            app.DismissKeyboard();
            app.Screenshot(fstrUserType + "AdditionalInformation");



            //Act- focus on previous button control
            //  Tap("AbtnPreviousP4");

            //Act- focus on Update button control 
            //  Tap("AButUpdt4");


            //Act-scroll up to customer registeration
            //  Scrolldown("AbtnSentOTP");
            //Act-dismiss keyboard
            //  app.DismissKeyboard();



            //Sendotp Confirmation
            //  app.Tap(c => c.Marked("NoResourceEntry-275"));
            // app.Tap(c => c.Marked("NoResourceEntry-274"));//Modify information
            //app.Tap(c => c.Marked("NoResourceEntry-276"));  // Already have an account? Login

            //Customer Registeration

            //  app.Tap(c => c.Marked("NoResourceEntry-257"));
            // string lstrSENDOTP_REGISTERATION = RegisterUserEnglish.ResourceManager.GetString("SENDOTP_REGISTERATION");
            // app.EnterText(lstrSENDOTP_REGISTERATION);
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("SENDOTP_REGISTERATION");

            //Confirm
            //        app.Tap(c => c.Marked("NoResourceEntry-258"));
            //    app.Screenshot("Confirm");
            //Cancel
            //app.Tap(c => c.Marked("NoResourceEntry-259"));
            // Already have an account? Login
            //  app.Tap(c => c.Marked("NoResourceEntry-276"));


            //Dear Customer To login
            // app.Tap(c => c.Marked("NoResourceEntry-263"));
            // app.Screenshot("login");
            // Already have an account? Login
            //  app.Tap(c => c.Marked("NoResourceEntry-276"));



        }       
    
        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 08-Nov-2022 
        /// Themes:Feature to change the App’s theme to 3 different styles,
        /// 1.Light (Default theme) 
        /// 2.Green (National Day theme)  
        /// 3.Dark theme
        /// </summary>
        /// Obsolete Date:
        /// Category:Method
        public void procThemes()
        {
            //Act-focus on ok button click
            Tap("OK");

            //Act-scroll down to theme
            Scrolldown("AlblTheme");
           
            Tap("AlblTheme");
            Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Themes");
            Thread.Sleep(3000);

            //Act-focus on light theme button click
            Tap("AbtnLightTheme");
            //Act-focus on apply button click
            Tap("AbtnApply");
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 16-Nov-2022 
        /// RegisterUser Login Menu
        /// Track->Basic Tracking
        /// Tracking shipment feature will be useful to find status of given container number.
        /// If the given container number is valid, then app will show the details about the container. 
        /// If the given container number is not valid or not available in database, then we will show “No record found” information.
        /// Notification:
        /// Will be settings for container status notification to given mobile #, when respective container’s status being changed up to gated out.
        /// </summary>
        ///  <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procTrackShipment(string fstrUserType)
        {

            //Arrange-variable initalization
            string lstrContainerNo = "";

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
            Thread.Sleep(1000);
            //Act-focus on dashboard menu click
            Tap("AlblDashboard");
            Thread.Sleep(1000);
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
            //Act-focus on track button click
            Tap("AlblTrack");
            //Act-focus on basic tracking button click
            Tap("AlblBasicTracking");
            //Act-focus on container number control
            Tap("AtxtContainerNumber");
            //Act-reading value from the resource file
            lstrContainerNo = objResource.GetString("Container_" + fstrUserType).ToString().Trim();
            //Act-assigning value to the control
            EnterTextID("AtxtContainerNumber", lstrContainerNo);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("ContainerNumber");
            //Act-focus on track button click
            Tap("AbtnTrack");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("TrackingResult");

            //Act-focus on expand button click
            Tap("AimgDownArrowIcon");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("ContainerDetails_Expand");
            Thread.Sleep(1000);

            //Act-focus on expand collapse button click
            Tap("AimgDownArrowIcon");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("ContainerDetails_Collapse");
            Thread.Sleep(3000);
            //Act-scroll down to gated out button
            // Scrolldown("AGatedOut");

            //Act-focus on notify button click
            //   Tap("AbtnNotify");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //   app.Screenshot("Notify_BTNClick");

            //Act-focus on message control
            // Tap("message");
            //Act-reading value from the resource file
            // lstrMobile = BasicResource.ResourceManager.GetString("Mobile");
            //Act-assigning value to the control
            // app.EnterText(lstrMobile);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Basictracking-MobileNo");
            //Act-focus on ok button click
            // Tap("button1");-> ok
            //Act-focus on cancel button click
            // Tap("button1");->Cancel

        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 16-Nov-2022 
        /// RegisterUser login Menu
        /// Track -> Advance Tracking
        /// It is for navigating Bayan, Bill of lading and Container pages and seeing respective records for logged in user.
        /// Generate Invoice, pay invoice and appointment will be done for respective eligible bill of lading #.
        /// Can see the container detail PDF and can mail the same PDF through mail.
        /// </summary>
        /// <param name="fstrUserType">
        /// 1.Broker User
        /// 2.ClearingAgent User
        /// 3.Consignee User
        /// 4.Transporter User
        /// </param>
        /// Obsolete Date:
        /// Category:Method
        public void procAdvancedTracking(string fstrUserType)
        {
            

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.iOS)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            Thread.Sleep(1000);
            //Act-focus on dashboard menu click
               Tap("AlblDashboard");
            Thread.Sleep(1000);

            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.Android)
            {
                //Act-focus on ok button click
                Tap("OK");
            }
            //Validating the ios or android 
            if (AppManager.AppManager.Platform == Platform.iOS)
               {
                  //Act-focus on ok button click
                   Tap("OK");
               }
            Thread.Sleep(1000);
            //Act-focus on track button click
              Tap("AlblTrack");
            Thread.Sleep(1000);
            //Act-focus on advance tracking button click
            Tap("AlblAdvanceTracking");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Bayanlist");
            Thread.Sleep(1000);

            //Act-focus on expand collapse button click
           // Tap("AimgDownArrow1");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("BayanDetails");
            //Act-focus on expand collapse button click
            //Tap("AimgDownArrow1");

            //Act-focus on searchbox control
                 Tap("AlEtySearchbox");
                 //Act-reading value from the resource file
                 //lstrCarrier = objResource.GetString("Carrier_" + fstrUserType).ToString().Trim();
                  //Act-assigning value to the control
               //  EnterTextID("AlEtySearchbox", lstrCarrier);
                   //Act-dismiss keyboard
                 app.DismissKeyboard();
             // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot(fstrUserType + "AdvanceTrackingSearch");

         /*   //Act-focus on search button click
                 Tap("AlImgButSearch");
             // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
                 app.Screenshot("BayanNoSearch");

                 //Act-focus on expand collapse button click
                 Tap("AimgDownArrow1");
                 Thread.Sleep(1000);
                // The screenshot can be inspected after the test run to verify
                 // the visual correctness of the screen.
                 app.Screenshot("ExpandBayanList");
            //Act-focus on clear text values
                 // app.ClearText("AlEtySearchbox");
             //Act-focus on search button click
                 // Tap("AlImgButSearch");

                 //Act-focus on main page filter button click
                 //  Tap("AlImgButFlt");

                  //Act-focus on status button click
                 /*Tap("AChkStatus");
                   //Validating the ios or android 
                   if (AppManager.AppManager.Platform == Platform.Android)
                    {
                        app.Tap(c => c.Marked("text1").Index(0));
                   // The screenshot can be inspected after the test run to verify
                  // the visual correctness of the screen.
                         app.Screenshot("Status");
                    }

                  Thread.Sleep(1000);

                   //Act-focus on filter apply button click 
                  Tap("AlButFilter");  

                 Thread.Sleep(1000);
             //Act-focus on more details button click
                 Tap("AbtnMoreDetails");
             // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
                 app.Screenshot("ExpandBillofLadingList");


                 */






        }


      



    }
}