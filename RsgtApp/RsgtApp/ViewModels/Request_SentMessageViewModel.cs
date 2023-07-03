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
    class Request_SentMessageViewModel : INotifyPropertyChanged
    {
        //CMS Caption List
        private List<InfoItem> objCMS = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //gotoOk button
        public Command gotoOk { get; set; }
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
        // To declare Set property
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
        //To declare boolean variable
        private bool requestEn = true;
        public bool RequestEn
        {
            get { return requestEn; }
            set
            {
                requestEn = value;
                OnPropertyChanged();
                RaisePropertyChange("RequestEn");
            }
        }
        //imgconfirmtick purpose of using image varaiable
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
        // Two way binding  IndicatorViewBGColor process on Propertychange Event
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
            }
        }
        // Two way binding  IndicatorViewBGColor process on Propertychange Event
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
            }
        }
        //lblcustomername purpose of using label varaiable
        private string lblcustomername = "";
        public string lblCustomername
        {
            get { return lblcustomername; }
            set
            {
                lblcustomername = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomername");
            }
        }
        //lblcustomername purpose of using label varaiable
        private string lbldisplayMessages = "";
        public string lblDisplayMessages
        {
            get { return lbldisplayMessages; }
            set
            {
                lbldisplayMessages = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDisplayMessages");
            }
        }
        //lblcustomername purpose of using label varaiable
        private string lblthanksmsg = "";
        public string lblThanksmsg
        {
            get { return lblthanksmsg; }
            set
            {
                lblthanksmsg = value;
                OnPropertyChanged();
                RaisePropertyChange("lblThanksmsg");
            }
        }
        //lblcustomername purpose of using label varaiable
        private string btnok = "";
        public string btnOk
        {
            get { return btnok; }
            set
            {
                btnok = value;
                OnPropertyChanged();
                RaisePropertyChange("btnOk");
            }
        }
        //To declare Boolean variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoOk.ChangeCanExecute();
            }
        }
        //Begin Request Sent Message ViewModel Constructor 
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public Request_SentMessageViewModel()
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("Request_SentMessageViewModel");
                //To Call Caption Function 
                Task.Run(() => assignCms()).Wait();
                //To call Command Buttons
                gotoOk = new Command(async () => await gotook(), () => !IsBusy);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End Request Sent Message ViewModel Constructor 
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM416");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM416");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //End assignCms function
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
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
                imgConfirmtick = dbLayer.getCaption("imgconfirmtick", objCMS);
                lblCustomername = dbLayer.getCaption("strDearCustomer", objCMS);
                lblDisplayMessages = dbLayer.getCaption("strRequestSubmitMsg", objCMS);
                lblThanksmsg = dbLayer.getCaption("strThankYou", objCMS);
                btnOk = dbLayer.getCaption("strOk", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }

        /// <summary>
        /// To click OK Button
        /// </summary>
        /// <returns></returns>
        private async Task gotook()
        {
            try
            {
                RequestEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PopToRootAsync();
                RequestEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
    }
}
