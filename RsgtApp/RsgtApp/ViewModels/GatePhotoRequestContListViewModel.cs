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
using static RsgtApp.Models.BOLModel;
using static RsgtApp.Models.ContainerModel;
using static RsgtApp.Models.GatePhotoDetailModel;

namespace RsgtApp.ViewModels
{
    public class GatePhotoRequestContListViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        private List<Gatephotodetaildt> lstGatephotodetail { get; set; } = new List<Gatephotodetaildt>();
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command GatephotodetailClicked { get; set; }
        public Command BtnClickedMsg { get; set; }
        List<ContainerDt> lstGetphotos = new List<ContainerDt>();
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
        public string lblBayanNo = "";
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
        //To handle Indicator
        private bool stackGatePhotoRequest = true;
        public bool StackGatePhotoRequest
        {
            get { return stackGatePhotoRequest; }
            set
            {
                stackGatePhotoRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("StackGatePhotoRequest");
            }
        }
        //LblGatePhotoRequest purpose of using Label Variable
        private string lblGatePhotoRequest = "";
        public string LblGatePhotoRequest
        {
            get { return lblGatePhotoRequest; }
            set
            {
                lblGatePhotoRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGatePhotoRequest");
            }
        }
        //LblBillofLading purpose of using Label Variable
        private string lblContainerNo = "";
        public string LblContainerNo
        {
            get { return lblContainerNo; }
            set
            {
                lblContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerNo");
            }
        }
        //LblBillofLading purpose of using Label Variable
        private string lblBillofLading = "";
        public string LblBillofLading
        {
            get { return lblBillofLading; }
            set
            {
                lblBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBillofLading");
            }
        }
        //BtnRequestPhoto purpose of using Label Variable
        private string btnRequestPhoto = "";
        public string BtnRequestPhoto
        {
            get { return btnRequestPhoto; }
            set
            {
                btnRequestPhoto = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnRequestPhoto");
            }
        }
        //LblRequestMsg purpose of using Label Variable
        private string lblRequestMsg = "";
        public string LblRequestMsg
        {
            get { return lblRequestMsg; }
            set
            {
                lblRequestMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRequestMsg");
            }
        }
        //LblThankYou purpose of using Label Variable
        private string lblThankYou = "";
        public string LblThankYou
        {
            get { return lblThankYou; }
            set
            {
                lblThankYou = value;
                OnPropertyChanged();
                RaisePropertyChange("LblThankYou");
            }
        }
        //BtnClickPhotos purpose of using Button Variable
        private string btnClickPhotos = "";
        public string BtnClickPhotos
        {
            get { return btnClickPhotos; }
            set
            {
                btnClickPhotos = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnClickPhotos");
            }
        }
        // lfintPageSize variable
        private int lfintPageSize = Convert.ToInt32(RSGT_Resource.ResourceManager.GetString("ColletionViewPageSize").ToString().Trim());
        public int LfintPageSize
        {
            get { return lfintPageSize; }
            set
            {
                lfintPageSize = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageSize");
            }
        }
        // lfintPageNo variable
        private int lfintPageNo = 1;
        public int LfintPageNo
        {
            get { return lfintPageNo; }
            set
            {
                lfintPageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageNo");
            }
        }
        private bool IsbtnClickPhotos = false;
        public bool IsBtnClickPhotos
        {
            get { return IsbtnClickPhotos; }
            set
            {
                IsbtnClickPhotos = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBtnClickPhotos");
            }
        }


        private string strserverSlowMsg = "";
        public string strServerSlowMsg
        {
            get { return strserverSlowMsg; }
            set
            {
                strserverSlowMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("strServerSlowMsg");
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
                GatephotodetailClicked.ChangeCanExecute();
                BtnClickedMsg.ChangeCanExecute();

            }
        }
        private string strReRequestFlag = "";
        /// <summary>
        /// Begin to container gate photo list ViewModel
        /// </summary>
        /// <param name="strLicenseNo"></param>
        /// <param name="strBOL"></param>
        /// <param name="strContainer"></param>
        /// <param name="strRequest"></param>
        public GatePhotoRequestContListViewModel(string strLicenseNo, string strBOL, string strContainer, string strRequest)
        {
            strReRequestFlag = strRequest;
            //Appcenter Track Event handler
            Analytics.TrackEvent("GatePhotoRequestContListViewModel");
            Task.Run(() => assignCms()).Wait();
            BtnClickedMsg = new Command(async () => await btnClickedMsg(strLicenseNo, strBOL, strContainer, strRequest), () => !IsBusy);
            GatephotodetailClicked = new Command(async () => await gatephotodetailClicked(strBOL, strContainer, strRequest), () => !IsBusy);
        }
        //End to container gate photo list ViewModel
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM012");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM012");
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
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            LblGatePhotoRequest = dbLayer.getCaption("strGatePhotoRequest", objCMS);
            LblContainerNo = dbLayer.getCaption("strContainerNo", objCMS) + " " + gblContainer.strContainer;
            LblBillofLading = dbLayer.getCaption("strBillofLading", objCMS) + " " + gblContainer.strBOL;
            BtnRequestPhoto = dbLayer.getCaption("strRequestPhoto", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            LblRequestMsg = dbLayer.getCaption("stRequestIsUnderProcessMsg", objCMS);
            LblThankYou = dbLayer.getCaption("strThankYou", objCMS);
            IsBtnClickPhotos = false;
            if (strReRequestFlag == "Y")
            {
                BtnRequestPhoto = dbLayer.getCaption("strRerequest", objCMS);
                IsBtnClickPhotos = true;//babu20230304
                BtnClickPhotos = dbLayer.getCaption("strClicktoseePhotos", objCMS);
            }

        }
        /// <summary>
        /// To Get Gate Photo Details
        /// </summary>
        /// <param name="strBOL"></param>
        /// <param name="strContainer"></param>
        /// <param name="strRequest"></param>
        /// <returns></returns>
        private async Task gatephotodetailClicked(string strBOL, string strContainer, string strRequest)
        {
            try
            {
                IsBusy = true;
                StackGatePhotoRequest = false;
                await Task.Delay(1000);
                string fstrFilter = "fstrBOLNo:" + strBOL + ";" + "fstrContainerNo:" + strContainer + ";";
                lstGatephotodetail = objBl.getGatedoutImage(fstrFilter, lfintPageNo, lfintPageSize);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (lstGatephotodetail.Count == 0)
                {
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await App.Current.MainPage?.Navigation.PushAsync(new ContainerPhotoDetails(strBOL, strContainer));
                }
                StackGatePhotoRequest = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to Message Page
        /// </summary>
        /// <param name="strLicenseNo"></param>
        /// <param name="strBOL"></param>
        /// <param name="fstrContainerNo"></param>
        /// <param name="strRequest"></param>
        /// <returns></returns>
        private async Task btnClickedMsg(string strLicenseNo, string strBOL, string fstrContainerNo, string strRequest)
        {
            try
            {
                IsBusy = true;
                StackGatePhotoRequest = false;
                await Task.Delay(1000);
                lstGetphotos.Clear();
                string fstrBillofladingNo = strBOL;
                string fstrLicenseNo = strLicenseNo;
                string objRawData = objBl.getContainerImage(fstrLicenseNo, fstrBillofladingNo, fstrContainerNo);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                await App.Current.MainPage?.Navigation.PushAsync(new ContainerListGatePhotoMsg(strBOL));
                StackGatePhotoRequest = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}