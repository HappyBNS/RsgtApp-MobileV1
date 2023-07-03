using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
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
    public class ExtendDetentionMainViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();

        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();

        public Command ByContainerRequest { get; set; }
        public Command ByBOLrequest { get; set; }
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
        private bool _StackExtendDetentionMain = true;
        public bool StackExtendDetentionMain
        {
            get { return _StackExtendDetentionMain; }
            set
            {
                _StackExtendDetentionMain = value;
                OnPropertyChanged();
                RaisePropertyChange("StackExtendDetentionMain");
            }
        }
        //ImgDetentionIcon purpose of using Image varaiable
        private string _ImgDetentionIcon = "";
        public string ImgDetentionIcon
        {
            get { return _ImgDetentionIcon; }
            set
            {
                _ImgDetentionIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDetentionIcon");
            }
        }
        //LblExtendDetention purpose of using label varaiable
        private string _LblExtendDetention = "";
        public string LblExtendDetention
        {
            get { return _LblExtendDetention; }
            set
            {
                _LblExtendDetention = value;
                OnPropertyChanged();
                RaisePropertyChange("LblExtendDetention");
            }
        }
        //ImgContainer purpose of using Image varaiable
        private string _ImgContainer = "";
        public string ImgContainer
        {
            get { return _ImgContainer; }
            set
            {
                _ImgContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgContainer");
            }
        }
        //LblByContainers purpose of using label varaiable
        private string _LblByContainers = "";
        public string LblByContainers
        {
            get { return _LblByContainers; }
            set
            {
                _LblByContainers = value;
                OnPropertyChanged();
                RaisePropertyChange("LblByContainers");
            }
        }
        //ImgBLIcon purpose of using Image varaiable
        private string _ImgBLIcon = "";
        public string ImgBLIcon
        {
            get { return _ImgBLIcon; }
            set
            {
                _ImgBLIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBLIcon");
            }
        }
        //LblByBol purpose of using label varaiable
        private string _LblByBol = "";
        public string LblByBol
        {
            get { return _LblByBol; }
            set
            {
                _LblByBol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblByBol");
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
                ByContainerRequest.ChangeCanExecute();
                ByBOLrequest.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel - Constructor
        /// </summary>
        public ExtendDetentionMainViewModel()
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("ExtendDetentionMainViewModel");
                Task.Run(() => assignCms()).Wait();
                ByContainerRequest = new Command(async () => await byContainerRequest(), () => !IsBusy);
                ByBOLrequest = new Command(async () => await byBOLrequest(), () => !IsBusy);
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
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

            ImgDetentionIcon = dbLayer.getCaption("imgDetention", objCMS);
            LblExtendDetention = dbLayer.getCaption("strExtendDetention", objCMS);
            ImgContainer = dbLayer.getCaption("imgContainer", objCMS);
            LblByContainers = dbLayer.getCaption("strByContainers", objCMS);
            ImgBLIcon = dbLayer.getCaption("imgBOL", objCMS);
            LblByBol = dbLayer.getCaption("strByBillofLadings", objCMS);
        }
        /// <summary>
        /// To go to Container Request
        /// </summary>
        /// <returns></returns>
        private async Task byContainerRequest()
        {
            IsBusy = true;
            StackExtendDetentionMain = false;
            await Task.Delay(1000);
            App.Current.MainPage?.Navigation.PushAsync(new ExtendDetentionAddcontainer("Y"));
            StackExtendDetentionMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to BOL Request
        /// </summary>
        /// <returns></returns>
        private async Task byBOLrequest()
        {
            IsBusy = true;
            StackExtendDetentionMain = false;
            await Task.Delay(1000);
            App.Current.MainPage?.Navigation.PushAsync(new ExtendDetentionAddcontainer("N"));
            StackExtendDetentionMain = true;
            IsBusy = false;
        }
    }
}
