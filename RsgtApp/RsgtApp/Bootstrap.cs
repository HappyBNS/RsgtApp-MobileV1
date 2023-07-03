using System;
using System.Collections.Generic;
using System.Text;
using RsgtApp.Services;

namespace RsgtApp
{
    public static class Bootstrap
    {
        /*
         * The Begin method will be called by each platform when the app launches passing in a platform-specific 
         * implementation of IDeviceInstallationService.
         * 
         * The NotificationRegistrationService apiKey constructor argument is only required if you chose to complete the 
         * Authenticate clients using an API Key section.
         * 
         * IDeviceInstallationService (Service Folder) Interface used
         * IRsgtAppNotificationActionService(Service Folder) Interface used
         * INotificationRegistrationService(Service Folder) Interface used
         * NotificationRegistrationService (Service Folder) Class used
         * 
        */
        public static void Begin(Func<IDeviceInstallationService> deviceInstallationService)
        {
            ServiceContainer.Register(deviceInstallationService);

            ServiceContainer.Register<IRsgtAppNotificationActionService>(() => new RsgtAppNotificationActionService());

            ServiceContainer.Register<INotificationRegistrationService>(()
                => new NotificationRegistrationService(
                    Config.BackendServiceEndpoint,
                    Config.ApiKey));
        }
    }
}
