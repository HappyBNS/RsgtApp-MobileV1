using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class SurveyFormMessageViewModel : INotifyPropertyChanged
    {
        //To assign CMS
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        // BLConnect objBl = new BLConnect();
        public Command clicktoevaluation { get; set; }
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
        // using to setProperty in default value
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
        //To stackSurveyFormMsg variable
        private bool stackSurveyFormMsg = true;
        public bool StackSurveyFormMsg
        {
            get { return stackSurveyFormMsg; }
            set
            {
                stackSurveyFormMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackSurveyFormMsg");
            }
        }
        //To imgconfirmtick variable
        private string imgconfirmtick = "";
        public string imgConfirmtick
        {
            get { return imgconfirmtick; }
            set
            {
                imgconfirmtick = value;
                OnPropertyChanged();
                RaisePropertyChange("imgConfirmtick");
            }
        }
        //To lblDearCustomer variable
        private string lbldearCustomer = "";
        public string lblDearCustomer
        {
            get { return lbldearCustomer; }
            set
            {
                lbldearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDearCustomer");
            }
        }
        //To lblEvaluationFeedback variable
        private string lblevaluationFeedback = "";
        public string lblEvaluationFeedback
        {
            get { return lblevaluationFeedback; }
            set
            {
                lblevaluationFeedback = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEvaluationFeedback");
            }
        }
        //To btnOk variable
        private string btnok = "";
        public string btnOk
        {
            get { return btnok; }
            set
            {
                btnok = value;
                OnPropertyChanged();
                RaisePropertyChange("btnOk");
            }
        }
        //To handle Boolen variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                clicktoevaluation.ChangeCanExecute();
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
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public SurveyFormMessageViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("SurveyFormMessageViewModel");
            Task.Run(() => assignCms()).Wait();
            clicktoevaluation = new Command(async () => await clicktoEvaluation(), () => !IsBusy);
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {  
            await Task.Delay(1000);
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM408");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM408");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM408");
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
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            dbLayer.objInfoitems = objCMS;
            imgConfirmtick = dbLayer.getCaption("imgConfirm", objCMS);
            lblDearCustomer = dbLayer.getCaption("strDearcustomer", objCMS);
            lblEvaluationFeedback = dbLayer.getCaption("strEvaluationcompleted", objCMS);
            btnOk = dbLayer.getCaption("strok", objCMS);
            await Task.Delay(1000);           
       }

        /// <summary>
        /// To get Click Evaluation Function
        /// </summary>
        /// <returns></returns>
        private async Task clicktoEvaluation()
        {
            try
            {
                StackSurveyFormMsg = false;
                IsBusy = true;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PopToRootAsync(); 
                StackSurveyFormMsg = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}