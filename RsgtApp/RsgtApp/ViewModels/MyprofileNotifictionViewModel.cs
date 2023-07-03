using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
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
    public class MyprofileNotifictionViewModel : INotifyPropertyChanged
    {
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        //ButtonClickedOk Button 
        public Command ButtonClickedOk { get; set; }
        //ButtonClickedCancel Button 
        public Command ButtonClickedCancel { get; set; }
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
        //To handle Boolean Variable
        private bool StackmyprofileNotifiction = true;
        public bool StackMyprofileNotifiction
        {
            get { return StackmyprofileNotifiction; }
            set
            {
                StackmyprofileNotifiction = value;
                OnPropertyChanged();
                RaisePropertyChange("StackMyprofileNotifiction");
            }
        }
        //imgRegisterIcon purpose of using image varaiable
        public string imgRegisterIcon = "";
        public string ImgRegisterIcon
        {
            get { return imgRegisterIcon; }
            set
            {
                imgRegisterIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRegisterIcon");
            }
        }
        //lblDearCustomer purpose of using lable varaiable
        public string lblDearCustomer = "";
        public string LblDearCustomer
        {
            get { return lblDearCustomer; }
            set
            {
                lblDearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearCustomer");
            }
        }
        //lblMessage purpose of using lable varaiable
        public string lblMessage = "";
        public string LblMessage
        {
            get { return lblMessage; }
            set
            {
                lblMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessage");
            }
        }
        //btnOk purpose of using lable varaiable
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
        //btnCancel purpose of using lable varaiable
        private string btnCancel = "";
        public string BtnCancel
        {
            get { return btnCancel; }
            set
            {
                btnCancel = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnCancel");
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
                ButtonClickedOk.ChangeCanExecute();
                ButtonClickedCancel.ChangeCanExecute();
            }
        }
        string strServerSlowMsg = "";

        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        public MyprofileNotifictionViewModel()
        {
            // Caption Function
            Task.Run(() => assignCms()).Wait();
            //Appcenter Track Event handler
            Analytics.TrackEvent("MyprofileNotifictionViewModel");
            //Begin-All Command Buttons
            ButtonClickedOk = new Command(async () => await buttonClickedOk(), () => !IsBusy);
            ButtonClickedCancel = new Command(async () => await buttonClickedCancel(), () => !IsBusy);
            //End-All Command Buttons
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
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                // objCMS = await App.Database.GetCmsAsyncAccessId("RM010");
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
        public  void assignContent()
        {    
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            //dbLayer.objInfoitems = objCMS;
            ImgRegisterIcon = dbLayer.getCaption("imgRegistericon", objCMS);
            LblDearCustomer = dbLayer.getCaption("strCustomer", objCMS);
            LblMessage = dbLayer.getCaption("strRegistrationcustomertype", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            BtnCancel = dbLayer.getCaption("strCancel", objCMS);
            BtnOk = dbLayer.getCaption("strok", objCMS);
        }
        /// <summary>
        /// Ok Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonClickedOk()
        {           
                IsBusy = true;
                StackMyprofileNotifiction = false;
                await Task.Delay(1000);

            string lstrResult = objWebApi.putWebApi("UpdateRegisterUser", gblRegisteration.NewUserRegistration("MODIFY"), gblRegisteration.strLoginUser);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }

            await App.Current.MainPage?.Navigation.PushAsync(new Logout());
                StackMyprofileNotifiction = true;
                IsBusy = false;
            
        }
        /// <summary>
        /// Cancel Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonClickedCancel()
        {
            IsBusy = true;
            StackMyprofileNotifiction = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new MyProfile());
            StackMyprofileNotifiction = true;
            IsBusy = false;
        }
    }
}