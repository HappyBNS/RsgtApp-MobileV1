using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.ManuallnspectionModel;

namespace RsgtApp.ViewModels
{
    public class DisclaimerViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        List<ManualInspectionDt> lstManuallspection = new List<ManualInspectionDt>();
        // string lstrContainerNo = "";
        private string strServerSlowMsg = "";
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create Collection Object used ObservableCollection
        public ObservableCollection<ManualInspectionDt> lstBookManuallspection { get; set; } = new ObservableCollection<ManualInspectionDt>();
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
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
        //Button_Submit Button 
        public Command Button_Submit { get; set; }
        //btnOK Button 
        public Command btnOK { get; set; }
        //checkedDisclaimer Button 
        public Command checkedDisclaimer { get; set; }
        //lblDearCustomer purpose of using label varaiable
        private string lblDearCustomer = "";
        public string LblDearCustomer
        {
            get { return lblDearCustomer; }
            set
            {
                lblDearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearCustomer");
            }
        }
        //lblYourSubmittedMg purpose of using label varaiable
        private string lblYourSubmittedMg = "";
        public string LblYourSubmittedMg
        {
            get { return lblYourSubmittedMg; }
            set
            {
                lblYourSubmittedMg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblYourSubmittedMg");
            }
        }
        //imgConfirmtickIcon purpose of using image varaiable
        private string imgConfirmtickIcon = "";
        public string ImgConfirmtickIcon
        {
            get { return imgConfirmtickIcon; }
            set
            {
                imgConfirmtickIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgConfirmtickIcon");
            }
        }
        //btnOk purpose of using button varaiable
        private string btnOk = "";
        public string BtnOk
        {
            get { return btnOk; }
            set
            {
                btnOk = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnOk");
            }
        }
        //imgDisclaimerIcon purpose of using image varaiable
        private string imgDisclaimerIcon = "";
        public string ImgDisclaimerIcon
        {
            get { return imgDisclaimerIcon; }
            set
            {
                imgDisclaimerIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDisclaimerIcon");
            }
        }
        //lblDisclaimerForm purpose of using label varaiable
        private string lblDisclaimerForm = "";
        public string LblDisclaimerForm
        {
            get { return lblDisclaimerForm; }
            set
            {
                lblDisclaimerForm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDisclaimerForm");
            }
        }
        //lblLstContainer purpose of using label varaiable
        private string lblLstContainer = "";
        public string LblLstContainer
        {
            get { return lblLstContainer; }
            set
            {
                lblLstContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblLstContainer");
            }
        }
        //lblRedSeaGatewayTerminalMg purpose of using label varaiable
        private string lblRedSeaGatewayTerminalMg = "";
        public string LblRedSeaGatewayTerminalMg
        {
            get { return lblRedSeaGatewayTerminalMg; }
            set
            {
                lblRedSeaGatewayTerminalMg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRedSeaGatewayTerminalMg");
            }
        }
        //lblIHaveReadAgreedMg purpose of using label varaiable
        private string lblIHaveReadAgreedMg = "";
        public string LblIHaveReadAgreedMg
        {
            get { return lblIHaveReadAgreedMg; }
            set
            {
                lblIHaveReadAgreedMg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblIHaveReadAgreedMg");
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
        //disclaimerList purpose of using data varaiable
        private string disclaimerList = "";
        public string DisclaimerList
        {
            get { return disclaimerList; }
            set
            {
                DisclaimerList = value;
                OnPropertyChanged();
                RaisePropertyChange("DisclaimerList");
            }
        }
        //To handle Boolen variable
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Button_Submit.ChangeCanExecute();
                btnOK.ChangeCanExecute();
            }
        }
        //To Declare IndicatorBGColor Variable
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
        //To Declare indicatorBGOpacity Variable
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
        //To handle Boolen variable
        private bool disclaimerEn = true;
        public bool DisclaimerEn
        {
            get { return disclaimerEn; }
            set
            {
                disclaimerEn = value;
                OnPropertyChanged();
                RaisePropertyChange("DisclaimerEn");
            }
        }
        //To handle Boolen variable
        bool checkDisclaimer = false;
        public bool CheckDisclaimer
        {
            get { return checkDisclaimer; }
            set
            {
                checkDisclaimer = value;
                OnPropertyChanged();
                RaisePropertyChange("CheckDisclaimer");
                Task.Run(() => onCheckedChange()).Wait();
            }
        }
        //To handle Boolen variable
        bool buttonSubmit = false;
        public bool ButtonSubmit
        {
            get { return buttonSubmit; }
            set
            {
                buttonSubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("ButtonSubmit");
            }
        }
        /// <summary>
        /// To declare list variable
        /// </summary>
        public List<ManualInspectionDt> lstManuallspectionlocal { get; set; } = new List<ManualInspectionDt>();
        Dictionary<string, string> lobjBookforManualInspection = new Dictionary<string, string>();
        /// <summary>
        /// Begin DisclaimerViewModel Constructor
        /// </summary>
        /// <param name="flstManuallspectionlocal"></param>
        public DisclaimerViewModel(List<ManualInspectionDt> flstManuallspectionlocal)
        {
            try
            {
                //Analytics track event
                Analytics.TrackEvent("DisclaimerViewModel");
                if (flstManuallspectionlocal != null)
                {
                    foreach (var item in flstManuallspectionlocal)
                    {
                        lstManuallspectionlocal.Add(new ManualInspectionDt { ContainerNo = item.ContainerNo, ContainerUnitGKey = item.ContainerUnitGKey });
                    }
                }
                //Begin-All Command Buttons
                Button_Submit = new Command(async () => await submit(), () => !IsBusy);
                btnOK = new Command(async () => await btn_OK(), () => !IsBusy);
                //End-All Command Buttons
                //Begin-Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //End-Caption Function
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //End DisclaimerViewModel Constructor
        /// <summary>
        /// Begin assignCms function
        /// </summary>
        /// <returns></returns>
        public async Task assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM411");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM411");
                    objCMSMsg = await dbLayer.LoadContent("RM407");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //End assignCms function
        /// <summary>
        /// Begin assignContent function
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
                lblDearCustomer = dbLayer.getCaption("strDearCustomer", objCMS);
                lblYourSubmittedMg = dbLayer.getCaption("strFormSubmiitedMsg", objCMS);
                imgConfirmtickIcon = dbLayer.getCaption("imgConfirmTick", objCMSMsg);
                btnOk = dbLayer.getCaption("strok", objCMS);
                imgDisclaimerIcon = dbLayer.getCaption("imgDisclaimer", objCMS);
                lblDisclaimerForm = dbLayer.getCaption("strDisclaimer", objCMS);
                lblLstContainer = dbLayer.getCaption("strListofContainers", objCMS);
                lblRedSeaGatewayTerminalMg = dbLayer.getCaption("strRedSeaGateway", objCMS);
                lblIHaveReadAgreedMg = dbLayer.getCaption("strReadandAgree", objCMS);
                btnSubmit = dbLayer.getCaption("strSubmit", objCMS);
                lobjBookforManualInspection = dbLayer.getRequestLOV("strBookforManualInspectionlov", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To End assignContent function
        /// </summary>
        /// <returns></returns>
        private async Task submit()
        {
            try
            {
                IsBusy = true;
                DisclaimerEn = false;
                await Task.Delay(1000);
                foreach (var item in lstManuallspectionlocal)
                {
                    //http://172.19.35.68:89/api/DataSource/UpdateManualInspectionStatus/BEAU6375660
                    string strJson = "{ \"CD_ADDTIONALSTATUS\":\"BFM-Requested\"}";
                    string lstrResults = objWebApi.putWebApi("UpdateManualInspectionStatus", strJson, item.ContainerUnitGKey);
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                        App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    gblManualinspection.strCONTAINERNO = item.ContainerNo;
                    gblManualinspection.strCURRDATE = DateTime.Now.ToString("yyyy-MM-dd HHmmss");
                    objWebApi.postWebApi("PostSendEmail", gblManualinspection.ManualinspectionMailData(""));
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                        App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                }
                string lstrBookforManualInspection = "";
                foreach (var item in lobjBookforManualInspection)
                {
                    lstrBookforManualInspection = item.Key;
                }
                string[] lstrTemp = lstrBookforManualInspection.Split(':');
                gblTrackRequests.strTitle = "Book for Manual Inspection";
                gblTrackRequests.strCategoryCode = lstrTemp[0];
                gblTrackRequests.strCategoryDesc1 = "";
                gblTrackRequests.strCategoryDesc2 = "";
                gblTrackRequests.strCaseCode = lstrTemp[1];
                gblTrackRequests.strCaseDesc1 = "";
                gblTrackRequests.strCaseDesc2 = "";
                gblTrackRequests.strRequestTypeCode = lstrTemp[2];
                gblTrackRequests.strRequestTypeDesc1 = "";
                gblTrackRequests.strRequestTypeDesc2 = "";
                gblTrackRequests.strSubCaseCode = lstrTemp[3];
                gblTrackRequests.strSubCaseDesc1 = "";
                gblTrackRequests.strSubCaseDesc2 = "";
                string lstrDate = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss") + "Z";
                await gblRegisteration.getreguser();
                string lstrResult = objWebApi.postWebApi("NewTruckService", gblTrackRequests.TruckRequest("Book for Manual Inspection", lstrDate));
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                await App.Current.MainPage?.Navigation.PushAsync(new Disclaimer_Message());
                DisclaimerEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To click onCheckedChange button function
        /// </summary>
        /// <returns></returns>
        private async Task onCheckedChange()
        {

            try
            {
                await Task.Delay(1000);
                if (CheckDisclaimer == true)
                {
                    ButtonSubmit = true;
                }
                else
                {
                    ButtonSubmit = false;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To click OK button
        /// </summary>
        /// <returns></returns>
        private async Task btn_OK()
        {
            try
            {
                IsBusy = true;
                DisclaimerEn = false;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PopToRootAsync();
                DisclaimerEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
    }
}
