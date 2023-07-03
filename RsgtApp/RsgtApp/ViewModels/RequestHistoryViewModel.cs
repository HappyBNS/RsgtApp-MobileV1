using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
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
using static RsgtApp.Models.TicketsListModel;

namespace RsgtApp.ViewModels
{
    public class RequestHistoryViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private List<InfoItem> objCMSDtail = new List<InfoItem>();
        public List<ExtraCareDt> lstTicketLst = new List<ExtraCareDt>();

        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();

       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;

        private BLConnect objCon = new BLConnect();
        private BLConnect objBl = new BLConnect();

        string lstrCaptionALL = "";
        public string fstrFilter { get; set; }
        public string fstrTitle { get; set; }
        public string fstrRegisterUsercode { get; set; }
        public string fstrTicketNumber { get; set; }
        public string Ticketdetails { get; set; }
        public ObservableCollection<ExtraCareDt> lstTicketlist { get; set; } = new ObservableCollection<ExtraCareDt>();
        //go to Clicked gotoLoadMore
        public Command gotoLoadMore { get; set; }
        //go to Clicked SearchClicked
        public Command SearchClicked { get; set; }
        //go to Clicked FilterClicked
        public Command FilterClicked { get; set; }
        //go to Clicked ButtonClickedApply
        public Command ButtonClickedApply { get; set; }
        //go to Clicked ButtonClickedCancel
        public Command ButtonClickedCancel { get; set; }
        //go to Clicked ButtonClicked
        public Command ButtonClicked { get; set; }

        //go to Clicked ButtonClicked
        public Command ButtonRequestHistory { get; set; }
        public Command ButtonReset { get; set; }
        int fintPageNumbers = 1;
        int fintPageSize = 1000;
        string lblSno = "";
        public int intTotalCount { get; set; }
        string lblbtnMoreDetail = "";
        string strNoRecord = "";
        private string strTotalCaption = "";
        //To Declare Count Variable
        private int totalRecordCount = 0;

        string lstrINQueue = "";


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

