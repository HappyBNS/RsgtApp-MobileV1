using Microsoft.AppCenter.Analytics;
using Plugin.FilePicker;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.DirectDeliveryModel;

namespace RsgtApp.ViewModels
{
    public class DirectDeliveryRequest1ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        public static List<DirectDeliverydt> lstDelivery = new List<DirectDeliverydt>();
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Tapcontainerlist { get; set; }
        public Command Taprequesthistory { get; set; }
        public Command Buttonretreive { get; set; }
        public Command btnCancel { get; set; }
        public Command Button_Clicked { get; set; }
        //Assign Static Variables
        string strFileName = "";
        string strFileType = "";
        string strFileBody = "";

        private string strServerSlowMsg = "";

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
        private bool stackDirectDeliveryRequest1 = true;
        public bool StackDirectDeliveryRequest1
        {
            get { return stackDirectDeliveryRequest1; }
            set
            {
                stackDirectDeliveryRequest1 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDirectDeliveryRequest1");
            }
        }
        private string imgdDLIcon = "";
        public string imgDDLIcon
        {
            get { return imgdDLIcon; }
            set
            {
                imgdDLIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDDLIcon");
            }
        }
        private string lbldirectDeliveryRequest = "";
        public string lblDirectDeliveryRequest
        {
            get { return lbldirectDeliveryRequest; }
            set
            {
                lbldirectDeliveryRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDirectDeliveryRequest");
            }
        }
        private string imgcontainerAddIcon = "";
        public string imgContainerAddIcon
        {
            get { return imgcontainerAddIcon; }
            set
            {
                imgcontainerAddIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgContainerAddIcon");
            }
        }
        private string lbladdContainer = "";
        public string lblAddContainer
        {
            get { return lbladdContainer; }
            set
            {
                lbladdContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAddContainer ");
            }
        }
        private string lblbayanNumber = "";
        public string lblBayanNumber
        {
            get { return lblbayanNumber; }
            set
            {
                lblbayanNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBayanNumber");
            }
        }
        private string TxtbayanNumber = "";
        public string TxtBayanNumber
        {
            get { return TxtbayanNumber; }
            set
            {
                TxtbayanNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBayanNumber");
            }
        }
        private string lblapprovAlttachement = "";
        public string lblApprovAlttachement
        {
            get { return lblapprovAlttachement; }
            set
            {
                lblapprovAlttachement = value;
                OnPropertyChanged();
                RaisePropertyChange("lblApprovAlttachement");
            }
        }
        private string TxtapprovAlttachement = "";
        public string TxtApprovAlttachement
        {
            get { return TxtapprovAlttachement; }
            set
            {
                TxtapprovAlttachement = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtApprovAlttachement");
            }
        }
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
        private string imgcontainerIcon = "";
        public string imgContainerIcon
        {
            get { return imgcontainerIcon; }
            set
            {
                imgcontainerIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgContainerIcon");
            }
        }
        private string lblcontainerList = "";
        public string lblContainerList
        {
            get { return lblcontainerList; }
            set
            {
                lblcontainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerList");
            }
        }
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
        private string msgBayanNo = "";
        public string MsgBayanNo
        {
            get { return msgBayanNo; }
            set
            {
                msgBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgBayanNo");
            }
        }
        //To handle Boolean variable
        private bool isvalidatedBayanNo = false;
        public bool IsvalidatedBayanNo
        {
            get { return isvalidatedBayanNo; }
            set
            {
                isvalidatedBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedBayanNo ");
            }
        }
        //To handle Boolean variable
        private bool lblfilename = false;
        public bool lblFilename
        {
            get { return lblfilename; }
            set
            {
                lblfilename = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename ");
            }
        }
        //To handle Boolean variable
        private bool Imgcancel = false;
        public bool ImgCancel
        {
            get { return Imgcancel; }
            set
            {
                Imgcancel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCancel ");
            }
        }
        //To handle Boolean variable
        private bool ischooseFile = true;
        public bool IsChoosefile
        {
            get { return ischooseFile; }
            set
            {
                ischooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile");
            }
        }
        //txtFilename purpose of using text Variable
        private string txtFilename = "";
        public string TxtFilename
        {
            get { return txtFilename; }
            set
            {
                txtFilename = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename");
            }
        }
        //Btnchoosefile purpose of using text Variable
        private string btnchoosefile = "";
        public string BtnChooseFile
        {
            get { return btnchoosefile; }
            set
            {
                btnchoosefile = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnChooseFile");
            }
        }
        //MsgChooseFile purpose of using Madatory Variable
        private string msgChooseFile = "";
        public string MsgChooseFile
        {
            get { return msgChooseFile; }
            set
            {
                msgChooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile");
            }
        }
        //IsvalidatedChoose purpose of using Validation Variable
        private bool isvalidatedChoose = false;
        public bool IsvalidatedChoose
        {
            get { return isvalidatedChoose; }
            set
            {
                isvalidatedChoose = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChoose");
            }
        }
        //To handle boolean variable
        private bool isEnableContainerList = false;
        public bool IsEnableContainerList
        {
            get { return isEnableContainerList; }
            set
            {
                isEnableContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("IsEnableContainerList");
            }
        }
        //14-03-2023 - Sanduru
        private string provideValidDataMsg = ""; 
        public string ProvideValidDataMsg
        {
            get { return provideValidDataMsg; }
            set
            {
                provideValidDataMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("ProvideValidDataMsg");
            }
        }
        //14-03-2023 - Sanduru
        //To handle Boolean variable 
        private bool isvalidatedInfo = false;
        public bool IsvalidatedInfo
        {
            get { return isvalidatedInfo; }
            set
            {
                isvalidatedInfo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedInfo ");
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
                Tapcontainerlist.ChangeCanExecute();
                Taprequesthistory.ChangeCanExecute();
                Buttonretreive.ChangeCanExecute();
                btnCancel.ChangeCanExecute();
                Button_Clicked.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel Constructor
        /// </summary>
        public DirectDeliveryRequest1ViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DirectDeliveryRequest1ViewModel");
            Task.Run(() => assignCms()).Wait();
            Tapcontainerlist = new Command(async () => await tapcontainerlist(), () => !IsBusy);
            Taprequesthistory = new Command(async () => await taprequesthistory(), () => !IsBusy);
            btnCancel = new Command(async () => await btncancel(), () => !IsBusy);
            Buttonretreive = new Command(async () => await buttonretreive(), () => !IsBusy);
            Button_Clicked = new Command(async () => await button_Clicked(), () => !IsBusy);
            IsEnableContainerList = false;
            if (DirectDeliveryModel.lstDelivery.Count > 0)
            {
                IsEnableContainerList = true;

            }
        }
        /// <summary>
        /// /To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM458");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM458");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
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
           
            imgDDLIcon = dbLayer.getCaption("imgDDLicon", objCMS);
            lblDirectDeliveryRequest = dbLayer.getCaption("strDirectDeliveryRequest", objCMS);
            imgContainerAddIcon = dbLayer.getCaption("imgcontainer", objCMS);
            lblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            lblBayanNumber = dbLayer.getCaption("strBayanNumber", objCMS);
            lblApprovAlttachement = dbLayer.getCaption("strApprovalproofattachement", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            imgContainerIcon = dbLayer.getCaption("imgcontainers", objCMS);
            lblContainerList = dbLayer.getCaption("strContainerList", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            BtnChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
            MsgBayanNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgChooseFile = dbLayer.getCaption("strMandatory", objCMSMSG);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            ProvideValidDataMsg = dbLayer.getCaption("strInformationVaildMsg", objCMS); //14-03-2023
        }
        /// <summary>
        /// Function for Retreive
        /// </summary>
        /// <returns></returns>
        private async Task buttonretreive()
        {
            IsBusy = true;
            StackDirectDeliveryRequest1 = false;
            await Task.Delay(1000);
            await HideErrorValidation();
            var BayanNo = TxtBayanNumber.ToString().Trim();
            var strFilename = lblFilename.ToString();
            if (BayanNo == null) BayanNo = ""; //20230522
            if (BayanNo == "")
            {
                IsvalidatedBayanNo = true;
            }
            else
            {
                IsvalidatedBayanNo = false;
            }
            if (strFileBody == "")
            {
                IsvalidatedChoose = true;
            }
            else
            {
                IsvalidatedChoose = false ;
            }
            if ((BayanNo != "") && (lblFilename == true))
            {
               await fnNext(BayanNo, strFileBody);
            }
            StackDirectDeliveryRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Next Page Navigation
        /// </summary>
        /// <param name="fstrBayanNo"></param>
        /// <param name="strApproveattachfilename"></param>
        /// <returns></returns>
        private async Task fnNext(string fstrBayanNo, string strApproveattachfilename)
        {
            IsBusy = true;
            StackDirectDeliveryRequest1 = false;
            await Task.Delay(1000);
            await HideErrorValidation();
            IsvalidatedInfo = false;
            //string lstrBayanNo = "";
            var objRawData = new List<DirectDeliverydt>();
            objRawData = objBl.RetreiveDirectDeliveryDetails(fstrBayanNo);
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
              App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            if ((objRawData != null) && (objRawData.Count > 0))
            {
                string lblValBayanNo = fstrBayanNo;
                strBayanNo = fstrBayanNo;
                string lblApprovalAttachmentFile = strApproveattachfilename;
                App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryRequest2(lblValBayanNo, "N"));
            }
            else
            {
                IsvalidatedInfo = true;
            }
            StackDirectDeliveryRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get button_Clicked button
        /// </summary>
        /// <returns></returns>
        private async Task button_Clicked()
        {
            IsBusy = true;
            StackDirectDeliveryRequest1 = false;
            await Task.Delay(1000);
            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                   }
                await PickAndShow(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackDirectDeliveryRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get btncancel button
        /// </summary>
        /// <returns></returns>
        private async Task btncancel()
        {
            IsBusy = true;
            StackDirectDeliveryRequest1 = false;
            await Task.Delay(1000);
            try
            {
                lblFilename = false;
                TxtFilename = "";
                strFileBody = "";
                ImgCancel = false;
                IsChoosefile = true;
                
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackDirectDeliveryRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow(string[] fileTypes)
        {
            IsBusy = true;
            StackDirectDeliveryRequest1 = false;
            await Task.Delay(1000);
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    lblFilename = true;
                    ImgCancel = true;
                    IsChoosefile = false;
                    TxtFilename = pickedFile.FileName.ToString();
                    strFileName = pickedFile.FileName;
                    int lintLastDotPos = strFileName.LastIndexOf('.');
                    string lstrLoadFileType = strFileName.Substring(lintLastDotPos + 1);
                    strFileType = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    strFileBody = temp_inBase64;
                    strApproveattachfilename = strFileName;
                    strApproveattachimage = strFileBody;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackDirectDeliveryRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Container List
        /// </summary>
        /// <returns></returns>
        private async Task tapcontainerlist()
        {
            IsBusy = true;
            StackDirectDeliveryRequest1 = false;
            await Task.Delay(1000);
            if (lstDelivery.Count > 0)
            {

                await App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryContainerList(""));
            }
            else
            {
                await App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryRequest1());
            }
            StackDirectDeliveryRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Request History
        /// </summary>
        /// <returns></returns>
        private async Task taprequesthistory()
        {
            IsBusy = true;
            StackDirectDeliveryRequest1 = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Direct Delivery"));
             StackDirectDeliveryRequest1 = true;
            IsBusy = false;
        }

        public async Task HideErrorValidation()
        {
            IsvalidatedBayanNo = false;
            IsvalidatedInfo = false;
            IsvalidatedChoose = false;
        }
    }
}
