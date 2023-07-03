using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITest1;
using Xamarin.UITest;
using NUnit.Framework;
using System.Resources;


namespace RsgtUITest
{
   public  class LoginPage : BasicSetup 
    {


        public LoginPage(Platform platform) : base(platform)
        {
        }

        public void ProcRegisterUserLogin(ResourceManager objResource, string fstrUserType)

        {
            // System.Resources.ResourceManager
            ResourceManager objLoginuser = new ResourceManager("LoginResource", System.Reflection.Assembly.GetExecutingAssembly());

            app.Tap(c => c.Marked("AlblLogin"));
            app.Tap(c => c.Marked("ATxtUserName"));
          //  var rr1 = new System.Resources.ResourceReader("LoginUserResource.resources");
            string lstrUsername = objLoginuser.GetString("Username_" + fstrUserType).ToString().Trim();
            app.EnterText(lstrUsername);
            app.DismissKeyboard();
            app.Screenshot(fstrUserType + "Userid");

            //password
            app.Tap(c => c.Marked("ATxtPassword"));
            string lstrPassword = objResource.GetString("Password_" + fstrUserType).ToString().Trim();
            app.EnterText(lstrPassword);
            app.DismissKeyboard();
            app.Screenshot(fstrUserType + "Password");

            //UserLogin btn click
            app.Tap(c => c.Marked("AbtnLogIn"));
            app.Screenshot(fstrUserType + "Login_Click");

            //OTP Assign
            app.Tap(c => c.Marked("AtxtOtp"));
            string lstrOTP = objResource.GetString("OTP_" + fstrUserType).ToString().Trim();
            app.EnterText(lstrOTP);
            app.DismissKeyboard();
            app.Screenshot(fstrUserType + "OTP");
            //Confirm
            app.Tap(c => c.Marked("AbtnConfirm"));//
            app.Screenshot(fstrUserType + "Confirm");

            app.Tap(c => c.Marked("OK"));
            app.Screenshot(fstrUserType + "SlideMenu");
            //Landing to Login User Details


        }

    }
}
