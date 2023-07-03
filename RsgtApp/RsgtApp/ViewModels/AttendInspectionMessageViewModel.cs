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
    public class AttendInspectionMessageViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command BtnAttendInspectionMsgPage { get; set; }
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
        private bool stackAttendInspectionMessage = true;
        public bool StackAttendInspectionMessage
        {
            get { return stackAttendInspectionMessage; }
            set
            {
                stackAttendInspectionMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("StackAttendInspectionMessage");
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
                BtnAttendInspectionMsgPage.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public AttendInspectionMessageViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("AttendInspectionMessageViewModel");
            Task.Run(() => assignCms()).Wait();
            BtnAttendInspectionMsgPage = new Command(async () => await btnAttendInspectionMsgPage(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM459");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM459");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To bind cms
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
           
            imgConfirmtick = dbLayer.getCaption("imgConformLogo", objCMS);
            lblDearCustomer = dbLayer.getCaption("strCustomer", objCMS);
            lblRequestMsg = dbLayer.getCaption("strAttendInspectionMsg", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
        }
        /// <summary>
        /// To got to Back Function
        /// </summary>
        /// <returns></returns>
       private async Task btnAttendInspectionMsgPage()
        {
            IsBusy = true;
            StackAttendInspectionMessage = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            StackAttendInspectionMessage = true;
            IsBusy = false;   
        }
    }
}
