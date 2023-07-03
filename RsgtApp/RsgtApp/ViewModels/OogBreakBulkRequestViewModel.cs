using Microsoft.AppCenter.Analytics;
using Plugin.FilePicker;
using RsgtApp.BusinessLayer;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.OOGCalcuationModel;
using static RsgtApp.ViewModels.BreakBulk_PriceCalculationViewModel;

namespace RsgtApp.ViewModels
{
    public class OogBreakBulkRequestViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        public List<EnumCombo> lobjOogBreakBulkrequest { get; set; } = new List<EnumCombo>();
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command Buttonsubmit { get; set; }
        public Command Tapmanifestrequesthistory { get; set; }
        public Command Buttonreset { get; set; }
        //Button_Clicked Button
        public Command ButtonchooseFile { get; set; }
        public Command ButtonchooseFile2 { get; set; }
        public Command ButtonchooseFile3 { get; set; }
        public Command ButtonchooseFile4 { get; set; }
        public Command ButtonchooseFile5 { get; set; }
        public Command ButtonchooseFile6 { get; set; }
        public Command ButtonchooseFile7 { get; set; }
        public Command ButtonchooseFile8 { get; set; }
        public Command ButtonchooseFile9 { get; set; }
        public Command ButtonchooseFile1 { get; set; }

        //btnCancel Button
        public Command ButtonCancel { get; set; }
        public Command ButtonCancel2 { get; set; }
        public Command ButtonCancel3 { get; set; }
        public Command ButtonCancel4 { get; set; }
        public Command ButtonCancel5 { get; set; }
        public Command ButtonCancel6 { get; set; }
        public Command ButtonCancel7 { get; set; }
        public Command ButtonCancel8 { get; set; }
        public Command ButtonCancel9 { get; set; }
        public Command ButtonCancel1 { get; set; }
        public Command ButtonOOG { get; set; }
        public Command ButtonBreakBulk { get; set; }
        public Command PickerCargoChanged { get; set; }
        private string strServerSlowMsg = "";

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
        private bool stackOogBreakBulkRequest = true;
        public bool StackOogBreakBulkRequest
        {
            get { return stackOogBreakBulkRequest; }
            set
            {
                stackOogBreakBulkRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("StackOogBreakBulkRequest");
            }
        }
        private string imgoOGBreakbulkIcon = "";
        public string imgOOGBreakbulkIcon
        {
            get { return imgoOGBreakbulkIcon; }
            set
            {
                imgoOGBreakbulkIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgOOGBreakbulkIcon");
            }
        }
        private string lbloOGBreakbulkRequest = "";
        public string lblOOGBreakbulkRequest
        {
            get { return lbloOGBreakbulkRequest; }
            set
            {
                lbloOGBreakbulkRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOOGBreakbulkRequest");
            }
        }
        private string imgrequestIconDark = "";
        public string imgRequestIconDark
        {
            get { return imgrequestIconDark; }
            set
            {
                imgrequestIconDark = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRequestIconDark");
            }
        }
        private string lbloOGRequestForm = "";
        public string lblOOGRequestForm
        {
            get { return lbloOGRequestForm; }
            set
            {
                lbloOGRequestForm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOOGRequestForm");
            }
        }
        private string lblshippingLine = "";
        public string lblShippingLine
        {
            get { return lblshippingLine; }
            set
            {
                lblshippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("lblShippingLine");
            }
        }
        private string txtShippingLine = "";
        public string TxtShippingLine
        {
            get { return txtShippingLine; }
            set
            {
                txtShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtShippingLine");
            }
        }
        private string lbltypeofCargo = "";
        public string lblTypeofCargo
        {
            get { return lbltypeofCargo; }
            set
            {
                lbltypeofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTypeofCargo");
            }
        }
        private string txtTypeofCargo = "";
        public string TxtTypeofCargo
        {
            get { return txtTypeofCargo; }
            set
            {
                txtTypeofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTypeofCargo");
            }
        }
        private string lblcategoryofCargo = "";
        public string lblCategoryofCargo
        {
            get { return lblcategoryofCargo; }
            set
            {
                lblcategoryofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCategoryofCargo");
            }
        }
        private string txtCategoryofCargo = "";
        public string TxtCategoryofCargo
        {
            get { return txtCategoryofCargo; }
            set
            {
                txtCategoryofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCategoryofCargo");
            }
        }
        private string lbldimension = "";
        public string lblDimension
        {
            get { return lbldimension; }
            set
            {
                lbldimension = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDimension");
            }
        }
        private string txtDimension = "";
        public string TxtDimension
        {
            get { return txtDimension; }
            set
            {
                txtDimension = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDimension");
            }
        }
        private string lblweight = "";
        public string lblWeight
        {
            get { return lblweight; }
            set
            {
                lblweight = value;
                OnPropertyChanged();
                RaisePropertyChange("lblWeight");
            }
        }
        private string txtWeight = "";
        public string TxtWeight
        {
            get { return txtWeight; }
            set
            {
                txtWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtWeight");
            }
        }
        private string lblnoFlatTrunk = "";
        public string lblNoFlatTrunk
        {
            get { return lblnoFlatTrunk; }
            set
            {
                lblnoFlatTrunk = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNoFlatTrunk");
            }
        }
        private string txtNoFlatTrunk = "";
        public string TxtNoFlatTrunk
        {
            get { return txtNoFlatTrunk; }
            set
            {
                txtNoFlatTrunk = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtNoFlatTrunk");
            }
        }
        private string lblstowagePosition = "";
        public string lblStowagePosition
        {
            get { return lblstowagePosition; }
            set
            {
                lblstowagePosition = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStowagePosition");
            }
        }
        private string txtStowagePosition = "";
        public string TxtStowagePosition
        {
            get { return txtStowagePosition; }
            set
            {
                txtStowagePosition = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtStowagePosition");
            }
        }
        private string lbldischargingDetails = "";
        public string lblDischargingDetails
        {
            get { return lbldischargingDetails; }
            set
            {
                lbldischargingDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDischargingDetails");
            }
        }
        private string txtDischargingDetails = "";
        public string TxtDischargingDetails
        {
            get { return txtDischargingDetails; }
            set
            {
                txtDischargingDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDischargingDetails");
            }
        }
        private string lblloadingDetails = "";
        public string lblLoadingDetails
        {
            get { return lblloadingDetails; }
            set
            {
                lblloadingDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLoadingDetails");
            }
        }
        private string txtLoadingDetails = "";
        public string TxtLoadingDetails
        {
            get { return txtLoadingDetails; }
            set
            {
                txtLoadingDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLoadingDetails");
            }
        }
        private string lblphoto = "";
        public string lblPhoto
        {
            get { return lblphoto; }
            set
            {
                lblphoto = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPhoto");
            }
        }
        private string lblimage1 = "";
        public string lblImage1
        {
            get { return lblimage1; }
            set
            {
                lblimage1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblImage1");
            }
        }
        private string txtImage1 = "";
        public string TxtImage1
        {
            get { return txtImage1; }
            set
            {
                txtImage1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtImage1");
            }
        }
        private string imgdeleteIcon = "";
        public string imgDeleteIcon
        {
            get { return imgdeleteIcon; }
            set
            {
                imgdeleteIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDeleteIcon");
            }
        }
        private string lblimage2 = "";
        public string lblImage2
        {
            get { return lblimage2; }
            set
            {
                lblimage2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblImage2");
            }
        }
        private string txtImage2 = "";
        public string TxtImage2
        {
            get { return txtImage2; }
            set
            {
                txtImage2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtImage2");
            }
        }
        private string imgdeleteIcon1 = "";
        public string imgDeleteIcon1
        {
            get { return imgdeleteIcon1; }
            set
            {
                imgdeleteIcon1 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgDeleteIcon1");
            }
        }
        private string btnAddImage = "";
        public string BtnAddImage
        {
            get { return btnAddImage; }
            set
            {
                btnAddImage = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnAddImage");
            }
        }
        private string btnReset = "";
        public string BtnReset
        {
            get { return btnReset; }
            set
            {
                btnReset = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnReset");
            }
        }
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
        private string msgShippingLine = "";
        public string MsgShippingLine
        {
            get { return msgShippingLine; }
            set
            {
                msgShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgShippingLine");
            }
        }
        private bool isvalidatedShippingLine = false;
        public bool IsvalidatedShippingLine
        {
            get { return isvalidatedShippingLine; }
            set
            {
                isvalidatedShippingLine = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedShippingLine");
            }
        }
        private string msgTypeofCargo = "";
        public string MsgTypeofCargo
        {
            get { return msgTypeofCargo; }
            set
            {
                msgTypeofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTypeofCargo");
            }
        }
        private bool isvalidatedTypeofCargo = false;
        public bool IsvalidatedTypeofCargo
        {
            get { return isvalidatedTypeofCargo; }
            set
            {
                isvalidatedTypeofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedTypeofCargo");
            }
        }
        private string msgCategoryofCargo = "";
        public string MsgCategoryofCargo
        {
            get { return msgCategoryofCargo; }
            set
            {
                msgCategoryofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCategoryofCargo");
            }
        }
        private bool isvalidatedCategoryofCargo = false;
        public bool IsvalidatedCategoryofCargo
        {
            get { return isvalidatedCategoryofCargo; }
            set
            {
                isvalidatedCategoryofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCategoryofCargo");
            }
        }
        private string msgDimension = "";
        public string MsgDimension
        {
            get { return msgDimension; }
            set
            {
                msgDimension = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgDimension");
            }
        }
        private bool isvalidatedDimension = false;
        public bool IsvalidatedDimension
        {
            get { return isvalidatedDimension; }
            set
            {
                isvalidatedDimension = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedDimension");
            }
        }
        private string msgWeight = "";
        public string MsgWeight
        {
            get { return msgWeight; }
            set
            {
                msgWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgWeight");
            }
        }
        private bool isvalidatedWeight = false;
        public bool IsvalidatedWeight
        {
            get { return isvalidatedWeight; }
            set
            {
                isvalidatedWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedWeight");
            }
        }
        private string msgNoFlatTrunk = "";
        public string MsgNoFlatTrunk
        {
            get { return msgNoFlatTrunk; }
            set
            {
                msgNoFlatTrunk = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgNoFlatTrunk");
            }
        }
        private bool isvalidatedNoFlatTrunk = false;
        public bool IsvalidatedNoFlatTrunk
        {
            get { return isvalidatedNoFlatTrunk; }
            set
            {
                isvalidatedNoFlatTrunk = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedNoFlatTrunk");
            }
        }
        private string msgStowagePosition = "";
        public string MsgStowagePosition
        {
            get { return msgStowagePosition; }
            set
            {
                msgStowagePosition = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgStowagePosition");
            }
        }
        private bool isvalidatedStowagePosition = false;
        public bool IsvalidatedStowagePosition
        {
            get { return isvalidatedStowagePosition; }
            set
            {
                isvalidatedStowagePosition = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedStowagePosition");
            }
        }

