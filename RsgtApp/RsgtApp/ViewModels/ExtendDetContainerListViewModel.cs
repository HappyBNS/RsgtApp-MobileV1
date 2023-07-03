using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.ExtendedDetentionModel;

namespace RsgtApp.ViewModels
{
    public class ExtendDetContainerListViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private string strServerSlowMsg = "";
        private string strSelectleastCheckbox = "";
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public List<ExtendedDetention> lstDetentionLst { get; set; } = new List<ExtendedDetention>();
        public Command Btnsubmitrequest { get; set; }
        public Command Tapcontaineradd { get; set; }
        // public Command DeleteContList { get; set; }

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
        //To handle Boolean
        private bool _StackContainerList = true;
        public bool StackContainerList
        {
            get { return _StackContainerList; }
            set
            {
                _StackContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("StackContainerList");
            }
        }
        //ImgDetenIconDarkblue purpose of using label varaiable
        private string _ImgDetenIconDarkblue = "";
        public string ImgDetenIconDarkblue
        {
            get { return _ImgDetenIconDarkblue; }
            set
            {
                _ImgDetenIconDarkblue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDetenIconDarkblue");
            }
        }
        //LblExtendDetContList purpose of using label varaiable
        private string _LblExtendDetContList = "";
        public string LblExtendDetContList
        {
            get { return _LblExtendDetContList; }
            set
            {
                _LblExtendDetContList = value;
                OnPropertyChanged();
                RaisePropertyChange("LblExtendDetContList");
            }
        }
        //LblBillofLading purpose of using label varaiable
        private string _LblBillofLading = "";
        public string LblBillofLading
        {
            get { return _LblBillofLading; }
            set
            {
                _LblBillofLading = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBillofLading");
            }
        }
        //LblBillofLadingVal purpose of using label varaiable
        private string _LblBillofLadingVal = "";
        public string LblBillofLadingVal
        {
            get { return _LblBillofLadingVal; }
            set
            {
                _LblBillofLadingVal = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBillofLadingVal");
            }
        }
        //LblContainerNo purpose of using label varaiable
        private string _LblContainerNo = "";
        public string LblContainerNo
        {
            get { return _LblContainerNo; }
            set
            {
                _LblContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerNo");
            }
        }
        //LblContainerNoVal purpose of using label varaiable
        private string _LblContainerNoVal = "";
        public string LblContainerNoVal
        {
            get { return _LblContainerNoVal; }
            set
            {
                _LblContainerNoVal = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerNoVal");
            }
        }
        //LblDetentionDate purpose of using label varaiable
        private string _LblDetentionDate = "";
        public string LblDetentionDate
        {
            get { return _LblDetentionDate; }
            set
            {
                _LblDetentionDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDetentionDate");
            }
        }
        //LblDetentionDateVal purpose of using label varaiable
        private string _LblDetentionDateVal = "";
        public string LblDetentionDateVal
        {
            get { return _LblDetentionDateVal; }
            set
            {
                _LblDetentionDateVal = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDetentionDateVal");
            }
        }
        //LblDepot purpose of using label varaiable
        private string _LblDepot = "";
        public string LblDepot
        {
            get { return _LblDepot; }
            set
            {
                _LblDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDepot");
            }
        }
        //LblDepotVal purpose of using label varaiable
        private string _LblDepotVal = "";
        public string LblDepotVal
        {
            get { return _LblDepotVal; }
            set
            {
                _LblDepotVal = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDepotVal");
            }
        }
        //BtnDelete purpose of using label varaiable
        private string _BtnDelete = "";
        public string BtnDelete
        {
            get { return _BtnDelete; }
            set
            {
                _BtnDelete = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnDelete");
            }
        }
        //BtnSubmit purpose of using label varaiable
        private string _BtnSubmit = "";
        public string BtnSubmit
        {
            get { return _BtnSubmit; }
            set
            {
                _BtnSubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnSubmit");
            }
        }
        //ImgContainerAddIcon purpose of using Image varaiable
        private string _ImgContainerAddIcon = "";
        public string ImgContainerAddIcon
        {
            get { return _ImgContainerAddIcon; }
            set
            {
                _ImgContainerAddIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgContainerAddIcon");
            }
        }
        //LblAddContainer purpose of using label varaiable
        private string _LblAddContainer = "";
        public string LblAddContainer
        {
            get { return _LblAddContainer; }
            set
            {
                _LblAddContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAddContainer");
            }
        }
        private string msgCheckboxMandatory = "";
        public string MsgCheckboxMandatory
        {
            get { return msgCheckboxMandatory; }
            set
            {
                msgCheckboxMandatory = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCheckboxMandatory");
            }
        }

