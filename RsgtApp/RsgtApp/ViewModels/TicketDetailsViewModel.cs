using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.TicketsListModel;

namespace RsgtApp.ViewModels
{
    public class TicketDetailsViewModel : INotifyPropertyChanged
    {
        //CMS Caption List
        private List<InfoItem> objCMSDtail = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<clsTickets> lstTicketCRMDays = new List<clsTickets>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To declare count Variable
        public int gblRowCount { get; set; }
        public int intTotalCount { get; set; }
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        //To declare Variable
        public string lstrRegisterUsercode { get; set; }
        public static string strLoginUser { get; set; }
        public int fintPageNumber { get; set; }
        public int fintPageSize { get; set; }
        //Button_Reply button
        public Command Button_Reply { get; set; }
        //To declare List variable
        public List<TicketdetailDt> lstTicketCRMLst = new List<TicketdetailDt>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        [Obsolete]
        public System.Windows.Input.ICommand Attachment_file => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
        //To create bussinessLayer Object
        private BLConnect objBl = new BLConnect();
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
        // Two way binding  IndicatorViewBGColor process on Propertychange Event
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
        // Two way binding  IndicatorViewOpacity process on Propertychange Event
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
        //imgRequestsService purpose of image label varaiable
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
        //lblActive purpose of using label varaiable
        private string lblActive = "";
        public string LblActive
        {
            get { return lblActive; }
            set
            {
                lblActive = value;
                OnPropertyChanged();
                RaisePropertyChange("LblActive");
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
        //To Declare boolean variable
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
        private string strServerSlowMsg = "";
        //To Declare boolean variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                Button_Reply.ChangeCanExecute();
            }
        }
        //Begin Ticket Details ViewModel Constructor 
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public TicketDetailsViewModel(string fstrCasegkey, string fstrCasetype, string fstrStatus, string fstrCreatedon, string fstrCompletedOn, string fstrTicketno)
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("TicketDetailsViewModel");
                //To Call Caption Function           
                Task.Run(() => assignCms()).Wait();
                //To call Command Buttons
                Button_Reply = new Command(async () => await ButtonReply(), () => !IsBusy);
                lblcasetype = fstrCasetype;
                lblActive = fstrStatus;
                lblCreatedondate = fstrCreatedon;
                lblcompleteondate = fstrCompletedOn;
                lblTicketno = fstrTicketno;
                lstTicketCRMLst = TicketdetailData(fstrCasegkey);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End Ticket Details View Model constructor
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async Task assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMSDtail = await App.Database.GetCmsAsyncAccessId("RM441");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMSDtail = await dbLayer.LoadContent("RM441");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
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
                await Task.Delay(1000);

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}

                dbLayer.objInfoitems = objCMSDtail;
                imgTicketIcon = dbLayer.getCaption("imgTicket", objCMSDtail);
                lblTicket = dbLayer.getCaption("strTicket", objCMSDtail);
                lblCase = dbLayer.getCaption("strCaseTypeSubject", objCMSDtail);
                lblStatus = dbLayer.getCaption("strStatus", objCMSDtail);
                lblCreatedOn = dbLayer.getCaption("strCreatedOn", objCMSDtail);
                lblcompleteon = dbLayer.getCaption("strCompletedOn", objCMSDtail);
                lblReply = dbLayer.getCaption("strReply", objCMSDtail);
                lblMmessageheading = dbLayer.getCaption("strRSGT", objCMSDtail);
                imgMbellicon = dbLayer.getCaption("imgBell", objCMSDtail);
                lblAttachment = dbLayer.getCaption("strAttachments", objCMSDtail);
                imgattachicon = dbLayer.getCaption("imgAttachment", objCMSDtail);
                imgRequestmenu = dbLayer.getCaption("imgRequest", objCMSDtail);
                lblReply = dbLayer.getCaption("strReply", objCMSDtail);
                lblMessage = dbLayer.getCaption("strMessage", objCMSDtail);
                lblAttach = dbLayer.getCaption("Attachment", objCMSDtail);
                btnSubmit = dbLayer.getCaption("strSentRequest", objCMSDtail);
                btnChoose = dbLayer.getCaption("strChoosefile", objCMSDtail);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End assignContent function

        /// <summary>
        /// To Click the applybuttion
        /// </summary>
        private async Task ButtonReply()
        {
            try
            {
                await Task.Delay(1000);
                await App.Current.MainPage?.Navigation.PushAsync(new Ticket_Detail("", "", "", "", "", ""));
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }

        /// <summary>
        ///To get list of data for ticket
        /// </summary>
        private List<TicketdetailDt> TicketdetailData(string fstrCasegkey)
        {
            try
            {
                lstTicketCRMLst = objCon.getCrmTicketActivites(fstrCasegkey);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

            }

            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
            return lstTicketCRMLst;
        }
    }
}
