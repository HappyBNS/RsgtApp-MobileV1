using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Models;
using static RsgtApp.BusinessLayer.BLConnect;
using static RsgtApp.Models.ExtraCare;

namespace RsgtApp.ViewModels
{
    public class ExtracareAddcontainerViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        public static List<ExtraCareContainer> lstrExtra = new List<ExtraCareContainer>();
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonretreive { get; set; }
        public Command Tapcontainerlist { get; set; }
        public Command Taprequesthistory { get; set; }
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
        //to handle indicator
        private bool stackExtracare = true;
        public bool StackExtracare
        {
            get { return stackExtracare; }
            set
            {
                stackExtracare = value;
                OnPropertyChanged();
                RaisePropertyChange("StackExtracare");
            }
        }
        //TxtContainerNo purpose of using Textbox varaiable
        private string TxtcontainerNo = "";
        public string TxtContainerNo
        {
            get { return TxtcontainerNo; }
            set
            {
                TxtcontainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainerNo");
            }
        }
        //TxtBOLNo purpose of using Textbox varaiable
        private string TxtbOLNo = "";
        public string TxtBOLNo
        {
            get { return TxtbOLNo; }
            set
            {
                TxtbOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOLNo");
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
        //imgContainerAdd purpose of using Image varaiable
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
        //lblBOLNo purpose of using label varaiable
        private string lblbOLNo = "";
        public string lblBOLNo
        {
            get { return lblbOLNo; }
            set
            {
                lblbOLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOLNo");
            }
        }
        //BtnNext purpose of using Button varaiable
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
        //imgHistoryIcon purpose of using image varaiable
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
        //MsgContainerNo purpose of using message varaiable
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
        //MsgBolno purpose of using message varaiable
        private string msgBolno = "";
        public string MsgBolno
        {
            get { return msgBolno; }
            set
            {
                msgBolno = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgBolno");
            }
        }
        //IsvalidatedContainerNo purpose of using Validation
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
        //IsvalidatedBolno purpose of using Validation
        private bool isvalidatedBolno = false;
        public bool IsvalidatedBolno
        {
            get { return isvalidatedBolno; }
            set
            {
                isvalidatedBolno = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedBolno");
            }
        }
        //MsgPleaseProvide purpose of using Validation
        private string msgPleaseProvide = "";
        public string MsgPleaseProvide
        {
            get { return msgPleaseProvide; }
            set
            {
                msgPleaseProvide = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPleaseProvide");
            }
        }
        //IsvalidatedPleaseProvide purpose of using Validation
        private bool isvalidatedPleaseProvide = false;
        public bool IsvalidatedPleaseProvide
        {
            get { return isvalidatedPleaseProvide; }
            set
            {
                isvalidatedPleaseProvide = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedPleaseProvide");
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
                Buttonretreive.ChangeCanExecute();
                Tapcontainerlist.ChangeCanExecute();
                Taprequesthistory.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Viewmodel-constructor
        /// </summary>
        public ExtracareAddcontainerViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ExtracareAddcontainerViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonretreive = new Command(async () => await buttonretreive(), () => !IsBusy);
            Tapcontainerlist = new Command(async () => await tapcontainerlist(), () => !IsBusy);
            Taprequesthistory = new Command(async () => await taprequesthistory(), () => !IsBusy);
            IsEnableContainerList = false;
            if (ExtraCare.lstExtra.Count > 0)
            {
                IsEnableContainerList = true;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM453");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM453");
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
        /// /Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
           
           
            imgExtraCareMenuIcon = dbLayer.getCaption("imgExtraCare", objCMS);
            lblExtraCareRequest = dbLayer.getCaption("strExtraCareRequest", objCMS);
            imgContainerAdd = dbLayer.getCaption("imgAddContainer", objCMS);
            lblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
            lblBOLNo = dbLayer.getCaption("strBillofLadingNumber", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            imgContainerIcon = dbLayer.getCaption("imgContainer", objCMS);
            lblContainerList = dbLayer.getCaption("strContainerList", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgBolno = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgPleaseProvide = dbLayer.getCaption("strContainerEnteredNotvalid", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To go to Retrive
        /// </summary>
        /// <returns></returns>
        private async Task buttonretreive()
        {
            var Containerno = TxtContainerNo.ToString().Trim();
            var BOLno = TxtBOLNo.ToString().Trim();
           await Hidevalidtion();
            if ((Containerno == "") || (Containerno == null))
            {
                IsvalidatedContainerNo = true;
            }
            else
            {
                IsvalidatedContainerNo = false;
            }
            if ((BOLno == "") || (BOLno == null))
            {
                IsvalidatedBolno = true;
            }
            else
            {
                IsvalidatedBolno = false;
            }
            if ((Containerno != "") && (BOLno != ""))
            {
                await fnExtracareRetreiveData(Containerno, BOLno);
            }
        }
        /// <summary>
        /// To go to fnExtracareRetreiveData
        /// </summary>
        /// <param name="fstrContainernumber"></param>
        /// <param name="fstrBlnumber"></param>
        /// <returns></returns>
        private async Task fnExtracareRetreiveData(string fstrContainernumber, string fstrBlnumber)
        {
            IsBusy = true;
            StackExtracare = false;
            await Task.Delay(1000);
         
            var objRawData = new List<ExctraCareDt>();
            objRawData = objBl.RetreiveExctraCareDetails(fstrContainernumber, fstrBlnumber);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            if ((objRawData != null) && (objRawData.Count > 0))
            {
                string lblValContainerno = objRawData.ToArray()[0].cd_containernumber;
                string lblValBOLno = objRawData.ToArray()[0].cd_blnumber;
                await App.Current.MainPage?.Navigation.PushAsync(new ExtracareAddcontainerstep2(lblValContainerno, lblValBOLno));
            }
            else
            {
                IsvalidatedPleaseProvide = true;
            }
            StackExtracare = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to tapcontainerlist
        /// </summary>
        /// <returns></returns>
        private async Task tapcontainerlist()
        {
            IsBusy = true;
            StackExtracare = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            if (ExtraCare.lstExtra.Count > 0)
            {
                IsEnableContainerList = true;
                await App.Current.MainPage?.Navigation.PushAsync(new ExtraCareContainerlist());
            }
            else
            {
                await App.Current.MainPage?.Navigation.PushAsync(new Extracare_Addcontainer());
            }
            StackExtracare = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to taprequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task taprequesthistory()
        {
            IsBusy = true;
            StackExtracare = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Extra Care & Hot Shipment"));
            StackExtracare = true;
            IsBusy = false;
        }
        public async Task Hidevalidtion()
        {
            IsvalidatedPleaseProvide = false;
             IsvalidatedContainerNo = false;
            IsvalidatedBolno= false;
        }
    }
}