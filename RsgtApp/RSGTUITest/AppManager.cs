using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.UITest;

namespace AppManager
{
    static class AppManager
    {
        /// <summary>
        /// Inilization for App setting(Android/iOS)
        /// </summary>
        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }
       
        /// <summary>
        /// To read the platforms(Android/iOS)
        /// </summary>
        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        /// <summary>
        /// StartApp For Apk Pathsettings (iOS/Android)
        /// ApkFile - Android
        /// ApkFile - UITest assembly, and then navigate down the project tree of the Android application project to find the apk file.
        /// AppBundle - iOS
        /// AppBundle - This method specifies the path to the app bundle to use when testing.
        /// DeviceIdentifier - Configures the device to use with the device identifier. This method will be described in more detail below.
        /// EnableLocalScreenshots - Enable screenshots when running tests locally. Screenshots are always enabled when tests are running in the cloud.
        /// </summary>
        public static void StartApp()
        {

           if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    // Used to run a .apk file:
                    .ApkFile(@"D:/20221203/RSGT_Mobile_v1/RsgtApp/RsgtApp.Android/bin/Debug/com.penygon.pushdemo.apk")
                    .EnableLocalScreenshots()
                    .StartApp();
            }
          

           
            // return app=ConfigureApp.iOS.AppBundle(“.. / .. / .. / RsgtApp.iOS / bin / iPhoneSimulator / Debug / RsgtApp.iOS.app").StartApp();
            /*      app = ConfigureApp
                     .iOS
                     // Used to run a .app file on an ios simulator:
                     .AppBundle("../../../RsgtApp.iOS/bin/iPhoneSimulator/Debug/RsgtApp.iOS.app")
                     .DeviceIdentifier("AD5FAD3A-C32E-4415-871F-6E0B1E0B4C8B")
                     .EnableLocalScreenshots()
                     .StartApp();
               */
        }
    }
}