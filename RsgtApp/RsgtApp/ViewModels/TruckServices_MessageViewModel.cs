using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class TruckServices_MessageViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //GotoOK Button 
        public Command GotoOK { get; set; }
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
            }
        }
        //Indicator Color
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
            }
        }
        //imgconfirmtickIcon purpose of using image varaiable
        private string imgconfirmtickIcon = "";
        public string imgConfirmtickIcon
        {
            get { return imgconfirmtickIcon; }
            set
            {
                imgconfirmtickIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgConfirmtickIcon");
            }
        }
        //lbldearCustomer purpose of using Lable varaiable
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
        //lblrequestReceived purpose of using Lable varaiable
        private string lblrequestReceived = "";
        public string lblRequestReceived
        {
            get { return lblrequestReceived; }
            set
            {
                lblrequestReceived = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestReceived");
            }
        }
        //btnoK purpose of using Lable varaiable
        private string btnoK = "";
        public string btnOK
        {
            get { return btnoK; }
            set
            {
                btnoK = value;
                OnPropertyChanged();
                RaisePropertyChange("btnOK");
            }
        }
        //To Handel Boolen Value
        private bool terminalMesg = true;
        public bool TerminalMesg
        {
            get { return terminalMesg; }
            set
            {
                terminalMesg = value;
                OnPropertyChanged();
                RaisePropertyChange("TerminalMesg");
            }
        }
        //To Handel Boolen Value
        private bool truckMsg = true;
        public bool TruckMsg
        {
            get { return truckMsg; }
            set
            {
                truckMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("TruckMsg");
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
                GotoOK.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>

        public TruckServices_MessageViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("TruckServices_MessageViewModel");
            //To call Caption Function
            Task.Run(() => assignCms()).Wait();
            //To call Command Buttons
            GotoOK = new Command(async () => await gotooK(), () => !IsBusy);
        }
        //End-ViewModel Constructor 
        //To bind CMS captions
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM432");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM432");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM432");
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message,30000);
            }
        }
        //To assign CMS Content respect Captions
        public async void assignContent()
        {
            try
            {
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
                dbLayer.objInfoitems = objCMS;
                imgConfirmtickIcon = dbLayer.getCaption("imgConfirmTick", objCMS);
                lblDearCustomer = dbLayer.getCaption("strDearCustomer", objCMS);
                lblRequestReceived = dbLayer.getCaption("TruckServiceRequestMsg", objCMS);
                btnOK = dbLayer.getCaption("strOk", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message,3000);
            }
        }
        //go to oK Button Function
        private async Task gotooK()
        {
            try
            {
                isBusy = true;
                TerminalMesg = false;
                Application.Current.MainPage?.Navigation.PopToRootAsync();
                await Task.Delay(1000);
                isBusy = false;
                TerminalMesg = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message,3000);
            }
        }
    }
}