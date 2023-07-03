using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Helpers;
using static RsgtApp.Models.Tracking;
using RsgtApp.Models;

namespace RsgtApp.ViewModels
{
    public class Basic_trackingViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       
        string strServerSlowMsg = "";
        private string lstrCurrentStatus = "";
        public int PhoneNumber { get; set; }
        public string strNT_UNITGKEY { get; set; }
        //To create bussinessLayer Object
        BLConnect objcon = new BLConnect();
        WebApiMethod objWeb = new WebApiMethod();
        public Command gotoNotify { get; set; }
        public Command ButtonClicked { get; set; }
        public Command gotoExit { get; set; }
        private List<BasicTrakingDetail> lstTrackingResult = new List<BasicTrakingDetail>();
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
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
        //Twoway Binding Property
        private bool stackTracking = true;
        public bool StackTracking
        {
            get { return stackTracking; }
            set
            {
                stackTracking = value;
                OnPropertyChanged();
                RaisePropertyChange("StackTracking");
            }
        }
        //imgTrackIcon purpose of using image varaiable
        private string imgTrackIcon = "";
        public string ImgTrackIcon
        {
            get { return imgTrackIcon; }
            set
            {
                imgTrackIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTrackIcon");
            }
        }
        //lblTrackShipment purpose of using lable varaiable
        private string lblTrackShipment = "";
        public string LblTrackShipment
        {
            get { return lblTrackShipment; }
            set
            {
                lblTrackShipment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTrackShipment");
            }
        }
        private string txtContainerNumber = "";
        public string TxtContainerNumber
        {
            get { return txtContainerNumber; }
            set
            {
                txtContainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainerNumber");
            }
        }
        //btnTrack purpose of using button varaiable
        private string btnTrack = "";
        public string BtnTrack
        {
            get { return btnTrack; }
            set
            {
                btnTrack = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnTrack");
            }
        }
        //txtTrackingNumber purpose of using entiry varaiable
        private string txtTrackingNumber = "";
        public string TxtTrackingNumber
        {
            get { return txtTrackingNumber; }
            set
            {
                txtTrackingNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTrackingNumber");
            }
        }
        //btnAdvanceTrackingLogIn purpose of using button varaiable
        private string btnAdvanceTrackingLogIn = "";
        public string BtnAdvanceTrackingLogIn
        {
            get { return btnAdvanceTrackingLogIn; }
            set
            {
                btnAdvanceTrackingLogIn = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnAdvanceTrackingLogIn");
            }
        }
        //msgMandatory purpose of using Mandatory varaiable
        private bool isvisibleMandatory = false;
        public bool IsVisibleMandatory
        {
            get { return isvisibleMandatory; }
            set
            {
                isvisibleMandatory = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleMandatory");
            }
        }
        //msgMandatory purpose of using Mandatory varaiable
        private string msgMandatorys = "";
        public string MsgMandatorys
        {
            get { return msgMandatorys; }
            set
            {
                msgMandatorys = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMandatorys");
            }
        }
        //placeContainerNumber purpose of using PlaceHolder varaiable
        private string placeContainerNumber = "";
        public string PlaceContainerNumber
        {
            get { return placeContainerNumber; }
            set
            {
                placeContainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceContainerNumber");
            }
        }
        //stackTrackingResult purpose of using StackResult varaiable
        private string stackTrackingResult = "";
        public string StackTrackingResult
        {
            get { return stackTrackingResult; }
            set
            {
                stackTrackingResult = value;
                OnPropertyChanged();
                RaisePropertyChange("StackTrackingResult");
            }
        }
        //lblTrackingResult purpose of using lable varaiable
        private string lblTrackingResult = "";
        public string LblTrackingResult
        {
            get { return lblTrackingResult; }
            set
            {
                lblTrackingResult = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTrackingResult");
            }
        }
        //lblBayanNo purpose of using lable varaiable
        private string lblBayanNo = "";
        public string LblBayanNo
        {
            get { return lblBayanNo; }
            set
            {
                lblBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBayanNo");
            }
        }
        //bayanNo purpose of using lable varaiable
        private string bayanNo = "";
        public string BayanNo
        {
            get { return bayanNo; }
            set
            {
                bayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("BayanNo");
            }
        }
        //imgDownArrowIcon purpose of using image varaiable
        private string imgDownArrowIcon = "";
        public string ImgDownArrowIcon
        {
            get { return imgDownArrowIcon; }
            set
            {
                imgDownArrowIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrowIcon");
            }
        }
        //lblBol purpose of using lable varaiable
        private string lblBol = "";
        public string LblBol
        {
            get { return lblBol; }
            set
            {
                lblBol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBol");
            }
        }
        //bLNo purpose of using Value varaiable
        private string bLNo = "";
        public string BLNo
        {
            get { return bLNo; }
            set
            {
                bLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("BLNo");
            }
        }
        //lblContainer purpose of using lable varaiable
        private string lblContainer = "";
        public string LblContainer
        {
            get { return lblContainer; }
            set
            {
                lblContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainer");
            }
        }
        //containerNo purpose of using Value varaiable
        private string containerNo = "";
        public string ContainerNo
        {
            get { return containerNo; }
            set
            {
                containerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("ContainerNo");
            }
        }
        private string lblcategory = "";
        public string lblCategory
        {
            get { return lblcategory; }
            set
            {
                lblcategory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCategory");
            }
        }
        private string categoryImpExp = "";
        public string CategoryImpExp
        {
            get { return categoryImpExp; }
            set
            {
                categoryImpExp = value;
                OnPropertyChanged();
                RaisePropertyChange("CategoryImpExp");
            }
        }
        //lblVesselVisitId purpose of using lable varaiable
        private string lblVesselVisitId = "";
        public string LblVesselVisitId
        {
            get { return lblVesselVisitId; }
            set
            {
                lblVesselVisitId = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVesselVisitId");
            }
        }
        //vesselVisitId purpose of using Value varaiable
        private string vesselVisitId = "";
        public string VesselVisitId
        {
            get { return vesselVisitId; }
            set
            {
                vesselVisitId = value;
                OnPropertyChanged();
                RaisePropertyChange("VesselVisitId");
            }
        }
        //lblVesseName purpose of using lable varaiable
        private string lblVesseName = "";
        public string LblVesseName
        {
            get { return lblVesseName; }
            set
            {
                lblVesseName = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVesseName");
            }
        }
        //vesseName purpose of using Value varaiable
        private string vesseName = "";
        public string VesseName
        {
            get { return vesseName; }
            set
            {
                vesseName = value;
                OnPropertyChanged();
                RaisePropertyChange("VesseName");
            }
        }
        //lblVoyage purpose of using lable varaiable
        private string lblVoyage = "";
        public string LblVoyage
        {
            get { return lblVoyage; }
            set
            {
                lblVoyage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVoyage");
            }
        }
        //voyage purpose of using Value varaiable
        private string voyage = "";
        public string Voyage
        {
            get { return voyage; }
            set
            {
                voyage = value;
                OnPropertyChanged();
                RaisePropertyChange("Voyage");
            }
        }
        //lblETA purpose of using lable varaiable
        private string lblETA = "";
        public string LblETA
        {
            get { return lblETA; }
            set
            {
                lblETA = value;
                OnPropertyChanged();
                RaisePropertyChange("LblETA");
            }
        }
        //eTA purpose of using Value varaiable
        private string eTA = "";
        public string ETA
        {
            get { return eTA; }
            set
            {
                eTA = value;
                OnPropertyChanged();
                RaisePropertyChange("ETA");
            }
        }
        //lblEmptyDepotFreeDays purpose of using lable varaiable
        private string lblEmptyDepotFreeDays = "";
        public string LblEmptyDepotFreeDays
        {
            get { return lblEmptyDepotFreeDays; }
            set
            {
                lblEmptyDepotFreeDays = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmptyDepotFreeDays");
            }
        }
        //emptyDepot purpose of using Value varaiable
        private string emptyDepot = "";
        public string EmptyDepot
        {
            get { return emptyDepot; }
            set
            {
                emptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("EmptyDepot");
            }
        }
        //lblDepotFreeDays purpose of using lable varaiable
        private string lblDepotFreeDays = "";
        public string LblDepotFreeDays
        {
            get { return lblDepotFreeDays; }
            set
            {
                lblDepotFreeDays = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDepotFreeDays");
            }
        }
        //depotFreeDays purpose of using Value varaiable
        private string depotFreeDays = "";
        public string DepotFreeDays
        {
            get { return depotFreeDays; }
            set
            {
                depotFreeDays = value;
                OnPropertyChanged();
                RaisePropertyChange("DepotFreeDays");
            }
        }
        //imgStatusIconOnVessel purpose of using image varaiable
        private string imgStatusIconOnVessel = "";
        public string ImgStatusIconOnVessel
        {
            get { return imgStatusIconOnVessel; }
            set
            {
                imgStatusIconOnVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusIconOnVessel");
            }
        }
        //lblOnVessel purpose of using lable varaiable
        private string lblOnVessel = "";
        public string LblOnVessel
        {
            get { return lblOnVessel; }
            set
            {
                lblOnVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOnVessel");
            }
        }
        //onVessel purpose of using Value varaiable
        private string onVessel = "";
        public string OnVessel
        {
            get { return onVessel; }
            set
            {
                onVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("OnVessel");
            }
        }
        //imgStatusIconUnderInspec purpose of using image varaiable
        private string imgStatusIconUnderInspec = "";
        public string ImgStatusIconUnderInspec
        {
            get { return imgStatusIconUnderInspec; }
            set
            {
                imgStatusIconUnderInspec = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusIconUnderInspec");
            }
        }
        //lblUnderInspection purpose of using lable varaiable
        private string lblUnderInspection = "";
        public string LblUnderInspection
        {
            get { return lblUnderInspection; }
            set
            {
                lblUnderInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("LblUnderInspection");
            }
        }
        //underInspection purpose of using Value varaiable
        private string underInspection = "";
        public string UnderInspection
        {
            get { return underInspection; }
            set
            {
                underInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("UnderInspection");
            }
        }
        //imgStatusIconInsComp purpose of using image varaiable
        private string imgStatusIconInsComp = "";
        public string ImgStatusIconInsComp
        {
            get { return imgStatusIconInsComp; }
            set
            {
                imgStatusIconInsComp = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusIconInsComp");
            }
        }
        //lblInspectionCompleted purpose of using lable varaiable
        private string lblInspectionCompleted = "";
        public string LblInspectionCompleted
        {
            get { return lblInspectionCompleted; }
            set
            {
                lblInspectionCompleted = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInspectionCompleted");
            }
        }
        //inspectionCompleted purpose of using Value varaiable
        private string inspectionCompleted = "";
        public string InspectionCompleted
        {
            get { return inspectionCompleted; }
            set
            {
                inspectionCompleted = value;
                OnPropertyChanged();
                RaisePropertyChange("InspectionCompleted");
            }
        }
        //imgStatusGreenIcon4 purpose of using image varaiable
        private string imgStatusGreenIcon4 = "";
        public string ImgStatusGreenIcon4
        {
            get { return imgStatusGreenIcon4; }
            set
            {
                imgStatusGreenIcon4 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusGreenIcon4");
            }
        }
        //lblContactShippingLine purpose of using lable varaiable
        private bool lblContactShippingLine = false;
        public bool LblContactShippingLine
        {
            get { return lblContactShippingLine; }
            set
            {
                lblContactShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContactShippingLine");
            }
        }
        //imgStatusIconRFD2 purpose of using image varaiable
        private string imgStatusIconRFD2 = "";
        public string ImgStatusIconRFD2
        {
            get { return imgStatusIconRFD2; }
            set
            {
                imgStatusIconRFD2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusIconRFD2");
            }
        }
        //contactShippingLine purpose of using Value varaiable
        private bool contactShippingLine = false;
        public bool ContactShippingLine
        {
            get { return contactShippingLine; }
            set
            {
                contactShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("ContactShippingLine");
            }
        }
        private string contactshippingLine = "";
        public string ContactshippingLine
        {
            get { return contactshippingLine; }
            set
            {
                contactshippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("ContactshippingLine");
            }
        }
        //lblportcharge purpose of using lable varaiable
        private string lblportcharge = "";
        public string Lblportcharge
        {
            get { return lblportcharge; }
            set
            {
                lblportcharge = value;
                OnPropertyChanged();
                RaisePropertyChange("lblportcharge");
            }
        }
        //waitingForPortcharge purpose of using Value varaiable
        private string waitingForPortcharge = "";
        public string WaitingForPortcharge
        {
            get { return waitingForPortcharge; }
            set
            {
                waitingForPortcharge = value;
                OnPropertyChanged();
                RaisePropertyChange("WaitingForPortcharge");
            }
        }
        //imgStatusIconRFD purpose of using image varaiable
        private string imgStatusIconRFD = "";
        public string ImgStatusIconRFD
        {
            get { return imgStatusIconRFD; }
            set
            {
                imgStatusIconRFD = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusIconRFD");
            }
        }
        //lblReadForDelivery purpose of using lable varaiable
        private string lblReadForDelivery = "";
        public string LblReadForDelivery
        {
            get { return lblReadForDelivery; }
            set
            {
                lblReadForDelivery = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReadForDelivery");
            }
        }
        //rFD purpose of using Value varaiable
        private string rFD = "";
        public string RFD
        {
            get { return rFD; }
            set
            {
                rFD = value;
                OnPropertyChanged();
                RaisePropertyChange("RFD");
            }
        }
        //imgStatusIconPrePickUp purpose of using image varaiable
        private string imgStatusIconPrePickUp = "";
        public string ImgStatusIconPrePickUp
        {
            get { return imgStatusIconPrePickUp; }
            set
            {
                imgStatusIconPrePickUp = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusIconPrePickUp");
            }
        }
        //imgStatusIconPrePickUp purpose of using image varaiable
        private string lblPrePickUpIssued = "";
        public string LblPrePickUpIssued
        {
            get { return lblPrePickUpIssued; }
            set
            {
                lblPrePickUpIssued = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPrePickUpIssued");
            }
        }
        //prePickUp purpose of using Value varaiable
        private string prePickUp = "";
        public string PrePickUp
        {
            get { return prePickUp; }
            set
            {
                prePickUp = value;
                OnPropertyChanged();
                RaisePropertyChange("PrePickUp");
            }
        }
        //imgStatusIconGO purpose of using image varaiable
        private string imgStatusIconGO = "";
        public string ImgStatusIconGO
        {
            get { return imgStatusIconGO; }
            set
            {
                imgStatusIconGO = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgStatusIconGO");
            }
        }
        //lblGatedOut purpose of using lable varaiable
        private string lblGatedOut = "";
        public string LblGatedOut
        {
            get { return lblGatedOut; }
            set
            {
                lblGatedOut = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGatedOut");
            }
        }
        //gatedOut purpose of using Value varaiable
        private string gatedOut = "";
        public string GatedOut
        {
            get { return gatedOut; }
            set
            {
                gatedOut = value;
                OnPropertyChanged();
                RaisePropertyChange("GatedOut");
            }
        }
        private string imgexpGatedIn = "";
        public string ImgexpGatedIn
        {
            get { return imgexpGatedIn; }
            set
            {
                imgexpGatedIn = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpGatedIn");
            }
        }
        private string lblgatedIn = "";
        public string lblGatedIn
        {
            get { return lblgatedIn; }
            set
            {
                lblgatedIn = value;
                OnPropertyChanged();
                RaisePropertyChange("lblGatedIn");
            }
        }
        private string receivedGatedIn = "";
        public string ReceivedGatedIn
        {
            get { return receivedGatedIn; }
            set
            {
                receivedGatedIn = value;
                OnPropertyChanged();
                RaisePropertyChange("ReceivedGatedIn");
            }
        }
        private string imgexpCustomsInspection = "";
        public string ImgexpCustomsInspection
        {
            get { return imgexpCustomsInspection; }
            set
            {
                imgexpCustomsInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpCustomsInspection");
            }
        }
        private string lblcustomsInspection = "";
        public string lblCustomsInspection
        {
            get { return lblcustomsInspection; }
            set
            {
                lblcustomsInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomsInspection");
            }
        }
        private string customsInspection = "";
        public string CustomsInspection
        {
            get { return customsInspection; }
            set
            {
                customsInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("CustomsInspection");
            }
        }
        private string inspectionBookingMsg = "";
        public string InspectionBookingMsg
        {
            get { return inspectionBookingMsg; }
            set
            {
                inspectionBookingMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("InspectionBookingMsg");
            }
        }
        private string imgexpExcessCargo = "";
        public string ImgexpExcessCargo
        {
            get { return imgexpExcessCargo; }
            set
            {
                imgexpExcessCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpExcessCargo");
            }
        }
        private string lblcolExcessCargo = "";
        public string lblColExcessCargo
        {
            get { return lblcolExcessCargo; }
            set
            {
                lblcolExcessCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblColExcessCargo");
            }
        }
        private string colExcessCargo = "";
        public string ColExcessCargo
        {
            get { return colExcessCargo; }
            set
            {
                colExcessCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("ColExcessCargo");
            }
        }
        private string imgexpWaitShipline = "";
        public string ImgexpWaitShipline
        {
            get { return imgexpWaitShipline; }
            set
            {
                imgexpWaitShipline = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpWaitShipline");
            }
        }
        private string lblwaitShipline = "";
        public string lblWaitShipline
        {
            get { return lblwaitShipline; }
            set
            {
                lblwaitShipline = value;
                OnPropertyChanged();
                RaisePropertyChange("lblWaitShipline");
            }
        }
        private string waitshiplineRelease = "";
        public string WaitshiplineRelease
        {
            get { return waitshiplineRelease; }
            set
            {
                waitshiplineRelease = value;
                OnPropertyChanged();
                RaisePropertyChange("WaitshiplineRelease");
            }
        }
        private string imgexpWaitcoldstorepayment = "";
        public string ImgexpWaitcoldstorepayment
        {
            get { return imgexpWaitcoldstorepayment; }
            set
            {
                imgexpWaitcoldstorepayment = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpWaitcoldstorepayment");
            }
        }
        private string lblwaitcoldstorepayment = "";
        public string lblWaitcoldstorepayment
        {
            get { return lblwaitcoldstorepayment; }
            set
            {
                lblwaitcoldstorepayment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblWaitcoldstorepayment");
            }
        }
        private string waitColdstorepayment = "";
        public string WaitColdstorepayment
        {
            get { return waitColdstorepayment; }
            set
            {
                waitColdstorepayment = value;
                OnPropertyChanged();
                RaisePropertyChange("WaitColdstorepayment");
            }
        }
        private string imgexpWaitforRSGTPayment = "";
        public string ImgexpWaitforRSGTPayment
        {
            get { return imgexpWaitforRSGTPayment; }
            set
            {
                imgexpWaitforRSGTPayment = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpWaitforRSGTPayment");
            }
        }
        private string lblwaitforRSGTPayment = "";
        public string lblWaitforRSGTPayment
        {
            get { return lblwaitforRSGTPayment; }
            set
            {
                lblwaitforRSGTPayment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblWaitforRSGTPayment");
            }
        }
        private string waitforRSGTPayment = "";
        public string WaitforRSGTPayment
        {
            get { return waitforRSGTPayment; }
            set
            {
                waitforRSGTPayment = value;
                OnPropertyChanged();
                RaisePropertyChange("WaitforRSGTPayment");
            }
        }
        private string imgexpReadytoLoad = "";
        public string ImgexpReadytoLoad
        {
            get { return imgexpReadytoLoad; }
            set
            {
                imgexpReadytoLoad = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpReadytoLoad");
            }
        }
        private string readytoLoad = "";
        public string ReadytoLoad
        {
            get { return readytoLoad; }
            set
            {
                readytoLoad = value;
                OnPropertyChanged();
                RaisePropertyChange("ReadytoLoad");
            }
        }
        private string imgexpLoadedonvessel = "";
        public string ImgexpLoadedonvessel
        {
            get { return imgexpLoadedonvessel; }
            set
            {
                imgexpLoadedonvessel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgexpLoadedonvessel");
            }
        }
        private string lblloadedonvessel = "";
        public string lblLoadedonvessel
        {
            get { return lblloadedonvessel; }
            set
            {
                lblloadedonvessel = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLoadedonvessel");
            }
        }
        private string loadedonvessel = "";
        public string Loadedonvessel
        {
            get { return loadedonvessel; }
            set
            {
                loadedonvessel = value;
                OnPropertyChanged();
                RaisePropertyChange("Loadedonvessel");
            }
        }
        private string containerRolledMsg = "";
        public string ContainerRolledMsg
        {
            get { return containerRolledMsg; }
            set
            {
                containerRolledMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("ContainerRolledMsg");
            }
        }
        private string lblgatedin = "";
        public string lblGatedin
        {
            get { return lblgatedin; }
            set
            {
                lblgatedin = value;
                OnPropertyChanged();
                RaisePropertyChange("lblGatedin");
            }
        }
        private string lblcustomsinspection = "";
        public string lblCustomsinspection
        {
            get { return lblcustomsinspection; }
            set
            {
                lblcustomsinspection = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomsinspection");
            }
        }
        private string lblcolexcesscargo = "";
        public string lblColexcesscargo
        {
            get { return lblcolexcesscargo; }
            set
            {
                lblcolexcesscargo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblColexcesscargo");
            }
        }
        private string lblwaitshipline = "";
        public string lblWaitshipline
        {
            get { return lblwaitshipline; }
            set
            {
                lblwaitshipline = value;
                OnPropertyChanged();
                RaisePropertyChange("lblWaitshipline");
            }
        }
        private string lblwaitforrsgtpayment = "";
        public string lblWaitforrsgtpayment
        {
            get { return lblwaitforrsgtpayment; }
            set
            {
                lblwaitforrsgtpayment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblWaitforrsgtpayment");
            }
        }
        private string lblreadytoload = "";
        public string lblReadytoload
        {
            get { return lblreadytoload; }
            set
            {
                lblreadytoload = value;
                OnPropertyChanged();
                RaisePropertyChange("lblReadytoload");
            }
        }
        private string lblemptydepotfreedays = "";
        public string lblEmptydepotfreedays
        {
            get { return lblemptydepotfreedays; }
            set
            {
                lblemptydepotfreedays = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmptydepotfreedays");
            }
        }
        private string inspectionbookingmsg = "";
        public string Inspectionbookingmsg
        {
            get { return inspectionbookingmsg; }
            set
            {
                inspectionbookingmsg = value;
                OnPropertyChanged();
                RaisePropertyChange("Inspectionbookingmsg");
            }
        }
        private string containerrolledmsg = "";
        public string Containerrolledmsg
        {
            get { return containerrolledmsg; }
            set
            {
                containerrolledmsg = value;
                OnPropertyChanged();
                RaisePropertyChange("Containerrolledmsg");
            }
        }
        private string imgexpgatedin = "";
        public string Imgexpgatedin
        {
            get { return imgexpgatedin; }
            set
            {
                imgexpgatedin = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexpgatedin");
            }
        }
        private string imgexpcustomsinspection = "";
        public string Imgexpcustomsinspection
        {
            get { return imgexpcustomsinspection; }
            set
            {
                imgexpcustomsinspection = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexpcustomsinspection");
            }
        }
        private string imgexpexcesscargo = "";
        public string Imgexpexcesscargo
        {
            get { return imgexpexcesscargo; }
            set
            {
                imgexpexcesscargo = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexpexcesscargo");
            }
        }
        private string imgexpwaitshipline = "";
        public string Imgexpwaitshipline
        {
            get { return imgexpwaitshipline; }
            set
            {
                imgexpwaitshipline = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexpwaitshipline");
            }
        }
        private string imgexpwaitcoldstorepayment = "";
        public string Imgexpwaitcoldstorepayment
        {
            get { return imgexpwaitcoldstorepayment; }
            set
            {
                imgexpwaitcoldstorepayment = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexpwaitcoldstorepayment");
            }
        }
        private string imgexpwaitforrsgtpayment = "";
        public string Imgexpwaitforrsgtpayment
        {
            get { return imgexpwaitforrsgtpayment; }
            set
            {
                imgexpwaitforrsgtpayment = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexpwaitforrsgtpayment");
            }
        }
        private string imgexpreadytoload = "";
        public string Imgexpreadytoload
        {
            get { return imgexpreadytoload; }
            set
            {
                imgexpreadytoload = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexpreadytoload");
            }
        }
        private string imgexploadedonvessel = "";
        public string Imgexploadedonvessel
        {
            get { return imgexploadedonvessel; }
            set
            {
                imgexploadedonvessel = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgexploadedonvessel");
            }
        }
        private bool isVisibleCustomInsp = false;
        public bool IsVisibleCustomInsp
        {
            get { return isVisibleCustomInsp; }
            set
            {
                isVisibleCustomInsp = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCustomInsp");
            }
        }
        private bool isVisibleInspectionBookingMsg = false;
        public bool IsVisibleInspectionBookingMsg
        {
            get { return isVisibleInspectionBookingMsg; }
            set
            {
                isVisibleInspectionBookingMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleInspectionBookingMsg");
            }
        }
        private bool isVisibleLoadonvessel = false;
        public bool IsVisibleLoadonvessel
        {
            get { return isVisibleLoadonvessel; }
            set
            {
                isVisibleLoadonvessel = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleLoadonvessel");
            }
        }
        private bool isVisibleContainerRolledMsg = false;
        public bool IsVisibleContainerRolledMsg
        {
            get { return isVisibleContainerRolledMsg; }
            set
            {
                isVisibleContainerRolledMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleContainerRolledMsg");
            }
        }
        private bool isVisibleEmptyDepot = false;
        public bool IsVisibleEmptyDepot
        {
            get { return isVisibleEmptyDepot; }
            set
            {
                isVisibleEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleEmptyDepot");
            }
        }
        private bool isVisibleDepotFreeDays = false;
        public bool IsVisibleDepotFreeDays
        {
            get { return isVisibleDepotFreeDays; }
            set
            {
                isVisibleDepotFreeDays = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleDepotFreeDays");
            }
        }
        private bool isVisibleBlImport = false;
        public bool IsVisibleBlImport
        {
            get { return isVisibleBlImport; }
            set
            {
                isVisibleBlImport = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleBlImport");
            }
        }
        private bool isVisibleBlExport = false;
        public bool IsVisibleBlExport
        {
            get { return isVisibleBlExport; }
            set
            {
                isVisibleBlExport = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleBlExport");
            }
        }
        //btnNotify purpose of using button varaiable
        private string btnNotify = "";
        public string BtnNotify
        {
            get { return btnNotify; }
            set
            {
                btnNotify = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnNotify");
            }
        }
        //stackTrackingResultMsg purpose of using Message varaiable
        private string stackTrackingResultMsg = "";
        public string StackTrackingResultMsg
        {
            get { return stackTrackingResultMsg; }
            set
            {
                stackTrackingResultMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackTrackingResultMsg");
            }
        }
        //imgRegisterIcon purpose of using image varaiable
        private string imgRegisterIcon = "";
        public string ImgRegisterIcon
        {
            get { return imgRegisterIcon; }
            set
            {
                imgRegisterIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRegisterIcon");
            }
        }
        //lblDearCustomer purpose of using lable varaiable
        private string lblDearCustomer = "";
        public string LblDearCustomer
        {
            get { return lblDearCustomer; }
            set
            {
                lblDearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearCustomer");
            }
        }
        //lblMessage purpose of using lable varaiable
        private string lblMessage = "";
        public string LblMessage
        {
            get { return lblMessage; }
            set
            {
                lblMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessage");
            }
        }
        //btnOk purpose of using button varaiable
        private string btnOk = "";
        public string BtnOk
        {
            get { return btnOk; }
            set
            {
                btnOk = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnOk");
            }
        }
        //isBusy purpose of using indicator varaiable
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoNotify.ChangeCanExecute();
                ButtonClicked.ChangeCanExecute();
                gotoExit.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        public Basic_trackingViewModel()
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("Basic_trackingViewModel");
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
                //Begin-All Command Buttons
                gotoNotify = new Command(async () => await gotonotify(), () => !IsBusy);
                ButtonClicked = new Command(async () => await Button_Clicked(), () => !IsBusy);
                gotoExit = new Command(async () => await gotoexit(), () => !IsBusy);

