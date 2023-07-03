using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class OogBreakBulkRequestModel
    {
        //20230206OOG-Modifications_Final
        //        ix.Notes:
        //1.	Base Cost = Cost per Meter for the selected container category picked from CMS
        //2.	DG Addl Charge = Base Cost * Damage Goods charge % picked from CMS
        //a.Do this calculation only if Dangerous goods option is selected.
        //3.	Total Dimensions = (Length / 100) * (Width / 100) * (Height / 100)
        //4.	Unit Cost = Base Cost + DG Addl Charge
        //5.	Total Cost = Unit Cost* Total Dimensions

        //Convert Width Cm to M
        public double Centimeter2Meter(double dbltxtVal)
        {
            double dblVal = 0;
            dblVal = Convert.ToDouble(dbltxtVal / 100);
            return dblVal;
        }

        //Total dimention in Cm = Length(cm) * Height(cm) * Width (cm)
        public double TotalDimentionCm(double txtCargoLengthCmVal, double txtCargoHeightCmVal, double txtCargoWidthCmVal)
        {
            double dblVal = 0;
            dblVal = (txtCargoLengthCmVal) + (txtCargoHeightCmVal) + (txtCargoWidthCmVal);
            return dblVal;
        }

        //Total dimention in M = Length(M) * Height(M) * Width (M)
        public double TotalDimentionM(double txtCargoLengthMVal, double txtCargoHeightMVal, double txtCargoWidthMVal)
        {
            double dblVal = 0;
            dblVal = (txtCargoLengthMVal) * (txtCargoHeightMVal) * (txtCargoWidthMVal);
            return dblVal;
        }

        //Weight(kg) to Tone = Weight(kg)/1000; (or) Qty value Find
        public double WeightTon(double txtCargoWeightKgVal)
        {
            double dblVal = 0;
            dblVal = (txtCargoWeightKgVal) / 1000;
            return dblVal;
        }

        //DG Addtional Cost = Base Cost * Damage Goods charge % picked from CMS -to be find
        public double DGAddlCost(double txtBasecostVal, double txtDGaddlchargesVal)
        {
            double dblVal = 0;
            dblVal = (txtBasecostVal) * (txtDGaddlchargesVal);
            return dblVal;
        }

        //Unit cost Find -- Base Cost + DG Addl Charge 
        public double Unitcost(double txtBasecostVal, double txtDGaddlchargesVal)
        {
            double dblVal = 0;
            dblVal = (txtBasecostVal) + (txtDGaddlchargesVal);
            return dblVal;
        }

        //Total dimentions to be find = (Length / 100) * (Width / 100) * (Height / 100)
        public double TotalDimention(double txtCargoLengthCmVal, double txtCargoHeightCmVal, double txtCargoWidthCmVal)
        {
            double dblVal = 0;
            dblVal = (txtCargoLengthCmVal / 100) * (txtCargoHeightCmVal / 100) * (txtCargoWidthCmVal / 100);
            return dblVal;
        }

        //Total Cost to be find = Unit Cost* Total Dimensions
        public double Totalcost(double txtUnitcostVal, double txtTotalDimentionVal)
        {
            double dblVal = 0;
            dblVal = (txtUnitcostVal) * (txtTotalDimentionVal);
            return dblVal;
        }

    }
}