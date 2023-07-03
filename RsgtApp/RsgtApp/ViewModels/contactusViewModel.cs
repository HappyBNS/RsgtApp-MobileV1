using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    class contactusViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
     
        private string strLanguage = App.gblLanguage;
        string strServerSlowMsg = "";
        //gotoSend Button 
        public Command gotoSend { get; set; }
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWeb = new WebApiMethod();
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
        //txtName purpose of using textbox varaiable
        private string txtName = "";
        public string TxtName
        {
            get { return txtName; }
            set
            {
                txtName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtName");
            }
        }
        //txtEmail purpose of using textbox varaiable
        private string txtEmail = "";
        public string TxtEmail
        {
            get { return txtEmail; }
            set
            {
                txtEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtEmail");
            }
        }
        //txtSubject purpose of using textbox varaiable
        private string txtSubject = "";
        public string TxtSubject
        {
            get { return txtSubject; }
            set
            {
                txtSubject = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtSubject");
            }
        }
        //txtMessage purpose of using textbox varaiable
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
        //msgName purpose of using textbox varaiable
        private string msgName = "";
        public string MsgName
        {
            get
            {
                return msgName;
            }
            set
            {
                msgName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgName");
            }
        }
        //msgMail purpose of using textbox varaiable
        private string msgMail = "";
        public string MsgMail
        {
            get
            {
                return msgMail;
            }
            set
            {
                msgMail = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMail");
            }
        }
        //msgSub purpose of using textbox varaiable
        private string msgSub = "";
        public string MsgSub
        {
            get
            {
                return msgSub;
            }
            set
            {
                msgSub = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgSub");
            }
        }
        //msgBody purpose of using textbox varaiable
        private string msgBody = "";
        public string MsgBody
        {
            get
            {
                return msgBody;
            }
            set
            {
                msgBody = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgBody");
            }
        }
        //plName purpose of using textbox varaiable
        public string plName = "";
        public string PlName
        {
            get
            {
                return plName;
            }
            set
            {
                plName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlName");
            }
        }
        //plEmail purpose of using textbox varaiable
        public string plEmail = "";
        public string PlEmail
        {
            get
            {
                return plEmail;
            }
            set
            {
                plEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("PlEmail");
            }
        }
        //plSubject purpose of using textbox varaiable
        public string plSubject = "";
        public string PlSubject
        {
            get
            {
                return plSubject;
            }
            set
            {
                plSubject = value;
                OnPropertyChanged();
                RaisePropertyChange("PlSubject");
            }
        }
        //plMessage purpose of using textbox varaiable
        public string plMessage = "";
        public string PlMessage
        {
            get
            {
                return plMessage;
            }
            set
            {
                plMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("PlMessage");
            }
        }
        //isvalidationName  purpose of using  name validation
        private bool isvalidationName = false;
        public bool IsvalidationName
        {
            get { return isvalidationName; }
            set
            {
                isvalidationName = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidationName");
            }
        }
        //isvalidationMail  purpose of using Mail validation
        private bool isvalidationMail = false;
        public bool IsvalidationMail
        {
            get { return isvalidationMail; }
            set
            {
                isvalidationMail = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidationMail");
            }
        }
        //isvalidationSub  purpose of using Sub validation
        private bool isvalidationSub = false;
        public bool IsvalidationSub
        {
            get { return isvalidationSub; }
            set
            {
                isvalidationSub = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidationSub");
            }
        }
        //isvalidationBody  purpose of using Body validation
        private bool isvalidationBody = false;
        public bool IsvalidationBody
        {
            get { return isvalidationBody; }
            set
            {
                isvalidationBody = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidationBody");
            }
        }
        //contactUSStack  purpose of using track validation
        private bool contactUSStack = true;
        public bool ContactUSStack
        {
            get { return contactUSStack; }
            set
            {
                contactUSStack = value;
                OnPropertyChanged();
                RaisePropertyChange("ContactUSStack");
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
                RaisePropertyChange("IsBusy");
                gotoSend.ChangeCanExecute();
            }
        }
        /// <summary>
        /// CMS caption list
        /// </summary>        
        private string _imgContactHead { get; set; }
        public string imgContactHead
        {
            get
            {
                return _imgContactHead;
            }
            set
            {
                _imgContactHead = value;
                OnPropertyChanged();
                RaisePropertyChange("imgContactHead");
            }
        }

        private string _lblContactUs { get; set; }
        public string lblContactUs
        {
            get
            {
                return _lblContactUs;
            }
            set
            {
                _lblContactUs = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContactUs");
            }
        }

        private string _lblName { get; set; }
        public string lblName
        {
            get
            {
                return _lblName;
            }
            set
            {
                _lblName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblName");
            }
        }

        private string _lblEmail { get; set; }
        public string lblEmail
        {
            get
            {
                return _lblEmail;
            }
            set
            {
                _lblEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmail");
            }
        }

        private string _lblSubject { get; set; }
        public string lblSubject
        {
            get
            {
                return _lblSubject;
            }
            set
            {
                _lblSubject = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSubject");
            }
        }

        private string _lblMessage { get; set; }
        public string lblMessage
        {
            get
            {
                return _lblMessage;
            }
            set
            {
                _lblMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMessage");
            }
        }

        private string _btnSend { get; set; }
        public string btnSend
        {
            get
            {
                return _btnSend;
            }
            set
            {
                _btnSend = value;
                OnPropertyChanged();
                RaisePropertyChange("btnSend");
            }
        }

        private string _lblRedSea { get; set; }
        public string lblRedSea
        {
            get
            {
                return _lblRedSea;
            }
            set
            {
                _lblRedSea = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRedSea");
            }
        }

        private string _lblPOBox { get; set; }
        public string lblPOBox
        {
            get
            {
                return _lblPOBox;
            }
            set
            {
                _lblPOBox = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPOBox");
            }
        }
        
        private string _lblTelephoneNo1 { get; set; }
        public string lblTelephoneNo1
        {
            get
            {
                return _lblTelephoneNo1;
            }
            set
            {
                _lblTelephoneNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTelephoneNo1");
            }
        }

        private string _lblFNumber { get; set; }
        public string lblFNumber
        {
            get
            {
                return _lblFNumber;
            }
            set
            {
                _lblFNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFNumber");
            }
        }

        private string _lblEmail1 { get; set; }
        public string lblEmail1
        {
            get
            {
                return _lblEmail1;
            }
            set
            {
                _lblEmail1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmail1");
            }
        }

        private string _lblCustomerService { get; set; }
        public string lblCustomerService
        {
            get
            {
                return _lblCustomerService;
            }
            set
            {
                _lblCustomerService = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerService");
            }
        }

        private string _lblTelephoneNo2 { get; set; }
        public string lblTelephoneNo2
        {
            get
            {
                return _lblTelephoneNo2;
            }
            set
            {
                _lblTelephoneNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTelephoneNo2");
            }
        }

        private string _lblEmail2 { get; set; }
        public string lblEmail2
        {
            get
            {
                return _lblEmail2;
            }
            set
            {
                _lblEmail2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmail2");
            }
        }

        private string _lblsubhead { get; set; }
        public string lblsubhead
        {
            get
            {
                return _lblsubhead;
            }
            set
            {
                _lblsubhead = value;
                OnPropertyChanged();
                RaisePropertyChange("lblsubhead");
            }
        }

        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        public contactusViewModel()
        {
            try
            {
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
                //Begin Command Button
                gotoSend = new Command(async () => await ContactSend(), () => !IsBusy);
                //End Command Button
                if (gblRegisteration.strLoginUser != null)
                {
                    if (gblRegisteration.strLoginUser != "")
                    {
                        TxtName = gblRegisteration.strLoginFirstName.ToString();
                        TxtEmail = gblRegisteration.strLoginUser.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM008");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM008");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {


            await Task.Delay(1000);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            imgContactHead = dbLayer.getCaption("imgContactHeadJpg", objCMS);
            lblContactUs = dbLayer.getCaption("strContactUs", objCMS);
            plName = dbLayer.getCaption("strName", objCMS);
            lblName = dbLayer.getCaption("strName", objCMS);
            plEmail = dbLayer.getCaption("strEmail1", objCMS);
            lblEmail = dbLayer.getCaption("strEmail1", objCMS);
            plSubject = dbLayer.getCaption("strSubject", objCMS);
            lblSubject = dbLayer.getCaption("strSubject", objCMS);
            plMessage = dbLayer.getCaption("strMessage", objCMS);
            lblMessage = dbLayer.getCaption("strMessage", objCMS);
            btnSend = dbLayer.getCaption("strSend", objCMS);
            lblRedSea = dbLayer.getCaption("strRedSeaGatewayTerminal", objCMS);
            lblPOBox = dbLayer.getCaption("strPOBox", objCMS);
            lblTelephoneNo1 = dbLayer.getCaption("strTelephoneNo", objCMS);
            lblFNumber = dbLayer.getCaption("strFaxs", objCMS);
            lblEmail1 = dbLayer.getCaption("strEmail2", objCMS);
            lblCustomerService = dbLayer.getCaption("strCustomerService", objCMS);
            lblTelephoneNo2 = dbLayer.getCaption("strTelephone1", objCMS);
            lblEmail2 = dbLayer.getCaption("strEmail3", objCMS);
            lblsubhead = dbLayer.getCaption("strRSGTMessage1", objCMS);
            MsgName = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgMail = dbLayer.getCaption("strMandatory",objCMSMsg);
            MsgSub = dbLayer.getCaption("strMandatory",  objCMSMsg);
            MsgBody = dbLayer.getCaption("strMandatory", objCMSMsg);
        }
        /// <summary>
        /// To bind CMS Error Messages
        /// </summary>
        public async void assignCmsMsg()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMSMsg = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();

                // objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get ContactSend data
        /// </summary>
        /// <returns></returns>
        private async Task ContactSend()
        {
            try
            {
                IsBusy = true;
                ContactUSStack = false;
                IsvalidationBody = false;
                IsvalidationMail = false;
                IsvalidationName = false;
                IsvalidationSub = false;
                Task.Run(() => assignCms()).Wait();
                await Task.Delay(1000);
                if ((txtName == null) || (txtName == ""))
                {
                    IsvalidationName = true;
                }
                else
                {
                    gblRegisteration.strCustName1 = txtName;
                    gblRegisteration.strCustName2 = txtName;
                    IsvalidationName = false;
                }
                if ((txtEmail == null) || (txtEmail == ""))
                {
                    IsvalidationMail = true;
                }
                else
                {
                    var email = txtEmail;
                    var emailpattern = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";
                    if (!string.IsNullOrWhiteSpace(email) && !(Regex.IsMatch(email, emailpattern)))
                    {
                        IsvalidationMail = true;
                    }
                    else
                    {
                        gblRegisteration.strCustMailId = txtEmail;
                        IsvalidationMail = false;
                    }
                }
                if ((txtSubject == null) || (txtSubject == ""))
                {
                    IsvalidationSub = true;
                }
                else
                {
                    gblRegisteration.strCustSub1 = txtSubject;
                    gblRegisteration.strCustSub2 = txtSubject;
                    IsvalidationSub = false;
                }
                if ((txtMessage == null) || (txtMessage == ""))
                {
                    IsvalidationBody = true;
                }
                else
                {
                    gblRegisteration.strCustMessage1 = txtMessage;
                    gblRegisteration.strCustMessage2 = txtMessage;
                    IsvalidationBody = false;
                }
                if ((isvalidationMail != true) &&
                    (isvalidationName != true) &&
                    (isvalidationSub != true) &&
                    (isvalidationBody != true))
                {
                    try
                    {
                        gblRegisteration.BoolResult = objWeb.postWebApi("NewContactUs", gblRegisteration.ContactUs());
                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                        if (gblRegisteration.BoolResult == "True")
                        {
                            objWeb.postWebApi("PostSendEmail", gblRegisteration.ContactusMail());
                            if (AppSettings.ErrorExceptionWebApi != "")
                            {
                                await Application.Current.MainPage?.DisplayAlert("", strServerSlowMsg, "OK");
                            }
                            Application.Current.MainPage?.Navigation.PushAsync(new ContactUsMessage());
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                        {
                            await Application.Current.MainPage?.DisplayAlert("", strServerSlowMsg, "OK");
                        }
                        else
                        {
                            await Application.Current.MainPage?.DisplayAlert("", ex.Message, "OK");
                        }
                    }
                }
                IsBusy = false;
                ContactUSStack = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}