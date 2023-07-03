using System.Collections.Generic;

namespace RsgtApp.Models
{
    public class Manifest
    {
        public static int lintManifestSno { get; set; }
        public static List<ManifestContainerDt> lstManifest = new List<ManifestContainerDt>();
        public static List<ManifestContainerDt> lstSelectedManifest = new List<ManifestContainerDt>();
        public class ManifestContainerDt
        {
            public string vd_visitid { get; set; }
            public string vd_ibvoyage { get; set; }
            public string vd_obvoyage { get; set; }
            public string vd_serviceid { get; set; }
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_category { get; set; }
            public string cd_commodity { get; set; }
            public int CD_SNO { get; set; }
            public string cd_status { get; set; }
            public string cd_Notes { get; set; }
            public string lbl_ContainerNo { get; set; }
            public string lbl_BOL { get; set; }
            public string lbl_VesseNo { get; set; }
            public string lbl_VoyageNo { get; set; }
            public string lbl_ManifestDetails { get; set; }
            public string lbl_Status { get; set; }
            public string Btn_Delete { get; set; }
            public string Btn_Edit { get; set; }
        }
    }
}