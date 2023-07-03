using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
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
    public class ManifestUpdateRequest1ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonupdatecontainer { get; set; }
        public Command ButtonCancel { get; set; }
        public Command Tapmanifestrequesthistory { get; set; }
        public Command Buttonretreive { get; set; }
        public Command Buttonreset { get; set; }
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
        //To handle indicator
        private bool stackManifestUpdateRequest1 = true;
        public bool StackManifestUpdateRequest1
        {
            get { return stackManifestUpdateRequest1; }
            set
            {
                stackManifestUpdateRequest1 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackManifestUpdateRequest1");
            }
        }
        //imgManifestIcon purpose of using Image varaiable
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
        //lblManifest purpose of using Label varaiable
        private string lblmanifest = "";
        public string lblManifest
        {
            get { return lblmanifest; }
            set
            {
                lblmanifest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifest");
            }
        }
        //imgRequestIcon purpose of using Image varaiable
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
        //lblManifestForm purpose of using Label varaiable
        private string lblmanifestForm = "";
        public string lblManifestForm
        {
            get { return lblmanifestForm; }
            set
            {
                lblmanifestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestForm");
            }
        }
        //lblVesselNo purpose of using Label varaiable
        private string lblvesselNo = "";
        public string lblVesselNo
        {
            get { return lblvesselNo; }
            set
            {
                lblvesselNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVesselNo");
            }
        }
        //TxtVesselNo purpose of using Textbox varaiable
        private string TxtvesselNo = "";
        public string TxtVesselNo
        {
            get { return TxtvesselNo; }
            set
            {
                TxtvesselNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVesselNo");
            }
        }
        //lblVoyageNo purpose of using Label varaiable
        private string lblvoyageNo = "";
        public string lblVoyageNo
        {
            get { return lblvoyageNo; }
            set
            {
                lblvoyageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVoyageNo");
            }
        }
        //TxtVoyageNo purpose of using Textbox varaiable
        private string TxtvoyageNo = "";
        public string TxtVoyageNo
        {
            get { return TxtvoyageNo; }
            set
            {
                TxtvoyageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVoyageNo");
            }
        }
        //lblBOLNo purpose of using Label varaiable
        private string lblbOLNo = "";
        public string lblBOLNo
        {
            get { return lblbOLNo; }
            set
            {
                lblbOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOLNo");
            }
        }
        //TxtBOLNo purpose of using Textbox varaiable
        private string TxtbOLNo = "";
        public string TxtBOLNo
        {
            get { return TxtbOLNo; }
            set
            {
                TxtbOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOLNo");
            }
        }
        //BtnReset purpose of using Button varaiable
        private string Btnreset = "";
        public string BtnReset
        {
            get { return Btnreset; }
            set
            {
                Btnreset = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnReset");
            }
        }
        //BtnNext purpose of using Button varaiable
        private string Btnnext = "";
        public string BtnNext
        {
            get { return Btnnext; }
            set
            {
                Btnnext = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnNext");
            }
        }
        //imgHistoryIcon purpose of using Image varaiable
        private string imghistoryIcon = "";
        public string imgHistoryIcon
        {
            get { return imghistoryIcon; }
            set
            {
                imghistoryIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgHistoryIcon");
            }
        }
        //lblRequestHistory purpose of using Label varaiable
        private string lblrequestHistory = "";
        public string lblRequestHistory
        {
            get { return lblrequestHistory; }
            set
            {
                lblrequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestHistory");
            }
        }
        //MsgVesselNo purpose of using Label varaiable
        private string msgVesselNo = "";
        public string MsgVesselNo
        {
            get { return msgVesselNo; }
            set
            {
                msgVesselNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgVesselNo");
            }
        }
        //MsgVoyageNo purpose of using Label varaiable
        private string msgVoyageNo = "";
        public string MsgVoyageNo
        {
            get { return msgVoyageNo; }
            set
            {
                msgVoyageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgVoyageNo");
            }
        }
        //MsgBOLNo purpose of using Label varaiable
        private string msgBOLNo = "";
        public string MsgBOLNo
        {
            get { return msgBOLNo; }
            set
            {
                msgBOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgBOLNo");
            }
        }
        //MsgPlsProvid purpose of using Label varaiable
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
        //IsvalidatedVesselNo purpose of using Valiadtion
        private bool isvalidatedVesselNo = false;
        public bool IsvalidatedVesselNo
        {
            get { return isvalidatedVesselNo; }
            set
            {
                isvalidatedVesselNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedVesselNo");
            }
        }
        //IsvalidatedVoyageNo purpose of using Valiadtion
        private bool isvalidatedVoyageNo = false;
        public bool IsvalidatedVoyageNo
        {
            get { return isvalidatedVoyageNo; }
            set
            {
                isvalidatedVoyageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedVoyageNo");
            }
        }
        //IsvalidatedBOLNo purpose of using Valiadtion
        private bool isvalidatedBOLNo = false;
        public bool IsvalidatedBOLNo
        {
            get { return isvalidatedBOLNo; }
            set
            {
                isvalidatedBOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedBOLNo");
            }
        }
        //IsvalidatedPlsProvid purpose of using Valiadtion
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
                Buttonretreive.ChangeCanExecute();
                Tapmanifestrequesthistory.ChangeCanExecute();
                Buttonreset.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel-Constructor
        /// </summary>
        public ManifestUpdateRequest1ViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ManifestUpdateRequest1ViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonupdatecontainer = new Command(async () => await buttonupdatecontainer(), () => !IsBusy);
            ButtonCancel = new Command(async () => await buttonCancel(), () => !IsBusy);
            Tapmanifestrequesthistory = new Command(async () => await tapmanifestrequesthistory(), () => !IsBusy);
            Buttonretreive = new Command(async () => await buttonretreive(), () => !IsBusy);
            Buttonreset = new Command(async () => await buttonreset(), () => !IsBusy);
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
            
          
            imgManifestIcon = dbLayer.getCaption("imgManifest", objCMS);
            lblManifest = dbLayer.getCaption("strUpdateRequest", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblManifestForm = dbLayer.getCaption("strUpdateRequestForm", objCMS);
            lblVesselNo = dbLayer.getCaption("strVesselNumber", objCMS);
            lblVoyageNo = dbLayer.getCaption("strVoyageNumber", objCMS);
            lblBOLNo = dbLayer.getCaption("strBOL", objCMS);
            BtnReset = dbLayer.getCaption("strReset", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            MsgVesselNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgVoyageNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgBOLNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgPlsProvid = dbLayer.getCaption("strMandatory", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
        }
        /// <summary>
        /// To get buttonreset
        /// </summary>
        /// <returns></returns>
        private async Task buttonreset()
        {
            IsBusy = true;
            StackManifestUpdateRequest1 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new ManifestUpdateRequest1());
            StackManifestUpdateRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get buttonupdatecontainer
        /// </summary>
        /// <returns></returns>
        private async Task buttonupdatecontainer()
        {
            IsBusy = true;
            StackManifestUpdateRequest1 = false;
            await Hidevalidtion();
            await Task.Delay(1000);
            //  Navigation.PushAsync(new ExtraCareContainerlist());
            StackManifestUpdateRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get buttonCancel
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel()
        {
            IsBusy = true;
            StackManifestUpdateRequest1 = false;
            await Task.Delay(1000);
            // Navigation.PushAsync(new ExtraCareContainerlist());
            StackManifestUpdateRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get buttonretreive
        /// </summary>
        /// <returns></returns>
        private async Task buttonretreive()
        {
            IsBusy = true;
            StackManifestUpdateRequest1 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            var Vesselno = TxtVesselNo.ToString().Trim();
            var Voyageno = TxtVoyageNo.ToString().Trim();
            var BOLno = TxtBOLNo.ToString().Trim();
            if ((Vesselno == null) || (Vesselno == ""))
            {
                IsvalidatedVesselNo = true;
            }
            else
            {
                IsvalidatedVesselNo = false;
            }
            if ((Voyageno == null) || (Voyageno == ""))
            {
                IsvalidatedVoyageNo = true;
            }
            else
            {
                IsvalidatedVoyageNo = false;
            }
            if ((BOLno == null) || (BOLno == ""))
            {
                IsvalidatedBOLNo = true;
            }
            else
            {
                IsvalidatedBOLNo = false;
            }
            if ((Vesselno != "") && (Voyageno != "") && (BOLno != ""))
            {
                await App.Current.MainPage?.Navigation.PushAsync(new ManifestUpdateRequest2(Vesselno, Voyageno, BOLno, "N"));
            }
            StackManifestUpdateRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get tapmanifestrequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task tapmanifestrequesthistory()
        {
            IsBusy = true;
            StackManifestUpdateRequest1 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Manifest Confirmation"));
            StackManifestUpdateRequest1 = true;
            IsBusy = false;
        }

        public async Task Hidevalidtion()
        {
            IsvalidatedPlsProvid = false;
            IsvalidatedVesselNo = false;
            IsvalidatedVoyageNo = false;
            IsvalidatedBOLNo = false;
        }
    }
}