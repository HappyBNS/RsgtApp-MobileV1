using Plugin.FilePicker;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.DamageContainerModel;

namespace RsgtApp.ViewModels
{
    class DamageContainerViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        
        private string strLanguage = App.gblLanguage;
        //Object creating for Business Layer
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        //CMS caption list
        Dictionary<string, string> lobjDamageContainer = new Dictionary<string, string>();

        //Button_Clicked Button
        public Command Button_Clicked { get; set; }
        //btnCancel Button
        public Command btnCancel { get; set; }
        //gotoDamageContainerMessage Button
        public Command gotoDamageContainerMessage { get; set; }
        //gotoRetreiveData Button
        public Command gotoRetreiveData { get; set; }
        //Assign Static Variables
        string strFileName = "";
        string strFileType = "";
        string strFileBody = "";
        string strServerSlowMsg = "";
        //To create Collection Object used ObservableCollection
        public ObservableCollection<DamageContainerdt> lstBody { get; }
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
        //To handle Boolean Variable
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

        public List<EnumCombo> _lobjTypeOfDamage { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjTypeOfDamage
        {
            get { return _lobjTypeOfDamage; }
            set
            {
                if (_lobjTypeOfDamage == value)
                    return;
                _lobjTypeOfDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjTypeOfDamage");
            }
        }
        public List<EnumCombo> _lobjCauseDamage { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjCauseDamage
        {
            get { return _lobjCauseDamage; }
            set
            {
                if (_lobjCauseDamage == value)
                    return;
                _lobjCauseDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCauseDamage");
            }
        }

        //_selectedTypeOfDamage Combo Variable
        private EnumCombo _selectedTypeOfDamage;
        public EnumCombo SelectedTypeOfDamage
        {
            get { return _selectedTypeOfDamage; }
            set
            {
                SetProperty(ref _selectedTypeOfDamage, value);

            }
        }
        //_selectedCauseDamage Combo Variable
        private EnumCombo _selectedCauseDamage;
        public EnumCombo SelectedCauseDamage
        {
            get { return _selectedCauseDamage; }
            set
            {
                SetProperty(ref _selectedCauseDamage, value);
            }
        }
        //imgrequestIcon purpose of using Image Variable
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
        //lblreportDamage purpose of using text Variable
        private string lblreportDamage = "";
        public string lblReportDamage
        {
            get { return lblreportDamage; }
            set
            {
                lblreportDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblReportDamage");
            }
        }
        //lblcontainerNo purpose of using text Variable
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
        //placeContainerNo purpose of using text Variable
        private string placeContainerNo = "";
        public string PlaceContainerNo
        {
            get { return placeContainerNo; }
            set
            {
                placeContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceContainerNo");
            }
        }
        //msgcontainerno purpose of using text Variable
        private string msgcontainerno = "";
        public string MsgContainerNo
        {
            get { return msgcontainerno; }
            set
            {
                msgcontainerno = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgContainerNo");
            }
        }
        //lblbillOfLading purpose of using text Variable
        private string lblbillOfLading = "";
        public string lblBillOfLading
        {
            get { return lblbillOfLading; }
            set
            {
                lblbillOfLading = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBillOfLading");
            }
        }
        //txtBOLNo purpose of using text Variable
        private string txtBOLNo = "";
        public string TxtBOLNo
        {
            get { return txtBOLNo; }
            set
            {
                txtBOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOLNo");
            }
        }
        //placeBOLNo purpose of using text Variable
        private string placeBOLNo = "";
        public string PlaceBOLNo
        {
            get { return placeBOLNo; }
            set
            {
                placeBOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBOLNo");
            }
        }
        //msgBOLNo purpose of using text Variable
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
        //lbltypeOfDamage purpose of using text Variable
        private string lbltypeOfDamage = "";
        public string lblTypeOfDamage
        {
            get { return lbltypeOfDamage; }
            set
            {
                lbltypeOfDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTypeOfDamage");
            }
        }
        //msgTypeofDamage purpose of using text Variable
        private string msgTypeofDamage = "";
        public string MsgTypeofDamage
        {
            get { return msgTypeofDamage; }
            set
            {
                msgTypeofDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTypeofDamage");
            }
        }
        //lblreportDate purpose of using text Variable
        private string lblreportDate = "";
        public string lblReportDate
        {
            get { return lblreportDate; }
            set
            {
                lblreportDate = value;
                OnPropertyChanged();
                RaisePropertyChange("lblReportDate");
            }
        }
        //lblcauseDamage purpose of using text Variable
        private string lblcauseDamage = "";
        public string lblCauseDamage
        {
            get { return lblcauseDamage; }
            set
            {
                lblcauseDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCauseDamage");
            }
        }
        //msgCauseofDamage purpose of using text Variable
        private string msgCauseofDamage = "";
        public string MsgCauseofDamage
        {
            get { return msgCauseofDamage; }
            set
            {
                msgCauseofDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCauseofDamage");
            }
        }
        //btnretreiveDetail purpose of using text Variable
        private string btnretreiveDetail = "";
        public string btnRetreiveDetail
        {
            get { return btnretreiveDetail; }
            set
            {
                btnretreiveDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("btnRetreiveDetail");
            }
        }
        //lblcontainerValidMg purpose of using text Variable
        private string lblcontainerValidMg = "";
        public string lblContainerValidMg
        {
            get { return lblcontainerValidMg; }
            set
            {
                lblcontainerValidMg = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerValidMg");
            }
        }
        //lbldischarge purpose of using text Variable
        private string lbldischarge = "";
        public string lblDischarge
        {
            get { return lbldischarge; }
            set
            {
                lbldischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDischarge");
            }
        }
        //lblvalDisharge purpose of using text Variable
        private string lblvalDisharge = "";
        public string lblValDisharge
        {
            get { return lblvalDisharge; }
            set
            {
                lblvalDisharge = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValDisharge");
            }
        }
        //lblgateOut purpose of using text Variable
        private string lblgateOut = "";
        public string lblGateOut
        {
            get { return lblgateOut; }
            set
            {
                lblgateOut = value;
                OnPropertyChanged();
                RaisePropertyChange("lblGateOut");
            }
        }
        //lblvalGateout purpose of using text Variable
        private string lblvalGateout = "";
        public string lblValGateout
        {
            get { return lblvalGateout; }
            set
            {
                lblvalGateout = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValGateout");
            }
        }
        //lblemptyDepot purpose of using text Variable
        private string lblemptyDepot = "";
        public string lblEmptyDepot
        {
            get { return lblemptyDepot; }
            set
            {
                lblemptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmptyDepot");
            }
        }
        //lblvalEmptyDepot purpose of using text Variable
        private string lblvalEmptyDepot = "";
        public string lblValEmptyDepot
        {
            get { return lblvalEmptyDepot; }
            set
            {
                lblvalEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValEmptyDepot");
            }
        }
        //lbldamageRemarks purpose of using text Variable
        private string lbldamageRemarks = "";
        public string lblDamageRemarks
        {
            get { return lbldamageRemarks; }
            set
            {
                lbldamageRemarks = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDamageRemarks");
            }
        }
        //lblvalDamageRemark purpose of using text Variable
        private string lblvalDamageRemark = "";
        public string lblValDamageRemark
        {
            get { return lblvalDamageRemark; }
            set
            {
                lblvalDamageRemark = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValDamageRemark");
            }
        }
        //lbldamageAttached purpose of using text Variable
        private string lbldamageAttached = "";
        public string lblDamageAttached
        {
            get { return lbldamageAttached; }
            set
            {
                lbldamageAttached = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDamageAttached");
            }
        }
        //lblattachment purpose of using text Variable
        private string lblattachment = "";
        public string lblAttachment
        {
            get { return lblattachment; }
            set
            {
                lblattachment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttachment");
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
        //o handle boolean variable
        private bool msgcontainerNo = false;
        public bool msgContainerNo
        {
            get { return msgcontainerNo; }
            set
            {
                msgcontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("msgContainerNo");
            }
        }
        //lblsubmit purpose of using text Variable
        private string lblsubmit = "";
        public string lblSubmit
        {
            get { return lblsubmit; }
            set
            {
                lblsubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSubmit");
            }
        }
        //txtContainerNo purpose of using text Variable
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
        //To handle Boolean variable
        private bool damageEn = true;
        public bool DamageEn
        {
            get { return damageEn; }
            set
            {
                damageEn = value;
                OnPropertyChanged();
                RaisePropertyChange("DamageEn");
            }
        }
        private bool isValidatedContainerMsg = false;
        public bool IsValidatedContainerMsg
        {
            get { return isValidatedContainerMsg; }
            set
            {
                isValidatedContainerMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("IsValidatedContainerMsg");
            }
        }
        //To handle Boolean variable
        private bool isvalidatedContainerNo = false;
        public bool IsvalidatedContainerNo
        {
            get { return isvalidatedContainerNo; }
            set
            {
                isvalidatedContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedContainerNo");
            }
        }
        //To handle Boolean variable
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
        //To handle Boolean variable
        private bool isvalidatedTypeDamage = false;
        public bool IsvalidatedTypeDamage
        {
            get { return isvalidatedTypeDamage; }
            set
            {
                isvalidatedTypeDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedTypeDamage");
            }
        }
        //To handle Boolean variable
        private bool isvalidatedCauseDamage = false;
        public bool IsvalidatedCauseDamage
        {
            get { return isvalidatedCauseDamage; }
            set
            {
                isvalidatedCauseDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCauseDamage");
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
        //To handle Boolean variable
        private string txtDescribtion = "";
        public string TxtDescribtion
        {
            get { return txtDescribtion; }
            set
            {
                txtDescribtion = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDescribtion");
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
        //To handle Boolean Variable
        private bool msgbOLNo = false;
        public bool msgbolNo
        {
            get { return msgbOLNo; }
            set
            {
                msgbOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("msgbolNo");
            }
        }
        //To handle Boolean Variable
        private bool msgtypeofDamage = false;
        public bool msgtypeofdamage
        {
            get { return msgtypeofDamage; }
            set
            {
                msgtypeofDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("msgtypeofdamage");
            }
        }
        //To handle boolean Variable
        private bool lblcontainervalidMg = false;
        public bool lblContainerValidmg
        {
            get { return lblcontainervalidMg; }
            set
            {
                lblcontainervalidMg = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContainerValidmg");
            }
        }
        //To handle Boolean variable
        private bool msgcauseofDamage = false;
        public bool msgCauseofdamage
        {
            get { return msgcauseofDamage; }
            set
            {
                msgcauseofDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("msgCauseofdamage");
            }
        }
        //Date Picker
        private DateTime? DtreportDate = null;
        public DateTime? DtReportDate
        {
            get { return DtreportDate; }
            set
            {
                DtreportDate = value;
                OnPropertyChanged();
                RaisePropertyChange("DtReportDate");
            }
        }
        //To handle boolean Variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Button_Clicked.ChangeCanExecute();
                gotoDamageContainerMessage.ChangeCanExecute();
                btnCancel.ChangeCanExecute();
                gotoRetreiveData.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin DamageContainerViewModel Constructor
        /// </summary>
        public DamageContainerViewModel()
        {
            try
            {
                Task.Run(() => assignCms()).Wait();
                lstBody = new ObservableCollection<DamageContainerdt>();
                Button_Clicked = new Command(async () => await button_Clicked(), () => !IsBusy);
                gotoDamageContainerMessage = new Command(async () => await gotodamageContainerMessage(), () => !IsBusy);
                btnCancel = new Command(async () => await btncancel(), () => !IsBusy);
                gotoRetreiveData = new Command(async () => await gotoretreiveData(), () => !IsBusy);
                Task.Run(() => HideErrorMsg()).Wait();

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Bind CMS Caption
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM415");
                    objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM415");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Assign CMS caption Content
        /// </summary>
        public async void assignContent()
        {
            try
            {
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
                dbLayer.objInfoitems = objCMS;
                imgRequestIcon = dbLayer.getCaption("imgRequestIcon", objCMS);
                lblReportDamage = dbLayer.getCaption("strReportDamageContainerForm", objCMS);
                lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
                lblBillOfLading = dbLayer.getCaption("strBillofLading", objCMS);
                lblTypeOfDamage = dbLayer.getCaption("strTypeofDamage", objCMS);
                lblReportDate = dbLayer.getCaption("strReportDate", objCMS);
                lblCauseDamage = dbLayer.getCaption("strCauseofDamage", objCMS);
                btnRetreiveDetail = dbLayer.getCaption("strRetreiveContainerDetail", objCMS);
                lblContainerValidMg = dbLayer.getCaption("strcontainerEnteredisNotValid", objCMS);
                lblDischarge = dbLayer.getCaption("strDischarge", objCMS);
                lblGateOut = dbLayer.getCaption("strGateOut", objCMS);
                lblEmptyDepot = dbLayer.getCaption("strEmptyDepot", objCMS);
                lblDamageRemarks = dbLayer.getCaption("strDamageRemarks", objCMS);
                lblDamageAttached = dbLayer.getCaption("strDamageFoundAttachedPhotos", objCMS);
                lblAttachment = dbLayer.getCaption("strAttachment", objCMS);
                lblSubmit = dbLayer.getCaption("strSubmit", objCMS);
                BtnChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
                msgTypeofDamage = dbLayer.getCaption("strMandatory", objCMSMSG);
                msgBOLNo = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMSG);
                msgTypeofDamage = dbLayer.getCaption("strMandatory", objCMSMSG);
                lobjTypeOfDamage = dbLayer.getEnum("strTypeofdamagelov", objCMS);
                lobjDamageContainer =  dbLayer.getRequestLOV("strDamageContainerlov", objCMS);
                lobjCauseDamage = dbLayer.getEnum("strCauseofdamagelov", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get button_Clicked button
        /// </summary>
        /// <returns></returns>
        private async Task button_Clicked()
        {
            try
            {
                IsBusy = true;
                DamageEn = false;
                await Task.Delay(10000);
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    // same as iOS constant UTType.Image
                    fileTypes = new string[] { "com.adobe.pdf", "public.rft", "com.microsoft.word.doc", "org.openxmlformats.wordprocessingml.document" };
                }
                await PickAndShow(fileTypes);
                DamageEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow(string[] fileTypes)
        {
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
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To load gotoretreiveData caption
        /// </summary>
        /// <returns></returns>
        private async Task gotodamageContainerMessage()
        {
            IsBusy = true;
            DamageEn = false;
            await Task.Delay(1000);
            var lstrContainerNo = "";
            var lstrBOLNo = "";
            var lstrTypeofDamage = "";
            var lstrDate = "";
            var lstrCauseofDamage = "";
            string lstrDamagemsg = "";
            var lstrResult = "";
            try
            {
                // HideErrorMsg();
                if ((TxtContainerNo == null) || (TxtContainerNo == ""))
                {
                    IsvalidatedContainerNo = true;
                }
                else
                {
                    lstrContainerNo = TxtContainerNo;
                    gblTrackRequests.strContainerNo = TxtContainerNo;
                    IsvalidatedContainerNo = false;
                }
                if ((TxtBOLNo == null) || (TxtBOLNo == ""))
                {
                    IsvalidatedBOLNo = true;
                }
                else
                {
                    lstrBOLNo = TxtBOLNo;
                    gblTrackRequests.strBOLNo = TxtBOLNo;
                    IsvalidatedBOLNo = false;
                }
                if (_selectedTypeOfDamage == null)
                {
                    IsvalidatedTypeDamage = true;
                }
                else
                {
                    gblTrackRequests.strTypeofDamage = SelectedTypeOfDamage.Value;
                    IsvalidatedTypeDamage = false;
                }
                if (DtReportDate != null)
                {
                    //lstrDate = DtReportDate;
                     lstrDate = DtReportDate.Value.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss") + "Z";
                }
                lstrDamagemsg = lblContainerNo + lstrContainerNo + lblBillOfLading + lstrBOLNo + lblTypeOfDamage + lstrTypeofDamage + lblCauseDamage + lstrCauseofDamage;
                if ((IsvalidatedTypeDamage != true) && (IsvalidatedBOLNo != true) && (IsvalidatedContainerNo != true))
                {
                    string lstrDamageContainer = "";
                    foreach (var item in lobjDamageContainer)
                    {
                        lstrDamageContainer = item.Key;
                    }
                    string[] lstrTemp = lstrDamageContainer.Split(':');
                    gblTrackRequests.strTitle = "Report Damage Container";
                    gblTrackRequests.strCategoryCode = lstrTemp[0];
                    gblTrackRequests.strCategoryDesc1 = "";
                    gblTrackRequests.strCategoryDesc2 = "";
                    gblTrackRequests.strCaseCode = lstrTemp[1];
                    gblTrackRequests.strCaseDesc1 = "";
                    gblTrackRequests.strCaseDesc2 = "";
                    gblTrackRequests.strRequestTypeCode = lstrTemp[2];
                    gblTrackRequests.strRequestTypeDesc1 = "";
                    gblTrackRequests.strRequestTypeDesc2 = "";
                    gblTrackRequests.strSubCaseCode = lstrTemp[3];
                    gblTrackRequests.strSubCaseDesc1 = "";
                    gblTrackRequests.strSubCaseDesc2 = "";
                    await gblRegisteration.getreguser();
                    lstrResult = objWebApi.postWebApi("NewTruckService", gblTrackRequests.TruckRequest(lstrDamagemsg, lstrDate));
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    gblTrackRequests.strFileName = strFileName;
                    gblTrackRequests.strFileType = strFileType;
                    gblTrackRequests.strFileBody = strFileBody;
                    lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    if (lstrResult.ToUpper().Trim() == "TRUE")
                    {
                        gblTrackRequests.strDescription = txtDescribtion;
                        objWebApi.postWebApi("PostSendEmail", gblTrackRequests.DamageContainerMailData(lstrDate, lstrDamagemsg));
                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                        await App.Current.MainPage?.Navigation.PushAsync(new DamageContainer_Message());
                    }
                }
                DamageEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To load gotoretreiveData caption
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBLNo"></param>
        /// <returns></returns>
        private async Task fnDamageContainerBody(string fstrContainerNo, string fstrBLNo)
        {
            
            var objRawData = new List<DamageContainerdt>();
            try
            {
                objRawData = objBl.DamageContainerBody(fstrContainerNo, fstrBLNo);
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((objRawData != null) && (objRawData.Count > 0))
                {
                    lblValDisharge = objRawData.ToArray()[0].cd_fmtdiscrecivaltime;
                    lblvalGateout = objRawData.ToArray()[0].cd_fmtgatedouttime;
                    lblValEmptyDepot = objRawData.ToArray()[0].cd_emptydepot;
                    lblValDamageRemark = objRawData.ToArray()[0].cd_damagedetails;
                }
                else
                {
                    IsValidatedContainerMsg = true;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To load gotoretreiveData caption
        /// </summary>
        /// <returns></returns>
        private async Task gotoretreiveData()
        {
            try
            {
                IsBusy = true;
                DamageEn = false;
                await Task.Delay(1000);
                msgContainerNo = false;
                msgbOLNo = false;
                var lstrContainerNo = "";
                var lstrBOLNo = "";
                var lstrDate = "";
                var ContainerNo = TxtContainerNo;
                var BOLNo = TxtBOLNo;
                if ((TxtContainerNo == null) || (TxtContainerNo == ""))
                {
                    IsvalidatedContainerNo = true;
                }
                else
                {
                    lstrContainerNo = TxtContainerNo;
                    gblTrackRequests.strContainerNo = TxtContainerNo;
                    IsvalidatedContainerNo = false;
                }
                if ((TxtBOLNo == null) || (TxtBOLNo == ""))
                {
                    IsvalidatedBOLNo = true;
                }
                else
                {
                    lstrBOLNo = TxtBOLNo;
                    gblTrackRequests.strBOLNo = TxtBOLNo;
                    IsvalidatedBOLNo = false;
                }
                if (_selectedTypeOfDamage == null)
                {
                    IsvalidatedTypeDamage = true;
                }
                else
                {
                    gblTrackRequests.strTypeofDamage = SelectedTypeOfDamage.Value;
                    IsvalidatedTypeDamage = false;
                }

                if (DtReportDate != null)
                {
                    lstrDate = DtReportDate.Value.ToString("yyyy-MM-dd");
                    //lstrDate = DtReportDate.Value.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss") + "Z";
                }
                //gokul
                if (ContainerNo == "")
                {
                    IsvalidatedContainerNo = true;
                }
                if (BOLNo == "")
                {
                    IsvalidatedBOLNo = true;
                }
                IsValidatedContainerMsg = false;

                if ((ContainerNo != "") && (BOLNo != ""))
                {
                    await fnDamageContainerBody(ContainerNo, BOLNo);
                }
                DamageEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get btncancel button
        /// </summary>
        /// <returns></returns>
        private async Task btncancel()
        {
            try
            {
                IsBusy = true;
                DamageEn = false;
                await Task.Delay(1000);
                lblFilename = false;
                TxtFilename = "";
                ImgCancel = false;
                IsChoosefile = true;
                DamageEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To load HideErrorMsg caption
        /// </summary>
        /// <returns></returns>
        private async Task HideErrorMsg()
        {
            try
            {
                msgContainerNo = false;
                msgbOLNo = false;
                msgtypeofdamage = false;
                lblContainerValidmg = false;
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}
