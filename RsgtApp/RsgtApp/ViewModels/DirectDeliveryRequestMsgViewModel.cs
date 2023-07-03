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
    public class DirectDeliveryRequestMsgViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command BtnDirectDeliveryMsgPage { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        // Two way binding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Two way binding process on Propertychange Event
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
        private bool stackDirectDeliveryRequestMsg = true;
        public bool StackDirectDeliveryRequestMsg
        {
            get { return stackDirectDeliveryRequestMsg; }
            set
            {
                stackDirectDeliveryRequestMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDirectDeliveryRequestMsg");
            }
        }
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
                BtnDirectDeliveryMsgPage.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel Constructor
        /// </summary>
        public DirectDeliveryRequestMsgViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DirectDeliveryRequestMsgViewModel");
            Task.Run(() => assignCms()).Wait();
            BtnDirectDeliveryMsgPage = new Command(async () => await btnDirectDeliveryMsgPage(), () => !IsBusy);

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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM458");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM458");
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
            lblRequestMsg = dbLayer.getCaption("strDirectDeliveryMsg", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
        }
        /// <summary>
        /// To go to Main page
        /// </summary>
        /// <returns></returns>
        private async Task btnDirectDeliveryMsgPage()
        {
            IsBusy = true;
            StackDirectDeliveryRequestMsg = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            StackDirectDeliveryRequestMsg = true;
            IsBusy = false;
        }
    }
}
