using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class ManifestRequestMsgViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command BtnManifestRequestMsgPage { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on Propertychange Event
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
        //To handle indicator
        private bool stackManifestRequestMsg = true;
        public bool StackManifestRequestMsg
        {
            get { return stackManifestRequestMsg; }
            set
            {
                stackManifestRequestMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackManifestRequestMsg");
            }
        }
        //imgConfirmtick purpose of using Image varaiable
        private string imgconfirmtick = "";
        public string imgConfirmtick
        {
            get { return imgconfirmtick; }
            set
            {
                imgconfirmtick = value;
                OnPropertyChanged();
                RaisePropertyChange("imgConfirmtick");
            }
        }
        //lblDearCustomer purpose of using Label varaiable
        private string lbldearCustomer = "";
        public string lblDearCustomer
        {
            get { return lbldearCustomer; }
            set
            {
                lbldearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDearCustomer");
            }
        }
        //lblRequestMsg purpose of using Label varaiable
        private string lblrequestMsg = "";
        public string lblRequestMsg
        {
            get { return lblrequestMsg; }
            set
            {
                lblrequestMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestMsg");
            }
        }
        //BtnOk purpose of using Button varaiable
        private string Btnok = "";
        public string BtnOk
        {
            get { return Btnok; }
            set
            {
                Btnok = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnOk");
            }
        }
        //To Handel Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                BtnManifestRequestMsgPage.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public ManifestRequestMsgViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ManifestRequestMsgViewModel");
            Task.Run(() => assignCms()).Wait();
            BtnManifestRequestMsgPage = new Command(async () => await btnManifestRequestMsgPage(), () => !IsBusy);
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM454");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM454");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            imgConfirmtick = dbLayer.getCaption("imgConformLogo", objCMS);
            lblDearCustomer = dbLayer.getCaption("strCustomer", objCMS);
            lblRequestMsg = dbLayer.getCaption("strManifestConfirmationMsg", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
        }
        /// <summary>
        /// To get btnManifestRequestMsgPage
        /// </summary>
        /// <returns></returns>
        private async Task btnManifestRequestMsgPage()
        {
            IsBusy = true;
            StackManifestRequestMsg = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            StackManifestRequestMsg = true;
            IsBusy = false;
        }
    }
}