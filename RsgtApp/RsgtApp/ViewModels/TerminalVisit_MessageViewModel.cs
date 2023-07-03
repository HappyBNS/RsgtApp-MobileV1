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
    public class TerminalVisit_MessageViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        public Command gotoOk { get; set; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event      
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
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
        //Property Changed indicatorBGColor Event Handler
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
        //Property Changed indicatorBGOpacity Event Handler
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
        //to imgconfirmtick varible
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
        //to lbldearCustomer varible
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
        //to lblRequestSubmittedMg varible
        private string lblrequestSubmittedMg = "";
        public string lblRequestSubmittedMg
        {
            get { return lblrequestSubmittedMg; }
            set
            {
                lblrequestSubmittedMg = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestSubmittedMg");
            }
        }
        //to lblThanksYou varible
        private string lblthanksYou = "";
        public string lblThanksYou
        {
            get { return lblthanksYou; }
            set
            {
                lblthanksYou = value;
                OnPropertyChanged();
                RaisePropertyChange("lblThanksYou");
            }
        }
        //to btnOk varible
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
        //to TerminalMesg varible
        bool terminalmesgEn = false;
        public bool TerminalmesgEn
        {
            get { return terminalmesgEn; }
            set
            {
                terminalmesgEn = value;
                OnPropertyChanged();
                RaisePropertyChange("TerminalmesgEn");
            }
        }
        //to bool value assign
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
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public TerminalVisit_MessageViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("TerminalVisit_MessageViewModel");
            Task.Run(() => assignCms()).Wait();
            gotoOk = new Command(async () => await gotook(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM407");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM407");
                    // objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message,3000);
            }
        }
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
                
                imgConfirmtick = dbLayer.getCaption("imgConfirmTick", objCMS);
                lblDearCustomer = dbLayer.getCaption("strDearCustomer", objCMS);
                lblRequestSubmittedMg = dbLayer.getCaption("strRequestReportDamageContainerMsg", objCMS);
                lblThanksYou = dbLayer.getCaption("strThanksYou", objCMS);
                btnOk = dbLayer.getCaption("strok", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// To bind click the ok buttion
        /// </summary>
        private async Task gotook()
        {
            try
            {
                IsBusy = true;
                TerminalmesgEn = false;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PopToRootAsync();
                TerminalmesgEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}