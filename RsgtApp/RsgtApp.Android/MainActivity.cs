using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Fingerprint;
using Android.Views;
using RsgtApp.Services;
using Android.Content;
using RsgtApp.Droid.Services;
using Firebase.Iid;
using Firebase;


namespace RsgtApp.Droid
{
    [Activity(Label = "Rsgt", LaunchMode = LaunchMode.SingleTop, Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, Android.Gms.Tasks.IOnSuccessListener
    {
        IRsgtAppNotificationActionService _notificationActionService;
        IDeviceInstallationService _deviceInstallationService;

        IRsgtAppNotificationActionService NotificationActionService => _notificationActionService ??
                (_notificationActionService =
                ServiceContainer.Resolve<IRsgtAppNotificationActionService>());

        IDeviceInstallationService DeviceInstallationService
            => _deviceInstallationService ??
                (_deviceInstallationService =
                ServiceContainer.Resolve<IDeviceInstallationService>());

        public static MainActivity MainActivityInstance { get; private set; }

        // protected readonly INavigationService NavigationService;//Gokul For Excel

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            switch (App.gblLanguage)
            {
                case "En":
                    Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Ltr;
                    break;
                case "Ar":
                    Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Rtl;
                    break;

            }
            FirebaseApp.InitializeApp(Application.Context);

            CrossFingerprint.SetCurrentActivityResolver(() => this);
            base.OnCreate(savedInstanceState);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);

            Bootstrap.Begin(() => new DeviceInstallationService());

            if (DeviceInstallationService.NotificationsSupported)
            {
                FirebaseInstanceId.GetInstance(Firebase.FirebaseApp.Instance).GetInstanceId().AddOnSuccessListener(this);
            }


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //20221110 Line 58 to Line 68 Vengatesh And Baskar
            Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
                if (!string.IsNullOrWhiteSpace(e.View.AutomationId))
                {
                    e.NativeView.ContentDescription = e.View.AutomationId;
                }
            };
            //20221110 Line 58 to Line 68 Vengatesh And Baskar



            //MainActivityInstance = this;   //20220906

            //string lstrLang = "en";
            //if (App.gblLanguage == "Ar") lstrLang = "ar";

            //Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(lstrLang);
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            //Java.Util.Locale.Default = new Java.Util.Locale(lstrLang);

            //English Mode Settings: Need to enable this for LTR swapping in English mode
            // Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Ltr;

            //Device dark mode issue solution 20220623
            AndroidX.AppCompat.App.AppCompatDelegate.DefaultNightMode = AndroidX.AppCompat.App.AppCompatDelegate.ModeNightNo;
            //localWebView.Settings.JavaScriptEnabled = true;
            //localWebView.Settings.DomStorageEnabled = true;
            LoadApplication(new App());

            ProcessNotificationActions(Intent);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            ProcessNotificationActions(intent);
        }

        public void OnSuccess(Java.Lang.Object result)
            => DeviceInstallationService.Token =
           result.Class.GetMethod("getToken").Invoke(result).ToString();


        void ProcessNotificationActions(Intent intent)
        {
            try
            {
                if (intent?.HasExtra("action") == true)
                {
                    var action = intent.GetStringExtra("action");

                    if (!string.IsNullOrEmpty(action))
                        NotificationActionService.TriggerAction(action);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


    }
}