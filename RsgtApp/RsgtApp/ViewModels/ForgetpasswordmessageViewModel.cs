using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.BusinessLayer;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using RsgtApp.Views;

namespace RsgtApp.ViewModels
{
    public class ForgetpasswordmessageViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //Button_Clicked_Login Button
        public Command Button_Clicked_Login { get; set; }
        string strServerSlowMsg = "";
        //Property Changed Event Handler
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
        // Twowaybinding process on Propertychange Event
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
                RaisePropertyChange("IndicatorBGColor");
            }
        }
        //To handle Activity Indicator
        private bool stackForgetpassMsg = true;
        public bool StackForgetpassMsg
        {
            get { return stackForgetpassMsg; }
            set
            {
                stackForgetpassMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackForgetpassMsg");
            }
        }
        //imgrecoveryIcon purpose of using image variable
        private string imgrecoveryIcon = "";
        public string imgRecoveryIcon
        {
            get { return imgrecoveryIcon; }
            set
            {
                imgrecoveryIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRecoveryIcon");
            }
        }
        //lblcustomer1 purpose of using label variable
        private string lblcustomer1 = "";
        public string lblCustomer1
        {
            get { return lblcustomer1; }
            set
            {
                lblcustomer1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomer1");
            }
        }
        //lblcontent1 purpose of using label variable
        private string lblcontent1 = "";
        public string lblContent1
        {
            get { return lblcontent1; }
            set
            {
                lblcontent1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContent1");
            }
        }
        //btnlogin purpose of using button variable
        private string btnlogin = "";
        public string btnLogin
        {
            get { return btnlogin; }
            set
            {
                btnlogin = value;
                OnPropertyChanged();
                RaisePropertyChange("btnLogin");
            }
        }
        //To Handel Boolean Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Button_Clicked_Login.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        public ForgetpasswordmessageViewModel()
        {
            Task.Run(() => assignCms()).Wait();
            Button_Clicked_Login = new Command(async () => await button_Clicked_Login(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM004");
                }
                // objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Method is for Assign Content
        /// </summary>
        /// To assign CMS Content respect Captions
        public async void assignContent()
        {
            await Task.Delay(1000);

            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;

            //}

            imgRecoveryIcon = dbLayer.getCaption("imgRegistericon", objCMS);
            lblCustomer1 = dbLayer.getCaption("strCustomer", objCMS);
            btnLogin = dbLayer.getCaption("strLogin", objCMS);
            lblContent1 = dbLayer.getCaption("strForgetPasswordMsg", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// To Navigate button_Clicked_Login Page
        /// </summary>
        /// <returns></returns>
        private async Task button_Clicked_Login()
        {
            IsBusy = true;
            StackForgetpassMsg = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new PageLogin());
            StackForgetpassMsg = true;
            IsBusy = false;
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
        }
    }
}