        private string imghistoryicon = "";
        public string imgHistoryicon
        {
            get { return imghistoryicon; }
            set
            {
                imghistoryicon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgHistoryicon");
            }
        }
        private string lblrequestHistory = "";
        public string lblRequestHistory
        {
            get { return lblrequestHistory; }
            set
            {
                lblrequestHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestHistory");
            }
        }
        //To handle Boolean variable
        private bool lblfilename = false;
        public bool lblFilename
        {
            get { return lblfilename; }
            set
            {
                lblfilename = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename");
            }
        }
        //To handle Boolean variable
        private bool lblfilename2 = false;
        public bool lblFilename2
        {
            get { return lblfilename2; }
            set
            {
                lblfilename2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename2");
            }
        }
        //To handle Boolean variable
        private bool lblfilename3 = false;
        public bool lblFilename3
        {
            get { return lblfilename3; }
            set
            {
                lblfilename3 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename3");
            }
        }
        //To handle Boolean variable
        private bool lblfilename4 = false;
        public bool lblFilename4
        {
            get { return lblfilename4; }
            set
            {
                lblfilename4 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename4");
            }
        }
        //To handle Boolean variable
        private bool lblfilename5 = false;
        public bool lblFilename5
        {
            get { return lblfilename5; }
            set
            {
                lblfilename5 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename5");
            }
        }
        //To handle Boolean variable
        private bool lblfilename6 = false;
        public bool lblFilename6
        {
            get { return lblfilename6; }
            set
            {
                lblfilename6 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename6");
            }
        }
        //To handle Boolean variable
        private bool lblfilename7 = false;
        public bool lblFilename7
        {
            get { return lblfilename7; }
            set
            {
                lblfilename7 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename7");
            }
        }
        //To handle Boolean variable
        private bool lblfilename8 = false;
        public bool lblFilename8
        {
            get { return lblfilename8; }
            set
            {
                lblfilename8 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename8");
            }
        }
        //To handle Boolean variable
        private bool lblfilename9 = false;
        public bool lblFilename9
        {
            get { return lblfilename9; }
            set
            {
                lblfilename9 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename9");
            }
        }
        //To handle Boolean variable
        private bool lblfilename10 = false;
        public bool lblFilename10
        {
            get { return lblfilename10; }
            set
            {
                lblfilename10 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename10");
            }
        }
        //To handle Boolean variable
        private bool Imgcancel = false;
        public bool ImgCancel
        {
            get { return Imgcancel; }
            set
            {
                Imgcancel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCancel ");
            }
        }
        private string txtDescribtion = "";
        public string TxtDescribtion
        {
            get { return txtDescribtion; }
            set
            {
                txtDescribtion = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDescribtion");
            }
        }
        private string btnchoosefile = "";
        public string BtnChooseFile
        {
            get { return btnchoosefile; }
            set
            {
                btnchoosefile = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnChooseFile");
            }
        }

        private string lblattachment = "";
        public string lblAttachment
        {
            get { return lblattachment; }
            set
            {
                lblattachment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttachment");
            }
        }
        //20230111
        private string lblchooseFile = "";
        public string lblChooseFile
        {
            get { return lblchooseFile; }
            set
            {
                lblchooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile");
            }
        }
        //20230111
        private string lblchooseFile2 = "";
        public string lblChooseFile2
        {
            get { return lblchooseFile2; }
            set
            {
                lblchooseFile2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile2");
            }
        }
        //20230111
        private string lblchooseFile3 = "";
        public string lblChooseFile3
        {
            get { return lblchooseFile3; }
            set
            {
                lblchooseFile3 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile3");
            }
        }
        //20230111
        private string lblchooseFile4 = "";
        public string lblChooseFile4
        {
            get { return lblchooseFile4; }
            set
            {
                lblchooseFile4 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile4");
            }
        }
        //20230111
        private string lblchooseFile5 = "";
        public string lblChooseFile5
        {
            get { return lblchooseFile5; }
            set
            {
                lblchooseFile5 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile5");
            }
        }
        //20230111
        private string lblchooseFile6 = "";
        public string lblChooseFile6
        {
            get { return lblchooseFile6; }
            set
            {
                lblchooseFile6 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile6");
            }
        }
        //20230111
        private string lblchooseFile7 = "";
        public string lblChooseFile7
        {
            get { return lblchooseFile7; }
            set
            {
                lblchooseFile7 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile7");
            }
        }
        //20230111
        private string lblchooseFile8 = "";
        public string lblChooseFile8
        {
            get { return lblchooseFile8; }
            set
            {
                lblchooseFile8 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile8");
            }
        }
        //20230111
        private string lblchooseFile9 = "";
        public string lblChooseFile9
        {
            get { return lblchooseFile9; }
            set
            {
                lblchooseFile9 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile9");
            }
        }
        //20230111
        private string lblchooseFile1 = "";
        public string lblChooseFile1
        {
            get { return lblchooseFile1; }
            set
            {
                lblchooseFile1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblChooseFile1");
            }
        }
        //20230111
        private string txtFilename = "";
        public string TxtFilename
        {
            get { return txtFilename; }
            set
            {
                txtFilename = value;
                OnPropertyChanged();
                RaisePropertyChange("txtFilename");
            }
        }
        //20230111
        private string txtFilename2 = "";
        public string TxtFilename2
        {
            get { return txtFilename2; }
            set
            {
                txtFilename2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename2");
            }
        }
        //20230111
        private string txtFilename3 = "";
        public string TxtFilename3
        {
            get { return txtFilename3; }
            set
            {
                txtFilename3 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename3");
            }
        }
        //20230111
        private string txtFilename4 = "";
        public string TxtFilename4
        {
            get { return txtFilename4; }
            set
            {
                txtFilename4 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename4");
            }
        }
        private string txtFilename5 = "";
        public string TxtFilename5
        {
            get { return txtFilename5; }
            set
            {
                txtFilename5 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename5");
            }
        }
        private string txtFilename6 = "";
        public string TxtFilename6
        {
            get { return txtFilename6; }
            set
            {
                txtFilename6 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename6");
            }
        }
        private string txtFilename7 = "";
        public string TxtFilename7
        {
            get { return txtFilename7; }
            set
            {
                txtFilename7 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename7");
            }
        }
        private string txtFilename8 = "";
        public string TxtFilename8
        {
            get { return txtFilename8; }
            set
            {
                txtFilename8 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename8");
            }
        }
        private string txtFilename9 = "";
        public string TxtFilename9
        {
            get { return txtFilename9; }
            set
            {
                txtFilename9 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename9");
            }
        }
        private string txtFilename1 = "";
        public string TxtFilename1
        {
            get { return txtFilename1; }
            set
            {
                txtFilename1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFilename1");
            }
        }
        private string msgChooseFile = "";
        public string MsgChooseFile
        {
            get { return msgChooseFile; }
            set
            {
                msgChooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile");
            }
        }
        private string msgChooseFile2 = "";
        public string MsgChooseFile2
        {
            get { return msgChooseFile2; }
            set
            {
                msgChooseFile2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile2");
            }
        }
        private string msgChooseFile3 = "";
        public string MsgChooseFile3
        {
            get { return msgChooseFile3; }
            set
            {
                msgChooseFile3 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile3");
            }
        }
        private string msgChooseFile4 = "";
        public string MsgChooseFile4
        {
            get { return msgChooseFile4; }
            set
            {
                msgChooseFile4 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile4");
            }
        }
        private string msgChooseFile5 = "";
        public string MsgChooseFile5
        {
            get { return msgChooseFile5; }
            set
            {
                msgChooseFile5 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile5");
            }
        }
        private string msgChooseFile6 = "";
        public string MsgChooseFile6
        {
            get { return msgChooseFile6; }
            set
            {
                msgChooseFile6 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile6");
            }
        }
        private string msgChooseFile7 = "";
        public string MsgChooseFile7
        {
            get { return msgChooseFile7; }
            set
            {
                msgChooseFile7 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile7");
            }
        }
        private string msgChooseFile8 = "";
        public string MsgChooseFile8
        {
            get { return msgChooseFile8; }
            set
            {
                msgChooseFile8 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile8");
            }
        }
        private string msgChooseFile9 = "";
        public string MsgChooseFile9
        {
            get { return msgChooseFile9; }
            set
            {
                msgChooseFile9 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile9");
            }
        }
        private string msgChooseFile1 = "";
        public string MsgChooseFile1
        {
            get { return msgChooseFile1; }
            set
            {
                msgChooseFile1 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgChooseFile1");
            }
        }
        //20230207
        private string lblOOGlengthincm = "";
        public string lblOOGLengthincm
        {
            get { return lblOOGlengthincm; }
            set
            {
                lblOOGlengthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOOGLengthincm");
            }
        }
        //20230207
        private string Txtlengthincm = "";
        public string TxtLengthincm
        {
            get { return Txtlengthincm; }
            set
            {
                Txtlengthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLengthincm");
            }
        }
        //20230207
        private string lblOOGwidthincm = "";
        public string lblOOGWidthincm
        {
            get { return lblOOGwidthincm; }
            set
            {
                lblOOGwidthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOOGWidthincm");
            }
        }
        //20230207
        private string Txtwidthincm = "";
        public string TxtWidthincm
        {
            get { return Txtwidthincm; }
            set
            {
                Txtwidthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtWidthincm");
            }
        }
        //20230207
        private string lblOOGheightincm = "";
        public string lblOOGHeightincm
        {
            get { return lblOOGheightincm; }
            set
            {
                lblOOGheightincm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblHeightincm");
            }
        }
        //20230207
        private string Txtheightincm = "";
        public string TxtHeightincm
        {
            get { return Txtheightincm; }
            set
            {
                Txtheightincm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtHeightincm");
            }
        }
        //20230207
        private string lbldangerousCargo = "";
        public string lblDangerousCargo
        {
            get { return lbldangerousCargo; }
            set
            {
                lbldangerousCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDangerousCargo");
            }
        }
        //20230207
        private string lblyes = "";
        public string lblYes
        {
            get { return lblyes; }
            set
            {
                lblyes = value;
                OnPropertyChanged();
                RaisePropertyChange("lblYes");
            }
        }
        //20230207
        private string lblno = "";
        public string lblNo
        {
            get { return lblno; }
            set
            {
                lblno = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNo");
            }
        }
        //20230207
        private string lblpriceCalculator = "";
        public string lblPriceCalculator
        {
            get { return lblpriceCalculator; }
            set
            {
                lblpriceCalculator = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPriceCalculator");
            }
        }
        //20230207
        private string lblpriceCalculator2 = "";
        public string lblPriceCalculator2
        {
            get { return lblpriceCalculator2; }
            set
            {
                lblpriceCalculator2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPriceCalculator2");
            }
        }
        private bool isVisibleLengthBB = false;
        public bool IsVisibleLengthBB
        {
            get { return isVisibleLengthBB; }
            set
            {
                isVisibleLengthBB = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleLengthBB");
            }
        }
        private bool isVisibleWidthBB = false;
        public bool IsVisibleWidthBB
        {
            get { return isVisibleWidthBB; }
            set
            {
                isVisibleWidthBB = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleWidthBB");
            }
        }
        private bool isVisibleHeightBB = false;
        public bool IsVisibleHeightBB
        {
            get { return isVisibleHeightBB; }
            set
            {
                isVisibleHeightBB = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleHeightBB");
            }
        }
        private string lblBBlengthincm = "";
        public string lblBBLengthincm
        {
            get { return lblBBlengthincm; }
            set
            {
                lblBBlengthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBBLengthincm");
            }
        }
        private string lblBBwidthincm = "";
        public string lblBBWidthincm
        {
            get { return lblBBwidthincm; }
            set
            {
                lblBBwidthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBBWidthincm");
            }
        }
        private string lblBBheightincm = "";
        public string lblBBHeightincm
        {
            get { return lblBBheightincm; }
            set
            {
                lblBBheightincm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBBHeightincm");
            }
        }
        private bool isVisibleWidthOOG = true;
        public bool IsVisibleWidthOOG
        {
            get { return isVisibleWidthOOG; }
            set
            {
                isVisibleWidthOOG = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleWidthOOG");
            }
        }
        private bool isVisibleLengthOOG = true;
        public bool IsVisibleLengthOOG
        {
            get { return isVisibleLengthOOG; }
            set
            {
                isVisibleLengthOOG = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleLengthOOG");
            }
        }
        private bool isVisibleHeightOOG = true;
        public bool IsVisibleHeightOOG
        {
            get { return isVisibleHeightOOG; }
            set
            {
                isVisibleHeightOOG = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleHeightOOG");
            }
        }

