using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class SurveyFormViewModel : INotifyPropertyChanged
    {
        //To assign CMS
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
     //   private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        public Command gotoSubmit { get; set; }
        Dictionary<string, string> lobjEvaluateQuestion = new Dictionary<string, string>();
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
        // msgFirstcomment  MSG variable
        private string msgFirstcomment = "";
        public string MsgFirstcomment
        {
            get { return msgFirstcomment; }
            set
            {
                msgFirstcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgFirstcomment");
            }
        }
        // msgSecondcomment  MSG variable
        private string msgSecondcomment = "";
        public string MsgSecondcomment
        {
            get { return msgSecondcomment; }
            set
            {
                msgSecondcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgSecondcomment");
            }
        }
        // msgThirdcomment  MSG variable
        private string msgThirdcomment = "";
        public string MsgThirdcomment
        {
            get { return msgThirdcomment; }
            set
            {
                msgThirdcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgThirdcomment");
            }
        }
        // MsgFourcomment  MSG variable
        private string msgFourcomment = "";
        public string MsgFourcomment
        {
            get { return msgFourcomment; }
            set
            {
                msgFourcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgFourcomment");
            }
        }
        //To indicatorBGColor  Variable
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
        //To indicatorBGOpacity  Variable
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
        // IsvalidatedFirstcomment  MSG variable
        private bool isvalidatedFirstcomment = false;
        public bool IsvalidatedFirstcomment
        {
            get { return isvalidatedFirstcomment; }
            set
            {
                isvalidatedFirstcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedFirstcomment");
            }
        }
        // IsvalidatedSecondcomment  MSG variable
        private bool isvalidatedSecondcomment = false;
        public bool IsvalidatedSecondcomment
        {
            get { return isvalidatedSecondcomment; }
            set
            {
                isvalidatedSecondcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedSecondcomment");
            }
        }
        // IsvalidatedThirdcomment  value variable
        private bool isvalidatedThirdcomment = false;
        public bool IsvalidatedThirdcomment
        {
            get { return isvalidatedThirdcomment; }
            set
            {
                isvalidatedThirdcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedThirdcomment");
            }
        }
        // IsvalidatedFourcomment  value variable
        private bool isvalidatedFourcomment = false;
        public bool IsvalidatedFourcomment
        {
            get { return isvalidatedFourcomment; }
            set
            {
                isvalidatedFourcomment = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedFourcomment");
            }
        }
        // StackSurveyForm  value variable
        private bool stackSurveyForm = true;
        public bool StackSurveyForm
        {
            get { return stackSurveyForm; }
            set
            {
                stackSurveyForm = value;
                OnPropertyChanged();
                RaisePropertyChange("StackSurveyForm");
            }
        }
        // Rating  value variable
        private int rating = 0;
        public int Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged();
                RaisePropertyChange("Rating");
            }
        }
        // Rating2  value variable
        private int rating2 = 0;
        public int Rating2
        {
            get { return rating2; }
            set
            {
                rating2 = value;
                OnPropertyChanged();
                RaisePropertyChange("Rating2");
            }
        }
        // Rating3  value variable
        private int rating3 = 0;
        public int Rating3
        {
            get { return rating3; }
            set
            {
                rating3 = value;
                OnPropertyChanged();
                RaisePropertyChange("Rating3");
            }
        }
        // Rating4  value variable
        private int rating4 = 0;
        public int Rating4
        {
            get { return rating4; }
            set
            {
                rating4 = value;
                OnPropertyChanged();
                RaisePropertyChange("Rating4");
            }
        }
        // imgevaluationForm  IMAGE variable
        private string imgevaluationForm = "";
        public string imgEvaluationForm
        {
            get { return imgevaluationForm; }
            set
            {
                imgevaluationForm = value;
                OnPropertyChanged();
                RaisePropertyChange("imgEvaluationForm");
            }
        }
        // lblEvaluationForm  lable variable
        private string lblevaluationForm = "";
        public string lblEvaluationForm
        {
            get { return lblevaluationForm; }
            set
            {
                lblevaluationForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEvaluationForm");
            }
        }
        // lblBayan  lable variable
        private string lblbayan = "";
        public string lblBayan
        {
            get { return lblbayan; }
            set
            {
                lblbayan = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBayan");
            }
        }
        // lblBOL  lable variable
        private string lblbOL = "";
        public string lblBOL
        {
            get { return lblbOL; }
            set
            {
                lblbOL = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBOL");
            }
        }
        // lblBlgkey  lable variable
        private string lblblgkey = "";
        public string lblBlgkey
        {
            get { return lblblgkey; }
            set
            {
                lblblgkey = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBlgkey");
            }
        }
        // lblFirstQues  lable variable
        private string lblfirstQues = "";
        public string lblFirstQues
        {
            get { return lblfirstQues; }
            set
            {
                lblfirstQues = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstQues");
            }
        }
        // lblComments1  lable variable
        private string lblcomments1 = "";
        public string lblComments1
        {
            get { return lblcomments1; }
            set
            {
                lblcomments1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblComments1");
            }
        }
        // TxtComments  lable variable
        private string txtComments = "";
        public string TxtComments
        {
            get { return txtComments; }
            set
            {
                txtComments = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtComments");
            }
        }
        // PlaceComments  lable variable
        private string placeComments = "";
        public string PlaceComments
        {
            get { return placeComments; }
            set
            {
                placeComments = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceComments");
            }
        }
        // lblsecoundQues  lable variable
        private string lblsecoundQues = "";
        public string lblSecoundQues
        {
            get { return lblsecoundQues; }
            set
            {
                lblsecoundQues = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSecoundQues");
            }
        }
        // lblComments2  lable variable
        private string lblcomments2 = "";
        public string lblComments2
        {
            get { return lblcomments2; }
            set
            {
                lblcomments2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblComments2");
            }
        }
        // txtComments2  value variable
        private string txtComments2 = "";
        public string TxtComments2
        {
            get { return txtComments2; }
            set
            {
                txtComments2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtComments2");
            }
        }
        // PlaceComments2  lable variable
        private string placeComments2 = "";
        public string PlaceComments2
        {
            get { return placeComments2; }
            set
            {
                placeComments2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceComments2");
            }
        }
        // lblThreeQues  lable variable
        private string lblthreeQues = "";
        public string lblThreeQues
        {
            get { return lblthreeQues; }
            set
            {
                lblthreeQues = value;
                OnPropertyChanged();
                RaisePropertyChange("lblThreeQues");
            }
        }
        // lblComments3  lable variable
        private string lblcomments3 = "";
        public string lblComments3
        {
            get { return lblcomments3; }
            set
            {
                lblcomments3 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblComments3");
            }
        }
        // TxtComments3  lable variable
        private string txtComments3 = "";
        public string TxtComments3
        {
            get { return txtComments3; }
            set
            {
                txtComments3 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtComments3");
            }
        }
        // PlaceComments3  lable variable
        private string placeComments3 = "";
        public string PlaceComments3
        {
            get { return placeComments3; }
            set
            {
                placeComments3 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceComments3");
            }
        }
        // lblfourQues  lable variable
        private string lblfourQues = "";
        public string lblFourQues
        {
            get { return lblfourQues; }
            set
            {
                lblfourQues = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFourQues");
            }
        }
        // lblComments4  lable variable
        private string lblcomments4 = "";
        public string lblComments4
        {
            get { return lblcomments4; }
            set
            {
                lblcomments4 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblComments4");
            }
        }
        // TxtComments4  lable variable
        private string txtComments4 = "";
        public string TxtComments4
        {
            get { return txtComments4; }
            set
            {
                txtComments4 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtComments4");
            }
        }
        // PlaceComments4  lable variable
        private string placeComments4 = "";
        public string PlaceComments4
        {
            get { return placeComments4; }
            set
            {
                placeComments4 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceComments4");
            }
        }
        // btnSubmit  lable variable
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
        // using bool value  variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoSubmit.ChangeCanExecute();
            }
        }
        private string strServerSlowMsg = "";
        // PlaceComments4  lable variable
        private string lblPleaseImprove = "";
        public string LblPleaseImprove
        {
            get { return lblPleaseImprove; }
            set
            {
                lblPleaseImprove = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPleaseImprove");
            }
        }
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public SurveyFormViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("SurveyFormViewModel");
            Task.Run(() => assignCms()).Wait();
            gotoSubmit = new Command(async () => await gotosubmit(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM030");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM030");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //To bind CMS Error Messages
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
                await Task.Delay(1000);
                lblPleaseImprove = dbLayer.getCaption("strMessage", objCMS);
                imgEvaluationForm = dbLayer.getCaption("imgEvaluationForm", objCMS);
                lblEvaluationForm = dbLayer.getCaption("strSurveyform", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS) + " " + gblSuryvaform.strBayanNo;
                lblBOL = dbLayer.getCaption("strBillofLading", objCMS) + " " + gblSuryvaform.strBlNo;
                lblBlgkey = gblSuryvaform.strBlgkey;
                lblComments1 = dbLayer.getCaption("strComments", objCMS);
                lblComments2 = dbLayer.getCaption("strComments", objCMS);
                lblComments3 = dbLayer.getCaption("strComments", objCMS);
                lblComments4 = dbLayer.getCaption("strComments", objCMS);
                MsgFirstcomment = dbLayer.getCaption("strMandatory", objCMSMsg);
                MsgSecondcomment = dbLayer.getCaption("strMandatory", objCMSMsg);
                MsgThirdcomment = dbLayer.getCaption("strMandatory", objCMSMsg);
                MsgFourcomment = dbLayer.getCaption("strMandatory", objCMSMsg);
                btnSubmit = dbLayer.getCaption("strSubmit", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                lobjEvaluateQuestion = dbLayer.getLOV("strQuestions", objCMS);
                int lintRowNo = 0;
                foreach (var item in lobjEvaluateQuestion)
                {
                    if (lintRowNo == 0) lblFirstQues = item.Key;
                    if (lintRowNo == 1) lblSecoundQues = item.Key;
                    if (lintRowNo == 2) lblThreeQues = item.Key;
                    if (lintRowNo == 3) lblFourQues = item.Key;
                    lintRowNo++;
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        ///To submit respect the value
        /// </summary>
        /// <returns></returns>
        private async Task gotosubmit()
        {
            try
            {
                StackSurveyForm = false;
                IsBusy = true;
                await Task.Delay(1000);
                bool blflag = FormValidation();
                if (blflag == true)
                {
                    if (lblFirstQues == null) lblFirstQues = "";
                    gblSuryvaform.strQuestion = lblFirstQues;
                    if (PlaceComments == null) PlaceComments = "";
                    gblSuryvaform.strComments = PlaceComments;
                    // if (Rating == null) Rating = 0;
                    Rating = 0;
                    gblSuryvaform.strRating = Rating.ToString();
                    gblSuryvaform.strRegMailid = gblRegisteration.strLoginUser;
                    gblSuryvaform.strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    gblSuryvaform.strSortoder = "1";
                    string lstrResult = objWebApi.postWebApi("NewSurveyAnswers", gblSuryvaform.SurveyForm());
                    if (lblSecoundQues == null) lblSecoundQues = "";
                    gblSuryvaform.strQuestion = lblSecoundQues;
                    if (PlaceComments2 == null) PlaceComments2 = "";
                    gblSuryvaform.strComments = PlaceComments2;
                   // if (Rating2 == null) 
                        Rating2 = 0;
                    gblSuryvaform.strRating = Rating2.ToString();
                    gblSuryvaform.strRegMailid = gblRegisteration.strLoginUser;
                    gblSuryvaform.strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    gblSuryvaform.strSortoder = "2";
                    lstrResult = objWebApi.postWebApi("NewSurveyAnswers", gblSuryvaform.SurveyForm());
                    if (lblThreeQues == null) lblThreeQues = "";
                    gblSuryvaform.strQuestion = lblThreeQues;
                    if (PlaceComments3 == null) PlaceComments3 = "";
                    gblSuryvaform.strComments = PlaceComments3;
                    //if (Rating3 == null) 
                        Rating3 = 0;
                    gblSuryvaform.strRating = Rating3.ToString();
                    gblSuryvaform.strRegMailid = gblRegisteration.strLoginUser;
                    gblSuryvaform.strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    gblSuryvaform.strSortoder = "3";
                    lstrResult = objWebApi.postWebApi("NewSurveyAnswers", gblSuryvaform.SurveyForm());
                    if (lblFourQues == null) lblFourQues = "";
                    gblSuryvaform.strQuestion = lblFourQues;
                    if (PlaceComments4 == null) PlaceComments4 = "";
                    gblSuryvaform.strComments = PlaceComments4;
                   // if (Rating4 == null)
                        Rating4 = 0;
                    gblSuryvaform.strRating = Rating4.ToString();
                    gblSuryvaform.strRegMailid = gblRegisteration.strLoginUser;
                    gblSuryvaform.strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    gblSuryvaform.strSortoder = "4";
                    lstrResult = objWebApi.postWebApi("NewSurveyAnswers", gblSuryvaform.SurveyForm());
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                      App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    string strJson = "{ \"RU_REVIEWSCOUNT\":\"0\", \"RU_REVIEWSPENDINGCOUNT\":\"0\" }";
                    string lstrEmailID = gblRegisteration.strLoginUser;
                    if (lstrResult == "True")
                    {
                        lstrResult = objWebApi.putWebApi("UpdateEvalauteCount", strJson, lstrEmailID);
                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                        await App.Current.MainPage?.Navigation.PushAsync(new SurveyFormMessage());
                    }
                   

                }
                StackSurveyForm = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To submit respect the value Validation checking
        private bool FormValidation()
        {
            bool blResult = true;
            IsvalidatedFirstcomment = false;
            IsvalidatedSecondcomment = false;
            IsvalidatedThirdcomment = false;
            IsvalidatedFourcomment = false;
            //first comment and rating
            if (Rating == 0)
            {
                IsvalidatedFirstcomment = true;
                blResult = false;
            }
            if ((TxtComments == null) || (TxtComments == ""))
            {
                IsvalidatedFirstcomment = true;
                blResult = false;
            }
            //secound  comment and rating
            if (Rating2 == 0)
            {
                IsvalidatedSecondcomment = true;
                blResult = false;
            }
            if ((TxtComments2 == null) || (TxtComments2 == ""))
            {
                IsvalidatedSecondcomment = true;
                blResult = false;
            }
            //thirg comment and rating
            if (Rating3 == 0)
            {
                IsvalidatedThirdcomment = true;
                blResult = false;
            }
            if ((TxtComments3 == null) || (TxtComments3 == ""))
            {
                IsvalidatedThirdcomment = true;
                blResult = false;
            }
            //fourth comment and rating
            if (Rating4 == 0)
            {
                IsvalidatedFourcomment = true;
                blResult = false;
            }
            if ((TxtComments4 == null) || (TxtComments4 == ""))
            {
                IsvalidatedFourcomment = true;
                blResult = false;
            }
            return blResult;
        }
    }
}