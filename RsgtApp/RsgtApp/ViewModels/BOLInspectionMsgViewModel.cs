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
    public class BOLInspectionMsgViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// CMS caption list
        /// </summary>
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
         
        private string strLanguage = App.gblLanguage;
        /// <summary>
        /// To create bussinessLayer Object
        /// </summary>
        BLConnect objBl = new BLConnect();
        public Command BtnBOLMsgPage { get; set; }
        public Command RequesthistoryTapped { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Twowaybinding process on Propertychange Event
        /// </summary>
        /// <param name="name">Name</param>
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// Twowaybinding process on Propertychange Event
        /// </summary>
        /// <param name="propertyname">PropertyName</param>
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
        /// <summary>
        /// Indicator Color
        /// </summary>
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
        /// <summary>
        /// Indicator Opacity
        /// </summary>
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
        /// <summary>
        /// To StackBOLGatePhotoRequest purpose of using Enable Disable varaiable
        /// </summary>
        private bool stackBOLGatePhotoRequest = true;
        public bool StackBOLGatePhotoRequest
        {
            get { return stackBOLGatePhotoRequest; }
            set
            {
                stackBOLGatePhotoRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBOLGatePhotoRequest");
            }
        }
        /// <summary>
        /// imgConfirmTickIcon purpose of using Image varaiable
        /// </summary>
        private string imgconfirmTickIcon = "";
        public string imgConfirmTickIcon
        {
            get { return imgconfirmTickIcon; }
            set
            {
                imgconfirmTickIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgConfirmTickIcon");
            }
        }
        /// <summary>
        /// lblDearCustomer purpose of using lable varaiable
        /// </summary>
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
        /// <summary>
        /// lblYourRequest purpose of using lable varaiable
        /// </summary>
        private string lblyourRequest = "";
        public string lblYourRequest
        {
            get { return lblyourRequest; }
            set
            {
                lblyourRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblYourRequest");
            }
        }
        /// <summary>
        /// lblLink purpose of using lable varaiable
        /// </summary>
        private string lbllink = "";
        public string lblLink
        {
            get { return lbllink; }
            set
            {
                lbllink = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLink");
            }
        }
        /// <summary>
        /// lblSeeThePhotos purpose of using lable varaiable
        /// </summary>
        private string lblseeThePhotos = "";
        public string lblSeeThePhotos
        {
            get { return lblseeThePhotos; }
            set
            {
                lblseeThePhotos = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSeeThePhotos");
            }
        }
        /// <summary>
        /// lblThankYou purpose of using lable varaiable
        /// </summary>
        private string lblthankYou = "";
        public string lblThankYou
        {
            get { return lblthankYou; }
            set
            {
                lblthankYou = value;
                OnPropertyChanged();
                RaisePropertyChange("lblThankYou");
            }
        }
        /// <summary>
        /// BtnOk purpose of using lable varaiable
        /// </summary>
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
        /// <summary>
        /// To Handel Boolen Value
        /// </summary>
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                BtnBOLMsgPage.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin BOL gate photo View Model Constructor Function
        /// </summary>
        public BOLInspectionMsgViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("BOLGatePhotoMsgViewModel");
            Task.Run(() => assignCms()).Wait();
            BtnBOLMsgPage = new Command(async () => await btnBOLMsgPage(), () => !IsBusy);
        }
        /// <summary>
        /// End BOL gate photo View Model Constructor Function
        /// </summary>
        /// <summary>
        ///To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM452");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM452");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To Assigncaption in Database
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
           
           
            imgConfirmTickIcon = dbLayer.getCaption("imgConformLogo", objCMS);
            lblDearCustomer = dbLayer.getCaption("strCustomer", objCMS);
            lblThankYou = dbLayer.getCaption("strThankYou", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
        }
        /// <summary>
        /// To Begin Go to BOL Page
        /// </summary>
        private async Task btnBOLMsgPage()
        {
            IsBusy = true;
            StackBOLGatePhotoRequest = false;
            await Task.Delay(1000);
            try
            {
                Application.Current.MainPage?.Navigation.PopAsync();
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
            StackBOLGatePhotoRequest = true;
            IsBusy = false;
        }
        ///To End Go to BOL Page
    }
}
