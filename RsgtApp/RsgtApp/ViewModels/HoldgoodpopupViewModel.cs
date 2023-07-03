using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.HoldgoodpopupModel;

namespace RsgtApp.ViewModels
{
     public class HoldgoodpopupViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        // private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private List<clsHoldgoodPopup> lstPopup = new List<clsHoldgoodPopup>();
        //To create bussinessLayer Object
        private BLConnect objCon = new BLConnect();
        private string strLanguage = App.gblLanguage;

        private List<HoldgoodPopup> _lstHoldgoodPopup { get; set; } = new List<HoldgoodPopup>();
        public List<HoldgoodPopup> lstHoldgoodPopup
        {
            get { return _lstHoldgoodPopup; }
            set
            {
                if (_lstHoldgoodPopup == value)
                    return;
                _lstHoldgoodPopup = value;
                OnPropertyChanged();
                RaisePropertyChange("lstHoldgoodPopup");

            }

        }

        //dismisspopup Button 
        public Command Buttondismisspopup { get; set; }
        private string strServerSlowMsg = "";
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
        //imgHoldIcon purpose of using image varaiable
        private string imgHoldIcon = "";
        public string ImgHoldIcon
        {
            get { return imgHoldIcon; }
            set
            {
                imgHoldIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgHoldIcon");
            }
        }
        //LblHoldDetails purpose of using label varaiable
        private string lblHoldDetails = "";
        public string LblHoldDetails
        {
            get { return lblHoldDetails; }
            set
            {
                lblHoldDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblHoldDetails");
            }
        }
        //lblSno purpose of using label varaiable
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
        //btnOk purpose of using label varaiable
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
        //lblDate purpose of using label varaiable
        private string lblDate = "";
        public string LblDate
        {
            get { return lblDate; }
            set
            {
                lblDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDate");
            }
        }
        //lblTime purpose of using label varaiable
        private string lblTime = "";
        public string LblTime
        {
            get { return lblTime; }
            set
            {
                lblTime = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTime");
            }
        }
        //lblHoldType purpose of using label varaiable
        private string lblHoldType = "";
        public string LblHoldType
        {
            get { return lblHoldType; }
            set
            {
                lblHoldType = value;
                OnPropertyChanged();
                RaisePropertyChange("LblHoldType");
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
        //To handle boolean variables
        private bool stackHoldGoodPopup = true;
        public bool StackHoldGoodPopup
        {
            get { return stackHoldGoodPopup; }
            set
            {
                stackHoldGoodPopup = value;
                OnPropertyChanged();
                RaisePropertyChange("StackHoldGoodPopup");
            }
        }
        //To handle boolean variables
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Buttondismisspopup.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// <param name="fstrUnitGkey"></param>
        /// <param name="fsrtFlag"></param>
        public HoldgoodpopupViewModel(string fstrUnitGkey, string fsrtFlag)
        {
            //Begin-Call Caption Function
            Task.Run(() => assignCms()).Wait();
            Task.Run(() => fnHoldgoodpopup(fstrUnitGkey, fsrtFlag)).Wait();
            //End-Caption Function

            //Command Buttons
            Buttondismisspopup = new Command(async () => await Button_dismisspopup(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM013");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM013");
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
        /// To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {
            
            await Task.Delay(1000);

            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            ImgHoldIcon = dbLayer.getCaption("imgHold", objCMS);
            LblHoldDetails = dbLayer.getCaption("strHoldDetails", objCMS);
            LblSno = dbLayer.getCaption("strSno", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
            LblDate= dbLayer.getCaption("strDate", objCMS); 
            LblTime = dbLayer.getCaption("strTime", objCMS); 
            LblHoldType = dbLayer.getCaption("strHoldType", objCMS); 
            LblStatus = dbLayer.getCaption("strPopupStatus", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// To get container list
        /// </summary>
        /// <param name="fstrUnitGkey"></param>
        /// <param name="fsrtFlag"></param>
        private void fnHoldgoodpopup(string fstrUnitGkey, string fsrtFlag)
        {
            int lintCount = 1;
            string fstrFilterData = "";
            string fstrCategory = "IMPRT";
            if (fstrCategory == null) fstrCategory = "IMPRT";
            if (fstrUnitGkey == null) fstrUnitGkey = "";
            string hl_unitgkey = fstrUnitGkey;
            string ht_category = fstrCategory;
            string strApiName = "";
            if ((hl_unitgkey != "") && (ht_category != ""))
            {
                if (fsrtFlag == "Container")
                {
                    fstrFilterData = "hl_unitgkey:" + hl_unitgkey + ";";
                    fstrCategory = "ht_category:" + ht_category + ";";
                    strApiName = "getHoldPopupDetails";
                }
                if (fsrtFlag == "BOL")
                {
                    fstrFilterData = "fstrBLNo:" + hl_unitgkey + ";";
                    strApiName = "getBOLPopup";
                }

            }
            lstPopup = objCon.getHolgoodPopupDetails(gblRegisteration.strLoginUser, strApiName, fstrFilterData);
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            if ((lstPopup != null) && (lstPopup.Count > 0))
            {
                string lstrContainerStatus = "";
                string lstrContainerType = "";
                string lstrCount = "1";
                foreach (var item in lstPopup)
                {
                    if (item.hl_unitgkey == null) item.hl_unitgkey = "";
                    if (item.ht_desc1 == null) item.ht_desc1 = "";
                    if (item.ht_desc2 == null) item.ht_desc2 = "";
                    if (item.ca_name1 == null) item.ca_name1 = "";
                    if (item.ca_name2 == null) item.ca_name2 = "";
                    lstrCount = lintCount.ToString();
                    lstrContainerStatus = item.ca_name1.ToString();
                    lstrContainerType = item.ht_desc1.ToString();
                    if (App.gblLanguage == "Ar")
                    {
                        lstrContainerStatus = item.ca_name2.ToString();
                        lstrContainerType = item.ht_desc2.ToString();
                    }
                    if (item.hl_unitgkey != "")
                    {
                        lstHoldgoodPopup.Add(new HoldgoodPopup { SLNO = lstrCount,
                            date = item.hl_applieddate, 
                            time = item.hl_appliedtime,
                            type = lstrContainerType,
                            status = lstrContainerStatus,
                            lblDate=LblDate,
                            lblHoldType=LblHoldType,
                            lblStatus=LblStatus,
                            lblTime=LblTime
                        });
                    }

                    lintCount++;
                }
            }

        }
        /// <summary>
        /// Dismisspopup Button Function
        /// </summary>
        /// <returns></returns>
        private async Task Button_dismisspopup()
        {
            IsBusy = true;
            StackHoldGoodPopup = false;
            await Task.Delay(1000);
            await Shell.Current.GoToAsync("..");
            StackHoldGoodPopup = true;
            IsBusy = false;
        }

    }
}
