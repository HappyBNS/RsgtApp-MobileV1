using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RsgtApp.Services;
using Firebase.Messaging;

namespace RsgtApp.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })] 
    public class PushNotificationFirebaseMessagingService : FirebaseMessagingService
    {
        IRsgtAppNotificationActionService _notificationActionService;
        INotificationRegistrationService _notificationRegistrationService;
        IDeviceInstallationService _deviceInstallationService;

        IRsgtAppNotificationActionService NotificationActionService
          => _notificationActionService ??
              (_notificationActionService =
              ServiceContainer.Resolve<IRsgtAppNotificationActionService>());

        INotificationRegistrationService NotificationRegistrationService
            => _notificationRegistrationService ??
                (_notificationRegistrationService =
                ServiceContainer.Resolve<INotificationRegistrationService>());

        IDeviceInstallationService DeviceInstallationService
            => _deviceInstallationService ??
                (_deviceInstallationService =
                ServiceContainer.Resolve<IDeviceInstallationService>());

        public override void OnNewToken(string token)
        {
            DeviceInstallationService.Token = token;

            NotificationRegistrationService.RefreshRegistrationAsync()
                .ContinueWith((task) => { if (task.IsFaulted) throw task.Exception; });
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            if (message.Data.TryGetValue("action", out var messageAction))
                NotificationActionService.TriggerAction(messageAction);
        }


    }
}