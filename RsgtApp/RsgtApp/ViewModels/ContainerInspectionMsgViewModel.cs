using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class ContainerInspectionMsgViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();

        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command BtnContListMsgPage { get; set; }
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
        /// Twowaybinding process on RaisePropertychange Event
        /// </summary>
        /// <param name="propertyname">Propertyname</param>
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        /// <summary>
        /// To declare SetProperty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backfield">Backfield</param>
        /// <param name="value">Value</param>
        /// <param name="propertyName">PropertyName</param>
        /// <returns></returns>
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
        //StackContainerListGatePhotoMsg purpose of Enable And disable Variable
        private bool stackContainerListGatePhotoMsg = true;
        public bool StackContainerListGatePhotoMsg
        {
            get { return stackContainerListGatePhotoMsg; }
            set
            {
                stackContainerListGatePhotoMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackContainerListGatePhotoMsg");
            }
        }
        //imgConfirmTickIcon purpose of Image Variable
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
        //lblDearCustomer purpose of Image Variable
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
        //lblYourRequest purpose of lable Variable
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
        //lblLink purpose of lable Variable
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
        //lblSeeThePhotos purpose of lable Variable
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
        //lblThankYou purpose of lable Variable
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
        //BtnOk purpose of lable Variable
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
                BtnContListMsgPage.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin Container gatephoto message View Model Constructor Function
        /// </summary>
        /// <param name="strBOL">BillofLading</param>
        public ContainerInspectionMsgViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ContListGatePhotoMsgViewModel");
            Task.Run(() => assignCms()).Wait();
            BtnContListMsgPage = new Command(async () => await btnContListMsgPage(), () => !IsBusy);
        }
        //Begin Container gatephoto message View Model Constructor Function
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

                    // objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To assign the caption in database
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
        /// To Go to Container Detail Page
        /// </summary>
        private async Task btnContListMsgPage()
        {
            IsBusy = true;
            StackContainerListGatePhotoMsg = false;
            await Task.Delay(1000);
            try
            {
                await Shell.Current.GoToAsync("..");
                //await App.Current.MainPage?.Navigation.PopAsync();
                // Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
            StackContainerListGatePhotoMsg = true;
            IsBusy = false;
        }
    }
}
