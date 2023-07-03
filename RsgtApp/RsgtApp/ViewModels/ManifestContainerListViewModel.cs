using Microsoft.AppCenter.Analytics;
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
using static RsgtApp.Models.Manifest;

namespace RsgtApp.ViewModels
{
    public class ManifestContainerListViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Editcontainer { get; set; }
        public Command Buttonsubmitrequest { get; set; }
        public Command Tapcontaineradd { get; set; }
        public Command Taprequesthistory { get; set; }
        private string strServerSlowMsg = "";
        public List<ManifestContainerDt> lstManifestDtl { get; set; } = new List<ManifestContainerDt>();
        public List<EnumCombo> lobjManifest { get; set; } = new List<EnumCombo>();
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
        private bool stackManifestContainerList = true;
        public bool StackManifestContainerList
        {
            get { return stackManifestContainerList; }
            set
            {
                stackManifestContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("StackManifestContainerList");
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
        //lblManifestContainersList purpose of using Label varaiable
        private string lblmanifestContainersList = "";
        public string lblManifestContainersList
        {
            get { return lblmanifestContainersList; }
            set
            {
                lblmanifestContainersList = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestContainersList");
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
        //lblBillofLading purpose of using Label varaiable
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
        //lblContainerNo purpose of using Label varaiable
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
        //lblManifestDetail purpose of using Label varaiable
        private string lblmanifestDetail = "";
        public string lblManifestDetail
        {
            get { return lblmanifestDetail; }
            set
            {
                lblmanifestDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestDetail");
            }
        }
        //lblStatus purpose of using Label varaiable
        private string lblstatus = "";
        public string lblStatus
        {
            get { return lblstatus; }
            set
            {
                lblstatus = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStatus");
            }
        }
        //lblComplete purpose of using Label varaiable
        private string lblcomplete = "";
        public string lblComplete
        {
            get { return lblcomplete; }
            set
            {
                lblcomplete = value;
                OnPropertyChanged();
                RaisePropertyChange("lblComplete");
            }
        }
        //BtnDelete purpose of using Button varaiable
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
        //BtnEdit purpose of using Button varaiable
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
        //lblVesselNo1 purpose of using Label varaiable
        private string lblvesselNo1 = "";
        public string lblVesselNo1
        {
            get { return lblvesselNo1; }
            set
            {
                lblvesselNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVesselNo1");
            }
        }
        //lblVoyageNo1 purpose of using Label varaiable
        private string lblvoyageNo1 = "";
        public string lblVoyageNo1
        {
            get { return lblvoyageNo1; }
            set
            {
                lblvoyageNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVoyageNo1");
            }
        }
        //lblBillofLading1 purpose of using Label varaiable
        private string lblbillofLading1 = "";
        public string lblBillofLading1
        {
            get { return lblbillofLading1; }
            set
            {
                lblbillofLading1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBillofLading1");
            }
        }
        //lblContainerNo1 purpose of using Label varaiable
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
        //lblManifestDetail1 purpose of using Label varaiable
        private string lblmanifestDetail1 = "";
        public string lblManifestDetail1
        {
            get { return lblmanifestDetail1; }
            set
            {
                lblmanifestDetail1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestDetail1");
            }
        }
        //lblStatus1 purpose of using Label varaiable
        private string lblstatus1 = "";
        public string lblStatus1
        {
            get { return lblstatus1; }
            set
            {
                lblstatus1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStatus1");
            }
        }
        //lblNotAvailable purpose of using Label varaiable
        private string lblnotAvailable = "";
        public string lblNotAvailable
        {
            get { return lblnotAvailable; }
            set
            {
                lblnotAvailable = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNotAvailable");
            }
        }
        //BtnDelete1 purpose of using Button varaiable
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
        //BtnEdit1 purpose of using Button varaiable
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
        //lblVesselNo2 purpose of using Label varaiable
        private string lblvesselNo2 = "";
        public string lblVesselNo2
        {
            get { return lblvesselNo2; }
            set
            {
                lblvesselNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVesselNo2");
            }
        }
        //lblVoyageNo2 purpose of using Label varaiable
        private string lblvoyageNo2 = "";
        public string lblVoyageNo2
        {
            get { return lblvoyageNo2; }
            set
            {
                lblvoyageNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVoyageNo2");
            }
        }
        //lblBillofLading2 purpose of using Label varaiable
        private string lblbillofLading2 = "";
        public string lblBillofLading2
        {
            get { return lblbillofLading2; }
            set
            {
                lblbillofLading2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBillofLading2");
            }
        }
        //lblContainerNo2 purpose of using Label varaiable
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
        //lblManifestDetail2 purpose of using Label varaiable
        private string lblmanifestDetail2 = "";
        public string lblManifestDetail2
        {
            get { return lblmanifestDetail2; }
            set
            {
                lblmanifestDetail2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestDetail2");
            }
        }
        //lblStatus2 purpose of using Label varaiable
        private string lblstatus2 = "";
        public string lblStatus2
        {
            get { return lblstatus2; }
            set
            {
                lblstatus2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStatus2");
            }
        }
        //lblInProcess purpose of using Label varaiable
        private string lblinProcess = "";
        public string lblInProcess
        {
            get { return lblinProcess; }
            set
            {
                lblinProcess = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInProcess");
            }
        }
        //BtnDelete2 purpose of using Button varaiable
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
        //BtnEdit2 purpose of using Button varaiable
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
        //lblNotes purpose of using Label varaiable
        private string lblnotes = "";
        public string lblNotes
        {
            get { return lblnotes; }
            set
            {
                lblnotes = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNotes");
            }
        }
        //TxtNotes purpose of using Textbox varaiable
        private string Txtnotes = "";
        public string TxtNotes
        {
            get { return Txtnotes; }
            set
            {
                Txtnotes = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtNotes");
            }
        }
        //BtnSubmitRequest purpose of using Button varaiable
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
        //imgContaineraddIcon purpose of using Image varaiable
        private string imgcontaineraddIcon = "";
        public string imgContaineraddIcon
        {
            get { return imgcontaineraddIcon; }
            set
            {
                imgcontaineraddIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgContaineraddIcon");
            }
        }
        //lblAddContainer purpose of using Validation
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
        //lblValueVesselNo purpose of using Validation
        private string lblvalueVesselNo = "";
        public string lblValueVesselNo
        {
            get { return lblvalueVesselNo; }
            set
            {
                lblvalueVesselNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueVesselNo");
            }
        }
        //lblValueVoyageNo purpose of using Label varaiable
        private string lblvalueVoyageNo = "";
        public string lblValueVoyageNo
        {
            get { return lblvalueVoyageNo; }
            set
            {
                lblvalueVoyageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueVoyageNo");
            }
        }
        //lblValueBillofLading purpose of using Validation
        private string lblvalueBillofLading = "";
        public string lblValueBillofLading
        {
            get { return lblvalueBillofLading; }
            set
            {
                lblvalueBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueBillofLading");
            }
        }
        //lblValueContainerNo purpose of using Validation
        private string lblvalueContainerNo = "";
        public string lblValueContainerNo
        {
            get { return lblvalueContainerNo; }
            set
            {
                lblvalueContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueContainerNo");
            }
        }
        //lblValueManifestDetail purpose of using Validation
        private string lblvalueManifestDetail = "";
        public string lblValueManifestDetail
        {
            get { return lblvalueManifestDetail; }
            set
            {
                lblvalueManifestDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueManifestDetail");
            }
        }
        //lblValueVesselNo1 purpose of using Validation
        private string lblvalueVesselNo1 = "";
        public string lblValueVesselNo1
        {
            get { return lblvalueVesselNo1; }
            set
            {
                lblvalueVesselNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueVesselNo1");
            }
        }
        //lblValueVoyageNo1 purpose of using Validation
        private string lblvalueVoyageNo1 = "";
        public string lblValueVoyageNo1
        {
            get { return lblvalueVoyageNo1; }
            set
            {
                lblvalueVoyageNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueVoyageNo1");
            }
        }
        //lblValueBillofLading1 purpose of using Validation
        private string lblvalueBillofLading1 = "";
        public string lblValueBillofLading1
        {
            get { return lblvalueBillofLading1; }
            set
            {
                lblvalueBillofLading1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueBillofLading1");
            }
        }
        //lblValueContainerNo1 purpose of using Validation
        private string lblvalueContainerNo1 = "";
        public string lblValueContainerNo1
        {
            get { return lblvalueContainerNo1; }
            set
            {
                lblvalueContainerNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueContainerNo1");
            }
        }
        //lblValueManifestDetail1 purpose of using Validation
        private string lblvalueManifestDetail1 = "";
        public string lblValueManifestDetail1
        {
            get { return lblvalueManifestDetail1; }
            set
            {
                lblvalueManifestDetail1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueManifestDetail1");
            }
        }
        //lblValueVesselNo2 purpose of using Validation
        private string lblvalueVesselNo2 = "";
        public string lblValueVesselNo2
        {
            get { return lblvalueVesselNo2; }
            set
            {
                lblvalueVesselNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueVesselNo2");
            }
        }
        //lblValueVoyageNo2 purpose of using Validation
        private string lblvalueVoyageNo2 = "";
        public string lblValueVoyageNo2
        {
            get { return lblvalueVoyageNo2; }
            set
            {
                lblvalueVoyageNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueVoyageNo2");
            }
        }
        //lblValueBillofLading2 purpose of using Validation
        private string lblvalueBillofLading2 = "";
        public string lblValueBillofLading2
        {
            get { return lblvalueBillofLading2; }
            set
            {
                lblvalueBillofLading2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueBillofLading2");
            }
        }
        //lblValueContainerNo2 purpose of using Validation
        private string lblvalueContainerNo2 = "";
        public string lblValueContainerNo2
        {
            get { return lblvalueContainerNo2; }
            set
            {
                lblvalueContainerNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueContainerNo2");
            }
        }
        //lblValueManifestDetail2 purpose of using Validation
        private string lblvalueManifestDetail2 = "";
        public string lblValueManifestDetail2
        {
            get { return lblvalueManifestDetail2; }
            set
            {
                lblvalueManifestDetail2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValueManifestDetail2");
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
        //To Handel Boolen Value
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
        private string lblvalvesselNo = "";  
        private string lblvalvoyageNo = "";
        private string lblvalbOLNo = "";      
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
                //Editcontainer.ChangeCanExecute();
                Buttonsubmitrequest.ChangeCanExecute();
                Tapcontaineradd.ChangeCanExecute();
                Taprequesthistory.ChangeCanExecute();
            }
        }
        //public System.Windows.Input.ICommand ButtonEditcontainerlist => new Command<ManifestContainerDt>(fnEditContainer);
        public System.Windows.Input.ICommand ButtonDeletcontainerlist => new Command<ManifestContainerDt>(fnDeletContainer);
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="fstrVesselno"></param>
        /// <param name="fstrVoyageno"></param>
        /// <param name="fstrBOLno"></param>
        public ManifestContainerListViewModel(string fstrVesselno, string fstrVoyageno, string fstrBOLno)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ManifestContainerListViewModel");
            Task.Run(() => assignCms()).Wait();
            // Editcontainer = new Command(async () => await editcontainer(), () => !IsBusy);
            Buttonsubmitrequest = new Command(async () => await buttonsubmitrequest(), () => !IsBusy);
            Tapcontaineradd = new Command(async () => await tapcontaineradd(), () => !IsBusy);
            Taprequesthistory = new Command(async () => await taprequesthistory(), () => !IsBusy);
            lblvalvesselNo = fstrVesselno;
            lblvalvoyageNo = fstrVoyageno;
            lblvalbOLNo = fstrBOLno;
            isEnableSubmit = false;
            if (Manifest.lstManifest.Count > 0) isEnableSubmit = true;
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
           
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            imgManifestIcon = dbLayer.getCaption("imgManifest", objCMS);
            lblManifestContainersList = dbLayer.getCaption("strManifestContainersList", objCMS);
            lblVesselNo = dbLayer.getCaption("strVesselNo", objCMS);
            lblVoyageNo = dbLayer.getCaption("strVoyageNo", objCMS);
            lblBillofLading = dbLayer.getCaption("strBillofLading", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
            lblManifestDetail = dbLayer.getCaption("strManifestDetail", objCMS);
            lblStatus = dbLayer.getCaption("strStatus", objCMS);
            lblComplete = dbLayer.getCaption("strComplete", objCMS);
            BtnDelete = dbLayer.getCaption("strDelete", objCMS);
            BtnEdit = dbLayer.getCaption("strEdit", objCMS);
            lblVesselNo1 = dbLayer.getCaption("strVesselNo", objCMS);
            lblVoyageNo1 = dbLayer.getCaption("strVoyageNo", objCMS);
            lblBillofLading1 = dbLayer.getCaption("strBillofLading", objCMS);
            lblContainerNo1 = dbLayer.getCaption("strContainerNo", objCMS);
            lblManifestDetail1 = dbLayer.getCaption("strManifestDetail", objCMS);
            lblStatus1 = dbLayer.getCaption("strStatus", objCMS);
            lblNotAvailable = dbLayer.getCaption("strNotAvailable", objCMS);
            BtnDelete1 = dbLayer.getCaption("strDelete", objCMS);
            BtnEdit1 = dbLayer.getCaption("strEdit", objCMS);
            lblVesselNo2 = dbLayer.getCaption("strVesselNo", objCMS);
            lblVoyageNo2 = dbLayer.getCaption("strVoyageNo", objCMS);
            lblBillofLading2 = dbLayer.getCaption("strBillofLading", objCMS);
            lblContainerNo2 = dbLayer.getCaption("strContainerNo", objCMS);
            lblManifestDetail2 = dbLayer.getCaption("strManifestDetail", objCMS);
            lblStatus2 = dbLayer.getCaption("strStatus", objCMS);
            lblInProcess = dbLayer.getCaption("strInprocess", objCMS);
            BtnDelete2 = dbLayer.getCaption("strDelete", objCMS);
            BtnEdit2 = dbLayer.getCaption("strEdit", objCMS);
            lblNotes = dbLayer.getCaption("strNotes", objCMS);
            BtnSubmitRequest = dbLayer.getCaption("strSubmitRequest", objCMS);
            imgContaineraddIcon = dbLayer.getCaption("imgContaineradd", objCMS);
            lblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            lobjManifest = dbLayer.getEnum("strManifestRequestLov", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            await Task.Delay(1000);
        }
        /// <summary>
        /// To get fnBindListData
        /// </summary>
        /// <returns></returns>
        private async Task fnBindListData()
        {
            await Task.Delay(1000);
            if (Manifest.lstManifest.Count > 0)
            {
                foreach (var item in Manifest.lstManifest)
                {
                    item.lbl_ContainerNo = lblContainerNo;
                    item.lbl_BOL = lblBillofLading;
                    item.lbl_VesseNo = lblVesselNo;
                    item.lbl_VoyageNo = lblVoyageNo;
                    item.lbl_ManifestDetails = lblManifestDetail;
                    item.lbl_Status = lblStatus;
                    item.Btn_Delete = BtnDelete;
                    item.Btn_Edit = BtnEdit;
                    lstManifestDtl.Add(item);
                }
                await Task.Delay(1000);
                if (lstManifestDtl.Count > 0) isEnableSubmit = true;
            }
        }
        /// <summary>
        /// To get buttonsubmitrequest
        /// </summary>
        /// <returns></returns>
        private async Task buttonsubmitrequest()
        {
            IsBusy = true;
            StackManifestContainerList = false;
            await Task.Delay(1000);
            await fnsubmitrequest();
            // App.Current.MainPage?.Navigation.PushAsync(new ManifestRequestMsg());
            StackManifestContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get fnsubmitrequest
        /// </summary>
        /// <returns></returns>
        private async Task fnsubmitrequest()
        {
            string lstrResult = "";
            string txtContainerNumber = "";
            string txtBillofLadingNumber = "";
            string txtVoyageNo = "";
            string txtVesselNo = "";
            string txtNotes = "";
            //   Containers No Manifest      Status=(Inprogress)     
            string strTempdate = lobjManifest[0].Value.ToString();
            string[] lstCaseCode = strTempdate.Split(':');
            string lstrCT_CATEGORYCODE = lstCaseCode[0].ToString();
            string lstrCT_CASETYPECODE = lstCaseCode[1].ToString();
            string lstrCT_CASESUBTYPECODE = lstCaseCode[2].ToString();
            string lstrCT_REQUESTTYPECODE = lstCaseCode[3].ToString();
            //  Containers Not Available      Status=(Not Available)   
            string strTempdate1 = lobjManifest[1].Value.ToString();
            string[] lstCaseCode1 = strTempdate1.Split(':');
            string lstrCT_CATEGORYCODE1 = lstCaseCode[0].ToString();
            string lstrCT_CASETYPECODE1 = lstCaseCode[1].ToString();
            string lstrCT_CASESUBTYPECODE1 = lstCaseCode[2].ToString();
            string lstrCT_REQUESTTYPECODE1 = lstCaseCode[3].ToString();
            string lstrCT_MESSAGE = "";
            string lstrCT_MESSAGE1 = "";
            string lstrCT_CASEGKEY = "";
            string lstrCT_TITLE = "";
            // string lstrct_reference = "mailto:cielotransporter@gmail.com_20220826142355";
            string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
            string lstrCT_USERNAME = gblRegisteration.strLoginUserLinkcode.ToString().Trim();
            string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
            string lstrStatus = "";
            if (Manifest.lstManifest.Count > 0)
            {
                foreach (var item in Manifest.lstManifest)
                {
                    txtContainerNumber = item.cd_containernumber;
                    txtBillofLadingNumber = item.cd_blnumber;
                    txtVoyageNo = item.vd_ibvoyage;
                    txtVesselNo = item.vd_visitid;
                    lstrStatus = item.cd_status;
                    txtNotes = item.cd_Notes;
                    lstrCT_TITLE = "Manifest Confirmation";//20221115
                    //if (lstrStatus == "Completed")
                    //{
                    //    lstrCT_MESSAGE += "Vessel No :" + txtVesselNo + ";Voyage No :" + txtVoyageNo + ";Bill of Lading : " + txtBillofLadingNumber + ";Container No : " + txtContainerNumber + ";Notes :" + txtNotes + ";~";

                    //}
                    if (lstrStatus == "Inprogress")
                    {
                        lstrCT_MESSAGE += "Vessel No :" + txtVesselNo + ";Voyage No :" + txtVoyageNo + ";Bill of Lading : " + txtBillofLadingNumber + ";Container No : " + txtContainerNumber + ";Notes :" + txtNotes + ";~";

                    }
                    if (lstrStatus == "Containers Not Available")
                    {
                        lstrCT_MESSAGE1 += "Vessel No :" + txtVesselNo + ";Voyage No :" + txtVoyageNo + ";Bill of Lading : " + txtBillofLadingNumber + ";Container No : " + txtContainerNumber + ";Notes :" + txtNotes + ";~";
                    }
                }
                //if (lstrStatus == "Completed")
                //{
                //    lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);

                //}
                if (lstrStatus == "Inprogress")
                {
                    lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                }
                if (lstrStatus == "Containers Not Available")
                {
                    lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE1, lstrCT_CASETYPECODE1, lstrCT_CASESUBTYPECODE1, lstrCT_REQUESTTYPECODE1, lstrCT_MESSAGE1, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                }
                if (lstrResult.ToUpper() == "TRUE")
                {
                    Manifest.lstManifest.Clear();
                    await App.Current.MainPage?.Navigation.PushAsync(new ManifestRequestMsg());
                }
                if (lstrResult.ToUpper() == "")
                {
                    Manifest.lstManifest.Clear();
                    await App.Current.MainPage?.Navigation.PushAsync(new ManifestContainerList("", "", ""));
                }
            }
        }
        /// <summary>
        /// To get fnDeletContainer
        /// </summary>
        /// <param name="objManiFest"></param>
        private async void fnDeletContainer(ManifestContainerDt objManiFest)
        {
            int lintSNO = objManiFest.CD_SNO;
            var index = Manifest.lstManifest.FindIndex(x => x.CD_SNO == lintSNO);
            if (index > -1)
            {
                var lstTemp = Manifest.lstManifest[index];
                Manifest.lstManifest.Remove(lstTemp);
                await App.Current.MainPage?.Navigation.PushAsync(new ManifestContainerList("", "", ""));
            }
        }
        /// <summary>
        /// To get tapcontaineradd
        /// </summary>
        /// <returns></returns>
        private async Task tapcontaineradd()
        {
            IsBusy = true;
            StackManifestContainerList = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ManifestUpdateRequest2(lblvalvesselNo, lblvalvoyageNo,lblvalbOLNo, "N"));
            StackManifestContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get taprequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task taprequesthistory()
        {
            IsBusy = true;
            StackManifestContainerList = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Manifest Confirmation"));
            StackManifestContainerList = true;
            IsBusy = false;
        }
    }
}