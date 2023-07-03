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
using static RsgtApp.BusinessLayer.BLConnect;

namespace RsgtApp.ViewModels
{
    public class Offloadrequest1ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonretreive { get; set; }
        public Command Tapoffloadrequesthistory { get; set; }
        public Command Buttonreset { get; set; }
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
        //To handle indiactor
        private bool stackOffloadrequest1 = true;
        public bool StackOffloadrequest1
        {
            get { return stackOffloadrequest1; }
            set
            {
                stackOffloadrequest1 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackOffloadrequest1");
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
        //TxtBOL purpose of using Textbox varaiable
        private string TxtbOL = "";
        public string TxtBOL
        {
            get { return TxtbOL; }
            set
            {
                TxtbOL = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOL");
            }
        }
        //imgOffLoadIcon purpose of using Image varaiable
        private string imgoffLoadIcon = "";
        public string imgOffLoadIcon
        {
            get { return imgoffLoadIcon; }
            set
            {
                imgoffLoadIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgOffLoadIcon");
            }
        }
        //lblOffloadRequest purpose of using Label varaiable
        private string lbloffloadRequest = "";
        public string lblOffloadRequest
        {
            get { return lbloffloadRequest; }
            set
            {
                lbloffloadRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOffloadRequest");
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
        //lblOffloadRequestForm purpose of using Label varaiable
        private string lbloffloadRequestForm = "";
        public string lblOffloadRequestForm
        {
            get { return lbloffloadRequestForm; }
            set
            {
                lbloffloadRequestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOffloadRequestForm");
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
        //lblBOL purpose of using Label varaiable
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
        //TxtReset purpose of using Textbox varaiable
        private string txtReset = "";
        public string TxtReset
        {
            get { return txtReset; }
            set
            {
                txtReset = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtReset");
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
        //MsgBolno purpose of using Label varaiable
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
        //MsgPlsProvid purpose of using Label varaiable
        private string msgPlsProvid = "";
        public string MsgPlsProvid
        {
            get { return msgPlsProvid; }
            set
            {
                msgPlsProvid = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPlsProvid");
            }
        }
        //To Handel Boolen Value
        private bool isvalidatedPlsProvid = false;
        public bool IsvalidatedPlsProvid
        {
            get { return isvalidatedPlsProvid; }
            set
            {
                isvalidatedPlsProvid = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedPlsProvid");
            }
        }
        //To Handel Boolen Value
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
        //To Handel Boolen Value
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
                Tapoffloadrequesthistory.ChangeCanExecute();
                Buttonreset.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public Offloadrequest1ViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("Offloadrequest1ViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonretreive = new Command(async () => await buttonretreive(), () => !IsBusy);
            Tapoffloadrequesthistory = new Command(async () => await tapoffloadrequesthistory(), () => !IsBusy);
            Buttonreset = new Command(async () => await buttonreset(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM455");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM455");
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
            imgOffLoadIcon = dbLayer.getCaption("imgOffloadiconBlue", objCMS);
            lblOffloadRequest = dbLayer.getCaption("strOffloadRequest", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequestDarkBlue", objCMS);
            lblOffloadRequestForm = dbLayer.getCaption("strOffloadRequestForm", objCMS);
            lblContainerNumber = dbLayer.getCaption("strContainerNumber", objCMS);
            lblBOL = dbLayer.getCaption("strBillOfLading", objCMS);
            TxtReset = dbLayer.getCaption("strReset", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryiconWwhite", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgBolno = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgPlsProvid = dbLayer.getCaption("strContainerEnteredNotValid", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To go to buttonretreive
        /// </summary>
        /// <returns></returns>
        private async Task buttonretreive()
        {
            var Containerno = TxtContainerNumber;
            var BOLno = TxtBOL;
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
                await fnOffloadRequestRetreiveData(Containerno, BOLno);
            }
        }
        /// <summary>
        /// To go to fnOffloadRequestRetreiveData
        /// </summary>
        /// <param name="fstrContainernumber"></param>
        /// <param name="fstrBlnumber"></param>
        /// <returns></returns>
        private async Task fnOffloadRequestRetreiveData(string fstrContainernumber, string fstrBlnumber)
        {
            try
            {
                IsBusy = true;
                StackOffloadrequest1 = false;
                await Task.Delay(1000);
               // string fstrTransporter = "";
               // string lstrContainerNo = "";
               // string lstrBLNo = "";
                var objRawData = new List<OffloadrequestDt>();
                objRawData = objBl.RetreiveOffloadRequest(fstrContainernumber, fstrBlnumber);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                  App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((objRawData != null) && (objRawData.Count > 0))
                {
                    string lblValContainerno = objRawData.ToArray()[0].cd_containernumber;
                    string lblValBOLno = objRawData.ToArray()[0].cd_blnumber;
                    //string lblValDischarge = objRawData.ToArray()[0].cd_fmtdiscrecivaltime;
                    //string lblValGateout = objRawData.ToArray()[0].cd_fmtgatedouttime;

                    await App.Current.MainPage?.Navigation.PushAsync(new Offloadrequest2(lblValContainerno, lblValBOLno));
                }
                else
                {
                    IsvalidatedPlsProvid = true;
                }
                StackOffloadrequest1 = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }         
        }
        /// <summary>
        /// To go to tapoffloadrequesthistory
        /// </summary>
        /// <returns></returns>
        private async Task tapoffloadrequesthistory()
        {
            IsBusy = true;
            StackOffloadrequest1 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Offload"));
            StackOffloadrequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to buttonreset
        /// </summary>
        /// <returns></returns>
        private async Task buttonreset()
        {
            IsBusy = true;
            StackOffloadrequest1 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new Offloadrequest_1());
            StackOffloadrequest1 = true;
            IsBusy = false;
        }

        public async Task Hidevalidtion()
        {
            IsvalidatedContainerNo = false;
            IsvalidatedBolno=false;
            IsvalidatedPlsProvid = false;
        }
    }
}