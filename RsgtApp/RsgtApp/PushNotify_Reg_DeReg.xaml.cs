using System;
using System.Collections.Generic;
using System.ComponentModel; // Changes 20220625
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials; // Changes 20220625
using RsgtApp.Services;  // Changes 20220625

namespace RsgtApp
{
    /*
     * 
     * 
    */

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PushNotify_Reg_DeReg : ContentPage
    {
        readonly INotificationRegistrationService _notificationRegistrationService;
        public PushNotify_Reg_DeReg()
        {
            InitializeComponent();
            _notificationRegistrationService = ServiceContainer.Resolve<INotificationRegistrationService>();

        }
        void RegisterButtonClicked(object sender, EventArgs e)
       => _notificationRegistrationService.RegisterDeviceAsync().ContinueWith((task)
       => {
           ShowAlert(task.IsFaulted ? task.Exception.Message : $"Device registered");
       });

        void DeregisterButtonClicked(object sender, EventArgs e)
         => _notificationRegistrationService.DeregisterDeviceAsync().ContinueWith((task)
        => {
            ShowAlert(task.IsFaulted ? task.Exception.Message : $"Device deregistered");
        });

        void ShowAlert(string message)
            => MainThread.BeginInvokeOnMainThread(()
                => DisplayAlert("PushDemo", message, "OK").ContinueWith((task)
                    => { if (task.IsFaulted) throw task.Exception; }));

    }
}