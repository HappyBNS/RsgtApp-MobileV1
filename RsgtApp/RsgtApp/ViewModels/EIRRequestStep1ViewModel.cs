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
    public class EIRRequestStep1ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonretreive { get; set; }
        public Command TapEIRrequesthistory { get; set; }
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
        //To handle indicator
        private bool stackEIRRequeststep1 = true;
        public bool StackEIRRequeststep1
        {
            get { return stackEIRRequeststep1; }
            set
            {
                stackEIRRequeststep1 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackEIRRequeststep1");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
        private string imgeIRIcon = "";
        public string imgEIRIcon
        {
            get { return imgeIRIcon; }
            set
            {
                imgeIRIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEIRIcon");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
        private string lbleIRCopyRequest = "";
        public string lblEIRCopyRequest
        {
            get { return lbleIRCopyRequest; }
            set
            {
                lbleIRCopyRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRCopyRequest");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
        private string lbleIRRequestForm = "";
        public string lblEIRRequestForm
        {
            get { return lbleIRRequestForm; }
            set
            {
                lbleIRRequestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEIRRequestForm");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
        private string lblbOLNumber = "";
        public string lblBOLNumber
        {
            get { return lblbOLNumber; }
            set
            {
                lblbOLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOLNumber");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
        private bool isvalidatedDetails = false;
        public bool IsvalidatedDetails
        {
            get { return isvalidatedDetails; }
            set
            {
                isvalidatedDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedDetails");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
        private string txtBOLNumber = "";
        public string TxtBOLNumber
        {
            get { return txtBOLNumber; }
            set
            {
                txtBOLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOLNumber");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
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
        //lblTrackingResult purpose of using lable varaiable
        private string lbltruckNo = "";
        public string lblTruckNo
        {
            get { return lbltruckNo; }
            set
            {
                lbltruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTruckNo");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
        private string txtTruckNo = "";
        public string TxtTruckNo
        {
            get { return txtTruckNo; }
            set
            {
                txtTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTruckNo");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
        private string msgTruckNo = "";
        public string MsgTruckNo
        {
            get { return msgTruckNo; }
            set
            {
                msgTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTruckNo");
            }
        }
        //IsvalidatedTruckNo purpose of using Validation
        private bool isvalidatedTruckNo = false;
        public bool IsvalidatedTruckNo
        {
            get { return isvalidatedTruckNo; }
            set
            {
                isvalidatedTruckNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedTruckNo");
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
                TapEIRrequesthistory.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Viewmodel-Constructor
        /// </summary>
        public EIRRequestStep1ViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("EIRRequestStep1ViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonretreive = new Command(async () => await buttonretreive(), () => !IsBusy);
            TapEIRrequesthistory = new Command(async () => await tapEIRrequesthistory(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM452");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM452");

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
            imgEIRIcon = dbLayer.getCaption("imgEIR", objCMS);
            lblEIRCopyRequest = dbLayer.getCaption("strEirCopyRequestHeading", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblEIRRequestForm = dbLayer.getCaption("strEirCopyRequestForm", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
            lblBOLNumber = dbLayer.getCaption("strBillOfLading", objCMS);
            lblTruckNo = dbLayer.getCaption("strTruckNumber", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgBolno = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgTruckNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgPlsProvid = dbLayer.getCaption("strContainerYouEnteredIsNotValid", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To go to Button Retreive
        /// </summary>
        /// <returns></returns>
        private async Task buttonretreive()
        {
            IsBusy = true;
            StackEIRRequeststep1 = false;
            await Task.Delay(1000);
            Hidevalidtion();
            var Containerno = TxtContainerNo.ToString().Trim();
            var BOLno = TxtBOLNumber.ToString().Trim();
            var TruckNo = TxtTruckNo.ToString().Trim();
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
            if ((TruckNo == "") || (TruckNo == null))
            {
                IsvalidatedTruckNo = true;
            }
            else
            {
                IsvalidatedTruckNo = false;
            }
            if ((Containerno != "") && (BOLno != "") && (TruckNo != ""))
            {
               await fnEirRetreiveData(Containerno, BOLno, TruckNo);
            }
            StackEIRRequeststep1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to fnEirRetreiveData
        /// </summary>
        /// <param name="fstrContainernumber"></param>
        /// <param name="fstrBlnumber"></param>
        /// <param name="fstrTruckNo"></param>
        /// <returns></returns>
        private async Task fnEirRetreiveData(string fstrContainernumber, string fstrBlnumber, string fstrTruckNo)
        {
            try
            {
                IsBusy = true;
                StackEIRRequeststep1 = false;
                await Task.Delay(1000);
                // string fstrTransporter = "";
                //string lstrContainerNo = "";
                //string lstrBLNo = "";
                //string lstrTruckNo = "";
                var objRawData = new List<EIRDt>();
                objRawData = objBl.RetreiveContainerDetail(fstrContainernumber, fstrBlnumber, fstrTruckNo);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((objRawData != null) && (objRawData.Count > 0))
                {
                    string lblValContainerno = fstrContainernumber;
                    string lblValBOLno = fstrBlnumber;
                    string lblValDischarge = objRawData.ToArray()[0].cd_fmtdiscrecivaltime;
                    string lblValGateout = objRawData.ToArray()[0].cd_fmtgatedouttime;
                    string lblvalTruckno = fstrTruckNo;
                    await App.Current.MainPage?.Navigation.PushAsync(new EIRRequeststep2(lblValContainerno, lblValBOLno, lblValDischarge, lblValGateout, lblvalTruckno));
                }
                else
                {
                    IsvalidatedPlsProvid = true;
                }
                StackEIRRequeststep1 = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to Request History
        /// </summary>
        /// <returns></returns>
        private async Task tapEIRrequesthistory()
        {
            IsBusy = true;
            StackEIRRequeststep1 = false;
            await Task.Delay(1000);
            Hidevalidtion();
            await App.Current.MainPage?.Navigation.PushAsync(new EIRRequestHistory("", "", "", "", ""));
            StackEIRRequeststep1 = true;
            IsBusy = false;
        }

        public async Task Hidevalidtion()
        {
            IsvalidatedContainerNo = false;
            IsvalidatedBolno = false;
            IsvalidatedTruckNo = false;
            IsvalidatedPlsProvid = false;
        }
    }
}