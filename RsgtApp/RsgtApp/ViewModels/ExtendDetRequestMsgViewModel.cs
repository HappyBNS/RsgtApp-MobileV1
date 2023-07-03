using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class ExtendDetRequestMsgViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();

        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();

        public Command BacktoMainPage { get; set; }

        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        protected bool SetProperty<T>(ref T backfield, T value,
        [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //Indicator Color
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGColor");
            }
        }
        //Indicator Opacity
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGOpacity");
            }
        }
        //To handle Boolean
        private bool _StackExtendDetRequestMsg = true;
        public bool StackExtendDetRequestMsg
        {
            get { return _StackExtendDetRequestMsg; }
            set
            {
                _StackExtendDetRequestMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackExtendDetRequestMsg");
            }
        }

        private string _ImgConfirmTickIcon = "";
        public string ImgConfirmTickIcon
        {
            get { return _ImgConfirmTickIcon; }
            set
            {
                _ImgConfirmTickIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgConfirmTickIcon");
            }
        }
        private string _LblDearCustomer = "";
        public string LblDearCustomer
        {
            get { return _LblDearCustomer; }
            set
            {
                _LblDearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearCustomer");
            }
        }
        private string _LblRequestMsg = "";
        public string LblRequestMsg
        {
            get { return _LblRequestMsg; }
            set
            {
                _LblRequestMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRequestMsg");
            }
        }
        private string _BtnOk = "";
        public string BtnOk
        {
            get { return _BtnOk; }
            set
            {
                _BtnOk = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnOk");
            }
        }
        //To Handle Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                BacktoMainPage.ChangeCanExecute();
            }
        }
        public ExtendDetRequestMsgViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ExtendDetPopulateContainerListViewModel");
            Task.Run(() => assignCms()).Wait();
            BacktoMainPage = new Command(async () => await backtoMainPage(), () => !IsBusy);
        }
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM467");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM467");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                //objCMSMSG = await dbLayer.LoadContent("RM026");
                assignContent();
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        public async void assignContent()
        {
            await Task.Delay(1000);
            ImgConfirmTickIcon = dbLayer.getCaption("imgTick", objCMS);
            LblDearCustomer = dbLayer.getCaption("strDearCustomer", objCMS);
            LblRequestMsg = dbLayer.getCaption("strRequestsubmittedMsg", objCMS);
            BtnOk = dbLayer.getCaption("strok", objCMS);
        }
        public async Task backtoMainPage()
        {
            IsBusy = true;
            StackExtendDetRequestMsg = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            StackExtendDetRequestMsg = true;
            IsBusy = false;
        }

    }
}
