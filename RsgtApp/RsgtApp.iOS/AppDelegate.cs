using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;


using System.Diagnostics;
using System.Threading.Tasks;
using RsgtApp.iOS.Extensions;
using RsgtApp.iOS.Services;
using RsgtApp.Services;
using UserNotifications;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RsgtApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //



        INotificationActionService _notificationActionService;
        INotificationRegistrationService _notificationRegistrationService;
        IDeviceInstallationService _deviceInstallationService;

        INotificationActionService NotificationActionService
            => _notificationActionService ??
                (_notificationActionService =
                ServiceContainer.Resolve<INotificationActionService>());

        INotificationRegistrationService NotificationRegistrationService
            => _notificationRegistrationService ??
                (_notificationRegistrationService =
                ServiceContainer.Resolve<INotificationRegistrationService>());

        IDeviceInstallationService DeviceInstallationService
            => _deviceInstallationService ??
                (_deviceInstallationService =
                ServiceContainer.Resolve<IDeviceInstallationService>());

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            //20221110 Line 58 to Line 68 Vengatesh And Baskar
#if ENABLE_TEST_CLOUD
    Xamarin.Calabash.Start();
#endif
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
                // http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
                if (null != e.View.AutomationId)
                {
                    e.NativeView.AccessibilityIdentifier = e.View.AutomationId;
                }
            };
            //20221110 Line 58 to Line 68 Vengatesh And Baskar




            Bootstrap.Begin(() => new DeviceInstallationService());
            if (DeviceInstallationService.NotificationsSupported)
            {
                UNUserNotificationCenter.Current.RequestAuthorization(
                        UNAuthorizationOptions.Alert |
                        UNAuthorizationOptions.Badge |
                        UNAuthorizationOptions.Sound,
                        (approvalGranted, error) =>
                        {
                            if (approvalGranted && error == null)
                                RegisterForRemoteNotifications();
                        });
            }

            // To hide All back button 
           // UIBarButtonItem.Appearance.SetBackButtonTitlePositionAdjustment(new UIOffset(-100, -60), UIBarMetrics.Default);

            // To hide back button text handled by Gokul on 20220906
            var attribute = new UITextAttributes();
            attribute.TextColor = UIColor.Clear;
            UIBarButtonItem.Appearance.SetTitleTextAttributes(attribute, UIControlState.Normal);
            UIBarButtonItem.Appearance.SetTitleTextAttributes(attribute, UIControlState.Highlighted);
           

            LoadApplication(new App());

            using (var userInfo = options?.ObjectForKey(UIApplication.LaunchOptionsRemoteNotificationKey) as NSDictionary)
                ProcessNotificationActions(userInfo);

            return base.FinishedLaunching(app, options);


        }
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
           => CompleteRegistrationAsync(deviceToken).ContinueWith((task)
           =>
           { if (task.IsFaulted) throw task.Exception; });

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
            => ProcessNotificationActions(userInfo);

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
            => Debug.WriteLine(error.Description);

        void RegisterForRemoteNotifications()
        {
            //MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
            //        UIUserNotificationType.Alert |
            //        UIUserNotificationType.Badge |
            //        UIUserNotificationType.Sound,
            //        new NSSet());

            //    UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
            //    UIApplication.SharedApplication.RegisterForRemoteNotifications();
            //});

            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                (granted, error) =>
                {
                    if (granted)
                        MainThread.BeginInvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);
                });

        }

        Task CompleteRegistrationAsync(NSData deviceToken)
        {
            DeviceInstallationService.Token = deviceToken.ToHexString();
            return NotificationRegistrationService.RefreshRegistrationAsync();
        }

        void ProcessNotificationActions(NSDictionary userInfo)
        {
            if (userInfo == null)
                return;

            try
            {
                var actionValue = userInfo.ObjectForKey(new NSString("action")) as NSString;

                if (!string.IsNullOrWhiteSpace(actionValue?.Description))
                    NotificationActionService.TriggerAction(actionValue.Description);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