        //20230207
        private string msgLengthincm = "";
        public string MsgLengthincm
        {
            get { return msgLengthincm; }
            set
            {
                msgLengthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLengthincm");
            }
        }
        //20230207
        private string msgWidthincm = "";
        public string MsgWidthincm
        {
            get { return msgWidthincm; }
            set
            {
                msgWidthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgWidthincm");
            }
        }
        //20230207
        private string msgHeightincm = "";
        public string MsgHeightincm
        {
            get { return msgHeightincm; }
            set
            {
                msgHeightincm = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgHeightincm");
            }
        }

        private string lblsAR = "";
        public string lblSAR
        {
            get { return lblsAR; }
            set
            {
                lblsAR = value;
                OnPropertyChanged();
                RaisePropertyChange("lblSAR");
            }
        }

        //To declare combo variable 
        private EnumCombo _selectedCatogoryPick1;
        public EnumCombo SelectedCatogoryPick
        {
            get { return _selectedCatogoryPick1; }
            set
            {
                SetProperty(ref _selectedCatogoryPick1, value);
                OnPropertyChanged();
                RaisePropertyChange("SelectedCatogoryPick");
            }
        }

        //To declare combo variable
        private EnumCombo _selectedCargopick;
        public EnumCombo SelectedCargopick
        {
            get { return _selectedCargopick; }
            set
            {
                SetProperty(ref _selectedCargopick, value);
                if (SelectedCargopick != null)
                {
                    if (SelectedCargopick.Key == "OOG")
                    {
                        IsVisibleOOG = true;
                        IsVisibleWidthOOG = true;
                        IsVisibleLengthOOG = true;
                        IsVisibleHeightOOG = true;
                        IsVisibleBreakBulk = false;
                        IsVisibleLengthBB = false;
                        IsVisibleWidthBB = false;
                        IsVisibleHeightBB = false;



                    }
                    else
                    {
                        IsVisibleOOG = false;
                        IsVisibleBreakBulk = true;
                        IsVisibleLengthBB = true;
                        IsVisibleHeightBB = true;
                        IsVisibleWidthBB = true;
                        IsVisibleWidthOOG = false;
                        IsVisibleLengthOOG = false;
                        IsVisibleHeightOOG = false;
                    }
                }
                OnPropertyChanged();
                RaisePropertyChange("SelectedCargopick");
            }
        }


