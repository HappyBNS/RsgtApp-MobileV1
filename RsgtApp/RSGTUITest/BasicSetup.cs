using NUnit.Framework;
using Xamarin.UITest;
using System.Threading;



namespace RsgtUITest
{
    /// <summary>
    /// This requires creating an NUnit TestFixture, configuring an instance of IApp that can be used in a Test method.
    /// </summary>
 
    //For Android device
    [TestFixture(Platform.Android)]

    //For iOS device
    //[TestFixture(Platform.iOS)]

    public abstract class BasicSetup
    {
        /// <summary>
        /// Variable declaration
        /// </summary>
        protected  IApp app => AppManager.AppManager.App;
        protected bool OnAndroid => AppManager.AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.AppManager.Platform == Platform.iOS;

        /// <summary>
      /// BasicSetup
      /// </summary>
      /// <param name="platform">
      /// Validate device should be Android/iOS
      /// </param>
        protected BasicSetup(Platform platform)
        {
            AppManager.AppManager.Platform = platform;
        }

        /// <summary>
        /// Setup to test
        /// Startpage iniliZation for BeforeEachTest
        /// </summary>
        [SetUp]
        public virtual void BeforeEachTest()
        {
            AppManager.AppManager.StartApp();
         
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        ///  Enters text into a matching element that supports it.
        /// Enters text into the view.
        /// In an iOS application, Xamarin.UITest will enter the text using the soft keyboard.
        /// In contrast, Xamarin.UITest won't use the Android keyboard, it will directly enter the text into the view.
        /// </summary>
        /// <param name="fstrControlID">
        /// Respective TextboxEditor AutomationId
        /// </param>
        /// <param name="fstrValue">
        /// Edit Textbox value
        /// </param>
        public void EnterTextID(string fstrControlID, string fstrValue)
        {
           // Tap Simulates a tap / touch gesture on the matched element.
            app.Tap(fstrControlID);

            // Enters text into a matching element that supports it.
            // Enters text into the view.
            // In an iOS application, Xamarin.UITest will enter the text using the soft keyboard.
            // In contrast, Xamarin.UITest won't use the Android keyboard, it will directly enter the text into the view.
            app.EnterText(fstrValue);

            // Hides keyboard if present
            app.DismissKeyboard();
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Tap Simulates a tap / touch gesture on the matched element.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        /// <param name="fstrControlID">
        /// Respective Labels AutomationId
        /// </param>
        public void Tap(string fstrControlID)
        {
            // Tap Simulates a tap / touch gesture on the matched element.
            app.Tap(fstrControlID);
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        ///  Scroll down until an element that matches the toQuery is shown on the screen.
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        /// <param name="fstrControlID">
        ///  Scroll down until an element that matches the toQuery is shown on the screen.
        /// </param>
        public void Scrolldown(string fstrControlID)
        {
            //Scroll down until an element that matches the toQuery is shown on the screen.
            app.ScrollDownTo(c => c.Marked(fstrControlID));
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Scrolls up on the first element matching query
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        /// <param name="fstrControlID">
        /// Scrolls up on the first element matching query.
        /// </param>
        public void ScrollUp(string fstrControlID)
        {
            //Scrolls up on the first element matching query.
            app.ScrollUpTo(c => c.Marked(fstrControlID));
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// SpalashPage Language Select Click English Button
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        public void procEnglish()
        {
            // Tap Simulates a tap / touch gesture on the matched element.
            app.Tap(c => c.Marked("AEnglish"));

            //Takes a screenshot of the app in it's current state.
            //This is used to denote test steps in the Xamarin Test Cloud.
            app.Screenshot("SplashPage_EnglishClick");

            //Wait For Some time
            Thread.Sleep(3000);
        }



        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022  
        /// SpalashPage Language Select click Arabic Button
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        public void procArabic()
        {   
            // Tap Simulates a tap / touch gesture on the matched element.
            app.Tap(c => c.Marked("AArabic"));

            //Takes a screenshot of the app in it's current state.
            //This is used to denote test steps in the Xamarin Test Cloud.
            app.Screenshot("SplashPage_ArabicClick");

            //Wait For Some time
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// StartupPage Click on the Getting started button
        /// Obsolete Date:
        /// Category:Method
        /// </summary>
        public void procGetstart()
        {
            //Only applicable Android device
            if (AppManager.AppManager.Platform == Platform.Android)
            {   
                // Tap Simulates a tap / touch gesture on the matched element.
                app.Tap(c => c.Marked("AlblGetStart"));

                //Takes a screenshot of the app in it's current state.
                //This is used to denote test steps in the Xamarin Test Cloud.
                app.Screenshot("GetStarted_Click");

                //Wait For Some time
                Thread.Sleep(2000);
            }

        }


    }
}


