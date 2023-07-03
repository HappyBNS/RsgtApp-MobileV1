using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
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
    public class ExtendDetentionAddcontainerViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();

        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonpopulate { get; set; }

        public Command ButtonAdd { get; set; }
        public Command TapContainerlist { get; set; }

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
        private bool _StackAddcontainer = true;
        public bool StackAddcontainer
        {
            get { return _StackAddcontainer; }
            set
            {
                _StackAddcontainer = value;
                OnPropertyChanged();
                RaisePropertyChange("StackAddcontainer");
            }
        }
        //ImgDetenIconDarkblue purpose of using Image varaiable
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
        //LblExtendDetenbyCont purpose of using label varaiable
        private string _LblExtendDetenbyCont = "";
        public string LblExtendDetenbyCont
        {
            get { return _LblExtendDetenbyCont; }
            set
            {
                _LblExtendDetenbyCont = value;
                OnPropertyChanged();
                RaisePropertyChange("LblExtendDetenbyCont");
            }
        }
        //ImgContainerAddblueIcon purpose of using Image varaiable
        private string _ImgContainerAddblueIcon = "";
        public string ImgContainerAddblueIcon
        {
            get { return _ImgContainerAddblueIcon; }
            set
            {
                _ImgContainerAddblueIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgContainerAddblueIcon");
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
        //LblContainerNumber purpose of using label varaiable
        private string _LblContainerNumber = "";
        public string LblContainerNumber
        {
            get { return _LblContainerNumber; }
            set
            {
                _LblContainerNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerNumber");
            }
        }
        //LblBOLNumber purpose of using label varaiable
        private string _LblBOLNumber = "";
        public string LblBOLNumber
        {
            get { return _LblBOLNumber; }
            set
            {
                _LblBOLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBOLNumber");
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
        //LblEmptyDepot purpose of using label varaiable
        private string _LblEmptyDepot = "";
        public string LblEmptyDepot
        {
            get { return _LblEmptyDepot; }
            set
            {
                _LblEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("LblEmptyDepot");
            }
        }
        //LblNewDepotName purpose of using label varaiable
        private string _LblNewDepotName = "";
        public string LblNewDepotName
        {
            get { return _LblNewDepotName; }
            set
            {
                _LblNewDepotName = value;
                OnPropertyChanged();
                RaisePropertyChange("LblNewDepotName");
            }
        }
        //BtnNext purpose of using label varaiable
        private string _BtnNext = "";
        public string BtnNext
        {
            get { return _BtnNext; }
            set
            {
                _BtnNext = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnNext");
            }
        }
        //ImgContainerIconwhite purpose of using Image varaiable
        private string _ImgContainerIconwhite = "";
        public string ImgContainerIconwhite
        {
            get { return _ImgContainerIconwhite; }
            set
            {
                _ImgContainerIconwhite = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgContainerIconwhite");
            }
        }
        //LblContainerList purpose of using label varaiable
        private string _LblContainerList = "";
        public string LblContainerList
        {
            get { return _LblContainerList; }
            set
            {
                _LblContainerList = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerList");
            }
        }
        //TxtContainerNo purpose of using Textbox varaiable
        private string _TxtContainerNo = "";
        public string TxtContainerNo
        {
            get { return _TxtContainerNo; }
            set
            {
                _TxtContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtContainerNo");
            }
        }
        //TxtBOLNumber purpose of using Textbox varaiable
        private string _TxtBOLNumber = "";
        public string TxtBOLNumber
        {
            get { return _TxtBOLNumber; }
            set
            {
                _TxtBOLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBOLNumber");
            }
        }
        //TxtDetentionDate purpose of using Textbox varaiable
        private string _TxtDetentionDate = "";
        public string TxtDetentionDate
        {
            get { return _TxtDetentionDate; }
            set
            {
                _TxtDetentionDate = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDetentionDate");
            }
        }

        private string _MsgContainerNo = "";
        public string MsgContainerNo
        {
            get { return _MsgContainerNo; }
            set
            {
                _MsgContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgContainerNo");
            }
        }
        private string _MsgBOLNumber = "";
        public string MsgBOLNumber
        {
            get { return _MsgBOLNumber; }
            set
            {
                _MsgBOLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgBOLNumber");
            }
        }
        private string _MsgDetentionDate = "";
        public string MsgDetentionDate
        {
            get { return _MsgDetentionDate; }
            set
            {
                _MsgDetentionDate = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgDetentionDate");
            }
        }
        private string _MsgEmptyDepot = "";
        public string MsgEmptyDepot
        {
            get { return _MsgEmptyDepot; }
            set
            {
                _MsgEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgEmptyDepot");
            }
        }
        private string msgNewDepot = "";
        public string MsgNewDepot
        {
            get { return msgNewDepot; }
            set
            {
                msgNewDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgNewDepot");
            }
        }
        private bool _IsvalidatedContainerNo = false;
        public bool IsvalidatedContainerNo
        {
            get { return _IsvalidatedContainerNo; }
            set
            {
                _IsvalidatedContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedContainerNo");
            }
        }
        private bool isvalidatedNewDepot = false;
        public bool IsvalidatedNewDepot
        {
            get { return isvalidatedNewDepot; }
            set
            {
                isvalidatedNewDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedNewDepot");
            }
        }
        private bool _IsvalidatedBOLNumber = false;
        public bool IsvalidatedBOLNumber
        {
            get { return _IsvalidatedBOLNumber; }
            set
            {
                _IsvalidatedBOLNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedBOLNumber");
            }
        }
        private bool _IsvalidatedDetentionDate = false;
        public bool IsvalidatedDetentionDate
        {
            get { return _IsvalidatedDetentionDate; }
            set
            {
                _IsvalidatedDetentionDate = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedDetentionDate");
            }
        }
        private bool _IsvalidatedEmptyDepot = false;
        public bool IsvalidatedEmptyDepot
        {
            get { return _IsvalidatedEmptyDepot; }
            set
            {
                _IsvalidatedEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedEmptyDepot");
            }
        }
        private DateTime? detentionDate = null;
        public DateTime? DetentionDate
        {
            get { return detentionDate; }
            set
            {
                detentionDate = value;
                OnPropertyChanged();
                RaisePropertyChange("DetentionDate");
            }
        }
        private string txtSNO = "0";
        public string TxtSNO
        {
            get { return txtSNO; }
            set
            {
                txtSNO = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtSNO");
            }
        }
        private string txtNewDepotName = "";
        public string TxtNewDepotName
        {
            get { return txtNewDepotName; }
            set
            {
                txtNewDepotName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtNewDepotName");
            }
        }
        //To declare combo variable
        private List<EnumCombo> _lobjEmptyDepot = new List<EnumCombo>();
        public List<EnumCombo> lobjEmptyDepot
        {
            get { return _lobjEmptyDepot; }
            set
            {
                _lobjEmptyDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjEmptyDepot");
            }
        }

        //To declare combo variable
        private EnumCombo _SelectedEmptyDepot;
        public EnumCombo SelectedEmptyDepot
        {
            get { return _SelectedEmptyDepot; }
            set
            {
                SetProperty(ref _SelectedEmptyDepot, value);
                if (SelectedEmptyDepot.Value == "47")
                {
                    IsVisibleDeportName = true;
                    IsVisibleEntryDepot = true;
                }
            }
        }
        private bool isVisibleDeportName = false;
        public bool IsVisibleDeportName
        {
            get { return isVisibleDeportName; }
            set
            {
                isVisibleDeportName = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleDeportName");
            }
        }
        private bool isVisibleEntryDepot = false;
        public bool IsVisibleEntryDepot
        {
            get { return isVisibleEntryDepot; }
            set
            {
                isVisibleEntryDepot = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleEntryDepot");
            }
        }
        private bool isVisibleAddBtn = false;
        public bool IsVisibleAddBtn
        {
            get { return isVisibleAddBtn; }
            set
            {
                isVisibleAddBtn = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleAddBtn");
            }
        }
        private bool isVisiblePopulateBtn = false;
        public bool IsVisiblePopulateBtn
        {
            get { return isVisiblePopulateBtn; }
            set
            {
                isVisiblePopulateBtn = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisiblePopulateBtn");
            }
        }
        private bool isVisibleContainerLbl = false;
        public bool IsVisibleContainerLbl
        {
            get { return isVisibleContainerLbl; }
            set
            {
                isVisibleContainerLbl = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleContainerLbl");
            }
        }
        private bool isVisibleContainerEntry = false;
        public bool IsVisibleContainerEntry
        {
            get { return isVisibleContainerEntry; }
            set
            {
                isVisibleContainerEntry = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleContainerEntry");
            }
        }
        private bool isVisibleContainerImg = false;
        public bool IsVisibleContainerImg
        {
            get { return isVisibleContainerImg; }
            set
            {
                isVisibleContainerImg = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleContainerImg");
            }
        }
        private bool isVisibleContainerbtn = false;
        public bool IsVisibleContainerbtn
        {
            get { return isVisibleContainerbtn; }
            set
            {
                isVisibleContainerbtn = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleContainerbtn");
            }
        }

        //BtnPopulate purpose of using label varaiable
        private string _BtnPopulate = "";
        public string BtnPopulate
        {
            get { return _BtnPopulate; }
            set
            {
                _BtnPopulate = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnPopulate");
            }
        }

        private string msgErrorMsg = "";
        public string MsgErrorMsg
        {
            get { return msgErrorMsg; }
            set
            {
                msgErrorMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgErrorMsg");
            }
        }
        private bool isvalidatedConBol = false;
        public bool IsvalidatedConBol
        {
            get { return isvalidatedConBol; }
            set
            {
                isvalidatedConBol = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedConBol");
            }
        }

        string lstrDtDate = "";
        private string strServerSlowMsg = "";
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
                ButtonAdd.ChangeCanExecute();
                TapContainerlist.ChangeCanExecute();
                Buttonpopulate.ChangeCanExecute();
            }
        }
        private string lstrFilterFlag { get; set; }
        public List<ExtendedDetention> lstExtendedDetention { get; set; } = new List<ExtendedDetention>();
        public ExtendDetentionAddcontainerViewModel(string fstrFilterFlag)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ExtendDetentionAddcontainerViewModel");
            Task.Run(() => assignCms()).Wait();
            lstrFilterFlag = fstrFilterFlag;
            if (fstrFilterFlag == "Y")
            {
                IsVisibleAddBtn = true;
                IsVisiblePopulateBtn = false;
                IsVisibleContainerLbl = true;
                IsVisibleContainerEntry = true;
                IsVisibleContainerImg = true;
                IsVisibleContainerbtn = true;
            }
            if (fstrFilterFlag == "N")
            {
                IsVisiblePopulateBtn = true;
                IsVisibleAddBtn = false;
                IsVisibleContainerLbl = false;
                IsVisibleContainerEntry = false;
                IsVisibleContainerImg = false;
                IsVisibleContainerbtn = false;
            }
            ButtonAdd = new Command(async () => await buttonAdd(), () => !IsBusy);
            TapContainerlist = new Command(async () => await tapContainerlist(), () => !IsBusy);
            Buttonpopulate = new Command(async () => await buttonAdd(), () => !IsBusy);

        }
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM467");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM467");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
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
            await Task.Delay(1000);

            ImgDetenIconDarkblue = dbLayer.getCaption("imgDetentionDark", objCMS);
            LblExtendDetenbyCont = dbLayer.getCaption("strExtendDetentionContainer", objCMS);
            ImgContainerAddblueIcon = dbLayer.getCaption("imgAddContainerBlue", objCMS);
            LblAddContainer = dbLayer.getCaption("strAddContainer", objCMS);
            LblContainerNumber = dbLayer.getCaption("strContainerNoMandatory", objCMS);
            LblBOLNumber = dbLayer.getCaption("strBillofLadingMandatory", objCMS);
            LblDetentionDate = dbLayer.getCaption("strDetentionDateMandatory", objCMS);
            LblEmptyDepot = dbLayer.getCaption("strEmptyDepotMandatory", objCMS);
            LblNewDepotName = dbLayer.getCaption("strNewDepot", objCMS);
            BtnNext = dbLayer.getCaption("strNext", objCMS);
            ImgContainerIconwhite = dbLayer.getCaption("imgContainerWhite", objCMS);
            LblContainerList = dbLayer.getCaption("strContainerList", objCMS);
            MsgContainerNo = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgBOLNumber = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgDetentionDate = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgEmptyDepot = dbLayer.getCaption("strMandatory", objCMSMsg);
            MsgNewDepot = dbLayer.getCaption("strMandatory", objCMSMsg);
            lobjEmptyDepot = dbLayer.getEnumSortOrder("strEmptyDepotsNames", objCMS);
            BtnPopulate = dbLayer.getCaption("strPOPULATE", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            MsgErrorMsg = dbLayer.getCaption("strEnterednotvalidMsg", objCMS);
        }

        private async Task buttonAdd()
        {
            IsBusy = true;
            StackAddcontainer = false;
            await Task.Delay(1000);
            HideErrorMsg();
            bool blResult = false;
            var ContainerNo = TxtContainerNo.ToString().Trim();
            var BolNo = TxtBOLNumber.ToString().Trim();
            var Deport = TxtNewDepotName.ToString().Trim();

            if (lstrFilterFlag == "Y")
            {
                if ((ContainerNo == null) || (ContainerNo == ""))
                {
                    blResult = true;
                    IsvalidatedContainerNo = true;
                }
                else
                {
                    IsvalidatedContainerNo = false;
                }

            }

            if ((BolNo == null) || (BolNo == ""))
            {
                blResult = true;
                IsvalidatedBOLNumber = true;
            }
            else
            {
                IsvalidatedBOLNumber = false;
            }
            if ((DetentionDate != null) || (SelectedEmptyDepot != null))
            {

                if (DetentionDate != null)
                {


                    if (DateTime.Now.Date > DetentionDate.Value)
                    {
                        blResult = true;
                        IsvalidatedDetentionDate = true;
                    }
                    else
                    {
                        IsvalidatedDetentionDate = false;
                        lstrDtDate = DetentionDate.Value.ToString("dd-MM-yyyy");
                    }

                }
                //else
                //{
                //    blResult = true;
                //    IsvalidatedDetentionDate = true;
                //}
                if (SelectedEmptyDepot != null)
                {
                    IsvalidatedEmptyDepot = false;
                }
                //else
                //{
                //    blResult = true;
                //    IsvalidatedEmptyDepot = true;
                //}
            }
            else
            {
                blResult = true;
                IsvalidatedEmptyDepot = true;
            }
            var strSelectedDeport = "";

            if (SelectedEmptyDepot != null)
            {
                strSelectedDeport = SelectedEmptyDepot.Key;
                if (SelectedEmptyDepot.Value == "47")
                {
                    strSelectedDeport = Deport;
                }


                if ((strSelectedDeport != null) && (strSelectedDeport != ""))
                {

                    IsvalidatedNewDepot = false;
                }
                else
                {
                    blResult = true;
                    IsvalidatedNewDepot = true;
                }

            }
            if (blResult == false)
            {
                if (lstrFilterFlag == "Y")
                {


                    await FnAdd(ContainerNo, BolNo, lstrDtDate, strSelectedDeport);

                }
                if (lstrFilterFlag == "N")
                {


                    await FnPopulate(ContainerNo, BolNo, lstrDtDate, strSelectedDeport);

                }
            }

            // App.Current.MainPage?.Navigation.PushAsync(new ExtendDetContainerList());
            StackAddcontainer = true;
            IsBusy = false;
        }
        private async Task FnPopulate(string fstrContainernumber, string fstrBlnumber, string fstrDentionDate, string strSelectedDeport)
        {
            bool blResult = false;
            if (blResult == false)
            {
                var objRawData = new List<ExtendedDetention>();
                objRawData = objBl.RetreiveExtendedDetention(fstrContainernumber, fstrBlnumber);

                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }

                if ((objRawData != null) && (objRawData.Count > 0))
                {
                    foreach (var item in objRawData)
                    {
                        int lintSNO = Convert.ToInt32(TxtSNO);
                        var objExtentionDetentionModel = new ExtendedDetention();
                        objExtentionDetentionModel.cd_containernumber = item.cd_containernumber;
                        objExtentionDetentionModel.cd_blnumber = fstrBlnumber.ToString().Trim();
                        objExtentionDetentionModel.cd_DetentionDate = fstrDentionDate;
                        objExtentionDetentionModel.cd_NewDeport = strSelectedDeport;
                        lstExtendedDetention.Add(item);


                        ExtendedDetentionModel.lintExtendDetionSno = ExtendedDetentionModel.lintExtendDetionSno + 1;
                        objExtentionDetentionModel.CD_SNO = ExtendedDetentionModel.lintExtendDetionSno;
                        ExtendedDetentionModel.lstExtendedDetention.Add(objExtentionDetentionModel);

                    }
                    if (ExtendedDetentionModel.lstExtendedDetention.Count > 0)
                    {
                        await App.Current.MainPage?.Navigation.PushAsync(new ExtendDetContainerList(fstrContainernumber, fstrBlnumber, lstrFilterFlag, fstrDentionDate, strSelectedDeport));
                    }
                }
                else
                {
                    IsvalidatedConBol = true;
                }
            }
        }
        private async Task FnAdd(string fstrContainernumber, string fstrBlnumber, string fstrDentionDate, string strSelectedDeport)
        {
            bool blResult = false;
            if (blResult == false)
            {
                var objRawData = new List<ExtendedDetention>();
                objRawData = objBl.RetreiveExtendedDetention(fstrContainernumber, fstrBlnumber);



                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if ((objRawData != null) && (objRawData.Count > 0))
                {
                    int lintSNO = Convert.ToInt32(TxtSNO);
                    var objExtentionDetentionModel = new ExtendedDetention();
                    objExtentionDetentionModel.cd_containernumber = fstrContainernumber.ToString().Trim();
                    objExtentionDetentionModel.cd_blnumber = fstrBlnumber.ToString().Trim();
                    objExtentionDetentionModel.cd_DetentionDate = fstrDentionDate;
                    objExtentionDetentionModel.cd_NewDeport = strSelectedDeport;
                    objExtentionDetentionModel.cd_CheckBox = true;

                    ExtendedDetentionModel.lintExtendDetionSno = ExtendedDetentionModel.lintExtendDetionSno + 1;
                    objExtentionDetentionModel.CD_SNO = ExtendedDetentionModel.lintExtendDetionSno;
                    ExtendedDetentionModel.lstExtendedDetention.Add(objExtentionDetentionModel);

                    if (ExtendedDetentionModel.lstExtendedDetention.Count > 0)
                    {
                        await App.Current.MainPage?.Navigation.PushAsync(new ExtendDetContainerList(fstrContainernumber, fstrBlnumber, lstrFilterFlag, fstrDentionDate, strSelectedDeport));
                    }
                    else
                    {
                        IsvalidatedConBol = true;
                    }
                }


            }
        }

        private void HideErrorMsg()
        {
            IsvalidatedContainerNo = false;
            IsvalidatedBOLNumber = false;
            IsvalidatedDetentionDate = false;
            IsvalidatedEmptyDepot = false;
            IsvalidatedConBol = false;
        }
        private async Task tapContainerlist()
        {
            IsBusy = true;
            StackAddcontainer = false;
            await Task.Delay(1000);
            App.Current.MainPage?.Navigation.PushAsync(new ExtendDetContainerList("", "", "", "", ""));
            StackAddcontainer = true;
            IsBusy = false;
        }
    }
}