        //To Handle Boolen Value
        private bool _IsCheckedList = false;
        public bool IsCheckedList
        {
            get { return _IsCheckedList; }
            set
            {
                _IsCheckedList = value;
                OnPropertyChanged();
                RaisePropertyChange("IsCheckedList");
            }
        }
        private bool isenableSubmit = false;
        public bool isEnableSubmit
        {
            get { return isenableSubmit; }
            set
            {
                isenableSubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("isEnableSubmit");
            }
        }
        private bool isChkMandatory = false;
        public bool IsChkMandatory
        {
            get { return isChkMandatory; }
            set
            {
                isChkMandatory = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChkMandatory");
            }
        }



        //CheckBox
        private bool _IsCheckedAll;
        public bool IsCheckedAll // Changes - "Select All" CheckBox Selection
        {
            get

            {
                return _IsCheckedAll;
            }
            set
            {
                _IsCheckedAll = value;
                foreach (ExtendedDetention data in lstDetentionLst)
                {
                    data.cd_CheckBox = value;
                }
                OnPropertyChanged();
                RaisePropertyChange("IsCheckedAll");
            }

        }


        //To Handle Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Btnsubmitrequest.ChangeCanExecute();
                Tapcontaineradd.ChangeCanExecute();
            }
        }
        WebApiMethod objWebApi = new WebApiMethod();
        private string lstrFilterFlag { get; set; }
        public System.Windows.Input.ICommand BtnDeleteContList => new Command<ExtendedDetention>(deleteContList);
        public ExtendDetContainerListViewModel(string fstrContainernumber, string fstrBlnumber, string fstrFilterFlag, string fstrDentionDate, string strSelectedDeport)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ExtendDetentionAddcontainerViewModel");
            Task.Run(() => assignCms()).Wait();
            lstrFilterFlag = fstrFilterFlag;
            Btnsubmitrequest = new Command(async () => await btnsubmitrequest(), () => !IsBusy);
            Tapcontaineradd = new Command(async () => await tapcontaineradd(), () => !IsBusy);
            isEnableSubmit = false;
            if (ExtendedDetentionModel.lstExtendedDetention.Count > 0) isEnableSubmit = true;
            Task.Run(() => fnBindListData()).Wait();
        }
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM467");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM467");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                //objCMSMSG = await dbLayer.LoadContent("RM026");
                assignContent();
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        public async void assignContent()
        {

            ImgDetenIconDarkblue = dbLayer.getCaption("imgDetentionDark", objCMS);
            LblExtendDetContList = dbLayer.getCaption("strExtendDetentionContainersList", objCMS);
            LblBillofLading = dbLayer.getCaption("strBillofLading", objCMS);
            LblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
            LblDetentionDate = dbLayer.getCaption("strDetentionDate", objCMS);
            LblDepot = dbLayer.getCaption("strDepot", objCMS);
            BtnDelete = dbLayer.getCaption("strDelete", objCMS);
            BtnSubmit = dbLayer.getCaption("strSubmit", objCMS);
            ImgContainerAddIcon = dbLayer.getCaption("imgAddContainer", objCMS);
            LblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            strSelectleastCheckbox = dbLayer.getCaption("strSelectleastCheckbox", objCMS);
            await Task.Delay(1000);
        }

        private async Task fnBindListData()
        {
            await Task.Delay(1000);
            if (ExtendedDetentionModel.lstExtendedDetention.Count > 0)
            {
                foreach (var item in ExtendedDetentionModel.lstExtendedDetention)
                {
                    item.lbl_Containerno = LblContainerNo;
                    //item.cd_containernumber = LblContainerNo;
                    item.lbl_Bolno = LblBillofLading;
                    item.lbl_Detentiondate = LblDetentionDate;
                    item.lbl_Newdeport = LblDepot;
                    item.btn_delete = BtnDelete;
                    lstDetentionLst.Add(item);
                }
            }
        }



        public async Task btnsubmitrequest()
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            ExtendDetention();
            // App.Current.MainPage?.Navigation.PushAsync(new ExtendDetRequestMsg());
            StackContainerList = true;
            IsBusy = false;

        }

        public string ExtendDetention()
        {
            string lstrResult = "";
            string ltxtContainerNo = "";
            string ltxtBolNo = "";
            string lDetentionDate = "";
            string lEmptyDepot = "";

            string lstrCT_MESSAGE = "";
            string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
            string lstrCT_USERNAME = gblRegisteration.strLoginUserLinkcode.ToString().Trim();
            string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (ExtendedDetentionModel.lstExtendedDetention.Count > 0)
            {
                string lstrInput = "";

                string lstrFinal = "";
                string strInput = "";
                foreach (var item in ExtendedDetentionModel.lstExtendedDetention)
                {
                    if (item.cd_CheckBox == true)
                    {
                        ltxtContainerNo = item.cd_containernumber;
                        ltxtBolNo = item.cd_blnumber;
                        lDetentionDate = item.cd_DetentionDate;
                        lEmptyDepot = item.cd_NewDeport;

                        // lstrCT_MESSAGE = "Container No :" + ltxtContainerNo + ";Bill Of Lading No:" + ltxtBolNo + ";Detention Date : " + lDetentionDate + ";New Depot : " + lEmptyDepot + ";";

                        lstrInput += "{\\\"BL\\\" : \\\"" + ltxtBolNo + "\\\",\\\"Container\\\" : \\\"" + ltxtContainerNo + "\\\",";
                        lstrInput += "\\\"Detention\\\" : \\\"" + lDetentionDate + "\\\" ,";
                        lstrInput += "\\\"emptyReturn\\\" :\\\"" + lEmptyDepot + "\\\"},";

                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                            App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }

                }


                if (lstrInput.Length == 0)
                {
                    App.Current.MainPage?.DisplayToastAsync(strSelectleastCheckbox, 3000);
                }
                if (lstrInput.Length > 0)
                {
                    lstrInput = lstrInput.Remove(lstrInput.Length - 1);
                    strInput = "{\\\"Detention_Eportal\\\": [" + lstrInput + "]}";
                    strInput = '"' + " " + strInput + "" + '"';

                    lstrFinal = "{\"PA_API\":\"extendDetentionManagement\",\"PA_PARAMETERS\":" + strInput + ",\"PA_STATUS\":\"Requested\"}";

                    lstrResult = objWebApi.postWebApi("PostExtenddetentionManagement", lstrFinal);
                }

            }
            if (lstrResult.ToUpper().Trim() == "TRUE")
            {
                ExtendedDetentionModel.lstExtendedDetention.Clear();
                App.Current.MainPage?.Navigation.PushAsync(new ExtendDetRequestMsg());
            }

            return lstrResult;
        }

        private async Task tapcontaineradd()
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            App.Current.MainPage?.Navigation.PushAsync(new ExtendDetentionAddcontainer(lstrFilterFlag));
            StackContainerList = true;
            IsBusy = false;
        }
        public async void deleteContList(ExtendedDetention objExtendDetention)
        {
            IsBusy = true;
            StackContainerList = false;
            await Task.Delay(1000);
            int lintSNO = objExtendDetention.CD_SNO;
            var index = ExtendedDetentionModel.lstExtendedDetention.FindIndex(x => x.CD_SNO == lintSNO);
            if (index > -1)
            {
                var lstTemp = ExtendedDetentionModel.lstExtendedDetention[index];
                ExtendedDetentionModel.lstExtendedDetention.Remove(lstTemp);
                await App.Current.MainPage?.Navigation.PushAsync(new ExtendDetContainerList("", "", "", "", ""));
            }
            StackContainerList = true;
            IsBusy = false;
        }
    }
}
