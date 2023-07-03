using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.DirectDeliveryModel;

namespace RsgtApp.ViewModels
{
    public class DirectDeliveryContainerListViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Editcontainer { get; set; }
        public Command Buttonsubmitrequest { get; set; }
        public Command Taprequesthistory { get; set; }
        public Command Tapcontaineradd { get; set; }
        private string strServerSlowMsg = "";
        public List<EnumCombo> lobjDirectDelivery { get; set; } = new List<EnumCombo>();
        public ObservableCollection<DirectDeliverydt> lstDirectDelivery { get; set; } = new ObservableCollection<DirectDeliverydt>();
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
        private bool stackDirectDeliveryContainerList = true;
        public bool StackDirectDeliveryContainerList
        {
            get { return stackDirectDeliveryContainerList; }
            set
            {
                stackDirectDeliveryContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDirectDeliveryContainerList");
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
        private string lbldDRContainers = "";
        public string lblDDRContainers
        {
            get { return lbldDRContainers; }
            set
            {
                lbldDRContainers = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDDRContainers");
            }
        }
        private string lblbOL = "";
        public string lblBOL
        {
            get { return lblbOL; }
            set
            {
                lblbOL = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOL");
            }
        }
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
        private string lbldriverDetail = "";
        public string lblDriverDetail
        {
            get { return lbldriverDetail; }
            set
            {
                lbldriverDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverDetail");
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
        private string lbldriverLicense = "";
        public string lblDriverLicense
        {
            get { return lbldriverLicense; }
            set
            {
                lbldriverLicense = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverLicense");
            }
        }
        private string Btndelete = "";
        public string BtnDelete
        {
            get { return Btndelete; }
            set
            {
                Btndelete = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnDelete");
            }
        }
        private string Btnedit = "";
        public string BtnEdit
        {
            get { return Btnedit; }
            set
            {
                Btnedit = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnEdit");
            }
        }
        private string lblbOL1 = "";
        public string lblBOL1
        {
            get { return lblbOL1; }
            set
            {
                lblbOL1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOL1");
            }
        }
        private string lblcontainerNo1 = "";
        public string lblContainerNo1
        {
            get { return lblcontainerNo1; }
            set
            {
                lblcontainerNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerNo1");
            }
        }
        private string lbldriverDetail1 = "";
        public string lblDriverDetail1
        {
            get { return lbldriverDetail1; }
            set
            {
                lbldriverDetail1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverDetail1");
            }
        }
        private string lbldriverName1 = "";
        public string lblDriverName1
        {
            get { return lbldriverName1; }
            set
            {
                lbldriverName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverName1");
            }
        }
        private string lblmobileNumber1 = "";
        public string lblMobileNumber1
        {
            get { return lblmobileNumber1; }
            set
            {
                lblmobileNumber1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMobileNumber1");
            }
        }
        private string lbldriverLicense1 = "";
        public string lblDriverLicense1
        {
            get { return lbldriverLicense1; }
            set
            {
                lbldriverLicense1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverLicense1");
            }
        }
        private string Btndelete1 = "";
        public string BtnDelete1
        {
            get { return Btndelete1; }
            set
            {
                Btndelete1 = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnDelete1");
            }
        }
        private string Btnedit1 = "";
        public string BtnEdit1
        {
            get { return Btnedit1; }
            set
            {
                Btnedit1 = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnEdit1");
            }
        }
        private string lblbOL2 = "";
        public string lblBOL2
        {
            get { return lblbOL2; }
            set
            {
                lblbOL2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOL2");
            }
        }
        private string lblcontainerNo2 = "";
        public string lblContainerNo2
        {
            get { return lblcontainerNo2; }
            set
            {
                lblcontainerNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerNo2");
            }
        }
        private string lbldriverDetail2 = "";
        public string lblDriverDetail2
        {
            get { return lbldriverDetail2; }
            set
            {
                lbldriverDetail2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverDetail2");
            }
        }
        private string lbldriverName2 = "";
        public string lblDriverName2
        {
            get { return lbldriverName2; }
            set
            {
                lbldriverName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverName2");
            }
        }
        private string lblmobileNumber2 = "";
        public string lblMobileNumber2
        {
            get { return lblmobileNumber2; }
            set
            {
                lblmobileNumber2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMobileNumber2");
            }
        }
        private string lbldriverLicense2 = "";
        public string lblDriverLicense2
        {
            get { return lbldriverLicense2; }
            set
            {
                lbldriverLicense2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDriverLicense2");
            }
        }
        private string Btndelete2 = "";
        public string BtnDelete2
        {
            get { return Btndelete2; }
            set
            {
                Btndelete2 = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnDelete2");
            }
        }
        private string Btnedit2 = "";
        public string BtnEdit2
        {
            get { return Btnedit2; }
            set
            {
                Btnedit2 = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnEdit2");
            }
        }
        private string BtnsubmitRequest = "";
        public string BtnSubmitRequest
        {
            get { return BtnsubmitRequest; }
            set
            {
                BtnsubmitRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnSubmitRequest");
            }
        }
        private string imgcontainerAdd = "";
        public string imgContainerAdd
        {
            get { return imgcontainerAdd; }
            set
            {
                imgcontainerAdd = value;
                OnPropertyChanged();
                RaisePropertyChange("imgContainerAdd");
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
        private string txtBOL = "";
        public string TxtBOL
        {
            get { return txtBOL; }
            set
            {
                txtBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOL");
            }
        }
        private string txtContainerNo = "";
        public string TxtContainerNo
        {
            get { return txtContainerNo; }
            set
            {
                txtContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainerNo");
            }
        }
        private string txtDriverName = "";
        public string TxtDriverName
        {
            get { return txtDriverName; }
            set
            {
                txtDriverName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDriverName");
            }
        }
        private string txtMobileNumber = "";
        public string TxtMobileNumber
        {
            get { return txtMobileNumber; }
            set
            {
                txtMobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtMobileNumber");
            }
        }
        private string imgdriverLicense = "";
        public string imgDriverLicense
        {
            get { return imgdriverLicense; }
            set
            {
                imgdriverLicense = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDriverLicense");
            }
        }
        bool isenableSubmit = false;
        public bool isEnableSubmit
        {
            get { return isenableSubmit; }
            set
            {
                isenableSubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("isEnableSubmit");
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
        
        private string _strNoRecord = "";
        public string strNoRecord
        {
            get { return _strNoRecord; }
            set
            {
                _strNoRecord = value;
                OnPropertyChanged();
                RaisePropertyChange("strNoRecord");
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
                Tapcontaineradd.ChangeCanExecute();
                Buttonsubmitrequest.ChangeCanExecute();
                Taprequesthistory.ChangeCanExecute();
            }
        }
        public System.Windows.Input.ICommand ButtonEditcontainerlist => new Command<DirectDeliverydt>(fnEditContainer);
        public System.Windows.Input.ICommand ButtonDeletcontainerlist => new Command<DirectDeliverydt>(fnDeletContainer);
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        /// <param name="fstrBayanNo"></param>
        public DirectDeliveryContainerListViewModel(string fstrBayanNo)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DirectDeliveryContainerListViewModel");
            Task.Run(() => assignCms()).Wait();
            Tapcontaineradd = new Command(async () => await tapcontaineradd(), () => !IsBusy);
            Buttonsubmitrequest = new Command(async () => await buttonsubmitrequest(), () => !IsBusy);
            Taprequesthistory = new Command(async () => await taprequesthistory(), () => !IsBusy);
            lblvalBayanNo = fstrBayanNo;
            lblApprovalAttachmentFile = strApproveattachfilename;
            isEnableSubmit = false;
            if (DirectDeliveryModel.lstDelivery.Count > 0) isEnableSubmit = true;
            Task.Run(() => fnBindListData()).Wait();
          
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
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM458");
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
            strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMSG);
            imgDDLIcon = dbLayer.getCaption("imgDDLicon", objCMS);
            lblDDRContainers = dbLayer.getCaption("strDirectDelivery", objCMS);
                lblBOL = dbLayer.getCaption("strBOL", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
            lblDriverDetail = dbLayer.getCaption("strDriverDetail", objCMS);
            lblDriverName = dbLayer.getCaption("strDriver", objCMS);
            lblMobileNumber = dbLayer.getCaption("strMobileNo", objCMS);
            lblDriverLicense = dbLayer.getCaption("strDriverLicenses", objCMS);
            BtnDelete = dbLayer.getCaption("strDelete", objCMS);
            BtnEdit = dbLayer.getCaption("strEdit", objCMS);
            lblBOL1 = dbLayer.getCaption("strBOL", objCMS);
            lblContainerNo1 = dbLayer.getCaption("strContainerNo", objCMS);
            lblDriverDetail1 = dbLayer.getCaption("strDriverDetail", objCMS);
            lblDriverName1 = dbLayer.getCaption("strDriver", objCMS);
            lblMobileNumber1 = dbLayer.getCaption("strMobileNo", objCMS);
            lblDriverLicense1 = dbLayer.getCaption("strDriverLicenses", objCMS);
            BtnDelete1 = dbLayer.getCaption("strDelete", objCMS);
            BtnEdit1 = dbLayer.getCaption("strEdit", objCMS);
            lblBOL2 = dbLayer.getCaption("strBOL", objCMS);
            lblContainerNo2 = dbLayer.getCaption("strContainerNo", objCMS);
            lblDriverDetail2 = dbLayer.getCaption("strDriverDetail", objCMS);
            lblDriverName2 = dbLayer.getCaption("strDriver", objCMS);
            lblMobileNumber2 = dbLayer.getCaption("strMobileNo", objCMS);
            lblDriverLicense2 = dbLayer.getCaption("strDriverLicenses", objCMS);
            BtnDelete2 = dbLayer.getCaption("strDelete", objCMS);
            BtnEdit2 = dbLayer.getCaption("strEdit", objCMS);
            BtnSubmitRequest = dbLayer.getCaption("strSubmit", objCMS);
            imgContainerAdd = dbLayer.getCaption("imgcontaineradd", objCMS);
            lblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            lobjDirectDelivery = dbLayer.getEnum("strDirectDeliveryRequestLov", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To get Bind List Data
        /// </summary>
        /// <returns></returns>
        private async Task fnBindListData()
        {
            await Task.Delay(1000);
            if (DirectDeliveryModel.lstDelivery.Count > 0)
            {
                foreach (var item in DirectDeliveryModel.lstDelivery)
                {
                    item.lbl_Bol = lblBOL;
                    item.lbl_ContainerNo = lblContainerNo;
                    item.lbl_DriverDetail = lblDriverDetail;
                    item.lbl_DriverName = lblDriverName;
                    item.lbl_MobileNo = lblMobileNumber;
                    item.btn_Delet = BtnDelete;
                    item.btn_Edit = BtnEdit;
                    item.lbl_DriverLicense = imgDriverLicense;
                    string base64Image = item.cd_licattachfileimage;
                    byte[] Base64Stream = Convert.FromBase64String(base64Image);
                    item.licattachfileimage = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                   // lstDirectDelivery.Add(item);
                }
                lstDirectDelivery = new ObservableCollection<DirectDeliverydt>(DirectDeliveryModel.lstDelivery);
                await Task.Delay(1000);
                if (lstDelivery.Count > 0) isEnableSubmit = true;
            }
        }
        /// <summary>
        /// To get Submit Request
        /// </summary>
        /// <returns></returns>
        private async Task buttonsubmitrequest()
        {
            IsBusy = true;
            StackDirectDeliveryContainerList = false;
            await Task.Delay(1000);
            await fnsubmitrequest();
            StackDirectDeliveryContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Submit Request
        /// </summary>
        /// <returns></returns>
        private async Task fnsubmitrequest()
        {
            try
            {
                string lstrResult = "";
                string ltxtBayanNo = "";
                string ltxtContainerNo = "";
                string ltxtApprovalAttachment = "";
                string ltxtBillofLadingNo = "";
                string ltxtDriverName = "";
                string ltxtMobileNo = "";
                string ltxtDrivingLicense = "";
                string strTempdate = lobjDirectDelivery[0].Value.ToString();
                string[] lstCaseCode = strTempdate.Split(':');
                string lstrCT_CATEGORYCODE = lstCaseCode[0].ToString();
                string lstrCT_CASETYPECODE = lstCaseCode[1].ToString();
                string lstrCT_CASESUBTYPECODE = lstCaseCode[2].ToString();
                string lstrCT_REQUESTTYPECODE = lstCaseCode[3].ToString();
                string lstrCT_MESSAGE = "{Bayan No: CMAU7826262;1.Container No: ANT1462936;Bill of Lading No: Gate 2;Driver Name:Test;Mobile No:898989898}";
               string lstrCT_CASEGKEY = "4b8e7582-3125-ed11-b7fb-d566c50e2c51";
                string lstrCT_TITLE = "Direct Delivery Request –  {container No} CMAU7826262";
                // string lstrct_reference = "mailto:cielotransporter@gmail.com_20220826142355";
                string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
                string lstrCT_USERNAME = gblRegisteration.strLoginUserLinkcode.ToString().Trim();
                string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (DirectDeliveryModel.lstDelivery.Count > 0)
                {
                    foreach (var item in DirectDeliveryModel.lstDelivery)
                    {
                        ltxtBayanNo = item.cd_bayannumber;
                        ltxtContainerNo = item.cd_containernumber;
                        ltxtBillofLadingNo = item.cd_blnumber;
                        ltxtDriverName = item.cd_DriverName;
                        ltxtMobileNo = item.cd_MobileNo;
                        lstrCT_TITLE = "Direct Delivery Request – " + ltxtContainerNo;
                        ltxtApprovalAttachment = item.cd_approveattachimage;
                        ltxtDrivingLicense = item.cd_licattachfileimage;
                        lstrCT_MESSAGE = "Bayan No :" + ltxtBayanNo + ";Container No :" + ltxtContainerNo + ";Bill of Lading No : " + ltxtBillofLadingNo + ";Driver Name : " + ltxtDriverName + ";Mobile No :" + ltxtMobileNo + ";Approval Attachment : " + ltxtApprovalAttachment + " ;Driving License : " + ltxtDrivingLicense + ";";
                        lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);
                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                }
                if (lstrResult.ToUpper() == "TRUE")
                {
                    DirectDeliveryModel.lstDelivery.Clear();
                    App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryRequestMsg());
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Function for Edit Container
        /// </summary>
        /// <param name="objDirectDelivery"></param>
        private async void fnEditContainer(DirectDeliverydt objDirectDelivery)
        {
            IsBusy = true;
            StackDirectDeliveryContainerList = false;
            await Task.Delay(1000);
            int lintSNO = objDirectDelivery.CD_SNO;
            foreach (var item in DirectDeliveryModel.lstDelivery)
            {
                if (item.CD_SNO == lintSNO)
                {
                    DirectDeliveryModel.lstSelectedDelivery.Clear();
                    DirectDeliveryModel.lstSelectedDelivery.Add(item);
                    App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryRequest2("", "Y"));
                }
            }
            StackDirectDeliveryContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Delete Container
        /// </summary>
        /// <param name="objDirectDelivery"></param>
        private async void fnDeletContainer(DirectDeliverydt objDirectDelivery)
        {
            IsBusy = true;
            StackDirectDeliveryContainerList = false;
            await Task.Delay(1000);
            int lintSNO = objDirectDelivery.CD_SNO;
            var index = DirectDeliveryModel.lstDelivery.FindIndex(x => x.CD_SNO == lintSNO);
            if (index > -1)
            {
                var lstTemp = DirectDeliveryModel.lstDelivery[index];
                DirectDeliveryModel.lstDelivery.Remove(lstTemp);
                App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryContainerList(""));
            }
            StackDirectDeliveryContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Containeradd
        /// </summary>
        /// <returns></returns>
        private async Task tapcontaineradd()
        {
            IsBusy = true;
            StackDirectDeliveryContainerList = false;
            await Task.Delay(1000);

             App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryRequest2("", "N"));

            StackDirectDeliveryContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        ///  To go to Request History
        /// </summary>
        /// <returns></returns>
        private async Task taprequesthistory()
        {
            IsBusy = true;
            StackDirectDeliveryContainerList = false;
            await Task.Delay(1000);
             App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Direct Delivery"));
            StackDirectDeliveryContainerList = true;
            IsBusy = false;
        }
    }
}
