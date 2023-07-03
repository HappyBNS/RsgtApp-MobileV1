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
   public class MyProfileMessagePageViewModel : INotifyPropertyChanged
    {
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //ButtonClicked Button 
        public Command ButtonClicked { get; set; }
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
        //To handle Boolen variable
        private bool stackMyProfileMsg = true;
        public bool StackMyProfileMsg
        {
            get { return stackMyProfileMsg; }
            set
            {
                stackMyProfileMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackMyProfileMsg");
            }
        }
        //imgRegisterIcons purpose of using image varaiable
        private string imgRegisterIcons = "";
        public string ImgRegisterIcons
        {
            get { return imgRegisterIcons; }
            set
            {
                imgRegisterIcons = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRegisterIcons");
            }
        }
        //lblDearCustomers purpose of using textbox varaiable
        private string lblDearCustomers = "";
        public string LblDearCustomers
        {
            get { return lblDearCustomers; }
            set
            {
                lblDearCustomers = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearCustomers");
            }
        }
        //lblMessages purpose of using textbox varaiable
        private string lblMessages = "";
        public string LblMessages
        {
            get { return lblMessages; }
            set
            {
                lblMessages = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessages");
            }
        }
        //btnOk purpose of using textbox varaiable
        private string btnOk = "";
        public string BtnOk
        {
            get { return btnOk; }
            set
            {
                btnOk = value;
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
                ButtonClicked.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        public MyProfileMessagePageViewModel()
        {
            //Caption Function
            Task.Run(() => assignCms()).Wait();
            //Appcenter Track Event handler
            Analytics.TrackEvent("MyProfileMessagePageViewModel");
            //Command Buttons
            ButtonClicked = new Command(async () => await buttonClicked(), () => !IsBusy);
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM019");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM019");
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
        /// To assign CMS Content respect Captions
        /// </summary>
        public void assignContent()
        {
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}      
            ImgRegisterIcons = dbLayer.getCaption("imgRegistericon", objCMS);
            LblDearCustomers = dbLayer.getCaption("strCustomer", objCMS);
            LblMessages = dbLayer.getCaption("strUpdateSuccessfully", objCMS);
            BtnOk = dbLayer.getCaption("strok", objCMS);
        }
        /// <summary>
        /// buttonClicked Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonClicked ()
        {
            IsBusy = true;
            StackMyProfileMsg = false;
            await Task.Delay(1000);
            Application.Current.MainPage?.Navigation.PopAsync();
            Application.Current.MainPage = new AppShell();
            StackMyProfileMsg = true;
            IsBusy = false;
        }
    }
}