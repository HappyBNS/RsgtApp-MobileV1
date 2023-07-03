
using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using static RsgtApp.Models.OOGCalcuationModel;


namespace RsgtApp.ViewModels
{
    public class OOG_PriceCalculationViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        public List<EnumCombo> lobjOogBreakBulkrequest { get; set; } = new List<EnumCombo>();
        public Command ButtonCancel { get; set; }
        public Command Buttonsubmit { get; set; }
        private string strServerSlowMsg = "";
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
        private bool stackOOGPriceCal = true;
        public bool StackOOGPriceCal
        {
            get { return stackOOGPriceCal; }
            set
            {
                stackOOGPriceCal = value;
                OnPropertyChanged();
                RaisePropertyChange("StackOOGPriceCal");
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
        private string lblOOGPriceCalculation = "";
        public string LblOOGPriceCalculation
        {
            get { return lblOOGPriceCalculation; }
            set
            {
                lblOOGPriceCalculation = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOOGPriceCalculation");
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
        private string lblOverLengthcm = "";
        public string LblOverLengthcm
        {
            get { return lblOverLengthcm; }
            set
            {
                lblOverLengthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOverLengthcm");
            }
        }
        private double txtOverLengthcm = 0;
        public double TxtOverLengthcm
        {
            get { return txtOverLengthcm; }
            set
            {
                txtOverLengthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOverLengthcm");
            }
        }
        private string lblOverLengthm = "";
        public string LblOverLengthm
        {
            get { return lblOverLengthm; }
            set
            {
                lblOverLengthm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOverLengthm");
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
        private string lblOverWidthcm = "";
        public string LblOverWidthcm
        {
            get { return lblOverWidthcm; }
            set
            {
                lblOverWidthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOverWidthcm");
            }
        }
        private double txtOverWidthcm = 0;
        public double TxtOverWidthcm
        {
            get { return txtOverWidthcm; }
            set
            {
                txtOverWidthcm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOverWidthcm");
            }
        }
        private string lblOverWidthm = "";
        public string LblOverWidthm
        {
            get { return lblOverWidthm; }
            set
            {
                lblOverWidthm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOverWidthm");
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
        private string lblOverHeightcm = "";
        public string LblOverHeightcm
        {
            get { return lblOverHeightcm; }
            set
            {
                lblOverHeightcm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOverHeightcm");
            }
        }
        private double txtOverHeightcm = 0;
        public double TxtOverHeightcm
        {
            get { return txtOverHeightcm; }
            set
            {
                txtOverHeightcm = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOverHeightcm");
            }
        }
        private string lblOverHeightm = "";
        public string LblOverHeightm
        {
            get { return lblOverHeightm; }
            set
            {
                lblOverHeightm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblOverHeightm");
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
        private string lblTotalDimensionsincm = "";
        public string LblTotalDimensionsincm
        {
            get { return lblTotalDimensionsincm; }
            set
            {
                lblTotalDimensionsincm = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTotalDimensionsincm");
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
        private string lblTotalDiminmeters = "";
        public string LblTotalDiminmeters
        {
            get { return lblTotalDiminmeters; }
            set
            {
                lblTotalDiminmeters = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTotalDiminmeters");
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

        private string strDGAddlCost = "";
        public string strTxtDGAddlCost
        {
            get { return strDGAddlCost; }
            set
            {
                strDGAddlCost = value;
                OnPropertyChanged();
                RaisePropertyChange("strTxtDGAddlCost");
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
        private string lblQty = "";
        public string LblQty
        {
            get { return lblQty; }
            set
            {
                lblQty = value;
                OnPropertyChanged();
                RaisePropertyChange("LblQty");
            }
        }
        private double txtQty = 0;
        public double TxtQty
        {
            get { return txtQty; }
            set
            {
                txtQty = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtQty");
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

        //lblSar purpose of using Label
        private string lblSar = "";
        public string LblSar
        {
            get { return lblSar; }
            set
            {
                lblSar = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSar");
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
        //strbasecost purpose of using Label
        private string strbasecost = "";
        public string strbaseCost
        {
            get { return strbasecost; }
            set
            {
                strbasecost = value;
                OnPropertyChanged();
                RaisePropertyChange("strbaseCost");
            }
        }
        //strbasecost purpose of using Label
        private string strunitCost = "";
        public string StrUnitCost
        {
            get { return strunitCost; }
            set
            {
                strunitCost = value;
                OnPropertyChanged();
                RaisePropertyChange("StrUnitCost");
            }
        }
        public string strSAR { get; set; }

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

        public string LblSAR = "";

        /// <summary>
        /// Begin-ViewModel Constructor TypeofCargo, CategoryofCargo, Length, Width, Height, Weight, TxtYesNo, BaseCostVal, TxtDGAddlCharge
        /// </summary>
        /// <param name="fstrTypeofCargo"></param>
        /// <param name="fstrCategoryofCargo"></param>
        /// <param name="fstrWeight"></param>
        /// <param name="fstrLength"></param>
        /// <param name="fstrWidth"></param>
        /// <param name="fstrHeight"></param>
        /// <param name="fstrChkDGCargo"></param>
        public OOG_PriceCalculationViewModel(string fstrTypeofCargo, string fstrCategoryofCargo, string fstrWeight, string fstrLength, string fstrWidth, string fstrHeight, string fstrChkDGCargo)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("OOG_PriceCalculationViewModel");
            //To Call Caption Function 
            Task.Run(() => assignCms()).Wait();
            //Begin-All Command Buttons
            ButtonCancel = new Command(async () => await buttonCancel(), () => !IsBusy);
            Buttonsubmit = new Command(async () => await buttonsubmit(fstrTypeofCargo, fstrCategoryofCargo, fstrWeight, fstrLength, fstrWidth, fstrHeight), () => !IsBusy);
            PDFprint = new Command(async () => await openPdf(), () => !IsBusy);
            //End-All Command Buttons
            lblValCargoType = fstrTypeofCargo;
            lblValCategory = fstrCategoryofCargo;
            lblValWeight = fstrWeight;
            lblValLength = fstrLength;
            lblValWidth = fstrWidth;
            lblValHeight = fstrHeight;
            TxtYesNo = fstrChkDGCargo;

            Task.Run(() => OOGPriceCalc(fstrTypeofCargo, fstrCategoryofCargo, fstrWeight, fstrLength, fstrWidth, fstrHeight, fstrChkDGCargo)).Wait();
        }
        //End-ViewModel Constructor
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        /// <returns></returns>
        private async Task openPdf()
        {
            IsBusy = true;
            StackOOGPriceCal = false;
            string lstrLang = "0";
            if (App.gblLanguage == "Ar")
            {
                lstrLang = "1";
            }
            string strURL = AppSettings.MobWebUrl;



            string strValDGAddlCharge = "0";
            string strBASECOST = "0";
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

            var pdfUrl = strURL + "/OOGBreakBulkRequest/OpenPDF?" + "fstrTYPEOFCARGO=" + lblValCargoType + "&fstrCATEGORYOFCARGO=" + lblValCategory + "&fstrOVERLENGTH=" + lblValLength + "&fstrOVERWIDTH=" + lblValWidth + "&fstrOVERHEIGHT=" + lblValHeight + "&fstrWEIGHT=" + lblValWeight + "&fstrDANGEROUSCARGO=" + TxtYesNo + "&fstrBASECOST=" + strBASECOST + "&fstrDGADDLCHARGE=" + strValDGAddlCharge + "&fstrLang=" + lstrLang + "";

           App.Current.MainPage?.DisplayToastAsync("Pdf file is opening. Please wait", 3000);

            await Task.Delay(1000);
            await Browser.OpenAsync(pdfUrl, BrowserLaunchMode.SystemPreferred);
            IsBusy = false;
            StackOOGPriceCal = true;
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
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //To assign CMS Content respect Captions
        public async void assignContent()
        {
            try
            {


                await Task.Delay(1000);
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
                ImgOOGbreakbulkiconblue = dbLayer.getCaption("imgOOGbreakbulkiconbluepng", objCMS);
                LblOOGBreakbulkRequest = dbLayer.getCaption("strOOGBreakbulkRequest", objCMS);
                ImgRequesticondarkblue = dbLayer.getCaption("imgrequesticondarkbluepng", objCMS);
                LblOOGPriceCalculation = dbLayer.getCaption("strOOGPrelimPriceCalculation", objCMS);
                LblTypeofCargo = dbLayer.getCaption("strPriceTypeCargo", objCMS);
                LblCategoryofCargo = dbLayer.getCaption("strPriceCategoryCargo", objCMS);
                LblCargoSizeDimension = dbLayer.getCaption("strPriceCargoSizeDimension", objCMS);
                LblOverLengthcm = dbLayer.getCaption("strOverLengthcm", objCMS);
                LblOverLengthm = dbLayer.getCaption("strOverLengthm", objCMS);
                LblOverWidthcm = dbLayer.getCaption("strOverWidthcm", objCMS);
                LblOverWidthm = dbLayer.getCaption("strOverWidthm", objCMS);
                LblOverHeightcm = dbLayer.getCaption("strOverHeightcm", objCMS);
                LblOverHeightm = dbLayer.getCaption("strOverHeightm", objCMS);
                LblTotalDimensionsincm = dbLayer.getCaption("strCargoTotalDimensionscm", objCMS);
                LblTotalDiminmeters = dbLayer.getCaption("strCargoTotalDimensionsm", objCMS);
                LblWeight = dbLayer.getCaption("strPriceWeight", objCMS);
                LblWeightinkg = dbLayer.getCaption("strWeightinkg", objCMS);
                LblWeightinTon = dbLayer.getCaption("strWeightinTon", objCMS);
                LblIsitDangerCargo = dbLayer.getCaption("strPriceDangerousCargo", objCMS);
                LblBaseCost = dbLayer.getCaption("strPriceBaseCost", objCMS);
                LblDGAddlCharge = dbLayer.getCaption("strDGAddlCharge", objCMS);
                LblDGAddlCost = dbLayer.getCaption("strDGAddlCost", objCMS);
                LblUnitCost = dbLayer.getCaption("strUnitCost", objCMS);
                LblQty = dbLayer.getCaption("strQty", objCMS);
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


                LblRemarkpara = dbLayer.getCaption("strOOGPricePara", objCMS);
                LblRemarkpara2 = dbLayer.getCaption("strOOGPricePara1", objCMS);
                LblRemarkpara3 = dbLayer.getCaption("strOOGPricePara2", objCMS);
                LblRemarkpara4 = dbLayer.getCaption("strOOGPricePara3", objCMS);
                LblRemarkpara5 = dbLayer.getCaption("strOOGPricePara4", objCMS);
                LblRemarkpara6 = dbLayer.getCaption("strOOGPricePara5", objCMS);
                LblRemarkpara7 = dbLayer.getCaption("strOOGPricePara6", objCMS);
                LblRemarkpara8 = dbLayer.getCaption("strOpsRequirments", objCMS);
                LblRemarkpara9 = dbLayer.getCaption("strGeneralRequirements", objCMS);
                LblRemarkpara10 = dbLayer.getCaption("strOOGPricePara7", objCMS);
                LblRemarkpara11 = dbLayer.getCaption("strOOGPricePara8", objCMS);
                LblRemarkpara12 = dbLayer.getCaption("strOOGPricePara9", objCMS);
                LblRemarkpara13 = dbLayer.getCaption("strOOGPricePara10", objCMS);
                LblRemarkpara14 = dbLayer.getCaption("strOOGPricePara11", objCMS);
                LblRemarkpara15 = dbLayer.getCaption("strOOGPricePara12", objCMS);
                LblRemarkpara16 = dbLayer.getCaption("strOOGPricePara13", objCMS);
                LblRemarkpara17 = dbLayer.getCaption("strOOGPricePara14", objCMS);

                LblDisclimerpara = dbLayer.getCaption("strBreakbulkPara25", objCMS);
                lobjOogBreakBulkrequest = dbLayer.getEnum("strOOGRequestLov", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);

                LblSAR = dbLayer.getCaption("strSAR", objCMS);
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get OOG Price Calculation
        /// </summary>
        /// <param name="TypeofCargo"></param>
        /// <param name="CategoryofCargo"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="BaseCostVal"></param>
        /// <returns></returns>
        private async Task OOGPriceCalc(string TypeofCargo, string CategoryofCargo, string Weight, string Length, string Width, string Height, string BaseCostVal)
        {
            try
            {

                await Task.Delay(2000);
                OOGCalcuationModel objOOGCalc = new OOGCalcuationModel();


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

                strbaseCost = LblSAR + Decimal.Parse(TxtBaseCost.ToString()).ToString("#,##0.00");
                //20-02-2023-Sanduru
                TxtValDGAddlCharge = 0;
                strValDGAddlCharge = 0.ToString();
                if (TxtYesNo == "Yes")
                {
                    TxtValDGAddlCharge = Convert.ToDouble(strAddlchargecalculate);
                }


                strValDGAddlCharge = TxtValDGAddlCharge + "%";

                TxtDGAddlCharge = Convert.ToDouble(TxtValDGAddlCharge) / 100;

                //DG Addl Cost = Base Cost * Dg Addl Charge
                TxtDGAddlCost = objOOGCalc.DGaddlCost(TxtBaseCost, TxtDGAddlCharge);
                strTxtDGAddlCost = LblSAR + Decimal.Parse(TxtDGAddlCost.ToString()).ToString("#,##0.00");


                //Total Dimension (CM) = Length * Width * Height

                //Length
                TxtOverLengthcm = Convert.ToDouble(lblValLength);

                TxtOverHeightcm = Convert.ToDouble(lblValHeight);

                TxtOverWidthcm = Convert.ToDouble(lblValWidth);


                TxtOverLengthm = objOOGCalc.Centimeter2Meter(TxtOverLengthcm);

                TxtOverHeightm = objOOGCalc.Centimeter2Meter(TxtOverHeightcm);

                TxtOverWidthm = objOOGCalc.Centimeter2Meter(TxtOverWidthcm);

                TxtTotalDiminmeters = objOOGCalc.TotalDimentionM(TxtOverLengthm, TxtOverHeightm, TxtOverWidthm);


                TxtTotalDimensionsincm = objOOGCalc.TotalDimention(TxtOverLengthcm, TxtOverHeightcm, TxtOverWidthcm);

                // Unit Cost = Base Cost + DG Addl cost
                TxtUnitCost = objOOGCalc.UnitCost(TxtBaseCost, TxtDGAddlCost);
                StrUnitCost = LblSAR + Decimal.Parse(TxtUnitCost.ToString()).ToString("#,##0.00");
                //Weight Convert to Tonne
                //Qty Calc
                double dblweightkg = Convert.ToDouble(lblValWeight);
                TxtWeightinTon = objOOGCalc.WeightTon(dblweightkg);



                //Total Cost = Unit Cost * Qty
                TxtTotalCost = objOOGCalc.TotalCost(TxtUnitCost, TxtWeightinTon);
                strTotalcost = LblSAR + Decimal.Parse(TxtTotalCost.ToString()).ToString("#,##0.00");

            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To handle in OOG Value submit function
        /// </summary>
        /// <param name="TypeofCargo"></param>
        /// <param name="CategoryofCargo"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        private async Task buttonsubmit(string TypeofCargo, string CategoryofCargo, string Weight, string Length, string Width, string Height)
        {
            IsBusy = true;
            StackOOGPriceCal = false;
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

                        await OOGPriceCalc(TypeofCargo, CategoryofCargo, Weight, Length, Width, Height, BaseCostVal);

                        lstrCT_MESSAGE = "Type of Cargo:" + TypeofCargo + "; Category of Cargo: " + CategoryofCargo + "; Length (M) :" + TxtOverLengthm + "; Width (M) :";
                        lstrCT_MESSAGE += " " + TxtOverWidthm + "; Height (M)" + TxtOverHeightm + "; Weight (Ton) :" + TxtWeightinTon + ";";
                        lstrCT_MESSAGE += " Base Cost:" + BaseCostVal + "; DG Addl Charge :" + TxtValDGAddlCharge + ";";
                        lstrCT_MESSAGE += " DG Addl Cost:" + TxtDGAddlCost + "; Unit Cost :" + TxtUnitCost + ";";
                        lstrCT_MESSAGE += " Qty:" + TxtWeightinTon + "; Total Cost :" + TxtTotalCost + ";";
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

                    if (clsOOGPhotos.strFileBody != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody2 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName2;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType2;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody2;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody3 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName3;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType3;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody3;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody4 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName4;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType4;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody4;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody5 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName5;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType5;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody5;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody6 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName6;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType6;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody6;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody7 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName7;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType7;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody7;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody8 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName8;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType8;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody8;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody9 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName9;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType9;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody9;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
                    if (clsOOGPhotos.strFileBody10 != "")
                    {
                        gblTrackRequests.strFileName = clsOOGPhotos.strFileName10;
                        gblTrackRequests.strFileType = clsOOGPhotos.strFileType10;
                        gblTrackRequests.strFileBody = clsOOGPhotos.strFileBody10;
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    }
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
            StackOOGPriceCal = true;
            IsBusy = false;
        }
        /// <summary>
        /// To go to button Cancel
        /// </summary>
        /// <returns></returns>
        private async Task buttonCancel()
        {
            IsBusy = true;
            StackOOGPriceCal = false;
            await Task.Delay(1000);
            await Shell.Current.GoToAsync("..");
            //App.Current.MainPage?.Navigation.PushAsync(new OogBreakBulkRequest());
            StackOOGPriceCal = true;
            IsBusy = false;
        }
        /// <summary>
        /// To Using in Commmand Event
        /// </summary>
        [Obsolete]
        public System.Windows.Input.ICommand MyPdftapcont => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
    }
}