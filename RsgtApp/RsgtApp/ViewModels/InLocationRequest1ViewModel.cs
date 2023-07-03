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
    public class InLocationRequest1ViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        //private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonretreive { get; set; }
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
        private bool stackInLocationRequest1 = true;
        public bool StackInLocationRequest1
        {
            get { return stackInLocationRequest1; }
            set
            {
                stackInLocationRequest1 = value;
                OnPropertyChanged();
                RaisePropertyChange("StackInLocationRequest1");
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
        private string TxtappointmentNo = "";
        public string TxtAppointmentNo
        {
            get { return TxtappointmentNo; }
            set
            {
                TxtappointmentNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtAppointmentNo");
            }
        }
        private string imgequipmentIcon = "";
        public string imgEquipmentIcon
        {
            get { return imgequipmentIcon; }
            set
            {
                imgequipmentIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEquipmentIcon");
            }
        }
        private string lblinlocationEquipment = "";
        public string lblInlocationEquipment
        {
            get { return lblinlocationEquipment; }
            set
            {
                lblinlocationEquipment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInlocationEquipment");
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
        private string lblinlocationRequestForm = "";
        public string lblInlocationRequestForm
        {
            get { return lblinlocationRequestForm; }
            set
            {
                lblinlocationRequestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblInlocationRequestForm");
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
        private string lblappointmentNo = "";
        public string lblAppointmentNo
        {
            get { return lblappointmentNo; }
            set
            {
                lblappointmentNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAppointmentNo");
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
        private string msgAppointmentno = "";
        public string MsgAppointmentno
        {
            get { return msgAppointmentno; }
            set
            {
                msgAppointmentno = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgAppointmentno");
            }
        }
        private bool isvalidatedAppointmentno = false;
        public bool IsvalidatedAppointmentno
        {
            get { return isvalidatedAppointmentno; }
            set
            {
                isvalidatedAppointmentno = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedAppointmentno");
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
                Tapmanifestrequesthistory.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public InLocationRequest1ViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("InLocationRequest1ViewModel");
            Task.Run(() => assignCms()).Wait();
            Buttonretreive = new Command(async () => await buttonretreive(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM460");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM460");
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
            imgEquipmentIcon = dbLayer.getCaption("imgEquipment", objCMS);
            lblInlocationEquipment = dbLayer.getCaption("strInLocationEquipmentRequest1", objCMS);
            imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
            lblInlocationRequestForm = dbLayer.getCaption("strInLocationRequestForm", objCMS);
            lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
            lblAppointmentNo = dbLayer.getCaption("strAppointmentNumber", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            imgHistoryIcon = dbLayer.getCaption("imgHistoryicon", objCMS);
            lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
            MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgAppointmentno = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgPlsProvid = dbLayer.getCaption("strEquipmentNotAvailableInLocation", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
        }
        /// <summary>
        /// To get button retreive
        /// </summary>
        /// <returns></returns>
        private async Task buttonretreive()
        {
            await Hidevalidtion();
            var Containerno = TxtContainerNo.ToString().Trim();
            var Appointmentno = TxtAppointmentNo.ToString().Trim();
            if ((Containerno == "") || (Containerno == null))
            {
                IsvalidatedContainerNo = true;
            }
            else
            {
                IsvalidatedContainerNo = false;
            }
            if ((Appointmentno == "") || (Appointmentno == null))
            {
                IsvalidatedAppointmentno = true;
            }
            else
            {
                IsvalidatedAppointmentno = false;
            }
            if ((Containerno != "") && (Appointmentno != ""))
            {
                await fnInlocationRetreiveData(Containerno, Appointmentno);
            }
        }
        /// <summary>
        /// Function for location Retreive Data
        /// </summary>
        /// <param name="fstrContainernumber"></param>
        /// <param name="fstrAppointmentno"></param>
        /// <returns></returns>
        private async Task fnInlocationRetreiveData(string fstrContainernumber, string fstrAppointmentno)
        {
            IsBusy = true;
            StackInLocationRequest1 = false;
            await Task.Delay(1000);
            await Hidevalidtion();
            var objRawData = new List<InlocationDt>();
            objRawData = objBl.RetreiveInlocation(fstrContainernumber, fstrAppointmentno);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
             App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            if ((objRawData != null) && (objRawData.Count > 0))
            {
                string lblValContainerno = fstrContainernumber;
                string lblValAppointmentno = fstrAppointmentno;
                await App.Current.MainPage?.Navigation.PushAsync(new InLocationEquipmentrequest2(lblValContainerno, lblValAppointmentno));
            }
            else
            {
                IsvalidatedPlsProvid = true;
            }
            StackInLocationRequest1 = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Request History
        /// </summary>
        /// <returns></returns>
        private async Task tapmanifestrequesthistory()
        {
            try
            {
                IsBusy = true;
                StackInLocationRequest1 = false;
                await Task.Delay(1000);
                await Hidevalidtion();
                await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Equipment Not Available in Location"));
                StackInLocationRequest1 = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        public async Task Hidevalidtion()
        {
            await Task.Delay(1000);
            IsvalidatedContainerNo = false;
            IsvalidatedPlsProvid = false;
            IsvalidatedAppointmentno = false;
            
        }
    }
}