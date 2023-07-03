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
    public class DamagePopupMessageViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //Damagepopup Button 
        public Command Damagepopup { get; set; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on RaisePropertyChange Event
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
        private bool stackDamagepopupMessage = true;
        public bool StackDamagepopupMessage
        {
            get { return stackDamagepopupMessage; }
            set
            {
                stackDamagepopupMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDamagepopupMessage");
            }
        }
        //imgRegisterIcon purpose of using image varaiable
        private string imgRegisterIcon = "";
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
        //lbldamageGoodDetails purpose of using Label varaiable
        private string lbldamageGoodDetails = "";
        public string lblDamageGoodDetails
        {
            get { return lbldamageGoodDetails; }
            set
            {
                lbldamageGoodDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDamageGoodDetails");
            }
        }
        //lblmessage purpose of using Label varaiable
        private string lblmessage = "";
        public string lblMessage
        {
            get { return lblmessage; }
            set
            {
                lblmessage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMessage");
            }
        }
        //btnOk purpose of using image varaiable
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
        //To handle Boolen variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Damagepopup.ChangeCanExecute();
            }
        }
        //Declare variable 
        private string lstrFlag = "";
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="fstrFlag"></param>
        public DamagePopupMessageViewModel(string fstrFlag)
        {
            //Appcenter Track Event handler
            lstrFlag = fstrFlag;
            //Appcenter Track Event handler
            Analytics.TrackEvent("DamagePopupMessageViewModel");
            //Caption Function
            Task.Run(() => assignCms()).Wait();
            //Begin-All Command Buttons
            Damagepopup = new Command(async () => await damagepopup(), () => !IsBusy);
            //End-All Command Buttons
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM013");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM013");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM416");
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
        public async void assignContent()
        {
            IsBusy = true;
            StackDamagepopupMessage = false;
            await Task.Delay(1000);
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            dbLayer.objInfoitems = objCMS;
            ImgRegisterIcon = dbLayer.getCaption("imgRegister", objCMS);
            lblDamageGoodDetails = dbLayer.getCaption("strDamagedetails", objCMS);
            if (lstrFlag == "A")
            {
                lblMessage = dbLayer.getCaption("strDamageGoodsAccepted", objCMS);
            }
            else
            {
                lblMessage = dbLayer.getCaption("strDamageGoodsRejected", objCMS);
            }
            BtnOk = dbLayer.getCaption("strOk", objCMS);
            StackDamagepopupMessage = true;
            IsBusy = false;
        }
        /// <summary>
        /// damagepopup Button Function
        /// </summary>
        /// <returns></returns>
        private async Task damagepopup()
        {
            IsBusy = true;
            StackDamagepopupMessage = false;
            await Task.Delay(1000);
            await Shell.Current.GoToAsync("..");
            StackDamagepopupMessage = true;
            IsBusy = false;
            // Navigation.PushAsync(new Containerlist(gblBol.strgblBolNo, "", "", "", "", "", "",""));
        }
    }
}
