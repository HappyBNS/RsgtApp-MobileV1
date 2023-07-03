using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class OOGCalcuationModel
    {

        public static class clsOOGPhotos
        {
            //Assign Static Variables
            public static string strFileName = "";
            public static string strFileType = "";
            public static string strFileBody = "";
            //Assign Static Variables2
            public static string strFileName2 = "";
            public static string strFileType2 = "";
            public static string strFileBody2 = "";
            //Assign Static Variables3
            public static string strFileName3 = "";
            public static string strFileType3 = "";
            public static string strFileBody3 = "";
            //Assign Static Variables4
            public static string strFileName4 = "";
            public static string strFileType4 = "";
            public static string strFileBody4 = "";
            //Assign Static Variables5
            public static string strFileName5 = "";
            public static string strFileType5 = "";
            public static string strFileBody5 = "";
            //Assign Static Variables6
            public static string strFileName6 = "";
            public static string strFileType6 = "";
            public static string strFileBody6 = "";
            //Assign Static Variables7
            public static string strFileName7 = "";
            public static string strFileType7 = "";
            public static string strFileBody7 = "";
            //Assign Static Variables8
            public static string strFileName8 = "";
            public static string strFileType8 = "";
            public static string strFileBody8 = "";
            //Assign Static Variables9
            public static string strFileName9 = "";
            public static string strFileType9 = "";
            public static string strFileBody9 = "";
            //Assign Static Variables10
            public static string strFileName10 = "";
            public static string strFileType10 = "";
            public static string strFileBody10 = "";
        }
        //20230206OOG-Modifications_Final
        //        ix.Notes:
        //1.	Base Cost = Cost per Tonne for the selected container category picked from CMS
        //2.	DG Addl Charge = Base Cost *  Damage Goods charge % picked from CMS.
        //a.Do this calculation only if Dangerous goods option is selected.
        //3.	Qty = Weight(User Input) / 1000
        //4.	Unit Cost = Base Cost + DG Addl Charge
        //5.	Total Cost = Unit Cost* Qty
        //6.	Query to RSGT: Shall we round up the qty or leave it with fractions?

        //Convert Width Cm to M
        public double Centimeter2Meter(double dbltxtVal)
        {
            double dblVal = 0;
            dblVal = Convert.ToDouble(dbltxtVal / 100);
            return dblVal;
        }

        //Total Dimension (CM) = Length + Width + Height
        //Total Dimentional for CentiMeter
        public double TotalDimention(double txtCargoLengthmVal, double txtCargoHeightmVal, double txtCargoWidthMVal)
        {
            double dblVal = 0;
            dblVal = txtCargoLengthmVal + txtCargoHeightmVal + txtCargoWidthMVal;
            return dblVal;
        }
        //2023-02-21-Sanduru
        //Total Dimension in Meter
        //Total Dimension (CM) = Length * Width * Height
        public double TotalDimentionM(double txtCargoLengthmVal, double txtCargoHeightmVal, double txtCargoWidthMVal)
        {
            double dblVal = 0;
            dblVal = txtCargoLengthmVal * txtCargoHeightmVal * txtCargoWidthMVal;
            return dblVal;
        }
        //Weight Convert to Tonne
        //Qty Calc
        public double WeightTon(double txtCargoWeightKGVal)
        {
            double dblVal = 0;
            dblVal = txtCargoWeightKGVal / 1000;
            return dblVal;
        }
        //DG Addl Cost = Base Cost * Dg Addl Charge
        public double DGaddlCost(double BaseCostVal, double DGAddlChargeValcalc)
        {
            double dblVal = 0;
            //DG Addl Charge  find
            dblVal = (BaseCostVal) * (DGAddlChargeValcalc);
            return dblVal;
        }
        // Unit Cost = Base Cost + DG Addl Charge
        public double UnitCost(double BaseCostVal, double DGAddlCostValcalc)
        {
            double dblVal = 0;
            //Unit cost find
            dblVal = BaseCostVal + DGAddlCostValcalc;
            return dblVal;
        }

        //Total Cost = Unit Cost * Qty
        public double TotalCost(double UnitCostVal, double Qty)
        {
            double dblVal = 0;
            //Total cost Find
            dblVal = (UnitCostVal) * (Qty);
            return dblVal;
        }
    }
}
