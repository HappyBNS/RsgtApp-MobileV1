using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.EvaluateModel;



namespace RsgtApp.ViewModels
{
    public class EvaluateViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        //private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //btnLoadMore Button 
        public Command btnLoadMore { get; set; }
        //FilterClicked Button 
        public Command FilterClicked { get; set; }
        //btnAnyWhereSearch Button 
        public Command AnyWhere { get; set; }
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //Property Changed Event Handler              
        public ObservableCollection<EvaluateDt> lstEvaluate { get; set; } = new ObservableCollection<EvaluateDt>();
        // Twowaybinding process on Propertychange Event
        public int fintPageNumber = 1;
        public int fintPageSize = 10000;
        public int intTotalCount { get; set; }
        public string gblfilter { get; set; }
        public int gblRowCount { get; set; }
        private string strTotalCaption = "";
        string lblSno = "";
        string lblCapEVL = "";
        string strNoRecord = "";
        string strServerSlowMsg = "";
        string strPleaseClickMg = "";
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
        //To searchbox Variable
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
        //To imgEvaluateIcon Variable
        private string imgEvaluateIcon = "";
        public string ImgEvaluateIcon
        {
            get { return imgEvaluateIcon; }
            set
            {
                imgEvaluateIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEvaluateIcon");
            }
        }
        //To lblElServices Variable
        private string lblElServices = "";
        public string LblElServices
        {
            get { return lblElServices; }
            set
            {
                lblElServices = value;
                OnPropertyChanged();
                RaisePropertyChange("LblElServices");
            }
        }
        //To lblRedSeaGatewayMg Variable
        private string lblRedSeaGatewayMg = "";
        public string LblRedSeaGatewayMg
        {
            get { return lblRedSeaGatewayMg; }
            set
            {
                lblRedSeaGatewayMg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRedSeaGatewayMg");
            }
        }
        //To lblPleaseClickMg Variable
        private string lblPleaseClickMg = "";
        public string LblPleaseClickMg
        {
            get { return lblPleaseClickMg; }
            set
            {
                lblPleaseClickMg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPleaseClickMg");
            }
        }
        //To txtSearch Variable
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
        //To imgSearch Variable
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
        //To lblStatus Variable
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
        //To StatusColor Variable
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
        //To StatusDesc Variable
        private string statusDesc = "";
        public string StatusDesc
        {
            get { return statusDesc; }
            set
            {
                statusDesc = value;
                OnPropertyChanged();
                RaisePropertyChange("StatusDesc");
            }
        }
        //To lblBayan Variable
        private string lblBayan = "";
        public string LblBayan
        {
            get { return lblBayan; }
            set
            {
                lblBayan = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBayan");
            }
        }
        //To LblBOL Variable
        private string lblBOL = "";
        public string LblBOL
        {
            get { return lblBOL; }
            set
            {
                lblBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBOL");
            }
        }
        //To LblBOL Variable
        private string lblStart = "";
        public string LblStart
        {
            get { return lblStart; }
            set
            {
                lblStart = value;
                OnPropertyChanged();
                RaisePropertyChange("LblStart");
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
                AnyWhere.ChangeCanExecute();
                FilterClicked.ChangeCanExecute();
                btnLoadMore.ChangeCanExecute();

            }
        }
        //To handle Boolen variable
        bool evaluateEn = true;
        public bool EvaluateEn
        {
            get { return evaluateEn; }
            set
            {
                evaluateEn = value;
                OnPropertyChanged();
                RaisePropertyChange("EvaluateEn");
            }
        }
        public System.Windows.Input.ICommand gotoEvaluationForm => new Command<EvaluateDt>(gotosurveyform);
        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        /// <param name="strSearchbox"></param>
        public EvaluateViewModel(string strSearchbox)
        {
            try
            {
                strTotalCaption = "";
                searchbox = strSearchbox;
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
                //Begin-All Command Buttons
                AnyWhere = new Command(async () => await AnyWhereSearch(), () => !IsBusy);
                FilterClicked = new Command(async () => await fnFilterClicked(), () => !IsBusy);
                btnLoadMore = new Command(async () => await EvaluateData(strSearchbox), () => !IsBusy);
                //Begin-Call Listview GetData Funtion
                Task.Run(() => EvaluateData(strSearchbox)).Wait();
                //End-Call Listview GetData Funtions
                if (lstEvaluate == null || lstEvaluate.Count == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strNoRecord, 3000);
                }
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// AnywhereSSearch Button Function
        /// </summary>
        /// <returns></returns>
        public async Task AnyWhereSearch()
        {
            try
            {
                IsBusy = true;
                EvaluateEn = false;
                await Task.Delay(1000);
                await EvaluateData(Searchbox);
               // App.Current.MainPage?.Navigation.PushAsync(new Evaluate(Searchbox));
                EvaluateEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get the Listview Data
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <returns></returns>
        public async Task EvaluateData(string strSearchbox)
        {
            try
            {           
                await Task.Delay(1000);
               
                string fstrAnyWhere = "";
                lstEvaluate.Clear();
                if (strSearchbox != null) fstrAnyWhere = strSearchbox;
                var objRawData = new List<EvaluateDt>();
                objRawData = objBl.getEvaluateDetails(fstrAnyWhere, fintPageNumber, fintPageSize);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);

                }
                totalRecordCount = objRawData.Count;
                TotalRecordCount = strTotalCaption + " (" + totalRecordCount + ")";
                foreach (var item in objRawData)
                {
                    item.lblPleaseClickMg = strPleaseClickMg;
                    item.lblSno = lblSno;
                    item.lblStatus = lblStatus;
                    item.lblBayan = lblBayan;
                    item.lblBOL = lblBOL;
                    item.lblStart = lblStart;
                    lstEvaluate.Add(item);

                }
                if (lstEvaluate == null || lstEvaluate.Count == 0)
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
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM408");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM408");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
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
        /// To bind CMS Error Messages
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
              
                //dbLayer.objInfoitems = objCMS;
             
                imgEvaluateIcon = dbLayer.getCaption("imgEvaluate", objCMS);
                strTotalCaption = dbLayer.getCaption("strEvaluateServices", objCMS);
                lblRedSeaGatewayMg = dbLayer.getCaption("strMessage", objCMS);
                imgSearch = dbLayer.getCaption("imgSearch", objCMS);
                lblPleaseClickMg = dbLayer.getCaption("strGiveyourFeedback", objCMS);
                lblCapEVL = dbLayer.getCaption("strEvaluateServices", objCMS);
                strPleaseClickMg = dbLayer.getCaption("strMessage", objCMS);
                lblSno = dbLayer.getCaption("strSno", objCMS);
                lblStatus = dbLayer.getCaption("strStatus", objCMS);
                lblBayan = dbLayer.getCaption("strBayan", objCMS);
                lblBOL = dbLayer.getCaption("strBillofLading", objCMS);
                lblStart = dbLayer.getCaption("strStart", objCMS);
                strNoRecord = dbLayer.getCaption("strNorecordfound", objCMSMsg);              
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                txtSearch = dbLayer.getCaption("StrEvaluatePlaceHolder", objCMS);
                //btnLoadMore = dbLayer.getCaption("strLoadMore", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Navigate DwellDays Filter Page
        /// </summary>
        /// <returns></returns>
        public async Task fnFilterClicked()
        {
            IsBusy = true;
            EvaluateEn = false;
            await Task.Delay(1000);

            try
            {
                Application.Current.MainPage?.Navigation.PushAsync(new Evaluate(Searchbox));
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            EvaluateEn = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Navigate gotosurveyform Filter Page
        /// </summary>
        /// <param name="fobjEval"></param>
        public async void gotosurveyform(EvaluateDt fobjEval)
        {
            try
            {
                IsBusy = true;
                EvaluateEn = false;
                await Task.Delay(1000);
                string bayanNo = fobjEval.Bayan;
                string bol = fobjEval.BOL;
                string blgkey = fobjEval.Blgkey;
                gblSuryvaform.strBayanNo = bayanNo;
                gblSuryvaform.strBlNo = bol;
                gblSuryvaform.strBlgkey = blgkey;
                await App.Current.MainPage?.Navigation.PushAsync(new SurveyForm());               
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            EvaluateEn = true;
            IsBusy = false;

        }
    }
}