                //End-All Command Buttons
                
                LblContactShippingLine = false;
                ContactShippingLine = false;

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To bind CMS  Captions
        /// </summary>
        /// <returns></returns>
        public async Task assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM010");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM010");

                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                await assignContent();
               
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// Date
        /// Created By
        /// Modified By
        /// </summary>

        ///To bind CMS captions
        public async Task assignContent()
        {
            try
            {
               
                                            
                imgTrackIcon = dbLayer.getCaption("imgTrack", objCMS);
                lblTrackShipment = dbLayer.getCaption("strTrackYourShipment", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                MsgMandatorys = dbLayer.getCaption("strMobilepattern", objCMSMSG);
                txtTrackingNumber = dbLayer.getCaption("strTrackingNumber", objCMS);
                btnTrack = dbLayer.getCaption("strTrack", objCMS);
                PlaceContainerNumber = dbLayer.getCaption("strContainerNumber", objCMS);
                btnAdvanceTrackingLogIn = dbLayer.getCaption("strAdvancrTracking", objCMS);
                //result
                string lstrGrayIcon = dbLayer.getCaption("imgstatusgrayicon", objCMS);
                lblTrackingResult = dbLayer.getCaption("strTrackingResult", objCMS);
                lblBayanNo = dbLayer.getCaption("strBayanNo", objCMS);
                imgDownArrowIcon = dbLayer.getCaption("imgDownArrowicon", objCMS);
                lblBol = dbLayer.getCaption("strBOL", objCMS);
                lblContainer = dbLayer.getCaption("strContainers", objCMS);
                lblVesselVisitId = dbLayer.getCaption("strVesselVisitID", objCMS);
                lblVesseName = dbLayer.getCaption("strVesselName", objCMS);
                lblVoyage = dbLayer.getCaption("strVoyage", objCMS);
                lblETA = dbLayer.getCaption("strETA", objCMS);
                lblOnVessel = dbLayer.getCaption("strOnVessel", objCMS);
                lblUnderInspection = dbLayer.getCaption("strUnderInspection", objCMS);
                lblInspectionCompleted = dbLayer.getCaption("strInspectionCompleted", objCMS);
                lblReadForDelivery = dbLayer.getCaption("strReadyfordelivery", objCMS);
                lblPrePickUpIssued = dbLayer.getCaption("strPrePickUpIssued", objCMS);
                lblGatedOut = dbLayer.getCaption("strGatedOut", objCMS);
                btnNotify = dbLayer.getCaption("strNotify", objCMS);
                imgStatusIconOnVessel = lstrGrayIcon;
                imgStatusIconPrePickUp = lstrGrayIcon;
                imgStatusIconUnderInspec = lstrGrayIcon;
                imgStatusIconInsComp = lstrGrayIcon;
                imgStatusIconRFD2 = lstrGrayIcon;
                imgStatusIconRFD = lstrGrayIcon;
                imgStatusIconGO = lstrGrayIcon;
                lblEmptyDepotFreeDays = dbLayer.getCaption("strEmptyDepots", objCMS);
                lblDepotFreeDays = dbLayer.getCaption("strFreeDays", objCMS);
                lblportcharge = dbLayer.getCaption("strWaitingforPortCharges", objCMS);
                lblDepotFreeDays = dbLayer.getCaption("strFreeDay", objCMS);
                //Messages page
                imgRegisterIcon = dbLayer.getCaption("imgRegistericon", objCMS);
                lblDearCustomer = dbLayer.getCaption("strCustomer", objCMS);
                lblMessage = dbLayer.getCaption("strBTrackingMessage", objCMS);
                btnOk = dbLayer.getCaption("strOk", objCMS);
                //Export captions 12-01-2023-sanduru
                lblCategory = dbLayer.getCaption("strCategory", objCMS);
                lblGatedin = dbLayer.getCaption("strReceivedGatedIn", objCMS);
                lblCustomsinspection = dbLayer.getCaption("strUnderCustomsInspection", objCMS);
                lblColexcesscargo = dbLayer.getCaption("strCollectingExcessCargo", objCMS);
                lblWaitshipline = dbLayer.getCaption("strWaitingshippinglineRelease", objCMS);
                lblWaitcoldstorepayment = dbLayer.getCaption("strWaitingcoldstorepayment", objCMS);
                lblWaitforrsgtpayment = dbLayer.getCaption("strWaitingforRSGTPayment", objCMS);
                lblReadytoload = dbLayer.getCaption("strReadytoLoad", objCMS);
                lblLoadedonvessel = dbLayer.getCaption("strLoadedonvessel", objCMS);
                lblEmptydepotfreedays = dbLayer.getCaption("strEmptyDepots", objCMS);
                InspectionBookingMsg = dbLayer.getCaption("strRSGTdidnotreceiveinspectionbooking", objCMS);
                ContainerRolledMsg = dbLayer.getCaption("strContainerRolledOver", objCMS);
                Imgexpgatedin = lstrGrayIcon;
                Imgexpcustomsinspection = lstrGrayIcon;
                Imgexpexcesscargo = lstrGrayIcon;
                Imgexpwaitshipline = lstrGrayIcon;
                Imgexpwaitcoldstorepayment = lstrGrayIcon;
                Imgexpwaitforrsgtpayment = lstrGrayIcon;
                Imgexpreadytoload = lstrGrayIcon;
                Imgexploadedonvessel = lstrGrayIcon;

                lstTrackingResult = Tracking.lstTracking;

                await BasicContainerDetails();
                await Task.Delay(1000);
                StackTracking = true;
            }
            catch (Exception ex)
            {
              App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To Navigate PageLogin Page 
        /// </summary>
        /// <returns></returns>
        private async Task gotoAdvanceTrackingLogIn()
        {
            await Task.Delay(1000);// Change 20220623
            await App.Current.MainPage?.Navigation.PushAsync(new PageLogin());
        }
        /// <summary>
        /// Go to Exit
        /// </summary>
        /// <returns></returns>
        private async Task gotoexit()
        {
            await Task.Delay(1000);
            Application.Current.MainPage?.Navigation.PopAsync();
            Application.Current.MainPage = new AppShell();
        }

        /// <summary>
        /// To Get BasicTrackingContainerDetails
        /// </summary>
        /// <returns></returns>
        private async Task BasicContainerDetails()
        {
            try
            {
                IsVisibleBlExport = true;
                IsVisibleBlImport = false;
                IsVisibleCustomInsp = true;
                IsVisibleLoadonvessel = true;
                IsVisibleInspectionBookingMsg = false;
                IsVisibleContainerRolledMsg = false;
                int lint = 0;
                lstTracking = objcon.getBasicTrakingContainerDetail(gblRegisteration.strContainerNo);
                await Task.Delay(1000);
                //Web Api Timeout
                //if (AppSettings.ErrorExceptionWebApi != "")
                //{
                //    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                //}
                if (lstTracking.Count > lint)
                {
                    BayanNo = lstTracking.ToArray()[0].cd_bayannumber.ToString();
                    BLNo = lstTracking.ToArray()[0].cd_blnumber.ToString();
                    ContainerNo = gblRegisteration.strContainerNo;
                    CategoryImpExp = lstTracking.ToArray()[0].cd_category.ToString(); //12-01-2023-Sanduru
                    if (CategoryImpExp == "IMPRT") //12-01-2023-Sanduru
                    {
                        IsVisibleBlImport = true;
                        IsVisibleBlExport = false;
                    }
                    VesselVisitId = lstTracking.ToArray()[0].cd_vesselvisitid.ToString();
                    string lstrVesselVisitId = lstTracking.ToArray()[0].cd_vesselvisitid.ToString(); //12-01-2023-Sanduru
                    if (lstrVesselVisitId.Length > 18)
                    {
                        VesselVisitId = lstrVesselVisitId.Substring(0, 18);
                    }
                    else
                    {
                        VesselVisitId = lstrVesselVisitId;
                    }
                    VesseName = lstTracking.ToArray()[0].cd_vesselname1.ToString();
                    string lstrVesseName = lstTracking.ToArray()[0].cd_vesselname1.ToString(); //12-01-2023-Sanduru
                    if (lstrVesseName.Length > 18)
                    {
                        VesseName = lstrVesseName.Substring(0, 18);
                    }
                    else
                    {
                        VesseName = lstrVesseName;
                    }
                    Voyage = lstTracking.ToArray()[0].cd_obvoyage.ToString();
                    strNT_UNITGKEY = lstTracking.ToArray()[0].cd_unitgkey.ToString().Trim();
                    if ((lstTracking.ToArray()[0].cd_fmtactualtimeofarrival != null) && (lstTracking.ToArray()[0].cd_fmtactualtimeofarrival != ""))
                    {
                        lblETA = dbLayer.getCaption("strATA", objCMS);
                        ETA = lstTracking.ToArray()[0].cd_fmtactualtimeofarrival.ToString();
                        OnVessel = lstTracking.ToArray()[0].cd_fmarrived.ToString();
                    }
                    else
                    {
                        lblETA = dbLayer.getCaption("strETA", objCMS);
                        ETA = lstTracking.ToArray()[0].cd_fmtexpectedtimeofarrival.ToString();
                        OnVessel = lstTracking.ToArray()[0].cd_fmarrived.ToString();
                    }
                    DepotFreeDays = lstTracking.ToArray()[0].cd_emptydepot_eng.ToString();
                    if (App.gblLanguage == "Ar")
                    {
                        DepotFreeDays = lstTracking.ToArray()[0].cd_emptydepot_ara.ToString();
                    }
                    EmptyDepot = lstTracking.ToArray()[0].cd_emptydepot.ToString();
                    UnderInspection = lstTracking.ToArray()[0].cd_fmtmovetoinspectiontime.ToString();
                    InspectionCompleted = lstTracking.ToArray()[0].cd_fmtinspectioncomplete.ToString();
                    lstrCurrentStatus = lstTracking.ToArray()[0].cd_statusdesc1.ToString();
                    string strGateOut = gblRegisteration.strContainerNo;
                    GatedOut = lstTracking.ToArray()[0].cd_fmgatedouttime.ToString();
                    WaitingForPortcharge = lstTracking.ToArray()[0].timeline_waitingforportcharges.ToString();
                    RFD = lstTracking.ToArray()[0].cd_fmreadyfordeliverytime.ToString();
                    ContactshippingLine = lstTracking.ToArray()[0].cd_shipperdesc1.ToString();
                    PrePickUp = lstTracking.ToArray()[0].cd_fmprepickissuedtime.ToString();
                    //12-01-2023-Sanduru
                    ReceivedGatedIn = lstTracking.ToArray()[0].timeline_expunitintime.ToString();
                    CustomsInspection = lstTracking.ToArray()[0].timeline_expbookforinsptime.ToString();
                    if (CustomsInspection == null || CustomsInspection == "")
                    {
                        IsVisibleCustomInsp = false;
                        IsVisibleInspectionBookingMsg = true;
                    }
                    ColExcessCargo = lstTracking.ToArray()[0].timeline_expexcesscargoholdtime.ToString();
                    WaitshiplineRelease = lstTracking.ToArray()[0].timeline_expdetentionholdtime.ToString();
                    WaitColdstorepayment = lstTracking.ToArray()[0].timeline_expcoldstorepayholdtime.ToString();
                    WaitforRSGTPayment = lstTracking.ToArray()[0].timeline_expfinholdtime.ToString();
                    ReadytoLoad = lstTracking.ToArray()[0].timeline_expreadytoloadtime.ToString();
                    Loadedonvessel = lstTracking.ToArray()[0].timeline_expunitloadtime.ToString();
                    if (Loadedonvessel == null || Loadedonvessel == "")
                    {
                        IsVisibleLoadonvessel = false;
                        IsVisibleContainerRolledMsg = true;
                    }
                    //03-01-2023-Sanduru
                    IsVisibleEmptyDepot = true;
                    IsVisibleDepotFreeDays = true;
                    if (CategoryImpExp == "EXPRT")
                    {
                        IsVisibleEmptyDepot = false;
                        IsVisibleDepotFreeDays = false;
                    }
                    string lstrgreenicon = dbLayer.getCaption("imgstatusgreenicon", objCMS);
                    if (lstTracking.ToArray()[0].cd_fmtexpectedtimeofarrival.ToString().Length > 0)
                    {
                        ImgStatusIconOnVessel = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].cd_fmprepickissuedtime.ToString().Length > 0)
                    {
                        ImgStatusIconPrePickUp = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].cd_fmtmovetoinspectiontime.ToString().Length > 0)
                    {
                        ImgStatusIconUnderInspec = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].cd_fmtinspectioncomplete.ToString().Length > 0)
                    {
                        ImgStatusIconInsComp = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].cd_fmreadyfordeliverytime.ToString().Length > 0)
                    {
                        ImgStatusIconRFD = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].cd_fmgatedouttime.ToString().Length > 0)
                    {
                        ImgStatusIconGO = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_waitingforportcharges.ToString().Length > 0)
                    {
                        ImgStatusIconRFD2 = lstrgreenicon;
                    }
                    //12-01-2023-Export
                    if (lstTracking.ToArray()[0].timeline_expunitintime.ToString().Length > 0)
                    {
                        Imgexpgatedin = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_expbookforinsptime.ToString().Length > 0)
                    {
                        Imgexpcustomsinspection = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_expexcesscargoholdtime.ToString().Length > 0)
                    {
                        Imgexpexcesscargo = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_expdetentionholdtime.ToString().Length > 0)
                    {
                        Imgexpwaitshipline = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_expcoldstorepayholdtime.ToString().Length > 0)
                    {
                        Imgexpwaitcoldstorepayment = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_expfinholdtime.ToString().Length > 0)
                    {
                        Imgexpwaitforrsgtpayment = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_expreadytoloadtime.ToString().Length > 0)
                    {
                        Imgexpreadytoload = lstrgreenicon;
                    }
                    if (lstTracking.ToArray()[0].timeline_expunitloadtime.ToString().Length > 0)
                    {
                        Imgexploadedonvessel = lstrgreenicon;
                    }
                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                   App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Navigate gotoNotify Page 
        /// </summary>
        /// <returns></returns>
        private async Task gotonotify()
        {
            try
            {
                await Task.Delay(1000);
                string lstrNotifi = dbLayer.getCaption("strNotification", objCMSMSG);
                string lstrOK = dbLayer.getCaption("strOk", objCMSMSG);
                string lstrCancel = dbLayer.getCaption("strcancel", objCMSMSG);
                string lstrMobNo = dbLayer.getCaption("strEnteryourMobileNumber", objCMSMSG);
                string result = await Application.Current.MainPage?.DisplayPromptAsync(lstrNotifi, lstrMobNo, lstrOK, lstrCancel, keyboard: Keyboard.Numeric, maxLength: 10);
                if (strNT_UNITGKEY == null) strNT_UNITGKEY = "";
                string fstrNT_UNITGKEY = strNT_UNITGKEY;
                if (result != null)
                {
                    if ((result == "") || (result.Length < 10))
                    {
                        string lstrMSG = dbLayer.getCaption("strProvidValidMobileNo", objCMSMSG);

                       App.Current.MainPage?.DisplayToastAsync(lstrMSG, 3000);
                    }
                    else
                    {
                        string lstrResponse = objWeb.postWebApi("TrackingNotify", gblRegisteration.Notify(lstrCurrentStatus, result, fstrNT_UNITGKEY));
                        
                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                        if (lstrResponse == "True")
                        {
                            await App.Current.MainPage?.Navigation.PushAsync(new BasicTrackingResultMsg());
                        }
                    }

                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Navigate MainPage Page 
        /// </summary>
        /// <returns></returns>
        private async Task Button_Clicked()
        {
            await Task.Delay(1000);
            Application.Current.MainPage?.Navigation.PopToRootAsync();
        }
    }
}
