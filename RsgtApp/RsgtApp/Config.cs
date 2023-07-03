using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp
{

    /*
 * Config used as a simple way to keep secrets out of source control.
 * 
 * Replace the placeholder values with your own. You should have made a note of these when you built the backend service
*/
    public static partial class Config
    {
        public static string ApiKey = "hl4bA4nB4yI0fC8fH7eT6";
        //public static string BackendServiceEndpoint = "Endpoint=sb://RSGTNotification.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=4Uh47o3M8UVrYjjytbfaFMXYZKldJu0BDwcpYrU5x9k=";

        //public static string BackendServiceEndpoint = "https://notifappapi1.azurewebsites.net/api/Notifications/requests";

        public static string BackendServiceEndpoint = "https://notifappapi1.azurewebsites.net/";
    }

}
