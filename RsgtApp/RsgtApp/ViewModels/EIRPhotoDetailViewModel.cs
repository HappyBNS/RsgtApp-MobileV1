using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.EirRequestHistoryModel;

namespace RsgtApp.ViewModels
{
    public class EIRPhotoDetailViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      
         
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        public Command TapEIRrequest { get; set; }
        public Command TapEIRrequesthistory { get; set; }
        private string strServerSlowMsg = "";
        private List<EirRequestHistoryModelDt> lstEIRCopyImage { get; set; } = new List<EirRequestHistoryModelDt>();
        public List<EirRequestHistoryModelDt> lstEIRImage { get; set; } = new List<EirRequestHistoryModelDt>();
        private ObservableCollection<EirRequestHistoryModelDt> _lstEIRCopyImages = new ObservableCollection<EirRequestHistoryModelDt>();
        public ObservableCollection<EirRequestHistoryModelDt> lstEIRCopyImages
        {
            get { return _lstEIRCopyImages; }
            set
            {
                if (_lstEIRCopyImages == value)
                    return;

                _lstEIRCopyImages = value;
                OnPropertyChanged();
                RaisePropertyChange("lstEIRCopyImages");
            }
        }
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
        private bool stackEIRPhotoDetail = true;
        public bool StackEIRPhotoDetail
        {
            get { return stackEIRPhotoDetail; }
            set
            {
                stackEIRPhotoDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("StackEIRPhotoDetail");
            }
        }
        //imgEIRIconBlue purpose of using Image varaiable
        private string imgeIRIconBlue = "";
        public string imgEIRIconBlue
        {
            get { return imgeIRIconBlue; }
            set
            {
                imgeIRIconBlue = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEIRIconBlue");
            }
        }
        //lblEIRGateDetail purpose of using lable varaiable
        private string lbleIRGateDetail = "";
        public string lblEIRGateDetail
        {
            get { return lbleIRGateDetail; }
            set
            {
                lbleIRGateDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRGateDetail");
            }
        }
        //lblContainerNo purpose of using lable varaiable
        private string lblcontainerNo = "";
        public string lblContainerNo
        {
            get { return lblcontainerNo; }
            set
            {
                lblcontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerNo");
            }
        }
        //lblBillofLading purpose of using lable varaiable
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
        //lblRequestDate purpose of using lable varaiable
        private string lblrequestDate = "";
        public string lblRequestDate
        {
            get { return lblrequestDate; }
            set
            {
                lblrequestDate = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestDate");
            }
        }
        //imgEIR1 purpose of using Image varaiable
        private string imgeIR1 = "";
        public string imgEIR1
        {
            get { return imgeIR1; }
            set
            {
                imgeIR1 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEIR1");
            }
        }
        //lblValContainerNo purpose of using lable varaiable
        private string lblvalContainerNo = "";
        public string lblValContainerNo
        {
            get { return lblvalContainerNo; }
            set
            {
                lblvalContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValContainerNo");
            }
        }
        //lblValBOLNo purpose of using lable varaiable
        private string lblvalBOLNo = "";
        public string lblValBOLNo
        {
            get { return lblvalBOLNo; }
            set
            {
                lblvalBOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValBOLNo");
            }
        }
        //lblValRequestedDate purpose of using lable varaiable
        private string lblvalRequestedDate = "";
        public string lblValRequestedDate
        {
            get { return lblvalRequestedDate; }
            set
            {
                lblvalRequestedDate = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValRequestedDate");
            }
        }
        //imgEIRIconWhite purpose of using Image varaiable
        private string imgeIRIconWhite = "";
        public string imgEIRIconWhite
        {
            get { return imgeIRIconWhite; }
            set
            {
                imgeIRIconWhite = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEIRIconWhite");
            }
        }
        //lblEIRGatePhotoRequest purpose of using lable varaiable
        private string lbleIRGatePhotoRequest = "";
        public string lblEIRGatePhotoRequest
        {
            get { return lbleIRGatePhotoRequest; }
            set
            {
                lbleIRGatePhotoRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRGatePhotoRequest");
            }
        }
        //imgHistoryIconWhite purpose of using Image varaiable
        private string imghistoryIconWhite = "";
        public string imgHistoryIconWhite
        {
            get { return imghistoryIconWhite; }
            set
            {
                imghistoryIconWhite = value;
                OnPropertyChanged();
                RaisePropertyChange("imgHistoryIconWhite");
            }
        }
        //lblRequestHistory purpose of using lable varaiable
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
                TapEIRrequest.ChangeCanExecute();
                TapEIRrequesthistory.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Viewmodel-Constructor
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrTruckNo"></param>
        public EIRPhotoDetailViewModel(string fstrContainerNo, string fstrBOLNo, string fstrTruckNo, string fstrRequestDt)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("EIRPhotoDetailViewModel");
            Task.Run(() => assignCms()).Wait();
            TapEIRrequest = new Command(async () => await tapEIRrequest(), () => !IsBusy);
            TapEIRrequesthistory = new Command(async () => await tapEIRrequesthistory(), () => !IsBusy);
            lblValBOLNo = fstrBOLNo;
            lblValContainerNo = fstrContainerNo;
            lblValRequestedDate = fstrRequestDt;
            string lstrData = fstrTruckNo + "_" + fstrBOLNo + "_" + fstrContainerNo;
            Task.Run(() => getimage(lstrData)).Wait();
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM452");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM452");
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
                        
            imgEIRIconBlue = dbLayer.getCaption("imgEIR", objCMS);
            lblEIRGateDetail = dbLayer.getCaption("strEIRGatePhotoDetail", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNo1", objCMS);
            lblBillofLading = dbLayer.getCaption("strBillofLading1", objCMS);
            lblRequestDate = dbLayer.getCaption("strRequestDate", objCMS);
            imgEIRIconWhite = dbLayer.getCaption("imgEIRiconwhite", objCMS);
            lblEIRGatePhotoRequest = dbLayer.getCaption("strEIRCopyampGatePhotoRequest", objCMS);
            imgHistoryIconWhite = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To go to EIRrequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task tapEIRrequesthistory()
        {
            IsBusy = true;
            StackEIRPhotoDetail = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new EIRRequestHistory("", "", "", "",""));
            StackEIRPhotoDetail = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get EIRrequest
        /// </summary>
        /// <returns></returns>
        private async Task tapEIRrequest()
        {
            IsBusy = true;
            StackEIRPhotoDetail = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new EIR_Request_step1());
            StackEIRPhotoDetail = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get image
        /// </summary>
        /// <param name="fstrReqreference"></param>
        /// <returns></returns>
        private async Task getimage(string fstrReqreference)
        {
            try
            {
                lstEIRCopyImage = objBl.getImages(fstrReqreference);
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                foreach (var item in lstEIRCopyImage)
                {
                    string Image_URL = item.gp_image;
                    var matchGroups = Regex.Match(Image_URL, @"^data:((?<type>[\w\/]+))?;base64,(?<data>.+)$").Groups;
                    var base64Data = matchGroups["data"].Value;                  
                    byte[] Base64Stream = Convert.FromBase64String(base64Data);
                    item.Gate_Image = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                    lstEIRCopyImages.Add(item);
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message,3000);
            }
        }
    }
}