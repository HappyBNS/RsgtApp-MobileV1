using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
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
    class ManifestEditContainerViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonupdatecontainer { get; set; }
        public Command ButtonCancel { get; set; }


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

        private bool stackManifestEditContainer = true;
        public bool StackManifestEditContainer
        {
            get { return stackManifestEditContainer; }
            set
            {
                stackManifestEditContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("StackManifestEditContainer");
            }
        }
        private string imgmanifestIcon = "";
        public string imgManifestIcon
        {
            get { return imgmanifestIcon; }
            set
            {
                imgmanifestIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgManifestIcon");
            }
        }
        private string lblmanifestUpdateRequest = "";
        public string lblManifestUpdateRequest
        {
            get { return lblmanifestUpdateRequest; }
            set
            {
                lblmanifestUpdateRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestUpdateRequest");
            }
        }
        private string imgrequestIcon = "";
        public string imgRequestIcon
        {
            get { return imgrequestIcon; }
            set
            {
                imgrequestIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRequestIcon");
            }
        }
        private string lblmanifestEditContainer = "";
        public string lblManifestEditContainer
        {
            get { return lblmanifestEditContainer; }
            set
            {
                lblmanifestEditContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestEditContainer");
            }
        }
        private string lblvesselNumber = "";
        public string lblVesselNumber
        {
            get { return lblvesselNumber; }
            set
            {
                lblvesselNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVesselNumber");
            }
        }
        private string lblvoyageNumber = "";
        public string lblVoyageNumber
        {
            get { return lblvoyageNumber; }
            set
            {
                lblvoyageNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVoyageNumber");
            }
        }
        private string lblbillofLading = "";
        public string lblBillofLading
        {
            get { return lblbillofLading; }
            set
            {
                lblbillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBillofLading");
            }
        }
        private string lblcontainerNumber = "";
        public string lblContainerNumber
        {
            get { return lblcontainerNumber; }
            set
            {
                lblcontainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerNumber");
            }
        }
        private string TxtcontainerNumber = "";
        public string TxtContainerNumber
        {
            get { return TxtcontainerNumber; }
            set
            {
                TxtcontainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainerNumber");
            }
        }
        private string Btnupdate = "";
        public string BtnUpdate
        {
            get { return Btnupdate; }
            set
            {
                Btnupdate = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnUpdate");
            }
        }
        private string Btncancel = "";
        public string BtnCancel
        {
            get { return Btncancel; }
            set
            {
                Btncancel = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnCancel");
            }
        }
        private string txtVesselNumber = "";
        public string TxtVesselNumber
        {
            get { return txtVesselNumber; }
            set
            {
                txtVesselNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVesselNumber");
            }
        }
        private string txtVoyageNumber = "";
        public string TxtVoyageNumber
        {
            get { return txtVoyageNumber; }
            set
            {
                txtVoyageNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVoyageNumber");
            }
        }
        private string txtBillofLading = "";
        public string TxtBillofLading
        {
            get { return txtBillofLading; }
            set
            {
                txtBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBillofLading");
            }
        }
        private string msgPlsProvid = "";
        public string MsgPlsProvid
        {
            get { return msgPlsProvid; }
            set
            {
                msgPlsProvid = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPlsProvid");
            }
        }
        private bool isvalidatedPlsProvid = false;
        public bool IsvalidatedPlsProvid
        {
            get { return isvalidatedPlsProvid; }
            set
            {
                isvalidatedPlsProvid = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedPlsProvid");
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
                Buttonupdatecontainer.ChangeCanExecute();
                ButtonCancel.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public ManifestEditContainerViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ManifestEditContainerViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonupdatecontainer = new Command(async () => await buttonupdatecontainer(), () => !IsBusy);
            ButtonCancel = new Command(async () => await buttonCancel(), () => !IsBusy);


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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM454");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM454");
                    objCMSMSG = await dbLayer.LoadContent("RM026");

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
            imgManifestIcon = dbLayer.getCaption("imgManifest", objCMS);
            lblManifestUpdateRequest = dbLayer.getCaption("strUpdateRequest", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblManifestEditContainer = dbLayer.getCaption("strEditContainer", objCMS);
            lblVesselNumber = dbLayer.getCaption("strVessel", objCMS);
            lblVoyageNumber = dbLayer.getCaption("strVoyage", objCMS);
            lblBillofLading = dbLayer.getCaption("strBillofLading", objCMS);
            lblContainerNumber = dbLayer.getCaption("strContainerNumber", objCMS);
            BtnUpdate = dbLayer.getCaption("strUpdate", objCMS);
            BtnCancel = dbLayer.getCaption("strCancel", objCMS);
            //MsgPlsProvid = dbLayer.getCaption("", objCMSMSG);
        }

        /// <summary>
        /// To Update Container Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonupdatecontainer()
        {
            IsBusy = true;
            StackManifestEditContainer = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ManifestContainerList("","",""));
            StackManifestEditContainer = true;
            IsBusy = false;
        }
        /// <summary>
        /// Cancel Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel()
        {
            IsBusy = true;
            StackManifestEditContainer = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ManifestContainerList("","",""));
            StackManifestEditContainer = true;
            IsBusy = false;
        }
    }
}