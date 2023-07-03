using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RsgtApp.BusinessLayer;

using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.Themes;
using System.Net.Http;
using RsgtApp.Views;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using static RsgtApp.Models.Tracking;

namespace RsgtApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        BLConnect objBl = new BLConnect();
        public Command OnTappedVesselschedule { get; set; }
        public Command OnTappedLogin { get; set; }
        public Command gotoBasicTracking { get; set; }
        string strServerSlowMsg = "";
        //To create Collection Object used ObservableCollection
        public ObservableCollection<BasicTrakingDetail> lstTracking { get; }
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
        private bool stackManiPage = true;
        public bool StackManiPage
        {
            get { return stackManiPage; }
            set
            {
                stackManiPage = value;
                OnPropertyChanged();
                RaisePropertyChange("StackManiPage");
            }
        }
        private string lbltitle = "";
        public string lblTitle
        {
            get { return lbltitle; }
            set
            {
                lbltitle = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTitle");
            }
        }
        private string lbltrackShip = "";
        public string lblTrackShip
        {
            get { return lbltrackShip; }
            set
            {
                lbltrackShip = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTrackShip");
            }
        }
        private string txtcontainerNo = "";
        public string TxtcontainerNo
        {
            get { return txtcontainerNo; }
            set
            {
                txtcontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtcontainerNo");
            }
        }
        private string placecontainerNo = "";
        public string PlacecontainerNo
        {
            get { return placecontainerNo; }
            set
            {
                placecontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacecontainerNo");
            }
        }
        private string msgcontainer = "";
        public string Msgcontainer
        {
            get { return msgcontainer; }
            set
            {
                msgcontainer = value;
                OnPropertyChanged();
                RaisePropertyChange("Msgcontainer");
            }
        }
        private string lbltrack = "";
        public string lblTrack
        {
            get { return lbltrack; }
            set
            {
                lbltrack = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTrack");
            }
        }
        private string imgvessel = "";
        public string imgVessel
        {
            get { return imgvessel; }
            set
            {
                imgvessel = value;
                OnPropertyChanged();
                RaisePropertyChange("imgVessel");
            }
        }
        private string lblvesselsch = "";
        public string lblVesselsch
        {
            get { return lblvesselsch; }
            set
            {
                lblvesselsch = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVesselsch");
            }
        }
        private string imglogin = "";
        public string imgLogin
        {
            get { return imglogin; }
            set
            {
                imglogin = value;
                OnPropertyChanged();
                RaisePropertyChange("imgLogin");
            }
        }
        private string lbllogin = "";
        public string lblLogin
        {
            get { return lbllogin; }
            set
            {
                lbllogin = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLogin");
            }
        }
        private string imgvessel2 = "";
        public string imgVessel2
        {
            get { return imgvessel2; }
            set
            {
                imgvessel2 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgVessel2");
            }
        }
        private string lblvesselsch2 = "";
        public string lblVesselsch2
        {
            get { return lblvesselsch2; }
            set
            {
                lblvesselsch2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVesselsch2");
            }
        }

        private bool msgContainer = false;
        public bool MsgContainer
        {
            get { return msgContainer; }
            set
            {
                msgContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgContainer");
            }
        }
        private bool btnsbeforeLogin = true;
        public bool btnsBeforeLogin
        {
            get { return btnsbeforeLogin; }
            set
            {
                btnsbeforeLogin = value;
                OnPropertyChanged();
                RaisePropertyChange("btnsBeforeLogin");
            }
        }
        private bool btnsafterLogin = false;
        public bool btnsAfterLogin
        {
            get { return btnsafterLogin; }
            set
            {
                btnsafterLogin = value;
                OnPropertyChanged();
                RaisePropertyChange("btnsAfterLogin");
            }
        }
        private bool tapafter = true;
        public bool Tapafter
        {
            get { return tapafter; }
            set
            {
                tapafter = value;
                OnPropertyChanged();
                RaisePropertyChange("Tapafter");
            }
        }
        private bool taplogin = true;
        public bool Taplogin
        {
            get { return taplogin; }
            set
            {
                taplogin = value;
                OnPropertyChanged();
                RaisePropertyChange("Taplogin");
            }
        }
        private bool tapbefore = true;
        public bool Tapbefore
        {
            get { return tapbefore; }
            set
            {
                tapbefore = value;
                OnPropertyChanged();
                RaisePropertyChange("Tapbefore");
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                OnTappedLogin.ChangeCanExecute();
                OnTappedVesselschedule.ChangeCanExecute();
                gotoBasicTracking.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public MainPageViewModel()
        {

            Task.Run(() => assignCms()).Wait();
           // Task.Run(() => assignCmsMsg()).Wait();

            //StackManiPage.IsEnabled = true;
            
            
            lstTracking = new ObservableCollection<BasicTrakingDetail>();
            OnTappedLogin = new Command(async () => await OntappedLogin(), () => !IsBusy);
            OnTappedVesselschedule = new Command(async () => await OntappedVesselschedule(), () => !IsBusy);
            gotoBasicTracking = new Command(async () => await gotobasicTracking(), () => !IsBusy);

            Task.Run(() => checkLogin()).Wait();
        }
        /// <summary>
        /// To go to check Login
        /// </summary>
        private async void checkLogin()
        {
            if (gblRegisteration.strLoginUser != null)
            {
                if (gblRegisteration.strLoginUser.Length > 0)
                {
                    btnsBeforeLogin = false;
                    btnsAfterLogin = true;
                }

            }
            else
            {
                btnsBeforeLogin = true;
                btnsAfterLogin = false;
            }
            await Task.Delay(1000);
         
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                // objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM004");
                }
                await Task.Delay(1000);
                assignContent();

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }

        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCmsMsg()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                //objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                msgcontainer = dbLayer.getCaption("strEmailpattern",  objCMSMSG);

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
           
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
              
            //}

            PlacecontainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
            lblLogin = dbLayer.getCaption("strLoginA", objCMS);
            lblTrack = dbLayer.getCaption("strTrack", objCMS);
            lblTrackShip = dbLayer.getCaption("strTrackYourShipment", objCMS);
            lblVesselsch = dbLayer.getCaption("strVesselSchedule", objCMS);
            imgLogin = dbLayer.getCaption("imgLoginiconwhitepng", objCMS);
            imgVessel = dbLayer.getCaption("imgvesselschedulehomepng", objCMS);
            lblTitle = dbLayer.getCaption("strTitle", objCMS);
            lblVesselsch2 = dbLayer.getCaption("strVesselSchedule", objCMS);
            imgVessel2 = dbLayer.getCaption("imgvesselschedulehomepng", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            //imglogowhite.Source = dbLayer.getCaption("imglogowhitepng", objCMS);
            //imgTrack.Source = dbLayer.getCaption("imgtrackiconpng");

            await Task.Delay(1000);
            string result = await SecureStorage.GetAsync("ApplyTheme");

            if (result == null)
            {
                App.gblSelectedTheme = "1";
                await SecureStorage.SetAsync("ApplyTheme", "1");
            }
            else
            {
                App.gblSelectedTheme = result.ToString();
            }
          
          //  StackManiPage = true;

            setThemes();


            //  BioLogin();

            //Begin - Code for Back Button - 20220429
            //2.When Back button clicked in other pages like PageRegistraion1.aspx,PageRegistration2.aspx,MyProfile1.aspx,MyProfile2.aspx etc... screen should navigate each page by page
            SecureStorage.Remove("V");
            //End - Code for Back Button - 20220429
        }
        /// <summary>
        /// To Set Theme Function
        /// </summary>
        private void setThemes()
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                switch (App.gblSelectedTheme)
                {
                    case "2":
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case "3":
                        mergedDictionaries.Add(new GreenTheme());
                        break;
                    case "1":
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }
        /// <summary>
        /// on clicked Vessel schedule
        /// </summary>
        /// <returns></returns>
        private async Task OntappedVesselschedule()
        {
            //Change 20220617
            //Tapbefore = false;
            //Tapafter = false;
            //// lblTrack.IsEnabled = false;
            //Taplogin = false;
            //Change 20220617
            // Begin -- 2022/06/02 - Code for Indicatorview set to true
            //StackManiPage.IsEnabled = true;
            // StackManiPage = false;

            // await Task.Delay(1000);// Change 20220623
            await App.Current.MainPage?.Navigation.PushAsync(new VesselSchedule("Inport"));
            //Begin - Code for Back Button - 20220429
            await SecureStorage.SetAsync("V", "VesselBack");
            //End - Code for Back Button - 20220429

            //StackManiPage = true;
            // StackManiPage.IsEnabled = true;

            // End -- 2022/06/02 - Code for Indicatorview set to true/false
        }
        /// <summary>
        /// go to Basic Tracking
        /// </summary>
        /// <returns></returns>
        private async Task gotobasicTracking()
        {
            //Change 20220617
            //Tapbefore = false;
            //Tapafter = false;
            //// lblTrack.IsEnabled = false;
            //Taplogin = false;
            //Change 20220617
            // Begin -- 2022/06/02 - Code for Indicatorview set to true
           // StackManiPage = false;

            await Task.Delay(1000);// Change 20220623
            int lint = 0;
            msgContainer = false;
           var objRawData = new List<BasicTrakingDetail>();
            try
            {
                gblRegisteration.strContainerNo = TxtcontainerNo.Trim().ToUpper();
                objRawData = objBl.getBasicTrakingContainerDetail(TxtcontainerNo.Trim().ToUpper());
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                if (objRawData.Count == lint)
                {
                    //Change 20220617
                    //Tapbefore = true;
                    //Tapafter = true;
                    //// lblTrack.IsEnabled = true;
                    //Taplogin = true;
                    //Change 20220617
                    msgContainer = true;
                }
                else
                {
                   await App.Current.MainPage?.Navigation.PushAsync(new Basic_Tracking_Result());

                     StackManiPage = true;
                    //mainpageActivityIndicator.IsVisible = false;
                    // End -- 2022/06/02 - Code for Indicatorview set to false
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                    // this.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                {
                   App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
                }
            }
           // StackManiPage = true;
        }
        /// <summary>
        /// On Click Login Function
        /// </summary>
        /// <returns></returns>
        private async Task OntappedLogin()
        {
            //Change 20220617
            //Tapbefore = false;
            //Tapafter = false;
            //// lblTrack.IsEnabled = false;
            //Taplogin = false;
            // StackManiPage = false;

            /* await Task.Delay(1000);*/// Change 20220623
                                        //Change 20220617

            await App.Current.MainPage?.Navigation.PushAsync(new PageLogin());
           
           // StackManiPage = true;
        }
    }
}