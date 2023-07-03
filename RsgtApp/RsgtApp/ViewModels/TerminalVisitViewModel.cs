using Microsoft.AppCenter.Analytics;
using Plugin.FilePicker;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Services;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    class TerminalVisitViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;      
        private string strLanguage = App.gblLanguage;
        BLConnect objBl = new BLConnect();
        WebApiMethod objWeb = new WebApiMethod();
        
        //gotoTerminalVisitMessage Button 
        public Command gotoTerminalVisitMessage { get; set; }
        //Button_Clicked Button 
        public Command ButtonClicked { get; set; }
        //btnCancel Button
        public Command btnCancel { get; set; }       
        string strFileName = "";
        string strFileType = "";
        string strFileBody = "";
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
        //Property Changed indicatorBGColor Event Handler
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
        //Property Changed indicatorBGOpacity Event Handler
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
        // SelectedVisit variable
        private EnumCombo _selectedVisit;
        public EnumCombo SelectedVisit
        {
            get { return _selectedVisit; }
            set
            {
                SetProperty(ref _selectedVisit, value);
            }
        }
        private List<EnumCombo> _lobjPurposeVisit { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjPurposeVisit
        {
            get { return _lobjPurposeVisit; }
            set
            {
                if (_lobjPurposeVisit == value)
                    return;
                _lobjPurposeVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjPurposeVisit");

            }

        }

        // TerminalEn variable
        private bool terminalEn = true;
        public bool TerminalEn
        {
            get { return terminalEn; }
            set
            {
                terminalEn = value;
                OnPropertyChanged();
                RaisePropertyChange("TerminalEn");
            }
        }
        // imgRequestIcon variable
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
        // lblTerminalVisit variable
        private string lblterminalVisit = "";
        public string lblTerminalVisit
        {
            get { return lblterminalVisit; }
            set
            {
                lblterminalVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTerminalVisit");
            }
        }
        // lblApplicantName variable
        private string lblapplicantName = "";
        public string lblApplicantName
        {
            get { return lblapplicantName; }
            set
            {
                lblapplicantName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblApplicantName");
            }
        }
        // TxtApplicantName variable
        private string TxtapplicantName = "";
        public string TxtApplicantName
        {
            get { return TxtapplicantName; }
            set
            {
                TxtapplicantName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtApplicantName");
            }
        }
        // PlaceApplicantName variable
        private string placeApplicantName = "";
        public string PlaceApplicantName
        {
            get { return placeApplicantName; }
            set
            {
                placeApplicantName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceApplicantName");
            }
        }
        // MsgApplicantName variable
        private string msgApplicantName = "";
        public string MsgApplicantName
        {
            get { return msgApplicantName; }
            set
            {
                msgApplicantName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgApplicantName");
            }
        }
        // lblCompanyName variable
        private string lblcompanyName = "";
        public string lblCompanyName
        {
            get { return lblcompanyName; }
            set
            {
                lblcompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyName");
            }
        }
        // TxtCompanyName variable
        private string TxtcompanyName = "";
        public string TxtCompanyName
        {
            get { return TxtcompanyName; }
            set
            {
                TxtcompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCompanyName");
            }
        }
        // PlaceCompanyName variable
        private string PlacecompanyName = "";
        public string PlaceCompanyName
        {
            get { return PlacecompanyName; }
            set
            {
                PlacecompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceCompanyName");
            }
        }
        // MsgCompanyName variable
        private string msgCompanyName = "";
        public string MsgCompanyName
        {
            get { return msgCompanyName; }
            set
            {
                msgCompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCompanyName");
            }
        }
        // lblNoOfVisitors variable
        private string lblnoOfVisitors = "";
        public string lblNoOfVisitors
        {
            get { return lblnoOfVisitors; }
            set
            {
                lblnoOfVisitors = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNoOfVisitors");
            }
        }
        // TxtnoOfVisitors variable
        private string TxtnoOfVisitors = "";
        public string TxtNoOfVisitors
        {
            get { return TxtnoOfVisitors; }
            set
            {
                TxtnoOfVisitors = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtNoOfVisitors");
            }
        }
        // PlaceNoOfVisitors variable
        private string placeNoOfVisitors = "";
        public string PlaceNoOfVisitors
        {
            get { return placeNoOfVisitors; }
            set
            {
                placeNoOfVisitors = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceNoOfVisitors");
            }
        }
        // lblvisitDurations variable
        private string lblvisitDurations = "";
        public string lblVisitDurations
        {
            get { return lblvisitDurations; }
            set
            {
                lblvisitDurations = value;
                OnPropertyChanged();
                RaisePropertyChange("lblVisitDurations");
            }
        }
        // TxtVisitDurations variable
        private string TxtvisitDurations = "";
        public string TxtVisitDurations
        {
            get { return TxtvisitDurations; }
            set
            {
                TxtvisitDurations = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVisitDurations");
            }
        }
        // PlaceVisitDurations variable
        private string placeVisitDurations = "";
        public string PlaceVisitDurations
        {
            get { return placeVisitDurations; }
            set
            {
                placeVisitDurations = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceVisitDurations");
            }
        }
        // lblPurposeOfVisit variable
        private string lblpurposeOfVisit = "";
        public string lblPurposeOfVisit
        {
            get { return lblpurposeOfVisit; }
            set
            {
                lblpurposeOfVisit = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPurposeOfVisit");
            }
        }
        // lblOpportunity variable
        private string lblopportunity = "";
        public string lblOpportunity
        {
            get { return lblopportunity; }
            set
            {
                lblopportunity = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOpportunity");
            }
        }
        // TxtOpportun variable
        private string Txtopportun = "";
        public string TxtOpportun
        {
            get { return Txtopportun; }
            set
            {
                Txtopportun = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOpportun");
            }
        }
        // lblAttachment variable
        private string lblattachment = "";
        public string lblAttachment
        {
            get { return lblattachment; }
            set
            {
                lblattachment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttachment");
            }
        }
        // BtnchooseFile variable
        private string BtnchooseFile = "";
        public string BtnChooseFile
        {
            get { return BtnchooseFile; }
            set
            {
                BtnchooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnChooseFile");
            }
        }
        // btnsubmit variable
        private string btnsubmit = "";
        public string btnSubmit
        {
            get { return btnsubmit; }
            set
            {
                btnsubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("btnSubmit");
            }
        }
        // lblDesignation variable
        private string lbldesignation = "";
        public string lblDesignation
        {
            get { return lbldesignation; }
            set
            {
                lbldesignation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDesignation");
            }
        }
        // MsgDesignation variable
        private string msgDesignation = "";
        public string MsgDesignation
        {
            get { return msgDesignation; }
            set
            {
                msgDesignation = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgDesignation");
            }
        }
        // TxtDesignation variable
        private string txtDesignation = "";
        public string TxtDesignation
        {
            get { return txtDesignation; }
            set
            {
                txtDesignation = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDesignation");
            }
        }
        // PlaceDesignation variable
        private string placeDesignation = "";
        public string PlaceDesignation
        {
            get { return placeDesignation; }
            set
            {
                placeDesignation = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceDesignation");
            }
        }
        private bool isvalidatedApplicant = false;

        public bool IsValidatedApplicant
        {
            get { return isvalidatedApplicant; }
            set
            {
                isvalidatedApplicant = value;
                OnPropertyChanged();
                RaisePropertyChange("IsValidatedApplicant");
            }
        }
        private bool isvalidatedCompany = false;
        public bool IsValidatedCompany
        {
            get { return isvalidatedCompany; }
            set
            {
                isvalidatedCompany = value;
                OnPropertyChanged();
                RaisePropertyChange("IsValidatedCompany");
            }
        }
        // IsValidatedDesignation variable
        private bool isvalidatedDesignation = false;
        public bool IsValidatedDesignation
        {
            get { return isvalidatedDesignation; }
            set
            {
                isvalidatedDesignation = value;
                OnPropertyChanged();
                RaisePropertyChange("IsValidatedDesignation");
            }
        }
        // lblFilename variable
        private bool lblfilename = false;

        public bool lblFilename
        {
            get { return lblfilename; }
            set
            {
                lblfilename = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename");
            }
        }
        // imgcancel variable
        private bool imgcancel = false;
        public bool ImgCancel
        {
            get { return imgcancel; }
            set
            {
                imgcancel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCancel");
            }
        }
        // btnchooseFile   variable                                                                                                                                                 variable
        private bool btnchooseFile = false;
        public bool btnChooseFile
        {
            get { return btnchooseFile; }
            set
            {
                btnchooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("btnChooseFile");
            }
        }
        // TxtFilename  variable 
        private string txtFilename = "";
        public string TxtFilename
        {
            get { return txtFilename; }
            set
            {
                txtFilename = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename");
            }
        }
        private string strServerSlowMsg = "";
        // isBusy  variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoTerminalVisitMessage.ChangeCanExecute();
                ButtonClicked.ChangeCanExecute();
                btnCancel.ChangeCanExecute();

            }
        }
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public TerminalVisitViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("TerminalVisitViewModel");
            Task.Run(() => assignCms()).Wait();
            gotoTerminalVisitMessage = new Command(async () => await gototerminalVisitMessage(), () => !IsBusy);
            ButtonClicked = new Command(async () => await button_Clicked(), () => !IsBusy);
            btnCancel = new Command(async () => await btncancel(), () => !IsBusy);
           // HideErrorMsg();
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM407");
                    objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM407");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                
               
                assignContent();
            }
            catch (Exception ex)
            {
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
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
                dbLayer.objInfoitems = objCMS;

                lobjPurposeVisit = dbLayer.getEnum("StrPurposeofvisit", objCMS);
                imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
                lblTerminalVisit = dbLayer.getCaption("strTerminalVisitRequestForm", objCMS);
                lblApplicantName = dbLayer.getCaption("strApplicantName", objCMS);
                lblCompanyName = dbLayer.getCaption("strCompanyName", objCMS);
                lblDesignation = dbLayer.getCaption("strDesignation", objCMS);
                lblNoOfVisitors = dbLayer.getCaption("strNoofVisitors", objCMS);
                lblVisitDurations = dbLayer.getCaption("strVisitDurations", objCMS);
                lblPurposeOfVisit = dbLayer.getCaption("strPurposeofVisit", objCMS);
                lblOpportunity = dbLayer.getCaption("strOpportnitiesIssueIdentified", objCMS);
                lblAttachment = dbLayer.getCaption("strAttachment", objCMS);
                btnSubmit = dbLayer.getCaption("strSubmit", objCMS);
                BtnChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
                MsgApplicantName = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCompanyName = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgDesignation = dbLayer.getCaption("strMandatory", objCMSMSG);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To get data binding in Terminal visit
        /// </summary>
        private async Task gototerminalVisitMessage()
        {
            try
            {
                TerminalEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                IsValidatedApplicant = false;
                IsValidatedCompany = false;
                IsValidatedDesignation = false;
                Task.Run(() => assignCms()).Wait();
                await Task.Delay(1000);
                              
                var lstrapplicantName = "";
                var lstrCompanyName = "";
                var lstrDesignation = "";
                var lstrNoofVis = "";
                var lstrPurVisit = "";
               // var lstrVisitDuration = "";
               // var lstrOppertunities = "";
               // byte lstrAttachment;
                var lstrResult = "";
                string lstrTicketmsg = "";
                if ((TxtApplicantName == null) || (TxtApplicantName == ""))
                {
                   
                    IsValidatedApplicant = true;
                }
                else
                {
                    gblTerminalVisit.strapplicantName = TxtApplicantName;
                   
                }
                if ((TxtCompanyName == null) || (TxtCompanyName == ""))
                {
                   
                    IsValidatedCompany = true;
                }
                else
                {
                    gblTerminalVisit.strCompanyName = TxtCompanyName;                 
                }
                if ((TxtDesignation == null) || (TxtDesignation == ""))
                {
                    
                    IsValidatedDesignation = true;
                }
                else
                {
                   // IsValidatedDesignation = false;
                    gblTerminalVisit.strDesignation = TxtDesignation;                 
                }
                if ((TxtNoOfVisitors != null) && (TxtNoOfVisitors != ""))
                {
                    gblTerminalVisit.strNoofVis = TxtNoOfVisitors;
                }
                if ((TxtVisitDurations != null) && (TxtVisitDurations != ""))
                {
                    gblTerminalVisit.strVisitDuration = TxtVisitDurations;
                }
                if(_selectedVisit!=null)
                {
                    gblTerminalVisit.strPurVisit = _selectedVisit.Value;
                }
                //if (picPurposeVisit.SelectedIndex != -1)
                //{
                //    gblTerminalVisit.strPurVisit = picPurposeVisit.Items[picPurposeVisit.SelectedIndex];
                //}
                if ((TxtOpportun != null) && (TxtOpportun != ""))
                {
                    gblTerminalVisit.strOppertunities = TxtOpportun;
                }
                lstrTicketmsg = lblApplicantName + lstrapplicantName + lblCompanyName + lstrCompanyName + lblDesignation + lstrDesignation + lblNoOfVisitors + lstrNoofVis + lblPurposeOfVisit + lstrPurVisit;

                if ((IsValidatedApplicant != true) && (IsValidatedCompany != true) && (IsValidatedDesignation != true))
                {

                    //Attachment Insert
                    gblTrackRequests.strFileName = strFileName;
                    gblTrackRequests.strFileType = strFileType;
                    gblTerminalVisit.strAttachment = strFileBody;

                    lstrResult = objWeb.postWebApi("NewTerminalVisit", gblTerminalVisit.TerminalVisit());
                    if (lstrResult.ToUpper().Trim() == "TRUE")
                    {
                        objWeb.postWebApi("PostSendEmail", gblTerminalVisit.TerminalVisitMailData());
                        // Navigation.PushAsync(new TerminalVisit_Message());
                       await App.Current.MainPage?.Navigation.PushAsync(new TerminalVisit_Message());
                   }
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }

                }
                TerminalEn = true;
                IsBusy = false;
               
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To Get PickAndShow Function for get jpg Files
        /// </summary>
        private async Task PickAndShow(string[] fileTypes)
        {
            try
            {

                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    lblFilename = true;
                    TxtFilename = pickedFile.FileName;
                    ImgCancel = true;
                    btnChooseFile = false;
                    strFileName = pickedFile.FileName;
                    int lintLastDotPos = strFileName.LastIndexOf('.');
                    string lstrLoadFileType = strFileName.Substring(lintLastDotPos + 1);
                    strFileType = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    strFileBody = temp_inBase64;// pickedFile.FilePath;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }


        /// <summary>
        /// button_Clicked Button Function
        /// </summary>
        private async Task button_Clicked()
        {
            try
            {
                IsBusy = true;
                TerminalEn = false;
                await Task.Delay(1000);
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "com.adobe.pdf", "public.rft", "com.microsoft.word.doc", "org.openxmlformats.wordprocessingml.document" }; // same as iOS constant UTType.Image
                }
                await PickAndShow(fileTypes);
                TerminalEn = true;
                IsBusy = false;
                
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get btncancel Button Function
        /// </summary>
        private async Task btncancel()
        {

            try
            {
                IsBusy = true;
                TerminalEn = false;
                await Task.Delay(1000);
                lblFilename = false;
                TxtFilename = "";
                ImgCancel = false;
                btnChooseFile = true;
                TerminalEn = true;
                IsBusy = false;
                
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

    }
}