        private bool isChoosefile = true;
        public bool IsChoosefile
        {
            get { return isChoosefile; }
            set
            {
                isChoosefile = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile");
            }
        }
        private bool isChoosefile2 = true;
        public bool IsChoosefile2
        {
            get { return isChoosefile2; }
            set
            {
                isChoosefile2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile2");
            }
        }
        //20230111
        private bool isChoosefile3 = true;
        public bool IsChoosefile3
        {
            get { return isChoosefile3; }
            set
            {
                isChoosefile3 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile3");
            }
        }
        //20230111
        private bool isChoosefile4 = true;
        public bool IsChoosefile4
        {
            get { return isChoosefile4; }
            set
            {
                isChoosefile4 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile4");
            }
        }
        //20230111
        private bool isChoosefile5 = true;
        public bool IsChoosefile5
        {
            get { return isChoosefile5; }
            set
            {
                isChoosefile5 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile5");
            }
        }
        //20230111
        private bool isChoosefile6 = true;
        public bool IsChoosefile6
        {
            get { return isChoosefile6; }
            set
            {
                isChoosefile6 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile6");
            }
        }
        //20230111
        private bool isChoosefile7 = true;
        public bool IsChoosefile7
        {
            get { return isChoosefile7; }
            set
            {
                isChoosefile7 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile7");
            }
        }
        //20230111
        private bool isChoosefile8 = true;
        public bool IsChoosefile8
        {
            get { return isChoosefile8; }
            set
            {
                isChoosefile8 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile8");
            }
        }
        //20230111
        private bool isChoosefile9 = true;
        public bool IsChoosefile9
        {
            get { return isChoosefile9; }
            set
            {
                isChoosefile9 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile9");
            }
        }
        //20230111
        private bool isChoosefile1 = true;
        public bool IsChoosefile1
        {
            get { return isChoosefile1; }
            set
            {
                isChoosefile1 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsChoosefile1");
            }
        }
        //20230111
        private bool isVisibleCancel = false;
        public bool IsVisibleCancel
        {
            get { return isVisibleCancel; }
            set
            {
                isVisibleCancel = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel");
            }
        }
        //20230111
        private bool isVisibleCancel2 = false;
        public bool IsVisibleCancel2
        {
            get { return isVisibleCancel2; }
            set
            {
                isVisibleCancel2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel2");
            }
        }
        //20230111
        private bool isVisibleCancel3 = false;
        public bool IsVisibleCancel3
        {
            get { return isVisibleCancel3; }
            set
            {
                isVisibleCancel3 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel3");
            }
        }
        //20230111
        private bool isVisibleCancel4 = false;
        public bool IsVisibleCancel4
        {
            get { return isVisibleCancel4; }
            set
            {
                isVisibleCancel4 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel4");
            }
        }
        //20230111
        private bool isVisibleCancel5 = false;
        public bool IsVisibleCancel5
        {
            get { return isVisibleCancel5; }
            set
            {
                isVisibleCancel5 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel5");
            }
        }
        //20230111
        private bool isVisibleCancel6 = false;
        public bool IsVisibleCancel6
        {
            get { return isVisibleCancel6; }
            set
            {
                isVisibleCancel6 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel6");
            }
        }
        //20230111
        private bool isVisibleCancel7 = false;
        public bool IsVisibleCancel7
        {
            get { return isVisibleCancel7; }
            set
            {
                isVisibleCancel7 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel7");
            }
        }
        //20230111
        private bool isVisibleCancel8 = false;
        public bool IsVisibleCancel8
        {
            get { return isVisibleCancel8; }
            set
            {
                isVisibleCancel8 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel8");
            }
        }
        //20230111
        private bool isVisibleCancel9 = false;
        public bool IsVisibleCancel9
        {
            get { return isVisibleCancel9; }
            set
            {
                isVisibleCancel9 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel9");
            }
        }
        //20230111
        private bool isVisibleCancel1 = false;
        public bool IsVisibleCancel1
        {
            get { return isVisibleCancel1; }
            set
            {
                isVisibleCancel1 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleCancel1");
            }
        }
        //20230111
        private bool isVisibleFilename = false;
        public bool IsVisibleFilename
        {
            get { return isVisibleFilename; }
            set
            {
                isVisibleFilename = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename");
            }
        }
        //20230111
        private bool isVisibleFilename2 = false;
        public bool IsVisibleFilename2
        {
            get { return isVisibleFilename2; }
            set
            {
                isVisibleFilename2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename2");
            }
        }
        //20230111
        private bool isVisibleFilename3 = false;
        public bool IsVisibleFilename3
        {
            get { return isVisibleFilename3; }
            set
            {
                isVisibleFilename3 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename3");
            }
        }
        //20230111
        private bool isVisibleFilename4 = false;
        public bool IsVisibleFilename4
        {
            get { return isVisibleFilename4; }
            set
            {
                isVisibleFilename4 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename4");
            }
        }
        //20230111
        private bool isVisibleFilename5 = false;
        public bool IsVisibleFilename5
        {
            get { return isVisibleFilename5; }
            set
            {
                isVisibleFilename5 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename5");
            }
        }
        //20230111
        private bool isVisibleFilename6 = false;
        public bool IsVisibleFilename6
        {
            get { return isVisibleFilename6; }
            set
            {
                isVisibleFilename6 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename6");
            }
        }
        //20230111
        private bool isVisibleFilename7 = false;
        public bool IsVisibleFilename7
        {
            get { return isVisibleFilename7; }
            set
            {
                isVisibleFilename7 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename7");
            }
        }
        //20230111
        private bool isVisibleFilename8 = false;
        public bool IsVisibleFilename8
        {
            get { return isVisibleFilename8; }
            set
            {
                isVisibleFilename8 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename8");
            }
        }
        //20230111
        private bool isVisibleFilename9 = false;
        public bool IsVisibleFilename9
        {
            get { return isVisibleFilename9; }
            set
            {
                isVisibleFilename9 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename9");
            }
        }
        //20230111
        private bool isVisibleFilename1 = false;
        public bool IsVisibleFilename1
        {
            get { return isVisibleFilename1; }
            set
            {
                isVisibleFilename1 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleFilename1");
            }
        }
        //20230111
        private bool isvalidatedChooseFile = false;
        public bool IsvalidatedChooseFile
        {
            get { return isvalidatedChooseFile; }
            set
            {
                isvalidatedChooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile");
            }
        }
        //20230111
        private bool isvalidatedChooseFile2 = false;
        public bool IsvalidatedChooseFile2
        {
            get { return isvalidatedChooseFile2; }
            set
            {
                isvalidatedChooseFile2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile2");
            }
        }
        //20230111
        private bool isvalidatedChooseFile3 = false;
        public bool IsvalidatedChooseFile3
        {
            get { return isvalidatedChooseFile3; }
            set
            {
                isvalidatedChooseFile3 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile3");
            }
        }
        //20230111
        private bool isvalidatedChooseFile4 = false;
        public bool IsvalidatedChooseFile4
        {
            get { return isvalidatedChooseFile4; }
            set
            {
                isvalidatedChooseFile4 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile4");
            }
        }
        //20230111
        private bool isvalidatedChooseFile5 = false;    //20230111
        public bool IsvalidatedChooseFile5
        {
            get { return isvalidatedChooseFile5; }
            set
            {
                isvalidatedChooseFile5 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile5");
            }
        }
        //20230111
        private bool isvalidatedChooseFile6 = false;
        public bool IsvalidatedChooseFile6
        {
            get { return isvalidatedChooseFile6; }
            set
            {
                isvalidatedChooseFile6 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile6");
            }
        }
        //20230111
        private bool isvalidatedChooseFile7 = false;
        public bool IsvalidatedChooseFile7
        {
            get { return isvalidatedChooseFile7; }
            set
            {
                isvalidatedChooseFile7 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile7");
            }
        }
        //20230111
        private bool isvalidatedChooseFile8 = false;
        public bool IsvalidatedChooseFile8
        {
            get { return isvalidatedChooseFile8; }
            set
            {
                isvalidatedChooseFile8 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile8");
            }
        }
        //20230111
        private bool isvalidatedChooseFile9 = false;
        public bool IsvalidatedChooseFile9
        {
            get { return isvalidatedChooseFile9; }
            set
            {
                isvalidatedChooseFile9 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile9");
            }
        }
        //20230111
        private bool isvalidatedChooseFile1 = false;
        public bool IsvalidatedChooseFile1
        {
            get { return isvalidatedChooseFile1; }
            set
            {
                isvalidatedChooseFile1 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedChooseFile1");
            }
        }
        //20230207
        private bool isVisibleOOG = false;
        public bool IsVisibleOOG
        {
            get { return isVisibleOOG; }
            set
            {
                isVisibleOOG = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleOOG");
            }
        }
        //20230207
        private bool isVisibleBreakBulk = false;
        public bool IsVisibleBreakBulk
        {
            get { return isVisibleBreakBulk; }
            set
            {
                isVisibleBreakBulk = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleBreakBulk");
            }
        }
        //20230207
        private bool isvalidatedHeightincm = false;
        public bool IsvalidatedHeightincm
        {
            get { return isvalidatedHeightincm; }
            set
            {
                isvalidatedHeightincm = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedHeightincm");
            }
        }
        //20230207
        private bool isvalidatedWidthincm = false;
        public bool IsvalidatedWidthincm
        {
            get { return isvalidatedWidthincm; }
            set
            {
                isvalidatedWidthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedWidthincm");
            }
        }
        //20230207
        private bool isvalidatedLengthincm = false;
        public bool IsvalidatedLengthincm
        {
            get { return isvalidatedLengthincm; }
            set
            {
                isvalidatedLengthincm = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedLengthincm");
            }
        }
        private bool isvalidatedProvideValid = false;
        public bool IsvalidatedProvideValid
        {
            get { return isvalidatedProvideValid; }
            set
            {
                isvalidatedProvideValid = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedProvideValid");
            }
        }
        private bool isvalidatedProvideValid2 = false;
        public bool IsvalidatedProvideValid2
        {
            get { return isvalidatedProvideValid2; }
            set
            {
                isvalidatedProvideValid2 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedProvideValid2");
            }
        }
        private bool isvalidatedProvideValid3 = false;
        public bool IsvalidatedProvideValid3
        {
            get { return isvalidatedProvideValid3; }
            set
            {
                isvalidatedProvideValid3 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedProvideValid3");
            }
        }
        private bool isvalidatedProvideValid4 = false;
        public bool IsvalidatedProvideValid4
        {
            get { return isvalidatedProvideValid4; }
            set
            {
                isvalidatedProvideValid4 = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedProvideValid4");
            }
        }
        private string msgProvideValid = "";
        public string MsgProvideValid
        {
            get { return msgProvideValid; }
            set
            {
                msgProvideValid = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgProvideValid");
            }
        }
        private string msgProvideValid2 = "";
        public string MsgProvideValid2
        {
            get { return msgProvideValid2; }
            set
            {
                msgProvideValid2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgProvideValid2");
            }
        }
        private string msgProvideValid3 = "";
        public string MsgProvideValid3
        {
            get { return msgProvideValid3; }
            set
            {
                msgProvideValid3 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgProvideValid3");
            }
        }
        private string msgProvideValid4 = "";
        public string MsgProvideValid4
        {
            get { return msgProvideValid4; }
            set
            {
                msgProvideValid4 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgProvideValid4");
            }
        }
        //20-02-2023-Sanduru
        private bool chkValYes = false;
        public bool ChkValYes
        {
            get { return chkValYes; }
            set
            {
                chkValYes = value;

                OnPropertyChanged();
                RaisePropertyChange("ChkValYes");

                if (chkValYes == true) ChkValNo = false;
            }
        }
        //20-02-2023-Sanduru
        private bool chkValNo = true;
        public bool ChkValNo
        {
            get { return chkValNo; }
            set
            {
                chkValNo = value;
                OnPropertyChanged();
                RaisePropertyChange("ChkValNo");
                if (chkValNo == true) ChkValYes = false;
            }
        }
        //20-02-2023-Sanduru
        private string txtYesNo = "";
        public string TxtYesNo
        {
            get { return txtYesNo; }
            set
            {
                txtYesNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtYesNo");
            }
        }
        //20-02-2023-Sanduru
        private double txtDGAddlCharge = 0;
        public double TxtDGAddlCharge
        {
            get { return txtDGAddlCharge; }
            set
            {
                txtDGAddlCharge = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDGAddlCharge");
            }
        }
        private double txtOverLengthm = 0;
        public double TxtOverLengthm
        {
            get { return txtOverLengthm; }
            set
            {
                txtOverLengthm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOverLengthm");
            }
        }
        private double txtOverHeightm = 0;
        public double TxtOverHeightm
        {
            get { return txtOverHeightm; }
            set
            {
                txtOverHeightm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOverHeightm");
            }
        }
        private double txtOverWidthm = 0;
        public double TxtOverWidthm
        {
            get { return txtOverWidthm; }
            set
            {
                txtOverWidthm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOverWidthm");
            }
        }
        private double txtTotalDiminmeters = 0;
        public double TxtTotalDiminmeters
        {
            get { return txtTotalDiminmeters; }
            set
            {
                txtTotalDiminmeters = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTotalDiminmeters");
            }
        }
        private double txtTotalDimensionsincm = 0;
        public double TxtTotalDimensionsincm
        {
            get { return txtTotalDimensionsincm; }
            set
            {
                txtTotalDimensionsincm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTotalDimensionsincm");
            }
        }
        private double txtUnitCost = 0;
        public double TxtUnitCost
        {
            get { return txtUnitCost; }
            set
            {
                txtUnitCost = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtUnitCost");
            }
        }
        private double txtWeightinTon = 0;
        public double TxtWeightinTon
        {
            get { return txtWeightinTon; }
            set
            {
                txtWeightinTon = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtWeightinTon");
            }
        }
        private double txtTotalCost = 0;
        public double TxtTotalCost
        {
            get { return txtTotalCost; }
            set
            {
                txtTotalCost = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTotalCost");
            }
        }
        private double txtDGAddlCost = 0;
        public double TxtDGAddlCost
        {
            get { return txtDGAddlCost; }
            set
            {
                txtDGAddlCost = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDGAddlCost");
            }
        }
        private double txtCargoLengthm = 0;
        public double TxtCargoLengthm
        {
            get { return txtCargoLengthm; }
            set
            {
                txtCargoLengthm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoLengthm");
            }
        }
        private double txtCargoHeightm = 0;
        public double TxtCargoHeightm
        {
            get { return txtCargoHeightm; }
            set
            {
                txtCargoHeightm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoHeightm");
            }
        }
        private double txtCargoWidthm = 0;
        public double TxtCargoWidthm
        {
            get { return txtCargoWidthm; }
            set
            {
                txtCargoWidthm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoWidthm");
            }
        }
        private double txtCargoTotalDiminm = 0;
        public double TxtCargoTotalDiminm
        {
            get { return txtCargoTotalDiminm; }
            set
            {
                txtCargoTotalDiminm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoTotalDiminm");
            }
        }
        private double txtTotalDimension = 0;
        public double TxtTotalDimension
        {
            get { return txtTotalDimension; }
            set
            {
                txtTotalDimension = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTotalDimension");
            }
        }
        ////To declare Combo variable
        private List<EnumCombo> _lobjCatogoryPick = new List<EnumCombo>();
        public List<EnumCombo> lobjCatogoryPick
        {
            get { return _lobjCatogoryPick; }
            set
            {
                if (_lobjCatogoryPick == value)
                    return;
                _lobjCatogoryPick = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCatogoryPick");
            }
        }


