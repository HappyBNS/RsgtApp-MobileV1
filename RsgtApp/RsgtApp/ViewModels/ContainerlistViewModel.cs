using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.ContainerModel;

namespace RsgtApp.ViewModels
{
    class ContainerlistViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        WebApiMethod objWebApi = new WebApiMethod();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private List<clsListofcontainer> lstcontainer = new List<clsListofcontainer>();
        private List<clsListofbillofladings> lstHeader = new List<clsListofbillofladings>();
        private List<clsListofcontainer> objDataSource = new List<clsListofcontainer>();
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        BLConnect objBl = new BLConnect();
        BLConnect bl = new BLConnect();
        private string strLanguage = App.gblLanguage;

        public int intTotalCount { get; set; }
        public string strSelectedBOLNo { get; set; }
        string strBolNo = gblBol.strgblBolNo;
        //Assign Property Two way Binding
        //Two way Binding Variable
        //To create Collection Object used ObservableCollection
        public ObservableCollection<ContainerDt> lstcontainerlist { get; }
        public int fintPageNumber = 1;
        public int fintPageSize = 10000;
        public Command SearchAny { get; set; }
        public Command FilterClicked { get; set; }
        public Command gotoLoadMore { get; set; }
        public Command ButtonClickedApply { get; set; }
        public Command gotoReset { get; set; }
        public Command ButtonClickedCancel { get; set; }
        public string Damageflag { get; set; }
        public bool flagPopupFrame { get; set; }
        public bool flagDangerous { get; set; }
        public bool flagDamage { get; set; }
        public bool flagHold { get; set; }
        public string lblFrightType = "";
        public string lblOthers = "";
        public string lblAnyWhere = "";
        public string lblBolNo = "";
        public string gblAnyWhere { get; set; }
        private string strNoRecord = "";
        string lblCapListofContainers = "";
        string strServerSlowMsg = "";
        //string AnyWhere = "";
        //string Container_unitgkey = "";
        //string BayanNo = "";
        //string Billoflading = "";
        //string Containerno = "";
        //string Containerno_Size = "";
        string lstrCaptionALL = "";
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
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
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
        private string strTotalCaption = "";
        //To Declare Count Variable
        private int totalRecordCount = 0;

