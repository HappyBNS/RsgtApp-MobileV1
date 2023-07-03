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
    public class AttendInspectionRequest1ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonretreive { get; set; }
        public Command Tapmanifestrequesthistory { get; set; }
        private string strServerSlowMsg = "";
        public event PropertyChangedEventHandler PropertyChanged;
        // Two way binding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Two way binding process on RaisePropertyChange Event
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
        private bool stackAttendRequest1 = true;
        public bool StackAttendRequest1
        {
            get { return stackAttendRequest1; }
            set
            {
                stackAttendRequest1 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackAttendRequest1");
            }
        }
        private string imgvisitorIcon = "";
        public string imgVisitorIcon
        {
            get { return imgvisitorIcon; }
            set
            {
                imgvisitorIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgVisitorIcon");
            }
        }
        private string lblattendRequest = "";
        public string lblAttendRequest
        {
            get { return lblattendRequest; }
            set
            {
                lblattendRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttendRequest");
            }
        }
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
        private string lblattendRequestForm = "";
        public string lblAttendRequestForm
        {
            get { return lblattendRequestForm; }
            set
            {
                lblattendRequestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttendRequestForm");
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
        private string imghistoryicon = "";
        public string imgHistoryicon
        {
            get { return imghistoryicon; }
            set
            {
                imghistoryicon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgHistoryicon");
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
                Tapmanifestrequesthistory.ChangeCanExecute();

            }
        }
        /// <summary>
        /// ViewModel - Constructor
        /// </summary>
        public AttendInspectionRequest1ViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("AttendInspectionRequest1ViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonretreive = new Command( async () => await buttonretreive(), () => !IsBusy);
            Tapmanifestrequesthistory = new Command(async () => await tapmanifestrequesthistory(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM459");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM459");
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

           
            imgVisitorIcon = dbLayer.getCaption("imgVisitor", objCMS);
            lblAttendRequest = dbLayer.getCaption("strAttendInspectionRequest", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblAttendRequestForm = dbLayer.getCaption("strAttendInspectionRequestForm", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
            lblBOLNo = dbLayer.getCaption("strBillOfLadingNumber", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            imgHistoryicon = dbLayer.getCaption("imgHistory", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgBolno = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgPlsProvid = dbLayer.getCaption("strSorryContainerEnteredNotValid", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To get Button Retreive Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonretreive()
        {
           await HiddErrorValidation();
            var Containerno = TxtContainerNo.ToString().Trim();
            var BOLno = TxtBOLNo.ToString().Trim();
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
                await fnAttendinspectionRetreiveData(Containerno, BOLno);
            }
        }
        /// <summary>
        /// To go to Retrive Data
        /// </summary>
        /// <param name="fstrContainernumber"></param>
        /// <param name="fstrBlnumber"></param>
        /// <returns></returns>
        private async Task fnAttendinspectionRetreiveData(string fstrContainernumber, string fstrBlnumber)
        {
            try
            {
              await  HiddErrorValidation();
                IsBusy = true;
                StackAttendRequest1 = false;
                await Task.Delay(1000);
                var objRawData = new List<AttendInspectiondt>();
                objRawData = objBl.RetreiveAttendInspectionDetails(fstrContainernumber, fstrBlnumber);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((objRawData != null) && (objRawData.Count > 0))
                {
                    string lblValContainerno = objRawData.ToArray()[0].cd_containernumber;
                    string lblValBOLno = objRawData.ToArray()[0].cd_blnumber;
                    await App.Current.MainPage?.Navigation.PushAsync(new AttendInspectionRequest2(lblValContainerno, lblValBOLno));
                }
                else
                {
                    IsvalidatedPlsProvid = true;
                }
                StackAttendRequest1 = true;
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
        private async Task tapmanifestrequesthistory()
        {
            IsBusy = true;
            StackAttendRequest1 = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Attend Inspection"));
            StackAttendRequest1 = true;
            IsBusy = false;
        }
        public async Task HiddErrorValidation()
        {
            IsvalidatedContainerNo = false;
            IsvalidatedBolno = false;
            IsvalidatedPlsProvid = false;
        }
    }
}
