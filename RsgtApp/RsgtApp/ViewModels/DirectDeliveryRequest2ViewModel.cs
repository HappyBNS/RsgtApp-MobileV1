using Microsoft.AppCenter.Analytics;
using Plugin.FilePicker;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.BusinessLayer.BLConnect;
using static RsgtApp.Models.DirectDeliveryModel;

namespace RsgtApp.ViewModels
{
    class DirectDeliveryRequest2ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        private string strServerSlowMsg = "";
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command ButtonAddcontainer { get; set; }
        public Command Tapcontainerlist { get; set; }
        public Command Taprequesthistory { get; set; }
        public Command Button_Clicked { get; set; }
        public Command Button2_Clicked { get; set; }
        public Command BtnCancel { get; set; }
        public Command BtnCancel2 { get; set; }
        // public Command BtnUpdate { get; set; }
        public Command BtnCancel3 { get; set; }
        //Assign Static Variables
        string strFileName2 = "";
        string strFileType2 = "";
        string strFileBody2 = "";
        public List<EnumCombo> lobjDirectDelivery { get; set; } = new List<EnumCombo>();
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
        private bool stackDirectDeliveryRequest2 = true;
        public bool StackDirectDeliveryRequest2
        {
            get { return stackDirectDeliveryRequest2; }
            set
            {
                stackDirectDeliveryRequest2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDirectDeliveryRequest2");
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
                RaisePropertyChange("lblAddContainer");
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
        private string lblapprovalAttachment = "";
        public string lblApprovalAttachment
        {
            get { return lblapprovalAttachment; }
            set
            {
                lblapprovalAttachment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblApprovalAttachment");
            }
        }
        private string lblenterInformation = "";
        public string lblEnterInformation
        {
            get { return lblenterInformation; }
            set
            {
                lblenterInformation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEnterInformation");
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
        private string TxtbillofLading = "";
        public string TxtBillofLading
        {
            get { return TxtbillofLading; }
            set
            {
                TxtbillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBillofLading");
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
        private string lbldriverName = "";
        public string lblDriverName
        {
            get { return lbldriverName; }
            set
            {
                lbldriverName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverName");
            }
        }
        private string TxtdriverName = "";
        public string TxtDriverName
        {
            get { return TxtdriverName; }
            set
            {
                TxtdriverName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDriverName");
            }
        }
        private string lblmobileNumber = "";
        public string lblMobileNumber
        {
            get { return lblmobileNumber; }
            set
            {
                lblmobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMobileNumber");
            }
        }
        private string TxtmobileNumber = "";
        public string TxtMobileNumber
        {
            get { return TxtmobileNumber; }
            set
            {
                TxtmobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtMobileNumber");
            }
        }
        private string lbllicenseAttachment = "";
        public string lblLicenseAttachment
        {
            get { return lbllicenseAttachment; }
            set
            {
                lbllicenseAttachment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseAttachment");
            }
        }
        private string TxtlicenseAttachment = "";
        public string TxtLicenseAttachment
        {
            get { return TxtlicenseAttachment; }
            set
            {
                TxtlicenseAttachment = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLicenseAttachment");
            }
        }
        private string Btnadd = "";
        public string BtnAdd
        {
            get { return Btnadd; }
            set
            {
                Btnadd = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnAdd");
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
        private string msgBillofLading = "";
        public string MsgBillofLading
        {
            get { return msgBillofLading; }
            set
            {
                msgBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgBillofLading");
            }
        }
        private string msgContainerNumber = "";
        public string MsgContainerNumber
        {
            get { return msgContainerNumber; }
            set
            {
                msgContainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgContainerNumber");
            }
        }
        private string msgDriverName = "";
        public string MsgDriverName
        {
            get { return msgDriverName; }
            set
            {
                msgDriverName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgDriverName");
            }
        }
        private string msgMobileNumber = "";
        public string MsgMobileNumber
        {
            get { return msgMobileNumber; }
            set
            {
                msgMobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMobileNumber");
            }
        }
        private string txtBayanNumber = "";
        public string TxtBayanNumber
        {
            get { return txtBayanNumber; }
            set
            {
                txtBayanNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBayanNumber");
            }
        }
        private string txtApprovalAttachment = "";
        public string TxtApprovalAttachment
        {
            get { return txtApprovalAttachment; }
            set
            {
                txtApprovalAttachment = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtApprovalAttachment");
            }
        }
        private bool isVisibleCancel = false;
        public bool IsVisibleCancel
        {
            get { return isVisibleCancel; }
            set
            {
                isVisibleCancel = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel");
            }
        }
        private bool isvalidatedBillofLading = false;
        public bool IsvalidatedBillofLading
        {
            get { return isvalidatedBillofLading; }
            set
            {
                isvalidatedBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedBillofLading");
            }
        }
        private bool isvalidatedMobileNumber = false;
        public bool IsvalidatedMobileNumber
        {
            get { return isvalidatedMobileNumber; }
            set
            {
                isvalidatedMobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedMobileNumber");
            }
        }
        private bool isvalidatedDriverName = false;
        public bool IsvalidatedDriverName
        {
            get { return isvalidatedDriverName; }
            set
            {
                isvalidatedDriverName = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedDriverName");
            }
        }
        private bool isvalidatedContainerNumber = false;
        public bool IsvalidatedContainerNumber
        {
            get { return isvalidatedContainerNumber; }
            set
            {
                isvalidatedContainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedContainerNumber");
            }
        }
        private string txtSNO = "0";
        public string TxtSNO
        {
            get { return txtSNO; }
            set
            {
                txtSNO = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtSNO");
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
        //To handle Boolean variable
        private bool ischooseFile2 = true;
        public bool IsChoosefile2
        {
            get { return ischooseFile2; }
            set
            {
                ischooseFile2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile2");
            }
        }
        private bool isvalidatedConBol = false;
        public bool IsvalidatedConBol
        {
            get { return isvalidatedConBol; }
            set
            {
                isvalidatedConBol = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedConBol");
            }
        }
        private bool Imgcancel = false;
        public bool ImgCancel
        {
            get { return Imgcancel; }
            set
            {
                Imgcancel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCancel");
            }
        }
        private string lblvalbayanNo = "";
        public string lblvalBayanNo
        {
            get { return lblvalbayanNo; }
            set
            {
                lblvalbayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblvalBayanNo");
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
                RaisePropertyChange("lblFilename");
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
        //txtFilename purpose of using text Variable
        private string txtFilename2 = "";
        public string TxtFilename2
        {
            get { return txtFilename2; }
            set
            {
                txtFilename2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename2");
            }
        }
        private string lblapprovalAttachmentFile = "";
        public string lblApprovalAttachmentFile
        {
            get { return lblapprovalAttachmentFile; }
            set
            {
                lblapprovalAttachmentFile = value;
                OnPropertyChanged();
                RaisePropertyChange("lblApprovalAttachmentFile");
            }
        }
        private bool Imgcancel2 = false;
        public bool ImgCancel2
        {
            get { return Imgcancel2; }
            set
            {
                Imgcancel2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCancel2");
            }
        }
        private ImageSource licattachfileimage = "";
        public ImageSource Licattachfileimage
        {
            get { return licattachfileimage; }
            set
            {
                licattachfileimage = value;
                OnPropertyChanged();
                RaisePropertyChange("Licattachfileimage");
            }
        }
        private string msgChooseFile1 = "";
        public string MsgChooseFile1
        {
            get { return msgChooseFile1; }
            set
            {
                msgChooseFile1 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile1");
            }
        }
        private bool isvalidatedChoose1 = false;
        public bool IsvalidatedChoose1
        {
            get { return isvalidatedChoose1; }
            set
            {
                isvalidatedChoose1 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChoose1");
            }
        }
        private bool isvisibleContainerList = false;
        public bool IsvisibleContainerList
        {
            get { return isvisibleContainerList; }
            set
            {
                isvisibleContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleContainerList");
            }
        }
        private bool isvisibleCancel = false;
        public bool IsvisibleCancel
        {
            get { return isvisibleCancel; }
            set
            {
                isvisibleContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleCancel");
            }
        }
        private string btnCancel5 = "";
        public string BtnCancel5
        {
            get { return btnCancel5; }
            set
            {
                btnCancel5 = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnCancel5");
            }
        }
        private string msgConBol = "";
        public string MsgConBol
        {
            get { return msgConBol; }
            set
            {
                msgConBol = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgConBol");
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
        //Assign Static Variables
        string strFileName = "";
        string strFileType = "";
        string strFileBody = "";
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
                ButtonAddcontainer.ChangeCanExecute();
                Tapcontainerlist.ChangeCanExecute();
                Taprequesthistory.ChangeCanExecute();
                Button_Clicked.ChangeCanExecute();
                BtnCancel.ChangeCanExecute();
                BtnCancel3.ChangeCanExecute();
            }
        }
        private string lstrsreenflag = "N";
        /// <summary>
        /// ViewModel Constructor
        /// </summary>
        /// <param name="fstrBayanNo"></param>
        /// <param name="fstrScreenflag"></param>
        public DirectDeliveryRequest2ViewModel(string fstrBayanNo, string fstrScreenflag)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DirectDeliveryRequest2ViewModel");
            lstrsreenflag = fstrScreenflag;
            Task.Run(() => assignCms()).Wait();
            ButtonAddcontainer = new Command(async () => await buttonAddcontainer(), () => !IsBusy);
            Tapcontainerlist = new Command(async () => await tapcontainerlist(), () => !IsBusy);
            Taprequesthistory = new Command(async () => await taprequesthistory(), () => !IsBusy);
            Button_Clicked = new Command(async () => await button_Clicked(), () => !IsBusy);
            BtnCancel = new Command(async () => await btncancel(), () => !IsBusy);
            BtnCancel3 = new Command(async () => await btnCancel3(), () => !IsBusy);
            lblvalBayanNo = strBayanNo;
            lblApprovalAttachmentFile = strApproveattachfilename;

            IsEnableContainerList = false;
            if (DirectDeliveryModel.lstDelivery.Count > 0)
            {
                IsEnableContainerList = true;

            }

            if ((fstrBayanNo == "") && (fstrScreenflag == "Y"))
            {
                Task.Run(() => fetchEditSelectedItem()).Wait();
            }
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM458");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM458");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
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

            imgDDLIcon = dbLayer.getCaption("imgDDLicon", objCMS);
            lblDirectDeliveryRequest = dbLayer.getCaption("strDirectDeliveryRequest", objCMS);
            imgContainerAddIcon = dbLayer.getCaption("imgcontainer", objCMS);
            lblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            lblBayanNumber = dbLayer.getCaption("strBayanNo", objCMS);
            lblApprovalAttachment = dbLayer.getCaption("strApprovalProofAttachment", objCMS);
            lblEnterInformation = dbLayer.getCaption("strBelowInformationMsg", objCMS);
            lblBillofLading = dbLayer.getCaption("strBillofLading", objCMS);
            lblContainerNumber = dbLayer.getCaption("strContainerNumber", objCMS);
            lblDriverName = dbLayer.getCaption("strDriverName", objCMS);
            lblMobileNumber = dbLayer.getCaption("strMobileNumber", objCMS);
            lblLicenseAttachment = dbLayer.getCaption("strDriverLicense", objCMS);
            BtnAdd = dbLayer.getCaption("strAdd", objCMS);
            if (lstrsreenflag == "Y")
            {
                BtnAdd = "Update";
                IsVisibleCancel = true;
            }
            imgContainerIcon = dbLayer.getCaption("imgcontainers", objCMS);
            lblContainerList = dbLayer.getCaption("strContainerList", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            lobjDirectDelivery = dbLayer.getEnum("strDirectDeliveryRequestLov", objCMS);
            MsgBillofLading = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgContainerNumber = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgDriverName = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgMobileNumber = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgChooseFile1 = dbLayer.getCaption("strMandatory", objCMSMsg);
            BtnChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
            MsgConBol = dbLayer.getCaption("strInformationVaildMsg", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// Button for cancel
        /// </summary>
        /// <returns></returns>
        private async Task btnCancel3()
        {
            IsBusy = true;
            StackDirectDeliveryRequest2 = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryContainerList(""));
            StackDirectDeliveryRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// Button for add Container
        /// </summary>
        /// <returns></returns>
        private async Task buttonAddcontainer()
        {
            IsBusy = true;
            StackDirectDeliveryRequest2 = false;
            await Task.Delay(3000);
            await HideErrorValidation();
            var BOL = TxtBillofLading.ToString().Trim();
            var ContainerNo = TxtContainerNumber.ToString().Trim();
            var DriverName = TxtDriverName.ToString().Trim();
            var MobileNo = TxtMobileNumber.ToString().Trim();
            if ((BOL == null) || (BOL == ""))
            {
                IsvalidatedBillofLading = true;
            }
            else
            {
                IsvalidatedBillofLading = false;
            }
            if ((ContainerNo == null) || (ContainerNo == ""))
            {
                IsvalidatedContainerNumber = true;
            }
            else
            {
                IsvalidatedContainerNumber = false;
            }
            if ((DriverName == null) || (DriverName == ""))
            {
                IsvalidatedDriverName = true;
            }
            else
            {
                IsvalidatedDriverName = false;
            }
            if ((MobileNo == null) || (MobileNo == ""))
            {
                IsvalidatedMobileNumber = true;
            }
            else
            {
                IsvalidatedMobileNumber = false;
            }
            if (strFileBody2 == "")
            {
                IsvalidatedChoose1 = true;
            }
            else
            {
                IsvalidatedChoose1 = false;
            }

            if ((BOL != "") && (ContainerNo != "") && (DriverName != "") && (MobileNo != "") && (strFileBody2 != ""))
            {
                await FnAdd(lblvalBayanNo, BOL, ContainerNo, DriverName, MobileNo, strFileBody2);
            }
            StackDirectDeliveryRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function to Add container
        /// </summary>
        /// <param name="fstrbayanNo"></param>
        /// <param name="fstrBOLNO"></param>
        /// <param name="fstrContainerNo"></param>
        /// <param name="DriverName"></param>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        private async Task FnAdd(string fstrbayanNo, string fstrBOLNO, string fstrContainerNo, string DriverName, string MobileNo, string strApproveattachfilename)
        {
            await HideErrorValidation();
            bool blResult = true;
            if (blResult == true)
            {
                var objRawData = new List<RETRIVECONTAINER>();
                objRawData = objBl.ReteriveDirectDelivery(fstrbayanNo, fstrBOLNO, fstrContainerNo);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                //   string lblApprovalAttachmentFile = strApproveattachfilename;
                if ((objRawData != null) && (objRawData.Count > 0))
                {
                    int lintSNO = Convert.ToInt32(TxtSNO);
                    var objDirectDeliverylistModel = new DirectDeliverydt();
                    objDirectDeliverylistModel.cd_bayannumber = fstrbayanNo.ToString().Trim();
                    objDirectDeliverylistModel.cd_blnumber = fstrBOLNO.ToString().Trim();
                    objDirectDeliverylistModel.cd_containernumber = fstrContainerNo.ToString().Trim();
                    objDirectDeliverylistModel.cd_DriverName = DriverName;
                    objDirectDeliverylistModel.cd_MobileNo = MobileNo;
                    objDirectDeliverylistModel.cd_approveattachfilename = strApproveattachfilename;
                    objDirectDeliverylistModel.cd_approveattachimage = strApproveattachimage;
                    objDirectDeliverylistModel.cd_licattachfilename = strLicattachfilename;
                    objDirectDeliverylistModel.cd_licattachfileimage = strLicattachfileimage;
                    if (lintSNO == 0)
                    {
                        DirectDeliveryModel.lintDirectDeliverySno = DirectDeliveryModel.lintDirectDeliverySno + 1;
                        objDirectDeliverylistModel.CD_SNO = DirectDeliveryModel.lintDirectDeliverySno;
                        DirectDeliveryModel.lstDelivery.Add(objDirectDeliverylistModel);
                    }
                    //Update List added by Anand-20221109
                    if (lintSNO > 0)
                    {
                        objDirectDeliverylistModel.CD_SNO = lintSNO;
                        var index = DirectDeliveryModel.lstDelivery.FindIndex(x => x.CD_SNO == lintSNO);
                        if (index > -1)
                        {
                            DirectDeliveryModel.lstDelivery[index] = objDirectDeliverylistModel;
                        }
                    }
                    if (DirectDeliveryModel.lstDelivery.Count > 0)
                    {
                        await App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryContainerList(lblvalBayanNo));
                    }
                }
                else
                {
                    IsvalidatedConBol = true;
                }
            }
        }
        /// <summary>
        /// To get button_Clicked button
        /// </summary>
        /// <returns></returns>
        private async Task button_Clicked()
        {
            IsBusy = true;
            StackDirectDeliveryRequest2 = false;
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
            StackDirectDeliveryRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get btncancel button
        /// </summary>
        /// <returns></returns>
        private async Task btncancel()
        {
            IsBusy = true;
            StackDirectDeliveryRequest2 = false;
            await Task.Delay(1000);
            try
            {
                lblFilename = false;
                TxtFilename = "";
                strFileBody2 = "";
                ImgCancel = false;
                IsChoosefile = true;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackDirectDeliveryRequest2 = true;
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
            StackDirectDeliveryRequest2 = false;
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
                    strFileName2 = pickedFile.FileName;
                    int lintLastDotPos = strFileName2.LastIndexOf('.');
                    string lstrLoadFileType = strFileName2.Substring(lintLastDotPos + 1);
                    strFileType2 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    //  string imgDataURL = string.Format("data:image/png;base64,{0}", temp_inBase64);
                    //imgDataURL = temp_inBase64;
                    strFileBody2 = temp_inBase64;
                    strLicattachfilename = strFileName2;
                    strLicattachfileimage = strFileBody2;

                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackDirectDeliveryRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Container list
        /// </summary>
        /// <returns></returns>
        private async Task tapcontainerlist()
        {
            IsBusy = true;
            StackDirectDeliveryRequest2 = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryContainerList(""));
            StackDirectDeliveryRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Request History
        /// </summary>
        /// <returns></returns>
        private async Task taprequesthistory()
        {
            IsBusy = true;
            StackDirectDeliveryRequest2 = false;
            await Task.Delay(1000);
             App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Direct Delivery"));
            StackDirectDeliveryRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Edit Selected Item
        /// </summary>
        /// <returns></returns>
        private async Task fetchEditSelectedItem()
        {
            IsBusy = true;
            StackDirectDeliveryRequest2 = false;
            await Task.Delay(3000);
            foreach (var item in DirectDeliveryModel.lstSelectedDelivery)
            {
                TxtSNO = item.CD_SNO.ToString();
                lblvalBayanNo = item.cd_bayannumber;
                TxtBillofLading = item.cd_blnumber;
                TxtContainerNumber = item.cd_containernumber;
                TxtDriverName = item.cd_DriverName;
                TxtMobileNumber = item.cd_MobileNo;
                string base64Image = item.cd_licattachfileimage;
                byte[] Base64Stream = Convert.FromBase64String(base64Image);
                strFileBody2 = base64Image;
                using (MemoryStream ms = new MemoryStream(Base64Stream))
                {
                    Licattachfileimage = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                }
            }
            StackDirectDeliveryRequest2 = true;
            IsBusy = false;
        }
        public async Task HideErrorValidation()
        {
            IsvalidatedBillofLading = false;
            IsvalidatedContainerNumber = false;
            IsvalidatedDriverName = false;
            IsvalidatedMobileNumber = false;
            IsvalidatedChoose1 = false;
            IsvalidatedConBol = false;
        }
    }
}
