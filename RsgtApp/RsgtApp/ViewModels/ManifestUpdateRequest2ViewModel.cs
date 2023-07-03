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
    public class ManifestUpdateRequest2ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonreset { get; set; }
        public Command ButtonAddcontainer { get; set; }
        public Command Tapcontainerlist { get; set; }
        public Command Tapmanifestrequesthistory { get; set; }
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
        //To handle Indicator
        private bool stackManifestUpdateRequest2 = true;
        public bool StackManifestUpdateRequest2
        {
            get { return stackManifestUpdateRequest2; }
            set
            {
                stackManifestUpdateRequest2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackManifestUpdateRequest2");
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
        //lblManifestUpdateRequest purpose of using Label varaiable
        private string lblmanifestUpdateRequest = "";
        public string lblManifestUpdateRequest
        {
            get { return lblmanifestUpdateRequest; }
            set
            {
                lblmanifestUpdateRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestUpdateRequest");
            }
        }
        //imgRequestIcon purpose of using Image varaiable
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
        //lblManifestAddContainer purpose of using Label varaiable
        private string lblmanifestAddContainer = "";
        public string lblManifestAddContainer
        {
            get { return lblmanifestAddContainer; }
            set
            {
                lblmanifestAddContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblManifestAddContainer");
            }
        }
        //lblVesselNumber purpose of using Label varaiable
        private string lblvesselNumber = "";
        public string lblVesselNumber
        {
            get { return lblvesselNumber; }
            set
            {
                lblvesselNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVesselNumber");
            }
        }
        //lblVoyageNumber purpose of using Label varaiable
        private string lblvoyageNumber = "";
        public string lblVoyageNumber
        {
            get { return lblvoyageNumber; }
            set
            {
                lblvoyageNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVoyageNumber");
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
        //lblContainerNumber purpose of using Label varaiable
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
        //TxtVesselNumber purpose of using Textbox varaiable
        private string txtVesselNumber = "";
        public string TxtVesselNumber
        {
            get { return txtVesselNumber; }
            set
            {
                txtVesselNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVesselNumber");
            }
        }
        //TxtVoyageNumber purpose of using Textbox varaiable
        private string txtVoyageNumber = "";
        public string TxtVoyageNumber
        {
            get { return txtVoyageNumber; }
            set
            {
                txtVoyageNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVoyageNumber");
            }
        }
        //TxtBillofLading purpose of using Textbox varaiable
        private string txtBillofLading = "";
        public string TxtBillofLading
        {
            get { return txtBillofLading; }
            set
            {
                txtBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBillofLading");
            }
        }
        //TxtContainerNumber purpose of using Textbox varaiable
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
        //BtnReset purpose of using Button varaiable
        private string Btnreset = "";
        public string BtnReset
        {
            get { return Btnreset; }
            set
            {
                Btnreset = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnReset");
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
        //lblContainerList purpose of using Label varaiable
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
        //lblvalVesselNo purpose of using Valiadtion
        private string lblvalvesselNo = "";
        public string lblvalVesselNo
        {
            get { return lblvalvesselNo; }
            set
            {
                lblvalvesselNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblvalVesselNo");
            }
        }
        //lblvalVoyageNo purpose of using Valiadtion
        private string lblvalvoyageNo = "";
        public string lblvalVoyageNo
        {
            get { return lblvalvoyageNo; }
            set
            {
                lblvalvoyageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblvalVoyageNo");
            }
        }
        //lblvalBOLNo purpose of using Valiadtion
        private string lblvalbOLNo = "";
        public string lblvalBOLNo
        {
            get { return lblvalbOLNo; }
            set
            {
                lblvalbOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblvalBOLNo");
            }
        }
        //MsgContainerNo purpose of using Label varaiable
        private string msgContainerNo = "";
        public string MsgContainerNo
        {
            get { return msgContainerNo; }
            set
            {
                msgContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgContainerNo");
            }
        }
        //IsvalidatedContainerNo purpose of using Valiadtion
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
        //fstrContainernumber purpose of using Label varaiable
        private string fstrcontainernumber = "";
        public string fstrContainernumber
        {
            get { return fstrcontainernumber; }
            set
            {
                fstrcontainernumber = value;
                OnPropertyChanged();
                RaisePropertyChange("fstrContainernumber");
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
                Buttonreset.ChangeCanExecute();
                ButtonAddcontainer.ChangeCanExecute();
                Tapcontainerlist.ChangeCanExecute();
                Tapmanifestrequesthistory.ChangeCanExecute();
            }
        }
        private string lstrsreenflag = "N";
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        /// <param name="fstrVesselno"></param>
        /// <param name="fstrVoyageno"></param>
        /// <param name="fstrBOLno"></param>
        /// <param name="fstrScreenflag"></param>
        public ManifestUpdateRequest2ViewModel(string fstrVesselno, string fstrVoyageno, string fstrBOLno, string fstrScreenflag)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ManifestUpdateRequest2ViewModel");
            lstrsreenflag = fstrScreenflag;
            Task.Run(() => assignCms()).Wait();
            Buttonreset = new Command(async () => await buttonreset(fstrVesselno, fstrVoyageno, fstrBOLno, fstrScreenflag), () => !IsBusy);
            ButtonAddcontainer = new Command(async () => await buttonAddcontainer(), () => !IsBusy);
            Tapcontainerlist = new Command(async () => await tapcontainerlist(), () => !IsBusy);
            Tapmanifestrequesthistory = new Command(async () => await tapmanifestrequesthistory(), () => !IsBusy);
            lblvalVesselNo = fstrVesselno;
            lblvalVoyageNo = fstrVoyageno;
            lblvalBOLNo = fstrBOLno;
            if ((fstrVesselno == "") && (fstrVoyageno == "") && (fstrBOLno == ""))
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
            await Task.Delay(1000);


            imgManifestIcon = dbLayer.getCaption("imgManifest", objCMS);
            lblManifestUpdateRequest = dbLayer.getCaption("strUpdateRequest", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblManifestAddContainer = dbLayer.getCaption("strManifestUpdateRequest", objCMS);
            lblVesselNumber = dbLayer.getCaption("strVessel", objCMS);
            lblVoyageNumber = dbLayer.getCaption("strVoyage", objCMS);
            lblBillofLading = dbLayer.getCaption("strBillofLading", objCMS);
            lblContainerNumber = dbLayer.getCaption("strContainerNo", objCMS);
            BtnAdd = dbLayer.getCaption("strAdd", objCMS);
            BtnReset = dbLayer.getCaption("strReset", objCMS);
            imgContainerIcon = dbLayer.getCaption("imgContainericon", objCMS);
            lblContainerList = dbLayer.getCaption("strContainerList", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To get buttonreset
        /// </summary>
        /// <returns></returns>
        private async Task buttonreset(string fstrVesselno, string fstrVoyageno, string fstrBOLno, string fstrScreenflag)
        {
            IsBusy = true;
            StackManifestUpdateRequest2 = false;
            await Task.Delay(1000);
            TxtContainerNumber = "";
            //  await App.Current.MainPage?.Navigation.PushAsync(new ManifestUpdateRequest2(fstrVesselno,  fstrVoyageno, fstrBOLno, fstrScreenflag));
            StackManifestUpdateRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get buttonAddcontainer
        /// </summary>
        /// <returns></returns>
        private async Task buttonAddcontainer()
        {
            IsBusy = true;
            StackManifestUpdateRequest2 = false;
            await Task.Delay(1000);
            await fnAddcontainer();
            StackManifestUpdateRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get fnAddcontainer
        /// </summary>
        /// <returns></returns>
        private async Task fnAddcontainer()
        {
            await Hidevalidtion();
            var ContainerNo = TxtContainerNumber.ToString().Trim();
            bool blResult = true;
            blResult = false;
            if ((ContainerNo == null) || (ContainerNo == ""))
            {
                IsvalidatedContainerNo = true;
            }
            else
            {
                blResult = true;
                IsvalidatedContainerNo = false;
            }

            if (blResult == true)
            {
                //webgateway.rsgt.com:9090/eportal_api/getManiFestMandatorycheck?fstrContainerNo=MSKU7616040
                var objRawData = new List<ManifestContainerDt>();
                objRawData = objBl.ManifestupdateRequest(ContainerNo);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                var lstrStatus = "";
                var lstrDetailsData = "";
                if (objRawData.Count > 0)
                {
                    if (objRawData[0].cd_commodity != "")
                    {
                        lstrDetailsData = objRawData[0].cd_commodity;
                        lstrStatus = "Completed";
                    }
                    else
                    {
                        lstrStatus = "Inprogress";
                    }
                }
                else
                {
                    lstrStatus = "Containers Not Available";
                }
                int lintSNO = Convert.ToInt32(TxtSNO);
                var objManifestupdate = new ManifestContainerDt();
                objManifestupdate.cd_containernumber = TxtContainerNumber.ToString().Trim();
                objManifestupdate.cd_blnumber = lblvalBOLNo.ToString().Trim();
                objManifestupdate.vd_obvoyage = lblvalVoyageNo.ToString().Trim();
                objManifestupdate.vd_visitid = lblvalVesselNo.ToString().Trim();
                objManifestupdate.cd_commodity = lstrDetailsData;
                objManifestupdate.cd_status = lstrStatus;
                objManifestupdate.cd_Notes = "";
                if (lintSNO == 0)
                {
                    Manifest.lintManifestSno = Manifest.lintManifestSno + 1;
                    objManifestupdate.CD_SNO = Manifest.lintManifestSno;
                    Manifest.lstManifest.Add(objManifestupdate);
                }
                //Update List added by Anand-20221109
                if (lintSNO > 0)
                {
                    objManifestupdate.CD_SNO = lintSNO;
                    var index = Manifest.lstManifest.FindIndex(x => x.CD_SNO == lintSNO);
                    if (index > -1)
                    {
                        Manifest.lstManifest[index] = objManifestupdate;
                    }
                }

                if (Manifest.lstManifest.Count > 0)
                {
                    await App.Current.MainPage?.Navigation.PushAsync(new ManifestContainerList(lblvalVesselNo, lblvalVoyageNo, lblvalBOLNo));
                }
            }
        }
        /// <summary>
        /// To get tapcontainerlist
        /// </summary>
        /// <returns></returns>
        private async Task tapcontainerlist()
        {
            IsBusy = true;
            StackManifestUpdateRequest2 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new ManifestContainerList("", "", ""));
            StackManifestUpdateRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get tapmanifestrequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task tapmanifestrequesthistory()
        {
            IsBusy = true;
            StackManifestUpdateRequest2 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Manifest Confirmation"));
            StackManifestUpdateRequest2 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get fetchEditSelectedItem
        /// </summary>
        /// <returns></returns>
        private void fetchEditSelectedItem()
        {
            foreach (var item in Manifest.lstSelectedManifest)
            {
                TxtSNO = item.CD_SNO.ToString();
                lblvalVesselNo = item.vd_visitid;
                lblvalVoyageNo = item.vd_ibvoyage;
                lblvalBOLNo = item.cd_blnumber;
                TxtContainerNumber = item.cd_containernumber;
                //inprogress = item.CD_ETA2;
                //Details = item.CD_StowagePlan1;
            }
        }

        public async Task Hidevalidtion()
        {
            IsvalidatedContainerNo = false;
        }
    }
}