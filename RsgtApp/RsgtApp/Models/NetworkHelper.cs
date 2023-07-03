using Android.Content;
using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkHelper))]
namespace RsgtApp.BusinessLayer
{


    public class NetworkHelper : INetwork
    {
        Context context = Android.App.Application.Context;

        [Obsolete]
        public bool IsConnected()
        {
            return NetworkConnectivity.IsConnected(context);
        }

        public bool IsConnectedFast()
        {
            return NetworkConnectivity.IsConnectedFast(context);
        }
    }

}