        // Twowaybinding  IndicatorViewBGColor process on Propertychange Event
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorViewOpacity");

            }
        }
        // Twowaybinding  IndicatorViewOpacity process on Propertychange Event
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

        //TotalRecordCount
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

        //Ticket Details
        private string imgTicketIcon = "";
        public string ImgTicketIcon
        {
            get { return imgTicketIcon; }
            set
            {
                imgTicketIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTicketIcon");
            }
        }

        //To binding lblTicketDetail variable
        private string lblTicketDetail = "";
        public string LblTicketDetail
        {
            get { return lblTicketDetail; }
            set
            {
                lblTicketDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTicketDetail");
            }
        }
        //To binding LblTicketno variable
        private string lblTicketno = "";
        public string LblTicketno
        {
            get { return lblTicketno; }
            set
            {
                lblTicketno = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTicketno");
            }
        }
        //To binding LblCase variable
        private string lblCase = "";
        public string LblCase
        {
            get { return lblCase; }
            set
            {
                lblCase = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCase");
            }
        }

        //To binding Lblcasetype variable
        private string lblcasetype = "";
        public string Lblcasetype
        {
            get { return lblcasetype; }
            set
            {
                lblcasetype = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblcasetype");
            }
        }

        //To binding LblStatusDetail variable
        private string lblStatusDetail = "";
        public string LblStatusDetail
        {
            get { return lblStatusDetail; }
            set
            {
                lblStatusDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("LblStatusDetail");
            }
        }


        //To binding LblCreatedOn variable
        private string lblCreatedOn = "";
        public string LblCreatedOn
        {
            get { return lblCreatedOn; }
            set
            {
                lblCreatedOn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCreatedOn");
            }
        }

        //To binding LblCreatedondate variable
        private string lblCreatedondate = "";
        public string LblCreatedondate
        {
            get { return lblCreatedondate; }
            set
            {
                lblCreatedondate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCreatedondate");
            }
        }


        //To binding Lblcompleteon variable
        private string lblcompleteon = "";
        public string Lblcompleteon
        {
            get { return lblcompleteon; }
            set
            {
                lblcompleteon = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblcompleteon");
            }
        }
        //To binding Lblcompleteondate variable
        private string lblcompleteondate = "";
        public string Lblcompleteondate
        {
            get { return lblcompleteondate; }
            set
            {
                lblcompleteondate = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblcompleteondate");
            }
        }
        //To binding LblMmessageheading variable
        private string lblMmessageheading = "";
        public string LblMmessageheading
        {
            get { return lblMmessageheading; }
            set
            {
                lblMmessageheading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMmessageheading");
            }
        }
        //To binding ImgMbellicon variable
        private string imgMbellicon = "";
        public string ImgMbellicon
        {
            get { return imgMbellicon; }
            set
            {
                imgMbellicon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgMbellicon");
            }
        }
        //To binding MMessagetime variable
        private string mMessagetime = "";
        public string MMessagetime
        {
            get { return mMessagetime; }
            set
            {
                mMessagetime = value;
                OnPropertyChanged();
                RaisePropertyChange("MMessagetime");
            }
        }
        //To binding MMessageinfo variable
        private string mMessageinfo = "";
        public string MMessageinfo
        {
            get { return mMessageinfo; }
            set
            {
                mMessageinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("MMessageinfo");
            }
        }
        //To binding LblAttachmentDetail variable
        private string lblAttachmentDetail = "";
        public string LblAttachmentDetail
        {
            get { return lblAttachmentDetail; }
            set
            {
                lblAttachmentDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAttachmentDetail");
            }
        }

        //To binding ImgattachiconDetail variable
        private string imgattachiconDetail = "";
        public string ImgattachiconDetail
        {
            get { return imgattachiconDetail; }
            set
            {
                imgattachiconDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgattachiconDetail");
            }
        }

        // Ticket Filter
        //To binding ImgFilterBlue variable
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
        //To binding LblFilters variable
        private string lblFilters = "";
        public string LblFilters
        {
            get { return lblFilters; }
            set
            {
                lblFilters = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFilters");
            }
        }
        //To binding BtnApply variable
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
        //To binding ImgReset variable
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
        //To binding LblStatusFilter variable
        private string lblStatusFilter = "";
        public string LblStatusFilter
        {
            get { return lblStatusFilter; }
            set
            {
                lblStatusFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("LblStatusFilter");
            }
        }
        //To binding ImgDownArrow1 variable
        private string imgDownArrow1 = "";
        public string ImgDownArrow1
        {
            get { return imgDownArrow1; }
            set
            {
                imgDownArrow1 = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDownArrow1");
            }
        }
        //To binding LblCategory variable
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
        //To binding ImgDownArrow2 variable
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
        //To binding LblType variable
        private string lblType = "";
        public string LblType
        {
            get { return lblType; }
            set
            {
                lblType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblType");
            }
        }
        //To binding ImgDownArrow3 variable
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
        //To binding LblTicket variable
        private string lblTicket = "";
        public string LblTicket
        {
            get { return lblTicket; }
            set
            {
                lblTicket = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTicket");
            }
        }

        //Ticket_Reply
        //To binding ImgRequestmenu variable

        private string imgRequestmenu = "";
        public string ImgRequestmenu
        {
            get { return imgRequestmenu; }
            set
            {
                imgRequestmenu = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRequestmenu");
            }
        }
        //To binding LblReply variable
        private string lblReply = "";
        public string LblReply
        {
            get { return lblReply; }
            set
            {
                lblReply = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReply");
            }
        }
        //To binding LblMessage variable
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
        //To binding LblMessage variable
        private string lblAttach = "";
        public string LblAttach
        {
            get { return lblAttach; }
            set
            {
                lblAttach = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAttach");
            }
        }
        //To binding BtnChoose variable
        private string btnChoose = "";
        public string BtnChoose
        {
            get { return btnChoose; }
            set
            {
                btnChoose = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnChoose");
            }
        }
        //To binding BtnSubmit variable
        private string btnSubmit = "";
        public string BtnSubmit
        {
            get { return btnSubmit; }
            set
            {
                btnSubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnSubmit");
            }
        }

        //To binding ImgRequestsService variable
        private string imgRequestsService = "";
        public string ImgRequestsService
        {
            get { return imgRequestsService; }
            set
            {
                imgRequestsService = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRequestsService");
            }
        }
        //To binding Lblcomplaint variable
        private string lblcomplaint = "";
        public string Lblcomplaint
        {
            get { return lblcomplaint; }
            set
            {
                lblcomplaint = value;
                OnPropertyChanged();
                RaisePropertyChange("Lblcomplaint");
            }
        }
        //To binding Lblcomplaint variable
        private string lblTitle = "";
        public string LblTitle
        {
            get { return lblTitle; }
            set
            {
                lblTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTitle");
            }
        }
        //To binding TxtTitle1 variable
        private string txtTitle1 = "";
        public string TxtTitle1
        {
            get { return txtTitle1; }
            set
            {
                txtTitle1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTitle1");
            }
        }
        //To binding MsgTitle variable
        private string msgTitle = "";
        public string MsgTitle
        {
            get { return msgTitle; }
            set
            {
                msgTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTitle");
            }
        }
        //To binding LblCaseType variable
        private string lblCaseType = "";
        public string LblCaseType
        {
            get { return lblCaseType; }
            set
            {
                lblCaseType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseType");
            }
        }
        //To binding PicCaseType1 variable
        private string picCaseType1 = "";
        public string PicCaseType1
        {
            get { return picCaseType1; }
            set
            {
                picCaseType1 = value;
                OnPropertyChanged();
                RaisePropertyChange("PicCaseType1");
            }
        }
        //To binding MsgCase variable
        private string msgCase = "";
        public string MsgCase
        {
            get { return msgCase; }
            set
            {
                msgCase = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCase");
            }
        }
        //To binding LblCaseSubType variable
        private string lblCaseSubType = "";
        public string LblCaseSubType
        {
            get { return lblCaseSubType; }
            set
            {
                lblCaseSubType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseSubType");
            }
        }
        //To binding PicSubType1 variable
        private string picSubType1 = "";
        public string PicSubType1
        {
            get { return picSubType1; }
            set
            {
                picSubType1 = value;
                OnPropertyChanged();
                RaisePropertyChange("PicSubType1");
            }
        }
        //To binding MsgCaseSubType variable
        private string msgCaseSubType = "";
        public string MsgCaseSubType
        {
            get { return msgCaseSubType; }
            set
            {
                msgCaseSubType = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCaseSubType");
            }
        }
        //To binding LblMessageReply variable
        private string lblMessageReply = "";
        public string LblMessageReply
        {
            get { return lblMessageReply; }
            set
            {
                lblMessageReply = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessageReply");
            }
        }
        //To binding TxtMessage variable
        private string txtMessage = "";
        public string TxtMessage
        {
            get { return txtMessage; }
            set
            {
                txtMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtMessage");
            }
        }
        //To binding BtnAttach variable
        private string btnAttach = "";
        public string BtnAttach
        {
            get { return btnAttach; }
            set
            {
                btnAttach = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnAttach");
            }
        }
        //To binding BtnChooseFile variable
        private string btnChooseFile = "";
        public string BtnChooseFile
        {
            get { return btnChooseFile; }
            set
            {
                btnChooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnChooseFile");
            }
        }
        //To binding ImgCancel variable
        private string imgCancel = "";
        public string ImgCancel
        {
            get { return imgCancel; }
            set
            {
                imgCancel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCancel");
            }
        }
        //To binding LblFilename variable
        private string lblFilename = "";
        public string LblFilename
        {
            get { return lblFilename; }
            set
            {
                lblFilename = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFilename");
            }
        }
        //To binding BtnSubmitReply variable
        private string btnSubmitReply = "";
        public string BtnSubmitReply
        {
            get { return btnSubmitReply; }
            set
            {
                btnSubmitReply = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnSubmitReply");
            }
        }

        //To binding Imginfodark variable
        private string imginfodark = "";
        public string Imginfodark
        {
            get { return imginfodark; }
            set
            {
                imginfodark = value;
                OnPropertyChanged();
                RaisePropertyChange("Imginfodark");
            }
        }
        //To binding LblReqinfo variable
        private string lblReqinfo = "";
        public string LblReqinfo
        {
            get { return lblReqinfo; }
            set
            {
                lblReqinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblReqinfo");
            }
        }
        //To binding LblTitles variable
        private string lblTitles = "";
        public string LblTitles
        {
            get { return lblTitles; }
            set
            {
                lblTitles = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTitles");
            }
        }
        //To binding TxtTitle2 variable
        private string txtTitle2 = "";
        public string TxtTitle2
        {
            get { return txtTitle2; }
            set
            {
                txtTitle2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTitle2");
            }
        }
        //To binding LblCaseTypes variable
        private string lblCaseTypes = "";
        public string LblCaseTypes
        {
            get { return lblCaseTypes; }
            set
            {
                lblCaseTypes = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseTypes");
            }
        }
        //To binding PicCaseTypes2 variable
        private string picCaseTypes2 = "";
        public string PicCaseTypes2
        {
            get { return picCaseTypes2; }
            set
            {
                picCaseTypes2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PicCaseTypes2");
            }
        }

        //To binding LblCaseSubTypes variable

        private string lblCaseSubTypes = "";
        public string LblCaseSubTypes
        {
            get { return lblCaseSubTypes; }
            set
            {
                lblCaseSubTypes = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseSubTypes");
            }
        }
        //To binding PicSubTypes2 variable
        private string picSubTypes2 = "";
        public string PicSubTypes2
        {
            get { return picSubTypes2; }
            set
            {
                picSubTypes2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PicSubTypes2");
            }
        }

        //To binding LblMessages variable
        private string lblMessages = "";
        public string LblMessages
        {
            get { return lblMessages; }
            set
            {
                lblMessages = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessages");
            }
        }
        //To binding MsgMessage variable
        private string msgMessage = "";
        public string MsgMessage
        {
            get { return msgMessage; }
            set
            {
                msgMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMessage");
            }
        }
        //To binding LblAttachment variable

        private string lblAttachment = "";
        public string LblAttachment
        {
            get { return lblAttachment; }
            set
            {
                lblAttachment = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAttachment");
            }
        }

        //To binding ImgTicketIcondark variable

        //Request_TicketList
        private string imgTicketIcondark = "";
        public string ImgTicketIcondark
        {
            get { return imgTicketIcondark; }
            set
            {
                imgTicketIcondark = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTicketIcondark");
            }
        }
        //To binding LblTickets variable
        private string lblTickets = "";
        public string LblTickets
        {
            get { return lblTickets; }
            set
            {
                lblTickets = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTickets");
            }
        }

        //To binding  searchbox  variable
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

        //To binding  TxtSearch  variable
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
        //To binding  ImgSearch  variable
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
        //To binding  ImgFilter  variable
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
        //To binding  Ticketdetailinfo  variable
        private string ticketdetailinfo = "";
        public string Ticketdetailinfo
        {
            get { return ticketdetailinfo; }
            set
            {
                ticketdetailinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("Ticketdetailinfo");
            }
        }
        //To binding  LblTicketNo  variable
        private string lblTicketNo = "";
        public string LblTicketNo
        {
            get { return lblTicketNo; }
            set
            {
                lblTicketNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTicketNo");
            }
        }
        //To binding  TicketNo  variable
        private string ticketNo = "";
        public string TicketNo
        {
            get { return ticketNo; }
            set
            {
                ticketNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TicketNo");
            }
        }
        //To binding  LblStatus  variable
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
        //To binding  Status  variable
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
        //To binding  LblCasetitle1  variable
        private string lblCasetitle1 = "";
        public string LblCasetitle1
        {
            get { return lblCasetitle1; }
            set
            {
                lblCasetitle1 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCasetitle1");
            }
        }
        //To binding  Casetitle  variable
        private string casetitle = "";
        public string Casetitle
        {
            get { return casetitle; }
            set
            {
                casetitle = value;
                OnPropertyChanged();
                RaisePropertyChange("Casetitle");
            }
        }
        //To binding  LblCategoryRequestList  variable
        private string lblCategoryRequestList = "";
        public string LblCategoryRequestList
        {
            get { return lblCategoryRequestList; }
            set
            {
                lblCategoryRequestList = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCategoryRequestList");
            }
        }
        //To binding  Category variable
        private string category = "";
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged();
                RaisePropertyChange("Category");
            }
        }
        //To binding  LblCaseTypeRequestList variable
        private string lblCaseTypeRequestList = "";
        public string LblCaseTypeRequestList
        {
            get { return lblCaseTypeRequestList; }
            set
            {
                lblCaseTypeRequestList = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCaseTypeRequestList");
            }
        }
        //To binding  CaseType variable
        private string caseType = "";
        public string CaseType
        {
            get { return caseType; }
            set
            {
                caseType = value;
                OnPropertyChanged();
                RaisePropertyChange("CaseType");
            }
        }
        //To binding  LblSubType variable
        private string lblSubType = "";
        public string LblSubType
        {
            get { return lblSubType; }
            set
            {
                lblSubType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSubType");
            }
        }
        //To binding  SubType variable
        private string subType = "";
        public string SubType
        {
            get { return subType; }
            set
            {
                subType = value;
                OnPropertyChanged();
                RaisePropertyChange("SubType");
            }
        }
        //To binding  LblOrigin variable
        private string lblOrigin = "";
        public string LblOrigin
        {
            get { return lblOrigin; }
            set
            {
                lblOrigin = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOrigin");
            }
        }
        //To binding  Origin variable
        private string origin = "";
        public string Origin
        {
            get { return origin; }
            set
            {
                origin = value;
                OnPropertyChanged();
                RaisePropertyChange("Origin");
            }
        }
        //To binding  CreatedOn variable
        private string createdOn = "";
        public string CreatedOn
        {
            get { return createdOn; }
            set
            {
                createdOn = value;
                OnPropertyChanged();
                RaisePropertyChange("CreatedOn");
            }
        }
        //To binding  LblCompletedOn variable
        private string lblCompletedOn = "";
        public string LblCompletedOn
        {
            get { return lblCompletedOn; }
            set
            {
                lblCompletedOn = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCompletedOn");
            }
        }
        //To binding  CompletedOn variable
        private string completedOn = "";
        public string CompletedOn
        {
            get { return completedOn; }
            set
            {
                completedOn = value;
                OnPropertyChanged();
                RaisePropertyChange("CompletedOn");
            }
        }
        //To binding  StrtiCketStatus variable
        private string strtiCketStatus = "";
        public string StrtiCketStatus
        {
            get { return strtiCketStatus; }
            set
            {
                strtiCketStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("StrtiCketStatus");
            }
        }
        //To binding  CompletedON variable
        private string completedON = "";
        public string CompletedON
        {
            get { return completedON; }
            set
            {
                completedON = value;
                OnPropertyChanged();
                RaisePropertyChange("CompletedON");
            }
        }
        //To binding  StatusCode variable
        private string statusCode = "";
        public string StatusCode
        {
            get { return statusCode; }
            set
            {
                statusCode = value;
                OnPropertyChanged();
                RaisePropertyChange("StatusCode");
            }
        }
        //To binding  StatusColor variable
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

        //To binding  Casegkey variable
        private string casegkey = "";
        public string Casegkey
        {
            get { return casegkey; }
            set
            {
                casegkey = value;
                OnPropertyChanged();
                RaisePropertyChange("Casegkey");
            }
        }

        //To binding  BtnLoadMore variable
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

        //To binding  EnumStatus variable
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

        //To binding  EnumCategory variable

        private string enumCategory = "";
        public string EnumCategory
        {
            get { return enumCategory; }
            set
            {
                enumCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumCategory");
            }
        }
        //To binding  EnumCasetype variable
        private string enumCasetype = "";
        public string EnumCasetype
        {
            get { return enumCasetype; }
            set
            {
                enumCasetype = value;
                OnPropertyChanged();
                RaisePropertyChange("EnumCasetype");
            }
        }
        private bool isVisibleRequestMain = false;
        public bool IsVisibleRequestMain
        {
            get { return isVisibleRequestMain; }
            set
            {
                isVisibleRequestMain = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleRequestMain");
            }
        }


        private bool isVisibleRequestFilter = false;
        public bool IsVisibleRequestFilter
        {
            get { return isVisibleRequestFilter; }
            set
            {
                isVisibleRequestFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleRequestFilter");
            }
        }
        //To binding  TxtTicketNo variable
        private string txtTicketNo = "";
        public string TxtTicketNo
        {
            get { return txtTicketNo; }
            set
            {
                txtTicketNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTicketNo");
            }
        }
        //To binding  PlaceTicketNo variable
        private string placeTicketNo = "";
        public string PlaceTicketNo
        {
            get { return placeTicketNo; }
            set
            {
                placeTicketNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceTicketNo");
            }
        }

        //To binding  Imgattachicon variable
        private string imgattachicon = "";
        public string Imgattachicon
        {
            get { return imgattachicon; }
            set
            {
                imgattachicon = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgattachicon");
            }
        }
        bool enticket = true;
        public bool Enticket
        {
            get { return enticket; }
            set
            {
                enticket = value;

                OnPropertyChanged();
                RaisePropertyChange("Enticket");
            }
        }

        private string btnQuotation = "";
        public string Btnquotation
        {
            get { return btnQuotation; }
            set
            {
                btnQuotation = value;
                OnPropertyChanged();
                RaisePropertyChange("Btnquotation");
            }
        }
        private string imgrequestHistory = "";
        public string imgRequestHistory
        {
            get { return imgrequestHistory; }
            set
            {
                imgrequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRequestHistory");
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
        private bool isvisiblerequestImage = true;
        public bool IsvisibleRequestImage
        {
            get { return isvisiblerequestImage; }
            set
            {
                isvisiblerequestImage = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleRequestImage");
            }
        }
        private bool isvisibleRequestHistory = true;
        public bool IsvisibleRequestHistory
        {
            get { return isvisibleRequestHistory; }
            set
            {
                isvisibleRequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleRequestHistory");
            }
        }
        private string strselectedStatus = "";
        public string StrselectedStatus
        {
            get { return strselectedStatus; }
            set
            {
                strselectedStatus = value;
                OnPropertyChanged();
                RaisePropertyChange("StrselectedStatus");
            }
        }


        private string strselectedcategory = "";
        public string Strselectedcategory
        {
            get { return strselectedcategory; }
            set
            {
                strselectedcategory = value;
                OnPropertyChanged();
                RaisePropertyChange("Strselectedcategory");
            }
        }

        private string strselectedtype = "";
        public string Strselectedtype
        {
            get { return strselectedtype; }
            set
            {
                strselectedtype = value;
                OnPropertyChanged();
                RaisePropertyChange("Strselectedtype");
            }
        }

        private string strTicketNo = "";
        public string StrTicketNo
        {
            get { return strTicketNo; }
            set
            {
                strTicketNo = value;
                OnPropertyChanged();
                RaisePropertyChange("StrTicketNo");
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
        //To handle Bool in Expander
        private bool _isExpandedStatus = false;
        public bool IsExpandedStatus
        {
            get { return _isExpandedStatus; }
            set { SetProperty(ref _isExpandedStatus, value); }
        }

        //To handle Bool in Expander
        private bool _isExpandedCategory = false;
        public bool IsExpandedCategory
        {
            get { return _isExpandedCategory; }
            set { SetProperty(ref _isExpandedCategory, value); }
        }

        //To handle Bool in Expander
        private bool _isExpandedType = false;
        public bool IsExpandedType
        {
            get { return _isExpandedType; }
            set { SetProperty(ref _isExpandedType, value); }
        }


        ContentPage Myview;
        public System.Windows.Input.ICommand ButtonQuotation => new Command<ExtraCareDt>(BtnQuotation);
        string lstrScreenFlag = "";
        List<clsTICKETSSTATUSFILTER> lstStatus = new List<clsTICKETSSTATUSFILTER>();
        public ObservableCollection<TicketFilterDlList> lstFilterStatusData { get; set; } = new ObservableCollection<TicketFilterDlList>();
        List<ClsTICKETSCATEGORYFILTER> lstCategory = new List<ClsTICKETSCATEGORYFILTER>();
        public ObservableCollection<TicketFilterDlList> lstFilterCategoryData { get; set; } = new ObservableCollection<TicketFilterDlList>();
        List<clsTICKETSTYPEFILTER> lsttype = new List<clsTICKETSTYPEFILTER>();
        public ObservableCollection<TicketFilterDlList> lstFiltertypeData { get; set; } = new ObservableCollection<TicketFilterDlList>();


        private string strServerSlowMsg = "";
        //To Declare Indicator
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();

                FilterClicked.ChangeCanExecute();
                gotoLoadMore.ChangeCanExecute();
                SearchClicked.ChangeCanExecute();
                ButtonClickedApply.ChangeCanExecute();
                ButtonClickedCancel.ChangeCanExecute();
                ButtonReset.ChangeCanExecute();
                ButtonRequestHistory.ChangeCanExecute();

            }
        }

        //Begin Ticket list view model function
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public RequestHistoryViewModel(string strSearchbox, string strselectedStatus, string strselectedcategory, string strselectedtype, string strTicketNo, string fstrScreenFlag, ContentPage view)
        {
            try
            {
                Analytics.TrackEvent("RequestHistoryViewModel");
                Myview = view;
                lstrScreenFlag = fstrScreenFlag;
                strTotalCaption = "";
                searchbox = strSearchbox;
                IsVisibleRequestMain = false;
                IsVisibleRequestFilter = false;
                lstTicketlist = new ObservableCollection<ExtraCareDt>();
                ButtonClicked = new Command(async () => await Button_Clicked(), () => !IsBusy);
                FilterClicked = new Command(async () => await TickeFilter(), () => !IsBusy);
                gotoLoadMore = new Command(async () => await TicketsData(strSearchbox, strselectedStatus, strselectedcategory, strselectedtype, strTicketNo), () => !IsBusy);
                SearchClicked = new Command(async () => await Tickesearch(), () => !IsBusy);
                ButtonClickedApply = new Command(async () => await Button_ClickedApply(), () => !IsBusy);
                ButtonClickedCancel = new Command(async () => await clear(), () => !IsBusy);
                ButtonRequestHistory = new Command(async () => await buttonRequestHistory(), () => !IsBusy);
                ButtonReset = new Command(async () => await clear(), () => !IsBusy);
                //To Call Caption Function           
                Task.Run(() => assignCms()).Wait();
                //End-Call Listview GetData Funtions
                Task.Run(() => StatusFilterData()).Wait();
                Task.Run(() => CategoryFilterData()).Wait();
                Task.Run(() => typeFilterData()).Wait();

                //Begin-Call Listview GetData Funtion
                Task.Run(() => TicketsData(strSearchbox, strselectedStatus, strselectedcategory, strselectedtype, strTicketNo)).Wait();
                IsVisibleRequestMain = true;
                IsVisibleRequestFilter = false;
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End Ticket list view model function

        /// <summary>
		/// To Get Rest Data 
		/// </summary>
        public async Task clear()
        {
            Enticket = false;
            IsBusy = true;
            await Task.Delay(1000);
            IsVisibleRequestMain = true;
            IsVisibleRequestFilter = false;
            await TicketsData("", "", "", "", "");
            await StatusFilterData();
            await CategoryFilterData();
            await typeFilterData();
            IsExpandedCategory = false;
            IsExpandedStatus = false;
            IsExpandedType = false;
            TxtTicketNo = "";
           
            // App.Current.MainPage?.Navigation.PushAsync(new Request_TicketsList("", "", "", "", "", "N"));
            Enticket = true;
            IsBusy = false;
        }

        // To Click the Filter Page
        /// <summary>
        /// To Navigate Filter Page 
        /// </summary>
        public async Task TickeFilter()
        {
            try
            {
                Enticket = false;
                IsBusy = true;
                await Task.Delay(1000);
                IsVisibleRequestMain = false;
                IsVisibleRequestFilter = true;
                //Application.Current.MainPage?.Navigation.PushAsync(new Ticket_Filter());
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            Enticket = true;
            IsBusy = false;
        }
        /// <summary>
        ///To Click the Anywhere search
        /// </summary>
        public async Task Tickesearch()
        {
            Enticket = false;
            IsBusy = true;
            await Task.Delay(1000);

            try
            {
                await TicketsData(Searchbox, "", "", "", "");
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            Enticket = true;
            IsBusy = false;
        }


        /// <summary>
        ///To binding the data in get value in database 
        /// </summary>
        public async Task TicketsData(string strSearchbox, string strselectedStatus, string strselectedcategory, string strselectedtype, string strTicketNo)
        {
            try
            {
                string fstrAnywhere = "";
                string fstrCasetype = "";
                string fstrCategory = "";
                string fstrStatus = "";
                if (strSearchbox != null) fstrAnywhere = strSearchbox;
                if (strselectedStatus != null) fstrStatus = strselectedStatus;
                if (strselectedcategory != null) fstrCategory = strselectedcategory;
                if (strselectedtype != null) fstrCasetype = strselectedtype;
                fstrAnywhere = fstrAnywhere.Replace("&", "%26");

                string fstrFilter = "fstrAnyWordSearch:" + fstrAnywhere + ";" + "fstrTicketNumer:" + strTicketNo + ";" + "fstrTickettype:" + fstrCasetype + ";" + "fstrCategory:" + fstrCategory + ";" + "fstrStatus:" + fstrStatus + ";";
                // &fstrFilter = fstrAnyWordSearch:; fstrTicketNumer:; fstrTickettype:; fstrCategory:; fstrStatus:;
                var objRawData = new List<ExtraCareDt>();
                fstrRegisterUsercode = gblRegisteration.strContactGkeyCRM;
                lstTicketlist.Clear();
                objRawData = objCon.getExtraCare(fstrRegisterUsercode, lstrScreenFlag, fintPageNumbers, fintPageSize, "", fstrFilter);
                //Web Api Timeout
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                foreach (var item in objRawData)
                {

                    item.lblSno = lblSno;
                    item.lblTicketNo = lblTicketNo;
                    item.lblStatus = lblStatus;
                    item.lblCasetitle1 = lblCasetitle1;
                    item.lblCategory = lblCategory;
                    item.lblCaseType = lblCaseType;
                    item.lblSubType = lblSubType;
                    item.lblOrigin = lblOrigin;
                    item.lblCreatedOn = lblCreatedOn;
                    item.lblCompletedOn = lblCompletedOn;
                    item.btnMoreDetail = lblbtnMoreDetail;
                    strtiCketStatus = item.Status;
                    item.lblQuotation = Btnquotation;
                    //20230518
                    item.IsVisibleQuotation = false;
                    item.BtnactioncaptionGI = false;
                    if (lstrScreenFlag == "OOG")
                    {
                   
                    if ((item.CT_CATEGORYOFCARGO != "") && (item.CT_CATEGORYOFCARGO != null))
                    {
                        item.IsVisibleQuotation = true;
                        item.BtnactioncaptionGI = true;
                    }
                    }


                    if (item.Status == null || item.Status == "")
                    {
                        item.Status = dbLayer.getCaption("strInQueue", objCMS);
                        item.AnywhereAll += item.Status;
                    }
                   // lstTicketlist.Add(item);
                }
                lstTicketlist = new ObservableCollection<ExtraCareDt>(objRawData);
                totalRecordCount = objRawData.Count;
                TotalRecordCount = lblTicket + " (" + totalRecordCount + ")";
                if (lstTicketlist.Count() > 0)
                {
                    CollectionView cvRequesthistory = Myview.FindByName<CollectionView>("GridRequesthistory");
                    cvRequesthistory.ItemsSource = null;
                    cvRequesthistory.ItemsSource = lstTicketlist;
                    cvRequesthistory.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                }
               
                if (lstTicketlist == null || lstTicketlist.Count == 0)
                {
                  App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async Task assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM462");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM462");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                    objCMSDtail = await dbLayer.LoadContent("RM441");

                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM441");
                await assignContent();

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End assignCms function

        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async Task assignContent()
        {

            try
            {
                await Task.Delay(1000);
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}

              
                dbLayer.objInfoitems = objCMS;

                // Request_TicketList
                imgTicketIcondark = dbLayer.getCaption("imgticketIcondark", objCMS);

                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                txtSearch = dbLayer.getCaption("strTicketNo", objCMS) + "/" + dbLayer.getCaption("strStatus", objCMS) + "/" + dbLayer.getCaption("strCaseTitle", objCMS) + "/" + dbLayer.getCaption("strCategory", objCMS) + "/" + dbLayer.getCaption("strCaseType", objCMS) + "/" + dbLayer.getCaption("strSubType", objCMS) + "/" + dbLayer.getCaption("strOrigin", objCMS);
                lstrINQueue = dbLayer.getCaption("strInQueue", objCMS);
                strTotalCaption = dbLayer.getCaption("strTicketList", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblTicketNo = dbLayer.getCaption("strTicketNo", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                lblCasetitle1 = dbLayer.getCaption("strCaseTitle", objCMS);
                lblCategory = dbLayer.getCaption("strCategory", objCMS);
                lblCaseType = dbLayer.getCaption("strCaseType", objCMS);
                lblSubType = dbLayer.getCaption("strSubType", objCMS);
                lblOrigin = dbLayer.getCaption("strOrigin", objCMS);
                lblCreatedOn = dbLayer.getCaption("strCreatedOn", objCMS);
                lblCompletedOn = dbLayer.getCaption("strCompletedOn", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                Btnquotation = dbLayer.getCaption("strQUOTATION", objCMS);

                imgFilterBlue = dbLayer.getCaption("imgFilters", objCMS);
                lblFilters = dbLayer.getCaption("strFilters", objCMS);
                btnApply = dbLayer.getCaption("strApply", objCMS);
                imgReset = dbLayer.getCaption("imgReset", objCMS);
                lblStatus = dbLayer.getCaption("strFilterStatus", objCMS);
                imgDownArrow1 = dbLayer.getCaption("imgDownArrow", objCMS);
                imgDownArrow2 = dbLayer.getCaption("imgDownArrow", objCMS);
                imgDownArrow3 = dbLayer.getCaption("imgDownArrow", objCMS);
                lblTicket = dbLayer.getCaption("strTicketNo", objCMS);
                PlaceTicketNo = dbLayer.getCaption("strTicketNo", objCMS);
                lblType = dbLayer.getCaption("strType", objCMS);
                lblCategory = dbLayer.getCaption("strCategory", objCMS);
                lstrCaptionALL = dbLayer.getCaption("strAll", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
               // lobjcategory = dbLayer.getLOV("strcategorylov", objCMSDtail);


                if (lstrScreenFlag == "Extra Care & Hot Shipment")
                {
                    lblTicket = dbLayer.getCaption("strExtraCareRequests", objCMS);
                    imgRequestHistory = dbLayer.getCaption("imgExtracareicon", objCMS);
                    lblRequestHistory = dbLayer.getCaption("strExtraCareRequest", objCMS);
                }
                if (lstrScreenFlag == "Manifest Confirmation")
                {
                    lblTicket = dbLayer.getCaption("strManifestRequestsHistory", objCMS);
                    imgRequestHistory = dbLayer.getCaption("imgManifest", objCMS);
                    lblRequestHistory = dbLayer.getCaption("strManifestUpdateRequest", objCMS);
                }
                if (lstrScreenFlag == "Offload")
                {
                    lblTicket = dbLayer.getCaption("strOffloadRequests", objCMS);
                    imgRequestHistory = dbLayer.getCaption("imgOffloadicon", objCMS);
                    lblRequestHistory = dbLayer.getCaption("strOffloadRequest", objCMS);
                }
                if (lstrScreenFlag == "Direct Delivery")
                {
                    lblTicket = dbLayer.getCaption("strDirectDeliveryRequests", objCMS);
                    imgRequestHistory = dbLayer.getCaption("imgDDLicon", objCMS);
                    lblRequestHistory = dbLayer.getCaption("strDirectDeliveryRequest", objCMS);
                }
                if (lstrScreenFlag == "Attend Inspection")
                {
                    lblTicket = dbLayer.getCaption("strAttendInspectionRequests", objCMS);
                    imgRequestHistory = dbLayer.getCaption("imgvisitor", objCMS);
                    lblRequestHistory = dbLayer.getCaption("strAttendInspectionRequest", objCMS);
                }
                if (lstrScreenFlag == "Equipment Not Available in Location")
                {
                    lblTicket = dbLayer.getCaption("strInlocationEquipment", objCMS);
                    imgRequestHistory = dbLayer.getCaption("imgEquipment", objCMS);
                    lblRequestHistory = dbLayer.getCaption("strInLocationEquipmentRequest", objCMS);
                }

                if (lstrScreenFlag == "OOG")
                {

                    lblTicket = dbLayer.getCaption("strOOGBreakbulk", objCMS);
                    imgRequestHistory = dbLayer.getCaption("imgEquipment", objCMS);
                    lblRequestHistory = dbLayer.getCaption("strOOGBreakbulk", objCMS);
                }

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }

        }
        //End assignContent function
        /// <summary>
		/// To fetch StatusFilterData
		/// </summary>
        private async Task StatusFilterData()
        {
            try
            {

                await Task.Delay(1000);
                lstStatus = objBl.getTicketsStatusFilter();
                lstFilterStatusData.Clear();
                var groupedResult = from s in lstStatus
                                    group s by s.ct_statusdesc1;


               // lstFilterStatusData.Add(new TicketFilterDlList { CmbStatus = lstrCaptionALL });

                foreach (var item in groupedResult)
                {
                    lstFilterStatusData.Add(new TicketFilterDlList { CmbStatus = item.Key }); ;
                }
            }


            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// To fetch CategoryFilterData
        /// </summary>
        private async Task CategoryFilterData()
        {
            try
            {


                //            SELECT DISTINCT ISNULL(CT_CASETYPECODE, '') AS CT_CASETYPECODE, ISNULL(CT_CASETYPEDESC1, '') AS CT_CASETYPEDESC1, ISNULL(CT_CASETYPEDESC2, '') AS CT_CASETYPEDESC2 FROM CRMTICKETS WHERE CT_CASETYPECODE<>''

                //SELECT DISTINCT ISNULL(CT_CATEGORYCODE, '') AS CT_CATEGORYCODE, ISNULL(CT_CATEGORYDESC1, '') AS CT_CATEGORYDESC1, ISNULL(CT_CATEGORYDESC2, '') AS CT_CATEGORYDESC2 FROM CRMTICKETS WHERE CT_CATEGORYCODE<>''

                // SELECT DISTINCT ISNULL(CT_STATUSCODE, '') AS CT_STATUSCODE, ISNULL(CT_STATUSDESC1, '') AS CT_STATUSDESC1, ISNULL(CT_STATUSDESC2, '') AS CT_STATUSDESC2 FROM CRMTICKETS WHERE CT_STATUSCODE<>''

                await Task.Delay(1000);
                lstCategory = objBl.getTicketsCategoryFilter();
                lstFilterCategoryData.Clear();
                var groupedResult = from s in lstCategory
                                    group s by s.ct_categorydesc1;
                //lstFilterCategoryData.Add(new TicketFilterDlList { CmbCategory = lstrCaptionALL });
                int lintRow = 0;
                foreach (var item in groupedResult)
                {
                    if (lintRow > 2)
                    {
                        break;
                    }
                    lstFilterCategoryData.Add(new TicketFilterDlList { CmbCategory = item.Key });
                    lintRow++;
                }
            }


            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// To fetch typeFilterData
        /// </summary>
        private async Task typeFilterData()
        {
            try
            {


                await Task.Delay(1000);
                lsttype = objBl.getTicketsTypeFilter();
                lstFiltertypeData.Clear();
                var groupedResult = from s in lsttype
                                    group s by s.ct_casetypedesc1;
               // lstFiltertypeData.Add(new TicketFilterDlList { CmbType = lstrCaptionALL });

                foreach (var item in groupedResult)
                {
                    lstFiltertypeData.Add(new TicketFilterDlList { CmbType = item.Key });
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }



        }
        /// <summary>
        /// To get ClickedApply Button
        /// </summary>
        private async Task Button_ClickedApply()
        {
            try
            {


                Enticket = false;
                IsBusy = true;
                await Task.Delay(1000);

                var strTicketNo = "";
                var strselectedStatus = "";
                var strselectedcategory = "";
                var strselectedtype = "";
                if (lstFilterStatusData.Count > 0)
                {
                    foreach (var item in lstFilterStatusData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbStatus.ToString().Trim().ToUpper() != "ALL")
                            {
                                strselectedStatus += item.CmbStatus + ",";
                            }


                        }
                    }

                }
                if (lstFilterCategoryData.Count > 0)
                {
                    foreach (var item in lstFilterCategoryData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbCategory.ToString().Trim().ToUpper() != "ALL")
                            {
                                strselectedcategory += item.CmbCategory + ",";
                            }

                        }
                    }

                }
                if (lstFiltertypeData.Count > 0)
                {
                    foreach (var item in lstFiltertypeData)
                    {
                        if (item.isChecked == true)
                        {
                            if (item.CmbType.ToString().Trim().ToUpper() != "ALL")
                            {
                                strselectedtype += item.CmbType + ",";
                            }

                        }
                    }

                }
                if (TxtTicketNo != null)
                {
                    strTicketNo = TxtTicketNo;
                }



                if (strselectedStatus.Length > 0) strselectedStatus = strselectedStatus.Substring(0, strselectedStatus.Length - 1);
                if (strselectedcategory.Length > 0) strselectedcategory = strselectedcategory.Substring(0, strselectedcategory.Length - 1);
                if (strselectedtype.Length > 0) strselectedtype = strselectedtype.Substring(0, strselectedtype.Length - 1);

               await TicketsData("", strselectedStatus, strselectedcategory, strselectedtype, strTicketNo);
                IsVisibleRequestMain = true;
                IsVisibleRequestFilter = false;


                //App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", strselectedStatus, strselectedcategory, strselectedtype, strTicketNo, lstrScreenFlag));

            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }

            Enticket = true;
            IsBusy = false;
        }

        /// <summary>
        /// Click To Respective Ticket Number find the API
        /// </summary>
        private async Task Button_Clicked()
        {
            Enticket = false;
            IsBusy = true;
            await Task.Delay(1000);

            await App.Current.MainPage?.Navigation.PushAsync(new Ticket_Reply());
            Enticket = true;
            IsBusy = false;
        }
        /// <summary>
        /// Click To get BtnQuotation
        /// </summary>
        private async void BtnQuotation(ExtraCareDt fobjOOG)
        {
            Enticket = false;
            IsBusy = true;
            await Task.Delay(1000);

            string lblValCargoType = "";
            string lblValCategory = "";
            string fstrWeight = "";
            string lblValLength = "";
            string lblValWidth = "";
            string lblValHeight = "";
            string lblValChkDGCargo = "";
            string lblValWeight = "";
            string lblvalDGCargo = "";
            string lblvalDGaddlch = "";
            if (fobjOOG.CT_TYPEOFCARGO == "OOG")
            {
                lblValCargoType = fobjOOG.CT_TYPEOFCARGO;
                lblValCategory = fobjOOG.CT_CATEGORYOFCARGO;
                fstrWeight = fobjOOG.CT_WEIGHT;
                lblValLength = fobjOOG.CT_OVERLENGTH;
                lblValWidth = fobjOOG.CT_OVERWIDTH;
                lblValHeight = fobjOOG.CT_OVERHEIGHT;
                lblValChkDGCargo = fobjOOG.CT_CATEGORYOFCARGO;

                await App.Current.MainPage?.Navigation.PushAsync(new OOG_PriceCalculation(lblValCargoType, lblValCategory, fstrWeight, lblValLength, lblValWidth, lblValHeight, lblValChkDGCargo));
            }
            if (fobjOOG.CT_TYPEOFCARGO == "Breakbulk")
            {
                lblValCargoType = fobjOOG.CT_TYPEOFCARGO;
                lblValCategory = fobjOOG.CT_CATEGORYOFCARGO;
                lblValLength = fobjOOG.CT_OVERLENGTH;
                lblValWidth = fobjOOG.CT_OVERWIDTH;
                lblValHeight = fobjOOG.CT_OVERHEIGHT;
                lblValWeight = fobjOOG.CT_WEIGHT;
                lblvalDGCargo = fobjOOG.CT_CATEGORYOFCARGO;
                lblvalDGaddlch = fobjOOG.CT_DGADDLCHARGE;

                await App.Current.MainPage?.Navigation.PushAsync(new BreakBulk_PriceCalculation(lblValCargoType, lblValCategory, fstrWeight, lblValLength, lblValWidth, lblValHeight, lblvalDGCargo, lblvalDGaddlch));
            }
            Enticket = true;
            IsBusy = false;

        }
        /// <summary>
        /// Click To get buttonRequestHistory
        /// </summary>
        private async Task buttonRequestHistory()
        {
            Enticket = false;
            IsBusy = true;
            await Task.Delay(1000);

            if (lstrScreenFlag == "Extra Care & Hot Shipment")
            {
                await App.Current.MainPage?.Navigation.PushAsync(new Extracare_Addcontainer());
            }
            if (lstrScreenFlag == "Manifest Confirmation")
            {
                await App.Current.MainPage?.Navigation.PushAsync(new ManifestUpdateRequest1());
            }
            if (lstrScreenFlag == "Offload")
            {
                await App.Current.MainPage?.Navigation.PushAsync(new Offloadrequest_1());
            }
            if (lstrScreenFlag == "Direct Delivery")
            {
                await App.Current.MainPage?.Navigation.PushAsync(new DirectDeliveryRequest1());
            }
            if (lstrScreenFlag == "Attend Inspection")
            {
                await App.Current.MainPage?.Navigation.PushAsync(new Attendinspection_request1());
            }
            if (lstrScreenFlag == "Equipment Not Available in Location")
            {
                await App.Current.MainPage?.Navigation.PushAsync(new Inlocationequipment_request1());
            }
            if (lstrScreenFlag == "OOG")
            {
                await App.Current.MainPage?.Navigation.PushAsync(new OogBreakBulkRequest());
            }
            Enticket = true;
            IsBusy = false;

        }

    }

}