        ////To declare Combo variable
        private List<EnumCombo> _lobjCargopick = new List<EnumCombo>();
        public List<EnumCombo> lobjCargopick
        {
            get { return _lobjCargopick; }
            set
            {
                if (_lobjCargopick == value)
                    return;
                _lobjCargopick = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCargopick");
            }
        }

        string TypeofCargo = "";
        string CategoryofCargo = "";
        string Weight = "";
        string Length = "";
        string Width = "";
        string Height = "";


        public string strOOGTransshipment { get; set; }
        public string strBreakbulkLengthCM { get; set; }
        public string strBreakbulkWidthCM { get; set; }
        public string strBreakbulkHeightCM { get; set; }
        public string strOOGLengthCM { get; set; }
        public string strOOGWidthCM { get; set; }
        public string strOOGHeightCM { get; set; }
        public string strOOGWeightKG { get; set; }
        public string strOOGImport { get; set; }
        public string strOOGExport { get; set; }
        public string strBreakbulkWeightKG { get; set; }
        public string strBreakbulkImport { get; set; }
        public string strBreakbulkExport { get; set; }
        public string strBreakbulkTransshipment { get; set; }
        public string strAddlchargecalculate { get; set; }
        public string strSAR { get; set; }

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

                ButtonchooseFile.ChangeCanExecute();
                ButtonCancel.ChangeCanExecute();
                Tapmanifestrequesthistory.ChangeCanExecute();
                ButtonchooseFile.ChangeCanExecute();
                Buttonreset.ChangeCanExecute();
                ButtonchooseFile2.ChangeCanExecute();
                ButtonchooseFile3.ChangeCanExecute();
                ButtonchooseFile4.ChangeCanExecute();
                ButtonchooseFile5.ChangeCanExecute();
                ButtonchooseFile6.ChangeCanExecute();
                ButtonchooseFile7.ChangeCanExecute();
                ButtonchooseFile8.ChangeCanExecute();
                ButtonchooseFile9.ChangeCanExecute();
                ButtonchooseFile1.ChangeCanExecute();
                ButtonCancel2.ChangeCanExecute();
                ButtonCancel3.ChangeCanExecute();
                ButtonCancel4.ChangeCanExecute();
                ButtonCancel5.ChangeCanExecute();
                ButtonCancel6.ChangeCanExecute();
                ButtonCancel7.ChangeCanExecute();
                ButtonCancel8.ChangeCanExecute();
                ButtonCancel9.ChangeCanExecute();
                ButtonCancel1.ChangeCanExecute();
                ButtonOOG.ChangeCanExecute();
                ButtonBreakBulk.ChangeCanExecute();
            }
        }
        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public OogBreakBulkRequestViewModel()
        {
            try
            {

                //Appcenter Track Event handler
                Analytics.TrackEvent("OogBreakBulkRequestViewModel");
                Task.Run(() => assignCms()).Wait();
                ButtonchooseFile = new Command(async () => await buttonchooseFile(), () => !IsBusy);
                ButtonCancel = new Command(async () => await buttonCancel(), () => !IsBusy);
                Buttonsubmit = new Command(async () => await buttonsubmit(), () => !IsBusy);
                Tapmanifestrequesthistory = new Command(async () => await tapmanifestrequesthistory(), () => !IsBusy);
                Buttonreset = new Command(async () => await buttonreset(), () => !IsBusy);
                ButtonchooseFile2 = new Command(async () => await buttonchooseFile2(), () => !IsBusy);
                ButtonchooseFile3 = new Command(async () => await buttonchooseFile3(), () => !IsBusy);
                ButtonchooseFile4 = new Command(async () => await buttonchooseFile4(), () => !IsBusy);
                ButtonchooseFile5 = new Command(async () => await buttonchooseFile5(), () => !IsBusy);
                ButtonchooseFile6 = new Command(async () => await buttonchooseFile6(), () => !IsBusy);
                ButtonchooseFile7 = new Command(async () => await buttonchooseFile7(), () => !IsBusy);
                ButtonchooseFile8 = new Command(async () => await buttonchooseFile8(), () => !IsBusy);
                ButtonchooseFile9 = new Command(async () => await buttonchooseFile9(), () => !IsBusy);
                ButtonchooseFile1 = new Command(async () => await buttonchooseFile1(), () => !IsBusy);
                ButtonCancel2 = new Command(async () => await buttonCancel2(), () => !IsBusy);
                ButtonCancel3 = new Command(async () => await buttonCancel3(), () => !IsBusy);
                ButtonCancel4 = new Command(async () => await buttonCancel4(), () => !IsBusy);
                ButtonCancel5 = new Command(async () => await buttonCancel5(), () => !IsBusy);
                ButtonCancel6 = new Command(async () => await buttonCancel6(), () => !IsBusy);
                ButtonCancel7 = new Command(async () => await buttonCancel7(), () => !IsBusy);
                ButtonCancel8 = new Command(async () => await buttonCancel8(), () => !IsBusy);
                ButtonCancel9 = new Command(async () => await buttonCancel9(), () => !IsBusy);
                ButtonCancel1 = new Command(async () => await buttonCancel1(), () => !IsBusy);
                ButtonOOG = new Command(async () => await buttonOOG(), () => !IsBusy);
                ButtonBreakBulk = new Command(async () => await buttonBreakBulk(), () => !IsBusy);

                //string TypeofCargo = SelectedCatogoryPick.Value;
                //string CategoryofCargo = SelectedCargopick.Value;
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM461");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM461");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
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
              
                //dbLayer.objInfoitems = objCMS;
               
                imgOOGBreakbulkIcon = dbLayer.getCaption("imgOOGbreakbulk", objCMS);
                lblOOGBreakbulkRequest = dbLayer.getCaption("strOOGBreakbulkRequest", objCMS);
                imgRequestIconDark = dbLayer.getCaption("imgrequest", objCMS);
                lblOOGRequestForm = dbLayer.getCaption("strOOGBreakbulkRequestForm", objCMS);
                lblShippingLine = dbLayer.getCaption("strShippingLine", objCMS);
                lblTypeofCargo = dbLayer.getCaption("strTypeofCargo", objCMS);
                lblCategoryofCargo = dbLayer.getCaption("strCategoryofCargo", objCMS);
                lblDimension = dbLayer.getCaption("strDimensions", objCMS);
                lblWeight = dbLayer.getCaption("strWeights", objCMS);
                lblNoFlatTrunk = dbLayer.getCaption("strNumberofFlatTrunk", objCMS);
                lblStowagePosition = dbLayer.getCaption("strStowagePosition", objCMS);
                lblDischargingDetails = dbLayer.getCaption("strDischargingVesselDetails", objCMS);
                lblLoadingDetails = dbLayer.getCaption("strLoadingVesselDetails", objCMS);
                lblPhoto = dbLayer.getCaption("strPhotoDrawing", objCMS);
                lblImage1 = dbLayer.getCaption("strImage", objCMS);
                imgDeleteIcon = dbLayer.getCaption("imgdeleteicon", objCMS);
                lblImage2 = dbLayer.getCaption("strImages", objCMS);
                imgDeleteIcon1 = dbLayer.getCaption("imgdeleteicon", objCMS);
                BtnAddImage = dbLayer.getCaption("strAddImage", objCMS);
                BtnReset = dbLayer.getCaption("strReset", objCMS);
                BtnSubmit = dbLayer.getCaption("strSubmit", objCMS);
                imgHistoryicon = dbLayer.getCaption("imgHistory", objCMS);
                lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
                MsgShippingLine = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgTypeofCargo = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCategoryofCargo = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgDimension = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgWeight = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgNoFlatTrunk = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgStowagePosition = dbLayer.getCaption("strMandatory", objCMSMSG);
                lobjOogBreakBulkrequest = dbLayer.getEnum("strOOGRequestLov", objCMS);
                lblAttachment = dbLayer.getCaption("strPhotoDrawing", objCMS);
                lblSAR = dbLayer.getCaption("strSAR", objCMS);
                lblChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile2 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile3 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile4 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile5 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile6 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile7 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile8 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile9 = dbLayer.getCaption("strChoosefile", objCMS);
                lblChooseFile1 = dbLayer.getCaption("strChoosefile", objCMS);
                MsgChooseFile = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile2 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile3 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile4 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile5 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile6 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile7 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile8 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile9 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgChooseFile1 = dbLayer.getCaption("strMandatory", objCMSMSG);

                //Sanduru_07-02-2023
                MsgLengthincm = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgWidthincm = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgHeightincm = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgProvideValid = dbLayer.getCaption("strMobilepattern", objCMSMSG);
                MsgProvideValid2 = dbLayer.getCaption("strMobilepattern", objCMSMSG);
                MsgProvideValid3 = dbLayer.getCaption("strMobilepattern", objCMSMSG);
                MsgProvideValid4 = dbLayer.getCaption("strMobilepattern", objCMSMSG);

                lblOOGLengthincm = dbLayer.getCaption("strLength", objCMS);
                lblBBLengthincm = dbLayer.getCaption("strLengthincm", objCMS);
                lblOOGWidthincm = dbLayer.getCaption("strWidth", objCMS);
                lblBBWidthincm = dbLayer.getCaption("strWidthincm", objCMS);
                lblOOGHeightincm = dbLayer.getCaption("strHeight", objCMS);
                lblBBHeightincm = dbLayer.getCaption("strHeightincm", objCMS);
                lblDangerousCargo = dbLayer.getCaption("strDangerousCargo", objCMS);
                lblYes = dbLayer.getCaption("strYes", objCMS);
                lblNo = dbLayer.getCaption("strNo", objCMS);
                lblPriceCalculator = dbLayer.getCaption("strPriceCalculator", objCMS);
                lblPriceCalculator2 = dbLayer.getCaption("strPriceCalculator", objCMS);

                strBreakbulkExport = dbLayer.getCaption("strBreakbulkExport", objCMS);
                strBreakbulkHeightCM = dbLayer.getCaption("strBreakbulkHeightCM", objCMS);
                strBreakbulkImport = dbLayer.getCaption("strBreakbulkImport", objCMS);
                strBreakbulkLengthCM = dbLayer.getCaption("strBreakbulkLengthCM", objCMS);
                strBreakbulkTransshipment = dbLayer.getCaption("strBreakbulkTransshipment", objCMS);
                strBreakbulkWeightKG = dbLayer.getCaption("strBreakbulkWeightKG", objCMS);
                strBreakbulkWidthCM = dbLayer.getCaption("strBreakbulkWidthCM", objCMS);
                strOOGExport = dbLayer.getCaption("strOOGExport", objCMS);
                strOOGHeightCM = dbLayer.getCaption("strOOGHeightCM", objCMS);
                strOOGImport = dbLayer.getCaption("strOOGImport", objCMS);
                strOOGLengthCM = dbLayer.getCaption("strOOGLengthCM", objCMS);
                strOOGTransshipment = dbLayer.getCaption("strOOGTransshipment", objCMS);
                strOOGWeightKG = dbLayer.getCaption("strOOGWeightKG", objCMS);
                strOOGWidthCM = dbLayer.getCaption("strOOGWidthCM", objCMS);
                strAddlchargecalculate = dbLayer.getCaption("strAddlchargecalculate", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);

                Dictionary<string, string> lobjCargo = new Dictionary<string, string>();
                Dictionary<string, string> lobjCategory = new Dictionary<string, string>();
                lobjCargo = dbLayer.getLOV("strTypeofCargoLov", objCMS);
                lobjCategory = dbLayer.getLOV("strCategoryofCargoLov", objCMS);


                foreach (var dic in lobjCargo)
                {
                    lobjCargopick.Add(new EnumCombo { Key = dic.Key });
                }

                foreach (var dic in lobjCategory)
                {
                    lobjCatogoryPick.Add(new EnumCombo { Key = dic.Key });
                }


                await Task.Delay(1000);

                //string strTemdata = lobjCargopick[0].ToString().Trim();
                //string[] lsttyprofcargo = strTemdata.Split(':');
                //string OOG = lsttyprofcargo[0]; if (IsVisibleOOG == true) ;
                //string Breakbulkrequest = lsttyprofcargo[1]; if (IsVisibleBreakBulk == true) ;             
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }
        /// <summary>
        /// To go to Submit Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonsubmit()
        {

            IsBusy = true;
            StackOogBreakBulkRequest = false;
            hideValidation();
            await Task.Delay(1000);
            try
            {
                bool blResult = true;
                hideValidation();
                if (SelectedCargopick != null)
                {
                    IsvalidatedTypeofCargo = false;
                    TypeofCargo = SelectedCargopick.Key;
                }
                else
                {
                    blResult = false;
                    IsvalidatedTypeofCargo = true;
                }
                if(SelectedCatogoryPick !=null)
                {
                    IsvalidatedTypeofCargo = false;
                    CategoryofCargo = SelectedCatogoryPick.Key;
                }
                else
                {
                    blResult = false;
                    IsvalidatedTypeofCargo = true;
                  
                }
               
               
                if (TypeofCargo == "OOG")
                {
                    blResult = OOGValidation();
                }
                if (TypeofCargo == "BreakBulk")
                {
                    blResult = BulkRequestValidation();
                }
                if (ChkValYes == true)
                {
                    TxtYesNo = "Yes";
                    TxtDGAddlCharge = Convert.ToDouble(strAddlchargecalculate) / 100;
                }
                else
                {
                    TxtDGAddlCharge = 0;
                    TxtYesNo = "No";
                }
                if (blResult == true)
                {
                    await fnOogBreakBulkSubmitData(TypeofCargo, CategoryofCargo, Weight, Length, Width, Height);
                }
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Oog BreakBulk Submit Data
        /// </summary>
        /// <param name="TypeofCargo"></param>
        /// <param name="CategoryofCargo"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        private async Task fnOogBreakBulkSubmitData(string TypeofCargo, string CategoryofCargo, string Weight, string Length, string Width, string Height)
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            hideValidation();
            try
            {
                string BaseCostVal = "";
                string lstrResult = "";
                bool blResult = true;
                if (blResult == true)
                {
                    string strTempdate = lobjOogBreakBulkrequest[0].Value.ToString();
                    string[] lstCaseCode = strTempdate.Split(':');
                    string lstrCT_CATEGORYCODE = lstCaseCode[0].ToString();
                    string lstrCT_CASETYPECODE = lstCaseCode[1].ToString();
                    string lstrCT_CASESUBTYPECODE = lstCaseCode[2].ToString();
                    string lstrCT_REQUESTTYPECODE = lstCaseCode[3].ToString();
                    //string lstrCT_MESSAGE = "Container No:CMAU7826262;Bill of Lading No:ANT1462936;Location in Yard: Gate 2";
                    string lstrCT_CASEGKEY = "";
                    //  string lstrct_reference = "cielotransporter@gmail.com_20220826142355";
                    string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
                    string lstrCT_USERNAME = gblRegisteration.strLoginUser.ToString().Trim();
                    string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string lstrCT_TITLE = "";
                    string lstrCT_MESSAGE = "";

                    if (TypeofCargo == "OOG")
                    {
                        if (CategoryofCargo == "Import")
                        {
                            BaseCostVal = strOOGImport;
                        }

                        if (CategoryofCargo == "Export")
                        {
                            BaseCostVal = strOOGExport;
                        }

                        if (CategoryofCargo == "Transshipment")
                        {
                            BaseCostVal = strOOGTransshipment;
                        }

                        lstrCT_TITLE = "OOG Request";

                        OOGPriceCalc(TypeofCargo, CategoryofCargo, Weight, Length, Width, Height, BaseCostVal);

                        lstrCT_MESSAGE = "Type of Cargo:" + TypeofCargo + "; Category of Cargo: " + CategoryofCargo + "; Length (M) :" + TxtOverLengthm + "; Width (M) :";
                        lstrCT_MESSAGE += " " + TxtOverWidthm + "; Height (M)" + TxtOverHeightm + "; Weight (Ton) :" + TxtWeightinTon + ";";
                        lstrCT_MESSAGE += " Base Cost:" + BaseCostVal + "; DG Addl Charge :" + TxtDGAddlCharge + ";";
                        lstrCT_MESSAGE += " DG Addl Cost:" + TxtDGAddlCost + "; Unit Cost :" + TxtUnitCost + ";";
                        lstrCT_MESSAGE += " Qty:" + TxtWeightinTon + "; Total Cost :" + TxtTotalCost + ";";

                    }

                    if (TypeofCargo == "Breakbulk")
                    {
                        if (CategoryofCargo == "Import")
                        {
                            BaseCostVal = strBreakbulkImport;
                        }

                        if (CategoryofCargo == "Export")
                        {
                            BaseCostVal = strBreakbulkExport;
                        }

                        if (CategoryofCargo == "Transshipment")
                        {
                            BaseCostVal = strBreakbulkTransshipment;
                        }
                        lstrCT_TITLE = "Break Bulk Request";
                         BreakbulkrequestPriceCalc(TypeofCargo, CategoryofCargo, Weight, Length, Width, Height, BaseCostVal);

                        lstrCT_MESSAGE = "Type of Cargo:" + TypeofCargo + "; Category of Cargo: " + CategoryofCargo + "; Length (M) :" + TxtCargoLengthm + "; Width (M) :";
                        lstrCT_MESSAGE += " " + TxtCargoWidthm + "; Height (M)" + TxtCargoHeightm + "; Weight (Ton) :" + TxtWeightinTon + ";";
                        lstrCT_MESSAGE += " Base Cost:" + BaseCostVal + "; DG Addl Charge :" + TxtDGAddlCharge + ";";
                        lstrCT_MESSAGE += " DG Addl Cost:" + TxtDGAddlCost + "; Unit Cost :" + TxtUnitCost + ";";
                        lstrCT_MESSAGE += " Total Dimension:" + TxtCargoTotalDiminm + "; Total Cost :" + TxtTotalCost + ";";
                    }


                    string lstrCT_TYPEOFCARGO = TypeofCargo;
                    string lstrCT_CATEGORYOFCARGO = CategoryofCargo;
                    string lstrCT_OVERLENGTH = Length;
                    string lstrCT_OVERWIDTH = Width;
                    string lstrCT_OVERHEIGHT = Height;
                    string lstrCT_WEIGHT = Weight;
                    string lstrCT_DANGEROUSCARGO = TxtYesNo;
                    string lstrCT_BASECOST = BaseCostVal;
                    string lstrCT_DGADDLCHARGE = TxtDGAddlCharge.ToString();

                    lstrResult = objBl.OOGRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference, lstrCT_TYPEOFCARGO, lstrCT_CATEGORYOFCARGO, lstrCT_OVERLENGTH, lstrCT_OVERWIDTH, lstrCT_OVERHEIGHT, lstrCT_WEIGHT, lstrCT_DANGEROUSCARGO, lstrCT_BASECOST, lstrCT_DGADDLCHARGE);
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }


                    if (lstrResult.ToUpper() == "TRUE")
                    {
                        await App.Current.MainPage?.Navigation.PushAsync(new OogBreakBulkMsg());
                    }
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for OOG Price Calcultion
        /// </summary>
        /// <param name="TypeofCargo"></param>
        /// <param name="CategoryofCargo"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="BaseCostVal"></param>
        private void OOGPriceCalc(string TypeofCargo, string CategoryofCargo, string Weight, string Length, string Width, string Height, string BaseCostVal)
        {
            try
            {
                OOGCalcuationModel objOOGCalc = new OOGCalcuationModel();

                //Total Dimension (CM) = Length * Width * Height

                double dblWeight = Convert.ToDouble(Weight);
                double dblLength = Convert.ToDouble(Length);
                double dblWidth = Convert.ToDouble(Width);
                double dblHeight = Convert.ToDouble(Height);
                double dblBaseCostVal = Convert.ToDouble(BaseCostVal);

                TxtOverLengthm = objOOGCalc.Centimeter2Meter(dblLength);

                TxtOverHeightm = objOOGCalc.Centimeter2Meter(dblHeight);

                TxtOverWidthm = objOOGCalc.Centimeter2Meter(dblWidth);

                TxtTotalDiminmeters = objOOGCalc.TotalDimention(TxtOverLengthm, TxtOverHeightm, TxtOverWidthm);

                TxtTotalDimensionsincm = objOOGCalc.TotalDimention(dblLength, dblHeight, dblWidth);

                //DG Addl Cost = Base Cost * Dg Addl Charge
                TxtDGAddlCost = objOOGCalc.DGaddlCost(dblBaseCostVal, TxtDGAddlCharge);

                // Unit Cost = Base Cost + DG Addl Charge
                TxtUnitCost = objOOGCalc.UnitCost(dblBaseCostVal, TxtDGAddlCharge);
                //Weight Convert to Tonne
                //Qty Calc
                TxtWeightinTon = objOOGCalc.WeightTon(dblWeight);
                //Total Cost = Unit Cost * Qty
                TxtTotalCost = objOOGCalc.TotalCost(TxtUnitCost, TxtWeightinTon);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Function for Breakbulk Price Calcultion
        /// </summary>
        /// <param name="TypeofCargo"></param>
        /// <param name="CategoryofCargo"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="BaseCostVal"></param>
        /// <returns></returns>
        private void BreakbulkrequestPriceCalc(string TypeofCargo, string CategoryofCargo, string Weight, string Length, string Width, string Height, string BaseCostVal)
        {
            OogBreakBulkRequestModel objBreakbulkCalc = new OogBreakBulkRequestModel();

            double dblWeight = Convert.ToDouble(Weight);
            double dblLength = Convert.ToDouble(Length);
            double dblWidth = Convert.ToDouble(Width);
            double dblHeight = Convert.ToDouble(Height);
            double dblBaseCostVal = Convert.ToDouble(BaseCostVal);
            //DG Addl Cost = Base Cost * Dg Addl Charge
            TxtDGAddlCost = objBreakbulkCalc.DGAddlCost(dblBaseCostVal, TxtDGAddlCharge);
            TxtCargoLengthm = objBreakbulkCalc.Centimeter2Meter(dblLength);

            TxtCargoHeightm = objBreakbulkCalc.Centimeter2Meter(dblHeight);

            TxtCargoWidthm = objBreakbulkCalc.Centimeter2Meter(dblWidth);

            TxtCargoTotalDiminm = objBreakbulkCalc.TotalDimentionM(TxtCargoLengthm, TxtCargoHeightm, TxtCargoWidthm);

            TxtTotalDimension = objBreakbulkCalc.TotalDimentionCm(dblLength, dblHeight, dblWidth);

            // Unit Cost = Base Cost + DG Addl Charge
            TxtUnitCost = objBreakbulkCalc.Unitcost(dblBaseCostVal, TxtDGAddlCharge);

            TxtWeightinTon = objBreakbulkCalc.WeightTon(dblWeight);



            //Total Cost = Unit Cost * Qty
            TxtTotalCost =  objBreakbulkCalc.Totalcost(TxtUnitCost, TxtWeightinTon);
           //
           //
           //
           // await Task.Delay(1000);

        }
        /// <summary>
        /// To get button_Clicked button
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);

            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }

        /// <summary>
        ///  To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow(string[] fileTypes)
        {

            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename = true;
                    IsVisibleCancel = true;
                    IsChoosefile = false;
                    TxtFilename = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);

            }
        }

        /// <summary>
        /// To get btncancel button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            try
            {
                StackOogBreakBulkRequest = false;
                await Task.Delay(1000);
                IsVisibleFilename = false;
                TxtFilename = ""; 
                IsVisibleCancel = false;
                IsChoosefile = true;
                StackOogBreakBulkRequest = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to Request History
        /// </summary>
        /// <returns></returns>
        private async Task tapmanifestrequesthistory()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "OOG"));
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// Button Reset Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonreset()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new OogBreakBulkRequest());
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }

        /// <summary>
        /// Choose File Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile2() //20230111
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow2(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }

        /// <summary>
        /// To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow2(string[] fileTypes)
        {

            await Task.Delay(1000);
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename2 = true;
                    IsVisibleCancel2 = true;
                    IsChoosefile2 = false;
                    TxtFilename2 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName2 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName2.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName2.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType2 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody2 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);

            }
        }
        /// <summary>
        /// Choose File Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile3() //20230111
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow3(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// //To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow3(string[] fileTypes)
        {

            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename3 = true;
                    IsVisibleCancel3 = true;
                    IsChoosefile3 = false;
                    TxtFilename3 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName3 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName3.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName3.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType3 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody3 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);

            }
        }
        //20230111
        /// <summary>
        /// Choose File Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile4()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow4(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        ///  //To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow4(string[] fileTypes)
        {

            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename4 = true;
                    IsVisibleCancel4 = true;
                    IsChoosefile4 = false;
                    TxtFilename4 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName4 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName4.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName4.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType4 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody4 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);

            }
        }
        //20230111
        /// <summary>
        /// Choose File Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile5()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            string[] fileTypes = null;
            if (Device.RuntimePlatform == Device.Android)
            {
                fileTypes = new string[] { "image/png", "image/jpeg" };
            }
            await PickAndShow5(fileTypes);
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow5(string[] fileTypes)
        {

            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename5 = true;
                    IsVisibleCancel5 = true;
                    IsChoosefile5 = false;
                    TxtFilename5 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName5 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName5.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName5.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType5 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody5 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);

            }
        }
        /// <summary>
        /// Choose File Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile6() //20230111
        {

            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow6(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }

        /// <summary>
        /// To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow6(string[] fileTypes)
        {

            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename6 = true;
                    IsVisibleCancel6 = true;
                    IsChoosefile6 = false;
                    TxtFilename6 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName6 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName6.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType6 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody6 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Choose File Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile7()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            try
            {

                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow7(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// To load PickAndShow Caption
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow7(string[] fileTypes)
        {
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename7 = true;
                    IsVisibleCancel7 = true;
                    IsChoosefile7 = false;
                    TxtFilename7 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName7 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName7.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName7.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType7 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody7 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);

            }
        }
        //20230111
        /// <summary>
        /// Choose File Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile8()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);

            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow8(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Pick And Show
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow8(string[] fileTypes)
        {

            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename8 = true;
                    IsVisibleCancel8 = true;
                    IsChoosefile8 = false;
                    TxtFilename8 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName8 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName8.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType8 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody8 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //20230111
        /// <summary>
        /// Function for Pick And Show
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile9()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);

            try
            {

                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow9(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //To load PickAndShow Caption
        /// <summary>
        /// Function for Pick And Show
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow9(string[] fileTypes)
        {
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename9 = true;
                    IsVisibleCancel9 = true;
                    IsChoosefile9 = false;
                    TxtFilename9 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName9 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName9.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileName9.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType9 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody9 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //20230111
        /// <summary>
        /// Function for Pick And Show
        /// </summary>
        /// <returns></returns>
        private async Task buttonchooseFile1()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            try
            {

                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }
                await PickAndShow1(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// Function for Pick And Show
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow1(string[] fileTypes)
        {
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    IsVisibleFilename1 = true;
                    IsVisibleCancel1 = true;
                    IsChoosefile1 = false;
                    TxtFilename1 = pickedFile.FileName.ToString();
                    clsOOGPhotos.strFileName10 = pickedFile.FileName;
                    int lintLastDotPos = clsOOGPhotos.strFileName10.LastIndexOf('.');
                    string lstrLoadFileType = clsOOGPhotos.strFileType10.Substring(lintLastDotPos + 1);
                    clsOOGPhotos.strFileType10 = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    clsOOGPhotos.strFileBody10 = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel1()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            IsVisibleFilename1 = false;
            TxtFilename1 = "";
            IsVisibleCancel1 = false;
            IsChoosefile1 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel2()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename2 = false;
            TxtFilename2 = "";
            IsVisibleCancel2 = false;
            IsChoosefile2 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel3()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename3 = false;
            TxtFilename3 = "";
            IsVisibleCancel3 = false;
            IsChoosefile3 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel4()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename4 = false;
            TxtFilename4 = "";
            IsVisibleCancel4 = false;
            IsChoosefile4 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel5()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename5 = false;
            TxtFilename5 = "";
            IsVisibleCancel5 = false;
            IsChoosefile5 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel6()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename6 = false;
            TxtFilename6 = "";
            IsVisibleCancel6 = false;
            IsChoosefile6 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel7()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename7 = false;
            TxtFilename7 = "";
            IsVisibleCancel7 = false;
            IsChoosefile7 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel8()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename8 = false;
            TxtFilename8 = "";
            IsVisibleCancel8 = false;
            IsChoosefile8 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        //20230111
        /// <summary>
        /// Function for Cancel Button
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel9()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            await Task.Delay(1000);
            lblFilename9 = false;
            TxtFilename9 = "";
            IsVisibleCancel9 = false;
            IsChoosefile9 = true;
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// To get Hide Validation
        /// </summary>
        /// <returns></returns>
        private async Task hideValidation()
        {
            IsvalidatedChooseFile = false;
            IsvalidatedChooseFile2 = false;
            IsvalidatedChooseFile3 = false;
            IsvalidatedChooseFile4 = false;
            IsvalidatedChooseFile5 = false;
            IsvalidatedChooseFile7 = false;
            IsvalidatedChooseFile8 = false;
            IsvalidatedChooseFile9 = false;
            IsvalidatedChooseFile1 = false;
             IsvalidatedLengthincm = false;
            IsvalidatedWidthincm = false;
            IsvalidatedHeightincm = false;
            IsvalidatedWeight = false;
            IsvalidatedTypeofCargo = false;
            IsvalidatedCategoryofCargo = false;
            IsvalidatedProvideValid4 = false;
            IsvalidatedProvideValid3 = false;
            IsvalidatedProvideValid2 = false;
            IsvalidatedProvideValid = false;
           
        }

        /// <summary>
        /// Button OOG Price Calc Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonOOG()
        {

            IsBusy = true;
            StackOogBreakBulkRequest = false;
            bool blResult = true;
            await Task.Delay(1000);
            try
            {
                 hideValidation();
                blResult = OOGValidation();
                string BaseCostVal = "0";
                if (blResult == true)
                {
                    if (ChkValYes == true)
                    {
                        TxtYesNo = "Yes";
                        TxtDGAddlCharge = Convert.ToDouble(strAddlchargecalculate) / 100;
                    }
                    else
                    {
                        TxtDGAddlCharge = 0;
                        TxtYesNo = "No";
                    }
                    if (CategoryofCargo == "Import")
                    {
                        BaseCostVal = strBreakbulkImport;
                    }

                    if (CategoryofCargo == "Export")
                    {
                        BaseCostVal = strBreakbulkExport;
                    }

                    if (CategoryofCargo == "Transshipment")
                    {
                        BaseCostVal = strBreakbulkTransshipment;
                    }

                    //App.Current.MainPage?.Navigation.PushAsync(new OOGPriceCalcWebView(TypeofCargo, CategoryofCargo, Length, Width, Height, Weight, TxtYesNo, BaseCostVal, TxtDGAddlCharge.ToString()));
                    await fnOogpriceCalculator(TypeofCargo, CategoryofCargo, Weight, Length, Width, Height, TxtYesNo);
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);

            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// Button Breakbulk Price Calc Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonBreakBulk()
        {

            IsBusy = true;
            StackOogBreakBulkRequest = false;
            bool blResult = true;
            await Task.Delay(1000);
            try
            {
                 hideValidation();
                blResult = BulkRequestValidation();
                string BaseCostVal = "0";
                if (blResult == true)
                {
                    if (ChkValYes == true)
                    {
                        TxtYesNo = "Yes";
                        TxtDGAddlCharge = Convert.ToDouble(strAddlchargecalculate) / 100;
                    }
                    else
                    {
                        TxtDGAddlCharge = 0;
                        TxtYesNo = "No";
                    }
                    if (CategoryofCargo == "Import")
                    {
                        BaseCostVal = strBreakbulkImport;
                    }

                    if (CategoryofCargo == "Export")
                    {
                        BaseCostVal = strBreakbulkExport;
                    }

                    if (CategoryofCargo == "Transshipment")
                    {
                        BaseCostVal = strBreakbulkTransshipment;
                    }
                    //App.Current.MainPage?.Navigation.PushAsync(new BreakbulkPriceCalcWebView(TypeofCargo, CategoryofCargo, Length, Width, Height, Weight, TxtYesNo, BaseCostVal, TxtDGAddlCharge.ToString()));

                    await fnBBpriceCalculator(TypeofCargo, CategoryofCargo, Weight, Length, Width, Height, TxtYesNo, TxtDGAddlCharge.ToString());
                }

            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackOogBreakBulkRequest = true;
            IsBusy = false;
        }
        /// <summary>
        /// OOG Price Calculation Valiadtion
        /// </summary>
        /// <returns></returns>
        private  bool OOGValidation()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            bool blResult = true;

            try
            {
                 hideValidation();
                Weight = TxtWeight.ToString().Trim();
                Length = Txtlengthincm.ToString().Trim();
                Width = Txtwidthincm.ToString().Trim();
                Height = TxtHeightincm.ToString().Trim();
                TxtYesNo = TxtYesNo.ToString().Trim();


                if (_selectedCargopick != null)
                {
                    IsvalidatedTypeofCargo = false;
                    TypeofCargo = _selectedCargopick.Key;
                }
                else
                {
                    blResult = false;
                    IsvalidatedTypeofCargo = true;
                }

                if (_selectedCatogoryPick1 != null)
                {
                    IsvalidatedCategoryofCargo = false;
                    CategoryofCargo = _selectedCatogoryPick1.Key;
                }
                else
                {
                    blResult = false;
                    IsvalidatedCategoryofCargo = true;
                }
                if ((Length == "") || (Length == null))
                {
                    blResult = false;
                    IsvalidatedLengthincm = true;
                }
                else
                {
                    var calcLength = Convert.ToInt32(Length);
                    if (calcLength == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid = true;
                    }
                    if (calcLength > 350)
                    {
                        blResult = false;
                        IsvalidatedProvideValid = true;
                    }

                }

                if ((Width == "") || (Width == null))
                {
                    blResult = false;
                    IsvalidatedWidthincm = true;
                }
                else
                {
                    var calcWidth = Convert.ToInt32(Width);
                   
                    if (calcWidth == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid2 = true;
                    }
                    if (calcWidth > 350)
                    {
                        blResult = false;
                        IsvalidatedProvideValid2 = true;
                    }

                }

                if ((Height == "") || (Height == null))
                {
                    blResult = false;
                    IsvalidatedHeightincm = true;
                }
                else
                {
                    var calcHeight = Convert.ToInt32(Height);
                    if (calcHeight == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid3 = true;
                    }
                    if (calcHeight > 500)
                    {
                        blResult = false;
                        IsvalidatedProvideValid3 = true;
                    }

                }
                if ((Weight == "") || (Weight == null))
                {
                    blResult = false;
                    IsvalidatedWeight = true;
                }
                else
                {
                    var calcHeight = Convert.ToInt32(Weight);

                    if (calcHeight == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid4 = true;
                    }
                    if (calcHeight > 120000)
                    {
                        blResult = false;
                        IsvalidatedProvideValid4 = true;
                    }

                }
                if (ChkValYes == true)
                {
                    TxtYesNo = "Yes";
                    //TxtDGAddlCharge = Convert.ToDouble(strAddlchargecalculate) / 100;
                }
                else
                {
                    //TxtDGAddlCharge = 0;
                    TxtYesNo = "No";
                }
               
            }
          
            catch (Exception ex)
            {
                string strErrorMsg = ex.Message.ToString(); 
              App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
           
            IsBusy = false;
            StackOogBreakBulkRequest = true;
            return blResult;
        }

      
        /// <summary>
        /// Breakbulk Price Calculation Valiadtion
        /// </summary>
        /// <returns></returns>
        private bool BulkRequestValidation()
        {
            IsBusy = true;
            StackOogBreakBulkRequest = false;
            bool blResult = true;
            try
            {
                 hideValidation();
                Weight = TxtWeight.ToString().Trim();
                Length = Txtlengthincm.ToString().Trim();
                Width = Txtwidthincm.ToString().Trim();
                Height = TxtHeightincm.ToString().Trim();

                if (_selectedCargopick != null)
                {
                    IsvalidatedTypeofCargo = false;
                    TypeofCargo = _selectedCargopick.Key;
                }
                else
                {
                    blResult = false;
                    IsvalidatedTypeofCargo = true;
                }

                if (_selectedCatogoryPick1 != null)
                {
                    IsvalidatedCategoryofCargo = false;
                    CategoryofCargo = _selectedCatogoryPick1.Key;
                }
                else
                {
                    blResult = false;
                    IsvalidatedCategoryofCargo = true;
                }
                if ((Length == "") || (Length == null))
                {
                    blResult = false;
                    IsvalidatedLengthincm = true;
                }
                else
                {
                    var calcLength = Convert.ToInt32(Length);
                    if (calcLength == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid = true;
                    }
                    if (calcLength > 2000)
                    {
                        blResult = false;
                        IsvalidatedProvideValid = true;
                    }

                }

                if ((Width == "") || (Width == null))
                {
                    blResult = false;
                    IsvalidatedWidthincm = true;
                }
                else
                {
                    var calcWidth = Convert.ToInt32(Width);
                    if (calcWidth == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid2 = true;

                    }
                    if (calcWidth > 1000)
                    {
                        blResult = false;
                        IsvalidatedProvideValid2 = true;
                    }

                }

                if ((Height == "") || (Height == null))
                {
                    blResult = false;
                    IsvalidatedHeightincm = true;
                }
                else
                {
                    var calcHeight = Convert.ToInt32(Height);
                    if (calcHeight == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid3 = true;
                    }
                    if (calcHeight > 800)
                    {
                        blResult = false;
                        IsvalidatedProvideValid3 = true;
                    }

                }
                if ((Weight == "") || (Weight == null))
                {
                    blResult = false;
                    IsvalidatedWeight = true;
                }
                else
                {
                    var calcHeight = Convert.ToInt32(Weight);
                    if (calcHeight == 0)
                    {
                        blResult = false;
                        IsvalidatedProvideValid4 = true;
                    }
                    if (calcHeight > 120000)
                    {
                        blResult = false;
                        IsvalidatedProvideValid4 = true;
                    }

                }

            }
            catch (Exception ex)
            {
                string strErrorMsg = ex.Message.ToString();

                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

            IsBusy = false;
            StackOogBreakBulkRequest = true;

            return blResult;
            
           
        }
        /// <summary>
        /// Function For OOG price Calculator
        /// </summary>
        /// <param name="fstrTypeofCargo"></param>
        /// <param name="fstrCategoryofCargo"></param>
        /// <param name="fstrWeight"></param>
        /// <param name="fstrLength"></param>
        /// <param name="fstrWidth"></param>
        /// <param name="fstrHeight"></param>
        /// <param name="fstrChkDGCargo"></param>
        /// <returns></returns>
        private async Task fnOogpriceCalculator(string fstrTypeofCargo, string fstrCategoryofCargo, string fstrWeight, string fstrLength, string fstrWidth, string fstrHeight, string fstrChkDGCargo)
        {
            try
            {
                string lblValCargoType = fstrTypeofCargo;
                string lblValCategory = fstrCategoryofCargo;
                string lblValLength = fstrLength;
                string lblValWidth = fstrWidth;
                string lblValHeight = fstrHeight;
                string lblValWeight = fstrWeight;
                string lblValChkDGCargo = fstrChkDGCargo;
               


               await App.Current.MainPage?.Navigation.PushAsync(new OOG_PriceCalculation(lblValCargoType, lblValCategory, fstrWeight, lblValLength, lblValWidth, lblValHeight, lblValChkDGCargo));
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// Function For Breakbulk price Calculator
        /// </summary>
        /// <param name="fstrTypeofCargo"></param>
        /// <param name="fstrCategoryofCargo"></param>
        /// <param name="fstrWeight"></param>
        /// <param name="fstrLength"></param>
        /// <param name="fstrWidth"></param>
        /// <param name="fstrHeight"></param>
        /// <param name="fstrDGCargo"></param>
        /// <param name="fstrDGaddlch"></param>
        /// <returns></returns>
        private async Task fnBBpriceCalculator(string fstrTypeofCargo, string fstrCategoryofCargo, string fstrWeight, string fstrLength, string fstrWidth, string fstrHeight, string fstrDGCargo,  string fstrDGaddlch)
        {
            try
            {
                string lblValCargoType = fstrTypeofCargo;
                string lblValCategory = fstrCategoryofCargo;
                string lblValLength = fstrLength;
                string lblValWidth = fstrWidth;
                string lblValHeight = fstrHeight;
                string lblValWeight = fstrWeight;
                string lblvalDGCargo = fstrDGCargo;
                string lblvalDGaddlch = fstrDGaddlch;

                await App.Current.MainPage?.Navigation.PushAsync(new BreakBulk_PriceCalculation(lblValCargoType, lblValCategory, fstrWeight, lblValLength, lblValWidth, lblValHeight, lblvalDGCargo, lblvalDGaddlch));
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

       

    }

}
