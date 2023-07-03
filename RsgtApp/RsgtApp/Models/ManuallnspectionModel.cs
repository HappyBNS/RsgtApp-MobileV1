using System;
using System.Collections.Generic;
using System.Text;
namespace RsgtApp.Models
{
    public class ManuallnspectionModel
    {
        //Begin ManualInspectionDt ListView Model 
        public class ManualInspectionDt
        {
            public string Sno { get; set; }
            public string ContainerNo { get; set; }
            public string ContainerUnitGKey { get; set; }
            public string Size { get; set; }
            public string Bayan { get; set; }
            public string BOL { get; set; }
            public string Carrier { get; set; }
            public string Vessel { get; set; }
            public string Voyage { get; set; }
            public string Category { get; set; }
            public string Freightkind { get; set; }
            public string POL { get; set; }
            public string POD { get; set; }
            public string Status { get; set; }
            public string statuscode { get; set; }
            public string IsChekedflag { get; set; }
            public string StatusColor { get; set; }
            public bool IsCheked { get; set; }
            public string lblListContainers { get; set; }
            public string TimeIn { get; set; }
            public string lblSno { get; set; }
            public string lblStatus { get; set; }
            public string lblContainerNo { get; set; }
            public string lblSize { get; set; }
            public string lblBayan { get; set; }
            public string lblBOL { get; set; }
            public string lblCarrier { get; set; }
            public string lblVessel { get; set; }
            public string lblVoyage { get; set; }
            public string lblCategory { get; set; }
            public string lblPOL { get; set; }
            public string lblPOD { get; set; }
            public string lblFreightkind { get; set; }
            public string lblTimeIn { get; set; }
            public string lblDischargedOn { get; set; }
            public string lblGatedOutOn { get; set; }
        }
        //End ManualInspectionDt ListView Model 
        //Begin ManualInspectionFilterDlList Filter Model 
        public class ManualInspectionFilterDlList
        {
            public string CmbSize { get; set; }
            public string CmbCarrier { get; set; }
            public string CmbCategory { get; set; }
            public string CmbFreightkind { get; set; }
            public string CmbPol { get; set; }
            public string CmbPod { get; set; }
            public bool isChecked { get; set; }
        }
        //Begin ManualInspectionFilterDlList Filter Model 
    }
}
