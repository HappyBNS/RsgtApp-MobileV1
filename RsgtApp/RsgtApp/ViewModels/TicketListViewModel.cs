using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
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
    public class TicketListViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private List<InfoItem> objCMSDtail = new List<InfoItem>();
        public List<RequesttDt> lstTicketLst = new List<RequesttDt>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        private BLConnect objBl = new BLConnect();
        //To declare Variable
        string lstrCaptionALL = "";
        public string fstrFilter { get; set; }
        public string fstrRegisterUsercode { get; set; }
        public string Ticketdetails { get; set; }
        //To declare obervation collection object
        public ObservableCollection<RequesttDt> lstTicketlist { get; set; } = new ObservableCollection<RequesttDt>();
        //Loadmore Button
        public Command gotoLoadMore { get; set; }
        //Search button
        public Command SearchClicked { get; set; }
        //Filter Button
        public Command FilterClicked { get; set; }
        //Apply Button
        public Command ButtonClickedApply { get; set; }
        //Cancel Button
        public Command ButtonClickedCancel { get; set; }
        //ButtonClicked button
        public Command ButtonClicked { get; set; }
        //go to Clicked Reset Button
        public Command ButtonReset { get; set; }
        // lfintPageSize variable

        private int lfintPageSize = Convert.ToInt32(RSGT_Resource.ResourceManager.GetString("ColletionViewPageSize").ToString().Trim());

        public int LfintPageSize
        {
            get { return lfintPageSize; }
            set
            {
                lfintPageSize = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageSize");
            }
        }

        // lfintPageNo variable
        private int lfintPageNo = 1;


        public int LfintPageNo
        {
            get { return lfintPageNo; }
            set
            {
                lfintPageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageNo");
            }
        }
        string lblSno = "";
        public int intTotalCount { get; set; }
        string lblbtnMoreDetail = "";
        string strNoRecord = "";
        private string strTotalCaption = "";
        //To Declare Count Variable
        //  private int totalRecordCount = 0;
        //private string strtotalRecordCount = "";
        string lstrINQueue = "";
        //To declare Count variable
        //Property Changed Event Handler
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
        //imgTicketIcon purpose of using image varaiable
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
        //lblTicketDetail purpose of using label varaiable
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
        //lblTicketno purpose of using label varaiable
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
        //lblCase purpose of using label varaiable
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
        //lblcasetype purpose of using label varaiable
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
        //lblStatusDetail purpose of using label varaiable
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
        //lblCreatedOn purpose of using label varaiable
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
        //lblCreatedondate purpose of using label varaiable
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
        //lblcompleteon purpose of using label varaiable
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
        //lblcompleteondate purpose of using label varaiable
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
        //lblMmessageheading purpose of using label varaiable
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
        //imgMbellicon purpose of using image varaiable
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
        //mMessagetime purpose of using data varaiable
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
        //mMessageinfo purpose of using data varaiable
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
        //lblAttachmentDetail purpose of using label varaiable
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
        //imgattachiconDetail purpose of using image varaiable
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
        //imgFilterBlue purpose of using image varaiable
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
        //lblFilters purpose of using label varaiable
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
        //btnApply purpose of using button varaiable
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
        //imgReset purpose of using image varaiable
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
        //lblStatusFilter purpose of using label varaiable
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
        //imgDownArrow1 purpose of using image varaiable
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
        //lblCategory purpose of using label varaiable
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
        //imgDownArrow2 purpose of using image varaiable
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
        //lblType purpose of using label varaiable
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
        //imgDownArrow3 purpose of using image varaiable
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
        //lblTicket purpose of using label varaiable
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
        //imgRequestmenu purpose of using image varaiable
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
        //lblReply purpose of using label varaiable
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
        //lblMessage purpose of using label varaiable
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
        //lblAttach purpose of using label varaiable
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
        //btnChoose purpose of using button varaiable
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
        //btnSubmit purpose of using button varaiable
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
        //imgRequestsService purpose of using image varaiable
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
        //lblcomplaint purpose of using label varaiable
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
        //lblTitle purpose of using label varaiable
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
        //txtTitle1 purpose of using text varaiable
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
        //msgTitle purpose of using data varaiable
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
        //lblCaseType purpose of using label varaiable
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
        //picCaseType1 purpose of using data varaiable
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
        //msgCase purpose of using data varaiable
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
        //lblCaseSubType purpose of using label varaiable
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
        //picSubType1 purpose of using data varaiable
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
        //msgCaseSubType purpose of using data varaiable
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
        //lblMessageReply purpose of using label varaiable
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
        //txtMessage purpose of using text varaiable
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
        //btnAttach purpose of using button varaiable
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
        //btnChooseFile purpose of using button varaiable
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
        //imgCancel purpose of using image varaiable
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
        //lblFilename purpose of using label varaiable
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
        //btnSubmitReply purpose of using btn varaiable
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
        //imginfodark purpose of using image varaiable
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
        //lblReqinfo purpose of using label varaiable
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
        //lblTitles purpose of using label varaiable
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
        //txtTitle2 purpose of using text varaiable
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
        //lblCaseTypes purpose of using label varaiable
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
        //picCaseTypes2 purpose of using data varaiable
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
        //lblCaseSubTypes purpose of using label varaiable
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
        //picSubTypes2 purpose of using data varaiable
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
        //lblMessages purpose of using label varaiable
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
        //msgMessage purpose of using data varaiable
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
        //lblAttachment purpose of using label varaiable
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
        //imgTicketIcondark purpose of using image varaiable
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
        //lblTickets purpose of using label varaiable
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
        //searchbox purpose of using data varaiable
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
        //txtSearch purpose of using text varaiable
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
        //imgSearch purpose of using image varaiable
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
        //imgFilter purpose of using image varaiable
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
        //ticketdetailinfo purpose of using data varaiable
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
        //lblTicketNo purpose of using label varaiable
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
        //ticketNo purpose of using data varaiable
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
        //lblStatus purpose of using label varaiable
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
        //status purpose of using data varaiable
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
        //lblCasetitle1 purpose of using label varaiable
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
        //casetitle purpose of using data varaiable
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
        //lblCategoryRequestList purpose of using label varaiable
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
        //category purpose of using data varaiable
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
        //lblCaseTypeRequestList purpose of using label varaiable
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
        //caseType purpose of using data varaiable
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
        //lblSubType purpose of using label varaiable
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
        //subType purpose of using data varaiable
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
        //lblOrigin purpose of using label varaiable
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
        //origin purpose of using data varaiable
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
        //createdOn purpose of using data varaiable
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
        //lblCompletedOn purpose of using label varaiable
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
        //completedOn purpose of using data varaiable
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
        //strtiCketStatus purpose of using string varaiable
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
        //completedON purpose of using data varaiable
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
        //statusCode purpose of using data varaiable
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
        //statusColor purpose of using data varaiable
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
        //casegkey purpose of using data varaiable
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
        //btnLoadMore purpose of using button varaiable
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
        //To declare Combo variable
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
        //To declare Combo variable
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
        //To declare Combo variable
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
        //txtTicketNo purpose of using text varaiable
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
        //placeTicketNo purpose of using data varaiable
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
        //imgattachicon purpose of using image varaiable
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
        //To declare boolean variable
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




        //Hide and Show Tickets 2023/03/18
        private bool isVisibleTicketMain = false;
        public bool IsVisibleTicketMain
        {
            get { return isVisibleTicketMain; }
            set
            {
                isVisibleTicketMain = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleTicketMain");
            }
        }


        private bool isVisibleTicketFilter = false;
        public bool IsVisibleTicketFilter
        {
            get { return isVisibleTicketFilter; }
            set
            {
                isVisibleTicketFilter = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleTicketFilter");
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
        private string totalRecordCount = "";

        public string TotalRecordCount
        {
            get { return totalRecordCount; }
            set
            {
                totalRecordCount = value;
                OnPropertyChanged();
                RaisePropertyChange("TotalRecordCount");
            }
        }
        private string strServerSlowMsg = "";
        //To declare boolean variable
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
        //To create Observation collection object 
        List<clsTICKETSSTATUSFILTER> lstStatus = new List<clsTICKETSSTATUSFILTER>();
        public ObservableCollection<TicketFilterDlList> lstFilterStatusData { get; set; } = new ObservableCollection<TicketFilterDlList>();
        List<ClsTICKETSCATEGORYFILTER> lstCategory = new List<ClsTICKETSCATEGORYFILTER>();
        public ObservableCollection<TicketFilterDlList> lstFilterCategoryData { get; set; } = new ObservableCollection<TicketFilterDlList>();
        List<clsTICKETSTYPEFILTER> lsttype = new List<clsTICKETSTYPEFILTER>();
        public ObservableCollection<TicketFilterDlList> lstFiltertypeData { get; set; } = new ObservableCollection<TicketFilterDlList>();
        public System.Windows.Input.ICommand Ticketdeta => new Command<RequesttDt>(Ticketdetail);
        Dictionary<string, string> lobjcategory = new Dictionary<string, string>();
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public TicketListViewModel(string strSearchbox, string strselectedStatus, string strselectedcategory, string strselectedtype, string strTicketNo, string fstrFilterFlag, ContentPage view)
        {
            try
            {
                Myview = view;
                strTotalCaption = "";
                searchbox = strSearchbox;
                IsVisibleTicketFilter = false;
                IsVisibleTicketMain = false;
                if (fstrFilterFlag == "N")
                {
                    IsVisibleTicketFilter = false;
                    IsVisibleTicketMain = true;
                }

                //Appcenter Track Event handler
                Analytics.TrackEvent("TicketListViewModel");
                lstTicketlist = new ObservableCollection<RequesttDt>();
                //Begin-All Command Buttons
                ButtonClicked = new Command(async () => await Button_Clicked(), () => !IsBusy);
                FilterClicked = new Command(async () => await TickeFilter(), () => !IsBusy);
                gotoLoadMore = new Command(async () => await TicketsData(strSearchbox, strselectedStatus, strselectedcategory, strselectedtype, strTicketNo), () => !IsBusy);
                SearchClicked = new Command(async () => await Tickesearch(), () => !IsBusy);
                ButtonClickedApply = new Command(async () => await Button_ClickedApply(), () => !IsBusy);
                ButtonClickedCancel = new Command(async () => await clear(), () => !IsBusy);
                ButtonReset = new Command(async () => await clear(), () => !IsBusy);
                //End-Call Command Button
                //To Call Caption Function           
                Task.Run(() => assignCms()).Wait();
                if (fstrFilterFlag == "Y")
                {
                    IsVisibleTicketFilter = true;
                    IsVisibleTicketMain = false;

                }
                //Begin-Call Listview GetData Funtions
                Task.Run(() => StatusFilterData()).Wait();
                Task.Run(() => typeFilterData()).Wait();
                //End-Call Listview GetData Funtions

                //To-Call Listview GetData Funtion
                Task.Run(() => TicketsData(strSearchbox, strselectedStatus, strselectedcategory, strselectedtype, strTicketNo)).Wait();
                if (lstTicketlist == null || lstTicketlist.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End Ticket list view model Constructor

        /// <summary>
        ///  To click Clear button 
        /// </summary>
        public async Task clear()
        {
            try
            {
                Enticket = false;
                IsBusy = true;
                await Task.Delay(1000);
                lstTicketlist.Clear();
                await TicketsData("", "", "", "", "");
                await StatusFilterData();
                await typeFilterData();
                await assignContent();
                await assignCms();
                await assignContent();
                IsExpandedCategory = false;
                IsExpandedStatus = false;
                IsExpandedType = false;
                TxtTicketNo = "";
                IsVisibleTicketFilter = false;
                IsVisibleTicketMain = true;

                Enticket = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }

        /// <summary>
        /// To Click the Filter Page function
        /// </summary>
        public async Task TickeFilter()
        {
            try
            {
                Enticket = false;
                IsBusy = true;
                await Task.Delay(1000);
                IsVisibleTicketMain = false;
                IsVisibleTicketFilter = true;
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
        ///To Click the Anywhere search function
        /// </summary>
        public async Task Tickesearch()
        {
            Enticket = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                await Task.Delay(1000);
                await TicketsData(searchbox, strselectedStatus, strselectedcategory, strselectedtype, strTicketNo);
                //Application.Current.MainPage?.Navigation.PushAsync(new Request_TicketsList(searchbox, "", "", "", ""));
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            Enticket = true;
            IsBusy = false;
        }

        /// <summary>
        ///To get list view of Ticket details
        /// </summary>
        private async void Ticketdetail(RequesttDt fobjTicketdetail)
        {
            try
            {
                Enticket = false;
                IsBusy = true;
                await Task.Delay(1000);
                string lstrTicketNo = fobjTicketdetail.TicketNo;
                string lstrcasegkey = fobjTicketdetail.casegkey;
                string lstrCasetype = fobjTicketdetail.CaseType;
                string lstrStatus = fobjTicketdetail.Status;
                string lstrCreatedon = fobjTicketdetail.CreatedOn;
                string lstrCompletedOn = fobjTicketdetail.CompletedOn;
                string lstrTicketno = fobjTicketdetail.TicketNo;
                await App.Current.MainPage?.Navigation.PushAsync(new Ticket_Detail(lstrcasegkey, lstrCasetype, lstrStatus, lstrCreatedon, lstrCompletedOn, lstrTicketno));
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
            Enticket = true;
            IsBusy = false;
        }
        /// <summary>
        /// To binding the data in get value in database 
        /// </summary>
        /// <returns></returns>
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
                string fstrFilter = "fstrAnywhere:" + fstrAnywhere + ";" + "fstrCasetype:" + fstrCasetype + ";" + "fstrCategory:" + fstrCategory + ";" + "fstrStatus:" + fstrStatus + ";";
                var objRawData = new List<RequesttDt>();
                fstrRegisterUsercode = gblRegisteration.strContactGkeyCRM;
                objRawData = objCon.getTickets(fstrRegisterUsercode, fstrFilter, lfintPageNo, lfintPageSize);
                lstTicketlist.Clear();
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
                    if (item.Status == null || item.Status == "")
                    {
                        item.Status = dbLayer.getCaption("strInQueue", objCMS);
                       // item.AnywhereAll += item.Status;
                    }
                   // lstTicketlist.Add(item);
                }

                lstTicketlist = new ObservableCollection<RequesttDt>(objRawData);//20230623 App Crash Issues to Handel the observableCollection by gokul 
                if (lstTicketlist.Count > 0)
                {
                    CollectionView cvTicketlist = Myview.FindByName<CollectionView>("GridTicketlist");
                    cvTicketlist.ItemsSource = null;
                    cvTicketlist.ItemsSource = lstTicketlist;
                    cvTicketlist.ItemsUpdatingScrollMode = ItemsUpdatingScrollMode.KeepScrollOffset;
                }
                totalRecordCount = objRawData.Count.ToString();
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (lstTicketlist == null || lstTicketlist.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
                await Task.Delay(1000);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM440");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM440");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                    objCMSDtail = await dbLayer.LoadContent("RM441");
                }
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


                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}

                dbLayer.objInfoitems = objCMS;
                imgTicketIcondark = dbLayer.getCaption("imgticketIcondark", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                imgFilter = dbLayer.getCaption("imgFilter", objCMS);
                txtSearch = dbLayer.getCaption("strTicketNo", objCMS) + "/" + dbLayer.getCaption("strStatus", objCMS) + "/" + dbLayer.getCaption("strCaseTitle", objCMS) + "/" + dbLayer.getCaption("strCategory", objCMS) + "/" + dbLayer.getCaption("strCaseType", objCMS) + "/" + dbLayer.getCaption("strSubType", objCMS) + "/" + dbLayer.getCaption("strOrigin", objCMS);
                lstrINQueue = dbLayer.getCaption("strInQueue", objCMS);
                strTotalCaption = dbLayer.getCaption("strTicketList", objCMS);
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
                lblbtnMoreDetail = dbLayer.getCaption("strMoreDetail", objCMS);
                btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                // starts ticket filter caption assign
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
                lobjcategory = dbLayer.getLOV("strcategorylov", objCMSDtail);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);
                lstFilterCategoryData.Clear();
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFilterCategoryData.Add(new TicketFilterDlList { CmbCategory = lstrCaptionALL });
                foreach (var dic in lobjcategory)
                {
                    lstFilterCategoryData.Add(new TicketFilterDlList { CmbCategory = dic.Key }); ;
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End assignContent function

        /// <summary>
        ///To go status filter function
        /// </summary>
        private async Task StatusFilterData()
        {
            try
            {

                lstStatus = objBl.getTicketsStatusFilter();
                lstFilterStatusData.Clear();
                var groupedResult = from s in lstStatus
                                    group s by s.ct_statusdesc1;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                // lstFilterStatusData.Add(new TicketFilterDlList { CmbStatus = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFilterStatusData.Add(new TicketFilterDlList { CmbStatus = item.Key }); ;
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }

        /// <summary>
        ///To get Type filter funtion
        /// </summary>
        private async Task typeFilterData()
        {
            try
            {

                lsttype = objBl.getTicketsTypeFilter();
                lstFiltertypeData.Clear();
                var groupedResult = from s in lsttype
                                    group s by s.ct_casetypedesc1;
                //20230322 As per Mr.Raju Advice Select All Removed Temporary
                //lstFiltertypeData.Add(new TicketFilterDlList { CmbType = lstrCaptionALL });
                foreach (var item in groupedResult)
                {
                    lstFiltertypeData.Add(new TicketFilterDlList { CmbType = item.Key });
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }

        /// <summary>
        ///To click Apply button
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
                if (txtTicketNo != null)
                {
                    strTicketNo = txtTicketNo;
                }
                if (strselectedStatus.Length > 0) strselectedStatus = strselectedStatus.Substring(0, strselectedStatus.Length - 1);
                if (strselectedcategory.Length > 0) strselectedcategory = strselectedcategory.Substring(0, strselectedcategory.Length - 1);
                if (strselectedtype.Length > 0) strselectedtype = strselectedtype.Substring(0, strselectedtype.Length - 1);
                await TicketsData("", strselectedStatus, strselectedcategory, strselectedtype, strTicketNo);
                IsVisibleTicketMain = true;
                IsVisibleTicketFilter = false;
                // App.Current.MainPage?.Navigation.PushAsync(new Request_TicketsList("", strselectedStatus, strselectedcategory, strselectedtype, strTicketNo));
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
            Enticket = true;
            IsBusy = false;
        }
        /// <summary>
        ///Click To Respective Ticket Number find the API
        /// </summary>
        private async Task Button_Clicked()
        {
            try
            {
                Enticket = false;
                IsBusy = true;
                await Task.Delay(1000);
                await App.Current.MainPage?.Navigation.PushAsync(new Ticket_Reply());
                Enticket = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
    }
}
