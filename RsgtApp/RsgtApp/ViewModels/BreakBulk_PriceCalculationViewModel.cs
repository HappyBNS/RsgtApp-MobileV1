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
using Xamarin.Essentials;
using Xamarin.Forms;
using static RsgtApp.Models.OOGCalcuationModel;

namespace RsgtApp.ViewModels
{
    public class BreakBulk_PriceCalculationViewModel : INotifyPropertyChanged
    {

        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        
        private string strLanguage = App.gblLanguage;
        WebApiMethod objWebApi = new WebApiMethod();
        private string strServerSlowMsg = "";
        public List<EnumCombo> lobjOogBreakBulkrequest { get; set; } = new List<EnumCombo>();
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command ButtonCancel { get; set; }
        public Command Buttonsubmit { get; set; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on RaisePropertyChange Event
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
        //To handle Boolen variable
        private bool stackBreakBulkPriceCal = true;
        public bool StackBreakBulkPriceCal
        {
            get { return stackBreakBulkPriceCal; }
            set
            {
                stackBreakBulkPriceCal = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBreakBulkPriceCal");
            }
        }
        //LblStatus purpose of using Label varaiable 
        private string imgOOGbreakbulkiconblue = "";
        public string ImgOOGbreakbulkiconblue
        {
            get { return imgOOGbreakbulkiconblue; }
            set
            {
                imgOOGbreakbulkiconblue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgOOGbreakbulkiconblue");
            }
        }
        private string strvalDGAddlCharge = "";
        public string strValDGAddlCharge
        {
            get { return strvalDGAddlCharge; }
            set
            {
                strvalDGAddlCharge = value;
                OnPropertyChanged();
                RaisePropertyChange("strValDGAddlCharge");
            }
        }

        private string strbasecost = "";
        public string strBasecost
        {
            get { return strbasecost; }
            set
            {
                strbasecost = value;
                OnPropertyChanged();
                RaisePropertyChange("strBasecost");
            }
        }
        private string strcargoLengthcm = "";
        public string strCargoLengthcm
        {
            get { return strcargoLengthcm; }
            set
            {
                strcargoLengthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("strCargoLengthcm");
            }
        }
        private string strcargoHeightcm = "";
        public string strCargoHeightcm
        {
            get { return strcargoHeightcm; }
            set
            {
                strcargoHeightcm = value;
                OnPropertyChanged();
                RaisePropertyChange("strCargoHeightcm");
            }
        }
        private string strcargoWidthcm = "";
        public string strCargoWidthcm
        {
            get { return strcargoWidthcm; }
            set
            {
                strcargoWidthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("strCargoWidthcm");
            }
        }
        private string strcargoLengthm = "";
        public string strCargoLengthm
        {
            get { return strcargoLengthm; }
            set
            {
                strcargoLengthm = value;
                OnPropertyChanged();
                RaisePropertyChange("strCargoLengthm");
            }
        }
        private string strcargoHeightm = "";
        public string strCargoHeightm
        {
            get { return strcargoHeightm; }
            set
            {
                strcargoHeightm = value;
                OnPropertyChanged();
                RaisePropertyChange("strCargoHeightm");
            }
        }
        private string strcargoWidthm = "";
        public string strCargoWidthm
        {
            get { return strcargoWidthm; }
            set
            {
                strcargoWidthm = value;
                OnPropertyChanged();
                RaisePropertyChange("strCargoWidthm");
            }
        }
        private string strcargoTotalDiminm = "";
        public string strCargoTotalDiminm
        {
            get { return strcargoTotalDiminm; }
            set
            {
                strcargoTotalDiminm = value;
                OnPropertyChanged();
                RaisePropertyChange("strCargoTotalDiminm");
            }
        }
        private string strtotalDimensioncm = "";
        public string strTotalDimensioncm
        {
            get { return strtotalDimensioncm; }
            set
            {
                strtotalDimensioncm = value;
                OnPropertyChanged();
                RaisePropertyChange("strTotalDimensioncm");
            }
        }
        private string strdGAddlCost = "";
        public string strDGAddlCost
        {
            get { return strdGAddlCost; }
            set
            {
                strdGAddlCost = value;
                OnPropertyChanged();
                RaisePropertyChange("strDGAddlCost");
            }
        }
        private string strunitCost = "";
        public string strUnitCost
        {
            get { return strunitCost; }
            set
            {
                strunitCost = value;
                OnPropertyChanged();
                RaisePropertyChange("strUnitCost");
            }
        }
        private string strtotalcost = "";
        public string strTotalcost
        {
            get { return strtotalcost; }
            set
            {
                strtotalcost = value;
                OnPropertyChanged();
                RaisePropertyChange("strTotalcost");
            }
        }
        private string lblOOGBreakbulkRequest = "";
        public string LblOOGBreakbulkRequest
        {
            get { return lblOOGBreakbulkRequest; }
            set
            {
                lblOOGBreakbulkRequest = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOOGBreakbulkRequest");
            }
        }
        private string imgRequesticondarkblue = "";
        public string ImgRequesticondarkblue
        {
            get { return imgRequesticondarkblue; }
            set
            {
                imgRequesticondarkblue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRequesticondarkblue");
            }
        }
        private string lblBBPriceCalculation = "";
        public string LblBBPriceCalculation
        {
            get { return lblBBPriceCalculation; }
            set
            {
                lblBBPriceCalculation = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBBPriceCalculation");
            }
        }
        private string lblTypeofCargo = "";
        public string LblTypeofCargo
        {
            get { return lblTypeofCargo; }
            set
            {
                lblTypeofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTypeofCargo");
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
        private string lblCategoryofCargo = "";
        public string LblCategoryofCargo
        {
            get { return lblCategoryofCargo; }
            set
            {
                lblCategoryofCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCategoryofCargo");
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
        private string lblCargoSizeDimension = "";
        public string LblCargoSizeDimension
        {
            get { return lblCargoSizeDimension; }
            set
            {
                lblCargoSizeDimension = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoSizeDimension");
            }
        }
        private string lblCargoLengthcm = "";
        public string LblCargoLengthcm
        {
            get { return lblCargoLengthcm; }
            set
            {
                lblCargoLengthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoLengthcm");
            }
        }
        private double txtCargoLengthcm = 0;
        public double TxtCargoLengthcm
        {
            get { return txtCargoLengthcm; }
            set
            {
                txtCargoLengthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoLengthcm");
            }
        }
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
        private string lblCargoLengthm = "";
        public string LblCargoLengthm
        {
            get { return lblCargoLengthm; }
            set
            {
                lblCargoLengthm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoLengthm");
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
        private string lblCargoWidthcm = "";
        public string LblCargoWidthcm
        {
            get { return lblCargoWidthcm; }
            set
            {
                lblCargoWidthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoWidthcm");
            }
        }
        private double txtCargoWidthcm = 0;
        public double TxtCargoWidthcm
        {
            get { return txtCargoWidthcm; }
            set
            {
                txtCargoWidthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoWidthcm");
            }
        }
        private string lblCargoWidthm = "";
        public string LblCargoWidthm
        {
            get { return lblCargoWidthm; }
            set
            {
                lblCargoWidthm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoWidthm");
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
        private string lblCargoHeighcm = "";
        public string LblCargoHeighcm
        {
            get { return lblCargoHeighcm; }
            set
            {
                lblCargoHeighcm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoHeighcm");
            }
        }
        private string txtCargoHeighcm = "";
        public string TxtCargoHeighcm
        {
            get { return txtCargoHeighcm; }
            set
            {
                txtCargoHeighcm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoHeighcm");
            }
        }
        private string lblCargoHeightm = "";
        public string LblCargoHeightm
        {
            get { return lblCargoHeightm; }
            set
            {
                lblCargoHeightm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoHeightm");
            }
        }
        private double txtCargoHeightcm = 0;
        public double TxtCargoHeightcm
        {
            get { return txtCargoHeightcm; }
            set
            {
                txtCargoHeightcm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCargoHeightcm");
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
        private string lblCargoTotalDiminm = "";
        public string LblCargoTotalDiminm
        {
            get { return lblCargoTotalDiminm; }
            set
            {
                lblCargoTotalDiminm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoTotalDiminm");
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
        private string lblTotalDimension = "";
        public string LblTotalDimension
        {
            get { return lblTotalDimension; }
            set
            {
                lblTotalDimension = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTotalDimension");
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
        private string lblTotalCost = "";
        public string LblTotalCost
        {
            get { return lblTotalCost; }
            set
            {
                lblTotalCost = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTotalCost");
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
        private string lblDGAddlCharge = "";
        public string LblDGAddlCharge
        {
            get { return lblDGAddlCharge; }
            set
            {
                lblDGAddlCharge = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDGAddlCharge");
            }
        }
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

        private double txtValDGAddlCharge = 0;
        public double TxtValDGAddlCharge
        {
            get { return txtValDGAddlCharge; }
            set
            {
                txtValDGAddlCharge = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtValDGAddlCharge");
            }
        }
        private string lblDGAddlCost = "";
        public string LblDGAddlCost
        {
            get { return lblDGAddlCost; }
            set
            {
                lblDGAddlCost = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDGAddlCost");
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
        private string lblUnitCost = "";
        public string LblUnitCost
        {
            get { return lblUnitCost; }
            set
            {
                lblUnitCost = value;
                OnPropertyChanged();
                RaisePropertyChange("LblUnitCost");
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
        private string lblRemarks = "";
        public string LblRemarks
        {
            get { return lblRemarks; }
            set
            {
                lblRemarks = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarks");
            }
        }
        private string lblDisclaimer = "";
        public string LblDisclaimer
        {
            get { return lblDisclaimer; }
            set
            {
                lblDisclaimer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDisclaimer");
            }
        }
        private string btnCancel = "";
        public string BtnCancel
        {
            get { return btnCancel; }
            set
            {
                btnCancel = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnCancel");
            }
        }
        private string btnConfirm = "";
        public string BtnConfirm
        {
            get { return btnConfirm; }
            set
            {
                btnConfirm = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnConfirm");
            }
        }
        private string imgpdficon = "";
        public string Imgpdficon
        {
            get { return imgpdficon; }
            set
            {
                imgpdficon = value;
                OnPropertyChanged();
                RaisePropertyChange("Imgpdficon");
            }
        }
        private string btnPrintPDF = "";
        public string BtnPrintPDF
        {
            get { return btnPrintPDF; }
            set
            {
                btnPrintPDF = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnPrintPDF");
            }
        }
        private string lblBaseCost = "";
        public string LblBaseCost
        {
            get { return lblBaseCost; }
            set
            {
                lblBaseCost = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBaseCost");
            }
        }
        private double txtBaseCost = 0;
        public double TxtBaseCost
        {
            get { return txtBaseCost; }
            set
            {
                txtBaseCost = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBaseCost");
            }
        }
        private string lblIsitDangerCargo = "";
        public string LblIsitDangerCargo
        {
            get { return lblIsitDangerCargo; }
            set
            {
                lblIsitDangerCargo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblIsitDangerCargo");
            }
        }
        private string lblWeightinkg = "";
        public string LblWeightinkg
        {
            get { return lblWeightinkg; }
            set
            {
                lblWeightinkg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWeightinkg");
            }
        }
        private string txtWeightinkg = "";
        public string TxtWeightinkg
        {
            get { return txtWeightinkg; }
            set
            {
                txtWeightinkg = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtWeightinkg");
            }
        }
        private string lblWeightinTon = "";
        public string LblWeightinTon
        {
            get { return lblWeightinTon; }
            set
            {
                lblWeightinTon = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWeightinTon");
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
        private string lblWeight = "";
        public string LblWeight
        {
            get { return lblWeight; }
            set
            {
                lblWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWeight");
            }
        }
        private string lblCargoTotalDimincm = "";
        public string LblCargoTotalDimincm
        {
            get { return lblCargoTotalDimincm; }
            set
            {
                lblCargoTotalDimincm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCargoTotalDimincm");
            }
        }
        private string lblvalCargoType = "";
        public string lblValCargoType
        {
            get { return lblvalCargoType; }
            set
            {
                lblvalCargoType = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValCargoType");
            }
        }
        private string lblvalCategory = "";
        public string lblValCategory
        {
            get { return lblvalCategory; }
            set
            {
                lblvalCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValCategory");
            }
        }
        private string lblvalHeight = "";
        public string lblValHeight
        {
            get { return lblvalHeight; }
            set
            {
                lblvalHeight = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValHeight");
            }
        }
        private string lblvalLength = "";
        public string lblValLength
        {
            get { return lblvalLength; }
            set
            {
                lblvalLength = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValLength");
            }
        }
        private string lblvalWidth = "";
        public string lblValWidth
        {
            get { return lblvalWidth; }
            set
            {
                lblvalWidth = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValWidth");
            }
        }
        private string lblvalWeight = "";
        public string lblValWeight
        {
            get { return lblvalWeight; }
            set
            {
                lblvalWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("lblValWeight");
            }
        }
        private string lblRemarkpara = "";
        public string LblRemarkpara
        {
            get { return lblRemarkpara; }
            set
            {
                lblRemarkpara = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara");
            }
        }
        private string lblRemarkpara2 = "";
        public string LblRemarkpara2
        {
            get { return lblRemarkpara2; }
            set
            {
                lblRemarkpara2 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara2");
            }
        }
        private string lblRemarkpara3 = "";
        public string LblRemarkpara3
        {
            get { return lblRemarkpara3; }
            set
            {
                lblRemarkpara3 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara3");
            }
        }
        private string lblRemarkpara4 = "";
        public string LblRemarkpara4
        {
            get { return lblRemarkpara4; }
            set
            {
                lblRemarkpara4 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara4");
            }
        }
        private string lblRemarkpara5 = "";
        public string LblRemarkpara5
        {
            get { return lblRemarkpara5; }
            set
            {
                lblRemarkpara5 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara5");
            }
        }
        private string lblRemarkpara6 = "";
        public string LblRemarkpara6
        {
            get { return lblRemarkpara6; }
            set
            {
                lblRemarkpara6 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara6");
            }
        }
        private string lblRemarkpara7 = "";
        public string LblRemarkpara7
        {
            get { return lblRemarkpara7; }
            set
            {
                lblRemarkpara7 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara7");
            }
        }
        private string lblRemarkpara8 = "";
        public string LblRemarkpara8
        {
            get { return lblRemarkpara8; }
            set
            {
                lblRemarkpara8 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara8");
            }
        }
        private string lblRemarkpara9 = "";
        public string LblRemarkpara9
        {
            get { return lblRemarkpara9; }
            set
            {
                lblRemarkpara9 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara9");
            }
        }
        private string lblRemarkpara10 = "";
        public string LblRemarkpara10
        {
            get { return lblRemarkpara10; }
            set
            {
                lblRemarkpara10 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara10");
            }
        }
        private string lblRemarkpara11 = "";
        public string LblRemarkpara11
        {
            get { return lblRemarkpara11; }
            set
            {
                lblRemarkpara11 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara11");
            }
        }
        private string lblRemarkpara12 = "";
        public string LblRemarkpara12
        {
            get { return lblRemarkpara12; }
            set
            {
                lblRemarkpara12 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara12");
            }
        }
        private string lblRemarkpara13 = "";
        public string LblRemarkpara13
        {
            get { return lblRemarkpara13; }
            set
            {
                lblRemarkpara13 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara13");
            }
        }
        private string lblRemarkpara14 = "";
        public string LblRemarkpara14
        {
            get { return lblRemarkpara14; }
            set
            {
                lblRemarkpara14 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara14");
            }
        }
        private string lblRemarkpara15 = "";
        public string LblRemarkpara15
        {
            get { return lblRemarkpara15; }
            set
            {
                lblRemarkpara15 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara15");
            }
        }
        private string lblRemarkpara16 = "";
        public string LblRemarkpara16
        {
            get { return lblRemarkpara16; }
            set
            {
                lblRemarkpara16 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara16");
            }
        }
        private string lblRemarkpara17 = "";
        public string LblRemarkpara17
        {
            get { return lblRemarkpara17; }
            set
            {
                lblRemarkpara17 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara17");
            }
        }
        private string lblRemarkpara18 = "";
        public string LblRemarkpara18
        {
            get { return lblRemarkpara18; }
            set
            {
                lblRemarkpara18 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara18");
            }
        }
        private string lblRemarkpara19 = "";
        public string LblRemarkpara19
        {
            get { return lblRemarkpara19; }
            set
            {
                lblRemarkpara19 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara19");
            }
        }
        private string lblRemarkpara20 = "";
        public string LblRemarkpara20
        {
            get { return lblRemarkpara20; }
            set
            {
                lblRemarkpara20 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara20");
            }
        }
        private string lblRemarkpara21 = "";
        public string LblRemarkpara21
        {
            get { return lblRemarkpara21; }
            set
            {
                lblRemarkpara21 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara21");
            }
        }
        private string lblRemarkpara22 = "";
        public string LblRemarkpara22
        {
            get { return lblRemarkpara22; }
            set
            {
                lblRemarkpara22 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara22");
            }
        }
        private string lblRemarkpara23 = "";
        public string LblRemarkpara23
        {
            get { return lblRemarkpara23; }
            set
            {
                lblRemarkpara23 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara23");
            }
        }
        private string lblRemarkpara24 = "";
        public string LblRemarkpara24
        {
            get { return lblRemarkpara24; }
            set
            {
                lblRemarkpara24 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara24");
            }
        }
        private string lblRemarkpara25 = "";
        public string LblRemarkpara25
        {
            get { return lblRemarkpara25; }
            set
            {
                lblRemarkpara25 = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRemarkpara24");
            }
        }
        private string lblDisclimerpara = "";
        public string LblDisclimerpara
        {
            get { return lblDisclimerpara; }
            set
            {
                lblDisclimerpara = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDisclimerpara");
            }
        }
        private string LblSAR = "";


        //2023-02-11
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
        //To Declare Indicator
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                ButtonCancel.ChangeCanExecute();
                Buttonsubmit.ChangeCanExecute();
                PDFprint.ChangeCanExecute();
            }
        }
        public Command PDFprint { get; set; }

        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        /// <param name="fstrTypeofCargo"></param>
        /// <param name="fstrCategoryofCargo"></param>
        /// <param name="fstrWeight"></param>
        /// <param name="fstrLength"></param>
        /// <param name="fstrWidth"></param>
        /// <param name="fstrHeight"></param>
        /// <param name="fstrDGCargo"></param>
        /// <param name="fstrDGaddlch"></param>
        public BreakBulk_PriceCalculationViewModel(string fstrTypeofCargo, string fstrCategoryofCargo, string fstrWeight, string fstrLength, string fstrWidth, string fstrHeight, string fstrDGCargo, string fstrDGaddlch)
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("BreakBulk_PriceCalculationViewModel");
                //To Call Caption Function 
                Task.Run(() => assignCms()).Wait();
                //Begin-All Command Buttons
                ButtonCancel = new Command(async () => await buttonCancel(), () => !IsBusy);
                Buttonsubmit = new Command(async () => await buttonsubmit(fstrTypeofCargo, fstrCategoryofCargo, fstrWeight, fstrLength, fstrWidth, fstrHeight, fstrDGCargo, fstrDGaddlch), () => !IsBusy);

                PDFprint = new Command(async () => await openPdf(), () => !IsBusy);

                //End-All Command Buttons
                lblValCargoType = fstrTypeofCargo;
                lblValCategory = fstrCategoryofCargo;
                lblValWeight = fstrWeight;
                lblValLength = fstrLength;
                lblValWidth = fstrWidth;
                lblValHeight = fstrHeight;
                TxtYesNo = fstrDGCargo;

                Task.Run(() => BreakbulkrequestPriceCalc()).Wait();
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To open PDF
        /// </summary>
        /// <returns></returns>
        private async Task openPdf()
        {
             IsBusy = true;
            StackBreakBulkPriceCal = false;
            string lstrLang = "0";
            if (App.gblLanguage == "Ar")
            {
                lstrLang = "1";
            }
            string strURL = AppSettings.MobWebUrl;



            string strValDGAddlCharge = "0";
            string strBASECOST= "0";
            if (TxtYesNo == "Yes")
            {
                strValDGAddlCharge = strAddlchargecalculate;
                
            }
           
            //Base Cost
            if (lblValCategory == "Import")
            {
                strBASECOST = strOOGImport;
               
            }

            if (lblValCategory == "Export")
            {
                strBASECOST = strOOGExport;
               
            }

            if (lblValCategory == "Transshipment")
            {
                strBASECOST = strOOGTransshipment;
               
            }

            if (lblValCargoType == "Breakbulk") lblValCargoType = "BreakBulk";

             var pdfUrl = strURL + "/OOGBreakBulkRequest/OpenPDF?" + "fstrTYPEOFCARGO=" + lblValCargoType + "&fstrCATEGORYOFCARGO=" + lblValCategory + "&fstrOVERLENGTH=" + lblValLength + "&fstrOVERWIDTH=" + lblValWidth + "&fstrOVERHEIGHT=" + lblValHeight + "&fstrWEIGHT=" + lblValWeight + "&fstrDANGEROUSCARGO=" + TxtYesNo + "&fstrBASECOST=" + strBASECOST + "&fstrDGADDLCHARGE=" + strValDGAddlCharge + "&fstrLang=" + lstrLang + "";

           App.Current.MainPage?.DisplayToastAsync("Pdf file is opening. Please wait", 3000);

            await Task.Delay(1000);
            await Browser.OpenAsync(pdfUrl, BrowserLaunchMode.SystemPreferred);
            IsBusy = false;
            StackBreakBulkPriceCal = true;
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

                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM461");

                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// //To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
            
            
            ImgOOGbreakbulkiconblue = dbLayer.getCaption("imgOOGbreakbulkiconbluepng", objCMS);
            LblOOGBreakbulkRequest = dbLayer.getCaption("strOOGBreakbulkRequest", objCMS);
            ImgRequesticondarkblue = dbLayer.getCaption("imgrequesticondarkbluepng", objCMS);
            LblBBPriceCalculation = dbLayer.getCaption("strBreakbulkPrelimPriceCalculation", objCMS);
            LblTypeofCargo = dbLayer.getCaption("strPriceTypeCargo", objCMS);
            LblCategoryofCargo = dbLayer.getCaption("strPriceCategoryCargo", objCMS);
            LblCargoSizeDimension = dbLayer.getCaption("strPriceCargoSizeDimension", objCMS);
            LblCargoLengthcm = dbLayer.getCaption("strCargoLengthcm", objCMS);
            LblCargoLengthm = dbLayer.getCaption("strCargoLengthm", objCMS);
            LblCargoWidthcm = dbLayer.getCaption("strCargoWidthcm", objCMS);
            LblCargoWidthm = dbLayer.getCaption("strCargoWidthm", objCMS);
            LblCargoHeighcm = dbLayer.getCaption("strCargoHeightcm", objCMS);
            LblCargoHeightm = dbLayer.getCaption("strCargoHeightm", objCMS);
            LblCargoTotalDimincm = dbLayer.getCaption("strCargoTotalDimensionscm", objCMS);
            LblCargoTotalDiminm = dbLayer.getCaption("strCargoTotalDimensionsm", objCMS);
            LblWeight = dbLayer.getCaption("strPriceWeight", objCMS);
            LblWeightinkg = dbLayer.getCaption("strWeightinkg", objCMS);
            LblWeightinTon = dbLayer.getCaption("strWeightinTon", objCMS);
            LblIsitDangerCargo = dbLayer.getCaption("strPriceDangerousCargo", objCMS);
            LblBaseCost = dbLayer.getCaption("strPriceBaseCost", objCMS);
            LblDGAddlCharge = dbLayer.getCaption("strDGAddlCharge", objCMS);
            LblDGAddlCost = dbLayer.getCaption("strDGAddlCost", objCMS);
            LblUnitCost = dbLayer.getCaption("strUnitCost", objCMS);
            LblTotalDimension = dbLayer.getCaption("strTotaldimension", objCMS);
            LblTotalCost = dbLayer.getCaption("strTotalCost", objCMS);
            LblRemarks = dbLayer.getCaption("strRemarks", objCMS);
            LblDisclaimer = dbLayer.getCaption("strDisclaimer", objCMS);
            BtnCancel = dbLayer.getCaption("strCancel", objCMS);
            BtnConfirm = dbLayer.getCaption("strConfirm", objCMS);
            Imgpdficon = dbLayer.getCaption("imgpdficonpng", objCMS);
            BtnPrintPDF = dbLayer.getCaption("strPrintPDF", objCMS);

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

            lobjOogBreakBulkrequest = dbLayer.getEnum("strOOGRequestLov", objCMS);

            LblRemarkpara = dbLayer.getCaption("strBreakbulkPara", objCMS);
            LblRemarkpara2 = dbLayer.getCaption("strBreakbulkPara1", objCMS);
            LblRemarkpara3 = dbLayer.getCaption("strBreakbulkPara2", objCMS);
            LblRemarkpara4 = dbLayer.getCaption("strBreakbulkPara3", objCMS);
            LblRemarkpara5 = dbLayer.getCaption("strBreakbulkPara4", objCMS);
            LblRemarkpara6 = dbLayer.getCaption("strBreakbulkPara5", objCMS);
            LblRemarkpara7 = dbLayer.getCaption("strBreakbulkPara6", objCMS);
            LblRemarkpara8 = dbLayer.getCaption("strBreakbulkPara7", objCMS);
            LblRemarkpara9 = dbLayer.getCaption("strBreakbulkPara8", objCMS);
            LblRemarkpara10 = dbLayer.getCaption("strBreakbulkPara9", objCMS);
            LblRemarkpara11 = dbLayer.getCaption("strBreakbulkPara10", objCMS);
            LblRemarkpara12 = dbLayer.getCaption("strBreakbulkPara11", objCMS);
            LblRemarkpara13 = dbLayer.getCaption("strBreakbulkPara12", objCMS);
            LblRemarkpara14 = dbLayer.getCaption("strBreakbulkPara13", objCMS);
            LblRemarkpara15 = dbLayer.getCaption("strBreakbulkPara14", objCMS);
            LblRemarkpara16 = dbLayer.getCaption("strBreakbulkPara15", objCMS);
            LblRemarkpara17 = dbLayer.getCaption("strBreakbulkPara16", objCMS);
            LblRemarkpara18 = dbLayer.getCaption("strBreakbulkPara17", objCMS);
            LblRemarkpara19 = dbLayer.getCaption("strBreakbulkPara18", objCMS);
            LblRemarkpara20 = dbLayer.getCaption("strBreakbulkPara19", objCMS);
            LblRemarkpara21 = dbLayer.getCaption("strBreakbulkPara20", objCMS);
            LblRemarkpara22 = dbLayer.getCaption("strBreakbulkPara21", objCMS);
            LblRemarkpara23 = dbLayer.getCaption("strBreakbulkPara22", objCMS);
            LblRemarkpara24 = dbLayer.getCaption("strBreakbulkPara23", objCMS);
            LblRemarkpara25 = dbLayer.getCaption("strBreakbulkPara24", objCMS);
            LblDisclimerpara = dbLayer.getCaption("strBreakbulkPara25", objCMS);

            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);

            LblSAR = dbLayer.getCaption("strSAR", objCMS);
        }
        /// <summary>
        /// Function For submit button
        /// </summary>
        /// <param name="TypeofCargo"></param>
        /// <param name="CategoryofCargo"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="DGCargo"></param>
        /// <param name="DGAddlCharge"></param>
        /// <returns></returns>
        private async Task buttonsubmit(string TypeofCargo, string CategoryofCargo, string Weight, string Length, string Width, string Height, string DGCargo, string DGAddlCharge)
        {
            IsBusy = true;
            StackBreakBulkPriceCal = false;
            await Task.Delay(1000);
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
                    string lstrCT_CASEGKEY = "";
                    string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
                    string lstrCT_USERNAME = gblRegisteration.strLoginUser.ToString().Trim();
                    string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string lstrCT_TITLE = "";
                    string lstrCT_MESSAGE = "";

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

                    lstrCT_TITLE = "OOG Break Bulk Request";

                    lstrCT_MESSAGE = "Type of Cargo:" + TypeofCargo + "; Category of Cargo: " + CategoryofCargo + "; Length (M) :" + TxtCargoLengthm + "; Width (M) :";
                    lstrCT_MESSAGE += " " + TxtCargoWidthm + "; Height (M)" + TxtCargoHeightm + "; Weight (Ton) :" + TxtWeightinTon + ";";
                    lstrCT_MESSAGE += " Base Cost:" + BaseCostVal + "; DG Addl Charge :" + TxtValDGAddlCharge + ";";
                    lstrCT_MESSAGE += " DG Addl Cost:" + TxtDGAddlCost + "; Unit Cost :" + TxtUnitCost + ";";
                    lstrCT_MESSAGE += " Total Dimension:" + TxtCargoTotalDiminm + "; Total Cost :" + TxtTotalCost + ";";


                    string lstrCT_TYPEOFCARGO = TypeofCargo;
                    string lstrCT_CATEGORYOFCARGO = CategoryofCargo;
                    string lstrCT_OVERLENGTH = Length;
                    string lstrCT_OVERWIDTH = Width;
                    string lstrCT_OVERHEIGHT = Height;
                    string lstrCT_WEIGHT = Weight;
                    string lstrCT_DANGEROUSCARGO = TxtYesNo;
                    string lstrCT_BASECOST = BaseCostVal;
                    string lstrCT_DGADDLCHARGE = TxtValDGAddlCharge.ToString();

                    lstrResult = objBl.OOGRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference, lstrCT_TYPEOFCARGO, lstrCT_CATEGORYOFCARGO, lstrCT_OVERLENGTH, lstrCT_OVERWIDTH, lstrCT_OVERHEIGHT, lstrCT_WEIGHT, lstrCT_DANGEROUSCARGO, lstrCT_BASECOST, lstrCT_DGADDLCHARGE);
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    if (clsOOGPhotos.strFileBody != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody2 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName2;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType2;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody2;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody3 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName3;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType3;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody3;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody4 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName4;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType4;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody4;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody5 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName5;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType5;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody5;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody6 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName6;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType6;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody6;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody7 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName7;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType7;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody7;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody8 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName8;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType8;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody8;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody9 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName9;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType9;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody9;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                    }
                    if (clsOOGPhotos.strFileBody10 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName10;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType10;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody10;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
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
            StackBreakBulkPriceCal = true;
            IsBusy = false;
        }
        /// <summary>
        /// Breakbulk price calculation Function
        /// </summary>
        /// <returns></returns>
        private async Task BreakbulkrequestPriceCalc()
        {

            await Task.Delay(2000);

            OogBreakBulkRequestModel objBreakbulkCalc = new OogBreakBulkRequestModel();

            //Length
            TxtCargoLengthcm = Convert.ToDouble(lblValLength);
           

            TxtCargoHeightcm = Convert.ToDouble(lblValHeight);
           

            TxtCargoWidthcm = Convert.ToDouble(lblValWidth);
           

            TxtCargoLengthm = objBreakbulkCalc.Centimeter2Meter(TxtCargoLengthcm);
           

            TxtCargoHeightm = objBreakbulkCalc.Centimeter2Meter(TxtCargoHeightcm);
           
            TxtCargoWidthm = objBreakbulkCalc.Centimeter2Meter(TxtCargoWidthcm);
            
            TxtCargoTotalDiminm = objBreakbulkCalc.TotalDimentionM(TxtCargoLengthm, TxtCargoHeightm, TxtCargoWidthm);
           
            TxtTotalDimension = objBreakbulkCalc.TotalDimentionCm(TxtCargoLengthcm, TxtCargoHeightcm, TxtCargoWidthcm);
            
            //Weight Convert to Tonne
            //Qty Calc
            double dblweightkg = Convert.ToDouble(lblValWeight);
            TxtWeightinTon = objBreakbulkCalc.WeightTon(dblweightkg);

            //Dangerous Cargo
            TxtValDGAddlCharge = 0;
            strValDGAddlCharge = 0.ToString();
            if (TxtYesNo == "Yes")
            {
                TxtValDGAddlCharge = Convert.ToDouble(strAddlchargecalculate);              
            }

            strValDGAddlCharge = TxtValDGAddlCharge + "%";
            TxtDGAddlCharge = Convert.ToDouble(TxtValDGAddlCharge) / 100;

            //Base Cost
            if (lblValCategory == "Import")
            {
                TxtBaseCost = Convert.ToDouble(strOOGImport);               
            }

            if (lblValCategory == "Export")
            {
                TxtBaseCost = Convert.ToDouble(strOOGExport);                
            }

            if (lblValCategory == "Transshipment")
            {
                TxtBaseCost = Convert.ToDouble(strOOGTransshipment);               
            }

            strBasecost = LblSAR + Decimal.Parse(TxtBaseCost.ToString()).ToString("#,##0.00");

            //DG Addl Cost = Base Cost * Dg Addl Charge
            TxtDGAddlCost = objBreakbulkCalc.DGAddlCost(TxtBaseCost, TxtDGAddlCharge);
            strDGAddlCost = LblSAR + Decimal.Parse(TxtDGAddlCost.ToString()).ToString("#,##0.00");

            //Unit Cost = Base Cost + DG Addl Charge
            TxtUnitCost = objBreakbulkCalc.Unitcost(TxtBaseCost, TxtDGAddlCost);
            strUnitCost = LblSAR + Decimal.Parse(TxtUnitCost.ToString()).ToString("#,##0.00");

            //Total Cost = Unit Cost * Qty
            TxtTotalCost = objBreakbulkCalc.Totalcost(TxtUnitCost, TxtCargoTotalDiminm);
            strTotalcost = LblSAR + Decimal.Parse(TxtTotalCost.ToString()).ToString("#,##0.00");


        }
        /// <summary>
        /// To get button cancel Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel()
        {
            IsBusy = true;
            StackBreakBulkPriceCal = false;
            await Task.Delay(1000);
            await Shell.Current.GoToAsync("..");
           // App.Current.MainPage?.Navigation.PushAsync(new OogBreakBulkRequest());
            StackBreakBulkPriceCal = true;
            IsBusy = false;
        }

        [Obsolete]
        public System.Windows.Input.ICommand MyPdftapcont => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
    }
}