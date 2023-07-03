using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class ContainerdetailViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();

        private string strLanguage = App.gblLanguage;
        private List<ContainerDtcls.clsContainertimeline> lstTimeLine = new List<ContainerDtcls.clsContainertimeline>();
        private List<ContainerDtcls.clsContainerDetails> lstContainerDtls = new List<ContainerDtcls.clsContainerDetails>();
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        WebApiMethod objWeb = new WebApiMethod();
        public string gblBayanNo { get; set; }
        public string gblBlNo { get; set; }
        public string gblContainerNo { get; set; }
        string strServerSlowMsg = "";
        [Obsolete]
        public System.Windows.Input.ICommand MyPdftap => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
        //Assign Property Two way Binding
        //Two way Binding Variable
        public Command ContainerPDFprint { get; set; }
        public Command ContainerPDFMail { get; set; }
        public Command gotosurvey { get; set; }
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
        //accountSettingsActivityIndicator purpose of using indicator varaiable
        bool accountSettingsActivityIndicator = false;
        public bool AccountSettingsActivityIndicator
        {
            get { return accountSettingsActivityIndicator; }
            set
            {
                accountSettingsActivityIndicator = value;

                OnPropertyChanged();
                RaisePropertyChange("AccountSettingsActivityIndicator");
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
        //To Handle Indicator
        private bool stackContainerDetails = true;
        public bool StackContainerDetails
        {
            get { return stackContainerDetails; }
            set
            {
                stackContainerDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("StackContainerDetails");
            }
        }
        //LblContainerDetails purpose of using Label varaiable
        private string lblContainerDetails = "";
        public string LblContainerDetails
        {
            get { return lblContainerDetails; }
            set
            {
                lblContainerDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerDetails");
            }
        }
        //LblContainerNo purpose of using Label varaiable
        private string lblContainerNo = "";
        public string LblContainerNo
        {
            get { return lblContainerNo; }
            set
            {
                lblContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerNo");
            }
        }
        //StrContainerNo purpose of using Label varaiable
        private string strContainerNo = "";
        public string StrContainerNo
        {
            get { return strContainerNo; }
            set
            {
                strContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("StrContainerNo");
            }
        }
        //ImgVisit purpose of using Label varaiable
        private string imgVisit = "";
        public string ImgVisit
        {
            get { return imgVisit; }
            set
            {
                imgVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgVisit");
            }
        }
        //LblVesselVisitId purpose of using Label varaiable
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
        //StrVesselVisitId purpose of using Label varaiable
        private string strVesselVisitId = "";
        public string StrVesselVisitId
        {
            get { return strVesselVisitId; }
            set
            {
                strVesselVisitId = value;
                OnPropertyChanged();
                RaisePropertyChange("StrVesselVisitId");
            }
        }
        //ImgShippingLine3 purpose of using Image varaiable
        private string imgShippingLine3 = "";
        public string ImgShippingLine3
        {
            get { return imgShippingLine3; }
            set
            {
                imgShippingLine3 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgShippingLine3");
            }
        }
        //LblVeeselName purpose of using Label varaiable
        private string lblVeeselName = "";
        public string LblVeeselName
        {
            get { return lblVeeselName; }
            set
            {
                lblVeeselName = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVeeselName");
            }
        }
        //ImgVoyage purpose of using Image varaiable
        private string imgVoyage = "";
        public string ImgVoyage
        {
            get { return imgVoyage; }
            set
            {
                imgVoyage = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgVoyage");
            }
        }
        //LblVoyage purpose of using Label varaiable
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
        //StrVoyage purpose of using Label varaiable
        private string strVoyage = "";
        public string StrVoyage
        {
            get { return strVoyage; }
            set
            {
                strVoyage = value;
                OnPropertyChanged();
                RaisePropertyChange("StrVoyage");
            }
        }
        //ImgBLIcon purpose of using Image varaiable
        private string imgBLIcon = "";
        public string ImgBLIcon
        {
            get { return imgBLIcon; }
            set
            {
                imgBLIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBLIcon");
            }
        }
        //LblBLNumber purpose of using Label varaiable
        private string lblBLNumber = "";
        public string LblBLNumber
        {
            get { return lblBLNumber; }
            set
            {
                lblBLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBLNumber");
            }
        }
        //StrBLNumber purpose of using Label varaiable
        private string strBLNumber = "";
        public string StrBLNumber
        {
            get { return strBLNumber; }
            set
            {
                strBLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("StrBLNumber");
            }
        }
        //ImgBayan purpose of using Image varaiable
        private string imgBayan = "";
        public string ImgBayan
        {
            get { return imgBayan; }
            set
            {
                imgBayan = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBayan");
            }
        }
        //LblCustomerBayanNUmber purpose of using Label varaiable
        private string lblCustomerBayanNUmber = "";
        public string LblCustomerBayanNUmber
        {
            get { return lblCustomerBayanNUmber; }
            set
            {
                lblCustomerBayanNUmber = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCustomerBayanNUmber");
            }
        }
        //StrCustomerBayanNo purpose of using Label varaiable
        private string strCustomerBayanNo = "";
        public string StrCustomerBayanNo
        {
            get { return strCustomerBayanNo; }
            set
            {
                strCustomerBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("StrCustomerBayanNo");
            }
        }
        //ImgShippingLine purpose of using Image varaiable
        private string imgShippingLine = "";
        public string ImgShippingLine
        {
            get { return imgShippingLine; }
            set
            {
                imgShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgShippingLine");
            }
        }
        //LblShippingLineId2 purpose of using Label varaiable
        private string lblShippingLineId2 = "";
        public string LblShippingLineId2
        {
            get { return lblShippingLineId2; }
            set
            {
                lblShippingLineId2 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShippingLineId2");
            }
        }
        //ImgMaersk purpose of using Image varaiable
        private string imgMaersk = "";
        public string ImgMaersk
        {
            get { return imgMaersk; }
            set
            {
                imgMaersk = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgMaersk");
            }
        }
        //StrShippingLineId2 purpose of using Label varaiable
        private string strShippingLineId2 = "";
        public string StrShippingLineId2
        {
            get { return strShippingLineId2; }
            set
            {
                strShippingLineId2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StrShippingLineId2");
            }
        }
        //ImgConsignee purpose of using Label varaiable
        private string imgConsignee = "";
        public string ImgConsignee
        {
            get { return imgConsignee; }
            set
            {
                imgConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgConsignee");
            }
        }
        //LblConsignee purpose of using Label varaiable
        private string lblConsignee = "";
        public string LblConsignee
        {
            get { return lblConsignee; }
            set
            {
                lblConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("LblConsignee");
            }
        }
        //StrConsignee purpose of using Label varaiable
        private string strConsignee = "";
        public string StrConsignee
        {
            get { return strConsignee; }
            set
            {
                strConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("StrConsignee");
            }
        }
        //ImgShipper purpose of using Image varaiable
        private string imgShipper = "";
        public string ImgShipper
        {
            get { return imgShipper; }
            set
            {
                imgShipper = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgShipper");
            }
        }
        //LblShipper purpose of using Label varaiable
        private string lblShipper = "";
        public string LblShipper
        {
            get { return lblShipper; }
            set
            {
                lblShipper = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShipper");
            }
        }
        //StrShipper purpose of using Label varaiable
        private string strShipper = "";
        public string StrShipper
        {
            get { return strShipper; }
            set
            {
                strShipper = value;
                OnPropertyChanged();
                RaisePropertyChange("StrShipper");
            }
        }
        //ImgCustomagent purpose of using Image varaiable
        private string imgCustomagent = "";
        public string ImgCustomagent
        {
            get { return imgCustomagent; }
            set
            {
                imgCustomagent = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCustomagent");
            }
        }
        //LblCustomBrokerAgent purpose of using Label varaiable
        private string lblCustomBrokerAgent = "";
        public string LblCustomBrokerAgent
        {
            get { return lblCustomBrokerAgent; }
            set
            {
                lblCustomBrokerAgent = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCustomBrokerAgent");
            }
        }
        //StrCustomBrokerAgent purpose of using Label varaiable
        private string strCustomBrokerAgent = "";
        public string StrCustomBrokerAgent
        {
            get { return strCustomBrokerAgent; }
            set
            {
                strCustomBrokerAgent = value;
                OnPropertyChanged();
                RaisePropertyChange("StrCustomBrokerAgent");
            }
        }
        //ImgBLCat purpose of using Image varaiable
        private string imgBLCat = "";
        public string ImgBLCat
        {
            get { return imgBLCat; }
            set
            {
                imgBLCat = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBLCat");
            }
        }
        //LblCategory purpose of using Label varaiable
        private string lblCategory = "";
        public string LblCategory
        {
            get { return lblCategory; }
            set
            {
                lblCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCategory");
            }
        }
        //StrCategory purpose of using Label varaiable
        private string strCategory = "";
        public string StrCategory
        {
            get { return strCategory; }
            set
            {
                strCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("StrCategory");
            }
        }
        //ImgFreight purpose of using Image varaiable
        private string imgFreight = "";
        public string ImgFreight
        {
            get { return imgFreight; }
            set
            {
                imgFreight = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgFreight");
            }
        }
        //LblFreightKind purpose of using Label varaiable
        private string lblFreightKind = "";
        public string LblFreightKind
        {
            get { return lblFreightKind; }
            set
            {
                lblFreightKind = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFreightKind");
            }
        }
        //StrFreightKind purpose of using Label varaiable
        private string strFreightKind = "";
        public string StrFreightKind
        {
            get { return strFreightKind; }
            set
            {
                strFreightKind = value;
                OnPropertyChanged();
                RaisePropertyChange("StrFreightKind");
            }
        }
        //ImgUnitSize purpose of using Image varaiable
        private string imgUnitSize = "";
        public string ImgUnitSize
        {
            get { return imgUnitSize; }
            set
            {
                imgUnitSize = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgUnitSize");
            }
        }
        //LblSize purpose of using Label varaiable
        private string lblSize = "";
        public string LblSize
        {
            get { return lblSize; }
            set
            {
                lblSize = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSize");
            }
        }
        //StrSize purpose of using Label varaiable
        private string strSize = "";
        public string StrSize
        {
            get { return strSize; }
            set
            {
                strSize = value;
                OnPropertyChanged();
                RaisePropertyChange("StrSize");
            }
        }
        //ImgWeight purpose of using Image varaiable
        private string imgWeight = "";
        public string ImgWeight
        {
            get { return imgWeight; }
            set
            {
                imgWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgWeight");
            }
        }
        //LblWeight purpose of using Label varaiable
        private string lblWeight = "";
        public string LblWeight
        {
            get { return lblWeight; }
            set
            {
                lblWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWeight");
            }
        }
        //StrWeight purpose of using Label varaiable
        private string strWeight = "";
        public string StrWeight
        {
            get { return strWeight; }
            set
            {
                strWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("StrWeight");
            }
        }
        //ImgPolIcon purpose of using Image varaiable
        private string imgPolIcon = "";
        public string ImgPolIcon
        {
            get { return imgPolIcon; }
            set
            {
                imgPolIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgPolIcon");
            }
        }
        //LblPortOfLoading purpose of using Label varaiable
        private string lblPortOfLoading = "";
        public string LblPortOfLoading
        {
            get { return lblPortOfLoading; }
            set
            {
                lblPortOfLoading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPortOfLoading");
            }
        }
        //StrPortOfLoading purpose of using Label varaiable
        private string strPortOfLoading = "";
        public string StrPortOfLoading
        {
            get { return strPortOfLoading; }
            set
            {
                strPortOfLoading = value;
                OnPropertyChanged();
                RaisePropertyChange("StrPortOfLoading");
            }
        }
        //ImgPodIcon purpose of using Image varaiable
        private string imgPodIcon = "";
        public string ImgPodIcon
        {
            get { return imgPodIcon; }
            set
            {
                imgPodIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgPodIcon");
            }
        }
        //LblPortOfDischarge purpose of using Label varaiable
        private string lblPortOfDischarge = "";
        public string LblPortOfDischarge
        {
            get { return lblPortOfDischarge; }
            set
            {
                lblPortOfDischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPortOfDischarge");
            }
        }
        //StrPortOfDischarge purpose of using Label varaiable
        private string strPortOfDischarge = "";
        public string StrPortOfDischarge
        {
            get { return strPortOfDischarge; }
            set
            {
                strPortOfDischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("StrPortOfDischarge");
            }
        }
        //ImgInspectionIcon purpose of using Image varaiable
        private string imgInspectionIcon = "";
        public string ImgInspectionIcon
        {
            get { return imgInspectionIcon; }
            set
            {
                imgInspectionIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgInspectionIcon");
            }
        }
        //LblInspectionStatus purpose of using Label varaiable
        private string lblInspectionStatus = "";
        public string LblInspectionStatus
        {
            get { return lblInspectionStatus; }
            set
            {
                lblInspectionStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInspectionStatus");
            }
        }
        //StrInspectionStatus purpose of using Label varaiable
        private string strInspectionStatus = "";
        public string StrInspectionStatus
        {
            get { return strInspectionStatus; }
            set
            {
                strInspectionStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("StrInspectionStatus");
            }
        }
        //ImgHoldIcon purpose of using Image varaiable
        private string imgHoldIcon = "";
        public string ImgHoldIcon
        {
            get { return imgHoldIcon; }
            set
            {
                imgHoldIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgHoldIcon");
            }
        }
        //LblHoldPermission purpose of using Label varaiable
        private string lblHoldPermission = "";
        public string LblHoldPermission
        {
            get { return lblHoldPermission; }
            set
            {
                lblHoldPermission = value;
                OnPropertyChanged();
                RaisePropertyChange("LblHoldPermission");
            }
        }
        //StrHoldPermission purpose of using Label varaiable
        private string strHoldPermission = "";
        public string StrHoldPermission
        {
            get { return strHoldPermission; }
            set
            {
                strHoldPermission = value;
                OnPropertyChanged();
                RaisePropertyChange("StrHoldPermission");
            }
        }
        //ImgArrivedIcon purpose of using Image varaiable
        private string imgArrivedIcon = "";
        public string ImgArrivedIcon
        {
            get { return imgArrivedIcon; }
            set
            {
                imgArrivedIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgArrivedIcon");
            }
        }
        //LblTransitStatus purpose of using Label varaiable
        private string lblTransitStatus = "";
        public string LblTransitStatus
        {
            get { return lblTransitStatus; }
            set
            {
                lblTransitStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTransitStatus");
            }
        }
        //StrTransitStatus purpose of using Label varaiable
        private string strTransitStatus = "";
        public string StrTransitStatus
        {
            get { return strTransitStatus; }
            set
            {
                strTransitStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("StrTransitStatus");
            }
        }
        //ImgGauge purpose of using Image varaiable
        private string imgGauge = "";
        public string ImgGauge
        {
            get { return imgGauge; }
            set
            {
                imgGauge = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgGauge");
            }
        }
        //LblOoGDetails purpose of using Label varaiable
        private string lblOoGDetails = "";
        public string LblOoGDetails
        {
            get { return lblOoGDetails; }
            set
            {
                lblOoGDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOoGDetails");
            }
        }
        //StrOoGDetails purpose of using Label varaiable
        private string strOoGDetails = "";
        public string StrOoGDetails
        {
            get { return strOoGDetails; }
            set
            {
                strOoGDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("StrOoGDetails");
            }
        }
        //ImgTemperature purpose of using Image varaiable
        private string imgTemperature = "";
        public string ImgTemperature
        {
            get { return imgTemperature; }
            set
            {
                imgTemperature = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTemperature");
            }
        }
        //LblReeferDetails purpose of using Label varaiable
        private string lblReeferDetails = "";
        public string LblReeferDetails
        {
            get { return lblReeferDetails; }
            set
            {
                lblReeferDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReeferDetails");
            }
        }
        //StrReeferDetails purpose of using Label varaiable
        private string strReeferDetails = "";
        public string StrReeferDetails
        {
            get { return strReeferDetails; }
            set
            {
                strReeferDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("StrReeferDetails");
            }
        }
        //ImgDangerred purpose of using Image varaiable
        private string imgDangerred = "";
        public string ImgDangerred
        {
            get { return imgDangerred; }
            set
            {
                imgDangerred = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDangerred");
            }
        }
        //LblDgDetails purpose of using Label varaiable
        private string lblDgDetails = "";
        public string LblDgDetails
        {
            get { return lblDgDetails; }
            set
            {
                lblDgDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDgDetails");
            }
        }
        //StrDgDetails purpose of using Label varaiable
        private string strDgDetails = "";
        public string StrDgDetails
        {
            get { return strDgDetails; }
            set
            {
                strDgDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("StrDgDetails");
            }
        }
        //ImgDamageDetail purpose of using Image varaiable
        private string imgDamageDetail = "";
        public string ImgDamageDetail
        {
            get { return imgDamageDetail; }
            set
            {
                imgDamageDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDamageDetail");
            }
        }
        //LblDamageDetails purpose of using Label varaiable
        private string lblDamageDetails = "";
        public string LblDamageDetails
        {
            get { return lblDamageDetails; }
            set
            {
                lblDamageDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDamageDetails");
            }
        }
        //StrDamageDetails purpose of using Label varaiable
        private string strDamageDetails = "";
        public string StrDamageDetails
        {
            get { return strDamageDetails; }
            set
            {
                strDamageDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("StrDamageDetails");
            }
        }
        //imgDamageDetail2 purpose of using Image varaiable
        private string imgDamageDetail2 = "";
        public string ImgDamageDetail2
        {
            get { return imgDamageDetail2; }
            set
            {
                imgDamageDetail2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDamageDetail2");
            }
        }
        //lblEmptyDeport purpose of using Label varaiable
        private string lblEmptyDeport = "";
        public string LblEmptyDeport
        {
            get { return lblEmptyDeport; }
            set
            {
                lblEmptyDeport = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmptyDeport");
            }
        }
        //StrEmptyDeport purpose of using Label varaiable
        private string strEmptyDeport = "";
        public string StrEmptyDeport
        {
            get { return strEmptyDeport; }
            set
            {
                strEmptyDeport = value;
                OnPropertyChanged();
                RaisePropertyChange("StrEmptyDeport");
            }
        }
        //ImgDamageDetail3 purpose of using Image varaiable
        private string imgDamageDetail3 = "";
        public string ImgDamageDetail3
        {
            get { return imgDamageDetail3; }
            set
            {
                imgDamageDetail3 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDamageDetail3");
            }
        }
        //Lblfreedays purpose of using Label varaiable
        private string lblfreedays = "";
        public string Lblfreedays
        {
            get { return lblfreedays; }
            set
            {
                lblfreedays = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblfreedays");
            }
        }
        //Strfreedays purpose of using Label varaiable
        private string strfreedays = "";
        public string Strfreedays
        {
            get { return strfreedays; }
            set
            {
                strfreedays = value;
                OnPropertyChanged();
                RaisePropertyChange("Strfreedays");
            }
        }
        //LblSNo purpose of using Label varaiable
        private string lblSNo = "";
        public string LblSNo
        {
            get { return lblSNo; }
            set
            {
                lblSNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSNo");
            }
        }
        //LblPdfFile purpose of using Label varaiable
        private string lblPdfFile = "";
        public string LblPdfFile
        {
            get { return lblPdfFile; }
            set
            {
                lblPdfFile = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPdfFile");
            }
        }
        //BtnAccept purpose of using Button varaiable
        private string btnAccept = "";
        public string BtnAccept
        {
            get { return btnAccept; }
            set
            {
                btnAccept = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnAccept");
            }
        }
        //BtnReject purpose of using Button varaiable
        private string btnReject = "";
        public string BtnReject
        {
            get { return btnReject; }
            set
            {
                btnReject = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnReject");
            }
        }
        //LblStatus purpose of using Label varaiable
        private string lblStatus = "";
        public string LblStatus
        {
            get { return lblStatus; }
            set
            {
                lblStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("LblStatus");
            }
        }
        //ImgArrivalGreenIcon1 purpose of using Image varaiable
        private string imgArrivalGreenIcon1 = "";
        public string ImgArrivalGreenIcon1
        {
            get { return imgArrivalGreenIcon1; }
            set
            {
                imgArrivalGreenIcon1 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgArrivalGreenIcon1");
            }
        }
        //LblArrival purpose of using Label varaiable
        private string lblArrival = "";
        public string LblArrival
        {
            get { return lblArrival; }
            set
            {
                lblArrival = value;
                OnPropertyChanged();
                RaisePropertyChange("LblArrival");
            }
        }
        //LblValArrival purpose of using Label varaiable
        private string lblValArrival = "";
        public string LblValArrival
        {
            get { return lblValArrival; }
            set
            {
                lblValArrival = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValArrival");
            }
        }
        //ImgDischargeGreenIcon2 purpose of using Image varaiable
        private string imgDischargeGreenIcon2 = "";
        public string ImgDischargeGreenIcon2
        {
            get { return imgDischargeGreenIcon2; }
            set
            {
                imgDischargeGreenIcon2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDischargeGreenIcon2");
            }
        }
        //LblDischarge purpose of using Label varaiable
        private string lblDischarge = "";
        public string LblDischarge
        {
            get { return lblDischarge; }
            set
            {
                lblDischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDischarge");
            }
        }
        //LblValDischarge purpose of using Label varaiable
        private string lblValDischarge = "";
        public string LblValDischarge
        {
            get { return lblValDischarge; }
            set
            {
                lblValDischarge = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValDischarge");
            }
        }
        //ImgUnderGreenIcon3 purpose of using Image varaiable
        private string imgUnderGreenIcon3 = "";
        public string ImgUnderGreenIcon3
        {
            get { return imgUnderGreenIcon3; }
            set
            {
                imgUnderGreenIcon3 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgUnderGreenIcon3");
            }
        }
        //LblUnderInspection purpose of using Label varaiable
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
        //LblValUnderInsp purpose of using Label varaiable
        private string lblValUnderInsp = "";
        public string LblValUnderInsp
        {
            get { return lblValUnderInsp; }
            set
            {
                lblValUnderInsp = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValUnderInsp");
            }
        }
        //Cd_containerdocument purpose of using Label varaiable
        private string cd_containerdocument = "";
        public string Cd_containerdocument
        {
            get { return cd_containerdocument; }
            set
            {
                cd_containerdocument = value;
                OnPropertyChanged();
                RaisePropertyChange("Cd_containerdocument");
            }
        }
        //ImgInspectioGreenIcon4 purpose of using Image varaiable
        private string imgInspectioGreenIcon4 = "";
        public string ImgInspectioGreenIcon4
        {
            get { return imgInspectioGreenIcon4; }
            set
            {
                imgInspectioGreenIcon4 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgInspectioGreenIcon4");
            }
        }
        //LblInspectionCompleted purpose of using Label varaiable
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
        //LblValInsComp purpose of using Label varaiable
        private string lblValInsComp = "";
        public string LblValInsComp
        {
            get { return lblValInsComp; }
            set
            {
                lblValInsComp = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValInsComp");
            }
        }
        //ImgportchargeGreenIcon5 purpose of using Image varaiable
        private string imgportchargeGreenIcon5 = "";
        public string ImgportchargeGreenIcon5
        {
            get { return imgportchargeGreenIcon5; }
            set
            {
                imgportchargeGreenIcon5 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgportchargeGreenIcon5");
            }
        }
        //Lblportcharge purpose of using Label varaiable
        private string lblportcharge = "";
        public string Lblportcharge
        {
            get { return lblportcharge; }
            set
            {
                lblportcharge = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblportcharge");
            }
        }
        //LblValPortCharges purpose of using Label varaiable
        private string lblValPortCharges = "";
        public string LblValPortCharges
        {
            get { return lblValPortCharges; }
            set
            {
                lblValPortCharges = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValPortCharges");
            }
        }
        //ImgReadyGreenIcon6 purpose of using Image varaiable
        private string imgReadyGreenIcon6 = "";
        public string ImgReadyGreenIcon6
        {
            get { return imgReadyGreenIcon6; }
            set
            {
                imgReadyGreenIcon6 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgReadyGreenIcon6");
            }
        }
        //LblReadyForDelivery purpose of using Label varaiable
        private string lblReadyForDelivery = "";
        public string LblReadyForDelivery
        {
            get { return lblReadyForDelivery; }
            set
            {
                lblReadyForDelivery = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReadyForDelivery");
            }
        }
        //LblValRFD purpose of using Label varaiable
        private string lblValRFD = "";
        public string LblValRFD
        {
            get { return lblValRFD; }
            set
            {
                lblValRFD = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValRFD");
            }
        }
        //ImgprepickGrayIcon7 purpose of using Image varaiable
        private string imgprepickGrayIcon7 = "";
        public string ImgprepickGrayIcon7
        {
            get { return imgprepickGrayIcon7; }
            set
            {
                imgprepickGrayIcon7 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgprepickGrayIcon7");
            }
        }
        //LblPrePickUpissued purpose of using Label varaiable
        private string lblPrePickUpissued = "";
        public string LblPrePickUpissued
        {
            get { return lblPrePickUpissued; }
            set
            {
                lblPrePickUpissued = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPrePickUpissued");
            }
        }
        //LblValPrePickUpissued purpose of using Label varaiable
        private string lblValPrePickUpissued = "";
        public string LblValPrePickUpissued
        {
            get { return lblValPrePickUpissued; }
            set
            {
                lblValPrePickUpissued = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValPrePickUpissued");
            }
        }
        //ImgGatedGreenIcon8 purpose of using Image varaiable
        private string imgGatedGreenIcon8 = "";
        public string ImgGatedGreenIcon8
        {
            get { return imgGatedGreenIcon8; }
            set
            {
                imgGatedGreenIcon8 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgGatedGreenIcon8");
            }
        }
        //LblGatedOut purpose of using Label varaiable
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
        //LblValGatedOut purpose of using Label varaiable
        private string lblValGatedOut = "";
        public string LblValGatedOut
        {
            get { return lblValGatedOut; }
            set
            {
                lblValGatedOut = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValGatedOut");
            }
        }
        //Lblsurvey purpose of using Label varaiable
        private string lblsurvey = "";
        public string Lblsurvey
        {
            get { return lblsurvey; }
            set
            {
                lblsurvey = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblsurvey");
            }
        }
        //LblDearConsignee purpose of using Label varaiable
        private string lblDearConsignee = "";
        public string LblDearConsignee
        {
            get { return lblDearConsignee; }
            set
            {
                lblDearConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearConsignee");
            }
        }
        //LblMessage purpose of using Label varaiable
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
        //StrVeeselName purpose of using Label varaiable
        private string strVeeselName = "";
        public string StrVeeselName
        {
            get { return strVeeselName; }
            set
            {
                strVeeselName = value;
                OnPropertyChanged();
                RaisePropertyChange("StrVeeselName");
            }
        }
        //LblReceivedGatedIn purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblReceivedGatedIn = "";
        public string LblReceivedGatedIn
        {
            get { return lblReceivedGatedIn; }
            set
            {
                lblReceivedGatedIn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReceivedGatedIn");
            }
        }
        //LblUnderCustomsInspection purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblUnderCustomsInspection = "";
        public string LblUnderCustomsInspection
        {
            get { return lblUnderCustomsInspection; }
            set
            {
                lblUnderCustomsInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("LblUnderCustomsInspection");
            }
        }
        //LblCollectingExcessCargo purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblCollectingExcessCargo = "";
        public string LblCollectingExcessCargo
        {
            get { return lblCollectingExcessCargo; }
            set
            {
                lblCollectingExcessCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCollectingExcessCargo");
            }
        }
        //LblWaitshiplineRelease purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblWaitshiplineRelease = "";
        public string LblWaitshiplineRelease
        {
            get { return lblWaitshiplineRelease; }
            set
            {
                lblWaitshiplineRelease = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWaitshiplineRelease");
            }
        }
        //LblWaitcoldstorepayment purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblWaitcoldstorepayment = "";
        public string LblWaitcoldstorepayment
        {
            get { return lblWaitcoldstorepayment; }
            set
            {
                lblWaitcoldstorepayment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWaitcoldstorepayment");
            }
        }
        //LblWaitforRSGTPay purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblWaitforRSGTPay = "";
        public string LblWaitforRSGTPay
        {
            get { return lblWaitforRSGTPay; }
            set
            {
                lblWaitforRSGTPay = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWaitforRSGTPay");
            }
        }
        //LblReadytoLoad purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblReadytoLoad = "";
        public string LblReadytoLoad
        {
            get { return lblReadytoLoad; }
            set
            {
                lblReadytoLoad = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReadytoLoad");
            }
        }
        //LblLoadedonvessel purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblLoadedonvessel = "";
        public string LblLoadedonvessel
        {
            get { return lblLoadedonvessel; }
            set
            {
                lblLoadedonvessel = value;
                OnPropertyChanged();
                RaisePropertyChange("LblLoadedonvessel");
            }
        }
        //LblGatedIn purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblGatedIn = "";
        public string LblGatedIn
        {
            get { return lblGatedIn; }
            set
            {
                lblGatedIn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGatedIn");
            }
        }
        //LblValGatedIn purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValGatedIn = "";
        public string LblValGatedIn
        {
            get { return lblValGatedIn; }
            set
            {
                lblValGatedIn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValGatedIn");
            }
        }
        //LblCustomsInspection purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblCustomsInspection = "";
        public string LblCustomsInspection
        {
            get { return lblCustomsInspection; }
            set
            {
                lblCustomsInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCustomsInspection");
            }
        }
        //LblValCustomsInspection purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValCustomsInspection = "";
        public string LblValCustomsInspection
        {
            get { return lblValCustomsInspection; }
            set
            {
                lblValCustomsInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValCustomsInspection");
            }
        }
        //LblWaitShipline purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblWaitShipline = "";
        public string LblWaitShipline
        {
            get { return lblWaitShipline; }
            set
            {
                lblWaitShipline = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWaitShipline");
            }
        }
        //LblValWaitShipline purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValWaitShipline = "";
        public string LblValWaitShipline
        {
            get { return lblValWaitShipline; }
            set
            {
                lblValWaitShipline = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValWaitShipline");
            }
        }
        //LblWaitColdstorepayment purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblWaitColdstorepayment = "";
        public string LblWaitColdstorepayment
        {
            get { return lblWaitColdstorepayment; }
            set
            {
                lblWaitColdstorepayment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWaitColdstorepayment");
            }
        }
        //LblValWaitColdstorepayment purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValWaitColdstorepayment = "";
        public string LblValWaitColdstorepayment
        {
            get { return lblValWaitColdstorepayment; }
            set
            {
                lblValWaitColdstorepayment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValWaitColdstorepayment");
            }
        }
        //LblWaitforRSGTPayment purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblWaitforRSGTPayment = "";
        public string LblWaitforRSGTPayment
        {
            get { return lblWaitforRSGTPayment; }
            set
            {
                lblWaitforRSGTPayment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWaitforRSGTPayment");
            }
        }
        //LblValWaitforRSGTPayment purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValWaitforRSGTPayment = "";
        public string LblValWaitforRSGTPayment
        {
            get { return lblValWaitforRSGTPayment; }
            set
            {
                lblValWaitforRSGTPayment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValWaitforRSGTPayment");
            }
        }
        //LblReadytoload purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblReadytoload = "";
        public string LblReadytoload
        {
            get { return lblReadytoload; }
            set
            {
                lblReadytoload = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReadytoload");
            }
        }
        //LblValReadytoload purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValReadytoload = "";
        public string LblValReadytoload
        {
            get { return lblValReadytoload; }
            set
            {
                lblValReadytoload = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValReadytoload");
            }
        }
        //LblLoadedonVessel purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblLoadedonVessel = "";
        public string LblLoadedonVessel
        {
            get { return lblLoadedonVessel; }
            set
            {
                lblLoadedonVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("LblLoadedonVessel");
            }
        }
        //LblValLoadedonVessel purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValLoadedonVessel = "";
        public string LblValLoadedonVessel
        {
            get { return lblValLoadedonVessel; }
            set
            {
                lblValLoadedonVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValLoadedonVessel");
            }
        }
        //LblColExcessCargo purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblColExcessCargo = "";
        public string LblColExcessCargo
        {
            get { return lblColExcessCargo; }
            set
            {
                lblColExcessCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblColExcessCargo");
            }
        }
        //LblValColExcessCargo purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblValColExcessCargo = "";
        public string LblValColExcessCargo
        {
            get { return lblValColExcessCargo; }
            set
            {
                lblValColExcessCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValColExcessCargo");
            }
        }
        //ImgexpGatedIn purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //ImgexpCustomsInspection purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //ImgexpExcessCargo purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //ImgexpWaitShipline purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //ImgexpWaitcoldstorepayment purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //ImgexpWaitforRSGTPayment purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //ImgexpReadytoLoad purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //ImgexpLoadedonvessel purpose of using Image varaiable
        //12-01-2023-Sanduru
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
        //isVisibleExport purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleExport = false;
        public bool isVisibleExport
        {
            get { return isvisibleExport; }
            set
            {
                isvisibleExport = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleExport");
            }
        }
        //isVisibleImport purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleImport = false;
        public bool isVisibleImport
        {
            get { return isvisibleImport; }
            set
            {
                isvisibleImport = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleImport");
            }
        }
        //IsvisibleEmptyDept purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleEmptyDept = false;
        public bool IsvisibleEmptyDept
        {
            get { return isvisibleEmptyDept; }
            set
            {
                isvisibleEmptyDept = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleEmptyDept");
            }
        }
        //IsvisibleFreeDays purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleFreeDays = false;
        public bool IsvisibleFreeDays
        {
            get { return isvisibleFreeDays; }
            set
            {
                isvisibleFreeDays = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleFreeDays");
            }
        }
        //LblCustomsInspectionMsg purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblCustomsInspectionMsg = "";
        public string LblCustomsInspectionMsg
        {
            get { return lblCustomsInspectionMsg; }
            set
            {
                lblCustomsInspectionMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCustomsInspectionMsg");
            }
        }
        //LblLoadedonvesselMsg purpose of using Label varaiable
        //12-01-2023-Sanduru
        private string lblLoadedonvesselMsg = "";
        public string LblLoadedonvesselMsg
        {
            get { return lblLoadedonvesselMsg; }
            set
            {
                lblLoadedonvesselMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblLoadedonvesselMsg");
            }
        }
        //isVisibleValInspection purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleValInspection = false;
        public bool isVisibleValInspection
        {
            get { return isvisibleValInspection; }
            set
            {
                isvisibleValInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleValInspection");
            }
        }
        //isVisibleValLoadedVessel purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleValLoadedVessel = false;
        public bool isVisibleValLoadedVessel
        {
            get { return isvisibleValLoadedVessel; }
            set
            {
                isvisibleValLoadedVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleValLoadedVessel");
            }
        }
        //isVisibleInspection purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleInspection = false;
        public bool isVisibleInspection
        {
            get { return isvisibleInspection; }
            set
            {
                isvisibleInspection = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleInspection");
            }
        }
        //isVisibleLoadedVessel purpose of using Boolean varaiable
        //12-01-2023-Sanduru
        private bool isvisibleLoadedVessel = false;
        public bool isVisibleLoadedVessel
        {
            get { return isvisibleLoadedVessel; }
            set
            {
                isvisibleLoadedVessel = value;
                OnPropertyChanged();
                RaisePropertyChange("isVisibleLoadedVessel");
            }
        }
        //isBusy purpose of using indicator varaiable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                ContainerPDFprint.ChangeCanExecute();
                ContainerPDFMail.ChangeCanExecute();
                gotosurvey.ChangeCanExecute();

            }
        }

        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="fstrConatinerNo"></param>
        /// <param name="fstrBLNo"></param>
        /// <param name="fstrBayanNo"></param>
        public ContainerdetailViewModel(string fstrConatinerNo, string fstrBLNo, string fstrBayanNo)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ContainerdetailViewModel");
            strBLNumber = fstrBLNo;
            //Begin Command Button
            ContainerPDFprint = new Command(async () => await Container_PDF_Clicked(), () => !IsBusy);
            ContainerPDFMail = new Command(async () => await ContainerMail_PDF_Clicked(), () => !IsBusy);
            gotosurvey = new Command(async () => await gotosurveyform(), () => !IsBusy);
            //End Command Button
            //Begin-Call Caption Function
            Task.Run(() => assignCms()).Wait();
            Task.Run(() => ContainerDetailsSection(fstrConatinerNo, fstrBLNo, fstrBayanNo)).Wait();
            Task.Run(() => ContainerTimeLineData(fstrConatinerNo, fstrBLNo, fstrBayanNo)).Wait();
            // End - Caption Function
        }
        //End-ViewModel Constructor 

        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM024");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM024");

                    objCMSMsg = await dbLayer.LoadContent("RM026");
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
            try
            {
                

                string lstrGrayicon = dbLayer.getCaption("imgStatusGrayicon", objCMS);
                lblContainerDetails = dbLayer.getCaption("strContainerDetail", objCMS);
                lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
                imgVisit = dbLayer.getCaption("imgvisit", objCMS);
                lblVesselVisitId = dbLayer.getCaption("strVesselVisitID", objCMS);
                imgShippingLine3 = dbLayer.getCaption("imgshippingline", objCMS);
                lblVeeselName = dbLayer.getCaption("strVesselName", objCMS);
                imgVoyage = dbLayer.getCaption("imgvoyage", objCMS);
                lblVoyage = dbLayer.getCaption("strVoyage", objCMS);
                imgBLIcon = dbLayer.getCaption("imgBL", objCMS);
                lblBLNumber = dbLayer.getCaption("strBLNumber", objCMS);
                imgBayan = dbLayer.getCaption("imgBayan", objCMS);
                lblCustomerBayanNUmber = dbLayer.getCaption("strCustomsBayanNumber", objCMS);
                imgShippingLine = dbLayer.getCaption("imgshippingline", objCMS);
                lblShippingLineId2 = dbLayer.getCaption("strShippingLineID", objCMS);
                imgConsignee = dbLayer.getCaption("imgconsignee", objCMS);
                lblConsignee = dbLayer.getCaption("strConsignee", objCMS);
                imgShipper = dbLayer.getCaption("imgshipper", objCMS);
                lblShipper = dbLayer.getCaption("strShipper", objCMS);
                imgCustomagent = dbLayer.getCaption("imgcustomagent", objCMS);
                lblCustomBrokerAgent = dbLayer.getCaption("strCustombrokerAgent", objCMS);
                imgBLCat = dbLayer.getCaption("imgBlCat", objCMS);
                lblCategory = dbLayer.getCaption("strCategory", objCMS);
                imgFreight = dbLayer.getCaption("imgfreight", objCMS);
                lblFreightKind = dbLayer.getCaption("strFreightKind", objCMS);
                imgUnitSize = dbLayer.getCaption("imgunit", objCMS);
                lblSize = dbLayer.getCaption("strSize", objCMS);
                imgWeight = dbLayer.getCaption("imgweight", objCMS);
                lblWeight = dbLayer.getCaption("strWeight", objCMS);
                imgPolIcon = dbLayer.getCaption("imgpol", objCMS);
                lblPortOfLoading = dbLayer.getCaption("strPortOfLoading", objCMS);
                imgPodIcon = dbLayer.getCaption("imgpod", objCMS);
                lblPortOfDischarge = dbLayer.getCaption("strPortofDischarge", objCMS);
                imgInspectionIcon = dbLayer.getCaption("imginspection", objCMS);
                lblInspectionStatus = dbLayer.getCaption("strInspectionStatus", objCMS);
                imgHoldIcon = dbLayer.getCaption("imghold", objCMS);
                lblHoldPermission = dbLayer.getCaption("strHoldsPermission", objCMS);
                imgArrivedIcon = dbLayer.getCaption("imgarrived", objCMS);
                lblTransitStatus = dbLayer.getCaption("strTransitStatus", objCMS);
                imgGauge = dbLayer.getCaption("imggauge", objCMS);
                lblOoGDetails = dbLayer.getCaption("strOOGdetails", objCMS);
                imgTemperature = dbLayer.getCaption("imgtemperature", objCMS);
                lblReeferDetails = dbLayer.getCaption("strReeferdetails", objCMS);
                imgDangerred = dbLayer.getCaption("imgDangerred", objCMS);
                lblDgDetails = dbLayer.getCaption("strDGdetails", objCMS);
                imgDamageDetail = dbLayer.getCaption("imgDamage", objCMS);
                lblDamageDetails = dbLayer.getCaption("strDamagedetails", objCMS);
                lblEmptyDeport = dbLayer.getCaption("strEmptyDepot", objCMS);
                lblfreedays = dbLayer.getCaption("strFreeDays", objCMS);
                lblSNo = dbLayer.getCaption("strSno", objCMS);
                lblPdfFile = dbLayer.getCaption("strPDFfile", objCMS);
                lblMessage = dbLayer.getCaption("strAgreeGoodsCurrentCondition", objCMS);
                btnAccept = dbLayer.getCaption("strAccept", objCMS);
                btnReject = dbLayer.getCaption("strReject", objCMS);
                lblUnderInspection = dbLayer.getCaption("strUnderInspection", objCMS);
                lblInspectionCompleted = dbLayer.getCaption("strInspectionCompleted", objCMS);
                lblReadyForDelivery = dbLayer.getCaption("strReadyForDelivery", objCMS);
                lblPrePickUpissued = dbLayer.getCaption("strPrePickUpIssued", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                lblArrival = dbLayer.getCaption("strArrived", objCMS);
                lblportcharge = dbLayer.getCaption("strWaitingforPortCharges", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                lblsurvey = dbLayer.getCaption("strSurvey", objCMS);
                lblDischarge = dbLayer.getCaption("strDischarged", objCMS);
                lblGatedOut = dbLayer.getCaption("strGatedOut", objCMS);
                //12-01-2023-Sanduru
                await Task.Delay(1000);
                lblGatedIn = dbLayer.getCaption("strReceivedGatedIn", objCMS);
                lblCustomsInspection = dbLayer.getCaption("strUnderCustomsInspection", objCMS);
                lblColExcessCargo = dbLayer.getCaption("strCollectingExcessCargo", objCMS);
                lblWaitShipline = dbLayer.getCaption("strWaitingshippinglineRelease", objCMS);
                lblWaitColdstorepayment = dbLayer.getCaption("strWaitingcoldstorepayment", objCMS);
                lblWaitforRSGTPayment = dbLayer.getCaption("strWaitingforRSGTPayment", objCMS);
                lblReadytoload = dbLayer.getCaption("strReadytoLoad", objCMS);
                lblLoadedonVessel = dbLayer.getCaption("strLoadedonvessel", objCMS);
                lblCustomsInspectionMsg = dbLayer.getCaption("strRSGTdidnotreceiveinspectionbooking", objCMS);
                lblLoadedonvesselMsg = dbLayer.getCaption("strContainerRolledOver", objCMS);
                imgArrivalGreenIcon1 = lstrGrayicon;
                imgDischargeGreenIcon2 = lstrGrayicon;
                imgUnderGreenIcon3 = lstrGrayicon;
                imgInspectioGreenIcon4 = lstrGrayicon;
                imgportchargeGreenIcon5 = lstrGrayicon;
                imgprepickGrayIcon7 = lstrGrayicon;
                imgReadyGreenIcon6 = lstrGrayicon;
                imgGatedGreenIcon8 = lstrGrayicon;
                //12-01-2023-Sanduru
                imgexpGatedIn = lstrGrayicon;
                imgexpCustomsInspection = lstrGrayicon;
                imgexpExcessCargo = lstrGrayicon;
                imgexpWaitShipline = lstrGrayicon;
                imgexpWaitcoldstorepayment = lstrGrayicon;
                imgexpWaitforRSGTPayment = lstrGrayicon;
                imgexpReadytoLoad = lstrGrayicon;
                imgexpLoadedonvessel = lstrGrayicon;

                lblDearConsignee = dbLayer.getCaption("strConsigneeMsg", objCMS) + "(" + " " + strBLNumber + " " + ")";

            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To get Container Details Section
        /// </summary>
        /// <param name="fstrConatinerNo"></param>
        /// <param name="fstrBLNo"></param>
        /// <param name="fstrBayanNo"></param>
        private async void ContainerDetailsSection(string fstrConatinerNo, string fstrBLNo, string fstrBayanNo)
        {
            try
            {
                string fstrFilterData = "";
                //BayanNum
                if ((fstrBLNo != "") && (fstrConatinerNo != ""))
                {
                    fstrFilterData += "fstrBLNumber:" + fstrBLNo + ";" + "fstrContainerNo:" + fstrConatinerNo + ";";
                }
                lstContainerDtls = objCon.getContainerDetailsSection(gblRegisteration.strLoginUser, fstrFilterData);

                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                if ((lstContainerDtls != null) && (lstContainerDtls.Count > 0))
                {
                    StrContainerNo = lstContainerDtls.ToArray()[0].cd_containernumber;
                    StrVesselVisitId = lstContainerDtls.ToArray()[0].cd_vesselvisitid;
                    StrVeeselName = lstContainerDtls.ToArray()[0].cd_vesselname1;
                    StrVoyage = lstContainerDtls.ToArray()[0].cd_ibvoyage;
                    StrBLNumber = lstContainerDtls.ToArray()[0].cd_blnumber;
                    StrCustomerBayanNo = lstContainerDtls.ToArray()[0].cd_bayannumber;
                    ImgMaersk = lstContainerDtls.ToArray()[0].cd_shippingicon;
                    StrShippingLineId2 = "(" + lstContainerDtls.ToArray()[0].cd_shippinglineid + ")";
                    StrConsignee = lstContainerDtls.ToArray()[0].cd_consigneedesc1;
                    StrShipper = lstContainerDtls.ToArray()[0].cd_shipperdesc1;
                    StrCustomBrokerAgent = lstContainerDtls.ToArray()[0].cd_custombrokeragent;
                    StrCategory = lstContainerDtls.ToArray()[0].cd_category;
                    //12-01-2023-Sanduru
                    isVisibleExport = false;
                    isVisibleImport = true;
                    if (StrCategory == "EXPRT")
                    {
                        isVisibleExport = true;
                        isVisibleImport = false;
                    }
                    IsvisibleEmptyDept = true;
                    IsvisibleFreeDays = true;
                    if (StrCategory == "EXPRT")
                    {
                        IsvisibleEmptyDept = false;
                        IsvisibleFreeDays = false;
                    }
                    StrFreightKind = lstContainerDtls.ToArray()[0].cd_freightkind;
                    StrSize = lstContainerDtls.ToArray()[0].cd_size;
                    StrWeight = lstContainerDtls.ToArray()[0].cd_weight;
                    StrPortOfLoading = lstContainerDtls.ToArray()[0].cd_portofloading;
                    StrPortOfDischarge = lstContainerDtls.ToArray()[0].cd_portofdischarge;
                    StrInspectionStatus = lstContainerDtls.ToArray()[0].cd_inspectionstatus;
                    StrHoldPermission = lstContainerDtls.ToArray()[0].cd_holdpermission;
                    StrTransitStatus = lstContainerDtls.ToArray()[0].cd_transitstatus;
                    StrOoGDetails = lstContainerDtls.ToArray()[0].cd_oogdetails;
                    StrReeferDetails = lstContainerDtls.ToArray()[0].cd_reeferdetails;
                    StrDgDetails = lstContainerDtls.ToArray()[0].cd_dgdetails;
                    StrDamageDetails = lstContainerDtls.ToArray()[0].cd_damagedetails;
                    StrEmptyDeport = lstContainerDtls.ToArray()[0].cd_emptydepot;
                    Strfreedays = lstContainerDtls.ToArray()[0].cd_emptydepot_eng;
                    //20230411
                    gblSuryvaform.strBlgkey = lstContainerDtls.ToArray()[0].cd_blgkey;
                    gblSuryvaform.strBayanNo = lstContainerDtls.ToArray()[0].cd_bayannumber;
                    gblSuryvaform.strBlNo = lstContainerDtls.ToArray()[0].cd_blnumber;
                    if (App.gblLanguage == "Ar")
                    {
                        Strfreedays = lstContainerDtls.ToArray()[0].cd_emptydepot_ara;
                    }
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                 App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Container TimeLine Data
        /// </summary>
        /// <param name="fstrConatinerNo"></param>
        /// <param name="fstrBLNo"></param>
        /// <param name="fstrBayanNo"></param>
        private void ContainerTimeLineData(string fstrConatinerNo, string fstrBLNo, string fstrBayanNo)
        {
            try
            {
                //04-01-2023-Sanduru-Export
                isVisibleValInspection = true;
                isVisibleValLoadedVessel = true;
                isVisibleInspection = false;
                isVisibleLoadedVessel = false;
                string fstrFilterData = "";
                //BayanNum
                if ((fstrBayanNo != "") && (fstrBLNo != "") && (fstrConatinerNo != ""))
                {
                    fstrFilterData += "CD_BAYANNUMBER:" + fstrBayanNo + "," + "CD_BLNUMBER:" + fstrBLNo + "," + "CD_CONTAINERNUMBER:" + fstrConatinerNo + ",";
                }
                lstTimeLine = objCon.getContainerTimeLine(gblRegisteration.strLoginUser, fstrFilterData);

                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((lstTimeLine != null) && (lstTimeLine.Count > 0))
                {
                    lblValArrival = lstTimeLine.ToArray()[0].timeline_arrived;
                    lblValDischarge = lstTimeLine.ToArray()[0].timeline_discharge;
                    lblValInsComp = lstTimeLine.ToArray()[0].timeline_inspectioncomplete;
                    lblValPortCharges = lstTimeLine.ToArray()[0].timeline_waitingforportcharges;
                    lblValPrePickUpissued = lstTimeLine.ToArray()[0].timeline_prepickupissuedtime;
                    lblValRFD = lstTimeLine.ToArray()[0].timeline_readyfordeliverytime;
                    lblValUnderInsp = lstTimeLine.ToArray()[0].timeline_underinspection;
                    lblValGatedOut = lstTimeLine.ToArray()[0].timeline_gatedouttime;

                    //12-01-2023-Sanduru
                    lblValGatedIn = lstTimeLine.ToArray()[0].timeline_expunitintime.ToString();
                    lblValCustomsInspection = lstTimeLine.ToArray()[0].timeline_expbookforinsptime.ToString();
                    if (lblValCustomsInspection == null || lblValCustomsInspection == "") //04-01-2023-Sanduru-Export
                    {
                        isVisibleValInspection = false;
                        isVisibleInspection = true;
                    }
                    lblValColExcessCargo = lstTimeLine.ToArray()[0].timeline_expexcesscargoholdtime.ToString();
                    lblValWaitShipline = lstTimeLine.ToArray()[0].timeline_expdetentionholdtime.ToString();
                    lblValWaitColdstorepayment = lstTimeLine.ToArray()[0].timeline_expcoldstorepayholdtime.ToString();
                    lblValWaitforRSGTPayment = lstTimeLine.ToArray()[0].timeline_expfinholdtime.ToString();
                    lblValReadytoload = lstTimeLine.ToArray()[0].timeline_expreadytoloadtime.ToString();
                    lblValLoadedonVessel = lstTimeLine.ToArray()[0].timeline_expunitloadtime.ToString();
                    if (lblValLoadedonVessel == null || lblValLoadedonVessel == "") //04-01-2023-Sanduru-Export
                    {
                        isVisibleValLoadedVessel = false;
                        isVisibleLoadedVessel = true;
                    }
                    string lstrgreenicon = dbLayer.getCaption("imgStatusGreenicon", objCMS);
                    if (lstTimeLine.ToArray()[0].timeline_arrived.ToString().Length > 0)
                    {
                        imgArrivalGreenIcon1 = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_discharge.ToString().Length > 0)
                    {
                        imgDischargeGreenIcon2 = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_underinspection.ToString().Length > 0)
                    {
                        imgUnderGreenIcon3 = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_inspectioncomplete.ToString().Length > 0)
                    {
                        imgInspectioGreenIcon4 = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_waitingforportcharges.ToString().Length > 0)
                    {
                        imgportchargeGreenIcon5 = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_prepickupissuedtime.ToString().Length > 0)
                    {
                        imgprepickGrayIcon7 = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_readyfordeliverytime.ToString().Length > 0)
                    {
                        imgReadyGreenIcon6 = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_gatedouttime.ToString().Length > 0)
                    {
                        imgGatedGreenIcon8 = lstrgreenicon;
                    }
                    //12-01-2023-Sanduru
                    if (lstTimeLine.ToArray()[0].timeline_expunitintime.ToString().Length > 0)
                    {
                        imgexpGatedIn = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_expbookforinsptime.ToString().Length > 0)
                    {
                        imgexpCustomsInspection = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_expexcesscargoholdtime.ToString().Length > 0)
                    {
                        imgexpExcessCargo = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_expdetentionholdtime.ToString().Length > 0)
                    {
                        imgexpWaitShipline = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_expcoldstorepayholdtime.ToString().Length > 0)
                    {
                        imgexpWaitcoldstorepayment = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_expfinholdtime.ToString().Length > 0)
                    {
                        imgexpWaitforRSGTPayment = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_expreadytoloadtime.ToString().Length > 0)
                    {
                        imgexpReadytoLoad = lstrgreenicon;
                    }
                    if (lstTimeLine.ToArray()[0].timeline_expunitloadtime.ToString().Length > 0)
                    {
                        imgexpLoadedonvessel = lstrgreenicon;
                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Container PDF
        /// </summary>
        /// <returns></returns>
        private async Task Container_PDF_Clicked()
        {
            try
            {
                IsBusy = true;
                StackContainerDetails = false;
                await Task.Delay(1000);
                string lstrLang = "0";
                if (App.gblLanguage == "Ar")
                {
                    lstrLang = "1";
                }
                string strURL = AppSettings.MobWebUrl;

                gblContainerNo = gblContainer.strgblContainerNo;
                gblBlNo = gblContainer.strgblBolNo;


                var pdfUrl = strURL + "/ContainerDetail/OpenPDF?" + "fstrContainerNo=" + gblContainerNo + "&fstrBlnNo=" + gblBlNo + "&fstrLang=" + lstrLang + "";

               App.Current.MainPage?.DisplayToastAsync("Pdf file is opening. Please wait", 3000);
                openPdf(pdfUrl);
                IsBusy = false;
                StackContainerDetails = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }

        /// <summary>
        /// To get PDF
        /// </summary>
        /// <param name="fstrUrl"></param>
        private async void openPdf(string fstrUrl)
        {
            IsBusy = true;
            StackContainerDetails = false;
            await Task.Delay(1000);
            await Browser.OpenAsync(fstrUrl, BrowserLaunchMode.SystemPreferred);
            IsBusy = false;
            StackContainerDetails = true;
        }
        /// <summary>
        /// To get Container Mail PDF
        /// </summary>
        /// <returns></returns>
        private async Task ContainerMail_PDF_Clicked()
        {
            try
            {
                IsBusy = true;
                StackContainerDetails = false;
                await Task.Delay(1000);
                gblContainerNo = gblContainer.strgblContainerNo;
                string lstrTime = DateTime.Now.ToString("yyyyMMdd");
                string lstrUserName = gblRegisteration.strLoginFirstName.ToString().Trim();
                lstrTime = "_" + gblContainerNo + "_" + lstrTime;
                string strURL = AppSettings.MobWebUrl;
                string url = strURL + "/PDF/Container" + lstrTime + ".pdf";
                string lstrInput = "{\"SMT_CODE\":\"ContainerPDF\",\"ru_emailid\":\"" + gblRegisteration.strLoginUser + "\",\"RU_FIRSTNAME1\":\"" + gblRegisteration.strLoginFirstName + "\",\"CD_CONTAINERNUMBER\":\"" + gblContainerNo + "\",\"SMM_ATTACHMENT\":\"" + url + "\"}";
                objWeb.postWebApi("PostSendEmail", lstrInput);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                await App.Current.MainPage?.Navigation.PushAsync(new Container_PDF_Message());
                IsBusy = false;
                StackContainerDetails = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to Survey form
        /// </summary>
        /// <returns></returns>
        private async Task gotosurveyform()
        {
            IsBusy = true;
            StackContainerDetails = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new SurveyForm());
            StackContainerDetails = true;
            IsBusy = false;
        }
    }
}
