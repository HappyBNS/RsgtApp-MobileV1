using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.CommodityPopupModel;

namespace RsgtApp.ViewModels
{
    public class CommodityPopupViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        //private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
         
        private string strLanguage = App.gblLanguage;
        private List<clsCommoditypopup> lstComPopup = new List<clsCommoditypopup>();
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();

        public Command ButtondismissBLpopup { get; set; }
        string strServerSlowMsg = "";

        private List<COMPopuplist> _lstCommodityPopup { get; set; } =  new List<COMPopuplist>();
        public List<COMPopuplist> lstCommodityPopup
        {
            get { return _lstCommodityPopup; }
            set
            {
                if (_lstCommodityPopup == value)
                    return;
                _lstCommodityPopup = value;
                OnPropertyChanged();
                RaisePropertyChange("lstCommodityPopup");

            }

        }

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
        //To Handle Indicator 
        private bool stackCommodityPopup = true;
        public bool StackCommodityPopup
        {
            get { return stackCommodityPopup; }
            set
            {
                stackCommodityPopup = value;
                OnPropertyChanged();
                RaisePropertyChange("StackCommodityPopup");
            }
        }
        //LblCommodityCodes purpose of using Label varaiable
        private string lblCommodityCodes = "";
        public string LblCommodityCodes
        {
            get { return lblCommodityCodes; }
            set
            {
                lblCommodityCodes = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCommodityCodes");
            }
        }
        //LblCode purpose of using Label varaiable
        private string lblCode = "";
        public string LblCode
        {
            get { return lblCode; }
            set
            {
                lblCode = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCode");
            }
        }
        //LblDescription purpose of using Label varaiable
        private string lblDescription = "";
        public string LblDescription
        {
            get { return lblDescription; }
            set
            {
                lblDescription = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDescription");
            }
        }
        //BtnOk purpose of using Button varaiable
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
        //To Handel Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                ButtondismissBLpopup.ChangeCanExecute();

            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="fstrBLNo"></param>
        public CommodityPopupViewModel(string fstrBLNo)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("CommodityPopupViewModel");
            //Begin-Call Caption Function
            Task.Run(() => assignCms()).Wait();
            //End-Call Caption Function

            //Begin Command Button
            ButtondismissBLpopup = new Command(async () => await buttondismissBLpopup(), () => !IsBusy);
            //End Command Button
            ComPopupData(fstrBLNo);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM012");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM012");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// Function for caption and flowdirection (English - left to right / Arabic - right to left)
        /// </summary>
        public async void assignContent()
        {
          
           
            //dbLayer.lintLanguage = lintIndex;
            // dbLayer.objInfoitems = objCMS;

            LblCommodityCodes = dbLayer.getCaption("strCommodityCodes", objCMS);
            LblCode = dbLayer.getCaption("strCode", objCMS);
            LblDescription = dbLayer.getCaption("strDescription", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
            await Task.Delay(1000);

        }
        /// <summary>
        /// To get Commodity Popup Data
        /// </summary>
        /// <param name="fstrBLNo"></param>
        private void ComPopupData(string fstrBLNo)
        {
            int lintCount = 1;

            string fstrFilterData = "";
            if (fstrBLNo == null) fstrBLNo = "";
            string fstrBLNumber = fstrBLNo;
            //BLNo
            try
            {
                fstrFilterData += "CD_BLNUMBER:" + fstrBLNumber + ";";

                lstComPopup = objCon.getBOLPopupDetails(gblRegisteration.strLoginUser, fstrFilterData);

                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                if ((lstComPopup != null) && (lstComPopup.Count > 0))
                {
                    foreach (var item in lstComPopup)
                    {
                        if (item.code == null) item.code = "";
                        if (item.description == null) item.description = "";
                        if (item.cd_blnumber != "")
                        {
                            lstCommodityPopup.Add(new COMPopuplist { Code = item.code, Description = item.description });
                        }
                        lintCount++;
                    }
                }
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
        /// To get Button Dissmiss Popup
        /// </summary>
        /// <returns></returns>
        private async Task buttondismissBLpopup()
        {

            IsBusy = true;
            StackCommodityPopup = false;
            await Task.Delay(1000);
            await Shell.Current.GoToAsync("..");
            StackCommodityPopup = true;
            IsBusy = false;
            //Dismiss(null);
            // Navigation.PushAsync(new BOL("", "", "", "", "", ""));
        }
    }
}