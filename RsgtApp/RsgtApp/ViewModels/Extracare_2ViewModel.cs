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

namespace RsgtApp.ViewModels
{
    public class Extracare_2ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command ButtonAddcontainer { get; set; }
        public Command Tapcontainerlist { get; set; }
        public Command Taprequesthistory { get; set; }
        string lstrExpectedDT1 = "";
        string lstrExpectedDT2 = "";
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
        private bool stackExtracareStep2 = true;
        public bool StackExtracareStep2
        {
            get { return stackExtracareStep2; }
            set
            {
                stackExtracareStep2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackExtracareStep2");
            }
        }
        //lblExtraCareRequest purpose of using label varaiable
        private string TxtshippingLineName = "";
        public string TxtShippingLineName
        {
            get { return TxtshippingLineName; }
            set
            {
                TxtshippingLineName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtShippingLineName");
            }
        }
        //Date picker
        private DateTime? TxtexpectedDT = null;
        public DateTime? TxtExpectedDT
        {
            get { return TxtexpectedDT; }
            set
            {
                TxtexpectedDT = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtExpectedDT");
            }
        }
        //lblExtraCareRequest purpose of using label varaiable
        private string TxtstowagePlan = "";
        public string TxtStowagePlan
        {
            get { return TxtstowagePlan; }
            set
            {
                TxtstowagePlan = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtStowagePlan");
            }
        }
        //lblExtraCareRequest purpose of using label varaiable
        private string TxtshippingLineName2 = "";
        public string TxtShippingLineName2
        {
            get { return TxtshippingLineName2; }
            set
            {
                TxtshippingLineName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtShippingLineName2");
            }
        }
        //Date picker
        private DateTime? TxtexpectedDT2 = null;
        public DateTime? TxtExpectedDT2
        {
            get { return TxtexpectedDT2; }
            set
            {
                TxtexpectedDT2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtExpectedDT2");
            }
        }
        //TxtStowagePlan2 purpose of using Textbox varaiable
        private string TxtstowagePlan2 = "";
        public string TxtStowagePlan2
        {
            get { return TxtstowagePlan2; }
            set
            {
                TxtstowagePlan2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtStowagePlan2");
            }
        }
        //imgExtraCareMenuIcon purpose of using Image varaiable
        private string imgextraCareMenuIcon = "";
        public string imgExtraCareMenuIcon
        {
            get { return imgextraCareMenuIcon; }
            set
            {
                imgextraCareMenuIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgExtraCareMenuIcon");
            }
        }
        //lblExtraCareRequest purpose of using label varaiable
        private string lblextraCareRequest = "";
        public string lblExtraCareRequest
        {
            get { return lblextraCareRequest; }
            set
            {
                lblextraCareRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblExtraCareRequest");
            }
        }
        //imgContainerAddIcon purpose of using Image varaiable
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
        //lblAddContainer purpose of using label varaiable
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
        //imgCont purpose of using Image varaiable
        private string imgcont = "";
        public string imgCont
        {
            get { return imgcont; }
            set
            {
                imgcont = value;
                OnPropertyChanged();
                RaisePropertyChange("imgCont");
            }
        }
        //lblContainerNo purpose of using label varaiable
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
        //imgBLIcon purpose of using Image varaiable
        private string imgbLIcon = "";
        public string imgBLIcon
        {
            get { return imgbLIcon; }
            set
            {
                imgbLIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgBLIcon");
            }
        }
        //lblBLNo purpose of using label varaiable
        private string lblbLNo = "";
        public string lblBLNo
        {
            get { return lblbLNo; }
            set
            {
                lblbLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBLNo");
            }
        }
        //lblPleaseEnter purpose of using label varaiable
        private string lblpleaseEnter = "";
        public string lblPleaseEnter
        {
            get { return lblpleaseEnter; }
            set
            {
                lblpleaseEnter = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPleaseEnter");
            }
        }
        //lblShippingLine1 purpose of using label varaiable
        private string lblshippingLine1 = "";
        public string lblShippingLine1
        {
            get { return lblshippingLine1; }
            set
            {
                lblshippingLine1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLine1");
            }
        }
        //lblShippingLineName purpose of using label varaiable
        private string lblshippingLineName = "";
        public string lblShippingLineName
        {
            get { return lblshippingLineName; }
            set
            {
                lblshippingLineName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLineName");
            }
        }
        //lblExpectedDT purpose of using label varaiable
        private string lblexpectedDT = "";
        public string lblExpectedDT
        {
            get { return lblexpectedDT; }
            set
            {
                lblexpectedDT = value;
                OnPropertyChanged();
                RaisePropertyChange("lblExpectedDT");
            }
        }
        //lblStowagePlan purpose of using label varaiable
        private string lblstowagePlan = "";
        public string lblStowagePlan
        {
            get { return lblstowagePlan; }
            set
            {
                lblstowagePlan = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStowagePlan");
            }
        }
        //lblShippingLine2 purpose of using label varaiable
        private string lblshippingLine2 = "";
        public string lblShippingLine2
        {
            get { return lblshippingLine2; }
            set
            {
                lblshippingLine2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLine2");
            }
        }
        //lblShippingLineName2 purpose of using label varaiable
        private string lblshippingLineName2 = "";
        public string lblShippingLineName2
        {
            get { return lblshippingLineName2; }
            set
            {
                lblshippingLineName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLineName2");
            }
        }
        //lblExpectedDT2 purpose of using label varaiable
        private string lblexpectedDT2 = "";
        public string lblExpectedDT2
        {
            get { return lblexpectedDT2; }
            set
            {
                lblexpectedDT2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblExpectedDT2");
            }
        }
        //lblStowagePlan2 purpose of using label varaiable
        private string lblstowagePlan2 = "";
        public string lblStowagePlan2
        {
            get { return lblstowagePlan2; }
            set
            {
                lblstowagePlan2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStowagePlan2");
            }
        }
        //BtnAdd purpose of using Button varaiable
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
        //imgContainerIcon purpose of using Image varaiable
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
        //lblContainerList purpose of using label varaiable
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
        //lblRequestHistory purpose of using label varaiable
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
        //lblValContainerno purpose of using Validation
        private string lblvalContainerno = "";
        public string lblValContainerno
        {
            get { return lblvalContainerno; }
            set
            {
                lblvalContainerno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValContainerno");
            }
        }
        //lblValBOLno purpose of using Validation
        private string lblvalBOLno = "";
        public string lblValBOLno
        {
            get { return lblvalBOLno; }
            set
            {
                lblvalBOLno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValBOLno");
            }
        }
        //MsgShippingLineName purpose of using label varaiable
        private string msgShippingLineName = "";
        public string MsgShippingLineName
        {
            get { return msgShippingLineName; }
            set
            {
                msgShippingLineName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgShippingLineName");
            }
        }
        //MsgExpectedDT purpose of using label varaiable
        private string msgExpectedDT = "";
        public string MsgExpectedDT
        {
            get { return msgExpectedDT; }
            set
            {
                msgExpectedDT = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgExpectedDT");
            }
        }
        //MsgStowagePlan purpose of using label varaiable
        private string msgStowagePlan = "";
        public string MsgStowagePlan
        {
            get { return msgStowagePlan; }
            set
            {
                msgStowagePlan = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgStowagePlan");
            }
        }
        //MsgShippingLineName2 purpose of using label varaiable
        private string msgShippingLineName2 = "";
        public string MsgShippingLineName2
        {
            get { return msgShippingLineName2; }
            set
            {
                msgShippingLineName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgShippingLineName2");
            }
        }
        //MsgExpectedDT2 purpose of using label varaiable
        private string msgExpectedDT2 = "";
        public string MsgExpectedDT2
        {
            get { return msgExpectedDT2; }
            set
            {
                msgExpectedDT2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgExpectedDT2");
            }
        }
        //MsgStowagePlan2 purpose of using label varaiable
        private string msgStowagePlan2 = "";
        public string MsgStowagePlan2
        {
            get { return msgStowagePlan2; }
            set
            {
                msgStowagePlan2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgStowagePlan2");
            }
        }
        //TxtSNO purpose of using Textbox varaiable
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
        //MsgAdddiffent1 purpose of using label varaiable
        private string msgAdddiffent1 = "";
        public string MsgAdddiffent1
        {
            get { return msgAdddiffent1; }
            set
            {
                msgAdddiffent1 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgAdddiffent1");
            }
        }
        private string _MsgPastDate1 = "";
        public string MsgPastDate1
        {
            get { return _MsgPastDate1; }
            set
            {
                _MsgPastDate1 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPastDate1");
            }
        }
        private string _MsgPastDate2 = "";
        public string MsgPastDate2
        {
            get { return _MsgPastDate2; }
            set
            {
                _MsgPastDate2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPastDate2");
            }
        }
        //MsgAdddiffent2 purpose of using label varaiable
        private string msgAdddiffent2 = "";
        public string MsgAdddiffent2
        {
            get { return msgAdddiffent2; }
            set
            {
                msgAdddiffent2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgAdddiffent2");
            }
        }
        //MsgAdddiffent3 purpose of using label varaiable
        private string msgAdddiffent3 = "";
        public string MsgAdddiffent3
        {
            get { return msgAdddiffent3; }
            set
            {
                msgAdddiffent3 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgAdddiffent3");
            }
        }
        //IsvalidatedShippingLineName purpose of using Validation
        private bool isvalidatedShippingLineName = false;
        public bool IsvalidatedShippingLineName
        {
            get { return isvalidatedShippingLineName; }
            set
            {
                isvalidatedShippingLineName = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedShippingLineName");
            }
        }
        //IsvalidatedExpectedDT purpose of using Validation
        private bool isvalidatedExpectedDT = false;
        public bool IsvalidatedExpectedDT
        {
            get { return isvalidatedExpectedDT; }
            set
            {
                isvalidatedExpectedDT = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedExpectedDT");
            }
        }
        //IsvalidatedStowagePlan purpose of using Validation
        private bool isvalidatedStowagePlan = false;
        public bool IsvalidatedStowagePlan
        {
            get { return isvalidatedStowagePlan; }
            set
            {
                isvalidatedStowagePlan = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedStowagePlan");
            }
        }
        //IsvalidatedShippingLineName2 purpose of using Validation
        private bool isvalidatedShippingLineName2 = false;
        public bool IsvalidatedShippingLineName2
        {
            get { return isvalidatedShippingLineName2; }
            set
            {
                isvalidatedShippingLineName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedShippingLineName2");
            }
        }
        //IsvalidatedExpectedDT2 purpose of using Validation
        private bool isvalidatedExpectedDT2 = false;
        public bool IsvalidatedExpectedDT2
        {
            get { return isvalidatedExpectedDT2; }
            set
            {
                isvalidatedExpectedDT2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedExpectedDT2");
            }
        }
        //IsvalidatedStowagePlan2 purpose of using Validation
        private bool isvalidatedStowagePlan2 = false;
        public bool IsvalidatedStowagePlan2
        {
            get { return isvalidatedStowagePlan2; }
            set
            {
                isvalidatedStowagePlan2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedStowagePlan2");
            }
        }
        //IsvalidatedAdddiffent purpose of using Validation
        private bool isvalidatedAdddiffent = false;
        public bool IsvalidatedAdddiffent
        {
            get { return isvalidatedAdddiffent; }
            set
            {
                isvalidatedAdddiffent = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedAdddiffent");
            }
        }
        //IsvalidatedAdddiffent1 purpose of using Validation
        private bool isvalidatedAdddiffent1 = false;
        public bool IsvalidatedAdddiffent1
        {
            get { return isvalidatedAdddiffent1; }
            set
            {
                isvalidatedAdddiffent1 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedAdddiffent1");
            }
        }
        //IsvalidatedAdddiffent2 purpose of using Validation
        private bool isvalidatedAdddiffent2 = false;
        public bool IsvalidatedAdddiffent2
        {
            get { return isvalidatedAdddiffent2; }
            set
            {
                isvalidatedAdddiffent2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedAdddiffent2");
            }
        }
        //IsvalidatedAdddiffent3 purpose of using Validation 
        private bool isvalidatedAdddiffent3 = false;
        public bool IsvalidatedAdddiffent3
        {
            get { return isvalidatedAdddiffent3; }
            set
            {
                isvalidatedAdddiffent3 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedAdddiffent3");
            }
        }
        private bool _IsvalidatedETA1 = false;
        public bool IsvalidatedETA1
        {
            get { return _IsvalidatedETA1; }
            set
            {
                _IsvalidatedETA1 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedETA1");
            }
        }
        private bool _IsvalidatedETA2 = false;
        public bool IsvalidatedETA2
        {
            get { return _IsvalidatedETA2; }
            set
            {
                _IsvalidatedETA2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedETA2");
            }
        }
        //Date Picker
        private DateTime? dtExpectedDT1 = null;
        public DateTime? DtExpectedDT1
        {
            get { return dtExpectedDT1; }
            set
            {
                dtExpectedDT1 = value;
                OnPropertyChanged();
                RaisePropertyChange("DtExpectedDT1");
            }
        }
        //Date Picker
        private DateTime? dtExpectedDT2 = null;
        public DateTime? DtExpectedDT2
        {
            get { return dtExpectedDT2; }
            set
            {
                dtExpectedDT2 = value;
                OnPropertyChanged();
                RaisePropertyChange("DtExpectedDT2");
            }
        }
        //Date Picker
        private DateTime? selectedExpectedDT1 = null;
        public DateTime? SelectedExpectedDT1
        {
            get { return selectedExpectedDT1; }
            set
            {
                selectedExpectedDT1 = value;
                OnPropertyChanged();
                RaisePropertyChange("SelectedExpectedDT1");
            }
        }
        //Date Picker
        private DateTime? selectedExpectedDT2 = null;
        public DateTime? SelectedExpectedDT2
        {
            get { return selectedExpectedDT2; }
            set
            {
                selectedExpectedDT2 = value;
                OnPropertyChanged();
                RaisePropertyChange("SelectedExpectedDT2");
            }
        }
        //IsEnableContainerList purpose of using Validation
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
            }
        }
        /// <summary>
        /// viewmodel-Constructor
        /// </summary>
        /// <param name="fstrValContainerno"></param>
        /// <param name="fstrValBOLno"></param>
        public Extracare_2ViewModel(string fstrValContainerno, string fstrValBOLno)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("Extracare_2ViewModel");
            Task.Run(() => assignCms()).Wait();
            ButtonAddcontainer = new Command(async () => await buttonAddcontainer(), () => !IsBusy);
            Tapcontainerlist = new Command(async () => await tapcontainerlist(), () => !IsBusy);
            Taprequesthistory = new Command(async () => await taprequesthistory(), () => !IsBusy);
            lblValContainerno = fstrValContainerno;
            lblValBOLno = fstrValBOLno;
            IsEnableContainerList = false;
            if (ExtraCare.lstExtra.Count > 0)
            {
                IsEnableContainerList = true;
            }
            if ((fstrValContainerno == "") && (fstrValBOLno == ""))
            {
                Task.Run(() => fetchEditSelectedItem()).Wait();
            }
            Task.Run(() => HiderrorMsg()).Wait();
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM453");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM453");
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

            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;

            //}
            lblExtraCareRequest = dbLayer.getCaption("strExtraCareRequest", objCMS);
            imgExtraCareMenuIcon = dbLayer.getCaption("imgExtraCare", objCMS);
            lblPleaseEnter = dbLayer.getCaption("strEnterBelowInformation", objCMS);
            imgContainerAddIcon = dbLayer.getCaption("imgAddContainer", objCMS);
            lblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            imgCont = dbLayer.getCaption("imgContainerNo", objCMS);
            lblShippingLine1 = dbLayer.getCaption("strShippingLine1", objCMS);
            lblShippingLineName = dbLayer.getCaption("strShippingLineName", objCMS);
            lblExpectedDT = dbLayer.getCaption("strExpectedArrivalDateTime", objCMS);
            lblStowagePlan = dbLayer.getCaption("strStowagePlan", objCMS);
            lblShippingLine2 = dbLayer.getCaption("strShippingLine2", objCMS);
            lblShippingLineName2 = dbLayer.getCaption("strShippingLineName", objCMS);
            lblExpectedDT2 = dbLayer.getCaption("strExpectedArrivalDateTime", objCMS);
            lblStowagePlan2 = dbLayer.getCaption("strStowagePlan", objCMS);
            imgContainerIcon = dbLayer.getCaption("imgContainer", objCMS);
            lblContainerList = dbLayer.getCaption("strContainerList", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            BtnAdd = dbLayer.getCaption("strAdd", objCMS);
            imgBLIcon = dbLayer.getCaption("imgBL", objCMS);
            lblBLNo = dbLayer.getCaption("strBLNumber", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNumbers", objCMS);
            MsgShippingLineName = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgExpectedDT = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgStowagePlan = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgShippingLineName2 = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgExpectedDT2 = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgStowagePlan2 = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgAdddiffent1 = dbLayer.getCaption("strAddDifferent", objCMSMSG);
            MsgAdddiffent2 = dbLayer.getCaption("strAddDifferent", objCMSMSG);
            MsgAdddiffent3 = dbLayer.getCaption("strAddDifferent", objCMSMSG);
            MsgPastDate1 = dbLayer.getCaption("strEmailpattern", objCMSMSG);
            MsgPastDate2 = dbLayer.getCaption("strEmailpattern", objCMSMSG);
        }
        /// <summary>
        /// To go to buttonAddcontainer
        /// </summary>
        /// <returns></returns>
        private async Task buttonAddcontainer()
        {
            IsBusy = true;
            StackExtracareStep2 = false;
            await Task.Delay(1000);

            await fnAddcontainer();
            // App.Current.MainPage?.Navigation.PushAsync(new ExtraCareContainerlist());
            StackExtracareStep2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Add Container
        /// </summary>
        /// <returns></returns>        
        private async Task fnAddcontainer()
        {
            bool blResult = true;
            HiderrorMsg();
            var Shipperlinename = TxtShippingLineName.ToString().Trim();
            var Expecteddate = TxtExpectedDT.ToString().Trim();
            var Stowageplan = TxtStowagePlan.ToString().Trim();
            var Shipperlinename2 = TxtShippingLineName2.ToString().Trim();
            var Expecteddate2 = TxtExpectedDT2.ToString().Trim();
            var Stowageplan2 = TxtStowagePlan2.ToString().Trim();
            var ETA1 = DtExpectedDT1.ToString().Trim();
            var ETA2 = DtExpectedDT2.ToString().Trim();
            if ((Shipperlinename == null) || (Shipperlinename == ""))
            {
                IsvalidatedShippingLineName = true;
                blResult = false;
            }
            if ((Shipperlinename2 == null) || (Shipperlinename2 == ""))
            {
                IsvalidatedShippingLineName2 = true;
                blResult = false;
            }
            else
            {
                if (Shipperlinename == Shipperlinename2)
                {
                    IsvalidatedAdddiffent1 = true;
                    blResult = false;
                }
            }
            if (DtExpectedDT1 != null)
            {
                if (DateTime.Now.Date > DtExpectedDT1.Value)
                {
                    blResult = true;
                    IsvalidatedETA1 = true;
                }
                else
                {
                    lstrExpectedDT1 = DtExpectedDT1.Value.ToString("yyyy-MM-dd");
                    IsvalidatedETA1 = false;
                }

            }
            else
            {
                IsvalidatedExpectedDT = true;
                blResult = false;
            }
            if (DtExpectedDT2 != null)
            {
                if (DateTime.Now.Date > DtExpectedDT2.Value)
                {
                    blResult = true;
                    IsvalidatedETA2 = true;
                }
                else
                {
                    lstrExpectedDT2 = DtExpectedDT2.Value.ToString("yyyy-MM-dd");
                    IsvalidatedETA2 = false;
                }
            }
            else
            {
                IsvalidatedExpectedDT2 = true;
                blResult = false;
            }

            if ((lstrExpectedDT1 != "") && (lstrExpectedDT2 != ""))
            {
                if (lstrExpectedDT1 == lstrExpectedDT2)
                {
                    IsvalidatedAdddiffent2 = true;
                    blResult = false;
                }
            }

            if ((Stowageplan == null) || (Stowageplan == ""))
            {
                IsvalidatedStowagePlan = true;
                blResult = false;
            }
            if ((Stowageplan2 == null) || (Stowageplan2 == ""))
            {
                IsvalidatedStowagePlan2 = true;
                blResult = false;
            }
            else
            {
                if (Stowageplan == Stowageplan2)
                {
                    IsvalidatedAdddiffent3 = true;
                    blResult = false;
                }
            }
            if (blResult == true)
            {
                int lintSNO = Convert.ToInt32(TxtSNO);
                // Declare Master object
                var objExtraCareContainerlistModel = new ExtraCare.ExtraCareContainer();
                objExtraCareContainerlistModel.CD_ContainerNo = lblValContainerno;
                objExtraCareContainerlistModel.CD_BillofLading = lblValBOLno;
                objExtraCareContainerlistModel.CD_ShippingLineName1 = TxtShippingLineName;
                objExtraCareContainerlistModel.CD_ShippingLineName2 = TxtShippingLineName2;
                objExtraCareContainerlistModel.CD_ETA1 = DtExpectedDT1.Value.ToString("yyyy-MM-dd");
                objExtraCareContainerlistModel.CD_ETA2 = DtExpectedDT2.Value.ToString("yyyy-MM-dd");
                objExtraCareContainerlistModel.CD_StowagePlan1 = TxtStowagePlan;
                objExtraCareContainerlistModel.CD_StowagePlan2 = TxtStowagePlan2;
                if (lintSNO == 0)
                {
                    ExtraCare.lintExtraCareSno = ExtraCare.lintExtraCareSno + 1;
                    objExtraCareContainerlistModel.CD_SNO = ExtraCare.lintExtraCareSno;
                    ExtraCare.lstExtra.Add(objExtraCareContainerlistModel);
                }
                //Update List added by Anand-20221109
                if (lintSNO > 0)
                {
                    objExtraCareContainerlistModel.CD_SNO = lintSNO;
                    var index = ExtraCare.lstExtra.FindIndex(x => x.CD_SNO == lintSNO);
                    if (index > -1)
                    {
                        ExtraCare.lstExtra[index] = objExtraCareContainerlistModel;
                    }
                }
                if (ExtraCare.lstExtra.Count > 0)
                {
                    await App.Current.MainPage?.Navigation.PushAsync(new ExtraCareContainerlist());
                }
            }
        }
        /// <summary>
        /// to go to HiderrorMsg
        /// </summary>
        /// <returns></returns>
        private void HiderrorMsg()
        {
            IsvalidatedShippingLineName = false;
            IsvalidatedShippingLineName2 = false;
            IsvalidatedExpectedDT = false;
            IsvalidatedExpectedDT2 = false;
            IsvalidatedStowagePlan = false;
            IsvalidatedStowagePlan2 = false;
            IsvalidatedAdddiffent = false;
            IsvalidatedExpectedDT = false;
            IsvalidatedAdddiffent3 = false;
            IsvalidatedAdddiffent2 = false;
            IsvalidatedETA2 = false;
            IsvalidatedAdddiffent1 = false;
            IsvalidatedETA1 = false;
        }
        /// <summary>
        /// To go to tapcontainerlist
        /// </summary>
        /// <returns></returns>
        private async Task tapcontainerlist()
        {
            IsBusy = true;
            StackExtracareStep2 = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new ExtraCareContainerlist());
            StackExtracareStep2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to taprequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task taprequesthistory()
        {
            IsBusy = true;
            StackExtracareStep2 = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Extra Care & Hot Shipment"));
            StackExtracareStep2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to fetchEditSelectedItem
        /// </summary>
        /// <returns></returns>
        private async Task fetchEditSelectedItem()
        {
            foreach (var item in ExtraCare.lstSelectedExtra)
            {
                //RequestedDate = DateTime.Now.Date.AddDays(-90);
                TxtSNO = item.CD_SNO.ToString();
                lblvalContainerno = item.CD_ContainerNo;
                lblvalBOLno = item.CD_BillofLading;
                TxtShippingLineName2 = item.CD_ShippingLineName2;
                int lintyear = Convert.ToInt32(item.CD_ETA1.Substring(0, 4));
                int lintMonth = Convert.ToInt32(item.CD_ETA1.Substring(5, 2));
                int lintDay = Convert.ToInt32(item.CD_ETA1.Substring(8, 2));
                DateTime dtETA1 = new DateTime(lintyear, lintMonth, lintDay);
                DtExpectedDT1 = dtETA1;

                lintyear = Convert.ToInt32(item.CD_ETA2.Substring(0, 4));
                lintMonth = Convert.ToInt32(item.CD_ETA2.Substring(5, 2));
                lintDay = Convert.ToInt32(item.CD_ETA2.Substring(8, 2));
                DateTime dtETA2 = new DateTime(lintyear, lintMonth, lintDay);

                DtExpectedDT2 = dtETA2;
                TxtStowagePlan = item.CD_StowagePlan1;
                TxtStowagePlan2 = item.CD_StowagePlan2;
                TxtShippingLineName = item.CD_ShippingLineName1;
                await Task.Delay(1000);
            }
        }
    }
}