        private string strtotalRecordCount = "";
        public string TotalRecordCount
        {
            get { return strtotalRecordCount; }
            set
            {
                strtotalRecordCount = value;
                OnPropertyChanged();
                RaisePropertyChange("TotalRecordCount");
            }
        }
        //LblBayanNo purpose of using Label varaiable
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
        //LblValBayanNo purpose of using Label varaiable
        private string lblValBayanNo = "";
        public string LblValBayanNo
        {
            get { return lblValBayanNo; }
            set
            {
                lblValBayanNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValBayanNo");
            }
        }
        //LblAppoint purpose of using Label varaiable
        public string lblAppoint = "";
        public string LblAppoint
        {
            get { return lblAppoint; }
            set
            {
                lblAppoint = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAppoint");
            }
        }
        //LblDepot purpose of using Label varaiable
        public string lblDepot = "";
        public string LblDepot
        {
            get { return lblDepot; }
            set
            {
                lblDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDepot");
            }
        }
        //LblLoaded purpose of using Label varaiable
        public string lblLoaded = "";
        public string LblLoaded
        {
            get { return lblLoaded; }
            set
            {
                lblLoaded = value;
                OnPropertyChanged();
                RaisePropertyChange("LblLoaded");
            }
        }
        //LblGatedOut purpose of using Label varaiable
        public string lblGatedOut = "";
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
        //LblInsp purpose of using Label varaiable
        public string lblInsp { get; set; }
        public string LblInsp
        {
            get { return lblInsp; }
            set
            {
                lblInsp = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInsp");
            }
        }
        //LblDepot2 purpose of using Label varaiable
        public string lblDepot2 = "";
        public string LblDepot2
        {
            get { return lblDepot2; }
            set
            {
                lblDepot2 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDepot2");
            }
        }
        //ImgDownArrow purpose of using Image varaiable
        private string imgDownArrow = "";
        public string ImgDownArrow
        {
            get { return imgDownArrow; }
            set
            {
                imgDownArrow = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow");
            }
        }
        //LblBillOfLading purpose of using Label varaiable
        private string lblBillOfLading = "";
        public string LblBillOfLading
        {
            get { return lblBillOfLading; }
            set
            {
                lblBillOfLading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBillOfLading");
            }
        }
        //LblValBLNo purpose of using Label varaiable
        private string lblValBLNo = "";
        public string LblValBLNo
        {
            get { return lblValBLNo; }
            set
            {
                lblValBLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValBLNo");
            }
        }
        //LblShippingLine purpose of using Label varaiable
        private string lblShippingLine = "";
        public string LblShippingLine
        {
            get { return lblShippingLine; }
            set
            {
                lblShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("LblShippingLine");
            }
        }
        //ImgHapag purpose of using Image varaiable
        private string imgHapag = "";
        public string ImgHapag
        {
            get { return imgHapag; }
            set
            {
                imgHapag = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgHapag");
            }
        }
        //LblValShippingLine purpose of using Label varaiable
        private string lblValShippingLine = "";
        public string LblValShippingLine
        {
            get { return lblValShippingLine; }
            set
            {
                lblValShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValShippingLine");
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
        //LblValConsignee purpose of using Label varaiable
        private string lblValConsignee = "";
        public string LblValConsignee
        {
            get { return lblValConsignee; }
            set
            {
                lblValConsignee = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValConsignee");
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
        //LblValShipper purpose of using Label varaiable
        private string lblValShipper = "";
        public string LblValShipper
        {
            get { return lblValShipper; }
            set
            {
                lblValShipper = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValShipper");
            }
        }
        //LblVesselVisit purpose of using Label varaiable
        private string lblVesselVisit = "";
        public string LblVesselVisit
        {
            get { return lblVesselVisit; }
            set
            {
                lblVesselVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("LblVesselVisit");
            }
        }
        //LblValVesselVisit purpose of using Label varaiable
        private string lblValVesselVisit = "";
        public string LblValVesselVisit
        {
            get { return lblValVesselVisit; }
            set
            {
                lblValVesselVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValVesselVisit");
            }
        }
        //LblBlCategory purpose of using Label varaiable
        private string lblBlCategory = "";
        public string LblBlCategory
        {
            get { return lblBlCategory; }
            set
            {
                lblBlCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBlCategory");
            }
        }
        //LblValBlCategory purpose of using Label varaiable
        private string lblValBlCategory = "";
        public string LblValBlCategory
        {
            get { return lblValBlCategory; }
            set
            {
                lblValBlCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValBlCategory");
            }
        }
        //LblPol purpose of using Label varaiable
        private string lblPol = "";
        public string LblPol
        {
            get { return lblPol; }
            set
            {
                lblPol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPol");
            }
        }
        //LblValPol purpose of using Label varaiable
        private string lblValPol = "";
        public string LblValPol
        {
            get { return lblValPol; }
            set
            {
                lblValPol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValPol");
            }
        }
        //LblPod purpose of using Label varaiable
        private string lblPod = "";
        public string LblPod
        {
            get { return lblPod; }
            set
            {
                lblPod = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPod");
            }
        }
        //LblValPod purpose of using Label varaiable
        private string lblValPod = "";
        public string LblValPod
        {
            get { return lblValPod; }
            set
            {
                lblValPod = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValPod");
            }
        }
        //Searchbox purpose of using TextBox varaiable
        private string searchbox = "";
        public string Searchbox
        {
            get { return searchbox; }
            set
            {
                searchbox = value;
                OnPropertyChanged();
                RaisePropertyChange("Searchbox");
            }
        }
        //TxtSearch purpose of using Label varaiable
        private string txtSearch = "";
        public string TxtSearch
        {
            get { return txtSearch; }
            set
            {
                txtSearch = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtSearch");
            }
        }
        //ImgSearch purpose of using Image varaiable
        private string imgSearch = "";
        public string ImgSearch
        {
            get { return imgSearch; }
            set
            {
                imgSearch = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgSearch");
            }
        }
        //ImgFilter purpose of using Image varaiable
        private string imgFilter = "";
        public string ImgFilter
        {
            get { return imgFilter; }
            set
            {
                imgFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgFilter");
            }
        }
        //Freighticon purpose of using Image varaiable
        private string freighticon = "";
        public string Freighticon
        {
            get { return freighticon; }
            set
            {
                freighticon = value;
                OnPropertyChanged();
                RaisePropertyChange("Freighticon");
            }
        }
        //Freightinfo purpose of using Label varaiable
        private string freightinfo = "";
        public string Freightinfo
        {
            get { return freightinfo; }
            set
            {
                freightinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Freightinfo");
            }
        }
        //Unitsizeicon purpose of using Image varaiable
        private string unitsizeicon = "";
        public string Unitsizeicon
        {
            get { return unitsizeicon; }
            set
            {
                unitsizeicon = value;
                OnPropertyChanged();
                RaisePropertyChange("Unitsizeicon");
            }
        }
        //Unitsizeinfo purpose of using Label varaiable
        private string unitsizeinfo = "";
        public string Unitsizeinfo
        {
            get { return unitsizeinfo; }
            set
            {
                unitsizeinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Unitsizeinfo");
            }
        }
        //Temperaturecon purpose of using Image varaiable
        private string temperaturecon = "";
        public string Temperaturecon
        {
            get { return temperaturecon; }
            set
            {
                temperaturecon = value;
                OnPropertyChanged();
                RaisePropertyChange("Temperaturecon");
            }
        }
        //Temperatureinfo purpose of using Label varaiable
        private string temperatureinfo = "";
        public string Temperatureinfo
        {
            get { return temperatureinfo; }
            set
            {
                temperatureinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Temperatureinfo");
            }
        }
        //Loadinginfo purpose of using Label varaiable
        private string loadinginfo = "";
        public string Loadinginfo
        {
            get { return loadinginfo; }
            set
            {
                loadinginfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Loadinginfo");
            }
        }
        //Inspectionicon purpose of using Image varaiable
        private string inspectionicon = "";
        public string Inspectionicon
        {
            get { return inspectionicon; }
            set
            {
                inspectionicon = value;
                OnPropertyChanged();
                RaisePropertyChange("Inspectionicon");
            }
        }
        //Inspectioninfo purpose of using Label varaiable
        private string inspectioninfo = "";
        public string Inspectioninfo
        {
            get { return inspectioninfo; }
            set
            {
                inspectioninfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Inspectioninfo");
            }
        }
        //Invoiceicon purpose of using Image varaiable
        private string invoiceicon = "";
        public string Invoiceicon
        {
            get { return invoiceicon; }
            set
            {
                invoiceicon = value;
                OnPropertyChanged();
                RaisePropertyChange("Invoiceicon");
            }
        }
        //Invoiceinfo purpose of using Label varaiable
        private string invoiceinfo = "";
        public string Invoiceinfo
        {
            get { return invoiceinfo; }
            set
            {
                invoiceinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Invoiceinfo");
            }
        }
        //Appointmenticon purpose of using Image varaiable
        private string appointmenticon = "";
        public string Appointmenticon
        {
            get { return appointmenticon; }
            set
            {
                appointmenticon = value;
                OnPropertyChanged();
                RaisePropertyChange("Appointmenticon");
            }
        }
        //Appointmentdate purpose of using Label varaiable
        private string appointmentdate = "";
        public string Appointmentdate
        {
            get { return appointmentdate; }
            set
            {
                appointmentdate = value;
                OnPropertyChanged();
                RaisePropertyChange("Appointmentdate");
            }
        }
        //Appointmenttime purpose of using Label varaiable
        private string appointmenttime = "";
        public string Appointmenttime
        {
            get { return appointmenttime; }
            set
            {
                appointmenttime = value;
                OnPropertyChanged();
                RaisePropertyChange("Appointmenttime");
            }
        }
        //Appointmentinfo purpose of using Label varaiable
        private string appointmentinfo = "";
        public string Appointmentinfo
        {
            get { return appointmentinfo; }
            set
            {
                appointmentinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Appointmentinfo");
            }
        }
        //Gateicon purpose of using Image varaiable
        private string gateicon = "";
        public string Gateicon
        {
            get { return gateicon; }
            set
            {
                gateicon = value;
                OnPropertyChanged();
                RaisePropertyChange("Gateicon");
            }
        }
        //Gateinfo purpose of using Image varaiable
        private string gateinfo = "";
        public string Gateinfo
        {
            get { return gateinfo; }
            set
            {
                gateinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Gateinfo");
            }
        }
        //Returndepoticon purpose of using Image varaiable
        private string returndepoticon = "";
        public string Returndepoticon
        {
            get { return returndepoticon; }
            set
            {
                returndepoticon = value;
                OnPropertyChanged();
                RaisePropertyChange("Returndepoticon");
            }
        }
        //Returndepotinfo purpose of using Label varaiable
        private string returndepotinfo = "";
        public string Returndepotinfo
        {
            get { return returndepotinfo; }
            set
            {
                returndepotinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Returndepotinfo");
            }
        }
        //StatusColor purpose of using Color varaiable
        private string statusColor = "";
        public string StatusColor
        {
            get { return statusColor; }
            set
            {
                statusColor = value;
                OnPropertyChanged();
                RaisePropertyChange("StatusColor");
            }
        }
        //Status purpose of using Label varaiable
        private string status = "";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
                RaisePropertyChange("Status");
            }
        }
        //BtnMoreDetails purpose of using Button varaiable
        private string btnMoreDetails = "";
        public string BtnMoreDetails
        {
            get { return btnMoreDetails; }
            set
            {
                btnMoreDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnMoreDetails");
            }
        }
        //BtnLoadMore purpose of using Button varaiable
        private string btnLoadMore = "";
        public string BtnLoadMore
        {
            get { return btnLoadMore; }
            set
            {
                btnLoadMore = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnLoadMore");
            }
        }

        //ImgDangerRed purpose of using Image varaiable
        private string imgDangerRed = "";
        public string ImgDangerRed
        {
            get { return imgDangerRed; }
            set
            {
                imgDangerRed = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDangerRed");
            }
        }
        //imgDamage purpose of using Image varaiable
        private string imgDamage = "";
        public string ImgDamage
        {
            get { return imgDamage; }
            set
            {
                imgDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDamage");
            }
        }
        //ImgHoldIconRed purpose of using Image varaiable
        private string imgHoldIconRed = "";
        public string ImgHoldIconRed
        {
            get { return imgHoldIconRed; }
            set
            {
                imgHoldIconRed = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgHoldIconRed");
            }
        }
        //ImgFilterBlue purpose of using Image varaiable
        private string imgFilterBlue = "";
        public string ImgFilterBlue
        {
            get { return imgFilterBlue; }
            set
            {
                imgFilterBlue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgFilterBlue");
            }
        }
        //LblFilter purpose of using Label varaiable
        private string lblFilter = "";
        public string LblFilter
        {
            get { return lblFilter; }
            set
            {
                lblFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFilter");
            }
        }
        //BtnApply purpose of using Button varaiable
        private string btnApply = "";
        public string BtnApply
        {
            get { return btnApply; }
            set
            {
                btnApply = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnApply");
            }
        }
        //ImgReset purpose of using Image varaiable
        private string imgReset = "";
        public string ImgReset
        {
            get { return imgReset; }
            set
            {
                imgReset = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgReset");
            }
        }
        //LblFreightType purpose of using Label varaiable
        private string lblFreightType = "";
        public string LblFreightType
        {
            get { return lblFreightType; }
            set
            {
                lblFreightType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFreightType");
            }
        }
        //LblContainerSize purpose of using Label varaiable
        private string lblContainerSize = "";
        public string LblContainerSize
        {
            get { return lblContainerSize; }
            set
            {
                lblContainerSize = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerSize");
            }
        }
        //ImgDownArrow2 purpose of using Image varaiable
        private string imgDownArrow2 = "";
        public string ImgDownArrow2
        {
            get { return imgDownArrow2; }
            set
            {
                imgDownArrow2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow2");
            }
        }
        //lblok purpose of using checkbox varaiable
        private string lblok = "";
        public string Lblok
        {
            get { return lblok; }
            set
            {
                lblok = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblok");
            }
        }
        //LblAppointment purpose of using Label varaiable
        private string lblAppointment = "";
        public string LblAppointment
        {
            get { return lblAppointment; }
            set
            {
                lblAppointment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAppointment");
            }
        }
        //ImgDownArrow3 purpose of using Image varaiable
        private string imgDownArrow3 = "";
        public string ImgDownArrow3
        {
            get { return imgDownArrow3; }
            set
            {
                imgDownArrow3 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow3");
            }
        }
        //LblGate purpose of using Label varaiable
        private string lblGate = "";
        public string LblGate
        {
            get { return lblGate; }
            set
            {
                lblGate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGate");
            }
        }
        //ImgDownArrow4 purpose of using Image varaiable
        private string imgDownArrow4 = "";
        public string ImgDownArrow4
        {
            get { return imgDownArrow4; }
            set
            {
                imgDownArrow4 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow4");
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
        //LblDownArrow6 purpose of using Label varaiable
        private string lblDownArrow6 = "";
        public string LblDownArrow6
        {
            get { return lblDownArrow6; }
            set
            {
                lblDownArrow6 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDownArrow6");
            }
        }
        //LblDamage purpose of using Label varaiable
        private string lblDamage = "";
        public string LblDamage
        {
            get { return lblDamage; }
            set
            {
                lblDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDamage");
            }
        }
        //EnumFrightType purpose of using combo varaiable
        private string enumFrightType = "";
        public string EnumFrightType
        {
            get { return enumFrightType; }
            set
            {
                enumFrightType = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumFrightType");
            }
        }
        //EnumContainerSize purpose of using combo varaiable
        private string enumContainerSize = "";
        public string EnumContainerSize
        {
            get { return enumContainerSize; }
            set
            {
                enumContainerSize = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumContainerSize");
            }
        }
        //EnumAppointment purpose of using combo varaiable
        private string enumAppointment = "";
        public string EnumAppointment
        {
            get { return enumAppointment; }
            set
            {
                enumAppointment = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumAppointment");
            }
        }
        //EnumGate purpose of using combo varaiable
        private string enumGate = "";
        public string EnumGate
        {
            get { return enumGate; }
            set
            {
                enumGate = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumGate");
            }
        }
        //EnumStatus purpose of using combo varaiable
        private string enumStatus = "";
        public string EnumStatus
        {
            get { return enumStatus; }
            set
            {
                enumStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumStatus");
            }
        }
        //EnumOthers purpose of using combo varaiable
        private string enumOthers = "";
        public string EnumOthers
        {
            get { return enumOthers; }
            set
            {
                enumOthers = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumOthers");
            }
        }
        //EnumDamage purpose of using combo varaiable
        private string enumDamage = "";
        public string EnumDamage
        {
            get { return enumDamage; }
            set
            {
                enumDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumDamage");
            }
        }
        //TxtBolNo purpose of using TextBox varaiable
        private string txtBolNo = "";
        public string TxtBolNo
        {
            get { return txtBolNo; }
            set
            {
                txtBolNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBolNo");
            }
        }
        //Filter Page
        //FilterContainerSize purpose of using Filter varaiable
        private string filterContainerSize = "";
        public string FilterContainerSize
        {
            get { return filterContainerSize; }
            set
            {
                filterContainerSize = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterContainerSize");
            }
        }
        //FilterAppointment purpose of using Filter varaiable
        private string filterAppointment = "";
        public string FilterAppointment
        {
            get { return filterAppointment; }
            set
            {
                filterAppointment = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterAppointment");
            }
        }
        //FilterGate purpose of using Filter varaiable
        private string filterGate = "";
        public string FilterGate
        {
            get { return filterGate; }
            set
            {
                filterGate = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterGate");
            }
        }
        //FilterStatus purpose of using Filter varaiable
        private string filterStatus = "";
        public string FilterStatus
        {
            get { return filterStatus; }
            set
            {
                filterStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterStatus");
            }
        }
        //FilterDamage purpose of using Filter varaiable
        private string filterDamage = "";
        public string FilterDamage
        {
            get { return filterDamage; }
            set
            {
                filterDamage = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterDamage");
            }
        }
        //ImgDownArrow7 purpose of using Image varaiable
        private string imgDownArrow7 = "";
        public string ImgDownArrow7
        {
            get { return imgDownArrow7; }
            set
            {
                imgDownArrow7 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow7");
            }
        }
        //FilterFreightType purpose of using Filter varaiable
        private string filterFreightType = "";
        public string FilterFreightType
        {
            get { return filterFreightType; }
            set
            {
                filterFreightType = value;
                OnPropertyChanged();
                RaisePropertyChange("FilterFreightType");
            }
        }
        //ImgDownArrow6 purpose of using Image varaiable
        private string imgDownArrow6 = "";
        public string ImgDownArrow6
        {
            get { return imgDownArrow6; }
            set
            {
                imgDownArrow6 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow6");
            }
        }
        //lblGatedIn purpose of using Label varaiable
        //12-01-2023-Sanduru
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
        //To Handle Indicator
        private bool stackContainerList = true;
        public bool StackContainerList
        {
            get { return stackContainerList; }
            set
            {
                stackContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("StackContainerList");
            }
        }
        private bool isVisibleContainerMain = false;
        public bool IsVisibleContainerMain
        {
            get { return isVisibleContainerMain; }
            set
            {
                isVisibleContainerMain = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleContainerMain");
            }
        }
        private bool isVisibleContainerFilter = false;
        public bool IsVisibleContainerFilter
        {
            get { return isVisibleContainerFilter; }
            set
            {
                isVisibleContainerFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleContainerFilter");
            }
        }


        private bool isExpandFreight = false;
        public bool IsExpandFreight
        {
            get { return isExpandFreight; }
            set
            {
                SetProperty(ref isExpandFreight, value);
                OnPropertyChanged();
                RaisePropertyChange("IsExpandFreight");
            }
        }
        private bool isExpandContainerSize = false;
        public bool IsExpandContainerSize
        {
            get { return isExpandContainerSize; }
            set
            {
                SetProperty(ref isExpandContainerSize, value);
                OnPropertyChanged();
                RaisePropertyChange("IsExpandContainerSize");
            }
        }
        private bool isExpandAppointment = false;
        public bool IsExpandAppointment
        {
            get { return isExpandAppointment; }
            set
            {
                SetProperty(ref isExpandAppointment, value);
                OnPropertyChanged();
                RaisePropertyChange("IsExpandAppointment");
            }
        }
        private bool isExpandGate = false;
        public bool IsExpandGate
        {
            get { return isExpandGate; }
            set
            {
                SetProperty(ref isExpandGate, value);
                OnPropertyChanged();
                RaisePropertyChange("IsExpandGate");
            }
        }
        private bool isExpandStatus = false;
        public bool IsExpandStatus
        {
            get { return isExpandStatus; }
            set
            {
                SetProperty(ref isExpandStatus, value);
                OnPropertyChanged();
                RaisePropertyChange("IsExpandStatus");
            }
        }

        private bool isExpandDamage = false;
        public bool IsExpandDamage
        {
            get { return isExpandDamage; }
            set
            {
                SetProperty(ref isExpandDamage, value);
                OnPropertyChanged();
                RaisePropertyChange("IsExpandDamage");
            }
        }



        //Two way Binding Variable
        //private string searchbox = "";
        //public string Searchbox
        //{
        //    get { return searchbox; }
        //    set
        //    {
        //        searchbox = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("Searchbox");
        //    }
        //}
        List<clsContainerStatusFilter> lstStatus = new List<clsContainerStatusFilter>();
        List<clsContainerDamageGoodFt> lstDamage = new List<clsContainerDamageGoodFt>();
        Dictionary<string, string> lobjpicFreightType = new Dictionary<string, string>();
        Dictionary<string, string> lobjpicContainerSize = new Dictionary<string, string>();
        Dictionary<string, string> lobjpicAppointment = new Dictionary<string, string>();
        Dictionary<string, string> lobjpicGate = new Dictionary<string, string>();
        Dictionary<string, string> lobjpicOthers = new Dictionary<string, string>();
        public ObservableCollection<ContainerFilterDlList> lstFilterStatusData { get; set; } = new ObservableCollection<ContainerFilterDlList>();
        public ObservableCollection<ContainerFilterDlList> lstFilterDamageData { get; set; } = new ObservableCollection<ContainerFilterDlList>();
        public ObservableCollection<ContainerFilterDlList> lstFrightFilterData { get; set; } = new ObservableCollection<ContainerFilterDlList>();
        public ObservableCollection<ContainerFilterDlList> lstFilterContainerSizeData { get; set; } = new ObservableCollection<ContainerFilterDlList>();
        public ObservableCollection<ContainerFilterDlList> lstFilterAppointmentData { get; set; } = new ObservableCollection<ContainerFilterDlList>();
        public ObservableCollection<ContainerFilterDlList> lstFilterGateData { get; set; } = new ObservableCollection<ContainerFilterDlList>();
        public System.Windows.Input.ICommand Containerdetail => new Command<ContainerDt>(Details);
        public System.Windows.Input.ICommand DamagegoodClicked => new Command<ContainerDt>(Damagegood_Clicked);
        public System.Windows.Input.ICommand HoldgoodClicked => new Command<ContainerDt>(Holdgood_Clicked);
        public System.Windows.Input.ICommand ContainerListphotorequest => new Command<ContainerDt>(ContainerListRequest);
        public System.Windows.Input.ICommand ContListInsprequest => new Command<ContainerDt>(contListInspRequest);
        string strHoldPopup = "";
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strBolNo"></param>
        /// <param name="strselectedFrightType"></param>
        /// <param name="strselectedSize"></param>
        /// <param name="strselectedAppoinment"></param>
        /// <param name="strselectedGate"></param>
        /// <param name="strselectedStatus"></param>
        /// <param name="strselectedOther"></param>
        /// <param name="fstrHoldPopup"></param>
        /// <param name="fstrFilterFlag"></param>
           //isBusy purpose of using indicator varaiable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                SearchAny.ChangeCanExecute();
                FilterClicked.ChangeCanExecute();
                gotoLoadMore.ChangeCanExecute();
                ButtonClickedApply.ChangeCanExecute();
                gotoReset.ChangeCanExecute();
                ButtonClickedCancel.ChangeCanExecute();
            }
        }


        public ContainerlistViewModel(string strSearchbox, string strBolNo, string strselectedFrightType, string strselectedSize, string strselectedAppoinment, string strselectedGate, string strselectedStatus, string strselectedOther, string fstrHoldPopup, string fstrFilterFlag)
        {
            Analytics.TrackEvent("ContainerlistViewModel");
            lstcontainerlist = new ObservableCollection<ContainerDt>();
            strTotalCaption = "";
            searchbox = strSearchbox;
            strHoldPopup = fstrHoldPopup;

            IsVisibleContainerFilter = false;
            IsVisibleContainerMain = false;
            if (fstrFilterFlag == "N")
            {
                IsVisibleContainerMain = true;
                IsVisibleContainerFilter = false;
            }
            if (fstrFilterFlag == "Y")
            {
                IsVisibleContainerFilter = true;
                IsVisibleContainerMain = false;
            }

            //Begin-Call Caption Function
            Task.Run(() => assignContent()).Wait();
            //Begin Command Button
            SearchAny = new Command(async () => await Anywhere(strBolNo), () => !IsBusy);
            FilterClicked = new Command(async () => await Filterclick(), () => !IsBusy);
            gotoLoadMore = new Command(async () => await ContainerData(strSearchbox, strBolNo, strselectedFrightType, strselectedSize, strselectedAppoinment, strselectedGate, strselectedStatus, strselectedOther), () => !IsBusy);
            ButtonClickedApply = new Command(async () => await ClickedApply(), () => !IsBusy);
            gotoReset = new Command(async () => await clear(), () => !IsBusy);
            ButtonClickedCancel = new Command(async () => await clear(), () => !IsBusy);
            //End Command Button

            Task.Run(() => StatusFilterData()).Wait();
            Task.Run(() => DamageFtData()).Wait();
            Task.Run(() => ContainerHeaderData(strBolNo)).Wait();
            Task.Run(() => ContainerData(strSearchbox, strBolNo, strselectedFrightType, strselectedSize, strselectedAppoinment, strselectedGate, strselectedStatus, strselectedOther)).Wait();

            // End - Caption Function
        }
        //End-ViewModel Constructor

        /// <summary>
        /// To Get Clear Function
        /// </summary>
        /// <returns></returns>
        public async Task clear()
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            StatusFilterData();
            assignContent();
            IsVisibleContainerFilter = false;
            IsVisibleContainerMain = true;
            IsExpandFreight = false;
            IsExpandContainerSize = false;
            IsExpandAppointment = false;
            IsExpandGate = false;
            IsExpandStatus = false;
            IsExpandDamage = false;
            StackContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Get Details Function
        /// </summary>
        /// <param name="fobjxcontainer"></param>
        public async void Details(ContainerDt fobjxcontainer)
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);
                string ContainerNo = fobjxcontainer.Containerno;
                string BLNo = fobjxcontainer.Billoflading;
                string BayanNo = fobjxcontainer.BayanNo;
                gblContainer.strgblContainerNo = ContainerNo;
                gblContainer.strgblBolNo = BLNo;
                gblContainer.strgblBaynanNo = BayanNo;
                Application.Current.MainPage?.Navigation.PushAsync(new Views.Containerdetail(fobjxcontainer.Containerno, fobjxcontainer.Billoflading, fobjxcontainer.BayanNo));
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Anywhere Function
        /// </summary>
        /// <param name="strBolNo"></param>
        /// <returns></returns>
        public async Task Anywhere(string strBolNo)
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);
                await ContainerData(searchbox, strBolNo, "", "", "", "", "", "");
                // Application.Current.MainPage?.Navigation.PushAsync(new Containerlist(searchbox, strBolNo, "", "", "", "", "", "", ""));
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Filterclick Function
        /// </summary>
        /// <returns></returns>
        public async Task Filterclick()
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);

                IsVisibleContainerMain = false;
                IsVisibleContainerFilter = true;

                IsBusy = false;
                StackContainerList = true;

            }
            catch (Exception ex)
            {
                string fstrCondition = "fstrCode=" + "RM013ContainerList" + "&fstrCustomMsg=" + "" + "&fstrSystemMsg=" + ex.Message + "&fstrSuggestion=" + "Exception" + "&fstrsource=" + "MobileApp" + "";
                string lstrResult = objWebApi.getstringPostWebApi("procWriteApiTraceLog", "", fstrCondition);
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }


        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM013");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM013");

                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }

                await Task.Delay(1000);

                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                lobjpicFreightType = dbLayer.getLOV("strFreighttype2", objCMS);
                lobjpicContainerSize = dbLayer.getLOV("strContainersize2", objCMS);
                lobjpicAppointment = dbLayer.getLOV("strAppointment2", objCMS);
                lobjpicGate = dbLayer.getLOV("strGate2", objCMS);
                lobjpicOthers = dbLayer.getLOV("strOthersFilters", objCMS);


                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFrightFilterData.Add(new ContainerFilterDlList { CmbFreightType = lstrCaptionALL });
                lstFrightFilterData.Clear();
                foreach (var dic in lobjpicFreightType)
                {
                    lstFrightFilterData.Add(new ContainerFilterDlList { CmbFreightType = dic.Key });
                }
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterContainerSizeData.Add(new ContainerFilterDlList { CmbContainerSize = lstrCaptionALL });
                lstFilterContainerSizeData.Clear();
                foreach (var dic in lobjpicContainerSize)
                {
                    lstFilterContainerSizeData.Add(new ContainerFilterDlList { CmbContainerSize = dic.Key });
                }
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterAppointmentData.Add(new ContainerFilterDlList { CmbAppointment = lstrCaptionALL });
                lstFilterAppointmentData.Clear();
                foreach (var dic in lobjpicAppointment)
                {
                    lstFilterAppointmentData.Add(new ContainerFilterDlList { CmbAppointment = dic.Key });
                }
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterGateData.Add(new ContainerFilterDlList { CmbGate = lstrCaptionALL });
                lstFilterGateData.Clear();
                foreach (var dic in lobjpicGate)
                {
                    lstFilterGateData.Add(new ContainerFilterDlList { CmbGate = dic.Key });
                }
                lstFilterDamageData.Clear();
                foreach (var dic in lobjpicOthers)
                {
                    lstFilterDamageData.Add(new ContainerFilterDlList { CmbDamage = dic.Key });
                }


                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                strTotalCaption = dbLayer.getCaption("strListofContainers", objCMS);
                lblCapListofContainers = dbLayer.getCaption("strListofContainers", objCMS);
                lblBayanNo = dbLayer.getCaption("strBayanNo", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                lblBillOfLading = dbLayer.getCaption("strBillofLading", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                lblShippingLine = dbLayer.getCaption("strShippingLine", objCMS);
                lblConsignee = dbLayer.getCaption("strConsignee", objCMS);
                lblShipper = dbLayer.getCaption("strShipper", objCMS);
                lblVesselVisit = dbLayer.getCaption("strVesselVisit", objCMS);
                lblBlCategory = dbLayer.getCaption("strBLCategory", objCMS);
                lblPol = dbLayer.getCaption("strPOL", objCMS);
                lblPod = dbLayer.getCaption("strPOD", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                txtSearch = dbLayer.getCaption("strContainerPlaceHolder", objCMS);
                Lblok = dbLayer.getCaption("strOk", objCMSMsg);//Gokul
                // Filter screen               
                ImgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                LblFilter = dbLayer.getCaption("strFilters", objCMS);
                BtnApply = dbLayer.getCaption("strApply", objCMS);
                ImgReset = dbLayer.getCaption("imgReset", objCMS);
                FilterFreightType = dbLayer.getCaption("strFreightType", objCMS);
                imgDownArrow = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterContainerSize = dbLayer.getCaption("strContainerSize", objCMS);
                imgDownArrow2 = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterAppointment = dbLayer.getCaption("strAppointment", objCMS);
                imgDownArrow3 = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterGate = dbLayer.getCaption("strGate", objCMS);
                imgDownArrow4 = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterStatus = dbLayer.getCaption("strStatus", objCMS);
                ImgDownArrow6 = dbLayer.getCaption("imgDownArrow", objCMS);
                FilterDamage = dbLayer.getCaption("strOther", objCMS);
                imgDownArrow7 = dbLayer.getCaption("imgDownArrow", objCMS);

                //start new changes in cardview_20221201_BABU
                lblAppoint = dbLayer.getCaption("strAppoint", objCMS);
                lblDepot = dbLayer.getCaption("strDepot", objCMS);
                lblLoaded = dbLayer.getCaption("strLoaded", objCMS);
                lblGatedOut = dbLayer.getCaption("strGatedOut", objCMS);
                lblInsp = dbLayer.getCaption("strInsp", objCMS);
                lblDepot2 = dbLayer.getCaption("strDepot2", objCMS);
                //End new changes in cardview_20221201_BABU               
                btnMoreDetails = dbLayer.getCaption("strMoreDetails", objCMS);
                imgDownArrow2 = dbLayer.getCaption("imgDownArrow", objCMS);
                imgDangerRed = dbLayer.getCaption("imgDangerred", objCMS);
                imgDamage = dbLayer.getCaption("imgDamage", objCMS);
                imgHoldIconRed = dbLayer.getCaption("imgHoldred", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                await Task.Delay(1000);

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }


        /// <summary>
        /// To Get ContainerData Function
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strBolNo"></param>
        /// <param name="strselectedFrightType"></param>
        /// <param name="strselectedSize"></param>
        /// <param name="strselectedAppoinment"></param>
        /// <param name="strselectedGate"></param>
        /// <param name="strselectedStatus"></param>
        /// <param name="strselectedOther"></param>
        /// <returns></returns>
        private async Task ContainerData(string strSearchbox, string strBolNo, string strselectedFrightType, string strselectedSize, string strselectedAppoinment, string strselectedGate, string strselectedStatus, string strselectedOther)
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);
                var stremptydepot = "";
                // var strContainerStatus = "";
                bool blflagDangerous = false;
                bool blflagDamage = false;
                bool blflagHold = false;
                bool blflagPopupFram = false;
                var objRawData = new List<ContainerDt>();
                string lstrBLNo = "";
                string fstrAnyWhere = "";
                string fstrFrightType = "";
                string fstrAppointment = "";
                string fstrContainerSize = "";
                string fstrGate = "";
                string fstrDamage = "";
                string fstrStatus = "";
                string fstrOthers = "";
                if (strSearchbox != null) fstrAnyWhere = strSearchbox;
                if (strselectedSize != null) fstrContainerSize = strselectedSize;
                if (strselectedAppoinment != null) fstrAppointment = strselectedAppoinment;
                if (strselectedGate != null) fstrGate = strselectedGate;
                if (strselectedStatus != null) fstrStatus = strselectedStatus;
                if (strselectedFrightType != null) fstrFrightType = strselectedFrightType;
                if (strselectedOther != null) fstrOthers = strselectedOther;
                if (strBolNo != null) lstrBLNo = strBolNo;
                lstcontainerlist.Clear();
                await Task.Delay(2000);
                string fstrFilterData = "fstrBLNUMBER:" + lstrBLNo + ";" + "fstrAnyWhere:" + fstrAnyWhere + ";" + "fstrFreightkind:" + fstrFrightType + ";" + "fstrAppoinment:" + fstrAppointment + ";" + "fstrContainersize:" + fstrContainerSize + ";" + "fstrGate:" + fstrGate + ";" + "fstrDamage:" + fstrDamage + ";" + "fstrStatus:" + fstrStatus + ";" + "fstrOthers:" + fstrOthers + ";";
                objRawData = objBl.getContainerDetails(gblRegisteration.strLoginUser, fintPageNumber, fintPageSize, fstrFilterData, strHoldPopup);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);

                }
                foreach (var item in objRawData)
                {
                    //Dangerous Popup
                    if (item.dgdetails.ToUpper().ToString().Trim() != "NO")
                    {
                        blflagDangerous = true;
                    }
                    //Hold Popup
                    if (item.containerpopup.ToUpper().ToString().Trim() != "N")
                    {
                        blflagHold = true;
                    }
                    //Damage Popup
                    if (item.damagepopup.ToUpper().ToString().Trim() != "N")
                    {
                        blflagDamage = true;
                    }
                    if (blflagDangerous == true || blflagHold == true || blflagDamage == true)
                    {
                        blflagPopupFram = true;
                    }
                    item.flagDangerous = blflagDangerous;
                    item.flagDamage = blflagDamage;
                    item.flagHold = blflagHold;
                    item.flagPopupFrame = blflagPopupFram;
                    item.Invoiceicon = "money_icon.png";
                    item.Invoiceinfo = "";
                    item.Returndepoticon = "container.png";
                    item.Returndepotinfo = stremptydepot;
                    item.btnMoreDetails = btnMoreDetails;
                    item.imgDownArrow2 = imgDownArrow2;
                    item.imgDangerRed = imgDangerRed;
                    item.imgDamage = imgDamage;
                    item.imgHoldIconRed = imgHoldIconRed;
                    item.lblDepot = lblDepot;
                    item.lblLoaded = lblLoaded;
                    item.lblGatedOut = lblGatedOut;
                    item.lblInsp = lblInsp;
                    item.lblDepot2 = lblDepot2;
                    item.lblAppoint = lblAppoint;
                    item.lblAnyWhere = lblAnyWhere;
                    item.lblGatedIn = "Gated In"; //12-01-2023-Sanduru
                    //30-12-2022-Sanduru
                    item.isVisibleExport = false;
                    item.isVisibleImport = true;
                    if (LblValBlCategory == "EXPRT")
                    {
                        item.isVisibleExport = true;
                        item.isVisibleImport = false;
                    }
                    lstcontainerlist.Add(item);
                }
                await Task.Delay(1000);

                totalRecordCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                if (lstcontainerlist == null || lstcontainerlist.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                StackContainerList = true;
                IsBusy = false;
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
        /// To Get Status Filter Data
        /// </summary>
        private async void StatusFilterData()
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            string strbaynNo = gblBayan.strgblBaynanNo;
            string strBLNo = gblBol.strgblBolNo;
            string fstrfilter = "fstrCD_BAYANNUMBER:" + strbaynNo + ";" + "fstrCD_BLNUMBER:" + strBLNo + ";";
            lstStatus = objBl.getContainerFilterStatusList(gblRegisteration.strLoginUser, fstrfilter);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            lstFilterStatusData.Clear();
            try
            {
                //var groupedResult = lstStatus.GroupBy(x => new { x.value, x.text }).Select(x => x.Key).ToList();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterStatusData.Add(new ContainerFilterDlList { CmbStatus = lstrCaptionALL });
                if (lstStatus != null && lstStatus.Count > 0)
                {
                    foreach (var dic in lstStatus)
                    {
                        lstFilterStatusData.Add(new ContainerFilterDlList { CmbStatus = dic.text });
                    }
                }
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get DamageFt Data
        /// </summary>
        private async void DamageFtData()
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            string strbaynNo = gblBayan.strgblBaynanNo;
            string strBLNo = gblBol.strgblBolNo;
            string fstrfilter = "fstrCD_BAYANNUMBER:" + strbaynNo + ";" + "fstrCD_BLNUMBER:" + strBLNo + ";";
            lstDamage = objBl.getContainerFtDamageList(gblRegisteration.strLoginUser, fstrfilter, "");
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            try
            {
                var groupedResult = lstDamage.GroupBy(x => new { x.cd_commodity, x.cd_blnumber }).Select(x => x.Key).ToList();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterDamageData.Add(new ContainerFilterDlList { CmbDamage = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterDamageData.Add(new ContainerFilterDlList { CmbDamage = item.cd_commodity });
                }
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Container Header Data
        /// </summary>
        /// <param name="fstrBLNo"></param>
        /// <returns></returns>
        private async Task ContainerHeaderData(string fstrBLNo)
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);

                string fstrFilterData = "";
                string lstrBLNo = "";
                if ((fstrBLNo != null) && (fstrBLNo != null))
                {
                    lstrBLNo = fstrBLNo;
                }
                //BayanNum
                if (lstrBLNo != "")
                {
                    fstrFilterData += "CD_BLNUMBER:" + lstrBLNo + ",";
                }
                lstHeader = objCon.getContainerDetailsHeader(gblRegisteration.strLoginUser, fstrFilterData);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((lstHeader != null) && (lstHeader.Count > 0))
                {
                    lblValBayanNo = lstHeader.ToArray()[0].bl_bayannumber;
                    lblValBlCategory = lstHeader.ToArray()[0].bl_blcategory;
                    lblValConsignee = lstHeader.ToArray()[0].bl_consigneedesc1;

                    string lstrConsigneeName = lstHeader.ToArray()[0].bl_consigneedesc1;
                    if (lstrConsigneeName.Length > 25)
                    {
                        lblValConsignee = lstrConsigneeName.Substring(0, 25);
                    }
                    else
                    {
                        lblValConsignee = lstrConsigneeName;
                    }
                    LblValPod = lstHeader.ToArray()[0].bl_portofdischsrge;
                    LblValPol = lstHeader.ToArray()[0].bl_portofload;
                    LblValShipper = lstHeader.ToArray()[0].bl_shipperdesc1;
                    string lstShipper = lstHeader.ToArray()[0].bl_shipperdesc1; //12-01-2023-Sanduru
                    if (lstShipper.Length > 18)
                    {
                        LblValShipper = lstShipper.Substring(0, 18);
                    }
                    else
                    {
                        LblValShipper = lstShipper;
                    }
                    LblValShippingLine = lstHeader.ToArray()[0].bl_shippingline;
                    ImgHapag = lstHeader.ToArray()[0].bl_shippinglineimage;
                    LblValVesselVisit = lstHeader.ToArray()[0].bl_vesselvisitid;
                    LblValBLNo = lstHeader.ToArray()[0].bl_blnumber;
                }
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Clicked Apply
        /// </summary>
        /// <returns></returns>
        private async Task ClickedApply()
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);
                var strselectedFrightType = "";
                var strselectedSize = "";
                var strselectedAppoinment = "";
                var strselectedGate = "";
                var strselectedStatus = "";
                var strselectedOther = "";
                if (lstFrightFilterData.Count > 0)
                {
                    foreach (var item in lstFrightFilterData)
                    {
                        if (item.isChecked == true)
                        {

                            if (item.CmbFreightType.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstselectedFrightType = lobjpicFreightType.Where(x => x.Key.Contains(item.CmbFreightType)).ToList();

                                strselectedFrightType += lstselectedFrightType[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                if (lstFilterContainerSizeData.Count > 0)
                {
                    foreach (var item in lstFilterContainerSizeData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbContainerSize.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstFilterContainerSizeData = lobjpicContainerSize.Where(x => x.Key.Contains(item.CmbContainerSize)).ToList();
                                strselectedSize += lstFilterContainerSizeData[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                if (lstFilterAppointmentData.Count > 0)
                {
                    foreach (var item in lstFilterAppointmentData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbAppointment.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstFilterAppointmentData = lobjpicAppointment.Where(x => x.Key.Contains(item.CmbAppointment)).ToList();
                                strselectedAppoinment += lstFilterAppointmentData[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                if (lstFilterGateData.Count > 0)
                {
                    foreach (var item in lstFilterGateData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbGate.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstFilterGateData = lobjpicGate.Where(x => x.Key.Contains(item.CmbGate)).ToList();
                                strselectedGate += lstFilterGateData[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                if (lstFilterStatusData.Count > 0)
                {
                    foreach (var item in lstFilterStatusData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbStatus.ToString().ToUpper().Trim() != "ALL")
                            {
                                strselectedStatus += item.CmbStatus + ",";
                            }
                        }
                    }
                }
                if (lstFilterDamageData.Count > 0)
                {
                    foreach (var item in lstFilterDamageData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbDamage.ToString().ToUpper().Trim() != "ALL")
                            {
                                var lstFilterDamageData = lobjpicOthers.Where(x => x.Key.Contains(item.CmbDamage)).ToList();
                                strselectedOther += lstFilterDamageData[0].Value.ToString().Trim() + ",";
                            }
                        }
                    }
                }
                if (strselectedFrightType.Length > 0) strselectedFrightType = strselectedFrightType.Substring(0, strselectedFrightType.Length - 1);
                if (strselectedGate.Length > 0) strselectedGate = strselectedGate.Substring(0, strselectedGate.Length - 1);
                if (strselectedAppoinment.Length > 0) strselectedAppoinment = strselectedAppoinment.Substring(0, strselectedAppoinment.Length - 1);
                if (strselectedSize.Length > 0) strselectedSize = strselectedSize.Substring(0, strselectedSize.Length - 1);
                if (strselectedStatus.Length > 0) strselectedStatus = strselectedStatus.Substring(0, strselectedStatus.Length - 1);
                if (strselectedOther.Length > 0) strselectedOther = strselectedOther.Substring(0, strselectedOther.Length - 1);
                await ContainerData("", strBolNo, strselectedFrightType, strselectedSize, strselectedAppoinment, strselectedGate, strselectedStatus, strselectedOther);
                IsVisibleContainerFilter = false;
                IsVisibleContainerMain = true;
                // App.Current.MainPage?.Navigation.PushAsync(new Containerlist("", strBolNo, strselectedFrightType, strselectedSize, strselectedAppoinment, strselectedGate, strselectedStatus, strselectedOther, ""));
                await Task.Delay(1000);
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }
        /// <summary>
        /// To Get Damage Good
        /// </summary>
        /// <param name="fobjcontainer"></param>
        public async void Damagegood_Clicked(ContainerDt fobjcontainer)
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);

                string strContainerno = fobjcontainer.Containerno;
                string strBolNo = fobjcontainer.Billoflading;
                string strDamageflag = fobjcontainer.Damageflag;
                App.Current.MainPage?.Navigation.PushAsync(new Damagegoodpopup(strContainerno, strBolNo, "N", strDamageflag));
                await Task.Delay(1000);
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Hold Good
        /// </summary>
        /// <param name="fobjContainerunitgkey"></param>
        private async void Holdgood_Clicked(ContainerDt fobjContainerunitgkey)
        {
            try
            {

                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);
                string strContainerunitgkey = fobjContainerunitgkey.Container_unitgkey;
                string fsrtFlag = "Container";
                App.Current.MainPage?.Navigation.PushAsync(new Holdgoodpopup(strContainerunitgkey, fsrtFlag));
                await Task.Delay(1000);
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get Danger Good
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Dangergood_Clicked(object sender, EventArgs e)
        {
            try
            {
                IsBusy = true;
                StackContainerList = false;
                await Task.Delay(1000);
                App.Current.MainPage?.Navigation.PushAsync(new Dangerousgoodpopup());
                await Task.Delay(1000);
                StackContainerList = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Container List Request
        /// </summary>
        /// <param name="fobjcontainer"></param>
        private async void ContainerListRequest(ContainerDt fobjcontainer)
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            gblContainer.strBOL = fobjcontainer.Billoflading;
            gblContainer.strContainer = fobjcontainer.Containerno;
            string strLicenseNo = fobjcontainer.LicenseNo;
            string strRequest = fobjcontainer.fstrRequest;
            App.Current.MainPage?.Navigation.PushAsync(new GatePhotoRequestContList(strLicenseNo, gblContainer.strBOL, gblContainer.strContainer, strRequest));
            StackContainerList = true;
            IsBusy = false;
        }
        /// <summary>
        /// to get container List Inspection Request
        /// </summary>
        /// <param name="fobjcontainer"></param>
        private async void contListInspRequest(ContainerDt fobjcontainer)
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            gblContainer.strBOL = fobjcontainer.Billoflading;
            gblContainer.strContainer = fobjcontainer.Containerno;

            //As Per Client Request to  enable based on customer type
            //User based Screen Restriction handled by Gokul on 20230413
            if ((gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "TRANSPORTER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CONSIGNEE") ||
                   (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "CLEARING AGENT") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPER")
               || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "BROKER") || (gblRegisteration.strLoginCustomerType.ToUpper().Trim() == "SHIPPING LINE"))
            {

                gblContainer.strBOL = fobjcontainer.Billoflading;
                gblContainer.strContainer = fobjcontainer.Containerno;
                string fstrFilter = "fstrBOLNo:" + gblContainer.strBOL + ";" + "fstrContainerNo:" + gblContainer.strContainer + ";";
                var lstcontainerInspectionlist = bl.getInspection("ContainerInspectionImage", gblContainer.strBOL, gblContainer.strContainer);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (lstcontainerInspectionlist.Count == 0)
                {
                    App.Current.MainPage?.Navigation.PushAsync(new ContainerInspectionMsg());
                }
                else
                {
                    App.Current.MainPage?.Navigation.PushAsync(new ContainerInspectionPhoto(gblContainer.strBOL, gblContainer.strContainer));
                }
            }

            StackContainerList = true;
            IsBusy = false;
        }
    }
}
