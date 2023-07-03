using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Helpers;
using static RsgtApp.Models.Tracking;

namespace RsgtApp.ViewModels
{
    public class BasicTracking1ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       
        //To create bussinessLayer Object
        BLConnect objcon = new BLConnect();
        private List<BasicTrakingDetail> lstTracking = new List<BasicTrakingDetail>();
        WebApiMethod objWeb = new WebApiMethod();
        string strServerSlowMsg = "";
        public Command gotoTrackingresult { get; set; }
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
        //Twoway Binding Property
        private bool stackTracking = true;
        public bool StackTracking
        {
            get { return stackTracking; }
            set
            {
                stackTracking = value;
                OnPropertyChanged();
                RaisePropertyChange("StackTracking");
            }
        }
        //imgTrackIcon purpose of using image varaiable
        private string imgTrackIcon = "";
        public string ImgTrackIcon
        {
            get { return imgTrackIcon; }
            set
            {
                imgTrackIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTrackIcon");
            }
        }
        //lblTrackShipment purpose of using lable varaiable
        private string lblTrackShipment = "";
        public string LblTrackShipment
        {
            get { return lblTrackShipment; }
            set
            {
                lblTrackShipment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTrackShipment");
            }
        }
        private string txtcontainerNumber = "";
        public string txtContainerNumber
        {
            get { return txtcontainerNumber; }
            set
            {
                txtcontainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("txtContainerNumber");
            }
        }
        //btnTrack purpose of using button varaiable
        private string btnTrack = "";
        public string BtnTrack
        {
            get { return btnTrack; }
            set
            {
                btnTrack = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnTrack");
            }
        }
        //txtTrackingNumber purpose of using entiry varaiable
        private string txtTrackingNumber = "";
        public string TxtTrackingNumber
        {
            get { return txtTrackingNumber; }
            set
            {
                txtTrackingNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTrackingNumber");
            }
        }
        //btnAdvanceTrackingLogIn purpose of using button varaiable
        private string btnAdvanceTrackingLogIn = "";
        public string BtnAdvanceTrackingLogIn
        {
            get { return btnAdvanceTrackingLogIn; }
            set
            {
                btnAdvanceTrackingLogIn = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnAdvanceTrackingLogIn");
            }
        }
        //msgMandatory purpose of using Mandatory varaiable
        private bool isvisibleMandatory = false;
        public bool IsVisibleMandatory
        {
            get { return isvisibleMandatory; }
            set
            {
                isvisibleMandatory = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleMandatory");
            }
        }
        //msgMandatory purpose of using Mandatory varaiable
        private string msgMandatorys = "";
        public string MsgMandatorys
        {
            get { return msgMandatorys; }
            set
            {
                msgMandatorys = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMandatorys");
            }
        }
        //placeContainerNumber purpose of using PlaceHolder varaiable
        private string placeContainerNumber = "";
        public string PlaceContainerNumber
        {
            get { return placeContainerNumber; }
            set
            {
                placeContainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceContainerNumber");
            }
        }
        //isBusy purpose of using indicator varaiable
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoTrackingresult.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel - Constructor
        /// </summary>
        public BasicTracking1ViewModel()
        {

            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("Basic_trackingViewModel");
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
                gotoTrackingresult = new Command(async () => await Trackingresult(), () => !IsBusy);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To bind CMS  Captions
        /// </summary>
        /// <returns></returns>
        public async Task assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM010");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM010");

                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                await assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To bind CMS
        /// </summary>
        /// <returns></returns>
        public async Task assignContent()
        {
            try
            {
                await Task.Delay(1000);
                
                              
                ImgTrackIcon = dbLayer.getCaption("imgTrack", objCMS);
                LblTrackShipment = dbLayer.getCaption("strTrackYourShipment", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                MsgMandatorys = dbLayer.getCaption("strMobilepattern", objCMSMSG);
                txtTrackingNumber = dbLayer.getCaption("strTrackingNumber", objCMS);
                BtnTrack = dbLayer.getCaption("strTrack", objCMS);
                PlaceContainerNumber = dbLayer.getCaption("strContainerNumber", objCMS);
                btnAdvanceTrackingLogIn = dbLayer.getCaption("strAdvancrTracking", objCMS);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Tracking Result
        /// </summary>
        /// <returns></returns>
        private async Task Trackingresult()
        {
            IsBusy = true;
            StackTracking = false;
            IsVisibleMandatory = false;
            BLConnect objcon = new BLConnect();
            await Task.Delay(1000);
            try
            {
                if (txtContainerNumber == null) txtContainerNumber = "";
                if (txtContainerNumber != "") gblRegisteration.strContainerNo = txtContainerNumber.ToString().Trim();
                if (gblRegisteration.strContainerNo != null && gblRegisteration.strContainerNo != "")
                {
                    var lint = 0;
                    lstTracking = objcon.getBasicTrakingContainerDetail(gblRegisteration.strContainerNo.Trim().ToUpper());
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                    }

                    if (txtContainerNumber != "")
                    {
                        if (lstTracking.Count == lint)
                        {
                            IsVisibleMandatory = true;
                        }
                        else
                        {
                            await App.Current.MainPage?.Navigation.PushAsync(new Basic_Tracking_Result());
                        }
                    }
                }
                else
                {
                    IsVisibleMandatory = true;
                }
                IsBusy = false;
                StackTracking = true;
            }
            catch (Exception ex)
            {
                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                   App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

    } 
}
