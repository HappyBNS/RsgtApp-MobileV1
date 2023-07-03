using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Views.BOL_list_popup;

namespace RsgtApp.ViewModels
{
    public class BOLListpopupViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
       
        private List<clsBayanpopup> lstPopup = new List<clsBayanpopup>();
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        private string strLanguage = App.gblLanguage;
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        //Declare variables
       
        public int intTotalCount { get; set; }
       
         
        public Command Button_dismissBLpopup { get; set; }
        private string strServerSlowMsg = "";
        //To create Collection Object used ObservableCollection
        private List<BOLPopuplist> _lstBayanPopup { get; set; } = new List<BOLPopuplist>();
        public List<BOLPopuplist> lstBayanPopup
        {
            get { return _lstBayanPopup; }
            set
            {
                if (_lstBayanPopup == value)
                    return;
                _lstBayanPopup = value;
                OnPropertyChanged();
                RaisePropertyChange("lstBayanPopup");

            }

        }


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
        //To declare Set property
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
        //Assign Property Two way Binding
        // To declare boolean variable
        private bool stackBOLPopup = true;
        public bool StackBOLPopup
        {
            get { return stackBOLPopup; }
            set
            {
                stackBOLPopup = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBOLPopup");
            }
        }
        // To declare boolean variable
        private bool stackBayanPopup = true;
        public bool StackBayanPopup
        {
            get { return stackBayanPopup; }
            set
            {
                stackBayanPopup = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBayanPopup");
            }
        }
        // lblBayan represents label variable
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
        // lblBayan represents label variable
        private string lblBilloFLadings = "";
        public string LblBilloFLadings
        {
            get { return lblBilloFLadings; }
            set
            {
                lblBilloFLadings = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBilloFLadings");
            }
        }
        // lblBayan represents label variable
        private string lblSno = "";
        public string LblSno
        {
            get { return lblSno; }
            set
            {
                lblSno = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSno");
            }
        }
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
        // lblBayan represents label variable
        private string lblContainer = "";
        public string LblContainer
        {
            get { return lblContainer; }
            set
            {
                lblContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainer");
            }
        }
        // lblBayan represents label variable
        private string sLNo = "";
        public string SLNo
        {
            get { return sLNo; }
            set
            {
                sLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("SLNo");
            }
        }
        // lblBayan represents label variable
        private string bLNo = "";
        public string BLNo
        {
            get { return bLNo; }
            set
            {
                bLNo = value;
                OnPropertyChanged();
                RaisePropertyChange("BLNo");
            }
        }
        // lblBayan represents label variable
        private string containerCount = "";
        public string ContainerCount
        {
            get { return containerCount; }
            set
            {
                containerCount = value;
                OnPropertyChanged();
                RaisePropertyChange("ContainerCount");
            }
        }
        // lblBayan represents label variable
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
        private string _LblBayanHead = "";
        public string LblBayanHead
        {
            get { return _LblBayanHead; }
            set
            {
                _LblBayanHead = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBayanHead");
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
                Button_dismissBLpopup.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        /// <param name="fstrbayanNo"></param>
        public BOLListpopupViewModel(string fstrbayanNo)
        {
            try
            {
               
                LblBayan = fstrbayanNo;
                //Appcenter Track Event handler
                Analytics.TrackEvent("BOLListpopupViewModel");
                //To Call Caption Function
                Task.Run(() => assignCms()).Wait();
                fnBayanpopup(fstrbayanNo);
                //To call Command Buttons
                Button_dismissBLpopup = new Command(async () => await button_dismissBLpopup(), () => !IsBusy);
                
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// Begin assignCms function
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM011");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM011");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
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
        public void assignContent()
        {
            try
            {
               
                
                LblBayanHead = dbLayer.getCaption("strBAYAN", objCMS) + "  " + LblBayan;
                LblBilloFLadings = dbLayer.getCaption("strBillofLadings", objCMS);
                LblSno = dbLayer.getCaption("strSno", objCMS);
                LblBOL = dbLayer.getCaption("strBOL", objCMS);
                LblContainer = dbLayer.getCaption("strContainer", objCMS);
                BtnOk = dbLayer.getCaption("strok", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignContent function
        /// <summary>
        /// To Get the fnBayanpopup Data
        /// </summary>
        /// <param name="fstrbayanNo"></param>
        private async void fnBayanpopup(string fstrbayanNo)
        {
            try
            {
                int lintCount = 1;
                string fstrFilterData = "";
                if (fstrbayanNo == null) fstrbayanNo = "";
                string fstrBayanNumber = fstrbayanNo;
                if (fstrBayanNumber != "")
                {
                    fstrFilterData += "BLD_BAYANNUMBER:" + fstrBayanNumber + ";";
                }
                lstPopup = objCon.getBayanPopupDetails(gblRegisteration.strLoginUser, fstrFilterData);
               
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                  App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((lstPopup != null) && (lstPopup.Count > 0))
                {
                    foreach (var item in lstPopup)
                    {
                        if (item.bld_blnumber == null) item.bld_blnumber = "";
                       
                        string lstrContainerCount = "";
                        string lstrCount = "";
                        lstrCount = lintCount.ToString();
                        lstrContainerCount = item.bld_count.ToString();
                        if (item.bld_blnumber != "")
                        {
                            lstBayanPopup.Add(new BOLPopuplist { SLNo = lstrCount, BLNo = item.bld_blnumber, ContainerCount = lstrContainerCount });
                        }
                        intTotalCount = lstBayanPopup.Count;
                        lblBilloFLadings = intTotalCount + " " + lblBilloFLadings;
                        lintCount++;
                    }
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
              App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To click dismissBLpopup Button function
        /// </summary>
        /// <returns></returns>
        private async Task button_dismissBLpopup()
        {
            try
            {
                IsBusy = true;
                stackBOLPopup = false;
                await Task.Delay(1000);
                await Shell.Current.GoToAsync("..");
                stackBOLPopup = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
       
    }
}
