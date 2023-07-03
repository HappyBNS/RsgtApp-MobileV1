using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace RsgtApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        [Obsolete]
        static void Main(string[] args)
        {
            try
            {

            }
            catch (Exception ex)
            {

                string lstrError = ex.ToString();
            }
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
             UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
