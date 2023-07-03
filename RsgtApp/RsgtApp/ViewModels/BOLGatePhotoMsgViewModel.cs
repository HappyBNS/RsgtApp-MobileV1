using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class BOLGatePhotoMsgViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command BtnBOLMsgPage { get; set; }
        public Command RequesthistoryTapped { get; set; }
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
        //To StackBOLGatePhotoRequest purpose of using Enable Disable varaiable
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
        //imgConfirmTickIcon purpose of using Image varaiable
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
        //lblDearCustomer purpose of using lable varaiable
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
        //lblYourRequest purpose of using lable varaiable
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
        //lblLink purpose of using lable varaiable
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
        //lblSeeThePhotos purpose of using lable varaiable
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
        //lblThankYou purpose of using lable varaiable
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
        //BtnOk purpose of using lable varaiable
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
                BtnBOLMsgPage.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin BOL gate photo View Model Constructor Function
        /// </summary>
        /// <param name="strBaynanNo"></param>
        public BOLGatePhotoMsgViewModel(string strBaynanNo)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("BOLGatePhotoMsgViewModel");
            Task.Run(() => assignCms()).Wait();
            BtnBOLMsgPage = new Command(async () => await btnBOLMsgPage(strBaynanNo), () => !IsBusy);
        }
        //End BOL gate photo View Model Constructor Function
        /// <summary>
        /// To bind CMS captions
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
        /// <param name="strBaynanNo"></param>
        /// <returns></returns>
        private async Task btnBOLMsgPage(string strBaynanNo)
        {
            IsBusy = true;
            StackBOLGatePhotoRequest = false;
            await Task.Delay(1000);
            try
            {
                await App.Current.MainPage?.Navigation.PushAsync(new BOL("", strBaynanNo,"","","",""));
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
            StackBOLGatePhotoRequest = true;
            IsBusy = false;
        }
        //To End Go to BOL Page
    }
}
